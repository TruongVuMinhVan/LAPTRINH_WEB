using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KIEMTRA.Models;

namespace KIEMTRA.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SinhVienController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: /SinhVien
        public async Task<IActionResult> Index()
        {
            var sinhViens = await _context.SinhViens
                                           .Include(s => s.NganhHoc)
                                           .AsNoTracking()
                                           .ToListAsync();
            return View(sinhViens);
        }

        // GET: /SinhVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var sv = await _context.SinhViens
                                   .Include(s => s.NganhHoc)
                                   .FirstOrDefaultAsync(m => m.MaSV == id);
            if (sv == null) return NotFound();
            return View(sv);
        }

        // GET: /SinhVien/Create
        public IActionResult Create()
        {
            PopulateNganhDropDown();
            return View(new SinhVien());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
    [Bind("MaSV,HoTen,GioiTinh,NgaySinh,MaNganh")] SinhVien sv,
    IFormFile HinhUpload)
        {
            // 1. Đảm bảo dropdown vẫn có dữ liệu nếu phải trả lại View
            PopulateNganhDropDown(sv.MaNganh);

            // 2. Kiểm tra ModelState
            if (!ModelState.IsValid)
            {
                // Lấy danh sách lỗi ra để bạn nhìn thấy
                var errors = ModelState
                    .Where(kv => kv.Value.Errors.Count > 0)
                    .SelectMany(kv => kv.Value.Errors.Select(e => $"{kv.Key}: {e.ErrorMessage}"))
                    .ToList();

                // Tạm lưu vào ViewBag để hiển thị trong view
                ViewBag.ModelErrors = errors;
                return View(sv);
            }

            // 3. Kiểm tra việc upload file
            if (HinhUpload != null)
            {
                // đặt breakpoint ở đây để inspect _env.WebRootPath & HinhUpload.Length
                var imagesDir = Path.Combine(_env.WebRootPath, "images");
                if (!Directory.Exists(imagesDir))
                    Directory.CreateDirectory(imagesDir);

                var fileName = $"{sv.MaSV}{Path.GetExtension(HinhUpload.FileName)}";
                var fullPath = Path.Combine(imagesDir, fileName);
                using var fs = new FileStream(fullPath, FileMode.Create);
                await HinhUpload.CopyToAsync(fs);
                sv.Hinh = $"/images/{fileName}";
            }
            else
            {
                // Nếu bạn muốn mặc định một đường dẫn (tránh null)
                sv.Hinh ??= "/images/default.png";
            }

            // 4. Thử-catch SaveChanges để bắt exception nếu có
            try
            {
                _context.Add(sv);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Bắt exception và đưa message ra view
                ViewBag.DbError = ex.GetBaseException().Message;
                return View(sv);
            }

            return RedirectToAction(nameof(Index));
        }


        // GET: /SinhVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var sv = await _context.SinhViens.FindAsync(id);
            if (sv == null) return NotFound();

            PopulateNganhDropDown(sv.MaNganh);
            return View(sv);
        }

        // POST: /SinhVien/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
    string id,
    [Bind("MaSV,HoTen,GioiTinh,NgaySinh,Hinh,MaNganh")] SinhVien sv,
    IFormFile HinhUpload)
        {
            if (id != sv.MaSV) return NotFound();
            PopulateNganhDropDown(sv.MaNganh);

            if (!ModelState.IsValid)
                return View(sv);

            if (HinhUpload != null && HinhUpload.Length > 0)
            {
                var imagesDir = Path.Combine(_env.WebRootPath, "images");
                if (!Directory.Exists(imagesDir))
                    Directory.CreateDirectory(imagesDir);
                var fileName = $"{sv.MaSV}{Path.GetExtension(HinhUpload.FileName)}";
                var fullPath = Path.Combine(imagesDir, fileName);
                using var fs = new FileStream(fullPath, FileMode.Create);
                await HinhUpload.CopyToAsync(fs);
                sv.Hinh = $"/images/{fileName}";
            }

            try
            {
                _context.Update(sv);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SinhVienExists(sv.MaSV)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: /SinhVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var sv = await _context.SinhViens
                                   .Include(s => s.NganhHoc)
                                   .FirstOrDefaultAsync(m => m.MaSV == id);
            if (sv == null) return NotFound();
            return View(sv);
        }

        // POST: /SinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sv = await _context.SinhViens.FindAsync(id);
            if (sv != null)
            {
                _context.SinhViens.Remove(sv);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool SinhVienExists(string id)
        {
            return _context.SinhViens.Any(e => e.MaSV == id);
        }

        private void PopulateNganhDropDown(object selected = null)
        {
            var items = _context.NganhHocs
                                 .OrderBy(n => n.TenNganh)
                                 .Select(n => new SelectListItem
                                 {
                                     Value = n.MaNganh,
                                     Text = n.TenNganh
                                 }).ToList();
            ViewBag.NganhList = new SelectList(items, "Value", "Text", selected);
        }
    }
}
