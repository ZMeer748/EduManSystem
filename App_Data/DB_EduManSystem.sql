-- TEXT 不允许空字符串

CREATE TABLE department
(
	dept_id TEXT(20) CONSTRAINT pK_department_dept_id PRIMARY KEY,
    dept_name TEXT(20) UNIQUE NOT NULL
)

CREATE TABLE class
(
	class_id TEXT(20) CONSTRAINT pK_class_class_id PRIMARY KEY,
    class_name TEXT(20) UNIQUE NOT NULL,
    dept_id TEXT(20) NOT NULL,
    CONSTRAINT fk_class_department_dept_id FOREIGN KEY(dept_id) REFERENCES department(dept_id) 
)

CREATE TABLE user_status(
    user_status_id BYTE,
    user_status_name TEXT(20),
    CONSTRAINT pk_user_status_user_status_id PRIMARY KEY(user_status_id)
)

CREATE TABLE teacher(
    tch_id TEXT(20) CONSTRAINT pK_teacher_tch_id PRIMARY KEY,
    tch_name TEXT(16) NOT NULL,
    tch_password TEXT(30) NOT NULL,
    tch_gender TEXT(2) NOT NULL,
    tch_birthday DATETIME NOT NULL,
    tch_status BYTE NOT NULL,
    dept_id TEXT(20) NOT NULL,
    CONSTRAINT fk_teacher_department_dept_id FOREIGN KEY(dept_id) REFERENCES department(dept_id),
    CONSTRAINT fk_teacher_user_status_user_status_id FOREIGN KEY(tch_status) REFERENCES user_status(user_status_id)
)
-- tch_status default 0 check 0 Or 1 Or 2
-- tch_gender '男' Or '女'
-- tch_birthday 格式 短日期

CREATE TABLE student(
    stu_id TEXT(20) CONSTRAINT pK_student_stu_id PRIMARY KEY,
    stu_name TEXT(16) NOT NULL,
    stu_password TEXT(30) NOT NULL,
    stu_gender TEXT(2) NOT NULL,
    stu_birthday DATETIME NOT NULL,
    stu_status BYTE NOT NULL,
    class_id TEXT(20) NOT NULL,
    CONSTRAINT fk_student_department_dept_id FOREIGN KEY(class_id) REFERENCES class(class_id),
    CONSTRAINT fk_student_user_status_user_status_id FOREIGN KEY(stu_status) REFERENCES user_status(user_status_id)
)
-- stu_status default 0 check 0 Or 1 Or 2
-- stu_gender '男' Or '女'
-- stu_birthday 格式 短日期

CREATE TABLE administrator(
    admin_id TEXT(20) CONSTRAINT pK_administrator_admin_id PRIMARY KEY,
    admin_name TEXT(16) NOT NULL,
    admin_password TEXT(30) NOT NULL,
    admin_gender TEXT(2) NOT NULL,
    admin_birthday DATETIME NOT NULL,
    admin_status BYTE NOT NULL,
    CONSTRAINT fk_administrator_user_status_user_status_id FOREIGN KEY(admin_status) REFERENCES user_status(user_status_id)
)
-- admin_status default 0 check 0 Or 1 Or 2
-- admin_gender '男' Or '女' 不允许空字符串
-- admin_birthday 格式 短日期

CREATE TABLE course(
    course_id TEXT(20) CONSTRAINT pK_course_course_id PRIMARY KEY,
    course_name TEXT(50) UNIQUE NOT NULL,
    course_credit BYTE NOT NULL,
    tch_id TEXT(20) NOT NULL,
    FOREIGN KEY(tch_id) REFERENCES teacher(tch_id)
)

CREATE TABLE course_schedule_status(
    course_schedule_status_id BYTE,
    course_schedule_status_name TEXT(20),
    CONSTRAINT pk_course_schedule_status_course_schedule_statuss_id PRIMARY KEY(course_schedule_status_id)
)

CREATE TABLE course_schedule(
    course_schedule_id TEXT(20) UNIQUE NOT NULL,
    course_id TEXT(20) NOT NULL,
    dept_id TEXT(20) NOT NULL,
    course_schedule_type TEXT(20) NOT NULL,
    course_schedule_capacity INTEGER,
    course_schedule_status BYTE NOT NULL,
    CONSTRAINT pk_sc_stu_id_course_id PRIMARY KEY(course_id, dept_id),
    CONSTRAINT fk_course_schedule_course_course_id FOREIGN KEY(course_id) REFERENCES course(course_id),
    CONSTRAINT fk_course_schedule_department_dept_id FOREIGN KEY(dept_id) REFERENCES department(dept_id),
    CONSTRAINT fk_course_schedule_status_id FOREIGN KEY(course_schedule_status) REFERENCES course_schedule_status(course_schedule_status_id)
)
-- course_schedule_type Default "公共必修课" Or "公共选修课" Or "专业必修课" Or "专业选修课"
-- [course_schedule_semester]>0 And [course_schedule_semester]<=8
-- course_schedule_capacity Default 300

