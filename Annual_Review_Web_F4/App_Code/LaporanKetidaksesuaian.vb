Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class LaporanKetidaksesuaian
    Private cn As SqlConnection
    Private cmd As SqlCommand

    Public Sub New()

        cn = New SqlConnection( _
            ConfigurationManager.ConnectionStrings("csOtto").ConnectionString)
        cmd = New SqlCommand
        cmd.Connection = cn
        cmd.CommandType = Data.CommandType.StoredProcedure

    End Sub

    Public Sub SaveLaporanKetidaksesuaian(ByVal NoLK As String, ByVal IsClosed As String, ByVal Jenis As String, ByVal Produk As String, ByVal Manufaktur As String, _
                                          ByVal NoBatch As String, ByVal Sumber As String, ByVal SumberLain As String, ByVal AsalKeluhan As String, ByVal DetailAsalKeluhan As String, _
                                          ByVal KeluhanLain As String, ByVal Ketidaksesuaian As String, ByVal KetidaksesuaianLain As String, ByVal TglTerjadi As String, ByVal Rencana As String, _
                                          ByVal Dampak As String, ByVal YesDampak As String, ByVal JenisSediaan As String, ByVal Uraian As String, ByVal TindakanSementara As String, _
                                          ByVal Resiko As String, ByVal Pelapor As String, ByVal DepartemenPelapor As String, ByVal TglPelapor As String, ByVal Investigasi As String, _
                                          ByVal PenyebabPenyimpangan As String, ByVal PenyebabPenyimpanganLain As String, ByVal Perbaikan As String, ByVal IsClosedPerbaikan As String, ByVal TglPerbaikan As String, ByVal EmailPerbaikan As String, _
                                          ByVal PenanggungJawabPerbaikan As String, ByVal DepartemenPJPerbaikan As String, ByVal TindakanPerbaikan As String, ByVal IsClosedTPerbaikan As String, ByVal TglTindakanPerbaikan As String, _
                                          ByVal EmailTindakanPerbaikan As String, ByVal PenanggungJawabTindakanPerbaikan As String, ByVal DepartemenPJTPerbaikan As String, ByVal TindakanPencegahan As String, ByVal IsClosedTPencegahan As String, ByVal TglTindakanPencegahan As String, _
                                          ByVal EmailTindakanPencegahan As String, ByVal PenanggungJawabTindakanPencegahan As String, ByVal DepartemenPJTPencegahan As String, _
                                          ByVal KesimpulanPerbaikan As String, ByVal Verifikasi As String, ByVal KesimpulanVerifikasi As String, ByVal TglKesimpulanVerifikasi As String, ByVal TerbitBaru As String)

        cmd.CommandText = "QA_SaveLaporanKetidaksesuaian"
        With cmd.Parameters
            .AddWithValue("@NoLK", NoLK)
            .AddWithValue("@IsClosed", IsClosed)
            .AddWithValue("@Jenis", Jenis)
            .AddWithValue("@Produk", Produk)
            .AddWithValue("@Manufaktur", Manufaktur)
            .AddWithValue("@NoBatch", NoBatch)
            .AddWithValue("@Sumber", Sumber)
            .AddWithValue("@SumberLain", SumberLain)
            .AddWithValue("@AsalKeluhan", AsalKeluhan)
            .AddWithValue("@DetailAsalKeluhan", DetailAsalKeluhan)
            .AddWithValue("@KeluhanLain", KeluhanLain)
            .AddWithValue("@Ketidaksesuaian", Ketidaksesuaian)
            .AddWithValue("@KetidaksesuaianLain", KetidaksesuaianLain)
            .AddWithValue("@TglTerjadi", TglTerjadi)
            .AddWithValue("@Rencana", Rencana)
            .AddWithValue("@Dampak", Dampak)
            .AddWithValue("@YesDampak", YesDampak)
            .AddWithValue("@JenisSediaan", JenisSediaan)
            .AddWithValue("@Uraian", Uraian)
            .AddWithValue("@TindakanSementara", TindakanSementara)
            .AddWithValue("@Resiko", Resiko)
            .AddWithValue("@Pelapor", Pelapor)
            .AddWithValue("@DepartemenPelapor", DepartemenPelapor)
            .AddWithValue("@TglPelapor", TglPelapor)
            .AddWithValue("@Investigasi", Investigasi)
            .AddWithValue("@PenyebabPenyimpangan", PenyebabPenyimpangan)
            .AddWithValue("@PenyebabPenyimpanganLain", PenyebabPenyimpanganLain)
            .AddWithValue("@Perbaikan", Perbaikan)
            .AddWithValue("@IsClosedPerbaikan", IsClosedPerbaikan)
            .AddWithValue("@TglPerbaikan", TglPerbaikan)
            .AddWithValue("@EmailPerbaikan", EmailPerbaikan)
            .AddWithValue("@PenanggungJawabPerbaikan", PenanggungJawabPerbaikan)
            .AddWithValue("@DepartemenPJPerbaikan", DepartemenPJPerbaikan)
            .AddWithValue("@TindakanPerbaikan", TindakanPerbaikan)
            .AddWithValue("@IsClosedTPerbaikan", IsClosedTPerbaikan)
            .AddWithValue("@TglTindakanPerbaikan", TglTindakanPerbaikan)
            .AddWithValue("@EmailTindakanPerbaikan", EmailTindakanPerbaikan)
            .AddWithValue("@PenanggungJawabTindakanPerbaikan", PenanggungJawabTindakanPerbaikan)
            .AddWithValue("@DepartemenPJTPerbaikan", DepartemenPJTPerbaikan)
            .AddWithValue("@TindakanPencegahan", TindakanPencegahan)
            .AddWithValue("@IsClosedTPencegahan", IsClosedTPencegahan)
            .AddWithValue("@TglTindakanPencegahan", TglTindakanPencegahan)
            .AddWithValue("@EmailTindakanPencegahan", EmailTindakanPencegahan)
            .AddWithValue("@PenanggungJawabTindakanPencegahan", PenanggungJawabTindakanPencegahan)
            .AddWithValue("@DepartemenPJTPencegahan", DepartemenPJTPencegahan)
            .AddWithValue("@KesimpulanPerbaikan", KesimpulanPerbaikan)
            .AddWithValue("@Verifikasi", Verifikasi)
            .AddWithValue("@KesimpulanVerifikasi", KesimpulanVerifikasi)
            .AddWithValue("@TglKesimpulanVerifikasi", TglKesimpulanVerifikasi)
            .AddWithValue("@TerbitBaru", TerbitBaru)

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

    Public Function GetLaporanKetidaksesuaian(ByVal NoLK As String) As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "QA_GetLaporanKetidaksesuaian"
        With cmd.Parameters
            .AddWithValue("@NoLK", NoLK)
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


    Public Sub DeleteLaporanKetidaksesuaian(ByVal NoLK As String)

        cmd.CommandText = "QA_DeleteLaporanKetidaksesuaian"
        With cmd.Parameters
            .AddWithValue("@NoLK", NoLK)
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

    Public Function GetDepartement() As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "Shared_GetDepartement"

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
