using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EduManSystem.App_Code
{
    public class CourseDBUtil : DBUtil
    {
        public static new bool Exists(string course_id)
        {
            return Exists("course", "course_id", "'" + course_id + "'");
        }

        public static bool Add(string course_id, string course_name, string course_credit, string tch_id)
        {
            List<string> list = new List<string>();
            list = new string[] { course_id, course_name, course_credit, tch_id }.ToList();
            return Add("course", list);
        }

        public static bool Delete(string course_id)
        {
            return Delete("course", "course_id", "'" + course_id + "'");
        }

        public static string Get(string course_id, string course_info_name)
        {
            return Get("course", "course_id", "'" + course_id + "'", "course_" + course_info_name);
        }

        public static bool Update(string course_id, string course_info_name, string course_update_value)
        {
            return Update("course", "course_id", "'" + course_id + "'", "course_" + course_info_name, course_update_value);
        }

        public static string GetName(string course_id, string course_info_name)
        {
            return Get(course_id, "name");
        }

        public static string GetCredit(string course_id, string course_info_name)
        {
            return Get(course_id, "credit");
        }

        public static string GetTchID(string course_id, string course_info_name)
        {
            return Get("course", "course_id", "'" + course_id + "'", "tch_id");
        }

        public static bool UpdateName(string course_id, string course_update_value)
        {
            return Update(course_id, "name", "'" + course_update_value + "'");
        }

        public static bool UpdateCredit(string course_id, string course_update_value)
        {
            return Update(course_id, "credit", course_update_value);
        }

        public static bool UpdateTchID(string course_id, string course_update_value)
        {
            return Update("course", "course_id", "'" + course_id + "'", "tch_id", "'" + course_update_value + "'");
        }
    }

    public class CourseScheduleDBUtil : DBUtil
    {

        public static DataTable GetDataTable()
        {
            string sql = "SELECT course_schedule_id AS `课排编号`, course_id AS `课程编号`, dept_id AS `系编号`, course_schedule_type AS `课排类型`, course_schedule_capacity AS `课排容量`, course_schedule_semester AS `课排学期` FROM course_schedule";
            return GetDataTable(sql);
        }

        public static new bool Exists(string course_schedule_id)
        {
            return Exists("course_schedule", "course_schedule_id", course_schedule_id);
        }

        public static bool Add(string course_schedule_id, string course_id, string dept_id, string course_schedule_type, string course_schedule_capacity, string course_schedule_semester)
        {
            List<string> list = new List<string>();
            list = new string[] { course_schedule_id, course_id, dept_id, course_schedule_type, course_schedule_capacity, course_schedule_semester }.ToList();
            return Add("course_schedule", list);
        }

        public static bool Delete(string course_schedule_id)
        {
            return Delete("course_schedule", "course_schedule_id", "'" + course_schedule_id + "'");
        }

        public static string Get(string course_schedule_id, string course_schedule_info_name)
        {
            return Get("course_schedule", "course_schedule_id", "'" + course_schedule_id + "'", "course_schedule_" + course_schedule_info_name);
        }

        public static bool Update(string course_schedule_id, string course_schedule_info_name, string course_schedule_update_value)
        {
            return Update("course_schedule", "course_schedule_id", "'" + course_schedule_id + "'", "course_schedule_" + course_schedule_info_name, course_schedule_update_value);
        }

        public static string GetType(string course_schedule_id)
        {
            return Get(course_schedule_id, "type");
        }

        public static string GetCapacity(string course_schedule_id)
        {
            return Get(course_schedule_id, "capacity");
        }

        public static string GetSemester(string course_schedule_id)
        {
            return Get(course_schedule_id, "semester");
        }

        public static string GetCourseID(string course_schedule_id)
        {
            return Get("course_schedule", "course_schedule_id", "'" + course_schedule_id + "'", "course_id");
        }

        public static string GetDeptID(string course_schedule_id)
        {
            return Get("course_schedule", "course_schedule_id", "'" + course_schedule_id + "'", "dept_id");
        }

        public static bool UpdateType(string course_schedule_id, string course_schedule_update_value)
        {
            return Update(course_schedule_id, "type", "'" + course_schedule_update_value + "'");
        }

        public static bool UpdateCapacity(string course_schedule_id, string course_schedule_update_value)
        {
            return Update(course_schedule_id, "capacity", course_schedule_update_value);
        }

        public static bool UpdateSemester(string course_schedule_id, string course_schedule_update_value)
        {
            return Update(course_schedule_id, "semester", course_schedule_update_value);
        }

        public static bool UpdateCourseID(string course_schedule_id, string course_schedule_update_value)
        {
            return Update("course_schedule", "course_schedule_id", "'" + course_schedule_id + "'", "course_id", "'" + course_schedule_update_value + "'");
        }

        public static bool UpdateDeptID(string course_schedule_id, string course_schedule_update_value)
        {
            return Update("course_schedule", "course_schedule_id", "'" + course_schedule_id + "'", "dept_id", "'" + course_schedule_update_value + "'");
        }
    }

    public class CourseSelectDBUtil : DBUtil
    {

        public static new bool Exists(string course_select_id)
        {
            return Exists("course_select", "course_select_id", "'" + course_select_id + "'");
        }

        public static bool Add(string course_select_id, string stu_id, string course_schedule_id, string course_select_score)
        {
            List<string> list = new List<string>();
            list = new string[] { course_select_id, stu_id, course_schedule_id, course_select_score }.ToList();
            return Add("course_select", list);
        }

        public static bool Delete(string course_select_id)
        {
            return Delete("course_select", "course_select_id", "'" + course_select_id + "'");
        }

        public static string Get(string course_select_id, string course_select_info_name)
        {
            return Get("course_select", "course_select_id", "'" + course_select_id + "'", "course_select_" + course_select_info_name);
        }

        public static bool Update(string course_select_id, string course_select_info_name, string course_select_update_value)
        {
            return Update("course_select", "course_select_id", "'" + course_select_id + "'", "course_select_" + course_select_info_name, course_select_update_value);
        }

        public static string GetScore(string course_select_id)
        {
            return Get(course_select_id, "score");
        }

        public static string GetStuID(string course_select_id)
        {
            return Get("course_select", "course_select_id", "'" + course_select_id + "'", "stu_id");
        }

        public static string GetCourseScheduleID(string course_select_id)
        {
            return Get("course_select", "course_select_id", "'" + course_select_id + "'", "course_schedule_id");
        }

        public static string GetStatus(string course_select_id)
        {
            return Get(course_select_id, "status");
        }

        public static bool UpdateScore(string course_select_id, string course_select_update_value)
        {
            return Update(course_select_id, "score", "'" + course_select_update_value + "'");
        }

        public static bool UpdateStuID(string course_select_id, string course_select_update_value)
        {
            return Update("course_select", "course_select_id", "'" + course_select_id + "'", "stu_id", "'" + course_select_update_value + "'");
        }

        public static bool UpdateCourseScheduleID(string course_select_id, string course_select_update_value)
        {
            return Update("course_select", "course_select_id", "'" + course_select_id + "'", "course_schedule_id", "'" + course_select_update_value + "'");
        }

        public static bool UpdateStatus(string course_select_id, string course_select_update_value)
        {
            return Update(course_select_id, "status", course_select_update_value);
        }
    }
}