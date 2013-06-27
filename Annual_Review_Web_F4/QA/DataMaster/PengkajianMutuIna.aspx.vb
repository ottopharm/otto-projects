
Partial Class QA_DataMaster_PengkajianMutuIna
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
                GetINA()
            End If
        End If

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim structInaHdr As New PengkajianMutu.InaHdr

        With structInaHdr
            .ItemCode = txtProdID.Text
            .Batch = txtNoBatch.Text
            .BesarBatch = If(txtBesarBatch.Text = "", Nothing, txtBesarBatch.Text)
            .UoM = ddlUoM.SelectedValue
            .Sterilitas = ddlSterilitas.SelectedValue
            .pHSpek = txtpHSpek.Text
            .pHMassa = If(txtpHMassa.Text = "", Nothing, txtpHMassa.Text)
            .pHAmpul = If(txtpHAmpul.Text = "", Nothing, txtpHAmpul.Text)
            .VolumeSpek = txtVolSpek.Text
            .VolumeHasil = If(txtVolHasil.Text = "", Nothing, txtVolHasil.Text)
            .EndotoksinSpek = txtEndotoksinSpek.Text
            .EndotoksinHasil = txtEndotoksinHasil.Text
        End With

        Try
            oPengkajianMutu.SaveinaHDR(structInaHdr)
            ClearControls()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim DataInaKadar As New PengkajianMutu.InaDtl

        With DataInaKadar
            .ItemCode = txtProdID.Text
            .Batch = txtNoBatch.Text
            .Kadar = txtKadar.Text
            .KadarSpek = txtKadarSpek.Text
            .KadarMassa = txtKadarMassa.Text
            .KadarAmpul = txtKadarAmpul.Text
            .LineID = txtKadarLineID.Text
        End With

        Try
            oPengkajianMutu.SaveInaDTL(DataInaKadar)
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
        Dim lblKadarAmpul As Label = DirectCast(row.FindControl("lblKadarAmpul"), Label)

        If e.CommandName = "Select" Then
            txtKadarSpek.Text = lblKadarSpek.Text
            txtKadar.Text = lblKadar.Text
            txtKadarMassa.Text = lblKadarMassa.Text
            txtKadarAmpul.Text = lblKadarAmpul.Text
            txtKadarLineID.Text = lblLineID.Text
        End If

        btnAdd.Enabled = True
        btnHapus.Enabled = True

    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Try
            oPengkajianMutu.DeleteInaHDR(txtProdID.Text, txtNoBatch.Text)
            ClearControls()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnHapus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHapus.Click

        Try
            oPengkajianMutu.DeleteinaDTL(txtKadarLineID.Text)
            BindKadar()
            ClearKadarDetailControls()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub GetINA()

        Dim dt As New Data.DataTable

        Dim sInaAPR As String = oPengkajianMutu.GetINAFromAPR(txtProdID.Text, txtNoBatch.Text)
        Dim sItems() As String = sInaAPR.Split("|")

        dt = oPengkajianMutu.GetINA(PengkajianMutu.InaTargetTable.Header, txtProdID.Text, txtNoBatch.Text)

        If dt.Rows.Count > 0 Then
            txtBesarBatch.Text = "" & dt.Rows(0)("BesarBatch")
            ddlUoM.SelectedValue = dt.Rows(0)("UoM")
            ddlSterilitas.SelectedValue = dt.Rows(0)("Sterilitas")
            txtVolSpek.Text = "" & dt.Rows(0)("VolumeSpek")
            txtVolHasil.Text = dt.Rows(0)("VolumeHasil")
            txtpHSpek.Text = "" & dt.Rows(0)("pHSpek")
            txtpHMassa.Text = dt.Rows(0)("pHMassa")
            txtpHAmpul.Text = dt.Rows(0)("pHAmpul")
            txtEndotoksinSpek.Text = "" & dt.Rows(0)("EndotoksinSpek")
            txtEndotoksinHasil.Text = "" & dt.Rows(0)("EndotoksinHasil")

            btnDelete.Enabled = True
            btnAdd.Enabled = True

            BindKadar()

        End If

        lblTglProduksi.Text = sItems(1)
        lblED.Text = sItems(0)
        lblFilling.Text = sItems(2)
        lblJamKerja.Text = sItems(3)
        lblRendemen.Text = sItems(4)

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
        ddlSterilitas.SelectedIndex = 0
        txtVolSpek.Text = ""
        txtVolHasil.Text = ""
        txtpHSpek.Text = ""
        txtpHMassa.Text = ""
        txtpHAmpul.Text = ""
        txtEndotoksinSpek.Text = ""
        txtEndotoksinHasil.Text = ""

        lblED.Text = "."
        lblFilling.Text = "."
        lblJamKerja.Text = "."
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
        txtKadarAmpul.Text = ""
        txtKadarLineID.Text = "0"
        btnHapus.Enabled = False

    End Sub

End Class
