
Partial Class QA_DataMaster_ChangeControl
    Inherits System.Web.UI.Page

    Private oCC As New ChangeControl
    Protected PostBackStr As String


    Private Sub GetChangeControl()
        Dim dt As New Data.DataTable

        Try
            dt = oCC.GetChangeControl(txtNoCC.Text)
            If dt.Rows.Count > 0 Then
                txtProduk.Text = dt.Rows(0)("Produk")
                txtProdID.Text = "" & dt.Rows(0)("ItemCode")
                txtNoBatch.Text = "" & dt.Rows(0)("NoBatch")
                txtJenisPerubahan.Text = dt.Rows(0)("JenisPerubahan")
                ddlKategori.SelectedValue = dt.Rows(0)("KategoriPerubahan")
                txtStatus.Text = dt.Rows(0)("Status")
                txtUraian.Text = dt.Rows(0)("Uraian")
                txtAlasan.Text = dt.Rows(0)("Alasan")
                txtPengusul.Text = dt.Rows(0)("Pengusul")
                ddlDept.SelectedValue = dt.Rows(0)("Department")
                txtTglPengajuan.Text = Format(dt.Rows(0)("TglPengajuan"), "dd-MMM-yy")

                If IsDBNull(dt.Rows(0)("Disetujui")) Then
                    rbYes.Checked = False
                    rbNo.Checked = False
                Else
                    If dt.Rows(0)("Disetujui") = "S" Then
                        rbYes.Checked = True
                    Else
                        rbNo.Checked = True
                    End If
                End If

                If IsDBNull(dt.Rows(0)("Pemberitahuan")) Then
                    rbYa.Checked = False
                    rbTidak.Checked = False
                Else
                    If dt.Rows(0)("Pemberitahuan") = "Y" Then
                        rbYa.Checked = True
                    Else
                        rbTidak.Checked = True
                    End If
                End If

                btnAdd.Enabled = True
                btnDelete.Enabled = True

                txtKesimpulan.Text = "" & dt.Rows(0)("Kesimpulan")

            Else
                Dim sTemp As String = txtNoCC.Text
                ClearControls()
                txtNoCC.Text = sTemp
                txtProdID.Focus()

            End If
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
        End Try

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Disetujui, Pemberitahuan As String

        If rbYes.Checked Then
            Disetujui = "S"
        ElseIf rbNo.Checked Then
            Disetujui = "T"
        Else
            Disetujui = Nothing
        End If

        If rbYa.Checked Then
            Pemberitahuan = "Y"
        ElseIf rbTidak.Checked Then
            Pemberitahuan = "T"
        Else
            Pemberitahuan = Nothing
        End If

        Try
            If (txtNoCC.Text <> "") Then
                oCC.SaveChangeControl(txtNoCC.Text, txtProduk.Text, txtProdID.Text, txtNoBatch.Text, txtJenisPerubahan.Text, _
                    ddlKategori.SelectedValue, txtStatus.Text, txtUraian.Text, txtAlasan.Text, txtPengusul.Text, ddlDept.SelectedValue, _
                    txtTglPengajuan.Text, Disetujui, Pemberitahuan, txtKesimpulan.Text)

                ClearControls()
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub txtNoCC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoCC.TextChanged

        If txtNoCC.Text <> "" Then
            GetChangeControl()
            BindGrid()
        End If

        txtProduk.Focus()

    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If Not String.IsNullOrEmpty(txtNoCC.Text) Then
            Try
                oCC.DeleteChangeControl(txtNoCC.Text)
                ClearControls()

            Catch ex As Exception
                Throw ex
            End Try
        End If

    End Sub

    Protected Sub gvPelaksana_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvPelaksana.RowCommand
        Dim btnSelect As LinkButton = DirectCast(e.CommandSource, LinkButton)
        Dim row As GridViewRow = DirectCast(btnSelect.NamingContainer, GridViewRow)
        Dim LineID As Label = DirectCast(row.FindControl("lblLineID"), Label)
        Dim lblPelaksana As Label = DirectCast(row.FindControl("lblPelaksana"), Label)
        Dim lblTglSelesai As Label = DirectCast(row.FindControl("lblTglSelesai"), Label)
        Dim lblTindakan As Label = DirectCast(row.FindControl("lblTindakan"), Label)
        Dim lblVerifikasi As Label = DirectCast(row.FindControl("lblVerifikasi"), Label)
        Dim lblEmail As Label = DirectCast(row.FindControl("lblEmail"), Label)
        Dim isClosed As CheckBox = DirectCast(row.FindControl("chkIsClosed"), CheckBox)

        If e.CommandName = "Select" Then
            lblLineID.Text = LineID.Text
            txtPelaksana.Text = lblPelaksana.Text
            txtTglSelesai.Text = lblTglSelesai.Text
            txtTindakan.Text = lblTindakan.Text
            txtVerifikasi.Text = lblVerifikasi.Text
            txtEmail.Text = lblEmail.Text
            chkIsClosed.Checked = isClosed.Checked
            btnHapus.Enabled = True
        End If

    End Sub


    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        'oCC_Detail.Insert()
        Try
            If Not String.IsNullOrEmpty(txtPelaksana.Text) Then
                oCC.SaveChangeControlDetail(txtPelaksana.Text, txtTglSelesai.Text, txtTindakan.Text, _
                    txtVerifikasi.Text, txtEmail.Text, chkIsClosed.Checked, lblLineID.Text, txtNoCC.Text)

                ResetDetailControls()
                BindGrid()
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnHapus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHapus.Click

        Try
            If Not String.IsNullOrEmpty(txtPelaksana.Text) Then
                oCC.DeleteChangeControlDetail(lblLineID.Text)
                ResetDetailControls()
                BindGrid()
            End If

        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Private Sub ClearControls()

        txtNoCC.Text = ""
        txtProduk.Text = ""
        txtProdID.Text = ""
        txtNoBatch.Text = ""
        txtJenisPerubahan.Text = ""
        ddlKategori.SelectedValue = 1
        txtStatus.Text = ""
        txtUraian.Text = ""
        txtAlasan.Text = ""
        txtPengusul.Text = ""
        ddlDept.SelectedIndex = 0
        txtTglPengajuan.Text = ""
        rbYes.Checked = False
        rbNo.Checked = False
        rbYa.Checked = False
        rbTidak.Checked = False
        txtKesimpulan.Text = ""
        btnAdd.Enabled = False
        btnDelete.Enabled = False
        ResetDetailControls()
        gvPelaksana.DataSource = Nothing
        chkIsClosed.Checked = False
        txtNoCC.Focus()

    End Sub

    Private Sub ResetDetailControls()

        txtPelaksana.Text = ""
        txtTglSelesai.Text = ""
        txtTindakan.Text = ""
        txtVerifikasi.Text = ""
        txtEmail.Text = ""
        lblLineID.Text = "0"
        btnHapus.Enabled = False

    End Sub


    Private Sub BindGrid()

        oCC_Detail.Select()
        gvPelaksana.DataSourceID = "oCC_Detail"
        gvPelaksana.DataBind()

    End Sub

    
    Protected Sub ddlDept_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDept.DataBound

        ddlDept.SelectedIndex = 0

    End Sub

End Class
