var ht = {};
var Req = "";
var obj = "";
var Procedure = "";
var Action = "";

$(document).ready(function () {
    localStorage.clear();
});
function LoginSubmit() {
    if ($("#txtAccountNumber").val() == "") {
        popupErrorMsg($("#txtAccountNumber"), "Account number is required.", 5);
        return false;
    }
    if ($("#txtPassword").val() == "") {
        popupErrorMsg($("#txtPassword"), "Password is required.", 5);
        return false;
    }
}
function NextSubmit2() {
    if ($("#txtPhoneNumber").val() == "") {
        popupErrorMsg($("#txtPhoneNumber"), "Phone number is required.", 5);
        return false;
    }
    if ($("#txtFullName").val() == "") {
        popupErrorMsg($("#txtFullName"), "Full Name is required.", 5);
        return false;
    }
    if ($("#txtDOB").val() == "") {
        popupErrorMsg($("#txtDOB"), "DOB is required.", 5);
        return false;
    }
    if ($("#SelCountry :selected").val() == "") {
        popupErrorMsg($("#SelCountry"), "Country is required.", 5);
        return false;
    }
    if ($("#SelState :selected").val() == "") {
        popupErrorMsg($("#SelState"), "State is required.", 5);
        return false;
    }
    if ($("#SelDistrict :selected").val() == "") {
        popupErrorMsg($("#SelDistrict"), "District is required.", 5);
        return false;
    }
    if ($("#txtPINCode").val() == "") {
        popupErrorMsg($("#txtPINCode"), "PIN is required.", 5);
        return false;
    }
    if ($("#position :selected").val() == "") {
        popupErrorMsg($("#position"), "Position is required.", 5);
        return false;
    }
    swal("Conguratulation", "Account successfully created !", "success");
}

function NextSubmit1() {
    if ($("#txtSponsorAccountNumber").val() == "") {
        popupErrorMsg($("#txtSponsorAccountNumber"), "Account number is required.", 5);
        return false;
    }
    $("#1Div").hide();
    $("#2Div").show();
}
function Back() {
    $("#1Div").show();
    $("#2Div").hide();
}
$(document).ready(function () {
    $(".select2").select2();
});
$(function () {
    $(".select2").select2();
});
$(function () {
    $('.datepicker').datepicker({
        autoclose: true
    });
});
function LoadAjaxLogin(ht, obj, Req, url) {
    $.ajax({
        type: "POST",
        url: url,
        data: "{ht:" + JSON.stringify(ht) + " ,Type :'" + obj + "' ,Req :'" + Req + "'}",
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
            if (sa_error == '2') {
                // swal("", sa_errrorMsg, "error");
                alert(sa_errrorMsg);
                return 0;
            }
            else if (sa_error == '1') {
                //swal("", sa_errrorMsg, "info");
                alert(sa_errrorMsg);
                return 0;
            }


            if (obj == "Login") {

                if (Result.d.Login != "" && Result.d.Login != undefined) {

                    var data = jQuery.parseJSON(Result.d.Login);
                    //  alert(data.IsAgent);
                    if (data.IsAgent == "True") {

                        window.location.assign('MyProfile.aspx');
                    }
                    else {
                        window.location.assign('Home.aspx');
                    }
                    //localStorage.setItem('MENU', data.MENU);
                    localStorage.setItem('COMPANY_ID', data.COMPANY_ID);
                    localStorage.setItem('BRANCH_ID', data.BRANCH_ID);
                    localStorage.setItem('CONTACT_ID', data.CONTACT_ID);
                    localStorage.setItem('COMPANY_LOGOPATH', data.COMPANY_LOGOPATH);
                    localStorage.setItem('BRANCH_LOGOPATH', data.BRANCH_LOGOPATH);
                    //localStorage.setItem('CONTACT_LOGOPATH', data.CONTACT_LOGOPATH);
                    localStorage.setItem('COMPANY_NAME', data.COMPANY_NAME);
                    localStorage.setItem('BRANCH_NAME', data.BRANCH_NAME);
                    localStorage.setItem('CONTACT_NAME', data.CONTACT_NAME);
                    localStorage.setItem('ROLEID', data.ROLEID);
                    //localStorage.setItem('CONTACT_TYPE', data.CONTACT_TYPE);

                    //if (data.CONTACT_TYPE == "COMPANY ADMIN") {
                    //    localStorage.setItem('MENU', '<li><a href="BranchList.aspx"><i class="fa fa-cog"></i><span>List of Locations</span></a></li>');                      
                    //}
                    //else if (data.CONTACT_TYPE == "SUPER ADMIN") {
                    //    localStorage.setItem('MENU', '<li><a href="CompanyList.aspx"><i class="fa fa-cog"></i><span>Company List</span></a></li>');                    
                    //}
                    //else {
                    localStorage.setItem('MENU', data.MENU);
                    //}


                    if (Result.d.PagePermission != "" && Result.d.PagePermission != undefined) {
                        localStorage.setItem('USERPERMISSIONS', Result.d.PagePermission);
                    }
                    else {
                        localStorage.setItem('USERPERMISSIONS', '');
                    }

                }
                else {
                    swal("", "Oops.. Someting Went wrong..!", "error");
                }
            }
        }
    });
}
function LoginSubmit() {
    if (validationchecklogin() == true) {

        setTimeout(function () {
            ht = {};
            ht["Email"] = $("#txtAccountNumber").val();
            ht["Password"] = $("#txtPassword").val();
            Req = "NormalLogin";
            obj = "Login";
            url = "Login.aspx/LoginDetails";
            LoadAjaxLogin(ht, obj, Req, url);
        }, 1000);
    }
}
function validationchecklogin() {

    if ($('#txtAccountNumber').val() == "") {
        alert("Login ID is required.");
        $('#txtAccountNumber').focus();
        return false;
    }
    if ($('#txtPassword').val() == "") {
        alert("Password is required.");
        $('#txtPassword').focus();
        return false;
    }

    return true;
}