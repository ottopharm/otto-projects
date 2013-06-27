
Partial Class QA_DataMaster_PengkajianMutuSyk
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
                GetSYK()
            End If
        End If

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim structSykHdr As New PengkajianMutu.SykHdr

        With structSykHdr
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
            .BobotIsiSpek = txtBobotIsiSpek.Text
            .BobotIsiHasil = If(txtBobotIsiHasil.Text = "", Nothing, txtBobotIsiHasil.Text)
            .SimpangMinSpek = txtSimpangSpekMin.Text
            .SimpangMinHasil = If(txtSimpangMinHasil.Text = "", Nothing, txtSimpangMinHasil.Text)
            .SimpangMaxSpek = txtSimpangSpekMax.Text
            .SimpangMaxHasil = If(txtSimpangMaxHasil.Text = "", Nothing, txtSimpangMaxHasil.Text)
            .AirSpek = txtAirSpek.Text
            .AirMassa = If(txtAirMassa.Text = "", Nothing, txtAirMassa.Text)
            .AirBotol = If(txtAirBotol.Text = "", Nothing, txtAirBotol.Text)
            .AerobSpek = txtAerobSpek.Text
            .AerobHasil = txtAerobHasil.Text
            .KhamirSpek = txtKhamirSpek.Text
            .KhamirHasil = txtKhamirHasil.Text
            .Ecoli = ddlEcoli.SelectedValue
            .Salmonelia = ddlSalmonelia.SelectedValue
            .Pseudomonas = ddlPseudomonas.SelectedValue
            .Staphylococcus = ddlStaphylococcus.Text
            .MoistureSpek = txtMoisSpek.Text
            .MoistureMassa = If(txtMoisMassa.Text = "", Nothing, txtMoisMassa.Text)
            .MoistureSachet = If(txtMoisSachet.Text = "", Nothing, txtMoisSachet.Text)
        End With

        Try
            oPengkajianMutu.SaveSykHDR(structSykHdr)
            ClearControls()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim DataSykKadar As New PengkajianMutu.SyrupDtl

        With DataSykKadar
            .ItemCode = txtProdID.Text
            .Batch = txtNoBatch.Text
            .Kadar = txtKadar.Text
            .KadarSpek = txtKadarSpek.Text
            .KadarMassa = txtKadarMassa.Text
            .KadarBotol = txtKadarBotol.Text
            .LineID = txtKadarLineID.Text
        End With

        Try
            oPengkajianMutu.SaveSykDTL(DataSykKadar)
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
            oPengkajianMutu.DeleteSykHDR(txtProdID.Text, txtNoBatch.Text)
            ClearControls()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnHapus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHapus.Click

        Try
            oPengkajianMutu.DeleteSykDTL(txtKadarLineID.Text)
            BindKadar()
            ClearKadarDetailControls()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub GetSYK()

        Dim dt As New Data.DataTable

        Dim sSyrAPR As String = oPengkajianMutu.GetSYKFromAPR(txtProdID.Text, txtNoBatch.Text)
        Dim sItems() As String = sSyrAPR.Split("|")

        dt = oPengkajianMutu.GetSYK(PengkajianMutu.SykTargetTable.Header, txtProdID.Text, txtNoBatch.Text)

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
            txtBobotIsiSpek.Text = "" & dt.Rows(0)("BobotIsiSpek")
            txtBobotIsiHasil.Text = dt.Rows(0)("BobotIsiHasil")
            txtSimpangSpekMin.Text = "" & dt.Rows(0)("SimpangMinSpek")
            txtSimpangMinHasil.Text = dt.Rows(0)("SimpangMinHasil")
            txtSimpangSpekMax.Text = "" & dt.Rows(0)("SimpangMaxSpek")
            txtSimpangMaxHasil.Text = dt.Rows(0)("SimpangMaxHasil")
            txtAirSpek.Text = "" & dt.Rows(0)("AirSpek")
            txtAirMassa.Text = dt.Rows(0)("AirMassa")
            txtAirBotol.Text = dt.Rows(0)("AirBotol")
            txtAerobSpek.Text = "" & dt.Rows(0)("AerobSpek")
            txtAerobHasil.Text = "" & dt.Rows(0)("AerobHasil")
            txtKhamirSpek.Text = "" & dt.Rows(0)("KhamirSpek")
            txtKhamirHasil.Text = "" & dt.Rows(0)("KhamirHasil")
            ddlEcoli.SelectedValue = If(IsDBNull(dt.Rows(0)("Ecoli")), "-", dt.Rows(0)("Ecoli"))
            ddlSalmonelia.SelectedValue = If(IsDBNull(dt.Rows(0)("Salmonelia")), "-", dt.Rows(0)("Salmonelia"))
            ddlPseudomonas.SelectedValue = If(IsDBNull(dt.Rows(0)("Pseudomonas")), "-", dt.Rows(0)("Pseudomonas"))
            ddlStaphylococcus.SelectedValue = If(IsDBNull(dt.Rows(0)("Staphylococcus")), "-", dt.Rows(0)("Staphylococcus"))
            txtMoisSpek.Text = "" & dt.Rows(0)("MoistureSpek")
            txtMoisMassa.Text = If(IsDBNull(dt.Rows(0)("MoistureMassa")), "", dt.Rows(0)("MoistureMassa"))
            txtMoisSachet.Text = If(IsDBNull(dt.Rows(0)("MoistureSachet")), "", dt.Rows(0)("MoistureSachet"))
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
        txtBobotIsiSpek.Text = ""
        txtBobotIsiHasil.Text = ""
        txtSimpangSpekMin.Text = ""
        txtSimpangMinHasil.Text = ""
        txtSimpangSpekMax.Text = ""
        txtSimpangMaxHasil.Text = ""
        txtAirSpek.Text = ""
        txtAirMassa.Text = ""
        txtAirBotol.Text = ""
        txtAerobSpek.Text = ""
        txtAerobHasil.Text = ""
        txtKhamirSpek.Text = ""
        txtKhamirHasil.Text = ""
        ddlEcoli.SelectedIndex = 0
        ddlSalmonelia.SelectedIndex = 0
        ddlPseudomonas.SelectedIndex = 0
        ddlStaphylococcus.SelectedIndex = 0
        txtMoisSpek.Text = ""
        txtMoisMassa.Text = ""
        txtMoisSachet.Text = ""

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
