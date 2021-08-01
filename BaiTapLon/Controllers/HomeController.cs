using BaiTapLon.Models;
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
        public ActionResult Index()
        {
            var _product = getAllProduct();
            var _categories = getAllCategories();
            ViewBag.Product = _product;
            ViewBag.Category = _categories;
            return View();
        }

        public List<SanPham> getAllProduct()
        {
            return db.SanPhams.ToList();
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

        public ActionResult Cart(string mahoadon)
        {

            return View();
        }


        public ActionResult Accout()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }
    }
}