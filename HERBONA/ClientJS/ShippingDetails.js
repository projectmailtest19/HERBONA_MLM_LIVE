var ht = {};
var Req = "";
var obj = "";
var Procedure = "";
var Action = "";
var _allowadd, _allowedit, _allowdelete;
$(document).ready(function () {
    setTimeout(function () {
        GetShippingMethod();
        GetShippingAddress();
        fillCountry();
    }, 1000);

});
function GetShippingMethod() {
    Req = 'FillShippingMethod';
    obj = "FillShippingMethod";
    url = "ShippingDetails.aspx/ContactDetails";
    ht = {};
    LoadAjaxCompany(ht, obj, Req, url);
}
function GetShippingAddress() {
    Req = 'FillShippingAddress';
    obj = "FillShippingAddress";
    url = "ShippingDetails.aspx/ContactDetails";
    ht = {};
    ht["Contact_id"] = localStorage.getItem('OrderMember_ID');
    LoadAjaxCompany(ht, obj, Req, url);
}
function fillCountry()
{
    Req = 'Country';
    obj = "Fill";
    url = "ShippingDetails.aspx/ContactDetails";
    ht = {};
    LoadAjaxCompany(ht, obj, Req, url);
}
$("#cmbCountry").change(function () {
    Req = 'State';
    obj = "State";
    url = "ShippingDetails.aspx/ContactDetails";
    ht = {};
    ht["COUNTRY_ID"] = $("#cmbCountry :selected").val();
    LoadAjaxCompany(ht, obj, Req, url);
});
$("#cmbState").change(function () {
    Req = 'District';
    obj = "District";
    url = "ShippingDetails.aspx/ContactDetails";
    ht = {};
    ht["State_ID"] = $("#cmbState :selected").val();
    LoadAjaxCompany(ht, obj, Req, url);
});
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
            if (obj == "Fill") {
                if (Result.d.Country != "" && Result.d.Country != undefined) {
                    var Country = jQuery.parseJSON(Result.d.Country);
                    $('#cmbCountry').html('');
                    $('#cmbCountry').append($('<option></option>'));
                    $.each(Country, function (index, item) {
                        $('#cmbCountry').append($('<option></option>').val(item.COUNTRY_ID).html(item.Name));
                    });
                    $("#cmbCountry").val(1).trigger('change');
                }

            }

            if (obj == "FillShippingMethod") {
                var data = jQuery.parseJSON(Result.d.FillShippingMethod);
                var table = '<table id="ShippingMethodList" class="table table-bordered table-striped">';
                var KK = 1, Radio_style;
                table = table + '<thead><tr><th style="display:none">ID</th><th style="display:none">Method</th><th style="display:none">Method</th></tr></thead> ';
                $.each(data, function (i, item) {
                    //alert(item.IsAgentActive);
                    if (KK == 1) {
                        Radio_style = "<input id='radioMethod' type='radio' checked='checked' value='1' name='RadioDefault' class='flat-red RadioDefault' />";
                    }
                    else {
                        Radio_style = "<input id='radioMethod' type='radio' value='1' name='RadioDefault' class='flat-red RadioDefault' />";
                    }
                    table = table + "<tbody><tr><td style='display:none' >" + item.ID +
                                    "</td><td style='width:5%'>" + Radio_style + 
                                    "</td><td style='width:95%'>" + item.NAME +
                                    "</td></tr>"
                    KK = KK + 1;
                });
                
                document.getElementById("ShippingMethodListDiv").innerHTML = table + "</tbody></table>";
                $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
                    checkboxClass: 'icheckbox_flat-green',
                    radioClass: 'iradio_flat-green',
                });
                setTimeout(function () {
                    ShortTable('#ShippingMethodList');
                }, 100);
               
            }
            if (obj == "FillShippingAddress") {
                var data = jQuery.parseJSON(Result.d.FillShippingAddress);
                var table1 = '<table id="ShippingAddressList" class="table table-bordered table-striped">';
                var Radio_style1;
                table1 = table1 + '<thead><tr><th style="display:none">ID</th><th style="display:none">radio</th><th style="display:none">Name</th><th style="display:none">Address</th></tr></thead> ';
                $.each(data, function (i, item) {
                    //alert(item.IsAgentActive);
                    if (item.is_default == 1) {
                        Radio_style1 = "<input id='radioAddress' type='radio' checked='checked' value='2' name='RadioDefaultAddress' class='flat-red RadioDefaultAddress' />";
                    }
                    else {
                        Radio_style1 = "<input id='radioAddress' type='radio' value='2' name='RadioDefaultAddress' class='flat-red RadioDefaultAddress' />";
                    }
                    table1 = table1 + "<tbody><tr><td style='display:none' >" + item.id +
                                    "</td><td style='width:5%'>" + Radio_style1 +
                                    "</td><td style='width:20%'>" + item.name +
                                    "</td><td style='width:75%'><p>" + item.addressline + "<br/>" + item.District_Name + "<br/>" + item.State_Name + "<br/>" + item.Country_Name + "<br/>" + item.pincode + "<br/>" + item.MobileNo + "</p>"
                                    "</td></tr>"
                });

                document.getElementById("ShippingAddressListDiv").innerHTML = table1 + "</tbody></table>";
                $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
                    checkboxClass: 'icheckbox_flat-green',
                    radioClass: 'iradio_flat-green',
                });
                setTimeout(function () {
                    ShortTable('#ShippingAddressList');
                }, 100);

            }
            if (obj == "SaveAddress") {
                if (Result.d.SaveAddress != "" && Result.d.SaveAddress != undefined) {
                    var json = jQuery.parseJSON(Result.d.SaveAddress)[0];

                    if (json.CustomErrorState == "0") {
                        setTimeout(function () {
                        swal({
                            title: json.CustomMessage,
                            text: "",
                            type: "success",
                            timer: 1000,
                            showConfirmButton: false
                        });
                        }, 100);
                        //setTimeout(function () {
                        $("#btnCancelAddress").click();
                        GetShippingAddress();
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

            if (obj == "SaveOrder_Details") {
                if (Result.d.SaveOrder_Details != "" && Result.d.SaveOrder_Details != undefined) {
                    var json = jQuery.parseJSON(Result.d.SaveOrder_Details)[0];

                    if (json.CustomErrorState == "0") {
                        //setTimeout(function () {
                        //    swal({
                        //        title: json.CustomMessage,
                        //        text: "",
                        //        type: "success",
                        //        timer: 1000,
                        //        showConfirmButton: false
                        //    });
                        //}, 100);
                        //setTimeout(function () {
                        
                        //}, 2000);
                        alert(json.ID);
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
    var Member_Id = localStorage.getItem('OrderMember_ID');
    var Order_ID = localStorage.getItem('Order_ID');
    var Address_ID, ShippingMethod_ID;
    $("#ShippingMethodList tbody tr").each(function () {
        if ($(this).find("#radioMethod").is(":Checked")) {
            ShippingMethod_ID = $(this).find("td:eq(0)").html();
        }
    });
    $("#ShippingAddressList tbody tr").each(function () {
        if ($(this).find("#radioAddress").is(":Checked")) {
            Address_ID = $(this).find("td:eq(0)").html();
        }
    });
    setTimeout(function () {
        ht = {};
        ht["Member_Id"] = Member_Id;
        ht["Order_ID"] = Order_ID;
        ht["ShippingMethod_ID"] = ShippingMethod_ID;
        ht["Address_ID"] = Address_ID;

        Req = 'SaveOrder_Details';
        obj = "SaveOrder_Details";
        url = "ShippingDetails.aspx/ContactDetails";
        LoadAjaxCompany(ht, obj, Req, url);
    }, 1000);
    //window.location = 'CreateAgentProfile.aspx';
}
function ShortTable(Tbl) {
    $(Tbl).DataTable({
        "paging": false,
        "lengthChange": true,
        "searching": false,
        "ordering": false,
        "info": false,
        "autoWidth": false,
        dom: 'C<"clear">lfrtip',
        colVis: {
            exclude: [0]
        }
    });
}
$('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
    checkboxClass: 'icheckbox_flat-green',
    radioClass: 'iradio_flat-green',
});
function OpenAddressPopup()
{
    $("#AddressModel").modal({ backdrop: "static" });
}
$('#AddressModel').on('hidden.bs.modal', function (e) {
    //$("#cmbCountry").val("").trigger('change');
    $("#cmbState").val("").trigger('change');
    $("#cmbDistrict").val("").trigger('change');
    $("#txtName").val("");
    $("#txtPinCode").val("");
    $("#txtCity").val("");
    $("#txtMobileNo").val("");
    $("#txtAddress").val("");
});
function AddressSave()
{
    if (validationcheck() == true) {

        setTimeout(function () {
            ht = {};
            ht["Contact_ID"] = localStorage.getItem('OrderMember_ID');
            ht["Name"] = $("#txtName").val();
            ht["MobileNo"] = $("#txtMobileNo").val();
            ht["country_id"] = $("#cmbCountry :selected").val();
            ht["state_id"] = $("#cmbState :selected").val();
            ht["district_id"] = $("#cmbDistrict :selected").val();
            ht["addressline"] = $("#txtAddress").val();
            ht["pincode"] = $("#txtPinCode").val();
            ht["city"] = $("#txtCity").val();

                Req = 'SaveAddress';
                obj = "SaveAddress";
                url = "ShippingDetails.aspx/ContactDetails";
                LoadAjaxCompany(ht, obj, Req, url);
        }, 1000);
    }
}
function validationcheck() {
    if ($('#txtName').val() == "") {
        popupErrorMsg($("#txtName"), "Enter Full Name.", 5);
        return false;
    }
    if ($('#cmbCountry :selected').val() == "") {
        popupErrorMsg($("#cmbCountry"), "Please Select Country.", 5);
        return false;
    }
    if ($('#cmbState :selected').val() == "") {
        popupErrorMsg($("#cmbState"), "Please Select State.", 5);
        return false;
    }
    if ($('#cmbDistrict :selected').val() == "") {
        popupErrorMsg($("#cmbDistrict"), "Please Select District.", 5);
        return false;
    }
    return true;
}