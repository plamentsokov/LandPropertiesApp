using Abp.Web.Mvc.Views;

namespace LandPropertiesApp.Web.Views
{
    public abstract class LandPropertiesAppWebViewPageBase : LandPropertiesAppWebViewPageBase<dynamic>
    {

    }

    public abstract class LandPropertiesAppWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected LandPropertiesAppWebViewPageBase()
        {
            LocalizationSourceName = LandPropertiesAppConsts.LocalizationSourceName;
        }
    }
}