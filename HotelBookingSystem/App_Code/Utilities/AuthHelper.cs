using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public static class AuthHelper
    {
        public static void SignIn(User user)
        {
            HttpContext.Current.Session["UserEmail"] = user.Email;
        }

        public static void SignOut()
        {
            HttpContext.Current.Session["UserEmail"] = null;
        }

        public static User CurrentUser()
        {
            var email = HttpContext.Current.Session["UserEmail"] as string;
            if (string.IsNullOrEmpty(email)) return null;
            return DataManager.GetUserByEmail(email);
        }

        public static bool IsLoggedIn()
        {
            return CurrentUser() != null;
        }

        public static bool IsAdmin()
        {
            var u = CurrentUser();
            return u != null && u.Role == UserRole.Admin;
        }

        public static void RequireLogin()
        {
            if (!IsLoggedIn())
            {
                HttpContext.Current.Response.Redirect("~/Pages/Login.aspx");
            }
        }

        public static void RequireAdmin()
        {
            RequireLogin();
            if (!IsAdmin())
            {
                HttpContext.Current.Response.Redirect("~/Pages/Dashboard.aspx");
            }
        }
    }
