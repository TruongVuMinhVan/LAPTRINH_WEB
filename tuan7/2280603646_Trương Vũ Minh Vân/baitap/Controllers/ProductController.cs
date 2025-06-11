using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace baitap.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
