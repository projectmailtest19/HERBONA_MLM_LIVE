<%@ Page Title="" Language="C#" MasterPageFile="~/SmartTruck.Master" AutoEventWireup="true" CodeBehind="MemberGeneology.aspx.cs" Inherits="HERBONA.MemberGeneology" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 187px;
        }
        .style3
        {
            width: 182px;
        }
        .style414
        {
            width: 124px;
        }
        .style415
        {
            width: 104px;
        }
        .style416
        {
            width: 172px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div id="childpage">
   
        <table class="style1">
            <tr>
                <td>
                 <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <center>
                        <asp:Label ID="Label1" runat="server" Text="Geneology" Font-Bold="False" Font-Names="Algerian"
                            Font-Size="25px"></asp:Label>
                    </center>
                </td>
            </tr>
        </table>
        <table class="style1">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style415">
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Associate ID"></asp:Label>
                </td>
                <td class="style416">
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txt_associateid" runat="server" AutoPostBack="True" 
                                CssClass="Txt_Size1" ontextchanged="txt_associateid_TextChanged"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style414">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;
                </td>
                <td class="style415">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Associate ID"></asp:Label>
                </td>
                <td class="style416">
                 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                    <asp:DropDownList ID="ddlassid" runat="server" Width="157px" AppendDataBoundItems="true"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlassid_SelectedIndexChanged" 
                        CssClass="Txt_Size1">
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style414">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Associate Name"></asp:Label>
                </td>
                <td>
                    &nbsp;
                    <asp:DropDownList ID="ddlname" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlname_SelectedIndexChanged"
                        AppendDataBoundItems="true" Width="170px" CssClass="Txt_Size1">
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <table class="style1">
            <tr>
                <td class="style3">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;
                </td>
                <td>
                    <asp:UpdatePanel ID="updatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:TreeView ID="tvwItems" runat="server" Font-Names="Verdana" Font-Size="20px"
                                LeafNodeStyle-CssClass="standardTreeview " ForeColor="Black" SkinID="NonPostBackTree"
                                Width="415px" SelectedNodeStyle-ForeColor="blue" OnSelectedNodeChanged="tvwItems_SelectedNodeChanged"
                                ShowLines="True">
                                <SelectedNodeStyle ForeColor="Blue" />
                                <NodeStyle VerticalPadding="1px" />
                                <LeafNodeStyle CssClass="standardTreeview " />
                            </asp:TreeView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
