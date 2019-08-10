﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agent_ID_Card.aspx.cs" Inherits="HERBONA.Agent_ID_Card" %>

<!DOCTYPE html>
<html>
<head>
    <title></title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="https://files.codepedia.info/files/uploads/iScripts/html2canvas.js"></script>
    <script src="plugins/jQuery/jquery-2.2.3.min.js"></script>
    <script src="dist/js/sweetalert-dev.js"></script>
    <script src="dist/js/sweetalert.min.js"></script>
    <link href="dist/css/sweetalert.css" rel="stylesheet" />
    <script src="ClientJS/jquery.pleaseWait.js"></script>


    <style type="text/css">
        .MainRound {
            border: 1px solid #0b6fb4;
            border-radius: 20px;
            background-color: #fff;
        }

        .Pro {
            font-size: 230%;
            color: #9696a0;
        }

        .Young {
            font-weight: bold;
            font-size: 230%;
        }

        .Pad3Side {
            padding: 15px 30px 3px 10px;
        }

        .BoldText {
            font-weight: bolder;
            padding: 10px;
        }

        .Image {
            width: 25%;
        }

        .BlueBorder {
            border-top: 2px solid #0b6fb4;
        }

        .BlueBackground {
            background-color: #0b6fb4;
            color: #fff;
            border-radius: 0px 0px 15px 15px;
            text-align: center;
        }

        .BoldFooter {
            font-weight: bolder;
        }

        .PadFooter {
            padding: 15px;
        }

        .PadAll {
            padding: 35px 20px 35px 20px;
        }

        .ImageBack {
            width: 11%;
        }

        .ProBack {
            font-size: 180%;
            color: #9696a0;
        }

        .YoungBack {
            font-weight: bold;
            font-size: 180%;
        }

        .padLit {
            /*padding: 10px 15px 0px 15px;*/
            padding: 8px 15px 0px 15px;
            font-size: 13px;
            font-weight: bold;
        }

        .PadAllBack {
            padding: 5px 15px 12px 20px;
        }

        .PadAllButtom {
            padding: 10px 10px 8px 20px;
        }

        .ManageFont {
            font-size: 12px;
            font-weight: bold;
        }

        .ManageLogo {
            font-size: 10px;
            font-weight: bold;
        }
    </style>
