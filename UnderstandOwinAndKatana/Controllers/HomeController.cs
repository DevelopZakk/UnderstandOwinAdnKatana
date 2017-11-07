using System.Web.Mvc;

namespace UnderstandOwinAndKatana.Controllers
{
    public class HomeController:Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}