<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="CreateShippingCharges.aspx.cs" Inherits="SmartTrucking.CreateShippingCharges" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Create Vacation Tour</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">


                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="inputCountry" class="col-sm-3 control-label">Country<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                        <select class="form-control select2" id="cmbCountry" style="width: 100%;" data-placeholder="Select Country" disabled="disabled">
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                                <br />
                                <div class="form-group">
                                    <label for="inputState" class="col-sm-3 control-label">State<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                        <select id="cmbState" class="form-control select2" style="width: 100%;" data-placeholder="Select State">
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                                <br />
                                <div class="form-group">
                                    <label for="inputState" class="col-sm-3 control-label">District<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                        <select id="cmbDistrict" class="form-control select2" style="width: 100%;" data-placeholder="Select District">
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>CHARGE_PERCENTAGE<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtCHARGE_PERCENTAGE" class="form-control" type="text" placeholder="CHARGE PERCENTAGE" />
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>CHARGE AMOUNT<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtCHARGE_AMOUNT" class="form-control" type="text" placeholder="CHARGE AMOUNT" />
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row" style="margin-bottom: 15px; margin-right: 370px">
                            <div class="col-lg-12">
                                <hr />
                                <div class="col-lg-3"></div>
                                <div class="col-lg-3" style="text-align: left">
                                    <button type="button" id="btnsave" class="btn btn-block btn-success" onclick="AddNewGst()">Save</button>
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

    <script src="ClientJS/CreateShippingCharges.js"></script>
    <script>

        $(document).ready(function () {
            $(".select2").select2();
        });
    </script>



</asp:Content>
