Partial Class QA_Report_LPPT

    Inherits System.Web.UI.Page

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click

        Response.Redirect("~/QA/Report/RptLPPT.aspx?" & _
                        "Produk=" & txtProduk.Text & "&" & _
                        "Eff=" & ddlEffective.SelectedValue & "&" & _
                        "FromDate=" & txtFromDate.Text & "&" & _
                        "ToDate=" & txtToDate.Text)
    End Sub
End Class
