using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using LandPropertiesApp.EntityFramework;
using LandPropertiesApp.EntityFramework.Repositories;

namespace LandPropertiesApp
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(LandPropertiesAppCoreModule))]
    public class LandPropertiesAppDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "LandPropertiesSystemConnection";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<LandPropertiesAppDbContext>(null);
        }
    }
}
