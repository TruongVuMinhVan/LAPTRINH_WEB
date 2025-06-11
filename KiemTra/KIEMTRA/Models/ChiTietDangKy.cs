// Models/ChiTietDangKy.cs
using KIEMTRA.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KIEMTRA.Models
{
    [Table("ChiTietDangKy")]
    public class ChiTietDangKy
    {
        [Key, Column(Order = 0)]
        public int MaDK { get; set; }

        [Key, Column(Order = 1), StringLength(6)]
        public string MaHP { get; set; }

        public virtual DangKy DangKy { get; set; }
        public virtual HocPhan HocPhan { get; set; }
    }
}
