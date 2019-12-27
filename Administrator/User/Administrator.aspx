<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Administrator.master" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="EduManSystem.Administrator.User.Administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHeaderNamePlaceHolder" runat="server">
    管理员信息管理
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
                                                    <label for="Input_Add_Administrator_ID">管理员编号</label>
                                                    <asp:TextBox id="Input_Add_Administrator_ID" runat="server"
                                                        name="administrator_id" class="form-control" type="text"
                                                        data-inputmask='"mask": "[A|9]{1,8}"' data-mask />
                                                </div>
                                            </div>
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                    <label for="Input_Add_Administrator_Name">姓名</label>
                                                    <asp:TextBox id="Input_Add_Administrator_Name" runat="server"
                                                        name="administrator_name" class="form-control" type="text" />
                                                </div>
                                            </div>
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                    <label for="Input_Add_Administrator_Password">用户密码</label>
                                                    <asp:TextBox id="Input_Add_Administrator_Password" runat="server"
                                                        name="administrator_password" class="form-control" type="text"
                                                        data-inputmask='"mask": "[A|9]{1,16}"' data-mask />
                                                </div>
                                            </div>
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                    <label for="Input_Add_Administrator_Gender">性别</label>
                                                    <asp:TextBox id="Input_Add_Administrator_Gender" runat="server"
                                                        name="administrator_gender" class="form-control" type="text"
                                                        data-inputmask='"mask": "[女|男]"' data-mask />
                                                </div>
                                            </div>
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                    <label for="Input_Add_Administrator_Birthday">出生时间</label>
                                                    <asp:TextBox id="Input_Add_Administrator_Birthday" runat="server"
                                                        name="administrator_birthday" class="form-control" type="text"
                                                        data-inputmask-alias="datetime"
                                                        data-inputmask-inputformat="yyyy/mm/dd" data-mask />
                                                </div>
                                            </div>
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                    <label for="Input_Add_Administrator_Status">用户状态</label>
                                                    <asp:TextBox id="Input_Add_Administrator_Status" runat="server"
                                                        name="administrator_status" class="form-control" type="text"
                                                        data-inputmask='"mask": "9[9]"' data-mask />
                                                </div>
                                            </div>
                                        </div>
                                        <asp:Button ID="Button_Add" runat="server" Text="添加管理员信息"
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
                                                    <label for="Input_Delete_Administrator_ID">管理员编号</label>
                                                    <asp:TextBox id="Input_Delete_Administrator_ID" runat="server"
                                                        name="administrator_id" class="form-control" type="text"
                                                        data-inputmask='"mask": "[A|9]{1,8}"' data-mask />
                                                </div>
                                            </div>
                                        </div>
                                        <asp:Button ID="Button_Delete" runat="server" Text="删除管理员信息"
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
                                                    <label for="Input_Update_Administrator_ID">管理员编号</label>
                                                    <asp:TextBox id="Input_Update_Administrator_ID" runat="server"
                                                        name="administrator_id" class="form-control" type="text"
                                                        data-inputmask='"mask": "[A|9]{1,8}"' data-mask />
                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <!-- select -->
                                                <div class="form-group">
                                                    <label>修改项</label>
                                                    <select id="Input_Update_Item_Select" runat="server"
                                                        class="form-control">
                                                        <option>管理员编号</option>
                                                        <option>姓名</option>
                                                        <option>用户密码</option>
                                                        <option>性别</option>
                                                        <option>出生时间</option>
                                                        <option>用户状态</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <div class="form-group">
                                                    <label for="Input_Update_Value">修改为</label>
                                                    <asp:TextBox id="Input_Update_Value" runat="server" name="administrator_update_value"
                                                        class="form-control" type="text" />
                                                </div>
                                            </div>
                                        </div>
                                        <asp:Button ID="Button_Update" runat="server" Text="修改管理员信息"
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
                                <h3 class="card-title">管理员信息列表</h3>

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

        </div>
        <!-- /.row -->
    </form>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ScriptFunctionPlaceHolder" runat="server">
</asp:Content>
