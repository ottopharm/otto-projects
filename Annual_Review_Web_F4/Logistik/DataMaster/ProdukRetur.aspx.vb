
Partial Class Logistic_DataMaster_ProdukRetur
    Inherits System.Web.UI.Page

    Private oRetur As New ProdukRetur
    Private oPR As New ProductReview

    Protected PostBackStr As String

    Dim userRole As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PostBackStr = Page.ClientScript.GetPostBackEventReference(Me, "PostBackFromClient")

        Dim arrRoles As String() = Roles.GetRolesForUser(User.Identity.Name)

        If IsPostBack Then
            Dim EventArg As String = Request("__EVENTARGUMENT")
            If EventArg = "PostBackFromClient" Then
                If Not String.IsNullOrEmpty(txtNoLPK.Text) Then
                    GetDataLPK()
                    BindGrid()
                End If
            End If
        Else
            If arrRoles.Contains("AdminLogistik") Then
                userRole = "admin"
                ddlPenggantian.SelectedIndex = 0
                ddlPenggantian.Enabled = True
            Else
                userRole = "user"
                ddlPenggantian.SelectedIndex = 2
                ddlPenggantian.Enabled = False
            End If
        End If
    End Sub

    Private Sub GetDataLPK()
        Dim dt As New Data.DataTable

        Try
            dt = oRetur.GetProdukReturByLPK(txtNoLPK.Text)
            If dt.Rows.Count > 0 Then
                txtNoLPK.Text = dt.Rows(0)("NoLPK")
                txtTglLPK.Text = Format(CDate(dt.Rows(0)("TglLPK")), "dd-MMM-yy")
                ddlAsalMBS.SelectedValue = dt.Rows(0)("AsalMBS")
                txtNoSPPB.Text = dt.Rows(0)("NoSPPB")
                btnAdd.Enabled = True
                btnDelete.Enabled = True
            Else
                Dim sTemp As String = txtNoLPK.Text
                ClearControls()
                txtNoLPK.Text = sTemp
                txtTglLPK.Focus()

            End If

        Catch ex As Exception
            Throw ex
        Finally
            dt.Dispose()
        End Try

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try

            oRetur.SaveProdukRetur(txtNoLPK.Text.ToUpper, txtTglLPK.Text, ddlAsalMBS.SelectedValue, txtNoSPPB.Text.ToUpper)
            ClearControls()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Try
            If Not String.IsNullOrEmpty(txtProdID.Text) Then

                oRetur.SaveProdukReturDetail(txtNoLPK.Text.ToUpper, txtProdID.Text.ToUpper, hideProdName.Value, ddlUoM.SelectedValue, _
                    txtQty.Text, txtNoBatch.Text.ToUpper, ddlPenggantian.SelectedValue, txtKeterangan.Text, lblLineID.Text)

                ResetDetailControls()
                BindGrid()
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If Not String.IsNullOrEmpty(txtNoLPK.Text) Then
            Try
                oRetur.DeleteProdukRetur(txtNoLPK.Text)
                DeleteLog("btnDelete")
                ClearControls()

            Catch ex As Exception
                Throw ex
            End Try
        End If

    End Sub

    Protected Sub btnHapus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHapus.Click

        If Not String.IsNullOrEmpty(txtNoLPK.Text) Then
            Try
                oRetur.DeleteProdukReturDetail(lblLineID.Text)
                DeleteLog("btnHapus")
                ResetDetailControls()
                BindGrid()

            Catch ex As Exception
                Throw ex
            End Try
        End If

    End Sub

    Protected Sub gvRetur_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvRetur.RowCommand
        Dim btnSelect As LinkButton = DirectCast(e.CommandSource, LinkButton)
        Dim row As GridViewRow = DirectCast(btnSelect.NamingContainer, GridViewRow)
        Dim LineID As Label = DirectCast(row.FindControl("lblLineID"), Label)
        Dim lblProdID As Label = DirectCast(row.FindControl("lblProdID"), Label)
        Dim lblProdName1 As Label = DirectCast(row.FindControl("lblProdName"), Label)
        Dim lblUoM As Label = DirectCast(row.FindControl("lblUoM"), Label)
        Dim lblQty As Label = DirectCast(row.FindControl("lblQty"), Label)
        Dim lblBatch As Label = DirectCast(row.FindControl("lblBatch"), Label)
        Dim lblPenggantian As Label = DirectCast(row.FindControl("lblPenggantian"), Label)
        Dim lblKeterangan As Label = DirectCast(row.FindControl("lblKeterangan"), Label)

        If e.CommandName = "Select" Then
            lblLineID.Text = LineID.Text
            txtProdID.Text = lblProdID.Text
            lblProdName.Text = lblProdName1.Text
            hideProdName.Value = lblProdName1.Text
            ddlUoM.SelectedValue = lblUoM.Text
            txtQty.Text = lblQty.Text
            txtNoBatch.Text = lblBatch.Text
            txtKeterangan.Text = lblKeterangan.Text

            If lblPenggantian.Text = "Diganti" Then
                ddlPenggantian.SelectedValue = "D"
            ElseIf lblPenggantian.Text = "Tidak Diganti" Then
                ddlPenggantian.SelectedValue = "T"
            Else
                ddlPenggantian.SelectedValue = "N"
            End If

            btnHapus.Enabled = True
        End If

    End Sub

    Protected Function GetPenggantian(ByVal CodePenggantian As String) As String

        Select Case (CodePenggantian)
            Case "T"
                Return "Tidak Diganti"
            Case "D"
                Return "Diganti"
            Case "N"
                Return "NONE"
            Case Else
                Return ""
        End Select

    End Function

    Private Sub ClearControls()

        txtNoLPK.Text = ""
        txtTglLPK.Text = ""
        ddlAsalMBS.SelectedIndex = 0
        txtNoSPPB.Text = ""
        btnDelete.Enabled = False
        ResetDetailControls()
        gvRetur.DataSource = Nothing
        btnAdd.Enabled = False

    End Sub

    Private Sub ResetDetailControls()

        txtProdID.Text = ""
        lblProdName.Text = ""
        txtNoBatch.Text = ""
        ddlUoM.SelectedIndex = "0"
        txtQty.Text = ""
        txtNoBatch.Text = ""
        lblLineID.Text = "0"
        txtKeterangan.Text = ""
        btnHapus.Enabled = False

        If userRole = "admin" Then
            ddlPenggantian.SelectedIndex = 0
        Else
            ddlPenggantian.SelectedIndex = 2
        End If

    End Sub

    Private Sub BindGrid()

        oReturDetail.Select()
        gvRetur.DataSourceID = "oReturDetail"
        gvRetur.DataBind()

    End Sub

    Private Sub DeleteLog(ByVal ComesFrom As String)

        Dim UserName As String = User.Identity.Name
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim IpAddr As String = System.Net.Dns.GetHostEntry(strHostName).HostName

        oRetur.SaveDeleteLog(txtNoLPK.Text, UserName, ComesFrom, IpAddr)

    End Sub



End Class
