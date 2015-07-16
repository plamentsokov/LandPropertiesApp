using Abp.Application.Services;

namespace LandPropertiesApp
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class LandPropertiesAppAppServiceBase : ApplicationService
    {
        protected LandPropertiesAppAppServiceBase()
        {
            LocalizationSourceName = LandPropertiesAppConsts.LocalizationSourceName;
        }
    }
}