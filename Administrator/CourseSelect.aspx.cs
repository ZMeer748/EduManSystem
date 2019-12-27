using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EduManSystem.App_Code;

namespace EduManSystem.Administrator
{
    public partial class CourseSelect : System.Web.UI.Page
    {
        protected void Data_Bind()
        {
            string sql1 = "SELECT course_select.course_select_id AS `选课编号`, course_select.stu_id AS `学生编号`, student.stu_name AS `学生姓名`, course_select.course_schedule_id AS `课程编号`, course.course_name AS `课程名称`, course_select.course_select_score AS `成绩`, course_select.course_select_status AS `选课状态` FROM ((course_select INNER JOIN course_schedule ON course_select.course_schedule_id = course_schedule.course_schedule_id) INNER JOIN course ON course_schedule.course_id = course.course_id) INNER JOIN student ON course_select.stu_id = student.stu_id";
            GeneralUtil.GridViewInit(GridView1, sql1);

            string sql2 = "SELECT course_schedule.course_schedule_id AS `课程安排编号`, course_schedule.course_id AS `课程编号`,course.course_name AS `课程名称`, course_schedule.dept_id AS `面向院系编号`, department.dept_name AS `院系名称`, course_schedule.course_schedule_type AS `课程安排类型`, course_schedule.course_schedule_capacity AS `课程安排容量`, course_schedule_status AS `课程安排状态` FROM (course_schedule INNER JOIN course ON course_schedule.course_id = course.course_id) INNER JOIN department ON course_schedule.dept_id = department.dept_id";
            GeneralUtil.GridViewInit(GridView2, sql2);

            string sql3 = "SELECT student.stu_id AS `学生编号`, student.stu_name AS `学生姓名`, student.stu_gender AS `性别`, DateDiff('yyyy',[student.stu_birthday],Date()) AS `年龄`, student.stu_status AS `用户状态`, student.class_id AS `班级编号`, class.class_name AS `班级名称`, department.dept_name AS `所属院系` FROM (student INNER JOIN class ON student.class_id = class.class_id) INNER JOIN department ON class.dept_id = department.dept_id";
            GeneralUtil.GridViewInit(GridView3, sql3);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Data_Bind();
        }

        protected void Button_Add_Click(object sender, EventArgs e)
        {
            string course_select_id = Input_Add_Course_Select_ID.Text;
            string student_id = Input_Add_Student_ID.Text;
            string course_schedule_id = Input_Add_Course_Schedule_ID.Text;
            string course_select_score = Input_Add_Course_Select_Score.Text;
            string course_select_status = Input_Add_Course_Select_Status.Text;

            bool isChanged = CourseSelectDBUtil.Add(course_select_id, student_id, course_schedule_id, course_select_score, course_select_status);
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "添加选课信息成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "添加选课信息失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            Data_Bind();
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            string course_select_id = Input_Delete_Course_Select_ID.Text;
            bool isChanged = CourseSelectDBUtil.Delete(course_select_id);
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "删除选课信息成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "删除选课信息失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            Data_Bind();
        }

        protected void Button_Update_Click(object sender, EventArgs e)
        {
            string course_select_id = Input_Update_Course_Select_ID.Text;
            string update_item_select = Input_Update_Item_Select.Value.ToString();
            string update_value = Input_Update_Value.Text;
            bool isChanged = false;
            switch (update_item_select)
            {
                case "选课编号":
                    isChanged = CourseSelectDBUtil.UpdateID(course_select_id, update_value);
                    break;
                case "学生编号":
                    isChanged = CourseSelectDBUtil.UpdateStudentID(course_select_id, update_value);
                    break;
                case "课程安排编号":
                    isChanged = CourseSelectDBUtil.UpdateCourseScheduleID(course_select_id, update_value);
                    break;
                case "成绩":
                    isChanged = CourseSelectDBUtil.UpdateScore(course_select_id, update_value);
                    break;
                case "选课状态":
                    isChanged = CourseSelectDBUtil.UpdateStatus(course_select_id, update_value);
                    break;
            }
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "修改选课信息成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "修改选课信息失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            Data_Bind();
        }
    }
}