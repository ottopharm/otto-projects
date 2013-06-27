Imports Microsoft.Reporting.WebForms

Partial Class QA_Report_RptPengkajianTABSalut
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

            rptPengkajianTab.Reset()

            lsParam.Add(New ReportParameter("ItemCode", ItemCode))
            lsParam.Add(New ReportParameter("FromDate", FromDate))
            lsParam.Add(New ReportParameter("ToDate", ToDate))

            Dim dsHDR As New dsPengkajianMutuTableAdapters.ReportTabHDRTableAdapter
            Dim dsKadar As New dsPengkajianMutuTableAdapters.ReportTabKadarTableAdapter
            Dim dsKandungan As New dsPengkajianMutuTableAdapters.ReportTabKandunganTableAdapter
            Dim dsBobot As New dsPengkajianMutuTableAdapters.ReportTabBobotTableAdapter
            Dim dsDisolusi As New dsPengkajianMutuTableAdapters.ReportTabDisolusiTableAdapter
            Dim dsTssDisolusi As New dsPengkajianMutuTableAdapters.ReportTabTssDisolusiTableAdapter
            Dim dtKadar, dtKandungan, dtBobot, dtDisolusi, dtTssDisolusi As New Data.DataTable

            rptPengkajianTab.LocalReport.ReportPath = "Report/PengkajianMutuTabSalut.rdlc"
            dt = dsHDR.GetTabSalutHDR(ItemCode, FromDate, ToDate)
            dsRpt = New ReportDataSource("dsPengkajianMutu_ReportTabHDR", dt)
            rptPengkajianTab.LocalReport.DataSources.Clear()
            rptPengkajianTab.LocalReport.DataSources.Add(dsRpt)

            AddHandler rptPengkajianTab.LocalReport.SubreportProcessing, AddressOf SetKadarDataSource
            dtKadar = dsKadar.GetTabKadar
            rptPengkajianTab.LocalReport.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportTabKadar", dtKadar))

            AddHandler rptPengkajianTab.LocalReport.SubreportProcessing, AddressOf SetKandunganDataSource
            dtKandungan = dsKandungan.GetTabKandungan
            rptPengkajianTab.LocalReport.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportTabKandungan", dtKandungan))

            AddHandler rptPengkajianTab.LocalReport.SubreportProcessing, AddressOf SetBobotDataSource
            dtBobot = dsBobot.GetTabBobot
            rptPengkajianTab.LocalReport.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportTabBobot", dtBobot))

            AddHandler rptPengkajianTab.LocalReport.SubreportProcessing, AddressOf SetDisolusiDataSource
            dtDisolusi = dsDisolusi.GetTabDisolusi
            rptPengkajianTab.LocalReport.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportTabDisolusi", dtDisolusi))

            AddHandler rptPengkajianTab.LocalReport.SubreportProcessing, AddressOf SetTssDisolusiDataSource
            dtTssDisolusi = dsTssDisolusi.GetTabTssDisolusi
            rptPengkajianTab.LocalReport.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportTabTssDisolusi", dtTssDisolusi))

            Try

                rptPengkajianTab.LocalReport.SetParameters(lsParam)
                rptPengkajianTab.LocalReport.Refresh()

            Catch ex As ReportViewerException
                Throw ex

            End Try

        End If
    End Sub

    Public Sub SetKadarDataSource(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim ds As New dsPengkajianMutuTableAdapters.ReportTabKadarTableAdapter
        Dim dt As New Data.DataTable

        dt = ds.GetTabKadar
        e.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportTabKadar", dt))

    End Sub

    Public Sub SetKandunganDataSource(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim ds As New dsPengkajianMutuTableAdapters.ReportTabKandunganTableAdapter
        Dim dt As New Data.DataTable

        dt = ds.GetTabKandungan
        e.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportTabKandungan", dt))

    End Sub

    Public Sub SetBobotDataSource(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim ds As New dsPengkajianMutuTableAdapters.ReportTabBobotTableAdapter
        Dim dt As New Data.DataTable

        dt = ds.GetTabBobot
        e.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportTabBobot", dt))

    End Sub

    Public Sub SetDisolusiDataSource(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim ds As New dsPengkajianMutuTableAdapters.ReportTabDisolusiTableAdapter
        Dim dt As New Data.DataTable

        dt = ds.GetTabDisolusi
        e.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportTabDisolusi", dt))

    End Sub

    Public Sub SetTssDisolusiDataSource(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim ds As New dsPengkajianMutuTableAdapters.ReportTabTssDisolusiTableAdapter
        Dim dt As New Data.DataTable

        dt = ds.GetTabTssDisolusi
        e.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportTabTssDisolusi", dt))

    End Sub

End Class
