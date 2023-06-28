using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebAppliction.Models;
using TestWebAppliction.Models.Batch;
using TestWebAppliction.Models.Course;
using TestWebAppliction.Models.StudentCourse;

namespace TestWebAppliction.Controllers
{
    public class StuCourBatchController : Controller
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

            BatchDbhandel batchDbhandel = new BatchDbhandel();
            var batch = batchDbhandel.GetBatch();
            ViewBag.batch = new SelectList(batch, "ID", "BatchNumber");

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

                BatchDbhandel batchDbhandel = new BatchDbhandel();
                var batch = batchDbhandel.GetBatch();
                ViewBag.batch = new SelectList(batch, "ID", "BatchNumber");

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


        //public ActionResult Create(int id = 0)
        //{
        //    if (id != 0)
        //    {
        //        ScFilterDbHandel scFilterDbHandel = new ScFilterDbHandel();
        //        /*ModelState.Clear();*/

        //        var StudentCourseDetails = scFilterDbHandel.GetFilter(id);
        //        foreach (var item in StudentCourseDetails)
        //        {
        //            ViewBag.StudentName = item.StudentModel.Name;
        //        }


        //        ViewBag.StudentCourse = StudentCourseDetails;
        //    }
        //    return View();
        //}

        // search
        /*public ActionResult search()
        {

            return View();
        }
*/
        //Searching

        public ActionResult SearchStudent()
        {

            return View();
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

            BatchDbhandel batchDbhandel = new BatchDbhandel();
            var batch = batchDbhandel.GetBatch();
            ViewBag.batch = new SelectList(batch, "ID", "BatchNumber");

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

                BatchDbhandel batchDbhandel = new BatchDbhandel();
                var batch = batchDbhandel.GetBatch();
                ViewBag.batch = new SelectList(batch, "ID", "BatchNumber");

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