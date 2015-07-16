using Abp.Web.Mvc.Controllers;

namespace LandPropertiesApp.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class LandPropertiesAppControllerBase : AbpController
    {
        protected LandPropertiesAppControllerBase()
        {
            LocalizationSourceName = LandPropertiesAppConsts.LocalizationSourceName;
        }
    }
}