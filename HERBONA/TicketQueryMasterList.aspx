<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="TicketQueryMasterList.aspx.cs" Inherits="SmartTrucking.TicketQueryMasterList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Modal -->

    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Ticket Query Master List</h3>
                        <div style="float: right;">
                            <button type="button" class="btn btn-block btn-primary" onclick="redirect()" id="btn_create">CREATE Ticket Query Master</button>
                        </div>
                    </div>                 
                    <div class="box-body" id="LoadListDiv">
                    </div>                  
                </div>
            </div>
        </div>
    </section>
    <script src="ClientJS/TicketQueryMasterList.js"></script>
</asp:Content>
