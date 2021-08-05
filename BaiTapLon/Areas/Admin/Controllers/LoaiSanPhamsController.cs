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
    public class LoaiSanPhamsController : Controller
    {
        private DoGo db = new DoGo();

        // GET: Admin/LoaiSanPhams
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.SapTheoTen = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var loaisanPhams = db.LoaiSanPhams.Select(p=>p);
            if (!String.IsNullOrEmpty(searchString))
            {
                loaisanPhams = loaisanPhams.Where(p => p.Tenloai.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    loaisanPhams = loaisanPhams.OrderByDescending(s => s.Tenloai);
                    break;
               
                default:
                    loaisanPhams = loaisanPhams.OrderBy(s => s.Tenloai);
                    break;
            }
            int pageSize = 6; //Kích thước trang
            int pageNumber = (page ?? 1);
            return View(loaisanPhams.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/LoaiSanPhams/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }

        // GET: Admin/LoaiSanPhams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Maloai,Tenloai,Mota")] LoaiSanPham loaiSanPham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.LoaiSanPhams.Add(loaiSanPham);
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ViewBag.Error = "Lỗi nhập dữ liệu! " + ex.Message; ;
                return View(loaiSanPham);

            }
        }

        // GET: Admin/LoaiSanPhams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }

        // POST: Admin/LoaiSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Maloai,Tenloai,Mota")] LoaiSanPham loaiSanPham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(loaiSanPham).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu! " + ex.Message;
                return View(loaiSanPham);
            }
        }

        // GET: Admin/LoaiSanPhams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }

        // POST: Admin/LoaiSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Find(id);
            try
            {
                db.LoaiSanPhams.Remove(loaiSanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Không xóa được loại sản phẩm này! " + ex.Message;
                return View("Delete", loaiSanPham);
            }
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
