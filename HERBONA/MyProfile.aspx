<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="SmartTrucking.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .disabledLI {
            pointer-events: none;
            opacity: 0.6;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Main content -->
    <section class="content">

        <div class="row">
            <div class="box-header">
                <h3 class="box-title"><b>My Profile</b></h3>
            </div>
            <div class="col-md-3">

                <!-- Profile Image -->
                <div class="box box-primary">
                    <div class="box-body box-profile">
                        <img id="selectimg" class="profile-user-img img-responsive img-circle" alt="User profile picture" style="display: none;">

                        <h3 class="profile-username text-center" id="lblAgentname"></h3>

                        <p class="text-muted text-center">Browse Profile Picture</p>
                        <div class="col-lg-8">
                            <input type="file" id="f_Uploadfile" />
                        </div>

                        <button type="button" id="btnGetIDCard" class="btn btn-primary btn-block" onclick="GetIDCard()" style="margin-top: 50px; display: none;">Get Your ID Card</button>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->


            </div>
            <!-- /.col -->
            <div class="col-md-9">
                <div class="nav-tabs-custom">
                    <ul class="nav nav-tabs">

                        <li class="active"><a href="#Personal_Details" data-toggle="tab">Personal Details</a></li>
                        <li id="liSponsor" class="disabledLI" ><a href="#Sponsor_Details" data-toggle="tab">Sponsor Details</a></li>
                        <li id="liBank" class="disabledLI"><a href="#Bank_Details" data-toggle="tab">Bank Details</a></li>
                        <li id="likyc" class="disabledLI"><a href="#KYC_Details" data-toggle="tab">KYC Details</a></li>
                        <li id="lirank" class="disabledLI"><a href="#Rank_History" data-toggle="tab">Rank History</a></li>
                    </ul>
                    <div class="tab-content">
                        <form class="form-horizontal">
                        </form>
                        <div class="active tab-pane" id="Personal_Details">
                            <form class="form-horizontal">
                                <h4 class="box-title" style="color: cornflowerblue">(i). Personal Details</h4>
                                <div class="form-group">
                                    <label for="inputName" class="col-sm-3 control-label">Name<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                        <input id="txtName" class="form-control" type="text" placeholder="Agent's Name" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputCountry" class="col-sm-3 control-label">Gender<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                        <select class="form-control select2" id="cmbGender" style="width: 100%;" data-placeholder="Select Gender">
                                            <option></option>
                                            <option value="Male">Male</option>
                                            <option value="Female">Female</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputMob" class="col-sm-3 control-label">Mobile Number</label>

                                    <div class="col-sm-9">
                                        <input id="txtMobileNo" class="form-control" type="number" placeholder="Cell No." />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputemail" class="col-sm-3 control-label">Email<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                        <input id="txtEmail" class="form-control" type="email" placeholder="Email ID" />
                                    </div>
                                </div>
                                <h4 class="box-title" style="padding-top: 20px; color: cornflowerblue">(ii). Address Details</h4>
                                <div class="form-group">
                                    <label for="inputCountry" class="col-sm-3 control-label">Country<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                        <select class="form-control select2" id="cmbCountry" style="width: 100%;" data-placeholder="Select Country" disabled="disabled">
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputState" class="col-sm-3 control-label">State<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                        <select id="cmbState" class="form-control select2" style="width: 100%;" data-placeholder="Select State">
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputState" class="col-sm-3 control-label">District<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                        <select id="cmbDistrict" class="form-control select2" style="width: 100%;" data-placeholder="Select District">
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputAddress" class="col-sm-3 control-label">Full Address</label>

                                    <div class="col-sm-9">
                                        <textarea id="txtAddress" class="form-control" rows="3" placeholder="Enter  Address..."></textarea>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputCity" class="col-sm-3 control-label">Pincode</label>

                                    <div class="col-sm-9">
                                        <input id="txtPinCode" class="form-control" type="number" placeholder="Enter PIN Code" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-3 col-sm-9">
                                        <button type="button" id="btnAgentPersonalDetails" class="btn btn-success" onclick="AddNewAgentPresonalDetails()">Save</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                        <div class="tab-pane" id="Sponsor_Details">
                            <form class="form-horizontal">
                                <div class="form-group">
                                    <label for="inputCountry" class="col-sm-3 control-label">Sponsor Name<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                       <select id="cmbSponsor_Name" class="form-control select2" style="width: 100%;" data-placeholder="Select Sponsor">
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputName" class="col-sm-3 control-label">Sponsor Account No.<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                        <input id="txtSponsor_Account_No" class="form-control" type="text" placeholder="Sponsor Account No." disabled />
                                    </div>
                                </div>
                                
                                <div class="form-group">
                                    <label for="inputMob" class="col-sm-3 control-label">Sponsor MemberID</label>

                                    <div class="col-sm-9">
                                        <input id="txtSponsor_MemberID" class="form-control" type="text" placeholder="Sponsor MemberID" disabled/>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputemail" class="col-sm-3 control-label">Sponsor Mobile Number</label>

                                    <div class="col-sm-9">
                                        <input id="txtSponsor_Mobile_Number" class="form-control" type="text" placeholder="Sponsor Mobile Number" disabled/>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputCountry" class="col-sm-3 control-label">Placed Name</label>

                                    <div class="col-sm-9">
                                        <input id="txtPlaced_Name" class="form-control" type="text" placeholder="Placed Name" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputState" class="col-sm-3 control-label">Placed MemberID</label>

                                    <div class="col-sm-9">
                                        <input id="txtPlaced_MemberID" class="form-control" type="text" placeholder="Placed MemberID" disabled/>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputState" class="col-sm-3 control-label">Placed Team</label>

                                    <div class="col-sm-9">
                                        <input id="txtPlaced_Team" class="form-control" type="text" placeholder="Placed Team" disabled/>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputCountry" class="col-sm-3 control-label">Split Sponsor Name<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                        <select id="cmbSplitSponsor_Name" class="form-control select2" style="width: 100%;" data-placeholder="Select Split Sponsor">
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-3 col-sm-9">
                                        <button type="button" id="btnAgentSponsorDetails" class="btn btn-success" onclick="AddNewAgentSponsorDetails()">Save</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                        <div class="tab-pane" id="Bank_Details">
                            <form class="form-horizontal">
                                <div class="form-group">
                                    <label for="inputName" class="col-sm-3 control-label">A/c Holder Name<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                        <input id="txtAccountHolderName" class="form-control" type="text" placeholder="A/c Holder Name" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputCountry" class="col-sm-3 control-label">A/c Number<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                        <input id="txtAccountNumber" class="form-control" type="text" placeholder="A/c Number" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputMob" class="col-sm-3 control-label">Bank Name<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                        <input id="txtBank_Name" class="form-control" type="text" placeholder="Bank Name" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputemail" class="col-sm-3 control-label">A/c Type<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                        <select class="form-control select2" id="cmbAccount_Type" style="width: 100%;" data-placeholder="Select A/c Type">
                                            <option></option>
                                            <option value="Savings">Savings</option>
                                            <option value="Current">Current</option>
                                            <option value="Salary">Salary</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputCountry" class="col-sm-3 control-label">IFSC Code<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                        <input id="txtIFSC_Code" class="form-control" type="text" placeholder="IFSC Code" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputState" class="col-sm-3 control-label">Branch Name<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                        <input id="txtBranch_Name" class="form-control" type="text" placeholder="Branch Name" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputState" class="col-sm-3 control-label">Pan No</label>

                                    <div class="col-sm-9">
                                        <input id="txtPan_No" class="form-control" type="text" placeholder="Pan No" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-3 col-sm-9">
                                        <button type="button" id="btnAgentBankDetails" class="btn btn-success" onclick="AddNewAgentAgentBankDetails()">Save</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                        <div class="tab-pane" id="KYC_Details">
                            <form class="form-horizontal">
                                <h4 class="box-title" style="color: cornflowerblue">(i). Address Proof</h4>
                                <div class="form-group">
                                    <label for="inputName" class="col-sm-3 control-label">Address Proof Type<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                        <select class="form-control select2" id="cmbAddressProof_Type" style="width: 100%;" data-placeholder="Select Address Proof Type">
                                            <option></option>
                                            <option value="Aadhar Card">Aadhar Card</option>
                                            <option value="Voter ID">Voter ID</option>
                                            <option value="Ration Card">Ration Card</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputCountry" class="col-sm-3 control-label">Upload Address Proof<span class="reqstar">*</span></label>

                                    <div class="col-sm-6">
                                        <input type="file" id="f_UploadAddress_Proof" />
                                    </div>
                                    <div class="col-sm-3">
                                        <button type="button" id="btnUploadAddress_Proof" class="btn btn-block btn-info" onclick="UploadAddress_Proof()">Upload</button>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-3">
                                    </div>
                                    <div class="col-sm-9" id="adAddress_ProofListDiv">
                                        <table id="adAddress_ProofList" class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th style="display: none">ID</th>
                                                    <th>Type</th>
                                                    <th>Download</th>
                                                    <th style="display: none">Url</th>
                                                    <th class=' + _allowdelete + '>Delete</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-3 col-sm-9">
                                        <button type="button" id="btnSaveAgentAddressProof" class="btn btn-success" onclick="SaveAgentAddressProof()">Save Address Proofs</button>
                                    </div>
                                </div>
                                <h4 class="box-title" style="padding-top: 20px; color: cornflowerblue">(ii). PAN Card</h4>
                                <div class="form-group">
                                    <label for="inputCountry" class="col-sm-3 control-label">Upload PAN Card<span class="reqstar">*</span></label>

                                    <div class="col-sm-6">
                                        <input type="file" id="f_UploadPAN_Card" />
                                    </div>
                                    <div class="col-sm-3">
                                        <a id="APAN_Link" target="_blank" href="" hidden="hidden">View Uploaded PAN Card</a>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-3 col-sm-9">
                                        <button type="button" id="btnSavePANCard" class="btn btn-success" onclick="SaveAgentPANCard()">Save PAN Card</button>
                                    </div>
                                </div>
                                <h4 class="box-title" style="padding-top: 20px; color: cornflowerblue">(iii). Bank Proof</h4>
                                <div class="form-group">
                                    <label for="inputName" class="col-sm-3 control-label">Bank Proof Type<span class="reqstar">*</span></label>

                                    <div class="col-sm-9">
                                        <select class="form-control select2" id="cmbBankProof_Type" style="width: 100%;" data-placeholder="Select Bank Proof Type">
                                            <option></option>
                                            <option value="Pass Book">Pass Book</option>
                                            <option value="Cheque">Cheque</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputCountry" class="col-sm-3 control-label">Upload Bank Proof<span class="reqstar">*</span></label>

                                    <div class="col-sm-6">
                                        <input type="file" id="f_UploadBank_Proof" />
                                    </div>
                                    <div class="col-sm-3">
                                        <button type="button" id="btnUploadBank_Proof" class="btn btn-block btn-info" onclick="UploadBank_Proof()">Upload</button>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-3">
                                    </div>
                                    <div class="col-sm-9" id="adBank_ProofListDiv">
                                        <table id="Bank_ProofList" class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th style="display: none">ID</th>
                                                    <th>Type</th>
                                                    <th>Download</th>
                                                    <th style="display: none">Url</th>
                                                    <th class=' + _allowdelete + '>Delete</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-3 col-sm-9">
                                        <button type="button" id="btnSaveAgentBankProof" class="btn btn-success" onclick="SaveAgentBankProof()">Save Bank Proofs</button>
                                    </div>
                                </div>
                                <h4 class="box-title" style="padding-top: 20px; color: cornflowerblue">(iv). Appication Form No</h4>
                                <div class="form-group">
                                    <a target="_blank" href="" style="margin-left: 35px;">Download Appication Form   <i class="fa fa-fw fa-cloud-download"></i></a>
                                </div>
                                <div class="form-group">
                                    <label for="inputCountry" class="col-sm-3 control-label">Upload Appication Form<span class="reqstar">*</span></label>

                                    <div class="col-sm-6">
                                        <input type="file" id="f_UploadAppication_Form" />
                                    </div>
                                    <div class="col-sm-3">
                                        <a id="AAppication_Form_Link" target="_blank" href="" hidden="hidden">View Uploaded Appication Form</a>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-3 col-sm-9">
                                        <button type="button" id="btnSaveAppication_Form" class="btn btn-success" onclick="SaveAgentAppication_Form()">Save Appication Form</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                        <div class="tab-pane" id="Rank_History">
                            <form class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-sm-12">
                                       <!-- /.box-header -->
                                        <div class="box-body" id="RankHistoryListDiv">
                                        </div>
                                        <!-- /.box-body -->
                                    </div>
                                </div>
                            </form>
                        </div>
                        <!-- /.tab-pane -->
                    </div>
                    <!-- /.tab-content -->
                </div>
                <!-- /.nav-tabs-custom -->
            </div>
            <!-- /.col -->
        </div>

        <!-- /.row -->

    </section>
    <input type="hidden" id="ID_hidden" class="form-control" />
      <input type="hidden" id="ID_hidden_SponsorDetails" class="form-control" />
     <input type="hidden" id="ID_hidden_BankDetails" class="form-control" />
     <input type="hidden" id="ID_hidden_PANCardDetails" class="form-control" />
    <input type="hidden" id="LogoPathPAN" />
    <input type="hidden" id="ID_hidden_ApplicationCardDetails" class="form-control" />
    <input type="hidden" id="LogoPathApplication" />
    <input type="hidden" id="LogoPath" />
    <input type="hidden" id="OldLogoPath" />
    <script src="ClientJS/MyProfile.js"></script>
    <script>
        $(function () {
            $(".select2").select2();
        });
    </script>
    <!-- /.content -->

</asp:Content>
