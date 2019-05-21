<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="CreateAddress.aspx.cs" Inherits="SmartTrucking.CreateAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />  --%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Add an Address</h3>
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
                                        <input id="txtCompanyName" class="form-control" type="text" placeholder="Company Name" />
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Customer Type</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <select class="form-control select2" id="cmbCustomer" style="width: 100%;" data-placeholder="Select Customer Type">
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                                   <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Street</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtStreet" class="form-control" type="text" placeholder="Street" />
                                    </div>
                                </div>
                                  <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Apt/Suite/Other</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtApt_Suite_Other" class="form-control" type="text" placeholder="Apt/Suite/Other" />
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
                                        <label>State/Province</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <select id="cmbState" class="form-control select2" style="width: 100%;" data-placeholder="Select State/Province">
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                                 <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Zip Code</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtZip_Code" class="form-control" type="text" placeholder="Zip Code" />

                                    </div>
                                </div>
                               <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Cell No.</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtCellNo" class="form-control" type="number" placeholder="Cell No." />

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
                               
                              
                            </div>
                            <!-- /.col -->
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="col-lg-4">
                                        <label>Fax</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtFax" class="form-control" type="text" placeholder="Fax" />
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
                                        <label>Website</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtWebsite" class="form-control" type="text" placeholder="Website URL..." />

                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Contact</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtContact" class="form-control" type="text" placeholder="Contact" />

                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Notes</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <textarea id="txtNotes" class="form-control" rows="4" placeholder="Enter  Notes..."></textarea>
                                    </div>
                                </div>
                                 <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Motor Carrier Number</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtMotor_Carrier_Number" class="form-control" type="text" placeholder="Motor Carrier Number" />

                                    </div>
                                </div>

                                  <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Tax ID (EIN#)</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtTax_ID" class="form-control" type="text" placeholder="Tax ID (EIN#)" />

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
                                    <button type="button" id="btnsave" class="btn btn-block btn-success" onclick="AddNewAddress()">Save</button>
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
    <script src="ClientJS/CreateAddress.js"></script>
     <script>
         $(function () {            
             $(".select2").select2();          
        });
    </script>
</asp:Content>