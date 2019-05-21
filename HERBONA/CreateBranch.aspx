<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="CreateBranch.aspx.cs" Inherits="SmartTrucking.CreateBranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--   <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />

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
                        <h3 class="box-title">Create Branch</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">

                                <div class="form-group">
                                    <div class="col-lg-4">
                                        <label>Company Name<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <select class="form-control select2" id="cmbCompany" style="width: 100%;" data-placeholder="Select Company">
                                              <option></option>
                                        </select>                                          
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Name</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtHOD" class="form-control" type="text" placeholder="Name" />

                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Cell No.</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtMobileNo" class="form-control" type="number" placeholder="Mobile No." />

                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Phone No.</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtPhoneNo" class="form-control" type="number" placeholder="Phone No." />

                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Email<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtEmail" class="form-control" type="email" placeholder="Email" />

                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Password<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtPassword" class="form-control" type="password" placeholder="Password" />

                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Browse Logo</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input type="file" id="f_Uploadfile" />
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
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="col-lg-4">
                                        <label>Location Name<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtCBranchName" class="form-control" type="text" placeholder="Branch Name" />
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Country</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <select class="form-control select2" id="cmbCountry" style="width: 100%;" data-placeholder="Select Country">
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>State</label>
                                    </div>
                                    <div class="col-lg-8">
                                         <select id="cmbState" class="form-control select2" style="width: 100%;" data-placeholder="Select State">
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>City</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtCity" class="form-control" type="text" placeholder="City" />

                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Address</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <textarea id="txtAddress" class="form-control" rows="3" placeholder="Enter  Address..."></textarea>
                                    </div>
                                </div>

                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->


                        <div class="row" style="margin-bottom: 15px;">
                            <div class="col-lg-12">
                                <hr />
                                <div class="col-lg-3"></div>
                                <div class="col-lg-3" style="text-align: left">
                                    <button type="button" id="btnsave" class="btn btn-block btn-success" onclick="AddNewCompany()">Save</button>
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
    <input type="hidden" id="LogoPath" />
    <input type="hidden" id="OldLogoPath" />
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
    <script src="ClientJS/CreateBranch.js"></script>

    <script>
        $(document).ready(function () {
            $(".select2").select2();
        });
    </script>



</asp:Content>
