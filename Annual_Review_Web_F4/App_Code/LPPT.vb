Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class LPPT
    Private cn As SqlConnection
    Private cmd As SqlCommand

    Public Sub New()

        cn = New SqlConnection( _
            ConfigurationManager.ConnectionStrings("csOtto").ConnectionString)
        cmd = New SqlCommand
        cmd.Connection = cn
        cmd.CommandType = Data.CommandType.StoredProcedure

    End Sub

    Public Sub SaveLPPT(ByVal NoLPPT As String, ByVal Produk As String, ByVal ItemCode As String, ByVal NoBatch As String, _
        ByVal TglSimpang As DateTime, ByVal Penyimpangan As String, ByVal Tindakan As String, ByVal Pelapor As String, ByVal TglLapor As DateTime, _
        ByVal TindakanPerbaikan As String, ByVal AkarMasalah As String, ByVal Perbaikan As String, ByVal Pencegahan As String, ByVal Kesimpulan As String)

        cmd.CommandText = "QA_SaveLPPT"
        With cmd.Parameters
            .AddWithValue("@NoLPPT", NoLPPT)
            .AddWithValue("@Produk", Produk)
            .AddWithValue("@ItemCode", ItemCode)
            .AddWithValue("@NoBatch ", NoBatch)
            .AddWithValue("@TglSimpang", TglSimpang)
            .AddWithValue("@Penyimpangan", Penyimpangan)
            .AddWithValue("@Tindakan", Tindakan)
            .AddWithValue("@Pelapor", Pelapor)
            .AddWithValue("@TglLapor", TglLapor)
            .AddWithValue("@TindakanPerbaikan", TindakanPerbaikan)
            .AddWithValue("@AkarMasalah", AkarMasalah)
            .AddWithValue("@Perbaikan", Perbaikan)
            .AddWithValue("@Pencegahan", Pencegahan)
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

    Public Function GetLPPT(ByVal NoLPPT As String) As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "QA_GetLPPT"
        With cmd.Parameters
            .AddWithValue("@NoLPPT", NoLPPT)
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

    Public Sub DeleteLPPT(ByVal NoLPPT As String)

        cmd.CommandText = "QA_DeleteLPPT"
        With cmd.Parameters
            .AddWithValue("@NoLPPT", NoLPPT)
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

End Class
