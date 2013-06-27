<%@ Page Language="VB" MasterPageFile="~/MasterPage/main.master" AutoEventWireup="false" CodeFile="ProductReview-QC.aspx.vb" Inherits="QC_DataMaster_ProductReview_QC" title="QC APR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
        var txtNoBatch;

        function pageLoad() {
            txtNoBatch = $get("<%=txtNoBatch.ClientID%>");
            $addHandler(txtNoBatch, "blur", txtNoBatch_OnBlur);
            Sys.Application.add_disposing(appDispose);
        }

        function txtNoBatch_OnBlur(e) {
            if(this.value != '')
                WS_ProdukReview.ValidateNoBatch(this.value,$get("<%=txtProdID.ClientID%>").value,onSuccess, onError);
        }

        function appDispose() {
            $clearHandlers(txtNoBatch);
        }
        
        function onSuccess(result) {
            if (!result) {
                alert('No Batch Salah !');
                txtNoBatch.value = '';
                txtNoBatch.focus();
            }
            else
                <%=PostBackStr%>
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
    <asp:panel ID="pnl" runat="server" Enabled="true" style="padding:2px">
        <table border="0">
            <tr valign="middle">
                <td align="right" style="width:130px">
                    Produk :
                </td>
                <td align="left" colspan="2">
                    <asp:Label ID="lblProdName" runat="server" Text="." />
                    <asp:TextBox ID="txtProdID" runat="server" style="display:none" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">
                    No. Batch :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNoBatch" runat="server" />
                    <asp:RequiredFieldValidator ID="valNoBatch" runat="server" ControlToValidate="txtNoBatch" ErrorMessage="*" ValidationGroup="Save" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Expired Date :</td>
                <td align="left">
                    <asp:TextBox ID="txtEDmm" runat="server" Width="20" />
                    <AjaxToolkit:MaskedEditExtender ID="meEDmm" runat="server"
                        MaskType="Number"
                        Mask="99"
                        ClearTextOnInvalid="true"
                        TargetControlID="txtEDmm"
                        ClearMaskOnLostFocus="false" />
                    -
                    <asp:TextBox ID="txtEDyy" runat="server" Width="40" />
                    <AjaxToolkit:MaskedEditExtender ID="meEDyy" runat="server"
                        MaskType="Number"
                        Mask="9999"
                        ClearTextOnInvalid="true"
                        TargetControlID="txtEDyy"
                        ClearMaskOnLostFocus="false" />
                    &nbsp;
                    <AjaxToolkit:MaskedEditValidator ID="mevEDmm" runat="server"
                        SetFocusOnError="true"
                        ControlToValidate="txtEDmm"
                        ControlExtender="meEDmm"
                        MinimumValue="1"
                        MinimumValueMessage="Bulan : 01-12"
                        MaximumValue="12"
                        MaximumValueMessage="Bulan : 01-12"
                        InvalidValueMessage="*" />
                    &nbsp;
                    <AjaxToolkit:MaskedEditValidator ID="mevEDyy" runat="server"
                        SetFocusOnError="true"
                        ControlToValidate="txtEDyy"
                        ControlExtender="meEDyy"
                        MinimumValue="2007"
                        MinimumValueMessage="Min. Th : 2007"
                        MaximumValue="2100"
                        MaximumValueMessage="Max. Th : 2100"
                        InvalidValueMessage="*" />
                </td>
            </tr>
            <tr valign="middle">
                <td align="right">Tgl. CPB ke QC :</td>
                <td>
                    <asp:TextBox ID="txtCPBDate" runat="server" Width="100" />
                    <asp:ImageButton ID="btnCPBDate" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calCPBDate" runat="server"
                        TargetControlID="txtCPBDate"
                        PopupButtonID="btnCPBDate"
                        Format="dd-MMM-yy"
                        CssClass="MyCalendar"/>
                 </td>
            </tr>
            <tr valign="middle">
                <td align="right">Tgl. CKB ke QC :</td>
                <td>
                    <asp:TextBox ID="txtCKBDate" runat="server" Width="100" />
                    <asp:ImageButton ID="btnCKBDate" runat="server" ImageUrl="~/Image/25.png" />
                    <AjaxToolkit:CalendarExtender ID="calCKBDate" runat="server"
                        TargetControlID="txtCKBDate"
                        PopupButtonID="btnCKBDate"
                        Format="dd-MMM-yy"
                        CssClass="MyCalendar"/>
                 </td>
            </tr>
        </table>
        <br />
        <div class="groupTitle">
            <div style="text-align:center; background-color:Navy">
                Besar Batch    
            </div>
        </div>
        <div class="groupContent">
            <table border="0">
                <tr valign="middle">
                    <td align="right">KG;LITER :</td>
                    <td align="left">
                        <asp:TextBox ID="txtBatch1" runat="server" Width="100" Text="0" style="text-align:right" />
                        <asp:RequiredFieldValidator ID="valBatch1" runat="server" ControlToValidate="txtBatch1" ErrorMessage="*" />
                        <AjaxToolkit:AutoCompleteExtender ID="acBatch1" runat="server"
                            TargetControlID="txtBatch1"
                            ServicePath="~/WS_ProdukReview.asmx"
                            ServiceMethod="GetListBatch1"
                            CompletionSetCount="5"
                            MinimumPrefixLength="1"
                            UseContextKey="true"
                            OnLoad="AutoComplete_Load"/> 
                    </td>
                </tr>
                <tr> 
                    <td align="right">Butir;botol;tube;ampul :</td>
                    <td align="left">
                        <asp:TextBox ID="txtBatch2" runat="server" Width="100" Text="0" style="text-align:right"/>
                        <asp:RequiredFieldValidator ID="valBatch2" runat="server" ControlToValidate="txtBatch2" ErrorMessage="*" />
                        <AjaxToolkit:AutoCompleteExtender ID="acBatch2" runat="server"
                            TargetControlID="txtBatch2"
                            ServicePath="~/WS_ProdukReview.asmx"
                            ServiceMethod="GetListBatch2"
                            CompletionSetCount="5"
                            MinimumPrefixLength="1"
                            UseContextKey="true"
                            OnLoad="AutoComplete_Load"/> 
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="groupTitle">
            <div style="text-align:center; background-color:Navy">
                CPB    
            </div>
        </div>
        <div class="groupContent">
            <asp:UpdatePanel ID="upCPB" runat="server" UpdateMode="Conditional">
                <ContentTemplate>  
                    <table border="0">
                        <tr valign="middle">
                            <td align="right">Kode Dokumen :</td>
                            <td align="left">
                                <asp:TextBox ID="txtCPBDoc" runat="server" Width="150" AutoPostBack="true" />
<%--                                <asp:RequiredFieldValidator ID="valCPBDoc" runat="server" ControlToValidate="txtCPBDoc" ErrorMessage="*" ValidationGroup="Save"  />
--%>                                <AjaxToolkit:AutoCompleteExtender ID="aceCPBDoc" runat="server"
                                    TargetControlID="txtCPBDoc"
                                    ServicePath="~/WS_ProdukReview.asmx"
                                    ServiceMethod="GetListDocCPB"
                                    CompletionSetCount="5"
                                    MinimumPrefixLength="1"
                                    UseContextKey="true"
                                    OnLoad="AutoComplete_Load"/> 
                            </td>
                            <td style="width:30px"></td>
                            <td align="right">Tgl. Berlaku :</td>
                            <td align="left">
                                <asp:TextBox ID="txtTglCPB" runat="server" Width="100" />
                                <asp:ImageButton ID="btnTglCPB" runat="server" ImageUrl="~/Image/25.png" />
                                <AjaxToolkit:CalendarExtender ID="calCPB" runat="server"
                                    TargetControlID="txtTglCPB"
                                    PopupButtonID="btnTglCPB"
                                    Format="dd-MMM-yy"
                                    CssClass="MyCalendar" />
<%--                                <asp:RequiredFieldValidator ID="valTglCPB" runat="server" ControlToValidate="txtTglCPB" ErrorMessage="*" ValidationGroup="Save" />
--%>                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">Keterangan :</td>
                            <td align="left" colspan="4" >
                                <asp:TextBox ID="txtKetCPB" runat="server" Width="100%" TextMode="MultiLine" Wrap="true" Height="40" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="txtCPBDoc" EventName="TextChanged" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="progCPB" runat="server" AssociatedUpdatePanelID="upCPB">
                <ProgressTemplate>
                    <img src="../../Image/spinner.gif" alt="" />Get Document Date...
                </ProgressTemplate>
            </asp:UpdateProgress>      
        </div>
        <br />
        <div class="groupTitle">
            <div style="text-align:center; background-color:Navy">
                CPB Penyalutan    
            </div>
        </div>
        <div class="groupContent">  
            <asp:UpdatePanel ID="upCPBP" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table border="0">
                        <tr valign="middle">
                            <td align="right">Kode Dokumen :</td>
                            <td align="left">
                                <asp:TextBox ID="txtCPBPDoc" runat="server" Width="150" AutoPostBack="true" />
<%--                                <asp:RequiredFieldValidator ID="valCPBPDoc" runat="server" ControlToValidate="txtCPBPDoc" ErrorMessage="*" ValidationGroup="Save" />
--%>                                <AjaxToolkit:AutoCompleteExtender ID="acCPBPDoc" runat="server"
                                    TargetControlID="txtCPBPDoc"
                                    ServicePath="~/WS_ProdukReview.asmx"
                                    ServiceMethod="GetListDocCPBP"
                                    CompletionSetCount="5"
                                    MinimumPrefixLength="1"
                                    UseContextKey="true"
                                    OnLoad="AutoComplete_Load"/> 
                            </td>
                            <td style="width:30px"></td>
                            <td align="right">Tgl. Berlaku :</td>
                            <td align="left">
                                <asp:TextBox ID="txtTglCPBP" runat="server" Width="100" />
                                <asp:ImageButton ID="btnTglCPBP" runat="server" ImageUrl="~/Image/25.png" />
                                <AjaxToolkit:CalendarExtender ID="calCPBP" runat="server"
                                    TargetControlID="txtTglCPBP"
                                    PopupButtonID="btnTglCPBP"
                                    Format="dd-MMM-yy"
                                    CssClass="MyCalendar" />
<%--                                <asp:RequiredFieldValidator ID="valTglCPBP" runat="server" ControlToValidate="txtTglCPBP" ErrorMessage="*" ValidationGroup="Save" />
--%>                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">Keterangan :</td>
                            <td align="left" colspan="4" >
                                <asp:TextBox ID="txtKetCPBP" runat="server" Width="100%" TextMode="MultiLine" Wrap="true" Height="40" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="txtCPBPDoc" EventName="TextChanged" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="proCPBP" runat="server" AssociatedUpdatePanelID="upCPBP">
                <ProgressTemplate>
                    <img src="../../Image/spinner.gif" alt="" />Get Document Date...
                </ProgressTemplate>
            </asp:UpdateProgress> 
        </div>
        <br />
        <div class="groupTitle">
            <div style="text-align:center; background-color:Navy">
                CKB Primer    
            </div>
        </div>
        <div class="groupContent">
            <asp:UpdatePanel ID="upCKBP" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table border="0">
                        <tr valign="middle">
                            <td align="right">Kode Dokumen :</td>
                            <td align="left">
                                <asp:TextBox ID="txtCKBPDoc" runat="server" Width="150" AutoPostBack="true" />
<%--                                <asp:RequiredFieldValidator ID="valCKBPDoc" runat="server" ControlToValidate="txtCKBPDoc" ErrorMessage="*" ValidationGroup="Save"  />
--%>                                <AjaxToolkit:AutoCompleteExtender ID="acCKBPDoc" runat="server"
                                    CompletionSetCount="5"
                                    MinimumPrefixLength="1"
                                    TargetControlID="txtCKBPDoc"
                                    ServicePath="~/WS_ProdukReview.asmx"
                                    ServiceMethod="GetListDocCKBP"
                                    UseContextKey="true"
                                    OnLoad="AutoComplete_Load"/>
                            </td>
                            <td style="width:30px"></td>
                            <td align="right">Tgl. Berlaku :</td>
                            <td align="left">
                                <asp:TextBox ID="txtTglCKBP" runat="server" Width="100" />
                                <asp:ImageButton ID="btnTglCKBP" runat="server" ImageUrl="~/Image/25.png" />
                                <AjaxToolkit:CalendarExtender ID="CalCKBP" runat="server"
                                    TargetControlID="txtTglCKBP"
                                    PopupButtonID="btnTglCKBP"
                                    Format="dd-MMM-yy"
                                    CssClass="MyCalendar" />
<%--                                <asp:RequiredFieldValidator ID="valTglCKBP" runat="server" ControlToValidate="txtTglCKBP" ErrorMessage="*" ValidationGroup="Save" />
--%>                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">Keterangan :</td>
                            <td align="left" colspan="4" >
                                <asp:TextBox ID="txtKetCKBP" runat="server" Width="100%" TextMode="MultiLine" Wrap="true" Height="40" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="txtCKBPDoc" EventName="TextChanged" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="progCKBP" runat="server" AssociatedUpdatePanelID="upCKBP">
                <ProgressTemplate>
                    <img src="../../Image/spinner.gif" alt="" />Get Document Date...
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
        <br />
        <div class="groupTitle">
            <div style="text-align:center; background-color:Navy">
                CKB Sekunder    
            </div>
        </div>
        <div class="groupContent">
            <asp:UpdatePanel ID="upCKBS" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table border="0">
                        <tr valign="middle">
                            <td align="right">Kode Dokumen :</td>
                            <td align="left">
                                <asp:TextBox ID="txtCKBSDoc" runat="server" Width="150" AutoPostBack="true" />
<%--                                <asp:RequiredFieldValidator ID="valCKBSDoc" runat="server" ControlToValidate="txtCKBSDoc" ErrorMessage="*" ValidationGroup="Save" />
--%>                                <AjaxToolkit:AutoCompleteExtender ID="acCKBSDoc" runat="server"
                                    CompletionSetCount="5"
                                    MinimumPrefixLength="1"
                                    TargetControlID="txtCKBSDoc"
                                    ServicePath="~/WS_ProdukReview.asmx"
                                    ServiceMethod="GetListDocCKBS"
                                    UseContextKey="true"
                                    OnLoad="AutoComplete_Load"/>
                            </td>
                            <td style="width:30px"></td>
                            <td align="right">Tgl. Berlaku :</td>
                            <td align="left">
                                <asp:TextBox ID="txtTglCKBS" runat="server" Width="100" />
                                <asp:ImageButton ID="btnTglCKBS" runat="server" ImageUrl="~/Image/25.png" />
                                <AjaxToolkit:CalendarExtender ID="calCKBS" runat="server"
                                    TargetControlID="txtTglCKBS"
                                    PopupButtonID="btnTglCKBS"
                                    Format="dd-MMM-yy"
                                    CssClass="MyCalendar" />
<%--                                <asp:RequiredFieldValidator ID="valTglCKBS" runat="server" ControlToValidate="txtTglCKBS" ErrorMessage="*" ValidationGroup="Save" />
--%>                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">Keterangan :</td>
                            <td align="left" colspan="4" >
                                <asp:TextBox ID="txtKetCKBS" runat="server" Width="100%" TextMode="MultiLine" Wrap="true" Height="40" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="txtCKBSDoc" EventName="TextChanged" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="progCKBS" runat="server" AssociatedUpdatePanelID="upCKBS">
                <ProgressTemplate>
                    <img src="../../Image/spinner.gif" alt="" />Get Document Date...
                </ProgressTemplate>
            </asp:UpdateProgress>            
        </div>
        <br />
        <fieldset class="kelengkapanDok">
            <legend>Kelengkapan Dokumen</legend>        
            <asp:Panel ID="pnlCPS" runat="server" Visible="false">
                <asp:CheckBox ID="chkCPS" runat="server" Text="CPS" />
            </asp:Panel>
            <asp:Panel ID="pnlCOA" runat="server" Visible="false">
                <asp:CheckBox ID="chkCoA" runat="server" Text="CoA" />
            </asp:Panel>
            <asp:Panel ID="pnlCCIsi" runat="server" Visible="false">
                <asp:CheckBox ID="chkCCIsi" runat="server" Text="CC Pengisian" />
            </asp:Panel>
            <asp:Panel ID="pnlPrimer" runat="server" Visible="false">
                <asp:CheckBox ID="chkPrimer" runat="server" Text="CC Proses Pengemasan Primer" />
            </asp:Panel>
            <asp:Panel ID="pnlSalut" runat="server" Visible="false">
                <asp:checkbox ID="chkSalut" runat="server" Text="CC Salut" />
            </asp:Panel>
            <asp:Panel ID="pnlCetak" runat="server" Visible="false">
                <asp:CheckBox ID="chkCetak" runat="server" Text="CC Cetak" />
            </asp:Panel>
            <asp:Panel ID="pnlSyrKering" runat="server" Visible="false">
                <asp:CheckBox ID="chkSyrKering" runat="server" Text="Pemeriksaan Harian Kesiapan Sarana Pengisian Ampul" />
            </asp:Panel>
            <asp:Panel ID="pnlSyrup" runat="server" Visible="false">
                <asp:CheckBox ID="chkSyrup" runat="server" Text="Pemeriksaan Harian Kesiapan Sarana Pengisian Sirup" />
            </asp:Panel>
            <asp:Panel ID="pnlKemas" runat="server" Visible="false">
                <asp:CheckBox ID="chkKemas" runat="server" Text="Pemeriksaan Kesiapan Sarana Pengemasan Tablet/Tablet Salut/Kapsul dalam strip/blister" />
            </asp:Panel>
            <asp:Panel ID="pnlCream" runat="server" Visible="false">
                <asp:CheckBox ID="chkCream" runat="server" Text="Pemeriksaan Harian Kesiapan Sarana Pengisian Cream" />
            </asp:Panel>
            <asp:Panel ID="pnlSek" runat="server" Visible="false">
                <asp:CheckBox ID="chkSek" runat="server" Text="Pemeriksaan Kesiapan Sarana Pengemasan Sekunder " />
                    (FI Packing)</asp:Panel>
            <asp:Panel ID="pnlKad" runat="server" Visible="false">
                <asp:CheckBox ID="chkKad" runat="server" Text="Pemeriksaan Kesiapan Sarana Pengemasan Penandaan No.Batch dan Kadaluarsa" />
            </asp:Panel>
        </fieldset>
        <br />
        <div style="width:575px;">
            <asp:LinkButton ID="btnSave" CssClass="LinkButton" runat="server" Text="Save" ValidationGroup="Save" />
        </div> 
    </asp:panel>
</asp:Content>

