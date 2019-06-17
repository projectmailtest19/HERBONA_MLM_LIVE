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
            width: 696px;
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
    <div>
        <div>

            <table class="style111">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="style413">&nbsp;</td>
                    <td>
                        <asp:Label ID="Label2" runat="server" CssClass="Lbl_Class" Text="Associate Id"></asp:Label>
                    </td>
                    <td class="style414">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="Txt_Size1"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" CssClass="Button_style"
                            OnClick="Button1_Click" Text="Search" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
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
                <td colspan="2" rowspan="2" valign="top">
                    <%--<asp:ImageButton ID="ImgBack" runat="server" ImageUrl="../TreeImages/backward-48.png"
                        OnClick="ImgBack_Click" ToolTip="Back To Up" />--%>
                </td>
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
                <td scope="row">&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td align="center" colspan="8" valign="top">
                    <img height="18" src="../TreeImages/level1.png" style="width: 338px" />
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td scope="row">&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td align="center" colspan="2">
                    <asp:LinkButton ID="Lb2L" runat="server" OnClick="Lb2L_Click"></asp:LinkButton>
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td align="center" colspan="2" valign="top">
                    <asp:LinkButton ID="Lb3R" runat="server" OnClick="Lb3R_Click"></asp:LinkButton>
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td scope="row">&nbsp;
                </td>
                <td width="34">&nbsp;
                </td>
                <td align="center" colspan="2">
                    <img id="i2" runat="server" alt="" height="31" src="..//TreeImages/R.jpg" width="35" />
                </td>
                <td width="34">&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td width="34">&nbsp;
                </td>
                <td align="center" colspan="2" valign="top">
                    <img id="i3" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35" />
                </td>
                <td width="34">&nbsp;
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td scope="row" width="50">&nbsp;
                </td>
                <td width="34">&nbsp;
                </td>
                <td align="center" colspan="2">
                    <img height="20" src="../TreeImages/Treeview_107.jpg" width="2" />
                </td>
                <td width="34">&nbsp;
                </td>
                <td width="50">&nbsp;
                </td>
                <td width="50">&nbsp;
                </td>
                <td width="34">&nbsp;
                </td>
                <td align="center" colspan="2">
                    <img height="20" src="../TreeImages/Treeview_107.jpg" width="2" />
                </td>
                <td width="34">&nbsp;
                </td>
                <td width="50">&nbsp;
                </td>
            </tr>
            <tr>
                <td scope="row" width="50">&nbsp;
                </td>
                <td align="center" colspan="4" valign="top">
                    <img height="18" src="../TreeImages/Level2.png" width="168" />
                </td>
                <td width="50">&nbsp;
                </td>
                <td width="50">&nbsp;
                </td>
                <td align="center" colspan="4" valign="top">
                    <img height="18" src="../TreeImages/Level2.png" style="width: 178px" />
                </td>
                <td width="50">&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="12" scope="row" valign="middle">
                    <asp:LinkButton ID="Lb4L" runat="server" OnClick="Lb4L_Click"></asp:LinkButton>
                </td>
                <td align="left" height="12" valign="middle">&nbsp;
                </td>
                <td height="12">&nbsp;
                </td>
                <td align="left" colspan="2" height="12" valign="top">
                    <asp:LinkButton ID="Lb5R" runat="server" OnClick="Lb5R_Click"></asp:LinkButton>
                </td>
                <td align="center" colspan="2" height="12">
                    <asp:LinkButton ID="Lb6L" runat="server" OnClick="Lb6L_Click"></asp:LinkButton>
                </td>
                <td height="12">&nbsp;
                </td>
                <td height="12">&nbsp;
                </td>
                <td align="left" colspan="2" height="12" valign="top">
                    <asp:LinkButton ID="Lb7R" runat="server" OnClick="Lb7R_Click"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="right" height="30" scope="row" valign="middle" width="50">&nbsp;
                </td>
                <td align="center" height="30" width="34">
                    <img id="i4" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35" />
                </td>
                <td align="left" height="30" valign="middle" width="50">&nbsp;
                </td>
                <td height="30" width="50">&nbsp;
                </td>
                <td align="center" height="30" valign="top" width="34">
                    <img id="i5" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35" />
                </td>
                <td height="30" width="50">&nbsp;
                </td>
                <td height="30" width="50">&nbsp;
                </td>
                <td align="center" height="30" valign="top" width="34">
                    <img id="i6" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35" />
                </td>
                <td height="30" width="50">&nbsp;
                </td>
                <td height="30" width="50">&nbsp;
                </td>
                <td align="center" height="30" valign="top" width="34">
                    <img id="i7" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35" />
                </td>
                <td height="30" width="50">&nbsp;
                </td>
            </tr>
            <tr>
                <td scope="row">&nbsp;
                </td>
                <td align="center" width="34">
                    <img height="20" src="../TreeImages/Treeview_107.jpg" width="2" />
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td align="center" width="34">
                    <img height="20" src="../TreeImages/Treeview_107.jpg" width="2" />
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td align="center" width="34">
                    <img height="20" src="../TreeImages/Treeview_107.jpg" width="2" />
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td align="center" width="34">
                    <img height="20" src="../TreeImages/Treeview_107.jpg" width="2" />
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3" scope="row" valign="top">
                    <img height="18" src="../TreeImages/level3.png" width="134" />
                </td>
                <td align="center" colspan="3" valign="top">
                    <img alt="" height="18" src="../TreeImages/level3.png" width="134" />
                </td>
                <td align="center" colspan="3" valign="top">
                    <img alt="" height="18" src="../TreeImages/level3.png" width="134" />
                </td>
                <td align="center" colspan="3" valign="top">
                    <img alt="" height="18" src="../TreeImages/level3.png" width="134" />
                </td>
            </tr>
            <tr>
                <td align="left" scope="row" valign="top" width="50">
                    <img id="i8" runat="server" height="31" src="../TreeImages/R.jpg" width="35" />
                </td>
                <td width="34">&nbsp;
                </td>
                <td align="right" valign="top" width="50">
                    <img id="i9" runat="server" height="31" src="../TreeImages/R.jpg" width="35" style="float: left" />
                </td>
                <td align="left" valign="top" width="50">
                    <img id="i10" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35"
                        style="float: left" />
                </td>
                <td width="34">&nbsp;
                </td>
                <td align="right" valign="top" width="50">
                    <img id="i11" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35"
                        style="float: right" />
                </td>
                <td align="left" valign="top" width="50">
                    <img id="i12" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35"
                        style="float: right" />
                </td>
                <td width="34">&nbsp;
                </td>
                <td align="right" valign="top" width="50">
                    <img id="i13" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35"
                        style="float: right" />
                </td>
                <td align="left" valign="top" width="50">
                    <img id="i14" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35"
                        style="float: right" />
                </td>
                <td width="34">&nbsp;
                </td>
                <td align="right" valign="top" width="50">
                    <img id="i15" runat="server" alt="" height="31" src="../TreeImages/R.jpg" width="35" />
                </td>
            </tr>
            <tr>
                <td align="left" scope="row">
                    <asp:LinkButton ID="Lb8L" runat="server" OnClick="Lb8L_Click"></asp:LinkButton>
                </td>
                <td>&nbsp;
                </td>
                <td style="text-align: center">
                    <asp:LinkButton ID="Lb9R" runat="server" OnClick="Lb9R_Click"></asp:LinkButton>
                </td>
                <td align="left">
                    <asp:LinkButton ID="Lb10L" runat="server" OnClick="Lb10L_Click"></asp:LinkButton>
                </td>
                <td>&nbsp;
                </td>
                <td align="center">
                    <asp:LinkButton ID="Lb11R" runat="server" OnClick="Lb11R_Click"></asp:LinkButton>
                </td>
                <td align="right">
                    <asp:LinkButton ID="Lb12L" runat="server" OnClick="Lb12L_Click"></asp:LinkButton>
                </td>
                <td>&nbsp;
                </td>
                <td style="text-align: right">
                    <asp:LinkButton ID="Lb13R" runat="server" OnClick="Lb13R_Click"></asp:LinkButton>
                </td>
                <td align="center">
                    <asp:LinkButton ID="Lb14L" runat="server" OnClick="Lb14L_Click"></asp:LinkButton>
                </td>
                <td>&nbsp;
                </td>
                <td style="text-align: right">
                    <asp:LinkButton ID="Lb15R" runat="server" OnClick="Lb15R_Click" Style="text-align: right"></asp:LinkButton>
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
