
Partial Class QA_DataMaster_PengkajianMutuSyr
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
                GetSYR()
            End If
        End If

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim structSyrHdr As New PengkajianMutu.SyrHdr

        With structSyrHdr
            .ItemCode = txtProdID.Text
            .Batch = txtNoBatch.Text
            .BesarBatch = If(txtBesarBatch.Text = "", Nothing, txtBesarBatch.Text)
            .UoM = ddlUoM.SelectedValue
            .pHSpek = txtpHSpek.Text
            .pHMassa = If(txtpHMassa.Text = "", Nothing, txtpHMassa.Text)
            .pHBotol = If(txtpHBotol.Text = "", Nothing, txtpHBotol.Text)
            .BobotSpek = txtBobotMassaSpek.Text
            .BobotMassa = If(txtBobotMassaHasil.Text = "", Nothing, txtBobotMassaHasil.Text)
            .BobotBotol = If(txtBobotBotolHasil.Text = "", Nothing, txtBobotBotolHasil.Text)
            .ViskositasSpek = txtViskositsaSpek.Text
            .ViskositasMassa = If(txtViskositasMassa.Text = "", Nothing, txtViskositasMassa.Text)
            .ViskositasBotol = If(txtViskositasBotol.Text = "", Nothing, txtViskositasBotol.Text)
            .NettoVolumeSpek = txtNettoVolumeSpek.Text
            .NettoVolumeHasil = If(txtNettoVolumeHasil.Text = "", Nothing, txtNettoVolumeHasil.Text)
            .PenetralanSpek = txtPenetralanSpek.Text
            .PenetralanHasil = If(txtPenetralanHasil.Text = "", Nothing, txtPenetralanHasil.Text)
            .DefoamingSpek = txtDefoamingSpek.Text
            .DefoamingHasil = If(txtDefoamingHasil.Text = "", Nothing, txtDefoamingHasil.Text)
            .AerobSpek = txtAerobSpek.Text
            .AerobHasil = txtAerobHasil.Text
            .KhamirSpek = txtKhamirSpek.Text
            .KhamirHasil = txtKhamirHasil.Text
            .Ecoli = ddlEcoli.SelectedValue
            .Salmonelia = ddlSalmonelia.SelectedValue
            .Pseudomonas = ddlPseudomonas.SelectedValue
            .Staphylococcus = ddlStaphylococcus.Text
        End With

        Try
            oPengkajianMutu.SaveSyrHDR(structSyrHdr)
            ClearControls()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim DataSyrKadar As New PengkajianMutu.SyrupDtl

        With DataSyrKadar
            .ItemCode = txtProdID.Text
            .Batch = txtNoBatch.Text
            .Kadar = txtKadar.Text
            .KadarSpek = txtKadarSpek.Text
            .KadarMassa = txtKadarMassa.Text
            .KadarBotol = txtKadarBotol.Text
            .LineID = txtKadarLineID.Text
        End With

        Try
            oPengkajianMutu.SaveSyrDTL(DataSyrKadar)
            ClearKadarDetailControls()
            BindKadar()

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
        Dim lblKadarBotol As Label = DirectCast(row.FindControl("lblKadarBotol"), Label)

        If e.CommandName = "Select" Then
            txtKadarSpek.Text = lblKadarSpek.Text
            txtKadar.Text = lblKadar.Text
            txtKadarMassa.Text = lblKadarMassa.Text
            txtKadarBotol.Text = lblKadarBotol.Text
            txtKadarLineID.Text = lblLineID.Text
        End If

        btnAdd.Enabled = True
        btnHapus.Enabled = True

    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Try
            oPengkajianMutu.DeleteSyrHDR(txtProdID.Text, txtNoBatch.Text)
            ClearControls()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnHapus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHapus.Click

        Try
            oPengkajianMutu.DeleteSyrDTL(txtKadarLineID.Text)
            BindKadar()
            ClearKadarDetailControls()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub GetSYR()

        Dim dt As New Data.DataTable

        Dim sSyrAPR As String = oPengkajianMutu.GetSYRFromAPR(txtProdID.Text, txtNoBatch.Text)
        Dim sItems() As String = sSyrAPR.Split("|")

        dt = oPengkajianMutu.GetSYR(PengkajianMutu.SykTargetTable.Header, txtProdID.Text, txtNoBatch.Text)

        If dt.Rows.Count > 0 Then
            txtBesarBatch.Text = "" & dt.Rows(0)("BesarBatch")
            ddlUoM.SelectedValue = dt.Rows(0)("UoM")
            txtpHSpek.Text = "" & dt.Rows(0)("pHSpek")
            txtpHMassa.Text = dt.Rows(0)("pHMassa")
            txtpHBotol.Text = dt.Rows(0)("pHBotol")
            txtBobotMassaSpek.Text = "" & dt.Rows(0)("BobotSpek")
            txtBobotMassaHasil.Text = dt.Rows(0)("BobotMassa")
            txtBobotBotolHasil.Text = dt.Rows(0)("BobotBotol")
            txtViskositsaSpek.Text = "" & dt.Rows(0)("ViskositasSpek")
            txtViskositasMassa.Text = dt.Rows(0)("ViskositasMassa")
            txtViskositasBotol.Text = dt.Rows(0)("ViskositasBotol")
            txtNettoVolumeSpek.Text = "" & dt.Rows(0)("NettoVolumeSpek")
            txtNettoVolumeHasil.Text = dt.Rows(0)("NettoVolumeHasil")
            txtPenetralanSpek.Text = "" & dt.Rows(0)("PenetralanSpek")
            txtPenetralanHasil.Text = dt.Rows(0)("PenetralanHasil")
            txtDefoamingSpek.Text = "" & dt.Rows(0)("DefoamingSpek")
            txtDefoamingHasil.Text = dt.Rows(0)("DefoamingHasil")
            txtAerobSpek.Text = "" & dt.Rows(0)("AerobSpek")
            txtAerobHasil.Text = "" & dt.Rows(0)("AerobHasil")
            txtKhamirSpek.Text = "" & dt.Rows(0)("KhamirSpek")
            txtKhamirHasil.Text = "" & dt.Rows(0)("KhamirHasil")
            ddlEcoli.SelectedValue = dt.Rows(0)("Ecoli")
            ddlSalmonelia.SelectedValue = dt.Rows(0)("Salmonelia")
            ddlPseudomonas.SelectedValue = dt.Rows(0)("Pseudomonas")
            ddlStaphylococcus.SelectedValue = dt.Rows(0)("Staphylococcus")

            btnDelete.Enabled = True
            btnAdd.Enabled = True

            BindKadar()

        End If

        lblTglProduksi.Text = Format(CDate(sItems(1)), "dd-MMM-yyyy")
        lblED.Text = sItems(0)
        lblMixing.Text = sItems(2)
        lblFilling.Text = sItems(3)
        lblJamKerja.Text = sItems(4)
        lblRendemen.Text = sItems(5)

        txtBesarBatch.Focus()

    End Sub

    Private Sub BindKadar()

        oKadar.Select()
        gvKadar.DataSourceID = "oKadar"
        gvKadar.DataBind()

    End Sub

    Private Sub ClearControls()

        txtNoBatch.Text = ""
        txtBesarBatch.Text = ""
        ddlUoM.SelectedIndex = 0
        txtpHSpek.Text = ""
        txtpHMassa.Text = ""
        txtpHBotol.Text = ""
        txtBobotMassaSpek.Text = ""
        txtBobotMassaHasil.Text = ""
        txtBobotBotolHasil.Text = ""
        txtViskositsaSpek.Text = ""
        txtViskositasMassa.Text = ""
        txtViskositasBotol.Text = ""
        txtNettoVolumeSpek.Text = ""
        txtNettoVolumeHasil.Text = ""
        txtPenetralanSpek.Text = ""
        txtPenetralanHasil.Text = ""
        txtDefoamingSpek.Text = ""
        txtDefoamingHasil.Text = ""
        txtAerobSpek.Text = ""
        txtAerobHasil.Text = ""
        txtKhamirSpek.Text = ""
        txtKhamirHasil.Text = ""
        ddlEcoli.SelectedIndex = 0
        ddlSalmonelia.SelectedIndex = 0
        ddlPseudomonas.SelectedIndex = 0
        ddlStaphylococcus.SelectedIndex = 0

        lblED.Text = "."
        lblFilling.Text = "."
        lblJamKerja.Text = "."
        lblMixing.Text = "."
        lblRendemen.Text = "."
        lblTglProduksi.Text = "."

        gvKadar.DataSourceID = ""

        btnDelete.Enabled = False
        btnAdd.Enabled = False

        ClearKadarDetailControls()

    End Sub

    Private Sub ClearKadarDetailControls()

        txtKadarSpek.Text = ""
        txtKadar.Text = ""
        txtKadarMassa.Text = ""
        txtKadarBotol.Text = ""
        txtKadarLineID.Text = "0"
        btnHapus.Enabled = False

    End Sub

End Class
