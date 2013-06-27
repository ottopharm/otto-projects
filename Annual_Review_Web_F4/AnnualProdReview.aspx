<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="AnnualProdReview.aspx.vb" Inherits="AnnualProdReview" title="Product Review" %>

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
                WS_ProdukReview.ValidateProdID(this.value, onSuccess, onError);
        }

        function appDispose() {
            $clearHandlers(txt_ProdID);
        }
        
        function onSuccess(result) {
            if (!result){
                alert('Produk ID belum terdaftar dalam database!');
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
            <asp:ServiceReference Path="~/WS_ProdukReview.asmx" />
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
                <td align="left">
                    <asp:ImageButton ID="btnFind" runat="server" 
                        ImageUrl="~/Image/001_60.png" 
                        ToolTip="Find Produk" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    
</asp:Content>

