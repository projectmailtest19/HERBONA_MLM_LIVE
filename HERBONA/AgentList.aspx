<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="AgentList.aspx.cs" Inherits="SmartTrucking.AgentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Modal -->
     
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Entrepreneur List</h3>
                        <div style="float: right;">
                            <!-- Trigger the modal with a button -->
                            <button type="button" class="btn btn-block btn-primary" onclick="redirect()" id="btn_create">CREATE ENTREPRENEUR</button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body" id="ContactListDiv">
                        
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
        </div>
    </section>
    <script src="ClientJS/AgentList.js"></script>
</asp:Content>
