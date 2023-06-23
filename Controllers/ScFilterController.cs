using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebAppliction.Models;
using TestWebAppliction.Models.StudentCourse;
/*using SearchSortPaging.Model;*/

namespace TestWebAppliction.Controllers
{
    public class ScFilterController : Controller
    {
        // GET: ScFilter

        public ActionResult Index(int id)
        {
            ScFilterDbHandel scdbhandle = new ScFilterDbHandel();
            ModelState.Clear();
            return View(scdbhandle.GetFilter(id));
        }
        
    }
}