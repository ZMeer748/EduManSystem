<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher/Teacher.master" AutoEventWireup="true" CodeBehind="CourseScore.aspx.cs" Inherits="EduManSystem.Teacher.CourseScore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHeaderNamePlaceHolder" runat="server">
    课程成绩录入
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
                                <h3 class="card-title">修改栏</h3>
                            </div>
                            <!-- /.card-header -->
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-sm-4">
                                        <label>课程编号</label>
                                        <div class="input-group">
                                            <asp:TextBox id="Input_Course_Schedule_ID" runat="server" name="course_id"
                                                class="form-control" type="text" data-inputmask='"mask": "[A|9]{1,8}"'
                                                data-mask />
                                            <span class="input-group-append">
                                                <asp:Button ID="Button_Course_Search" runat="server" Text="查找课程"
                                                    class="btn btn-outline-secondary btn-flat"
                                                    OnClick="Button_Course_Search_Click" />
                                            </span>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="Input_Student_ID">学生编号</label>
                                            <asp:TextBox id="Input_Student_ID" runat="server" name="course_id"
                                                class="form-control" type="text" data-inputmask='"mask": "[A|9]{1,8}"'
                                                data-mask />
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label for="Input_Course_Select_Score">课程成绩</label>
                                            <asp:TextBox id="Input_Course_Select_Score" runat="server"
                                                name="course_credit" class="form-control" type="text"
                                                data-inputmask='"mask": "9[9][9]"' data-mask />
                                        </div>
                                    </div>
                                </div>
                                <asp:Button ID="Button_Score_Entry" runat="server" Text="成绩录入"
                                    class="btn btn-primary float-right" OnClick="Button_Score_Entry_Click" />
                            </div>
                            <!-- /.card-body -->
                        </div>
                        <!-- /.card -->
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- /.col -->

            <div class="col-sm-12">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="card">
                            <div class="card-header">
                                <h3 class="card-title">当前课程信息</h3>

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
    <script>
        function pageLoad(sender, args) {
            $('#MainContentPlaceHolder_TeacherMainContentPlaceHolder_GridView1').DataTable();

            // data-mask
            $('[data-mask]').inputmask();
        };
    </script>
</asp:Content>