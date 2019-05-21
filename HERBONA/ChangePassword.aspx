<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="SmartTrucking.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--<link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />

    <!-- iCheck for checkboxes and radio inputs -->
    <link rel="stylesheet" href="plugins/iCheck/all.css" />
    <!-- Bootstrap time Picker -->
    <link rel="stylesheet" href="plugins/timepicker/bootstrap-timepicker.min.css" />
    <link rel="stylesheet" href="plugins/select2/select2.min.css" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">CHANGE PASSWORD</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="col-lg-4">
                                        <label>Old Password</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtoldPsswd" class="form-control" type="password" placeholder="......." />
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>New Password</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtnewPsswd" class="form-control" type="password" placeholder="......." />
                                        <div class="clearfix"></div>

                                    </div>

                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Confirm Password</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtconfPsswd" class="form-control" type="password" placeholder="......." />
                                    </div>
                                </div>
                          
                                <div class="col-lg-12 removespace">
                                    <div class="col-lg-6 removespace" style="padding-right: 20px">
                                        <div class="col-lg-9 removespace">
                                            <img id="selectimg" width="100" height="100" style="display: none;" />
                                        </div>
                                    </div>
                                </div>


                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->

                        <div class="row" style="margin-bottom: 15px; margin-right: 370px">
                            <div class="col-lg-12">
                                <hr />
                                <div class="col-lg-3"></div>
                                <div class="col-lg-3" style="text-align: left">
                                    <button type="button" id="btnsave" class="btn btn-block btn-success" onclick="Change_Password()">Change</button>
                                </div>
                                <div class="col-lg-3" style="text-align: center">
                                    <button type="button" id="btnCancel" class="btn btn-block btn-danger" onclick="redirect()">Cancel</button>
                                </div>
                                <div class="col-lg-3"></div>
                            </div>
                        </div>
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
        </div>
    </section>


    <input type="hidden" id="ID_hidden" class="form-control" />

   <%-- <script src="plugins/jQuery/jquery-2.2.3.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="plugins/select2/select2.full.min.js"></script>

    <!-- InputMask -->
    <script src="plugins/input-mask/jquery.inputmask.js"></script>
    <script src="plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
    <script src="plugins/input-mask/jquery.inputmask.extensions.js"></script>

    <!-- bootstrap time picker -->
    <script src="plugins/timepicker/bootstrap-timepicker.min.js"></script>
    <script src="dist/js/app.min.js"></script>--%>

<script src="ClientJS/Changepassword.js"></script>
    <script>

        $(document).ready(function () {
            $(".select2").select2();
        });
    </script>



</asp:Content>
