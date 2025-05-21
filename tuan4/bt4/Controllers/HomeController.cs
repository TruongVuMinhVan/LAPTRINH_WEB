using bt4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace bt4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var actors = new List<Actor>
            {
                new Actor { Name = "Phương Anh Đào", Height= 160, Role ="Mai"},
                new Actor { Name = "Tuan Tran", Height= 170, Role ="Duong (Sau)"},
                new Actor { Name = "Tran Thanh", Height= 150, Role ="ong Hoang"},
            };
            return View(actors);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
