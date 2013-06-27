
Partial Class AnnualProdReview
    Inherits System.Web.UI.Page

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnFind.Click

        Select Case Session("DeptID")
            Case "QC"
                Response.Redirect("~/QC/DataMaster/ProductReview-QC.aspx?ProdID=" & txtProdID.Text)
            Case "PRD"
                Response.Redirect("~/Produksi/DataMaster/ProductReview-Prod.aspx?ProdID=" & txtProdID.Text)
            Case "QA"
                Response.Redirect("~/QA/DataMaster/ProductReview-QA.aspx?ProdID=" & txtProdID.Text)
            Case Else
        End Select

    End Sub
End Class
