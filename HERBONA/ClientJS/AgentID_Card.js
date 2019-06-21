var ht = {};
var Req = "";
var obj = "";
var Procedure = "";
var Action = "";

var _allowadd, _allowedit, _allowdelete;
$(document).ready(function () {
    var cid = GetParameterValues('cid');
    function GetParameterValues(param) {
        //var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
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
    //permissionforlist('AddContact.aspx', 'btnsave', 'ContactList.aspx', 'btnCancel');
    //// *******************************end permissionm**************************
    setTimeout(function () {    
        Req = 'Fill';
        obj = "Fill";
        url = "AgentID_Card.aspx/ContactDetails";
        ht = {};
       // alert(cid);
        ht["ID"] = cid;
        LoadAjaxContact(ht, obj, Req, url);
    }, 1000);
});

function Print()
{

    //var divToPrint = document.getElementById('Print_Div');

    //var newWin = window.open('', 'Print-Window', 'height=400,width=800');

    //newWin.document.open();

    //newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');

    //newWin.document.close();

    //setTimeout(function () { newWin.close(); }, 10);
    var divToPrint = document.getElementById("Print_Div");
    newWin = window.open("");
    newWin.document.write(divToPrint.outerHTML);
    newWin.document.write('<link rel="stylesheet" href="ClientCss/Idcard.css" type="text/css" />');
    newWin.print();
    newWin.close();
}

function LoadAjaxContact(ht, obj, Req, url) {
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
           // alert(obj);
            if (obj == "Fill") {
                if (Result.d.FillIDCardDetails != "" && Result.d.FillIDCardDetails != undefined) {
                    var json = jQuery.parseJSON(Result.d.FillIDCardDetails);
                  //  alert(1);
                    $.each(json, function (index, item) {
                     //   alert(item.Name);
                        $('#Hname').text(item.Name);
                        $("#PAcNo").text(item.Account_Number);
                        $("#PDistrict").text(item.District_Name);
                        $("#PState").text(item.State_Name);
                        $("#PCountry").text(item.Countey_Name);
                        $("#PValidDate").text(item.Valid_Upto);
                        $("#PPanNo").text(item.Pan_No);
                        $('#Agent_Img').attr('src', '' + item.ImageURL + '');

                    });

                }

            }
            $('body').pleaseWait('stop');
        }
    });
}








