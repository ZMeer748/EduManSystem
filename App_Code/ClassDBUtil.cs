using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduManSystem.App_Code
{
    public class ClassDBUtil : DBUtil
    {
        public static bool IsExist(string class_id)
        {
            return IsExist("class", "class_id", class_id);
        }

        public static bool Add(string class_id, string class_name, string dept_id)
        {
            List<string> list = new List<string>();
            list = new string[] { class_id, class_name, dept_id }.ToList();
            return Add("class", list);
        }

        public static bool Delete(string class_id)
        {
            return Delete("class", "class_id", class_id);
        }

        public static string Get(string class_id, string class_info_name)
        {
            return Get("class", "class_id", class_id, "class_" + class_info_name);
        }

        public static bool Update(string class_id, string class_info_name, string class_update_value)
        {
            return Update("class", "class_id", class_id, "class_" + class_info_name, class_update_value);
        }

        public static string GetName(string class_id, string class_info_name)
        {
            return Get(class_id, "name");
        }

        public static string GetDeptID(string class_id, string class_info_name)
        {
            return Get("class", "class_id", class_id, "dept_id");
        }

        public static bool UpdateName(string class_id, string class_update_value)
        {
            return Update(class_id, "name", class_update_value);
        }

        public static bool UpdateDeptID(string class_id, string class_update_value)
        {
            return Update("class", "class_id", class_id, "dept_id", class_update_value);
        }

    }
}