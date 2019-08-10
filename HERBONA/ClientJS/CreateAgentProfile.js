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
        Req = 'Country@Sponsor@Placed';
        obj = "Fill";
        url = "CreateAgentProfile.aspx/ContactDetails";
        ht = {};
        LoadAjaxContact(ht, obj, Req, url);
    }
    else {
        $("#btnGetIDCard").show();
        $("#liSponsor").removeClass('disabledLI');
        $("#liBank").removeClass('disabledLI');
        $("#likyc").removeClass('disabledLI');
        $("#lirank").removeClass('disabledLI');
        $('#ID_hidden').val('' + cid);
        setTimeout(function () {
            Req = 'Country@Sponsor@Placed@FillPersonalDetails@FillSponsorDetails@FillbankDetails@FillAddressProof@FillBankProof@FillPAN@FillApplication@FillRankHistory';
            obj = "Fill";
            url = "CreateAgentProfile.aspx/ContactDetails";
            ht = {};
            ht["Contact_id"] = cid;
            LoadAjaxContact(ht, obj, Req, url);
        }, 2000);
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
$("#cmbSponsor_Name").change(function () {
    Req = 'Sponsor_Details';
    obj = "Sponsor_Details";
    url = "CreateAgentProfile.aspx/ContactDetails";
    ht = {};
    ht["id"] = $("#cmbSponsor_Name :selected").val();
    LoadAjaxContact(ht, obj, Req, url);
});
$("#cmbPlaced_Name").change(function () {
    Req = 'Placed_Details';
    obj = "Placed_Details";
    url = "CreateAgentProfile.aspx/ContactDetails";
    ht = {};
    ht["id"] = $("#cmbPlaced_Name :selected").val();
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
function SaveAgentPANCard() {
    if (validationcheckAgentPANProof() == true) {
        if ($('#f_UploadPAN_Card')[0].files[0] != undefined) {
            sendAgentPANCard();
            setTimeout(function () {
                $('#APAN_Link').show();
                $('#APAN_Link').attr("href", AgentPanCard);
            }, 500);
        }
        setTimeout(function () {
            ht = {};
            ht["PANCard_URL"] = $("#LogoPathPAN").val();
            if ($("#ID_hidden").val() == "") {
                swal("", "Please Fill Agent Personal Details First", "error");
            }
            else {
                ht["Contact_id"] = $("#ID_hidden").val();
                if ($("#ID_hidden_PANCardDetails").val() == "") {
                    ht["MODE"] = "INSERT";
                    Req = 'SavePAN';
                    obj = "SavePAN";
                    url = "CreateAgentProfile.aspx/ContactDetails";
                    LoadAjaxContact(ht, obj, Req, url);
                }
                else {
                    ht["MODE"] = "UPDATE";
                    Req = 'UpdatePAN';
                    obj = "UpdatePAN";
                    url = "CreateAgentProfile.aspx/ContactDetails";
                    LoadAjaxContact(ht, obj, Req, url);
                }
            }
        }, 1000);
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
                $("#LogoPathPAN").val("AgentDocument/" + status);
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
        setTimeout(function () {
            ht = {};
            ht["AppicationForm_URL"] = $("#LogoPathApplication").val();
            if ($("#ID_hidden").val() == "") {
                swal("", "Please Fill Agent Personal Details First", "error");
            }
            else {
                ht["Contact_id"] = $("#ID_hidden").val();
                if ($("#ID_hidden_ApplicationCardDetails").val() == "") {
                    ht["MODE"] = "INSERT";
                    Req = 'SaveApplication';
                    obj = "SaveApplication";
                    url = "CreateAgentProfile.aspx/ContactDetails";
                    LoadAjaxContact(ht, obj, Req, url);
                }
                else {
                    ht["MODE"] = "UPDATE";
                    Req = 'UpdateApplication';
                    obj = "UpdateApplication";
                    url = "CreateAgentProfile.aspx/ContactDetails";
                    LoadAjaxContact(ht, obj, Req, url);
                }
            }
        }, 1000);
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
                $("#LogoPathApplication").val("AgentDocument/" + status);
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

            if (obj == "Sponsor_Details") {
                $("#txtSponsor_Name").val("");
                $("#txtSponsor_MemberID").val("");
                $("#txtSponsor_Mobile_Number").val("");
                if (Result.d.Sponsor_Details != "" && Result.d.Sponsor_Details != undefined) {
                    var json = jQuery.parseJSON(Result.d.Sponsor_Details);
                    $.each(json, function (index, item) {
                        // alert(item.Account_Number);
                        $("#txtSponsor_Name").val(item.Name);
                        $("#txtSponsor_MemberID").val(item.MemberID);
                        $("#txtSponsor_Mobile_Number").val(item.MobileNo);
                    });
                }
            }
            if (obj == "Placed_Details") {
                $("#txtPlaced_Name").val("");
                $("#txtPlaced_MemberID").val("");
                $("#txtPlaced_Mobile_Number").val("");
                if (Result.d.Placed_Details != "" && Result.d.Placed_Details != undefined) {
                    var json = jQuery.parseJSON(Result.d.Placed_Details);
                    $.each(json, function (index, item) {
                        // alert(item.Account_Number);
                        $("#txtPlaced_Name").val(item.Name);
                        $("#txtPlaced_MemberID").val(item.MemberID);
                        $("#txtPlaced_Mobile_Number").val(item.MobileNo);
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

                if (Result.d.FillRankHistory != "" && Result.d.FillRankHistory != undefined) {
                    var data = jQuery.parseJSON(Result.d.FillRankHistory);
                    var table = '<table id="RankHistoryList" class="table table-bordered table-striped">';
                    table = table + '<thead><tr><th>Sno</th><th>Member ID</th><th>Name</th><th>Registration Date</th><th>Designation</th><th>Designation Date</th></tr></thead> <tbody>';
                    $.each(data, function (i, item) {
                        table = table + "<tr><td>" + item.Sno +
                                        "</td><td>" + item.Account_No +
                                        "</td><td>" + item.Name +
                                        "</td><td>" + item.Registration_Date +
                                        "</td><td>" + item.Designation +
                                        "</td><td>" + item.Designation_Date +
                                        "</td></tr>"
                    });
                    document.getElementById("RankHistoryListDiv").innerHTML = table + '</tbody></table>';
                    setTimeout(function () {
                        ShortTable('#RankHistoryList');
                    }, 100);
                }
                if (Result.d.Country != "" && Result.d.Country != undefined) {
                    var Country = jQuery.parseJSON(Result.d.Country);
                    $('#cmbCountry').html('');
                    $('#cmbCountry').append($('<option></option>'));
                    $.each(Country, function (index, item) {
                        $('#cmbCountry').append($('<option></option>').val(item.COUNTRY_ID).html(item.Name));
                    });
                    $("#cmbCountry").val(1).trigger('change');
                }

                if (Result.d.Sponsor != "" && Result.d.Sponsor != undefined) {
                    var Sponsor = jQuery.parseJSON(Result.d.Sponsor);
                    $('#cmbSponsor_Name').html('');
                    $('#cmbSponsor_Name').append($('<option></option>'));
                    $.each(Sponsor, function (index, item) {
                        $('#cmbSponsor_Name').append($('<option></option>').val(item.COUNTRY_ID).html(item.Name));
                    });
                }
                if (Result.d.Placed != "" && Result.d.Placed != undefined) {
                    var Placed = jQuery.parseJSON(Result.d.Placed);
                    $('#cmbPlaced_Name').html('');
                    $('#cmbPlaced_Name').append($('<option></option>'));
                    $.each(Placed, function (index, item) {
                        $('#cmbPlaced_Name').append($('<option></option>').val(item.COUNTRY_ID).html(item.Name));
                    });
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
                //if (Req == 'FillPersonalDetails') {
                if (Result.d.FillPersonalDetails != "" && Result.d.FillPersonalDetails != undefined) {
                    var json = jQuery.parseJSON(Result.d.FillPersonalDetails);
                    $("#btnAgentPersonalDetails").text("Update");
                    $.each(json, function (index, item) {

                        $("#ID_hidden").val(item.ID);
                        $("#txtName").val(item.Name);
                        $("#cmbGender").val(item.Gender).trigger('change');
                        $("#txtMobileNo").val(item.MobileNo);
                        $("#txtEmail").val(item.Email);
                        $("#cmbCountry").val(item.country_id).trigger('change');
                        setTimeout(function () {
                            $("#cmbState").val(item.state_id).trigger('change');
                        }, 1000);
                        setTimeout(function () {
                            $("#cmbDistrict").val(item.district_id).trigger('change');
                        }, 2000);
                        $("#txtAddress").val(item.Address);
                        $("#txtPinCode").val(item.pincode);
                        $('#selectimg').attr('src', "");
                        $('#LogoPath').val(item.ImageURL);
                        $('#txtDateOfBirth').val(item.DateOfBirth);
                        $('#selectimg').attr('src', '' + item.ImageURL + '');
                        if (item.ImageURL != "") {
                            $("#selectimg").show();
                        }

                    });
                    //}
                }

                //if (Req == 'FillSponsorDetails') {
                // alert(jQuery.parseJSON(Result.d.FillSponsorDetails));
                if (Result.d.FillSponsorDetails != "" && Result.d.FillSponsorDetails != undefined) {
                    var json = jQuery.parseJSON(Result.d.FillSponsorDetails);
                    if (json != "") {
                        $("#btnAgentSponsorDetails").text("Update");
                        $.each(json, function (index, item) {
                           
                            $("#ID_hidden_SponsorDetails").val(item.id);
                            $("#position").val(item.Placed_Team).trigger('change');
                            $("#cmbSponsor_Name").val(item.Sponsor_Contact_Id).trigger('change');
                            $("#cmbPlaced_Name").val(item.Placed_Contact_Id).trigger('change');
                           
                        });
                    }
                    //}
                }
                if (Result.d.FillbankDetails != "" && Result.d.FillbankDetails != undefined) {
                    var json = jQuery.parseJSON(Result.d.FillbankDetails);
                    if (json != "") {
                        $("#btnAgentBankDetails").text("Update");
                        $.each(json, function (index, item) {

                            $("#ID_hidden_BankDetails").val(item.id);
                            $("#txtAccountHolderName").val(item.Account_Holder_Name);
                            $("#txtAccountNumber").val(item.Account_Number);
                            $("#txtBank_Name").val(item.Bank_Name);
                            $("#cmbAccount_Type").val(item.Account_Type).trigger('change');
                            $("#txtIFSC_Code").val(item.IFSC_Code);
                            $("#txtBranch_Name").val(item.Branch_Name);
                            $("#txtPan_No").val(item.Pan_No);

                        });
                    }
                }
                if (Result.d.FillPAN != "" && Result.d.FillPAN != undefined) {
                    var json = jQuery.parseJSON(Result.d.FillPAN);
                    if (json != "") {
                        $("#btnSavePANCard").text("Update PAN Card");
                        $.each(json, function (index, item) {

                            $("#ID_hidden_PANCardDetails").val(item.id);
                            $('#APAN_Link').attr("href", "");
                            $('#LogoPathPAN').val(item.PANCard_URL);
                            $('#APAN_Link').attr("href", item.PANCard_URL);
                            if (item.PANCard_URL != "") {
                                $("#APAN_Link").show();
                            }
                        });
                    }
                }
                if (Result.d.FillApplication != "" && Result.d.FillApplication != undefined) {
                    var json = jQuery.parseJSON(Result.d.FillApplication);
                    if (json != "") {
                        $("#btnSaveAppication_Form").text("Update Application Form");
                        $.each(json, function (index, item) {
                            $("#ID_hidden_ApplicationCardDetails").val(item.id);
                            $('#AAppication_Form_Link').attr("href", "");
                            $('#LogoPathApplication').val(item.AppicationForm_URL);
                            $('#AAppication_Form_Link').attr("href", item.AppicationForm_URL);
                            if (item.AppicationForm_URL != "") {
                                $("#AAppication_Form_Link").show();
                            }
                        });
                    }
                }
                //if (Req == 'FillAddressProof') {
                if (Result.d.FillAddressProof != "" && Result.d.FillAddressProof != undefined) {
                    var data = jQuery.parseJSON(Result.d.FillAddressProof);
                    var table_Doc = "";
                    $.each(data, function (i, item) {

                        table_Doc = table_Doc + "<tr><td style='display:none' >" + item.id +
                                     "</td><td>" + item.Address_Proof_Type +
                                     "</td><td><a href=" + item.Address_Proof_URL + " target='_blank'>Download</a> " +
                     "</td><td style = 'display:none'>" + item.Address_Proof_URL +
                      "</td><td class='Edit " + _allowdelete + "' align='center'> <button type='button' onclick=AgentAddressProofDelet(this) class='btn btn-default btn-sm' id='btndelete_AgentAddressProof' > <span class='glyphicon glyphicon-trash'></span> </button></td>" +
                     "</tr>"

                    });



                    $("#adAddress_ProofListDiv tbody tr").remove()
                    setTimeout(function () {
                        $("#adAddress_ProofListDiv tbody").append(table_Doc);
                    }, 100);
                }
                //}
                //if (Req == 'FillBankProof') {
                if (Result.d.FillBankProof != "" && Result.d.FillBankProof != undefined) {
                    var data = jQuery.parseJSON(Result.d.FillBankProof);
                    var table_Doc1 = "";
                    $.each(data, function (i, item) {

                        table_Doc1 = table_Doc1 + "<tr><td style='display:none' >" + item.id +
                                     "</td><td>" + item.Bank_Proof_Type +
                                     "</td><td><a href=" + item.Bank_Proof_URL + " target='_blank'>Download</a> " +
                     "</td><td style = 'display:none'>" + item.Bank_Proof_URL +
                      "</td><td class='Edit " + _allowdelete + "' align='center'> <button type='button' onclick=AgentBankProofDelet(this) class='btn btn-default btn-sm' id='btndelete_AgentAddressProof' > <span class='glyphicon glyphicon-trash'></span> </button></td>" +
                     "</tr>"

                    });



                    $("#adBank_ProofListDiv tbody tr").remove()
                    setTimeout(function () {
                        $("#adBank_ProofListDiv tbody").append(table_Doc1);
                    }, 100);
                }
                //}
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
                        $("#liSponsor").removeClass('disabledLI');
                        $("#liBank").removeClass('disabledLI');
                        $("#likyc").removeClass('disabledLI');
                        $("#lirank").removeClass('disabledLI');
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

            if (obj == "SaveSponsor") {


                if (Result.d.SaveSponsor != "" && Result.d.SaveSponsor != undefined) {
                    var json = jQuery.parseJSON(Result.d.SaveSponsor)[0];

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
                        $("#ID_hidden_SponsorDetails").val(json.ID);
                        $("#btnAgentSponsorDetails").text('Update');
                        //});

                        setTimeout(function () {
                            Req = 'FillSponsorDetails';
                            obj = "Fill";
                            url = "CreateAgentProfile.aspx/ContactDetails";
                            ht = {};
                            ht["Contact_id"] = $("#ID_hidden").val();
                            LoadAjaxContact(ht, obj, Req, url);
                        }, 2000);
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

            if (obj == "UpdateSponsor") {


                if (Result.d.UpdateSponsor != "" && Result.d.UpdateSponsor != undefined) {
                    var json = jQuery.parseJSON(Result.d.UpdateSponsor)[0];

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

            if (obj == "SaveBank") {


                if (Result.d.SaveBank != "" && Result.d.SaveBank != undefined) {
                    var json = jQuery.parseJSON(Result.d.SaveBank)[0];

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
                        $("#btnGetIDCard").show();
                        $("#ID_hidden_BankDetails").val(json.ID);
                        $("#btnAgentBankDetails").text('Update');
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

            if (obj == "UpdateBank") {


                if (Result.d.UpdateBank != "" && Result.d.UpdateBank != undefined) {
                    var json = jQuery.parseJSON(Result.d.UpdateBank)[0];

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

            if (obj == "SavePAN") {


                if (Result.d.SavePAN != "" && Result.d.SavePAN != undefined) {
                    var json = jQuery.parseJSON(Result.d.SavePAN)[0];

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
                        $("#ID_hidden_PANCardDetails").val(json.ID);
                        $("#btnSavePANCard").text('Update PAN Card');
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

            if (obj == "UpdatePAN") {


                if (Result.d.UpdatePAN != "" && Result.d.UpdatePAN != undefined) {
                    var json = jQuery.parseJSON(Result.d.UpdatePAN)[0];

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

            if (obj == "SaveApplication") {


                if (Result.d.SaveApplication != "" && Result.d.SaveApplication != undefined) {
                    var json = jQuery.parseJSON(Result.d.SaveApplication)[0];

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
                        $("#ID_hidden_ApplicationCardDetails").val(json.ID);
                        $("#btnSaveAppication_Form").text('Update Application Form');
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

            if (obj == "UpdateApplication") {


                if (Result.d.UpdateApplication != "" && Result.d.UpdateApplication != undefined) {
                    var json = jQuery.parseJSON(Result.d.UpdateApplication)[0];

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
            ht["DateOfBirth"] = $("#txtDateOfBirth").val();


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
function AddNewAgentSponsorDetails() {
    if (validationcheck_SponsorDetails() == true) {
        setTimeout(function () {
            ht = {};
            ht["Sponsor_Contact_Id"] = $("#cmbSponsor_Name :selected").val();
            ht["Placed_Contact_Id"] = $("#cmbPlaced_Name :selected").val();
            ht["Placed_Team"] = $("#position :selected").val();

            if ($("#ID_hidden").val() == "") {
                swal("", "Please Fill Agent Personal Details First", "error");
            }
            else {
                ht["Contact_id"] = $("#ID_hidden").val();
                if ($("#ID_hidden_SponsorDetails").val() == "") {
                    ht["MODE"] = "INSERT";
                    Req = 'SaveSponsor';
                    obj = "SaveSponsor";
                    url = "CreateAgentProfile.aspx/ContactDetails";
                    LoadAjaxContact(ht, obj, Req, url);
                }
                else {
                    ht["MODE"] = "UPDATE";
                    Req = 'UpdateSponsor';
                    obj = "UpdateSponsor";
                    url = "CreateAgentProfile.aspx/ContactDetails";
                    LoadAjaxContact(ht, obj, Req, url);
                }
            }
        }, 1000);
    }
}
function validationcheck_SponsorDetails() {
    if ($('#cmbSponsor_Name').val() == "") {
        popupErrorMsg($("#cmbSponsor_Name"), "Please Select Sponsor.", 5);
        return false;
    }

    return true;
}

function AddNewAgentAgentBankDetails() {
    if (validationcheck_BankDetails() == true) {
        setTimeout(function () {
            ht = {};

            ht["Account_Holder_Name"] = $("#txtAccountHolderName").val();
            ht["Account_Number"] = $("#txtAccountNumber").val();
            ht["Bank_Name"] = $("#txtBank_Name").val();
            ht["Account_Type"] = $("#cmbAccount_Type :selected").val();
            ht["IFSC_Code"] = $("#txtIFSC_Code").val();
            ht["Branch_Name"] = $("#txtBranch_Name").val();
            ht["Pan_No"] = $("#txtPan_No").val();


            if ($("#ID_hidden").val() == "") {
                swal("", "Please Fill Agent Personal Details First", "error");
            }
            else {
                ht["Contact_id"] = $("#ID_hidden").val();
                if ($("#ID_hidden_BankDetails").val() == "") {
                    ht["MODE"] = "INSERT";
                    Req = 'SaveBank';
                    obj = "SaveBank";
                    url = "CreateAgentProfile.aspx/ContactDetails";
                    LoadAjaxContact(ht, obj, Req, url);
                }
                else {
                    ht["MODE"] = "UPDATE";
                    Req = 'UpdateBank';
                    obj = "UpdateBank";
                    url = "CreateAgentProfile.aspx/ContactDetails";
                    LoadAjaxContact(ht, obj, Req, url);
                }
            }
        }, 1000);
    }
}
function validationcheck_BankDetails() {
    if ($('#txtAccountHolderName').val() == "") {
        popupErrorMsg($("#txtAccountHolderName"), "Account Holder Name is Required.", 5);
        return false;
    }
    if ($('#txtAccountNumber').val() == "") {
        popupErrorMsg($("#txtAccountNumber"), "Account Number is Required.", 5);
        return false;
    }
    if ($('#txtBank_Name').val() == "") {
        popupErrorMsg($("#txtBank_Name"), "Bank Name is Required.", 5);
        return false;
    }
    if ($('#cmbAccount_Type :selected').val() == "") {
        popupErrorMsg($("#cmbAccount_Type"), "Account Type is Required.", 5);
        return false;
    }
    if ($('#txtIFSC_Code').val() == "") {
        popupErrorMsg($("#txtIFSC_Code"), "IFSC Code is Required.", 5);
        return false;
    }
    if ($('#txtBranch_Name').val() == "") {
        popupErrorMsg($("#txtBranch_Name"), "Branch Name is Required.", 5);
        return false;
    }
    return true;
}
function LoadAjaxAddressProoflist(ht, obj, Req, url, AddressProofList) {
    $('body').pleaseWait();

    $.ajax({
        type: "POST",
        url: url,
        data: "{ht:" + JSON.stringify(ht) + ",Type :'" + obj + "' ,Req :'" + Req + "'," +
            " AddressProofList:" + JSON.stringify(AddressProofList) +
            "}",
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

            if (obj == "SaveAddressProof") {
                if (Result.d.SaveAddressProof != "" && Result.d.SaveAddressProof != undefined) {
                    var json = jQuery.parseJSON(Result.d.SaveAddressProof)[0];

                    if (json.CustomErrorState == "0") {

                        swal({
                            title: "",
                            text: "Address Proofs Successfully Saved",
                            type: "success",
                            showCancelButton: false,
                            confirmButtonColor: "#5cb85c",
                            confirmButtonText: "Ok!",
                            closeOnConfirm: false,
                            timer: 2000
                        });
                        //function () {
                        //alert(json.ID);
                        FillAddressProofs();
                        //});

                        //FillAddressProofs();
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

function FillAddressProofs() {
    Req = 'FillAddressProof';
    obj = "Fill";
    url = "CreateAgentProfile.aspx/ContactDetails";
    ht = {};
    ht["Contact_id"] = $("#ID_hidden").val();
    LoadAjaxContact(ht, obj, Req, url);
}

function SaveAgentAddressProof() {
    if ($("#ID_hidden").val() == "") {
        swal("", "Please Fill Agent Personal Details First", "error");
    }
    else {
        //alert($('#adAddress_ProofList tbody tr').html());

        if ($('#adAddress_ProofList tbody tr').html() == undefined) {
            swal("", "Please Upload Address Proof To Save", "error");
        }
        else {
            var i = 0;
            AddressProofList = new Array();
            $('#adAddress_ProofList tbody tr').each(function () {
                var Address_Proof_Model = {};
                Address_Proof_Model.id = $(this).find('td:eq(0)').html();
                Address_Proof_Model.Contact_id = $("#ID_hidden").val();
                Address_Proof_Model.Address_Proof_Type = $(this).find('td:eq(1)').html();
                Address_Proof_Model.Address_Proof_URL = $(this).find('td:eq(3)').html();
                AddressProofList[i++] = Address_Proof_Model;
            });

            Req = 'SaveAddressProof';
            obj = "SaveAddressProof";
            url = "CreateAgentProfile.aspx/SaveAddressProofList";
            ht = {};
            ht["Contact_id"] = $("#ID_hidden").val();
            LoadAjaxAddressProoflist(ht, obj, Req, url, AddressProofList);
        }
    }
}

function LoadAjaxBankProoflist(ht, obj, Req, url, BankProofList) {
    $('body').pleaseWait();

    $.ajax({
        type: "POST",
        url: url,
        data: "{ht:" + JSON.stringify(ht) + ",Type :'" + obj + "' ,Req :'" + Req + "'," +
            " BankProofList:" + JSON.stringify(BankProofList) +
            "}",
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

            if (obj == "SaveBankProof") {
                if (Result.d.SaveBankProof != "" && Result.d.SaveBankProof != undefined) {
                    var json = jQuery.parseJSON(Result.d.SaveBankProof)[0];

                    if (json.CustomErrorState == "0") {

                        swal({
                            title: "",
                            text: "Bank Proofs Successfully Saved",
                            type: "success",
                            showCancelButton: false,
                            confirmButtonColor: "#5cb85c",
                            confirmButtonText: "Ok!",
                            closeOnConfirm: false,
                            timer: 2000
                        });
                        //function () {
                        //alert(json.ID);
                        FillBankProofs();
                        //});

                        //FillAddressProofs();
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

function FillBankProofs() {
    Req = 'FillBankProof';
    obj = "Fill";
    url = "CreateAgentProfile.aspx/ContactDetails";
    ht = {};
    ht["Contact_id"] = $("#ID_hidden").val();
    LoadAjaxContact(ht, obj, Req, url);
}

function SaveAgentBankProof() {
    if ($("#ID_hidden").val() == "") {
        swal("", "Please Fill Agent Personal Details First", "error");
    }
    else {
        //alert($('#adAddress_ProofList tbody tr').html());

        if ($('#Bank_ProofList tbody tr').html() == undefined) {
            swal("", "Please Upload Bank Proof To Save", "error");
        }
        else {
            var i = 0;
            BankProofList = new Array();
            $('#Bank_ProofList tbody tr').each(function () {
                var Bank_Proof_Model = {};
                Bank_Proof_Model.id = $(this).find('td:eq(0)').html();
                Bank_Proof_Model.Contact_id = $("#ID_hidden").val();
                Bank_Proof_Model.Bank_Proof_Type = $(this).find('td:eq(1)').html();
                Bank_Proof_Model.Bank_Proof_URL = $(this).find('td:eq(3)').html();
                BankProofList[i++] = Bank_Proof_Model;
            });

            Req = 'SaveBankProof';
            obj = "SaveBankProof";
            url = "CreateAgentProfile.aspx/SaveBankProofList";
            ht = {};
            ht["Contact_id"] = $("#ID_hidden").val();
            LoadAjaxBankProoflist(ht, obj, Req, url, BankProofList);
        }
    }
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

function GetIDCard() {
    //alert($('#ID_hidden').val());
    var bt = btoa("cid=" + $('#ID_hidden').val() + "");
    //  window.location = 'AgentID_Card.aspx?' + bt;
    window.open('Agent_ID_Card.aspx?' + bt, '_blank');
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











