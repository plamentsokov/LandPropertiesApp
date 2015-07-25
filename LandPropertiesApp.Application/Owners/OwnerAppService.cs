using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using LandPropertiesApp.Entities;
using LandPropertiesApp.Owners.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandPropertiesApp.Owners
{
    public class OwnerAppService : ApplicationService, IOwnerAppService
    {
        private readonly IRepository<Owner> _ownerRepository;

        public OwnerAppService(IRepository<Owner> ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<GetOwnerOutput> GetOwners()
        {
            return new GetOwnerOutput
            {
                Owners = Mapper.Map<List<OwnerDto>>(await _ownerRepository.GetAllListAsync())
            };
        }


        public void UpdateOwner()
        {
            throw new NotImplementedException();
        }
    }
}
