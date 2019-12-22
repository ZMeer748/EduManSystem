# EduManSystem

使用 ASP.NET 搭建的教务管理 Web 项目。

## 开发笔记

### Site.Master

- [ ] 删除无用元素，配置跳转入口
- [X] 用户图标在 Site.Master 载入时配置完成
- [ ] 侧栏用户名作为用户页入口（Student.aspx、Teacher.aspx 以及 Administrator.aspx），用户登录后能够访问主页
- [ ] Default.aspx 展示系统开发过程，中间另外提供一个醒目的登录页入口
- [X] 顶栏配置登出按钮
- [ ] 底部 README.md 读取？

### Login

- [ ] 样式调整
~~- [ ] 注意登录失败后清除输入框内容~~

### Student

- [ ] 本学期？已选课程
- [ ] 选课页面
- [ ] 成绩查询（学分计算等）

### Teacher

- [ ] 成绩录入
- [ ] 教授课程查询
- [ ] 开课申请

### Administrator

- [ ] 学生管理（添加、删除、修改）
- [ ] 课程管理
- [ ] 开课信息确认

### 数据库

- [ ] 开课表（课程、班级为主键，课程容纳学生数量，已选学生数量，选课时有余量判断；课程安排信息，如上课时间等）
- [ ] 管理信息表（教师提交开课信息，记录到管理信息表，管理员通过后删除，并在 course 中添加新的课程）
- [ ] 属性：学期，为选课表、开课表以及学生表配置

## 数据库设计

### 1 department

| 字段         | 键          | 数据类型  | 长度 | 格式 | 必需 | 字符串空 | 验证规则      | 默认值 |
| :-:          | :-:        | :-:     | :-:  | :-: | :-: | :-:     | :-:          | :-:   |
| dept_id      | PK         | INTEGER |      |     | 是   |        |             |        |
| dept_name    |            | TEXT    | 20   |     | 是   | 否     | UNIQUE       |       |

### 2 class

| 字段         | 键          | 数据类型  | 长度 | 格式 | 必需 | 字符串空 | 验证规则      | 默认值 |
| :-:          | :-:        | :-:     | :-:  | :-: | :-: | :-:     | :-:          | :-:   |
| class_id     | PK         | INTEGER |      |     | 是   |        |             |        |
| dept_id      | FK (dept)  | INTEGER |      |     | 是   |        |             |       |
| class_name   |            | TEXT    | 20   |     | 是   | 否     | UNIQUE       |       |

### 3 student

| 字段         | 键          | 数据类型  | 长度 | 格式 | 必需 | 字符串空 | 验证规则      | 默认值 |
| :-:          | :-:        | :-:     | :-:  | :-: | :-: | :-:     | :-:          | :-:   |
| stu_id       | PK         | INTEGER |      |     | 是   |        |             |        |
| stu_name     |            | TEXT    | 16   |     | 是   | 否     |              |       |
| stu_password |            | TEXT    | 30   |     | 是   | 否     |              |       |
| stu_gender   |            | TEXT    | 2    |     | 是   |        | '男' Or '女' |       |
| stu_status   |            | BYTE    |      |     | 是   |        | 0 Or 1 Or 2  | 0     |
| class_id     | FK (class) | INTEGER |      |     | 是   |        |              |       |

### 4 teacher

| 字段         | 键          | 数据类型  | 长度 | 格式 | 必需 | 字符串空 | 验证规则      | 默认值 |
| :-:          | :-:        | :-:     | :-:  | :-: | :-: | :-:      | :-:          | :-:   |
| tch_id       | PK         | INTEGER |      |     | 是   |          |             |        |
| tch_name     |            | TEXT    | 16   |     | 是   | 否       |              |       |
| tch_password |            | TEXT    | 30   |     | 是   | 否       |              |       |
| tch_gender   |            | TEXT    | 2    |     | 是   |          | '男' Or '女' |       |
| tch_status   |            | BYTE    |      |     | 是   |          | 0 Or 1 Or 2  | 0     |
| dept_id      | FK (dept)  | INTEGER |      |     | 是   |          |              |       |

### 5 course

| 字段         | 键          | 数据类型  | 长度 | 格式 | 必需 | 字符串空 | 验证规则      | 默认值 |
| :-:          | :-:        | :-:     | :-:  | :-: | :-: | :-:      | :-:          | :-:   |
| course_id    | PK         | INTEGER |      |     | 是   |          |             |        |
| course_name  |            | TEXT    | 50   |     | 是   | 否       | UNIQUE       |       |
| course_credit| | BYTE    | | | 是   | | [course_credit]<=6 And [course_credit]>=0 |     |
| tch_id       | FK (teacher)| INTEGER| 2    |     | 是   |          | '男' Or '女' |       |

### 6 sc

| 字段         | 键          | 数据类型  | 长度 | 格式 | 必需 | 字符串空 | 验证规则      | 默认值 |
| :-:          | :-:        | :-:     | :-:  | :-: | :-: | :-:      | :-:          | :-:  |
| stu_id       | PK, FK     | INTEGER |      |     | 是   |        |             |        |
| course_id    | PK, FK     | INTEGER |      |     | 是   |          |             |       |
| sc_score     |            | SINGLE  | | .2  | | | [sc_score]<=100 And [sc_score]>=0 |    |
| sc_credit    |            | SINGLE  | | .2  | | | [sc_credit]<=10 And [sc_credit]>=0 |   |
| sc_type      |            | BYTE    |      |     | 是   |          | 0 Or 1 Or 2 |       |


  <!-- '<%=ResolveClientUrl() %>' -->
