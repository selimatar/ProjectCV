using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCV.Models.Entity;
using ProjectCV.Models.Class;

namespace ProjectCV.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Value1 = db.TblAbouts.ToList();
            cs.Value2 = db.TblExperiences.ToList();
            cs.Value3 = db.TblEducations.ToList();
            cs.Value4 = db.TblSkills.ToList();
            cs.Value5 = db.TblReferences.ToList();
            cs.Value6 = db.TblProjects.ToList();
            cs.Value7 = db.TblAboutPersons.ToList();
            return View(cs);
            //var degerler = db.TblAbout.ToList();
            //return View(degerler);
        }
    }
}