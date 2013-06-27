<%@ Page Title="Evaluasi Produk Retur" Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="ProdukRetur.aspx.vb" Inherits="QA_DataMaster_ProdukRetur" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <script type="text/javascript">
        var txtProdID, txtProdName;

        function pageLoad() {
            txtProdID = $get("<%=txtProdID.ClientID%>");
            lblProdName = $get("<%=lblProdName.ClientID%>");
            $addHandler(txtProdID,"blur",txtProdID_OnBlur);
            Sys.Application.add_disposing(appDispose);
        }

        function txtProdID_OnBlur(e) {
            if(this.value != '')
                WS_ProdukReview.GetProdNameByCode(this.value,onProdSuccess, onProdError);
        }
               
        function appDispose() {
            $clearHandlers(txtProdID);
        }
        
        function onProdSuccess(result) {
            if (result == '') {
                alert('Kode Produk belum ada dalam database\n Coba masukkan kode yang lain');
                txtProdID.value = '';
                txtProdID.focus();
            } else {
                lblProdName.innerHTML = result;
            }
        }
               
        function onProdError(err) {
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
    <asp:Panel ID="pnlRetur" DefaultButton="btnFind" runat="server">
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
                <td align="right">
                    Kode Produk :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtProdID" Width="80" runat="server" />
                    <asp:RequiredFieldValidator ID="valProdID" runat="server" ValidationGroup="master" ControlToValidate="txtProdID" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Nama Produk :</td>
                <td align="left">
                    <asp:Label ID="lblProdName" Text="" runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">No. Batch :</td>
                <td align="left">
                    <asp:TextBox ID="txtNoBatch" Width="80" runat="server" />
                    <asp:RequiredFieldValidator ID="valNoBatch" runat="server" ValidationGroup="master" ControlToValidate="txtNoBatch" ErrorMessage="*" /> &nbsp;
                    <asp:ImageButton ID="btnFind" runat="server" 
                        ImageUrl="~/Image/001_60.png" ValidationGroup="master" 
                        ToolTip="Find Produk" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Jumlah :</td>
                <td align="left">
                    <asp:Label ID="lblQty" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="lblDataNotFound" ForeColor="Red" Visible="false" Text="Data Tidak Ditemukan !!" runat="server" />
                </td>
            </tr>
        </table>   
        </asp:Panel> 
        <asp:TextBox ID="txtPPICLineID" Text="0" Style="display:none" runat="server" />
        <div style="background-color: #7E7E7E; padding-left: 5px; margin-top: 10px; margin-bottom: 10px">
            <h1>Evaluasi</h1>
        </div>
        <asp:UpdatePanel ID="upPelaksana" runat="server">
        <ContentTemplate>
            <table>
                <tr valign="middle">
                    <td align="right">Jml. Sampel :</td>
                    <td align="left">
                        <asp:TextBox ID="txtJmlSampel" Width="80" Text="0" style="text-align:right" runat="server" />
                        <asp:RequiredFieldValidator ID="valJmlSample" ValidationGroup="detail" runat="server" ControlToValidate="txtJmlSampel" ErrorMessage="*" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">
                        Kategori Evaluasi :
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlCatEvaluasi" DataSourceID="oEvaluasi" runat="server"
                            DataTextField="Evaluasi" DataValueField="EvalCode" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">
                        Hasil Evaluasi :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtHasilEvaluasi" Width="250" TextMode="MultiLine" runat="server" />
                        <asp:RequiredFieldValidator ID="valHasilEvaluasi" ValidationGroup="detail" runat="server" ControlToValidate="txtHasilEvaluasi" ErrorMessage="*" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right">Disposisi :</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlDisposisi" DataSourceID="oDisposisi" runat="server" 
                            DataTextField="Disposisi" DataValueField="DisposisiCode" />
                    </td>
                </tr>
                <tr valign="middle">
                    <td align="right" colspan="2">
                        <asp:LinkButton ID="btnHapus" CssClass="LinkButton" Enabled="false" Text="Delete" runat="server" />&nbsp;|&nbsp;
                        <asp:LinkButton ID="btnAdd" CssClass="LinkButton" ValidationGroup="detail" Enabled="false" Text="Save" runat="server" />
                    </td>
                </tr>
            </table>
            <asp:TextBox ID="txtLineID" Text="0" Style="display:none" runat="server" />
            <br />
            <asp:GridView ID="gvRetur" runat="server" AllowSorting="true" AutoGenerateColumns="false" AlternatingRowStyle-BackColor="#F7F7F7"
                DataKeyNames="LineID" BorderColor="#333333" CellPadding="5">
                <Columns>
                    <asp:TemplateField ShowHeader="false" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnSelect" CssClass="LinkButton" Text="Select" CommandName="Select" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Jml. Sampel" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblJmlSampel" Text='<%# Eval("JmlSampel") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Kategori Evaluasi" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblEvalName" Text='<%# GetEvalName(Eval("CatEvaluasi")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hasil Evaluasi" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblHasilEvaluasi" Text='<%# Eval("HasilEvaluasi") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Disposisi" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblDispName" Text='<%# GetDisposisiName(Eval("Disposisi")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblLineID" Text='<%# Eval("LineID") %>' style="display:none" runat="server" />
                            <asp:Label ID="lblCatEvaluasi" Text='<%# Eval("CatEvaluasi") %>' style="display:none" runat="server" />
                            <asp:Label ID="lblDisposisi" Text='<%# Eval("Disposisi") %>' style="display:none" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:ObjectDataSource ID="oProdRetur" runat="server"
        TypeName="ProdukRetur"
        SelectMethod="GetProdukRetur">
        <SelectParameters>
            <asp:Parameter Name="PPIC_LineID" DbType="Int32" />
        </SelectParameters>
        </asp:ObjectDataSource>
        
    <asp:ObjectDataSource ID="oEvaluasi" runat="server"
        TypeName="ProdukRetur"
        SelectMethod="GetAllEvaluasiCat">
    </asp:ObjectDataSource>      
    
    <asp:ObjectDataSource ID="oDisposisi" runat="server"
        TypeName="ProdukRetur"
        SelectMethod="GetAllDisposisi">
    </asp:ObjectDataSource>
</asp:Content>

