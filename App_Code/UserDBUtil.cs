using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduManSystem.App_Code
{

    public class UserDBUtil : DBUtil
    {
        public static bool IsExist(string user_id, string user_type_str)
        {
            return IsExist(GetUserType(user_type_str), GetUserTypeAbbreviation(user_type_str) + "_id", user_id);
        }

        public static bool Delete(string user_id, string user_type_str)
        {
            return Delete(GetUserType(user_type_str), GetUserTypeAbbreviation(user_type_str) + "_id", user_id);
        }

        public static string Get(string user_id, string user_info_name, string user_type_str)
        {
            return Get(GetUserType(user_type_str), GetUserTypeAbbreviation(user_type_str) + "_id", user_id, GetUserTypeAbbreviation(user_type_str) + "_" + user_info_name);
        }

        public static bool Update(string user_id, string user_info_name, string user_update_value, string user_type_str)
        {
            return Update(GetUserType(user_type_str), GetUserTypeAbbreviation(user_type_str) + "_id", user_id, GetUserTypeAbbreviation(user_type_str) + "_" + user_info_name, user_update_value);
        }

        public static string GetName(string user_id, string user_type_str)
        {
            return Get(user_id, "name", GetUserType(user_type_str));
        }

        public static string GetPassword(string user_id, string user_type_str)
        {
            return Get(user_id, "password", GetUserType(user_type_str));
        }

        public static string GetGender(string user_id, string user_type_str)
        {
            return Get(user_id, "gender", GetUserType(user_type_str));
        }

        public static string GetBirthday(string user_id, string user_type_str)
        {
            return Get(user_id, "birthday", GetUserType(user_type_str));
        }

        public static string GetAge(string user_id, string user_type_str)
        {
            return AccessHelper.GetSingle("SELECT " + GetUserTypeAbbreviation(user_type_str) + "_age FROM " + GetUserType(user_type_str) + "_age WHERE " + GetUserTypeAbbreviation(user_type_str) + "_id = " + user_id).ToString();
        }

        public static string GetStatus(string user_id, string user_type_str)
        {
            return Get(user_id, "status", GetUserType(user_type_str));
        }

        public static bool UpdateName(string user_id, string user_update_value, string user_type_str)
        {
            return Update(user_id, "name", user_update_value, GetUserType(user_type_str));
        }

        public static bool UpdatePassword(string user_id, string user_update_value, string user_type_str)
        {
            return Update(user_id, "password", user_update_value, GetUserType(user_type_str));
        }

        public static bool UpdateGender(string user_id, string user_update_value, string user_type_str)
        {
            return Update(user_id, "gender", user_update_value, GetUserType(user_type_str));
        }

        public static bool UpdateBirthday(string user_id, string user_update_value, string user_type_str)
        {
            return Update(user_id, "birthday", user_update_value, GetUserType(user_type_str));
        }

        public static bool UpdateStatus(string user_id, string user_update_value, string user_type_str)
        {
            return Update(user_id, "status", user_update_value, GetUserType(user_type_str));
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

    public class StudentUserDBUtil : UserDBUtil
    {
        public static bool IsExist(string stu_id)
        {
            return IsExist("student", stu_id);
        }

        public static bool Add(string stu_id, string stu_name, string stu_password, string stu_gender, string stu_birthday, string stu_status, string class_id)
        {
            List<string> list = new List<string>();
            list = new string[] { stu_id, stu_name, stu_password, stu_gender, stu_birthday, stu_status, class_id }.ToList();
            return Add("student", list);
        }

        public static bool Delete(string stu_id)
        {
            return Delete(stu_id, "student");
        }

        public static string Get(string stu_id, string stu_info_name)
        {
            return Get(stu_id, "stu_" + stu_info_name, "student");
        }

        public static bool Update(string stu_id, string stu_info_name, string stu_update_value)
        {
            return Update(stu_id, "stu_" + stu_info_name, stu_update_value, "student");
        }

        public static string GetName(string stu_id)
        {
            return GetName(stu_id, "student");
        }

        public static string GetPassword(string stu_id)
        {
            return GetPassword(stu_id, "student");
        }

        public static string GetGender(string stu_id)
        {
            return GetGender(stu_id, "student");
        }

        public static string GetBirthday(string stu_id)
        {
            return GetBirthday(stu_id, "student");
        }

        public static string GetAge(string stu_id)
        {
            return GetAge(stu_id, "student");
        }

        public static string GetStatus(string stu_id)
        {
            return GetStatus(stu_id, "student");
        }

        public static string GetClassID(string stu_id)
        {
            return Get("student", "stu_id", stu_id, "class_id");
        }

        public static bool UpdateName(string stu_id, string stu_update_value)
        {
            return UpdateName(stu_id, stu_update_value, "student");
        }

        public static bool UpdatePassword(string stu_id, string stu_update_value)
        {
            return UpdatePassword(stu_id, stu_update_value, "student");
        }

        public static bool UpdateGender(string stu_id, string stu_update_value)
        {
            return UpdateGender(stu_id, stu_update_value, "student");
        }

        public static bool UpdateBirthday(string stu_id, string stu_update_value)
        {
            return UpdateBirthday(stu_id, stu_update_value, "student");
        }

        public static bool UpdateStatus(string stu_id, string stu_update_value)
        {
            return UpdateStatus(stu_id, stu_update_value, "student");
        }

        public static bool UpdateClassID(string stu_id, string stu_update_value)
        {
            return Update("student", "stu_id", stu_id, "class_id", stu_update_value);
        }
    }

    public class TeacherUserDBUtil : UserDBUtil
    {
        public static bool IsExist(string tch_id)
        {
            return IsExist("teacher", tch_id);
        }

        public static bool Add(string tch_id, string tch_name, string tch_password, string tch_gender, string tch_birthday, string tch_status, string dept_id)
        {
            List<string> list = new List<string>();
            list = new string[] { tch_id, tch_name, tch_password, tch_gender, tch_birthday, tch_status, dept_id }.ToList();
            return Add("teacher", list);
        }

        public static bool Delete(string tch_id)
        {
            return Delete(tch_id, "teacher");
        }

        public static string Get(string tch_id, string tch_info_name)
        {
            return Get(tch_id, "tch_" + tch_info_name, "teacher");
        }

        public static bool Update(string tch_id, string tch_info_name, string tch_update_value)
        {
            return Update(tch_id, "tch_" + tch_info_name, tch_update_value, "teacher");
        }

        public static string GetName(string tch_id)
        {
            return GetName(tch_id, "teacher");
        }

        public static string GetPassword(string tch_id)
        {
            return GetPassword(tch_id, "teacher");
        }

        public static string GetGender(string tch_id)
        {
            return GetGender(tch_id, "teacher");
        }

        public static string GetBirthday(string tch_id)
        {
            return GetBirthday(tch_id, "teacher");
        }

        public static string GetAge(string tch_id)
        {
            return GetAge(tch_id, "teacher");
        }

        public static string GetStatus(string tch_id)
        {
            return GetStatus(tch_id, "teacher");
        }

        public static string GetSeptID(string tch_id)
        {
            return Get("teacher", "tch_id", tch_id, "sept_id");
        }

        public static bool UpdateName(string tch_id, string tch_update_value)
        {
            return UpdateName(tch_id, tch_update_value, "teacher");
        }

        public static bool UpdatePassword(string tch_id, string tch_update_value)
        {
            return UpdatePassword(tch_id, tch_update_value, "teacher");
        }

        public static bool UpdateGender(string tch_id, string tch_update_value)
        {
            return UpdateGender(tch_id, tch_update_value, "teacher");
        }

        public static bool UpdateBirthday(string tch_id, string tch_update_value)
        {
            return UpdateBirthday(tch_id, tch_update_value, "teacher");
        }

        public static bool UpdateStatus(string tch_id, string tch_update_value)
        {
            return UpdateStatus(tch_id, tch_update_value, "teacher");
        }

        public static bool UpdateSeptID(string tch_id, string tch_update_value)
        {
            return Update("teacher", "tch_id", tch_id, "sept_id", tch_update_value);
        }
    }

    public class AdministratorUserDBUtil : UserDBUtil
    {
        public static bool IsExist(string admin_id)
        {
            return IsExist("administrator", admin_id);
        }

        public static bool Add(string admin_id, string admin_name, string admin_password, string admin_gender, string admin_birthday, string admin_status)
        {
            List<string> list = new List<string>();
            list = new string[] { admin_id, admin_name, admin_password, admin_gender, admin_birthday, admin_status }.ToList();
            return Add("administrator", list);
        }

        public static bool Delete(string admin_id)
        {
            return Delete(admin_id, "administrator");
        }

        public static string Get(string admin_id, string admin_info_name)
        {
            return Get(admin_id, "admin_" + admin_info_name, "administrator");
        }

        public static bool Update(string admin_id, string admin_info_name, string admin_update_value)
        {
            return Update(admin_id, "admin_" + admin_info_name, admin_update_value, "administrator");
        }

        public static string GetName(string admin_id)
        {
            return GetName(admin_id, "administrator");
        }

        public static string GetPassword(string admin_id)
        {
            return GetPassword(admin_id, "administrator");
        }

        public static string GetGender(string admin_id)
        {
            return GetGender(admin_id, "administrator");
        }

        public static string GetStatus(string admin_id)
        {
            return GetStatus(admin_id, "administrator");
        }

        public static bool UpdateName(string admin_id, string admin_update_value)
        {
            return UpdateName(admin_id, admin_update_value, "administrator");
        }

        public static bool UpdatePassword(string admin_id, string admin_update_value)
        {
            return UpdatePassword(admin_id, admin_update_value, "administrator");
        }

        public static bool UpdateGender(string admin_id, string admin_update_value)
        {
            return UpdateGender(admin_id, admin_update_value, "administrator");
        }

        public static bool UpdateStatus(string admin_id, string admin_update_value)
        {
            return UpdateStatus(admin_id, admin_update_value, "administrator");
        }
    }

}