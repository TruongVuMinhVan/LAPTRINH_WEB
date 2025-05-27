using Microsoft.EntityFrameworkCore;

namespace buoi5.Models
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        public DbSet<Book> Books => Set<Book>();
        public DbSet<Category> Categories => Set<Category>();

        // ✔️ OnModelCreating phải đặt trong class
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Lập trình" },
                new Category { CategoryId = 2, CategoryName = "Kỹ năng sống" },
                new Category { CategoryId = 3, CategoryName = "Thiếu nhi" },
                new Category { CategoryId = 4, CategoryName = "Tâm lý - Giáo dục" },
                new Category { CategoryId = 5, CategoryName = "Khoa học phổ thông" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = "B00001", Title = "C# căn bản cho người mới bắt đầu", Author = "Nguyễn Văn A", Price = 85000, Image = "csharpcanban.jpg", CategoryId = 1 },
                new Book { BookId = "B00002", Title = "ASP.NET Core MVC thực chiến", Author = "Trần Thị B", Price = 110000, Image = "aspnetcoremvc.jpg", CategoryId = 1 },
                new Book { BookId = "B00003", Title = "Dạy con làm giàu", Author = "Robert Kiyosaki", Price = 99000, Image = "dayconlamgiau.jpg", CategoryId = 2 },
                new Book { BookId = "B00004", Title = "Tớ học lập trình", Author = "Nguyễn Nhật Ánh", Price = 75000, Image = "tohoclaptrinh.jpg", CategoryId = 3 },
                new Book { BookId = "B00005", Title = "5 ngôn ngữ tình yêu", Author = "Gary Chapman", Price = 105000, Image = "5ngonngutinhyeu.jpg", CategoryId = 4 },
                new Book { BookId = "B00006", Title = "Vũ trụ trong vỏ hạt dẻ", Author = "Stephen Hawking", Price = 120000, Image = "vutrutrongvo.jpg", CategoryId = 5 }
            );
        }
    }
}
