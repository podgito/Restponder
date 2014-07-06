using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace DummyAPI.Controllers
{
    public class EditController : Controller
    {
        // GET: Edit
        public ActionResult Index()
        {
            //Return view similar to the create view
            //but with pre populated form and have update buttons instead of create



            return View();
        }


        public ActionResult Api(string id)
        {
            var urlBuilder = new System.UriBuilder(Request.Url.AbsoluteUri)
            {
                Path = Url.HttpRouteUrl("DefaultApi", new { controller = "Dummy", id = id }),
                Query = null,
            };

            Uri uri = urlBuilder.Uri;
            string url = urlBuilder.ToString();

            ViewBag.Url = url;
            ViewBag.Id = id;
            return View();
        }


    }
}