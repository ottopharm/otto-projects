Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class ProdukRetur

    Dim cn As SqlConnection
    Dim cmd As SqlCommand

    Enum EDept
        PPIC = 1
        QA = 2
    End Enum

    Public Sub New()

        cn = New SqlConnection( _
            ConfigurationManager.ConnectionStrings("csOtto").ConnectionString)
        cmd = New SqlCommand()
        cmd.Connection = cn
        cmd.CommandType = Data.CommandType.StoredProcedure

    End Sub

#Region "PPIC"

    Public Function GetProdukReturByLPK(ByVal NoLPK As String) As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "PPIC_GetProdukReturByLPK"
        cmd.Parameters.AddWithValue("@NoLPK", NoLPK)

        Try
            cn.Open()
            da.SelectCommand = cmd
            da.Fill(dt)

            Return dt

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
            da = Nothing
            dt = Nothing
        End Try
    End Function

    Public Function GetProdukReturDetail(ByVal NoLPK As String, ByVal Dept As EDept) As Data.DataTable

        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        Try

            If Not NoLPK Is Nothing Then

                If Dept = EDept.PPIC Then
                    cmd.CommandText = "PPIC_GetProdukReturDetailByLPK"
                Else
                    cmd.CommandText = "QA_GetProdukReturByLPK"
                End If

                cmd.Parameters.AddWithValue("@NoLPK", NoLPK)


                cn.Open()
                da.SelectCommand = cmd
                da.Fill(dt)

            End If
            Return dt

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
            da = Nothing
            dt = Nothing
        End Try

    End Function

    Public Sub SaveProdukRetur(ByVal NoLPK As String, ByVal TglLPK As Date, ByVal AsalMBS As Integer, ByVal NoSPPB As String)

        cmd.CommandText = "PPIC_SaveProdukRetur"
        With cmd.Parameters
            .AddWithValue("@NoLPK", NoLPK)
            .AddWithValue("@TglLPK", TglLPK)
            .AddWithValue("@AsalMBS", AsalMBS)
            .AddWithValue("@NoSPPB", NoSPPB)
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

    Public Sub SaveProdukReturDetail(ByVal NoLPK As String, ByVal ItemCode As String, ByVal ProdName As String, ByVal UoM As String, _
        ByVal Qty As Integer, ByVal Batch As String, ByVal Penggantian As String, ByVal Keterangan As String, Optional ByVal LineID As Integer = 0)

        cmd.CommandText = "PPIC_SaveProdukReturDetail"
        With cmd.Parameters
            .AddWithValue("@NoLPK", NoLPK)
            .AddWithValue("@ItemCode", ItemCode)
            .AddWithValue("@ProdName", ProdName)
            .AddWithValue("@UoM", UoM)
            .AddWithValue("@Qty", Qty)
            .AddWithValue("@Batch", Batch)
            .AddWithValue("@Penggantian", Penggantian)
            .AddWithValue("@Keterangan", Keterangan)
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

    Public Sub DeleteProdukRetur(ByVal NoLPK As String)

        cmd.CommandText = "PPIC_DeleteProdukRetur"
        cmd.Parameters.AddWithValue("@NoLPK", NoLPK)

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

    Public Sub DeleteProdukReturDetail(ByVal LineID As String)

        cmd.CommandText = "PPIC_DeleteProdukReturDetail"
        cmd.Parameters.AddWithValue("@LineID", LineID)

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

    Public Function GetAllCabangMBS() As Data.DataTable

        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable


        cmd.CommandText = "PPIC_GetAllCabangMBS"

        Try
            cn.Open()
            da.SelectCommand = cmd
            da.Fill(dt)

            Return dt

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
            da = Nothing
            dt = Nothing
        End Try

    End Function

#End Region

