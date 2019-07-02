<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SmartTrucking.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-12">
            <div class="box">
                <div class="box-header">
                    <h3 id="Heading" class="box-title"></h3>
                    <div style="float: right;">
                        <div class="form-group">
                            <div class="col-lg-8">
                                <label>Purchase Wallet: </label>
                            </div>
                            <div class="col-lg-8">
                                <label id="Lbl_WalletBalance">&#x20b9; xxxxxxxx</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box-body">
                    <div class="row">
                        <div class="col-lg-4 col-xs-6">
                            <!-- small box -->
                            <div class="small-box bg-aqua">
                                <div class="inner">
                                    <h3 id="h_Personal_Purchase_Invoice"></h3>

                                    <p>PERSONAL</p>
                                    <p>PURCHASE INVOICE</p>
                                </div>
                                <div class="icon">
                                    <i class="fa fa-fw fa-database"></i>
                                </div>
                            </div>
                        </div>
                        <!-- ./col -->
                        <div class="col-lg-4 col-xs-6">
                            <div class="small-box bg-green">
                                <div class="inner">
                                    <h3 id="h_repurchase_due_date"></h3>
                                    <p>NEXT DUE</p>
                                    <p>DATE OF REPURCHASE</p>
                                </div>
                                <div class="icon">
                                    <i class="fa fa-fw fa-calendar"></i>
                                </div>
                            </div>
                        </div>
                        <!-- ./col -->
                        <div class="col-lg-4 col-xs-6">
                            <div class="small-box bg-yellow">
                                <div class="inner">
                                    <h3 id="h_Payschedule_purchase"></h3>
                                    <p>CURRENT</p>
                                    <p>PAYSCHEDULE PURCHASE</p>
                                </div>
                                <div class="icon">
                                    <i class="fa fa-fw fa-database"></i>
                                </div>
                            </div>
                        </div>
                        <!-- ./col -->
                    </div>

                    <div class="row">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="info-box">
                                <span class="info-box-icon bg-aqua"><i class="fa fa-fw fa-rupee"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">TOTAL FTB</span>
                                    <span id="Span_TotalFtb" class="info-box-number"></span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->
                        </div>
                        <!-- /.col -->
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="info-box">
                                <span class="info-box-icon bg-green"><i class="fa fa-fw fa-rupee"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">TOTAL TLB</span>
                                    <span id="Span_TotalTLB" class="info-box-number"></span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->
                        </div>
                        <!-- /.col -->

                        <!-- fix for small devices only -->
                        <div class="clearfix visible-sm-block"></div>

                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="info-box">
                                <span class="info-box-icon bg-yellow"><i class="fa fa-fw fa-rupee"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">TOTAL DPLX</span>
                                    <span id="Span_TotalDplx" class="info-box-number"></span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->
                        </div>
                        <!-- /.col -->
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="info-box">
                                <span class="info-box-icon bg-purple"><i class="fa fa-fw fa-rupee"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">TOTAL RAB</span>
                                    <span id="Span_TotalRab" class="info-box-number"></span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->
                        </div>
                        <!-- /.col -->
                    </div>
                    <div class="row">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="info-box">
                                <span class="info-box-icon bg-light-blue"><i class="fa fa-fw fa-car"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">CAR & TRAVEL FUND</span>
                                    <span id="Span_CarTravelFund" class="info-box-number"></span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->
                        </div>
                        <!-- /.col -->
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="info-box">
                                <span class="info-box-icon bg-navy"><i class="fa fa-fw fa-home"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">HOUSE FUND</span>
                                    <span id="Span_HouseFund" class="info-box-number"></span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->
                        </div>
                        <!-- /.col -->

                        <!-- fix for small devices only -->
                        <div class="clearfix visible-sm-block"></div>

                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="info-box">
                                <span class="info-box-icon bg-teal"><i class="fa fa-fw fa-odnoklassniki"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">LEADERSHIP BONUS</span>
                                    <span id="Span_LeadershipBonus" class="info-box-number"></span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->
                        </div>
                        <!-- /.col -->
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="info-box">
                                <span class="info-box-icon bg-aqua"><i class="fa fa-fw fa-sitemap"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">ELITE RANKING BONUS</span>
                                    <span id="Span_RankingBonus" class="info-box-number"></span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->
                        </div>
                        <!-- /.col -->
                    </div>
                    <div class="row">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="info-box">
                                <span class="info-box-icon bg-red"><i class="fa fa-fw fa-rupee"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">RETAIL PROFIT</span>
                                    <span id="Span_RetailProfit" class="info-box-number"></span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->
                        </div>
                        <!-- /.col -->
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="info-box">
                                <span class="info-box-icon bg-green"><i class="fa fa-fw fa-sitemap"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">CURRENT RANK TITLE</span>
                                    <span id="Span_RankTitle" class="info-box-number"></span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->
                        </div>
                        <!-- /.col -->

                        <!-- fix for small devices only -->
                        <div class="clearfix visible-sm-block"></div>

                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="info-box">
                                <span class="info-box-icon bg-red"><i class="fa fa-fw fa-users"></i></span>

                                <div class="info-box-content">
                                    <span class="info-box-text">NO. OF DIRECTS</span>
                                    <span id="Span_DirectorsNumber" class="info-box-number"></span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->
                        </div>
                        <!-- /.col -->
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <!-- /.info-box -->
                        </div>
                        <!-- /.col -->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="ClientJS/Home.js"></script>
</asp:Content>
