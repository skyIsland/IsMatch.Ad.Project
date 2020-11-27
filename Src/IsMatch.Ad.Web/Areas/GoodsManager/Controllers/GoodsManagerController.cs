using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IsMatch.Models;
using System.ComponentModel;
using NewLife.Cube;
using XCode;
using IsMatch.Models.Enum;

namespace IsMatch.Ad.Web.Areas.GoodsManager.Controllers
{
    [DisplayName("商品")]
    public class GoodsManagerController : EntityController<Goods>
    {
        [AllowAnonymous]
        public ActionResult GetList(string categoryId)
        {
            var result = Goods.FindAll($"CategoryID={categoryId} and State = '{StateEnum.Enabled.ToString()}'", "ID", null, 0, 0);
            var list = result.OrderBy(p => p.ID).Select(p =>
            new GoodsVM
            {
                Text = p.Name,
                Value = p.ID,
                Price = p.Price,
                Remark = p.Remark
            });
            return Json(1, "", list);
        }

        [AllowAnonymous]
        public ActionResult GetById(int goodsId)
        {
            var result = Goods.FindByID(goodsId);    
            
            if(result == null)
            {
                return Json(0, "商品信息获取失败。", "");
            }

            return Json(1, "", result);
        }
    }
}