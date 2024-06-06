using DemoEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoEntityFramework.Controllers
{
    public class ShoppingController : Controller
    {
        // GET: Shopping
        public ActionResult Index()
        {
            var db = new dbShoppingEntities();
            var model = db.OrderDetail.Where(m => m.UserId == "Bonny456" && m.Price >50).ToList();
            return View(model);
        }
    }
}