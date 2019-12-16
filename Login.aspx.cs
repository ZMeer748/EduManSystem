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
            if (!IsPostBack)
            {
                Button_Login.Attributes.Add("OnClick", "javascript:if(confirm('试试看吧，能成功否？')) return false; ");
            }
        }

        protected void Button_Login_Click(object sender, EventArgs e)
        {
            // Label1.Text = account_sort_label_value.Value;
            string user_id = Input_ID.Text;
            string user_password = Input_UserPassword.Text;
            string user_type_str = account_sort_label_value.Value;
            if(LoginCheck(user_type_str, user_id, user_password))
            {
                string sql;
                sql = "SELECT " + Get_User_Type_Abbreviation(user_type_str) + "_name FROM " + Get_User_Type(user_type_str) + " WHERE " + Get_User_Type_Abbreviation(user_type_str) + "_id=" + user_id;

                Session["account_user_name"] = AccessHelper.GetSingle(sql);
                Session["account_user_id"] = user_id;
                Session["account_user_type"] = user_type_str;
                Label1.Text = "登录成功";
                Label1.Text = Session["account_user_name"].ToString();
                Console.Write(Session["account_user_name"].ToString());

            } else
            {
                Label1.Text = "登录失败";
            }
        }

        protected bool LoginCheck(string user_type_str, string user_id, string user_password)
        {
            string user_type = Get_User_Type(user_type_str);
            string user_type_abbreviation = Get_User_Type_Abbreviation(user_type_str);
            string sql;
            sql = "SELECT * FROM " + user_type + " WHERE " + user_type_abbreviation + "_id=" + user_id + " and " + user_type_abbreviation + "_password=\"" + user_password + "\"";
            try
            {
                return AccessHelper.Exists(sql);
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }

        protected string Get_User_Type(string user_type_str)
        {
            switch (user_type_str)
            {
                case "学生":
                    return "student";
                case "教师":
                    return "teacher";
                case "管理员":
                    return "administrator";
                default:
                    return "";
            }
        }

        protected string Get_User_Type_Abbreviation(string user_type_str)
        {
            switch (user_type_str)
            {
                case "学生":
                    return "stu";
                case "教师":
                    return "tch";
                case "管理员":
                    return "admin";
                default:
                    return "";
            }
        }

    }
}