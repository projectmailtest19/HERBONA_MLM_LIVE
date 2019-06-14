var ht = {};
var Req = "";
var obj = "";
var Procedure = "";
var Action = "";
var _allowadd, _allowedit, _allowdelete;

$(document).ready(function () {
    var id = GetParameterValues('id');
    function GetParameterValues(param) {       
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

    //// *******************************start permissionm**************************
    //permissionforlist('CreateTax.aspx', 'btnsave', 'TaxList.aspx', 'btnCancel');
    //// *******************************end permissionm**************************

    setTimeout(function () {  
    if (id == undefined) {
        Req = 'CATEGORY@GST';
        obj = "Fill";
        url = "CreateItemDetails.aspx/TaxDetails";
        ht = {};
        LoadAjaxTax(ht, obj, Req, url);
    }
    else {
        $('#ID_hidden').val('' + id);
        Req = 'Edit@CATEGORY@GST';
        obj = "Fill";
        url = "CreateItemDetails.aspx/TaxDetails";
        ht = {};
        ht["ID"] = id;
        LoadAjaxTax(ht, obj, Req, url);
    }
    }, 2000);
});

function LoadAjaxTax(ht, obj, Req, url) {
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

                if (Result.d.CATEGORY != "" && Result.d.CATEGORY != undefined) {
                    var cmbCATEGORY = jQuery.parseJSON(Result.d.CATEGORY);
                    $('#cmbCATEGORY').html('');
                    $('#cmbCATEGORY').append($('<option></option>'));
                    $.each(cmbCATEGORY, function (index, item) {
                        $('#cmbCATEGORY').append($('<option></option>').val(item.ID).html(item.NAME));
                    }); 
                }
                if (Result.d.GST != "" && Result.d.GST != undefined) {
                    var cmbGST = jQuery.parseJSON(Result.d.GST);
                    $('#cmbGST').html('');
                    $('#cmbGST').append($('<option></option>'));
                    $.each(cmbGST, function (index, item) {
                        $('#cmbGST').append($('<option></option>').val(item.ID).html(item.IGST));
                    }); 
                }

                //EDIT MAPPING
                if (Result.d.TaxData != "" && Result.d.TaxData != undefined) {
                    var json = jQuery.parseJSON(Result.d.TaxData);
                    $("#btnsave").text("Update");

                    $.each(json, function (index, item) {
                        $("#ID_hidden").val(item.ID);
                        $("#txtITEMNAME").val(item.NAME);
                        $("#txtITEMCODE").val(item.CODE);
                        $("#txtPBO_PRICE").val(item.PBO_PRICE);
                        $("#txtPRODUCT_SVP").val(item.PRODUCT_SVP);
                        $("#txtMRP").val(item.MRP);
                        $("#txtSALE_PRICE").val(item.SALE_PRICE);
                        $("#txtDISCOUNT_PERCENTAGE").val(item.DISCOUNT_PERCENTAGE);
                        $("#txtDISCOUNT_AMOUNT").val(item.DISCOUNT_AMOUNT);

                        setTimeout(function () {
                            $("#cmbCATEGORY").val(item.CATEGORY_ID).trigger('change');
                        }, 1000);

                        setTimeout(function () {
                            $("#cmbGST").val(item.GST_ID).trigger('change');
                        }, 1000);
                    });
                }


            }
            if (obj == "Save") {
                if (Result.d.Save != "" && Result.d.Save != undefined) {
                    var json = jQuery.parseJSON(Result.d.Save)[0];

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
                       window.location = 'ItemDetails_List.aspx';
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
            if (obj == "Update") {
                if (Result.d.Update != "" && Result.d.Update != undefined) {
                    var json = jQuery.parseJSON(Result.d.Update)[0];

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
                        window.location = 'ItemDetails_List.aspx';
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
function redirect() {
    window.location = 'ItemDetails_List.aspx';
}

function AddNewGst() {
    if (validationcheck() == true) {

        setTimeout(function () {
           
            ht = {};
            ht["ID"] = $("#ID_hidden").val();           
            ht["CATEGORY_ID"] = $("#cmbCATEGORY").val();
            ht["NAME"] = $("#txtITEMNAME").val();
            ht["PBO_PRICE"] = $("#txtPBO_PRICE").val();
            ht["PRODUCT_SVP"] = $("#txtPRODUCT_SVP").val();
            ht["DISCOUNT_PERCENTAGE"] = $("#txtDISCOUNT_PERCENTAGE").val();
            ht["DISCOUNT_AMOUNT"] = $("#txtDISCOUNT_AMOUNT").val();
            ht["CODE"] = $("#txtITEMCODE").val();
            ht["GST_ID"] = $("#cmbGST").val();
            ht["MRP"] = $("#txtMRP").val();
            ht["SALE_PRICE"] = $("#txtSALE_PRICE").val();

            ht["IsActive"] = "1";

            if ($("#btnsave").text() == "Save") {
                Req = 'Save';
                obj = "Save";
                url = "CreateItemDetails.aspx/TaxDetails";
                LoadAjaxTax(ht, obj, Req, url);
            }
            if ($("#btnsave").text() == "Update") {
                Req = 'Update';
                obj = "Update";
                url = "CreateItemDetails.aspx/TaxDetails";
                LoadAjaxTax(ht, obj, Req, url);
            }
        }, 1000);
    }
}
function validationcheck() {

    if ($('#txtITEMNAME').val() == "") {
        popupErrorMsg($("#txtITEMNAME"), "ITEM NAME is required.", 5);
        return false;
    }
    if ($('#txtITEMCODE').val() == "") {
        popupErrorMsg($("#txtITEMCODE"), "ITEM CODE is required.", 5);
        return false;
    }
    

    return true;
}