Imports Microsoft.Reporting.WebForms

Partial Class QA_Report_RptPengkajianSYR
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

            rptPengkajianSYR.Reset()

            lsParam.Add(New ReportParameter("ItemCode", ItemCode))
            lsParam.Add(New ReportParameter("FromDate", FromDate))
            lsParam.Add(New ReportParameter("ToDate", ToDate))

            Dim dsHDR As New dsPengkajianMutuTableAdapters.ReportSyrHDRTableAdapter
            Dim dsDTL As New dsPengkajianMutuTableAdapters.ReportSyrDTLTableAdapter
            Dim dtDTL As New Data.DataTable

            rptPengkajianSYR.LocalReport.ReportPath = "Report/PengkajianMutuSYR.rdlc"
            dt = dsHDR.GetSyrHDR(ItemCode, FromDate, ToDate)
            dsRpt = New ReportDataSource("dsPengkajianMutu_ReportSyrHDR", dt)
            rptPengkajianSYR.LocalReport.DataSources.Clear()
            rptPengkajianSYR.LocalReport.DataSources.Add(dsRpt)
            AddHandler rptPengkajianSYR.LocalReport.SubreportProcessing, AddressOf SetSubDataSource
            dtDTL = dsDTL.GetSyrDTL()
            rptPengkajianSYR.LocalReport.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportSyrDTL", dtDTL))


            Try

                rptPengkajianSYR.LocalReport.SetParameters(lsParam)
                rptPengkajianSYR.LocalReport.Refresh()

            Catch ex As ReportViewerException
                Throw ex

            End Try

        End If
    End Sub

    Public Sub SetSubDataSource(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim ds As New dsPengkajianMutuTableAdapters.ReportSyrDTLTableAdapter
        Dim dt As New Data.DataTable

        dt = ds.GetSyrDTL
        e.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportSyrDTL", dt))

    End Sub

End Class
