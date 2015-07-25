using Abp.Application.Services;
using LandPropertiesApp.Mortgages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandPropertiesApp.Mortgages
{
    public interface IMortgageAppService : IApplicationService
    {
        Task<GetMortgageOutput> All();
        Task<GetMortgageOutput> Get(GetMortgageInput input);
        void AddOrUpdate(GetMortgageInput input);
    }
}
