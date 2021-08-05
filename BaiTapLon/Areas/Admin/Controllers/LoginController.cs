using BaiTapLon.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTapLon.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private DoGo db = new DoGo();
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            
            if (ModelState.IsValid)
            {
                var user = db.TaiKhoans.Where(u => u.Tendangnhap.Equals(username) && u.Matkhau.Equals(password) && u.Loaitaikhoan.Equals("admin")).ToList();
                if (user.Count() > 0)
                {
                    Session["id"] = user.FirstOrDefault().Mataikhoan;
                    Session["Username"] = user.FirstOrDefault().Tendangnhap;
                    Session["Hoten"] = user.FirstOrDefault().Hoten;
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.error = "The account is not admin !";
                }
            }

            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}