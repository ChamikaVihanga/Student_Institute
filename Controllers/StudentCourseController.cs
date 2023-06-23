using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebAppliction.Models;
using TestWebAppliction.Models.Course;
using TestWebAppliction.Models.StudentCourse;

namespace TestWebAppliction.Controllers
{
    public class StudentCourseController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentCourseDbHandel scdbhandle = new StudentCourseDbHandel();
            ModelState.Clear();
            return View(scdbhandle.GetSC());
        }


        // GET: Student/Create
        public ActionResult Create()
        {
            StudentDbHandel scdbhandle = new StudentDbHandel();
            var student = scdbhandle.GetStudent();
            ViewBag.student = new SelectList(student, "ID", "Name");


            CourseDbHandel courseModel = new CourseDbHandel();
            var course = courseModel.GetCourse();
            ViewBag.course = new SelectList(course, "ID", "CourseName");

            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentCourseModel smodel)
        {
            try
            {
                StudentDbHandel scdbhandle = new StudentDbHandel();
                var x = scdbhandle.GetStudent();
                ViewBag.student = new SelectList(x, "ID", "Name");

                CourseDbHandel courseModel = new CourseDbHandel();
                var a = courseModel.GetCourse();
                ViewBag.course = new SelectList(a, "ID", "CourseName");

                if (ModelState.IsValid)
                {
                    StudentCourseDbHandel scdb = new StudentCourseDbHandel();
                    if (scdb.AddSC(smodel))
                    {
                        ViewBag.Message = "Student Course Details Added Successfully";
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
            StudentDbHandel scdbhandle = new StudentDbHandel();
            var x = scdbhandle.GetStudent();
            ViewBag.student = new SelectList(x, "ID", "Name");

            CourseDbHandel courseModel = new CourseDbHandel();
            var course = courseModel.GetCourse();
            ViewBag.course = new SelectList(course, "ID", "CourseName");

            StudentCourseDbHandel scdbhandel = new StudentCourseDbHandel();
            return View(scdbhandel.GetSC().Find(smodel => smodel.ID == id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentCourseModel scmodel)
        {
            try
            {
                StudentDbHandel scdbhandle = new StudentDbHandel();
                var x = scdbhandle.GetStudent();
                ViewBag.student = new SelectList(x, "ID", "Name");

                CourseDbHandel courseModel = new CourseDbHandel();
                var course = courseModel.GetCourse();
                ViewBag.course = new SelectList(course, "ID", "CourseName");

                StudentCourseDbHandel scdbhandel = new StudentCourseDbHandel();
                scdbhandel.UpdateSC(scmodel);
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
                StudentCourseDbHandel scdbhandel = new StudentCourseDbHandel();
                if (scdbhandel.DeleteSC(id))
                {
                    ViewBag.AlertMsg = "Student-Course Deleted Successfully";
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