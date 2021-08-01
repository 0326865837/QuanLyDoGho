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
    public class SanPhamsController : Controller
    {
        private ShopDoGho db = new ShopDoGho();


        // GET: SanPhams/Details/5
        public ActionResult Details(string id)
        {
            var _categories = getAllCategories();
            ViewBag.Category = _categories;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        public List<LoaiSanPham> getAllCategories()
        {
            return db.LoaiSanPhams.ToList();
        }
       
    }
}
