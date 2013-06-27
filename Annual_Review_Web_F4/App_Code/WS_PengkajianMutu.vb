Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data.SqlClient

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WS_PengkajianMutu
    Inherits System.Web.Services.WebService

    Private cn As SqlConnection
    Private cmd As SqlCommand

    Public Sub New()

        cn = New SqlConnection( _
        ConfigurationManager.ConnectionStrings("csOtto").ConnectionString)

        cmd = New SqlCommand
        cmd.Connection = cn
        cmd.CommandType = Data.CommandType.StoredProcedure

    End Sub

    <WebMethod()> _
    Public Function ValidateItemCode(ByVal ItemCode As String) As Boolean
        Dim dr As SqlDataReader

        cmd.CommandText = "QA_PengkajianValidateItemCode"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)

        Try
            cn.Open()
            dr = cmd.ExecuteReader()
            dr.Read()

            Return CBool(dr(0))

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Close()
            dr.Close()
            cmd.Parameters.Clear()

        End Try

    End Function

    <WebMethod()> _
    Public Function ValidateBatch(ByVal Batch As String, ByVal ItemCode As String) As Boolean
        Dim isValidBatch As Boolean

        cmd.CommandText = "QA_PengkajianValidateBatch"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

        Try
            cn.Open()
            isValidBatch = cmd.ExecuteScalar
            Return isValidBatch

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

End Class
