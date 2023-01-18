using System.Web.Mvc;

namespace VehicleManagement.UI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}