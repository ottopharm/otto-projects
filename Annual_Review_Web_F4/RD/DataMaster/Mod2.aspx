<%@ Page Title="Perubahan Umur Produk" Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="Mod2.aspx.vb" Inherits="RD_DataMaster_Mod2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:ScriptManagerProxy ID="smProxy" runat="server">

        <Services>
            <asp:ServiceReference Path="~/WS_ProdukReview.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <div style="padding:2px;">
        <table border="0">
            <tr valign="middle">
                <td align="right">Kode Produk :</td>
                <td align="left">
                    <asp:TextBox ID="txtProdID" runat="server" />
                    <asp:RequiredFieldValidator ID="valProdID" runat="server" ValidationGroup="save" ControlToValidate="txtProdID" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Nama Produk :</td>
                <td align="left">
                    <asp:Label ID="lblNamaProduk" Text="." runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Batch Size</td>
                <td align="left">
                    <asp:TextBox ID="txtBatchSize" runat="server" Width="400" TextMode="MultiLine" Height="30" Wrap="true" />    
                    <asp:RequiredFieldValidator ID="valBatchSize" runat="server" ControlToValidate="txtBatchSize" ValidationGroup="save" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">No. CPB :</td>
                <td align="left">
                    <asp:TextBox ID="txtNoCPB" runat="server" Width="200" />
                    <asp:RequiredFieldValidator ID="valNoCPB" runat="server" ControlToValidate="txtNoCPB" ValidationGroup="save" ErrorMessage="Tidak boleh kosong!" />
                    <asp:CustomValidator ID="custNoCPB" runat="server" ControlToValidate="txtNoCPB" ValidationGroup="save" ErrorMessage="No. CPB harus diganti!"></asp:CustomValidator>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Tgl CPB :</td>
                <td align="left">
                    <asp:TextBox ID="txtTglCPB" runat="server" Width="80" />
                    <asp:ImageButton ID="btnTglCPB" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calTglCPB" runat="server"
                        TargetControlID="txtTglCPB"
                        PopupButtonID="btnTglCPB"
                        CssClass="MyCalendar"
                        Format="dd-MMM-yy" />
                    <asp:RequiredFieldValidator ID="valTglCPB" runat="server" ControlToValidate="txtTglCPB" ValidationGroup="save" ErrorMessage="Tidak boleh kosong!" />
                    <asp:CustomValidator ID="CustTglCPB" runat="server" ControlToValidate="txtTglCPB" ValidationGroup="save" ErrorMessage="Tgl. CPB harus diganti!"></asp:CustomValidator>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top">No. CKB :</td>
                <td align="left">
                    <asp:TextBox ID="txtNoCKB" runat="server" Width="200" />
                    <asp:RequiredFieldValidator ID="valNoCKB" runat="server" ControlToValidate="txtNoCKB" ValidationGroup="save" ErrorMessage="Tidak boleh kosong!" />
                    <asp:CustomValidator ID="custNoCKB" runat="server" ControlToValidate="txtNoCKB" ValidationGroup="save" ErrorMessage="No. CKB harus diganti!"></asp:CustomValidator>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Tgl CKB :</td>
                <td align="left">
                    <asp:TextBox ID="txtTglCKB" runat="server" Width="80" />
                    <asp:ImageButton ID="btnTglCKB" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calTglCKB" runat="server"
                        TargetControlID="txtTglCKB"
                        PopupButtonID="btnTglCKB"
                        CssClass="MyCalendar"
                        Format="dd-MMM-yy" />
                     <asp:RequiredFieldValidator ID="valTglCKB" runat="server" ControlToValidate="txtTglCKB" ValidationGroup="save" ErrorMessage="Tidak boleh kosong!" />
                    <asp:CustomValidator ID="custTglCKB" runat="server" ControlToValidate="txtTglCKB" ValidationGroup="save" ErrorMessage="Tgl. CKB harus diganti!"></asp:CustomValidator>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" colspan="2">
                    <asp:LinkButton ID="btnDelete" CssClass="LinkButton" runat="server" Text="Delete" /> &nbsp; | &nbsp;
                    <asp:LinkButton ID="btnSave" CssClass="LinkButton" runat="server" ValidationGroup="save" Text="Save" />
                </td>
            </tr>
        </table>
        <div style="display: none">
            <asp:TextBox ID="orgBatchSize" runat="server" EnableViewState="false" />
            <asp:TextBox ID="orgNoCPB" runat="server" EnableViewState="false" />
            <asp:TextBox ID="orgTglCPB" runat="server" EnableViewState="false" />
            <asp:TextBox ID="orgNoCKB" runat="server" EnableViewState="false" />
            <asp:TextBox ID="orgTglCKB" runat="server" EnableViewState="false" />
        </div>
    </div>
    
</asp:Content>

