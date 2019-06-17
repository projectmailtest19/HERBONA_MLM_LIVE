<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="OrderEntry.aspx.cs" Inherits="SmartTrucking.OrderEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Modal -->

    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Order Entry</h3>
                    </div>
                    <div class="col-xs-12">
                        <div class="form-group col-xs-6">
                            <label for="inputCountry" class="col-sm-3 control-label">Member Name<span class="reqstar">*</span></label>

                            <div class="col-sm-9">
                                <select id="cmbSponsor_Name" class="form-control select2" style="width: 100%;" data-placeholder="Select Member">
                                    <option></option>
                                </select>
                            </div>
                        </div>
                        <div class="col-xs-6">
                        </div>
                    </div>


                    <div class="box-body" id="LoadListDiv">
                    </div>
                    <div class="col-xs-12">
                        <br />
                        <div class="col-lg-6"></div>
                        <div class="col-lg-3">
                            Total PRODUCT SVP :
                            <label id="Total_PRODUCT_SVP"></label>
                        </div>
                        <div class="col-lg-3">
                            Total PRICE :
                            <label id="Total_PBO_PRICE"></label>
                        </div>



                    </div>
                </div>
            </div>
        </div>
        <div class="row" style="margin-bottom: 15px;">
            <div class="col-lg-12">
                <hr />
                <div class="col-lg-3"></div>
                <div class="col-lg-3" style="text-align: center">
                    <button type="button" id="btnsave" class="btn btn-block btn-info">Proceed</button>
                    <%-- <button type="button" id="btnProceed" class="btn btn-block btn-info" onclick="AddOrder()" style="display:none">Proceed</button>--%>
                </div>
                <div class="col-lg-3" style="text-align: center">
                    <button type="button" id="btnCancel" class="btn btn-block btn-danger" onclick="redirect()">Cancel</button>
                </div>
                <div class="col-lg-3"></div>
            </div>
        </div>
    </section>
    <script src="ClientJS/OrderEntry.js"></script>
    <input type="hidden" id="ID_Hidden" value="1" />
      <script>
        $(document).ready(function () {
            $(".select2").select2();
        });
    </script>
</asp:Content>
