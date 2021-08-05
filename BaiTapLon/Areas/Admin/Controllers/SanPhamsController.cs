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
    public class SanPhamsController : Controller
    {
        private DoGo db = new DoGo();

        // GET: Admin/SanPhams
        public ActionResult Index(string sortOrder,string searchString, string currentFilter, int? page)
        {

            ViewBag.SapTheoTen = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SapTheoGia = sortOrder == "Gia" ? "gia_desc" : "Gia";
            //Lấy danh sách hàng
            var sanPhams = db.SanPhams.Include(s => s.LoaiSanPham);
            //Lọc theo tên hàng
            if (!String.IsNullOrEmpty(searchString))
            {
                sanPhams= sanPhams.Where(p => p.Tensanpham.Contains(searchString));
            }
            //Sap xep
            switch (sortOrder)
            {
                case "name_desc":
                    sanPhams = sanPhams.OrderByDescending(s => s.Tensanpham);
                    break;
                case "Gia":
                    sanPhams = sanPhams.OrderBy(s => s.Dongia);
                    break;
                case "gia_desc":
                    sanPhams = sanPhams.OrderByDescending(s => s.Dongia);
                    break;
                default:
                    sanPhams =sanPhams.OrderBy(s => s.Tensanpham);
                    break;
            }
            int pageSize = 6; //Kích thước trang
            int pageNumber = (page ?? 1);
            return View(sanPhams.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/SanPhams/Details/5
        public ActionResult Details(string id)
        {
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

        // GET: Admin/SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.Maloai = new SelectList(db.LoaiSanPhams, "Maloai", "Tenloai");
            return View();
        }

        // POST: Admin/SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Masanpham,Maloai,Tensanpham,Kichthuoc,Chatlieu,Dongia,Anh,Soluongton,Mota")] SanPham sanPham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sanPham.Anh = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        //Use Namespace called : System.IO
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        //Lấy tên file upload
                        string UploadPath = Server.MapPath("~/Areas/Admin/wwwroot/Images/" + FileName);
                        //Copy Và lưu file vào server.
                        f.SaveAs(UploadPath);
                        //Lưu tên file vào trường Image
                        sanPham.Anh = FileName;
                    }
                    db.SanPhams.Add(sanPham);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu! " + ex.Message;
                ViewBag.Masanpham = new SelectList(db.SanPhams, "Masanpham", "Tensanpham", sanPham.Masanpham);
                return View(sanPham);
            }
        }

        // GET: Admin/SanPhams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.Maloai = new SelectList(db.LoaiSanPhams, "Maloai", "Tenloai", sanPham.Maloai);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Masanpham,Maloai,Tensanpham,Kichthuoc,Chatlieu,Dongia,Anh,Soluongton,Mota")] SanPham sanPham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sanPham.Anh = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        //Use Namespace called : System.IO
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        //Lấy tên file upload
                        string UploadPath = Server.MapPath("~/Areas/Admin/wwwroot/Images/" + FileName);
                        //Copy Và lưu file vào server.
                        f.SaveAs(UploadPath);
                        //Lưu tên file vào trường Image
                        sanPham.Anh = FileName;
                    }
                    db.Entry(sanPham).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu! " + ex.Message;
                ViewBag.Masanpham= new SelectList(db.SanPhams, "Masanpham", "Tensanpham", sanPham.Masanpham);
                return View(sanPham);
            }
        }

        // GET: Admin/SanPhams/Delete/5
        public ActionResult Delete(string id)
        {
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

        // POST: Admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            try
            {
                db.SanPhams.Remove(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Không xóa được sản phẩm này! " + ex.Message;
                return View("Delete", sanPham);
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
