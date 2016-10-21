using System.Web.Mvc;

namespace AplikacjaLingwistyczna.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Adrian Dadok - Praca inżynierska";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Adrian Dadok - Kontakt";

            return View();
        }
    }
}