using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IsMatch.Models;

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

        [HttpGet]
        public JsonResult GetOrderStatus(string searchtype, string keyword)
        {
            // searchtype 暂时用不到
            var r = Orders.FindAll(Orders._.SerialNumber.Contains(keyword));
            return Json(new
            { 
                code = 1, 
                message = "", 
                data = r.Select(p =>
                new OrdersVM { 
                    GoodsName = p.GoodsName, 
                    PlaceOrder = p.PlaceOrder, 
                    Nums = p.Nums, 
                    CreateTime = p.CreateTime.ToString("yyyy-MM-dd HH"), 
                    Status = p.Status 
                })
            },JsonRequestBehavior.AllowGet);
        }
    }
}