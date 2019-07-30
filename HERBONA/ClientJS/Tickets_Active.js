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
    url = "Tickets_Active.aspx/AllLoadDetails";
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
                table = table + '<thead><tr><th>Ticker Number</th><th>Ticket Date</th><th>Ticket Label</th><th>Query Type</th><th>Assigned TO</th>' +
                    '<th>Status</th><th>Answered By</th><th>Action Pending From</th><th  style="display:none">ORDER_NUMBER</th><th  style="display:none">Subject</th>' +
                    '<th  style="display:none">Attatchments</th><th  style="display:none">EstimatedAmount</th><th  style="display:none">CreditedAmount</th><th  style="display:none">PayScheduleNo</th></tr></thead> <tbody>';
                $.each(data, function (i, item) {

                    table = table + "<tr><td>" + item.TickerNumber +
                                    "</td><td>" + item.TicketDate +
                                      "</td><td>" + item.TicketLabel +
                                      "</td><td>" + item.QueryType +
                                      "</td><td>" + item.AssignedTO +
                                      "</td><td>" + item.Status +
                                      "</td><td>" + item.AnsweredBy +
                                      "</td><td>" + item.ActionPendingFrom +
                                      "</td><td  style='display:none' >" + item.ORDER_NUMBER +
                                      "</td><td  style='display:none' >" + item.Subject +
                                      "</td><td  style='display:none' >" + item.Attatchments +
                                      "</td><td  style='display:none' >" + item.EstimatedAmount +
                                    "</td><td  style='display:none' >" + item.CreditedAmount +
                                    "</td><td  style='display:none' >" + item.PayScheduleNo +
                                    "</tr>"
                });
                document.getElementById("LoadListDiv").innerHTML = table + '</tbody></table>';
                setTimeout(function () {
                    ShortTable('#LoadList');
                }, 100);
            }
            if (obj == "Delete") {
                if (Result.d.Delete != "" && Result.d.Delete != undefined) {
                    var json = jQuery.parseJSON(Result.d.Delete)[0];

                    if (json.CustomErrorState == "0") {

                        swal({
                            title: json.CustomMessage,
                            text: "",
                            type: "success",
                            timer: 2000,
                            showConfirmButton: false
                        });

                        GetLoadDetails();

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

function setStatus(Status, ID) {
    swal({
        title: "Are you sure you want to Update?",
        text: "",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes",
        closeOnConfirm: true
    },
 function () {
     Req = 'setStatus';
     obj = "setStatus";
     url = "Tickets_Active.aspx/AllLoadDetails";
     ht = {};
     ht["ID"] = ID;
     ht["IsActive"] = Status;
     LoadAjaxLoad(ht, obj, Req, url);
     GetLoadDetails();
 });

    return false;
}
function redirect() {
    window.location = 'CreateGst.aspx';
}


function LoadEdit(id) {
    var bt = btoa("id=" + id + "");
    window.location = 'CreateGst.aspx?' + bt;
}


function DeleteLoad(Status, ID) {
    swal({
        title: "Are you sure you want to delete?",
        text: "",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes",
        closeOnConfirm: true
    },
function () {
    Req = 'Delete';
    obj = "Delete";
    url = "Tickets_Active.aspx/AllLoadDetails";
    ht = {};
    ht["ID"] = ID;
    ht["IsActive"] = Status;
    LoadAjaxLoad(ht, obj, Req, url);
});

    return false;
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


