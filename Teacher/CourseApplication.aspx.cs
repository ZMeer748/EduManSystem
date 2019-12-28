using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EduManSystem.App_Code;

namespace EduManSystem.Teacher
{
    public partial class CourseApplication : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["account_user_type"] == null)
            {
                Response.Redirect("~/");
            }
            else if (!Session["account_user_type"].Equals("教师"))
            {
                Response.Redirect("~/");
            }
        }

        protected void Button_Course_Application_Click(object sender, EventArgs e)
        {
            string course_id = Input_Course_ID.Text;
            string course_name = Input_Course_Name.Text;
            string course_credit = Input_Course_Credit.Text;
            string tch_id = Session["account_user_id"].ToString();
            bool isChanged = CourseDBUtil.Add(course_id, course_name, course_credit, tch_id);
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "开课申请成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "开课申请失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
        }
    }
}