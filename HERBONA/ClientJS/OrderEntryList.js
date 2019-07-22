var ht = {};
var Req = "";
var obj = "";
var Procedure = "";
var Action = "";
var _Status;
var _Text;
var _TextClass;

var _allowadd, _allowedit, _allowdelete;

$(document).ready(function () {
    setTimeout(function () {
        GetLoadDetails();
    }, 2000);
});
function GetLoadDetails() {
    Req = 'LoadList';
    obj = "Fill";
    url = "OrderEntryList.aspx/AllLoadDetails";
    ht = {};
    LoadAjaxLoad(ht, obj, Req, url);
}

function Search() {
    Req = 'Search';
    obj = "Fill";
    url = "OrderEntryList.aspx/AllLoadDetails";
    ht = {};
    ht["ORDER_NUMBER"] = $("#txtOrderNumber").val();
    ht["FROM_ORDER_DATE"] = $("#txtdateFrom").val();
    ht["TO_ORDER_DATE"] = $("#txtdateTo").val();
    LoadAjaxLoad(ht, obj, Req, url);
}
function LoadAjaxLoad(ht, obj, Req, url) {
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
                var data = jQuery.parseJSON(Result.d.LoadData);
                document.getElementById("LoadListDiv").innerHTML = '';
                var table = '<table id="LoadList" class="table table-bordered table-striped">';
                table = table + '<thead><tr><th style="display:none">ID</th><th>Member Id</th><th>Account No</th><th>Order Date</th><th>Order Number</th><th>Invoive Date</th>' +
                    '<th>Invoice No</th><th>Payment Status</th><th>Mode Of Payment</th><th>Total SVP</th><th>Total Amount</th><th>Order Type</th></tr></thead> <tbody>';
                $.each(data, function (i, item) {
                     
                    table = table + "<tr><td style='display:none' >" + item.ID +
                                    "</td><td>" + item.MEMEBER_ID +
                                    "</td><td>" + item.Account_Number +
                                    "</td><td>" + item.ORDER_DATE +
                                    "</td><td>" + item.ORDER_NUMBER +
                                     "</td><td>" + item.INVOICE_DATE +
                                       "</td><td>" + item.INVOICE_NUMBER +
                                       "</td><td>" + item.PAYMENT_STATUS +
                                       "</td><td>" + item.ModeOfPayment +
                                       "</td><td>" + item.TOTAL_SVP +
                                    "</td><td>" + item.TOTAL_AMOUNT +
                                    "</td><td>" + item.ORDER_TYPE +
                                    "</td></tr>"
                });
                document.getElementById("LoadListDiv").innerHTML = table + '</tbody></table>';
                setTimeout(function () {
                    ShortTable('#LoadList');
                }, 100);
            }

            $('body').pleaseWait('stop');
        }
    });
}
function redirect() {
    window.location = 'OrderEntry.aspx';
}

function ShortTable(Tbl) {
    $(Tbl).DataTable({
        "paging": true,
        "lengthChange": true,
        "searching": true,
        "ordering": false,
        "info": true,
        "autoWidth": false,
        dom: 'C<"clear">lfrtip',
        colVis: {
            exclude: [0]
        }
    });
}


