<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="MasterListProdukJadi.aspx.vb" Inherits="QA_DataMaster_MasterListProdukJadi" title="Master List Produk Jadi - QA" %>
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
                    <asp:RequiredFieldValidator ID="valProdID" runat="server" ControlToValidate="txtProdID" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Nama Produk :</td>
                <td align="left">
                    <asp:Label ID="lblNamaProduk" Text="." runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Golongan :</td>
                <td>
                    <asp:DropDownList ID="ddlGol" runat="server">
                        <asp:ListItem Value="0" Text="--- Pilih Golongan ---" />
                        <asp:ListItem Value="1" Text="Obat Keras" />
                        <asp:ListItem Value="2" Text="Obat Psikotropika" />
                        <asp:ListItem Value="3" Text="Obat Bebas" />
                        <asp:ListItem Value="4" Text="Obat Bebas Terbatas (P.No.1)" />
                        <asp:ListItem Value="5" Text="Obat Bebas Terbatas (P.No.2)" />
                        <asp:ListItem Value="6" Text="Suplemen makanan" />
                        <asp:ListItem Value="7" Text="Kosmetika" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Status Produk :</td>
                <td align="left">
                    <asp:DropDownList ID="ddlStatus" runat="server">
                        <asp:ListItem Text="Aktif" Value="1" />
                        <asp:ListItem Text="Non Aktif" Value="0" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Komposisi :</td>
                <td align="left">
                    <asp:TextBox ID="txtKomposisi" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />    
                    <asp:RequiredFieldValidator ID="valKomposisi" runat="server" ControlToValidate="txtKomposisi" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">NIE :</td>
                <td align="left">
                    <asp:TextBox ID="txtNIE" runat="server" />    
                    <asp:RequiredFieldValidator ID="valNIE" runat="server" ControlToValidate="txtNIE" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Tgl. NIE :</td>
                <td align="left">
                    <asp:TextBox ID="txtTglNIE" runat="server" Width="80" />
                    <asp:ImageButton ID="btnTglNIE" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calTglNIE" runat="server"
                        TargetControlID="txtTglNIE"
                        PopupButtonID="btnTglNIE"
                        CssClass="MyCalendar"
                        Format="dd-MMM-yyyy" />
                    <asp:RequiredFieldValidator ID="valTglNIE" runat="server" ControlToValidate="txtTglNIE" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">ED NIE :</td>
                <td align="left">
                    <asp:TextBox ID="txtEDNIE" runat="server" Width="80" />
                    <asp:ImageButton ID="btnEDNIE" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calEDNIE" runat="server"
                        TargetControlID="txtEDNIE"
                        PopupButtonID="btnEDNIE"
                        CssClass="MyCalendar"
                        Format="dd-MMM-yyyy" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Umur Produk :</td>
                <td align="left">
                    <asp:TextBox ID="txtUmurProduk" runat="server" Width="60" /> &nbsp; tahun
                    <asp:RequiredFieldValidator ID="valUmurPeoduk" ControlToValidate="txtUmurProduk" ErrorMessage="*" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top">Kemasan :</td>
                <td align="left">
                    <asp:TextBox ID="txtKemasan" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                    <asp:RequiredFieldValidator ID="valKemasan" runat="server" ControlToValidate="txtKemasan" ErrorMessage="*" />
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

