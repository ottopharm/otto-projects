
Partial Class QA_Report_ChangeControl
    Inherits System.Web.UI.Page

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click

        Response.Redirect("~/QA/Report/RptChangeControl.aspx?" & _
                        "JenisPerubahan=" & txtJenisPerubahan.Text & "&" & _
                        "KategoriPerubahan=" & ddlKategori.SelectedValue & "&" & _
                        "BPOM=" & ddlBPOM.SelectedValue & "&" & _
                        "Eff=" & ddlEffective.SelectedValue & "&" & _
                        "FromDate=" & txtFromDate.Text & "&" & _
                        "ToDate=" & txtToDate.Text & "&" & _
                        "Dept=" & ddlDept.SelectedValue & "&" & _
                        "Status=" & ddlStatus.SelectedValue)
    End Sub

    Protected Sub ddlDept_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDept.DataBound
        Dim item As New ListItem

        item.Text = "ALL"
        item.Value = -1

        ddlDept.Items.Insert(0, item)

    End Sub

    Protected Sub ddlDept_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDept.Load

    End Sub
End Class
