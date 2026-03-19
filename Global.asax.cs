using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SoanPha
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["login"] = false;
            Session["uname"] = "";
            Session["pword"] = "";
            Session["fname"] = "";
            Session["type"] = "USER";
            Session["public"] = true;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Session["login"] = false;
            Session["uname"] = "";
            Session["pword"] = "";
            Session["fname"] = "";
            Session["type"] = "";
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}