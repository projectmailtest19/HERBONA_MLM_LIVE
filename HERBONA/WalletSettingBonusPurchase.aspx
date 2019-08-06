<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="WalletSettingBonusPurchase.aspx.cs" Inherits="SmartTrucking.WalletSettingBonusPurchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ht = {};
        $(document).ready(function () {
            setTimeout(function () {
                GetList();
            }, 2000);
            $("#hdnID").val('');
            ht = {};
            ht["BranchID"] = "2";
            ht["CompanyID"] = "1";
            AjaxPost('WalletSettingBonusPurchase.aspx/AjaxTicketQueryMasterDetails', ht, 'GetWALLET_PAYMENT_TYPE', 'GetWALLET_PAYMENT_TYPE');
        });
        $(function () {
            $(document).on("change", ":checkbox", function () {
                if ($(this).attr("id") == "chkCopyAllIems") {
                    if ($(".deeCheckAll").is(":checked")) {
                        $(".deeCheck").prop("checked", true);
                    }
                    else {
                        $(".deeCheck").prop("checked", false);
                    }
                }
                if ($('.deeCheck:checked').length == $('.deeCheck').length) {
                    $(".deeCheckAll").prop("checked", true);
                }
                if ($('.deeCheck:checked').length < $('.deeCheck').length) {
                    $(".deeCheckAll").prop("checked", false);
                }
            });
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
            //alert(JSON.stringify(data));
            if (Type == "GetWALLET_PAYMENT_TYPE") {
                document.getElementById("WalletDiv").innerHTML = "";
                var table = '<table id="WalletItemList" class="table table-bordered table-striped">';
                table = table + '<thead><tr><th><input type="checkbox" id="chkCopyAllIems" class="deeCheckAll"></th><th style="display:none">User ID</th> </th><th>Item Name</th></tr></thead><tbody>';
                $.each(data, function (i, item) {
                    $.each(JSON.parse(item.GetWALLET_PAYMENT_TYPE), function (i, Titem) {
                        table = table + "<tr><td><input type='checkbox' id='chkCopyIyems'  class='deeCheck'>" +
                                "</td><td style='display:none' >" + Titem.id +
                                "</td><td>" + Titem.name +
                                "</td></tr>"
                    });
                });
                document.getElementById("WalletDiv").innerHTML = table + '</tbody></table>';
            }
            if (Type == "GetWallet_Setting_Bonus_PurchaseList") {
                document.getElementById("MainDiv").innerHTML = "";
                var table = '<table id="MenuItemList" class="table table-bordered table-striped">';
                table = table + '<thead><tr><th style="display:none">ID</th><th>Name</th><th>Wallet Payment Type</th> <th style="width: 58px;">Edit</th></tr></thead><tbody>';
                $.each(data, function (i, Titem) {
                    //console.log(JSON.parse(item.TicketQuery));
                    $.each(JSON.parse(Titem.GetWallet_Setting_Bonus_PurchaseList), function (i, item) {
                        table = table + "<tr><td style='display:none' >" + item.id +
                                "</td><td>" + item.name +
                                "</td><td>" + item.WALLET_PAYMENT_TYPE_NAME +
                                "</td><td class='Edit' align='Left'> <button type='button' onclick=EditThis(" + item.id + ") class='btn btn-default btn-sm' id='btnEdit' > <span class='glyphicon glyphicon-edit'></span> </button>" +
                                "</td></tr>";
                    });
                });
                document.getElementById("MainDiv").innerHTML = table + '</tbody></table>';
            }

            if (Type == "EditWallet_Setting_Bonus_Purchase") {
                $.each(data, function (i, Titem) {
                    $.each(JSON.parse(Titem.EditWallet_Setting_Bonus_Purchase), function (i, item) {
                        //$("#chkPaySchedual").is(":checked"); 
                        $("#txtTicketName").val(item.name);
                        var IDs = item.WALLET_PAYMENT_TYPE_ID.split(',');
                        $.each(IDs, function (i, LiItem) { 
                            $("#WalletItemList tbody tr").each(function () {
                                if ($(this).find("td:eq(1)").html() == LiItem) {
                                    $(this).find("#chkCopyIyems").prop("checked", true);
                                }
                            });
                        }); 
                    });
                });
                if ($('.deeCheck:checked').length == $('.deeCheck').length) {
                    $(".deeCheckAll").prop("checked", true);
                }
                else {
                    $(".deeCheckAll").prop("checked", false);
                }
            }
            if (Type == "SaveWallet_Setting_Bonus_Purchase") {
                ClearAll();
                GetList();
                $.each(data.d, function (i, item) {
                    var g = JSON.parse(item);
                    alert(g.Message);
                });
            }
        }

        function GetList() {
            ht = {};
            ht["BranchID"] = "2";
            ht["CompanyID"] = "1";
            AjaxPost('WalletSettingBonusPurchase.aspx/AjaxTicketQueryMasterDetails', ht, 'GetWallet_Setting_Bonus_PurchaseList', 'GetWallet_Setting_Bonus_PurchaseList');
        }
        function EditThis(id) {
            ClearAll();
            $("#hdnID").val(id);
            $("#btnsave").text('Update');
            ht = {};
            ht["BranchID"] = "2";
            ht["CompanyID"] = "1";
            ht["ID"] = id;
            AjaxPost('WalletSettingBonusPurchase.aspx/AjaxTicketQueryMasterDetails', ht, 'EditWallet_Setting_Bonus_Purchase', 'EditWallet_Setting_Bonus_Purchase');
        }
        function ClearAll() {
            $("#btnsave").text('Save');
            $("#hdnID").val('');
            $("#txtTicketName").val('');
            //("#chkCopyAllIems").prop("checked", false);
            $("#WalletItemList tbody tr").each(function () {
                $(this).find("#chkCopyIyems").prop("checked", false);
            });
            if ($('.deeCheck:checked').length == $('.deeCheck').length) {
                $(".deeCheckAll").prop("checked", true);
            }
            else {
                $(".deeCheckAll").prop("checked", false);
            }
        }

        function SaveAllDetails() {
            if (validation()) {
                var Wallet_ID = "";
                ht = {};
                ht["ID"] = $("#hdnID").val();
                ht["name"] = $("#txtTicketName").val();
                $("#WalletItemList tbody tr").each(function () {
                    if ($(this).find("#chkCopyIyems").is(":Checked")) {
                        Wallet_ID = Wallet_ID == "" ? Wallet_ID + $(this).find("td:eq(1)").html() : Wallet_ID + "," + $(this).find("td:eq(1)").html();
                    }
                });
                ht["WALLET_PAYMENT_TYPE_ID"] = Wallet_ID;
                ht["BranchID"] = "2";
                ht["CompanyID"] = "1";
                //console.log(ht);
                AjaxPost('WalletSettingBonusPurchase.aspx/AjaxTicketQueryMasterDetails', ht, 'SaveWallet_Setting_Bonus_Purchase', 'SaveWallet_Setting_Bonus_Purchase');
            }
        }
        function validation() {
            if ($("#txtTicketName").val() == "") {
                alert("Name is required");
                return false;
            }
            if ($('.deeCheck:checked').length == 0)
            {
                alert("Wallet Payment Type is required");
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
                        <h3 id="Heading" class="box-title">Wallet Setting Bonus Purchase</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div id="AddSection">
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
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-2">
                                        <label>Wallet Payment Type<span class="reqstar">*</span></label>
                                    </div>
                                    <div id="WalletDiv" class="col-lg-10">
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
