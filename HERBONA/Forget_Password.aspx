<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forget_Password.aspx.cs" Inherits="SmartTrucking.Forget_Password" %>
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
                    <a href="#"><b>PASSWORD</b>RESET</a>
                </div>
                <!-- /.login-logo -->
                <div class="login-box-body">
                    <p class="login-box-msg">Enter Email Id to Reset Password</p>
                    <div class="form-group has-feedback">
                        <input type="email" class="form-control" placeholder="Email" id="txtemail_forlogin" />
                        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                    </div>
                  
                    <div class="row">
                        <div class="col-xs-8">                            
                        </div>
                        <!-- /.col -->
                        <div class="col-xs-4">
                            <button type="button" class="btn btn-primary btn-block btn-flat" id="Btn_Reset" onclick="Reset_Password()">Continue</button>
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.social-auth-links -->
                     <a href="Signup.aspx">BACK</a>
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

    <script src="ClientJS/Forget_Password.js"></script>
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
