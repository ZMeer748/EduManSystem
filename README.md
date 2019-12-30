## 课程设计报告

### 目录

(Index)

### 1 简介

本次课程设计的题目是选课系统，有学生、教师以及管理员三个角色，学生可进行选/退课以及查看成绩的操作；教师可以进行查看课程安排、录入课程成绩以及申请开课信息的操作；管理员可进行对用户、课程、课程安排信息、选课信息进行添加、删除，对它们的属性进行修改的操作。

系统开发环境：Windows 10，Visual Studio 2019，Visual Studio Code，Microsoft Office 2016。

### 2 相关技术

#### 2.1 ASP.NET

ASP.NET 是由微软在 .NET Framework 框架中所提供，开发 Web 应用程序的类别库，封装在 System.Web.dll 文件中，显露出 System.Web 名字空间，并提供 ASP.NET 网页处理、扩展以及 HTTP 通道的应用程序与通信处理等工作，以及 Web Service 的基础架构。ASP.NET 是 ASP 技术的后继者，但它的发展性要比 ASP 技术要强大许多。课程主要内容，本次课程设计用到的主要技术。

#### 2.2 Microsoft Office Access

由微软发布的关系数据库管理系统。它结合了 Microsoft Jet Database Engine 和图形用户界面两项特点，是 Microsoft Office 的系统程序之一。本次课程设计使用该数据库。该数据库某些方面确实存在优势，但往往遇到的问题更多。使用该数据库，是由于当初想要尝试的原因，后来由于时间缘故，无法重新构建了，才一直使用了下来。版本为 2016，与 ASP.NET 后端交互使用 OLEDB 数据库引擎。

#### 2.3 JQuery

jQuery 是一套跨浏览器的 JavaScript 库，简化 HTML 与 JavaScript 之间的操作。本次课程设计中，通常是在调用其他库，或者后端以 RegisterClientScriptBlock 相应页面请求时使用。

#### 2.4 Bootstrap

Bootstrap 是一组用于网站和网络应用程序开发的开源前端。本次课程设计中，大量使用 Bootstrap 进行布局。

#### 2.5 AdminLTE

