
Partial Class QA_Report_LaporanKeluhan
    Inherits System.Web.UI.Page

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click

        Response.Redirect("~/QA/Report/RptLaporanKeluhan.aspx?" & _
                          "Manufaktur=" & txtManufaktur.Text & "&" & _
                          "Resiko=" & ddlResiko.SelectedValue & "&" & _
                          "Investigasi=" & txtInvestigasi.Text & "&" & _
                          "IsClosed=" & ddlIsClosed.SelectedValue & "&" & _
                          "FromDate=" & txtFromDate.Text & "&" & _
                          "ToDate=" & txtToDate.Text)
    End Sub
End Class
