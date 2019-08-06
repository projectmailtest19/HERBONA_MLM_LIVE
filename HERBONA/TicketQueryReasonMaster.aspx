<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="TicketQueryReasonMaster.aspx.cs" Inherits="SmartTrucking.TicketQueryReasonMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ht = {};
        $(document).ready(function () {
            $("#hdnID").val('');
            ht = {};
            ht["BranchID"] = "2";
            ht["CompanyID"] = "1";
            AjaxPost('TicketQueryReasonMaster.aspx/AjaxTicketQueryMasterDetails', ht, 'GetTicketQuery', 'GetTicketQuery');
        });
        function AjaxPost(baseurl, input, Type, Req) {
            $.ajax({
                type: "POST",
                url: baseurl,
                data: "{ht:" + JSON.stringify(input) + ",Type :'" + Type + "' ,Req :'" + Req + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                //beforeSend: function (xhr) { xhr.setRequestHeader('Authorization', Global.Authorization); },
                //async: false,
                success: function (result) {
                    SuccessData(Type, result);
                },
                error: function (result) {
                    alert('Some problem occured !' + JSON.stringify(result));
                }
            });
        }
        function SuccessData(Type, data) {
            if (Type == "GetTicketQuery") {
                //alert(JSON.stringify(data));
                $('#SelTicketQuery').html('');
                $('#SelTicketQuery').append($('<option></option>'));
                $.each(data, function (i, item) {
                    //console.log(JSON.parse(item.TicketQuery));
                    $.each(JSON.parse(item.TicketQuery), function (i, Titem) {
                        $('#SelTicketQuery').append($('<option></option>').val(Titem.id).html(Titem.name));
                    });
                });
            }
            if (Type == "GetSavedTicketQueryList") {
                document.getElementById("MainDiv").innerHTML = "";
                var table = '<table id="MenuItemList" class="table table-bordered table-striped">';
                table = table + '<thead><tr><th style="display:none">ID</th><th>Name</th><th>Pay Schedule No</th><th>Credited Amount</th><th>Estimated Amount</th><th>Comments</th><th>Order ID</th><th>Attatchments</th><th>Subject</th><th>Status</th><th style="width: 58px;">Edit</th></tr></thead><tbody>';
                $.each(data, function (i, Titem) {
                    //console.log(JSON.parse(item.TicketQuery));
                    $.each(JSON.parse(Titem.GetSavedTicketQueryList), function (i, item) {
                        table = table + "<tr><td style='display:none' >" + item.id +
                                "</td><td>" + item.name +
                                "</td><td>" + (item.PayScheduleNo == "True" ? "Show" : "Hide") +
                                "</td><td>" + (item.CreditedAmount == "True" ? "Show" : "Hide") +
                                "</td><td>" + (item.EstimatedAmount == "True" ? "Show" : "Hide") +
                                "</td><td>" + (item.Comments == "True" ? "Show" : "Hide") +
                                "</td><td>" + (item.orderid == "True" ? "Show" : "Hide") +
                                "</td><td>" + (item.Attatchments == "True" ? "Show" : "Hide") +
                                "</td><td>" + (item.subject == "True" ? "Show" : "Hide") +
                                "</td><td>" + (item.IsActive == "True" ? "Active" : "InActive") +
                                "</td><td class='Edit' align='Left'> <button type='button' onclick=EditThis(" + item.id + ") class='btn btn-default btn-sm' id='btnEdit' > <span class='glyphicon glyphicon-edit'></span> </button>" +
                                "</td></tr>";
                    });
                });
                document.getElementById("MainDiv").innerHTML = table + '</tbody></table>';
            }

            if (Type == "EditTicketQueryList") {
                $.each(data, function (i, Titem) {
                    $.each(JSON.parse(Titem.EditTicketQueryList), function (i, item) {
                        //$("#chkPaySchedual").is(":checked"); 
                        $("#txtTicketName").val(item.name);
                        $("#chkPaySchedual").prop("checked", (item.PayScheduleNo == "True" ? true : false));
                        $("#chkCreaditAmount").prop("checked", (item.CreditedAmount == "True" ? true : false));
                        $("#chkEstimatedTime").prop("checked", (item.EstimatedAmount == "True" ? true : false));
                        $("#chkComment").prop("checked", (item.Comments == "True" ? true : false));
                        $("#chkOrderedID").prop("checked", (item.orderid == "True" ? true : false));
                        $("#chkAttachement").prop("checked", (item.Attatchments == "True" ? true : false));
                        $("#chkSubject").prop("checked", (item.subject == "True" ? true : false));
                        $("#chkStatus").prop("checked", (item.IsActive == "True" ? true : false));
                    });
                });
            }
            if (Type == "SaveTicketQuery") {
                ClearAll();
                ht = {};
                ht["BranchID"] = "2";
                ht["CompanyID"] = "1";
                ht["TicketID"] = $("#SelTicketQuery :selected").val()
                AjaxPost('TicketQueryReasonMaster.aspx/AjaxTicketQueryMasterDetails', ht, 'GetSavedTicketQueryList', 'GetSavedTicketQueryList');

                $.each(data.d, function (i, item) {
                    var g = JSON.parse(item);
                    alert(g.Message);
                });
            }
        }

        function GetList(e) {
            $("#btnsave").text('Update');
            $("#hdnID").val('');
            ClearAll();
            ht = {};
            ht["BranchID"] = "2";
            ht["CompanyID"] = "1";
            ht["TicketID"] = $("#SelTicketQuery :selected").val()
            AjaxPost('TicketQueryReasonMaster.aspx/AjaxTicketQueryMasterDetails', ht, 'GetSavedTicketQueryList', 'GetSavedTicketQueryList');
        }
        function EditThis(id) {
            ClearAll();
            $("#hdnID").val(id);
            $("#btnsave").text('Update');
            ht = {};
            ht["BranchID"] = "2";
            ht["CompanyID"] = "1";
            ht["TicketID"] = $("#SelTicketQuery :selected").val()
            ht["ID"] = id;
            AjaxPost('TicketQueryReasonMaster.aspx/AjaxTicketQueryMasterDetails', ht, 'EditTicketQueryList', 'EditTicketQueryList');
        }
        function ClearAll() {
            $("#btnsave").text('Save');
            $("#hdnID").val('');
            $("#txtTicketName").val('');
            $("#chkPaySchedual").prop("checked", false);
            $("#chkCreaditAmount").prop("checked", false);
            $("#chkEstimatedTime").prop("checked", false);
            $("#chkComment").prop("checked", false);
            $("#chkOrderedID").prop("checked", false);
            $("#chkAttachement").prop("checked", false);
            $("#chkSubject").prop("checked", false);
            $("#chkStatus").prop("checked", false);
        }

        function SaveAllDetails() {
            if (validation()) {
                ht = {};
                ht["ID"] = $("#hdnID").val();
                ht["TicketID"] = $("#SelTicketQuery :selected").val();
                ht["name"] = $("#txtTicketName").val();
                ht["PayScheduleNo"] = $("#chkPaySchedual").is(":checked");
                ht["CreditedAmount"] = $("#chkCreaditAmount").is(":checked");
                ht["EstimatedAmount"] = $("#chkEstimatedTime").is(":checked");
                ht["Comments"] = $("#chkComment").is(":checked");
                ht["orderid"] = $("#chkOrderedID").is(":checked");
                ht["Attatchments"] = $("#chkAttachement").is(":checked");
                ht["subject"] = $("#chkSubject").is(":checked");
                ht["IsActive"] = $("#chkStatus").is(":checked");
                ht["BranchID"] = "2";
                ht["CompanyID"] = "1";
                //console.log(ht);
                AjaxPost('TicketQueryReasonMaster.aspx/AjaxTicketQueryMasterDetails', ht, 'SaveTicketQuery', 'SaveTicketQuery');
            }
        }
        function validation() {
            if ($("#SelTicketQuery :selected").val() == "")
            {
                alert("Ticket Query is required");
                return false;
            }
            if ($("#txtTicketName").val() == "") {
                alert("Name is required");
                return false;
            } 
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <input type="hidden" id="hdnID" />
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 id="Heading" class="box-title">Ticket Query Reason Master</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div id="AddSection">
                            <div class="col-lg-12">
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-2">
                                        <label>Ticket Query<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-10">
                                        <select class="form-control select2" id="SelTicketQuery" style="width: 100%;" onchange="GetList(this);" data-placeholder="Select Ticket Query">
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-12">
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-2">
                                        <label>Name<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-10">
                                        <input type="text" id="txtTicketName" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-12">
                                <div class="row">
                                    <div class="col-lg-2">
                                    </div>
                                    <div class="col-lg-10">
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="form-group" style="padding-top: 5px;">
                                                    <div class="col-lg-6">
                                                        <label>Pay Schedual</label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <input type="checkbox" id="chkPaySchedual" />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group" style="padding-top: 5px;">
                                                    <div class="col-lg-6">
                                                        <label>Creadit Amount</label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <input type="checkbox" id="chkCreaditAmount" />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group" style="padding-top: 5px;">
                                                    <div class="col-lg-6">
                                                        <label>Estimated Time</label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <input type="checkbox" id="chkEstimatedTime" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-12">
                                <div class="row">
                                    <div class="col-lg-2">
                                    </div>
                                    <div class="col-lg-10">
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="form-group" style="padding-top: 5px;">
                                                    <div class="col-lg-6">
                                                        <label>Comment</label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <input type="checkbox" id="chkComment" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group" style="padding-top: 5px;">
                                                    <div class="col-lg-6">
                                                        <label>Ordered ID</label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <input type="checkbox" id="chkOrderedID" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group" style="padding-top: 5px;">
                                                    <div class="col-lg-6">
                                                        <label>Attachement</label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <input type="checkbox" id="chkAttachement" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-12">
                                <div class="row">
                                    <div class="col-lg-2">
                                    </div>
                                    <div class="col-lg-10">
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="form-group" style="padding-top: 5px;">
                                                    <div class="col-lg-6">
                                                        <label>Subject</label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <input type="checkbox" id="chkSubject" />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-lg-4">
                                                <div class="form-group" style="padding-top: 5px;">
                                                    <div class="col-lg-6">
                                                        <label>Status</label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <input type="checkbox" id="chkStatus" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 15px;">
                                <div class="col-lg-12">
                                    <hr />
                                    <div class="col-lg-3"></div>
                                    <div class="col-lg-3" style="text-align: left">
                                        <button type="button" id="btnsave" class="btn btn-block btn-success" onclick="SaveAllDetails()">Save</button>
                                    </div>
                                    <div class="col-lg-3" style="text-align: center">
                                        <button type="button" id="btnCancel" class="btn btn-block btn-danger" onclick="ClearAll()">Cancel</button>
                                    </div>
                                    <div class="col-lg-3"></div>
                                </div>
                            </div>
                        </div>
                        <div id="ListSection">
                            <div class="row" style="margin-bottom: 15px;">
                                <div id="MainDiv" class="col-lg-12">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
