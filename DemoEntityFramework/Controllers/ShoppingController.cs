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

        public ActionResult Read()
        {
            var db = new dbShoppingEntities();
            var members = db.Member.OrderByDescending(m => m.UserId).ToList();
            return View(members);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Member member)
        {
            var db = new dbShoppingEntities();
            db.Member.Add(member);
            db.SaveChanges();

            return RedirectToAction("Read");
        }

        public ActionResult Edit(int id)
        {
            var db = new dbShoppingEntities();
            var member = db.Member.Where(m => m.Id == id).FirstOrDefault();
            return View(member);
        }

        [HttpPost]
        public ActionResult Edit(Member member) 
        {
            var db = new dbShoppingEntities();
            var memberData = db.Member.Where(m => m.Id == member.Id).FirstOrDefault();
            memberData.UserId = member.UserId;
            memberData.UserName = member.UserName;
            memberData.Password = member.Password;
            memberData.Email = member.Email;
            memberData.Address = member.Address;
            db.SaveChanges();

            return RedirectToAction("Read");
        }

        public ActionResult Delete(int id)
        {
            var db = new dbShoppingEntities();
            var member = db.Member.Where(m => m.Id ==id).FirstOrDefault();
            return View(member);
        }

        [HttpPost]
        public ActionResult Delete(Member member)
        {
            var db = new dbShoppingEntities();
            var memberData = db.Member.Where(m => m.Id == member.Id).FirstOrDefault();
            db.Member.Remove(memberData);
            db.SaveChanges();
            return RedirectToAction("Read");
        }

    }
}