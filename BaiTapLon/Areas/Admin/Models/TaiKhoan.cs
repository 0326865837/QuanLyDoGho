namespace BaiTapLon.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        [StringLength(20)]
        [Required(ErrorMessage = "Mã tài khoản không được để trống!")]
        [DisplayName("Mã tài khoản")]
        public string Mataikhoan { get; set; }


        [StringLength(100)]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống!")]
        [DisplayName("Tên đăng nhập")]
        public string Tendangnhap { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [StringLength(100)]
        [DisplayName("Mật khẩu")]
        public string Matkhau { get; set; }

        [Required(ErrorMessage = "Loại tài khoản không được để trống!")]
        [StringLength(100)]
        [DisplayName("Loại tài khoản")]
        public string Loaitaikhoan { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống!")]
        [StringLength(100)]
        [DisplayName("Họ tên")]
        public string Hoten { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        [DisplayName("Số điện thoại")]
        public string Sodienthoai { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Email không được để trống!")]
        [DisplayName("Địa chỉ Email")]
        public string Email { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Địa chỉ không được để trống!")]
        [DisplayName("Địa chỉ")]
        public string Diachi { get; set; }

        [StringLength(100)]
        [DisplayName("Ảnh")]
        public string Anh { get; set; }
       
    }
}
