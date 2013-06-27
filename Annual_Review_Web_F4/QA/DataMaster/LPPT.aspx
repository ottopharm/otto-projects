<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="LPPT.aspx.vb" Inherits="QA_DataMaster_LPPT" title="LPPT" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<asp:ScriptManagerProxy ID="smProxy" runat="server">
        <Services>
            <asp:ServiceReference Path="~/WS_ProdukReview.asmx" />
        </Services>
    </asp:ScriptManagerProxy>--%>
    <div style="padding:2px;">
        <table border="0">
            <tr valign="middle">
                <td align="right">No. LPPT :</td>
                <td align="left">
                    <asp:TextBox ID="txtNoLPPT" runat="server" AutoPostBack="true" />
                    <asp:RequiredFieldValidator ID="valNoLPPT" runat="server" ControlToValidate="txtNoLPPT" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">
                    Product / Proses :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtProses" runat="server" />
                    <asp:RequiredFieldValidator ID="valProses" runat="server" ControlToValidate="txtProses" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">
                    Product ID :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtProdID" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">No. Batch :</td>
                <td align="left">
                    <asp:TextBox ID="txtNoBatch" runat="server" Width="400" TextMode="MultiLine" Height="40" Wrap="true" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Tgl.Penyimpangan :</td>
                <td align="left">
                    <asp:TextBox ID="txtTglSimpang" runat="server" Width="80" />
                    <asp:ImageButton ID="btnTglSimpang" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calTglSimpang" runat="server"
                        TargetControlID="txtTglSimpang"
                        PopupButtonID="btnTglSimpang"
                        CssClass="MyCalendar"
                        Format="dd-MMM-yy" />
                    <asp:RequiredFieldValidator ID="valTglSimpang" runat="server" ControlToValidate="txtTglSimpang" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top">Penyimpangan :</td>
                <td align="left">
                    <asp:TextBox ID="txtSimpang" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                    <asp:RequiredFieldValidator ID="valSimpang" runat="server" ControlToValidate="txtSimpang" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top">Tindakan sementara yang telah dilakukan :</td>
                <td align="left">
                    <asp:TextBox ID="txtTindakan" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                    <asp:RequiredFieldValidator ID="valTindakan" runat="server" ControlToValidate="txtTindakan" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top">Pelapor :</td>
                <td align="left">
                    <asp:TextBox ID="txtPelapor" runat="server" />
                    <asp:RequiredFieldValidator ID="valPelapor" runat="server" ControlToValidate="txtPelapor" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Tgl. Lapor :</td>
                <td align="left">
                    <asp:TextBox ID="txtTglLapor" runat="server" Width="80" />
                    <asp:ImageButton ID="btnTglLapor" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calTglLapor" runat="server"
                        TargetControlID="txtTglLapor"
                        PopupButtonID="btnTglLapor"
                        CssClass="MyCalendar"
                        Format="dd-MMM-yy" />
                    <asp:RequiredFieldValidator ID="valTglLapor" runat="server" ControlToValidate="txtTglLapor" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top">Kesimpulan akar masalah penyimpangan :</td>
                <td align="left">
                    <asp:TextBox ID="txtAkar" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top">Perbaikan :</td>
                <td align="left">
                    <asp:TextBox ID="txtPerbaikan" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top">Tindakan perbaikan :</td>
                <td align="left">
                    <asp:TextBox ID="txtTPerbaikan" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top">Tindakan pencegahan :</td>
                <td align="left">
                    <asp:TextBox ID="txtCegah" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top">Kesimpulan :</td>
                <td align="left">
                    <asp:TextBox ID="txtKesimpulan" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" colspan="2">
                    <asp:LinkButton ID="btnDelete" CssClass="LinkButton" runat="server" Text="Delete" /> &nbsp;|&nbsp;
                    <asp:LinkButton ID="btnSave" CssClass="LinkButton" runat="server" Text="Save" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

