using System.Reflection;
using Abp.Modules;

namespace LandPropertiesApp
{
    public class LandPropertiesAppCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
