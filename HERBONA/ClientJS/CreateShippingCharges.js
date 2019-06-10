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


    if (id == undefined) {
        Req = 'Country';
        obj = "Fill";
        url = "CreateShippingCharges.aspx/TaxDetails";
        ht = {};
        LoadAjaxTax(ht, obj, Req, url);
    }
    else {
        $('#ID_hidden').val('' + id);
        Req = 'Edit@Country';
        obj = "Fill";
        url = "CreateShippingCharges.aspx/TaxDetails";
        ht = {};
        ht["ID"] = id;
        LoadAjaxTax(ht, obj, Req, url);
    }

});
$("#cmbCountry").change(function () {
    Req = 'State';
    obj = "State";
    url = "CreateShippingCharges.aspx/TaxDetails";
    ht = {};
    ht["COUNTRY_ID"] = $("#cmbCountry :selected").val();
    LoadAjaxTax(ht, obj, Req, url);
});
$("#cmbState").change(function () {
    Req = 'District';
    obj = "District";
    url = "CreateShippingCharges.aspx/TaxDetails";
    ht = {};
    ht["State_ID"] = $("#cmbState :selected").val();
    LoadAjaxTax(ht, obj, Req, url);
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

                //EDIT MAPPING
                

                if (Result.d.Country != "" && Result.d.Country != undefined) {
                    var Country = jQuery.parseJSON(Result.d.Country);
                    $('#cmbCountry').html('');
                    $('#cmbCountry').append($('<option></option>'));
                    $.each(Country, function (index, item) {
                        $('#cmbCountry').append($('<option></option>').val(item.COUNTRY_ID).html(item.Name));
                    });
                    $("#cmbCountry").val(1).trigger('change');
                }
                if (Result.d.State != "" && Result.d.State != undefined) {
                    var State = jQuery.parseJSON(Result.d.State);
                    $('#cmbState').html('');
                    $('#cmbState').append($('<option></option>'));
                    $.each(State, function (index, item) {
                        $('#cmbState').append($('<option></option>').val(item.COUNTRY_ID).html(item.Name));
                    });
                }
                if (Result.d.TaxData != "" && Result.d.TaxData != undefined) {
                    var json = jQuery.parseJSON(Result.d.TaxData);
                    $("#btnsave").text("Update");

                    $.each(json, function (index, item) {
                        $("#ID_hidden").val(item.ID);
                        $("#txtCHARGE_PERCENTAGE").val(item.CHARGE_PERCENTAGE);
                        $("#txtCHARGE_AMOUNT").val(item.CHARGE_AMOUNT);
                        $("#cmbCountry").val(item.country_id).trigger('change');
                        setTimeout(function () {
                            $("#cmbState").val(item.state_id).trigger('change');
                        }, 1000);
                        setTimeout(function () {
                            $("#cmbDistrict").val(item.DISTRICT_ID).trigger('change');
                        }, 2000);
                    });
                }

            }
            if (obj == "State") {
                if (Result.d.State != "" && Result.d.State != undefined) {
                    var State = jQuery.parseJSON(Result.d.State);
                    $('#cmbState').html('');
                    $('#cmbState').append($('<option></option>'));
                    $.each(State, function (index, item) {
                        $('#cmbState').append($('<option></option>').val(item.COUNTRY_ID).html(item.Name));
                    });
                }
            }
            if (obj == "District") {
                if (Result.d.District != "" && Result.d.District != undefined) {
                    var District = jQuery.parseJSON(Result.d.District);
                    $('#cmbDistrict').html('');
                    $('#cmbDistrict').append($('<option></option>'));
                    $.each(District, function (index, item) {
                        $('#cmbDistrict').append($('<option></option>').val(item.COUNTRY_ID).html(item.Name));
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
                       window.location = 'ShippingCharges_List.aspx';
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
                        window.location = 'ShippingCharges_List.aspx';
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
    window.location = 'ShippingCharges_List.aspx';
}

function AddNewGst() {
    if (validationcheck() == true) {

        setTimeout(function () {

            ht = {};
            ht["ID"] = $("#ID_hidden").val();
            ht["CHARGE_PERCENTAGE"] = $("#txtCHARGE_PERCENTAGE").val();
            ht["CHARGE_AMOUNT"] = $("#txtCHARGE_AMOUNT").val();
            ht["DISTRICT_ID"] = $("#cmbDistrict :selected").val();
            ht["IsActive"] = "1";

            if ($("#btnsave").text() == "Save") {
                Req = 'Save';
                obj = "Save";
                url = "CreateShippingCharges.aspx/TaxDetails";
                LoadAjaxTax(ht, obj, Req, url);
            }
            if ($("#btnsave").text() == "Update") {
                Req = 'Update';
                obj = "Update";
                url = "CreateShippingCharges.aspx/TaxDetails";
                LoadAjaxTax(ht, obj, Req, url);
            }
        }, 1000);
    }
}
function validationcheck() {

    if ($('#txtNAME').val() == "") {
        popupErrorMsg($("#txtNAME"), "NAME is required.", 5);
        return false;
    }
    if ($('#txtCODE').val() == "") {
        popupErrorMsg($("#txtCODE"), "CODE is required.", 5);
        return false;
    }

    return true;
}