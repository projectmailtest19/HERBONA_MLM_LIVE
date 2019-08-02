var ht = {};
var Req = "";
var obj = "";
var Procedure = "";
var Action = "";

$(document).ready(function () {
    localStorage.clear();

});

function fillfunction()
{
    setTimeout(function () {
    Req = 'Country@Sponsor';
    obj = "Fill";
    url = "Signup.aspx/LoginDetails";
    ht = {};
    ht["Company_ID"] = $("#Company_ID_hidden").val();
    ht["Branch_ID"] = $("#Branch_ID_hidden").val();
    LoadAjaxLogin(ht, obj, Req, url);
    }, 1000);
}
function StateFill() {
    Req = 'State';
    obj = "State";
    url = "Signup.aspx/LoginDetails";
    ht = {};
    ht["COUNTRY_ID"] = $("#cmbCountry :selected").val();
    LoadAjaxLogin(ht, obj, Req, url);
}
function DistrictFill(){
    Req = 'District';
    obj = "District";
    url = "Signup.aspx/LoginDetails";
    ht = {};
    ht["State_ID"] = $("#cmbState :selected").val();
    LoadAjaxLogin(ht, obj, Req, url);
}
function NextSubmit2() {
    if (validationcheckQuickAgentInsert() == true) {
        //   swal("Conguratulation", "Account successfully created !", "success");

        setTimeout(function () {
            ht = {};

            ht["Name"] = $("#txtFullName").val();
            ht["DOB"] = $("#txtDOB").val();
            ht["MobileNo"] = $("#txtPhoneNumber").val();
            ht["Email"] = $("#txtEmailID").val();

            ht["country_id"] = $("#cmbCountry :selected").val();
            ht["state_id"] = $("#cmbState :selected").val();
            ht["district_id"] = $("#cmbDistrict :selected").val();
            ht["pincode"] = $("#txtPINCode").val();
            ht["Sponsor_Member_ID"] = $("#txtSponsorAccountNumber").val();
            ht["Placed_ID"] = $("#cmbSponsor_Name :selected").val();
            ht["Team"] = $("#position :selected").val();
                Req = 'Save';
                obj = "Save";
                url = "Signup.aspx/LoginDetails";
                LoadAjaxLogin(ht, obj, Req, url);
        }, 1000);

    }
}
function validationcheckQuickAgentInsert() {

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
    if ($("#cmbCountry :selected").val() == "") {
        popupErrorMsg($("#cmbCountry"), "Country is required.", 5);
        return false;
    }
    if ($("#cmbState :selected").val() == "") {
        popupErrorMsg($("#cmbState"), "State is required.", 5);
        return false;
    }
    if ($("#cmbDistrict :selected").val() == "") {
        popupErrorMsg($("#cmbDistrict"), "District is required.", 5);
        return false;
    }
    if ($("#txtPINCode").val() == "") {
        popupErrorMsg($("#txtPINCode"), "PIN is required.", 5);
        return false;
    }
    if ($("#cmbSponsor_Name :selected").val() == "") {
        popupErrorMsg($("#cmbSponsor_Name"), "Placed Member is required.", 5);
        return false;
    }
    if ($("#position :selected").val() == "") {
        popupErrorMsg($("#position"), "Position is required.", 5);
        return false;
    }

    return true;
}
function NextSubmit1() {
    if ($("#txtSponsorAccountNumber").val() == "") {
        popupErrorMsg($("#txtSponsorAccountNumber"), "Please Enter Sponsor ID.", 5);
        return false;
    }
   
    //setTimeout(function () {
    ht = {};
    ht["MemberID"] = $("#txtSponsorAccountNumber").val();
    Req = "Sopnsorname";
    obj = "Sopnsorname";
    url = "Signup.aspx/LoginDetails";
    LoadAjaxLogin(ht, obj, Req, url);
    //}, 1000);

   
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
    $('body').pleaseWait();
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
                    //setTimeout(function () {
                        $("#cmbCountry").val(1).trigger('change');
                    //}, 500);
                }

                if (Result.d.Sponsor != "" && Result.d.Sponsor != undefined) {
                    var Sponsor = jQuery.parseJSON(Result.d.Sponsor);
                    $('#cmbSponsor_Name').html('');
                    $('#cmbSponsor_Name').append($('<option></option>'));
                    $.each(Sponsor, function (index, item) {
                        $('#cmbSponsor_Name').append($('<option></option>').val(item.COUNTRY_ID).html(item.Name));
                    });
                }
            }
            if (obj == "Sopnsorname") {
                if (Result.d.Sopnsor != "" && Result.d.Sopnsor != undefined) {
                    var json = jQuery.parseJSON(Result.d.Sopnsor);
                    if (json != "") {
                        $.each(json, function (index, item) {
                            $("#hSponsrName").text('Sponsor Name: ' + item.name);
                            $("#Company_ID_hidden").val(item.Company_ID);
                            $("#Branch_ID_hidden").val(item.Branch_ID);
                        });
                        $("#1Div").hide();
                        $("#2Div").show();
                        fillfunction();
                    }
                    else
                    {
                        alert("Invalid Sponsor Id");
                      
                    }

                }
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

            if (obj == "Save") {


                if (Result.d.Save != "" && Result.d.Save != undefined) {
                    var json = jQuery.parseJSON(Result.d.Save)[0];

                    if (json.CustomErrorState == "0") {

                        //swal({
                        //    title: "",
                        //    text: json.CustomMessage,
                        //    type: "success",
                        //    showCancelButton: false,
                        //    confirmButtonColor: "#5cb85c",
                        //    confirmButtonText: "Ok!",
                        //    closeOnConfirm: false,
                        //    timer: 2000
                        //});

                        $('#LblAccountNumber').text(json.Account_Number);
                        $('#Lblname').text(json.Name);
                        $('#lblMobNUM').text(json.MobileNo);
                        $('#lblEmailAddress').text(json.Email);
                        $("#SuccessPopupModel").modal({ backdrop: "static" });



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

    $('body').pleaseWait('stop');
}

function Pagerefresh() {
    location.reload();
}
function LoginSubmit() {
    if (validationchecklogin() == true) {

        setTimeout(function () {
            ht = {};
            ht["Email"] = $("#txtAccountNumber").val();
            ht["Password"] = $("#txtPassword").val();
            Req = "NormalLogin";
            obj = "Login";
            url = "Signup.aspx/LoginDetails";
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