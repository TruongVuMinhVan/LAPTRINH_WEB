// Models/HocPhan.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KIEMTRA.Models
{
    [Table("HocPhan")]
    public class HocPhan
    {
        [Key, StringLength(6)]
        public string MaHP { get; set; }

        [Required, StringLength(30)]
        public string TenHP { get; set; }

        [Required]
        public int SoTinChi { get; set; }

        public virtual ICollection<ChiTietDangKy> ChiTietDangKies { get; set; }
    }
}
