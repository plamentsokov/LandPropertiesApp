using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace LandPropertiesApp
{
    [DependsOn(typeof(AbpWebApiModule), typeof(LandPropertiesAppApplicationModule))]
    public class LandPropertiesAppWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(LandPropertiesAppApplicationModule).Assembly, "landpropertyapp")
                .Build();
        }
    }
}
