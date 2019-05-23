/// <reference path="C:\Users\Satyam-PC\Documents\Visual Studio 2015\Projects\SmartTrucking\SmartTrucking\CompanyList.aspx" />
var ht = {};
var Req = "";
var obj = "";
var Procedure = "";
var Action = "";
var AgentAddressproof = "", AgentPanCard = "", AgentBankproof = "", AgentApplicationForm = "";
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

    if (cid == undefined) {
        Req = 'Country';
        obj = "Fill";
        url = "CreateAgentProfile.aspx/ContactDetails";
        ht = {};
        LoadAjaxContact(ht, obj, Req, url);
    }
    else {
        $('#ID_hidden').val('' + cid);
        Req = 'Country@Edit';
        obj = "Fill";
        url = "CreateAgentProfile.aspx/ContactDetails";
        ht = {};
        ht["ID"] = cid;
        LoadAjaxContact(ht, obj, Req, url);
    }
});
$("#cmbCountry").change(function () {
    Req = 'State';
    obj = "State";
    url = "CreateAgentProfile.aspx/ContactDetails";
    ht = {};
    ht["COUNTRY_ID"] = $("#cmbCountry :selected").val();
    LoadAjaxContact(ht, obj, Req, url);
});
$("#cmbState").change(function () {
    Req = 'District';
    obj = "District";
    url = "CreateAgentProfile.aspx/ContactDetails";
    ht = {};
    ht["State_ID"] = $("#cmbState :selected").val();
    LoadAjaxContact(ht, obj, Req, url);
});
function UploadAddress_Proof() {
    if (validationcheckAgentAddressProof() == true) {
        if ($('#f_UploadAddress_Proof')[0].files[0] != undefined) {
            sendAgentAddressproof();
        }

        setTimeout(function () {
            ht = {};

            ht["DocType"] = $("#cmbAddressProof_Type :selected").val();
            ht["DocUpload"] = AgentAddressproof;

            var table = "";

            table = table + "<tr><td style='display:none' >" + 0 +
                            "</td><td>" + ht["DocType"] +
                            "</td><td><a href=" + ht["DocUpload"] + " target='_blank'>Download</a> " +
            "</td><td style = 'display:none'>" + ht["DocUpload"] +
             "</td><td class='Edit " + _allowdelete + "' align='center'> <button type='button' onclick=AgentAddressProofDelet(this) class='btn btn-default btn-sm' id='btndelete_AgentAddressProof' > <span class='glyphicon glyphicon-trash'></span> </button></td>" +
            "</tr>"

            $("#adAddress_ProofListDiv tbody tr .dataTables_empty").parents('tr').remove()
            $("#adAddress_ProofListDiv tbody").append(table);

            $("#cmbAddressProof_Type").val("").trigger('change');
            $('#f_UploadAddress_Proof').val("");

        }, 500);
    }
}
function sendAgentAddressproof() {

    var formData = new FormData();
    formData.append('file', $('#f_UploadAddress_Proof')[0].files[0]);
    $.ajax({
        type: 'post',
        url: 'AgentDocUploadHandler.ashx',
        data: formData,
        success: function (status) {
            if (status != 'error') {
                AgentAddressproof = "AgentDocument/" + status;
            }
        },
        processData: false,
        contentType: false,
        error: function () {
            alert("Error saving image");
        }
    });
}
function AgentAddressProofDelet(e) {
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
    $(e).parents('tr').remove();
});
}
function validationcheckAgentAddressProof() {
    if ($('#cmbAddressProof_Type').val() == "" || $('#cmbAddressProof_Type').val() == null) {
        popupErrorMsg($("#cmbAddressProof_Type"), "Select Address Proof Type.", 5);

        return false;
    }

    if ($('#f_UploadAddress_Proof').val() == "" || $('#f_UploadAddress_Proof').val() == null) {
        popupErrorMsg($("#f_UploadAddress_Proof"), "Please Select a file to Upload.", 5);

        return false;
    }
    return true;
}
function SaveAgentPANCard()
{
    if (validationcheckAgentPANProof() == true) {
        if ($('#f_UploadPAN_Card')[0].files[0] != undefined) {
            sendAgentPANCard();
            setTimeout(function () {
            $('#APAN_Link').show();
            $('#APAN_Link').attr("href", AgentPanCard);
            }, 500);
        }
    }

}
function validationcheckAgentPANProof() {

    if ($('#f_UploadPAN_Card').val() == "" || $('#f_UploadPAN_Card').val() == null) {
        popupErrorMsg($("#f_UploadPAN_Card"), "Please Select a file to Upload.", 5);

        return false;
    }
    return true;
}
function sendAgentPANCard() {

    var formData = new FormData();
    formData.append('file', $('#f_UploadPAN_Card')[0].files[0]);
    $.ajax({
        type: 'post',
        url: 'AgentDocUploadHandler.ashx',
        data: formData,
        success: function (status) {
            if (status != 'error') {
                AgentPanCard = "AgentDocument/" + status;
            }
        },
        processData: false,
        contentType: false,
        error: function () {
            alert("Error saving image");
        }
    });
}
function UploadBank_Proof() {
    if (validationcheckAgentBankProof() == true) {
        if ($('#f_UploadBank_Proof')[0].files[0] != undefined) {
            sendAgentBankproof();
        }

        setTimeout(function () {
            ht = {};

            ht["DocType"] = $("#cmbBankProof_Type :selected").val();
            ht["DocUpload"] = AgentBankproof;

            var table = "";

            table = table + "<tr><td style='display:none' >" + 0 +
                            "</td><td>" + ht["DocType"] +
                            "</td><td><a href=" + ht["DocUpload"] + " target='_blank'>Download</a> " +
            "</td><td style = 'display:none'>" + ht["DocUpload"] +
             "</td><td class='Edit " + _allowdelete + "' align='center'> <button type='button' onclick=AgentBankProofDelet(this) class='btn btn-default btn-sm' id='btndelete_AgentBankProof' > <span class='glyphicon glyphicon-trash'></span> </button></td>" +
            "</tr>"

            $("#adBank_ProofListDiv tbody tr .dataTables_empty").parents('tr').remove()
            $("#adBank_ProofListDiv tbody").append(table);

            $("#cmbBankProof_Type").val("").trigger('change');
            $('#f_UploadBank_Proof').val("");

        }, 500);
    }
}
function sendAgentBankproof() {

    var formData = new FormData();
    formData.append('file', $('#f_UploadBank_Proof')[0].files[0]);
    $.ajax({
        type: 'post',
        url: 'AgentDocUploadHandler.ashx',
        data: formData,
        success: function (status) {
            if (status != 'error') {
                AgentBankproof = "AgentDocument/" + status;
            }
        },
        processData: false,
        contentType: false,
        error: function () {
            alert("Error saving image");
        }
    });
}
function AgentBankProofDelet(e) {
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
    $(e).parents('tr').remove();
});
}
function validationcheckAgentBankProof() {
    if ($('#cmbBankProof_Type').val() == "" || $('#cmbBankProof_Type').val() == null) {
        popupErrorMsg($("#cmbBankProof_Type"), "Select Bank Proof Type.", 5);

        return false;
    }

    if ($('#f_UploadBank_Proof').val() == "" || $('#f_UploadBank_Proof').val() == null) {
        popupErrorMsg($("#f_UploadBank_Proof"), "Please Select a file to Upload.", 5);

        return false;
    }
    return true;
}

