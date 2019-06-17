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
        //$("#btnsave").show();
        //$("#btnProceed").hide();
        GetLoadDetails();
    }, 2000);
});
function GetLoadDetails() {
    Req = 'LoadList@Sponsor';
    obj = "Fill";
    url = "OrderEntry.aspx/AllLoadDetails";
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
                table = table + '<thead><tr><th style="display:none">ID</th><th  style="display:none">CATEGORY NAME</th><th>ITEM NAME</th><th style="display:none">ITEM CODE</th><th>QTN.</th><th>PBO PRICE</th>' +
                    '<th>PRODUCT SVP</th><th style="display:none">DISCOUNT PERCENTAGE</th><th style="display:none">DISCOUNT AMOUNT</th><th  style="display:none">MRP</th><th  style="display:none">SALE PRICE</th>' +
                    '<th>Total SVP</th><th>Total Amount</th></tr></thead> <tbody>';
                $.each(data, function (i, item) {
                    table = table + "<tr><td style='display:none' >" + item.ID +
                                    "</td><td style='display:none'>" + item.CATEGORY_NAME +
                                    "</td><td>" + item.NAME +
                                    "</td><td style='display:none'>" + item.CODE +
                                    "</td><td>  <input type='text' value='' placeholder='Quantity' class='cmbQuantity' onkeyup='rowCalculateFunction(this)'/>   " +
                                    "</td><td >" + item.PBO_PRICE +
                                    "</td><td >" + item.PRODUCT_SVP +
                                    "</td><td style='display:none' >" + item.DISCOUNT_PERCENTAGE +
                                    "</td><td style='display:none' >" + item.DISCOUNT_AMOUNT +
                                    "</td><td style='display:none'>" + item.MRP +
                                    "</td><td style='display:none'>" + item.SALE_PRICE +
                                     "</td><td class='cmbPRODUCT_SVP'>       " +
                                      "</td><td class='cmbPBO_PRICE'>   " +
                                    "</td></tr>"
                });
                document.getElementById("LoadListDiv").innerHTML = table + '</tbody></table>';
                setTimeout(function () {
                    ShortTable('#LoadList');
                }, 100);


                if (Result.d.Sponsor != "" && Result.d.Sponsor != undefined) {
                    var Sponsor = jQuery.parseJSON(Result.d.Sponsor);
                    $('#cmbSponsor_Name').html('');
                    $('#cmbSponsor_Name').append($('<option></option>'));
                    $.each(Sponsor, function (index, item) {
                        $('#cmbSponsor_Name').append($('<option></option>').val(item.COUNTRY_ID).html(item.Name));
                    });                   
                }
            }

            if (obj == "FillGivenOrder") {
                if (Result.d.FillGivenOrder != "" && Result.d.FillGivenOrder != undefined) {
                    var data = jQuery.parseJSON(Result.d.FillGivenOrder);
                    document.getElementById("LoadListDiv").innerHTML = "";
                    var table = '<table id="LoadList" class="table table-bordered table-striped">';
                    table = table + '<thead><tr><th style="display:none">ID</th><th  style="display:none">CATEGORY NAME</th><th>ITEM NAME</th><th style="display:none">ITEM CODE</th><th>QTN.</th><th>PBO PRICE</th>' +
                        '<th>PRODUCT SVP</th><th style="display:none">DISCOUNT PERCENTAGE</th><th style="display:none">DISCOUNT AMOUNT</th><th  style="display:none">MRP</th><th  style="display:none">SALE PRICE</th>' +
                        '<th>Total SVP</th><th>Total Amount</th></tr></thead> <tbody>';
                    $.each(data, function (i, item) {
                        table = table + "<tr><td style='display:none' >" + item.ID +
                                        "</td><td style='display:none'>" + item.CATEGORY_NAME +
                                        "</td><td>" + item.NAME +
                                        "</td><td style='display:none'>" + item.CODE +
                                        "</td><td>" + item.QUANTITY +
                                        "</td><td >" + item.PBO_PRICE +
                                        "</td><td >" + item.PRODUCT_SVP +
                                        "</td><td style='display:none' >" + item.DISCOUNT_PERCENTAGE +
                                        "</td><td style='display:none' >" + item.DISCOUNT_AMOUNT +
                                        "</td><td style='display:none'>" + item.MRP +
                                        "</td><td style='display:none'>" + item.SALE_PRICE +
                                         "</td><td>       " + item.Total_SVP +
                                          "</td><td>   " + item.Total_Amount +
                                        "</td></tr>"
                    });
                    document.getElementById("LoadListDiv").innerHTML = table + '</tbody></table>';
                    setTimeout(function () {
                        ShortTable('#LoadList');
                    }, 100);
                }
            }

            $('body').pleaseWait('stop');
        }
    });
}

