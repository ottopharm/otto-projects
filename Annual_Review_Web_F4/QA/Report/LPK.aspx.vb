
Partial Class QA_Report_LPK
    Inherits System.Web.UI.Page

    Protected Sub ddlCatEvaluasi_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCatEvaluasi.DataBound
        ddlCatEvaluasi.Items.Insert(0, "ALL")

    End Sub

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Dim Cat As Byte

        If ddlCatEvaluasi.SelectedIndex = 0 Then
            Cat = 0
        Else
            Cat = ddlCatEvaluasi.SelectedValue
        End If

        Response.Redirect("~/QA/Report/RptLPK.aspx?" & _
            "CatEval=" & Cat & "&" & _
            "FromDate=" & txtFromDate.Text & "&" & _
            "ToDate=" & txtToDate.Text)

    End Sub
End Class
