using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EduManSystem.Student
{
    public partial class Student : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string localPath = Request.Url.LocalPath;
            if (localPath.Equals("/Student/Default") || localPath.Equals("/Student/Default.aspx") || localPath.Equals("/Student/default.aspx"))
            {
                NavHyperLink1.CssClass = "nav-link active";
            }
            else if (localPath.Equals("/Student/CourseSelect") || localPath.Equals("/Student/CourseSelect.aspx"))
            {
                NavHyperLink_Course_Select.CssClass = "nav-link active";
            }
            else if (localPath.Equals("/Student/CourseScore") || localPath.Equals("/Student/CourseScore.aspx"))
            {
                NavHyperLink_Course_Score.CssClass = "nav-link active";
            }
        }
    }
}