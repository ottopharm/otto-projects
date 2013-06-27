<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="LPPT.aspx.vb" Inherits="QA_Report_LPPT" title="Laporan LPPT" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding:2px">
        <div id="searchBased">
            <table border="0" cellspacing="0" cellpadding="5" style="background-color:#F2F4FD;">
                <tr valign="middle">
                    <td align="right">Tgl. Lapor :</td>
                    <td align="left">
                        <asp:TextBox ID="txtFromDate" runat="server" Width="80" />
                        <asp:ImageButton ID="btnFromDate" runat="server" ImageUrl="~/Image/25.png" /> &nbsp; s/d &nbsp;
                        <asp:RequiredFieldValidator ID="valFromDate" runat="server" ControlToValidate="txtFromDate" ErrorMessage="*" />
                        <asp:TextBox ID="txtToDate" runat="server" Width="80" />
                        <asp:ImageButton ID="btnToDate" runat="server" ImageUrl="~/Image/25.png" />
                        <asp:RequiredFieldValidator ID="valToDate" runat="server" ControlToValidate="txtToDate" ErrorMessage="*" />
                        <AjaxToolkit:CalendarExtender ID="calFromDate" runat="server"
                            TargetControlID="txtFromDate"
                            PopupButtonID="btnFromDate"
                            Format="dd-MMM-yy"
                            CssClass="MyCalendar" />
                        <AjaxToolkit:CalendarExtender ID="calToDate" runat="server"
                            TargetControlID="txtToDate"
                            PopupButtonID="btnToDate"
                            Format="dd-MMM-yy"
                            CssClass="MyCalendar" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Produk / Process :</td>
                    <td align="left">
                        <asp:TextBox ID="txtProduk" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Status :</td>
                    <td>
                        <asp:DropDownList ID="ddlEffective" runat="server">
                            <asp:ListItem Text="All" Value="A" Selected="True" />
                            <asp:ListItem Text="Effective" Value="E" />
                            <asp:ListItem Text="Non Effective" Value="N" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr valign="middle">
                    <td colspan="2" style="background-color:White; text-align: center">
                        <asp:LinkButton ID="btnFind" runat="server" CssClass="LinkButton" Text="Get Data" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

