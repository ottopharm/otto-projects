Imports Microsoft.Reporting.WebForms

Partial Class QA_Report_RptPengkajianOil
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

            rptPengkajianOil.Reset()

            lsParam.Add(New ReportParameter("ItemCode", ItemCode))
            lsParam.Add(New ReportParameter("FromDate", FromDate))
            lsParam.Add(New ReportParameter("ToDate", ToDate))

            Dim dsHDR As New dsPengkajianMutuTableAdapters.ReportOilHDRTableAdapter
            Dim dsKadar As New dsPengkajianMutuTableAdapters.ReportOilKadarTableAdapter
            Dim dsPotensi As New dsPengkajianMutuTableAdapters.ReportOilPotensiTableAdapter

            Dim dtKadar, dtPotensi As New Data.DataTable

            rptPengkajianOil.LocalReport.ReportPath = "Report/PengkajianMutuOil.rdlc"
            dt = dsHDR.GetOilHDR(ItemCode, FromDate, ToDate)
            dsRpt = New ReportDataSource("dsPengkajianMutu_ReportOilHDR", dt)
            rptPengkajianOil.LocalReport.DataSources.Clear()
            rptPengkajianOil.LocalReport.DataSources.Add(dsRpt)

            AddHandler rptPengkajianOil.LocalReport.SubreportProcessing, AddressOf SetKadarDataSource
            dtKadar = dsKadar.GetOilKadar
            rptPengkajianOil.LocalReport.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportOilKadar", dtKadar))

            AddHandler rptPengkajianOil.LocalReport.SubreportProcessing, AddressOf SetPotensiDataSource
            dtPotensi = dsPotensi.GetOilPotensi
            rptPengkajianOil.LocalReport.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportOilPotensi", dtPotensi))


            Try

                rptPengkajianOil.LocalReport.SetParameters(lsParam)
                rptPengkajianOil.LocalReport.Refresh()

            Catch ex As ReportViewerException
                Throw ex

            End Try

        End If
    End Sub

    Public Sub SetKadarDataSource(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim ds As New dsPengkajianMutuTableAdapters.ReportOilKadarTableAdapter
        Dim dt As New Data.DataTable

        dt = ds.GetOilKadar
        e.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportOilKadar", dt))

    End Sub

    Public Sub SetPotensiDataSource(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim ds As New dsPengkajianMutuTableAdapters.ReportOilPotensiTableAdapter
        Dim dt As New Data.DataTable

        dt = ds.GetOilPotensi
        e.DataSources.Add(New ReportDataSource("dsPengkajianMutu_ReportOilPotensi", dt))
    End Sub

End Class
