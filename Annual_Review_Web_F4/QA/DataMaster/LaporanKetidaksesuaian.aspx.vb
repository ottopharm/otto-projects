
Partial Class QA_DataMaster_LaporanKetidaksesuaian
    Inherits System.Web.UI.Page

    Private oLK As New LaporanKetidaksesuaian
    Protected PostBackStr As String


    Private Sub GetLaporanKetidaksesuaian()
        Dim dt As New Data.DataTable

        Try
            dt = oLK.GetLaporanKetidaksesuaian(txtNoLK.Text)
            If dt.Rows.Count > 0 Then
                chkIsClosed.Checked = dt.Rows(0)("IsClosed")
                ddlJenis.SelectedValue = dt.Rows(0)("Jenis")
                txtProduk.Text = dt.Rows(0)("Produk")
                txtManufaktur.Text = dt.Rows(0)("Manufaktur")
                txtNoBatch.Text = dt.Rows(0)("NoBatch")
                ddlSumber.SelectedValue = dt.Rows(0)("Sumber")
                txtSumberLain.Text = "" & dt.Rows(0)("SumberLain")
                ddlAsalKeluhan.SelectedValue = dt.Rows(0)("AsalKeluhan")
                txtDetailAsalKeluhan.Text = "" & dt.Rows(0)("DetailAsalKeluhan")
                txtKeluhanLain.Text = "" & dt.Rows(0)("KeluhanLain")
                ddlKetidaksesuaian.SelectedValue = dt.Rows(0)("Ketidaksesuaian")
                txtKetidaksesuaianLain.Text = "" & dt.Rows(0)("KetidaksesuaianLain")
                txtTglTerjadi.Text = If(IsDBNull(dt.Rows(0)("TglTerjadi")), _
                                    String.Empty, _
                                    Format(CDate(dt.Rows(0)("TglTerjadi")), "dd-MMM-yy"))
                ddlRencana.SelectedValue = dt.Rows(0)("Rencana")
                ddlDampak.SelectedValue = dt.Rows(0)("Dampak")
                txtYesDampak.Text = "" & dt.Rows(0)("YesDampak")
                ddlJenisSediaan.SelectedValue = dt.Rows(0)("JenisSediaan")
                txtUraian.Text = dt.Rows(0)("Uraian")
                txtTindakan.Text = dt.Rows(0)("TindakanSementara")
                ddlResiko.SelectedValue = dt.Rows(0)("Resiko")
                txtPelapor.Text = dt.Rows(0)("Pelapor")
                ddlDepartemenPelapor.SelectedValue = dt.Rows(0)("DepartemenPelapor")
                txtTglPelapor.Text = If(IsDBNull(dt.Rows(0)("TglPelapor")), _
                                    String.Empty, _
                                    Format(CDate(dt.Rows(0)("TglPelapor")), "dd-MMM-yy"))
                txtInvestigasi.Text = dt.Rows(0)("Investigasi")
                ddlPenyebabPenyimpangan.SelectedValue = dt.Rows(0)("PenyebabPenyimpangan")
                txtPenyebabPenyimpanganLain.Text = "" & dt.Rows(0)("PenyebabPenyimpanganLain")

                'txtPerbaikan.Text = "" & dt.Rows(0)("Perbaikan")
                'If Not IsDBNull(dt.Rows(0)("IsClosedPerbaikan")) Then
                '    chkIsClosedPerbaikan.Checked = dt.Rows(0)("IsClosedPerbaikan")
                'End If
                'txtTglPerbaikan.Text = If(IsDBNull(dt.Rows(0)("TglPerbaikan")), _
                '                    String.Empty, _
                '                    Format(CDate(dt.Rows(0)("TglPerbaikan")), "dd-MMM-yy"))
                'txtEmailPerbaikan.Text = "" & dt.Rows(0)("EmailPerbaikan")
                'txtPenanggungJawabPerbaikan.Text = "" & dt.Rows(0)("PenanggungJawabPerbaikan")
                ''ddlDepartemenPJPerbaikan.SelectedValue = dt.Rows(0)("DepartemenPJPerbaikan")
                'If Not IsDBNull(dt.Rows(0)("DepartemenPJPerbaikan")) Then
                '    ddlDepartemenPJPerbaikan.SelectedValue = dt.Rows(0)("DepartemenPJPerbaikan")
                'End If

                txtTindakanPerbaikan.Text = "" & dt.Rows(0)("TindakanPerbaikan")
                If Not IsDBNull(dt.Rows(0)("IsClosedTPerbaikan")) Then
                    chkIsClosedTPerbaikan.Checked = dt.Rows(0)("IsClosedTPerbaikan")
                End If
                txtTglTindakanPerbaikan.Text = If(IsDBNull(dt.Rows(0)("TglTindakanPerbaikan")), _
                                    String.Empty, _
                                    Format(CDate(dt.Rows(0)("TglTindakanPerbaikan")), "dd-MMM-yy"))

                txtEmailTindakanPerbaikan.Text = "" & dt.Rows(0)("EmailTindakanPerbaikan")
                txtPenanggungJawabTindakanPerbaikan.Text = "" & dt.Rows(0)("PenanggungJawabTindakanPerbaikan")
                'ddlDepartemenPJTPerbaikan.SelectedValue = dt.Rows(0)("DepartemenPJTPerbaikan")
                If Not IsDBNull(dt.Rows(0)("DepartemenPJTPerbaikan")) Then
                    ddlDepartemenPJTPerbaikan.SelectedValue = dt.Rows(0)("DepartemenPJTPerbaikan")
                End If

                txtTindakanPencegahan.Text = "" & dt.Rows(0)("TindakanPencegahan")
                If Not IsDBNull(dt.Rows(0)("IsClosedTPencegahan")) Then
                    chkIsClosedTPencegahan.Checked = dt.Rows(0)("IsClosedTPencegahan")
                End If
                txtTglTindakanPencegahan.Text = If(IsDBNull(dt.Rows(0)("TglTindakanPencegahan")), _
                                    String.Empty, _
                                    Format(CDate(dt.Rows(0)("TglTindakanPencegahan")), "dd-MMM-yy"))

                txtEmailTindakanPencegahan.Text = "" & dt.Rows(0)("EmailTindakanPencegahan")
                txtPenanggungJawabTindakanPencegahan.Text = "" & dt.Rows(0)("PenanggungJawabTindakanPencegahan")
                'ddlDepartemenPJTPencegahan.SelectedValue = dt.Rows(0)("DepartemenPJTPencegahan")
                If Not IsDBNull(dt.Rows(0)("DepartemenPJTPencegahan")) Then
                    ddlDepartemenPJTPencegahan.SelectedValue = dt.Rows(0)("DepartemenPJTPencegahan")
                End If

                btnAddPerbaikan.Enabled = True
                btnHapusPerbaikan.Enabled = True

                txtKesimpulanPerbaikan.Text = "" & dt.Rows(0)("KesimpulanPerbaikan")
                txtVerifikasi.Text = dt.Rows(0)("Verifikasi")
                ddlKesimpulanVerifikasi.SelectedValue = dt.Rows(0)("KesimpulanVerifikasi")
                txtTglKesimpulanVerifikasi.Text = If(IsDBNull(dt.Rows(0)("TglKesimpulanVerifikasi")), _
                                    String.Empty, _
                                    Format(CDate(dt.Rows(0)("TglKesimpulanVerifikasi")), "dd-MMM-yy"))

                txtTerbitBaru.Text = "" & dt.Rows(0)("TerbitBaru")

            Else
                Dim sTemp As String = txtNoLK.Text
                ClearControls()
                txtNoLK.Text = sTemp
                txtProduk.Focus()

            End If
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
        End Try

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        'Dim Rencana, Dampak As String

        'If rbYesRencana.Checked Then
        '    Rencana = "R"
        'ElseIf rbNoRencana.Checked Then
        '    Rencana = "T"
        'Else
        '    Rencana = Nothing
        'End If

        'If rbYesDampak.Checked Then
        '    Dampak = "D"
        'ElseIf rbNoDampak.Checked Then
        '    Dampak = "T"
        'Else
        '    Dampak = Nothing
        'End If

        Try
            If (txtNoLK.Text <> "") Then
                oLK.SaveLaporanKetidaksesuaian(txtNoLK.Text, chkIsClosed.Checked, ddlJenis.SelectedValue, txtProduk.Text, txtManufaktur.Text, _
                    txtNoBatch.Text, ddlSumber.SelectedValue, txtSumberLain.Text, ddlAsalKeluhan.SelectedValue, txtDetailAsalKeluhan.Text, _
                    txtKeluhanLain.Text, ddlKetidaksesuaian.SelectedValue, txtKetidaksesuaianLain.Text, txtTglTerjadi.Text, ddlRencana.SelectedValue, _
                    ddlDampak.SelectedValue, txtYesDampak.Text, ddlJenisSediaan.SelectedValue, txtUraian.Text, txtTindakan.Text, _
                    ddlResiko.SelectedValue, txtPelapor.Text, ddlDepartemenPelapor.SelectedValue, txtTglPelapor.Text, txtInvestigasi.Text, _
                    ddlPenyebabPenyimpangan.SelectedValue, txtPenyebabPenyimpanganLain.Text, _
                    txtTindakanPerbaikan.Text, chkIsClosedTPerbaikan.Checked, txtTglTindakanPerbaikan.Text, txtEmailTindakanPerbaikan.Text, _
                    txtPenanggungJawabTindakanPerbaikan.Text, ddlDepartemenPJTPerbaikan.SelectedValue, txtTindakanPencegahan.Text, chkIsClosedTPencegahan.Checked, txtTglTindakanPencegahan.Text, txtEmailTindakanPencegahan.Text, _
                    txtPenanggungJawabTindakanPencegahan.Text, ddlDepartemenPJTPencegahan.SelectedValue, txtKesimpulanPerbaikan.Text, txtVerifikasi.Text, ddlKesimpulanVerifikasi.SelectedValue, _
                    txtTglKesimpulanVerifikasi.Text, txtTerbitBaru.Text)

                ClearControls()
            End If

        Catch ex As Exception
            Throw ex
        End Try

        'txtPerbaikan.Text, chkIsClosedPerbaikan.Checked, txtTglPerbaikan.Text, txtEmailPerbaikan.Text,txtPenanggungJawabPerbaikan.Text, ddlDepartemenPJPerbaikan.SelectedValue, 
    End Sub

    Protected Sub txtNoLK_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoLK.TextChanged

        If txtNoLK.Text <> "" Then
            GetLaporanKetidaksesuaian()
            BindGrid()
        End If

        If txtSumberLain.Text <> "" Then
            txtSumberLain.Enabled = True
        End If

        If ddlSumber.SelectedValue = 4 Then
            ddlAsalKeluhan.Enabled = True
        End If

        If ddlAsalKeluhan.SelectedValue = 4 Then
            txtKeluhanLain.Enabled = True
        End If

        If txtKeluhanLain.Text <> "" Then
            txtKeluhanLain.Enabled = True
        End If

        If txtKetidaksesuaianLain.Text <> "" Then
            txtKetidaksesuaianLain.Enabled = True
        End If

        If txtPenyebabPenyimpanganLain.Text <> "" Then
            txtPenyebabPenyimpanganLain.Enabled = True
        End If

        If ddlDampak.SelectedValue = 1 Then
            txtYesDampak.Enabled = False
        End If

        If txtYesDampak.Text <> "" Then
            txtYesDampak.Enabled = True
        End If

        If txtTglKesimpulanVerifikasi.Text <> "" Then
            txtTglKesimpulanVerifikasi.Enabled = True
        End If

        If txtTerbitBaru.Text <> "" Then
            txtTerbitBaru.Enabled = True
        End If
        'txtSumberLain.Enabled = True
        'ddlAsalKeluhan.Enabled = True
        'txtKeluhanLain.Enabled = True
        'txtKetidaksesuaianLain.Enabled = True
        'txtYesDampak.Enabled = True
        'txtTglKesimpulanVerifikasi.Enabled = True
        'txtTerbitBaru.Enabled = True

        txtProduk.Focus()

    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If Not String.IsNullOrEmpty(txtNoLK.Text) Then
            Try
                oLK.DeleteLaporanKetidaksesuaian(txtNoLK.Text)
                ClearControls()

            Catch ex As Exception
                Throw ex
            End Try
        End If

    End Sub

    Protected Sub gvDetailPerbaikan_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvDetailPerbaikan.RowCommand
        Dim btnSelect As LinkButton = DirectCast(e.CommandSource, LinkButton)
        Dim row As GridViewRow = DirectCast(btnSelect.NamingContainer, GridViewRow)
        Dim LineID As Label = DirectCast(row.FindControl("lblLineID"), Label)
        Dim lblPenanggungJawabPerbaikan As Label = DirectCast(row.FindControl("lblPenanggungJawabPerbaikan"), Label)
        Dim ddlDepartemenPJPerbaikan As DropDownList = DirectCast(row.FindControl("ddlDepartemenPJPerbaikan"), DropDownList)
        Dim lblTglPerbaikan As Label = DirectCast(row.FindControl("lblTglPerbaikan"), Label)
        Dim lblPerbaikan As Label = DirectCast(row.FindControl("lblPerbaikan"), Label)
        Dim lblEmailPerbaikan As Label = DirectCast(row.FindControl("lblEmailPerbaikan"), Label)
        Dim isClosedPerbaikan As CheckBox = DirectCast(row.FindControl("chkIsClosedPerbaikan"), CheckBox)

        If e.CommandName = "Select" Then
            lblLineID.Text = LineID.Text
            txtPenanggungJawabPerbaikan.Text = lblPenanggungJawabPerbaikan.Text
            ddlDepartemenPJPerbaikan.SelectedValue = ddlDepartemenPJPerbaikan.SelectedValue
            txtTglPerbaikan.Text = lblTglPerbaikan.Text
            txtPerbaikan.Text = lblPerbaikan.Text
            txtEmailPerbaikan.Text = lblEmailPerbaikan.Text
            chkIsClosedPerbaikan.Checked = isClosedPerbaikan.Checked
            btnHapusPerbaikan.Enabled = True
        End If

    End Sub

    Protected Sub btnAddPerbaikan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddPerbaikan.Click

        Try
            If Not String.IsNullOrEmpty(txtPenanggungJawabPerbaikan.Text) Then
                oLK.SaveLaporanKetidaksesuaianDetail(txtPenanggungJawabPerbaikan.Text, ddlDepartemenPJPerbaikan.SelectedValue, txtTglPerbaikan.Text, _
                                                     txtPerbaikan.Text, txtEmailPerbaikan.Text, chkIsClosedPerbaikan.Checked, lblLineID.Text, txtNoLK.Text)

                ResetDetailControls()
                BindGrid()
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnHapusPerbaikan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHapusPerbaikan.Click

        Try
            If Not String.IsNullOrEmpty(txtPenanggungJawabPerbaikan.Text) Then
                oLK.DeleteLaporanKetidaksesuaianDetail(lblLineID.Text)
                ResetDetailControls()
                BindGrid()
            End If

        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Private Sub ClearControls()

        txtNoLK.Text = ""
        chkIsClosed.Checked = False
        ddlJenis.SelectedValue = 0
        txtProduk.Text = ""
        txtManufaktur.Text = ""
        txtNoBatch.Text = ""
        ddlSumber.SelectedIndex = 0
        txtSumberLain.Text = ""
        txtSumberLain.Enabled = False
        ddlAsalKeluhan.SelectedIndex = 0
        ddlAsalKeluhan.Enabled = False
        txtDetailAsalKeluhan.Text = ""
        txtKeluhanLain.Text = ""
        txtKeluhanLain.Enabled = False
        ddlKetidaksesuaian.SelectedIndex = 0
        txtKetidaksesuaianLain.Text = ""
        txtKetidaksesuaianLain.Enabled = False
        txtTglTerjadi.Text = ""
        'rbYesRencana.Checked = False
        'rbNoRencana.Checked = False
        'rbYesDampak.Checked = False
        'rbNoDampak.Checked = False
        ddlRencana.SelectedIndex = 0
        ddlDampak.SelectedIndex = 0
        txtYesDampak.Text = ""
        txtYesDampak.Enabled = False
        ddlJenisSediaan.SelectedIndex = 0
        txtUraian.Text = ""
        txtTindakan.Text = ""
        ddlResiko.SelectedIndex = 0
        txtPelapor.Text = ""
        ddlDepartemenPelapor.SelectedIndex = 0
        txtTglPelapor.Text = ""
        txtInvestigasi.Text = ""
        ddlPenyebabPenyimpangan.SelectedIndex = 0
        txtPenyebabPenyimpanganLain.Text = ""
        txtPenyebabPenyimpanganLain.Enabled = False
        'txtPerbaikan.Text = ""
        'chkIsClosedPerbaikan.Checked = False
        'txtTglPerbaikan.Text = ""
        'txtEmailPerbaikan.Text = ""
        'txtPenanggungJawabPerbaikan.Text = ""
        'ddlDepartemenPJPerbaikan.SelectedIndex = 0
        txtTindakanPerbaikan.Text = ""
        chkIsClosedTPerbaikan.Checked = False
        txtTglTindakanPerbaikan.Text = ""
        txtEmailTindakanPerbaikan.Text = ""
        txtPenanggungJawabTindakanPerbaikan.Text = ""
        ddlDepartemenPJTPerbaikan.SelectedIndex = 0
        txtTindakanPencegahan.Text = ""
        chkIsClosedTPencegahan.Checked = False
        txtTglTindakanPencegahan.Text = ""
        txtEmailTindakanPencegahan.Text = ""
        txtPenanggungJawabTindakanPencegahan.Text = ""
        ddlDepartemenPJTPencegahan.SelectedIndex = 0
        txtKesimpulanPerbaikan.Text = ""
        txtVerifikasi.Text = ""
        ddlKesimpulanVerifikasi.SelectedValue = 0
        txtTglKesimpulanVerifikasi.Text = ""
        txtTglKesimpulanVerifikasi.Enabled = False
        txtTerbitBaru.Text = ""
        txtTerbitBaru.Enabled = False
        btnAddPerbaikan.Enabled = False
        btnHapusPerbaikan.Enabled = False
        ResetDetailControls()
        gvDetailPerbaikan.DataSource = Nothing
        chkIsClosedPerbaikan.Checked = False
        txtNoLK.Focus()

    End Sub

    Private Sub ResetDetailControls()

        txtPenanggungJawabPerbaikan.Text = ""
        ddlDepartemenPJPerbaikan.SelectedIndex = 0
        txtTglPerbaikan.Text = ""
        txtPerbaikan.Text = ""
        txtEmailPerbaikan.Text = ""
        lblLineID.Text = "0"
        btnHapusPerbaikan.Enabled = False

    End Sub

    Private Sub BindGrid()

        oLK_Detail.Select()
        gvDetailPerbaikan.DataSourceID = "oLK_Detail"
        gvDetailPerbaikan.DataBind()

    End Sub

    Protected Sub ddlDepartemenPelapor_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepartemenPelapor.DataBound

        ddlDepartemenPelapor.SelectedIndex = 0

    End Sub

    Protected Sub ddlSumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSumber.SelectedIndexChanged

        If ddlSumber.SelectedValue = 4 Then
            ddlAsalKeluhan.Enabled = True
        Else
            ddlAsalKeluhan.Enabled = False
        End If

        If ddlSumber.SelectedValue = 5 Then
            txtSumberLain.Enabled = True
        Else
            txtSumberLain.Enabled = False
        End If

    End Sub

    Protected Sub ddlAsalKeluhan_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAsalKeluhan.SelectedIndexChanged

        If ddlAsalKeluhan.SelectedValue = 4 Then
            txtKeluhanLain.Enabled = True
        Else
            txtKeluhanLain.Enabled = False
        End If

    End Sub

    Protected Sub ddlKetidaksesuaian_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlKetidaksesuaian.SelectedIndexChanged

        If ddlKetidaksesuaian.SelectedValue = 9 Then
            txtKetidaksesuaianLain.Enabled = True
        Else
            txtKetidaksesuaianLain.Enabled = False
        End If

    End Sub

    'Protected Sub rbYesDampak_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbYesDampak.CheckedChanged

    '    If rbYesDampak.Checked = True Then
    '        txtYesDampak.Enabled = True
    '    Else
    '        txtYesDampak.Enabled = False
    '    End If

    'End Sub

    Protected Sub ddlKesimpulanVerifikasi_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlKesimpulanVerifikasi.SelectedIndexChanged

        If ddlKesimpulanVerifikasi.SelectedValue = 1 Then
            txtTglKesimpulanVerifikasi.Enabled = True
        Else
            txtTglKesimpulanVerifikasi.Enabled = False
        End If

        If ddlKesimpulanVerifikasi.SelectedValue = 2 Then
            txtTerbitBaru.Enabled = True
        Else
            txtTerbitBaru.Enabled = False
        End If

    End Sub

    Protected Sub ddlDampak_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDampak.SelectedIndexChanged

        If ddlDampak.SelectedValue = 2 Then
            txtYesDampak.Enabled = True
        Else
            txtYesDampak.Enabled = False
        End If
    End Sub

    Protected Sub ddlPenyebabPenyimpangan_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPenyebabPenyimpangan.SelectedIndexChanged

        If ddlPenyebabPenyimpangan.SelectedValue = 8 Then
            txtPenyebabPenyimpanganLain.Enabled = True
        Else
            txtPenyebabPenyimpanganLain.Enabled = False
        End If

    End Sub

    Protected Sub ddlDepartemenPJPerbaikan_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepartemenPJPerbaikan.DataBound

        ddlDepartemenPJPerbaikan.SelectedIndex = 0

    End Sub

    Protected Sub ddlDepartemenPJTPencegahan_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepartemenPJTPencegahan.DataBound

        ddlDepartemenPJTPencegahan.SelectedIndex = 0

    End Sub

    Protected Sub ddlDepartemenPJTPerbaikan_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepartemenPJTPerbaikan.DataBound

        ddlDepartemenPJTPerbaikan.SelectedIndex = 0

    End Sub

End Class