function redirect() {
    window.location = 'OrderEntryList.aspx';
}
function validationcheck() {
    if ($('#cmbSponsor_Name').val() == "") {
        popupErrorMsg($("#cmbSponsor_Name"), "Please Select Member.", 5);
        return false;
    }
    return true;
}
function AddNew() {
    if (validationcheck() == true) {
        ht = {};
        ht["MEMEBER_ID"] = $("#cmbSponsor_Name").val();
        localStorage.setItem('OrderMember_ID', $("#cmbSponsor_Name").val());
        ht["TOTAL_SVP"] = $("#Total_PRODUCT_SVP").text();
        ht["TOTAL_AMOUNT"] = $("#Total_PBO_PRICE").text();
        ht["ORDER_TYPE"] = 'PURCHASE';

        ht["IsActive"] = "1";


        var i = 0;
        LoadList = new Array();
        $('#LoadListDiv tbody tr').each(function () {
            var LoadList_Model = {};

            if ($(this).find('td:eq(4)').find(".cmbQuantity").val() != "") {
                LoadList_Model.ITEM_ID = $(this).find('td:eq(0)').html();
                LoadList_Model.QUANTITY = $(this).find('td:eq(4)').find(".cmbQuantity").val();
            }

            LoadList[i++] = LoadList_Model;
        });

        Req = 'SaveCompleteLoad';
        obj = "SaveCompleteLoad";
        url = "OrderEntry.aspx/savedetailswithlist";
        LoadAjaxLoadwithlist(ht, obj, Req, url, LoadList);
    }

}
function ShortTable(Tbl) {
    $(Tbl).DataTable({
        "paging": false,
        "lengthChange": true,
        "searching": false,
        "ordering": false,
        "info": false,
        "autoWidth": false,
        dom: 'C<"clear">lfrtip',
        colVis: {
            exclude: [0]
        }
    });
}


function LoadAjaxLoadwithlist(ht, obj, Req, url, LoadList) {
    $('body').pleaseWait();

    $.ajax({
        type: "POST",
        url: url,
        data: "{ht:" + JSON.stringify(ht) + ",Type :'" + obj + "' ,Req :'" + Req + "'," +
             " LoadList:" + JSON.stringify(LoadList) +
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

            if (obj == "SaveCompleteLoad") {
                if (Result.d.Save != "" && Result.d.Save != undefined) {
                    var json = jQuery.parseJSON(Result.d.Save)[0];

                    if (json.CustomErrorState == "0") {

                        //swal({
                        //    title: "",
                        //    text: json.CustomMessage,
                        //    type: "success",
                        //    showCancelButton: false,
                        //    confirmButtonColor: "#5cb85c",
                        //    confirmButtonText: "Ok!",
                        //    closeOnConfirm: false,
                        //    timer: 2000
                        //});
                        //localStorage.removeItem('Order_ID');
                        //alert(json.ID);
                        localStorage.setItem('Order_ID', json.ID);
                        FilertGiven_Order();
                        //$("#btnsave").hide();
                        //$("#btnsave").css('display', 'none');
                        //$("#btnProceed").show();
                        $("#ID_Hidden").val('2');
                   //function () {
                   //    window.location = 'OrderEntryList.aspx';
                   //});

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

function rowCalculateFunction(e) {
    var qtn_val = e.value;
    var currentRow = $(e).closest("tr");

    var col6 = currentRow.find("td:eq(6)").text();
    var col7 = currentRow.find("td:eq(7)").text();

    var TotalSVP = col6 * qtn_val;
    var TotalAmount = col7 * qtn_val;


    currentRow.find("td:eq(11)").text(TotalSVP);
    currentRow.find("td:eq(12)").text(TotalAmount)

    var sumPBO_PRICE = 0;
    var sumPRODUCT_SVP = 0;

    $('td[class*="cmbPBO_PRICE"]').each(function () {
        sumPBO_PRICE += Number($(this).text()) || 0;
    });

    $('td[class*="cmbPRODUCT_SVP"]').each(function () {
        sumPRODUCT_SVP += Number($(this).text()) || 0;
    });

    $('#Total_PBO_PRICE').text(sumPBO_PRICE);
    $('#Total_PRODUCT_SVP').text(sumPRODUCT_SVP);
    

}

function FilertGiven_Order()
{
    Req = 'FillGivenOrder';
    obj = "FillGivenOrder";
    url = "OrderEntry.aspx/AllLoadDetails";
    ht = {};
    ht["ORDER_ID"] = localStorage.getItem('Order_ID');
    //alert(localStorage.getItem('Order_ID'));
    LoadAjaxLoad(ht, obj, Req, url);
}
$("#btnsave").click(function () {
    if ($("#ID_Hidden").val()=='1')
    {
        AddNew();
    }
    else
    {
        //AddOrder();
        window.location = 'ShippingDetails.aspx';
    }
});