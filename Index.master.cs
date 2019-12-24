using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EduManSystem.App_Code;

namespace EduManSystem
{
    public partial class Index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string localPath = Request.Url.LocalPath;
            if (localPath.Equals("/Login") || localPath.Equals("/Login.aspx"))
            {
                IndexHyperLink2.CssClass = "nav-link active";
            }
            else if (localPath.Equals("/") || localPath.Equals("/Default") || localPath.Equals("/Default.aspx") || localPath.Equals("/default.aspx"))
            {
                IndexHyperLink1.CssClass = "nav-link active";
            }
            string toastrScript = ToastrHelper.GetToastrScript("success", "提示", localPath);
        }
    }
}