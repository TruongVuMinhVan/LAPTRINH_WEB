using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace baitap.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
                ViewBag.Role = "Admin";
            else if (User.IsInRole("User"))
                ViewBag.Role = "User";
            else
                ViewBag.Role = "None";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
