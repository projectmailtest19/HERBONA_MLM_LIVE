var ht = {};
var Req = "";
var obj = "";
var Procedure = "";
var Action = "";
var _allowadd, _allowedit, _allowdelete;
$(document).ready(function () {
    setTimeout(function () {
        GetContactDetails();
    }, 1000);

});
function GetContactDetails() {
    Req = 'AgentList';
    obj = "Fill";
    url = "AgentList.aspx/ContactDetails";
    ht = {};
    LoadAjaxCompany(ht, obj, Req, url);
}
function LoadAjaxCompany(ht, obj, Req, url) {
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
                var data = jQuery.parseJSON(Result.d.AgentData);
                var table = '<table id="ContactList" class="table table-bordered table-striped">';
                table = table + '<thead><tr><th style="display:none">Agent ID</th><th>Status</th><th>Agent Name</th><th>Mobile Number</th><th>Email ID</th><th>Gender</th><th>Address</th><th  class=' + _allowedit + '>Edit</th></tr></thead> <tbody>';
                $.each(data, function (i, item) {
                    //alert(item.IsAgentActive);
                    if (item.IsAgentActive == "True") {
                        statusclass = 'btn btn-block btn-success';
                        Text = 'Active';
                    }
                    else {
                        statusclass = 'btn btn-block btn-danger';
                        Text = 'Inactive';
                    }
                    table = table + "<tr><td style='display:none' >" + item.ID +
                        "</td><td class='Edit " + _allowedit + "' align='center'><button type='button' class='" + statusclass + "' onclick=UpdateAgentStatus(" + item.ID + ")>" + Text + "</button>" +
                                    "</td><td>" + item.Name +
                                    "</td><td>" + item.MobileNo +
                                    "</td><td>" + item.Email +
                                    "</td><td>" + item.Gender +
                                    "</td><td>" + item.Address +
                                    "<td class='Edit " + _allowedit + "' align='center'> <button type='button' onclick=ContactEdit(" + item.ID + ") class='btn btn-default btn-sm' id='btnedit' > <span class='glyphicon glyphicon-edit'></span> </button></td>" +
                                    "</tr>"
                });
                document.getElementById("ContactListDiv").innerHTML = table + '</tbody></table>';
                setTimeout(function () {
                    ShortTable('#ContactList');
                }, 100);
            }
            if (obj == "StatusUpdate") {
                if (Result.d.CompanyData != "" && Result.d.CompanyData != undefined) {
                    var json = jQuery.parseJSON(Result.d.CompanyData)[0];

                    if (json.CustomErrorState == "0") {
                        setTimeout(function () {
                        swal({
                            title: json.CustomMessage,
                            text: "",
                            type: "success",
                            timer: 2000,
                            showConfirmButton: false
                        });
                        }, 100);
                        //setTimeout(function () {
                        GetContactDetails();
                        //}, 2000);
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
    window.location = 'CreateAgentProfile.aspx';
}

function ContactEdit(id) {
    var bt = btoa("cid=" + id + "");
    window.location = 'CreateAgentProfile.aspx?'+ bt;
}
function UpdateAgentStatus(id) {
    swal({
        title: "Are you sure you want to update the status?",
        text: "",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes",
        closeOnConfirm: true
    },
function () {
    Req = 'StatusUpdate';
    obj = "StatusUpdate";
    url = "AgentList.aspx/ContactDetails";
    ht = {};
    ht["ID"] = id;
    LoadAjaxCompany(ht, obj, Req, url);
});


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


