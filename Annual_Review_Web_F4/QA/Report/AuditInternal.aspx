<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="AuditInternal.aspx.vb" Inherits="QA_Report_AuditInternal" Title="Audit Internal Form" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellspacing="0" cellpadding="5" style="background-color:#F2F4FD;">
        <!--<tr valign="middle">
            <td align="right">Departemen :</td>
            <td>
                <asp:DropDownList ID="ddlDepartemen" runat="server"
                    DataSourceID="oDept" DataTextField="DeptName" DataValueField="DeptId">
                </asp:DropDownList>
            </td>
        </tr>--> 
        <tr valign="middle">
            <td align="right">Tingkat Resiko :</td>
            <td><asp:DropDownList ID="ddlResiko" runat="server">
                <asp:ListItem Text="ALL" Value="A" Selected="True" />
                <asp:ListItem Text="Critical" Value="1" />
                <asp:ListItem Text="Mayor" Value="2" />
                <asp:ListItem Text="Minor" Value="3" />
            </asp:DropDownList></td>
        </tr>
        <tr valign="middle">
            <td align="right">Status :</td>
            <td>
                <asp:DropDownList ID="ddlIsClosed" runat="server">
                    <asp:ListItem Text="ALL" Value="A" Selected="True" />
                    <asp:ListItem Text="Open" Value="0" />
                    <asp:ListItem Text="Closed" Value="1" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr valign="middle">
            <td colspan="2" style="background-color:White; text-align: center">
                <asp:LinkButton ID="btnFind" runat="server" CssClass="LinkButton" Text="Get Data" />
            </td>
        </tr>
    </table>
       <!-- <asp:ObjectDataSource ID="oDept" runat="server"
        TypeName="ChangeControl"
        SelectMethod="GetDepartment"></asp:ObjectDataSource>-->
</asp:Content>

