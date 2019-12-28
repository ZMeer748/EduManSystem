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
    public partial class Course : System.Web.UI.Page
    {
        protected void Data_Bind()
        {
            string tch_id = Session["account_user_id"].ToString();
            string sql1 = "SELECT course_schedule.course_schedule_id AS `课程编号`, course.course_name AS `课程名称`, class.class_name AS `教授班级`, course_schedule.course_schedule_type AS `课程类型`, course_schedule.course_schedule_status AS `课程状态` FROM ((class INNER JOIN department ON class.dept_id = department.dept_id) LEFT JOIN course_schedule ON department.dept_id = course_schedule.dept_id) LEFT JOIN course ON course_schedule.course_id = course.course_id WHERE tch_id = '" + tch_id + "'";
            GeneralUtil.GridViewInit(GridView1, sql1);
        }

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

            Data_Bind();
        }
    }
}