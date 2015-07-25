using Abp.Application.Services;
using LandPropertiesApp.Owners.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandPropertiesApp.Owners
{
    public interface IOwnerAppService : IApplicationService
    {
        Task<GetOwnerOutput> GetOwners();
        void UpdateOwner();
    }
}
