using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KIEMTRA.Models;

namespace KIEMTRA.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // Constructor receives DbContextOptions and passes to base
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Các DbSet tương ứng với các bảng
        public DbSet<NganhHoc> NganhHocs { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<HocPhan> HocPhans { get; set; }
        public DbSet<DangKy> DangKies { get; set; }
        public DbSet<ChiTietDangKy> ChiTietDangKies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Composite primary key cho ChiTietDangKy
            builder.Entity<ChiTietDangKy>()
                   .HasKey(ct => new { ct.MaDK, ct.MaHP });

            // Quan hệ SinhVien (1) - DangKy (n)
            builder.Entity<DangKy>()
                   .HasOne(dk => dk.SinhVien)
                   .WithMany(sv => sv.DangKies)
                   .HasForeignKey(dk => dk.MaSV);

            // Quan hệ DangKy (1) - ChiTietDangKy (n)
            builder.Entity<ChiTietDangKy>()
                   .HasOne(ct => ct.DangKy)
                   .WithMany(dk => dk.ChiTietDangKies)
                   .HasForeignKey(ct => ct.MaDK);

            // Quan hệ HocPhan (1) - ChiTietDangKy (n)
            builder.Entity<ChiTietDangKy>()
                   .HasOne(ct => ct.HocPhan)
                   .WithMany(hp => hp.ChiTietDangKies)
                   .HasForeignKey(ct => ct.MaHP);

            // Quan hệ SinhVien (n) - NganhHoc (1)
            builder.Entity<SinhVien>()
                   .HasOne(sv => sv.NganhHoc)
                   .WithMany(nh => nh.SinhViens)
                   .HasForeignKey(sv => sv.MaNganh);
        }
    }
}