using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebAppliction.Models.Clerk;
using TestWebAppliction.Models.Coordinator;

namespace TestWebAppliction.Controllers
{
    public class ClerkController : Controller
    {
        // GET: Clerk
        public ActionResult Index()
        {
            ClerkDbHandel cdbhandle = new ClerkDbHandel();
            ModelState.Clear();
            return View(cdbhandle.GetCLerk());
        }

        // 2. *************ADD NEW Clerk ******************
        // GET: Clerk/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clerk/Create
        [HttpPost]
        public ActionResult Create(S_Clerk cmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ClerkDbHandel cdbh = new ClerkDbHandel();
                    if (cdbh.AddClark(cmodel))
                    {
                        ViewBag.Message = "Student Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                //return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        // 3. ************* EDIT Clerk DETAILS ******************
        // GET: Clerk/Edit/5
        public ActionResult Update(int id)
        {
            ClerkDbHandel cdbh = new ClerkDbHandel();
            return View(cdbh.GetCLerk().Find(smodel => smodel.Id == id));
        }

        // POST: Clerk/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, S_Clerk cmodel)
        {
            try
            {
                ClerkDbHandel cdbh = new ClerkDbHandel();
                cdbh.UpdateClerk(cmodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // 4. ************* DELETE Clerk DETAILS ******************
        // GET: Clerk/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ClerkDbHandel cdbh = new ClerkDbHandel();
                if (cdbh.DeleteClerk(id))
                {
                    ViewBag.AlertMsg = "Clerck Deleted Successfully";
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