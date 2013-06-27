<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="MasterListDoc.aspx.vb" Inherits="MasterListReport_MasterListDoc" title="Master List Kode Dokumen CPB dan CKB" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding:2px">
        <div id="searchBased">
            <table border="0" cellspacing="0" cellpadding="5" style="background-color:#F2F4FD;">
                <tr valign="middle">
                    <td align="right">Kode Produk :</td>
                    <td align="left">
                        <asp:TextBox ID="txtProdID" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td colspan="2" style="background-color:White; text-align: center">
                        <asp:LinkButton ID="btnGetRpt" runat="server" CssClass="LinkButton" Text="Get Data" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="padding-top: 10px">
            <rsweb:ReportViewer ID="RptMasterList" runat="server" Font-Size="Small" Width="100%" Visible="false">
            </rsweb:ReportViewer>  
        </div>
    </div>
</asp:Content>

