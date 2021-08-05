using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BaiTapLon.Areas.Admin.Models
{
    public partial class DoGo : DbContext
    {
        public DoGo()
            : base("name=ShopDoGho")
        {
        }

        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiSanPham>()
                .HasMany(e => e.SanPhams)
                .WithRequired(e => e.LoaiSanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Dongia)
                .HasPrecision(19, 4);
        }

        public System.Data.Entity.DbSet<BaiTapLon.Areas.Admin.Models.Hoadonsanpham> Hoadonsanphams { get; set; }

        public System.Data.Entity.DbSet<BaiTapLon.Areas.Admin.Models.HoaDon> HoaDons { get; set; }
    }
}
