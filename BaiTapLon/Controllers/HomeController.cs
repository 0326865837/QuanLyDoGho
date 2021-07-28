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
        private ShopQuanLyDoGo db = new ShopQuanLyDoGo();
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
        public ActionResult Product_Details()
        {
            return View();
        }
        public ActionResult addCart(string id)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart == null)
            {
                var product = getDetailProduct(id);
                List<GioHang> listCart = new List<GioHang>()
                {
                    new GioHang
                    {
                        San
                    }
                }
            }
        }
        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult Login()
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