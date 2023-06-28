using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TestWebAppliction.Models;
using TestWebAppliction.Models.Coordinator;
using TestWebAppliction.Models.Student;

namespace TestWebAppliction.Controllers
{
    public class LogController : Controller
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["TestWebApCon"].ToString();
            con = new SqlConnection(constring);
        }
        public ActionResult Login(int id = 0)
        {
            /*CoordinatorBdHendel cdbh = new CoordinatorBdHendel();*/
            CoordinatorModel cmodel = new CoordinatorModel();
            return View();
        }

        [HttpPost]
        /* [ValidateAntiForgeryToken]*/
        /* public CoordinatorModel coordinatorModel =  new CoordinatorModel();*/
        public ActionResult Login(CoordinatorModel cmode)
        {
            EntityModelModel entity = new EntityModelModel();
            LogHandel logHandel = new LogHandel();


            connection();
            var a = logHandel.LogIn(cmode.UserName,cmode.Password);
            if (a)
            {
                Session["ID"] = cmode.ID.ToString();
                Session["UserName"] = cmode.UserName.ToString();
                return RedirectToAction("../Home/index");
            }
            //var coorLog = entity.CoordinatorModels.Where(x => x.UserName == cmode.UserName && x.Password == cmode.Password).FirstOrDefault();
            //if (coorLog != null)
            //{
            //    Session["ID"] = coorLog.ID.ToString();
            //    Session["UserName"] = coorLog.UserName.ToString();
            //    return RedirectToAction("StudentDash");
            //}

            return View(cmode);
        }
        public ActionResult Student()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}