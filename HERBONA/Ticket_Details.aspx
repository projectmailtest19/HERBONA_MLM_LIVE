<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="Ticket_Details.aspx.cs" Inherits="SmartTrucking.Ticket_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title"></h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div class="col-lg-2">
                                        <label>Ticket No:</label>
                                    </div>
                                    <div class="col-lg-2">
                                        <label id="TicketNo"></label>
                                    </div>
                                    <div class="col-lg-2">
                                        <label>Ticket Status:</label>
                                    </div>
                                    <div class="col-lg-2">
                                        <label id="TicketStatus"></label>
                                    </div>
                                    <div class="col-lg-2">
                                        <label>Ticket Date:</label>
                                    </div>
                                    <div class="col-lg-2">
                                        <label id="TicketDate"></label>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-2">
                                        <label>Query Type</label>
                                    </div>
                                    <div class="col-lg-10">
                                        <label id="QueryType"></label>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-2">
                                        <label>Subject</label>
                                    </div>
                                    <div class="col-lg-10">
                                        <label id="Subject"></label>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-2">
                                        <label>Message</label>
                                    </div>
                                    <div class="col-lg-10" id="Message">


                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-2">
                                        <label>Reply</label>
                                    </div>
                                    <div class="col-lg-10">
                                        <textarea id="txtReply" class="form-control"></textarea>
                                    </div>
                                </div>

                            </div>
                        </div>


                        <div class="row" style="margin-bottom: 15px; margin-right: 370px">
                            <div class="col-lg-12">
                                <hr />
                                <div class="col-lg-3"></div>
                                <div class="col-lg-3" style="text-align: left">
                                    <button type="button" id="btnsave" class="btn btn-block btn-success" onclick="AddNewGst()">Reply</button>
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

    <script src="ClientJS/Ticket_Details.js"></script>
    <script>

        $(document).ready(function () {
            $(".select2").select2();
        });
    </script>



</asp:Content>
