using BulletinBoard.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BulletinBoard.Controllers
{
    public class HomeController : Controller
    {
        AdContext db = new AdContext();

        // GET: Home
        public ActionResult Index()
        {
            var count = db.Ads.Count();
            ViewBag.countAd = count;
            return View(db.Ads);
        }

        [HttpGet]
        public ActionResult View(int? id)
        {
            if (id != null)
            {
                Ad ad = db.Ads.Find(id);
                return View(ad);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Ad ad = db.Ads.Find(id);
            if (ad != null)
            {
                string[] typeStatus = new string[] { "Куплю", "Продам" };
                ViewBag.TypeStatusList = typeStatus;
                return View(ad);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Update(Ad ad)
        {
            if (ad != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(ad).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(ad);
        }

        [HttpGet]
        public ActionResult Create()
        {
            string[] typeStatus = new string[] { "Куплю", "Продам" };
            ViewBag.TypeStatusList = typeStatus;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Ad ad)
        {
            if (ModelState.IsValid)
            {
                db.Ads.Add(ad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Ad ad = db.Ads.Find(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            db.Ads.Remove(ad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}