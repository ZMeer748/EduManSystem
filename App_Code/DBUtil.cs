using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Collections;

namespace EduManSystem.App_Code
{
    public class DBUtil : AccessHelper
    {
        public static DataSet GetDataSet(string sql)
        {
            return AccessHelper.Query(sql);
        }

        public static DataTable GetDataTable(string sql)
        {
            return AccessHelper.Query(sql).Tables[0];
        }

        public static bool Exists(string table_name, string PK_name, string PK_value)
        {
            string sql = "SELECT * FROM " + table_name + " WHERE " + PK_name + " = " + PK_value;
            return AccessHelper.Exists(sql);
        }

        public static bool Add(string table_name, List<string> field_values)
        {
            string sql = "INSERT INTO " + table_name + ValuesListToString(field_values);
            int isChanged = AccessHelper.ExecuteSql(sql);
            if (isChanged > 0)
                return true;
            else
                return false;
        }

        public static bool Delete(string table_name, string PK_name, string PK_value)
        {
            string sql = "DELETE FROM " + table_name + " WHERE " + PK_name + " = " + PK_value;
            if (AccessHelper.ExecuteSql(sql) > 0)
                return true;
            else
                return false;
        }

        public static string Get(string table_name, string PK_name, string PK_value, string field_name)
        {
            string sql = "SELECT " + field_name + " FROM " + table_name + " WHERE " + PK_name + " = " + PK_value;
            return AccessHelper.GetSingle(sql).ToString();
        }

        public static bool Update(string table_name, string PK_name, string PK_value, string field_name, string field_value)
        {
            string sql = "UPDATE " + table_name + " SET " + field_name + " = " + field_value + " WHERE " + PK_name + " = " + PK_value;
            if (AccessHelper.ExecuteSql(sql) > 0)
                return true;
            else
                return false;
        }

        public static string ValuesListToString(List<string> list)
        {
            string values_str = " VALUES('";
            for (int i = 0; i < list.Count - 1; i++)
            {
                values_str += list[i] + "', '";
            }
            values_str += list[list.Count - 1];
            return values_str += "')";
        }
    }

}