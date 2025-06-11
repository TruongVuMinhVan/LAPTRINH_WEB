using System;
using System.ComponentModel.DataAnnotations;

namespace KIEMTRA.Models
{
    public class DangNhapViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Mã SV")]
        [Display(Name = "Mã Sinh Viên")]
        public string MaSV { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn Ngày Sinh")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày Sinh")]
        public DateTime NgaySinh { get; set; }
    }
}
