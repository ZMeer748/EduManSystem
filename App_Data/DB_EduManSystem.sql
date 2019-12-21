CREATE TABLE department
(
	dept_id INTEGER CONSTRAINT pK_department_dept_id PRIMARY KEY,
    dept_name TEXT(20) UNIQUE NOT NULL
)

CREATE TABLE class
(
	class_id INTEGER CONSTRAINT pK_class_class_id PRIMARY KEY,
    class_name TEXT(20) UNIQUE NOT NULL,
    dept_id INTEGER NOT NULL,
    CONSTRAINT fk_class_department_dept_id FOREIGN KEY(dept_id) REFERENCES department(dept_id) 
)

CREATE TABLE teacher(
    tch_id INTEGER CONSTRAINT pK_teacher_tch_id PRIMARY KEY,
    tch_name TEXT(16) NOT NULL,
    tch_password TEXT(30) NOT NULL,
    tch_gender TEXT(2) NOT NULL,
    tch_birthday DATETIME NOT NULL,
    tch_status INTEGER NOT NULL,
    dept_id INTEGER NOT NULL,
    CONSTRAINT fk_teacher_department_dept_id FOREIGN KEY(dept_id) REFERENCES department(dept_id)
)
-- tch_status default 0 check 0 Or 1 Or 2
-- tch_gender '男' Or '女' 不允许空字符串
-- tch_birthday 格式 短日期

CREATE TABLE student(
    stu_id INTEGER CONSTRAINT pK_student_stu_id PRIMARY KEY,
    stu_name TEXT(16) NOT NULL,
    stu_password TEXT(30) NOT NULL,
    stu_gender TEXT(2) NOT NULL,
    stu_birthday DATETIME NOT NULL,
    stu_status INTEGER NOT NULL,
    class_id INTEGER NOT NULL,
    CONSTRAINT fk_student_department_dept_id FOREIGN KEY(class_id) REFERENCES class(class_id)
)
-- stu_status default 0 check 0 Or 1 Or 2
-- stu_gender '男' Or '女' 不允许空字符串
-- stu_birthday 格式 短日期

CREATE TABLE administrator(
    admin_id INTEGER CONSTRAINT pK_administrator_admin_id PRIMARY KEY,
    admin_name TEXT(16) NOT NULL,
    admin_password TEXT(30) NOT NULL,
    admin_gender TEXT(2) NOT NULL,
    admin_birthday DATETIME NOT NULL,
    admin_status INTEGER NOT NULL,
)
-- admin_status default 0 check 0 Or 1 Or 2
-- admin_gender '男' Or '女' 不允许空字符串
-- admin_birthday 格式 短日期

CREATE TABLE course(
    course_id INTEGER CONSTRAINT pK_course_course_id PRIMARY KEY,
    course_name TEXT(50) UNIQUE NOT NULL,
    course_credit INTEGER NOT NULL,
    tch_id INTEGER NOT NULL,
    FOREIGN KEY(tch_id) REFERENCES teacher(tch_id)
)
-- course_name 不允许空字符串

CREATE TABLE course_schedule(
    course_schedule_id INTEGER UNIQUE NOT NULL,
    course_id INTEGER NOT NULL,
    dept_id INTEGER NOT NULL,
    course_schedule_type INTEGER NOT NULL,
    course_schedule_capacity INTEGER,
    course_schedule_semester INTEGER NOT NULL,
    CONSTRAINT pk_sc_stu_id_course_id PRIMARY KEY(course_id, dept_id),
    CONSTRAINT fk_course_schedule_course_course_id FOREIGN KEY(course_id) REFERENCES course(course_id),
    CONSTRAINT fk_course_schedule_department_dept_id FOREIGN KEY(dept_id) REFERENCES department(dept_id)
)
-- course_schedule_type 0 Or 1 Or 2 Or 3（0 为公共必修课，1 为公共选修课，2 为专业必修课，3 为 专业选修课）
-- [course_schedule_semester]>0 And [course_schedule_semester]<=8

CREATE TABLE course_select(
    course_select_id TEXT(30) UNIQUE NOT NULL,
    stu_id INTEGER NOT NULL,
    course_schedule_id INTEGER NOT NULL,
    course_select_score SINGLE,
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