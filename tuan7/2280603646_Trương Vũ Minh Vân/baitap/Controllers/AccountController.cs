using Microsoft.AspNetCore.Mvc;

namespace baitap.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
