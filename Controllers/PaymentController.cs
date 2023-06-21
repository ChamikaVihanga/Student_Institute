using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebAppliction.Models.Course;
using TestWebAppliction.Models.StudentCourse;
using TestWebAppliction.Models;
using TestWebAppliction.Models.Payment;

namespace TestWebAppliction.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            PaymentDbHandel pdbhandel = new PaymentDbHandel();
            ModelState.Clear();
            return View(pdbhandel.GetPayment());
        }

        public ActionResult search()
        {

            return View();
        }

        // GET: Payment/Create
        public ActionResult Create(string input1)
        {
            
            ViewBag.AlertMessage = input1;
            StudentCourseDbHandel scdbhandel = new StudentCourseDbHandel();
            var sc = scdbhandel.GetSC();
            ViewBag.sc = new SelectList(sc, "studentID", "Name");

            return View(input1);
        }

        // POST: Payment/Create
        [HttpPost]
        public ActionResult Create(PaymentModel pmodel)
        {
            try
            {
                
                StudentCourseDbHandel scdbhandel = new StudentCourseDbHandel();
                var sc = scdbhandel.GetSC();
                ViewBag.sc = new SelectList(sc, "studentID", "Name");


                StudentCourseDetailsController paymentDbHandel = new StudentCourseDetailsController();
                paymentDbHandel.GetStudentCourseDetails(9);
                /*CourseDbHandel courseModel = new CourseDbHandel();
                var a = courseModel.GetCourse();
                ViewBag.course = new SelectList(a, "CourseModelID", "CoureseName");*/

                if (ModelState.IsValid)
                {
                    PaymentDbHandel pdbhandel = new PaymentDbHandel();
                    if (pdbhandel.AddPay(pmodel))
                    {
                        ViewBag.Message = "Payment Details Added Successfully";
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

        /*public ActionResult StudentStudent(string Name)
        {

        }*/

        //Searching
        public ActionResult SearchStudent(string Name)
        {

            ScFilterDbHandel scfilterdbhandle = new ScFilterDbHandel();
            var pay = scfilterdbhandle.GetFilter();
            ViewBag.student = new SelectList(pay, "ID", "Name");




            return View();
        }

        //......................................
        //post paymet get student_course
        /* public ActionResult Payment()
         {
             return View();
         }

         public ActionResult Payment(PaymentModel pmodel)
         {
             try
             {
                 if (ModelState.IsValid)
                 {
                     PaymentDbHandel pdbhandel = new PaymentDbHandel();
                     if (pdbhandel.AddPay(pmodel))
                     {
                         ViewBag.Message = "Payment Details Added Successfully";
                         ModelState.Clear();
                     }
                 }
                 return View();
             }
             catch
             {
                 return View();
             }
         }*/

        //.......................................



        // GET: Payment/Edit/5
        public ActionResult Edit(int id)
        {
            PaymentDbHandel pdbhandel = new PaymentDbHandel();
            return View(pdbhandel.GetPayment().Find(pmodel => pmodel.Id == id));
        }

        // POST: Payment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PaymentModel pmodel)
        {
            try
            {
                PaymentDbHandel pdbhandel = new PaymentDbHandel();
                pdbhandel.UpdatePay(pmodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Payment/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                PaymentDbHandel pdbhandel = new PaymentDbHandel();
                if (pdbhandel.DeletePay(id))
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