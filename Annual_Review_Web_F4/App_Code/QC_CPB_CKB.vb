Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class QC_CPB_CKB

    Private cn As SqlConnection
    Private cmd As SqlCommand

    Public Sub New()

        cn = New SqlConnection(ConfigurationManager.ConnectionStrings("csOtto").ConnectionString)
        cmd = New SqlCommand
        cmd.Connection = cn
        cmd.CommandType = Data.CommandType.StoredProcedure

    End Sub

    Public Function IsValidItem(ByVal ItemCode As String, ByVal ItemType As String) As Boolean

        cmd.CommandText = "Shared_ValidStock"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@ItemType", ItemType)

        Try
            cn.Open()
            IsValidItem = cmd.ExecuteScalar

        Catch ex As SqlException
            Throw ex
        Finally
            cmd.Parameters.Clear()
            cn.Close()
        End Try

    End Function

    Public Function IsValidBatch(ByVal ItemCode As String, ByVal NoBatch As String) As Boolean

        cmd.CommandText = "QA_ValidateBatch"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ItemCode)
            .AddWithValue("@NoBatch", NoBatch)
        End With

        Try
            cn.Open()
            IsValidBatch = cmd.ExecuteScalar

        Catch ex As SqlException
            Throw ex
        Finally
            cmd.Parameters.Clear()
            cn.Close()
        End Try

    End Function

    Public Function IsItemSalut(ByVal ItemCode As String) As Boolean

        cmd.CommandText = "QC_IsItemSalut"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)

        Try
            cn.Open()
            IsItemSalut = cmd.ExecuteScalar

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    Public Function GetKelengkapanDok(ByVal ItemCode As String, ByVal NoBatch As String) As Data.DataTable
        Dim dt As New Data.DataTable
        Dim da As New SqlDataAdapter

        cmd.CommandText = "QC_GetKelengkapanDok"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@NoBatch", NoBatch)

        da.SelectCommand = cmd

        Try
            cn.Open()
            da.Fill(dt)
            Return dt

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    Public Function GetItemSalut() As Data.DataTable
        Dim dt As New Data.DataTable
        Dim da As New SqlDataAdapter

        cmd.CommandText = "QC_GetItemSalut"
        da.SelectCommand = cmd

        Try
            cn.Open()
            da.Fill(dt)
            Return dt

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Close()
            dt.Dispose()
            da.Dispose()
        End Try

    End Function

    Public Function GetMPACetak() As Data.DataTable
        Dim dt As New Data.DataTable
        Dim da As New SqlDataAdapter

        cmd.CommandText = "QC_GetMPACetak"
        da.SelectCommand = cmd

        Try
            cn.Open()
            da.Fill(dt)
            Return dt

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Close()
            da.Dispose()
            da.Dispose()
        End Try

    End Function

    Public Sub SaveKelengkapanDok(ByVal ItemCode As String, ByVal NoBatch As String, ByVal CPS As Boolean, ByVal CoA As Boolean, _
        ByVal CC_Isi As Boolean, ByVal CC_Cetak As Boolean, ByVal CC_Primer As Boolean, ByVal CC_Salut As Boolean, ByVal Cream As Boolean, _
        ByVal Kemas As Boolean, ByVal SyrKering As Boolean, ByVal Syrup As Boolean, ByVal Sekunder As Boolean, ByVal Kadaluarsa As Boolean)

        cmd.CommandText = "QC_SaveKelengkapanDok"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ItemCode)
            .AddWithValue("@NoBatch", NoBatch)
            .AddWithValue("@CPS", CPS)
            .AddWithValue("@CoA", CoA)
            .AddWithValue("@CC_Isi", CC_Isi)
            .AddWithValue("@CC_Cetak", CC_Cetak)
            .AddWithValue("@CC_Primer", CC_Primer)
            .AddWithValue("@CC_Salut", CC_Salut)
            .AddWithValue("@Cream", Cream)
            .AddWithValue("@Kemas", Kemas)
            .AddWithValue("@SyrKering", SyrKering)
            .AddWithValue("@Syrup", Syrup)
            .AddWithValue("@Sekunder", Sekunder)
            .AddWithValue("@Kadaluarsa", Kadaluarsa)
        End With

        Try
            cn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try
    End Sub

    Public Sub SaveItemSalut(ByVal ItemCode As String)

        cmd.CommandText = "QC_SaveItemSalut"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)

        Try
            cn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Sub

    Public Sub SaveMPACetak(ByVal ItemCode As String)

        cmd.CommandText = "QC_SaveMPACetak"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)

        Try
            cn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Sub

    Public Sub DeleteItemSalut(ByVal ItemCode As String)

        cmd.CommandText = "QC_DeleteItemSalut"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)

        Try
            cn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Sub

    Public Sub DeleteMPACetak(ByVal ItemCode As String)

        cmd.CommandText = "QC_DeleteMPACetak"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)

        Try
            cn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Sub

End Class
