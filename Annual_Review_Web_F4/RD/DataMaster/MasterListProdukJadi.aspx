<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false"
    CodeFile="MasterListProdukJadi.aspx.vb" Inherits="QA_DataMaster_MasterListProdukJadi"
    Title="Master List Produk Jadi - QA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        var txt_ProdID

        function pageLoad() {
            txt_ProdID = $get("<%=txtProdID.ClientID%>");
            $addHandler(txt_ProdID, "blur", txtProdID_onBlur);
            Sys.Application.add_disposing(appDispose);
        }

        function txtProdID_onBlur(e) {
            if (this.value != '')
                WS_ProdukReview.ValidateProdID(this.value, onSuccess, onError);
        }

        function appDispose() {
            $clearHandlers(txt_ProdID);
        }

        function onSuccess(result) {
            if (!result) {
                alert('Produk ID belum terdaftar dalam database!');
                txt_ProdID.value = '';
                txt_ProdID.focus();
            }
            else
                <%=PostBackStr%>
        }

        function onError(err) {
            alert(err.get_message());
        }
                
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="smProxy" runat="server">
        <Services>
            <asp:ServiceReference Path="~/WS_ProdukReview.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <div style="padding: 2px;">
        <table border="0">
            <tr valign="middle">
                <td align="right">
                    Kode Produk :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtProdID" runat="server" />
                    <asp:RequiredFieldValidator ID="valProdID" runat="server" ControlToValidate="txtProdID"
                        ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">
                    Nama Produk :
                </td>
                <td align="left">
                    <asp:Label ID="lblNamaProduk" Text="." runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">
                </td>
                <td align="left">
                    <asp:RadioButton ID="rbInhouse" runat="server" Text="Inhouse" GroupName="InToll" />
                    <asp:RadioButton ID="rbTollOut" runat="server" Text="Toll out" GroupName="InToll" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">
                    Batch Size
                </td>
                <td align="left">
                    <asp:TextBox ID="txtBatchSize" runat="server" Width="400" TextMode="MultiLine" Height="30"
                        Wrap="true" />
                    <asp:RequiredFieldValidator ID="valBatchSize" runat="server" ControlToValidate="txtBatchSize"
                        ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">
                    Umur Produk :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtUmurProduk" runat="server" Width="60" />
                    <asp:RequiredFieldValidator ID="valUmurProduk" runat="server" ControlToValidate="txtUmurProduk"
                        ErrorMessage="*" />
                    &nbsp; tahun
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">
                    Kondisi Simpan :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtKondisiSimpan" runat="server" Width="400" TextMode="MultiLine"
                        Height="30" Wrap="true" />
                    <asp:RequiredFieldValidator ID="valKondisiSimpan" runat="server" ControlToValidate="txtKondisiSimpan"
                        ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">
                    No. CPB :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNoCPB" runat="server" Width="200" />
                    <asp:RequiredFieldValidator ID="valNoCPB" runat="server" ControlToValidate="txtNoCPB"
                        ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">
                    Tgl CPB :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtTglCPB" runat="server" Width="80" />
                    <asp:ImageButton ID="btnTglCPB" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calTglCPB" runat="server" TargetControlID="txtTglCPB"
                        PopupButtonID="btnTglCPB" CssClass="MyCalendar" Format="dd-MMM-yy" />
                    <asp:RequiredFieldValidator ID="valTglCPB" runat="server" ControlToValidate="txtTglCPB"
                        ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top">
                    No. CKB :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNoCKB" runat="server" Width="200" />
                    <asp:RequiredFieldValidator ID="val" runat="server" ControlToValidate="txtNoCKB"
                        ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">
                    Tgl CKB :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtTglCKB" runat="server" Width="80" />
                    <asp:ImageButton ID="btnTglCKB" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calTglCKB" runat="server" TargetControlID="txtTglCKB"
                        PopupButtonID="btnTglCKB" CssClass="MyCalendar" Format="dd-MMM-yy" />
                    <asp:RequiredFieldValidator ID="valTglCKB" runat="server" ControlToValidate="txtTglCKB"
                        ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top">
                    No. PBP OJ :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPBPOJ" runat="server" Width="200" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">
                    Tgl PBP OJ :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtTglPBPOJ" runat="server" Width="80" />
                    <asp:ImageButton ID="btnPBPOJ" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calPBPOJ" runat="server" TargetControlID="txtTglPBPOJ"
                        PopupButtonID="btnPBPOJ" CssClass="MyCalendar" Format="dd-MMM-yy" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top">
                    Ref. PBP OJ :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtRefPBPOJ" runat="server" Width="200" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" colspan="2">
                    <asp:LinkButton ID="btnSave" CssClass="LinkButton" runat="server" Text="Save" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
