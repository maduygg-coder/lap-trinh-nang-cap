using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace QuanLySinhVien.Data.Entities
{
    
    public class LopHoc
    {
        [Key]
        public int MaLop { get; set; }

        [Required]
        public string TenLop { get; set; }

        public ICollection<SinhVien> SinhViens { get; set; }
    }

    public class SinhVien
    {
        [Key]
        public int MaSV { get; set; }

        [Required]
        public string HoTen { get; set; }

        public DateTime NgaySinh { get; set; }

        public int MaLop { get; set; }

        public LopHoc LopHoc { get; set; }
    }
    public class QLSVContext : DbContext
    {
        public QLSVContext(DbContextOptions<QLSVContext> options)
            : base(options)
        {
        }

        public DbSet<LopHoc> LopHocs { get; set; }

        public DbSet<SinhVien> SinhViens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LopHoc>()
                .HasMany(l => l.SinhViens)
                .WithOne(s => s.LopHoc)
                .HasForeignKey(s => s.MaLop);
        }
    }
}
