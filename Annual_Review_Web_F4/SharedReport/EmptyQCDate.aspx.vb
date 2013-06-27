Imports Microsoft.Reporting.WebForms


Partial Class QA_Report_EmptyQCDate
    Inherits System.Web.UI.Page

    Protected Sub btnGetData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetData.Click
        'Per tgl 5 Nov 2012, data dari report ini digunakan untuk
        'mencari CoA yg belum masuk ke QA.
        'Nama SP masih sama hanya coding nya berubah
        Dim ds As New dsOttoTableAdapters.EmptyTglQCTableAdapter
        Dim dt As New Data.DataTable
        Dim lsParam As New List(Of ReportParameter)
        Dim dsRpt As ReportDataSource

        rptEmptyQCDate.Visible = True
        rptEmptyQCDate.Reset()

        lsParam.Add(New ReportParameter("FromDate", txtFromDate.Text))
        lsParam.Add(New ReportParameter("ToDate", txtToDate.Text))

        Try
            rptEmptyQCDate.LocalReport.ReportPath = "Report/ListEmptyTglQC.rdlc"
            dt = ds.GetEmptyTglQC(CDate(txtFromDate.Text), CDate(txtToDate.Text))
            dsRpt = New ReportDataSource("dsOtto_EmptyTglQC", dt)
            rptEmptyQCDate.LocalReport.DataSources.Clear()
            rptEmptyQCDate.LocalReport.DataSources.Add(dsRpt)
            rptEmptyQCDate.LocalReport.SetParameters(lsParam)
            rptEmptyQCDate.LocalReport.Refresh()

        Catch ex As ReportViewerException
            Throw ex
        End Try

    End Sub
End Class
