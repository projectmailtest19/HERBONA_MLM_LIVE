<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="MyDirects.aspx.cs" Inherits="SmartTrucking.MyDirects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Modal -->
     
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">My Directs</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body" id="ContactListDiv">
                        
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
        </div>
    </section>
    <script src="ClientJS/MyDirects.js"></script>
</asp:Content>
