Imports Microsoft.Reporting.WebForms

Partial Class QA_Report_RptLaporanKeluhan
    Inherits System.Web.UI.Page

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load

        If Not IsPostBack Then
            Dim Manufaktur As String = If(Request.QueryString("Manufaktur") = "", "ALL", Request.QueryString("Manufaktur"))
            Dim Resiko As String = Request.QueryString("Resiko")
            Dim Investigasi As String = If(Request.QueryString("Investigasi") = "", "ALL", Request.QueryString("Investigasi"))
            Dim IsClosed As String = Request.QueryString("IsClosed")
            Dim FromDate As Date = CDate(Request.QueryString("FromDate"))
            Dim ToDate As Date = CDate(Request.QueryString("ToDate"))

            Dim strResiko, strIsClosed As String

            Dim ds As New dsOttoTableAdapters.LaporanKeluhanTableAdapter
            Dim dt As New Data.DataTable
            Dim lsParam As New List(Of ReportParameter)
            Dim dsRpt As ReportDataSource

            Dim oLK As LaporanKetidaksesuaian = New LaporanKetidaksesuaian()

            Select Case Resiko
                Case "A"
                    strResiko = "ALL"
                Case "1"
                    strResiko = "Critical"
                Case "2"
                    strResiko = "Mayor"
                Case Else
                    strResiko = "Minor"
            End Select

            Select Case IsClosed
                Case "A"
                    strIsClosed = "ALL"
                Case "0"
                    strIsClosed = "Open"
                Case "1"
                    strIsClosed = "Closed"
            End Select

            rptLaporanKeluhan.Reset()

            lsParam.Add(New ReportParameter("Manufaktur", Manufaktur))
            lsParam.Add(New ReportParameter("Resiko", strResiko))
            lsParam.Add(New ReportParameter("Investigasi", Investigasi))
            lsParam.Add(New ReportParameter("IsClosed", strIsClosed))
            lsParam.Add(New ReportParameter("FromDate", FromDate))
            lsParam.Add(New ReportParameter("ToDate", ToDate))

            Try
                rptLaporanKeluhan.LocalReport.ReportPath = "Report/LaporanKeluhan.rdlc"
                dt = ds.GetDataLK(Manufaktur, Resiko, Investigasi, IsClosed, FromDate, ToDate)
                dsRpt = New ReportDataSource("dsOtto_LaporanKeluhan", dt)

                rptLaporanKeluhan.LocalReport.DataSources.Clear()
                rptLaporanKeluhan.LocalReport.DataSources.Add(dsRpt)

                rptLaporanKeluhan.LocalReport.SetParameters(lsParam)
                rptLaporanKeluhan.LocalReport.Refresh()

            Catch ex As ReportViewerException
                Throw ex
            End Try

        End If

    End Sub

End Class
