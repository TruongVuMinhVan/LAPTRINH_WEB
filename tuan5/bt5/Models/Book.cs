using System.ComponentModel.DataAnnotations;

namespace buoi5.Models
{
    public class Book
    {
        [Key]
        [Required(ErrorMessage = "Mã sách không được để trống")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Mã sách phải đúng 6 ký tự")]
        public string BookId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tên sách không được để trống")]
        [StringLength(100, ErrorMessage = "Tên sách không quá 100 ký tự")]
        public string Title { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Author { get; set; }

        [Range(1000, 999999, ErrorMessage = "Giá phải từ 1000 đến 999999")]
        public decimal? Price { get; set; }

        public string? Image { get; set; }

        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
