using KIEMTRA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace KIEMTRA.Controllers
{
    public class NguoiDungController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NguoiDungController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /NguoiDung/DangNhap
        [HttpGet]
        public IActionResult DangNhap()
        {
            // Trả về model rỗng cho view
            return View(new DangNhapViewModel());
        }

        // POST: /NguoiDung/DangNhap
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DangNhap(DangNhapViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Tìm sinh viên theo MaSV và NgaySinh
            var sv = await _context.SinhViens
                .FirstOrDefaultAsync(s => s.MaSV == model.MaSV && s.NgaySinh == model.NgaySinh);

            if (sv == null)
            {
                ViewBag.ThongBao = "Sai Mã SV hoặc Ngày Sinh!";
                return View(model);
            }

            // Lưu session
            HttpContext.Session.SetString("MaSV", sv.MaSV);
            HttpContext.Session.SetString("HoTen", sv.HoTen);

            // Chuyển về trang Index của SinhVien
            return RedirectToAction("Index", "SinhVien");
        }

        // GET: /NguoiDung/DangXuat
        public IActionResult DangXuat()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("DangNhap");
        }
    }
}
