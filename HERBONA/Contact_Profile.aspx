<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="Contact_Profile.aspx.cs" Inherits="SmartTrucking.Contact_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Main content -->
    <section class="content">

        <div class="row">
            <div class="col-md-3">

                <!-- Profile Image -->
                <div class="box box-primary">
                    <div class="box-body box-profile">
                        <img id="selectimg" class="profile-user-img img-responsive img-circle" alt="User profile picture">

                        <h3 class="profile-username text-center" id="lblCompanyName"></h3>

                        <p class="text-muted text-center">Browse Logo</p>
                        <div class="col-lg-8">
                            <input type="file" id="f_Uploadfile" />
                        </div>

                        <button type="button" id="btnchangepsswd" class="btn btn-primary btn-block" onclick="redirect()" style="margin-top: 50px;">Change Password</button>
                        <%--    <a href="#" class="btn btn-primary btn-block"><b>Change Password</b></a>--%>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->


            </div>
            <!-- /.col -->
            <div class="col-md-9">
                <div class="nav-tabs-custom">
                    <ul class="nav nav-tabs">

                        <li><a href="#settings" data-toggle="tab">Contact Profile</a></li>
                    </ul>
                    <div class="tab-content">


                        <form class="form-horizontal">
                        </form>


                        <div class="active tab-pane" id="settings">
                            <form class="form-horizontal">
                                <div class="form-group">
                                    <label for="inputName" class="col-sm-2 control-label">Contact Name<span class="reqstar">*</span></label>

                                    <div class="col-sm-10">
                                        <input id="txtName" class="form-control" type="text" placeholder="Contact Name" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputMob" class="col-sm-2 control-label">Cell No.</label>

                                    <div class="col-sm-10">
                                        <input id="txtMobileNo" class="form-control" type="number" placeholder="Cell No." />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputPhone" class="col-sm-2 control-label">Phone No.</label>

                                    <div class="col-sm-10">
                                        <input id="txtPhoneNo" class="form-control" type="number" placeholder="Phone No." />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputemail" class="col-sm-2 control-label">Email<span class="reqstar">*</span></label>

                                    <div class="col-sm-10">
                                        <input id="txtEmail" class="form-control" type="email" placeholder="Email" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputWebsite" class="col-sm-2 control-label">Website</label>

                                    <div class="col-sm-10">
                                        <input id="txtWebsite" class="form-control" type="text" placeholder="Website Address.." />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputRight" class="col-sm-2 control-label">Right</label>

                                    <div class="col-sm-10">
                                        <select id="cmbRole" class="form-control select2" style="width: 100%;" data-placeholder="Select Role">
                                             <option></option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputCountry" class="col-sm-2 control-label">Country</label>

                                    <div class="col-sm-10">
                                        <select class="form-control select2" id="cmbCountry" style="width: 100%;" data-placeholder="Select Country">
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputState" class="col-sm-2 control-label">State</label>

                                    <div class="col-sm-10">
                                        <select id="cmbState" class="form-control select2" style="width: 100%;" data-placeholder="Select State">
                                            <option></option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputCity" class="col-sm-2 control-label">City</label>

                                    <div class="col-sm-10">
                                        <input id="txtCity" class="form-control" type="text" placeholder="City" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputAddress" class="col-sm-2 control-label">Address</label>

                                    <div class="col-sm-10">
                                        <textarea id="txtAddress" class="form-control" rows="3" placeholder="Enter  Address..."></textarea>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-2 col-sm-10">
                                        <div class="checkbox">
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-2 col-sm-10">
                                        <button type="button" id="btnupdate" class="btn btn-danger" onclick="UpdateContact()">Update</button>
                                        <%--   <button type="submit" class="btn btn-danger">Update</button>--%>
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

    <input type="hidden" id="LogoPath" />
    <input type="hidden" id="OldLogoPath" />
    <script src="ClientJS/ContactProfile.js"></script>
    <script>
        $(function () {
            $(".select2").select2();
        });
    </script>
    <!-- /.content -->

</asp:Content>
