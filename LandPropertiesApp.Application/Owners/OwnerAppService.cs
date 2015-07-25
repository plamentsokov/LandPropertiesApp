using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using LandPropertiesApp.Entities;
using LandPropertiesApp.LandProperties.Dtos;
using LandPropertiesApp.Owners.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandPropertiesApp.Owners
{
    public class OwnerAppService : ApplicationService, IOwnerAppService
    {
        private readonly IRepository<Owner> _ownerRepository;
        private readonly IRepository<LandProperty> _landPropertyRepository;

        public OwnerAppService(IRepository<Owner> ownerRepository, IRepository<LandProperty> landPropertyRepository)
        {
            _ownerRepository = ownerRepository;
            _landPropertyRepository = landPropertyRepository;
        }

        public async Task<GetOwnerOutput> GetOwners()
        {
            GetOwnerOutput output = new GetOwnerOutput();

            try
            {
                output.Owners = Mapper.Map<List<OwnerDto>>(await _ownerRepository.GetAllListAsync());
            }
            catch (Exception e)
            {                
                throw e;
            }            

            return output;
        }

        public async Task<GetOwnerOutput> GetOwner(GetOwnerInput input)
        {
            GetOwnerOutput output = new GetOwnerOutput();

            if (input.OwnerId > 0)
            {
                output.SingleOwner = Mapper.Map<OwnerDto>(await _ownerRepository.GetAsync(input.OwnerId));
            }
            else
            {
                output.SingleOwner = Mapper.Map<OwnerDto>(new Owner());
            }

            return output;
        }

        public void AddOrUpdate(UpdateOwnerInput input)
        {
            var config = new ConfigurationStore(new TypeMapFactory(), AutoMapper.Mappers.MapperRegistry.Mappers);
            var mapper = new MappingEngine(config);

            config.CreateMap<OwnerDto, Owner>().ConstructUsing(model =>
            {
                if (model.Id == 0)
                {
                    Owner toAdd = new Owner();
                    _ownerRepository.Insert(toAdd);

                    return toAdd;
                }
                else
                {
                    return _ownerRepository.Get(model.Id);
                }
            });

            config.CreateMap<OwnerLandPropertyDto, LandProperty>().ConstructUsing(model =>
            {
                return _landPropertyRepository.Get(model.Id);
            });

            try
            {
                mapper.Map<OwnerDto, Owner>(input.OwnerToUpdate);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
