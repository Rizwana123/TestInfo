using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace souq_ul_taib.Controllers
{
    public class MedicinetypenamesController : Controller
    {
        // GET: Medicinetypenames

        public ActionResult Insert()
        {
            ViewBag.Title = "Medicine_Type_Insert Page";
            return View();
        }

        public ActionResult Update()
        {
            ViewBag.Title = "Medicine_Type_Update Page";
            return View();
        }

        public ActionResult Delete()
        {
            ViewBag.Title = "Medicine_Type_Delete Page";
            return View();
        }
    }
}