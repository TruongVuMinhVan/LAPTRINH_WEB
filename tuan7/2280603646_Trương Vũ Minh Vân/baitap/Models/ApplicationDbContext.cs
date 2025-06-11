using baitap.Models; // Thay thế bằng namespace thực tế của bạn
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public
    ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    { }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
}