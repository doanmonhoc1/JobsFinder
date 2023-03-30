using Data;
using Demo_1.Models;
using Demo_1.Unility;
using Demo_1.Models.LoginCompanyViewModel;
using Demo_1.Models.RegisterCompanyViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using bc = BCrypt.Net;

namespace Demo_1.Controllers
{
    public class CompanyController : Controller
    {
        CompanyModel _companyModel;
        public CompanyModel CompanyModel { get { return _companyModel ?? (_companyModel = new CompanyModel()); } private set { } }

        public ActionResult Index()
        {
            LoginCompanyViewModel md = new LoginCompanyViewModel();
            return View(md);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginCompanyViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var md = CompanyModel.CheckLogin(obj.PhoneNumber, obj.Password);

                if (md != null)
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, FormsAuthentication.FormsCookieName, DateTime.Now, DateTime.Now.AddDays(2), false, md.sdt, FormsAuthentication.FormsCookiePath);
                    string encTicket = FormsAuthentication.Encrypt(ticket);
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                    SessionHelper.CreateSessionCompany(md);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Error", "Số điện thoại hoặc mật khẩu không đúng");
                }
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            SessionHelper.ClearSessionCompany();
            return Redirect("/Company/Index");
        }

        [HttpGet]
        public ActionResult Register()
        {
            RegisterCompanyViewModel md2 = new RegisterCompanyViewModel();
            return View(md2);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterCompanyViewModel model)
        {
            var check = new CompanyModel();
            if (check.CheckPhoneNumber(model.PhoneNumber))
            {
                ModelState.AddModelError("PhoneNumber", "Số điện thoại đã tồn tại");
                return View(model);
            }
            else
            {
                var user = new cong_ty
                {
                    sdt = model.PhoneNumber,
                    mat_khau = bc.BCrypt.HashPassword(model.Password),
                    ten_cong_ty = model.Name
                };
                using (var db = new JobFinderEntities())
                {
                    db.cong_ty.Add(user);
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "Home");
            }
        }
    }
}