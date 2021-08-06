using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaiTapLon.Areas.Admin.Models;
using PagedList;
namespace BaiTapLon.Areas.Admin.Controllers
{
    public class HoaDonsController : Controller
    {
        private DoGo db = new DoGo();

        // GET: Admin/HoaDons
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.SapTheoma = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            //Lấy danh sách tk
            var hoadons = db.HoaDons.Select(s => s);
            if (!String.IsNullOrEmpty(searchString))
            {
                hoadons = hoadons.Where(p => p.Mahoadon.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    hoadons = hoadons.OrderByDescending(s => s.Mahoadon);
                    break;
                default:
                    hoadons = hoadons.OrderBy(s => s.Mahoadon);
                    break;
            }
            int pageSize = 6; //Kích thước trang
            int pageNumber = (page ?? 1);
            return View(hoadons.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/HoaDons/Details/5
        public ActionResult Details(string id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.Taikhoan = getTaiKhoan(id);
            ViewBag.Mahoadon = id;
            return View(getAllSanPham(id));
        }
        public TaiKhoan getTaiKhoan(string mahd)
        {
            var tk = db.TaiKhoans.Join(db.HoaDons, s => s.Mataikhoan, b => b.Mataikhoan, (s, b) => new { s, b })
                .Where(sc => sc.b.Mahoadon == mahd).Select(s => s.s).FirstOrDefault<TaiKhoan>();
            return tk;
        }
        public IList<Hoadonsanpham> getAllSanPham(string mahd)
        {
            var sp = db.Hoadonsanphams.Join(db.SanPhams, s => s.Masanpham, b => b.Masanpham, (s, b) => new { s, b })
                .Where(sc => sc.s.Mahoadon == mahd).Select(s => s.s);
            return sp.ToList();
        }

        // GET: Admin/HoaDons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/HoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mahoadon,Mataikhoan,Trangthai")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mahoadon,Mataikhoan,Trangthai")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
