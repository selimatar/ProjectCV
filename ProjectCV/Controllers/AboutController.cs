using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCV.Models.Entity;
using ProjectCV.Models.Class;

namespace ProjectCV.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        DbMvcCvEntities db = new DbMvcCvEntities();

        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Value1 = db.TblAbouts.ToList();
            cs.Value7 = db.TblAboutPersons.ToList();
            return View(cs);
        }

        [HttpGet]
        public ActionResult NewTrait()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewTrait(TblAboutPerson p)
        {
            db.TblAboutPersons.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult DeleteTrait(int id)
        {
            var trait = db.TblAboutPersons.Find(id);
            db.TblAboutPersons.Remove(trait);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringDatas(int id)
        {
            var datas = db.TblAbouts.Find(id);
            return View("BringDatas", datas);    
        }

        public ActionResult Update(TblAbout p)
        {
            var values = db.TblAbouts.Find(p.id);
            values.name = p.name;
            values.surname = p.surname;
            values.address = p.address;
            values.phone = p.phone;
            values.mail = p.mail;
            values.about = p.about;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TraitDatas(int id)
        {
            var datas = db.TblAboutPersons.Find(id);
            return View("TraitDatas", datas);
        }

        public ActionResult UpdateTrait(TblAboutPerson p)
        {
            var values = db.TblAboutPersons.Find(p.id);
            values.trait = p.trait;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}