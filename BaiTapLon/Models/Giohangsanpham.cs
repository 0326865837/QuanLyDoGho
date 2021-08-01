namespace BaiTapLon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Giohangsanpham")]
    public partial class Giohangsanpham
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string Magio { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string Masanpham { get; set; }

        public int Soluongmua { get; set; }

        [StringLength(1000)]
        public string Trangthai { get; set; }

        public virtual GioHang GioHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
