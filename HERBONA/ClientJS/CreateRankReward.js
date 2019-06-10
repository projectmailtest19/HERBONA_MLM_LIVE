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

    }
    else {
        $('#ID_hidden').val('' + id);
        Req = 'Edit';
        obj = "Fill";
        url = "CreateRankReward.aspx/TaxDetails";
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

                //EDIT MAPPING
                if (Result.d.TaxData != "" && Result.d.TaxData != undefined) {
                    var json = jQuery.parseJSON(Result.d.TaxData);
                    $("#btnsave").text("Update");

                    $.each(json, function (index, item) {
                        $("#ID_hidden").val(item.ID);
                        $("#txtNAME").val(item.NAME);
                        $("#txtSTART").val(item.START);
                        $("#txtLEFT_SIDE").val(item.LEFT_SIDE);
                        $("#txtRIGHT_SIDE").val(item.RIGHT_SIDE);
                        $("#txtREWARDS_DETAIL").val(item.REWARDS_DETAIL);
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
                       window.location = 'RankReward_List.aspx';
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
                        window.location = 'RankReward_List.aspx';
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
    window.location = 'RankReward_List.aspx';
}

function AddNewGst() {
    if (validationcheck() == true) {

        setTimeout(function () {
           
            ht = {};
            ht["ID"] = $("#ID_hidden").val();           
            ht["NAME"] = $("#txtNAME").val();
            ht["START"] = $("#txtSTART").val();
            ht["LEFT_SIDE"] = $("#txtLEFT_SIDE").val();
            ht["RIGHT_SIDE"] = $("#txtRIGHT_SIDE").val();
            ht["REWARDS_DETAIL"] = $("#txtREWARDS_DETAIL").val();
            ht["IsActive"] = "1";

            if ($("#btnsave").text() == "Save") {
                Req = 'Save';
                obj = "Save";
                url = "CreateRankReward.aspx/TaxDetails";
                LoadAjaxTax(ht, obj, Req, url);
            }
            if ($("#btnsave").text() == "Update") {
                Req = 'Update';
                obj = "Update";
                url = "CreateRankReward.aspx/TaxDetails";
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
    if ($('#txtSTART').val() == "") {
        popupErrorMsg($("#txtSTART"), "START is required.", 5);
        return false;
    }
    if ($('#txtLEFT_SIDE').val() == "") {
        popupErrorMsg($("#txtLEFT_SIDE"), "LEFT SIDE is required.", 5);
        return false;
    }
    if ($('#txtRIGHT_SIDE').val() == "") {
        popupErrorMsg($("#txtRIGHT_SIDE"), "RIGHT SIDE is required.", 5);
        return false;
    }
    if ($('#txtREWARDS_DETAIL').val() == "") {
        popupErrorMsg($("#txtREWARDS_DETAIL"), "REWARDS DETAIL is required.", 5);
        return false;
    }

    return true;
}