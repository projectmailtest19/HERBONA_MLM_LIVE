<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="OrderEntryList.aspx.cs" Inherits="SmartTrucking.OrderEntryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Modal -->

    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Order Entry List</h3>
                        <div style="float: right;">
                            <button type="button" class="btn btn-block btn-primary" onclick="redirect()" id="btn_create">Stock Entry</button>
                        </div>
                    </div>   
                    <div class="col-lg-12" style="margin-top:10px;">
                                <div class="row">
                                    <div class="col-lg-2">
                                    </div>
                                    <div class="col-lg-2">
                                       <input id="txtOrderNumber" class="form-control" type="text" placeholder="Order Number" />
                                    </div>
                                     <div class="col-lg-1" style="text-align:center;">
                                         <label>OR</label>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="input-group date">
                                            <div class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </div>
                                            <input id="txtdateFrom" class="form-control pull-right datepicker" type="text" placeholder="mm/dd/yyyy" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="input-group date">
                                            <div class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </div>
                                            <input id="txtdateTo" class="form-control pull-right datepicker" type="text" placeholder="mm/dd/yyyy" />
                                        </div>
                                    </div>
                                    <div class="col-lg-1">
                                        <button type="button" class="btn btn-block btn-primary" onclick="Search()" id="btn_Search">Go</button>
                                    </div>
                                </div>
                            </div>              
                    <div class="box-body" id="LoadListDiv" style="overflow-x: auto;">
                    </div>                  
                </div>
            </div>
        </div>
    </section>
    <script src="ClientJS/OrderEntryList.js"></script>
    <script>
        $(function () {
            $(".select2").select2();
        });

        $('.datepicker').datepicker({
            autoclose: true
        });
    </script>
</asp:Content>
