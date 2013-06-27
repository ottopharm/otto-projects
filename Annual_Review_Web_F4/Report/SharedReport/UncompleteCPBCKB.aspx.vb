Imports Microsoft.Reporting.WebForms

Partial Class UncompleteCPBCKB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds As New dsOttoTableAdapters.UncompleteCPBCKBTableAdapter
        Dim dt As New Data.DataTable
        Dim dsRpt As ReportDataSource

        rptCPBCKB.Reset()
        rptCPBCKB.Visible = True

        Try
            rptCPBCKB.LocalReport.ReportPath = "Report/Uncomplete_CPB_CKB.rdlc"
            dt = ds.GetData()
            dsRpt = New ReportDataSource("dsOtto_UncompleteCPBCKB", dt)
            rptCPBCKB.LocalReport.DataSources.Clear()
            rptCPBCKB.LocalReport.DataSources.Add(dsRpt)
            rptCPBCKB.LocalReport.Refresh()

        Catch ex As ReportViewerException
            Throw ex
        End Try

    End Sub
End Class
