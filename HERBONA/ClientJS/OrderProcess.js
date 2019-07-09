var ht = {};
var Req = "";
var obj = "";
var Procedure = "";
var Action = "";
var _allowadd, _allowedit, _allowdelete;
$(document).ready(function () {
    var id = GetParameterValues('id');
    function GetParameterValues(param) {
        //var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        if (window.location.href.indexOf('?') > 0) {
            var urlenc = (window.location.href.slice(window.location.href.indexOf('?') + 1));
            var url = atob(urlenc).split('&');
            for (var i = 0; i < url.length; i++) {
                var urlparam = url[i].split('=');
                if (urlparam[0] == param) {
                    return urlparam[1];
                }
            }
        }
    }
    setTimeout(function () {
        if (id == undefined) {
           
        }
        else {
            //alert(id);
            $('#ID_hidden').val(id);
            Req = 'Wallet_Balance@Payment_Details';
            obj = "Fill";
            url = "OrderProcess.aspx/PaymentDetails";
            ht = {};
            ht["Order_Details_id"] = $('#ID_hidden').val();
            LoadAjaxPayment(ht, obj, Req, url);
        }
    }, 1000);
});
function LoadAjaxPayment(ht, obj, Req, url) {
    $('body').pleaseWait();

    $.ajax({
        type: "POST",
        url: url,
        data: "{ht:" + JSON.stringify(ht) + ",Type :'" + obj + "' ,Req :'" + Req + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Result) {
            var json = jQuery.parseJSON(Result.d.ErrorDetail);
            var sa_error = "";
            var sa_errrorMsg = "";
            $.each(json, function (index, K) {
                sa_error = K.Error;
                sa_errrorMsg = K.ErrorMessage;
            });
            if (sa_error != 'false') {
                swal("", sa_errrorMsg, "error");
                $('body').pleaseWait('stop');
                return 0;
            }

            if (obj == "Fill") {

                if (Result.d.Wallet_Balance != "" && Result.d.Wallet_Balance != undefined) {
                    var json = jQuery.parseJSON(Result.d.Wallet_Balance);
                    $.each(json, function (index, item) {
                        $("#Div_Wallet_bal").html("<label id='LBL_Wallet_Balance'>&#x20b9; "+parseFloat(item.Wallet_Balance).toFixed(2)+"</label>");
                        $("#Small_Total_Wallet_Amount").text('Available Balance :INR ' + parseFloat(item.Wallet_Balance).toFixed(2));
                        $("#Total_Wallet_Balance_Hidden").val(parseFloat(item.Wallet_Balance).toFixed(2));
                    });
                }
                if (Result.d.Payment_Details != "" && Result.d.Payment_Details != undefined) {
                    var json = jQuery.parseJSON(Result.d.Payment_Details);
                    $.each(json, function (index, item) {
                        $("#H_Sales_Amount").text('Sales Amount :INR ' + parseFloat(item.SALES_AMOUNT).toFixed(2));
                        $("#H_Shipping_Changes").text('Shipping Charges :INR ' + parseFloat(item.SHIPPING).toFixed(2));
                        $("#H_Net_Amount").text(parseFloat(item.NET_AMOUNT).toFixed(2));
                        $("#Net_Payable_Amount_Hidden").val(parseFloat(item.NET_AMOUNT).toFixed(2));
                        $("#H_Balance_Amount").text('Balance Amount :INR ' + parseFloat(item.NET_AMOUNT).toFixed(2));
                    });
                }
            }
            $('body').pleaseWait('stop');
        }
    });
}
$('#chk_Wallet').on('ifChecked', function (event) {
    $("#Txt_Wallet_Amount").prop("disabled", false);
});
$('#chk_Wallet').on('ifUnchecked', function (event) {
    $("#Txt_Wallet_Amount").prop("disabled", true);
    $('#Txt_Wallet_Amount').val("0.00");
    Calculate_Balance();
});

$('#chk_Gateway').on('ifChecked', function (event) {
    $("#Txt_Gateway_Amount").prop("disabled", false);
});
$('#chk_Gateway').on('ifUnchecked', function (event) {
    $("#Txt_Gateway_Amount").prop("disabled", true);
    $('#Txt_Gateway_Amount').val("0.00");
    Calculate_Balance();
});

