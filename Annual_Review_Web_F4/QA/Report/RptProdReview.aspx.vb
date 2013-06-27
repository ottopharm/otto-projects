Imports Microsoft.Reporting.WebForms

Partial Class QA_Report_RptProdReview
    Inherits System.Web.UI.Page

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        Dim oProdReview As New ProductReview

        If Not IsPostBack Then
            Dim ItemCode As String = If(Request.QueryString("ItemCode") = "", "ALL", Request.QueryString("ItemCode"))
            Dim ItemName As String = If(Request.QueryString("ItemCode") = "", "", oProdReview.GetItemNameByCode(ItemCode))
            Dim Batch As String = If(Request.QueryString("Batch") = "", "ALL", Request.QueryString("Batch"))
            Dim FromDate As Date = CDate(Request.QueryString("FromDate"))
            Dim ToDate As Date = CDate(Request.QueryString("ToDate"))

            Dim ds As New dsOttoTableAdapters.AnnualProdReviewTableAdapter
            Dim dt As New Data.DataTable
            Dim lsParam As New List(Of ReportParameter)
            Dim dsRpt As ReportDataSource

            rptProdReview.Reset()

            lsParam.Add(New ReportParameter("ItemCode", ItemCode))
            lsParam.Add(New ReportParameter("ItemName", ItemName))
            lsParam.Add(New ReportParameter("Batch", Batch))
            lsParam.Add(New ReportParameter("FromDate", FromDate))
            lsParam.Add(New ReportParameter("ToDate", ToDate))

            Try
                rptProdReview.LocalReport.ReportPath = "Report/AnnualPR.rdlc"

                dt = ds.GetProdReview(ItemCode, Batch, FromDate, ToDate)
                dsRpt = New ReportDataSource("dsOtto_AnnualProdReview", dt)

                rptProdReview.LocalReport.DataSources.Clear()
                rptProdReview.LocalReport.DataSources.Add(dsRpt)
                rptProdReview.LocalReport.SetParameters(lsParam)
                rptProdReview.LocalReport.Refresh()

            Catch ex As ReportViewerException
                Throw ex
            End Try

            'rptTest.LocalReport.Refresh()

        End If


    End Sub

End Class
