<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="AddressList.aspx.cs" Inherits="SmartTrucking.AddressList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Address List</h3>
                        <div style="float: right;">                           
                            <button type="button" class="btn btn-block btn-primary" onclick="redirect()" id="btn_create">ADD AN ADDRESS</button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body" id="AddressListDiv">
                        
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
        </div>
    </section>
    <script src="ClientJS/AddressList.js"></script>

</asp:Content>
