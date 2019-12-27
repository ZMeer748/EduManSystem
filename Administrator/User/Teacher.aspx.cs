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
    public partial class Teacher : System.Web.UI.Page
    {
        protected void Data_Bind()
        {
            string sql1 = "SELECT teacher.tch_id AS `教师编号`, teacher.tch_name AS `教师姓名`, teacher.tch_gender AS `性别`, DateDiff('yyyy',[teacher.tch_birthday],Date()) AS `年龄`, teacher.tch_status AS `用户状态`, teacher.dept_id AS `所属院系编号`,department.dept_name AS `所属院系` FROM teacher INNER JOIN department ON teacher.dept_id = department.dept_id";
            GeneralUtil.GridViewInit(GridView1, sql1);

            string sql2 = "SELECT dept_id AS `院系编号`, dept_name AS `院系名称` FROM department";
            GeneralUtil.GridViewInit(GridView2, sql2);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Data_Bind();
        }

        protected void Button_Add_Click(object sender, EventArgs e)
        {
            string teacher_id = Input_Add_Teacher_ID.Text;
            string teacher_name = Input_Add_Teacher_Name.Text;
            string teacher_password = Input_Add_Teacher_Password.Text;
            string teacher_gender = Input_Add_Teacher_Gender.Text;
            string teacher_birthday = Input_Add_Teacher_Birthday.Text;
            string teacher_status = Input_Add_Teacher_Status.Text;
            string department_id = Input_Add_Department_ID.Text;

            bool isChanged = TeacherUserDBUtil.Add(teacher_id, teacher_name, teacher_password, teacher_gender, teacher_birthday, teacher_status, department_id);
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "添加教师信息成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "添加教师信息失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            Data_Bind();
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            string teacher_id = Input_Delete_Teacher_ID.Text;
            bool isChanged = TeacherUserDBUtil.Delete(teacher_id);
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "删除教师信息成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "删除教师信息失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            Data_Bind();
        }

        protected void Button_Update_Click(object sender, EventArgs e)
        {
            string teacher_id = Input_Update_Teacher_ID.Text;
            string update_item_select = Input_Update_Item_Select.Value.ToString();
            string update_value = Input_Update_Value.Text;
            bool isChanged = false;
            switch (update_item_select)
            {
                case "教师编号":
                    isChanged = TeacherUserDBUtil.UpdateID(teacher_id, update_value);
                    break;
                case "姓名":
                    isChanged = TeacherUserDBUtil.UpdateName(teacher_id, update_value);
                    break;
                case "用户密码":
                    isChanged = TeacherUserDBUtil.UpdatePassword(teacher_id, update_value);
                    break;
                case "性别":
                    isChanged = TeacherUserDBUtil.UpdateGender(teacher_id, update_value);
                    break;
                case "出生时间":
                    isChanged = TeacherUserDBUtil.UpdateBirthday(teacher_id, update_value);
                    break;
                case "用户状态":
                    isChanged = TeacherUserDBUtil.UpdateStatus(teacher_id, update_value);
                    break;
                case "院系":
                    isChanged = TeacherUserDBUtil.UpdateDepartmentID(teacher_id, update_value);
                    break;
            }
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "修改教师信息成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "修改教师信息失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            Data_Bind();
        }
    }
}