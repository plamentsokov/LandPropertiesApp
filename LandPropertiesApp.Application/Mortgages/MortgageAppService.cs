using Abp.Domain.Repositories;
using AutoMapper;
using LandPropertiesApp.Entities;
using LandPropertiesApp.LandProperties.Dtos;
using LandPropertiesApp.Mortgages.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandPropertiesApp.Mortgages
{
    public class MortgageAppService : LandPropertiesAppAppServiceBase, IMortgageAppService
    {
        private readonly IRepository<Mortgage> _mortgageRepository;
        private readonly IRepository<LandProperty> _landPropertyRepository;

        public MortgageAppService(IRepository<Mortgage> mortgageRepository, IRepository<LandProperty> landPropertyRepository)
        {
            _mortgageRepository = mortgageRepository;
            _landPropertyRepository = landPropertyRepository;
        }

        public async Task<GetMortgageOutput> All()
        {
            GetMortgageOutput output = new GetMortgageOutput();

            try
            {
                output.Mortgages = Mapper.Map<List<MortgageDto>>(await _mortgageRepository.GetAllListAsync());
            }
            catch (Exception e)
            {
                throw e;
            }

            return output;
        }

        public async Task<GetMortgageOutput> Get(GetMortgageInput input)
        {
            GetMortgageOutput output = new GetMortgageOutput();

            if (input.MortgageId > 0)
            {
                output.SingleMortgage = Mapper.Map<MortgageDto>(await _mortgageRepository.GetAsync(input.MortgageId));
            }
            else
            {
                output.SingleMortgage = Mapper.Map<MortgageDto>(new Mortgage());
            }

            return output;
        }

        public void AddOrUpdate(GetMortgageInput input)
        {
            var config = new ConfigurationStore(new TypeMapFactory(), AutoMapper.Mappers.MapperRegistry.Mappers);
            var mapper = new MappingEngine(config);

            config.CreateMap<MortgageDto, Mortgage>().ConstructUsing(model =>
            {
                if (model.Id == 0)
                {
                    Mortgage toAdd = new Mortgage();
                    _mortgageRepository.Insert(toAdd);

                    return toAdd;
                }
                else
                {
                    return _mortgageRepository.Get(model.Id);
                }
            }).ForMember(x => x.LandProperty, o => o.Ignore());

            try
            {
                mapper.Map<MortgageDto, Mortgage>(input.MortgageToUpdate);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
