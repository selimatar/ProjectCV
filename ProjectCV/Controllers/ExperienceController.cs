using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCV.Models.Entity;
using ProjectCV.Models.Class;

namespace ProjectCV.Controllers
{
    public class ExperienceController : Controller
    {
        
        // GET: Experience
        DbMvcCvEntities db = new DbMvcCvEntities();

        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Value2 = db.TblExperiences.ToList();
            return View(cs);
        }
        [HttpGet]
        public ActionResult NewExperience()
        {
            return View();
        }

        [HttpPost]        
        public ActionResult NewExperience(TblExperience p)
        {
            db.TblExperiences.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult DeleteExperience(int id)
        {
            var experience = db.TblExperiences.Find(id);
            db.TblExperiences.Remove(experience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringExperience(int id)
        {
            var data = db.TblExperiences.Find(id);
            return View("BringExperience", data);
        }

        public ActionResult UpdateExperience(TblExperience p)
        {
            var value = db.TblExperiences.Find(p.id);
            value.title = p.title;
            value.subtitle = p.subtitle;
            value.company = p.company;
            value.date = p.date;
            value.details = p.details;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}