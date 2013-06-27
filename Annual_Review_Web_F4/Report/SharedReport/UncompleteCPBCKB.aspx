<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="UncompleteCPBCKB.aspx.vb" Inherits="UncompleteCPBCKB" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <rsweb:ReportViewer ID="rptCPBCKB" Width="100%" runat="server" Font-Names="Trebuchet MS" Font-Size="Small" Visible="False">
    </rsweb:ReportViewer>
</asp:Content>

