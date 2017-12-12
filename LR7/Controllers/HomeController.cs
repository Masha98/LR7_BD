using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using LR7.Models;

namespace LR7.Controllers
{
    public class HomeController : Controller
    {
        CountryEntities db = new CountryEntities();
        public ActionResult Index()
        {
            IEnumerable<country> country = db.country;
            ViewBag.country = country;
            return View();
        }

      

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
       
        [HttpPost]
        public string Insert(country a)
        {
            db.country.Add(a);
            db.SaveChanges();
            return "Зміни внесено";
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            country a = db.country.Find(id);
            ViewBag.id_country = a.id_country;
            ViewBag.name = a.name;
            ViewBag.capital = a.capital;
            ViewBag.region = a.region;
            return View();
        }
        [HttpPost]
        public string Edit(country a)
        {
            country ins_A = db.country.Find(a.id_country);
            ins_A.name = a.name;
            ins_A.capital = a.capital;
            ins_A.region = a.region;
            db.SaveChanges();
            return "Зміни внесено";
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            country a = db.country.Find(id);
            if (FormMethod.Get == 0)
            {
                ViewBag.country = a;
                return View("Delete");
            }
        }

        [HttpPost]
        public ActionResult Delete(country a)
        {
            db.country.Remove(db.country.Find(a.id_country));
            db.SaveChanges();
            IEnumerable<country> country = db.country;
            ViewBag.country = country;
            return View("Index");
        }
    }
}