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
    public class TaiKhoansController : Controller
    {
        private ShopDoGho db = new ShopDoGho();

        // GET: TaiKhoans
        public ActionResult Index(string id)
        {
            if (Session["Mataikhoan"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            TaiKhoan tk = db.TaiKhoans.Find(id);
            return View(tk);
        }

        // GET: TaiKhoans/Details/5
        public ActionResult Details(string id)
        {
            if (Session["Mataikhoan"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
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



        // GET: TaiKhoans/Edit/5
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

        // POST: TaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string Tendangnhap, string Matkhau, string Hoten, string Sodienthoai, string Email, string Diachi)
        {
            if (Session["Mataikhoan"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            string matk = Session["Mataikhoan"].ToString();
            if(matk == null)
            {
                return View("Edit");
            }
            else
            {
                TaiKhoan tk = db.TaiKhoans.Where(e => e.Mataikhoan.Equals(matk)).Select(s => s).FirstOrDefault<TaiKhoan>();
                var f = Request.Files["anh"];

                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/wwwroot/images/accout/" + FileName);
                    f.SaveAs(UploadPath);
                    tk.Anh = FileName;
                }
                tk.Tendangnhap = Tendangnhap;
                tk.Matkhau = Matkhau;
                tk.Hoten = Hoten;
                tk.Sodienthoai = Sodienthoai;
                tk.Email = Email;
                tk.Diachi = Diachi;
                db.Entry(tk).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Content = "Cập nhật thành công";
            }
            return RedirectToAction("Login","Home");
        }

        // GET: TaiKhoans/Delete/5
        public ActionResult Delete(string id)
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

        // POST: TaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            db.TaiKhoans.Remove(taiKhoan);
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
