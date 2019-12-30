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
    public partial class CourseSchedule : System.Web.UI.Page
    {

        protected void Data_Bind()
        {
            string sql1 = "SELECT course_schedule.course_schedule_id AS `课程安排编号`, course_schedule.course_id AS `课程编号`,course.course_name AS `课程名称`, course_schedule.dept_id AS `面向院系编号`, department.dept_name AS `院系名称`, course_schedule.course_schedule_type AS `课程安排类型`, course_schedule.course_schedule_capacity AS `课程安排容量`, course_schedule_status AS `课程安排状态` FROM (course_schedule INNER JOIN course ON course_schedule.course_id = course.course_id) INNER JOIN department ON course_schedule.dept_id = department.dept_id";
            GeneralUtil.GridViewInit(GridView1, sql1);

            string sql2 = "SELECT course.course_id as `课程编号`, course.course_name as `课程名称`,  course.course_credit as `课程学分`, department.dept_name as `开课院系`, teacher.tch_name as `任课教师` FROM (course INNER JOIN teacher ON course.tch_id = teacher.tch_id) INNER JOIN department ON teacher.dept_id = department.dept_id";
            GeneralUtil.GridViewInit(GridView2, sql2);

            string sql3 = "SELECT dept_id AS `院系编号`, dept_name AS `院系名称` FROM department";
            GeneralUtil.GridViewInit(GridView3, sql3);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["account_user_type"] == null)
            {
                Response.Redirect("~/");
            }
            else if (!Session["account_user_type"].Equals("管理员"))
            {
                Response.Redirect("~/");
            }

            Data_Bind();
        }

        protected void Button_Add_Click(object sender, EventArgs e)
        {
            string course_schedule_id = Input_Add_Course_Schedule_ID.Text;
            string course_id = Input_Add_Course_ID.Text;
            string department_id = Input_Add_Department_ID.Text;
            string course_schedule_type = Input_Add_Course_Schedule_Type.Value;
            string course_schedule_capacity = Input_Add_Course_Schedule_Capacity.Text;
            string course_schedule_status = Input_Add_Course_Schedule_Status.Text;

            bool isChanged = CourseScheduleDBUtil.Add(course_schedule_id, course_id, department_id, course_schedule_type, course_schedule_capacity, course_schedule_status);
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "添加课程安排信息成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "添加课程安排信息失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            Data_Bind();
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            string course_schedule_id = Input_Delete_Course_Schedule_ID.Text;
            bool isChanged = CourseScheduleDBUtil.Delete(course_schedule_id);
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "删除课程安排信息成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "删除课程安排信息失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            Data_Bind();
        }

        protected void Button_Update_Click(object sender, EventArgs e)
        {
            string course_schedule_id = Input_Update_Course_Schedule_ID.Text;
            string update_item_select = Input_Update_Item_Select.Value.ToString();
            string update_value = Input_Update_Value.Text;
            bool isChanged = false;
            switch (update_item_select)
            {
                case "课程安排编号":
                    isChanged = CourseScheduleDBUtil.UpdateID(course_schedule_id, update_value);
                    break;
                case "课程编号":
                    isChanged = CourseScheduleDBUtil.UpdateCourseID(course_schedule_id, update_value);
                    break;
                case "面向院系编号":
                    isChanged = CourseScheduleDBUtil.UpdateDeptID(course_schedule_id, update_value);
                    break;
                case "课程安排类型":
                    isChanged = CourseScheduleDBUtil.UpdateType(course_schedule_id, update_value);
                    break;
                case "课程安排容量":
                    isChanged = CourseScheduleDBUtil.UpdateCapacity(course_schedule_id, update_value);
                    break;
                case "课程安排状态":
                    isChanged = CourseScheduleDBUtil.UpdateStatus(course_schedule_id, update_value);
                    break;
            }
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "修改课程安排信息成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "修改课程安排信息失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            Data_Bind();
        }
    }
}