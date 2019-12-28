<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.master" AutoEventWireup="true" CodeBehind="CourseSelect.aspx.cs" Inherits="EduManSystem.Student.CourseSelect" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHeaderNamePlaceHolder" runat="server">
    学生选课
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentHeaderBreadCrumbPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="StudentMainContentPlaceHolder" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="row">
            <div class="col-sm-12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="card">
                            <div class="card-header">
                                <h3 class="card-title">可选课程</h3>

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
                                    OnRowCommand="GridView1_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="课程编号" HeaderText="课程编号" SortExpression="课程编号">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="课程名称" HeaderText="课程名称" SortExpression="课程名称">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="课程类型" HeaderText="课程类型" SortExpression="课程类型">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="课程学分" HeaderText="课程学分" SortExpression="课程学分">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="容量" HeaderText="容量" SortExpression="容量">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="余量" HeaderText="余量" ReadOnly="True"
                                            SortExpression="余量"></asp:BoundField>
                                        <asp:ButtonField ButtonType="Button" Text="选修" HeaderText="操作"
                                            CommandName="Select" ControlStyle-CssClass="btn btn-xs btn-outline-success">
                                        </asp:ButtonField>
                                    </Columns>
                                </asp:GridView>
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
                                <h3 class="card-title">已选课程</h3>

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
                                    OnRowCommand="GridView2_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="课程编号" HeaderText="课程编号" SortExpression="课程编号">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="课程名称" HeaderText="课程名称" SortExpression="课程名称">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="课程类型" HeaderText="课程类型" SortExpression="课程类型">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="课程学分" HeaderText="课程学分" SortExpression="课程学分">
                                        </asp:BoundField>
                                        <asp:ButtonField ButtonType="Button" Text="退选" HeaderText="操作"
                                            CommandName="DeSelect"
                                            ControlStyle-CssClass="btn btn-xs btn-outline-warning">
                                        </asp:ButtonField>
                                    </Columns>
                                </asp:GridView>
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
            $('#MainContentPlaceHolder_StudentMainContentPlaceHolder_GridView1').DataTable();
            $('#MainContentPlaceHolder_StudentMainContentPlaceHolder_GridView2').DataTable();
        };
    </script>
</asp:Content>