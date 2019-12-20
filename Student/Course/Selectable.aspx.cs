using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EduManSystem.App_Code;

namespace EduManSystem.Student.Course
{
    public partial class Selectable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // String sql;
            // sql = "SELECT course_id as `课程编号`, course_name as `课程名称`, course_credit as `课程学分` FROM course";
            // table_example_container_1.InnerHtml = ConvertDataTableToHTML(AccessHelper.Query(sql).Tables[0]);
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            GridView1.CssClass = "table table-bordered table-striped";

            string sql = "SELECT course.course_id as `课程编号`, course.course_name as `课程名称`,  course.course_credit as `课程学分`, department.dept_name as `开课院系`, teacher.tch_name as `任课教师` FROM (course INNER JOIN teacher ON course.tch_id = teacher.tch_id) INNER JOIN department ON teacher.dept_id = department.dept_id";
            GridView2.DataSource = DBUtil.GetDataTable(sql);
            GridView2.DataBind();
            GridView2.HeaderRow.TableSection = TableRowSection.TableHeader;
            GridView2.CssClass = "table table-bordered table-striped";

        }

        // public static string ConvertDataTableToHTML(DataTable dt)
        // {
        //     string html = "<table id=\"example3\" class=\"table table-bordered table-striped\">";
        //     //add header row
        //     html += "<thead>";
        //     for (int i = 0; i < dt.Columns.Count; i++)
        //         html += "<th>" + dt.Columns[i].ColumnName + "</th>";
        //     html += "</thead>";
        //     html += "<tbody>";
        //     //add rows
        //     for (int i = 0; i < dt.Rows.Count; i++)
        //     {
        //         html += "<tr>";
        //         for (int j = 0; j < dt.Columns.Count; j++)
        //             html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
        //         html += "</tr>";
        //     }
        //     html += "</tbody>";
        //     html += "</table>";
        //     return html;
        // }
    }
}