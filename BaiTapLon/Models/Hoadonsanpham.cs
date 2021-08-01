namespace BaiTapLon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hoadonsanpham")]
    public partial class Hoadonsanpham
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string Mahoadon { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string Masanpham { get; set; }

        public int Soluongmua { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
