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
                                <div id="Div_Wallet_bal" class="col-lg-8">
                                   <%-- <label id="LBL_Wallet_Balance">&#x20b9; 200.50</label>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="box-body">
                        <!-- /.box-header -->
                        <h4 class="box-title" style="color: cornflowerblue">Payment Process</h4>
                        <div class="box-body">
                            <div class="col-md-12 text-center">
                                 <h3 id="H_Sales_Amount" class="ng-binding"></h3>
                                <br>
                                <h3 id="H_Shipping_Changes" class="ng-binding"></h3>
                                <br>
                                <h3>Net Amount Payable INR(Include Shipping)</h3>
                                <h2 id="H_Net_Amount" class="ng-binding"></h2>


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
                                        <input id="chk_Wallet" type="checkbox" class="flat-red" />
                                        Purchase Wallet
                                    </label>
                                </div>
                                <div class="col-md-4">
                                    <!--ng-change="CheckTransactions()"-->
                                    <input id="Txt_Wallet_Amount" type="number" class="form-control" placeholder="Enter Amount" value="0.00" disabled="disabled" onchange="Calculate_Balance();"/>
                                    <small id="Small_Total_Wallet_Amount" class="ng-binding"></small>
                                </div>
                                <div class="col-md-4">
                                   <%-- <input type="password" id="TransPwd" class="form-control" placeholder="Enter Transaction Password" />
                                    <label style="color: red" class="ng-binding"></label>--%>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <label>
                                        <input id="chk_Gateway" type="checkbox" class="flat-red" />
                                        Payment Gateway
                                    </label>
                                </div>
                                <div class="col-md-4">
                                    <input id="Txt_Gateway_Amount" type="number" class="form-control" placeholder="Enter Amount" value="0.00" disabled="disabled" onchange="Calculate_Balance();"/>
                                </div>
                                <div class="col-md-4">
                                </div>
                            </div>
                            <div class="col-md-12" style="padding-top:5px;">
                                <div class="col-md-4">
                                    <label>
                                        <input id="chk_Cash" type="checkbox" class="flat-red" />
                                        Cash Payment
                                    </label>
                                </div>
                                <div class="col-md-4">
                                    <input type="number" class="form-control" id="txt_Cash_Amount" placeholder="Enter Amount" value="0.00" disabled="disabled" onchange="Calculate_Balance();"/>
                                </div>
                                <div class="col-md-4">
                                </div>
                            </div>
                            <div class="col-md-12 m-t-xl text-center" id="divbal" style="">
                                                <h2 id="H_Balance_Amount" class="ng-binding"></h2>
                                            </div>
                            <div class="col-md-12 " id="divproceed" style=" text-align:center; display:none;">
                                                    <button class="btn btn-s-md btn-primary" onclick="finalProceed();" id="btnproceed">Proceed</button>
                                            </div>
                        </div>
                        <!-- /.box-body -->
                    </div>
                </div>
            </div>
        </div>
    </section>
     <input type="hidden" id="ID_hidden" class="form-control" />
     <input type="hidden" id="Total_Wallet_Balance_Hidden" class="form-control" />
     <input type="hidden" id="Net_Payable_Amount_Hidden" class="form-control"/>
    <script src="ClientJS/OrderProcess.js"></script>
    <script>
        $(function () {
            $(".select2").select2();
        });
    </script>
</asp:Content>
