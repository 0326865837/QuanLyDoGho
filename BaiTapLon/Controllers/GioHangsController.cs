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
    public class GioHangsController : Controller
    {
        private ShopDoGho db = new ShopDoGho();

        // GET: GioHangs
        public ActionResult Index()
        {
            string id = Session["Mataikhoan"].ToString();
            string magio = getMaGio(id).Magio;
            ViewBag.User = magio;
            return View(getAllSanPham(magio));
        }

        public GioHang getMaGio(string userId)
        {
            var giohang = (from s in db.GioHangs where s.Mataikhoan == userId select s).FirstOrDefault<GioHang>();
            return giohang;
        }
        public IList<Giohangsanpham> getAllSanPham(string magio)
        {
            //var sp1 = db.SanPhams.Join(db.Giohangsanphams, s => s.Masanpham, b => b.Masanpham, (s, b) => new { s, b })
            //    .Where(sc => sc.b.Magio == magio).Select(sc => sc.s);

            var sp = db.Giohangsanphams.Join(db.SanPhams, s => s.Masanpham, b => b.Masanpham, (s, b) => new { s, b })
                .Where(sc => sc.s.Magio == magio).Select(s => s.s);
            return sp.ToList();
        }


        public ActionResult AddGioHang(string masp)
        {
            SanPham sp = db.SanPhams.Find(masp);
            if (sp == null)
            {
                return HttpNotFound();
            }
            string id = Session["Mataikhoan"].ToString();
            Giohangsanpham hdsp = new Giohangsanpham()
            {
                Masanpham = sp.Masanpham,
                Soluongmua = 1,
                Magio = getMaGio(id).Magio,
                Trangthai = "thanhtoan",
            };
            db.Giohangsanphams.Add(hdsp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        // GET: GioHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gioHang = db.GioHangs.Find(id);
            if (gioHang == null)
            {
                return HttpNotFound();
            }
            return View(gioHang);
        }

        // GET: GioHangs/Create
        public ActionResult Create()
        {
            ViewBag.Mataikhoan = new SelectList(db.TaiKhoans, "Mataikhoan", "Tendangnhap");
            return View();
        }

        // POST: GioHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Magio,Mataikhoan")] GioHang gioHang)
        {
            if (ModelState.IsValid)
            {
                db.GioHangs.Add(gioHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Mataikhoan = new SelectList(db.TaiKhoans, "Mataikhoan", "Tendangnhap", gioHang.Mataikhoan);
            return View(gioHang);
        }

        // GET: GioHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gioHang = db.GioHangs.Find(id);
            if (gioHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mataikhoan = new SelectList(db.TaiKhoans, "Mataikhoan", "Tendangnhap", gioHang.Mataikhoan);
            return View(gioHang);
        }

        // POST: GioHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Magio,Mataikhoan")] GioHang gioHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gioHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Mataikhoan = new SelectList(db.TaiKhoans, "Mataikhoan", "Tendangnhap", gioHang.Mataikhoan);
            return View(gioHang);
        }

        // GET: GioHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gioHang = db.GioHangs.Find(id);
            if (gioHang == null)
            {
                return HttpNotFound();
            }
            return View(gioHang);
        }

        // POST: GioHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GioHang gioHang = db.GioHangs.Find(id);
            db.GioHangs.Remove(gioHang);
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
