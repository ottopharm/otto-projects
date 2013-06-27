
Partial Class QA_DataMaster_PengkajianMutuKrim
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
                GetOil()
            End If
        End If

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim structOilHdr As New PengkajianMutu.OilHdr
        With structOilHdr
            .ItemCode = txtProdID.Text
            .Batch = txtNoBatch.Text
            .BesarBatch = If(txtBesarBatch.Text = "", Nothing, txtBesarBatch.Text)
            .UoM = ddlUoM.SelectedValue
            .MassaSpek = txtMassaSpek.Text
            .MassaHasil = txtMassaHasil.Text
            .TubeSpek = txtTubeSpek.Text
            .TubeHasil = If(txtTubeHasil.Text = "", Nothing, txtTubeHasil.Text)
            .ViskositasSpek = txtViskositasSpek.Text
            .ViskositasHasil = If(txtViskositasHasil.Text = "", Nothing, txtViskositasHasil.Text)
            .BobotSpek = txtBobotSpek.Text
            .BobotHasil = If(txtBobotHasil.Text = "", Nothing, txtBobotHasil.Text)
            .BobotMinSpek = txtBobotMinSpek.Text
            .BobotMinHasil = If(txtBobotMinHasil.Text = "", Nothing, txtBobotMinHasil.Text)
            .BobotMaxSpek = txtBobotMaxSpek.Text
            .BobotMaxHasil = If(txtBobotMaxHasil.Text = "", Nothing, txtBobotMaxHasil.Text)
        End With

        Try
            oPengkajianMutu.SaveOilHDR(structOilHdr)
            ClearControls()

        Catch ex As Exception
            Throw ex
        End Try


    End Sub

    Private Sub GetOil()

        Dim dt As New Data.DataTable

        Dim sOilAPR As String = oPengkajianMutu.GetOilFromAPR(txtProdID.Text, txtNoBatch.Text)
        Dim sItems() As String = sOilAPR.Split("|")

        dt = oPengkajianMutu.GetOil(PengkajianMutu.OilDataType.Header, txtProdID.Text, txtNoBatch.Text)

        If dt.Rows.Count > 0 Then
            txtBesarBatch.Text = "" & dt.Rows(0)("BesarBatch")
            ddlUoM.SelectedValue = dt.Rows(0)("UoM")
            txtMassaSpek.Text = "" & dt.Rows(0)("MassaSpek")
            txtMassaHasil.Text = "" & dt.Rows(0)("MassaHasil")
            txtTubeSpek.Text = "" & dt.Rows(0)("TubeSpek")
            txtTubeHasil.Text = "" & dt.Rows(0)("TubeHasil")
            txtViskositasSpek.Text = "" & dt.Rows(0)("ViskositasSpek")
            txtViskositasHasil.Text = "" & dt.Rows(0)("ViskositasHasil")
            txtBobotSpek.Text = "" & dt.Rows(0)("BobotSpek")
            txtBobotHasil.Text = "" & dt.Rows(0)("BobotHasil")
            txtBobotMinSpek.Text = "" & dt.Rows(0)("BobotMinSpek")
            txtBobotMinHasil.Text = "" & dt.Rows(0)("BobotMinHasil")
            txtBobotMaxSpek.Text = "" & dt.Rows(0)("BobotMaxSpek")
            txtBobotMaxHasil.Text = "" & dt.Rows(0)("BobotMaxHasil")

            btnDelete.Enabled = True
            btnAdd.Enabled = True
            BindKadar()
            BindPotensi()

        End If

        lblTglProduksi.Text = Format(CDate(sItems(1)), "dd-MMM-yyyy")
        lblED.Text = sItems(0)
        lblMixing.Text = sItems(2)
        lblFilling.Text = sItems(3)
        lblJamKerja.Text = sItems(4)
        lblRendemen.Text = sItems(5)

        txtBesarBatch.Focus()

    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim DataOilDtl As New PengkajianMutu.OilDtl

        With DataOilDtl
            .TargetTable = ddlDataType.SelectedValue
            .ItemCode = txtProdID.Text
            .Batch = txtNoBatch.Text
            .Spek = txtSpek.Text
            .Jenis = txtJenis.Text
            .Hasil = txtHasil.Text
            .LineID = If(ddlDataType.SelectedValue = 1, txtKadarLineID.Text, txtPotensiLineID.Text)
        End With

        Try
            oPengkajianMutu.SaveOilDTL(DataOilDtl)
            ClearDetailControls()

            If ddlDataType.SelectedValue = 1 Then
                BindKadar()
            Else
                BindPotensi()
            End If

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Protected Sub gvKadar_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvKadar.RowCommand
        Dim btnSelect As LinkButton = DirectCast(e.CommandSource, LinkButton)
        Dim row As GridViewRow = DirectCast(btnSelect.NamingContainer, GridViewRow)
        Dim lblLineID As Label = DirectCast(row.FindControl("lblLineID"), Label)
        Dim lblSpekKadar As Label = DirectCast(row.FindControl("lblSpekKadar"), Label)
        Dim lblJenisKadar As Label = DirectCast(row.FindControl("lblJenisKadar"), Label)
        Dim lblHasilKadar As Label = DirectCast(row.FindControl("lblHasilKadar"), Label)

        If e.CommandName = "Select" Then
            txtSpek.Text = lblSpekKadar.Text
            txtJenis.Text = lblJenisKadar.Text
            txtHasil.Text = lblHasilKadar.Text
            txtKadarLineID.Text = lblLineID.Text
            ddlDataType.SelectedValue = 1
        End If

        btnAdd.Enabled = True
        btnHapus.Enabled = True

    End Sub

    Protected Sub gvPotensi_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvPotensi.RowCommand
        Dim btnSelect As LinkButton = DirectCast(e.CommandSource, LinkButton)
        Dim row As GridViewRow = DirectCast(btnSelect.NamingContainer, GridViewRow)
        Dim lblLineID As Label = DirectCast(row.FindControl("lblLineID"), Label)
        Dim lblSpekPotensi As Label = DirectCast(row.FindControl("lblSpekPotensi"), Label)
        Dim lblJenisPotensi As Label = DirectCast(row.FindControl("lblJenisPotensi"), Label)
        Dim lblHasilPotensi As Label = DirectCast(row.FindControl("lblHasilPotensi"), Label)

        If e.CommandName = "Select" Then
            txtSpek.Text = lblSpekPotensi.Text
            txtJenis.Text = lblJenisPotensi.Text
            txtHasil.Text = lblHasilPotensi.Text
            txtPotensiLineID.Text = lblLineID.Text
            ddlDataType.SelectedValue = 2
        End If

        btnAdd.Enabled = True
        btnHapus.Enabled = True

    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Try
            oPengkajianMutu.DeleteOilHDR(txtProdID.Text, txtNoBatch.Text)
            ClearControls()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnHapus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHapus.Click

        Dim TargetTable As Integer = ddlDataType.SelectedValue
        Dim LineID As Integer = If(TargetTable = 1, txtKadarLineID.Text, txtPotensiLineID.Text)

        Try
            oPengkajianMutu.DeleteOilDTL(TargetTable, LineID)
            ClearDetailControls()

            If TargetTable = 1 Then
                BindKadar()
            Else
                BindPotensi()
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ClearControls()
        txtNoBatch.Text = ""
        txtBesarBatch.Text = ""
        ddlUoM.SelectedIndex = 0
        txtMassaSpek.Text = ""
        txtMassaHasil.Text = ""
        txtTubeSpek.Text = ""
        txtTubeHasil.Text = ""
        txtViskositasSpek.Text = ""
        txtViskositasHasil.Text = ""
        txtBobotSpek.Text = ""
        txtBobotHasil.Text = ""
        txtBobotMinSpek.Text = ""
        txtBobotMinHasil.Text = ""
        txtBobotMaxSpek.Text = ""
        txtBobotMaxHasil.Text = ""
        lblED.Text = "."
        lblFilling.Text = "."
        lblJamKerja.Text = "."
        lblMixing.Text = "."
        lblRendemen.Text = "."
        lblTglProduksi.Text = "."

        gvKadar.DataSourceID = ""
        gvPotensi.DataSourceID = ""

        btnDelete.Enabled = False
        btnAdd.Enabled = False

        ClearDetailControls()
        

    End Sub

    Private Sub ClearDetailControls()

        txtSpek.Text = ""
        txtJenis.Text = ""
        txtHasil.Text = ""
        txtKadarLineID.Text = "0"
        txtPotensiLineID.Text = "0"
        btnHapus.Enabled = False

    End Sub

    Private Sub BindKadar()

        oKadar.Select()
        gvKadar.DataSourceID = "oKadar"
        gvKadar.DataBind()

    End Sub

    Private Sub BindPotensi()

        oPotensi.Select()
        gvPotensi.DataSourceID = "oPotensi"
        gvPotensi.DataBind()

    End Sub

    

    
End Class
