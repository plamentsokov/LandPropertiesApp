using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using LandPropertiesApp.LandProperties.Dtos;
using LandPropertiesApp.Entities;
using LandPropertiesApp.Owners.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LandPropertiesApp.Mortgages.Dtos;

namespace LandPropertiesApp.LandProperties
{
    public class LandPropertyAppService : ApplicationService, ILandPropertyAppService
    {
        private readonly IRepository<LandProperty> _landPropertyRepository;
        private readonly IRepository<Owner> _ownerRepository;
        private readonly IRepository<Mortgage> _mortgageRepository;

        public LandPropertyAppService(IRepository<LandProperty> landPropertyRepository, IRepository<Owner> ownerRepository, IRepository<Mortgage> mortgageRepository)
        {
            _landPropertyRepository = landPropertyRepository;
            _ownerRepository = ownerRepository;
            _mortgageRepository = mortgageRepository;
        }

        public async Task<GetLandPropertyOutput> GetLandProperties()
        {
            GetLandPropertyOutput output = new GetLandPropertyOutput();

            try
            {
                output.LandPropertiesList = Mapper.Map<List<LandPropertyDto>>(await _landPropertyRepository.GetAllListAsync());
            }
            catch (Exception e)
            {                
                throw e;
            }            

            return output;
        }

        public async Task<GetLandPropertyOutput> GetLandProperty(GetLandPropertyInput input)
        {
            GetLandPropertyOutput output = new GetLandPropertyOutput();

            if (input.LandPropertyId > 0)
            {
                output.SingleLandProperty = Mapper.Map<LandPropertyDto>(await _landPropertyRepository.GetAsync(input.LandPropertyId));
            }
            else
            {
                output.SingleLandProperty = Mapper.Map<LandPropertyDto>(new LandProperty());
            }

            return output;
        }

        public void AddOrUpdate(UpdateLandPropertyInput input)
        {
            var config = new ConfigurationStore(new TypeMapFactory(), AutoMapper.Mappers.MapperRegistry.Mappers);
            var mapper = new MappingEngine(config);

            config.CreateMap<LandPropertyDto, LandProperty>().ConstructUsing(model =>
            {
                if (model.Id == 0)
                {
                    LandProperty toAdd = new LandProperty();
                    _landPropertyRepository.InsertAsync(toAdd);

                    return toAdd;
                }
                else
                {
                    return _landPropertyRepository.Get(model.Id);
                }                
            });

            config.CreateMap<LandPropertyOwnerDto, Owner>().ConstructUsing(model =>
            {
                return _ownerRepository.Get(model.Id);
            });

            config.CreateMap<MortgageDto, Mortgage>().ConstructUsing(model =>
            {
                if (model.MortgageIdentifier > 0 && model.Id == 0)
                {
                    Mortgage toAdd = new Mortgage();
                    _mortgageRepository.Insert(toAdd);

                    return toAdd;
                }
                else if (model.Id > 0)
                {
                    return _mortgageRepository.Get(model.Id);
                }
                else
                {
                    return null;
                }                
            }).ForMember(x => x.LandProperty, o => o.Ignore());

            try
            {
                mapper.Map<LandPropertyDto, LandProperty>(input.LandPropToUpdate);
            }
            catch (Exception e)
            {                
                throw e;
            }            
        }
    }
}
