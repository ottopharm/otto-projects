
Partial Class PengkajianMutuProduk
    Inherits System.Web.UI.Page

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnFind.Click

        Select Case Mid(txtProdID.Text, 1, 3)
            Case "G00"
                Response.Redirect("~/QA/DataMaster/PengkajianMutuGranul.aspx?itemcode=" & txtProdID.Text)
            Case "OIL"
                Response.Redirect("~/QA/DataMaster/PengkajianMutuKrim.aspx?itemcode=" & txtProdID.Text)
            Case "KPS"
                Response.Redirect("~/QA/DataMaster/PengkajianMutuKapsul.aspx?itemcode=" & txtProdID.Text)
            Case "SYK"
                Response.Redirect("~/QA/DataMaster/PengkajianMutuSyk.aspx?itemcode=" & txtProdID.Text)
            Case "SYR"
                Response.Redirect("~/QA/DataMaster/PengkajianMutuSyr.aspx?itemcode=" & txtProdID.Text)
            Case "INA", "MOT"
                Response.Redirect("~/QA/DataMaster/PengkajianMutuIna.aspx?itemcode=" & txtProdID.Text)
            Case "INF"

            Case "INV"
                Response.Redirect("~/QA/DataMaster/PengkajianMutuInv.aspx?itemcode=" & txtProdID.Text)
            Case "TAB", "KPT"
                If ddlTab.SelectedValue = "s" Then
                    Response.Redirect("~/QA/DataMaster/PengkajianMutuTabSalut.aspx?itemcode=" & txtProdID.Text)
                Else
                    Response.Redirect("~/QA/DataMaster/PengkajianMutuTabNonSalut.aspx?itemcode=" & txtProdID.Text)
                End If
            Case Else
        End Select

    End Sub
End Class
