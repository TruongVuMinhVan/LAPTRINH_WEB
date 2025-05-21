using bt4.Models;
using Microsoft.AspNetCore.Mvc;

namespace bt4.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        // Xử lý khi form đăng ký được gửi
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Lưu thông tin người dùng vào database
                // Ví dụ: Hash mật khẩu và lưu vào bảng Users

                // Chuyển hướng đến trang đăng nhập hoặc trang khác
                return RedirectToAction("Login", "Account");
            }

            // Nếu có lỗi, hiển thị lại form
            return View(model);
        }
    }
}
