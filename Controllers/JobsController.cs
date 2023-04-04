using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_1.Controllers
{
    public class JobsController : Controller
    {
        // GET: Jobs
        public ActionResult Index(string searchName, decimal? minSalary, string location, string jobType)
        {
            using (var db = new JobFinderEntities())
            {
                var jobs = db.cong_viec.Include("cong_ty").AsQueryable();

                // Tìm kiếm theo tên công việc
                if (!string.IsNullOrEmpty(searchName))
                {
                    jobs = jobs.Where(j => j.ten_cong_viec.Contains(searchName));
                }

                // Tìm kiếm theo mức lương tối thiểu
                if (minSalary.HasValue)
                {
                    jobs = jobs.Where(j => j.muc_luong_min >= minSalary.Value);
                }

                // Tìm kiếm theo vị trí làm việc
                if (!string.IsNullOrEmpty(location))
                {
                    jobs = jobs.Where(j => j.vi_tri.ToLower() == location.ToLower());
                }

                // Tìm kiếm theo hình thức làm việc
                if (!string.IsNullOrEmpty(jobType))
                {
                    jobs = jobs.Where(j => j.hinh_thuc_lam_viec.ToLower() == jobType.ToLower());
                }

                return View(jobs.ToList());
            }
        }

    }
}