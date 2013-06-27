Imports Microsoft.Reporting.WebForms

Partial Class QA_Report_RptChangeControl
    Inherits System.Web.UI.Page

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load

        If Not IsPostBack Then
            Dim JenisPerubahan As String = If(Request.QueryString("JenisPerubahan") = "", "ALL", Request.QueryString("JenisPerubahan"))
            Dim KategoriPerubahan As String = Request.QueryString("KategoriPerubahan")
            Dim BPOM As String = Request.QueryString("BPOM")
            Dim Effective As String = Request.QueryString("Eff")
            Dim FromDate As Date = CDate(Request.QueryString("FromDate"))
            Dim ToDate As Date = CDate(Request.QueryString("ToDate"))
            Dim Dept As String = Request.QueryString("Dept")
            Dim Status As String = Request.QueryString("Status")

            Dim strEff, strKategoriPerubahan, strBPOM As String
            Dim strStatus, strDept As String

            Dim ds As New dsOttoTableAdapters.ChangeControlTableAdapter
            Dim dt As New Data.DataTable
            Dim lsParam As New List(Of ReportParameter)
            Dim dsRpt As ReportDataSource

            Dim oCC As ChangeControl = New ChangeControl()

            Select Case Effective
                Case "A"
                    strEff = "ALL"
                Case "E"
                    strEff = "Effective"
                Case Else
                    strEff = "Non Effective"
            End Select

            Select Case KategoriPerubahan
                Case "A"
                    strKategoriPerubahan = "ALL"
                Case "1"
                    strKategoriPerubahan = "Minor"
                Case "2"
                    strKategoriPerubahan = "Mayor"
                Case Else
                    strKategoriPerubahan = "Critical"
            End Select

            Select Case BPOM
                Case "A"
                    strBPOM = "ALL"
                Case "Y"
                    strBPOM = "Ya"
                Case Else
                    strBPOM = "Tidak"
            End Select

            Select Case Status
                Case "A"
                    strStatus = "ALL"
                Case "0"
                    strStatus = "Open"
                Case "1"
                    strStatus = "Closed"
            End Select

            If Dept = -1 Then
                strDept = "ALL"
            Else
                strDept = oCC.GetDeptNameById(Dept)
            End If

            rptChangeControl.Reset()

            lsParam.Add(New ReportParameter("JenisPerubahan", JenisPerubahan))
            lsParam.Add(New ReportParameter("KategoriPerubahan", strKategoriPerubahan))
            lsParam.Add(New ReportParameter("BPOM", strBPOM))
            lsParam.Add(New ReportParameter("Effective", strEff))
            lsParam.Add(New ReportParameter("FromDate", FromDate))
            lsParam.Add(New ReportParameter("ToDate", ToDate))
            lsParam.Add(New ReportParameter("Dept", strDept))
            lsParam.Add(New ReportParameter("Status", strStatus))

            Try
                rptChangeControl.LocalReport.ReportPath = "Report/ChangeControl.rdlc"
                dt = ds.GetDataCC(JenisPerubahan, KategoriPerubahan, BPOM, FromDate, ToDate, Dept, Status, Effective)
                dsRpt = New ReportDataSource("dsOtto_ChangeControl", dt)

                rptChangeControl.LocalReport.DataSources.Clear()
                rptChangeControl.LocalReport.DataSources.Add(dsRpt)

                rptChangeControl.LocalReport.SetParameters(lsParam)
                rptChangeControl.LocalReport.Refresh()

            Catch ex As ReportViewerException
                Throw ex
            End Try

        End If

    End Sub

End Class
