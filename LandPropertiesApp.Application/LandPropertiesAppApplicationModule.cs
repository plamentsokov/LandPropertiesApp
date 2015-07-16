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
        }
    }
}
