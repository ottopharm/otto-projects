
Partial Class PengkajianMutu
    Inherits System.Web.UI.Page

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnFind.Click

        Dim ItemCode As String
        If txtProdID.Text.Length > 3 Then
            ItemCode = txtProdID.Text
        Else
            ItemCode = "ALL"
        End If

        Select Case Mid(txtProdID.Text, 1, 3)
            Case "G00"            
                Response.Redirect("~/QA/Report/RptPengkajianGranul.aspx?itemcode=" & ItemCode & _
                    "&fromdate=" & txtFromDate.Text & _
                    "&todate=" & txtToDate.Text)
            Case "OIL"
                Response.Redirect("~/QA/Report/RptPengkajianOil.aspx?itemcode=" & ItemCode & _
                    "&fromdate=" & txtFromDate.Text & _
                    "&todate=" & txtToDate.Text)
            Case "KPS"
                Response.Redirect("~/QA/Report/RptPengkajianKPS.aspx?itemcode=" & ItemCode & _
                    "&fromdate=" & txtFromDate.Text & _
                    "&todate=" & txtToDate.Text)
            Case "SYK"
                Response.Redirect("~/QA/Report/RptPengkajianSYK.aspx?itemcode=" & ItemCode & _
                    "&fromdate=" & txtFromDate.Text & _
                    "&todate=" & txtToDate.Text)
            Case "SYR"
                Response.Redirect("~/QA/Report/RptPengkajianSYR.aspx?itemcode=" & ItemCode & _
                    "&fromdate=" & txtFromDate.Text & _
                    "&todate=" & txtToDate.Text)
            Case "INA", "INF"
                Response.Redirect("~/QA/Report/RptPengkajianINA.aspx?itemcode=" & ItemCode & _
                    "&fromdate=" & txtFromDate.Text & _
                    "&todate=" & txtToDate.Text)
                'Case "INF"

            Case "INV"
                Response.Redirect("~/QA/Report/RptPengkajianINV.aspx?itemcode=" & ItemCode & _
                    "&fromdate=" & txtFromDate.Text & _
                    "&todate=" & txtToDate.Text)
            Case "TAB", "KPT"
                If ddlTab.SelectedValue = "s" Then
                    Response.Redirect("~/QA/Report/RptPengkajianTABSalut.aspx?itemcode=" & ItemCode & _
                        "&fromdate=" & txtFromDate.Text & _
                        "&todate=" & txtToDate.Text)
                Else
                    Response.Redirect("~/QA/Report/RptPengkajianTABNonSalut.aspx?itemcode=" & ItemCode & _
                        "&fromdate=" & txtFromDate.Text & _
                        "&todate=" & txtToDate.Text)
                End If
            Case Else
        End Select

    End Sub
End Class
