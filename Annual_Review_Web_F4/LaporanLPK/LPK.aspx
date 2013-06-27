<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="LPK.aspx.vb" Inherits="Logistik_Report_LPK" Title="Laporan Produk Kembalian" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="pnlLPK" DefaultButton="btnFind" runat="server">
        <table border="0" cellspacing="0" cellpadding="5" style="background-color:#F2F4FD;">
            <tr valign="middle">
                <td align="right">No. LPK :</td>
                <td align="left">
                    <asp:TextBox ID="txtNoLPK" runat="server" Width="100" />
                </td>
                <td>
                    <asp:LinkButton ID="btnFind" runat="server" CssClass="LinkButton" Text="Get Data" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

