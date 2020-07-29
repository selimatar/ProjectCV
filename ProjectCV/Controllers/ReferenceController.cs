using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCV.Models.Entity;
using ProjectCV.Models.Class;

namespace ProjectCV.Controllers
{
    public class ReferenceController : Controller
    {
        // GET: Reference
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Value5 = db.TblReferences.ToList();
            return View(cs);
        }
        [HttpGet]
        public ActionResult NewReference()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewReference(TblReference p)
        {
            db.TblReferences.Add(p);
            db.SaveChanges();
            return View(p);
        }
        public ActionResult DeleteReference(int id)
        {
            var reference = db.TblReferences.Find(id);
            db.TblReferences.Remove(reference);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringReference(int id)
        {
            var reference = db.TblReferences.Find(id);
            return View("BringReference", reference);
        }

        public ActionResult UpdateReference(TblReference p)
        {
            var reference = db.TblReferences.Find(p.id);
            reference.name = p.name;
            reference.surname = p.surname;
            reference.department = p.department;
            reference.company = p.company;
            reference.position = p.position;
            reference.phone = p.phone;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}