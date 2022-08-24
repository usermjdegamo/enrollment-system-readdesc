using EnrollmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnrollmentSystem.Controllers
{
    public class lolcController : Controller
    {
        schoolEntities db = new schoolEntities();

        // GET: lolc
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCourses()
        {
            using (schoolEntities db = new schoolEntities())
            {
                var courses = db.records.ToList();
                return Json(new { data = courses }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public JsonResult Edit(int id)
        {

            var course = db.records.Where(a => a.Id == id).FirstOrDefault();

            return Json(course, JsonRequestBehavior.AllowGet);
        }

        public ActionResult save(record rec)
        {
            
            bool status = false;

            if (ModelState.IsValid)
            {
                using (schoolEntities db = new schoolEntities())
                {
                    db.records.Add(rec);
                    db.SaveChanges();
                    status = true;
                }

               
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}