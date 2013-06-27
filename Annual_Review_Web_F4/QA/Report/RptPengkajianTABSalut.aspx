<%@ Page Title="Laporan Pengkajian Mutu TSS / TSG" Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="RptPengkajianTABSalut.aspx.vb" Inherits="QA_Report_RptPengkajianTABSalut" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="rptPengkajianTab" Width="100%" style="min-height:400px" runat="server">
    </rsweb:ReportViewer>
</asp:Content>

