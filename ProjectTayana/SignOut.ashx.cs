using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ProjectTayana
{
    /// <summary>
    /// SignOut 的摘要描述
    /// </summary>
    public class SignOut : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session != null)
            {
                context.Session.Abandon();
                context.Session.RemoveAll();
            }
            HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            authenticationCookie.Expires = DateTime.Now.AddYears(-1);
            context.Response.Cookies.Add(authenticationCookie);
            FormsAuthentication.SignOut();
            context.Response.Redirect("Index.aspx", true);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}