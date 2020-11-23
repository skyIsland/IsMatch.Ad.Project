using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsMatch.Ad.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // http://www.xy-door.com/index2.php
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}