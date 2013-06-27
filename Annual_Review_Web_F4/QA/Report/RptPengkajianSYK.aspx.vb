Imports Microsoft.Reporting.WebForms

Partial Class QA_Report_RptPengkajianSYK
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oRetur As New ProdukRetur

        If Not IsPostBack Then

            Dim ItemCode As String = Request.QueryString("itemcode")
            Dim FromDate As Date = CDate(Request.QueryString("fromdate"))
            Dim ToDate As Date = CDate(Request.QueryString("todate"))

            Dim dt As New Data.DataTable
            Dim lsParam As New List(Of ReportParameter)
            Dim dsRpt As ReportDataSource

            rptPengkajianSYK.Reset()

            lsParam.Add(New ReportParameter("ItemCode", ItemCode))
            lsParam.Add(New ReportParameter("FromDate", FromDate))
            lsParam.Add(New ReportParameter("ToDate", ToDate))

            Dim dsHDR As New dsPengkajianMutuTableAdapters.ReportSykHDRTableAdapter
            Dim dsDTL As New dsPengkajianMutuTableAdapters.ReportSykDTLTableAdapter
            Dim dtDTL As New Data.DataTable

            rptPengkajianSYK.LocalReport.ReportPath = "Report/PengkajianMutuSYK.rdlc"
            dt = dsHDR.GetSykHDR(ItemCode, FromDate, ToDate)
            dsRpt = New ReportDataSource("dsPengkajianMutu_ReportSykHDR", dt)
            rptPengkajianSYK.LocalReport.DataSources.Clear()
            rptPengkajianSYK.LocalReport.DataSources.Add(dsRpt)
            AddHandler rptPengkajianSYK.LocalReport.SubreportProcessing, AddressOf SetSubDataSource
            dtDTL = dsDTL.GetSykDTL()
            rptPengkajianSYK.LocalReport.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportSykDTL", dtDTL))


            Try

                rptPengkajianSYK.LocalReport.SetParameters(lsParam)
                rptPengkajianSYK.LocalReport.Refresh()

            Catch ex As ReportViewerException
                Throw ex

            End Try

        End If
    End Sub

    Public Sub SetSubDataSource(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim ds As New dsPengkajianMutuTableAdapters.ReportSykDTLTableAdapter
        Dim dt As New Data.DataTable

        dt = ds.GetSykDTL
        e.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportSykDTL", dt))

    End Sub

End Class
