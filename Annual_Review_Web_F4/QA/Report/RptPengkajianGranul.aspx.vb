Imports Microsoft.Reporting.WebForms

Partial Class QA_Report_RptPengkajianGranul
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

            rptPengkajianGranul.Reset()

            lsParam.Add(New ReportParameter("ItemCode", ItemCode))
            lsParam.Add(New ReportParameter("FromDate", FromDate))
            lsParam.Add(New ReportParameter("ToDate", ToDate))

            Dim dsHDR As New dsPengkajianMutuTableAdapters.ReportGranulHDRTableAdapter
            Dim dsDTL As New dsPengkajianMutuTableAdapters.ReportGranulDTLTableAdapter
            Dim dtDTL As New Data.DataTable

            rptPengkajianGranul.LocalReport.ReportPath = "Report/PengkajianMutuGranul.rdlc"
            dt = dsHDR.GetGranulHDR(ItemCode, FromDate, ToDate)
            dsRpt = New ReportDataSource("dsPengkajianMutu_ReportGranulHDR", dt)
            rptPengkajianGranul.LocalReport.DataSources.Clear()
            rptPengkajianGranul.LocalReport.DataSources.Add(dsRpt)
            AddHandler rptPengkajianGranul.LocalReport.SubreportProcessing, AddressOf SetSubDataSource
            dtDTL = dsDTL.GetGranulDTL()
            rptPengkajianGranul.LocalReport.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportGranulDTL", dtDTL))


            Try

                rptPengkajianGranul.LocalReport.SetParameters(lsParam)
                rptPengkajianGranul.LocalReport.Refresh()

            Catch ex As ReportViewerException
                Throw ex

            End Try

        End If
    End Sub

    Public Sub SetSubDataSource(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim ds As New dsPengkajianMutuTableAdapters.ReportGranulDTLTableAdapter
        Dim dt As New Data.DataTable

        dt = ds.GetGranulDTL
        e.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportGranulDTL", dt))

    End Sub

End Class
