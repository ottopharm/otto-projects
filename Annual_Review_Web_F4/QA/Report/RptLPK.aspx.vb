Imports Microsoft.Reporting.WebForms

Partial Class QA_Report_RptLPK
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oRetur As New ProdukRetur

        If Not IsPostBack Then

            Dim CatEval As String = Request.QueryString("CatEval")
            Dim FromDate As Date = CDate(Request.QueryString("FromDate"))
            Dim ToDate As Date = CDate(Request.QueryString("ToDate"))

            Dim dt As New Data.DataTable
            Dim lsParam As New List(Of ReportParameter)
            Dim dsRpt As ReportDataSource

            rptLPK.Reset()

            lsParam.Add(New ReportParameter("FromDate", Format(FromDate, "dd-MMM-yyyy")))
            lsParam.Add(New ReportParameter("ToDate", Format(ToDate, "dd-MMM-yyyy")))

            If CatEval = 0 Then
                Dim ds As New dsOttoTableAdapters.LPKReportByPeriodTableAdapter
                Dim dsQA As New dsOttoTableAdapters.QA_LPKReportTableAdapter
                Dim dtQA As New Data.DataTable

                rptLPK.LocalReport.ReportPath = "Report/QA_LPKByPeriod.rdlc"
                dt = ds.GetLPKByPeriod(FromDate, ToDate)
                dsRpt = New ReportDataSource("dsOtto_LPKReportByPeriod", dt)
                rptLPK.LocalReport.DataSources.Clear()
                rptLPK.LocalReport.DataSources.Add(dsRpt)
                AddHandler rptLPK.LocalReport.SubreportProcessing, AddressOf SetSubDataSource
                dtQA = dsQA.GetQALPK()
                rptLPK.LocalReport.DataSources.Add(New ReportDataSource("dsOtto_QA_LPKReport", dtQA))

            Else
                Dim ds As New dsOttoTableAdapters.LPKReportByCatTableAdapter

                rptLPK.LocalReport.ReportPath = "Report/QA_LPKByCat.rdlc"
                lsParam.Add(New ReportParameter("EvalCat", oRetur.GetEvalName(CatEval)))
                dt = ds.GetLPKByCat(FromDate, ToDate, CatEval)
                dsRpt = New ReportDataSource("dsOtto_LPKReportByCat", dt)
                rptLPK.LocalReport.DataSources.Clear()
                rptLPK.LocalReport.DataSources.Add(dsRpt)
            End If

            Try
                rptLPK.LocalReport.SetParameters(lsParam)
                rptLPK.LocalReport.Refresh()

            Catch ex As ReportViewerException
                Throw ex

            End Try

        End If

    End Sub

    Public Sub SetSubDataSource(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim ds As New dsOttoTableAdapters.QA_LPKReportTableAdapter
        Dim dt As New Data.DataTable

        dt = ds.GetQALPK()
        e.DataSources.Add(New ReportDataSource("dsOtto_QA_LPKReport", dt))

    End Sub
End Class
