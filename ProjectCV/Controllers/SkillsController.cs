using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCV.Models.Entity;
using ProjectCV.Models.Class;
using PagedList;
using PagedList.Mvc;

namespace ProjectCV.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
        DbMvcCvEntities db = new DbMvcCvEntities();

        public ActionResult Index(int page=1)
        {
            //Class1 cs = new Class1();
            var values = db.TblSkills.ToList().ToPagedList(page, 4);
            return View(values);
        }

       [HttpGet]
       public ActionResult NewSkill()
       {
           return View();
       }

       [HttpPost]
       public ActionResult NewSkill(TblSkill p)
       {
           db.TblSkills.Add(p);
           db.SaveChanges();
           return View();
       }

       public ActionResult DeleteSkill(int id)
       {
           var skill = db.TblSkills.Find(id);
           db.TblSkills.Remove(skill);
           db.SaveChanges();
           return RedirectToAction("Index");
       }

        public ActionResult BringSkill(int id)
       {
           var skill = db.TblSkills.Find(id);
           return View("BringSkill", skill);
       }

        public ActionResult UpdateSkill(TblSkill p)
        {
            var skill = db.TblSkills.Find(p.id);
            skill.skill = p.skill;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}