</head>
<body class="panel-body">
    <div class="container">
        <div class="col-lg-2">
        </div>
        <div class="col-lg-8" id='DivIdToPrint'>
            <div class="row">
                <div class="col-lg-12">
                    <div class="col-lg-12 MainRound">
                        <div class="row Pad3Side">
                            <div class="col-lg-6">
                                <img class="Image" src="dist/img/Trucking_Logo.jpg" /><span class="Pro">HER</span><span class="Young">BONA</span>
                            </div>
                            <div class="col-lg-6 text-right BoldText">
                                <div>Most Promising Cellular Nutrition</div>
                                <div>Company In India</div>
                            </div>
                        </div>
                        <div class="row BlueBorder PadAll">
                            <div class="col-lg-12">
                                <div class="row">
                                    <div class="col-lg-8">
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <label>Name</label>
                                            </div>
                                            <div class="col-lg-1">
                                                <label>:</label>
                                            </div>
                                            <div class="col-lg-7">
                                                <span>
                                                    <p id="Hname"></p>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <label>PBO A/C No</label>
                                            </div>
                                            <div class="col-lg-1">
                                                <label>:</label>
                                            </div>
                                            <div class="col-lg-7">
                                                <span>
                                                    <p id="PAcNo"></p>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <label>District</label>
                                            </div>
                                            <div class="col-lg-1">
                                                <label>:</label>
                                            </div>
                                            <div class="col-lg-7">
                                                <span>
                                                    <p id="PDistrict"></p>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <label>State</label>
                                            </div>
                                            <div class="col-lg-1">
                                                <label>:</label>
                                            </div>
                                            <div class="col-lg-7">
                                                <span>
                                                    <p id="PState"></p>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <label>Valid Upto</label>
                                            </div>
                                            <div class="col-lg-1">
                                                <label>:</label>
                                            </div>
                                            <div class="col-lg-7">
                                                <span>
                                                    <p id="PValidDate"></p>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <label>Pan Number</label>
                                            </div>
                                            <div class="col-lg-1">
                                                <label>:</label>
                                            </div>
                                            <div class="col-lg-7">
                                                <span>
                                                    <p id="PPanNo"></p>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 text-right">
                                        <div class="col-lg-12">
                                            <img style="padding: 1px; margin: 1px; height: 140px; border: 1px solid #000;" src="" id="Agent_Img" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row BlueBackground">
                            <div class="col-lg-12 PadFooter">
                                <div class="BoldFooter">PROYOUNG INTERNATIONAL PVT. LTD.</div>
                                <div>T.F.6, 3rd Floar, Empire Squire, R.No: 36, Jubilee Hills, Hyd-33,</div>
                                <div>Telengana, India. Ph: 040-6606 6606, Email: support@proyoung.com</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="col-lg-12 MainRound">
                        <div class="row PadAllBack">
                            <div class="col-lg-12">
                                <div class="row">
                                    <div class="col-lg-6" style="font-weight: bold; font-size: 20px; padding-top: 23px; padding-bottom: 12px;">
                                        Terms & Conditions**
                                    </div>
                                    <div class="col-lg-6 text-right">
                                        <img class="ImageBack" src="dist/img/Trucking_Logo.jpg" /><span class="ProBack">HER</span><span class="YoungBack">BONA</span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-12 padLit">
                                The card holder is not employee of the company, but an independent distributor to promote the product of PROYOUNG INTERNATIONAL PVT. LTD.,
                            </div>
                            <div class="col-lg-12 padLit">
                                This card belongs to PROYOUNG INTERNATIONAL PVT. LTD., which must be hand-overed om request and it is not transferable.
                            </div>
                            <div class="col-lg-12 padLit">
                                This card is only for the personal identification (should be presented alonge with any government authorized
                                phote id card) of an Independent Direct Seller. It should not be allowed/used to get any addition benifits or
                                any cash collection on behalf of company.
                            </div>
                            <div class="col-lg-12 padLit">
                                This ID usage is permitted only on the acceptence of the term and conditions allowed for governing distributor agreement signed by the card holder
                                (as may be amended from time to time) and constitutes acceptance of the same.
                            </div>
                            <div class="col-lg-12 padLit">
                                If card found; please return it to the address mentioned on the other side of card.
                            </div>
                        </div>
                        <div class="row PadAllButtom BlueBorder">
                            <div class="row">
                                <div class="col-lg-7" style="padding-top: 10px;">
                                    <div class="col-lg-12">
                                        <label>PROYOUNG INTERNATIONAL PVT LTD,</label>
                                    </div>
                                    <div class="col-lg-12 ManageFont">
                                        Affiliated with Federation of Direct Selling Association (FDSA)
                                    </div>
                                </div>
                                <div class="col-lg-1">
                                </div>
                                <div class="col-lg-4 ManageLogo">
                                    <div class="row">
                                        <div class="col-lg-12 text-center">
                                            <img style="width: 40px;" src="dist/img/Trucking_Logo.jpg" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12 text-center">
                                            FDSA MEMBER COMPANY
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>

                </div>
            </div>
        </div>
        <div class="col-lg-2">
            <input type='button' id='btn' class="btn btn-sm btn-success" value='Print'>
        </div>
    </div>
    <div class="container">
        <div class="col-lg-2">
        </div>
        <div class="col-lg-8">
            <div id="previewImage" style="display: none">
            </div>
        </div>
        <div class="col-lg-2">
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            var element = $("#DivIdToPrint"); // global variable
            var getCanvas; // global variable

            $("#btn").on('click', function () {

                html2canvas(element, {
                    onrendered: function (canvas) {
                        $("#previewImage").append(canvas);
                        getCanvas = canvas;
                    }
                });
                setTimeout(function () {
                    var imgageData = getCanvas.toDataURL("image/png");
                    var newData = imgageData.replace(/^data:image\/png/, "data:application/octet-stream");
                    var newWin = window.open('', 'Print-Window');
                    newWin.document.open();
                    newWin.document.write('<html><body style="text-align: center" onload="window.print()"><img src="' + newData + '" /> </body></html>');
                    newWin.document.close();
                    setTimeout(function () { newWin.close(); }, 10);
                }, 2000);
            });
        });
    </script>

    <script src="ClientJS/Agent_ID_Card.js"></script>

</body>
</html>
