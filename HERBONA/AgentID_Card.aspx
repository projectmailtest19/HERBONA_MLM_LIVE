<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentID_Card.aspx.cs" Inherits="HERBONA.AgentID_Card" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <script src="plugins/jQuery/jquery-2.2.3.min.js"></script>
    <script src="ClientJS/AgentID_Card.js"></script>
     <script src="dist/js/sweetalert-dev.js"></script>
    <script src="dist/js/sweetalert.min.js"></script>
     <link href="dist/css/sweetalert.css" rel="stylesheet" />
     <script src="ClientJS/jquery.pleaseWait.js"></script>
    <link rel="stylesheet" href="ClientCss/Idcard.css" />
    <title>HERBONA</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="id-card-tag"></div>
            <div class="id-card-tag-strip"></div>
            <div class="id-card-hook"></div>
            <div class="id-card-holder">
                <div id="Print_Div" class="id-card">
                    <div class="header">
                        <img src="dist/img/Trucking_Logo.jpg"/>
                    </div>
                    <div class="photo">
                        <img id="Agent_Img" src=""/>
                    </div>
                    <h2 id="Hname"></h2>
                    <div class="InfoTable">
                        <table>
                            <tr>
                                <td><p><strong>PBO A/C No:</strong></p></td>
                                <td><p id="PAcNo"></p></td>
                            </tr>
                            <tr>
                                <td><p><strong>District:</strong></p></td>
                                <td><p id="PDistrict"></p></td>
                            </tr>
                            <tr>
                                <td><p><strong>State:</strong></p></td>
                                <td><p id="PState"></p></td>
                            </tr>
                            <tr>
                                <td><p><strong>Country:</strong></p></td>
                                <td><p id="PCountry"></p></td>
                            </tr>
                            <tr>
                                <td><p><strong>Valid Upto:</strong></td>
                                <td><p id="PValidDate"></td>
                            </tr>
                            <tr>
                                <td><p><strong>Pan Number:</strong></p></td>
                                <td><p id="PPanNo"></p></td>
                            </tr>
                        </table>
                    </div>
                    <h3>www.herbona.com</h3>
                    <hr/>
                    <p>
                        <strong>"PENGG"</strong>HOUSE,4th Floor, TC 11/729(4), Division Office Road
                        </p>
                            <p>Near PMG Junction, Thiruvananthapuram Kerala, India <strong>695033</strong></p>
                            <p>Ph: 9446062493 | E-ail: info@onetikk.info</p>
                </div>
            </div>
            <div class="print-div" style="text-align:center">
                <button class="print-cls" onclick="Print();"><i class="fa fa-print"></i>Print</button>
            </div>
        </div>
    </form>
</body>
</html>
