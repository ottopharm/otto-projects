<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="test.aspx.vb" Inherits="test" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="txt" runat="server" style="text-align:right" AutoPostBack="true"></asp:TextBox>
    <asp:textbox ID="txt1" runat="server" />
    <asp:TextBox ID="txt2" runat="server" AutoPostBack="true" />
    <asp:TextBox ID="txt21" runat="server" />
</asp:Content>

