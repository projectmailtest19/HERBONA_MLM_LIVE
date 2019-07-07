<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="MemberTreeView.aspx.cs" Inherits="HERBONA.MemberTreeView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .contentdisplay3 {
            border: 1px solid #ECF4FF;
            background-color: #fbfbff;
            text-align: left;
            color: #4b4b4b;
            font-size: 11px;
            font-weight: normal;
            font-family: verdana, arial, helvetica, sans-serif;
            text-decoration: none;
            width: 1000px;
        }

        .style1 {
            height: 13px;
        }

        .style413 {
            width: 279px;
        }

        .style414 {
            width: 251px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-12">
            <div class="col-xs-3">
            </div>
            <div class="col-xs-6">
                <div class="form-group">

                    <div class="form-group" style="padding-top: 5px;">
                        <div class="col-lg-3">
                            <asp:Label ID="Label2" runat="server" CssClass="Lbl_Class" Text="Associate Id"></asp:Label>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <asp:Button ID="Button1" runat="server" class="btn btn-block btn-success"
                                OnClick="Button1_Click" Text="Search" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-3">
            </div>
        </div>
        <br />
        <br />
        <br />

        <table align="center" border="0" cellpadding="0" cellspacing="0" class="contentdisplay3">
            <tr>
                <td scope="row">&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td align="left" colspan="5" rowspan="3" valign="top">
                    <table border="0" cellpadding="0" cellspacing="0" class="Tree" width="280">
                        <tr>
                            <td align="left" class="style5" scope="row" valign="top">Name :
                            </td>
                            <td width="197">
                                <asp:Label ID="LBL_Name" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style1" scope="row" valign="top">Left Join :
                            </td>
                            <td class="style1">
                                <asp:Label ID="LBL_LEFT" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style5" scope="row" valign="top">Right Join :
                            </td>
                            <td>
                                <asp:Label ID="LBL_RIGHT" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style5" scope="row" valign="top">Total Pair :
                            </td>
                            <td>
                                <asp:Label ID="LBL_PAIR" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td scope="row">&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td colspan="2" rowspan="2" valign="top"></td>
                <td>&nbsp;
                </td>
                <td colspan="2" style="text-align: center">
                    <asp:LinkButton ID="Lb1" runat="server" OnClick="Lb1_Click"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td scope="row">&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td align="center" colspan="2">
                    <img id="i1" runat="server" alt="" height="31" src="../TreeImages/G.jpg" width="35" />
                </td>
            </tr>
            <tr>
                <td scope="row">&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td align="center" colspan="2">
                    <img height="20" src="../TreeImages/Treeview_107.jpg" width="2" />
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="12" valign="top">
                    <div class="col-lg-12">
                        <div class="col-lg-2"></div>
                        <div class="col-lg-8">
                            <img height="18" src="../TreeImages/level1.png" style="width: 420px" />
                        </div>
                        <div class="col-lg-2"></div>
                    </div>
                </td>


            </tr>
            <tr>

                <td align="center" colspan="12" valign="top">
                    <div class="col-lg-12">
                        <div class="col-lg-2"></div>
                        <div class="col-lg-3">
                            <asp:LinkButton ID="Lb2L" runat="server" OnClick="Lb2L_Click"></asp:LinkButton>
                        </div>
                        <div class="col-lg-2"></div>
                        <div class="col-lg-3">
                            <asp:LinkButton ID="Lb3R" runat="server" OnClick="Lb3R_Click"></asp:LinkButton>
                        </div>
                        <div class="col-lg-2"></div>
                    </div>
                </td>


            </tr>
            <tr>
                <td align="center" colspan="12" valign="top">
                    <div class="col-lg-12">
                        <div class="col-lg-2"></div>
                        <div class="col-lg-3">

                            <img id="i2" runat="server" alt="" height="31" src="..//TreeImages/R.jpg" width="35" />
                        </div>
                        <div class="col-lg-2"></div>
                        <div class="col-lg-3">
                            <img id="i3" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35" />
                        </div>

                        <div class="col-lg-2"></div>
                    </div>
                </td>

            </tr>
            <tr>
                <td align="center" colspan="12" valign="top">
                    <div class="col-lg-12">
                        <div class="col-lg-2"></div>
                        <div class="col-lg-3">

                            <img height="20" src="../TreeImages/Treeview_107.jpg" width="2" />
                        </div>
                        <div class="col-lg-2"></div>
                        <div class="col-lg-3">
                            <img height="20" src="../TreeImages/Treeview_107.jpg" width="2" />
                        </div>

                        <div class="col-lg-2"></div>
                    </div>
                </td>


            </tr>
            <tr>
                <td align="center" colspan="12" valign="top">
                    <div class="col-lg-12">
                        <div class="col-lg-1"></div>
                        <div class="col-lg-4">

                            <img height="18" src="../TreeImages/Level2.png" width="230" />
                        </div>
                        <div class="col-lg-2"></div>
                        <div class="col-lg-4">
                            <img height="18" src="../TreeImages/Level2.png" style="width: 230px" />
                        </div>

                        <div class="col-lg-1"></div>
                    </div>
                </td>


            </tr>
            <tr>

                <td align="center" colspan="12" valign="top">
                    <div class="col-lg-12">
                        <div class="col-lg-1" style="margin-left: -50px;"></div>
                        <div class="col-lg-1">
                            <asp:LinkButton ID="Lb4L" runat="server" OnClick="Lb4L_Click"></asp:LinkButton>
                        </div>
                        <div class="col-lg-2"></div>
                        <div class="col-lg-1">
                            <asp:LinkButton ID="Lb5R" runat="server" OnClick="Lb5R_Click"></asp:LinkButton>
                        </div>
                        <div class="col-lg-3" style="margin-left: -50px"></div>
                        <div class="col-lg-1">
                            <asp:LinkButton ID="Lb6L" runat="server" OnClick="Lb6L_Click"></asp:LinkButton>
                        </div>
                        <div class="col-lg-2"></div>
                        <div class="col-lg-1">
                            <asp:LinkButton ID="Lb7R" runat="server" OnClick="Lb7R_Click"></asp:LinkButton>
                        </div>

                    </div>
                </td>

            </tr>
            <tr>
                <td align="center" colspan="12" valign="top">
                    <div class="col-lg-12">
                        <div class="col-lg-1" style="margin-left: -50px;"></div>
                        <div class="col-lg-1">
                            <img id="i4" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35" />
                        </div>
                        <div class="col-lg-2"></div>
                        <div class="col-lg-1">
                            <img id="i5" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35" />
                        </div>
                        <div class="col-lg-3" style="margin-left: -50px"></div>
                        <div class="col-lg-1">
                            <img id="i6" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35" />
                        </div>
                        <div class="col-lg-2"></div>
                        <div class="col-lg-1">
                            <img id="i7" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35" />
                        </div>

                    </div>
                </td>


            </tr>
            <tr>
                <td align="center" colspan="12" valign="top">
                    <div class="col-lg-12">
                        <div class="col-lg-1" style="margin-left: -50px;"></div>
                        <div class="col-lg-1">
                            <img height="20" src="../TreeImages/Treeview_107.jpg" width="2" />
                        </div>
                        <div class="col-lg-2"></div>
                        <div class="col-lg-1">
                            <img height="20" src="../TreeImages/Treeview_107.jpg" width="2" />
                        </div>
                        <div class="col-lg-3" style="margin-left: -50px"></div>
                        <div class="col-lg-1">
                            <img height="20" src="../TreeImages/Treeview_107.jpg" width="2" />
                        </div>
                        <div class="col-lg-2"></div>
                        <div class="col-lg-1">
                            <img height="20" src="../TreeImages/Treeview_107.jpg" width="2" />
                        </div>

                    </div>
                </td>

            </tr>
            <tr>
                <td align="center" colspan="12" valign="top">
                    <div class="col-lg-12">
                        <div class="col-lg-1" style="margin-left: -50px;"></div>
                        <div class="col-lg-2">
                            <img height="18" src="../TreeImages/level3.png" width="134" />
                        </div>
                        <div class="col-lg-1"></div>
                        <div class="col-lg-2">
                            <img height="18" src="../TreeImages/level3.png" width="134" />
                        </div>
                        <div class="col-lg-1"></div>
                        <div class="col-lg-2">
                            <img height="18" src="../TreeImages/level3.png" width="134" />
                        </div>
                        <div class="col-lg-1"></div>
                        <div class="col-lg-2">
                            <img height="18" src="../TreeImages/level3.png" width="134" />
                        </div>

                    </div>
                </td>

            </tr>
            <tr>
                <td align="center" colspan="12" valign="top">
                    <div class="col-lg-12">
                        <div class="col-lg-1" style="margin-right: 50px;">
                            <img id="i8" runat="server" height="31" src="../TreeImages/R.jpg" width="35" />
                        </div>
                        <div class="col-lg-1">
                            <img id="i9" runat="server" height="31" src="../TreeImages/R.jpg" width="35" style="float: left" />
                        </div>
                        <div class="col-lg-1"></div>
                        <div class="col-lg-1" style="margin-left: -30px; margin-right: 20px;">
                            <img id="i10" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35"
                                style="float: left" />
                        </div>
                        <div class="col-lg-1">
                            <img id="i11" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35"
                                style="float: right" />
                        </div>
                        <div class="col-lg-1" style="margin-left: -30px"></div>
                        <div class="col-lg-1" style="margin-right: 20px;">
                            <img id="i12" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35"
                                style="float: right" />
                        </div>
                        <div class="col-lg-1">
                            <img id="i13" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35"
                                style="float: right" />
                        </div>
                        <div class="col-lg-1"></div>
                        <div class="col-lg-1" style="margin-left: -30px; margin-right: 30px;">
                            <img id="i14" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35"
                                style="float: right" />
                        </div>
                        <div class="col-lg-1">
                            <img id="i15" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35" />
                        </div>

                    </div>
                </td>

            </tr>
            <tr>
                <td align="center" colspan="12" valign="top">
                    <div class="col-lg-12">
                        <div class="col-lg-1" style="margin-right: 50px;">
                            <asp:LinkButton ID="Lb8L" runat="server" OnClick="Lb8L_Click"></asp:LinkButton>
                        </div>
                        <div class="col-lg-1">
                            <asp:LinkButton ID="Lb9R" runat="server" OnClick="Lb9R_Click"></asp:LinkButton>
                        </div>
                        <div class="col-lg-1"></div>
                        <div class="col-lg-1" style="margin-left: -30px; margin-right: 20px;">
                            <asp:LinkButton ID="Lb10L" runat="server" OnClick="Lb10L_Click"></asp:LinkButton>
                        </div>
                        <div class="col-lg-1">
                            <asp:LinkButton ID="Lb11R" runat="server" OnClick="Lb11R_Click"></asp:LinkButton>
                        </div>
                        <div class="col-lg-1" style="margin-left: -30px"></div>
                        <div class="col-lg-1" style="margin-right: 20px;">
                            <asp:LinkButton ID="Lb12L" runat="server" OnClick="Lb12L_Click"></asp:LinkButton>
                        </div>
                        <div class="col-lg-1">
                            <asp:LinkButton ID="Lb13R" runat="server" OnClick="Lb13R_Click"></asp:LinkButton>
                        </div>
                        <div class="col-lg-1"></div>
                        <div class="col-lg-1" style="margin-left: -30px; margin-right: 30px;">
                            <asp:LinkButton ID="Lb14L" runat="server" OnClick="Lb14L_Click"></asp:LinkButton>
                        </div>
                        <div class="col-lg-1">
                            <asp:LinkButton ID="Lb15R" runat="server" OnClick="Lb15R_Click" Style="text-align: right"></asp:LinkButton>
                        </div>
                    </div>
                </td>

            </tr>
            <tr>
                <td scope="row" width="50">&nbsp;
                </td>
                <td width="34">&nbsp;
                </td>
                <td width="50">&nbsp;
                </td>
                <td width="50">&nbsp;
                </td>
                <td width="34">&nbsp;
                </td>
                <td width="50">&nbsp;
                </td>
                <td width="50">&nbsp;
                </td>
                <td width="34">&nbsp;
                </td>
                <td width="50">&nbsp;
                </td>
                <td width="50">&nbsp;
                </td>
                <td width="34">&nbsp;
                </td>
                <td width="50">&nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
