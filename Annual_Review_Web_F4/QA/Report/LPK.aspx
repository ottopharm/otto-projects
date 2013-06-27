<%@ Page Title="Evaluasi LPK" Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="LPK.aspx.vb" Inherits="QA_Report_LPK" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellspacing="0" cellpadding="5" style="background-color:#F2F4FD;">
        <tr valign="middle">
            <td align="right">Tgl. LPK :</td>
            <td align="left">
                <asp:TextBox ID="txtFromDate" runat="server" Width="80" />
                <asp:ImageButton ID="btnFromDate" runat="server" ImageUrl="~/Image/25.png" /> 
                <asp:RequiredFieldValidator ID="valFromDate" runat="server" ControlToValidate="txtFromDate" ErrorMessage="*" /> &nbsp; s/d &nbsp;
                <asp:TextBox ID="txtToDate" runat="server" Width="80" />
                <asp:ImageButton ID="btnToDate" runat="server" ImageUrl="~/Image/25.png" />
                <asp:RequiredFieldValidator ID="valToDate" runat="server" ControlToValidate="txtToDate" ErrorMessage="*" />
                <AjaxToolkit:CalendarExtender ID="calFromDate" runat="server"
                    TargetControlID="txtFromDate"
                    PopupButtonID="btnFromDate"
                    Format="dd-MMM-yy"
                    CssClass="MyCalendar" />
                <AjaxToolkit:CalendarExtender ID="calToDate" runat="server"
                    TargetControlID="txtToDate"
                    PopupButtonID="btnToDate"
                    Format="dd-MMM-yy"
                    CssClass="MyCalendar" />
            </td>
        </tr>
        <tr valign="middle">
            <td align="right">Kategory LPK :</td>
            <td>
                <asp:DropDownList ID="ddlCatEvaluasi" DataSourceID="oEvaluasi" runat="server"
                    DataTextField="Evaluasi" DataValueField="EvalCode" />
            </td>
        </tr>
        <tr valign="middle">
            <td colspan="2" style="background-color:White; text-align: center">
                <asp:LinkButton ID="btnFind" runat="server" CssClass="LinkButton" Text="Get Data" />
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="oEvaluasi" runat="server"
        TypeName="ProdukRetur"
        SelectMethod="GetAllEvaluasiCat">
    </asp:ObjectDataSource>     
</asp:Content>

