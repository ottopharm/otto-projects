Partial Class QA_Report_AnnualProductReview
    Inherits System.Web.UI.Page

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click

        Response.Redirect("~/QA/Report/RptProdReview.aspx?" & _
                        "ItemCode=" & txtItemCode.Text & "&" & _
                        "Batch=" & txtNoBatch.Text & "&" & _
                        "FromDate=" & txtFromDate.Text & "&" & _
                        "ToDate=" & txtToDate.Text)
    End Sub
End Class
