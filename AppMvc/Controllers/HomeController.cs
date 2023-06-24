using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppMvc.Controllers {
    public class HomeController : Controller {

        [HttpGet]
        [Route("")]
        public ActionResult Index() {
            return View();
        }

        [HttpGet]
        [Route("about")]
        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        [Route("contact")]
        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}