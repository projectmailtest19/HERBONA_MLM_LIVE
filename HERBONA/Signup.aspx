<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="SmartTrucking.Signup" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>User Login / Signup</title>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />

    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="ClientJS/Signup.js"></script>

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
                <%-- <div class="login-logo">
                    <a href="#"><b>USER</b>LOGIN</a>
                </div>--%>
                <!-- /.login-logo -->
                <div class="login-box-body">
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">

                            <li class="active"><a href="#Login" data-toggle="tab">Login</a></li>
                            <li id="liSponsor" class="disabledLI"><a href="#GetStarted" data-toggle="tab">Get Started</a></li>
                        </ul>
                        <div class="tab-content">
                            <div class="active tab-pane" id="Login">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <input id="txtAccountNumber" class="form-control" type="number" placeholder="Account Number" />
                                    </div>
                                    <div class="form-group">
                                        <input id="txtPassword" class="form-control" type="password" placeholder="Password" />
                                    </div>
                                </div>
                                <div class="row">
                                    <button type="button" class="btn btn-primary btn-flat btn-block" id="BtnLoginSubmit" onclick="LoginSubmit();">Submit</button>
                                </div>
                                <div class="row" style="margin-top: 10px; text-align: center;">
                                    <a href="Forget_Password.aspx">Forgot Password</a>
                                </div>
                            </div>
                            <div class="tab-pane" id="GetStarted">
                                <div class="form-horizontal">
                                    <div id="1Div">
                                        <div id="DivSponsorAccountNumber" class="form-group">
                                            <input id="txtSponsorAccountNumber" class="form-control" type="number" placeholder="Sponsor Account Number*" />
                                        </div>
                                        <div class="row">
                                            <button type="button" class="btn btn-primary btn-flat btn-block" id="Btn" onclick="NextSubmit1();">Next</button>
                                        </div>
                                    </div>
                                    <div id="2Div" style="display: none">
                                        <div id="DivSponsrName" class="form-group text-center text-primary">
                                            <h4 id="hSponsrName">Sponsor Name: Maniram sharma</h4>
                                        </div>
                                        <div>
                                            <div class="form-group">
                                                <input id="txtPhoneNumber" class="form-control" type="number" placeholder="Phone Number*" />
                                            </div>

                                            <div class="form-group">
                                                <input id="txtFullName" class="form-control" type="text" placeholder="Full Name*" />
                                            </div>
                                            <div class="form-group">
                                                <input id="txtEmailID" class="form-control" type="text" placeholder="Email ID" />
                                            </div>
                                            <div class="form-group">
                                                <div class="input-group date">
                                                    <div class="input-group-addon">
                                                        <i class="fa fa-calendar"></i>
                                                    </div>
                                                    <input id="txtDOB" class="form-control pull-right datepicker" type="text" placeholder="DOB(MM/DD/YYYY)*" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <select class="form-control select2" id="SelCountry" style="width: 100%;" data-placeholder="Select Country*">
                                                    <option value="1" selected="selected">India</option>
                                                    <option value="2">Bangladesh</option>
                                                    <option value="3">Bhutan</option>
                                                    <option value="4">Nepal</option>
                                                </select>
                                            </div>
                                            <div class="form-group">
                                                <select class="form-control select2" id="SelState" style="width: 100%;" data-placeholder="Select State*">
                                                    <option value="" selected="selected">Select State</option>
                                                    <option value="1" class="ng-binding ng-scope">ANDAMAN AND NICOBAR ISLANDS
                                                    </option>
                                                    <option value="2" class="ng-binding ng-scope">ANDHRA PRADESH
                                                    </option>
                                                    <option value="3" class="ng-binding ng-scope">ARUNACHAL PRADESH
                                                    </option>
                                                    <option value="4" class="ng-binding ng-scope">ASSAM
                                                    </option>
                                                    <option value="5" class="ng-binding ng-scope">BIHAR
                                                    </option>

                                                </select>
                                            </div>
                                            <div class="form-group">
                                                <select class="form-control select2" id="SelDistrict" style="width: 100%;" data-placeholder="Select District*">
                                                    <option value="" selected="selected">Select District</option>
                                                    <option value="Kolkata" class="ng-binding ng-scope">Kolkata</option>
                                                    <option value="North 24 Parganas" class="ng-binding ng-scope">North 24 Parganas</option>
                                                    <option value="South 24 Parganas" class="ng-binding ng-scope">South 24 Parganas</option>
                                                    <option value="Birbhum" class="ng-binding ng-scope">Birbhum</option>
                                                </select>
                                            </div>

                                            <div class="form-group">
                                                <input id="txtPINCode" class="form-control" type="text" placeholder="PIN Code*" />
                                            </div>
                                            <div class="form-group">
                                                <select class="form-control select2" id="position" style="width: 100%;" data-placeholder="Select Team*">
                                                    <option value="" selected="selected">Select Team</option>
                                                    <option value="Left">Team-A</option>
                                                    <option value="Right">Team-B</option>
                                                </select>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <button type="button" class="btn btn-primary btn-flat btn-block" id="Btn2Next" onclick="NextSubmit2();">Next</button>
                                                </div>
                                                <div class="col-lg-6">
                                                    <button type="button" class="btn btn-primary btn-flat btn-block" id="BtnBack" onclick="Back();">Back</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!-- /.login-box -->
    <script src="../../plugins/jQuery/jquery-2.2.3.min.js"></script>
    <script src="../../bootstrap/js/bootstrap.min.js"></script>
    <script src="../../plugins/iCheck/icheck.min.js"></script>
    <script src="dist/js/sweetalert-dev.js"></script>
    <script src="dist/js/sweetalert.min.js"></script>
    <script src="ClientJS/jquery.pleaseWait.js"></script>

    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css" />
    <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css" />
    <link rel="stylesheet" href="plugins/iCheck/flat/blue.css" />
    <link rel="stylesheet" href="plugins/morris/morris.css" />
    <link rel="stylesheet" href="plugins/jvectormap/jquery-jvectormap-1.2.2.css" />
    <link rel="stylesheet" href="plugins/datepicker/datepicker3.css" />
    <link rel="stylesheet" href="plugins/daterangepicker/daterangepicker.css" />
    <link rel="stylesheet" href="plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css" />
    <link rel="stylesheet" href="plugins/datatables/dataTables.bootstrap.css" />
    <link rel="stylesheet" href="plugins/timepicker/bootstrap-timepicker.min.css" />
    <link rel="stylesheet" href="plugins/select2/select2.min.css" />
    <link href="dist/css/sweetalert.css" rel="stylesheet" />
    <link href="ClientCss/Custom.css" rel="stylesheet" />
    <link href="plugins/iCheck/flat/_all.css" rel="stylesheet" />


    <script src="plugins/jQuery/jquery-2.2.3.min.js"></script>
    <script src="https://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>
    <script>
        $.widget.bridge('uibutton', $.ui.button);
    </script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
    <script src="plugins/sparkline/jquery.sparkline.min.js"></script>
    <script src="plugins/jvectormap/jquery-jvectormap-1.2.2.min.js"></script>
    <script src="plugins/jvectormap/jquery-jvectormap-world-mill-en.js"></script>
    <script src="plugins/knob/jquery.knob.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.11.2/moment.min.js"></script>
    <script src="plugins/daterangepicker/daterangepicker.js"></script>
    <script src="plugins/datepicker/bootstrap-datepicker.js"></script>
    <script src="plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"></script>
    <script src="plugins/slimScroll/jquery.slimscroll.min.js"></script>
    <script src="plugins/fastclick/fastclick.js"></script>
    <script src="plugins/select2/select2.full.min.js"></script>
    <script src="plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="dist/js/sweetalert-dev.js"></script>
    <script src="dist/js/sweetalert.min.js"></script>
    <script src="plugins/input-mask/jquery.inputmask.js"></script>
    <script src="plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
    <script src="plugins/input-mask/jquery.inputmask.extensions.js"></script>
    <script src="plugins/timepicker/bootstrap-timepicker.min.js"></script>
    <script src="dist/js/app.min.js"></script>
    <script src="dist/js/demo.js"></script>
    <script src="ClientJS/kmi-isvalid-1.0.0.js"></script>
    <script src="ClientJS/jquery.pleaseWait.js"></script>
    <script src="plugins/iCheck/icheck.min.js"></script>

</body>
</html>
