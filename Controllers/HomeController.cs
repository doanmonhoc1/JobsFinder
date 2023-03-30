using Data;
using Demo_1.Unility;
using Demo_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_1.Controllers
{
    [Authorize]
    [AllowAnonymous]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllJobs()
        {
            using (var db = new JobFinderEntities())
            {
                var jobs = db.cong_viec.ToList();
                return PartialView(jobs);
            }
        }

        public ActionResult JobDetails(int id)
        {
            using (var db = new JobFinderEntities())
            {
                var job = db.cong_viec.Find(id);
                if (job == null)
                {
                    return HttpNotFound();
                }
                return View(job);
            }
        }
    }
}