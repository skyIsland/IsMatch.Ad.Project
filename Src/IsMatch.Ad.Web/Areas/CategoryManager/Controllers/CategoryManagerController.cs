using NewLife.Cube;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IsMatch.Models;
using System.ComponentModel;

namespace IsMatch.Ad.Web.Areas.CategoryManager.Controllers
{
    [DisplayName("分类")]
    public class CategoryManagerController : EntityController<Category>
    {
        [AllowAnonymous]
        public ActionResult GetList()
        {
            var result = Category.FindAll();
            return Json(1, "", result.Select(p => new { Text = p.Name, Value = p.ID }));
        }
    }
}