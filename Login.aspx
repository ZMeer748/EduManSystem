<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EduManSystem.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <!-- <link href="https://cdn.bootcss.com/twitter-bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet"> -->
    <!-- <link href="https://cdn.bootcss.com/font-awesome/5.11.2/css/fontawesome.min.css" rel="stylesheet"> -->
    <link href="https://cdn.bootcss.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">
    <link href="https://cdn.bootcss.com/material-design-iconic-font/2.2.0/css/material-design-iconic-font.min.css"
        rel="stylesheet">
    <link href="https://cdn.bootcss.com/animate.css/3.7.2/animate.min.css" rel="stylesheet">
    <link href="https://cdn.bootcss.com/hamburgers/1.1.3/hamburgers.min.css" rel="stylesheet">
    <link href="https://cdn.bootcss.com/animsition/4.0.2/css/animsition.min.css" rel="stylesheet">
    <link href="https://cdn.bootcss.com/select2/4.0.10/css/select2.min.css" rel="stylesheet">
    <link href="https://cdn.bootcss.com/bootstrap-daterangepicker/3.0.5/daterangepicker.min.css" rel="stylesheet">
    <link href='<%=ResolveClientUrl("~/Styles/util.css") %>' rel="stylesheet">
    <link href='<%=ResolveClientUrl("~/Styles/main.css") %>' rel="stylesheet">
    <style>
        .callout span {
            font-weight: bold;
            color: #b721ff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="IndexMainContentPlaceHolder" runat="server">
    <div class="container-login100">
        <div class="wrap-login100">
            <form id="form1" class="login100-form validate-form" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <div class="limiter">
                    <span class="login100-form-title p-b-26">
                        账号登录
                    </span>

                    <div class="wrap-input100 validate-input" data-validate="请输入用户 ID">
                        <asp:TextBox id="Input_ID" name="user_id" class="input100" type="text" runat="server" />
                        <span class="focus-input100" data-placeholder="用户 ID"></span>
                    </div>

                    <div class="wrap-input100 validate-input" data-validate="请输入密码">
                        <span class="btn-show-pass">
                            <i class="zmdi zmdi-eye"></i>
                        </span>
                        <asp:TextBox id="Input_UserPassword" class="input100" type="password" name="user_password"
                            runat="server" />
                        <span class="focus-input100" data-placeholder="密码"></span>
                    </div>

                    <div id="account_sort_callout" class="callout callout-info mt-3 d-flex justify-content-start"
                        style="border-left-color: #21d4fd;">
                        以 <span id="account_sort_label" runat="server" class="w-25 text-center">学生</span> 的身份登录
                        <input id="account_sort_label_value" runat="server" type="hidden" value="学生" />
                    </div>

                    <div class="btn-group btn-group-toggle btn-block" data-toggle="buttons" id="count_sort_select">
                        <label class="btn btn-light active">
                            <input type="radio" name="options" id="option1" value="学生" checked>学生
                        </label>
                        <label class="btn btn-light">
                            <input type="radio" name="options" id="option2" value="教师">教师
                        </label>
                        <label class="btn btn-light">
                            <input type="radio" name="options" id="option3" value="管理员">管理员
                        </label>
                    </div>

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="container-login100-form-btn">
                                <div class="wrap-login100-form-btn">
                                    <div class="login100-form-bgbtn"></div>
                                    <button id="Button_Login" runat="server" class="login100-form-btn"
                                        onServerClick="Button_Login_Click">登录</button>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="text-center p-t-20">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Label class="txt1 d-none" ID="Label1" runat="server" Text=" "
                                    style="color: #c80000;">
                                </asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <span class="txt1">
                            还没有账号？
                        </span>
                        <asp:HyperLink class="txt2" ID="HyperLink1" runat="server" NavigateUrl="~/Register.aspx">点击注册
                        </asp:HyperLink>
                    </div>
                </div>
                <div id="dropDownSelect1"></div>
            </form>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <!-- <script src="https://cdn.bootcss.com/jquery/3.4.1/jquery.min.js"></script> -->
    <script src="https://cdn.bootcss.com/animsition/4.0.2/js/animsition.min.js"></script>
    <script src="https://cdn.bootcss.com/popper.js/1.15.0/esm/popper.min.js"></script>
    <!-- <script src="https://cdn.bootcss.com/twitter-bootstrap/4.3.1/js/bootstrap.min.js"></script> -->
    <script src="https://cdn.bootcss.com/select2/4.0.10/js/select2.min.js"></script>
    <script src="https://cdn.bootcss.com/bootstrap-daterangepicker/3.0.5/moment.min.js"></script>
    <script src="https://cdn.bootcss.com/bootstrap-daterangepicker/3.0.5/daterangepicker.min.js"></script>
    <script src='<%=ResolveClientUrl("~/Scripts/countdowntime.js") %>'></script>
    <script src='<%=ResolveClientUrl("~/Scripts/main.js") %>'></script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ScriptFunctionPlaceHolder" runat="server">
    <script>
        $(function () {
            $("#MainContentPlaceHolder_IndexMainContentPlaceHolder_Input_ID").val("");
            $("#count_sort_select label").on("click", function () {
                $('#MainContentPlaceHolder_IndexMainContentPlaceHolder_account_sort_label').html($(this)
                    .children('input').val());
                $('#MainContentPlaceHolder_IndexMainContentPlaceHolder_account_sort_label_value').val($(
                        this).children('input')
                    .val());
            });
            $("#MainContentPlaceHolder_IndexMainContentPlaceHolder_Input_UserPassword").val("");
            // $("#MainContentPlaceHolder_Input_UserPassword").attr("type", "password");
        });
    </script>
</asp:Content>