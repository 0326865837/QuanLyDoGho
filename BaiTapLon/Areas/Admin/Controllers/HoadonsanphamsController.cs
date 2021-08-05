using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaiTapLon.Areas.Admin.Models;

namespace BaiTapLon.Areas.Admin.Controllers
{
    public class HoadonsanphamsController : Controller
    {
        private DoGo db = new DoGo();

        // GET: Admin/Hoadonsanphams
        public ActionResult Index()
        {
            var hoadonsanphams = db.Hoadonsanphams.Include(h => h.HoaDon);
            return View(hoadonsanphams.ToList());
        }

        // GET: Admin/Hoadonsanphams/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoadonsanpham hoadonsanpham = db.Hoadonsanphams.Find(id);
            if (hoadonsanpham == null)
            {
                return HttpNotFound();
            }
            return View(hoadonsanpham);
        }

        // GET: Admin/Hoadonsanphams/Create
        public ActionResult Create()
        {
            ViewBag.Mahoadon = new SelectList(db.HoaDons, "Mahoadon", "Mataikhoan");
            return View();
        }

        // POST: Admin/Hoadonsanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mahoadon,Masanpham,Soluongmua")] Hoadonsanpham hoadonsanpham)
        {
            if (ModelState.IsValid)
            {
                db.Hoadonsanphams.Add(hoadonsanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Mahoadon = new SelectList(db.HoaDons, "Mahoadon", "Mataikhoan", hoadonsanpham.Mahoadon);
            return View(hoadonsanpham);
        }

        // GET: Admin/Hoadonsanphams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoadonsanpham hoadonsanpham = db.Hoadonsanphams.Find(id);
            if (hoadonsanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mahoadon = new SelectList(db.HoaDons, "Mahoadon", "Mataikhoan", hoadonsanpham.Mahoadon);
            return View(hoadonsanpham);
        }

        // POST: Admin/Hoadonsanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mahoadon,Masanpham,Soluongmua")] Hoadonsanpham hoadonsanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoadonsanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Mahoadon = new SelectList(db.HoaDons, "Mahoadon", "Mataikhoan", hoadonsanpham.Mahoadon);
            return View(hoadonsanpham);
        }

        // GET: Admin/Hoadonsanphams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoadonsanpham hoadonsanpham = db.Hoadonsanphams.Find(id);
            if (hoadonsanpham == null)
            {
                return HttpNotFound();
            }
            return View(hoadonsanpham);
        }

        // POST: Admin/Hoadonsanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Hoadonsanpham hoadonsanpham = db.Hoadonsanphams.Find(id);
            db.Hoadonsanphams.Remove(hoadonsanpham);
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
