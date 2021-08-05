namespace BaiTapLon.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hoadonsanpham")]
    public partial class Hoadonsanpham
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        [Required(ErrorMessage = "Mã hóa đơn không được để trống!")]
        [DisplayName("Mã hóa đơn")]
        public string Mahoadon { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        [Required(ErrorMessage = "Mã sản phẩm không được để trống!")]
        [DisplayName("Mã sản phẩm")]
        public string Masanpham { get; set; }

        public int Soluongmua { get; set; }
        [Required(ErrorMessage = "Số lượng mua không được để trống!")]
        [DisplayName("Số lượng mua")]

        public virtual HoaDon HoaDon { get; set; }
    }
}
