using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EduManSystem.App_Code;

namespace EduManSystem.Administrator
{
    public partial class Course : System.Web.UI.Page
    {

        protected void Data_Bind()
        {
            string sql1 = "SELECT course.course_id as `课程编号`, course.course_name as `课程名称`,  course.course_credit as `课程学分`, department.dept_name as `开课院系`, teacher.tch_name as `任课教师` FROM (course INNER JOIN teacher ON course.tch_id = teacher.tch_id) INNER JOIN department ON teacher.dept_id = department.dept_id";
            GeneralUtil.GridViewInit(GridView1, sql1);

            string sql2 = "SELECT teacher.tch_id as `教师编号`, teacher.tch_name as `教师姓名`, teacher.tch_gender as `教师性别`, DateDiff('yyyy', [teacher.tch_birthday], Date()) as `教师年龄`,  department.dept_name as `所属院系` FROM teacher INNER JOIN department ON teacher.dept_id = department.dept_id";
            GeneralUtil.GridViewInit(GridView2, sql2);
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
            string course_id = Input_Add_Course_ID.Text;
            string course_name = Input_Add_Course_Name.Text;
            string course_credit = Input_Add_Course_Credit.Text;
            string tch_id = Input_Add_Tch_ID.Text;
            bool isChanged = CourseDBUtil.Add(course_id, course_name, course_credit, tch_id);
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "添加课程信息成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "添加课程信息失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            Data_Bind();
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            string course_id = Input_Delete_Course_ID.Text;
            bool isChanged = CourseDBUtil.Delete(course_id);
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "删除课程信息成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "删除课程信息失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            Data_Bind();
        }

        protected void Button_Update_Click(object sender, EventArgs e)
        {
            string course_id = Input_Update_Course_ID.Text;
            string update_item_select = Input_Update_Item_Select.Value.ToString();
            string update_value = Input_Update_Value.Text;
            bool isChanged = false;
            switch (update_item_select)
            {
                case "课程编号":
                    isChanged = CourseDBUtil.UpdateID(course_id, update_value);
                    break;
                case "课程名称":
                    isChanged = CourseDBUtil.UpdateName(course_id, update_value);
                    break;
                case "课程学分":
                    isChanged = CourseDBUtil.UpdateCredit(course_id, update_value);
                    break;
                case "任课教师编号":
                    isChanged = CourseDBUtil.UpdateTchID(course_id, update_value);
                    break;
            }
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "修改课程信息成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "修改课程信息失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            Data_Bind();
        }

    }
}