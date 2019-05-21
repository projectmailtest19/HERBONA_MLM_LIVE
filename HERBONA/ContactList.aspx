<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="ContactList.aspx.cs" Inherits="SmartTrucking.ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   <%-- <!-- iCheck for checkboxes and radio inputs -->
    <link rel="stylesheet" href="plugins/iCheck/all.css" />
    <!-- Bootstrap time Picker -->
    <link rel="stylesheet" href="plugins/timepicker/bootstrap-timepicker.min.css" />
    <link rel="stylesheet" href="plugins/select2/select2.min.css" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Modal -->
     
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Contact List</h3>
                        <div style="float: right;">
                            <!-- Trigger the modal with a button -->
                            <button type="button" class="btn btn-block btn-primary" onclick="redirect()" id="btn_create">CREATE CONTACT</button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body" id="ContactListDiv">
                        
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
        </div>
    </section>

<%--    <script src="plugins/jQuery/jquery-2.2.3.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="plugins/select2/select2.full.min.js"></script>
    
    <script src="plugins/input-mask/jquery.inputmask.js"></script>
    <script src="plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
    <script src="plugins/input-mask/jquery.inputmask.extensions.js"></script>

   
    <script src="plugins/timepicker/bootstrap-timepicker.min.js"></script>   
    <script src="dist/js/app.min.js"></script>--%>
    <script src="ClientJS/ContactList.js"></script>
  <%--  <script>
        $(document).ready(function () {        
            //$("#companyList").DataTable();           
        });
</script>
    --%>

</asp:Content>
