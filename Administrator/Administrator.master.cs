using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EduManSystem.Administrator
{
    public partial class Administrator : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string localPath = Request.Url.LocalPath;
            if (localPath.Equals("/Administrator/Default") || localPath.Equals("/Administrator/Default.aspx") || localPath.Equals("/Administrator/default.aspx"))
            {
                NavHyperLink1.CssClass = "nav-link active";
            }
            else if (localPath.Equals("/Administrator/Course") || localPath.Equals("/Administrator/Course.aspx"))
            {
                NavHyperLink_Course.CssClass = "nav-link active";
            }

        }
    }
}