<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false"
    CodeFile="LaporanKeluhan.aspx.vb" Inherits="QA_Report_LaporanKeluhan" Title="Laporan Keluhan Periode Form" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellspacing="0" cellpadding="5" style="background-color: #F2F4FD;">
        <tr valign="middle">
            <td align="right">Tgl. Terjadi :</td>
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
            <td align="right">Manufaktur :</td>
            <td align="left">
                <asp:TextBox ID="txtManufaktur" runat="server" />
            </td>
        </tr>
        <tr valign="middle">
            <td align="right">Tingkat Resiko :</td>
            <td><asp:DropDownList ID="ddlResiko" runat="server">
                <asp:ListItem Text="ALL" Value="A" Selected="True" />
                <asp:ListItem Text="Critical" Value="1" />
                <asp:ListItem Text="Mayor" Value="2" />
                <asp:ListItem Text="Minor" Value="3" />
            </asp:DropDownList></td>
        </tr>
        <tr valign="middle">
            <td align="right">Investigasi :</td>
            <td align="left">
                <asp:TextBox ID="txtInvestigasi" runat="server" />
            </td>
        </tr>
        <tr valign="middle">
            <td align="right">Status :</td>
            <td>
                <asp:DropDownList ID="ddlIsClosed" runat="server">
                    <asp:ListItem Text="ALL" Value="A" Selected="True" />
                    <asp:ListItem Text="Open" Value="0" />
                    <asp:ListItem Text="Closed" Value="1" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr valign="middle">
            <td colspan="2" style="background-color: White; text-align: center">
                <asp:LinkButton ID="btnFind" runat="server" CssClass="LinkButton" Text="Get Data" />
            </td>
        </tr>
    </table>
</asp:Content>
