<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="PengkajianMutuProduk.aspx.vb" Inherits="PengkajianMutuProduk" title="Pengkajian Mutu Produk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript">
        var txt_ProdID

        function pageLoad() {
            txt_ProdID = $get("<%=txtProdID.ClientID%>");
            $addHandler(txt_ProdID, "blur", txtProdID_onBlur);
            Sys.Application.add_disposing(appDispose);
        }

        function txtProdID_onBlur(e) {
            if(this.value != '')
                WS_PengkajianMutu.ValidateItemCode(this.value, onSuccess, onError);
        }

        function appDispose() {
            $clearHandlers(txt_ProdID);
        }
        
        function onSuccess(result) {
            if (!result){
                alert('Kode Produk belum terdaftar dalam APR!');
                txt_ProdID.value = '';
                txt_ProdID.focus();
            }
        }

        function onError(err) {
            alert(err.get_message());
        }
                
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManagerProxy ID="proxy" runat="server">
        <Services>
            <asp:ServiceReference Path="~/WS_PengkajianMutu.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <asp:Panel ID="pnl" runat="server" DefaultButton="btnFind">
        <table border="0">
            <tr valign="middle">
                <td colspan="3">
                    Masukkan Kode Produk terlebih dahulu
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">
                    Kode Produk :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtProdID" runat="server" />
                    <asp:RequiredFieldValidator ID="valProdID" runat="server" ControlToValidate="txtProdID" ErrorMessage="*" />
                </td>
            </tr>
            <tr>
            <td align="right">
                    [Khusus Tablet / Kaplet]
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlTab" runat="server">
                        <asp:ListItem Text="Salut" Value="s" />
                        <asp:ListItem Text="NonSalut" Value="n" />
                    </asp:DropDownList>
                </td>
                <td align="left">
                    <asp:ImageButton ID="btnFind" runat="server" 
                        ImageUrl="~/Image/001_60.png" 
                        ToolTip="Find Produk" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    
</asp:Content>

