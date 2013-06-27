<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="PengkajianMutu.aspx.vb" Inherits="PengkajianMutu" title="Laporan Pengkajian Mutu" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManagerProxy ID="proxy" runat="server">
        <Services>
            <asp:ServiceReference Path="~/WS_PengkajianMutu.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <asp:Panel ID="pnl" runat="server" DefaultButton="btnFind">
        <table border="0">
            <tr valign="middle">
                <td align="right">Tgl. Produksi :</td>
                <td align="left">
                    <asp:TextBox ID="txtFromDate" runat="server" Width="80" />
                    <asp:ImageButton ID="btnFromDate" runat="server" ImageUrl="~/Image/25.png" /> 
                    <asp:RequiredFieldValidator ID="valFromDate" runat="server" ControlToValidate="txtFromDate" ErrorMessage="*" /> &nbsp; s/d &nbsp;
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
                <td align="right">
                    Kode Produk :
                </td>
                <td align="left" colspan="2">
                    <asp:TextBox ID="txtProdID" runat="server" />
                    <asp:RequiredFieldValidator ID="valProdID" runat="server" ControlToValidate="txtProdID" ErrorMessage="*" />
                </td>
            </tr>
            <tr>
            <td align="right">
                    [Khusus Tablet / Kaplet]
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlTab" runat="server">
                        <asp:ListItem Text="Salut" Value="s" />
                        <asp:ListItem Text="NonSalut" Value="n" />
                    </asp:DropDownList>
                </td>
                <td align="left">
                    <asp:ImageButton ID="btnFind" runat="server" 
                        ImageUrl="~/Image/001_60.png" 
                        ToolTip="Find Produk" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    
</asp:Content>

