using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebAppliction.Models;
using TestWebAppliction.Models.Batch;
using TestWebAppliction.Models.Course;

namespace TestWebAppliction.Controllers
{
    public class StudentController : Controller
    {

        // GET: Student
        public ActionResult Index()
        {
            StudentDbHandel dbhandle = new StudentDbHandel();
            ModelState.Clear();
            return View(dbhandle.GetStudent());
     
        }

     
        // GET: Student/Create
        public ActionResult Create()
        {
            //BatchDbhandel bdbhange = new BatchDbhandel();
            //var batch = bdbhange.GetBatch();
            //ViewBag.batch = new SelectList(batch, "ID", "BatchName");

            //CourseDbHandel cdbhandel = new CourseDbHandel();
            //var course = cdbhandel.GetCourse();
            //ViewBag.course = new SelectList(course, "ID", "CourseName");

            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel smodel)
        {
            
            try
            {
                //BatchDbhandel bdbhange = new BatchDbhandel();
                //var batch = bdbhange.GetBatch();
                //ViewBag.batch = new SelectList(batch, "ID", "BatchName");

                //CourseDbHandel cdbhandel = new CourseDbHandel();
                //var course = cdbhandel.GetCourse();
                //ViewBag.course = new SelectList(course, "ID", "CourseName");

                if (ModelState.IsValid)
                {
                    StudentDbHandel sdb = new StudentDbHandel();
                    if (sdb.AddStudent(smodel))
                    {
                        ViewBag.Message = "Student Details Added Successfully";
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
            StudentDbHandel sdb = new StudentDbHandel();

            //BatchDbhandel bdbhange = new BatchDbhandel();
            //var batch = bdbhange.GetBatch();
            //ViewBag.batch = new SelectList(batch, "ID", "BatchName");
            //CourseDbHandel cdbhandel = new CourseDbHandel();
            //var course = cdbhandel.GetCourse();
            //ViewBag.course = new SelectList(course, "ID", "CourseName");

            return View(sdb.GetStudent().Find(smodel => smodel.ID == id));
            


        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentModel smodel)
        {
            try
            {
               

                //CourseDbHandel cdbhandel = new CourseDbHandel();
                //var course = cdbhandel.GetCourse();
                //ViewBag.course = new SelectList(course, "ID", "CourseName");

                //BatchDbhandel bdbhange = new BatchDbhandel();
                //var batch = bdbhange.GetBatch();
                //ViewBag.batch = new SelectList(batch, "ID", "BatchName");

                StudentDbHandel sdb = new StudentDbHandel();
                sdb.UpdateDetails(smodel);
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
                StudentDbHandel sdb = new StudentDbHandel();
                if (sdb.DeleteStudent(id))
                {
                    ViewBag.AlertMsg = "Student Deleted Successfully";
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

