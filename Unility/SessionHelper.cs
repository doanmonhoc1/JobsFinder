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
                    HttpContext.Current.Response.Redirect("~/User/Login");
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
    }
}