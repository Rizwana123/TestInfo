using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace souq_ul_taib.Controllers
{
    public class MedicinesController : Controller
    {
        // GET: Medicines

        public ActionResult Insert()
        {
            ViewBag.Title = "Medicine_Insert Page";
            return View();
        }

        public ActionResult Update()
        {
            ViewBag.Title = "Medicine_Insert Page";
            return View();
        }

        public ActionResult Delete()
        {
            ViewBag.Title = "Medicine_Delete Page";
            return View();
        }


    }
}