[AdminLTE](https://adminlte.io/)，一个基于bootstrap 的轻量级后台模板。

1. **DataTables**，仅需一行代码，可将表格标签格式化，在前端实现分页、查询过滤等功能；
2. **Toastr**，起司提示，操作的反馈，曾经在别的课程中使用，十分方便；本次课程设计中设计了一个 Toastr 类，用以生成 Toastr 的前端代码；
3. **font-awesome**，前端图标库；
4. **input-mask**，规范输入，相当于一个前端的正则表达式验证。

#### 2.6 Git

分布式版本控制软件。管理代码，可查找更改处、撤销更改等。

#### 2.7 其他

1. [Login Form v2 by Colorlib](https://colorlib.com/wp/template/login-form-v2/)，登录页的 Bootstrap 模版；
2. [AccessHelper.cs by smartbooks](https://github.com/smartbooks/SmartDBUtility/blob/master/AccessHelper.cs)，Access 数据库工具类，是用来连接数据库并对数据库进行操作的基础类，方便后续编写上层的数据库交互方法。

### 3 系统设计

#### 3.1 数据库设计

由于没有花太多时间在设计上，本系统的数据库有不小的缺陷，原来是以能为各项功能提供存储服务的目的设计数据库的，结果导致了数据库设计的不合理，舍弃了许多的可扩展性。前期没有花时间去参考更多的设计案例，以及后来由于时间问题没有重新构建，导致了这方面本系统的完成度不高。

本系统的具体数据库设计如下。

##### 3.1.1 院系表

记录院系信息。

(image)

##### 3.1.2 班级表

记录班级信息，有外键院系编号。

(image)

##### 3.1.3 学生表

记录学生信息，有外键班级编号。

(image)

##### 3.1.4 管理员表

记录管理员信息。

(image)

##### 3.1.5 课程表

记录课程信息，教师编号、课程编号为外键。

(image)

##### 3.1.6 课程安排表

记录课程安排信息，课程编号、院系编号为外键，意为该院系课程面向某院系的开课安排。

(image)

##### 3.1.7 选课表

记录选课信息，学生编号、课程安排编号为外键。

(image)

##### 3.1.8 其他

(image)

还未使用的表：

1. user_status，用户状态表，设置用户可能的状态，主键是另外三个用户表的外键，此表可用作未来功能的扩展，暂时没有具体实现的功能，现只有 0 一个值，为用户默认状态，可扩展成有学生毕业、学生休学等的状态；
2. course_schedule_status，课程安排的状态表，同上，还未实现，可用作扩充，可扩充课程安排选课阶段，上课阶段，结课等的状态；
3. course_select_status，选课状态表，亦同上，未实现，用作扩充，可扩展成绩未录入、成绩已录入等的状态。

还有 Access 中的查询表，相当于一般数据库中的视图，共有三个：

1. course_select_count，用于计算每个课程安排的已选数量，在学生选课时用以判断课程容量是否已满；
2. student_age，用学生生日计算年龄，方便查询；
3. teacher_age，用教师生日计算年龄，方便查询。

##### 3.1.9 各表的关系

(image)

#### 3.2 功能设计

##### 3.2.1 母版（Site.Master）

主母版包含的元素有：

1. 从 AdminLTE 中摘取来的导航栏、侧栏、底栏以及主内容容器几个部分；
2. 修改 AdminLTE 侧栏的用户面板样式，修改用户图标，添加登出按钮；
3. 导航栏删除没有用到的 AdminLTE 元素，增加主页超链接；
4. 修改底栏样式。
5. 母版的内容容器有：
   - 网页标题；
   - 网页头部（一般用来放置 css 样式代码）；
   - 侧栏项目（二级母版配置）；
   - 主内容标题；
   - 主内容；
   - 外部 js 导入；
   - Script 代码。

主母版包含的功能有：

1. 作为二级母版的容器；
2. 以检查会话 Session 中的值的方式检查登录状态；
3. 侧栏用户面板上，不同用户类型显示不同图标，显示用户姓名，用户登录时显示登出按钮；
4. 登出按钮点击后置 Session 为 null，并重定向页面至主页。

##### 3.2.2 主页母版（Index.master）

主页母版包含的元素有：

1. 对主母版的各容器进行桥接；
2. 侧边栏增加主页和登录页的导航。

主页母版的功能有：

1. 获取 URL，设置相应的侧栏导航的样式为 active。

##### 3.2.3 用户页母版

用户页母版（Student.master、Teacher.master 以及 Administrator.master）包含的元素有：

1. 对主母版的各容器进行桥接；
2. 侧边栏增加各自用户功能页的导航。

用户页母版的功能有：

1. 获取 URL，设置相应的侧栏导航的样式为 active；

##### 3.2.4 登录页

登录页包含的元素有：

1. 母版为主页母版；
2. 套用 Bootstrap 模板；
3. 增加用户类型选择按钮组。

登录页的功能有：

1. 检查输入框中的用户 ID 以及密码，若在数据库中有相符的记录，则登录成功，跳转至相应用户的用户主页：若无相符记录，则登录失败，弹出 Toastr 吐司提示。

##### 3.2.5 学生

学生用户有两个功能，分别是选课与查看课程成绩：

###### 3.2.5.1 选课页

该页元素有：

1. 可选课程 GridView，最后一列为选课操作按钮，为其添加行命令；页面加载后，GridView 通过 dataTables.js 自动生成样式；
2. 已选课程 GridView，最后一列为退选操作按钮，为其添加行命令；页面加载后，GridView 通过 dataTables.js 自动生成样式

该页功能有：

1. 页面载入时，获取该学生的可选、已选课程，生成数据源，分别设置给两个 GridView；
2. 用户单击可选课程表某行选课按钮，触发行命令，向选课表中进行插入查询，成功则显示成功 Toastr，失败则显示失败 Toastr，退课表也同样。

###### 3.2.5.2 成绩页

该页元素有：

1. 已选课程 GridView，页面加载后，GridView 通过 dataTables.js 自动生成样式。

该页功能有：

1. 页面载入时，获取该学生的已选课程，显示有成绩的课程。

##### 3.2.6 教师

教师用户有三个功能，分别是课程安排、成绩录入与开课申请

###### 3.2.6.1 课程安排页

查看教师教授的课程信息。

###### 3.2.6.2 成绩录入

教师输入课程编号，查找课程，课程信息 GridView 中显示该门课程的信息，教师输入学生编号与课程成绩，点击录入，则可录入成绩。

###### 3.2.6.3 开课申请

教师输入课程编号、课程名称、课程学分，点击申请开课按钮，即可增加课程信息。

##### 3.2.7 管理员

管理员共有 6 个功能页面，对应课程信息、课程安排、选课、学生、教师以及管理员，每个页面主内容上方是一个标签卡，包含增加、删除与修改；下方是项目相对应的数据表。管理员可对各项进行增加与删除，以及修改它们的属性。

#### 3.2.8 用户功能页说明

所有用户功能页都包含登录状态检测与账号类型检测功能，不符则跳转至主页。

### 4 系统实现

#### 4.1 工具类（App_Code）

1. **AccessHelper.cs**，通用数据库工具类，方便数据库交互；
2. **DBUtil.cs**，继承 AccessHelper，增加 Exists、Add、Delete、Get、Update 以及 GetDataTable 方法；
3. **ClassDBUtil.cs**，继承 DBUtil，重写基本方法，添加 class 表各字段属于自己的 Get 和 Update 方法；
4. **UserDBUtil.cs**，类 UserDBUtil 继承 DBUtil，类 StudentUserDBUtil、类 TeacherUserDBUtil 以及类 Administrator 继承 UserDBUtil，重写与增加，为后续具体业务提高开发效率；
5. **CourseDBUtil.cs**，类 CourseDBUtil、类 CourseScheduleDBUtil 以及类 CourseSelectDBUtil 继承 DBUtil;
6. **GeneralUtil.cs**，通用工具类，当前仅有一个方法 GridViewInit，负责 GridView 的数据绑定以及样式调整，减少大量的代码重复；
7. **Toastr.cs**，负责生成 Toastr 的脚本代码，减少代码重复。

#### 4.2 母版

共有四个母版，一级母版为 Site.Master，二级母版为 Index.master、Student.master、Teacher.master 以及 Administrator.master。

Site.Master 的内容：

(image)

Index.master 添加的侧栏内容：

(image)

Student.master 添加的侧栏内容：

(image)

Teacher.master 添加的侧栏内容：

(image)

Administrator.master 添加的内容：

(image)

Site.Master 的账号状态检查功能：

(image)

二级母版根据页面 URL 定义侧栏项目样式功能：

(image)

#### 4.4 管理员

共六个功能页面，内容框架基本一致，都是对数据库的增删改操作，以下展示三个例子体现实现过程。

课程的添加示例：

(image)

学生的属性修改示例：

(image)

选课记录的删除示例：

(image)

#### 4.5 学生

选课页：

(image)

成绩页：

(image)

#### 4.6 教师

课程信息页：

(image)

成绩录入页：

(image)

开课申请页：

(image)

#### 4.7 Global.asax（URL Routing）

负责支持重定义的 URL 的路由：

(image)

#### 4.8 主页与用户页主页

Default.aspx：

(image)

用户页的 Default.aspx:

(image)

#### 4.9 部分细节实现

ASP.NET AJAX：

(image)

Toastr 吐司提示：

(image)

dataTables：

(image)

### 5 系统运行与测试

以下通过四个具体的运行案例进行测试。

#### 5.1 管理员添加课程与课程安排，修改教师名称

(image)

#### 5.2 教师申请开课

(image)

#### 5.3 学生选课

(image)

#### 5.4 教师录入成绩，学生查看成绩

(image)

### 6 参考

(text)

### 7 小结
