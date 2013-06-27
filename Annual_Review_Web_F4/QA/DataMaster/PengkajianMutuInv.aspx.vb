
Partial Class QA_DataMaster_PengkajianMutuInv
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
                GetINV()
            End If
        End If

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim structInvHdr As New PengkajianMutu.InvHdr

        With structInvHdr
            .ItemCode = txtProdID.Text
            .Batch = txtNoBatch.Text
            .BesarBatch = If(txtBesarBatch.Text = "", Nothing, txtBesarBatch.Text)
            .UoM = ddlUoM.SelectedValue
            .Sterilitas = ddlSterilitas.SelectedValue
            .pHSpek = txtpHSpek.Text
            .pHHasil = If(txtpHHasil.Text = "", Nothing, txtpHHasil.Text)
            .PervialSpek = txtPervialSpek.Text
            .PervialAvg = If(txtPervialAvg.Text = "", Nothing, txtPervialAvg.Text)
            .PervialMin = If(txtPervialMin.Text = "", Nothing, txtPervialMin.Text)
            .PervialMax = If(txtPervialMaks.Text = "", Nothing, txtPervialMaks.Text)
            .SusutSpek = txtSusutSpek.Text
            .SusutHasil = If(txtSusutHasil.Text = "", Nothing, txtSusutHasil.Text)
            .EndotoksinSpek = txtEndotoksinSpek.Text
            .EndotoksinHasil = txtEndotoksinHasil.Text
        End With

        Try
            oPengkajianMutu.SaveInvHDR(structInvHdr)
            ClearControls()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnAddKadar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim DataInvKadar As New PengkajianMutu.InvKadar

        With DataInvKadar
            .ItemCode = txtProdID.Text
            .Batch = txtNoBatch.Text
            .Kadar = txtKadar.Text
            .KadarSpek = txtKadarSpek.Text
            .KadarHasil = txtKadarHasil.Text
            .LineID = txtKadarLineID.Text
        End With

        Try
            oPengkajianMutu.SaveInvKadar(DataInvKadar)
            ClearKadarDetailControls()
            BindKadar()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Protected Sub btnAddBobot_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddBobot.Click

        Dim DataInvBobot As New PengkajianMutu.InvBobot

        With DataInvBobot
            .ItemCode = txtProdID.Text
            .Batch = txtNoBatch.Text
            .JenisKeragamanBobot = txtKeragamanBobot.Text
            .MinMaxSpek = txtMinMaxSpek.Text
            .MinHasil = txtMinHasil.Text
            .MaxHasil = txtMaxHasil.Text
            .RSDSpek = txtRSDSpek.Text
            .RSDHasil = txtRSDHasil.Text
            .AVSpek = txtAVSpek.Text
            .AVHasil = txtAVHasil.Text
            .LineID = txtBobotLineID.Text
        End With

        Try
            oPengkajianMutu.SaveInvBobot(DataInvBobot)
            ClearBobotDetailControls()
            BindBobot()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub


    Protected Sub gvKadar_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvKadar.RowCommand

        Dim btnSelect As LinkButton = DirectCast(e.CommandSource, LinkButton)
        Dim row As GridViewRow = DirectCast(btnSelect.NamingContainer, GridViewRow)
        Dim lblLineID As Label = DirectCast(row.FindControl("lblLineID"), Label)
        Dim lblKadarSpek As Label = DirectCast(row.FindControl("lblSpekKadar"), Label)
        Dim lblKadar As Label = DirectCast(row.FindControl("lblKadar"), Label)
        Dim lblKadarHasil As Label = DirectCast(row.FindControl("lblKadarHasil"), Label)

        If e.CommandName = "Select" Then
            txtKadarSpek.Text = lblKadarSpek.Text
            txtKadar.Text = lblKadar.Text
            txtKadarHasil.Text = lblKadarHasil.Text
            txtKadarLineID.Text = lblLineID.Text
        End If

        btnAdd.Enabled = True
        btnHapus.Enabled = True

    End Sub

    Protected Sub gvBobot_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvBobot.RowCommand

        Dim btnSelect As LinkButton = DirectCast(e.CommandSource, LinkButton)
        Dim row As GridViewRow = DirectCast(btnSelect.NamingContainer, GridViewRow)
        Dim lblLineID As Label = DirectCast(row.FindControl("lblLineID"), Label)
        Dim lblBobot As Label = DirectCast(row.FindControl("lblBobot"), Label)
        Dim lblMinMaxSpek As Label = DirectCast(row.FindControl("lblMinMaxSpek"), Label)
        Dim lblMinHasil As Label = DirectCast(row.FindControl("lblMinHasil"), Label)
        Dim lblMaxHasil As Label = DirectCast(row.FindControl("lblMaxHasil"), Label)
        Dim lblRSDSpek As Label = DirectCast(row.FindControl("lblRSDSpek"), Label)
        Dim lblRSDHasil As Label = DirectCast(row.FindControl("lblRSDHasil"), Label)
        Dim lblAVDSpek As Label = DirectCast(row.FindControl("lblAVDSpek"), Label)
        Dim lblAVHasil As Label = DirectCast(row.FindControl("lblAVHasil"), Label)

        If e.CommandName = "Select" Then
            txtKeragamanBobot.Text = lblBobot.Text
            txtMinMaxSpek.Text = lblMinMaxSpek.Text
            txtMinHasil.Text = lblMinHasil.Text
            txtMaxHasil.Text = lblMaxHasil.Text
            txtRSDSpek.Text = lblRSDSpek.Text
            txtRSDHasil.Text = lblRSDHasil.Text
            txtAVSpek.Text = lblAVDSpek.Text
            txtAVHasil.Text = lblAVHasil.Text
            txtBobotLineID.Text = lblLineID.Text
        End If

        btnAddBobot.Enabled = True
        btnHapusBobot.Enabled = True

    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Try
            oPengkajianMutu.DeleteInvHDR(txtProdID.Text, txtNoBatch.Text)
            ClearControls()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnHapus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHapus.Click

        Try
            oPengkajianMutu.DeleteInvKadar(txtKadarLineID.Text)
            BindKadar()
            ClearKadarDetailControls()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Protected Sub btnHapusBobot_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHapusBobot.Click

        Try
            oPengkajianMutu.DeleteInvbobot(txtBobotLineID.Text)
            BindBobot()
            ClearBobotDetailControls()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub GetINV()

        Dim dt As New Data.DataTable

        Dim sInaAPR As String = oPengkajianMutu.GetINVFromAPR(txtProdID.Text, txtNoBatch.Text)
        Dim sItems() As String = sInaAPR.Split("|")

        dt = oPengkajianMutu.GetINV(PengkajianMutu.InvTargetTable.Header, txtProdID.Text, txtNoBatch.Text)

        If dt.Rows.Count > 0 Then
            txtBesarBatch.Text = "" & dt.Rows(0)("BesarBatch")
            ddlUoM.SelectedValue = dt.Rows(0)("UoM")
            ddlSterilitas.SelectedValue = dt.Rows(0)("Sterilitas")
            txtPervialSpek.Text = "" & dt.Rows(0)("PervialSpek")
            txtPervialAvg.Text = dt.Rows(0)("PervialAvg")
            txtPervialMin.Text = dt.Rows(0)("PervialMin")
            txtPervialMaks.Text = dt.Rows(0)("PervialMax")
            txtSusutSpek.Text = "" & dt.Rows(0)("SusutSpek")
            txtSusutHasil.Text = dt.Rows(0)("SusutHasil")
            txtpHSpek.Text = "" & dt.Rows(0)("pHSpek")
            txtpHHasil.Text = dt.Rows(0)("pHHasil")
            txtEndotoksinSpek.Text = "" & dt.Rows(0)("EndotoksinSpek")
            txtEndotoksinHasil.Text = "" & dt.Rows(0)("EndotoksinHasil")

            btnDelete.Enabled = True
            btnAdd.Enabled = True
            btnAddBobot.Enabled = True

            BindKadar()
            BindBobot()

        End If

        lblTglProduksi.Text = sItems(1)
        lblED.Text = sItems(0)
        lblJamKerja.Text = sItems(2)
        lblRendemen.Text = sItems(3)

        txtBesarBatch.Focus()

    End Sub

    Private Sub BindKadar()

        oKadar.Select()
        gvKadar.DataSourceID = "oKadar"
        gvKadar.DataBind()

    End Sub

    Private Sub BindBobot()

        oKadar.Select()
        gvBobot.DataSourceID = "oBobot"
        gvBobot.DataBind()

    End Sub

    Private Sub ClearControls()

        txtNoBatch.Text = ""
        txtBesarBatch.Text = ""
        ddlUoM.SelectedIndex = 0
        ddlSterilitas.SelectedIndex = 0
        txtPervialSpek.Text = ""
        txtPervialAvg.Text = ""
        txtPervialMin.Text = ""
        txtPervialMaks.Text = ""
        txtSusutSpek.Text = ""
        txtSusutHasil.Text = ""
        txtpHSpek.Text = ""
        txtpHHasil.Text = ""
        txtEndotoksinSpek.Text = ""
        txtEndotoksinHasil.Text = ""

        lblED.Text = "."
        lblJamKerja.Text = "."
        lblRendemen.Text = "."
        lblTglProduksi.Text = "."

        gvKadar.DataSourceID = ""
        gvBobot.DataSourceID = ""

        btnDelete.Enabled = False
        btnAdd.Enabled = False
        btnAddBobot.Enabled = False

        ClearKadarDetailControls()
        ClearBobotDetailControls()

    End Sub

    Private Sub ClearKadarDetailControls()

        txtKadarSpek.Text = ""
        txtKadar.Text = ""
        txtKadarHasil.Text = ""
        txtKadarLineID.Text = "0"
        btnHapus.Enabled = False

    End Sub

    Private Sub ClearBobotDetailControls()

        txtKeragamanBobot.Text = ""
        txtMinMaxSpek.Text = ""
        txtMinHasil.Text = ""
        txtMaxHasil.Text = ""
        txtRSDSpek.Text = ""
        txtRSDHasil.Text = ""
        txtAVSpek.Text = ""
        txtAVHasil.Text = ""
        txtBobotLineID.Text = "0"
        btnHapusBobot.Enabled = False

    End Sub

    
    
 
End Class
