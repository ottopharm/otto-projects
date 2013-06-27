
Partial Class QA_Report_LaporanKetidaksesuaian
    Inherits System.Web.UI.Page

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click

        Response.Redirect("~/QA/Report/RptLaporanKetidaksesuaian.aspx?" & _
                        "DepartemenPelapor=" & ddlDepartemenPelapor.SelectedValue & "&" & _
                        "Ketidaksesuaian=" & ddlKetidaksesuaian.SelectedValue & "&" & _
                        "KetidaksesuaianLain=" & txtKetidaksesuaianLain.Text & "&" & _
                        "Rencana=" & ddlRencana.SelectedValue & "&" & _
                        "Resiko=" & ddlResiko.SelectedValue & "&" & _
                        "PenyebabPenyimpangan=" & ddlPenyebabPenyimpangan.SelectedValue & "&" & _
                        "PenyebabPenyimpanganLain=" & txtPenyebabPenyimpanganLain.Text & "&" & _
                        "IsClosed=" & ddlIsClosed.SelectedValue & "&" & _
                        "FromDate=" & txtFromDate.Text & "&" & _
                        "ToDate=" & txtToDate.Text)

    End Sub
   
    Protected Sub ddlDepartemenPelapor_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepartemenPelapor.DataBound
        Dim item As New ListItem

        item.Text = "ALL"
        item.Value = -1

        ddlDepartemenPelapor.Items.Insert(0, item)

    End Sub

    Protected Sub ddlDepartemenPelapor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepartemenPelapor.Load

    End Sub

    Protected Sub ddlKetidaksesuaian_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlKetidaksesuaian.SelectedIndexChanged

        If ddlKetidaksesuaian.SelectedValue = 9 Then
            txtKetidaksesuaianLain.Enabled = True
        Else
            txtKetidaksesuaianLain.Enabled = False
        End If

    End Sub

    Protected Sub ddlPenyebabPenyimpangan_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPenyebabPenyimpangan.SelectedIndexChanged

        If ddlPenyebabPenyimpangan.SelectedValue = 8 Then
            txtPenyebabPenyimpanganLain.Enabled = True
        Else
            txtPenyebabPenyimpanganLain.Enabled = False
        End If

    End Sub
End Class
