using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace EduManSystem
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // Add Routes.
            RegisterCustomRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

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

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "ProductsByCategoryRoute",
                "Category/{categoryName}",
                "~/ProductList.aspx"
            );
            routes.MapPageRoute(
                "Default",
                "Default",
                "~/Default.aspx"
            );
            routes.MapPageRoute(
                "Empty",
                "",
                "~/Default.aspx"
            );
            routes.MapPageRoute(
                "Login",
                "Login",
                "~/Login.aspx"
            );
            routes.MapPageRoute(
                "Student/Course/Selectable",
                "Student/Course/Selectable",
                "~/Student/Course/Selectable.aspx"
            );
        }
    }
}