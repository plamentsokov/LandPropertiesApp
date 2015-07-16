using System.Web.Mvc;

namespace LandPropertiesApp.Web.Controllers
{
    public class HomeController : LandPropertiesAppControllerBase
    {
        public ActionResult Index()
        { 
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}