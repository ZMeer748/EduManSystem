﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EduManSystem.Teacher
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["account_user_type"] == null)
            {
                Response.Redirect("~/");
            }
            else if (!Session["account_user_type"].Equals("教师"))
            {
                Response.Redirect("~/");
            }
            Label_User_Name.Text = Session["account_user_name"].ToString();
        }
    }
}