
Partial Class QA_DataMaster_PengkajianMutuKapsul
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
                GetKPS()
            End If
        End If

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim structKpsHdr As New PengkajianMutu.KpsHdr
        With structKpsHdr
            .ItemCode = txtProdID.Text
            .Batch = txtNoBatch.Text
            .BesarBatch = If(txtBesarBatch.Text = "", Nothing, txtBesarBatch.Text)
            .UoM = ddlUoM.SelectedValue
            .VariasiMaxSpek = txtVariasiMaxSpek.Text
            .VariasiMaxHasil = If(txtVariasiMaxHasil.Text = "", Nothing, txtVariasiMaxHasil.Text)
            .VariasiMinSpek = txtVariasiMinSpek.Text
            .VariasiMinHasil = If(txtVariasiMinHasil.Text = "", Nothing, txtVariasiMinHasil.Text)
            .BobotCangkangSpek = txtCangkangSpek.Text
            .BobotCangkangHasil = If(txtCangkangHasil.Text = "", Nothing, txtCangkangHasil.Text)
            .BobotKapsulSpek = txtKapsulSpek.Text
            .BobotKapsulHasil = If(txtKapsulHasil.Text = "", Nothing, txtKapsulHasil.Text)
            .PenyimpanganMinSpek = txtPenyimpanganMinSpek.Text
            .PenyimpanganMinHasil = If(txtPenyimpanganMinHasil.Text = "", Nothing, txtPenyimpanganMinHasil.Text)
            .PenyimpanganMaxSpek = txtPenyimpanganMaxSpek.Text
            .PenyimpanganMaxHasil = If(txtPenyimpanganMaxHasil.Text = "", Nothing, txtPenyimpanganMaxHasil.Text)
            .WaktuHancurSpek = txtWaktuHancurSpek.Text
            .WaktuHancurHasil = If(txtWaktuHancurHasil.Text = "", Nothing, txtWaktuHancurHasil.Text)
            .KadarAirSpek = txtKadarAirSpek.Text
            .KadarAirMassaHasil = If(txtKadarMassaHasil.Text = "", Nothing, txtKadarMassaHasil.Text)
            .KadarAirKapsulHasil = If(txtKadarKapsulHasil.Text = "", Nothing, txtKadarKapsulHasil.Text)
            .KandunganMinHasil = If(txtKandunganMinHasil.Text = "", Nothing, txtKandunganMinHasil.Text)
            .KandunganMaxHasil = If(txtKandunganMaxHasil.Text = "", Nothing, txtKandunganMaxHasil.Text)
            .KandunganRSDSpek = txtKandunganRSDSpek.Text
            .KandunganRSDHasil = If(txtKandunganRSDHasil.Text = "", Nothing, txtKandunganRSDHasil.Text)
            .KandunganAVSpek = txtKandunganAVSpek.Text
            .KandunganAVHasil = If(txtKandunganAVHasil.Text = "", Nothing, txtKandunganAVHasil.Text)
        End With

        Try
            oPengkajianMutu.SaveKpsHDR(structKpsHdr)
            ClearControls()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnKadarAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKadarAdd.Click

        Dim DataKpsKadar As New PengkajianMutu.KpsKadar

        With DataKpsKadar
            .ItemCode = txtProdID.Text
            .Batch = txtNoBatch.Text
            .KadarSpek = txtSpek.Text
            .KadarJenis = txtJenisKadar.Text
            .KadarMassa = txtMassa.Text
            .KadarKapsul = txtKapsul.Text
            .LineID = txtKadarLineID.Text
        End With

        Try
            oPengkajianMutu.SaveKpsKadar(DataKpsKadar)
            ClearKadarDetailControls()

            BindKadar()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Protected Sub btnDisolusiAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisolusiAdd.Click

        Dim DataKpsDisolusi As New PengkajianMutu.KpsDisolusi

        With DataKpsDisolusi
            .ItemCode = txtProdID.Text
            .Batch = txtNoBatch.Text
            .DisolusiSpek = txtDisolusi.Text
            .DisolusiJenis = txtJenisDisolusi.Text
            .DisolusiMin = txtDisolusiMin.Text
            .DisolusiMax = txtDisolusiMax.Text
            .DisolusiAvg = txtDisolusiAvg.Text
            .LineID = txtDisolusiLineID.Text
        End With

        Try
            oPengkajianMutu.SaveKpsDisolusi(DataKpsDisolusi)
            ClearDisolusiDetailControls()

            BindDisolusi()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Protected Sub gvKadar_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvKadar.RowCommand

        Dim btnSelect As LinkButton = DirectCast(e.CommandSource, LinkButton)
        Dim row As GridViewRow = DirectCast(btnSelect.NamingContainer, GridViewRow)
        Dim lblLineID As Label = DirectCast(row.FindControl("lblLineID"), Label)
        Dim lblKadarSpek As Label = DirectCast(row.FindControl("lblSpekKadar"), Label)
        Dim lblKadarJenis As Label = DirectCast(row.FindControl("lblJenisKadar"), Label)
        Dim lblKadarMassa As Label = DirectCast(row.FindControl("lblKadarMassa"), Label)
        Dim lblKadarKapsul As Label = DirectCast(row.FindControl("lblKadarKapsul"), Label)

        If e.CommandName = "Select" Then
            txtSpek.Text = lblKadarSpek.Text
            txtJenisKadar.Text = lblKadarJenis.Text
            txtMassa.Text = lblKadarMassa.Text
            txtKapsul.Text = lblKadarKapsul.Text
            txtKadarLineID.Text = lblLineID.Text
        End If

        btnKadarAdd.Enabled = True
        btnKadarHapus.Enabled = True

    End Sub

    Protected Sub gvDisolusi_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvDisolusi.RowCommand

        Dim btnSelect As LinkButton = DirectCast(e.CommandSource, LinkButton)
        Dim row As GridViewRow = DirectCast(btnSelect.NamingContainer, GridViewRow)
        Dim lblLineID As Label = DirectCast(row.FindControl("lblLineID"), Label)
        Dim lblDisolusiSpek As Label = DirectCast(row.FindControl("lblDisolusiSpek"), Label)
        Dim lblDisolusiJenis As Label = DirectCast(row.FindControl("lblDisolusiJenis"), Label)
        Dim lblDisolusiMin As Label = DirectCast(row.FindControl("lblDisolusiMin"), Label)
        Dim lblDisolusiMax As Label = DirectCast(row.FindControl("lblDisolusiMax"), Label)
        Dim lblDisolusiAvg As Label = DirectCast(row.FindControl("lblDisolusiAvg"), Label)

        If e.CommandName = "Select" Then
            txtDisolusi.Text = lblDisolusiSpek.Text
            txtJenisDisolusi.Text = lblDisolusiJenis.Text
            txtDisolusiMin.Text = lblDisolusiMin.Text
            txtDisolusiMax.Text = lblDisolusiMax.Text
            txtDisolusiAvg.Text = lblDisolusiAvg.Text
            txtDisolusiLineID.Text = lblLineID.Text
        End If

        btnDisolusiAdd.Enabled = True
        btnDisolusiHapus.Enabled = True

    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Try
            oPengkajianMutu.DeleteKpsHDR(txtProdID.Text, txtNoBatch.Text)
            ClearControls()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnKadarHapus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKadarHapus.Click

        Try
            oPengkajianMutu.DeleteKpsDTL(txtKadarLineID.Text, PengkajianMutu.KpsTargetTable.Kadar)
            BindKadar()
            ClearKadarDetailControls()

        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Protected Sub btnDisolusiHapus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisolusiHapus.Click

        Try
            oPengkajianMutu.DeleteKpsDTL(txtDisolusiLineID.Text, PengkajianMutu.KpsTargetTable.Disolusi)
            BindDisolusi()
            ClearDisolusiDetailControls()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub GetKPS()

        Dim dt As New Data.DataTable

        Dim sKpsAPR As String = oPengkajianMutu.GetKPSFromAPR(txtProdID.Text, txtNoBatch.Text)
        Dim sItems() As String = sKpsAPR.Split("|")

        dt = oPengkajianMutu.GetKps(PengkajianMutu.KpsTargetTable.Header, txtProdID.Text, txtNoBatch.Text)

        If dt.Rows.Count > 0 Then
            txtBesarBatch.Text = "" & dt.Rows(0)("BesarBatch")
            ddlUoM.SelectedValue = dt.Rows(0)("UoM")
            txtVariasiMaxSpek.Text = "" & dt.Rows(0)("VariasiMaxSpek")
            txtVariasiMaxHasil.Text = dt.Rows(0)("VariasiMaxHasil")
            txtVariasiMinSpek.Text = "" & dt.Rows(0)("VariasiMinSpek")
            txtVariasiMinHasil.Text = dt.Rows(0)("VariasiMinHasil")
            txtCangkangSpek.Text = "" & dt.Rows(0)("BobotCangkangSpek")
            txtCangkangHasil.Text = dt.Rows(0)("BobotCangkangHasil")
            txtKapsulSpek.Text = "" & dt.Rows(0)("BobotKapsulSpek")
            txtKapsulHasil.Text = dt.Rows(0)("BobotKapsulHasil")
            txtPenyimpanganMinSpek.Text = "" & dt.Rows(0)("PenyimpanganMinSpek")
            txtPenyimpanganMinHasil.Text = dt.Rows(0)("PenyimpanganMinHasil")
            txtPenyimpanganMaxSpek.Text = "" & dt.Rows(0)("PenyimpanganMaxSpek")
            txtPenyimpanganMaxHasil.Text = dt.Rows(0)("PenyimpanganMaxHasil")
            txtWaktuHancurSpek.Text = "" & dt.Rows(0)("WaktuHancurSpek")
            txtWaktuHancurHasil.Text = dt.Rows(0)("WaktuHancurHasil")
            txtKadarAirSpek.Text = "" & dt.Rows(0)("KadarAirSpek")
            txtKadarMassaHasil.Text = dt.Rows(0)("KadarAirMassaHasil")
            txtKadarKapsulHasil.Text = dt.Rows(0)("KadarAirKapsulHasil")
            txtKandunganMinHasil.Text = dt.Rows(0)("KandunganMinHasil")
            txtKandunganMaxHasil.Text = dt.Rows(0)("KandunganMaxHasil")
            txtKandunganRSDSpek.Text = "" & dt.Rows(0)("KandunganRSDSpek")
            txtKandunganRSDHasil.Text = dt.Rows(0)("KandunganRSDHasil")
            txtKandunganAVSpek.Text = "" & dt.Rows(0)("KandunganAVSpek")
            txtKandunganAVHasil.Text = dt.Rows(0)("KandunganAVHasil")

            btnDelete.Enabled = True
            btnKadarAdd.Enabled = True
            btnDisolusiAdd.Enabled = True
            BindKadar()
            BindDisolusi()

        End If

        lblTglProduksi.Text = Format(CDate(sItems(1)), "dd-MMM-yyyy")
        lblED.Text = sItems(0)
        lblMixing.Text = sItems(2)
        lblFilling.Text = sItems(3)
        lblJamKerja.Text = sItems(4)
        lblRendemen.Text = sItems(5)

        txtBesarBatch.Focus()

    End Sub

    'Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click

    '    Dim DataOilDtl As New PengkajianMutu.OilDtl

    '    With DataOilDtl
    '        .TargetTable = ddlDataType.SelectedValue
    '        .ItemCode = txtProdID.Text
    '        .Batch = txtNoBatch.Text
    '        .Spek = txtSpek.Text
    '        .Jenis = txtJenis.Text
    '        .Hasil = txtHasil.Text
    '        .LineID = If(ddlDataType.SelectedValue = 1, txtKadarLineID.Text, txtPotensiLineID.Text)
    '    End With

    '    Try
    '        oPengkajianMutu.SaveOilDTL(DataOilDtl)
    '        ClearDetailControls()

    '        If ddlDataType.SelectedValue = 1 Then
    '            BindKadar()
    '        Else
    '            BindPotensi()
    '        End If

    '    Catch ex As Exception
    '        Throw ex

    '    End Try

    'End Sub

    'Protected Sub gvKadar_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvKadar.RowCommand
    '    Dim btnSelect As LinkButton = DirectCast(e.CommandSource, LinkButton)
    '    Dim row As GridViewRow = DirectCast(btnSelect.NamingContainer, GridViewRow)
    '    Dim lblLineID As Label = DirectCast(row.FindControl("lblLineID"), Label)
    '    Dim lblSpekKadar As Label = DirectCast(row.FindControl("lblSpekKadar"), Label)
    '    Dim lblJenisKadar As Label = DirectCast(row.FindControl("lblJenisKadar"), Label)
    '    Dim lblHasilKadar As Label = DirectCast(row.FindControl("lblHasilKadar"), Label)

    '    If e.CommandName = "Select" Then
    '        txtSpek.Text = lblSpekKadar.Text
    '        txtJenis.Text = lblJenisKadar.Text
    '        txtHasil.Text = lblHasilKadar.Text
    '        txtKadarLineID.Text = lblLineID.Text
    '        ddlDataType.SelectedValue = 1
    '    End If

    '    btnAdd.Enabled = True
    '    btnHapus.Enabled = True

    'End Sub

    'Protected Sub gvPotensi_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvPotensi.RowCommand
    '    Dim btnSelect As LinkButton = DirectCast(e.CommandSource, LinkButton)
    '    Dim row As GridViewRow = DirectCast(btnSelect.NamingContainer, GridViewRow)
    '    Dim lblLineID As Label = DirectCast(row.FindControl("lblLineID"), Label)
    '    Dim lblSpekPotensi As Label = DirectCast(row.FindControl("lblSpekPotensi"), Label)
    '    Dim lblJenisPotensi As Label = DirectCast(row.FindControl("lblJenisPotensi"), Label)
    '    Dim lblHasilPotensi As Label = DirectCast(row.FindControl("lblHasilPotensi"), Label)

    '    If e.CommandName = "Select" Then
    '        txtSpek.Text = lblSpekPotensi.Text
    '        txtJenis.Text = lblJenisPotensi.Text
    '        txtHasil.Text = lblHasilPotensi.Text
    '        txtPotensiLineID.Text = lblLineID.Text
    '        ddlDataType.SelectedValue = 2
    '    End If

    '    btnAdd.Enabled = True
    '    btnHapus.Enabled = True

    'End Sub

    'Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

    '    Try
    '        oPengkajianMutu.DeleteOilHDR(txtProdID.Text, txtNoBatch.Text)
    '        ClearControls()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub

    'Protected Sub btnHapus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHapus.Click

    '    Dim TargetTable As Integer = ddlDataType.SelectedValue
    '    Dim LineID As Integer = If(TargetTable = 1, txtKadarLineID.Text, txtPotensiLineID.Text)

    '    Try
    '        oPengkajianMutu.DeleteOilDTL(TargetTable, LineID)
    '        ClearDetailControls()

    '        If TargetTable = 1 Then
    '            BindKadar()
    '        Else
    '            BindPotensi()
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub

    Private Sub ClearControls()
        txtNoBatch.Text = ""
        txtBesarBatch.Text = ""
        ddlUoM.SelectedIndex = 0
        txtVariasiMaxSpek.Text = ""
        txtVariasiMaxHasil.Text = ""
        txtVariasiMinSpek.Text = ""
        txtVariasiMinHasil.Text = ""
        txtCangkangSpek.Text = ""
        txtCangkangHasil.Text = ""
        txtKapsulSpek.Text = ""
        txtKapsulHasil.Text = ""
        txtPenyimpanganMinSpek.Text = ""
        txtPenyimpanganMinHasil.Text = ""
        txtPenyimpanganMaxSpek.Text = ""
        txtPenyimpanganMaxHasil.Text = ""
        txtWaktuHancurSpek.Text = ""
        txtWaktuHancurHasil.Text = ""
        txtKadarAirSpek.Text = ""
        txtKadarMassaHasil.Text = ""
        txtKadarKapsulHasil.Text = ""
        txtKandunganMinHasil.Text = ""
        txtKandunganMaxHasil.Text = ""
        txtKandunganRSDSpek.Text = ""
        txtKandunganRSDHasil.Text = ""
        txtKandunganAVSpek.Text = ""
        txtKandunganAVHasil.Text = ""

        lblED.Text = "."
        lblFilling.Text = "."
        lblJamKerja.Text = "."
        lblMixing.Text = "."
        lblRendemen.Text = "."
        lblTglProduksi.Text = "."

        gvKadar.DataSourceID = ""
        gvDisolusi.DataSourceID = ""

        btnDelete.Enabled = False
        btnKadarAdd.Enabled = False
        btnDisolusiAdd.Enabled = False

        ClearKadarDetailControls()


    End Sub

    Private Sub ClearKadarDetailControls()

        txtSpek.Text = ""
        txtJenisKadar.Text = ""
        txtMassa.Text = ""
        txtKapsul.Text = ""
        txtKadarLineID.Text = "0"
        btnKadarHapus.Enabled = False

    End Sub

    Private Sub ClearDisolusiDetailControls()

        txtDisolusi.Text = ""
        txtJenisDisolusi.Text = ""
        txtDisolusiMin.Text = ""
        txtDisolusiMax.Text = ""
        txtDisolusiAvg.Text = ""
        txtDisolusiLineID.Text = "0"
        btnDisolusiHapus.Enabled = False

    End Sub

    Private Sub BindKadar()

        oKadar.Select()
        gvKadar.DataSourceID = "oKadar"
        gvKadar.DataBind()

    End Sub

    Private Sub BindDisolusi()

        oDisolusi.Select()
        gvDisolusi.DataSourceID = "oDisolusi"
        gvDisolusi.DataBind()

    End Sub




   
    
    
    
   
    
 
End Class
