
Partial Class QA_DataMaster_ProdukSpek
    Inherits System.Web.UI.Page

    Private oProdReview As New ProductReview
    Protected PostBackStr As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PostBackStr = Page.ClientScript.GetPostBackEventReference(Me, "PostBackFromClient")

        If IsPostBack Then
            Dim EventArg As String = Request("__EVENTARGUMENT")
            If EventArg = "PostBackFromClient" Then
                GetPBPOJ()
                GetProductName()
                txtParameter.Focus()
                oProdSpek.Select()
                BindGrid()
            End If
        End If
    End Sub

    Private Sub GetPBPOJ()
        Dim PBPOJ As List(Of String)

        PBPOJ = oProdReview.GetProdukPBPOJ(txtProdID.Text)

        If PBPOJ IsNot Nothing Then
            txtPBPOJ.Text = PBPOJ(0)  'NoPBPOJ
            If Not PBPOJ(1).Equals("") Then
                PBPOJ(1) = Format(CDate(PBPOJ(1)), "dd-MMM-yy")
            End If
            txtTglPBPOJ.Text = PBPOJ(1)    'TglPBPOJ
            txtRefPBPOJ.Text = "" & PBPOJ(2)    'RefPBPOJ
        End If

    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Try
            oProdSpek.Insert()
            BindGrid()
            txtParameter.Text = ""
            txtSpek.Text = ""

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

    Private Sub BindGrid()

        gvProdSpek.DataSourceID = "oProdSpek"
        gvProdSpek.DataBind()

    End Sub

    Private Sub ResetControls()

        txtProdID.Text = ""
        lblNamaProduk.Text = "."
        txtPBPOJ.Text = ""
        txtTglPBPOJ.Text = ""
        txtRefPBPOJ.Text = ""
        txtParameter.Text = ""
        txtSpek.Text = ""
        gvProdSpek.DataSourceID = ""

    End Sub

    Protected Sub gvProdSpek_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvProdSpek.RowCommand
        Dim btnUpdate As ImageButton = DirectCast(e.CommandSource, ImageButton)
        Dim row As GridViewRow = DirectCast(btnUpdate.NamingContainer, GridViewRow)
        Dim lblLineID As Label = DirectCast(row.FindControl("lblLineID"), Label)

        If e.CommandName = "Update" OrElse e.CommandName = "Delete" Then
            oProdSpek.InsertParameters("LineID").DefaultValue = lblLineID.Text
        End If

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            oProdReview.UpdatePBPOJ(txtProdID.Text, txtPBPOJ.Text, txtTglPBPOJ.Text, txtRefPBPOJ.Text)
            ResetControls()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub
End Class
