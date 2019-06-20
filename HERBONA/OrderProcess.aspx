<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="OrderProcess.aspx.cs" Inherits="SmartTrucking.OrderProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Modal -->

    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Order Now</h3>
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
                        <h4 class="box-title" style="color: cornflowerblue">Payment Process</h4>
                        <div class="box-body">
                            <div class="col-md-12 text-center">
                                <h3 class="ng-binding">Shipping Charges :INR 100</h3>
                                <br>
                                <h3>Net Amount Payable INR(Include Shipping)</h3>
                                <h2 class="ng-binding">3690</h2>


                                <div class="col-md-12 b-r">
                                    <div class="">
                                        <img src="images/new_Indian_currency.png" style="height: 120px; width: 150px;" />
                                        <!--<h3>Purchase Wallet</h3>-->
                                    </div>
                                </div>
                            </div>
                        </div>
                        <h4 class="box-title" style="padding-top: 20px; color: cornflowerblue">Payment Modes</h4>
                        <div class="box-body" id="ShippingAddressListDiv">
                            <div class="col-md-12" id="divwallet">
                                <div class="col-md-4">
                                    <label>
                                        <input type="checkbox" class="flat-red" />
                                        Purchase Wallet
                                    </label>
                                </div>
                                <div class="col-md-4">
                                    <!--ng-change="CheckTransactions()"-->
                                    <input type="number" class="form-control" placeholder="Enter Amount" />
                                    <small class="ng-binding">Available Balance :INR 1488.5</small>
                                </div>
                                <div class="col-md-4">
                                    <input type="password" id="TransPwd" class="form-control" placeholder="Enter Transaction Password" />
                                    <label style="color: red" class="ng-binding"></label>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <label>
                                        <input type="checkbox" class="flat-red" />
                                        Payment Gateway
                                    </label>
                                </div>
                                <div class="col-md-4">
                                    <input type="number" class="form-control" id="txtNetBanking" placeholder="Enter Amount" />
                                </div>
                                <div class="col-md-4">
                                </div>
                            </div>
                        </div>
                        <!-- /.box-body -->
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script src="ClientJS/OrderProcess.js"></script>
    <script>
        $(function () {
            $(".select2").select2();
        });
    </script>
</asp:Content>
