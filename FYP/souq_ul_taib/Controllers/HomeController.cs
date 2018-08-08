using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace souq_ul_taib.Controllers
{
    public class HomeController : Controller
    {

       
        public ActionResult Index(string login)
        {
            ViewBag.Title = "Home Page";
            Session["UserName"] = login;
            if(Session["UserName"].ToString()=="")
            {
                return RedirectToAction("signup");
            }
            else
            {
                return View();
            }


        }

        
        public ActionResult signup()
        {

            ViewBag.Title = "Home Page";
           
            return View();
        }
        public ActionResult logout()
        {

            Session["UserName"] = "";
            Session.Abandon();
            return Redirect("signup");

          

        }
    }
}
