using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizWebApp.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.ClientId = ConfigurationManager.AppSettings["googleClientId"];
            ViewBag.Secret = ConfigurationManager.AppSettings["googleSecret"];

            return View();
        }
    }
}
