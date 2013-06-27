Imports Microsoft.Reporting.WebForms

Partial Class QA_Report_RptPengkajianINV
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

            rptPengkajianINV.Reset()

            lsParam.Add(New ReportParameter("ItemCode", ItemCode))
            lsParam.Add(New ReportParameter("FromDate", FromDate))
            lsParam.Add(New ReportParameter("ToDate", ToDate))

            Dim dsHDR As New dsPengkajianMutuTableAdapters.ReportInvHDRTableAdapter
            Dim dsKadar As New dsPengkajianMutuTableAdapters.ReportInvKadarTableAdapter
            Dim dsBobot As New dsPengkajianMutuTableAdapters.ReportInvBobotTableAdapter
            Dim dtKadar, dtBobot As New Data.DataTable

            rptPengkajianINV.LocalReport.ReportPath = "Report/PengkajianMutuINV.rdlc"
            dt = dsHDR.GetInvHDR(ItemCode, FromDate, ToDate)
            dsRpt = New ReportDataSource("dsPengkajianMutu_ReportInvHDR", dt)
            rptPengkajianINV.LocalReport.DataSources.Clear()
            rptPengkajianINV.LocalReport.DataSources.Add(dsRpt)

            AddHandler rptPengkajianINV.LocalReport.SubreportProcessing, AddressOf SetSubKadarDataSource
            dtKadar = dsKadar.GetInvKadar
            rptPengkajianINV.LocalReport.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportInvKadar", dtKadar))

            AddHandler rptPengkajianINV.LocalReport.SubreportProcessing, AddressOf SetSubBobotDataSource
            dtBobot = dsBobot.GetInvBobot
            rptPengkajianINV.LocalReport.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportInvBobot", dtBobot))

            Try

                rptPengkajianINV.LocalReport.SetParameters(lsParam)
                rptPengkajianINV.LocalReport.Refresh()

            Catch ex As ReportViewerException
                Throw ex

            End Try

        End If
    End Sub

    Public Sub SetSubKadarDataSource(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim ds As New dsPengkajianMutuTableAdapters.ReportInvKadarTableAdapter
        Dim dt As New Data.DataTable

        dt = ds.GetInvKadar
        e.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportInvKadar", dt))

    End Sub

    Public Sub SetSubBobotDataSource(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim ds As New dsPengkajianMutuTableAdapters.ReportInvBobotTableAdapter
        Dim dt As New Data.DataTable

        dt = ds.GetInvBobot
        e.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportInvBobot", dt))

    End Sub

End Class
