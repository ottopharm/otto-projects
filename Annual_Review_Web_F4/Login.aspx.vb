
Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub Login_Authenticate(ByVal sender As Object, ByVal e As AuthenticateEventArgs)

        If Membership.ValidateUser(UserLogin.UserName, UserLogin.Password) Then

            e.Authenticated = True
            UserLogin.RememberMeSet = True
            If Roles.IsUserInRole(UserLogin.UserName, "AdminQC") Then
                Session("DeptID") = "QC"
            ElseIf Roles.IsUserInRole(UserLogin.UserName, "AdminQA") Then
                Session("DeptID") = "QA"
            ElseIf Roles.IsUserInRole(UserLogin.UserName, "AdminProduksi") Then
                Session("DeptID") = "PRD"
            ElseIf Roles.IsUserInRole(UserLogin.UserName, "adminRD") Then
                Session("DeptID") = "RD"
            ElseIf Roles.IsUserInRole(UserLogin.UserName, "adminLogistik") OrElse _
                Roles.IsUserInRole(UserLogin.UserName, "UserLogistik") Then
                Session("DeptID") = "LOG"
            Else
                e.Authenticated = False
            End If
        Else
            UserLogin.FailureText = "Invalid user name / password"
            e.Authenticated = False
        End If

    End Sub

End Class
