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
            if (string.IsNullOrEmpty(order.VideoNo))
            {
                return Json(0, "作品Id为空，请检查", "");
            }

            // 10分钟内一个ip只能下单3次
            var ip = NewLife.Web.WebHelper.UserHost;
            var hasOrderCount = Orders.FindCount(Orders._.CreateIP == ip & Orders._.CreateTime > DateTime.Now.AddMinutes(-10));
            if (hasOrderCount >= 3)
            {
                return Json(0, "10分钟内一个ip只能下单3次", "");
            }

            // 10分钟内一个作品id只能下单1次
            hasOrderCount = Orders.FindCount(Orders._.VideoNo == order.VideoNo 
                & Orders._.CreateTime > DateTime.Now.AddMinutes(-10));
            if (hasOrderCount >= 1)
            {
                return Json(0, "10分钟内一个作品id只能下单1次", "");
            }

            var r = order.Insert();
            return Json(1, "", order.SerialNumber);
        }
    }
}