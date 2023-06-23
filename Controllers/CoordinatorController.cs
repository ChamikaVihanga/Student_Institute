using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using TestWebAppliction.Models;
using TestWebAppliction.Models.Coordinator;

namespace TestWebAppliction.Controllers
{
    public class CoordinatorController : Controller
    {
        // 1. *************RETRIEVE ALL STUDENT DETAILS ******************
        // GET: Student
        public ActionResult Index()
        {
            CoordinatorBdHendel cdbhandle = new CoordinatorBdHendel();
            ModelState.Clear();
            return View(cdbhandle.GetCoor());
        }

        // 2. *************ADD NEW STUDENT ******************
        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(CoordinatorModel smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CoordinatorBdHendel cdbh = new CoordinatorBdHendel();
                    if (cdbh.AddCoor(smodel))
                    {
                        ViewBag.Message = "Student Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                //return View();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        // 3. ************* EDIT Coor DETAILS ******************
        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            CoordinatorBdHendel cdbh = new CoordinatorBdHendel();
            return View(cdbh.GetCoor().Find(smodel => smodel.ID == id));
        }

        // POST: Coordinator/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CoordinatorModel smodel)
        {
            try
            {
                CoordinatorBdHendel cdbh = new CoordinatorBdHendel();
                cdbh.UpdateCoor(smodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // 4. ************* DELETE STUDENT DETAILS ******************
        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                CoordinatorBdHendel cdbh = new CoordinatorBdHendel();
                if (cdbh.DeleteCoor(id))
                {
                    ViewBag.AlertMsg = "Coordinator Deleted Successfully";
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