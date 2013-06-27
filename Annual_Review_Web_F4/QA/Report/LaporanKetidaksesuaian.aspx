<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false"
    CodeFile="LaporanKetidaksesuaian.aspx.vb" Inherits="QA_Report_LaporanKetidaksesuaian"
    Title="Laporan Penyimpangan Periode Form" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellspacing="0" cellpadding="5" style="background-color: #F2F4FD;">
        <tr valign="middle">
            <td align="right">
                Tgl. Penyimpangan :
            </td>
            <td align="left">
                <asp:TextBox ID="txtFromDate" runat="server" Width="80" />
                <asp:ImageButton ID="btnFromDate" runat="server" ImageUrl="~/Image/25.png" />
                &nbsp; s/d &nbsp;
                <asp:RequiredFieldValidator ID="valFromDate" runat="server" ControlToValidate="txtFromDate"
                    ErrorMessage="*" />
                <asp:TextBox ID="txtToDate" runat="server" Width="80" />
                <asp:ImageButton ID="btnToDate" runat="server" ImageUrl="~/Image/25.png" />
                <asp:RequiredFieldValidator ID="valToDate" runat="server" ControlToValidate="txtFromDate"
                    ErrorMessage="*" />
                <AjaxToolkit:CalendarExtender ID="calFromDate" runat="server" TargetControlID="txtFromDate"
                    PopupButtonID="btnFromDate" Format="dd-MMM-yy" CssClass="MyCalendar" />
                <AjaxToolkit:CalendarExtender ID="calToDate" runat="server" TargetControlID="txtToDate"
                    PopupButtonID="btnToDate" Format="dd-MMM-yy" CssClass="MyCalendar" />
            </td>
        </tr>
        <tr valign="middle">
            <td align="right">
                Departemen :
            </td>
            <td>
                <asp:DropDownList ID="ddlDepartemenPelapor" runat="server" DataSourceID="oDept" DataTextField="DeptName"
                    DataValueField="DeptId">
                </asp:DropDownList>
            </td>
        </tr>
         <tr valign="middle">
                <td align="right">Ketidaksesuain :</td>
                <td align="left">
                    <asp:UpdatePanel ID="upKetidaksesuaian" runat="server">
                    <ContentTemplate>
                    <asp:DropDownList ID="ddlKetidaksesuaian" runat="server" AutoPostBack="true">
                        <asp:ListItem Text="ALL" Value="0" Selected="True" />
                        <asp:ListItem Text="Bahan Baku" Value="1" />
                        <asp:ListItem Text="Bahan Kemas" Value="2" />
                        <asp:ListItem Text="Produk Ruahan" Value="3" />
                        <asp:ListItem Text="Produk Jadi" Value="4" />
                        <asp:ListItem Text="Bangunan" Value="5" />
                        <asp:ListItem Text="Sarana Penunjang" Value="6" />
                        <asp:ListItem Text="Mesin" Value="7" />
                        <asp:ListItem Text="Prosedur" Value="8" />
                        <asp:ListItem Text="Lain - lain" Value="9" />
                    </asp:DropDownList>
                    &nbsp;
                    <asp:TextBox ID="txtKetidaksesuaianLain" runat="server" Enabled="false" />
                    </ContentTemplate>                              
                    </asp:UpdatePanel> 
                </td>
            </tr>
        <tr valign="middle">
            <td align="right">
                Direncanakan Terjadi :
            </td>
            <td>
                <asp:DropDownList ID="ddlRencana" runat="server">
                    <asp:ListItem Text="ALL" Value="A" Selected="True" />
                    <asp:ListItem Text="Ya" Value="1" />
                    <asp:ListItem Text="Tidak" Value="2" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr valign="middle">
            <td align="right">
                Tingkat Resiko :
            </td>
            <td>
                <asp:DropDownList ID="ddlResiko" runat="server">
                    <asp:ListItem Text="ALL" Value="A" Selected="True" />
                    <asp:ListItem Text="Critical" Value="1" />
                    <asp:ListItem Text="Mayor" Value="2" />
                    <asp:ListItem Text="Minor" Value="3" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr valign="middle">
            <td align="right">
                Penyebab Penyimpangan :
            </td>
            <td align="left">
                <asp:UpdatePanel ID="upPenyebabPenyimpangan" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPenyebabPenyimpangan" runat="server" AutoPostBack="true">
                            <asp:ListItem Text="ALL" Value="0" Selected="True" />
                            <asp:ListItem Text="Human error" Value="1" />
                            <asp:ListItem Text="Supplier" Value="2" />
                            <asp:ListItem Text="Mesin / Alat" Value="3" />
                            <asp:ListItem Text="Formula" Value="4" />
                            <asp:ListItem Text="Spesifikasi" Value="5" />
                            <asp:ListItem Text="Proses" Value="6" />
                            <asp:ListItem Text="Sarana Penunjang" Value="7" />
                            <asp:ListItem Text="Lain - lain" Value="8" />
                        </asp:DropDownList>
                        &nbsp;
                        <asp:TextBox ID="txtPenyebabPenyimpanganLain" runat="server" Enabled="false" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr valign="middle">
            <td align="right">
                Status :
            </td>
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
    <asp:ObjectDataSource ID="oDept" runat="server" TypeName="ChangeControl" SelectMethod="GetDepartment">
    </asp:ObjectDataSource>
</asp:Content>
