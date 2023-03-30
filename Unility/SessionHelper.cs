using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Demo_1.Unility
{
    public class SessionHelper
    {

        private static string SessionName = "UserLoginSession";
        public static nguoi_tim_viec GetSessionInfoLogin
        {
            get
            {
                nguoi_tim_viec nt = new nguoi_tim_viec();
                if (HttpContext.Current.Request.IsAuthenticated)
                {
                    if (HttpContext.Current.Session[SessionName] != null)
                    {
                        nt = HttpContext.Current.Session[SessionName] as nguoi_tim_viec;
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("~/User/Index");
                }

                return nt;
            }
        }
        public static void CreateSession(nguoi_tim_viec nt)
        {
            if (HttpContext.Current.Session[SessionName] == null)
            {
                HttpContext.Current.Session[SessionName] = nt;
            }
        }

        public static void ClearSession()
        {
            HttpContext.Current.Session[SessionName] = null;
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.Clear();
        }

        private static string SessionNameCompany = "CompanyLoginSession";
        public static cong_ty GetSessionInfoLoginCompany
        {
            get
            {
                cong_ty ct = new cong_ty();
                if (HttpContext.Current.Request.IsAuthenticated)
                {
                    if (HttpContext.Current.Session[SessionNameCompany] != null)
                    {
                        ct = HttpContext.Current.Session[SessionNameCompany] as cong_ty;
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("~/Company/Index");
                }

                return ct;
            }
        }
        public static void CreateSessionCompany(cong_ty ct)
        {
            if (HttpContext.Current.Session[SessionNameCompany] == null)
            {
                HttpContext.Current.Session[SessionNameCompany] = ct;
            }
        }

        public static void ClearSessionCompany()
        {
            HttpContext.Current.Session[SessionNameCompany] = null;
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.Clear();
        }
    }
}