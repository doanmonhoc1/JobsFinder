using Demo_1.Unility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var numberPhone = SessionHelper.GetSessionInfoLogin.sdt;
            ViewBag.Message = numberPhone;
            return View();
        }

        public ActionResult About()
        {
            var numberPhone = SessionHelper.GetSessionInfoLogin.sdt;
            ViewBag.Message = numberPhone;
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}