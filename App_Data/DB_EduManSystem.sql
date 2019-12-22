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

CREATE TABLE course_schedule(
    course_schedule_id TEXT(20) UNIQUE NOT NULL,
    course_id TEXT(20) NOT NULL,
    dept_id TEXT(20) NOT NULL,
    course_schedule_type TEXT(20) NOT NULL,
    course_schedule_capacity INTEGER,
    course_schedule_semester BYTE NOT NULL,
    CONSTRAINT pk_sc_stu_id_course_id PRIMARY KEY(course_id, dept_id),
    CONSTRAINT fk_course_schedule_course_course_id FOREIGN KEY(course_id) REFERENCES course(course_id),
    CONSTRAINT fk_course_schedule_department_dept_id FOREIGN KEY(dept_id) REFERENCES department(dept_id)
)
-- course_schedule_type Default "公共必修课" Or "公共选修课" Or "专业必修课" Or "专业选修课"
-- [course_schedule_semester]>0 And [course_schedule_semester]<=8
-- course_schedule_capacity Default 300

CREATE TABLE course_select(
    course_select_id TEXT(30) UNIQUE NOT NULL,
    stu_id TEXT(20) NOT NULL,
    course_schedule_id TEXT(20) NOT NULL,
    course_select_score SINGLE,
    course_select_status BYTE NOT NULL,
    CONSTRAINT pk_course_select_stu_id_course_schedule_id PRIMARY KEY(stu_id, course_schedule_id),
    CONSTRAINT fk_course_select_student_stu_id FOREIGN KEY(stu_id) REFERENCES student(stu_id),
    CONSTRAINT fk_course_select_course_schedule_course_schedule_id FOREIGN KEY(course_schedule_id) REFERENCES course_schedule(course_schedule_id)
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