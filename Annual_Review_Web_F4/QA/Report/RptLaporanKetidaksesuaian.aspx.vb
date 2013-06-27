Imports Microsoft.Reporting.WebForms

Partial Class QA_Report_RptLaporanKetidaksesuaian
    Inherits System.Web.UI.Page

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load

        If Not IsPostBack Then
            Dim DepartemenPelapor As String = Request.QueryString("DepartemenPelapor")
            Dim Ketidaksesuaian As String = Request.QueryString("Ketidaksesuaian")
            Dim KetidaksesuaianLain As String = If(Request.QueryString("KetidaksesuaianLain") = "", "ALL", Request.QueryString("KetidaksesuaianLain"))
            Dim Rencana As String = Request.QueryString("Rencana")
            Dim Resiko As String = Request.QueryString("Resiko")
            Dim PenyebabPenyimpangan As String = Request.QueryString("PenyebabPenyimpangan")
            Dim PenyebabPenyimpanganLain As String = If(Request.QueryString("PenyebabPenyimpanganLain") = "", "ALL", Request.QueryString("PenyebabPenyimpanganLain"))
            Dim FromDate As Date = CDate(Request.QueryString("FromDate"))
            Dim ToDate As Date = CDate(Request.QueryString("ToDate"))
            Dim IsClosed As String = Request.QueryString("IsClosed")

            Dim strKetidaksesuaian, strRencana, strResiko, strPenyebabPenyimpangan As String
            Dim strDepartemenPelapor, strIsClosed As String

            Dim ds As New dsOttoTableAdapters.LaporanKetidaksesuaianTableAdapter
            Dim dt As New Data.DataTable
            Dim lsParam As New List(Of ReportParameter)
            Dim dsRpt As ReportDataSource

            Dim oLK As LaporanKetidaksesuaian = New LaporanKetidaksesuaian()

            Select Case Rencana
                Case "A"
                    strRencana = "ALL"
                Case "1"
                    strRencana = "Ya"
                Case Else
                    strRencana = "Tidak"
            End Select

            Select Case Ketidaksesuaian
                Case "0"
                    strKetidaksesuaian = "ALL"
                Case "1"
                    strKetidaksesuaian = "Bahan Baku"
                Case "2"
                    strKetidaksesuaian = "Bahan Kemas"
                Case "3"
                    strKetidaksesuaian = "Produk Ruahan"
                Case "4"
                    strKetidaksesuaian = "Produk Jadi"
                Case "5"
                    strKetidaksesuaian = "Bangunan"
                Case "6"
                    strKetidaksesuaian = "Sarana Penunjang"
                Case "7"
                    strKetidaksesuaian = "Mesin"
                Case "8"
                    strKetidaksesuaian = "Prosedur"
                Case Else
                    strKetidaksesuaian = "Lain - lain"
            End Select

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

            Select Case PenyebabPenyimpangan
                Case "0"
                    strPenyebabPenyimpangan = "ALL"
                Case "1"
                    strPenyebabPenyimpangan = "Human Error"
                Case "2"
                    strPenyebabPenyimpangan = "Supplier"
                Case "3"
                    strPenyebabPenyimpangan = "Mesin / Alat"
                Case "4"
                    strPenyebabPenyimpangan = "Formula"
                Case "5"
                    strPenyebabPenyimpangan = "Spesifikasi"
                Case "6"
                    strPenyebabPenyimpangan = "Proses"
                Case "7"
                    strPenyebabPenyimpangan = "Sarana Penunjang"
                Case Else
                    strPenyebabPenyimpangan = "Lain - lain"
            End Select

            Select Case IsClosed
                Case "A"
                    strIsClosed = "ALL"
                Case "0"
                    strIsClosed = "Open"
                Case "1"
                    strIsClosed = "Closed"
            End Select

            If DepartemenPelapor = -1 Then
                strDepartemenPelapor = "ALL"
            Else
                strDepartemenPelapor = oLK.GetDeptNameById(DepartemenPelapor)
            End If

            rptLaporanKetidaksesuaian.Reset()

            lsParam.Add(New ReportParameter("DepartemenPelapor", strDepartemenPelapor))
            lsParam.Add(New ReportParameter("Ketidaksesuaian", strKetidaksesuaian))
            lsParam.Add(New ReportParameter("KetidaksesuaianLain", KetidaksesuaianLain))
            lsParam.Add(New ReportParameter("Rencana", strRencana))
            lsParam.Add(New ReportParameter("Resiko", strResiko))
            lsParam.Add(New ReportParameter("PenyebabPenyimpangan", strPenyebabPenyimpangan))
            lsParam.Add(New ReportParameter("PenyebabPenyimpanganLain", PenyebabPenyimpanganLain))
            lsParam.Add(New ReportParameter("IsClosed", strIsClosed))
            lsParam.Add(New ReportParameter("FromDate", FromDate))
            lsParam.Add(New ReportParameter("ToDate", ToDate))

            Try
                rptLaporanKetidaksesuaian.LocalReport.ReportPath = "Report/LaporanKetidaksesuaian.rdlc"
                dt = ds.GetDataLK(DepartemenPelapor, Ketidaksesuaian, KetidaksesuaianLain, Rencana, Resiko, PenyebabPenyimpangan, PenyebabPenyimpanganLain, IsClosed, FromDate, ToDate)
                dsRpt = New ReportDataSource("dsOtto_LaporanKetidaksesuaian", dt)

                rptLaporanKetidaksesuaian.LocalReport.DataSources.Clear()
                rptLaporanKetidaksesuaian.LocalReport.DataSources.Add(dsRpt)

                rptLaporanKetidaksesuaian.LocalReport.SetParameters(lsParam)
                rptLaporanKetidaksesuaian.LocalReport.Refresh()

            Catch ex As ReportViewerException
                Throw ex
            End Try

        End If

    End Sub

End Class
