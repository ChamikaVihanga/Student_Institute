using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebAppliction.Models.Course;
using TestWebAppliction.Models.StudentCourse;
using TestWebAppliction.Models;
using TestWebAppliction.Models.Payment;
using DocumentFormat.OpenXml.Bibliography;

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
        //public ActionResult Create()
        //{

        //    /*StudentCourseDbHandel scdbhandel = new StudentCourseDbHandel();
        //    var sc = scdbhandel.GetSC();
        //    ViewBag.sc = new SelectList(sc, "studentID", "Name");*/

        //    return View();
        //}

        // POST: Payment/Create
        [HttpPost]
        public ActionResult Create(PaymentModel pmodel)
        {
            try
            {
                /* StudentCourseDetailsController paymentDbHandel = new StudentCourseDetailsController();
                 paymentDbHandel.GetStudentCourseDetails(9);*/

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


        public ActionResult Create(int id = 0)
        {
            if (id != 0)
            {
                ScFilterDbHandel scdbhandle = new ScFilterDbHandel();
                ModelState.Clear();
                //return View(scdbhandle.GetFilter(id));

                var StudentCourseDetails = scdbhandle.GetFilter(id);
                foreach (var item in StudentCourseDetails)
                {
                    ViewBag.StudentName = item.StudentModel.Name;
                    ViewBag.SelectCource = item.CourseModel.CourseName + "-" + item.CourseModel.CouresePrice;
                }


                ViewBag.StudentCourse = StudentCourseDetails;
            }

            return View();
        }

        //Searching

        public ActionResult SearchStudent()
        {
            return View();
        }


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