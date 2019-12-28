using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EduManSystem.App_Code;

namespace EduManSystem.Administrator.User
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Data_Bind()
        {
            string sql1 = "SELECT student.stu_id AS `学生编号`, student.stu_name AS `学生姓名`, student.stu_gender AS `性别`, DateDiff('yyyy',[student.stu_birthday],Date()) AS `年龄`, student.stu_status AS `用户状态`, student.class_id AS `班级编号`, class.class_name AS `班级名称`, department.dept_name AS `所属院系` FROM (student INNER JOIN class ON student.class_id = class.class_id) INNER JOIN department ON class.dept_id = department.dept_id";
            GeneralUtil.GridViewInit(GridView1, sql1);

            string sql2 = "SELECT class.class_id AS `班级编号`, class.class_name AS `班级名称`, department.dept_name AS `所属院系` FROM class INNER JOIN department ON class.dept_id = department.dept_id";
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
            string student_id = Input_Add_Student_ID.Text;
            string student_name = Input_Add_Student_Name.Text;
            string student_password = Input_Add_Student_Password.Text;
            string student_gender = Input_Add_Student_Gender.Text;
            string student_birthday = Input_Add_Student_Birthday.Text;
            string student_status = Input_Add_Student_Status.Text;
            string class_id = Input_Add_Class_ID.Text;

            bool isChanged = StudentUserDBUtil.Add(student_id, student_name, student_password, student_gender, student_birthday, student_status, class_id);
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "添加学生信息成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "添加学生信息失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            Data_Bind();
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            string student_id = Input_Delete_Student_ID.Text;
            bool isChanged = StudentUserDBUtil.Delete(student_id);
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "删除学生信息成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "删除学生信息失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            Data_Bind();
        }

        protected void Button_Update_Click(object sender, EventArgs e)
        {
            string student_id = Input_Update_Student_ID.Text;
            string update_item_select = Input_Update_Item_Select.Value.ToString();
            string update_value = Input_Update_Value.Text;
            bool isChanged = false;
            switch (update_item_select)
            {
                case "学生编号":
                    isChanged = StudentUserDBUtil.UpdateID(student_id, update_value);
                    break;
                case "姓名":
                    isChanged = StudentUserDBUtil.UpdateName(student_id, update_value);
                    break;
                case "用户密码":
                    isChanged = StudentUserDBUtil.UpdatePassword(student_id, update_value);
                    break;
                case "性别":
                    isChanged = StudentUserDBUtil.UpdateGender(student_id, update_value);
                    break;
                case "出生时间":
                    isChanged = StudentUserDBUtil.UpdateBirthday(student_id, update_value);
                    break;
                case "用户状态":
                    isChanged = StudentUserDBUtil.UpdateStatus(student_id, update_value);
                    break;
                case "班级编号":
                    isChanged = StudentUserDBUtil.UpdateClassID(student_id, update_value);
                    break;
            }
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "修改学生信息成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "修改学生信息失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            Data_Bind();
        }
    }
}