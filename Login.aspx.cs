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
            // if (!IsPostBack)
            // {
            //     Button_Login.Attributes.Add("OnClick", "javascript:if(confirm('试试看吧，能成功否？')) return false; ");
            // }
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
                Label1.Text = "登录成功";
                Label1.Text = Session["account_user_name"].ToString();

                Response.Redirect("~/Student/Course/Selectable");
            }
            else
            {
                Label1.Text = "登录失败";
            }
        }

    }
}