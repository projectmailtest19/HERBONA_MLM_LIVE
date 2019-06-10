<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="CreateItemDetails.aspx.cs" Inherits="SmartTrucking.CreateItemDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Create Item Details</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="col-lg-4">
                                        <label>CATEGORY<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <select class="form-control select2" id="cmbCATEGORY" style="width: 100%;" data-placeholder="Select CATEGORY" >
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>ITEM NAME<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtITEMNAME" class="form-control" type="text" placeholder="ITEM NAME" />
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>ITEM CODE<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtITEMCODE" class="form-control" type="text" placeholder="ITEM CODE" />
                                    </div>
                                </div>

                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>PBO PRICE<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtPBO_PRICE" class="form-control" type="text" placeholder="PBO PRICE" />
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>PRODUCT SVP<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtPRODUCT_SVP" class="form-control" type="text" placeholder="PRODUCT SVP" />
                                    </div>
                                </div>
                                
                            </div>
                            <div class="col-md-6">
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>GST<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                         <select class="form-control select2" id="cmbGST" style="width: 100%;" data-placeholder="Select GST" >
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>MRP<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtMRP" class="form-control" type="text" placeholder="MRP" />
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>SALE PRICE<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtSALE_PRICE" class="form-control" type="text" placeholder="SALE PRICE" />
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>DISCOUNT PERCENTAGE<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtDISCOUNT_PERCENTAGE" class="form-control" type="text" placeholder="DISCOUNT PERCENTAGE" />
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>DISCOUNT AMOUNT<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtDISCOUNT_AMOUNT" class="form-control" type="text" placeholder="DISCOUNT AMOUNT" />
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

    <script src="ClientJS/CreateItemDetails.js"></script>
    <script>

        $(document).ready(function () {
            $(".select2").select2();
        });
    </script>



</asp:Content>
