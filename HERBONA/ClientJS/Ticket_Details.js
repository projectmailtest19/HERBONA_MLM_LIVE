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
            Req = 'TicketView@TicketViewComment';
            obj = "Fill";
            url = "Ticket_Details.aspx/TaxDetails";
            ht = {};
            ht["TickerNumber"] = id;
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
                if (Result.d.TicketView != "" && Result.d.TicketView != undefined) {

                    var json = jQuery.parseJSON(Result.d.TicketView);
                    //$("#btnsave").text("Update");
                    $.each(json, function (index, item) {

                        $("#ID_hidden").val(item.TickerNumber);
                        $("#TicketNo").text(item.TickerNumber);
                        $("#TicketStatus").text(item.Status);
                        $("#TicketDate").text(item.TicketDate);
                        $("#QueryType").text(item.QueryType);
                        $("#Subject").text(item.Subject);
                    });
                }
                if (Result.d.TicketViewComment != "" && Result.d.TicketViewComment != undefined) {
                    var json = jQuery.parseJSON(Result.d.TicketViewComment);
                    //$("#btnsave").text("Update");
                    var messages = "";
                    $.each(json, function (index, item) {

                        messages = messages + ' <div class="col-lg-12" style="background-color: ' + item.Colour + ' ">' + item.comments + '</div><div class="clearfix">&nbsp;</div>'


                    });
                    $("#Message").append(messages);

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
                       //window.location = 'gst_list.aspx';
                       document.location.reload();
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
            //if (obj == "Update") {
            //    if (Result.d.Update != "" && Result.d.Update != undefined) {
            //        var json = jQuery.parseJSON(Result.d.Update)[0];

            //        if (json.CustomErrorState == "0") {

            //            swal({
            //                title: "",
            //                text: json.CustomMessage,
            //                type: "success",
            //                showCancelButton: false,
            //                confirmButtonColor: "#5cb85c",
            //                confirmButtonText: "Ok!",
            //                closeOnConfirm: false,
            //                timer: 2000
            //            },
            //        function () {
            //            window.location = 'gst_list.aspx';
            //        });


            //        }
            //        else if (json.CustomErrorState == "1") {
            //            swal("", "Something went wrong , please try again later !!", "error");

            //        }
            //        else if (json.CustomErrorState == "2") {
            //            swal("", json.CustomMessage, "info");

            //        }
            //    }
            //    else {
            //        swal("", "Some problem occurred please try again later", "info");
            //    }
            //}
            $('body').pleaseWait('stop');
        }
    });
}
function redirect() {
    window.location = 'Home.aspx';
}

function AddNewGst() {
    if (validationcheck() == true) {

        setTimeout(function () {

            ht = {};
            ht["TickerNumber"] = $("#ID_hidden").val();
            ht["Comments"] = $("#txtReply").val();


            //if ($("#btnsave").text() == "Save") {
            Req = 'Save';
            obj = "Save";
            url = "Ticket_Details.aspx/TaxDetails";
            LoadAjaxTax(ht, obj, Req, url);
            //}
            //if ($("#btnsave").text() == "Update") {
            //    Req = 'Update';
            //    obj = "Update";
            //    url = "Ticket_Details.aspx/TaxDetails";
            //    LoadAjaxTax(ht, obj, Req, url);
            //}
        }, 1000);
    }
}
function validationcheck() {

    //if ($('#txtCGST').val() == "") {
    //    popupErrorMsg($("#txtCGST"), "CGST is required.", 5);
    //    return false;
    //}
    //if ($('#txtSGST').val() == "") {
    //    popupErrorMsg($("#txtSGST"), "SGST is required.", 5);
    //    return false;
    //}
    //if ($('#txtIGST').val() == "") {
    //    popupErrorMsg($("#txtIGST"), "IGST is required.", 5);
    //    return false;
    //}    

    return true;
}