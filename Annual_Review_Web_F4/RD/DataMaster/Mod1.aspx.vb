
Partial Class QA_DataMaster_Mod1
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
                
                txtBatchSize.Text = "" & dt.Rows(0)("BatchSize")
                orgBatchSize.Text = txtBatchSize.Text

                txtUmurProduk.Text = dt.Rows(0)("UmurProduk")
                orgUmurProduk.Text = txtUmurProduk.Text

                txtNoCPB.Text = "" & dt.Rows(0)("NoCPB")
                orgNoCPB.Text = txtNoCPB.Text

                txtTglCPB.Text = If(IsDBNull(dt.Rows(0)("TglCPB")), String.Empty, _
                                    Format(dt.Rows(0)("TglCPB"), "dd-MMM-yy"))
                orgTglCPB.Text = txtTglCPB.Text

                txtNoCKB.Text = "" & dt.Rows(0)("NoCKB")
                orgNoCKB.Text = txtNoCKB.Text

                txtTglCKB.Text = If(IsDBNull(dt.Rows(0)("TglCKB")), String.Empty, _
                         Format(dt.Rows(0)("TglCKB"), "dd-MMM-yy"))
                orgTglCKB.Text = txtTglCKB.Text

            End If
        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
        End Try

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            If (Me.IsValid) Then
                oProdReview.ModMasterList(txtProdID.Text, txtBatchSize.Text, txtUmurProduk.Text, txtNoCPB.Text, _
                        CDate(txtTglCPB.Text), txtNoCKB.Text, CDate(txtTglCKB.Text), True)
                ResetControls()
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Try
            oProdReview.DeleteBatchSize(txtProdID.Text, False)
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
        txtBatchSize.Text = ""
        txtUmurProduk.Text = ""
        txtNoCPB.Text = ""
        txtTglCPB.Text = ""
        txtNoCKB.Text = ""
        txtTglCKB.Text = ""

    End Sub

    Protected Sub custNoCPB_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles custNoCPB.ServerValidate

        If ((txtBatchSize.Text <> orgBatchSize.Text) OrElse (CDec(txtUmurProduk.Text) - CDec(orgUmurProduk.Text) <> 0)) Then
            If (txtNoCPB.Text <> orgNoCPB.Text) Then
                args.IsValid = True
            Else
                args.IsValid = False
            End If
        End If

    End Sub

    Protected Sub txtTglCPB_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustTglCPB.ServerValidate

        If ((txtBatchSize.Text <> orgBatchSize.Text) OrElse (CDec(txtUmurProduk.Text) - CDec(orgUmurProduk.Text) <> 0)) Then
            If (CDate(txtTglCPB.Text) <> CDate(orgTglCPB.Text)) Then
                args.IsValid = True
            Else
                args.IsValid = False
            End If
        End If

    End Sub


    Protected Sub custNoCKB_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles custNoCKB.ServerValidate

        If ((txtBatchSize.Text <> orgBatchSize.Text) OrElse (CDec(txtUmurProduk.Text) - CDec(orgUmurProduk.Text) <> 0)) Then
            If (txtNoCKB.Text <> orgNoCKB.Text) Then
                args.IsValid = True
            Else
                args.IsValid = False
            End If
        End If

    End Sub

    Protected Sub custTglCKB_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles custTglCKB.ServerValidate

        If ((txtBatchSize.Text <> orgBatchSize.Text) OrElse (CDec(txtUmurProduk.Text) - CDec(orgUmurProduk.Text) <> 0)) Then
            If (CDate(txtTglCKB.Text) <> CDate(orgTglCKB.Text)) Then
                args.IsValid = True
            Else
                args.IsValid = False
            End If
        End If

    End Sub

    
End Class
