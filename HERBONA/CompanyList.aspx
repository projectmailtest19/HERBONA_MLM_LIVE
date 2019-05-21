<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="CompanyList.aspx.cs" Inherits="SmartTrucking.CompanyList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Company List</h3>
                        <div style="float: right;">                           
                            <button type="button" class="btn btn-block btn-primary" onclick="redirect()" id="btn_create">CREATE COMPANY</button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body" id="companyListDiv">
                        
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
        </div>
    </section>
     
    <script src="ClientJS/CompanyList.js"></script> 

</asp:Content>
