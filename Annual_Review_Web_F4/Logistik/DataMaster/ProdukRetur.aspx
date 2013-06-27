<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="ProdukRetur.aspx.vb" Inherits="Logistic_DataMaster_ProdukRetur" title="Produk Kembalian - PPIC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript">
        var txtNoBatch;

        function pageLoad() {
            txtNoLPK = $get("<%=txtNoLPK.ClientID%>");
            txtProdID = $get("<%=txtProdID.ClientID%>");
            lblProdName = $get("<%=lblProdName.ClientID%>");
            hideProdName = $get("<%=hideProdName.ClientID%>");
            ddlUoM = $get("<%=ddlUoM.ClientID%>");
            txtNoBatch = $get("<%=txtNoBatch.ClientID%>");
            $addHandler(txtNoLPK, "blur", txtNoLPK_OnBlur);
            $addHandler(txtProdID,"blur",txtProdID_OnBlur);
            $addHandler(txtNoBatch,"blur",txtNoBatch_OnBlur);
            Sys.Application.add_disposing(appDispose);
        }

        function txtNoLPK_OnBlur(e) {
            if(this.value != '')
                <%=PostBackStr%>
        }
        
        function txtProdID_OnBlur(e) {
            if(this.value != '')
                WS_ProdukReview.GetProdNameByCode(this.value,onProdSuccess, onProdError);
        }
        
        function txtNoBatch_OnBlur(e) {
            if(this.value != '')
                WS_ProdukReview.CekBatchDN(this.value,txtProdID.value,onSuccess, onError);
        }

        function appDispose() {
            $clearHandlers(txtNoLPK);
            $clearHandlers(txtProdID);
            $clearHandlers(txtNoBatch);
        }
        
        function onProdSuccess(result) {
            if (result == '') {
                alert('Kode Produk belum ada dalam database\n Coba masukkan kode yang lain');
                txtProdID.value = '';
                txtProdID.focus();
            } else {
                lblProdName.innerHTML = result;
                hideProdName.value = result;
                ddlUoM.focus();
            }
        }
        
        function onSuccess(result) {
            if (!result) {
                alert('No Batch Salah !');
                txtNoBatch.value = '';
                txtNoBatch.focus();
            }   
        }
        
        function onProdError(err) {
            alert(err.get_message());
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
                <td align="right">
                    No. LPK :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNoLPK" Width="100" runat="server" />
                    <asp:RequiredFieldValidator ID="valNoLPK" ValidationGroup="master" runat="server" ControlToValidate="txtNoLPK" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Tgl.LPK :</td>
                <td align="left">
                    <asp:TextBox ID="txtTglLPK" runat="server" Width="80" />
                    <asp:ImageButton ID="btnTglLPK" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calLPK" runat="server"
                        TargetControlID="txtTglLPK"
                        PopupButtonID="btnTglLPK"
                        CssClass="MyCalendar"
                        Format="dd-MMM-yy" />
                    <asp:RequiredFieldValidator ID="valTglLPK" ValidationGroup="master" runat="server" ControlToValidate="txtTglLPK" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" style="width: 142">Asal MBS :</td>
                <td align="left">
                    <asp:DropDownList ID="ddlAsalMBS" runat="server" 
                        DataSourceID="oMBS"
                        DataTextField="Cabang"
                        DataValueField="KodeCabang">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">No. SPPB :</td>
                <td align="left">
                    <asp:TextBox ID="txtNoSPPB" Width="80" runat="server" />
                     <asp:RequiredFieldValidator ID="valNoSPPB" ValidationGroup="master" runat="server" ControlToValidate="txtNoSPPB" ErrorMessage="*" />                  
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" colspan="2">
                    <asp:LinkButton ID="btnDelete" CssClass="LinkButton" Enabled="false" 
                        OnClientClick="return confirm('Semua data yang berhubungan dengan no. LPK ini,\nbaik yang diinput oleh PPIC dan QA akan dihapus.\nLanjutkan ?');" 
                        runat="server" Text="Delete" /> &nbsp;|&nbsp;
                    <asp:LinkButton ID="btnSave" CssClass="LinkButton" ValidationGroup="master" runat="server" Text="Save" />
                </td>
            </tr>
        </table>
        <div style="background-color: #7E7E7E; padding-left: 5px; margin-top: 10px; margin-bottom: 10px">
            <h1>Produk</h1>
        </div>
        <asp:UpdatePanel ID="upPelaksana" runat="server">
        <ContentTemplate>
            <table>
                <tr valign="middle">
                <td align="right">
                    Kode Produk :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtProdID" Width="80" runat="server" />
                    <asp:RequiredFieldValidator ID="valProdID" runat="server" ValidationGroup="detail" ControlToValidate="txtProdID" ErrorMessage="*" />
                </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Nama Produk :</td>
                    <td align="left">
                        <asp:Label ID="lblProdName" Text="" runat="server" />
                        <asp:HiddenField ID="hideProdName" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Satuan :</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlUoM" runat="server">
                            <asp:ListItem Value="Ampul" Text="Ampul" />
                            <asp:ListItem Value="Botol" Text="Botol" />
                            <asp:ListItem Value="Kapsul" Text="Kapsul" />
                            <asp:ListItem Value="Kaplet" Text="Kaplet" />
                            <asp:ListItem Value="Sachet" Text="Sachet" />
                            <asp:ListItem Value="Tablet" Text="Tablet" />
                            <asp:ListItem Value="Tube" Text="Tube" />
                            <asp:ListItem Value="Vial" Text="Vial" />
                            <asp:ListItem Value="Pot" Text="Pot" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">
                        Jumlah :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtQty" Width="80" style="text-align:right" runat="server" />
                        <asp:RequiredFieldValidator ID="valQty" ValidationGroup="detail" runat="server" ControlToValidate="txtQty" ErrorMessage="*" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">
                        No. Batch :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtNoBatch" Width="80" runat="server" />
                        <asp:RequiredFieldValidator ID="valNoBatch" ValidationGroup="detail" runat="server" ControlToValidate="txtNoBatch" ErrorMessage="*" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Penggantian :</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlPenggantian" runat="server">
                            <asp:ListItem Text="Diganti" Value="D" />
                            <asp:ListItem Text="Tidak Diganti" Value="T" />
                            <asp:ListItem Text="NONE" Value="N" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">
                        Keterangan :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtKeterangan" Width="250" Height="50" TextMode="MultiLine" runat="server" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right" colspan="2">
                        <asp:LinkButton ID="btnHapus" CssClass="LinkButton" Enabled="false" 
                            OnClientClick="return confirm('Semua data yang berhubungan dengan Produk dan Batch ini,\nbaik yang diinput oleh PPIC dan QA akan dihapus.\nLanjutkan ?');" 
                            Text="Delete" runat="server" />&nbsp;|&nbsp;
                        <asp:LinkButton ID="btnAdd" CssClass="LinkButton" ValidationGroup="detail" Enabled="false" Text="Save" runat="server" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="gvRetur" runat="server" AllowSorting="true" AutoGenerateColumns="false" AlternatingRowStyle-BackColor="#F7F7F7"
                DataKeyNames="LineID" BorderColor="#333333" CellPadding="5">
                <Columns>
                    <asp:TemplateField ShowHeader="false" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnSelect" CssClass="LinkButton" Text="Select" CommandName="Select" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Kode Produk" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblProdID" Text='<%# Eval("ItemCode") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nama Produk" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label id="lblProdName" Text='<%# Eval("ProdName") %>' runat="server" /> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Satuan" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblUoM" Text='<%# Eval("UoM") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Jumlah" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblQty" Text='<%# Eval("Qty") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="No Batch" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblBatch" Text='<%# Eval("Batch") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Exp. Date" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblED" Text='<%# Eval("ED","{0:dd-MMM-yyyy}") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Penggantian" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblPenggantian" Text='<%# GetPenggantian(Eval("Penggantian")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Keterangan" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblKeterangan" Text='<%# Eval("Keterangan") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblLineID" Text='<%# Eval("LineID") %>' style="display: none" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblLineID" Text="0" style="display:none" runat="server" />
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:ObjectDataSource ID="oReturDetail" runat="server" 
        TypeName="ProdukRetur"
        SelectMethod="GetProdukReturDetail">
        <SelectParameters>
            <asp:ControlParameter Name="NoLPK" ControlID="txtNoLPK" PropertyName="Text" Type="String" />
            <asp:Parameter Name="Dept" Type="Int16" DefaultValue="1" />
        </SelectParameters>
        </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="oMBS" runat="server"
        TypeName="ProdukRetur"
        SelectMethod="GetAllCabangMBS"></asp:ObjectDataSource>
</asp:Content>

