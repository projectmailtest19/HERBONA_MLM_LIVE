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
    url = "PurchaseWalletSummary.aspx/AllLoadDetails";
    ht = {};
    LoadAjaxLoad(ht, obj, Req, url);
}

function Search() {
    Req = 'Search';
    obj = "Fill";
    url = "PurchaseWalletSummary.aspx/AllLoadDetails";
    ht = {};
    ht["FROM_DATE"] = $("#txtdateFrom").val();
    ht["TO_DATE"] = $("#txtdateTo").val();
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
                table = table + '<thead><tr><th>Transaction Date</th><th>Pay Shedule</th><th>Credited Amount</th><th>Debited Amount</th><th>Balance</th>' +
                    '<th>Type</th><th>Narration</th></tr></thead> <tbody>';
                $.each(data, function (i, item) {
                     
                    table = table + "<tr><td>" + item.Transaction_Date +
                                    "</td><td>" + item.PayShedule +
                                    "</td><td>" + item.Credited_Amount +
                                    "</td><td>" + item.Debited_Amount +
                                    "</td><td>" + item.Balance +
                                     "</td><td>" + item.Type +
                                       "</td><td>" + item.Narration +
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


