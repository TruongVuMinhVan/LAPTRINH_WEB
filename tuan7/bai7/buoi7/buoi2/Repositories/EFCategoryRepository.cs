using buoi2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace buoi2.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public EFCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories
                .Include(c => c.Products) // Chỉ hoạt động sau khi bạn thêm navigation property
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category != null)
            {
                _context.Products.RemoveRange(category.Products); // Xóa tất cả sản phẩm
                _context.Categories.Remove(category);             // Xóa danh mục
                await _context.SaveChangesAsync();
            }
        }
    }
}
