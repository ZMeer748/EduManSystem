<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher/Teacher.master" AutoEventWireup="true" CodeBehind="CourseApplication.aspx.cs" Inherits="EduManSystem.Teacher.CourseApplication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHeaderNamePlaceHolder" runat="server">
    开课申请
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentHeaderBreadCrumbPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="TeacherMainContentPlaceHolder" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="row">
            <div class="col-sm-12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="card">
                            <div class="card-header">
                                <h3 class="card-title">课程申请信息</h3>
                            </div>
                            <!-- /.card-header -->
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="Input_Course_ID">课程编号</label>
                                            <asp:TextBox id="Input_Course_ID" runat="server" name="course_id"
                                                class="form-control" type="text" data-inputmask='"mask": "[A|9]{1,8}"'
                                                data-mask />
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="Input_Course_Name">课程名称</label>
                                            <asp:TextBox id="Input_Course_Name" runat="server" name="course_id"
                                                class="form-control" type="text" />
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="Input_Course_Credit">课程学分</label>
                                            <asp:TextBox id="Input_Course_Credit" runat="server" name="course_credit"
                                                class="form-control" type="text" data-inputmask='"mask": "9[9]"'
                                                data-mask />
                                        </div>
                                    </div>
                                </div>
                                <asp:Button ID="Button_Score_Entry" runat="server" Text="申请开课"
                                    class="btn btn-primary float-right" OnClick="Button_Course_Application_Click" />
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
            // data-mask
            $('[data-mask]').inputmask();
        };
    </script>
</asp:Content>