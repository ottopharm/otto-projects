Imports Microsoft.Reporting.WebForms

Partial Class QA_Report_RptLPPT
    Inherits System.Web.UI.Page

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        Dim oProdReview As New ProductReview

        If Not IsPostBack Then
            Dim Produk As String = If(Request.QueryString("Produk") = "", "ALL", Request.QueryString("ItemCode"))
            Dim Effective As String = Request.QueryString("Eff")
            Dim FromDate As Date = CDate(Request.QueryString("FromDate"))
            Dim ToDate As Date = CDate(Request.QueryString("ToDate"))

            Dim strEff As String

            Dim ds As New dsOttoTableAdapters.LPPTTableAdapter
            Dim dt As New Data.DataTable
            Dim lsParam As New List(Of ReportParameter)
            Dim dsRpt As ReportDataSource

            If Effective = "A" Then
                strEff = "ALL"
            ElseIf Effective = "E" Then
                strEff = "Effective"
            Else
                strEff = "Non Effective"
            End If

            rptLPPT.Reset()
 
            lsParam.Add(New ReportParameter("Produk", Produk))
            lsParam.Add(New ReportParameter("Status", strEff))
            lsParam.Add(New ReportParameter("FromDate", FromDate))
            lsParam.Add(New ReportParameter("ToDate", ToDate))

            Try
                rptLPPT.LocalReport.ReportPath = "Report/LPPT.rdlc"

                dt = ds.GetDataLPPT(Produk, Effective, FromDate, ToDate)
                dsRpt = New ReportDataSource("dsOtto_LPPT", dt)

                rptLPPT.LocalReport.DataSources.Clear()
                rptLPPT.LocalReport.DataSources.Add(dsRpt)
                rptLPPT.LocalReport.SetParameters(lsParam)
                rptLPPT.LocalReport.Refresh()

            Catch ex As ReportViewerException
                Throw ex
            End Try

        End If


    End Sub

End Class
