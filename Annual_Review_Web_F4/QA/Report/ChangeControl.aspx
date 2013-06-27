<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="ChangeControl.aspx.vb" Inherits="QA_Report_ChangeControl" title="Change Control Report Form" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellspacing="0" cellpadding="5" style="background-color:#F2F4FD;">
        <tr valign="middle">
            <td align="right">Tgl. Pengajuan :</td>
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
            <td align="right">Jenis Perubahan :</td>
            <td><asp:TextBox ID="txtJenisPerubahan" runat="server"></asp:TextBox></td>
        </tr>
        <tr valign="middle">
            <td align="right">Kategori Perubahan :</td>
            <td><asp:DropDownList ID="ddlKategori" runat="server">
                <asp:ListItem Text="ALL" Value="A" Selected="True" />
                <asp:ListItem Text="Minor" Value="1" />
                <asp:ListItem Text="Mayor" Value="2" />
                <asp:ListItem Text="Critical" Value="3" />
            </asp:DropDownList></td>
        </tr>
        <tr valign="middle">
            <td align="right">Info ke BPOM :</td>
            <td><asp:DropDownList ID="ddlBPOM" runat="server">
                <asp:ListItem Text="ALL" Value="A" Selected="True" />
                <asp:ListItem Text="Ya" Value="Y" />
                <asp:ListItem Text="Tidak" Value="T" />
            </asp:DropDownList></td>
        </tr>
        <tr valign="middle">
            <td align="right">Effective :</td>
            <td>
                <asp:DropDownList ID="ddlEffective" runat="server">
                    <asp:ListItem Text="ALL" Value="A" Selected="True" />
                    <asp:ListItem Text="Effective" Value="E" />
                    <asp:ListItem Text="Non Effective" Value="N" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr valign="middle">
            <td align="right">Department :</td>
            <td>
                <asp:DropDownList ID="ddlDept" runat="server"
                    DataSourceID="oDept" DataTextField="DeptName" DataValueField="DeptId">
                </asp:DropDownList>
            </td>
        </tr>
        <tr valign="middle">
            <td align="right">Status :</td>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem Text="ALL" Value="A" Selected="True" />
                    <asp:ListItem Text="Open" Value="0" />
                    <asp:ListItem Text="Closed" Value="1" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr valign="middle">
            <td colspan="2" style="background-color:White; text-align: center">
                <asp:LinkButton ID="btnFind" runat="server" CssClass="LinkButton" Text="Get Data" />
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="oDept" runat="server"
        TypeName="ChangeControl"
        SelectMethod="GetDepartment"></asp:ObjectDataSource>
</asp:Content>

