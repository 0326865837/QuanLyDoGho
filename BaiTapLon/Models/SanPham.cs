namespace BaiTapLon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            Hoadonsanphams = new HashSet<Hoadonsanpham>();
        }

        [Required]
        [StringLength(20)]
        public string Maloai { get; set; }

        [Key]
        [StringLength(20)]
        public string Masanpham { get; set; }

        [Required]
        [StringLength(90)]
        public string Tensanpham { get; set; }

        [Required]
        [StringLength(90)]
        public string Kichthuoc { get; set; }

        [Required]
        [StringLength(90)]
        public string Chatlieu { get; set; }

        [Column(TypeName = "money")]
        public decimal Dongia { get; set; }

        [StringLength(90)]
        public string Anh { get; set; }

        public int Soluongton { get; set; }

        [StringLength(500)]
        public string Mota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hoadonsanpham> Hoadonsanphams { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
