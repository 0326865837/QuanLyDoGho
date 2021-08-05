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
            if (Session["Mataikhoan"] == null)
            {
                return RedirectToAction("Login","Home");
            }
            string id = Session["Mataikhoan"].ToString();
            string magio = getMaGio(id).Magio;
            ViewBag.Magio = magio;
            return View(getAllSanPham(magio));
        }

        public GioHang getMaGio(string userId)
        {
            var giohang = (from s in db.GioHangs where s.Mataikhoan == userId select s).FirstOrDefault<GioHang>();
            return giohang;
        }
        public IList<Giohangsanpham> getAllSanPham(string magio)
        {

            var sp = db.Giohangsanphams.Join(db.SanPhams, s => s.Masanpham, b => b.Masanpham, (s, b) => new { s, b })
                .Where(sc => sc.s.Magio == magio).Select(s => s.s);
            return sp.ToList();
        }


        public ActionResult AddGioHang(string masp)
        {
            if (Session["Mataikhoan"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            SanPham sp = db.SanPhams.Find(masp);
            if (sp == null)
            {
                return HttpNotFound();
            }
            string id = Session["Mataikhoan"].ToString();
            string msp = db.Giohangsanphams.Where(s=>s.Masanpham.Equals(masp)).Select(s=>s).FirstOrDefault().ToString();
            if(msp == null)
            {
                Giohangsanpham hdsp = new Giohangsanpham()
                {
                    Masanpham = sp.Masanpham,
                    Soluongmua = 1,
                    Magio = getMaGio(id).Magio,
                    Trangthai = "thanhtoan",
                };
                db.Giohangsanphams.Add(hdsp);
                db.SaveChanges();
            }
            else
            {
               Giohangsanpham gio =  db.Giohangsanphams.Where(s => s.Masanpham.Equals(masp)).Select(s => s).First();
                gio.Soluongmua += 1;
                db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
        public ActionResult DeleteOnCart(string masp, string magio)
        {
            if (Session["Mataikhoan"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var sp = db.Giohangsanphams.Where(s=>s.Masanpham.Equals(masp) && s.Magio.Equals(magio)).Select(s=>s).FirstOrDefault();
            db.Giohangsanphams.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        // GET: GioHangs/Details/5
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
            GioHang gioHang = db.GioHangs.Find(id);
            if (gioHang == null)
            {
                return HttpNotFound();
            }
            return View(gioHang);
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
