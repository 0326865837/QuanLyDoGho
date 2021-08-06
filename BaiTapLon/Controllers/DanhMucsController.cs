using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaiTapLon.Models;
using PagedList;

namespace BaiTapLon.Controllers
{
    public class DanhMucsController : Controller
    {
        private ShopDoGho db = new ShopDoGho();
        public ActionResult Index(string id, int? page)
        {
            var products = db.SanPhams.Select(s=>s);

            products = products.Where(s => s.Maloai.Equals(id)).Select(s => s);
            products = products.OrderBy(s => s.Tensanpham);

            ViewBag.Category = getAllCategories();
            int pageSize = 20; //Kích thước trang
            int pageNumber = (page ?? 1);
            return View(products.ToPagedList(pageNumber, pageSize));
        }

        public List<LoaiSanPham> getAllCategories()
        {
            return db.LoaiSanPhams.ToList();
        }

    }
}
