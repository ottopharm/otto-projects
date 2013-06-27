Imports Microsoft.Reporting.WebForms

Partial Class QA_Report_RptPengkajianKPS
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

            rptPengkajianKPS.Reset()

            lsParam.Add(New ReportParameter("ItemCode", ItemCode))
            lsParam.Add(New ReportParameter("FromDate", FromDate))
            lsParam.Add(New ReportParameter("ToDate", ToDate))

            Dim dsHDR As New dsPengkajianMutuTableAdapters.ReportKpsHDRTableAdapter
            Dim dsKadar As New dsPengkajianMutuTableAdapters.ReportKpsKadarTableAdapter
            Dim dsDisolusi As New dsPengkajianMutuTableAdapters.ReportKpsDisolusiTableAdapter
            Dim dtKadar, dtDisolusi As New Data.DataTable

            rptPengkajianKPS.LocalReport.ReportPath = "Report/PengkajianMutuKPS.rdlc"
            dt = dsHDR.GetKpsHDR(ItemCode, FromDate, ToDate)
            dsRpt = New ReportDataSource("dsPengkajianMutu_ReportKpsHDR", dt)
            rptPengkajianKPS.LocalReport.DataSources.Clear()
            rptPengkajianKPS.LocalReport.DataSources.Add(dsRpt)

            AddHandler rptPengkajianKPS.LocalReport.SubreportProcessing, AddressOf SetKadarDataSource
            dtKadar = dsKadar.GetKpsKadar
            rptPengkajianKPS.LocalReport.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportKpsKadar", dtKadar))

            AddHandler rptPengkajianKPS.LocalReport.SubreportProcessing, AddressOf SetDisolusiDataSource
            dtDisolusi = dsDisolusi.GetKpsDisolusi
            rptPengkajianKPS.LocalReport.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportKpsDisolusi", dtDisolusi))


            Try

                rptPengkajianKPS.LocalReport.SetParameters(lsParam)
                rptPengkajianKPS.LocalReport.Refresh()

            Catch ex As ReportViewerException
                Throw ex

            End Try

        End If
    End Sub

    Public Sub SetKadarDataSource(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim ds As New dsPengkajianMutuTableAdapters.ReportKpsKadarTableAdapter
        Dim dt As New Data.DataTable

        dt = ds.GetKpsKadar
        e.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportKpsKadar", dt))

    End Sub

    Public Sub SetDisolusiDataSource(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim ds As New dsPengkajianMutuTableAdapters.ReportKpsDisolusiTableAdapter
        Dim dt As New Data.DataTable

        dt = ds.GetKpsDisolusi
        e.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportKpsDisolusi", dt))

    End Sub

End Class
