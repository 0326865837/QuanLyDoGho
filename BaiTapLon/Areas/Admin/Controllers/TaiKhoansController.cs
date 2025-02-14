﻿using System;
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
    public class TaiKhoansController : Controller
    {
        private DoGo db = new DoGo();

        // GET: Admin/TaiKhoans
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.SapTheoTen = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
           
            //Lấy danh sách tk
            var taiKhoans = db.TaiKhoans.Select(s => s);
            if (!String.IsNullOrEmpty(searchString))
            {
                taiKhoans = taiKhoans.Where(p => p.Hoten.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    taiKhoans = taiKhoans.OrderByDescending(s => s.Tendangnhap);
                    break;
                default:
                    taiKhoans = taiKhoans.OrderBy(s => s.Tendangnhap);
                    break;
            }
            int pageSize = 6; //Kích thước trang
            int pageNumber = (page ?? 1);
            return View(taiKhoans.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/TaiKhoans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TaiKhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mataikhoan,Tendangnhap,Matkhau,Loaitaikhoan,Hoten,Sodienthoai,Email,Diachi,Anh")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.TaiKhoans.Add(taiKhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // POST: Admin/TaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mataikhoan,Tendangnhap,Matkhau,Loaitaikhoan,Hoten,Sodienthoai,Email,Diachi,Anh")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Delete/5
        public ActionResult Delete(string id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null )
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // POST: Admin/TaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if ( id == Session["id"].ToString())
            {
                ViewBag.Error = "Không xóa được tài khoản  này! " ;
                return View("Delete", taiKhoan);
            }
            try
            {
                db.TaiKhoans.Remove(taiKhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Không xóa được tài khoản  này! " + ex.Message;
                return View("Delete", taiKhoan);
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
