
Partial Class Logistik_Report_LPK
    Inherits System.Web.UI.Page

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click

        Response.Redirect("~/LaporanLPK/RptLPK.aspx?" & _
                        "NoLPK=" & txtNoLPK.Text & "&")
    End Sub

End Class
