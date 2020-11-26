using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IsMatch.Models;
using System.ComponentModel;
using NewLife.Cube;
using XCode;

namespace IsMatch.Ad.Web.Areas.GoodsManager.Controllers
{
    [DisplayName("商品")]
    public class GoodsManagerController : EntityController<Goods>
    {
        [AllowAnonymous]
        public ActionResult GetList(string categoryId)
        {
            var result = Goods.FindAll("CategoryID", categoryId);
            return Json(1, "", result.OrderBy(p => p.ID).Select(p => new { Text = p.Name, Value = p.ID }));
        }
    }
}