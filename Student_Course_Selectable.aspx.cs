﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EduManSystem.App_Code;


namespace EduManSystem
{
    public partial class Student_Course_Selectable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String sql;
            sql = "SELECT * FROM course";
            table_example_container_1.InnerHtml = ConvertDataTableToHTML(AccessHelper.Query(sql).Tables[0]);
        }

        public static string ConvertDataTableToHTML(DataTable dt)
        {
            string html = "<table id=\"example3\" class=\"table table-bordered table-striped\">";
            //add header row
            html += "<thead>";
            for (int i = 0; i < dt.Columns.Count; i++)
                html += "<th>" + dt.Columns[i].ColumnName + "</th>";
            html += "</thead>";
            html += "<tbody>";
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                    html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                html += "</tr>";
            }
            html += "</tbody>";
            html += "</table>";
            return html;
        }
    }
}