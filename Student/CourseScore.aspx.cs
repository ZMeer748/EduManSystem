using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EduManSystem.App_Code;

namespace EduManSystem.Student
{
    public partial class CourseScore : System.Web.UI.Page
    {
        protected void Data_Bind()
        {
            string stu_id = Session["account_user_id"].ToString();
            string dept_id = ClassDBUtil.GetDeptID(StudentUserDBUtil.GetClassID(stu_id));
            string sql1 = "SELECT course_schedule.course_schedule_id AS `课程编号`, course.course_name AS `课程名称`, course_schedule.course_schedule_type AS `课程类型`, course.course_credit AS `课程学分`, course_select.course_select_score AS `课程成绩` FROM (course_schedule INNER JOIN course ON course_schedule.course_id = course.course_id) INNER JOIN course_select ON course_select.course_schedule_id = course_schedule.course_schedule_id WHERE course_select.stu_id = '" + stu_id + "' AND course_select.course_select_score <> 0";
            GeneralUtil.GridViewInit(GridView1, sql1);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["account_user_type"] == null)
            {
                Response.Redirect("~/");
            }
            else if (!Session["account_user_type"].Equals("学生"))
            {
                Response.Redirect("~/");
            }

            Data_Bind();
        }
    }
}