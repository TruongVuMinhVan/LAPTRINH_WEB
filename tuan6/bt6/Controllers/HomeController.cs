using System.Diagnostics;
using bt6.Models;
using Microsoft.AspNetCore.Mvc;

namespace bt6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public async Task<IActionResult> Index()
        {
            string data = await GetDataAsync();
            ViewBag.Message = data;
            return View();
        }

        public async Task<string> GetDataAsync()
        {
            await Task.Delay(1000);
            return "XIN CHOA";
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
