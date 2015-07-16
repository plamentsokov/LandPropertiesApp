using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using LandPropertiesApp.EntityFramework;

namespace LandPropertiesApp
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(LandPropertiesAppCoreModule))]
    public class LandPropertiesAppDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<LandPropertiesAppDbContext>(null);
        }
    }
}
