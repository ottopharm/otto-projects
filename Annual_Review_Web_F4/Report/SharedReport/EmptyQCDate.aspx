<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="EmptyQCDate.aspx.vb" Inherits="QA_Report_EmptyQCDate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h3>Daftar Batch yang Belum Ada Tanggal QC</h3>
        <table border="0">
            <tr valign="middle">
                <td>Periode :</td>
                <td>
                    <asp:TextBox ID="txtFromDate" runat="server" Width="80" />
                    <asp:ImageButton ID="btnFromDate" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calFromDate" runat="server"
                        TargetControlID="txtFromDate"
                        PopupButtonID="btnFromDate"
                        CssClass="MyCalendar"
                        Format="d-MMM-yy" />
                    <asp:RequiredFieldValidator ID="valFromDate" runat="server" ErrorMessage="*" ControlToValidate="txtFromDate" />
                </td>
                <td>s/d</td>
                <td>
                    <asp:TextBox ID="txtToDate" runat="server" Width="80" />
                    <asp:ImageButton ID="btnToDate" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calToDate" runat="server"
                        TargetControlID="txtToDate"
                        PopupButtonID="btnToDate"
                        CssClass="MyCalendar"
                        Format="d-MMM-yy">
                    </AjaxToolkit:CalendarExtender>
                    <asp:RequiredFieldValidator ID="valToDate"  runat="server" ControlToValidate="txtToDate" ErrorMessage="*" />
                </td>
                <td>
                    <asp:LinkButton ID="btnGetData" runat="server" CssClass="LinkButton" Text="Get Data" />
                </td>
            </tr>
        </table>
    </div>
    <div style="margin-top:5px">
        <rsweb:ReportViewer ID="rptEmptyQCDate" runat="server" 
            Width="100%" Height="500" Font-Names="Trebuchet MS" Visible="false" >
            <LocalReport>
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="dsOtto" Name="dsOtto_EmptyTglQC" />
                </DataSources>
            </LocalReport> 
        </rsweb:ReportViewer>
    </div>
</asp:Content>

