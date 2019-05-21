<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="CreateCompany.aspx.cs" Inherits="SmartTrucking.CreateCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <style type="text/css">
        .ui-autocomplete {
            position: absolute;
            top: 100%;
            left: 0;
            z-index: 1000;
            float: left;
            display: none;
            min-width: 160px;
            _width: 160px;
            padding: 4px 4px;
            margin: 2px 0 0 0;
            list-style: none;
            background-color: #fffdd0;
            border-color: #ccc;
            border-color: rgba(0, 0, 0, 0.2);
            border-style: solid;
            border-width: 1px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            -webkit-box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
            -moz-box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
            box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
            -webkit-background-clip: padding-box;
            -moz-background-clip: padding;
            background-clip: padding-box;
            *border-right-width: 2px;
            *border-bottom-width: 2px;
            font-size:medium;
        }

        .ui-state-hover,.ui-state-focus {
            background: #afeeee;
            border: none;
            color: #000;
            border-radius: 0;
            font-weight: normal;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Create Company</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">

                                <div class="form-group">
                                    <div class="col-lg-4">
                                        <label>Company Name <span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <%-- <input id="txtCompanyName" class="form-control" type="text" placeholder="Company Name" />--%>
                                        <input type="hidden" id="hd_txtEmpnameWithCode" />
                                        <input type="text" id="txtCompanyName" placeholder="Company Name" class="form-control" />
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Mobile No.</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtMobileNo" class="form-control" type="number" placeholder="Mobile No." />

                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Phone No.</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtPhoneNo" class="form-control" type="number" placeholder="Phone No." />

                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Email<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtEmail" class="form-control" type="email" placeholder="Email" />

                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Password<span class="reqstar">*</span></label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtPassword" class="form-control" type="password" placeholder="Password" />

                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Website</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtWebsite" class="form-control" type="text" placeholder="Website URL" />

                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Browse Logo</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input type="file" id="f_Uploadfile" />
                                    </div>
                                </div>
                                <div class="col-lg-12 removespace">
                                    <div class="col-lg-6 removespace" style="padding-right: 20px">
                                        <div class="col-lg-9 removespace">
                                            <img id="selectimg" width="100" height="100" style="display: none;" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- /.col -->
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="col-lg-4">
                                        <label>CEO Name</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtCeoName" class="form-control" type="text" placeholder="CEO Name" />
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Country</label>
                                    </div>
                                    <div class="col-lg-8" id="cmbCountryf" onfocus="OpenSelect2('cmbCountry');">
                                        <select class="form-control select2" id="cmbCountry" style="width: 100%;" data-placeholder="Select Country">
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>State</label>
                                    </div>
                                    <div class="col-lg-8" onfocus="OpenSelect2('cmbState');">
                                        <select id="cmbState" class="form-control select2" style="width: 100%;" data-placeholder="Select State">
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>City</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtCity" class="form-control" type="text" placeholder="City" />

                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Company Type</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <input id="txtCompanyType" class="form-control" type="text" placeholder="Company Type" />

                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group" style="padding-top: 5px;">
                                    <div class="col-lg-4">
                                        <label>Address</label>
                                    </div>
                                    <div class="col-lg-8">
                                        <textarea id="txtAddress" class="form-control" rows="3" placeholder="Enter  Address..."></textarea>
                                    </div>
                                </div>

                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                        <div class="row" style="margin-bottom: 15px;">
                            <div class="col-lg-12">
                                <hr />
                                <div class="col-lg-3"></div>
                                <div class="col-lg-3" style="text-align: left">
                                    <button type="button" id="btnsave" class="btn btn-block btn-success" onclick="AddNewCompany()">Save</button>
                                </div>
                                <div class="col-lg-3" style="text-align: center">
                                    <button type="button" id="btnCancel" class="btn btn-block btn-danger" onclick="redirect()">Cancel</button>
                                </div>
                                <div class="col-lg-3"></div>
                            </div>
                        </div>
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
        </div>
    </section>

    <input type="hidden" id="ID_hidden" class="form-control" />
    <input type="hidden" id="LogoPath" />
    <input type="hidden" id="OldLogoPath" />

    <script src="ClientJS/CreateCompany.js"></script>
    <script>
        $(function () {
            $(".select2").select2();
        });
    </script>
</asp:Content>