function SaveAgentAppication_Form() {
    if (validationcheckAgentAppication_Form() == true) {
        if ($('#f_UploadAppication_Form')[0].files[0] != undefined) {
            sendAgentAppication_Form();
            setTimeout(function () {
                $('#AAppication_Form_Link').show();
                $('#AAppication_Form_Link').attr("href", AgentApplicationForm);
            }, 500);
        }
    }

}
function validationcheckAgentAppication_Form() {

    if ($('#f_UploadAppication_Form').val() == "" || $('#f_UploadAppication_Form').val() == null) {
        popupErrorMsg($("#f_UploadAppication_Form"), "Please Select a file to Upload.", 5);

        return false;
    }
    return true;
}
function sendAgentAppication_Form() {

    var formData = new FormData();
    formData.append('file', $('#f_UploadAppication_Form')[0].files[0]);
    $.ajax({
        type: 'post',
        url: 'AgentDocUploadHandler.ashx',
        data: formData,
        success: function (status) {
            if (status != 'error') {
                AgentApplicationForm = "AgentDocument/" + status;
            }
        },
        processData: false,
        contentType: false,
        error: function () {
            alert("Error saving image");
        }
    });
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
                if (Result.d.State != "" && Result.d.State != undefined) {
                    var State = jQuery.parseJSON(Result.d.State);
                    $('#cmbState').html('');
                    $('#cmbState').append($('<option></option>'));
                    $.each(State, function (index, item) {
                        $('#cmbState').append($('<option></option>').val(item.COUNTRY_ID).html(item.Name));
                    });
                }

                //EDIT MAPPING

                if (Result.d.ContactData != "" && Result.d.ContactData != undefined) {
                    var json = jQuery.parseJSON(Result.d.ContactData);
                    $("#btnupdate").text("Update");

                    $.each(json, function (index, item) {
                      
                        $("#ID_hidden").val(item.ID);
                        $("#txtName").val(item.Name);
                        //  $("#cmbRole").val(item.RoleId);
                        $("#cmbRole option").each(function () {
                            if ($(this).val().trim() == item.RName) {
                                $(this).attr("selected", "selected");
                                $(this).prop('selected', true).trigger('change');
                            }
                        });
                        $("#cmbRole").attr('disabled', 'true');
                        $("#txtMobileNo").val(item.MobileNo);
                        $("#txtPhoneNo").val(item.PhoneNo);
                        $("#txtEmail").val(item.Email);
                       // $('#txtPassword').val("............");
                      //  $('#txtPassword').attr('readonly', 'true');
                        $("#txtCity").val(item.City);
                       // $("#txtType").val(item.Type);
                        $("#txtAddress").val(item.Address);
                        $("#txtWebsite").val(item.WebsiteUrl);


                        $("#cmbCountry option").each(function () {
                            if ($(this).val().trim() == item.Country) {
                                $(this).attr("selected", "selected");
                                $(this).prop('selected', true).trigger('change');
                            }
                        });
                        setTimeout(function () {
                            $("#cmbState option").each(function () {
                                if ($(this).val().trim() == item.State.trim()) {
                                    $(this).attr("selected", "selected");
                                    $(this).prop('selected', true).trigger('change');
                                }
                            });
                        }, 1000);


                        $('#selectimg').attr('src', "");
                        $('#LogoPath').val(item.LogoPath);
                        //alert(item.Logo);                    
                        $('#selectimg').attr('src', '' + item.LogoPath + '');
                        if (item.LogoPath != "") {
                            $("#selectimg").show();
                        }

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
                        });
                         //function () {
                             //alert(json.ID);
                             $("#ID_hidden").val(json.ID);
                             $("#btnAgentPersonalDetails").text('Update');
                         //});

                       
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

function AddNewAgentPresonalDetails() {

    if (validationcheck() == true) {

        if ($('#f_Uploadfile')[0].files[0] != undefined) {
            sendFile();
        }

        setTimeout(function () {
            ht = {};
            
            ht["Name"] = $("#txtName").val();
            ht["Gender"] = $("#cmbGender :selected").val();
            ht["MobileNo"] = $("#txtMobileNo").val();
            ht["Email"] = $("#txtEmail").val();
            ht["ImageURL"] = $("#LogoPath").val();

            ht["country_id"] = $("#cmbCountry :selected").val();
            ht["state_id"] = $("#cmbState :selected").val();
            ht["district_id"] = $("#cmbDistrict :selected").val();

            ht["addressline"] = $("#txtAddress").val();
            ht["pincode"] = $("#txtPinCode").val();
          
        
            if ($("#ID_hidden").val() == "") {
                ht["MODE"] = "INSERT";
                Req = 'Save';
                obj = "Save";
                url = "CreateAgentProfile.aspx/ContactDetails";
                LoadAjaxContact(ht, obj, Req, url);
            }
            else {
                ht["ID"] = $("#ID_hidden").val();
                ht["MODE"] = "UPDATE";
                Req = 'Update';
                obj = "Update";
                url = "CreateAgentProfile.aspx/ContactDetails";
                LoadAjaxContact(ht, obj, Req, url);
            }
        }, 1000);
    }
}

function validationcheck() {
    if ($('#txtName').val() == "") {
        popupErrorMsg($("#txtName"), "Agent Name is required.", 5);
        return false;
    }
    if ($('#cmbGender :selected').val() == "") {
        popupErrorMsg($("#cmbGender"), "Please Select Gender.", 5);
        return false;
    }
    if ($('#txtEmail').val() == "") {
        popupErrorMsg($("#txtEmail"), "Valid Email ID is Required.", 5);
        return false;
    }

    var reg = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (!reg.test($("#txtEmail").val())) {
        popupErrorMsg($("#txtEmail"), "Enter a Valid Email ID.", 5);
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


$("#f_Uploadfile").on('change', function () {
    readURL(this);
});

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $("#selectimg").attr("src", e.target.result);
            $("#selectimg").show();
        }
        reader.readAsDataURL(input.files[0]);
    }
}

function sendFile() {
    var formData = new FormData();
    formData.append('file', $('#f_Uploadfile')[0].files[0]);
    $.ajax({
        type: 'post',
        url: 'ImageUploadHandlerContact.ashx',
        data: formData,
        success: function (status) {
            if (status != 'error') {
                $("#LogoPath").val("ContactLogo/" + status); // id comming from html page             
            }
        },
        processData: false,
        contentType: false,
        error: function () {
            alert("Error saving image");
        }
    });
}















