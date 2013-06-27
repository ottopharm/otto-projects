<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false"
    CodeFile="ProdukSpek.aspx.vb" Inherits="QA_DataMaster_ProdukSpek" Title="Spek Produk" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        var txt_ProdID

        function pageLoad() {
            txt_ProdID = $get("<%=txtProdID.ClientID%>");
            $addHandler(txt_ProdID, "blur", txtProdID_onBlur);
            Sys.Application.add_disposing(appDispose);
        }

        function txtProdID_onBlur(e) {
            if (this.value != '')
                WS_ProdukReview.ValidateMasterListProd(this.value, onSuccess, onError);
        }

        function appDispose() {
            $clearHandlers(txt_ProdID);
        }

        function onSuccess(result) {
            if (!result) {
                alert('Produk ID belum terdaftar dalam master list!');
                txt_ProdID.value = '';
                txt_ProdID.focus();
            }
            else
                <%=PostBackStr%>
        }

        function onError(err) {
            alert(err.get_message());
        }
                
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="smProxy" runat="server">
        <Services>
            <asp:ServiceReference Path="~/WS_ProdukReview.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <div style="padding: 2px;">
        <table border="0">
            <tr valign="middle">
                <td align="right">
                    Kode Produk :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtProdID" runat="server" />
                    <asp:RequiredFieldValidator ID="valProdID" runat="server" ValidationGroup="master"
                        ControlToValidate="txtProdID" ErrorMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">
                    Nama Produk :
                </td>
                <td align="left">
                    <asp:Label ID="lblNamaProduk" Text="." runat="server" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top">
                    No. PBP OJ :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPBPOJ" runat="server" Width="200" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">
                    Tgl PBP OJ :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtTglPBPOJ" runat="server" Width="80" />
                    <asp:ImageButton ID="btnPBPOJ" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calPBPOJ" runat="server" TargetControlID="txtTglPBPOJ"
                        PopupButtonID="btnPBPOJ" CssClass="MyCalendar" Format="dd-MMM-yy" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" valign="top">
                    Ref. PBP OJ :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtRefPBPOJ" runat="server" Width="200" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right" colspan="2">
                    <asp:LinkButton ID="btnSave" CssClass="LinkButton" ValidationGroup="master" runat="server"
                        Text="Save" />
                </td>
            </tr>
        </table>
        <div style="background-color: #7E7E7E; padding-left: 5px; margin-top: 10px; margin-bottom: 10px">
            <h1>
                Kadar</h1>
        </div>
        <asp:UpdatePanel ID="upKadar" runat="server">
            <ContentTemplate>
                <table border="0">
                    <tr valign="middle">
                        <td align="right">
                            Parameter :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtParameter" runat="server" />
                            <asp:RequiredFieldValidator ID="valParameter" runat="server" ControlToValidate="txtParameter"
                                ErrorMessage="*" ValidationGroup="Insert" />
                        </td>
                    </tr>
                    <tr valign="middle">
                        <td align="right">
                            Spesifikasi :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtSpek" runat="server" />
                            <asp:RequiredFieldValidator ID="valSpek" runat="server" ControlToValidate="txtSpek"
                                ErrorMessage="*" ValidationGroup="Insert" />
                        </td>
                    </tr>
                    <tr valign="middle">
                        <td align="right" colspan="2">
                            <asp:LinkButton ID="btnAdd" CssClass="LinkButton" runat="server" Text="Add" ValidationGroup="Insert" />
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="gvProdSpek" runat="server" AllowSorting="true" AutoGenerateColumns="false"
                    AlternatingRowStyle-BackColor="#F7F7F7" DataKeyNames="LineID" BorderColor="#333333"
                    CellPadding="5">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEdit" ImageUrl="~/Image/001_45.png" ToolTip="Edit" CommandName="Edit"
                                    runat="server" />
                                &nbsp;
                                <asp:ImageButton ID="btnDelete" ImageUrl="~/Image/001_05.png" ToolTip="Delete" CommandName="Delete"
                                    runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="btnSave" ImageUrl="~/Image/001_06.png" ToolTip="Save" runat="server"
                                    CommandName="Update" />
                                <asp:ImageButton ID="btnCancel" ImageUrl="~/Image/001_05.png" ToolTip="Cancel" CommandName="Cancel"
                                    runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Parameter" HeaderText="Parameter" ItemStyle-Width="200" />
                        <asp:BoundField DataField="Spesifikasi" HeaderText="Spesifikasi" ItemStyle-Width="200" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblLineID" runat="server" Text='<%# Eval("LineID") %>' Style="display: none;" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblLineID" runat="server" Text='<%# Eval("LineID") %>' Style="display: none;" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:ObjectDataSource ID="oProdSpek" runat="server" TypeName="ProductReview" SelectMethod="GetProdukSpek"
        UpdateMethod="SaveProdSpek" InsertMethod="SaveProdSpek" DeleteMethod="DeleteProdSpek">
        <SelectParameters>
            <asp:ControlParameter Name="ItemCode" ControlID="txtProdID" PropertyName="Text" Type="String" />
        </SelectParameters>
        <InsertParameters>
            <asp:ControlParameter Name="ItemCode" ControlID="txtProdID" PropertyName="Text" Type="String" />
            <asp:ControlParameter Name="Parameter" ControlID="txtParameter" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter Name="Spesifikasi" ControlID="txtSpek" PropertyName="Text"
                Type="String" />
            <asp:Parameter Name="IsInsert" Type="Boolean" DefaultValue="true" />
            <asp:Parameter Name="LineID" Type="Int32" DefaultValue="0" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Parameter" Type="String" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="Spesifikasi" Type="String" ConvertEmptyStringToNull="true" />
            <asp:Parameter Name="LineID" Type="Int32" />
            <asp:Parameter Name="IsInsert" Type="Boolean" DefaultValue="false" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="LineID" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
</asp:Content>
