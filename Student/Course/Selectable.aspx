<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.master" AutoEventWireup="true" CodeBehind="Selectable.aspx.cs" Inherits="EduManSystem.Student.Course.Selectable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
  <link rel="stylesheet"
    href='<%=ResolveClientUrl("~/AdminLTE/plugins/datatables-bs4/css/dataTables.bootstrap4.css") %>'>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHeaderNamePlaceHolder" runat="server">
  可选课程
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentHeaderBreadCrumbPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="StudentMainContentPlaceHolder" runat="server">
  <form id="form1" runat="server">
    <div class="row">
      <div class="col-12">
        <div class="card">
          <div class="card-header">
            <h3 class="card-title">可选课程列表</h3>
          </div>
          <!-- /.card-header -->
          <div class="card-body">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
              <Columns>
                <asp:BoundField DataField="课程编号" HeaderText="课程编号" SortExpression="课程编号"></asp:BoundField>
                <asp:BoundField DataField="课程名称" HeaderText="课程名称" SortExpression="课程名称"></asp:BoundField>
                <asp:BoundField DataField="课程学分" HeaderText="课程学分" SortExpression="课程学分"></asp:BoundField>
                <asp:BoundField DataField="开课院系" HeaderText="开课院系" SortExpression="开课院系"></asp:BoundField>
                <asp:BoundField DataField="任课教师" HeaderText="任课教师" SortExpression="任课教师"></asp:BoundField>
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
      </div>
      <!-- /.col -->
    </div>
    <!-- /.row -->
  </form>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
  <script src='<%=ResolveClientUrl("~/AdminLTE/plugins/datatables/jquery.dataTables.js") %>'></script>
  <script src='<%=ResolveClientUrl("~/AdminLTE/plugins/datatables-bs4/js/dataTables.bootstrap4.js") %>'></script>
  <script>
    $(function () {
      $('#MainContentPlaceHolder_StudentMainContentPlaceHolder_GridView1').DataTable();
    });
  </script>
</asp:Content>