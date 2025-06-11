using buoi2.Extensions;
using buoi2.Models;
using buoi2.Repositories;
using Microsoft.AspNetCore.Mvc;

public class ShoppingCartController : Controller
{
    private readonly IProductRepository _productRepository;
    public ShoppingCartController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<IActionResult> AddToCart(int productId, int quantity)
    {
        // Giả sử bạn có phương thức lấy thông tin sản phẩm từ productId
        var product = await GetProductFromDatabase(productId);
        var cartItem = new CartItem
        {
            ProductId = productId,
            Name = product.Name,
            Price = product.Price,
            Quantity = quantity
        };
        var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ??
        new ShoppingCart();
        cart.AddItem(cartItem);
        HttpContext.Session.SetObjectAsJson("Cart", cart);
        return RedirectToAction("Index");
    }
    public IActionResult Index()
    {
        var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ??
new ShoppingCart();
        return View(cart);
    }
    // Các actions khác...
    private async Task<Product> GetProductFromDatabase(int productId)
    {
        // Truy vấn cơ sở dữ liệu để lấy thông tin sản phẩm
        var product = await _productRepository.GetByIdAsync(productId);
        return product;
    }
    public IActionResult RemoveFromCart(int productId)
    {
        var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart");
        if (cart is not null)
        {
            cart.RemoveItem(productId);
            // Lưu lại giỏ hàng vào Session sau khi đã xóa mục
            HttpContext.Session.SetObjectAsJson("Cart", cart);
        }
        return RedirectToAction("Index");
    }

    public IActionResult Checkout()
    {
        var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart");
        if (cart == null || !cart.Items.Any())
        {
            return RedirectToAction("Index");
        }

        // Xử lý thanh toán hoặc chuyển sang trang xác nhận đơn hàng
        return View(cart);
    }

}