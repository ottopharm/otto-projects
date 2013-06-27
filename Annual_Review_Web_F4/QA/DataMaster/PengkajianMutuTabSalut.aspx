<%@ Page Title="Pengkajian Mutu TAB/KPS/TSS/TSG" Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="PengkajianMutuTabSalut.aspx.vb" Inherits="QA_DataMaster_PengkajianMutuTabSalut" %>

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
                <td align="right">Waktu Mixing (jam) :</td>
                <td align="left">
                    <asp:Label ID="lblMixing" Text="." runat="server" />
                </td>
                <td></td>
                <td align="right">Waktu Cetak (jam) :</td>
                <td>
                    <asp:Label ID="lblCetak" Text="." runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Waktu Coating Lot 1 (jam) :</td>
                <td align="left">
                    <asp:Label ID="lblLot1" Text="." runat="server" />
                </td>
                <td></td>
                <td align="right">Waktu Coating Lot 2 (jam) :</td>
                <td>
                    <asp:Label ID="lblLot2" Text="." runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Waktu Coating Lot 3 (jam) :</td>
                <td align="left">
                    <asp:Label ID="lblLot3" Text="." runat="server" />
                </td>
                <td></td>
                <td align="right">Waktu Coating Lot 4 (jam) :</td>
                <td>
                    <asp:Label ID="lblLot4" Text="." runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Waktu Kemas Primer (jam) :</td>
                <td align="left">
                    <asp:Label ID="lblPGA" Text="." runat="server" />
                </td>
                <td colspan="3"></td>
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
                    TABLET / KAPLET</td>
            </tr>
            <tr valign="middle">
                <td align="right">Bobot Rata-rata Spek :</td>
                <td align="left">
                    <asp:TextBox ID="txtBobotAvgSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Bobot Rata-rata Hasil :</td>
                <td align="left">
                    <asp:TextBox ID="txtBobotAvgHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Penyimpangan Spek Maks :</td>
                <td align="left">
                    <asp:TextBox ID="txtSimpangMaxSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Penyimpangan Hasil Maks :</td>
                <td align="left">
                    <asp:TextBox ID="txtSimpangMaxHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Penyimpangan Spek Min. :</td>
                <td align="left">
                    <asp:TextBox ID="txtSimpangMinSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Penyimpangan Hasil Min. :</td>
                <td align="left">
                    <asp:TextBox ID="txtSimpangMinHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Tebal Spek :</td>
                <td align="left">
                    <asp:TextBox ID="txtTebalspek" Width="90" runat="server" />
                </td>
                <td colspan="3"></td>
            </tr>
            <tr valign="middle">
                <td align="right">Tebal Min. :</td>
                <td align="left">
                    <asp:TextBox ID="txtTebalMin" Width="90" style="text-align:right" runat="server" />
                </td>
                <td></td>
                <td align="right">Tebal Maks :</td>
                <td align="left">
                    <asp:TextBox ID="txtTebalMax" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Kekerasan Spek :</td>
                <td align="left">
                    <asp:TextBox ID="txtKekerasanSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Kekerasan Rata-rata :</td>
                <td align="left">
                    <asp:TextBox ID="txtKekerasanAvg" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Kekerasan Min. :</td>
                <td align="left">
                    <asp:TextBox ID="txtKekerasanMin" Width="90" style="text-align:right" runat="server" />
                </td>
                <td></td>
                <td align="right">Kekerasan Maks :</td>
                <td align="left">
                    <asp:TextBox ID="txtKekerasanMax" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Keausan Spek :</td>
                <td align="left">
                    <asp:TextBox ID="txtKeausanSpek" Width="90" runat="server" />
                </td>
                <td colspan="3"></td>
            </tr>
            <tr valign="middle">
                <td align="right">Keausan Min. :</td>
                <td align="left">
                    <asp:TextBox ID="txtKeausanMin" Width="90" style="text-align:right" runat="server" />
                </td>
                <td></td>
                <td align="right">Keausan Maks :</td>
                <td align="left">
                    <asp:TextBox ID="txtKeausanMax" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Moisture Content Spek :</td>
                <td align="left">
                    <asp:TextBox ID="txtMoistureSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Moisture Content Hasil :</td>
                <td align="left">
                    <asp:TextBox ID="txtMoistureHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Waktu Hancur Spek :</td>
                <td align="left">
                    <asp:TextBox ID="txtWaktuHancurSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Waktu Hancur Hasil :</td>
                <td align="left">
                    <asp:TextBox ID="txtWaktuHancurHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="background-color:Silver; font-weight: bold; padding:10px">
                    TSS/ TSG</td>
            </tr>
            <tr valign="middle">
                <td align="right">Bobot Rata-rata Spek :</td>
                <td align="left">
                    <asp:TextBox ID="txtTssBobotAvgSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Bobot Rata-rata Hasil :</td>
                <td align="left">
                    <asp:TextBox ID="txtTssBobotAvgHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Penyimpangan Spek Maks :</td>
                <td align="left">
                    <asp:TextBox ID="txtTssSimpangMaxSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Penyimpangan Hasil Maks :</td>
                <td align="left">
                    <asp:TextBox ID="txtTssSimpangMaxHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Penyimpangan Spek Min. :</td>
                <td align="left">
                    <asp:TextBox ID="txtTssSimpangMinSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Penyimpangan Hasil Min. :</td>
                <td align="left">
                    <asp:TextBox ID="txtTssSimpangMinHasil" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Tebal Spek :</td>
                <td align="left">
                    <asp:TextBox ID="txtTssTebalSpek" Width="90" runat="server" />
                </td>
                <td colspan="3"></td>
            </tr>
            <tr valign="middle">
                <td align="right">Tebal Min. :</td>
                <td align="left">
                    <asp:TextBox ID="txtTssTebalMin" Width="90" style="text-align:right" runat="server" />
                </td>
                <td></td>
                <td align="right">Tebal Maks :</td>
                <td align="left">
                    <asp:TextBox ID="txtTssTebalMax" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Kekerasan Spek :</td>
                <td align="left">
                    <asp:TextBox ID="txtTssKekerasanSpek" Width="90" runat="server" />
                </td>
                <td colspan="3"></td>
            </tr>
            <tr valign="middle">
                <td align="right">Kekerasan Min. :</td>
                <td align="left">
                    <asp:TextBox ID="txtTssKekerasanMin" Width="90" style="text-align:right" runat="server" />
                </td>
                <td></td>
                <td align="right">Kekerasan Maks :</td>
                <td align="left">
                    <asp:TextBox ID="txtTssKekerasanMax" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Keausan Spek :</td>
                <td align="left">
                    <asp:TextBox ID="txtTssKeausanSpek" Width="90" runat="server" />
                </td>
                <td colspan="3"></td>
            </tr>
            <tr valign="middle">
                <td align="right">Keausan Min. :</td>
                <td align="left">
                    <asp:TextBox ID="txtTssKeausanMin" Width="90" style="text-align:right" runat="server" />
                </td>
                <td></td>
                <td align="right">Keausan Maks :</td>
                <td align="left">
                    <asp:TextBox ID="txtTssKeausanMax" Width="90" style="text-align:right" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Waktu Hancur Spek :</td>
                <td align="left">
                    <asp:TextBox ID="txtTssWaktuHancurSpek" Width="90" runat="server" />
                </td>
                <td></td>
                <td align="right">Waktu Hancur Hasil :</td>
                <td align="left">
                    <asp:TextBox ID="txtTssWaktuHancurHasil" Width="90" style="text-align:right" runat="server" />
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
                <td colspan="5" style="background-color:Silver; font-weight: bold; padding:10px">Keseragaman Unit dosis</td>
            </tr>
            <tr valign="middle">
                <td align="right">Spek :</td>
                <td align="left">
                    <asp:TextBox ID="txtUnitDosisSpek" Width="120" runat="server" />
                </td>
                <td></td>
                <td align="right">Hasil :</td>
                <td align="left">
                    <asp:TextBox ID="txtUnitDosisHasil" Width="90" style="text-align:right" runat="server" />
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
            <h2>Keseragaman Kandungan</h2>
        </div>
        <asp:UpdatePanel ID="upKandungan" runat="server">
        <ContentTemplate>
            <table>
                <tr valign="middle">
                    <td align="right">Keseragaman Kandungan :</td>
                    <td align="left">
                        <asp:TextBox ID="txtKeseragamanKandungan" runat="server" />
                        <asp:RequiredFieldValidator ID="valKeseragamanKandungan" ControlToValidate="txtKeseragamanKandungan" ErrorMessage="*" ValidationGroup="kandungan" runat="server" />
                    </td>
                    <td style="width: 30px"></td>
                    <td align="right">Spek Min/Maks :</td>
                    <td align="left">
                        <asp:TextBox ID="txtMinMaxSpek" runat="server" />
                    </td>
                </tr>               
                <tr valign="middle">
                    <td align="right">Hasil Min. :</td>
                    <td align="left">
                        <asp:TextBox ID="txtMinHasil" style="text-align:right" runat="server" />
                    </td>
                    <td></td>
                    <td align="right">Hasil Maks. :</td>
                    <td align="left">
                        <asp:TextBox ID="txtMaxHasil" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Spek RSD :</td>
                    <td align="left">
                        <asp:TextBox ID="txtRSDSpek" runat="server" />
                    </td>
                    <td></td>
                    <td align="right">Hasil RSD :</td>
                    <td align="left">
                        <asp:TextBox ID="txtRSDHasil" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Spek AV :</td>
                    <td align="left">
                        <asp:TextBox ID="txtAVSpek" runat="server" />
                    </td>
                    <td></td>
                    <td align="right">Hasil AV :</td>
                    <td align="left">
                        <asp:TextBox ID="txtAVHasil" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right" colspan="2">
                        <asp:LinkButton ID="btnHapusKandungan" CssClass="LinkButton" Enabled="false" Text="Delete" runat="server" />&nbsp;|&nbsp;
                        <asp:LinkButton ID="btnAddKandungan" CssClass="LinkButton" ValidationGroup="kandungan" Enabled="false" Text="Save" runat="server" />
                    </td>
                </tr>
            </table>
            <div style="margin-top: 20px">
                <asp:GridView ID="gvKandungan" runat="server" AllowSorting="true" AutoGenerateColumns="false" AlternatingRowStyle-BackColor="#F7F7F7"
                    DataKeyNames="LineID" BorderColor="#333333" CellPadding="5">
                    <Columns>
                        <asp:TemplateField ShowHeader="false" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnSelect" CssClass="LinkButton" Text="Select" CommandName="Select" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Keseragaman Kandungan" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label id="lblKandungan" Text='<%# Eval("KeseragamanKandungan") %>' runat="server" /> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Spek Min / Maks" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblMinMaxSpek" Text='<%# Eval("MinMaxSpek") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hasil Min." HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblMinHasil" Text='<%# Eval("MinHasil") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hasil Maks" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblMaxHasil" Text='<%# Eval("MaxHasil") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Spek RSD" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblRSDSpek" Text='<%# Eval("RSDSpek") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hasil RSD" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblRSDHasil" Text='<%# Eval("RSDHasil") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Spek AV" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblAVSpek" Text='<%# Eval("AVSpek") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hasil AV" HeaderStyle-HorizontalAlign="Left">
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
                <asp:TextBox ID="txtKandunganLineID" style="display:none" Text="0" runat="server" />
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>
        <div style="background-color: #7E7E7E; padding-left: 5px; margin-top: 10px; margin-bottom: 10px">
            <h2>Keseragaman Bobot</h2>
        </div>
        <asp:UpdatePanel ID="upBobot" runat="server">
        <ContentTemplate>
            <table>
                <tr valign="middle">
                    <td align="right">Keseragaman Bobot :</td>
                    <td align="left">
                        <asp:TextBox ID="txtKeseragamanBobot" runat="server" />
                        <asp:RequiredFieldValidator ID="valKeseragamanBobot" ControlToValidate="txtKeseragamanBobot" ErrorMessage="*" ValidationGroup="bobot" runat="server" />
                    </td>
                    <td style="width: 30px"></td>
                    <td align="right">Spek Min/Maks :</td>
                    <td align="left">
                        <asp:TextBox ID="txtBobotMinMaxSpek" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Hasil Min. :</td>
                    <td align="left">
                        <asp:TextBox ID="txtBobotMinHasil" style="text-align:right" runat="server" />
                    </td>
                    <td></td>
                    <td align="right">Hasil Maks. :</td>
                    <td align="left">
                        <asp:TextBox ID="txtBobotMaxHasil" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Spek RSD :</td>
                    <td align="left">
                        <asp:TextBox ID="txtBobotRSDSpek" runat="server" />
                    </td>
                    <td></td>
                    <td align="right">Hasil RSD :</td>
                    <td align="left">
                        <asp:TextBox ID="txtBobotRSDHasil" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Spek AV :</td>
                    <td align="left">
                        <asp:TextBox ID="txtBobotAVSpek" runat="server" />
                    </td>
                    <td></td>
                    <td align="right">Hasil AV :</td>
                    <td align="left">
                        <asp:TextBox ID="txtBobotAVHasil" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right" colspan="2">
                        <asp:LinkButton ID="btnHapusBobot" CssClass="LinkButton" Enabled="false" Text="Delete" runat="server" />&nbsp;|&nbsp;
                        <asp:LinkButton ID="btnAddBobot" CssClass="LinkButton" ValidationGroup="bobot" Enabled="false" Text="Save" runat="server" />
                    </td>
                </tr>
            </table>
            <div style="margin-top: 20px">
                <asp:GridView ID="gvBobot" runat="server" AllowSorting="true" AutoGenerateColumns="false" AlternatingRowStyle-BackColor="#F7F7F7"
                    DataKeyNames="LineID" BorderColor="#333333" CellPadding="5">
                    <Columns>
                        <asp:TemplateField ShowHeader="false" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnSelect" CssClass="LinkButton" Text="Select" CommandName="Select" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Keseragaman Bobot" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label id="lblBobot" Text='<%# Eval("KeseragamanBobot") %>' runat="server" /> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Spek Min / Maks" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblMinMaxSpek" Text='<%# Eval("MinMaxSpek") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hasil Min." HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblMinHasil" Text='<%# Eval("MinHasil") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hasil Maks" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblMaxHasil" Text='<%# Eval("MaxHasil") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Spek RSD" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblRSDSpek" Text='<%# Eval("RSDSpek") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hasil RSD" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblRSDHasil" Text='<%# Eval("RSDHasil") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Spek AV" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblAVSpek" Text='<%# Eval("AVSpek") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hasil AV" HeaderStyle-HorizontalAlign="Left">
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
        <div style="background-color: #7E7E7E; padding-left: 5px; margin-top: 10px; margin-bottom: 10px">
            <h2>Kadar</h2>
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
                    <td align="right">Kapsul :</td>
                    <td align="left">
                        <asp:TextBox ID="txtKadarKapsul" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right" colspan="2">
                        <asp:LinkButton ID="btnHapusKadar" CssClass="LinkButton" Enabled="false" Text="Delete" runat="server" />&nbsp;|&nbsp;
                        <asp:LinkButton ID="btnAddKadar" CssClass="LinkButton" ValidationGroup="kadar" Enabled="false" Text="Save" runat="server" />
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
                                <asp:Label ID="lblKadarMassa" Text='<%# Eval("Massa") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Kapsul" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblKadarKapsul" Text='<%# Eval("Kapsul") %>' runat="server" />
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
            <h2>Disolusi Tablet</h2>
        </div>
        <asp:UpdatePanel ID="upDisolusiTablet" runat="server">
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
                        <asp:TextBox ID="txtDisolusiSpek" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Hasil Min. :</td>
                    <td align="left">
                        <asp:TextBox ID="txtDisolusiMinHasil" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Hasil Maks. :</td>
                    <td align="left">
                        <asp:TextBox ID="txtDisolusiMaxHasil" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Hasil AV :</td>
                    <td align="left">
                        <asp:TextBox ID="txtDisolusiAvgHasil" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right" colspan="2">
                        <asp:LinkButton ID="btnHapusDisolusi" CssClass="LinkButton" Enabled="false" Text="Delete" runat="server" />&nbsp;|&nbsp;
                        <asp:LinkButton ID="btnAddDisolusi" CssClass="LinkButton" ValidationGroup="disolusi" Enabled="false" Text="Save" runat="server" />
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
                                <asp:Label id="lblDisolusi" Text='<%# Eval("Disolusi") %>' runat="server" /> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Spek" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblSpek" Text='<%# Eval("DisolusiSpek") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hasil Min." HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblMinHasil" Text='<%# Eval("MinHasil") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hasil Maks" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblMaxHasil" Text='<%# Eval("MaxHasil") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hasil AV" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblAvgHasil" Text='<%# Eval("AvgHasil") %>' runat="server" />
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
        <div style="clear: left">&nbsp;</div>
        <div style="background-color: #7E7E7E; padding-left: 5px; margin-top: 10px; margin-bottom: 10px">
            <h2>Disolusi TSS</h2>
        </div>
        <asp:UpdatePanel ID="upTssDisolusi" runat="server">
        <ContentTemplate>
            <table style="float: left;">
                <tr valign="middle">
                    <td align="right">Disolusi :</td>
                    <td align="left">
                        <asp:TextBox ID="txtTssDisolusi" runat="server" />
                        <asp:RequiredFieldValidator ID="valTssDisolusi" ControlToValidate="txtTssDisolusi" ErrorMessage="*" ValidationGroup="tssdisolusi" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Spek Disolusi :</td>
                    <td align="left">
                        <asp:TextBox ID="txtTssDisolusiSpek" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Hasil Min. :</td>
                    <td align="left">
                        <asp:TextBox ID="txtTssMinHasil" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Hasil Maks. :</td>
                    <td align="left">
                        <asp:TextBox ID="txtTssMaxHasil" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Hasil AV :</td>
                    <td align="left">
                        <asp:TextBox ID="txtTssAvgHasil" style="text-align:right" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right" colspan="2">
                        <asp:LinkButton ID="btnHapusTssDisolusi" CssClass="LinkButton" Enabled="false" Text="Delete" runat="server" />&nbsp;|&nbsp;
                        <asp:LinkButton ID="btnAddTssDisolusi" CssClass="LinkButton" ValidationGroup="tssdisolusi" Enabled="false" Text="Save" runat="server" />
                    </td>
                </tr>
            </table>
            <div style="float: left; margin-left: 10px">
                <asp:GridView ID="gvTssDisolusi" runat="server" AllowSorting="true" AutoGenerateColumns="false" AlternatingRowStyle-BackColor="#F7F7F7"
                    DataKeyNames="LineID" BorderColor="#333333" CellPadding="5">
                    <Columns>
                        <asp:TemplateField ShowHeader="false" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnSelect" CssClass="LinkButton" Text="Select" CommandName="Select" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Disolusi" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label id="lblDisolusi" Text='<%# Eval("Disolusi") %>' runat="server" /> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Spek" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblSpek" Text='<%# Eval("DisolusiSpek") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hasil Min." HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblMinHasil" Text='<%# Eval("MinHasil") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hasil Maks" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblMaxHasil" Text='<%# Eval("MaxHasil") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hasil AV" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblAvgHasil" Text='<%# Eval("AvgHasil") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblLineID" Text='<%# Eval("LineID") %>' style="display:none" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:TextBox ID="txtTssDisolusiLineID" style="display:none" Text="0" runat="server" />
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>
        <div style="clear: left">&nbsp;</div>
    </div>
    <asp:ObjectDataSource ID="oKadar" runat="server"
        TypeName="PengkajianMutu"
        SelectMethod="GetTAB">
        <SelectParameters>
            <asp:ControlParameter Name="ItemCode" ControlID="txtProdID" PropertyName="text" Type="String" />
            <asp:ControlParameter Name="Batch" ControlID="txtNoBatch" PropertyName="text" Type="String" />
            <asp:Parameter Name="TargetTable" Type="Int16" DefaultValue="2" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="oKandungan" runat="server"
        TypeName="PengkajianMutu"
        SelectMethod="GetTAB">
        <SelectParameters>
            <asp:ControlParameter Name="ItemCode" ControlID="txtProdID" PropertyName="text" Type="String" />
            <asp:ControlParameter Name="Batch" ControlID="txtNoBatch" PropertyName="text" Type="String" />
            <asp:Parameter Name="TargetTable" Type="Int16" DefaultValue="3" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="oBobot" runat="server"
        TypeName="PengkajianMutu"
        SelectMethod="GetTAB">
        <SelectParameters>
            <asp:ControlParameter Name="ItemCode" ControlID="txtProdID" PropertyName="text" Type="String" />
            <asp:ControlParameter Name="Batch" ControlID="txtNoBatch" PropertyName="text" Type="String" />
            <asp:Parameter Name="TargetTable" Type="Int16" DefaultValue="4" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="oDisolusiTablet" runat="server"
        TypeName="PengkajianMutu"
        SelectMethod="GetTAB">
        <SelectParameters>
            <asp:ControlParameter Name="ItemCode" ControlID="txtProdID" PropertyName="text" Type="String" />
            <asp:ControlParameter Name="Batch" ControlID="txtNoBatch" PropertyName="text" Type="String" />
            <asp:Parameter Name="TargetTable" Type="Int16" DefaultValue="5" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="oTssDisolusi" runat="server"
        TypeName="PengkajianMutu"
        SelectMethod="GetTAB">
        <SelectParameters>
            <asp:ControlParameter Name="ItemCode" ControlID="txtProdID" PropertyName="text" Type="String" />
            <asp:ControlParameter Name="Batch" ControlID="txtNoBatch" PropertyName="text" Type="String" />
            <asp:Parameter Name="TargetTable" Type="Int16" DefaultValue="6" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

