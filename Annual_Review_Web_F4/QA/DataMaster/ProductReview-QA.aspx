<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="ProductReview-QA.aspx.vb" Inherits="QA_DataMaster_ProductReview_QA" title="Annual Review - QA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript">
        var txtNoBatch;

        function pageLoad() {
            txtNoBatch = $get("<%=txtNoBatch.ClientID%>");
            $addHandler(txtNoBatch, "blur", txtNoBatch_OnBlur);
            Sys.Application.add_disposing(appDispose);
        }

        function txtNoBatch_OnBlur(e) {
            if(this.value != '')
                WS_ProdukReview.ValidateNoBatch(this.value,$get("<%=txtProdID.ClientID%>").value,onSuccess, onError);
        }

        function appDispose() {
            $clearHandlers(txtNoBatch);
        }
        
        function onSuccess(result) {
            if (!result) {
                alert('No Batch Salah !');
                txtNoBatch.value = '';
                txtNoBatch.focus();
            }
            else
                <%=PostBackStr%>
        }

        function onError(err) {
            alert(err.get_message());
        }
    </script>
    <style type="text/css">
        .style1
        {
            width: 142px;
        }
        .style2
        {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManagerProxy ID="smProxy" runat="server">
        <Services>
            <asp:ServiceReference Path="~/WS_ProdukReview.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <div style="padding:2px;">
        <table border="0">
            <tr valign="middle">
                <td align="right" style="width: 142">Produk :</td>
                <td align="left">
                    <asp:Label ID="lblProdName" runat="server" Text="." />
                    <asp:TextBox ID="txtProdID" runat="server" style="display:none" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">
                    No. Batch :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNoBatch" runat="server" />
                    <asp:RequiredFieldValidator ID="valNoBatch" runat="server" ControlToValidate="txtNoBatch" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Tgl.DN :</td>
                <td align="left">
                    <asp:Label ID="lblTglDN" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" class="style2">Tgl.CPB->QC :</td>
                <td align="left" class="style2">
                    <asp:Label ID="lblTglCPBQC" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Tgl.CKB->QC :</td>
                <td align="left">
                    <asp:Label ID="lblTglCKBQC" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Tgl.CPB->QA :</td>
                <td align="left">
                    <asp:TextBox ID="txtTglCPBQA" runat="server" Width="80" />
                    <asp:ImageButton ID="btnTglCPBQA" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calTglCPBQA" runat="server"
                        TargetControlID="txtTglCPBQA"
                        PopupButtonID="btnTglCPBQA"
                        CssClass="MyCalendar"
                        Format="dd-MMM-yy" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Tgl.CKB->QA :</td>
                <td align="left">
                    <asp:TextBox ID="txtTglCKBQA" runat="server" Width="80" />
                    <asp:ImageButton ID="btnTglCKBQA" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calTglCKBQA" runat="server"
                        TargetControlID="txtTglCKBQA"
                        PopupButtonID="btnTglCKBQA"
                        CssClass="MyCalendar"
                        Format="dd-MMM-yy" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Tgl.CPB/CKB->QA :</td>
                <td align="left">
                    <asp:TextBox ID="txtTglCPBCKBQA" runat="server" Width="80" />
                    <asp:ImageButton ID="btnTglCPBCKBQA" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calCPBCKBQA" runat="server"
                        TargetControlID="txtTglCPBCKBQA"
                        PopupButtonID="btnTglCPBCKBQA"
                        CssClass="MyCalendar"
                        Format="dd-MMM-yy" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Tgl.CoA->QA :</td>
                <td align="left">
                    <asp:TextBox ID="txtTglCoAQA" runat="server" Width="80" />
                    <asp:ImageButton ID="btnTglCoAQA" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calCoAQA" runat="server"
                        TargetControlID="txtTglCoAQA"
                        PopupButtonID="btnTglCoAQA"
                        CssClass="MyCalendar"
                        Format="dd-MMM-yy" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Tgl. Masuk ke Gudang CPB/CKB :</td>
                <td align="left">
                    <asp:TextBox ID="txtTglGudang" runat="server" Width="80" />
                    <asp:ImageButton ID="btnTglGudang" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calTglGudang" runat="server"
                        TargetControlID="txtTglGudang"
                        PopupButtonID="btnTglGudang"
                        CssClass="MyCalendar"
                        Format="dd-MMM-yy" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top" class="style1">Ket. CPB :</td>
                <td align="left">
                    <asp:TextBox ID="txtCPB" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top" class="style1">Ket. CPB-P :</td>
                <td align="left">
                    <asp:TextBox ID="txtCPBP" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top" class="style1">Ket. CKB-Prm :</td>
                <td align="left">
                    <asp:TextBox ID="txtCKBP" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top" class="style1">Ket. CKB-Sk :</td>
                <td align="left">
                    <asp:TextBox ID="txtCKBS" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top" class="style1">Deviasi :</td>
                <td align="left">
                    <asp:TextBox ID="txtDeviasi" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top" class="style1">Keluhan :</td>
                <td align="left">
                    <asp:TextBox ID="txtKeluhan" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top" class="style1">HULS :</td>
                <td align="left">
                    <asp:TextBox ID="txtHULS" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" colspan="2">
                    <asp:LinkButton ID="btnSave" CssClass="LinkButton" runat="server" ValidationGroup="SYR" Text="Save" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

