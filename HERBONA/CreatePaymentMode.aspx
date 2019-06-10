<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="CreatePaymentMode.aspx.cs" Inherits="SmartTrucking.CreatePaymentMode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Create Vacation Tour</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="col-lg-4">
                                        <label>NAME<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtNAME" class="form-control" type="text" placeholder="NAME" />
                                    </div>
                                </div>                                
                            </div>                                           
                        </div>


                        <div class="row" style="margin-bottom: 15px; margin-right: 370px">
                            <div class="col-lg-12">
                                <hr />
                                <div class="col-lg-3"></div>
                                <div class="col-lg-3" style="text-align: left">
                                    <button type="button" id="btnsave" class="btn btn-block btn-success" onclick="AddNewGst()">Save</button>
                                </div>
                                <div class="col-lg-3" style="text-align: center">
                                    <button type="button" id="btnCancel" class="btn btn-block btn-danger" onclick="redirect()">Cancel</button>
                                </div>
                                <div class="col-lg-3"></div>
                            </div>
                        </div>
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
        </div>
    </section>


    <input type="hidden" id="ID_hidden" class="form-control" />

    <script src="ClientJS/CreatePaymentMode.js"></script>
    <script>

        $(document).ready(function () {
            $(".select2").select2();
        });
    </script>



</asp:Content>
