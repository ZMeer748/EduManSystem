﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EduManSystem
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["account_user_name"] != null && Session["account_user_type"] != null)
            {
                switch (Session["account_user_type"])
                {
                    case "管理员":
                        sidebar_user_icon_container.InnerHtml = "<i class=\"fas fa-user-cog img-circle elevation-2 text-white mt-1 ml-1\" title=\"管理员\" style=\"font-size:1.5em;\"></i>";
                        break;
                    case "学生":
                        sidebar_user_icon_container.InnerHtml = "<i class=\"fas fa-user-graduate img-circle elevation-2 text-white mt-1 ml-1\" title=\"学生\" style=\"font-size:1.5em;\"></i>";
                        UserHyperLink.NavigateUrl = "~/Student/Course/Selectable";
                        break;
                    case "教师":
                        sidebar_user_icon_container.InnerHtml = "<i class=\"fas fa-chalkboard-teacher img-circle elevation-2 text-white mt-1 ml-1\" title=\"教师\" style=\"font-size:1.5em;\"></i>";
                        break;
                }
                UserHyperLink.Text = Session["account_user_name"].ToString();
            }
        }
    }
}