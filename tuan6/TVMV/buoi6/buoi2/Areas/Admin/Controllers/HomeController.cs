using System.Threading.Tasks;
using buoi2.Models;
using buoi2.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace buoi2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        // Chú ý: IActionResult → async Task<IActionResult> khi gọi async repository
        public async Task<IActionResult> Index()
        {
            var productList = await _productRepository.GetAllAsync();
            return View(productList);
        }
    }
}
