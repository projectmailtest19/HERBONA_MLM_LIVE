<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="ShippingDetails.aspx.cs" Inherits="SmartTrucking.ShippingDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Modal -->

    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Shipping Details</h3>
                        <div style="float: right;">
                            <div class="form-group">
                                <div class="col-lg-8">
                                    <label>Purchase Wallet: </label>
                                </div>
                                <div class="col-lg-8">
                                    <label>&#x20b9; 1234</label>
                                </div>
                            </div>
                        </div>
                    </div>
                     <div class="box-body">
                    <!-- /.box-header -->
                    <h4 class="box-title" style="color: cornflowerblue">Choose Shipping Method</h4>
                    <div class="box-body" id="ShippingMethodListDiv">
                    </div>
                    <h4 class="box-title" style="padding-top: 20px; color: cornflowerblue">Products Will be Couriered to:</h4>
                    <div class="box-body" id="ShippingAddressListDiv">
                    </div>
                    <!-- /.box-body -->
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="col-lg-12">
                            <hr />
                            <div class="col-lg-3"></div>
                            <div class="col-lg-3" style="text-align: center">
                                <button type="button" id="btnOpenAddressPopup" class="btn btn-block btn-success" onclick="OpenAddressPopup()">Add Delivery Address</button>
                            </div>
                            <div class="col-lg-3" style="text-align: center">
                                <button type="button" id="btnProceed" class="btn btn-block btn-info" onclick="redirect()">Proceed</button>
                            </div>
                            <div class="col-lg-3"></div>
                        </div>
                    </div>
                         </div>
                </div>
            </div>
        </div>
        <!--Address Details Modal content -->
        <div class="modal fade" id="AddressModel" role="dialog">
            <div class="modal-dialog" style="width: 70%;">

                <!--Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Add New Address</h4>
                    </div>
                    <div class="modal-body">
                        <!-- Main content -->
                        <section class="content">

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="box-body">
                                        <div class="row">
                                            <div class="col-md-6">

                                                <div class="form-group">
                                                    <div class="col-lg-4">
                                                        <label>Full Name:<span class="reqstar">*</span></label>
                                                    </div>
                                                    <div class="col-lg-8">
                                                        <input id="txtName" class="form-control" type="text" placeholder="Enter Full Name" />
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <div class="form-group" style="padding-top: 5px;">
                                                    <div class="col-lg-4">
                                                        <label>Pincode:</label>
                                                    </div>
                                                    <div class="col-lg-8">
                                                        <input id="txtPinCode" class="form-control" type="number" placeholder="Enter PIN Code" />
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <div class="form-group" style="padding-top: 5px;">
                                                    <div class="col-lg-4">
                                                        <label>Country:<span class="reqstar">*</span></label>
                                                    </div>
                                                    <div class="col-lg-8">
                                                        <select class="form-control select2" id="cmbCountry" style="width: 100%;" data-placeholder="Select Country" disabled="disabled">
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
                                                        <label>Town / City:</label>
                                                    </div>
                                                    <div class="col-lg-8">
                                                        <input id="txtCity" class="form-control" type="text" placeholder="Enter Town / City" />
                                                    </div>
                                                </div>

                                            </div>
                                            <!-- /.col -->
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="col-lg-4">
                                                        <label>Mobile Number:</label>
                                                    </div>
                                                    <div class="col-lg-8">
                                                        <input id="txtMobileNo" class="form-control" type="number" placeholder="Enter Mobile Number" />
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <div class="form-group" style="padding-top: 5px;">
                                                    <div class="col-lg-4">
                                                        <label>Address:</label>
                                                    </div>
                                                    <div class="col-lg-8">
                                                        <textarea id="txtAddress" class="form-control" rows="3" placeholder="Enter  Address..."></textarea>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>
                                                <div class="form-group" style="padding-top: 5px;">
                                                    <div class="col-lg-4">
                                                        <label>District:<span class="reqstar">*</span></label>
                                                    </div>
                                                    <div class="col-lg-8">

                                                        <select id="cmbDistrict" class="form-control select2" style="width: 100%;" data-placeholder="Select District">
                                                            <option></option>
                                                        </select>
                                                    </div>
                                                </div>

                                            </div>
                                            <!-- /.col -->
                                        </div>
                                    </div>
                                    <div class="row" style="margin-bottom: 15px;">
                                        <div class="col-lg-12">
                                            <hr />
                                            <div class="col-lg-3">
                                            </div>
                                            <div class="col-lg-3">
                                                <button type="button" id="btnSaveAddress" class="btn btn-block btn-success" onclick="AddressSave()">Save</button>
                                            </div>
                                            <div class="col-lg-3">
                                                <button type="button" id="btnCancelAddress" class="btn btn-block btn-danger" data-dismiss="modal">Close</button>
                                            </div>
                                            <div class="col-lg-1">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </section>
                        <!-- /.content -->
                    </div>

                </div>

            </div>
        </div>
        <!-- End Address details  Modal content -->
    </section>
    <script src="ClientJS/ShippingDetails.js"></script>
    <script>
        $(function () {
            $(".select2").select2();
        });
    </script>
</asp:Content>
