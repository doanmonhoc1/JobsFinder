using Data;
using Demo_1.Models;
using Demo_1.Models.LoginViewModel;
using Demo_1.Models.RegisterViewModel;
using Demo_1.Unility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Net.Mail;
using System.Net;
using bc = BCrypt.Net;

namespace Demo_1.Controllers
{
    public class UserController : Controller
    {
        IUserModel _userModel;
        public IUserModel UserModel { get { return _userModel ?? (_userModel = new UserModel()); } private set { } }

        public ActionResult Index()
        {
            LoginViewModel md = new LoginViewModel();
            return View(md);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var md = UserModel.CheckLogin(obj.PhoneNumber, obj.Password);

                if(md != null)
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, FormsAuthentication.FormsCookieName, DateTime.Now, DateTime.Now.AddDays(2), false, md.sdt, FormsAuthentication.FormsCookiePath);
                    string encTicket = FormsAuthentication.Encrypt(ticket);
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                    SessionHelper.CreateSession(md);

                    return RedirectToAction("Index", "Home");
                } else
                {
                    ModelState.AddModelError("Error", "Số điện thoại hoặc mật khẩu không đúng");
                }
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            SessionHelper.ClearSession();
            return Redirect("/User/Login");
        }

        [HttpGet]
        public ActionResult Register()
        {
            RegisterViewModel md2 = new RegisterViewModel();
            return View(md2);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            var check = new UserModel();
            if (check.CheckPhoneNumber(model.PhoneNumber))
            {
                ModelState.AddModelError("PhoneNumber", "Số điện thoại đã tồn tại");
                return View(model);
            }
            else
            {
                var user = new nguoi_tim_viec
                {
                    sdt = model.PhoneNumber,
                    mat_khau = model.Password,
                    ho_ten = model.Name,
                    email = model.Email
                };
                using (var db = new JobFinderEntities())
                {
                    db.nguoi_tim_viec.Add(user);
                    db.SaveChanges();
                }

                // Chuyển hướng đến trang chủ
                return RedirectToAction("Index", "Home");
            }
        }

    }
}