﻿var ht = {};
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
    url = "ItemStockList.aspx/AllLoadDetails";
    ht = {};
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

                var table = '<table id="LoadList" class="table table-bordered table-striped">';
                table = table + '<thead><tr><th style="display:none">ID</th><th>CATEGORY NAME</th><th>ITEM NAME</th><th>ITEM CODE</th><th>PBO PRICE</th>' +
                    '<th style="display:none">PRODUCT SVP</th><th style="display:none">DISCOUNT PERCENTAGE</th><th style="display:none">DISCOUNT AMOUNT</th><th>MRP</th><th>SALE PRICE</th><th>STOCK QTN.</th></tr></thead> <tbody>';
                $.each(data, function (i, item) {
                    table = table + "<tr><td style='display:none' >" + item.ID +
                                    "</td><td>" + item.CATEGORY_NAME +
                                    "</td><td>" + item.NAME +
                                    "</td><td>" + item.CODE +
                                    "</td><td>" + item.PBO_PRICE +
                                    "</td><td style='display:none'>" + item.PRODUCT_SVP +
                                    "</td><td style='display:none' >" + item.DISCOUNT_PERCENTAGE +
                                    "</td><td style='display:none' >" + item.DISCOUNT_AMOUNT +
                                    "</td><td>" + item.MRP +
                                    "</td><td>" + item.SALE_PRICE +
                                     "</td><td>" + item.QUANTITY +
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
    window.location = 'ItemStockEntry.aspx';
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


