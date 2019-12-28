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
    public partial class CourseScore : System.Web.UI.Page
    {
        string course_schedule_id;

        protected void Data_Bind()
        {
            string tch_id = Session["account_user_id"].ToString();
            string sql1 = "SELECT student.stu_id AS `学生学号`, stu_name AS `学生姓名`, course_select_score AS `课程成绩` FROM (((course_select INNER JOIN course_schedule ON course_select.course_schedule_id = course_schedule.course_schedule_id) INNER JOIN course ON course_schedule.course_id = course.course_id) INNER JOIN teacher ON course.tch_id = teacher.tch_id) INNER JOIN student ON course_select.stu_id = student.stu_id WHERE course_schedule.course_schedule_id = '" + course_schedule_id + "' AND teacher.tch_id = '" + tch_id + "'";
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

        protected void Button_Course_Search_Click(object sender, EventArgs e)
        {
            course_schedule_id = Input_Course_Schedule_ID.Text;
            Data_Bind();
            if (GridView1.Rows[0].Visible)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "查找课程信息成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "当前教师账户无该课程信息。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
        }

        protected void Button_Score_Entry_Click(object sender, EventArgs e)
        {
            course_schedule_id = Input_Course_Schedule_ID.Text;
            string stu_id = Input_Student_ID.Text;
            string score = Input_Course_Select_Score.Text;
            bool isChanged = CourseSelectDBUtil.UpdateScore(course_schedule_id + stu_id, score);
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "录入成绩成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "录入成绩失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            Data_Bind();
        }
    }
}