<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="CreateCustomerDetails.aspx.cs" Inherits="SmartTrucking.CreateCustomerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Main content -->
    <section class="content">
        <!-- START ACCORDION & CAROUSEL-->
        <h2 class="page-header">Add Customer Details</h2>

        <div class="row">
            <div class="col-md-12">

                <div class="box-header with-border">

                    <h4 class="box-title col-md-12">
                        <div class="col-md-11">
                            <a>Basic Details
                            </a>
                        </div>

                    </h4>
                </div>
                <div class="box-body">
                    <div class="row">
                        <div class="col-md-6">

                            <div class="form-group">
                                <div class="col-lg-4">
                                    <label>Company Name:<span class="reqstar">*</span></label>
                                </div>
                                <div class="col-lg-8">
                                    <input id="txtCompanyName" class="form-control" type="text" placeholder="Enter Company Name" />
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group" style="padding-top: 5px;">
                                <div class="col-lg-4">
                                    <label>Country:<span class="reqstar">*</span></label>
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
                                    <label>State:<span class="reqstar">*</span></label>
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
                                    <label>City:<span class="reqstar">*</span></label>
                                </div>
                                <div class="col-lg-8">
                                    <input id="txtCity" class="form-control" type="text" placeholder="Enter The City" />
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group" style="padding-top: 5px;">
                                <div class="col-lg-4">
                                    <label>Address 1:<span class="reqstar">*</span></label>
                                </div>
                                <div class="col-lg-8">
                                    <input id="txtAddress1" class="form-control" type="text" placeholder="Enter  Address..." />
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group" style="padding-top: 5px;">
                                <div class="col-lg-4">
                                    <label>Address 2:</label>
                                </div>
                                <div class="col-lg-8">
                                    <input id="txtAddress2" class="form-control" type="text" placeholder="Enter  Address..." />
                                </div>
                            </div>

                        </div>
                        <!-- /.col -->
                        <div class="col-md-6">
                            <div class="form-group">
                                <div class="col-lg-4">
                                    <label>Account Number:</label>
                                </div>
                                <div class="col-lg-8">
                                    <input id="txtAcNo" class="form-control" type="number" placeholder="Enter Account Number" />
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group" style="padding-top: 5px;">
                                <div class="col-lg-4">
                                    <label>Zip Code:</label>
                                </div>
                                <div class="col-lg-8">
                                    <input id="txtZipCode" class="form-control" type="number" placeholder="Enter The Zip Code or Postal Code" />
                                </div>
                            </div>

                            <div class="clearfix"></div>
                            <div class="form-group" style="padding-top: 5px;">
                                <div class="col-lg-4">
                                    <label>Accounts Payable Email</label>
                                </div>
                                <div class="col-lg-8">
                                    <input id="txtaccntPayableEmail" class="form-control" type="text" placeholder="Enter Email ID" />

                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group" style="padding-top: 5px;">
                                <div class="col-lg-4">
                                </div>
                                <div class="col-lg-8">
                                </div>
                            </div>
                        </div>
                        <!-- /.col -->
                    </div>
                </div>
                <div class="box-header with-border">

                    <h4 class="box-title col-md-12">
                        <div class="col-md-11">
                            <a>Contact Details
                            </a>
                        </div>

                    </h4>
                </div>


                <div class="box-body">
                    <div class="row">

                        <div class="col-md-6">

                            <div class="form-group">
                                <div class="col-lg-4">
                                    <label>Contact Name:</label>
                                </div>
                                <div class="col-lg-8">
                                    <input id="txtContactName" class="form-control" type="text" placeholder="Enter Contact Name" />
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group" style="padding-top: 5px;">
                                <div class="col-lg-4">
                                    <label>Designation:</label>
                                </div>
                                <div class="col-lg-8">
                                    <input id="txtDesignation" class="form-control" type="text" placeholder="Enter Designation" />
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group" style="padding-top: 5px;">
                                <div class="col-lg-4">
                                    <label>Email:</label>
                                </div>
                                <div class="col-lg-8">
                                    <input id="txtContactEmail" class="form-control" type="text" placeholder="Enter Email ID" />
                                </div>
                            </div>
                        </div>

                        <!-- /.col -->
                        <div class="col-md-6">
                            <div class="form-group">
                                <div class="col-lg-4">
                                    <label>Phone Number:</label>
                                </div>
                                <div class="col-lg-8">
                                    <input id="txtContactPhoneNo" class="form-control" type="number" placeholder="Enter Phone Number" />
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group" style="padding-top: 5px;">
                                <div class="col-lg-4">
                                    <label>Fax:</label>
                                </div>
                                <div class="col-lg-8">
                                    <input id="txtContactFax" class="form-control" type="number" placeholder="Enter Fax" />
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group" style="padding-top: 5px;">
                                <div class="col-lg-4">
                                </div>
                                <div class="col-lg-8">
                                    <input id="txtID" class="form-control" type="number" placeholder="Enter Fax" style="display: none;" />
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group" style="padding-top: 5px;">
                                <div class="col-lg-8">
                                </div>
                                <div class="col-lg-4">
                                    <button type="button" id="btnAdd" class="btn btn-block btn-info" onclick="ClearAdd()">Clear</button>
                                </div>
                            </div>
                        </div>
                        <!-- /.col -->
                    </div>
                </div>
                <div class="box-body" id="turckLocationListDiv">
                </div>
                <div class="row" style="margin-bottom: 15px;">
                    <div class="col-lg-12">
                        <hr />
                        <div class="col-lg-3">
                        </div>
                        <%--  <div class="col-lg-3">
                                                <button type="button" id="btnsave5" class="btn btn-block btn-success" onclick="Save5('1')">Save & Close</button>
                                            </div>--%>
                        <div class="col-lg-3">
                            <button type="button" id="btnsave5_Save" class="btn btn-block btn-success" onclick="Save()">Save</button>
                        </div>
                        <div class="col-lg-3">
                            <button type="button" id="btnCancel5_Cancel" class="btn btn-block btn-danger" onclick="Cancel()">Close</button>
                        </div>
                        <div class="col-lg-1">
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
    <!-- /.content -->

    <input type="hidden" id="ID_hidden_Basic" class="form-control" />

    <script src="ClientJS/CreateCustomerDetails.js"></script>
    <script>
        $(function () {
            $(".select2").select2();
        });
    </script>
</asp:Content>
