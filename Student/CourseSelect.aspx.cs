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
    public partial class CourseSelect : System.Web.UI.Page
    {
        protected void Data_Bind()
        {
            string stu_id = Session["account_user_id"].ToString();
            string dept_id = ClassDBUtil.GetDeptID(StudentUserDBUtil.GetClassID(stu_id));
            string sql1 = "SELECT course_schedule.course_schedule_id AS `课程编号`, course.course_name AS `课程名称`, course_schedule.course_schedule_type AS `课程类型`, course_credit AS `课程学分`, course_schedule.course_schedule_capacity AS `容量`, course_schedule.course_schedule_capacity - course_selected_count.selected_count AS `余量` FROM (course_schedule INNER JOIN course ON course_schedule.course_id = course.course_id) LEFT JOIN course_selected_count ON course_schedule.course_schedule_id = course_selected_count.course_schedule_id WHERE course_schedule.dept_id = '" + dept_id + "' AND course_schedule.course_schedule_id NOT IN (SELECT course_schedule_id FROM course_select WHERE stu_id = '" + stu_id + "')";
            GeneralUtil.GridViewInit(GridView1, sql1);

            string sql2 = "SELECT course_schedule.course_schedule_id AS `课程编号`, course.course_name AS `课程名称`, course_schedule.course_schedule_type AS `课程类型`, course_credit AS `课程学分` FROM (course_schedule INNER JOIN course ON course_schedule.course_id = course.course_id) INNER JOIN course_select ON course_select.course_schedule_id = course_schedule.course_schedule_id WHERE course_select.stu_id = '" + stu_id + "' AND course_select.course_select_score = 0";
            GeneralUtil.GridViewInit(GridView2, sql2);
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int row;
                try
                {
                    row = System.Convert.ToInt32(e.CommandArgument);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                    row = -1;
                }

                //获得课程编号
                string course_schedule_id = GridView1.Rows[row].Cells[0].Text;
                //获得学生编号
                // string stu_id = Session["user_id"].toString();
                string stu_id = "17616";

                bool isChanged = CourseSelectDBUtil.Add(course_schedule_id + stu_id, stu_id, course_schedule_id, "0", "0");
                if (isChanged)
                {
                    string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "选课成功。");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
                }
                else
                {
                    string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "选课失败。");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
                }
                Data_Bind();
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeSelect")
            {
                int row;
                try
                {
                    row = System.Convert.ToInt32(e.CommandArgument);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                    row = -1;
                }

                //获得课程编号
                string course_schedule_id = GridView2.Rows[row].Cells[0].Text;
                //获得学生编号
                // string stu_id = Session["user_id"].toString();
                string stu_id = "17616";

                bool isChanged = CourseSelectDBUtil.Delete(course_schedule_id + stu_id);
                if (isChanged)
                {
                    string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "退选成功。");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
                }
                else
                {
                    string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "退选失败。");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
                }
                Data_Bind();
            }
        }
    }
}