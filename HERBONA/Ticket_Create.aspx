<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="Ticket_Create.aspx.cs" Inherits="SmartTrucking.Ticket_Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Create Item Details</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <div class="col-lg-4">
                                        <label>Query Ticket:<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <select class="form-control select2" id="cmbQueryTicket" style="width: 100%;" data-placeholder="Select Query Ticket">
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                                <div class="clearfix">&nbsp;</div>
                                 <div class="form-group">
                                    <div class="col-lg-4">
                                        <label>Reason:<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <select class="form-control select2" id="cmbReason" style="width: 100%;" data-placeholder="Select Reason" >
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                                <div class="clearfix">&nbsp;</div>
                                <div class="form-group" id="div_cmbPaySchedule">
                                    <div class="col-lg-4">
                                        <label>Pay Schedule No:<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <select class="form-control select2" id="cmbPaySchedule" style="width: 100%;" data-placeholder="Select Reason" >
                                            <option></option>
                                        </select>
                                    </div>
                                </div>

                                <div class="clearfix">&nbsp;</div>
                                <div class="form-group" style="padding-top: 5px;" id="div_txtCreditedAmount">
                                    <div class="col-lg-4">
                                        <label>Credited Amount:<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtCreditedAmount" class="form-control" type="text" placeholder="Credited Amount" />
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;" id="div_txtEstimatedAmount">
                                    <div class="col-lg-4">
                                        <label>Estimated Amount:<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtEstimatedAmount" class="form-control" type="text" placeholder="Estimated Amount" />
                                    </div>
                                </div>
                                 <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;" id="div_txtOrderId">
                                    <div class="col-lg-4">
                                        <label>Order Id:<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtOrderId" class="form-control" type="text" placeholder="Order Id" />
                                    </div>
                                </div>
                                 <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;" id="div_txtSubject">
                                    <div class="col-lg-4">
                                        <label>Subject :<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtSubject" class="form-control" type="text" placeholder="Subject" />
                                    </div>
                                </div>
                                 <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;" id="div_txtAttachments">
                                    <div class="col-lg-4">
                                        <label>Attachments:<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                           <input type="file" id="f_Uploadfile" />
                                        <%--<input id="txtAttachments" class="form-control" type="text" placeholder="Attachments" />--%>
                                    </div>
                                </div>
                                 <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;" id="div_txtComments">
                                    <div class="col-lg-4">
                                        <label>Comments:<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <textarea id="txtComments" class="form-control"  ></textarea>
                                    </div>
                                </div>
                                 <div class="clearfix"></div>                              
                                
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

    <script src="ClientJS/Ticket_Create.js"></script>
    <script>

        $(document).ready(function () {
            $(".select2").select2();
        });
    </script>



</asp:Content>
