
Partial Class QA_DataMaster_LPPT
    Inherits System.Web.UI.Page

    Private oLPPT As New LPPT
    Protected PostBackStr As String

    Private Sub GetDataLPPT()
        Dim dt As New Data.DataTable

        Try
            dt = oLPPT.GetLPPT(txtNoLPPT.Text)
            If dt.Rows.Count > 0 Then
                txtProses.Text = dt.Rows(0)("Produk")
                txtProdID.Text = "" & dt.Rows(0)("ItemCode")
                txtNoBatch.Text = "" & dt.Rows(0)("NoBatch")
                txtTglSimpang.Text = If(IsDBNull(dt.Rows(0)("TglSimpang")), _
                                    String.Empty, _
                                    Format(CDate(dt.Rows(0)("TglSimpang")), "dd-MMM-yy"))
                txtSimpang.Text = dt.Rows(0)("Penyimpangan")
                txtTindakan.Text = dt.Rows(0)("Tindakan")
                txtPelapor.Text = dt.Rows(0)("Pelapor")
                txtTglLapor.Text = If(IsDBNull(dt.Rows(0)("TglLapor")), _
                                    String.Empty, _
                                    Format(CDate(dt.Rows(0)("TglLapor")), "dd-MMM-yy"))
                txtTPerbaikan.Text = "" & dt.Rows(0)("TindakanPerbaikan")
                txtAkar.Text = "" & dt.Rows(0)("AkarMasalah")
                txtPerbaikan.Text = "" & dt.Rows(0)("Perbaikan")
                txtCegah.Text = "" & dt.Rows(0)("Pencegahan")
                txtKesimpulan.Text = "" & dt.Rows(0)("Kesimpulan")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
        End Try

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try

            oLPPT.SaveLPPT(txtNoLPPT.Text, txtProses.Text, txtProdID.Text, txtNoBatch.Text, txtTglSimpang.Text, _
                txtSimpang.Text, txtTindakan.Text, txtPelapor.Text, txtTglLapor.Text, txtTPerbaikan.Text, _
                txtAkar.Text, txtPerbaikan.Text, txtCegah.Text, txtKesimpulan.Text)

            ClearControls()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub txtNoLPPT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoLPPT.TextChanged

        If txtNoLPPT.Text <> "" Then
            GetDataLPPT()
        End If

        txtProses.Focus()

    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If Not String.IsNullOrEmpty(txtNoLPPT.Text) Then
            Try
                oLPPT.DeleteLPPT(txtNoLPPT.Text)
                ClearControls()

            Catch ex As Exception
                Throw ex
            End Try
        End If

    End Sub

    Private Sub ClearControls()

        txtNoLPPT.Text = String.Empty
        txtProses.Text = String.Empty
        txtProdID.Text = String.Empty
        txtNoBatch.Text = String.Empty
        txtTglSimpang.Text = String.Empty
        txtSimpang.Text = String.Empty
        txtTindakan.Text = String.Empty
        txtPelapor.Text = String.Empty
        txtTglLapor.Text = String.Empty
        txtTPerbaikan.Text = String.Empty
        txtAkar.Text = String.Empty
        txtPerbaikan.Text = String.Empty
        txtCegah.Text = String.Empty
        txtKesimpulan.Text = String.Empty

        txtNoLPPT.Focus()

    End Sub

End Class
