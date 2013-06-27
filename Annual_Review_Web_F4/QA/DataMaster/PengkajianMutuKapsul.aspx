<%@ Page Title="Pengkajian Mutu Kapsul" Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="PengkajianMutuKapsul.aspx.vb" Inherits="QA_DataMaster_PengkajianMutuKapsul" %>

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
            <tr valign="middle">
                <td align="right">Spek Bobot Rata-rata Cangkang :</td>
                <td align="left">
                    <asp:TextBox ID="txtCangkangSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil Bobot Rata-rata Cangkang :</td>
                <td align="left">
                    <asp:TextBox ID="txtCangkangHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek Bobot Rata-rata Isi Kapsul :</td>
                <td align="left">
                    <asp:TextBox ID="txtKapsulSpek" Width="90" runat="server" />
                </td>
                <td></td>
                 <td align="right">Hasil Bobot Rata-rata Isi Kapsul :</td>
                <td align="left">
                    <asp:TextBox ID="txtKapsulHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
           <tr valign="middle">
                <td align="right">Spek Waktu Hancur :</td>
                <td align="left">
                    <asp:TextBox ID="txtWaktuHancurSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil Waktu Hancur :</td>
                <td align="left">
                    <asp:TextBox ID="txtWaktuHancurHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="background-color:Silver; font-weight: bold; padding:10px">
                    Variasi Bobot cangkang + isi
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek Max :</td>
                <td align="left">
                    <asp:TextBox ID="txtVariasiMaxSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil Max :</td>
                <td align="left">
                    <asp:TextBox ID="txtVariasiMaxHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek Min :</td>
                <td align="left">
                    <asp:TextBox ID="txtVariasiMinSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil Min :</td>
                <td align="left">
                    <asp:TextBox ID="txtVariasiMinHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="background-color:Silver; font-weight: bold; padding:10px">
                    Penyimpangan
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek Penyimpangan Max :</td>
                <td align="left">
                    <asp:TextBox ID="txtPenyimpanganMaxSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil Penyimpangan Max :</td>
                <td align="left">
                    <asp:TextBox ID="txtPenyimpanganMaxHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek Penyimpangan Min :</td>
                <td align="left">
                    <asp:TextBox ID="txtPenyimpanganMinSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil Penyimpangan Min :</td>
                <td align="left">
                    <asp:TextBox ID="txtPenyimpanganMinHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="background-color:Silver; font-weight: bold; padding:10px">
                    Kadar Air
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek Kadar Air :</td>
                <td align="left" colspan="4">
                    <asp:TextBox ID="txtKadarAirSpek" Width="90" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Hasil Massa :</td>
                <td align="left">
                    <asp:TextBox ID="txtKadarMassaHasil" Width="90" style="text-align:right" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil Kapsul :</td>
                <td align="left">
                    <asp:TextBox ID="txtKadarKapsulHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="background-color:Silver; font-weight: bold; padding:10px">
                    Keseragaman Kandungan
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Hasil Min :</td>
                <td align="left">
                    <asp:TextBox ID="txtKandunganMinHasil" Width="90" style="text-align:right" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil Max :</td>
                <td align="left">
                    <asp:TextBox ID="txtKandunganMaxHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek RSD :</td>
                <td align="left">
                    <asp:TextBox ID="txtKandunganRSDSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil RSD :</td>
                <td align="left">
                    <asp:TextBox ID="txtKandunganRSDHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek AV :</td>
                <td align="left">
                    <asp:TextBox ID="txtKandunganAVSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil AV :</td>
                <td align="left">
                    <asp:TextBox ID="txtKandunganAVHasil" Width="90" style="text-align:right" runat="server" />
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
                        <asp:TextBox ID="txtSpek" runat="server" />
                        <asp:RequiredFieldValidator ID="valSpek" ControlToValidate="txtSpek" ErrorMessage="*" ValidationGroup="kadar" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Spek Kadar :</td>
                    <td align="left">
                        <asp:TextBox ID="txtJenisKadar" runat="server" />
                        <asp:RequiredFieldValidator ID="valJenisKadar" ControlToValidate="txtJenisKadar" ErrorMessage="*" ValidationGroup="kadar" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Massa :</td>
                    <td align="left">
                        <asp:TextBox ID="txtMassa" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Kapsul :</td>
                    <td align="left">
                        <asp:TextBox ID="txtKapsul" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right" colspan="2">
                        <asp:LinkButton ID="btnKadarHapus" CssClass="LinkButton" Enabled="false" Text="Delete" runat="server" />&nbsp;|&nbsp;
                        <asp:LinkButton ID="btnKadarAdd" CssClass="LinkButton" ValidationGroup="kadar" Enabled="false" Text="Save" runat="server" />
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
                                <asp:Label ID="lblSpekKadar" Text='<%# Eval("KadarSpek") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Spek Kadar" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label id="lblJenisKadar" Text='<%# Eval("KadarJenis") %>' runat="server" /> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Massa" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblKadarMassa" Text='<%# Eval("KadarMassa") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Kapsul" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblKadarKapsul" Text='<%# Eval("KadarKapsul") %>' runat="server" />
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
        <div style="background-color: #7E7E7E; padding-left: 5px; margin-top: 10px; margin-bottom: 10px; clear: left">
            <h1>Disolusi</h1>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="float: left;">
                <tr valign="middle">
                    <td align="right">Disolusi :</td>
                    <td align="left">
                        <asp:TextBox ID="txtDisolusi" runat="server" />
                        <asp:RequiredFieldValidator ID="valDisolusi" ControlToValidate="txtDisolusi" ErrorMessage="*" ValidationGroup="disolusi" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Spek Disolusi :</td>
                    <td align="left">
                        <asp:TextBox ID="txtJenisDisolusi" runat="server" />
                        <asp:RequiredFieldValidator ID="valJenisDisolusi" ControlToValidate="txtJenisDisolusi" ErrorMessage="*" ValidationGroup="disolusi" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Min :</td>
                    <td align="left">
                        <asp:TextBox ID="txtDisolusiMin" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Max :</td>
                    <td align="left">
                        <asp:TextBox ID="txtDisolusiMax" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Rata-rata :</td>
                    <td align="left">
                        <asp:TextBox ID="txtDisolusiAvg" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right" colspan="2">
                        <asp:LinkButton ID="btnDisolusiHapus" CssClass="LinkButton" Enabled="false" Text="Delete" runat="server" />&nbsp;|&nbsp;
                        <asp:LinkButton ID="btnDisolusiAdd" CssClass="LinkButton" ValidationGroup="disolusi" Enabled="false" Text="Save" runat="server" />
                    </td>
                </tr>
            </table>
            <div style="float: left; margin-left: 10px">
                <asp:GridView ID="gvDisolusi" runat="server" AllowSorting="true" AutoGenerateColumns="false" AlternatingRowStyle-BackColor="#F7F7F7"
                DataKeyNames="LineID" BorderColor="#333333" CellPadding="5">
                <Columns>
                    <asp:TemplateField ShowHeader="false" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnSelect" CssClass="LinkButton" Text="Select" CommandName="Select" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Disolusi" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblDisolusiSpek" Text='<%# Eval("DisolusiSpek") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Spek" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label id="lblDisolusiJenis" Text='<%# Eval("DisolusiJenis") %>' runat="server" /> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Min" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblDisolusiMin" Text='<%# Eval("DisolusiMin") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Max" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblDisolusiMax" Text='<%# Eval("DisolusiMax") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rata-rata" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblDisolusiAvg" Text='<%# Eval("DisolusiAvg") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblLineID" Text='<%# Eval("LineID") %>' style="display:none" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                <asp:TextBox ID="txtDisolusiLineID" style="display:none" Text="0" runat="server" />
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:ObjectDataSource ID="oKadar" runat="server"
        TypeName="PengkajianMutu"
        SelectMethod="GetKps">
        <SelectParameters>
            <asp:ControlParameter Name="ItemCode" ControlID="txtProdID" PropertyName="text" Type="String" />
            <asp:ControlParameter Name="Batch" ControlID="txtNoBatch" PropertyName="text" Type="String" />
            <asp:Parameter Name="TargetTable" Type="Int16" DefaultValue="2" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="oDisolusi" runat="server"
        TypeName="PengkajianMutu"
        SelectMethod="GetKps">
        <SelectParameters>
            <asp:ControlParameter Name="ItemCode" ControlID="txtProdID" PropertyName="text" Type="String" />
            <asp:ControlParameter Name="Batch" ControlID="txtNoBatch" PropertyName="text" Type="String" />
            <asp:Parameter Name="TargetTable" Type="Int16" DefaultValue="3" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

