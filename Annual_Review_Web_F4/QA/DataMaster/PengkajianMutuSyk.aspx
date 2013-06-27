<%@ Page Title="Pengkajian Mutu Syrup Kering" Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="PengkajianMutuSyk.aspx.vb" Inherits="QA_DataMaster_PengkajianMutuSyk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">

       var txtProdID, txtNoBatch, lblTglProduksi, lblMixing;
       function pageLoad() {
           txtProdID = $get("<%=txtProdID.ClientID%>");
           txtNoBatch = $get("<%=txtNoBatch.ClientID%>");
           lblTglProduksi = $get("<%=lblTglProduksi.ClientID%>")
           lblMixing = $get("<%=lblMixing.ClientID%>")
           $addHandler(txtNoBatch, "blur", txtNoBatch_OnBlur);
           Sys.Application.add_disposing(appDispose);
       }

       function txtNoBatch_OnBlur(e) {
           if (this.value != '')
               WS_PengkajianMutu.ValidateBatch(this.value, txtProdID.value, onSuccess, onError);
       }

       function onSuccess(result) {
           if (result == '') {
               alert('No Batch belum ada dalam APR\n Coba masukkan kode yang lain');
               txtNoBatch.value = '';
               lblTglProduksi.innerHTML = '';
               lblMixing.innerHTML = '';
               txtNoBatch.focus();
           } else {
               <%=PostBackStr%>
           }
       }

       function appDispose() {
           $clearHandlers(txtNoBatch);
       }

       function onError(err) {
           alert(err.get_message());
       }
   </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManagerProxy ID="smProxy" runat="server">
        <Services>
            <asp:ServiceReference Path="~/WS_PengkajianMutu.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <div id="breadcrumb">
        <asp:SiteMapPath ID="siteMapPath" runat="server"
            CssClass="siteMapPath" 
            PathSeparatorStyle-CssClass="breadcrumb" />
    </div>
    <div style="padding:2px;">
        <table border="0">
            <tr valign="middle">
                <td align="right">Produk :</td>
                <td align="left">
                    <asp:Label ID="lblProdName" runat="server" Text="." />
                    <asp:TextBox ID="txtProdID" runat="server" style="display:none" />
                </td>
                <td style="width:40px"></td>
                <td colspan="2"></td>
            </tr>
            <tr valign="middle">
                <td align="right">
                    No. Batch :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNoBatch" Width="90" runat="server" />
                    <asp:RequiredFieldValidator ID="valNoBatch" runat="server" ValidationGroup="master" ControlToValidate="txtNoBatch" ErrorMessage="*" />
                </td>
                <td></td>
                <td align="right">
                    Besar Batch :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtBesarBatch" Width="90" runat="server" />
                    <asp:DropDownList ID="ddlUoM" runat="server">
                        <asp:ListItem Text="Kg" Value="kg" />
                        <asp:ListItem Text="Liter" Value="liter" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Tgl. Produksi :</td>
                <td align="left">
                    <asp:Label ID="lblTglProduksi" runat="server" Text="." />
                </td>
                <td></td>
                <td align="right">ED :</td>
                <td align="left">
                    <asp:Label ID="lblED" Text="." runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Waktu Mixing (jam) :</td>
                <td align="left">
                    <asp:Label ID="lblMixing" Text="." runat="server" />
                </td>
                <td></td>
                <td align="right">Waktu Filling (jam) :</td>
                <td align="left">
                    <asp:Label ID="lblFilling" Text="." runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Waktu Pengemasan Sekunder (jam) :</td>
                <td align="left">
                    <asp:Label ID="lblJamKerja" Text="." runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil Kemas Sekunder (%) :</td>
                <td align="left">
                    <asp:Label ID="lblRendemen" Text="." runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="background-color:Silver; font-weight: bold; padding:10px">
                    pH
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek :</td>
                <td align="left">
                    <asp:TextBox ID="txtpHSpek" Width="90" runat="server" />
                </td>
                <td colspan="3"></td>
            </tr>
            <tr valign="middle">
                <td align="right">Massa :</td>
                <td align="left">
                    <asp:TextBox ID="txtpHMassa" Width="90" style="text-align:right" runat="server" />
                </td>
                <td></td>
                <td align="right">Botol :</td>
                <td align="left">
                    <asp:TextBox ID="txtpHBotol" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="background-color:Silver; font-weight: bold; padding:10px">
                    Bobot Massa per ml</td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek :</td>
                <td align="left">
                    <asp:TextBox ID="txtBobotMassaSpek" Width="90" runat="server" />
                </td>
                <td colspan="3"></td>
            </tr>
            <tr valign="middle">
                <td align="right">Massa :</td>
                <td align="left">
                    <asp:TextBox ID="txtBobotMassaHasil" Width="90" style="text-align:right" runat="server" />
                </td>
                <td></td>
                <td align="right">Botol :</td>
                <td align="left">
                    <asp:TextBox ID="txtBobotBotolHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="background-color:Silver; font-weight: bold; padding:10px">
                    Viskositas</td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek :</td>
                <td align="left" colspan="4">
                    <asp:TextBox ID="txtViskositsaSpek" Width="90" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Massa :</td>
                <td align="left">
                    <asp:TextBox ID="txtViskositasMassa" Width="90" style="text-align:right" runat="server" />
                </td>
                <td></td>
                <td align="right">Botol :</td>
                <td align="left">
                    <asp:TextBox ID="txtViskositasBotol" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="background-color:Silver; font-weight: bold; padding:10px">
                    Bobot Isi Botol / Sachet</td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek :</td>
                <td align="left">
                    <asp:TextBox ID="txtBobotIsiSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil :</td>
                <td align="left">
                    <asp:TextBox ID="txtBobotIsiHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="background-color:Silver; font-weight: bold; padding:10px">
                    Penyimpangan
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek Min :</td>
                <td align="left">
                    <asp:TextBox ID="txtSimpangSpekMin" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil Min :</td>
                <td align="left">
                    <asp:TextBox ID="txtSimpangMinHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek Maks :</td>
                <td align="left">
                    <asp:TextBox ID="txtSimpangSpekMax" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil Maks :</td>
                <td align="left">
                    <asp:TextBox ID="txtSimpangMaxHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="background-color:Silver; font-weight: bold; padding:10px">
                    % Air</td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek :</td>
                <td align="left" colspan="4">
                    <asp:TextBox ID="txtAirSpek" Width="90" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Massa :</td>
                <td align="left">
                    <asp:TextBox ID="txtAirMassa" Width="90" style="text-align:right" runat="server" />
                </td>
                <td></td>
                <td align="right">Botol :</td>
                <td align="left">
                    <asp:TextBox ID="txtAirBotol" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="background-color:Silver; font-weight: bold; padding:10px">
                    Uji Batas Microba</td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek Aerob Total :</td>
                <td align="left">
                    <asp:TextBox ID="txtAerobSpek" Width="120" runat="server" />
                </td>
                <td></td>
                <td align="right">Spek Aerob Hasil :</td>
                <td align="left">
                    <asp:TextBox ID="txtAerobHasil" style="text-align:right" Width="90" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek Kapang Khamir :</td>
                <td align="left">
                    <asp:TextBox ID="txtKhamirSpek" Width="120" runat="server" />
                </td>
                <td></td>
                <td align="right">Kapang Khamir Hasil :</td>
                <td align="left">
                    <asp:TextBox ID="txtKhamirHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="background-color:Silver; font-weight: bold; padding:10px">
                    Bakteri Patogen</td>
            </tr>
            <tr valign="middle">
                <td align="right">E.coli :</td>
                <td align="left">
                    <asp:DropDownList ID="ddlEcoli" runat="server">
                        <asp:ListItem Text="--" Value="-" />
                        <asp:ListItem Text="Positif" Value="positif" />
                        <asp:ListItem Text="Negatif" Value="negatif" />
                    </asp:DropDownList>
                </td>
                <td></td>
                <td align="right">Salmonelia Sp :</td>
                <td align="left">
                    <asp:DropDownList ID="ddlSalmonelia" runat="server">
                        <asp:ListItem Text="--" Value="-" />
                        <asp:ListItem Text="Positif" Value="positif" />
                        <asp:ListItem Text="Negatif" Value="negatif" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Psedomonas Aeruginosa :</td>
                <td align="left">
                    <asp:DropDownList ID="ddlPseudomonas" runat="server">
                        <asp:ListItem Text="--" Value="-" />
                        <asp:ListItem Text="Positif" Value="positif" />
                        <asp:ListItem Text="Negatif" Value="negatif" />
                    </asp:DropDownList>
                </td>
                <td></td>
                <td align="right">Staphylococcus Sp :</td>
                <td align="left">
                    <asp:DropDownList ID="ddlStaphylococcus" runat="server">
                        <asp:ListItem Text="--" Value="-" />
                        <asp:ListItem Text="Positif" Value="positif" />
                        <asp:ListItem Text="Negatif" Value="negatif" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="background-color:Silver; font-weight: bold; padding:10px">
                    Moisture Content</td>
            </tr>
             <tr valign="middle">
                <td align="right">Spek :</td>
                <td align="left" colspan="4">
                    <asp:TextBox ID="txtMoisSpek" Width="90" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Massa :</td>
                <td align="left">
                    <asp:TextBox ID="txtMoisMassa" Width="90" style="text-align:right" runat="server" />
                </td>
                <td></td>
                <td align="right">Botol :</td>
                <td align="left">
                    <asp:TextBox ID="txtMoisSachet" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="center" colspan="5">
                    <asp:LinkButton ID="btnDelete" CssClass="LinkButton" Enabled="false" 
                        OnClientClick="return confirm('Are you sure ?');"  runat="server" Text="Delete" /> &nbsp;|&nbsp;
                    <asp:LinkButton ID="btnSave" CssClass="LinkButton" ValidationGroup="master" runat="server" Text="Save" />
                </td>
            </tr>
        </table>
        <div style="background-color: #7E7E7E; padding-left: 5px; margin-top: 10px; margin-bottom: 10px">
            <h1>Kadar</h1>
        </div>
        <asp:UpdatePanel ID="upKadar" runat="server">
        <ContentTemplate>
            <table style="float: left;">
                <tr valign="middle">
                    <td align="right">Kadar :</td>
                    <td align="left">
                        <asp:TextBox ID="txtKadar" runat="server" />
                        <asp:RequiredFieldValidator ID="valSpek" ControlToValidate="txtKadar" ErrorMessage="*" ValidationGroup="kadar" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Spek Kadar :</td>
                    <td align="left">
                        <asp:TextBox ID="txtKadarSpek" runat="server" />
                        <asp:RequiredFieldValidator ID="valJenisKadar" ControlToValidate="txtKadarSpek" ErrorMessage="*" ValidationGroup="kadar" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Massa :</td>
                    <td align="left">
                        <asp:TextBox ID="txtKadarMassa" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Botol :</td>
                    <td align="left">
                        <asp:TextBox ID="txtKadarBotol" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right" colspan="2">
                        <asp:LinkButton ID="btnHapus" CssClass="LinkButton" Enabled="false" Text="Delete" runat="server" />&nbsp;|&nbsp;
                        <asp:LinkButton ID="btnAdd" CssClass="LinkButton" ValidationGroup="kadar" Enabled="false" Text="Save" runat="server" />
                    </td>
                </tr>
            </table>
            <div style="float: left; margin-left: 10px">
                <asp:GridView ID="gvKadar" runat="server" AllowSorting="true" AutoGenerateColumns="false" AlternatingRowStyle-BackColor="#F7F7F7"
                    DataKeyNames="LineID" BorderColor="#333333" CellPadding="5">
                    <Columns>
                        <asp:TemplateField ShowHeader="false" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnSelect" CssClass="LinkButton" Text="Select" CommandName="Select" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Kadar" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label id="lblKadar" Text='<%# Eval("Kadar") %>' runat="server" /> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Spek Kadar" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblSpekKadar" Text='<%# Eval("KadarSpek") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Massa" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblKadarMassa" Text='<%# Eval("KadarMassa") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Botol" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblKadarBotol" Text='<%# Eval("KadarBotol") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblLineID" Text='<%# Eval("LineID") %>' style="display:none" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:TextBox ID="txtKadarLineID" style="display:none" Text="0" runat="server" />
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>
        <div style="clear: left">&nbsp;</div>
    </div>
    <asp:ObjectDataSource ID="oKadar" runat="server"
        TypeName="PengkajianMutu"
        SelectMethod="GetSYK">
        <SelectParameters>
            <asp:ControlParameter Name="ItemCode" ControlID="txtProdID" PropertyName="text" Type="String" />
            <asp:ControlParameter Name="Batch" ControlID="txtNoBatch" PropertyName="text" Type="String" />
            <asp:Parameter Name="TargetTable" Type="Int16" DefaultValue="2" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

