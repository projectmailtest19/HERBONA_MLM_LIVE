<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="ItemStockEntry.aspx.cs" Inherits="SmartTrucking.ItemStockEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Modal -->

    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Item Stock Entry</h3>
                    </div>
                    <div class="box-body" id="LoadListDiv">
                    </div>
                </div>
            </div>
        </div>
        <div class="row" style="margin-bottom: 15px;">
            <div class="col-lg-12">
                <hr />
                <div class="col-lg-3"></div>
                <div class="col-lg-3" style="text-align: left">
                    <button type="button" id="btnsave" class="btn btn-block btn-success" onclick="AddNew()">Save</button>
                </div>
                <div class="col-lg-3" style="text-align: center">
                    <button type="button" id="btnCancel" class="btn btn-block btn-danger" onclick="redirect()">Cancel</button>
                </div>
                <div class="col-lg-3"></div>
            </div>
        </div>
    </section>
    <script src="ClientJS/ItemStockEntry.js"></script>
</asp:Content>
