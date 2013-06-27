
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
            dt = oProdReview.GetMasterListByCode(txtProdID.Text, "QA")
            If dt.Rows.Count > 0 Then
                'lblNamaProduk.Text = dt.Rows(0)("ProductName")
                ddlGol.SelectedValue = If(IsDBNull(dt.Rows(0)("Golongan")) OrElse dt.Rows(0)("Golongan") = "", _
                                    0, dt.Rows(0)("Golongan"))
                ddlStatus.SelectedValue = If(dt.Rows(0)("IsActive"), 1, 0)
                txtKomposisi.Text = "" & dt.Rows(0)("Komposisi")
                txtNIE.Text = "" & dt.Rows(0)("NIE")
                txtTglNIE.Text = If(IsDBNull(dt.Rows(0)("TglNIE")), String.Empty, _
                                Format(dt.Rows(0)("TglNIE"), "dd-MMM-yyyy"))
                txtEDNIE.Text = If(IsDBNull(dt.Rows(0)("EDNIE")), String.Empty, _
                                  Format(dt.Rows(0)("EDNIE"), "dd-MMM-yyyy"))
                txtUmurProduk.Text = "" & dt.Rows(0)("UmurProduk")
                txtKemasan.Text = "" & dt.Rows(0)("Kemasan")
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

            cal = If(String.IsNullOrEmpty(txtEDNIE.Text), Nothing, txtEDNIE.Text)

            oProdReview.SaveMasterListProduk(txtProdID.Text, CBool(ddlStatus.SelectedValue), txtNIE.Text, _
                ddlGol.SelectedValue, txtTglNIE.Text, cal, txtKomposisi.Text, CDec(txtUmurProduk.Text), txtKemasan.Text)

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

        ddlGol.SelectedValue = "0"
        txtProdID.Text = ""
        lblNamaProduk.Text = "."
        ddlStatus.SelectedValue = 1
        txtKomposisi.Text = ""
        txtNIE.Text = ""
        txtEDNIE.Text = ""
        txtTglNIE.Text = ""
        txtEDNIE.Text = ""
        txtUmurProduk.Text = ""
        txtKemasan.Text = ""

    End Sub

End Class
