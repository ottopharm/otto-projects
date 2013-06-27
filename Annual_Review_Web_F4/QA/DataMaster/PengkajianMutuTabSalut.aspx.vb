
Partial Class QA_DataMaster_PengkajianMutuTabSalut
    Inherits System.Web.UI.Page

    Dim oPengkajianMutu As New PengkajianMutu
    Dim oProduct As New ProductReview
    Protected PostBackStr As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PostBackStr = Page.ClientScript.GetPostBackEventReference(Me, "PostBackFromClient")

        If Not IsPostBack Then
            txtProdID.Text = Request.QueryString("itemcode")
            lblProdName.Text = oProduct.GetItemNameByCode(txtProdID.Text)
            txtNoBatch.Focus()
        Else
            Dim EventArg As String = Request("__EVENTARGUMENT")
            If EventArg = "PostBackFromClient" Then
                GetTAB()
            End If
        End If

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim structTabHdr As New PengkajianMutu.TabHdr

        With structTabHdr
            .ItemCode = txtProdID.Text
            .Batch = txtNoBatch.Text
            .BesarBatch = If(txtBesarBatch.Text = "", Nothing, txtBesarBatch.Text)
            .UoM = ddlUoM.SelectedValue
            .BobotAvgSpek = txtBobotAvgSpek.Text
            .BobotAvgHasil = If(txtBobotAvgHasil.Text = "", Nothing, txtBobotAvgHasil.Text)
            .SimpangMaxSpek = txtSimpangMaxSpek.Text
            .SimpangMaxHasil = If(txtSimpangMaxHasil.Text = "", Nothing, txtSimpangMaxHasil.Text)
            .SimpangMinSpek = txtSimpangMinSpek.Text
            .SimpangMinHasil = If(txtSimpangMinHasil.Text = "", Nothing, txtSimpangMinHasil.Text)
            .TebalSpek = txtTebalspek.Text
            .TebalMin = If(txtTebalMin.Text = "", Nothing, txtTebalMin.Text)
            .TebalMax = If(txtTebalMax.Text = "", Nothing, txtTebalMax.Text)
            .KekerasanSpek = txtKekerasanSpek.Text
            .KekerasanMin = If(txtKekerasanMin.Text = "", Nothing, txtKekerasanMin.Text)
            .KekerasanMax = If(txtKekerasanMax.Text = "", Nothing, txtKekerasanMax.Text)
            .KekerasanAvg = If(txtKekerasanAvg.Text = "", Nothing, txtKekerasanAvg.Text)
            .KeausanSpek = txtKeausanSpek.Text
            .KeausanMin = If(txtKeausanMin.Text = "", Nothing, txtKeausanMin.Text)
            .KeausanMax = If(txtKeausanMax.Text = "", Nothing, txtKeausanMax.Text)
            .MoistureSpek = txtMoistureSpek.Text
            .MoistureHasil = If(txtMoistureHasil.Text = "", Nothing, txtMoistureHasil.Text)
            .WaktuHancurSpek = txtWaktuHancurSpek.Text
            .WaktuHancurHasil = If(txtWaktuHancurHasil.Text = "", Nothing, txtWaktuHancurHasil.Text)
            .TssBobotAvgSpek = txtTssBobotAvgSpek.Text
            .TssBobotAvgHasil = If(txtTssBobotAvgHasil.Text = "", Nothing, txtTssBobotAvgHasil.Text)
            .TssSimpangMaxSpek = txtTssSimpangMaxSpek.Text
            .TssSimpangMaxHasil = If(txtTssSimpangMaxHasil.Text = "", Nothing, txtTssSimpangMaxHasil.Text)
            .TssSimpangMinSpek = txtTssSimpangMinSpek.Text
            .TssSimpangMinHasil = If(txtTssSimpangMinHasil.Text = "", Nothing, txtTssSimpangMinHasil.Text)
            .TssTebalSpek = txtTssTebalSpek.Text
            .TssTebalMin = If(txtTssTebalMin.Text = "", Nothing, txtTssTebalMin.Text)
            .TssTebalMax = If(txtTssTebalMax.Text = "", Nothing, txtTssTebalMax.Text)
            .TssKekerasanSpek = txtTssKekerasanSpek.Text
            .TssKekerasanMin = If(txtTssKekerasanMin.Text = "", Nothing, txtTssKekerasanMin.Text)
            .TssKekerasanMax = If(txtTssKekerasanMax.Text = "", Nothing, txtTssKekerasanMax.Text)
            .TssKeausanSpek = txtTssKeausanSpek.Text
            .TssKeausanMin = If(txtTssKeausanMin.Text = "", Nothing, txtTssKeausanMin.Text)
            .TssKeausanMax = If(txtTssKeausanMax.Text = "", Nothing, txtTssKeausanMax.Text)
            .TssWaktuHancurSpek = txtTssWaktuHancurSpek.Text
            .TssWaktuHancurHasil = If(txtTssWaktuHancurHasil.Text = "", Nothing, txtTssWaktuHancurHasil.Text)
            .AerobSpek = txtAerobSpek.Text
            .AerobHasil = txtAerobHasil.Text
            .KhamirSpek = txtKhamirSpek.Text
            .KhamirHasil = txtKhamirHasil.Text
            .Ecoli = ddlEcoli.SelectedValue
            .Salmonelia = ddlSalmonelia.SelectedValue
            .Pseudomonas = ddlPseudomonas.SelectedValue
            .Staphylococcus = ddlStaphylococcus.Text
            .UnitDosisSpek = txtUnitDosisSpek.Text
            .UnitDosisHasil = If(txtUnitDosisHasil.Text = "", Nothing, txtUnitDosisHasil.Text)
        End With

        Try
            oPengkajianMutu.SaveTabSalutHDR(structTabHdr)
            ClearControls()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnAddKadar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddKadar.Click

        Dim DataTabKadar As New PengkajianMutu.TabKadar

        With DataTabKadar
            .ItemCode = txtProdID.Text
            .Batch = txtNoBatch.Text
            .Kadar = txtKadar.Text
            .KadarSpek = txtKadarSpek.Text
            .Massa = txtKadarMassa.Text
            .Kapsul = txtKadarKapsul.Text
            .LineID = txtKadarLineID.Text
        End With

        Try
            oPengkajianMutu.SaveTabKadar(DataTabKadar)
            ClearKadarDetailControls()
            BindKadar()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Protected Sub btnAddKandungan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddKandungan.Click

        Dim DataTabKeseragaman As New PengkajianMutu.TabKeseragaman

        With DataTabKeseragaman
            .ItemCode = txtProdID.Text
            .Batch = txtNoBatch.Text
            .Keseragaman = txtKeseragamanKandungan.Text
            .MinMaxSpek = txtMinMaxSpek.Text
            .MinHasil = txtMinHasil.Text
            .MaxHasil = txtMaxHasil.Text
            .RSDSpek = txtRSDSpek.Text
            .RSDHasil = txtRSDHasil.Text
            .AVSpek = txtAVSpek.Text
            .AVHasil = txtAVHasil.Text
            .LineID = txtKandunganLineID.Text
        End With

        Try
            oPengkajianMutu.SaveTabKeseragaman(PengkajianMutu.JenisKeseragaman.Kandungan, _
                                               DataTabKeseragaman)
            ClearKandunganDetailControls()
            BindKandungan()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Protected Sub btnAddBobot_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddBobot.Click

        Dim DataTabKeseragaman As New PengkajianMutu.TabKeseragaman

        With DataTabKeseragaman
            .ItemCode = txtProdID.Text
            .Batch = txtNoBatch.Text
            .Keseragaman = txtKeseragamanBobot.Text
            .MinMaxSpek = txtBobotMinMaxSpek.Text
            .MinHasil = txtBobotMinHasil.Text
            .MaxHasil = txtBobotMaxHasil.Text
            .RSDSpek = txtBobotRSDSpek.Text
            .RSDHasil = txtBobotRSDHasil.Text
            .AVSpek = txtBobotAVSpek.Text
            .AVHasil = txtBobotAVHasil.Text
            .LineID = txtBobotLineID.Text
        End With

        Try
            oPengkajianMutu.SaveTabKeseragaman(PengkajianMutu.JenisKeseragaman.Bobot, _
                                               DataTabKeseragaman)
            ClearBobotDetailControls()
            BindBobot()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Protected Sub btnAddDisolusi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDisolusi.Click

        Dim DataTabDisolusi As New PengkajianMutu.TabDisolusi

        With DataTabDisolusi
            .ItemCode = txtProdID.Text
            .Batch = txtNoBatch.Text
            .Disolusi = txtDisolusi.Text
            .DisolusiSpek = txtDisolusiSpek.Text
            .MinHasil = txtDisolusiMinHasil.Text
            .MaxHasil = txtDisolusiMaxHasil.Text
            .AvgHasil = txtDisolusiAvgHasil.Text
            .LineID = txtDisolusiLineID.Text
        End With

        Try
            oPengkajianMutu.SaveTabDisolusi(PengkajianMutu.JenisDisolusi.Tablet, _
                                            DataTabDisolusi)
            ClearDisolusiDetailControls()
            BindDisolusi()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Protected Sub btnAddTssDisolusi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddTssDisolusi.Click

        Dim DataTabDisolusi As New PengkajianMutu.TabDisolusi

        With DataTabDisolusi
            .ItemCode = txtProdID.Text
            .Batch = txtNoBatch.Text
            .Disolusi = txtTssDisolusi.Text
            .DisolusiSpek = txtTssDisolusiSpek.Text
            .MinHasil = txtTssMinHasil.Text
            .MaxHasil = txtTssMaxHasil.Text
            .AvgHasil = txtTssAvgHasil.Text
            .LineID = txtTssDisolusiLineID.Text
        End With

        Try
            oPengkajianMutu.SaveTabDisolusi(PengkajianMutu.JenisDisolusi.TSS, _
                                            DataTabDisolusi)
            ClearTssDisolusiDetailControls()
            BindTssDisolusi()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Protected Sub gvKadar_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvKadar.RowCommand

        Dim btnSelect As LinkButton = DirectCast(e.CommandSource, LinkButton)
        Dim row As GridViewRow = DirectCast(btnSelect.NamingContainer, GridViewRow)
        Dim lblLineID As Label = DirectCast(row.FindControl("lblLineID"), Label)
        Dim lblKadarSpek As Label = DirectCast(row.FindControl("lblSpekKadar"), Label)
        Dim lblKadar As Label = DirectCast(row.FindControl("lblKadar"), Label)
        Dim lblKadarMassa As Label = DirectCast(row.FindControl("lblKadarMassa"), Label)
        Dim lblKadarKapsul As Label = DirectCast(row.FindControl("lblKadarKapsul"), Label)

        If e.CommandName = "Select" Then
            txtKadarSpek.Text = lblKadarSpek.Text
            txtKadar.Text = lblKadar.Text
            txtKadarMassa.Text = lblKadarMassa.Text
            txtKadarKapsul.Text = lblKadarKapsul.Text
            txtKadarLineID.Text = lblLineID.Text
        End If

        btnAddKadar.Enabled = True
        btnHapusKadar.Enabled = True

    End Sub

    Protected Sub gvKandungan_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvKandungan.RowCommand

        Dim btnSelect As LinkButton = DirectCast(e.CommandSource, LinkButton)
        Dim row As GridViewRow = DirectCast(btnSelect.NamingContainer, GridViewRow)
        Dim lblLineID As Label = DirectCast(row.FindControl("lblLineID"), Label)
        Dim lblKandungan As Label = DirectCast(row.FindControl("lblKandungan"), Label)
        Dim lblMinMaxSpek As Label = DirectCast(row.FindControl("lblMinMaxSpek"), Label)
        Dim lblMinHasil As Label = DirectCast(row.FindControl("lblMinHasil"), Label)
        Dim lblMaxHasil As Label = DirectCast(row.FindControl("lblMaxHasil"), Label)
        Dim lblRSDSpek As Label = DirectCast(row.FindControl("lblRSDSpek"), Label)
        Dim lblRSDHasil As Label = DirectCast(row.FindControl("lblRSDHasil"), Label)
        Dim lblAVSpek As Label = DirectCast(row.FindControl("lblAVSpek"), Label)
        Dim lblAVHasil As Label = DirectCast(row.FindControl("lblAVHasil"), Label)

        If e.CommandName = "Select" Then
            txtKeseragamanKandungan.Text = lblKandungan.Text
            txtMinMaxSpek.Text = lblMinMaxSpek.Text
            txtMinHasil.Text = lblMinHasil.Text
            txtMaxHasil.Text = lblMaxHasil.Text
            txtRSDSpek.Text = lblRSDSpek.Text
            txtRSDHasil.Text = lblRSDHasil.Text
            txtAVSpek.Text = lblAVSpek.Text
            txtAVHasil.Text = lblAVHasil.Text
            txtKandunganLineID.Text = lblLineID.Text
        End If

        btnAddKandungan.Enabled = True
        btnHapusKandungan.Enabled = True

    End Sub

    Protected Sub gvBobot_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvBobot.RowCommand

        Dim btnSelect As LinkButton = DirectCast(e.CommandSource, LinkButton)
        Dim row As GridViewRow = DirectCast(btnSelect.NamingContainer, GridViewRow)
        Dim lblLineID As Label = DirectCast(row.FindControl("lblLineID"), Label)
        Dim lblBobot As Label = DirectCast(row.FindControl("lblBobot"), Label)
        Dim lblMinMaxSpek As Label = DirectCast(row.FindControl("lblMinMaxSpek"), Label)
        Dim lblMinHasil As Label = DirectCast(row.FindControl("lblMinHasil"), Label)
        Dim lblMaxHasil As Label = DirectCast(row.FindControl("lblMaxHasil"), Label)
        Dim lblRSDSpek As Label = DirectCast(row.FindControl("lblRSDSpek"), Label)
        Dim lblRSDHasil As Label = DirectCast(row.FindControl("lblRSDHasil"), Label)
        Dim lblAVSpek As Label = DirectCast(row.FindControl("lblAVSpek"), Label)
        Dim lblAVHasil As Label = DirectCast(row.FindControl("lblAVHasil"), Label)

        If e.CommandName = "Select" Then
            txtKeseragamanBobot.Text = lblBobot.Text
            txtBobotMinMaxSpek.Text = lblMinMaxSpek.Text
            txtBobotMinHasil.Text = lblMinHasil.Text
            txtBobotMaxHasil.Text = lblMaxHasil.Text
            txtBobotRSDSpek.Text = lblRSDSpek.Text
            txtBobotRSDHasil.Text = lblRSDHasil.Text
            txtBobotAVSpek.Text = lblAVSpek.Text
            txtBobotAVHasil.Text = lblAVHasil.Text
            txtBobotLineID.Text = lblLineID.Text
        End If

        btnAddBobot.Enabled = True
        btnHapusBobot.Enabled = True

    End Sub

    Protected Sub gvDisolusi_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvDisolusi.RowCommand

        Dim btnSelect As LinkButton = DirectCast(e.CommandSource, LinkButton)
        Dim row As GridViewRow = DirectCast(btnSelect.NamingContainer, GridViewRow)
        Dim lblLineID As Label = DirectCast(row.FindControl("lblLineID"), Label)
        Dim lblDisolusi As Label = DirectCast(row.FindControl("lblDisolusi"), Label)
        Dim lblSpek As Label = DirectCast(row.FindControl("lblSpek"), Label)
        Dim lblMinHasil As Label = DirectCast(row.FindControl("lblMinHasil"), Label)
        Dim lblMaxHasil As Label = DirectCast(row.FindControl("lblMaxHasil"), Label)
        Dim lblAvgHasil As Label = DirectCast(row.FindControl("lblAvgHasil"), Label)

        If e.CommandName = "Select" Then
            txtDisolusi.Text = lblDisolusi.Text
            txtDisolusiSpek.Text = lblSpek.Text
            txtDisolusiMinHasil.Text = lblMinHasil.Text
            txtDisolusiMaxHasil.Text = lblMaxHasil.Text
            txtDisolusiAvgHasil.Text = lblAvgHasil.Text
            txtDisolusiLineID.Text = lblLineID.Text
        End If

        btnAddDisolusi.Enabled = True
        btnHapusDisolusi.Enabled = True

    End Sub

    Protected Sub gvTssDisolusi_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvTssDisolusi.RowCommand

        Dim btnSelect As LinkButton = DirectCast(e.CommandSource, LinkButton)
        Dim row As GridViewRow = DirectCast(btnSelect.NamingContainer, GridViewRow)
        Dim lblLineID As Label = DirectCast(row.FindControl("lblLineID"), Label)
        Dim lblDisolusi As Label = DirectCast(row.FindControl("lblDisolusi"), Label)
        Dim lblSpek As Label = DirectCast(row.FindControl("lblSpek"), Label)
        Dim lblMinHasil As Label = DirectCast(row.FindControl("lblMinHasil"), Label)
        Dim lblMaxHasil As Label = DirectCast(row.FindControl("lblMaxHasil"), Label)
        Dim lblAvgHasil As Label = DirectCast(row.FindControl("lblAvgHasil"), Label)

        If e.CommandName = "Select" Then
            txtTssDisolusi.Text = lblDisolusi.Text
            txtTssDisolusiSpek.Text = lblSpek.Text
            txtTssMinHasil.Text = lblMinHasil.Text
            txtTssMaxHasil.Text = lblMaxHasil.Text
            txtTssAvgHasil.Text = lblAvgHasil.Text
            txtTssDisolusiLineID.Text = lblLineID.Text
        End If

        btnAddTssDisolusi.Enabled = True
        btnHapusTssDisolusi.Enabled = True

    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Try
            oPengkajianMutu.DeleteInaHDR(txtProdID.Text, txtNoBatch.Text)
            ClearControls()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnHapus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        btnHapusKadar.Click, btnHapusBobot.Click, btnHapusKandungan.Click, _
        btnHapusDisolusi.Click, btnHapusTssDisolusi.Click

        Try
            Dim btnHapusDtl As LinkButton = DirectCast(sender, LinkButton)
            Select Case btnHapusDtl.ID
                Case "btnHapusKadar"
                    oPengkajianMutu.DeleteTabKadar(txtKadarLineID.Text)
                    BindKadar()
                    ClearKadarDetailControls()
                Case "btnHapusBobot"
                    oPengkajianMutu.DeleteTabKeseragaman(PengkajianMutu.JenisKeseragaman.Bobot, _
                        txtBobotLineID.Text)
                    BindBobot()
                    ClearBobotDetailControls()
                Case "btnHapusKandungan"
                    oPengkajianMutu.DeleteTabKeseragaman(PengkajianMutu.JenisKeseragaman.Kandungan, _
                        txtKandunganLineID.Text)
                    BindKandungan()
                    ClearKandunganDetailControls()
                Case "btnHapusDisolusi"
                    oPengkajianMutu.DeleteTabDisolusi(PengkajianMutu.JenisDisolusi.Tablet, _
                        txtDisolusiLineID.Text)
                    BindDisolusi()
                    ClearDisolusiDetailControls()
                Case "btnHapusTssDisolusi"
                    oPengkajianMutu.DeleteTabDisolusi(PengkajianMutu.JenisDisolusi.TSS, _
                        txtTssDisolusiLineID.Text)
                    BindTssDisolusi()
                    ClearTssDisolusiDetailControls()
            End Select

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub GetTAB()

        Dim dt As New Data.DataTable

        Dim sTabAPR As String = oPengkajianMutu.GetTABFromAPR(txtProdID.Text, txtNoBatch.Text)
        Dim sItems() As String = sTabAPR.Split("|")

        dt = oPengkajianMutu.GetTAB(PengkajianMutu.TabTargetTable.Header, txtProdID.Text, txtNoBatch.Text)

        If dt.Rows.Count > 0 Then
            txtBesarBatch.Text = "" & dt.Rows(0)("BesarBatch")
            ddlUoM.SelectedValue = dt.Rows(0)("UoM")
            txtBobotAvgSpek.Text = "" & dt.Rows(0)("BobotAvgSpek")
            txtBobotAvgHasil.Text = dt.Rows(0)("BobotAvgHasil")
            txtSimpangMaxSpek.Text = "" & dt.Rows(0)("SimpangMaxSpek")
            txtSimpangMaxHasil.Text = dt.Rows(0)("SimpangMaxHasil")
            txtSimpangMinSpek.Text = "" & dt.Rows(0)("SimpangMinSpek")
            txtSimpangMinHasil.Text = dt.Rows(0)("SimpangMinHasil")
            txtTebalspek.Text = "" & dt.Rows(0)("TebalSpek")
            txtTebalMin.Text = dt.Rows(0)("TebalMin")
            txtTebalMax.Text = dt.Rows(0)("TebalMax")
            txtKekerasanSpek.Text = "" & dt.Rows(0)("KekerasanSpek")
            txtKekerasanMin.Text = dt.Rows(0)("KekerasanMin")
            txtKekerasanMax.Text = dt.Rows(0)("KekerasanMax")
            txtKekerasanAvg.Text = dt.Rows(0)("KekerasanAvg")
            txtKeausanSpek.Text = "" & dt.Rows(0)("KeausanSpek")
            txtKeausanMin.Text = dt.Rows(0)("KeausanMin")
            txtKeausanMax.Text = dt.Rows(0)("KeausanMax")
            txtMoistureSpek.Text = "" & dt.Rows(0)("MoistureSpek")
            txtMoistureHasil.Text = dt.Rows(0)("MoistureHasil")
            txtWaktuHancurSpek.Text = "" & dt.Rows(0)("WaktuHancurSpek")
            txtWaktuHancurHasil.Text = dt.Rows(0)("WaktuHancurHasil")

            txtTssBobotAvgSpek.Text = "" & dt.Rows(0)("TssBobotAvgSpek")
            txtTssBobotAvgHasil.Text = dt.Rows(0)("TssBobotAvgHasil")
            txtTssSimpangMaxSpek.Text = "" & dt.Rows(0)("TssSimpangMaxSpek")
            txtTssSimpangMaxHasil.Text = dt.Rows(0)("TssSimpangMaxHasil")
            txtTssSimpangMinSpek.Text = "" & dt.Rows(0)("TssSimpangMinSpek")
            txtTssSimpangMinHasil.Text = dt.Rows(0)("TssSimpangMinHasil")
            txtTssTebalSpek.Text = "" & dt.Rows(0)("TssTebalSpek")
            txtTssTebalMin.Text = dt.Rows(0)("TssTebalMin")
            txtTssTebalMax.Text = dt.Rows(0)("TssTebalMax")
            txtTssKekerasanSpek.Text = "" & dt.Rows(0)("TssKekerasanSpek")
            txtTssKekerasanMin.Text = dt.Rows(0)("TssKekerasanMin")
            txtTssKekerasanMax.Text = dt.Rows(0)("TssKekerasanMax")
            txtTssKeausanSpek.Text = "" & dt.Rows(0)("TssKeausanSpek")
            txtTssKeausanMin.Text = dt.Rows(0)("TssKeausanMin")
            txtKeausanMax.Text = dt.Rows(0)("KeausanMax")
            txtTssWaktuHancurSpek.Text = "" & dt.Rows(0)("TssWaktuHancurSpek")
            txtTssWaktuHancurHasil.Text = dt.Rows(0)("TssWaktuHancurHasil")
            txtAerobSpek.Text = "" & dt.Rows(0)("AerobSpek")
            txtAerobHasil.Text = "" & dt.Rows(0)("AerobHasil")
            txtKhamirSpek.Text = "" & dt.Rows(0)("KhamirSpek")
            txtKhamirHasil.Text = "" & dt.Rows(0)("KhamirHasil")
            ddlEcoli.SelectedValue = "" & dt.Rows(0)("Ecoli")
            ddlSalmonelia.SelectedValue = "" & dt.Rows(0)("Salmonelia")
            ddlPseudomonas.SelectedValue = "" & dt.Rows(0)("Pseudomonas")
            ddlStaphylococcus.SelectedValue = "" & dt.Rows(0)("Staphylococcus")
            txtUnitDosisSpek.Text = "" & dt.Rows(0)("UnitDosisSpek")
            txtUnitDosisHasil.Text = "" & dt.Rows(0)("UnitDosisHasil")

            btnDelete.Enabled = True
            btnAddKadar.Enabled = True
            btnAddKandungan.Enabled = True
            btnAddBobot.Enabled = True
            btnAddDisolusi.Enabled = True
            btnAddTssDisolusi.Enabled = True

            BindKadar()
            BindKandungan()
            BindBobot()
            BindDisolusi()
            BindTssDisolusi()

        End If

        lblTglProduksi.Text = sItems(1)
        lblED.Text = sItems(0)
        lblMixing.Text = sItems(2)
        lblCetak.Text = sItems(3)
        lblLot1.Text = sItems(4)
        lblLot2.Text = sItems(5)
        lblLot3.Text = sItems(6)
        lblLot4.Text = sItems(7)
        lblPGA.Text = sItems(8)
        lblJamKerja.Text = sItems(9)
        lblRendemen.Text = sItems(10)

        txtBesarBatch.Focus()

    End Sub

    Private Sub BindKadar()

        oKadar.Select()
        gvKadar.DataSourceID = "oKadar"
        gvKadar.DataBind()

    End Sub

    Private Sub BindKandungan()

        oKandungan.Select()
        gvKandungan.DataSourceID = "oKandungan"
        gvKandungan.DataBind()

    End Sub

    Private Sub BindBobot()

        oBobot.Select()
        gvBobot.DataSourceID = "oBobot"
        gvBobot.DataBind()

    End Sub

    Private Sub BindDisolusi()

        oDisolusiTablet.Select()
        gvDisolusi.DataSourceID = "oDisolusiTablet"
        gvDisolusi.DataBind()

    End Sub

    Private Sub BindTssDisolusi()

        oTssDisolusi.Select()
        gvTssDisolusi.DataSourceID = "oTssDisolusi"
        gvTssDisolusi.DataBind()

    End Sub

    Private Sub ClearControls()

        txtNoBatch.Text = ""
        txtBesarBatch.Text = ""
        ddlUoM.SelectedIndex = 0
        txtBobotAvgSpek.Text = ""
        txtBobotAvgHasil.Text = ""
        txtSimpangMaxSpek.Text = ""
        txtSimpangMaxHasil.Text = ""
        txtSimpangMinSpek.Text = ""
        txtSimpangMinHasil.Text = ""
        txtTebalspek.Text = ""
        txtTebalMin.Text = ""
        txtTebalMax.Text = ""
        txtKekerasanSpek.Text = ""
        txtKekerasanMin.Text = ""
        txtKekerasanMax.Text = ""
        txtKekerasanAvg.Text = ""
        txtKeausanSpek.Text = ""
        txtKeausanMin.Text = ""
        txtKeausanMax.Text = ""
        txtMoistureSpek.Text = ""
        txtMoistureHasil.Text = ""
        txtWaktuHancurSpek.Text = ""
        txtWaktuHancurHasil.Text = ""
        txtTssBobotAvgSpek.Text = ""
        txtTssBobotAvgHasil.Text = ""
        txtTssSimpangMaxSpek.Text = ""
        txtTssSimpangMaxHasil.Text = ""
        txtTssSimpangMinSpek.Text = ""
        txtTssSimpangMinHasil.Text = ""
        txtTssTebalSpek.Text = ""
        txtTssTebalMin.Text = ""
        txtTssTebalMax.Text = ""
        txtTssKekerasanSpek.Text = ""
        txtTssKekerasanMin.Text = ""
        txtTssKekerasanMax.Text = ""
        txtTssKeausanSpek.Text = ""
        txtTssKeausanMin.Text = ""
        txtTssKeausanMax.Text = ""
        txtTssWaktuHancurSpek.Text = ""
        txtTssWaktuHancurHasil.Text = ""

        txtAerobSpek.Text = ""
        txtAerobHasil.Text = ""
        txtKhamirSpek.Text = ""
        txtKhamirHasil.Text = ""
        ddlEcoli.SelectedIndex = 0
        ddlSalmonelia.SelectedIndex = 0
        ddlPseudomonas.SelectedIndex = 0
        ddlStaphylococcus.SelectedIndex = 0
        txtUnitDosisSpek.Text = ""
        txtUnitDosisHasil.Text = ""

        lblTglProduksi.Text = "."
        lblED.Text = "."
        lblMixing.Text = "."
        lblCetak.Text = "."
        lblLot1.Text = "."
        lblLot2.Text = "."
        lblLot3.Text = "."
        lblLot4.Text = "."
        lblPGA.Text = "."
        lblJamKerja.Text = "."
        lblRendemen.Text = "."

        gvKadar.DataSourceID = ""
        gvDisolusi.DataSourceID = ""
        gvKandungan.DataSourceID = ""
        gvBobot.DataSourceID = ""
        gvTssDisolusi.DataSourceID = ""

        btnDelete.Enabled = False
        btnAddKadar.Enabled = False
        btnAddKandungan.Enabled = False
        btnAddBobot.Enabled = False
        btnAddDisolusi.Enabled = False
        btnAddTssDisolusi.Enabled = False

        ClearKadarDetailControls()
        ClearKandunganDetailControls()
        ClearBobotDetailControls()
        ClearDisolusiDetailControls()
        ClearTssDisolusiDetailControls()

    End Sub

    Private Sub ClearKadarDetailControls()

        txtKadarSpek.Text = ""
        txtKadar.Text = ""
        txtKadarMassa.Text = ""
        txtKadarKapsul.Text = ""
        txtKadarLineID.Text = "0"
        btnHapusKadar.Enabled = False

    End Sub

    Private Sub ClearKandunganDetailControls()

        txtKeseragamanKandungan.Text = ""
        txtMinMaxSpek.Text = ""
        txtMinHasil.Text = ""
        txtMaxHasil.Text = ""
        txtRSDSpek.Text = ""
        txtRSDHasil.Text = ""
        txtAVSpek.Text = ""
        txtAVHasil.Text = ""
        txtKandunganLineID.Text = "0"
        btnHapusKandungan.Enabled = False

    End Sub

    Private Sub ClearBobotDetailControls()

        txtKeseragamanBobot.Text = ""
        txtBobotMinMaxSpek.Text = ""
        txtBobotMinHasil.Text = ""
        txtBobotMaxHasil.Text = ""
        txtBobotRSDSpek.Text = ""
        txtBobotRSDHasil.Text = ""
        txtBobotAVSpek.Text = ""
        txtBobotAVHasil.Text = ""
        txtBobotLineID.Text = "0"
        btnHapusBobot.Enabled = False

    End Sub

    Private Sub ClearDisolusiDetailControls()

        txtDisolusiSpek.Text = ""
        txtDisolusi.Text = ""
        txtDisolusiMinHasil.Text = ""
        txtDisolusiMaxHasil.Text = ""
        txtDisolusiAvgHasil.Text = ""
        txtDisolusiLineID.Text = "0"
        btnHapusDisolusi.Enabled = False

    End Sub

    Private Sub ClearTssDisolusiDetailControls()

        txtTssDisolusiSpek.Text = ""
        txtTssDisolusi.Text = ""
        txtTssMinHasil.Text = ""
        txtTssMaxHasil.Text = ""
        txtTssAvgHasil.Text = ""
        txtTssDisolusiLineID.Text = "0"
        btnHapusTssDisolusi.Enabled = False

    End Sub

   
    
End Class
