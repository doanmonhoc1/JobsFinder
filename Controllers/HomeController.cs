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
            using (var db = new JobFinderEntities())
            {
                var jobs = db.cong_viec.Include("cong_ty").ToList();
                return PartialView(jobs);
            }
        }

        public ActionResult JobDetails(int id)
        {
            using (var db = new JobFinderEntities())
            {
                var job = db.cong_viec.Include("cong_ty").FirstOrDefault(j => j.id == id);
                if (job != null)
                {
                    return View(job);
                }
            }
            return RedirectToAction("Index");
        }
    }
}