Imports Microsoft.Reporting.WebForms


Partial Class Produksi_Report_ProdKPI
    Inherits System.Web.UI.Page

    Protected Sub btnGetData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetData.Click
        Dim ds As New dsOttoTableAdapters.ProdKPITableAdapter
        Dim dt As New Data.DataTable
        Dim lsParam As New List(Of ReportParameter)
        Dim dsRpt As ReportDataSource

        rptProdKPI.Visible = True
        rptProdKPI.Reset()

        lsParam.Add(New ReportParameter("FromDate", txtFromDate.Text))
        lsParam.Add(New ReportParameter("ToDate", txtToDate.Text))

        Try
            rptProdKPI.LocalReport.ReportPath = "Report/ProdKPI.rdlc"
            dt = ds.GetDataProdKPI(CDate(txtFromDate.Text), CDate(txtToDate.Text))
            dsRpt = New ReportDataSource("dsOtto_ProdKPI", dt)
            rptProdKPI.LocalReport.DataSources.Clear()
            rptProdKPI.LocalReport.DataSources.Add(dsRpt)
            rptProdKPI.LocalReport.SetParameters(lsParam)
            rptProdKPI.LocalReport.Refresh()

        Catch ex As ReportViewerException
            Throw ex
        End Try

    End Sub
End Class