$('#chk_Cash').on('ifChecked', function (event) {
    $("#txt_Cash_Amount").prop("disabled", false);
});
$('#chk_Cash').on('ifUnchecked', function (event) {
    $("#txt_Cash_Amount").prop("disabled", true);
    $('#txt_Cash_Amount').val("0.00");
    Calculate_Balance();
});
$('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
    checkboxClass: 'icheckbox_flat-green',
    radioClass: 'iradio_flat-green',
});

function Calculate_Balance()
{
    var text_Wallet, text_getway, text_Cash;
    if ($('#Txt_Wallet_Amount').val() == undefined || $('#Txt_Wallet_Amount').val() == "") {
        $('#Txt_Wallet_Amount').val("0.00");
        text_Wallet = 0;
    }
    else
    {
        if ((parseFloat($('#Txt_Wallet_Amount').val()).toFixed(2)) > (parseFloat($('#Total_Wallet_Balance_Hidden').val()).toFixed(2))) {
            popupErrorMsg($("#Txt_Wallet_Amount"), "You dont have enough amount in Wallet .", 5);
            $('#Txt_Wallet_Amount').val("0.00");
            text_Wallet =0;
        }
        else {
            $('#Txt_Wallet_Amount').val(parseFloat($('#Txt_Wallet_Amount').val()).toFixed(2));
            text_Wallet = parseFloat($('#Txt_Wallet_Amount').val()).toFixed(2);
        }
    }
    if ($('#Txt_Gateway_Amount').val() == undefined || $('#Txt_Gateway_Amount').val() == "") {
        $('#Txt_Gateway_Amount').val("0.00");
        text_getway = 0;
    }
    else
    {
        $('#Txt_Gateway_Amount').val(parseFloat($('#Txt_Gateway_Amount').val()).toFixed(2));
        text_getway = parseFloat($('#Txt_Gateway_Amount').val()).toFixed(2);
    }
    if ($('#txt_Cash_Amount').val() == undefined || $('#txt_Cash_Amount').val() == "") {
        $('#txt_Cash_Amount').val("0.00");
        text_Cash = 0;
    }
    else {
        $('#txt_Cash_Amount').val(parseFloat($('#txt_Cash_Amount').val()).toFixed(2));
        text_Cash = parseFloat($('#txt_Cash_Amount').val()).toFixed(2);
    }

    /// Balance calculation
    var Total_payment_amount = parseFloat(text_Wallet) + parseFloat(text_getway) + parseFloat(text_Cash);
    var Total_Payable_amount = (parseFloat($('#Net_Payable_Amount_Hidden').val()).toFixed(2));
    $('#H_Balance_Amount').text('Balance Amount :INR ' + parseFloat(parseFloat(Total_Payable_amount) - parseFloat(Total_payment_amount)).toFixed(2));
    //alert(Total_payment_amount);
    if (parseFloat(Total_payment_amount) == parseFloat(Total_Payable_amount))
    {
        $('#divproceed').show();
    }
    else
        if(parseFloat(Total_payment_amount) < parseFloat(Total_Payable_amount))
        {
            $('#divproceed').hide();
        }
        else
            if (parseFloat(Total_payment_amount) > parseFloat(Total_Payable_amount)) {
                swal({
                    title: "Amount Can't be exceed",
                    confirmButtonColor: "#5cb85c",
                    confirmButtonText: "Ok!",
                    closeOnConfirm: true,
                    timer: 2000
                });
                $('#divproceed').hide();
            }
}

