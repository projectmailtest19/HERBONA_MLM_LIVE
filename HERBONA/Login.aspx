<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SmartTrucking.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>User Log in</title>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <link rel="stylesheet" href="../../bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
    <link rel="stylesheet" href="../../dist/css/AdminLTE.min.css" />
    <link rel="stylesheet" href="../../plugins/iCheck/square/blue.css" />
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
    <script src="dist/js/sweetalert-dev.js"></script>
    <script src="dist/js/sweetalert.min.js"></script>
    <script type="text/javascript" language="javascript">

        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }


    </script>

</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
        <div>
            <div class="login-box">
                <div class="login-logo">
                    <a href="#"><b>USER</b>LOGIN</a>
                </div>
                <!-- /.login-logo -->
                <div class="login-box-body">
                    <p class="login-box-msg">Sign in to start your session</p>
                    <div class="form-group has-feedback">
                        <input type="email" class="form-control" placeholder="Email" id="txtemail_forlogin" value="projectmailtest19@gmail.com" />
                        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">
                        <input type="password" class="form-control" placeholder="Password" id="txtpassword_forlogin" value="123" />
                        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                    </div>
                    <div class="row">
                        <div class="col-xs-8">
                            <%--<div class="checkbox icheck">
                                <label>
                                    <input type="checkbox" />
                                    Remember Me
                                </label>
                            </div>--%>
                        </div>
                        <!-- /.col -->
                        <div class="col-xs-4">
                            <button type="button" class="btn btn-primary btn-block btn-flat" id="BtnLogin" onclick="Userlogin()">Sign In</button>
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.social-auth-links -->
                    <a href="Forget_Password.aspx">I forgot my password</a>
                </div>
                <!-- /.login-box-body -->
            </div>
        </div>
    </form>
    <!-- /.login-box -->
    <script src="../../plugins/jQuery/jquery-2.2.3.min.js"></script>
    <script src="../../bootstrap/js/bootstrap.min.js"></script>
    <script src="../../plugins/iCheck/icheck.min.js"></script>
    <script src="dist/js/sweetalert-dev.js"></script>
    <script src="dist/js/sweetalert.min.js"></script>
    <script src="ClientJS/Login.js"></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });
    </script>
</body>
</html>
