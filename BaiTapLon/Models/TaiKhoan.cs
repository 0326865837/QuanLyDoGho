namespace BaiTapLon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            GioHangs = new HashSet<GioHang>();
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(20)]
        public string Mataikhoan { get; set; }

        [Required]
        [StringLength(100)]
        public string Tendangnhap { get; set; }

        [Required]
        [StringLength(100)]
        public string Matkhau { get; set; }

        [Required]
        [StringLength(100)]
        public string Loaitaikhoan { get; set; }

        [Required]
        [StringLength(100)]
        public string Hoten { get; set; }

        [StringLength(100)]
        public string Sodienthoai { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Diachi { get; set; }

        [StringLength(100)]
        public string Anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
