using Microsoft.AspNetCore.Mvc;

namespace buoi2.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; } = new
List<CartItem>();
        public void AddItem(CartItem item)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId ==
            item.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                Items.Add(item);
            }
        }
        public void RemoveItem(int productId)
        {
            Items.RemoveAll(i => i.ProductId == productId);
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();

            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                if (quantity <= 0)
                {
                    cart.RemoveItem(productId);
                }
                else
                {
                    item.Quantity = quantity;
                }
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }

            return RedirectToAction("Index");
        }
        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index");
        }

    }
}
