using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace souq_ul_taib.Controllers
{
    public class ManufacturersController : Controller
    {
        // GET: Manufacturers

        public ActionResult Insert()
        {
            ViewBag.Title = "Manufacturer Page";
            return View();
        }

        public ActionResult Update()
        {
            ViewBag.Title = "Manufacturer_Update Page";
            return View();
        }

        public ActionResult Delete()
        {
            ViewBag.Title = "Manufacturer_Delete Page";
            return View();
        }

    }
    
}