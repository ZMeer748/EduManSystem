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
    tch_status INTEGER NOT NULL,
    dept_id INTEGER NOT NULL,
    CONSTRAINT fk_teacher_department_dept_id FOREIGN KEY(dept_id) REFERENCES department(dept_id)
)

CREATE TABLE student(
    stu_id INTEGER CONSTRAINT pK_student_stu_id PRIMARY KEY,
    stu_name TEXT(16) NOT NULL,
    stu_password TEXT(30) NOT NULL,
    stu_gender TEXT(2) NOT NULL,
    stu_status INTEGER NOT NULL,
    class_id INTEGER NOT NULL,
    CONSTRAINT fk_student_department_dept_id FOREIGN KEY(class_id) REFERENCES class(class_id)
)
-- stu_status default 0 check 0 Or 1 Or 2
-- stu_gender '男' Or '女' 不允许空字符串

CREATE TABLE course(
    course_id INTEGER CONSTRAINT pK_course_course_id PRIMARY KEY,
    course_name TEXT(50) UNIQUE NOT NULL,
    course_credit INTEGER NOT NULL,
    tch_id INTEGER NOT NULL,
    FOREIGN KEY(tch_id) REFERENCES teacher(tch_id)
)
-- 开课时间待补
-- 不允许空字符串

CREATE TABLE sc(
    stu_id INTEGER NOT NULL,
    course_id INTEGER NOT NULL,
    sc_type INTEGER NOT NULL,
    sc_score SINGLE,
    sc_credit SINGLE,
    CONSTRAINT pk_sc_stu_id_course_id PRIMARY KEY(stu_id, course_id),
    CONSTRAINT fk_sc_student_stu_id FOREIGN KEY(stu_id) REFERENCES student(stu_id),
    CONSTRAINT fk_sc_course_course_id FOREIGN KEY(course_id) REFERENCES course(course_id)
)
-- [sc_score]<=100 And [sc_score]>=0
-- [sc_credit]<=10 And [sc_credit]>=0
-- sc_score 小数点后两位
-- sc_credit 小数点后两位
-- sc_type default 0
-- sc_type check 0 Or 1 Or 2

INSERT INTO department(dept_id, dept_name) VALUES
(1, '政法系'),
(2, '中文系'),
(3, '数学系'),
(4, '外语系'),
(5, '化学系'),
(6, '计算机科学系'),
(7, '音乐系'),
(8, '美术学院');



-- Access 2010 Version
-- CREATE TABLE department
-- (
-- 	dept_id INTEGER CONSTRAINT pK_department_dept_id PRIMARY KEY,
--     dept_name TEXT(20) UNIQUE NOT NULL
-- )

-- CREATE TABLE class
-- (
-- 	class_id INTEGER CONSTRAINT pK_class_class_id PRIMARY KEY,
--     dept_id INTEGER NOT NULL,
--     FOREIGN KEY(dept_id) REFERENCES department(dept_id) 
-- )

-- CREATE TABLE teacher(
--     tch_id INTEGER CONSTRAINT pK_teacher_tch_id PRIMARY KEY,
--     tch_name TEXT(16) NOT NULL,
--     tch_password TEXT(30) NOT NULL,
--     tch_gender TEXT(2) NOT NULL,
--     tch_status INTEGER NOT NULL,
--     dept_id INTEGER NOT NULL,
--     FOREIGN KEY(dept_id) REFERENCES department(dept_id)
-- )

-- CREATE TABLE student(
--     stu_id INTEGER CONSTRAINT pK_student_stu_id PRIMARY KEY,
--     stu_name TEXT(16) NOT NULL,
--     stu_password TEXT(30) NOT NULL,
--     stu_gender TEXT(2) NOT NULL,
--     stu_status INTEGER NOT NULL,
--     class_id INTEGER NOT NULL,
--     FOREIGN KEY(class_id) REFERENCES class(class_id)
-- )

-- CREATE TABLE course(
--     course_id INTEGER CONSTRAINT pK_course_course_id PRIMARY KEY,
--     course_name TEXT(50) UNIQUE NOT NULL,
--     course_credit INTEGER NOT NULL,
--     tch_id INTEGER NOT NULL,
--     FOREIGN KEY(tch_id) REFERENCES teacher(tch_id)
-- )
-- -- 开课时间待补

-- CREATE TABLE sc(
--     stu_id INTEGER NOT NULL,
--     course_id INTEGER NOT NULL,
--     sc_score SINGLE,
--     sc_credit SINGLE,
--     CONSTRAINT pk_sc_stu_id_course_id PRIMARY KEY(stu_id, course_id),
--     FOREIGN KEY(stu_id) REFERENCES student(stu_id),
--     FOREIGN KEY(course_id) REFERENCES course(course_id)
-- )