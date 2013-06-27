
Partial Class QC_DataMaster_ProductReview_QC
    Inherits System.Web.UI.Page

    Private oProdReview As New ProductReview
    Private obj As New QC_CPB_CKB
    Protected PostBackStr As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        PostBackStr = Page.ClientScript.GetPostBackEventReference(Me, "PostBackFromClient")

        If Not IsPostBack Then
            If Request.QueryString("ProdID") IsNot Nothing Then
                Dim sItemType As String

                txtProdID.Text = Request.QueryString("ProdID")

                If Mid(txtProdID.Text, 1, 3) = "G00" Then
                    sItemType = "BB"
                Else
                    sItemType = "ST"
                End If

                lblProdName.Text = oProdReview.GetItemNameByCode(txtProdID.Text)

                KelengkapanDok()
                txtNoBatch.Focus()
            End If
        Else
            Dim EventArg As String = Request("__EVENTARGUMENT")
            If EventArg = "PostBackFromClient" Then
                GetDataQC()
                CekKelengkapanDok()
                txtEDmm.Focus()
            End If
        End If
    End Sub

    Private Sub GetDataQC()
        Dim dtQC As Data.DataTable

        Try
            dtQC = oProdReview.GetProductReview("QC", txtProdID.Text, txtNoBatch.Text)
            If dtQC.Rows.Count > 0 Then
                Dim sED() As String = dtQC.Rows(0)("ED").ToString.Split("-")
                If sED.Length > 1 Then
                    txtEDmm.Text = Trim(sED(0))
                    txtEDyy.Text = Trim(sED(1))
                Else
                    txtEDmm.Text = String.Empty
                    txtEDyy.Text = String.Empty
                End If

                txtCPBDate.Text = _
                    If(IsDBNull(dtQC.Rows(0)("TglCPB_QC")), String.Empty, _
                       Format(dtQC.Rows(0)("TglCPB_QC"), "dd-MMM-yy"))

                txtCKBDate.Text = _
                    If(IsDBNull(dtQC.Rows(0)("TglCKB_QC")), String.Empty, _
                       Format(dtQC.Rows(0)("TglCKB_QC"), "dd-MMM-yy"))

                txtBatch1.Text = If(IsDBNull(dtQC.Rows(0)("Batch1")), 0, dtQC.Rows(0)("Batch1"))
                txtBatch2.Text = If(IsDBNull(dtQC.Rows(0)("Batch2")), 0, dtQC.Rows(0)("Batch2"))
                txtCPBDoc.Text = "" & dtQC.Rows(0)("NoDocCPB")

                txtTglCPB.Text = _
                    If(IsDBNull(dtQC.Rows(0)("TglDocCPB")), String.Empty, _
                        Format(CDate(dtQC.Rows(0)("TglDocCPB")), "dd-MMM-yy"))
                txtKetCPB.Text = "" & dtQC.Rows(0)("KetCPB")

                txtCPBPDoc.Text = "" & dtQC.Rows(0)("NoDocCPBP")
                txtTglCPBP.Text = _
                    If(IsDBNull(dtQC.Rows(0)("TglDocCPBP")), String.Empty, _
                        Format(CDate(dtQC.Rows(0)("TglDocCPBP")), "dd-MMM-yy"))
                txtKetCPBP.Text = "" & dtQC.Rows(0)("KetCPBP")

                txtCKBPDoc.Text = "" & dtQC.Rows(0)("NoDocCKBP")
                txtTglCKBP.Text = _
                    If(IsDBNull(dtQC.Rows(0)("TglDocCKBP")), String.Empty, _
                        Format(CDate(dtQC.Rows(0)("TglDocCKBP")), "dd-MMM-yy"))
                txtKetCKBP.Text = "" & dtQC.Rows(0)("KetCKBP")

                txtCKBSDoc.Text = "" & dtQC.Rows(0)("NoDocCKBS")
                txtTglCKBS.Text = _
                    If(IsDBNull(dtQC.Rows(0)("TglDocCKBS")), String.Empty, _
                        Format(CDate(dtQC.Rows(0)("TglDocCKBS")), "dd-MMM-yy"))
                txtKetCKBS.Text = "" & dtQC.Rows(0)("KetCKBS")
            Else
                txtEDmm.Text = String.Empty
                txtEDyy.Text = String.Empty
                txtBatch1.Text = "0"
                txtBatch2.Text = "0"
                txtCPBDoc.Text = String.Empty
                txtTglCPB.Text = String.Empty
                txtKetCPB.Text = String.Empty
                txtCPBPDoc.Text = String.Empty
                txtTglCPBP.Text = String.Empty
                txtKetCPBP.Text = String.Empty
                txtCKBPDoc.Text = String.Empty
                txtTglCKBP.Text = String.Empty
                txtKetCKBP.Text = String.Empty
                txtCKBSDoc.Text = String.Empty
                txtTglCKBS.Text = String.Empty
                txtKetCKBS.Text = String.Empty
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        
        Try
            oProdReview.QC_UpdateProdReview(txtProdID.Text.ToUpper, txtNoBatch.Text.ToUpper, CDec(txtBatch1.Text), _
                CInt(txtBatch2.Text), txtEDmm.Text & "-" & txtEDyy.Text, txtCPBDate.Text, txtCKBDate.Text, txtCPBDoc.Text, _
                txtTglCPB.Text, txtKetCPB.Text, txtCPBPDoc.Text, txtTglCPBP.Text, txtKetCPBP.Text, _
                txtCKBPDoc.Text, txtTglCKBP.Text, txtKetCKBP.Text, txtCKBSDoc.Text, txtTglCKBS.Text, _
                txtKetCKBS.Text)

            'oProdReview.QC_UpdateProdReview(txtProdID.Text.ToUpper, txtNoBatch.Text.ToUpper, CDec(txtBatch1.Text), _
            '    CInt(txtBatch2.Text), txtEDmm.Text & "-" & txtEDyy.Text, txtCPBDate.Text, txtCKBDate.Text, CDate(txtProdDate.Text), txtCPBDoc.Text, _
            '    txtTglCPB.Text, txtKetCPB.Text, txtCPBPDoc.Text, txtTglCPBP.Text, txtKetCPBP.Text, _
            '    txtCKBPDoc.Text, txtTglCKBP.Text, txtKetCKBP.Text, txtCKBSDoc.Text, txtTglCKBS.Text, _
            '    txtKetCKBS.Text)

            obj.SaveKelengkapanDok(UCase(txtProdID.Text), UCase(txtNoBatch.Text), chkCPS.Checked, chkCoA.Checked, chkCCIsi.Checked, _
                chkCetak.Checked, chkPrimer.Checked, chkSalut.Checked, chkCream.Checked, chkKemas.Checked, chkSyrKering.Checked, _
                chkSyrup.Checked, chkSek.Checked, chkKad.Checked)
            'txtNoBatch.Text = String.Empty
            'ResetKelengkapan()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Protected Sub AutoComplete_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim AutoComplete As AjaxControlToolkit.AutoCompleteExtender = _
            DirectCast(sender, AjaxControlToolkit.AutoCompleteExtender)

        AutoComplete.ContextKey = txtProdID.Text

    End Sub

    Protected Sub txtCPBDoc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCPBDoc.TextChanged

        If txtCPBDoc.Text = String.Empty Then
            Exit Sub
        End If

        Try
            txtTglCPB.Text = oProdReview.GetTglDoc(txtProdID.Text, txtCPBDoc.Text, "CPB", txtNoBatch.Text)
            If String.IsNullOrEmpty(txtTglCPB.Text) Then
                txtTglCPB.Focus()
            Else
                txtKetCPB.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub txtCPBPDoc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCPBPDoc.TextChanged

        If txtCPBPDoc.Text = String.Empty Then
            Exit Sub
        End If

        Try
            txtTglCPBP.Text = oProdReview.GetTglDoc(txtProdID.Text, txtCPBPDoc.Text, "CPBP", txtNoBatch.Text)
            If String.IsNullOrEmpty(txtTglCPBP.Text) Then
                txtTglCPBP.Focus()
            Else
                txtKetCPBP.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub txtCKBPDoc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCKBPDoc.TextChanged

        If txtCKBPDoc.Text = String.Empty Then
            Exit Sub
        End If

        Try
            txtTglCKBP.Text = oProdReview.GetTglDoc(txtProdID.Text, txtCKBPDoc.Text, "CKBP", txtNoBatch.Text)
            If String.IsNullOrEmpty(txtTglCKBP.Text) Then
                txtTglCKBP.Focus()
            Else
                txtKetCKBP.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub txtCKBSDoc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCKBSDoc.TextChanged

        If txtCKBSDoc.Text = String.Empty Then
            Exit Sub
        End If

        Try
            txtTglCKBS.Text = oProdReview.GetTglDoc(txtProdID.Text, txtCKBSDoc.Text, "CKBS", txtNoBatch.Text)
            If String.IsNullOrEmpty(txtTglCKBS.Text) Then
                txtTglCKBS.Focus()
            Else
                txtKetCKBS.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub KelengkapanDok()
        Dim ItemGroup As String = UCase(Mid(txtProdID.Text, 1, 3))

        pnlCOA.Visible = True

        Select Case ItemGroup
            Case "G00", "MOT"
                pnlCPS.Visible = True
                pnlCCIsi.Visible = False
                pnlCetak.Visible = False
                pnlPrimer.Visible = False
                pnlCream.Visible = False
                pnlKemas.Visible = False
                pnlSalut.Visible = False
                pnlSyrKering.Visible = False
                pnlSyrup.Visible = False
                pnlSek.Visible = False
                pnlKad.Visible = False

            Case "INA", "SYK"
                pnlCPS.Visible = True
                pnlCCIsi.Visible = True
                pnlCetak.Visible = False
                pnlPrimer.Visible = False
                pnlCream.Visible = False
                pnlKemas.Visible = False
                pnlSalut.Visible = False
                pnlSyrKering.Visible = True
                pnlSyrup.Visible = False
                pnlSek.Visible = True
                pnlKad.Visible = True

            Case "INV"
                pnlCPS.Visible = False
                pnlCCIsi.Visible = True
                pnlCetak.Visible = False
                pnlPrimer.Visible = False
                pnlCream.Visible = False
                pnlKemas.Visible = False
                pnlSalut.Visible = False
                pnlSyrKering.Visible = False
                pnlSyrup.Visible = False
                pnlSek.Visible = False
                pnlKad.Visible = False

            Case "KPS"
                pnlCPS.Visible = True
                pnlCCIsi.Visible = True
                pnlCetak.Visible = False
                pnlPrimer.Visible = True
                pnlCream.Visible = False
                pnlKemas.Visible = True
                pnlSalut.Visible = False
                pnlSyrKering.Visible = False
                pnlSyrup.Visible = False
                pnlSek.Visible = True
                pnlKad.Visible = True

            Case "KPT", "TAB"
                pnlCPS.Visible = True
                pnlCCIsi.Visible = False
                pnlCetak.Visible = True
                pnlPrimer.Visible = True
                pnlCream.Visible = False
                pnlKemas.Visible = True
                pnlSyrKering.Visible = False
                pnlSyrup.Visible = False
                pnlSek.Visible = True
                pnlKad.Visible = True

                pnlSalut.Visible = If(obj.IsItemSalut(UCase(txtProdID.Text)), True, False)

            Case "MTR"
                pnlCPS.Visible = True
                pnlCream.Visible = False
                pnlSek.Visible = True
                pnlKad.Visible = True
                pnlSyrup.Visible = False

                Select Case UCase(txtProdID.Text)

                    Case "MTR001"
                        pnlCCIsi.Visible = True
                        pnlCetak.Visible = False
                        pnlPrimer.Visible = True
                        pnlKemas.Visible = True
                        pnlSalut.Visible = False
                        pnlSyrKering.Visible = False

                    Case "MTR002", "MTR004"
                        pnlCCIsi.Visible = True
                        pnlCetak.Visible = False
                        pnlPrimer.Visible = False
                        pnlKemas.Visible = False
                        pnlSalut.Visible = False
                        pnlSyrKering.Visible = True

                    Case "MTR003"
                        pnlCCIsi.Visible = False
                        pnlCetak.Visible = True
                        pnlPrimer.Visible = True
                        pnlKemas.Visible = True
                        pnlSalut.Visible = True
                        pnlSyrKering.Visible = False

                End Select

            Case "OIL"
                pnlCPS.Visible = True
                pnlCCIsi.Visible = True
                pnlCetak.Visible = False
                pnlPrimer.Visible = False
                pnlCream.Visible = True
                pnlKemas.Visible = False
                pnlSalut.Visible = False
                pnlSyrKering.Visible = False
                pnlSyrup.Visible = False
                pnlSek.Visible = True
                pnlKad.Visible = True

            Case "SYR"
                pnlCPS.Visible = True
                pnlCCIsi.Visible = True
                pnlCetak.Visible = False
                pnlPrimer.Visible = False
                pnlCream.Visible = False
                pnlKemas.Visible = False
                pnlSalut.Visible = False
                pnlSyrKering.Visible = False
                pnlSyrup.Visible = True
                pnlSek.Visible = True
                pnlKad.Visible = True

            Case "MKF", "MPF", "MPI"
                pnlCPS.Visible = True
                pnlCCIsi.Visible = True
                pnlCetak.Visible = False
                pnlPrimer.Visible = False
                pnlCream.Visible = False
                pnlKemas.Visible = True
                pnlSalut.Visible = False
                pnlSyrKering.Visible = False
                pnlSyrup.Visible = False
                pnlSek.Visible = True
                pnlKad.Visible = False

            Case "MPA"
                pnlCPS.Visible = True
                pnlPrimer.Visible = False
                pnlCream.Visible = False
                pnlKemas.Visible = True
                pnlSalut.Visible = False
                pnlSyrKering.Visible = False
                pnlSyrup.Visible = False
                pnlSek.Visible = True
                pnlKad.Visible = False

                Select Case UCase(txtProdID.Text)
                    Case "MPA037", "MPA039", "MPA041", "MPA042", "MPA044"
                        pnlCCIsi.Visible = False
                        pnlCetak.Visible = True
                    Case Else
                        pnlCCIsi.Visible = True
                        pnlCetak.Visible = False
                End Select

        End Select

    End Sub

    Private Sub CekKelengkapanDok()
        Dim dt As New Data.DataTable
        Dim row As Data.DataRow

        Try
            dt = obj.GetKelengkapanDok(UCase(txtProdID.Text), UCase(txtNoBatch.Text))
            If dt.Rows.Count > 0 Then
                row = dt.Rows(0)

                chkCoA.Checked = CBool(row("CoA"))
                Select Case UCase(Mid(txtProdID.Text, 1, 3))
                    Case "G00", "MOT"
                        chkCPS.Checked = CBool(row("CPS"))

                    Case "INA", "SYK"
                        chkCPS.Checked = CBool(row("CPS"))
                        chkCCIsi.Checked = CBool(row("CC_Isi"))
                        chkSyrKering.Checked = CBool(row("SyrKering"))
                        chkSek.Checked = CBool(row("Sekunder"))
                        chkKad.Checked = CBool(row("Kadaluarsa"))

                    Case "INV"
                        chkCCIsi.Checked = CBool(row("CC_Isi"))

                    Case "KPS"
                        chkCPS.Checked = CBool(row("CPS"))
                        chkCCIsi.Checked = CBool(row("CC_Isi"))
                        chkPrimer.Checked = CBool(row("CC_Primer"))
                        chkKemas.Checked = CBool(row("CC_Kemas"))
                        chkSek.Checked = CBool(row("Sekunder"))
                        chkKad.Checked = CBool(row("Kadaluarsa"))

                    Case "KPT", "TAB"
                        chkCPS.Checked = CBool(row("CPS"))
                        chkCetak.Checked = CBool(row("CC_Cetak"))
                        chkPrimer.Checked = CBool(row("CC_Primer"))
                        chkKemas.Checked = CBool(row("CC_Kemas"))
                        chkSek.Checked = CBool(row("Sekunder"))
                        chkKad.Checked = CBool(row("Kadaluarsa"))

                        If obj.IsItemSalut(UCase(txtProdID.Text)) Then
                            chkSalut.Checked = CBool(row("CC_Salut"))
                        End If
            
                    Case "OIL"
                        chkCPS.Checked = CBool(row("CPS"))
                        chkCCIsi.Checked = CBool(row("CC_Isi"))
                        chkCream.Checked = CBool(row("Cream"))
                        chkSek.Checked = CBool(row("Sekunder"))
                        chkKad.Checked = CBool(row("Kadaluarsa"))

                    Case "SYR"
                        chkCPS.Checked = CBool(row("CPS"))
                        chkCCIsi.Checked = CBool(row("CC_Isi"))
                        chkSyrup.Checked = CBool(row("Syrup"))
                        chkSek.Checked = CBool(row("Sekunder"))
                        chkKad.Checked = CBool(row("Kadaluarsa"))

                    Case "MTR"

                        Select Case UCase(txtProdID.Text)
                            Case "MTR001"
                                chkCPS.Checked = CBool(row("CPS"))
                                chkCCIsi.Checked = CBool(row("CC_Isi"))
                                chkPrimer.Checked = CBool(row("CC_Primer"))
                                chkKemas.Checked = CBool(row("CC_Kemas"))
                                chkSek.Checked = CBool(row("Sekunder"))
                                chkKad.Checked = CBool(row("Kadaluarsa"))

                            Case "MTR002", "MTR004"
                                chkCPS.Checked = CBool(row("CPS"))
                                chkCCIsi.Checked = CBool(row("CC_Isi"))
                                chkSyrKering.Checked = CBool(row("SyrKering"))
                                chkSek.Checked = CBool(row("Sekunder"))
                                chkKad.Checked = CBool(row("Kadaluarsa"))

                            Case "MTR003"
                                chkCPS.Checked = CBool(row("CPS"))
                                chkCetak.Checked = CBool(row("CC_Cetak"))
                                chkPrimer.Checked = CBool(row("CC_Primer"))
                                chkKemas.Checked = CBool(row("CC_Kemas"))
                                chkSalut.Checked = CBool(row("CC_Salut"))
                                chkSek.Checked = CBool(row("Sekunder"))
                                chkKad.Checked = CBool(row("Kadaluarsa"))

                        End Select

                    Case "MKF", "MPF", "MPI"
                        chkCPS.Checked = CBool(row("CPS"))
                        chkCCIsi.Checked = CBool(row("CC_Isi"))
                        chkKemas.Checked = CBool(row("CC_Kemas"))
                        chkSek.Checked = CBool(row("Sekunder"))

                    Case "MPA"
                        chkCPS.Checked = CBool(row("CPS"))
                        chkKemas.Checked = CBool(row("CC_Kemas"))
                        chkSek.Checked = CBool(row("Sekunder"))

                        Select Case UCase(txtProdID.Text)
                            Case "MPA037", "MPA039", "MPA041", "MPA042", "MPA044"
                                chkCetak.Checked = CBool(row("CC_Cetak"))
                            Case Else
                                chkCCIsi.Checked = CBool(row("CC_Isi"))
                        End Select
                End Select
            End If

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub ResetKelengkapan()

        chkCPS.Checked = False
        pnlCPS.Visible = False

        chkCoA.Checked = False
        pnlCOA.Visible = False

        chkCCIsi.Checked = False
        pnlCCIsi.Visible = False

        chkCetak.Checked = False
        pnlCetak.Visible = False

        chkPrimer.Checked = False
        pnlPrimer.Visible = False

        chkCream.Checked = False
        pnlCream.Visible = False

        chkKemas.Checked = False
        pnlKemas.Visible = False

        chkSalut.Checked = False
        pnlSalut.Visible = False

        chkSyrKering.Checked = False
        pnlSyrKering.Visible = False

        chkSyrup.Checked = False
        pnlSyrup.Visible = False

        chkSek.Checked = False
        pnlSek.Visible = False

        chkKad.Checked = False
        pnlKad.Visible = False

    End Sub

End Class
