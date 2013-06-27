<%@ Page Title="Laporan Evaluasi Produk Kembalian" Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="RptLPK.aspx.vb" Inherits="QA_Report_RptLPK" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SiteMapPath ID="siteMapPath" runat="server"
             CssClass="siteMapPath" 
             PathSeparatorStyle-CssClass="breadcrumb" />
    <rsweb:ReportViewer ID="rptLPK" Width="100%" style="min-height: 400px" runat="server">
    </rsweb:ReportViewer>
</asp:Content>

