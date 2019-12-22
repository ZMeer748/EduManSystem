using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EduManSystem.App_Code;

namespace EduManSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Login_Click(object sender, EventArgs e)
        {
            string input_user_id = Input_ID.Text;
            string input_user_password = Input_UserPassword.Text;
            string input_user_type_str = account_sort_label_value.Value;
            if (UserDBUtil.Exists(input_user_id, input_user_type_str) && UserDBUtil.GetPassword(input_user_id, input_user_type_str).Equals(input_user_password))
            {
                Session["account_user_name"] = UserDBUtil.GetName(input_user_id, input_user_type_str);
                Session["account_user_id"] = input_user_id;
                Session["account_user_type"] = input_user_type_str;
                Label1.Text = Session["account_user_name"].ToString() + "登录成功";

                Response.Redirect("~/Student/Course/Selectable");
            }
            else
            {
                Label1.Text = "登录失败";
                string toastrScript = ToastrHelper.GetToastrScript("danger", "提示", "登录失败！ID 不存在或密码错误。");
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", toastrScript, true);
            }
        }

    }
}