using System.ComponentModel.DataAnnotations;

namespace buoi5.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Tên chủ đề không được để trống")]
        public string CategoryName { get; set; } = string.Empty;

        public virtual ICollection<Book>? Books { get; set; }
    }
}
