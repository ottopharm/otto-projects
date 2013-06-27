<%@ Page Title="Pengkajian Mutu KRIM" Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="PengkajianMutuKrim.aspx.vb" Inherits="QA_DataMaster_PengkajianMutuKrim" %>

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
                <td align="right">Spek pH Massa :</td>
                <td align="left">
                    <asp:TextBox ID="txtMassaSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil pH Massa :</td>
                <td align="left">
                    <asp:TextBox ID="txtMassaHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek pH Tube :</td>
                <td align="left">
                    <asp:TextBox ID="txtTubeSpek" Width="90" runat="server" />
                </td>
                <td></td>
                 <td align="right">Hasil pH Tube :</td>
                <td align="left">
                    <asp:TextBox ID="txtTubeHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
           <tr valign="middle">
                <td align="right">Spek Viskositas Massa :</td>
                <td align="left">
                    <asp:TextBox ID="txtViskositasSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil Viskositas Massa :</td>
                <td align="left">
                    <asp:TextBox ID="txtViskositasHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek Bobot Rata-rata :</td>
                <td align="left">
                    <asp:TextBox ID="txtBobotSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil Bobot Rata-rata :</td>
                <td align="left">
                    <asp:TextBox ID="txtBobotHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek Bobot Min :</td>
                <td align="left">
                    <asp:TextBox ID="txtBobotMinSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil Bobot Min :</td>
                <td align="left">
                    <asp:TextBox ID="txtBobotMinHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek Bobot Max :</td>
                <td align="left">
                    <asp:TextBox ID="txtBobotMaxSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil Bobot Max :</td>
                <td align="left">
                    <asp:TextBox ID="txtBobotMaxHasil" Width="90" style="text-align:right" runat="server" />
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
            <h1>Kadar / Potensi</h1>
        </div>
        <asp:UpdatePanel ID="upKadar" runat="server">
        <ContentTemplate>
            <table>
                <tr valign="middle">
                    <td></td>
                    <td>
                        <asp:DropDownList ID="ddlDataType" runat="server">
                            <asp:ListItem Text="Kadar" Value="1" />
                            <asp:ListItem Text="Potensi" Value="2" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Spek. Kadar :</td>
                    <td align="left">
                        <asp:TextBox ID="txtSpek" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Jenis Kadar :</td>
                    <td align="left">
                        <asp:TextBox ID="txtJenis" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Hasil Kadar :</td>
                    <td align="left">
                        <asp:TextBox ID="txtHasil" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right" colspan="2">
                        <asp:LinkButton ID="btnHapus" CssClass="LinkButton" Enabled="false" Text="Delete" runat="server" />&nbsp;|&nbsp;
                        <asp:LinkButton ID="btnAdd" CssClass="LinkButton" ValidationGroup="detail" Enabled="false" Text="Save" runat="server" />
                    </td>
                </tr>
            </table>
            <br />
            <div style="float:left">
                <asp:GridView ID="gvKadar" runat="server" AllowSorting="true" AutoGenerateColumns="false" AlternatingRowStyle-BackColor="#F7F7F7"
                    DataKeyNames="LineID" BorderColor="#333333" CellPadding="5" Caption="Kadar">
                    <Columns>
                        <asp:TemplateField ShowHeader="false" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnSelect" CssClass="LinkButton" Text="Select" CommandName="Select" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Spek. Kadar" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblSpekKadar" Text='<%# Eval("SpekKadar") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Jenis Kadar" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label id="lblJenisKadar" Text='<%# Eval("JenisKadar") %>' runat="server" /> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hasil Kadar" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblHasilKadar" Text='<%# Eval("HasilKadar") %>' runat="server" />
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
            <div style="float:left; margin-left:20px">
                <asp:GridView ID="gvPotensi" runat="server" AllowSorting="true" AutoGenerateColumns="false" AlternatingRowStyle-BackColor="#F7F7F7"
                DataKeyNames="LineID" BorderColor="#333333" CellPadding="5" Caption="Potensi">
                <Columns>
                    <asp:TemplateField ShowHeader="false" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnSelect" CssClass="LinkButton" Text="Select" CommandName="Select" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Spek. Potensi" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblSpekPotensi" Text='<%# Eval("SpekPotensi") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Jenis Potensi" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label id="lblJenisPotensi" Text='<%# Eval("JenisPotensi") %>' runat="server" /> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hasil Potensi" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblHasilPotensi" Text='<%# Eval("HasilPotensi") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblLineID" Text='<%# Eval("LineID") %>' style="display:none" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                <asp:TextBox ID="txtPotensiLineID" style="display:none" Text="0" runat="server" />
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:ObjectDataSource ID="oKadar" runat="server"
        TypeName="PengkajianMutu"
        SelectMethod="GetOil">
        <SelectParameters>
            <asp:ControlParameter Name="ItemCode" ControlID="txtProdID" PropertyName="text" Type="String" />
            <asp:ControlParameter Name="Batch" ControlID="txtNoBatch" PropertyName="text" Type="String" />
            <asp:Parameter Name="DataType" Type="Int16" DefaultValue="2" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="oPotensi" runat="server"
        TypeName="PengkajianMutu"
        SelectMethod="GetOil">
        <SelectParameters>
            <asp:ControlParameter Name="ItemCode" ControlID="txtProdID" PropertyName="text" Type="String" />
            <asp:ControlParameter Name="Batch" ControlID="txtNoBatch" PropertyName="text" Type="String" />
            <asp:Parameter Name="DataType" Type="Int16" DefaultValue="3" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

