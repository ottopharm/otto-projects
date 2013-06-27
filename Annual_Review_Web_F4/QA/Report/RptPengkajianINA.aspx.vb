Imports Microsoft.Reporting.WebForms

Partial Class QA_Report_RptPengkajianINA
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

            rptPengkajianINA.Reset()

            lsParam.Add(New ReportParameter("ItemCode", ItemCode))
            lsParam.Add(New ReportParameter("FromDate", FromDate))
            lsParam.Add(New ReportParameter("ToDate", ToDate))

            Dim dsHDR As New dsPengkajianMutuTableAdapters.ReportInaHDRTableAdapter
            Dim dsDTL As New dsPengkajianMutuTableAdapters.ReportInaDTLTableAdapter
            Dim dtDTL As New Data.DataTable

            rptPengkajianINA.LocalReport.ReportPath = "Report/PengkajianMutuINA.rdlc"
            dt = dsHDR.GetInaHDR(ItemCode, FromDate, ToDate)
            dsRpt = New ReportDataSource("dsPengkajianMutu_ReportInaHDR", dt)
            rptPengkajianINA.LocalReport.DataSources.Clear()
            rptPengkajianINA.LocalReport.DataSources.Add(dsRpt)
            AddHandler rptPengkajianINA.LocalReport.SubreportProcessing, AddressOf SetSubDataSource
            dtDTL = dsDTL.GetInaDTL
            rptPengkajianINA.LocalReport.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportInaDTL", dtDTL))


            Try

                rptPengkajianINA.LocalReport.SetParameters(lsParam)
                rptPengkajianINA.LocalReport.Refresh()

            Catch ex As ReportViewerException
                Throw ex

            End Try

        End If
    End Sub

    Public Sub SetSubDataSource(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim ds As New dsPengkajianMutuTableAdapters.ReportInaDTLTableAdapter
        Dim dt As New Data.DataTable

        dt = ds.GetInaDTL
        e.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportInaDTL", dt))

    End Sub

End Class
