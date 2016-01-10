using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DummyAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Dummy API";

            return View();
        }

        public ActionResult Features()
        {
            ViewBag.Title = "Features";
            return View();

                
        }

        public ActionResult Create()
        {

            ViewBag.Title = "Create";

            return View();
        }
    }
}
