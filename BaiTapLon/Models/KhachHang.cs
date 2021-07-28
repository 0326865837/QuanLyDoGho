namespace BaiTapLon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            GioHangs = new HashSet<GioHang>();
        }

        [Key]
        [StringLength(20)]
        public string Makh { get; set; }

        [Required]
        [StringLength(90)]
        public string Tenkh { get; set; }

        [Required]
        [StringLength(500)]
        public string Diachi { get; set; }

        [Required]
        [StringLength(20)]
        public string Dienthoai { get; set; }

        [Required]
        [StringLength(500)]
        public string Anh { get; set; }

        [Required]
        [StringLength(20)]
        public string Mataikhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
