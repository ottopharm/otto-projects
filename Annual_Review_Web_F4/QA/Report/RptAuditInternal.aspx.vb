Imports Microsoft.Reporting.WebForms

Partial Class QA_Report_RptAuditInternal
    Inherits System.Web.UI.Page

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load

        If Not IsPostBack Then
            'Dim DepartemenPJPerbaikan As String = Request.QueryString("DepartemenPJPerbaikan")
            Dim Resiko As String = Request.QueryString("Resiko")
            Dim IsClosed As String = Request.QueryString("IsClosed")

            Dim strResiko, strIsClosed As String

            Dim ds As New dsOttoTableAdapters.AuditInternalTableAdapter
            Dim dt As New Data.DataTable
            Dim lsParam As New List(Of ReportParameter)
            Dim dsRpt As New ReportDataSource

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

            rptAuditInternal.Reset()

            'lsParam.Add(New ReportParameter("DepartemenPJPerbaikan", strDepartemenPJPerbaikan))
            lsParam.Add(New ReportParameter("Resiko", strResiko))
            lsParam.Add(New ReportParameter("IsClosed", strIsClosed))

            Try
                rptAuditInternal.LocalReport.ReportPath = "Report/AuditInternals.rdlc"
                dt = ds.GetDataAI(Resiko, IsClosed)
                dsRpt = New ReportDataSource("dsOtto_AuditInternal", dt)

                rptAuditInternal.LocalReport.DataSources.Clear()
                rptAuditInternal.LocalReport.DataSources.Add(dsRpt)

                rptAuditInternal.LocalReport.SetParameters(lsParam)
                rptAuditInternal.LocalReport.Refresh()

            Catch ex As ReportViewerException
                Throw ex
            End Try

        End If

    End Sub

End Class
