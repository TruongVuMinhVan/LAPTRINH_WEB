using KIEMTRA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace KIEMTRA.Controllers
{
    public class HocPhanController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HocPhanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /HocPhan/ListHP
        public async Task<IActionResult> ListHP()
        {
            // 1) Kiểm tra đã đăng nhập chưa
            var maSV = HttpContext.Session.GetString("MaSV");
            if (string.IsNullOrEmpty(maSV))
                return RedirectToAction("DangNhap", "NguoiDung");

            // 2) Lấy danh sách học phần
            var allHP = await _context.HocPhans.ToListAsync();

            // 3) Lấy những học phần đã đăng ký của sinh viên
            var dk = await _context.DangKies
                                   .Include(x => x.ChiTietDangKies)
                                   .FirstOrDefaultAsync(x => x.MaSV == maSV);

            var hpDaDK = dk?.ChiTietDangKies
                            .Select(ct => ct.MaHP)
                            .ToHashSet()
                         ?? new HashSet<string>();

            // 4) Map ra ViewModel
            var model = allHP.Select(hp => new HocPhanViewModel
            {
                MaHP = hp.MaHP,
                TenHP = hp.TenHP,
                SoTinChi = hp.SoTinChi,
                DaDangKy = hpDaDK.Contains(hp.MaHP)
            }).ToList();

            return View(model);
        }

        // POST: /HocPhan/DangKy
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DangKy(string maHP)
        {
            var maSV = HttpContext.Session.GetString("MaSV");
            if (string.IsNullOrEmpty(maSV))
                return RedirectToAction("DangNhap", "NguoiDung");

            // Tìm hoặc tạo bản ghi DangKy
            var dk = await _context.DangKies
                        .Include(d => d.ChiTietDangKies)
                        .FirstOrDefaultAsync(d => d.MaSV == maSV);
            if (dk == null)
            {
                dk = new DangKy { MaSV = maSV, NgayDK = DateTime.Now };
                _context.Add(dk);
                await _context.SaveChangesAsync();
            }

            // Nếu chưa đăng ký môn này, thêm ChiTietDangKy
            if (!dk.ChiTietDangKies.Any(ct => ct.MaHP == maHP))
            {
                _context.ChiTietDangKies.Add(new ChiTietDangKy
                {
                    MaDK = dk.MaDK,
                    MaHP = maHP
                });
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(ListHP));
        }
    }
}
