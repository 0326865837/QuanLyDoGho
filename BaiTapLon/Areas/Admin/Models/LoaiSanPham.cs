namespace BaiTapLon.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiSanPham")]
    public partial class LoaiSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiSanPham()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [Required(ErrorMessage = "Mã loại sản phẩm không được để trống!")]
        [StringLength(20)]
        [DisplayName("Mã loại sản phẩm")]
        public string Maloai { get; set; }

        [Required(ErrorMessage = "Tên loại sản phẩm không được để trống!")]
        [StringLength(100)]
        [DisplayName("Tên loại sản phẩm")]
        public string Tenloai { get; set; }

        [Required]
        [StringLength(2000)]
        [DisplayName("Mô tả")]
        public string Mota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
