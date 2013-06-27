<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false"
    CodeFile="LaporanKetidaksesuaian.aspx.vb" Inherits="QA_DataMaster_LaporanKetidaksesuaian"
    Title="Laporan Ketidaksesuaian" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 239px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="smProxy" runat="server">
        <Services>
            <asp:ServiceReference Path="/WS_ProdukReview.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <div style="padding: 2px;">
        <table border="1" cellpadding="10">
            <tr>
                <td colspan="2" align="left" bgcolor="Gray" style="font-family: 'Arial Black'; font-size: large;
                    font-weight: normal; font-variant: normal; text-transform: uppercase; color: #000000;
                    background-color: #7E7E7E; font-style: normal;">
                    A. Laporan Ketidaksesuaian
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" class="style1">
                    No. Lap.Ketidaksesuaian :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNoLK" runat="server" AutoPostBack="true" Height="19px" Width="237px" />
                    <asp:RequiredFieldValidator ID="valNoLK" runat="server" ControlToValidate="txtNoLK"
                        ErrorMessage="*" />
                    Status :
                    <asp:CheckBox ID="chkIsClosed" Text="Closed" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top" class="style1">
                    Jenis :
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlJenis" runat="server">
                        <asp:ListItem Text="- Pilih Jenis -" Value="0" Selected="True" />
                        <asp:ListItem Text="Ketidaksesuaian" Value="1" />
                        <asp:ListItem Text="Rekomendasi" Value="2" />
                    </asp:DropDownList>
                </td>
            </tr>
            <!-- <tr valign="middle">
                <td align="right" valign="top">Jenis :</td>
                <td align="left">
                    <asp:RadioButton ID="rbKetidaksesuaian" Text="Ketidaksesuaian" GroupName="jenis" runat="server" />&nbsp&nbsp
                    <asp:RadioButton ID="rbRekomendasi" Text="Rekomendasi" GroupName="jenis" runat="server" />
                </td>
            </tr> -->
            <tr valign="middle">
                <td align="right" class="style1">
                    Nama Produk / B.Baku / B.Kemas / Identitas lainnya :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtProduk" runat="server" Height="19px" Width="297px" />
                    <asp:RequiredFieldValidator ID="valProduk" runat="server" ControlToValidate="txtProduk"
                        ErrorMessage="*" />
                    Manufaktur :
                    <asp:TextBox ID="txtManufaktur" runat="server" Height="19px" Width="208px" />
                    <asp:RequiredFieldValidator ID="valManufaktur" runat="server" ControlToValidate="txtManufaktur"
                        ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" class="style1">
                    No.Batch / Analisa / Identitas lainnya :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNoBatch" Width="497px" TextMode="MultiLine" Height="50px" Wrap="true"
                        runat="server" />
                    <asp:RequiredFieldValidator ID="valNoBatch" runat="server" ControlToValidate="txtNoBatch"
                        ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" class="style1">
                    Sumber :
                </td>
                <td align="left">
                    <asp:UpdatePanel ID="upSumber" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlSumber" runat="server" AutoPostBack="true">
                                <asp:ListItem Text="- Pilih Sumber -" Value="0" Selected="True" />
                                <asp:ListItem Text="Audit Internal" Value="1" />
                                <asp:ListItem Text="Teguran dari BPOM" Value="2" />
                                <asp:ListItem Text="Penyimpangan yang terjadi" Value="3" />
                                <asp:ListItem Text="Keluhan" Value="4" />
                                <asp:ListItem Text="Lain - lain" Value="5" />
                            </asp:DropDownList>
                            &nbsp; Sumber Lain :
                            <asp:TextBox ID="txtSumberLain" runat="server" Enabled="false" Height="19px" Width="323px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" class="style1">
                    Asal Keluhan :
                </td>
                <td align="left">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlAsalKeluhan" runat="server" AutoPostBack="true" Enabled="false">
                                <asp:ListItem Text=" - " Value="0" Selected="True" />
                                <asp:ListItem Text="Apotek" Value="1" />
                                <asp:ListItem Text="Rumah Sakit" Value="2" />
                                <asp:ListItem Text="Distributor" Value="3" />
                                <asp:ListItem Text="Lain - lain" Value="4" />
                            </asp:DropDownList>
                            &nbsp;
                            <asp:TextBox ID="txtDetailAsalKeluhan" runat="server" Height="19px" Width="251px" />
                            <p>
                                Keluhan Lain :
                                <asp:TextBox ID="txtKeluhanLain" runat="server" Enabled="false" Height="19px" Width="272px" /></p>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" class="style1">
                    Ketidaksesuain terjadi pada :
                </td>
                <td align="left">
                    <asp:UpdatePanel ID="upKetidaksesuaian" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlKetidaksesuaian" runat="server" AutoPostBack="true">
                                <asp:ListItem Text="- Pilih Ketidaksesuaian -" Value="0" Selected="True" />
                                <asp:ListItem Text="Bahan Baku" Value="1" />
                                <asp:ListItem Text="Bahan Kemas" Value="2" />
                                <asp:ListItem Text="Produk Ruahan" Value="3" />
                                <asp:ListItem Text="Produk Jadi" Value="4" />
                                <asp:ListItem Text="Bangunan" Value="5" />
                                <asp:ListItem Text="Sarana Penunjang" Value="6" />
                                <asp:ListItem Text="Mesin" Value="7" />
                                <asp:ListItem Text="Prosedur" Value="8" />
                                <asp:ListItem Text="Lain - lain" Value="9" />
                            </asp:DropDownList>
                            &nbsp; Ketidaksesuaian Lain :
                            <asp:TextBox ID="txtKetidaksesuaianLain" runat="server" Enabled="false" Height="19px"
                                Width="276px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top" class="style1">
                    Tgl. Terjadinya / ditemukan Ketidaksesuaian :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtTglTerjadi" runat="server" Width="80" />
                    <%--<asp:ImageButton ID="btnTglTerjadi" runat="server" ValidationGroup="123" ImageUrl="~/Image/25.png" />--%>
                    <asp:Image ID="btnTglTerjadi" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calTglTerjadi" runat="server" TargetControlID="txtTglTerjadi"
                        PopupButtonID="btnTglTerjadi" CssClass="MyCalendar" Format="dd-MMM-yy" />
                    <asp:RequiredFieldValidator ID="valTglTerjadi" runat="server" ControlToValidate="txtTglTerjadi"
                        ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top" class="style1">
                    Apakah ketidaksesuaian direncanakan terjadi :
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlRencana" runat="server">
                        <asp:ListItem Text="- Pilih Rencana -" Value="0" Selected="True" />
                        <asp:ListItem Text="Ya" Value="1" />
                        <asp:ListItem Text="Tidak" Value="2" />
                    </asp:DropDownList>
                    <%--<asp:RadioButton ID="rbYesRencana" Text="Ya" GroupName="rencana" runat="server" />
                    <asp:RadioButton ID="rbNoRencana" Text="Tidak" GroupName="rencana" runat="server" />--%>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top" class="style1">
                    Adakah batch/produk lain yang terkena dampak :
                </td>
                <td align="left">
                    <%--<asp:RadioButton ID="rbNoDampak" Text="Tidak" GroupName="dampak" runat="server" AutoPostBack="true"/>
                    <asp:RadioButton ID="rbYesDampak" Text="Ya" GroupName="dampak" runat="server" AutoPostBack="true"/>--%>
                    <asp:UpdatePanel ID="upDampak" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlDampak" runat="server" AutoPostBack="true">
                                <asp:ListItem Text="- Pilih Dampak -" Value="0" Selected="True" />
                                <asp:ListItem Text="Tidak" Value="1" />
                                <asp:ListItem Text="Ya" Value="2" />
                            </asp:DropDownList>
                            &nbsp; No.Batch :
                            <asp:TextBox ID="txtYesDampak" runat="server" Enabled="false" Height="19px" Width="249px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" class="style1">
                    Jenis Sediaan :
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlJenisSediaan" runat="server">
                        <asp:ListItem Text="- Pilih Jenis Sediaan -" Value="0" Selected="True" />
                        <asp:ListItem Text="Tablet - Kaplet" Value="1" />
                        <asp:ListItem Text="Kapsul" Value="2" />
                        <asp:ListItem Text="Sirup - Suspensi" Value="3" />
                        <asp:ListItem Text="Injeksi & Infus" Value="4" />
                        <asp:ListItem Text="Serbuki Injeksi Steril" Value="5" />
                        <asp:ListItem Text="Krim" Value="6" />
                        <asp:ListItem Text="Tablet Salut" Value="7" />
                        <asp:ListItem Text="Suppositoria & Ovula" Value="8" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" class="style1">
                    Uraian Ketidaksesuaian / Rekomendasi :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtUraian" runat="server" Width="400" TextMode="MultiLine" Height="50"
                        Wrap="true" />
                    <asp:RequiredFieldValidator ID="valUraian" runat="server" ControlToValidate="txtUraian"
                        ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" class="style1">
                    Tindakan Sementara yang telah dilakukan :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtTindakan" runat="server" Width="400" TextMode="MultiLine" Height="50"
                        Wrap="true" />
                    <asp:RequiredFieldValidator ID="valTindakan" runat="server" ControlToValidate="txtTindakan"
                        ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" class="style1">
                    Tingkat Resiko :
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlResiko" runat="server">
                        <asp:ListItem Text="- Pilih Resiko -" Value="0" Selected="True" />
                        <asp:ListItem Text="Critical" Value="1" />
                        <asp:ListItem Text="Mayor" Value="2" />
                        <asp:ListItem Text="Minor" Value="3" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" class="style1">
                    Pelapor :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPelapor" runat="server" Height="19px" Width="190px" />
                    <asp:RequiredFieldValidator ID="valPelapor" runat="server" ErrorMessage="*" ControlToValidate="txtPelapor" />
                    &nbsp;
                    <asp:DropDownList ID="ddlDepartemenPelapor" runat="server" DataSourceID="oDept" DataTextField="DeptName"
                        DataValueField="DeptId">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" class="style1">
                    Tanggal Lapor :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtTglPelapor" runat="server" Width="80" />
                    <%--<asp:ImageButton ID="btnTglPelapor" runat="server" ValidationGroup="123" ImageUrl="~/Image/25.png" />--%>
                    <asp:Image ID="btnTglPelapor" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calTglPelapor" runat="server" TargetControlID="txtTglPelapor"
                        PopupButtonID="btnTglPelapor" CssClass="MyCalendar" Format="dd-MMM-yy" />
                    <asp:RequiredFieldValidator ID="valTglPelapor" runat="server" ControlToValidate="txtTglPelapor"
                        ErrorMessage="*" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left" bgcolor="Gray" style="font-family: 'Arial Black'; font-size: large;
                    font-weight: normal; font-variant: normal; text-transform: uppercase; color: #000000;
                    background-color: #7E7E7E; font-style: normal;">
                    B. Investigasi
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" class="style1">
                    Investigasi :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtInvestigasi" runat="server" Width="400" TextMode="MultiLine"
                        Height="50" Wrap="true" />
                    <asp:RequiredFieldValidator ID="valInvestigasi" runat="server" ControlToValidate="txtInvestigasi"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" class="style1">
                    Penyebab Penyimpangan :
                </td>
                <td align="left">
                    <asp:UpdatePanel ID="upPenyebabPenyimpangan" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlPenyebabPenyimpangan" runat="server" AutoPostBack="true">
                                <asp:ListItem Text="- Pilih Penyebab Penyimpangan" Value="0" Selected="True" />
                                <asp:ListItem Text="Human error" Value="1" />
                                <asp:ListItem Text="Supplier" Value="2" />
                                <asp:ListItem Text="Mesin / Alat" Value="3" />
                                <asp:ListItem Text="Formula" Value="4" />
                                <asp:ListItem Text="Spesifikasi" Value="5" />
                                <asp:ListItem Text="Proses" Value="6" />
                                <asp:ListItem Text="Sarana Penunjang" Value="7" />
                                <asp:ListItem Text="Lain - lain" Value="8" />
                            </asp:DropDownList>
                            &nbsp;
                            <br>
                            <br>
                            Penyebab Penyimpangan Lain :
                            <asp:TextBox ID="txtPenyebabPenyimpanganLain" runat="server" Enabled="false" Height="19px"
                                Width="256px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left" bgcolor="Gray" style="font-family: 'Arial Black'; font-size: large;
                    font-weight: normal; font-variant: normal; text-transform: uppercase; color: #000000;
                    background-color: #7E7E7E; font-style: normal;">
                    D. Perbaikan, Tindakan Perbaikan, dan Tindakan Pencegahan
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" class="style1">
                    Tindakan Perbaikan :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtTindakanPerbaikan" runat="server" Width="400" TextMode="MultiLine"
                        Height="50" Wrap="true" />
                    &nbsp; &nbsp; Status :
                    <asp:CheckBox ID="chkIsClosedTPerbaikan" Text="Closed" runat="server" />
                    <%--<asp:RequiredFieldValidator ID="valTindakanPerbaikan" runat="server" ControlToValidate="txtTindakanPerbaikan" ErrorMessage="*" />--%>
                    <p>
                        Batas Waktu Penyelesaian :
                        <asp:TextBox ID="txtTglTindakanPerbaikan" runat="server" Width="80" />
                        <%--<asp:ImageButton ID="btnTglTindakanPerbaikan" runat="server" ImageUrl="~/Image/25.png" />--%>
                        <asp:Image ID="btnTglTindakanPerbaikan" runat="server" ImageUrl="~/Image/25.png" />
                        <AjaxToolkit:CalendarExtender ID="calTglTindakanPerbaikan" runat="server" TargetControlID="txtTglTindakanPerbaikan"
                            PopupButtonID="btnTglTindakanPerbaikan" CssClass="MyCalendar" Format="dd-MMM-yy" />
                    </p>
                    <p>
                        Email Reminder : &nbsp; &nbsp; &nbsp;
                        <asp:TextBox ID="txtEmailTindakanPerbaikan" runat="server" Height="21px" Width="376px" />
                    </p>
                    <p>
                        Penanggung Jawab :
                        <asp:TextBox ID="txtPenanggungJawabTindakanPerbaikan" runat="server" Height="19px"
                            Width="190px" />
                        <%--<asp:RequiredFieldValidator ID="valPenanggungJawabTindakanPerbaikan" runat="server"
                            ControlToValidate="txtPenanggungJawabTindakanPerbaikan" ErrorMessage="*" />--%>
                        <asp:DropDownList ID="ddlDepartemenPJTPerbaikan" runat="server" DataSourceID="oDept"
                            DataTextField="DeptName" DataValueField="DeptId">
                        </asp:DropDownList>
                    </p>
                    <%--<asp:RequiredFieldValidator ID="valTglTindakanPerbaikan" runat="server" ControlToValidate="txtTglTindakanPerbaikan" ErrorMessage="*" />--%>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" class="style1">
                    Tindakan Pencegahan :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtTindakanPencegahan" runat="server" Width="400" TextMode="MultiLine"
                        Height="50" Wrap="true" />
                    &nbsp; &nbsp; Status :
                    <asp:CheckBox ID="chkIsClosedTPencegahan" Text="Closed" runat="server" />
                    <%--<asp:RequiredFieldValidator ID="valTindakanPencegahan" runat="server" ControlToValidate="txtTindakanPencegahan" ErrorMessage="*" />--%>
                    <p>
                        Batas Waktu Penyelesaian :
                        <asp:TextBox ID="txtTglTindakanPencegahan" runat="server" Width="80" />
                        <%--<asp:ImageButton ID="btnTglTindakanPencegahan" runat="server" ImageUrl="~/Image/25.png" />--%>
                        <asp:Image ID="btnTglTindakanPencegahan" runat="server" ImageUrl="~/Image/25.png" />
                        <AjaxToolkit:CalendarExtender ID="calTglTindakanPencegahan" runat="server" TargetControlID="txtTglTindakanPencegahan"
                            PopupButtonID="btnTglTindakanPencegahan" CssClass="MyCalendar" Format="dd-MMM-yy" />
                    </p>
                    <p>
                        Email Reminder : &nbsp; &nbsp; &nbsp;
                        <asp:TextBox ID="txtEmailTindakanPencegahan" runat="server" Height="21px" Width="376px" />
                    </p>
                    <p>
                        Penanggung Jawab :
                        <asp:TextBox ID="txtPenanggungJawabTindakanPencegahan" runat="server" Height="19px"
                            Width="190px" />
                        <%--<asp:RequiredFieldValidator ID="valPenanggungJawabTindakanPencegahan" runat="server"
                            ControlToValidate="txtPenanggungJawabTindakanPencegahan" ErrorMessage="*" />--%>
                        <asp:DropDownList ID="ddlDepartemenPJTPencegahan" runat="server" DataSourceID="oDept"
                            DataTextField="DeptName" DataValueField="DeptId">
                        </asp:DropDownList>
                    </p>
                    <%--<asp:RequiredFieldValidator ID="valTglTindakanPencegahan" runat="server" ControlToValidate="txtTglTindakanPencegahan" ErrorMessage="*" />--%>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" class="style1">
                    Kesimpulan :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtKesimpulanPerbaikan" runat="server" Width="400" TextMode="MultiLine"
                        Height="50" Wrap="true" />
                    <%--<asp:RequiredFieldValidator ID="valKesimpulanPerbaikan" runat="server" ControlToValidate="txtKesimpulanPerbaikan" ErrorMessage="*" />--%>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left" bgcolor="#7E7E7E" style="font-family: 'Arial Black';
                    font-size: large; font-weight: normal; font-variant: normal; text-transform: uppercase;
                    color: #000000; background-color: #7E7E7E; font-style: normal;">
                    E. Verifikasi Efektivitas Perbaikan, Tindakan Perbaikan, dan Tindakan Pencegahan
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top" class="style1">
                    Verifikasi Efektivitas Perbaikan, Tindakan Perbaikan, dan Tindakan Pencegahan :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtVerifikasi" runat="server" Width="400" TextMode="MultiLine" Height="50"
                        Wrap="true" />
                    <asp:RequiredFieldValidator ID="valVerifikasi" runat="server" ControlToValidate="txtVerifikasi"
                        ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" class="style1">
                    Kesimpulan :
                </td>
                <td align="left">
                    <asp:UpdatePanel ID="upKesimpulan2" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlKesimpulanVerifikasi" runat="server" AutoPostBack="true">
                                <asp:ListItem Text="- Pilih Kesimpulan Verifikasi -" Value="0" Selected="True" />
                                <asp:ListItem Text="Efektif" Value="1" />
                                <asp:ListItem Text="Terbit Baru" Value="2" />
                            </asp:DropDownList>
                            &nbsp;
                            <br>
                            <br>
                            Tanggal Efektif :
                            <asp:TextBox ID="txtTglKesimpulanVerifikasi" runat="server" Width="80" Enabled="false" />
                            <%-- <asp:ImageButton ID="btnTglKesimpulanVerifikasi" runat="server" ImageUrl="~/Image/25.png" />--%>
                            <asp:Image ID="btnTglKesimpulanVerifikasi" runat="server" ImageUrl="~/Image/25.png" />
                            <AjaxToolkit:CalendarExtender ID="calTglKesimpulanVerifikasi" runat="server" TargetControlID="txtTglKesimpulanVerifikasi"
                                PopupButtonID="btnTglKesimpulanVerifikasi" CssClass="MyCalendar" Format="dd-MMM-yy"
                                PopupPosition="TopLeft" />
                            <%--<asp:RequiredFieldValidator ID="valTglKesimpulanVerifikasi" runat="server" ControlToValidate="txtTglKesimpulanVerifikasi" ErrorMessage="*" />--%>
                            &nbsp; Terbit Baru
                            <asp:TextBox ID="txtTerbitBaru" runat="server" Enabled="false" Height="19px" Width="178px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" colspan="2">
                    <asp:LinkButton ID="btnDelete" CssClass="LinkButton" Enabled="false" runat="server"
                        Text="Delete" />
                    &nbsp;|&nbsp;
                    <asp:LinkButton ID="btnSave" CssClass="LinkButton" runat="server" Text="Save" />
                </td>
            </tr>
            </table>
            <%-- <tr>
                <td colspan="2" align="left" bgcolor="#7E7E7E" style="font-family: 'Arial Black';
                    font-size: large; font-weight: normal; font-variant: normal; text-transform: uppercase;
                    color: #000000; background-color: #7E7E7E; font-style: normal;">
                    Detail Perbaikan
                </td>
            </tr>--%>
            <div style="background-color: #7E7E7E; padding-left: 5px; margin-top: 10px; margin-bottom: 10px">
                <h1>Detail Perbaikan</h1>
            </div>
            <asp:UpdatePanel ID="upDetailPerbaikan" runat="server">
            <ContentTemplate>
            <table>
                <tr valign="middle">
                    <td align="right" class="style1">
                        Perbaikan :
                    </td>
                    <td align="left">
                        <p>
                            Penanggung Jawab :
                            <asp:TextBox ID="txtPenanggungJawabPerbaikan" runat="server" Height="19px" Width="190px" />
                            <asp:RequiredFieldValidator ID="valPenanggungJawabPerbaikan" ValidationGroup="detail"
                                runat="server" ControlToValidate="txtPenanggungJawabPerbaikan" ErrorMessage="*" />
                            <asp:DropDownList ID="ddlDepartemenPJPerbaikan" runat="server" DataSourceID="oDept"
                                DataTextField="DeptName" DataValueField="DeptId">
                            </asp:DropDownList>
                        </p>
                        <p>
                            Batas Waktu Penyelesaian :
                            <asp:TextBox ID="txtTglPerbaikan" runat="server" Width="80" />
                            <asp:Image ID="btnTglPerbaikan" runat="server" ImageUrl="~/Image/25.png" />
                            <AjaxToolkit:CalendarExtender ID="calTglPerbaikan" runat="server" TargetControlID="txtTglPerbaikan"
                                PopupButtonID="btnTglPerbaikan" CssClass="MyCalendar" Format="dd-MMM-yy" />
                            <asp:RequiredFieldValidator ID="valTglPerbaikan" ValidationGroup="detail" runat="server"
                                ControlToValidate="txtTglPerbaikan" ErrorMessage="*" />
                        </p>
                        <asp:TextBox ID="txtPerbaikan" runat="server" Width="400" TextMode="MultiLine" Height="50"
                            Wrap="true" />
                        <p>
                            Email Reminder : &nbsp; &nbsp; &nbsp;
                            <asp:TextBox ID="txtEmailPerbaikan" runat="server" Height="21px" Width="376px" />
                            <asp:RequiredFieldValidator ID="valEmailPerbaikan" ValidationGroup="detail" runat="server"
                                ControlToValidate="txtEmailPerbaikan" ErrorMessage="*" />
                        </p>
                        <p>
                            Status :
                            <asp:CheckBox ID="chkIsClosedPerbaikan" Text="Closed" runat="server" />
                        </p>
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right" colspan="2">
                        <asp:LinkButton ID="btnHapusPerbaikan" CssClass="LinkButton" Enabled="false" Text="Delete"
                            runat="server" />&nbsp;|&nbsp;
                        <asp:LinkButton ID="btnAddPerbaikan" CssClass="LinkButton" ValidationGroup="detail"
                            Enabled="false" Text="Save" runat="server" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="gvDetailPerbaikan" runat="server" AllowSorting="true" AutoGenerateColumns="false"
                AlternatingRowStyle-BackColor="#F7F7F7" DataKeyNames="LineID" BorderColor="#333333"
                CellPadding="5">
                <Columns>
                    <asp:TemplateField ShowHeader="false" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnSelect" CssClass="LinkButton" Text="Select" CommandName="Select"
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Penanggung Jawab" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblPenanggungJawabPerbaikan" Text='<%# Eval("PenanggungJawabPerbaikan") %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Departemen" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="ddlDepartemenPJPerbaikan" Text='<%# Eval("DepartemenPJPerbaikan") %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tgl. Perbaikan" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblTglPerbaikan" Text='<%# Eval("TglPerbaikan","{0:dd-MMM-yyyy}") %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Perbaikan" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblPerbaikan" Text='<%# Eval("Perbaikan") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email Reminder" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblEmailPerbaikan" Text='<%# Eval("EmailPerbaikan") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Closed" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:CheckBox ID="chk" Checked='<%# Eval("IsClosedPerbaikan") %>' Enabled="false" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblLineID" Text='<%# Eval("LineID") %>' Style="display: none" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblLineID" Style="display: none" Text="0" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:ObjectDataSource ID="oLK_Detail" runat="server" 
        TypeName="LaporanKetidaksesuaian"
        SelectMethod="GetLaporanKetidaksesuaianDetail">
        <SelectParameters>
            <asp:ControlParameter Name="NoLK" ControlID="txtNoLK" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="oDept" runat="server" 
        TypeName="ChangeControl" 
        SelectMethod="GetDepartment">
    </asp:ObjectDataSource>
</asp:Content>
