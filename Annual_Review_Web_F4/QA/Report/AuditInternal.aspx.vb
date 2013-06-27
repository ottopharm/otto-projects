
Partial Class QA_Report_AuditInternal
    Inherits System.Web.UI.Page

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click

        Response.Redirect("~/QA/Report/RptAuditInternal.aspx?" & _
                          "Resiko=" & ddlResiko.SelectedValue & "&" & _
                          "IsClosed=" & ddlIsClosed.SelectedValue)
    End Sub

End Class
