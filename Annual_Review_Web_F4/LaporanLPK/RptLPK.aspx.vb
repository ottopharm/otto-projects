Imports Microsoft.Reporting.WebForms

Partial Class Logistik_Report_RptLPK
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oRetur As New ProdukRetur
        Dim dtHDR As Data.DataTable

        If Not IsPostBack Then
            Dim NoLPK As String = Request.QueryString("NoLPK")

            Dim ds As New dsOttoTableAdapters.LaporanLPKTableAdapter
            Dim dt As New Data.DataTable
            Dim lsParam As New List(Of ReportParameter)
            Dim dsRpt As ReportDataSource

            dtHDR = oRetur.GetProdukReturByLPK(NoLPK)

            If dtHDR.Rows.Count > 0 Then
                Dim NamaCabangMBS As String = "MBS - " & _
                    oRetur.GetNamaCabangMBS(CInt(dtHDR.Rows(0)("AsalMBS")))

                lsParam.Add(New ReportParameter("NoLPK", NoLPK))
                lsParam.Add(New ReportParameter("TglLPK", CDate(dtHDR.Rows(0)("TglLPK"))))
                lsParam.Add(New ReportParameter("Pengirim", NamaCabangMBS))
                lsParam.Add(New ReportParameter("NoSPPB", dtHDR.Rows(0)("NoSPPB").ToString))

                rptLPK.Reset()

                Try
                    rptLPK.LocalReport.ReportPath = "Report/PPIC_LPK.rdlc"
                    dt = ds.GetDataLPK(NoLPK)
                    dsRpt = New ReportDataSource("dsOtto_LaporanLPK", dt)

                    rptLPK.LocalReport.DataSources.Clear()
                    rptLPK.LocalReport.DataSources.Add(dsRpt)

                    rptLPK.LocalReport.SetParameters(lsParam)
                    rptLPK.LocalReport.Refresh()

                Catch ex As ReportViewerException
                    Throw ex
                End Try

            End If

        End If

    End Sub
End Class
