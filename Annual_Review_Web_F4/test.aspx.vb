Imports System.Text

Partial Class test
    Inherits System.Web.UI.Page

    Protected Sub txt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt.TextChanged

        txt1.Text = txt.Text

    End Sub


    Protected Sub txt2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt2.TextChanged

        txt21.Text = txt2.Text

    End Sub
End Class
