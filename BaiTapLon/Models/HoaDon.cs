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
        public string Mahoadon { get; set; }

        [Required]
        [StringLength(20)]
        public string Mataikhoan { get; set; }

        [StringLength(1000)]
        public string Trangthai { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hoadonsanpham> Hoadonsanphams { get; set; }
    }
}
