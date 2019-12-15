<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EduManSystem.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.bootcss.com/twitter-bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet">
    <!-- <link href="https://cdn.bootcss.com/font-awesome/5.11.2/css/fontawesome.min.css" rel="stylesheet"> -->
    <link href="https://cdn.bootcss.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">
    <link href="https://cdn.bootcss.com/material-design-iconic-font/2.2.0/css/material-design-iconic-font.min.css"
        rel="stylesheet">
    <link href="https://cdn.bootcss.com/animate.css/3.7.2/animate.min.css" rel="stylesheet">
    <link href="https://cdn.bootcss.com/hamburgers/1.1.3/hamburgers.min.css" rel="stylesheet">
    <link href="https://cdn.bootcss.com/animsition/4.0.2/css/animsition.min.css" rel="stylesheet">
    <link href="https://cdn.bootcss.com/select2/4.0.10/css/select2.min.css" rel="stylesheet">
    <link href="https://cdn.bootcss.com/bootstrap-daterangepicker/3.0.5/daterangepicker.min.css" rel="stylesheet">
    <link rel="stylesheet" href="css/util.css">
    <link rel="stylesheet" href="css/main.css">
    <link rel="stylesheet" href="css/StyleSheet.min.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SideBarUserIconPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SideBarUserNamePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="NavItemPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">


    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <form id="form1" class="login100-form validate-form" runat="server">
                    <span class="login100-form-title p-b-26">
                        Welcome
                    </span>

                    <div class="wrap-input100 validate-input" data-validate="请输入用户名">
                        <asp:TextBox id="Input_UserName" name="user_name" class="input100" type="text" runat="server" />
                        <span class="focus-input100" data-placeholder="用户名"></span>
                    </div>

                    <div class="wrap-input100 validate-input" data-validate="请输入密码">
                        <span class="btn-show-pass">
                            <i class="zmdi zmdi-eye"></i>
                        </span>
                        <asp:TextBox id="Input_UserPassword" class="input100" type="password" name="user_password"
                            runat="server" />
                        <span class="focus-input100" data-placeholder="密码"></span>
                    </div>


                    <div class="switch">
                        <!-- <i class="fas fa-user-cog img-circle elevation-2 text-white" alt="管理员"></i> -->
                        <!-- <i class="fas fa-user-graduate img-circle elevation-2 text-white" alt="学生"></i> -->
                        <!-- <i class="fas fa-chalkboard-teacher img-circle elevation-2 text-white" alt="教师"></i> -->
                        <input name="switch" id="one" type="radio" checked />
                        <label for="one" class="switch__label">
                            <i class="fas fa-user-graduate img-circle elevation-2" alt="学生"></i>
                        </label>
                        <input name="switch" id="two" type="radio" />
                        <label for="two" class="switch__label">
                            <i class="fas fa-chalkboard-teacher img-circle elevation-2" alt="教师"></i>
                        </label>
                        <input name="switch" id="three" type="radio" />
                        <label for="three" class="switch__label">
                            <i class="fas fa-user-cog img-circle elevation-2" alt="管理员"></i>
                        </label>
                        <div class="switch__indicator"></div>
                    </div>

                    <div class="container-login100-form-btn">
                        <div class="wrap-login100-form-btn">
                            <div class="login100-form-bgbtn"></div>
                            <button id="Button_Register" runat="server" onserverClick="Button_Login_ServerClick"
                                class="login100-form-btn">登录</button>
                        </div>
                    </div>

                    <div class="text-center p-t-115">
                        <asp:Label class="txt1" ID="Label1" runat="server" Text="" style="color: #c80000;"></asp:Label>
                        <br />
                        <span class="txt1">
                            还没有账号？
                        </span>
                        <asp:HyperLink class="txt2" ID="HyperLink1" runat="server" NavigateUrl="~/Register.aspx">点击注册
                        </asp:HyperLink>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <div id="dropDownSelect1"></div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script src="https://cdn.bootcss.com/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdn.bootcss.com/animsition/4.0.2/js/animsition.min.js"></script>
    <script src="https://cdn.bootcss.com/popper.js/1.15.0/esm/popper.min.js"></script>
    <script src="https://cdn.bootcss.com/twitter-bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src="https://cdn.bootcss.com/select2/4.0.10/js/select2.min.js"></script>
    <script src="https://cdn.bootcss.com/bootstrap-daterangepicker/3.0.5/moment.min.js"></script>
    <script src="https://cdn.bootcss.com/bootstrap-daterangepicker/3.0.5/daterangepicker.min.js"></script>
    <script src="js/countdowntime.js"></script>
    <script src="js/main.js"></script>
</asp:Content>