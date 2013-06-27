<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptAuditInternal.aspx.vb" Inherits="QA_Report_RptAuditInternal" Title="Audit Internal Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="smMain" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumb">
    </div>
    <br />
    <rsweb:ReportViewer ID="rptAuditInternal" runat="server" Visible="true" Font-Size="Small" Width="100%" Height="500">
    
    </rsweb:ReportViewer>
    </form>
</body>
</html>