CREATE TABLE course_select_status(
    course_select_status_id BYTE,
    course_select_status_name TEXT(20),
    CONSTRAINT pk_course_select_status_course_select_statuss_id PRIMARY KEY(course_select_status_id)
)

CREATE TABLE course_select(
    course_select_id TEXT(30) UNIQUE NOT NULL,
    stu_id TEXT(20) NOT NULL,
    course_schedule_id TEXT(20) NOT NULL,
    course_select_score SINGLE,
    course_select_status BYTE NOT NULL,
    CONSTRAINT pk_course_select_stu_id_course_schedule_id PRIMARY KEY(stu_id, course_schedule_id),
    CONSTRAINT fk_course_select_student_stu_id FOREIGN KEY(stu_id) REFERENCES student(stu_id),
    CONSTRAINT fk_course_select_course_schedule_course_schedule_id FOREIGN KEY(course_schedule_id) REFERENCES course_schedule(course_schedule_id),
    CONSTRAINT fk_course_select_status_id FOREIGN KEY(course_select_status) REFERENCES course_select_status(course_select_status_id)
)
-- [course_select_score]<=100 And [course_select_score]>=0
-- course_select_score 小数点后两位


INSERT INTO department(dept_id, dept_name) VALUES
(1, '政法系'),
(2, '中文系'),
(3, '数学系'),
(4, '外语系'),
(5, '化学系'),
(6, '计算机科学系'),
(7, '音乐系'),
(8, '美术学院');

-- 选课表
SELECT course_select.course_select_id AS `选课编号`, course_select.stu_id AS `学生编号`, student.stu_name AS `学生姓名`, course_select.course_schedule_id AS `课程编号`, course.course_name AS `课程名称`, course_select.course_select_score AS `成绩`, course_select.course_select_status AS `选课状态` FROM ((course_select INNER JOIN course_schedule ON course_select.course_schedule_id = course_schedule.course_schedule_id) INNER JOIN course ON course_schedule.course_id = course.course_id) INNER JOIN student ON course_select.stu_id = student.stu_id

-- 课程安排表
SELECT course_schedule.course_schedule_id AS `课程安排编号`, course_schedule.course_id AS `课程编号`,course.course_name AS `课程名称`, course_schedule.dept_id AS `面向院系编号`, department.dept_name AS `院系名称`, course_schedule.course_schedule_type AS `课程安排类型`, course_schedule.course_schedule_capacity AS `课程安排容量`, course_schedule_status AS `课程安排状态` FROM (course_schedule INNER JOIN course ON course_schedule.course_id = course.course_id) INNER JOIN department ON course_schedule.dept_id = department.dept_id

-- 院系
SELECT dept_id AS `院系编号`, dept_name AS `院系名称` FROM department

-- 班级
SELECT class.class_id AS `班级编号`, class.class_name AS `班级名称`, department.dept_name AS `所属院系` FROM class INNER JOIN department ON class.dept_id = department.dept_id

-- 学生
SELECT student.stu_id AS `学生编号`, student.stu_name AS `学生姓名`, student.stu_gender AS `性别`, DateDiff('yyyy',[student.stu_birthday],Date()) AS `年龄`, student.stu_status AS `用户状态`, student.class_id AS `班级编号`, class.class_name AS `班级名称`, department.dept_name AS `所属院系` FROM (student INNER JOIN class ON student.class_id = class.class_id) INNER JOIN department ON class.dept_id = department.dept_id

-- 教师
SELECT teacher.tch_id AS `教师编号`, teacher.tch_name AS `教师姓名`, teacher.tch_gender AS `性别`, DateDiff('yyyy',[teacher.tch_birthday],Date()) AS `年龄`, teacher.tch_status AS `用户状态`, teacher.dept_id AS `所属院系编号`,department.dept_name AS `所属院系` FROM teacher INNER JOIN department ON teacher.dept_id = department.dept_id

-- 管理员
SELECT admin_id AS `管理员编号`, admin_name AS `管理员姓名`, admin_gender AS `性别`, DateDiff('yyyy',[admin_birthday],Date()) AS `年龄`, admin_status AS `用户状态` FROM administrator 