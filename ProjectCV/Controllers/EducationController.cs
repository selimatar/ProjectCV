using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCV.Models.Entity;
using ProjectCV.Models.Class;

namespace ProjectCV.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        DbMvcCvEntities db = new DbMvcCvEntities();

        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Value3 = db.TblEducations.ToList();
            return View(cs);
        }
        [HttpGet]
        public ActionResult NewEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewEducation(TblEducation p)
        {
            db.TblEducations.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult DeleteEducation(int id)
        {
            var education = db.TblEducations.Find(id);
            db.TblEducations.Remove(education);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringEducation(int id)
        {
            var education = db.TblEducations.Find(id);
            return View("BringEducation", education);
        }
        public ActionResult Update(TblEducation p )
        {
            var values = db.TblEducations.Find(p.id);
            values.title = p.title;
            values.subtitle = p.subtitle;
            values.department = p.department;
            values.date = p.date;
            values.gpa = p.gpa;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}