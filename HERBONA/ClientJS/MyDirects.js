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
    Req = 'MyDirectsList';
    obj = "Fill";
    url = "MyDirects.aspx/ContactDetails";
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
                table = table + '<thead><tr><th>Account No / Member ID</th><th>Name</th><th>Registration Date</th><th>Position</th></tr></thead> <tbody>';
                $.each(data, function (i, item) {
                    table = table + "<tr><td>" + item.PBO_Account_No +
                                    "</td><td>" + item.Name +
                                    "</td><td>" + item.RegistrationDate +
                                    "</td><td>" + item.Position +
                                    "</td></tr>"
                });
                document.getElementById("ContactListDiv").innerHTML = table + '</tbody></table>';
                setTimeout(function () {
                    ShortTable('#ContactList');
                }, 100);
            }
            $('body').pleaseWait('stop');
        }
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


