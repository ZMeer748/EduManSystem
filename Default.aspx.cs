using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EduManSystem.App_Code;

namespace EduManSystem
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Label1.Text = CourseScheduleDBUtil.UpdateCourseID("111", "12").ToString();

            // List<string> list = new List<string>();
            // list = new string[] { "17821", "林十一", "111111", "女", "1998/11/11", "0", "1782" }.ToList();
            // Label1.Text = StudentUserDBUtil.Add("student", list).ToString();

            // Label1.Text = StudentUserDBUtil.UpdateBirthday("17821", "1998/11/11").ToString();

            // Label1.Text = StudentUserDBUtil.Add("17821", "林十一", "111111", "女", "1998/11/11", "0", "1782").ToString();

            Label1.Text = StudentUserDBUtil.GetName("17616");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Page.ClientScript.RegisterStartupScript(this.GetType(), "pop", "jqueryFun()", true);
            // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "jqueryFun();", true);
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "script", "alert('Hi');", true);
        }
    }
}