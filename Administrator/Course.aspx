<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Administrator.master" AutoEventWireup="true" CodeBehind="Course.aspx.cs" Inherits="EduManSystem.Administrator.Course" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHeaderNamePlaceHolder" runat="server">
    课程信息管理
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentHeaderBreadCrumbPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="AdministratorMainContentPlaceHolder" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row">
            <div class="col-12">
                <div class="card card-primary card-outline card-tabs">
                    <div class="card-header p-0 pt-1 border-bottom-0">
                        <ul class="nav nav-tabs" id="custom-tabs-one-tab" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link active" id="custom-tabs-one-home-tab" data-toggle="pill"
                                    href="#custom-tabs-one-home" role="tab" aria-controls="custom-tabs-one-home"
                                    aria-selected="true">添加</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" id="custom-tabs-one-profile-tab" data-toggle="pill"
                                    href="#custom-tabs-one-profile" role="tab" aria-controls="custom-tabs-one-profile"
                                    aria-selected="false">删除</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" id="custom-tabs-one-messages-tab" data-toggle="pill"
                                    href="#custom-tabs-one-messages" role="tab" aria-controls="custom-tabs-one-messages"
                                    aria-selected="false">修改</a>
                            </li>
                        </ul>
                    </div>
                    <!-- /.card-header -->
                    <div class="card-body">
                        <div class="tab-content" id="custom-tabs-one-tabContent">
                            <div class="tab-pane fade show active" id="custom-tabs-one-home" role="tabpanel"
                                aria-labelledby="custom-tabs-one-home-tab">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                    <label for="Input_Add_Course_ID">课程 ID</label>
                                                    <asp:TextBox id="Input_Add_Course_ID" runat="server"
                                                        name="course_id" class="form-control" type="text"
                                                        data-inputmask='"mask": "[A|9]{1,8}"' data-mask />
                                                </div>
                                            </div>
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                    <label for="Input_Add_Course_Name">课程名称</label>
                                                    <asp:TextBox id="Input_Add_Course_Name" runat="server"
                                                        name="course_name" class="form-control" type="text" />
                                                </div>
                                            </div>
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                    <label for="Input_Add_Course_Credit">课程学分</label>
                                                    <asp:TextBox id="Input_Add_Course_Credit" runat="server"
                                                        name="course_name" class="form-control" type="text"
                                                        data-inputmask='"mask": "9[9]"' data-mask />
                                                </div>
                                            </div>
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                    <label for="Input_Add_Tch_ID">任课教师编号</label>
                                                    <asp:TextBox id="Input_Add_Tch_ID" runat="server" name="course_name"
                                                        class="form-control" type="text"
                                                        data-inputmask='"mask": "[A|9]{1,8}"' data-mask />
                                                </div>
                                                <!-- <div class="form-group">
                                                    <label for="Input_Add_Tch_ID">任课教师编号</label>
                                                    <input id="Input_Add_Tch_ID" name="course_name"
                                                        class="form-control" type="text" data-inputmask-alias="datetime"
                                                        data-inputmask-inputformat="yyyy/mm/dd" data-mask />
                                                </div> -->
                                            </div>
                                        </div>
                                        <asp:Button ID="Button_Add" runat="server" Text="添加课程"
                                            class="btn btn-primary float-right" OnClick="Button_Add_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="tab-pane fade" id="custom-tabs-one-profile" role="tabpanel"
                                aria-labelledby="custom-tabs-one-profile-tab">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-sm-6">
                                                <div class="form-group">
                                                    <label for="Input_Delete_Course_ID">课程 ID</label>
                                                    <asp:TextBox id="Input_Delete_Course_ID" runat="server"
                                                        name="course_id" class="form-control" type="text"
                                                        data-inputmask='"mask": "[A|9]{1,8}"' data-mask />
                                                </div>
                                            </div>
                                        </div>
                                        <asp:Button ID="Button_Delete" runat="server" Text="删除课程"
                                            class="btn btn-primary float-right" OnClick="Button_Delete_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="tab-pane fade" id="custom-tabs-one-messages" role="tabpanel"
                                aria-labelledby="custom-tabs-one-messages-tab">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-sm-4">
                                                <div class="form-group">
                                                    <label for="Input_Update_Course_ID">课程 ID</label>
                                                    <asp:TextBox id="Input_Update_Course_ID" runat="server"
                                                        name="course_id" class="form-control" type="text"
                                                        data-inputmask='"mask": "[A|9]{1,8}"' data-mask />
                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <!-- select -->
                                                <div class="form-group">
                                                    <label>修改项</label>
                                                    <select id="Input_Update_Item_Select" runat="server"
                                                        class="form-control">
                                                        <option>课程名称</option>
                                                        <option>课程学分</option>
                                                        <option>任课教师编号</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <div class="form-group">
                                                    <label for="Input_Update_Value">修改为</label>
                                                    <asp:TextBox id="Input_Update_Value" runat="server" name="course_id"
                                                        class="form-control" type="text" />
                                                </div>
                                            </div>
                                        </div>
                                        <asp:Button ID="Button_Update" runat="server" Text="修改课程信息"
                                            class="btn btn-primary float-right" OnClick="Button_Update_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <!-- /.card-body -->
                </div>
                <!-- /.card -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-sm-12">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <div class="card">
                            <div class="card-header">
                                <h3 class="card-title">课程信息列表</h3>

                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse"><i
                                            class="fas fa-minus"></i></button>
                                    <button type="button" class="btn btn-tool" data-card-widget="remove"><i
                                            class="fas fa-remove"></i></button>
                                </div>
                            </div>
                            <!-- /.card-header -->
                            <div class="card-body">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                    DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="课程编号" HeaderText="课程编号" SortExpression="课程编号">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="课程名称" HeaderText="课程名称" SortExpression="课程名称">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="课程学分" HeaderText="课程学分" SortExpression="课程学分">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="开课院系" HeaderText="开课院系" SortExpression="开课院系">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="任课教师" HeaderText="任课教师" SortExpression="任课教师">
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <!-- /.card-body -->
                            <asp:SqlDataSource runat="server" ID="SqlDataSource1"
                                ConnectionString='<%$ ConnectionStrings:ConnectionString %>'
                                ProviderName='<%$ ConnectionStrings:ConnectionString.ProviderName %>'
                                SelectCommand="SELECT course.course_id as `课程编号`, course.course_name as `课程名称`,  course.course_credit as `课程学分`, department.dept_name as `开课院系`, teacher.tch_name as `任课教师` FROM (course INNER JOIN teacher ON course.tch_id = teacher.tch_id) INNER JOIN department ON teacher.dept_id = department.dept_id">
                            </asp:SqlDataSource>
                        </div>
                        <!-- /.card -->
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- /.col -->
            <div class="col-sm-12">

                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <div class="card">
                            <div class="card-header">
                                <h3 class="card-title">教师信息列表</h3>

                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse"><i
                                            class="fas fa-minus"></i></button>
                                    <button type="button" class="btn btn-tool" data-card-widget="remove"><i
                                            class="fas fa-remove"></i></button>
                                </div>
                            </div>
                            <!-- /.card-header -->
                            <div class="card-body">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                                    DataSourceID="SqlDataSource2">
                                    <Columns>
                                        <asp:BoundField DataField="教师编号" HeaderText="教师编号" SortExpression="教师编号">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="教师姓名" HeaderText="教师姓名" SortExpression="教师姓名">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="教师性别" HeaderText="教师性别" SortExpression="教师性别">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="教师年龄" HeaderText="教师年龄" SortExpression="教师年龄"
                                            ReadOnly="True"></asp:BoundField>
                                        <asp:BoundField DataField="所属院系" HeaderText="所属院系" SortExpression="所属院系">
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <!-- /.card-body -->
                            <asp:SqlDataSource runat="server" ID="SqlDataSource2"
                                ConnectionString='<%$ ConnectionStrings:ConnectionString %>'
                                ProviderName='<%$ ConnectionStrings:ConnectionString.ProviderName %>'
                                SelectCommand="SELECT teacher.tch_id as `教师编号`, teacher.tch_name as `教师姓名`, teacher.tch_gender as `教师性别`, DateDiff('yyyy', [teacher.tch_birthday], Date()) as `教师年龄`,  department.dept_name as `所属院系` FROM teacher INNER JOIN department ON teacher.dept_id = department.dept_id">
                            </asp:SqlDataSource>
                        </div>
                        <!-- /.card -->
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <!-- /.row -->
    </form>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ScriptFunctionPlaceHolder" runat="server">
    <script>
        function pageLoad(sender, args) {
            $('#MainContentPlaceHolder_AdministratorMainContentPlaceHolder_GridView1').DataTable();
            $('#MainContentPlaceHolder_AdministratorMainContentPlaceHolder_GridView2').DataTable();

            // data-mask
            $('[data-mask]').inputmask()
        };
    </script>
</asp:Content>