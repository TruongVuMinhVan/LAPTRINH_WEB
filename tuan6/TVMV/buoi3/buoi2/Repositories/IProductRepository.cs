using System.Collections.Generic;
using System.Threading.Tasks;
using buoi2.Models;

namespace buoi2.Repositories
{
    public interface IProductRepository
    {
        // Lấy tất cả sản phẩm (async)
        Task<IEnumerable<Product>> GetAllAsync();

        // Lấy sản phẩm theo Id (async)
        Task<Product> GetByIdAsync(int id);

        // Thêm sản phẩm mới (async)
        Task AddAsync(Product product);

        // Cập nhật sản phẩm (async)
        Task UpdateAsync(Product product);

        // Xoá sản phẩm theo Id (async)
        Task DeleteAsync(int id);

        // Nếu bạn cần thêm các method khác (ví dụ tìm kiếm theo tên, paging, v.v.) thì cũng nên để chữ ký async tương tự.
    }
}
