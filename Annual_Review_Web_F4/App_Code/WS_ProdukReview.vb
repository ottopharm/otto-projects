Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data.SqlClient

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WS_ProdukReview
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
    Public Function ValidateProdID(ByVal ProdID As String) As Boolean
        Dim isValid As Boolean

        cmd.CommandText = "QA_ValidateProdID"
        cmd.Parameters.AddWithValue("@ProdID", ProdID)

        Try
            cn.Open()
            isValid = cmd.ExecuteScalar
            Return isValid

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    <WebMethod()> _
    Public Function ValidateNoBatch(ByVal NoBatch As String, ByVal ItemCode As String) As Boolean
        Dim isValidBatch As Boolean

        cmd.CommandText = "QA_ValidateBatch"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ItemCode)
            .AddWithValue("@NoBatch", NoBatch)
        End With

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

    <WebMethod()> _
    Public Function CekBatchDN(ByVal NoBatch As String, ByVal ItemCode As String) As Boolean
        Dim isValidBatch As Boolean

        cmd.CommandText = "PPIC_CekBatchDN"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ItemCode)
            .AddWithValue("@NoBatch", NoBatch)
        End With

        Try
            cn.Open()
            isValidBatch = cmd.ExecuteScalar()

            Return isValidBatch

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    <WebMethod()> _
    Public Function GetProdNameByCode(ByVal ProdID As String) As String
        Dim prodName As String

        cmd.CommandText = "Shared_GetItemNameByCode"
        cmd.Parameters.AddWithValue("@ItemCode", ProdID)

        Try
            cn.Open()
            prodName = "" & cmd.ExecuteScalar()
            Return prodName

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    <WebMethod()> _
    Public Function GetListDocCPB(ByVal prefixText As String, ByVal count As Int16, ByVal contextKey As String) As String()
        Dim dr As SqlDataReader
        Dim lsDoc As New List(Of String)

        prefixText += "%"
        cmd.CommandText = "QC_GetListDocCPBCKB"
        With cmd.Parameters
            .AddWithValue("@PrefixText", prefixText)
            .AddWithValue("@ItemCode", contextKey)
            .AddWithValue("@DocType", "CPB")
        End With

        Try
            cn.Open()
            dr = cmd.ExecuteReader
            Dim i As Int16 = 0
            Do While dr.Read
                lsDoc.Add(dr("NoDoc"))
                i += 1
                If i > count Then
                    Exit Do
                End If
            Loop
            dr.Close()
            Return lsDoc.ToArray

        Catch ex As Exception
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    <WebMethod()> _
    Public Function GetListDocCPBP(ByVal prefixText As String, ByVal count As Int16, ByVal contextKey As String) As String()
        Dim dr As SqlDataReader
        Dim lsDoc As New List(Of String)

        prefixText += "%"
        cmd.CommandText = "QC_GetListDocCPBCKB"
        With cmd.Parameters
            .AddWithValue("@PrefixText", prefixText)
            .AddWithValue("@ItemCode", contextKey)
            .AddWithValue("@DocType", "CPBP")
        End With

        Try
            cn.Open()
            dr = cmd.ExecuteReader
            Dim i As Int16 = 0
            Do While dr.Read
                lsDoc.Add(dr("NoDoc"))
                i += 1
                If i > count Then
                    Exit Do
                End If
            Loop
            dr.Close()
            Return lsDoc.ToArray

        Catch ex As Exception
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    <WebMethod()> _
    Public Function GetListDocCKBP(ByVal prefixText As String, ByVal count As Int16, ByVal contextKey As String) As String()
        Dim dr As SqlDataReader
        Dim lsDoc As New List(Of String)

        prefixText += "%"
        cmd.CommandText = "QC_GetListDocCPBCKB"
        With cmd.Parameters
            .AddWithValue("@PrefixText", prefixText)
            .AddWithValue("@ItemCode", contextKey)
            .AddWithValue("@DocType", "CKBP")
        End With

        Try
            cn.Open()
            dr = cmd.ExecuteReader
            Dim i As Int16 = 0
            Do While dr.Read
                lsDoc.Add(dr("NoDoc"))
                i += 1
                If i > count Then
                    Exit Do
                End If
            Loop
            dr.Close()
            Return lsDoc.ToArray

        Catch ex As Exception
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    <WebMethod()> _
    Public Function GetListDocCKBS(ByVal prefixText As String, ByVal count As Int16, ByVal contextKey As String) As String()
        Dim dr As SqlDataReader
        Dim lsDoc As New List(Of String)

        prefixText += "%"
        cmd.CommandText = "QC_GetListDocCPBCKB"
        With cmd.Parameters
            .AddWithValue("@PrefixText", prefixText)
            .AddWithValue("@ItemCode", contextKey)
            .AddWithValue("@DocType", "CKBS")
        End With

        Try
            cn.Open()
            dr = cmd.ExecuteReader
            Dim i As Int16 = 0
            Do While dr.Read
                lsDoc.Add(dr("NoDoc"))
                i += 1
                If i > count Then
                    Exit Do
                End If
            Loop
            dr.Close()
            Return lsDoc.ToArray

        Catch ex As Exception
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    Public Function GetListBatch1(ByVal prefixText As String, ByVal count As Int16, ByVal contextKey As String) As String()
        Dim dr As SqlDataReader
        Dim lsBatch As New List(Of String)

        prefixText += "%"
        cmd.CommandText = "QC_GetListBatch"
        With cmd.Parameters
            .AddWithValue("@PrefixText", prefixText)
            .AddWithValue("@ItemCode", contextKey)
            .AddWithValue("@BatchType", "1")
        End With

        Try
            cn.Open()
            dr = cmd.ExecuteReader
            Dim i As Int16 = 0
            Do While dr.Read
                lsBatch.Add(dr("BatchSize"))
                i += 1
                If i > count Then
                    Exit Do
                End If
            Loop
            dr.Close()
            Return lsBatch.ToArray

        Catch ex As Exception
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    Public Function GetListBatch2(ByVal prefixText As String, ByVal count As Int16, ByVal contextKey As String) As String()
        Dim dr As SqlDataReader
        Dim lsBatch As New List(Of String)

        prefixText += "%"
        cmd.CommandText = "QC_GetListBatch"
        With cmd.Parameters
            .AddWithValue("@PrefixText", prefixText)
            .AddWithValue("@ItemCode", contextKey)
            .AddWithValue("@BatchType", "2")
        End With

        Try
            cn.Open()
            dr = cmd.ExecuteReader
            Dim i As Int16 = 0
            Do While dr.Read
                lsBatch.Add(dr("BatchSize"))
                i += 1
                If i > count Then
                    Exit Do
                End If
            Loop
            dr.Close()
            Return lsBatch.ToArray

        Catch ex As Exception
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    <WebMethod()> _
    Public Function ValidateMasterListProd(ByVal ProdID As String) As Boolean
        Dim isValid As Boolean

        cmd.CommandText = "Shared_ValidateMasterListProdID"
        cmd.Parameters.AddWithValue("@ProdID", ProdID)

        Try
            cn.Open()
            isValid = cmd.ExecuteScalar
            Return isValid

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

End Class
