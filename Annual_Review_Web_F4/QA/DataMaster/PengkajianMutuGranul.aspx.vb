
Partial Class QA_DataMaster_PengkajianMutuGranul
    Inherits System.Web.UI.Page

    Dim oPengkajianMutu As New PengkajianMutu
    Dim oProduct As New ProductReview
    Protected PostBackStr As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PostBackStr = Page.ClientScript.GetPostBackEventReference(Me, "PostBackFromClient")

        If Not IsPostBack Then
            txtProdID.Text = Request.QueryString("itemcode")
            lblProdName.Text = oProduct.GetItemNameByCode(txtProdID.Text)
            txtNoBatch.Focus()
        Else
            Dim EventArg As String = Request("__EVENTARGUMENT")
            If EventArg = "PostBackFromClient" Then
                GetGranul()
            End If
        End If

    End Sub

    Private Sub GetGranul()
        Dim dt As New Data.DataTable

        Dim sGranulAPR As String = oPengkajianMutu.GetGranulFromAPR(txtProdID.Text, txtNoBatch.Text)
        Dim sItems() As String = sGranulAPR.Split("|")

        dt = oPengkajianMutu.GetGranul(PengkajianMutu.GranulDataType.Header, txtProdID.Text, txtNoBatch.Text)
        If dt.Rows.Count > 0 Then
            txtED.Text = dt.Rows(0)("ED")
            txtSpekSusut.Text = "" & dt.Rows(0)("SpekSusut")
            txtSusut.Text = dt.Rows(0)("Susut")
            txtBesarBatch.Text = If(IsDBNull(dt.Rows(0)("BesarBatch")), "", Format(dt.Rows(0)("BesarBatch"), "#.0"))
            ddlUoM.SelectedValue = If(IsDBNull(dt.Rows(0)("UoM")), "kg", dt.Rows(0)("UoM"))
            
            btnDelete.Enabled = True
            btnAdd.Enabled = True
            BindGrid()
        End If

        lblTglProduksi.Text = sItems(0)
        lblMixing.Text = sItems(1)
        txtBesarBatch.Focus()

    End Sub


    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            oPengkajianMutu.SaveGranulHDR(txtProdID.Text, txtNoBatch.Text, txtED.Text, _
                txtSpekSusut.Text, txtSusut.Text, txtBesarBatch.Text, ddlUoM.SelectedValue)
            ClearControls()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Try
            oPengkajianMutu.DeleteGranulHDR(txtProdID.Text, txtNoBatch.Text)
            ClearControls()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub gvGranul_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvGranul.RowCommand
        Dim btnSelect As LinkButton = DirectCast(e.CommandSource, LinkButton)
        Dim row As GridViewRow = DirectCast(btnSelect.NamingContainer, GridViewRow)
        Dim lblLineID As Label = DirectCast(row.FindControl("lblLineID"), Label)
        Dim lblSpekKadar As Label = DirectCast(row.FindControl("lblSpekKadar"), Label)
        Dim lblJenisKadar As Label = DirectCast(row.FindControl("lblJenisKadar"), Label)
        Dim lblHasilKadar As Label = DirectCast(row.FindControl("lblHasilKadar"), Label)

        If e.CommandName = "Select" Then
            txtSpekKadar.Text = lblSpekKadar.Text
            txtJenisKadar.Text = lblJenisKadar.Text
            txtHasilKadar.Text = lblHasilKadar.Text
            txtLineID.Text = lblLineID.Text
        End If

        btnAdd.Enabled = True
        btnHapus.Enabled = True

    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Try
            oPengkajianMutu.SaveGranulDTL(txtProdID.Text, txtNoBatch.Text, txtSpekKadar.Text, _
                txtJenisKadar.Text, txtHasilKadar.Text, txtLineID.Text)
            ClearDetailControls()
            BindGrid()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Protected Sub btnHapus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHapus.Click

        Try
            oPengkajianMutu.DeleteGranulDTL(txtLineID.Text)
            ClearDetailControls()
            BindGrid()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ClearControls()

        txtNoBatch.Text = ""
        txtED.Text = ""
        txtSpekSusut.Text = ""
        txtSusut.Text = ""
        lblTglProduksi.Text = ""
        lblMixing.Text = ""
        btnDelete.Enabled = False
        btnAdd.Enabled = False
        txtBesarBatch.Text = ""
        ddlUoM.SelectedIndex = 0
        gvGranul.DataSourceID = ""

        ClearDetailControls()

    End Sub

    Private Sub ClearDetailControls()

        txtSpekKadar.Text = ""
        txtJenisKadar.Text = ""
        txtHasilKadar.Text = ""
        txtLineID.Text = "0"
        btnHapus.Enabled = False

    End Sub

    Private Sub BindGrid()

        oGranul.SelectParameters("DataType").DefaultValue = 2
        oGranul.Select()
        gvGranul.DataSourceID = "oGranul"
        gvGranul.DataBind()

    End Sub
End Class
