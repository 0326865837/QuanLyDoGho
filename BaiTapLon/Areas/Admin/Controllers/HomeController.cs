﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTapLon.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if(Session["Username"] != null)
            {
                return View();
            }
            else { 
            return RedirectToAction("Login","Login");
            }
        }
       
       
    }
}