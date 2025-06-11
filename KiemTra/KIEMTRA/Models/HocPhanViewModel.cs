using Microsoft.AspNetCore.Mvc;

// Models/HocPhanViewModel.cs
namespace KIEMTRA.Models
{
    public class HocPhanViewModel
    {
        public string MaHP { get; set; }
        public string TenHP { get; set; }
        public int SoTinChi { get; set; }
        public bool DaDangKy { get; set; }
    }
}
