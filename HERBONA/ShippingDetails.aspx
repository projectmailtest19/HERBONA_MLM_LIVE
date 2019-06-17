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
                    <!-- /.box-header -->
                    <h4 class="box-title" style="color: cornflowerblue">Choose Shipping Method</h4>
                    <div class="box-body" id="ShippingMethodListDiv">
                        
                    </div>
                    <h4 class="box-title" style="padding-top: 20px;color: cornflowerblue">Products Will be Couriered to:</h4>
                    <div class="box-body" id="ShippingAddressListDiv">
                        
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
        </div>
    </section>
    <script src="ClientJS/ShippingDetails.js"></script>
</asp:Content>
