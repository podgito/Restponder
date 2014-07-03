using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DummyAPI.Controllers
{
    public class EditController : Controller
    {
        // GET: Edit
        public ActionResult Index(string id)
        {
            //Return view similar to the create view
            //but with pre populated form and have update buttons instead of create
            ViewBag.Id = id;

            return View();
        }

       
    }
}