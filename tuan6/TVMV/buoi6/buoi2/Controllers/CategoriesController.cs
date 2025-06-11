using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using buoi2.Models;
using buoi2.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace buoi2.Controllers
{
    [Authorize(Roles = SD.Role_Admin)] // Chỉ Admin mới thao tác CRUD Category
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: /Categories/Index
        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories = await _categoryRepository.GetAllAsync();
            return View(categories);
        }

        // GET: /Categories/Display/5
        public async Task<IActionResult> Display(int id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: /Categories/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: /Categories/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            await _categoryRepository.AddAsync(category);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Categories/Update/5
        public async Task<IActionResult> Update(int id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: /Categories/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            await _categoryRepository.UpdateAsync(category);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Categories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: /Categories/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
