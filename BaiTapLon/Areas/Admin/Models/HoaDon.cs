namespace BaiTapLon.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
        [Required(ErrorMessage = "Mã hóa đơn không được để trống!")]
        [DisplayName("Mã hóa đơn")]
        public string Mahoadon { get; set; }

        
        [StringLength(20)]
        [Required(ErrorMessage = "Mã tài khoản không được để trống!")]
        [DisplayName("Mã tài khoản")]
        public string Mataikhoan { get; set; }

        [StringLength(1000)]
        [Required(ErrorMessage = "Trạng thái không được để trống!")]
        [DisplayName("Trạng thái")]
        public string Trangthai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hoadonsanpham> Hoadonsanphams { get; set; }
    }
}