#Region "QA"

    Public Sub SaveProdukRetur(ByVal PPIC_LineID As Integer, ByVal JmlSampel As Integer, ByVal CatEvaluasi As Byte, _
        ByVal HasilEvaluasi As String, ByVal Disposisi As Byte, ByVal LineID As Integer)

        cmd.CommandText = "QA_SaveProdukRetur"
        With cmd.Parameters
            .AddWithValue("@PPIC_LineID", PPIC_LineID)
            .AddWithValue("@JmlSampel", JmlSampel)
            .AddWithValue("CatEvaluasi", CatEvaluasi)
            .AddWithValue("@HasilEvaluasi", HasilEvaluasi)
            .AddWithValue("@Disposisi", Disposisi)
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

    Public Function GetProdukRetur(ByVal PPIC_LineID As Integer) As Data.DataTable

        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "QA_GetProdukRetur"
        cmd.Parameters.AddWithValue("@PPIC_LineID", PPIC_LineID)

        Try

            cn.Open()
            da.SelectCommand = cmd
            da.Fill(dt)

            Return dt

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
            da = Nothing
            dt = Nothing
        End Try

    End Function

    Public Function CheckLPK(ByVal NoLPK As String, ByVal ItemCode As String, ByVal NoBatch As String) As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "QA_CheckLPK"
        cmd.Parameters.AddWithValue("@NoLPK", NoLPK)
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", NoBatch)

        Try
            cn.Open()
            da.SelectCommand = cmd
            da.Fill(dt)

            Return dt

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Close()
            cmd.Parameters.Clear()

        End Try

    End Function

    Public Function GetNamaCabangMBS(ByVal KodeCabang As Integer) As String
        Dim NamaCabang As String

        cmd.CommandText = "PPIC_GetNamaCabangMBS"
        cmd.Parameters.AddWithValue("@KodeCabang", KodeCabang)

        Try
            cn.Open()
            NamaCabang = cmd.ExecuteScalar()
            Return NamaCabang

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    Public Function GetAllEvaluasiCat() As Data.DataTable

        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "QA_GetAllEvaluasiCat"

        Try

            cn.Open()
            da.SelectCommand = cmd
            da.Fill(dt)

            Return dt

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
            da = Nothing
            dt = Nothing
        End Try

    End Function

    Public Function GetEvalName(ByVal EvalCode As Byte) As String
        Dim EvalName As String

        cmd.CommandText = "QA_GetEvalName"
        cmd.Parameters.AddWithValue("@EvalCode", EvalCode)

        Try
            cn.Open()
            EvalName = cmd.ExecuteScalar()
            Return EvalName

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Close()
            cmd.Parameters.Clear()

        End Try

    End Function

    Public Function GetAllDisposisi() As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "QA_GetAllDisposisi"

        Try

            cn.Open()
            da.SelectCommand = cmd
            da.Fill(dt)

            Return dt

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
            da = Nothing
            dt = Nothing
        End Try

    End Function

    Public Function GetDisposisiName(ByVal DisposisiCode As Byte) As String
        Dim DispName As String

        cmd.CommandText = "QA_GetDisposisiName"
        cmd.Parameters.AddWithValue("@DisposisiCode", DisposisiCode)

        Try
            cn.Open()
            DispName = cmd.ExecuteScalar()

            Return DispName

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Close()
            cmd.Parameters.Clear()

        End Try

    End Function

    Public Sub DeleteProdukRetur(ByVal LineID As Integer)

        cmd.CommandText = "QA_DeleteProdukRetur"
        cmd.Parameters.AddWithValue("@LineID", LineID)

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

    Public Sub SaveDeleteLog(ByVal NoLPK As String, ByVal UserName As String, ByVal ComesFrom As String, ByVal IpAddr As String)

        cmd.CommandText = "PPIC_DeleteLog"
        With cmd.Parameters
            .AddWithValue("@NoLPK", NoLPK)
            .AddWithValue("@UserName", UserName)
            .AddWithValue("@ComesFrom", ComesFrom)
            .AddWithValue("@IpAddr", IpAddr)
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

#End Region

End Class
