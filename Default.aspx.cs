using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EduManSystem.App_Code;

namespace EduManSystem
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String sql;
            sql = "SELECT stu_name FROM student WHERE stu_id=17616";
            Label1.Text = AccessHelper.GetSingle(sql).ToString();
        }
    }
}