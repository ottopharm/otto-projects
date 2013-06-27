
Partial Class QA_DataMaster_ProdukRetur
    Inherits System.Web.UI.Page

    Private oRetur As ProdukRetur
    Private oProdReview As ProductReview

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        oRetur = New ProdukRetur()
        oProdReview = New ProductReview()

    End Sub

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnFind.Click
        Dim dt As Data.DataTable

        dt = oRetur.CheckLPK(txtNoLPK.Text, txtProdID.Text, txtNoBatch.Text)

        If dt.Rows.Count > 0 Then
            GetProductName()
            lblDataNotFound.Visible = False
            txtJmlSampel.Focus()
            btnAdd.Enabled = True
            txtPPICLineID.Text = dt.Rows(0)("LineID")
            lblQty.Text = dt.Rows(0)("Qty")
            BindGrid()
        Else
            txtNoBatch.Text = ""
            txtProdID.Text = ""
            txtNoLPK.Focus()
            lblDataNotFound.Visible = True
            txtPPICLineID.Text = "0"
        End If

    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Try
            oRetur.SaveProdukRetur(txtPPICLineID.Text, txtJmlSampel.Text, _
                ddlCatEvaluasi.SelectedValue, txtHasilEvaluasi.Text, _
                ddlDisposisi.SelectedValue, txtLineID.Text)

            ResetControls()
            gvRetur.DataBind()

        Catch ex As Exception
            Throw ex
        End Try


    End Sub

    Protected Sub btnHapus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHapus.Click

        Try
            oRetur.DeleteProdukRetur(CInt(txtLineID.Text))
            DeleteLog("btnHapus")
            ResetControls()
            gvRetur.DataBind()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Protected Sub oProdRetur_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles oProdRetur.Selecting

        oProdRetur.SelectParameters(0).DefaultValue = txtPPICLineID.Text

    End Sub

    Protected Sub gvRetur_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvRetur.RowCommand
        Dim btnSelect As LinkButton = DirectCast(e.CommandSource, LinkButton)
        Dim row As GridViewRow = DirectCast(btnSelect.NamingContainer, GridViewRow)
        Dim lblLineID As Label = DirectCast(row.FindControl("lblLineID"), Label)
        Dim lblCatEvaluasi As Label = DirectCast(row.FindControl("lblCatEvaluasi"), Label)
        Dim lblDisposisi As Label = DirectCast(row.FindControl("lblDisposisi"), Label)
        Dim lblJmlSampel As Label = DirectCast(row.FindControl("lblJmlSampel"), Label)
        Dim lblHasilEvaluasi As Label = DirectCast(row.FindControl("lblHasilEvaluasi"), Label)

        If e.CommandName = "Select" Then
            txtJmlSampel.Text = lblJmlSampel.Text
            txtHasilEvaluasi.Text = lblHasilEvaluasi.Text
            txtLineID.Text = lblLineID.Text
            ddlCatEvaluasi.SelectedValue = lblCatEvaluasi.Text
            ddlDisposisi.SelectedValue = lblDisposisi.Text
            btnHapus.Enabled = True
        End If

    End Sub

    Protected Function GetEvalName(ByVal EvalCode As Byte) As String

        Try
            Return oRetur.GetEvalName(EvalCode)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Protected Function GetDisposisiName(ByVal DisposisiCode As Byte) As String

        Try
            Return oRetur.GetDisposisiName(DisposisiCode)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub GetProductName()

        Try

            lblProdName.Text = oProdReview.GetItemNameByCode(txtProdID.Text)

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub BindGrid()

        gvRetur.DataSourceID = "oProdRetur"
        oProdRetur.Select()
        gvRetur.DataBind()


    End Sub

    Private Sub ResetControls()

        txtJmlSampel.Text = "0"
        txtHasilEvaluasi.Text = ""
        ddlCatEvaluasi.SelectedIndex = "0"
        ddlDisposisi.SelectedIndex = "0"
        txtLineID.Text = "0"
        lblQty.Text = ""
        btnHapus.Enabled = False

    End Sub

    Private Sub DeleteLog(ByVal ComesFrom As String)

        Dim UserName As String = User.Identity.Name
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim IpAddr As String = System.Net.Dns.GetHostEntry(strHostName).HostName

        oRetur.SaveDeleteLog(txtNoLPK.Text, UserName, ComesFrom, IpAddr)

    End Sub

End Class
