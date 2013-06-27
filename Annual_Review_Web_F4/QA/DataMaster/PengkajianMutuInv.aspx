<%@ Page Title="Pengkajian Mutu Injeksi Kering" Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="PengkajianMutuInv.aspx.vb" Inherits="QA_DataMaster_PengkajianMutuInv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">

       var txtProdID, txtNoBatch, lblTglProduksi;
       function pageLoad() {
           txtProdID = $get("<%=txtProdID.ClientID%>");
           txtNoBatch = $get("<%=txtNoBatch.ClientID%>");
           lblTglProduksi = $get("<%=lblTglProduksi.ClientID%>")
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
                <td align="right">Sterilitas :</td>
                <td align="left">
                    <asp:DropDownList ID="ddlSterilitas" runat="server">
                        <asp:ListItem Text="--" Value="-" />
                        <asp:ListItem Text="Steril" Value="steril" />
                        <asp:ListItem Text="Tidak Steril" Value="nosteril" />
                    </asp:DropDownList>
                </td>
                <td colspan="3"></td>
                
            </tr>
            <tr>
                <td colspan="5" style="background-color:Silver; font-weight: bold; padding:10px">
                    Bobot Pervial</td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek :</td>
                <td align="left">
                    <asp:TextBox ID="txtPervialSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Rata-rata :</td>
                <td align="left">
                    <asp:TextBox ID="txtPervialAvg" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Min :</td>
                <td align="left">
                    <asp:TextBox ID="txtPervialMin" Width="90" style="text-align:right" runat="server" />
                </td>
                <td></td>
                <td align="right">Maks :</td>
                <td align="left">
                    <asp:TextBox ID="txtPervialMaks" Width="90" style="text-align:right" runat="server" />
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
                <td></td>
                <td align="right">Hasil :</td>
                <td align="left">
                    <asp:TextBox ID="txtpHHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="background-color:Silver; font-weight: bold; padding:10px">
                    Susut Pengeringan</td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek :</td>
                <td align="left">
                    <asp:TextBox ID="txtSusutSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil :</td>
                <td align="left">
                    <asp:TextBox ID="txtSusutHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="background-color:Silver; font-weight: bold; padding:10px">
                    Endotoksin</td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek :</td>
                <td align="left">
                    <asp:TextBox ID="txtEndotoksinSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil :</td>
                <td align="left">
                    <asp:TextBox ID="txtEndotoksinHasil" Width="90" runat="server" />
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
                    <td align="right">Hasil :</td>
                    <td align="left">
                        <asp:TextBox ID="txtKadarHasil" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right" colspan="2">
                        <asp:LinkButton ID="btnHapus" runat="server" CssClass="LinkButton" 
                            Enabled="false" Text="Delete" />
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="btnAdd" runat="server" CssClass="LinkButton" 
                            Enabled="false" Text="Save" ValidationGroup="kadar" />
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
                        <asp:TemplateField HeaderText="Hasil" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblKadarHasil" Text='<%# Eval("KadarHasil") %>' runat="server" />
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
        <div style="background-color: #7E7E7E; padding-left: 5px; margin-top: 10px; margin-bottom: 10px">
            <h1>Keragaman Bobot</h1>
        </div>
        <asp:UpdatePanel ID="upBobot" runat="server">
        <ContentTemplate>
            <table>
                <tr valign="middle">
                    <td align="right">Jenis Keragaman Bobot :</td>
                    <td align="left">
                        <asp:TextBox ID="txtKeragamanBobot" runat="server" />
                        <asp:RequiredFieldValidator ID="valKeragamanBobot" ControlToValidate="txtKeragamanBobot" ErrorMessage="*" ValidationGroup="bobot" runat="server" />
                    </td>
                    <td></td>
                    <td align="right">Spek Min/Maks :</td>
                    <td align="left">
                        <asp:TextBox ID="txtMinMaxSpek" runat="server" />
                        <asp:RequiredFieldValidator ID="valMinMaxSpek" ControlToValidate="txtMinMaxSpek" ErrorMessage="*" ValidationGroup="bobot" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Min Hasil :</td>
                    <td align="left">
                        <asp:TextBox ID="txtMinHasil" style="text-align:right" runat="server" />
                    </td>
                    <td></td>
                    <td align="right">Maks Hasil :</td>
                    <td align="left">
                        <asp:TextBox ID="txtMaxHasil" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">RSD Spek :</td>
                    <td align="left">
                        <asp:TextBox ID="txtRSDSpek" runat="server" />
                        <asp:RequiredFieldValidator ID="valRSDSpek" ControlToValidate="txtRSDSpek" ErrorMessage="*" ValidationGroup="bobot" runat="server" />
                    </td>
                    <td></td>
                    <td align="right">RSD Hasil :</td>
                    <td align="left">
                        <asp:TextBox ID="txtRSDHasil" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">AV Spek :</td>
                    <td align="left">
                        <asp:TextBox ID="txtAVSpek" runat="server" />
                        <asp:RequiredFieldValidator ID="valAVSpek" ControlToValidate="txtAVSpek" ErrorMessage="*" ValidationGroup="bobot" runat="server" />
                    </td>
                    <td></td>
                    <td align="right">AV Hasil :</td>
                    <td align="left">
                        <asp:TextBox ID="txtAVHasil" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right" colspan="2">
                        <asp:LinkButton ID="btnHapusBobot" runat="server" CssClass="LinkButton" 
                            Enabled="false" Text="Delete" />
                        &nbsp;|&nbsp;
                        <asp:LinkButton ID="btnAddBobot" runat="server" CssClass="LinkButton" 
                            Enabled="false" Text="Save" ValidationGroup="bobot" />
                    </td>
            </tr>
            </table>
            <div>
                <asp:GridView ID="gvBobot" runat="server" AllowSorting="true" AutoGenerateColumns="false" AlternatingRowStyle-BackColor="#F7F7F7"
                    DataKeyNames="LineID" BorderColor="#333333" CellPadding="5">
                    <Columns>
                        <asp:TemplateField ShowHeader="false" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnSelect" CssClass="LinkButton" Text="Select" CommandName="Select" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Jenis Keseragaman Bobot" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label id="lblBobot" Text='<%# Eval("JenisKeragamanBobot") %>' runat="server" /> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Min / Maks Spek" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblMinMaxSpek" Text='<%# Eval("MinMaxSpek") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Min Hasil" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblMinHasil" Text='<%# Eval("MinHasil") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Maks Hasil" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblMaxHasil" Text='<%# Eval("MaxHasil") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RSD Spek" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblRSDSpek" Text='<%# Eval("RSDSpek") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RSD Hasil" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblRSDHasil" Text='<%# Eval("RSDHasil") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AV Spek" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblAVDSpek" Text='<%# Eval("AVSpek") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AV Hasil" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblAVHasil" Text='<%# Eval("AVHasil") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblLineID" Text='<%# Eval("LineID") %>' style="display:none" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:TextBox ID="txtBobotLineID" style="display:none" Text="0" runat="server" />
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:ObjectDataSource ID="oKadar" runat="server"
        TypeName="PengkajianMutu"
        SelectMethod="GetINV">
        <SelectParameters>
            <asp:ControlParameter Name="ItemCode" ControlID="txtProdID" PropertyName="text" Type="String" />
            <asp:ControlParameter Name="Batch" ControlID="txtNoBatch" PropertyName="text" Type="String" />
            <asp:Parameter Name="TargetTable" Type="Int16" DefaultValue="2" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="oBobot" runat="server"
        TypeName="PengkajianMutu"
        SelectMethod="GetINV">
        <SelectParameters>
            <asp:ControlParameter Name="ItemCode" ControlID="txtProdID" PropertyName="text" Type="String" />
            <asp:ControlParameter Name="Batch" ControlID="txtNoBatch" PropertyName="text" Type="String" />
            <asp:Parameter Name="TargetTable" Type="Int16" DefaultValue="3" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

