using Abp.Application.Services;
using LandPropertiesApp.LandProperties.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandPropertiesApp.LandProperties
{
    public interface ILandPropertyAppService : IApplicationService
    {
        Task<GetLandPropertyOutput> GetLandProperties();
        Task<GetLandPropertyOutput> GetLandProperty(GetLandPropertyInput input);
        void AddOrUpdate(UpdateLandPropertyInput input);
    }
}
