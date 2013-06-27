<%@ Page Title="Laporan Pengkajian Mutu Syrup Kering" Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="RptPengkajianSYK.aspx.vb" Inherits="QA_Report_RptPengkajianSYK" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="rptPengkajianSYK" Width="100%" style="min-height:400px" runat="server">
    </rsweb:ReportViewer>
</asp:Content>

