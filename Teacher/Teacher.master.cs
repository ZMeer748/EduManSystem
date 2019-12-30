using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EduManSystem.Teacher
{
    public partial class Teacher : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string localPath = Request.Url.LocalPath;
            if (localPath.Equals("/Teacher/Default") || localPath.Equals("/Teacher/Default.aspx") || localPath.Equals("/Teacher/default.aspx"))
            {
                NavHyperLink1.CssClass = "nav-link active";
            }
            else if (localPath.Equals("/Teacher/Course") || localPath.Equals("/Teacher/Course.aspx"))
            {
                NavHyperLink_Course.CssClass = "nav-link active";
            }
            else if (localPath.Equals("/Teacher/CourseScore") || localPath.Equals("/Teacher/CourseScore.aspx"))
            {
                NavHyperLink_Course_Score.CssClass = "nav-link active";
            }
            else if (localPath.Equals("/Teacher/CourseApplication") || localPath.Equals("/Teacher/CourseApplication.aspx"))
            {
                NavHyperLink_Course_Application.CssClass = "nav-link active";
            }

        }
    }
}