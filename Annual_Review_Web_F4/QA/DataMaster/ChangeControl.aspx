<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="ChangeControl.aspx.vb" Inherits="QA_DataMaster_ChangeControl" title="Change Control" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding:2px;">
        <table border="0">
            <tr valign="middle">
                <td align="right">No. Change Control :</td>
                <td align="left">
                    <asp:TextBox ID="txtNoCC" runat="server" AutoPostBack="true" />
                    <asp:RequiredFieldValidator ID="valNoCC" ValidationGroup="master" runat="server" ControlToValidate="txtNoCC" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">
                    Nama Produk / Sistem :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtProduk" runat="server" />
                    <asp:RequiredFieldValidator ID="valProduk" ValidationGroup="master" runat="server" ControlToValidate="txtProduk" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Kode Produk :</td>
                <td align="left">
                    <asp:TextBox ID="txtProdID" Width="200" TextMode="MultiLine" Height="50" Wrap="true" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">No. Batch :</td>
                <td align="left">
                    <asp:TextBox ID="txtNoBatch" Width="200" TextMode="MultiLine" Height="50" Wrap="true" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Jenis Perubahan :</td>
                <td align="left">
                    <asp:TextBox ID="txtJenisPerubahan" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                    <asp:RequiredFieldValidator ID="valJenisPerubahan" ValidationGroup="master" runat="server" ControlToValidate="txtJenisPerubahan" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Kategori Perubahan :</td>
                <td align="left">
                    <asp:DropDownList ID="ddlKategori" runat="server">
                        <asp:ListItem Text="Minor" Value="1" Selected="True" />
                        <asp:ListItem Text="Mayor" Value="2" />
                        <asp:ListItem Text="Critical" Value="3" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Status saat ini :</td>
                <td align="left">
                    <asp:TextBox ID="txtStatus" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                    <asp:RequiredFieldValidator ID="valStatus" ValidationGroup="master" runat="server" ControlToValidate="txtStatus" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Uraian usul perubahan :</td>
                <td align="left">
                    <asp:TextBox ID="txtUraian" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                    <asp:RequiredFieldValidator ID="valUraian" ValidationGroup="master" runat="server" ControlToValidate="txtUraian" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Alasan perubahan :</td>
                <td align="left">
                    <asp:TextBox ID="txtAlasan" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                    <asp:RequiredFieldValidator ID="valAlasan" ValidationGroup="master" runat="server" ControlToValidate="txtAlasan" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Pemberi Usul :</td>
                <td align="left">
                    <asp:TextBox ID="txtPengusul" runat="server" />
                    <asp:RequiredFieldValidator ID="valPengusul" ValidationGroup="master" runat="server" ControlToValidate="txtPengusul" ErrorMessage="*" />
                    &nbsp; 
                    <asp:DropDownList ID="ddlDept" DataSourceID="oDept" DataTextField="DeptName" 
                        DataValueField="DeptId" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Tgl. Pengajuan :</td>
                <td align="left">
                    <asp:TextBox ID="txtTglPengajuan" runat="server" Width="80" />
                    <asp:ImageButton ID="btnTglPengajuan" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calTglPengajuan" runat="server"
                        TargetControlID="txtTglPengajuan"
                        PopupButtonID="btnTglPengajuan"
                        CssClass="MyCalendar"
                        Format="dd-MMM-yy" />
                    <asp:RequiredFieldValidator ID="valTglPengajuan" ValidationGroup="master" runat="server" ControlToValidate="txtTglPengajuan" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top">Disetujui :</td>
                <td align="left">
                    <asp:RadioButton ID="rbNo" Text="Tidak" GroupName="persetujuan" runat="server" />
                    <asp:RadioButton ID="rbYes" Text="Ya" GroupName="persetujuan" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top" style="width: 200px">Pemberitahuan/Persetujuan ke / dari badan otoritas :</td>
                <td align="left">
                    <asp:RadioButton ID="rbTidak" Text="Tidak" GroupName="bpom" runat="server" />
                    <asp:RadioButton ID="rbYa" Text="Ya" GroupName="bpom" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Kesimpulan :</td>
                <td align="left">
                    <asp:TextBox ID="txtKesimpulan" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" colspan="2">
                    <asp:LinkButton ID="btnDelete" CssClass="LinkButton" Enabled="false" runat="server" Text="Delete" /> &nbsp;|&nbsp;
                    <asp:LinkButton ID="btnSave" CssClass="LinkButton" ValidationGroup="master" runat="server" Text="Save" />
                </td>
            </tr>
        </table>
        <div style="background-color: #7E7E7E; padding-left: 5px; margin-top: 10px; margin-bottom: 10px">
            <h1>Pelaksana</h1>
        </div>
        <asp:UpdatePanel ID="upPelaksana" runat="server">
        <ContentTemplate>
            <table>
                <tr valign="middle">
                    <td align="right">Dilaksanakan oleh :</td>
                    <td align="left">
                        <asp:TextBox ID="txtPelaksana" runat="server" />
                        <asp:RequiredFieldValidator ID="valPelaksana" ValidationGroup="detail" runat="server" ControlToValidate="txtPelaksana" ErrorMessage="*" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Tgl. Selesai :</td>
                    <td align="left">
                        <asp:TextBox ID="txtTglSelesai" runat="server" Width="80" />
                        <asp:ImageButton ID="btnTglSelesai" runat="server" ImageUrl="~/Image/25.png" />
                        <AjaxToolkit:CalendarExtender ID="calSelesai" runat="server"
                            TargetControlID="txtTglSelesai"
                            PopupButtonID="btnTglSelesai"
                            CssClass="MyCalendar"
                            Format="dd-MMM-yy" />
                        <asp:RequiredFieldValidator ID="valTglSelesai" ValidationGroup="detail" runat="server" ControlToValidate="txtTglSelesai" ErrorMessage="*" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Tindakan :</td>
                    <td align="left">
                        <asp:TextBox ID="txtTindakan" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Verifikasi :</td>
                    <td align="left">
                        <asp:TextBox ID="txtVerifikasi" runat="server" Width="400" TextMode="MultiLine" Height="50" Wrap="true" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Email reminder :</td>
                    <td align="left">
                        <asp:TextBox ID="txtEmail" width="400" runat="server" />
                        <asp:RequiredFieldValidator ID="valEmail" ValidationGroup="detail" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Status :</td>
                    <td align="left">
                        <asp:CheckBox ID="chkIsClosed" Text="Closed" runat="server" />
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
            <asp:GridView ID="gvPelaksana" runat="server" AllowSorting="true" AutoGenerateColumns="false" AlternatingRowStyle-BackColor="#F7F7F7"
                DataKeyNames="LineID" BorderColor="#333333" CellPadding="5">
                <Columns>
                    <asp:TemplateField ShowHeader="false" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnSelect" CssClass="LinkButton" Text="Select" CommandName="Select" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pelaksana" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblPelaksana" Text='<%# Eval("Pelaksana") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tgl. Selesai" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label id="lblTglSelesai" Text='<%# Eval("TglSelesai","{0:dd-MMM-yyyy}") %>' runat="server" /> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tindakan" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblTindakan" Text='<%# Eval("Tindakan") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Verifikasi" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblVerifikasi" Text='<%# Eval("Verifikasi") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email Reminder" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" Text='<%# Eval("email") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Closed" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkIsClosed" Checked='<%# Eval("IsClosed") %>' Enabled="false" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblLineID" Text='<%# Eval("LineID") %>' style="display: none" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblLineID" style="display:none" Text="0" runat="server" />
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:ObjectDataSource ID="oCC_Detail"  runat="server" 
        TypeName="ChangeControl"
        SelectMethod="GetChangeControlDetail">
        <SelectParameters>
            <asp:ControlParameter Name="NoCC" ControlID="txtNoCC" PropertyName="Text" Type="String" />
        </SelectParameters>
        </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="oDept" runat="server"
        TypeName="ChangeControl"
        SelectMethod="GetDepartment">
    </asp:ObjectDataSource>
</asp:Content>

