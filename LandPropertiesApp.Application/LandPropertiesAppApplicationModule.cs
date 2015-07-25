using System.Reflection;
using Abp.Modules;

namespace LandPropertiesApp
{
    [DependsOn(typeof(LandPropertiesAppCoreModule))]
    public class LandPropertiesAppApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //We must declare mappings to be able to use AutoMapper
            DtoMappings.Map();
        }
    }
}
