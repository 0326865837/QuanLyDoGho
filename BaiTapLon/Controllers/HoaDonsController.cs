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
    public class HoaDonsController : Controller
    {
        private ShopDoGho db = new ShopDoGho();

        // GET: HoaDons
        public ActionResult Index()
        {
            if (Session["Mataikhoan"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            string userId = Session["Mataikhoan"].ToString();
            if(userId != null)
            {

                var hoadon = db.HoaDons.Where(s => s.Mataikhoan.Equals(userId)).Select(s => s);
                return View(hoadon.ToList());
            }
            else
            {
                ViewBag.Thongbao = "Không có hóa đơn nào";
                return View();
            }
        }

        // GET: HoaDons/Details/5
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
            HoaDon hoaDon = db.HoaDons.Find(id);
            var hdsp = db.Hoadonsanphams.Where(s => s.Mahoadon.Equals(id)).Select(s => s).ToList();
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.HoaDon = hoaDon;
            return View(hdsp);
        }
        public IList<Giohangsanpham> getAllSanPham(string magio)
        {

            var sp = db.Giohangsanphams.Join(db.SanPhams, s => s.Masanpham, b => b.Masanpham, (s, b) => new { s, b })
                .Where(sc => sc.s.Magio == magio).Select(s => s.s);
            return sp.ToList();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string magio)
        {
            if (Session["Mataikhoan"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (magio == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Random rd = new Random();
                int mahd = rd.Next(10, 10000);
                var sp = getAllSanPham(magio).ToList();
                db.HoaDons.Add(new HoaDon()
                {
                    Mahoadon = mahd.ToString(),
                    Mataikhoan = Session["Mataikhoan"].ToString(),
                    Trangthai = "Đặt hàng",
                });
                db.SaveChanges();
                foreach(var s in sp)
                {
                    db.Hoadonsanphams.Add(new Hoadonsanpham()
                    {
                        Mahoadon = mahd.ToString(),
                        Masanpham = s.Masanpham,
                        Soluongmua = s.Soluongmua,
                    });
                    db.SaveChanges();
                }
            }

         
            return RedirectToAction("Index");
        }



    }
}
