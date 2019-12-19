using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EduManSystem.App_Code
{
    public class DBUtil : AccessHelper
    {
        public static DataSet GetTableDataSet(string table_name)
        {
            string sql = "SELECT * FROM " + table_name;
            return AccessHelper.Query(sql);
        }

        public static bool Delete(string table_name, string PK_name, string PK_value)
        {
            string sql = "DELETE FROM " + table_name + " WHERE " + PK_name + " = " + PK_value;
            if (AccessHelper.ExecuteSql(sql) > 0)
                return true;
            else
                return false;
        }
    }

    public class UserDBUtil : DBUtil
    {
        public static bool IsExist(string user_id, string user_type_str)
        {
            string sql = "SELECT * FROM " + GetUserType(user_type_str) + " WHERE " + GetUserTypeAbbreviation(user_type_str) + "_id = " + user_id;
            return AccessHelper.Exists(sql);
        }

        public static string GetUserInfo(string user_id, string user_info_name, string user_type_str)
        {
            string user_type = GetUserType(user_type_str);
            string user_type_abbreviation = GetUserTypeAbbreviation(user_type_str);
            string sql = "SELECT " + user_type_abbreviation + "_" + user_info_name + " FROM " + user_type + " WHERE " + GetUserTypeAbbreviation(user_type_str) + "_id = " + user_id;
            return AccessHelper.GetSingle(sql).ToString();
        }

        public static bool UpdateUserInfo(string user_id, string user_info_name, string user_info_value, string user_type_str)
        {
            string user_type = GetUserType(user_type_str);
            string user_type_abbreviation = GetUserTypeAbbreviation(user_type_str);
            string sql = "UPDATE TABLE " + user_type + " SET " + user_type_abbreviation + "_" + user_info_name + " = " + user_info_value + " WHERE " + GetUserTypeAbbreviation(user_type_str) + "_id = " + user_id;
            if (AccessHelper.ExecuteSql(sql) > 0)
                return true;
            else
                return false;
        }

        // override
        public static bool Delete(string user_id, string user_type_str)
        {
            string user_type = GetUserType(user_type_str);
            string user_type_abbreviation = GetUserTypeAbbreviation(user_type_str);
            return Delete(user_type, user_type_abbreviation + "_id", user_id);
            // string sql = "DELETE FROM " + user_type + " WHERE " + GetUserTypeAbbreviation(user_type_str) + "_id = " + user_id;
        }

        public static string GetUserType(string user_type_str)
        {
            switch (user_type_str)
            {
                case "student":
                case "学生":
                    return "student";
                case "teacher":
                case "教师":
                    return "teacher";
                case "administrator":
                case "管理员":
                    return "administrator";
            }
            return null;
        }

        public static string GetUserTypeAbbreviation(string user_type_str)
        {
            switch (user_type_str)
            {
                case "student":
                case "学生":
                    return "stu";
                case "teacher":
                case "教师":
                    return "tch";
                case "administrator":
                case "管理员":
                    return "admin";
            }
            return null;
        }
    }

}