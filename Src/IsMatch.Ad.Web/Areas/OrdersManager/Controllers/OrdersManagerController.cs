using IsMatch.Models;
using NewLife.Cube;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsMatch.Ad.Web.Areas.OrdersManager.Controllers
{
    [DisplayName("订单")]
    public class OrdersManagerController : EntityController<Orders>
    {
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Save(Orders order)
        {
            if (order.GoodsID == 0)
            {
                return Json(0, "商品为空，请检查", "");
            }
            var r = order.Insert();
            return Json(1, "", order.SerialNumber);
        }
    }
}