function LoadAjaxOrderPaymentDetailslist(ht, obj, Req, url, OrderPaymentDetailsList) {
    $('body').pleaseWait();
    //alert(JSON.stringify(OrderPaymentDetailsList));
    $.ajax({
        type: "POST",
        url: url,
        data: "{ht:" + JSON.stringify(ht) + ",Type :'" + obj + "' ,Req :'" + Req + "'," +
            " OrderPaymentDetailsList:" + JSON.stringify(OrderPaymentDetailsList) +
            "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Result) {
            var json = jQuery.parseJSON(Result.d.ErrorDetail);
            var sa_error = "";
            var sa_errrorMsg = "";
            $.each(json, function (index, K) {
                sa_error = K.Error;
                sa_errrorMsg = K.ErrorMessage;
            });
            if (sa_error != 'false') {
                swal("", sa_errrorMsg, "error");
                $('body').pleaseWait('stop');
                return 0;
            }

            if (obj == "OrderPaymentDetails") {
                if (Result.d.OrderPaymentDetails != "" && Result.d.OrderPaymentDetails != undefined) {
                    var json = jQuery.parseJSON(Result.d.OrderPaymentDetails)[0];

                    if (json.CustomErrorState == "0") {

                        swal({
                            title: "",
                            text: json.CustomMessage,
                            type: "success",
                            showCancelButton: false,
                            confirmButtonColor: "#5cb85c",
                            confirmButtonText: "Ok!",
                            closeOnConfirm: false,
                            timer: 2000
                        },
                   function () {
                       window.location = 'Home.aspx';
                   });
                    }
                    else if (json.CustomErrorState == "1") {
                        swal("", "Something went wrong , please try again later !!", "error");

                    }
                    else if (json.CustomErrorState == "2") {
                        swal("", json.CustomMessage, "info");

                    }
                }
                else {
                    swal("", "Some problem occurred please try again later", "info");
                }

            }


            $('body').pleaseWait('stop');
        }

    });
}

function finalProceed()
{
    if (validationcheck() == true) {
        setTimeout(function () {
            
            var i = 0;
            OrderPaymentDetailsList = new Array();
            if ($("#chk_Wallet").is(":checked")) {
                var OrderPaymentDetailsList_Model = {};
                OrderPaymentDetailsList_Model.NAME ="Wallet";
                OrderPaymentDetailsList_Model.AMOUNT = $("#Txt_Wallet_Amount").val();
                OrderPaymentDetailsList[i++] = OrderPaymentDetailsList_Model;
            }

            if ($("#chk_Gateway").is(":checked")) {
                var OrderPaymentDetailsList_Model1 = {};
                OrderPaymentDetailsList_Model1.NAME = "PaymentGateway";
                OrderPaymentDetailsList_Model1.AMOUNT = $("#Txt_Gateway_Amount").val();
                OrderPaymentDetailsList[i++] = OrderPaymentDetailsList_Model1;
            }

            if ($("#chk_Cash").is(":checked")) {
                var OrderPaymentDetailsList_Model2 = {};
                OrderPaymentDetailsList_Model2.NAME = "Cash";
                OrderPaymentDetailsList_Model2.AMOUNT = $("#txt_Cash_Amount").val();
                OrderPaymentDetailsList[i++] = OrderPaymentDetailsList_Model2;
            }

            Req = 'OrderPaymentDetails';
            obj = "OrderPaymentDetails";
            url = "OrderProcess.aspx/SaveOrderPaymentDetailsList";
            ht = {};

            ht["Order_Details_id"] = $('#ID_hidden').val();

            LoadAjaxOrderPaymentDetailslist(ht, obj, Req, url, OrderPaymentDetailsList);

        }, 1000);
    }
}

function validationcheck()
{
    if ($("#chk_Wallet").is(":checked")) {
        if ($('#Txt_Wallet_Amount').val() == '0.00') {
            popupErrorMsg($("#Txt_Wallet_Amount"), "Please put some amount or uncheck the Wallet Checkbox.", 5);
            return false;
        }
    }
    if ($("#chk_Gateway").is(":checked")) {
        if ($('#Txt_Gateway_Amount').val() == '0.00') {
            popupErrorMsg($("#Txt_Gateway_Amount"), "Please put some amount or uncheck the Payment Gateway Checkbox.", 5);
            return false;
        }
    }
    if ($("#chk_Cash").is(":checked")) {
        if ($('#txt_Cash_Amount').val() == '0.00') {
            popupErrorMsg($("#txt_Cash_Amount"), "Please put some amount or uncheck the cash Checkbox.", 5);
            return false;
        }
    }
    return true;
}