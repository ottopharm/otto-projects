Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class ChangeControl
    Private cn As SqlConnection
    Private cmd As SqlCommand

    Public Sub New()

        cn = New SqlConnection( _
            ConfigurationManager.ConnectionStrings("csOtto").ConnectionString)
        cmd = New SqlCommand
        cmd.Connection = cn
        cmd.CommandType = Data.CommandType.StoredProcedure

    End Sub

    Public Sub SaveChangeControl(ByVal NoCC As String, ByVal Produk As String, ByVal ItemCode As String, ByVal NoBatch As String, ByVal JenisPerubahan As String, _
            ByVal KategoriPerubahan As String, ByVal Status As String, ByVal Uraian As String, ByVal Alasan As String, ByVal Pengusul As String, ByVal Department As String, _
            ByVal TglPengajuan As Date, ByVal Disetujui As String, ByVal Pemberitahuan As String, ByVal Kesimpulan As String)

        cmd.CommandText = "QA_SaveChangeControl"
        With cmd.Parameters
            .AddWithValue("@NoCC", NoCC)
            .AddWithValue("@Produk", Produk)
            .AddWithValue("@ItemCode", ItemCode)
            .AddWithValue("@NoBatch ", NoBatch)
            .AddWithValue("@JenisPerubahan", JenisPerubahan)
            .AddWithValue("@KategoriPerubahan", KategoriPerubahan)
            .AddWithValue("@Status", Status)
            .AddWithValue("@Uraian", Uraian)
            .AddWithValue("@Alasan", Alasan)
            .AddWithValue("@Pengusul", Pengusul)
            .AddWithValue("@Department", Department)
            .AddWithValue("@TglPengajuan", TglPengajuan)
            .AddWithValue("@Disetujui", Disetujui)
            .AddWithValue("@Pemberitahuan", Pemberitahuan)
            .AddWithValue("@Kesimpulan", Kesimpulan)
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

    Public Function GetChangeControl(ByVal NoCC As String) As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "QA_GetChangeControl"
        With cmd.Parameters
            .AddWithValue("@NoCC", NoCC)
        End With

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
            da.Dispose()
            dt.Dispose()
        End Try

    End Function

    Public Sub DeleteChangeControl(ByVal NoCC As String)

        cmd.CommandText = "QA_DeleteChangeControl"
        With cmd.Parameters
            .AddWithValue("@NoCC", NoCC)
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

    Public Function GetChangeControlDetail(ByVal NoCC As String) As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        If NoCC IsNot Nothing Then

            cmd.CommandText = "QA_GetCCDetailByNoCC"
            With cmd.Parameters
                .AddWithValue("@NoCC", NoCC)
            End With

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
                da.Dispose()
                dt.Dispose()
            End Try

        End If

    End Function

    Public Sub SaveChangeControlDetail(ByVal Pelaksana As String, ByVal TglSelesai As Date, ByVal Tindakan As String, _
        ByVal Verifikasi As String, ByVal Email As String, ByVal IsClosed As Boolean, Optional ByVal LineID As Integer = 0, _
        Optional ByVal NoCC As String = "")

        cmd.CommandText = "QA_SaveCCDetail"
        With cmd.Parameters
            .AddWithValue("@NoCC", NoCC)
            .AddWithValue("@Pelaksana", Pelaksana)
            .AddWithValue("@TglSelesai", TglSelesai)
            .AddWithValue("@Tindakan", Tindakan)
            .AddWithValue("@Verifikasi", Verifikasi)
            .AddWithValue("@email", Email)
            .AddWithValue("@IsClosed", IsClosed)
            .AddWithValue("@LineID", LineID)
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

    Public Sub DeleteChangeControlDetail(ByVal LineID As Integer)

        cmd.CommandText = "QA_DeleteCCDetail"
        cmd.Parameters.AddWithValue("@LineID", LineID)

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

    Public Function GetDepartment() As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "Shared_GetDepartment"

        Try
            cn.Open()
            da.SelectCommand = cmd
            da.Fill(dt)

            Return dt

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Close()
            da.Dispose()
            dt.Dispose()
        End Try

    End Function

    Public Function GetDeptNameById(ByVal DeptId As Int16) As String
        Dim strDept As String

        cmd.CommandText = "Shared_GetDeptNameById"
        cmd.Parameters.AddWithValue("@DeptId", DeptId)

        Try
            cn.Open()
            strDept = cmd.ExecuteScalar()
            Return strDept

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

End Class
