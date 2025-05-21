using Microsoft.AspNetCore.Mvc;

namespace bt4.Controllers
{
    public class HomeController2 : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Name = "View Bag";
            ViewData["NameData"] = "View Data";
            TempData["Name"] = "Temp Data";
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
    }
}
