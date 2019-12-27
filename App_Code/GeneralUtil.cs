using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;

namespace EduManSystem.App_Code
{
    public class GeneralUtil
    {
        public static void GridViewReLoad(GridView gridView)
        {
            gridView.DataBind();
            gridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            gridView.CssClass = "table table-bordered table-striped";
        }

        public static void GridViewReLoad(List<GridView> gridViewList)
        {
            foreach (GridView gridView in gridViewList)
            {
                GridViewReLoad(gridView);
            }
        }

        public static void GridViewInit(GridView gridView, string dataSourceStr)
        {
            DataTable dt = DBUtil.GetDataTable(dataSourceStr);
            if (dt.Rows.Count != 0)
            {
                gridView.DataSource = dt;
                gridView.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gridView.DataSource = dt;
                gridView.DataBind();
                gridView.Rows[0].Visible = false;
            }
            gridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            gridView.CssClass = "table table-bordered table-striped";
        }

    }
}