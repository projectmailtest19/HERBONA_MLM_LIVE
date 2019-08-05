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
    url = "TicketQueryStatusMasterList.aspx/AllLoadDetails";
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
                table = table + '<thead><tr><th style="display:none">ID</th><th>NAME</th><th>Status</th><th  class=' + _allowedit + '>Edit</th><th  class=' + _allowdelete + '>Delete</th></tr></thead> <tbody>';
                $.each(data, function (i, item) {

                    _Status = '';
                    _TextClass = '';
                    _Text = '';

                    if (item.IsActive == "False") {
                        _Status = 1
                        _TextClass = 'btn btn-block btn-warning';
                        _Text = 'In Active';

                    } else {
                        _Status = 0
                        _TextClass = 'btn btn-block btn-info';
                        _Text = 'Active';
                    }

                    table = table + "<tr><td style='display:none' >" + item.ID +
                                    "</td><td>" + item.NAME +
                                    "</td><td><input id=status_" + item.ID + " data=" + item.IsActive + " class='" + _TextClass + "'  onclick=setStatus(" + _Status + "," + item.ID + ") type='button' value='" + _Text + "' />" +
                                    "<td class='Edit " + _allowedit + "' align='Left'> <button type='button' onclick=LoadEdit(" + item.ID + ") class='btn btn-default btn-sm' id='btnedit' > <span class='glyphicon glyphicon-edit'></span> </button></td>" +
                                    "</td>" +
                                    "<td class='Edit " + _allowdelete + "' align='Left'> <button type='button' onclick=DeleteLoad(" + _Status + "," + item.ID + ") class='btn btn-default btn-sm' id='btndelete' > <span class='glyphicon glyphicon-trash'></span> </button></td>" +
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
     url = "TicketQueryStatusMasterList.aspx/AllLoadDetails";
     ht = {};
     ht["ID"] = ID;
     ht["IsActive"] = Status;
     LoadAjaxLoad(ht, obj, Req, url);
     GetLoadDetails();
 });

    return false;
}
function redirect() {
    window.location = 'CreateTicketQueryStatusMaster.aspx';
}


function LoadEdit(id) {
    var bt = btoa("id=" + id + "");
    window.location = 'CreateTicketQueryStatusMaster.aspx?' + bt;
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
    url = "TicketQueryStatusMasterList.aspx/AllLoadDetails";
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


