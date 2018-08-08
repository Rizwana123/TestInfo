using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace souq_ul_taib.Controllers
{
    public class GenericnamesController : Controller
    {
        // GET: Genericnames
       
        public ActionResult Insert()
        {
            ViewBag.Title = "Generic_Name_Insert Page";
            return View();
        }

        public ActionResult Update()
        {
            ViewBag.Title = "Generic_Name_Update Page";
            return View();
        }

        public ActionResult Delete()
        {
            ViewBag.Title = "Generic_Name_Delete Page";
            return View();
        }
    }
}