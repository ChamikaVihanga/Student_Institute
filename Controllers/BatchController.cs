﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebAppliction.Models;
using TestWebAppliction.Models.Batch;
using TestWebAppliction.Models.Course;

namespace TestWebAppliction.Controllers
{
    public class BatchController : Controller
    {
        // GET: Batch
        public ActionResult Index()
        {
            BatchDbhandel dbhandle = new BatchDbhandel();
            ModelState.Clear();
            return View(dbhandle.GetBatch());
        }

     
        // GET: Batch/Create
        public ActionResult Create()
        {
            CourseDbHandel cDbHandel = new CourseDbHandel();
            var course = cDbHandel.GetCourse();
            ViewBag.Course = new SelectList(course, "ID", "CourseName");

            return View();
        }

        // POST: batch/Create
        [HttpPost]
        public ActionResult Create(BatchModel bmodel)
        {
            try
            {
                CourseDbHandel cDbHandel = new CourseDbHandel();
                var course = cDbHandel.GetCourse();
                ViewBag.Course = new SelectList(course, "ID", "CourseName");

                if (ModelState.IsValid)
                {
                    BatchDbhandel sdb = new BatchDbhandel();
                    if (sdb.AddBatch(bmodel))
                    {
                        ViewBag.Message = "Batch Details Added Successfully";
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

        // GET: Batch/Edit/5
        public ActionResult Edit(int id)
        {
            BatchDbhandel sdb = new BatchDbhandel();

            CourseDbHandel cDbHandel = new CourseDbHandel();
            var course = cDbHandel.GetCourse();
            ViewBag.Course = new SelectList(course, "ID", "CourseName");

            return View(sdb.GetBatch().Find(smodel => smodel.ID == id));
        }

        // POST: Batch/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BatchModel smodel)
        {
            try
            {
                CourseDbHandel cDbHandel = new CourseDbHandel();
                var course = cDbHandel.GetCourse();
                ViewBag.Course = new SelectList(course, "ID", "CourseName");

                BatchDbhandel sdb = new BatchDbhandel();
                sdb.UpdateBatch(smodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Batch/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                BatchDbhandel sdb = new BatchDbhandel();
                if (sdb.DeleteBatch(id))
                {
                    ViewBag.AlertMsg = "Batch Deleted Successfully";
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