using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EduManSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Login_Click(object sender, EventArgs e)
        {
            Label1.Text = account_sort_label_value.Value;
            // Label1.Text = "TEST";
            // Response.Redirect("Default.aspx");
        }

        protected string GetStr() {
            // String account_sort = Label2.Text;
            return "";
        }


    }
}