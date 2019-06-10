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
        url = "CreateAgentProfile.aspx/ContactDetails";
        ht = {};
        LoadAjaxContact(ht, obj, Req, url);
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

                if (Result.d.Country != "" && Result.d.Country != undefined) {
                    var Country = jQuery.parseJSON(Result.d.Country);
                    $('#cmbCountry').html('');
                    $('#cmbCountry').append($('<option></option>'));
                    $.each(Country, function (index, item) {
                        $('#cmbCountry').append($('<option></option>').val(item.COUNTRY_ID).html(item.Name));
                    }); 
                }
                if (Result.d.Country != "" && Result.d.Country != undefined) {
                    var Country = jQuery.parseJSON(Result.d.Country);
                    $('#cmbCountry').html('');
                    $('#cmbCountry').append($('<option></option>'));
                    $.each(Country, function (index, item) {
                        $('#cmbCountry').append($('<option></option>').val(item.COUNTRY_ID).html(item.Name));
                    }); 
                }

                //EDIT MAPPING
                if (Result.d.TaxData != "" && Result.d.TaxData != undefined) {
                    var json = jQuery.parseJSON(Result.d.TaxData);
                    $("#btnsave").text("Update");

                    $.each(json, function (index, item) {
                        $("#ID_hidden").val(item.ID);
                        $("#txtTOUR_NAME").val(item.TOUR_NAME);
                        $("#txtLEFT_POINT").val(item.LEFT_POINT);
                        $("#txtLEFT_POINT_DETAIL").val(item.LEFT_POINT_DETAIL);
                        $("#txtRIGHT_POINT").val(item.RIGHT_POINT);
                        $("#txtRIGHT_POINT_DETAIL").val(item.RIGHT_POINT_DETAIL);

                        setTimeout(function () {
                            $("#cmbState").val(item.state_id).trigger('change');
                        }, 1000);

                        setTimeout(function () {
                            $("#cmbState").val(item.state_id).trigger('change');
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
            ht["TOUR_NAME"] = $("#txtTOUR_NAME").val();
            ht["LEFT_POINT"] = $("#txtLEFT_POINT").val();
            ht["LEFT_POINT_DETAIL"] = $("#txtLEFT_POINT_DETAIL").val();
            ht["RIGHT_POINT"] = $("#txtRIGHT_POINT").val();
            ht["RIGHT_POINT_DETAIL"] = $("#txtRIGHT_POINT_DETAIL").val();
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

    if ($('#txtTOUR_NAME').val() == "") {
        popupErrorMsg($("#txtTOUR_NAME"), "TOUR NAME is required.", 5);
        return false;
    }
    if ($('#txtLEFT_POINT').val() == "") {
        popupErrorMsg($("#txtLEFT_POINT"), "LEFT POINT is required.", 5);
        return false;
    }
    if ($('#txtLEFT_POINT_DETAIL').val() == "") {
        popupErrorMsg($("#txtLEFT_POINT_DETAIL"), "LEFT POINT DETAIL is required.", 5);
        return false;
    }
    if ($('#txtRIGHT_POINT').val() == "") {
        popupErrorMsg($("#txtRIGHT_POINT"), "RIGHT POINT is required.", 5);
        return false;
    }
    if ($('#txtRIGHT_POINT_DETAIL').val() == "") {
        popupErrorMsg($("#txtRIGHT_POINT_DETAIL"), "RIGHT POINT DETAIL is required.", 5);
        return false;
    }

    return true;
}