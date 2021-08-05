namespace BaiTapLon.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Required(ErrorMessage = "Mã loại không được để trống!")]
        [StringLength(20)]
        [DisplayName("Mã loại")]
        public string Maloai { get; set; }

        [Key]
        [Required(ErrorMessage = "Mã sản phẩm không được để trống!")]
        [StringLength(20)]
        [DisplayName("Mã sản phẩm")]
        public string Masanpham { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống!")]
        [StringLength(100)]
        [DisplayName("Tên sản phẩm")]
        public string Tensanpham { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Kích thước")]
        public string Kichthuoc { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Chất liệu")]
        public string Chatlieu { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "Gía không được để trống!")]
        [DisplayName("Gía")]
        public decimal Dongia { get; set; }

        [StringLength(1000)]
        [DisplayName("Ảnh")]
        public string Anh { get; set; }

        [DisplayName("Số lượng tồn")]
        public int Soluongton { get; set; }

        [StringLength(2000)]
        [DisplayName("Mô tả")]
        public string Mota { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
