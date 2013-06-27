<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptProdReview.aspx.vb" Inherits="QA_Report_RptProdReview" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
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
            <asp:SiteMapPath ID="siteMapPath" runat="server"
                 CssClass="siteMapPath" 
                 PathSeparatorStyle-CssClass="breadcrumb" />
        </div>
        <br />
        <rsweb:ReportViewer ID="rptProdReview" runat="server" Visible="True" Width="100%" Height="450" Font-Size="Small">
           
        </rsweb:ReportViewer>
    </form>
</body>
</html>
