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
    public partial class Administrator : System.Web.UI.Page
    {
        protected void Data_Bind()
        {
            string sql1 = "SELECT admin_id AS `管理员编号`, admin_name AS `管理员姓名`, admin_gender AS `性别`, DateDiff('yyyy',[admin_birthday],Date()) AS `年龄`, admin_status AS `用户状态` FROM administrator";
            GeneralUtil.GridViewInit(GridView1, sql1);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Data_Bind();
        }

        protected void Button_Add_Click(object sender, EventArgs e)
        {
            string administrator_id = Input_Add_Administrator_ID.Text;
            string administrator_name = Input_Add_Administrator_Name.Text;
            string administrator_password = Input_Add_Administrator_Password.Text;
            string administrator_gender = Input_Add_Administrator_Gender.Text;
            string administrator_birthday = Input_Add_Administrator_Birthday.Text;
            string administrator_status = Input_Add_Administrator_Status.Text;

            bool isChanged = AdministratorUserDBUtil.Add(administrator_id, administrator_name, administrator_password, administrator_gender, administrator_birthday, administrator_status);
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "添加管理员信息成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "添加管理员信息失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            Data_Bind();
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            string administrator_id = Input_Delete_Administrator_ID.Text;
            if(administrator_id.Equals("1119051"))
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "禁止删除该账户信息。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
                return;
            }
            bool isChanged = AdministratorUserDBUtil.Delete(administrator_id);
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "删除管理员信息成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "删除管理员信息失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            Data_Bind();
        }

        protected void Button_Update_Click(object sender, EventArgs e)
        {
            string administrator_id = Input_Update_Administrator_ID.Text;
            string update_item_select = Input_Update_Item_Select.Value.ToString();
            string update_value = Input_Update_Value.Text;
            bool isChanged = false;
            switch (update_item_select)
            {
                case "管理员编号":
                    isChanged = AdministratorUserDBUtil.UpdateID(administrator_id, update_value);
                    break;
                case "姓名":
                    isChanged = AdministratorUserDBUtil.UpdateName(administrator_id, update_value);
                    break;
                case "用户密码":
                    isChanged = AdministratorUserDBUtil.UpdatePassword(administrator_id, update_value);
                    break;
                case "性别":
                    isChanged = AdministratorUserDBUtil.UpdateGender(administrator_id, update_value);
                    break;
                case "出生时间":
                    isChanged = AdministratorUserDBUtil.UpdateBirthday(administrator_id, update_value);
                    break;
                case "用户状态":
                    isChanged = AdministratorUserDBUtil.UpdateStatus(administrator_id, update_value);
                    break;
            }
            if (isChanged)
            {
                string toastrScript = ToastrHelper.GetToastrScript("success", "提示", "修改管理员信息成功。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            else
            {
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "修改管理员信息失败。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
            Data_Bind();
        }
    }
}