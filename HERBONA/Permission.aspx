<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="Permission.aspx.cs" Inherits="SmartTrucking.Permission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />  
    <script src="plugins/jQuery/jquery-2.2.3.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="plugins/select2/select2.full.min.js"></script>  
    <script src="plugins/input-mask/jquery.inputmask.js"></script>
    <script src="plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
    <script src="plugins/input-mask/jquery.inputmask.extensions.js"></script> 
    <script src="plugins/timepicker/bootstrap-timepicker.min.js"></script>
    <script src="dist/js/app.min.js"></script>
    <link rel="stylesheet" href="plugins/iCheck/all.css" />  
    <link rel="stylesheet" href="plugins/timepicker/bootstrap-timepicker.min.css" />
    <script src="plugins/timepicker/bootstrap-timepicker.min.js"></script>--%>
    <script src="ClientJS/Permission.js"></script>
    <style type="text/css">
        .dontshow {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="remodal" data-remodal-id="modal" style="max-width: 80%; padding: 0px;" role="dialog" aria-labelledby="modal1Title" aria-describedby="modal1Desc" id="addmodel">

                    <div class="register-box classall" style="width: 100%; margin: 0px" id="addnew">
                        <div class="register-box-body">
                            <p style="margin: 0px;" id="permission">
                                <span style="font-size: 24px; font-family: inherit; font-weight: 500; line-height: 1.1; color: inherit;">
                                    <label id="header" style="font-family: inherit; font-size: 20px;" />
                                </span>

                            </p>
                            <p style="padding-bottom: 10px;">
                                <span style="position: relative; float: right;">
                                    <input type="checkbox" class="abc" id="Allchkbox" onchange="Check_All()" />
                                    Check All</span>
                            </p>
                            <div class="box box-info">
                                <div class="span12" style="width: 100%">
                                    <div style="margin: 10px 15px 0px 15px">
                                        <div class="row-fluid stats-box">
                                            <div id="PermissionDetails" class="info-box" style="padding-top: 10px; padding-bottom: 10px;">
                                                <div class="overlay">
                                                    <table id="example" class="display" cellspacing="0" width="100%">
                                                        <thead>
                                                            <tr>
                                                                <th style="width: 20px;"></th>
                                                                <th style="display: none;">Permission ID</th>
                                                                <th style="display: none;">Menu ID</th>
                                                                <th>Menu Name</th>
                                                                <th>View &nbsp&nbsp&nbsp<input type="checkbox" id="ViewRowchkbox" class="ck_view_h" onclick="viewallclick()" /></th>
                                                                <th>Add &nbsp&nbsp&nbsp<input type="checkbox" id="AddRowchkbox" class="ck_add_h" onclick="addallclick()" /></th>
                                                                <th>Edit &nbsp&nbsp&nbsp<input type="checkbox" id="EditRowchkbox" class="ck_edit_h" onclick="editallclick()" /></th>
                                                                <th>Delete &nbsp&nbsp&nbsp<input type="checkbox" id="DeleteRowchkbox" class="ck_delete_h" onclick="deleteallclick()" /></th>
                                                                <th style="display: none;">Payment &nbsp&nbsp&nbsp<input type="checkbox" id="PaymentRowchkbox" class="ck_payment_h" /></th>
                                                            </tr>
                                                        </thead>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 25px;">
                            <div class="col-lg-12">
                                <div class="col-lg-4"></div>
                                <div class="col-lg-2">
                                    <button type="button" id="btnsave" class="btn btn-block btn-success" onclick="InsertRow()">Save</button>
                                </div>
                                <div class="col-lg-2">
                                    <button type="button" id="btnCancel" onclick="redirect()" class="btn btn-block btn-danger">Cancel</button>
                                </div>
                                <div class="col-lg-4"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <input type="text" id="txtrole" style="display: none" class="form-control" placeholder="Company Name" />
        <input type="hidden" id="txtRoleID" class="form-control" />
    </section>
</asp:Content>
