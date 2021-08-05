using BaiTapLon.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTapLon.Controllers
{
    public class HomeController : Controller
    {
        private ShopDoGho db = new ShopDoGho();
        public ActionResult Index(string SearchString, int? page)
        {

            var _products = db.SanPhams.Select(s=>s);
            
            if (!String.IsNullOrEmpty(SearchString))
            {
                _products = _products.Where(p => p.Tensanpham.Contains(SearchString));
            }
            _products = _products.OrderBy(s => s.Tensanpham);
            var _categories = getAllCategories();
            ViewBag.Category = _categories;

            int pageSize = 20; //Kích thước trang
            int pageNumber = (page ?? 1);
            return View(_products.ToPagedList(pageNumber, pageSize));
        }


        public List<LoaiSanPham> getAllCategories()
        {
            return db.LoaiSanPhams.ToList();
        }
        public SanPham getDetailProduct(string id)
        {
            var product = db.SanPhams.Find(id);
            return product;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string tendangnhap, string matkhau)
        {
            if (ModelState.IsValid)
            {
                var user = db.TaiKhoans.Where(u => u.Tendangnhap.Equals(tendangnhap) && u.Matkhau.Equals(matkhau)).ToList();
                if (user.Count() > 0)
                {
                    Session["Hoten"] = user.FirstOrDefault().Hoten;
                    Session["Email"] = user.FirstOrDefault().Email;
                    Session["Mataikhoan"] = user.FirstOrDefault().Mataikhoan;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Đăng nhập không thành công";
                }
            }
            return View();
        }
        
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(string Tendangnhap, string Email,string Matkhau, string Diachi, string Hoten, string Sodienthoai)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    Random rd = new Random();
                    int matk = rd.Next(100, 100000);
                    db.TaiKhoans.Add(new TaiKhoan()
                    {
                        Mataikhoan = matk.ToString(),
                        Diachi = Diachi,
                        Email = Email,
                        Hoten = Hoten,
                        Loaitaikhoan = "user",
                        Sodienthoai = Sodienthoai,
                        Matkhau = Matkhau,
                        Tendangnhap = Tendangnhap,
                    });
                    ViewBag.error = "Đăng ký thành công";
                    db.GioHangs.Add(new GioHang()
                    {
                        Mataikhoan = matk.ToString(),
                        Magio = rd.Next(100, 100000).ToString()
                    });
                    db.SaveChanges();
                    Login(Tendangnhap, Matkhau);
                }
                catch (Exception ex)
                {
                    ViewBag.error = "Đăng ký không thàng công";
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Cart(string mahoadon)
        {
            if(Session["Mataikhoan"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }


        public ActionResult Accout()
        {
            if (Session["Mataikhoan"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Product()
        {
            if (Session["Mataikhoan"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}