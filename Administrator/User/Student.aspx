﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Administrator.master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="EduManSystem.Administrator.User.Student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHeaderNamePlaceHolder" runat="server">
    学生信息管理
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
                                                    <label for="Input_Add_Student_ID">学生编号</label>
                                                    <asp:TextBox id="Input_Add_Student_ID" runat="server"
                                                        name="student_id" class="form-control" type="text"
                                                        data-inputmask='"mask": "[A|9]{1,8}"' data-mask />
                                                </div>
                                            </div>
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                    <label for="Input_Add_Student_Name">姓名</label>
                                                    <asp:TextBox id="Input_Add_Student_Name" runat="server"
                                                        name="student_name" class="form-control" type="text" />
                                                </div>
                                            </div>
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                    <label for="Input_Add_Student_Password">用户密码</label>
                                                    <asp:TextBox id="Input_Add_Student_Password" runat="server"
                                                        name="student_password" class="form-control" type="text"
                                                        data-inputmask='"mask": "[A|9]{1,16}"' data-mask />
                                                </div>
                                            </div>
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                    <label for="Input_Add_Student_Gender">性别</label>
                                                    <asp:TextBox id="Input_Add_Student_Gender" runat="server"
                                                        name="student_gender" class="form-control" type="text"
                                                        data-inputmask='"mask": "[女|男]"' data-mask />
                                                </div>
                                            </div>
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                    <label for="Input_Add_Student_Birthday">出生时间</label>
                                                    <asp:TextBox id="Input_Add_Student_Birthday" runat="server"
                                                        name="student_birthday" class="form-control" type="text"
                                                        data-inputmask-alias="datetime"
                                                        data-inputmask-inputformat="yyyy/mm/dd" data-mask />
                                                </div>
                                            </div>
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                    <label for="Input_Add_Student_Status">用户状态</label>
                                                    <asp:TextBox id="Input_Add_Student_Status" runat="server"
                                                        name="student_status" class="form-control" type="text"
                                                        data-inputmask='"mask": "9[9]"' data-mask />
                                                </div>
                                            </div>
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                    <label for="Input_Add_Class_ID">班级编号</label>
                                                    <asp:TextBox id="Input_Add_Class_ID" runat="server"
                                                        name="class_id" class="form-control" type="text"
                                                        data-inputmask='"mask": "[A|9]{1,8}"' data-mask />
                                                </div>
                                            </div>
                                        </div>
                                        <asp:Button ID="Button_Add" runat="server" Text="添加学生信息"
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
                                                    <label for="Input_Delete_Student_ID">学生编号</label>
                                                    <asp:TextBox id="Input_Delete_Student_ID" runat="server"
                                                        name="student_id" class="form-control" type="text"
                                                        data-inputmask='"mask": "[A|9]{1,8}"' data-mask />
                                                </div>
                                            </div>
                                        </div>
                                        <asp:Button ID="Button_Delete" runat="server" Text="删除学生信息"
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
                                                    <label for="Input_Update_Student_ID">学生编号</label>
                                                    <asp:TextBox id="Input_Update_Student_ID" runat="server"
                                                        name="student_id" class="form-control" type="text"
                                                        data-inputmask='"mask": "[A|9]{1,8}"' data-mask />
                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <!-- select -->
                                                <div class="form-group">
                                                    <label>修改项</label>
                                                    <select id="Input_Update_Item_Select" runat="server"
                                                        class="form-control">
                                                        <option>学生编号</option>
                                                        <option>姓名</option>
                                                        <option>用户密码</option>
                                                        <option>性别</option>
                                                        <option>出生时间</option>
                                                        <option>用户状态</option>
                                                        <option>班级编号</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <div class="form-group">
                                                    <label for="Input_Update_Value">修改为</label>
                                                    <asp:TextBox id="Input_Update_Value" runat="server" name="student_update_value"
                                                        class="form-control" type="text" />
                                                </div>
                                            </div>
                                        </div>
                                        <asp:Button ID="Button_Update" runat="server" Text="修改学生信息"
                                            class="btn btn-primary float-right" OnClick="Button_Update_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <!-- /.tab-content -->
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
                                <h3 class="card-title">学生信息列表</h3>

                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse"><i
                                            class="fas fa-minus"></i></button>
                                    <button type="button" class="btn btn-tool" data-card-widget="remove"><i
                                            class="fas fa-remove"></i></button>
                                </div>
                            </div>
                            <!-- /.card-header -->
                            <div class="card-body">
                                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                            </div>
                            <!-- /.card-body -->
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
                                <h3 class="card-title">班级信息列表</h3>

                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse"><i
                                            class="fas fa-minus"></i></button>
                                    <button type="button" class="btn btn-tool" data-card-widget="remove"><i
                                            class="fas fa-remove"></i></button>
                                </div>
                            </div>
                            <!-- /.card-header -->
                            <div class="card-body">
                                <asp:GridView ID="GridView2" runat="server"></asp:GridView>
                            </div>
                            <!-- /.card-body -->
                        </div>
                        <!-- /.card -->
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- /.col -->

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
            $('[data-mask]').inputmask();
        };
    </script>
</asp:Content>