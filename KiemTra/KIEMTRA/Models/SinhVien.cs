using KIEMTRA.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KIEMTRA.Models
{
    [Table("SinhVien")]
    public class SinhVien
    {
        [Key, StringLength(10)]
        public string MaSV { get; set; }

        [Required, StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(5)]
        public string GioiTinh { get; set; }

        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }

        [StringLength(100)]
        public string? Hinh { get; set; }

        [Required, StringLength(4)]
        public string MaNganh { get; set; }

        // Navigation properties should not be validated
        [ValidateNever]
        [ForeignKey(nameof(MaNganh))]
        public virtual NganhHoc? NganhHoc { get; set; }

        [ValidateNever]
        public virtual ICollection<DangKy>? DangKies { get; set; }
    }
}
