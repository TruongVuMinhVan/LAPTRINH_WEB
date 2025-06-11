// Models/DangKy.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KIEMTRA.Models
{
    [Table("DangKy")]
    public class DangKy
    {
        [Key]
        public int MaDK { get; set; }

        [DataType(DataType.Date)]
        public DateTime NgayDK { get; set; }

        [StringLength(10)]
        public string MaSV { get; set; }

        public virtual SinhVien SinhVien { get; set; }
        public virtual ICollection<ChiTietDangKy> ChiTietDangKies { get; set; }
    }
}
