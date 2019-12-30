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
                "Default",
                "Default",
                "~/Default.aspx"
            );
            routes.MapPageRoute(
                "Login",
                "Login",
                "~/Login.aspx"
            );
            routes.MapPageRoute(
                "Administrator/Course",
                "Administrator/Course",
                "~/Administrator/Course.aspx"
            );
            routes.MapPageRoute(
                "Administrator/CourseSchedule",
                "Administrator/CourseSchedule",
                "~/Administrator/CourseSchedule.aspx"
            );
            routes.MapPageRoute(
                "Administrator/CourseSelect",
                "Administrator/CourseSelect",
                "~/Administrator/CourseSelect.aspx"
            );
            routes.MapPageRoute(
                "Administrator/User/Student",
                "Administrator/User/Student",
                "~/Administrator/User/Student.aspx"
            );
            routes.MapPageRoute(
                "Administrator/User/Teacher",
                "Administrator/User/Teacher",
                "~/Administrator/User/Teacher.aspx"
            );
            routes.MapPageRoute(
                "Administrator/User/Administrator",
                "Administrator/User/Administrator",
                "~/Administrator/User/Administrator.aspx"
            );
            routes.MapPageRoute(
                "Student/CourseSelect",
                "Student/CourseSelect",
                "~/Student/CourseSelect.aspx"
            );
            routes.MapPageRoute(
                "Student/CourseScore",
                "Student/CourseScore",
                "~/Student/CourseScore.aspx"
            );
            routes.MapPageRoute(
                "Teacher/Course",
                "Teacher/Course",
                "~/Teacher/Course.aspx"
            );
            routes.MapPageRoute(
                "Teacher/CourseScore",
                "Teacher/CourseScore",
                "~/Teacher/CourseScore.aspx"
            );
            routes.MapPageRoute(
                "Teacher/CourseApplication",
                "Teacher/CourseApplication",
                "~/Teacher/CourseApplication.aspx"
            );
        }
    }
}