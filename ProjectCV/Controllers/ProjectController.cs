using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCV.Models.Entity;
using ProjectCV.Models.Class;

namespace ProjectCV.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Value6 = db.TblProjects.ToList();
            return View(cs);
        }
        [HttpGet]
        public ActionResult NewProject()
        {

            return View();
        }

        [HttpPost]
        public ActionResult NewProject(TblProject p)
        {
            db.TblProjects.Add(p);
            db.SaveChanges();
            return View(p);
        }

        public ActionResult DeleteProject(int id)
        {
            var project = db.TblProjects.Find(id);
            db.TblProjects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringProject(int id)
        {
            var project = db.TblProjects.Find(id);
            return View("BringProject", project);
        }

        public ActionResult UpdateProject(TblProject p)
        {
            var values = db.TblProjects.Find(p.id);
            values.project = p.project;
            values.type = p.type;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}