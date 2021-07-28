namespace BaiTapLon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            Hoadonsanphams = new HashSet<Hoadonsanpham>();
        }

        [Key]
        [StringLength(20)]
        public string Mahd { get; set; }

        [Required]
        [StringLength(90)]
        public string Tensanpham { get; set; }

        [Required]
        [StringLength(90)]
        public string Hoten { get; set; }

        [Required]
        [StringLength(500)]
        public string Diachi { get; set; }

        [Required]
        [StringLength(20)]
        public string Dienthoai { get; set; }

        [Required]
        [StringLength(90)]
        public string Email { get; set; }

        public DateTime Ngaydathang { get; set; }

        public DateTime Ngaynhanhang { get; set; }

        [Required]
        [StringLength(90)]
        public string Phuongthucthanhtoan { get; set; }

        [StringLength(1000)]
        public string Ghichu { get; set; }

        [Required]
        [StringLength(20)]
        public string Magio { get; set; }

        public virtual GioHang GioHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hoadonsanpham> Hoadonsanphams { get; set; }
    }
}
