
Partial Class QA_DataMaster_MasterListProdukJadi
    Inherits System.Web.UI.Page

    Private oProdReview As New ProductReview
    Protected PostBackStr As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PostBackStr = Page.ClientScript.GetPostBackEventReference(Me, "PostBackFromClient")

        If IsPostBack Then
            Dim EventArg As String = Request("__EVENTARGUMENT")
            If EventArg = "PostBackFromClient" Then
                GetProductName()
                GetDataMasterProdukJadi()
            End If
        End If
    End Sub

    Private Sub GetDataMasterProdukJadi()
        Dim dt As New Data.DataTable

        Try
            dt = oProdReview.GetMasterListByCode(txtProdID.Text, "RD")
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0)("IsTollOut")) Then
                    rbTollOut.Checked = False
                    rbInhouse.Checked = False
                ElseIf CBool(dt.Rows(0)("IsTollOut")) Then
                    rbTollOut.Checked = True
                Else
                    rbInhouse.Checked = True
                End If

                txtBatchSize.Text = "" & dt.Rows(0)("BatchSize")
                txtUmurProduk.Text = "" & dt.Rows(0)("UmurProduk")
                txtKondisiSimpan.Text = "" & dt.Rows(0)("KondisiSimpan")
                txtNoCPB.Text = "" & dt.Rows(0)("NoCPB")
                txtTglCPB.Text = If(IsDBNull(dt.Rows(0)("TglCPB")), String.Empty, _
                                    Format(dt.Rows(0)("TglCPB"), "dd-MMM-yy"))
                txtNoCKB.Text = "" & dt.Rows(0)("NoCKB")
                txtTglCKB.Text = If(IsDBNull(dt.Rows(0)("TglCKB")), String.Empty, _
                         Format(dt.Rows(0)("TglCKB"), "dd-MMM-yy"))
                txtPBPOJ.Text = "" & dt.Rows(0)("NoPBPOJ")
                txtTglPBPOJ.Text = If(IsDBNull(dt.Rows(0)("TglPBPOJ")), String.Empty, _
                         Format(dt.Rows(0)("TglPBPOJ"), "dd-MMM-yy"))
                txtRefPBPOJ.Text = "" & dt.Rows(0)("RefPBPOJ")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
        End Try

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim calPBPOJ, calCPB, calCKB As String

        Try

            calPBPOJ = If(String.IsNullOrEmpty(txtTglPBPOJ.Text), Nothing, txtTglPBPOJ.Text)
            calCPB = If(String.IsNullOrEmpty(txtTglCPB.Text), Nothing, txtTglCPB.Text)
            calCKB = If(String.IsNullOrEmpty(txtTglCKB.Text), Nothing, txtTglCKB.Text)

            oProdReview.SaveMasterListProduk(txtProdID.Text, rbTollOut.Checked, rbInhouse.Checked, txtBatchSize.Text, CDec(txtUmurProduk.Text), _
                txtKondisiSimpan.Text, txtNoCPB.Text, calCPB, txtNoCKB.Text, calCKB, txtPBPOJ.Text, calPBPOJ, txtRefPBPOJ.Text)
            ResetControls()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub GetProductName()

        Try
            lblNamaProduk.Text = oProdReview.GetItemNameByCode(txtProdID.Text)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ResetControls()

        txtProdID.Text = ""
        lblNamaProduk.Text = "."
        rbInhouse.Checked = False
        rbTollOut.Checked = False
        txtBatchSize.Text = ""
        txtUmurProduk.Text = ""
        txtKondisiSimpan.Text = ""
        txtNoCPB.Text = ""
        txtTglCPB.Text = ""
        txtNoCKB.Text = ""
        txtTglCKB.Text = ""
        txtPBPOJ.Text = ""
        txtTglPBPOJ.Text = ""
        txtRefPBPOJ.Text = ""

    End Sub

End Class
