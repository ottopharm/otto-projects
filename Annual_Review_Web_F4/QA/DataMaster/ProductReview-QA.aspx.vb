
Partial Class QA_DataMaster_ProductReview_QA
    Inherits System.Web.UI.Page

    Private oProdReview As New ProductReview
    Protected PostBackStr As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PostBackStr = Page.ClientScript.GetPostBackEventReference(Me, "PostBackFromClient")

        If Not IsPostBack Then
            If Request.QueryString("ProdID") IsNot Nothing Then
                txtProdID.Text = Request.QueryString("ProdID")
                lblProdName.Text = oProdReview.GetItemNameByCode(txtProdID.Text)
                txtNoBatch.Focus()
            End If
        Else
            Dim EventArg As String = Request("__EVENTARGUMENT")
            If EventArg = "PostBackFromClient" Then
                GetDataQC()
            End If
        End If
    End Sub

    Private Sub GetDataQC()
        Dim dt As New Data.DataTable

        Try
            dt = oProdReview.GetProductReview("QA", txtProdID.Text, txtNoBatch.Text)
            If dt.Rows.Count > 0 Then
                lblTglDN.Text = If(IsDBNull(dt.Rows(0)("TglDN")), String.Empty, Format(CDate(dt.Rows(0)("TglDN")), "dd-MMM-yy"))
                lblTglCPBQC.Text = If(IsDBNull(dt.Rows(0)("TglCPB_QC")), String.Empty, Format(CDate(dt.Rows(0)("TglCPB_QC")), "dd-MMM-yy"))
                lblTglCKBQC.Text = If(IsDBNull(dt.Rows(0)("TglCKB_QC")), String.Empty, Format(CDate(dt.Rows(0)("TglCKB_QC")), "dd-MMM-yy"))
                txtTglCPBQA.Text = If(IsDBNull(dt.Rows(0)("TglCPB_QA")), _
                                    String.Empty, _
                                    Format(CDate(dt.Rows(0)("TglCPB_QA")), "dd-MMM-yy"))
                txtTglCKBQA.Text = If(IsDBNull(dt.Rows(0)("TglCKB_QA")), _
                                    String.Empty, _
                                    Format(CDate(dt.Rows(0)("TglCKB_QA")), "dd-MMM-yy"))
                txtTglCPBCKBQA.Text = If(IsDBNull(dt.Rows(0)("TglCPBCKB_QA")), _
                                    String.Empty, _
                                    Format(CDate(dt.Rows(0)("TglCPBCKB_QA")), "dd-MMM-yy"))
                txtTglCoAQA.Text = If(IsDBNull(dt.Rows(0)("TglCoA_QA")), _
                                    String.Empty, _
                                    Format(CDate(dt.Rows(0)("TglCoA_QA")), "dd-MMM-yy"))
                txtTglGudang.Text = If(IsDBNull(dt.Rows(0)("TglGudang")), _
                                    String.Empty, _
                                    Format(CDate(dt.Rows(0)("TglGudang")), "dd-MMM-yy"))
                txtHULS.Text = "" & dt.Rows(0)("HULS")
                txtDeviasi.Text = "" & dt.Rows(0)("Deviasi")
                txtKeluhan.Text = "" & dt.Rows(0)("Keluhan")
                txtCPB.Text = "" & dt.Rows(0)("KetCPB")
                txtCPBP.Text = "" & dt.Rows(0)("KetCPBP")
                txtCKBP.Text = "" & dt.Rows(0)("KetCKBP")
                txtCKBS.Text = "" & dt.Rows(0)("KetCKBS")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
        End Try

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cal As String

        Try

            cal = If(String.IsNullOrEmpty(txtTglCPBQA.Text), Nothing, txtTglCPBQA.Text)

            oProdReview.QA_UpdateProdReview(txtProdID.Text, txtNoBatch.Text, txtTglCPBQA.Text, txtTglCKBQA.Text, txtTglCPBCKBQA.Text, txtTglCoAQA.Text, _
                txtTglGudang.Text, txtDeviasi.Text, txtCPB.Text, txtCPBP.Text, txtCKBP.Text, txtCKBS.Text, txtKeluhan.Text, txtHULS.Text)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class
