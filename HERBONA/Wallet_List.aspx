<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="Wallet_List.aspx.cs" Inherits="SmartTrucking.Wallet_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Modal -->

    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">VACATION TOUR List</h3>
                        <div style="float: right;">
                            <button type="button" class="btn btn-block btn-primary" onclick="redirect()" id="btn_create">CREATE VACATION TOUR</button>
                        </div>
                    </div>                 
                    <div class="box-body" id="LoadListDiv">
                    </div>                  
                </div>
            </div>
        </div>
    </section>
    <script src="ClientJS/Wallet_List.js"></script>
</asp:Content>
