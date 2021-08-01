using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaiTapLon.Models;

namespace BaiTapLon.Controllers
{
    public class DanhMucsController : Controller
    {
        private ShopDoGho db = new ShopDoGho();
        public ActionResult Index(string id)
        {
            List<SanPham> products = new List<SanPham>();
            products = db.SanPhams.Where(s => s.Maloai.Equals(id)).Select(s => s).ToList();
            ViewBag.product = products;
            ViewBag.Category = getAllCategories();
            return View();
        }

        public List<LoaiSanPham> getAllCategories()
        {
            return db.LoaiSanPhams.ToList();
        }

    }
}
