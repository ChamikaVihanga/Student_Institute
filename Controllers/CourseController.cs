using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebAppliction.Models;
using TestWebAppliction.Models.Course;

namespace TestWebAppliction.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            CourseDbHandel cdbhandel = new CourseDbHandel();
            ModelState.Clear();
            return View(cdbhandel.GetCourse());
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(CourseModel cmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CourseDbHandel cdbhandel = new CourseDbHandel();
                    if (cdbhandel.AddCourse(cmodel))
                    {
                        ViewBag.Message = "Course Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            CourseDbHandel cdbhandel = new CourseDbHandel();
            return View(cdbhandel.GetCourse().Find(cmodel => cmodel.ID == id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CourseModel cmodel)
        {
            try
            {
                CourseDbHandel cdbhandel = new CourseDbHandel();
                cdbhandel.UpdateCourse(cmodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                CourseDbHandel cdbhandel = new CourseDbHandel();
                if (cdbhandel.DeleteCourse(id))
                {
                    ViewBag.AlertMsg = "Course Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}