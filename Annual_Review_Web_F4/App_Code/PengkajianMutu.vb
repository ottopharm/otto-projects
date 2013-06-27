Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class PengkajianMutu

#Region "Enum"
    Enum GranulDataType
        Header = 1
        Detail = 2
    End Enum

    Enum OilDataType
        Header = 1
        Kadar = 2
        Potential = 3
    End Enum

    Enum KpsTargetTable
        Header = 1
        Kadar = 2
        Disolusi = 3
    End Enum

    Enum SykTargetTable
        Header = 1
        Detail = 2
    End Enum

    Enum SyrTargetTable
        Header = 1
        Detail = 2
    End Enum

    Enum InaTargetTable
        Header = 1
        Detail = 2
    End Enum

    Enum InvTargetTable
        Header = 1
        Kadar = 2
        KeragamanBobot = 3
    End Enum

    Enum TabTargetTable
        Header = 1
        Kadar = 2
        Kandungan = 3
        Bobot = 4
        Disolusi = 5
    End Enum

    Enum JenisKeseragaman
        Kandungan = 1
        Bobot = 2
    End Enum

    Enum JenisDisolusi
        Tablet = 1
        TSS = 2
    End Enum

#End Region

#Region "Structure"
    Structure OilHdr
        Public ItemCode As String
        Public Batch As String
        Public BesarBatch As Decimal
        Public UoM As String
        Public MassaSpek As String
        Public MassaHasil As Decimal
        Public TubeSpek As String
        Public TubeHasil As Decimal
        Public ViskositasSpek As String
        Public ViskositasHasil As Decimal
        Public BobotSpek As String
        Public BobotHasil As Decimal
        Public BobotMinSpek As String
        Public BobotMinHasil As Decimal
        Public BobotMaxSpek As String
        Public BobotMaxHasil As Decimal
    End Structure

    Structure OilDtl
        Public TargetTable As Int16
        Public ItemCode As String
        Public Batch As String
        Public Spek As String
        Public Jenis As String
        Public Hasil As Decimal
        Public LineID As Integer
    End Structure

    Structure KpsHdr
        Public ItemCode As String
        Public Batch As String
        Public VariasiMaxSpek As String
        Public VariasiMaxHasil As Decimal
        Public VariasiMinSpek As String
        Public VariasiMinHasil As Decimal
        Public BobotCangkangSpek As String
        Public BobotCangkangHasil As Decimal
        Public BobotKapsulSpek As String
        Public BobotKapsulHasil As Decimal
        Public PenyimpanganMinSpek As String
        Public PenyimpanganMinHasil As Decimal
        Public PenyimpanganMaxSpek As String
        Public PenyimpanganMaxHasil As Decimal
        Public WaktuHancurSpek As String
        Public WaktuHancurHasil As Decimal
        Public KadarAirSpek As String
        Public KadarAirMassaHasil As Decimal
        Public KadarAirKapsulHasil As Decimal
        Public KandunganMinHasil As Decimal
        Public KandunganMaxHasil As Decimal
        Public KandunganRSDSpek As String
        Public KandunganRSDHasil As Decimal
        Public KandunganAVSpek As String
        Public KandunganAVHasil As Decimal
        Public UoM As String
        Public BesarBatch As Decimal
    End Structure

    Structure KpsKadar
        Public ItemCode As String
        Public Batch As String
        Public KadarSpek As String
        Public KadarJenis As String
        Public KadarMassa As Decimal
        Public KadarKapsul As Decimal
        Public LineID As Integer
    End Structure

    Structure KpsDisolusi
        Public ItemCode As String
        Public Batch As String
        Public DisolusiSpek As String
        Public DisolusiJenis As String
        Public DisolusiMin As Decimal
        Public DisolusiMax As Decimal
        Public DisolusiAvg As Decimal
        Public LineID As Integer
    End Structure

    Structure SykHdr
        Public ItemCode As String
        Public Batch As String
        Public pHSpek As String
        Public pHMassa As Decimal
        Public pHBotol As Decimal
        Public BobotSpek As String
        Public BobotMassa As Decimal
        Public BobotBotol As Decimal
        Public ViskositasSpek As String
        Public ViskositasMassa As Integer
        Public ViskositasBotol As Integer
        Public BobotIsiSpek As String
        Public BobotIsiHasil As Decimal
        Public SimpangMinSpek As String
        Public SimpangMinHasil As Decimal
        Public SimpangMaxSpek As String
        Public SimpangMaxHasil As Decimal
        Public AirSpek As String
        Public AirBotol As Decimal
        Public AirMassa As Decimal
        Public UoM As String
        Public BesarBatch As Decimal
        Public AerobSpek As String
        Public AerobHasil As String
        Public KhamirSpek As String
        Public KhamirHasil As String
        Public Ecoli As String
        Public Salmonelia As String
        Public Pseudomonas As String
        Public Staphylococcus As String
        Public MoistureSpek As String
        Public MoistureMassa As Decimal
        Public MoistureSachet As Decimal
    End Structure

    Structure SyrupDtl
        Public ItemCode As String
        Public Batch As String
        Public Kadar As String
        Public KadarSpek As String
        Public KadarMassa As Decimal
        Public KadarBotol As Decimal
        Public LineID As Integer
    End Structure

    Structure SyrHdr
        Public ItemCode As String
        Public Batch As String
        Public pHSpek As String
        Public pHMassa As Decimal
        Public pHBotol As Decimal
        Public BobotSpek As String
        Public BobotMassa As Decimal
        Public BobotBotol As Decimal
        Public ViskositasSpek As String
        Public ViskositasMassa As Integer
        Public ViskositasBotol As Integer
        Public NettoVolumeSpek As String
        Public NettoVolumeHasil As Decimal
        Public PenetralanSpek As String
        Public PenetralanHasil As Decimal
        Public DefoamingSpek As String
        Public DefoamingHasil As Decimal
        Public AerobSpek As String
        Public AerobHasil As String
        Public KhamirSpek As String
        Public KhamirHasil As String
        Public Ecoli As String
        Public Salmonelia As String
        Public Pseudomonas As String
        Public Staphylococcus As String
        Public UoM As String
        Public BesarBatch As Decimal
    End Structure

    Structure InaHdr
        Public ItemCode As String
        Public Batch As String
        Public pHSpek As String
        Public pHMassa As Decimal
        Public pHAmpul As Decimal
        Public Sterilitas As String
        Public VolumeSpek As String
        Public VolumeHasil As Decimal
        Public EndotoksinSpek As String
        Public EndotoksinHasil As String
        Public UoM As String
        Public BesarBatch As Decimal
    End Structure

    Structure InaDtl
        Public ItemCode As String
        Public Batch As String
        Public Kadar As String
        Public KadarSpek As String
        Public KadarMassa As Decimal
        Public KadarAmpul As Decimal
        Public LineID As Integer
    End Structure

    Structure InvHdr
        Public ItemCode As String
        Public Batch As String
        Public pHSpek As String
        Public pHHasil As Decimal
        Public Sterilitas As String
        Public PervialSpek As String
        Public PervialAvg As Decimal
        Public PervialMin As Decimal
        Public PervialMax As Decimal
        Public SusutSpek As String
        Public SusutHasil As Decimal
        Public EndotoksinSpek As String
        Public EndotoksinHasil As String
        Public UoM As String
        Public BesarBatch As Decimal
    End Structure

    Structure InvKadar
        Public ItemCode As String
        Public Batch As String
        Public Kadar As String
        Public KadarSpek As String
        Public KadarHasil As Decimal
        Public LineID As Integer
    End Structure

    Structure InvBobot
        Public ItemCode As String
        Public Batch As String
        Public JenisKeragamanBobot As String
        Public MinMaxSpek As String
        Public MinHasil As Decimal
        Public MaxHasil As Decimal
        Public RSDSpek As String
        Public RSDHasil As Decimal
        Public AVSpek As String
        Public AVHasil As Decimal
        Public LineID As Integer
    End Structure

    Structure TabHdr
        Public ItemCode As String
        Public Batch As String
        Public BesarBatch As Decimal
        Public UoM As String
        Public BobotAvgSpek As String
        Public BobotAvgHasil As Decimal
        Public SimpangMaxSpek As String
        Public SimpangMaxHasil As Decimal
        Public SimpangMinSpek As String
        Public SimpangMinHasil As Decimal
        Public TebalSpek As String
        Public TebalMin As Decimal
        Public TebalMax As Decimal
        Public KekerasanSpek As String
        Public KekerasanMin As Decimal
        Public KekerasanMax As Decimal
        Public KekerasanAvg As Decimal
        Public KeausanSpek As String
        Public KeausanMin As Decimal
        Public KeausanMax As Decimal
        Public MoistureSpek As String
        Public MoistureHasil As Decimal
        Public WaktuHancurSpek As String
        Public WaktuHancurHasil As Integer
        Public TssBobotAvgSpek As String
        Public TssBobotAvgHasil As Decimal
        Public TssSimpangMaxSpek As String
        Public TssSimpangMaxHasil As Decimal
        Public TssSimpangMinSpek As String
        Public TssSimpangMinHasil As Decimal
        Public TssTebalSpek As String
        Public TssTebalMin As Decimal
        Public TssTebalMax As Decimal
        Public TssKekerasanSpek As String
        Public TssKekerasanMin As Decimal
        Public TssKekerasanMax As Decimal
        Public TssKeausanSpek As String
        Public TssKeausanMin As Decimal
        Public TssKeausanMax As Decimal
        Public TssWaktuHancurSpek As String
        Public TssWaktuHancurHasil As Integer
        Public PenetralanSpek As String
        Public PenetralanHasil As Decimal
        Public DefoamingSpek As String
        Public DefoamingHasil As Decimal
        Public AerobSpek As String
        Public AerobHasil As String
        Public KhamirSpek As String
        Public KhamirHasil As String
        Public Ecoli As String
        Public Salmonelia As String
        Public Pseudomonas As String
        Public Staphylococcus As String
        Public UnitDosisSpek As String
        Public UnitDosisHasil As Decimal
    End Structure

    Structure TabKadar
        Public ItemCode As String
        Public Batch As String
        Public Kadar As String
        Public KadarSpek As String
        Public Massa As Decimal
        Public Kapsul As Decimal
        Public LineID As Integer
    End Structure

    Structure TabKeseragaman
        Public ItemCode As String
        Public Batch As String
        Public Keseragaman As String
        Public MinMaxSpek As String
        Public MinHasil As Decimal
        Public MaxHasil As Decimal
        Public RSDSpek As String
        Public RSDHasil As Decimal
        Public AVSpek As String
        Public AVHasil As Decimal
        Public LineID As Integer
    End Structure

    Structure TabDisolusi
        Public ItemCode As String
        Public Batch As String
        Public Disolusi As String
        Public DisolusiSpek As String
        Public MinHasil As Decimal
        Public MaxHasil As Decimal
        Public AvgHasil As Decimal
        Public LineID As Integer
    End Structure

#End Region

    Private cn As SqlConnection
    Private cmd As SqlCommand

    Public Sub New()

        cn = New SqlConnection( _
            ConfigurationManager.ConnectionStrings("csOtto").ConnectionString)
        cmd = New SqlCommand
        cmd.Connection = cn
        cmd.CommandType = Data.CommandType.StoredProcedure

    End Sub

#Region "Granul"

    Public Function GetGranul(ByVal DataType As GranulDataType, ByVal ItemCode As String, ByVal Batch As String) As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        If DataType = GranulDataType.Header Then
            cmd.CommandText = "QA_GetDataGranulHDR"
        Else
            cmd.CommandText = "QA_GetDataGranulDTL"
        End If


        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

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
            da.Dispose()
            dt.Dispose()
        End Try

    End Function

    Public Function GetGranulFromAPR(ByVal ItemCode As String, ByVal Batch As String) As String
        Dim dr As SqlDataReader = Nothing
        Dim sReturn As String

        cmd.CommandText = "QA_GetGranulAPR"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

        Try
            cn.Open()
            dr = cmd.ExecuteReader()
            dr.Read()

            sReturn = Format(CDate(dr(0)), "dd-MMM-yyyy") & "|" & dr(1).ToString

            Return sReturn

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Close()
            dr.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    Public Sub SaveGranulHDR(ByVal ItemCode As String, ByVal Batch As String, ByVal ED As String, _
        ByVal SpekSusut As String, ByVal Susut As Decimal, ByVal BesarBatch As Decimal, ByVal UoM As String)

        cmd.CommandText = "QA_SaveGranulHDR"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ItemCode)
            .AddWithValue("@Batch", Batch)
            .AddWithValue("@ED", ED)
            .AddWithValue("@SpekSusut", SpekSusut)
            .AddWithValue("@Susut", Susut)
            .AddWithValue("@BesarBatch", BesarBatch)
            .AddWithValue("@UoM", UoM)
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

    Public Sub SaveGranulDTL(ByVal ItemCode As String, ByVal Batch As String, _
        ByVal SpekKadar As String, ByVal JenisKadar As String, ByVal HasilKadar As Decimal, ByVal LineID As Integer)

        cmd.CommandText = "QA_SaveGranulDTL"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ItemCode)
            .AddWithValue("@Batch", Batch)
            .AddWithValue("@SpekKadar", SpekKadar)
            .AddWithValue("@JenisKadar", JenisKadar)
            .AddWithValue("@HasilKadar", HasilKadar)
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

    Public Sub DeleteGranulHDR(ByVal ItemCode As String, ByVal Batch As String)

        cmd.CommandText = "QA_DeleteGranulHDR"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

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

    Public Sub DeleteGranulDTL(ByVal LineID As Integer)

        cmd.CommandText = "QA_DeleteGranulDTL"
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

    Public Function GetGranulDTL(ByVal ItemCode As String, ByVal Batch As String) As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "QA_GetDataGranulDTL"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

        Try
            cn.Open()
            da.SelectCommand = cmd
            da.Fill(dt)

            Return dt

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Open()
            cmd.Parameters.Clear()
            da.Dispose()
            dt.Dispose()
        End Try
    End Function

#End Region

#Region "Oil"

    Public Function GetOilFromAPR(ByVal ItemCode As String, ByVal Batch As String) As String
        Dim dr As SqlDataReader = Nothing
        Dim sReturn As String

        cmd.CommandText = "QA_GetOilAPR"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

        Try
            cn.Open()
            dr = cmd.ExecuteReader()
            dr.Read()

            sReturn = dr(0).ToString & "|" & Format(CDate(dr(1)), "dd-MMM-yyyy") & "|" & _
                dr(2).ToString & "|" & dr(3).ToString & "|" & _
                dr(4).ToString & "|" & dr(5).ToString

            Return sReturn

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Close()
            dr.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    Public Function GetOil(ByVal DataType As OilDataType, ByVal ItemCode As String, ByVal Batch As String) As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "QA_GetDataOil"
        cmd.Parameters.AddWithValue("@TableType", DataType)
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

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
            da.Dispose()
            dt.Dispose()
        End Try

    End Function

    Public Sub SaveOilHDR(ByVal OilDataHDR As OilHdr)

        cmd.CommandText = "QA_SaveOilHDR"
        With cmd.Parameters
            .AddWithValue("@ItemCode", OilDataHDR.ItemCode)
            .AddWithValue("@Batch", OilDataHDR.Batch)
            .AddWithValue("@BesarBatch", OilDataHDR.BesarBatch)
            .AddWithValue("@UoM", OilDataHDR.UoM)
            .AddWithValue("@MassaSpek", OilDataHDR.MassaSpek)
            .AddWithValue("@MassaHasil", OilDataHDR.MassaHasil)
            .AddWithValue("@TubeSpek", OilDataHDR.TubeSpek)
            .AddWithValue("@TubeHasil", OilDataHDR.TubeHasil)
            .AddWithValue("@ViskositasSpek", OilDataHDR.ViskositasSpek)
            .AddWithValue("@ViskositasHasil", OilDataHDR.ViskositasHasil)
            .AddWithValue("@BobotSpek", OilDataHDR.BobotSpek)
            .AddWithValue("@BobotHasil", OilDataHDR.BobotHasil)
            .AddWithValue("@BobotMinSpek", OilDataHDR.BobotMinSpek)
            .AddWithValue("@BobotMinHasil", OilDataHDR.BobotMinHasil)
            .AddWithValue("@BobotMaxSpek", OilDataHDR.BobotMaxSpek)
            .AddWithValue("@BobotMaxHasil", OilDataHDR.BobotMaxHasil)
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

    Public Sub SaveOilDTL(ByVal OilDataDtl As OilDtl)

        cmd.CommandText = "QA_SaveOilDTL"
        With cmd.Parameters
            .AddWithValue("@TargetTable", OilDataDtl.TargetTable)
            .AddWithValue("@ItemCode", OilDataDtl.ItemCode)
            .AddWithValue("@Batch", OilDataDtl.Batch)
            .AddWithValue("@Spek", OilDataDtl.Spek)
            .AddWithValue("@Jenis", OilDataDtl.Jenis)
            .AddWithValue("@Hasil", OilDataDtl.Hasil)
            .AddWithValue("@LineID", OilDataDtl.LineID)
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

    Public Sub DeleteOilHDR(ByVal ItemCode As String, ByVal Batch As String)

        cmd.CommandText = "QA_DeleteOilHDR"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

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

    Public Sub DeleteOilDTL(ByVal TargetTable As Integer, ByVal LineID As Integer)

        cmd.CommandText = "QA_DeleteOilDTL"
        cmd.Parameters.AddWithValue("@TargetTable", TargetTable)
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

#End Region

#Region "KPS"

    Public Function GetKPSFromAPR(ByVal ItemCode As String, ByVal Batch As String) As String
        Dim dr As SqlDataReader = Nothing
        Dim sReturn As String

        cmd.CommandText = "QA_GetKpsAPR"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

        Try
            cn.Open()
            dr = cmd.ExecuteReader()
            dr.Read()

            sReturn = dr(0).ToString & "|" & Format(CDate(dr(1)), "dd-MMM-yyyy") & "|" & _
                dr(2).ToString & "|" & dr(3).ToString & "|" & _
                dr(4).ToString & "|" & dr(5).ToString

            Return sReturn

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Close()
            dr.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    Public Function GetKps(ByVal TargetTable As KpsTargetTable, ByVal ItemCode As String, ByVal Batch As String) As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "QA_GetDataKPS"
        cmd.Parameters.AddWithValue("@TargetTable", TargetTable)
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

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
            da.Dispose()
            dt.Dispose()
        End Try

    End Function

    Public Sub SaveKpsHDR(ByVal KpsDataHDR As KpsHdr)

        cmd.CommandText = "QA_SaveKpsHDR"
        With cmd.Parameters
            .AddWithValue("@ItemCode", KpsDataHDR.ItemCode)
            .AddWithValue("@Batch", KpsDataHDR.Batch)
            .AddWithValue("@BesarBatch", KpsDataHDR.BesarBatch)
            .AddWithValue("@UoM", KpsDataHDR.UoM)
            .AddWithValue("@VariasiMaxSpek", KpsDataHDR.VariasiMaxSpek)
            .AddWithValue("@VariasiMaxHasil", KpsDataHDR.VariasiMaxHasil)
            .AddWithValue("@VariasiMinSpek", KpsDataHDR.VariasiMinSpek)
            .AddWithValue("@VariasiMinHasil", KpsDataHDR.VariasiMinHasil)
            .AddWithValue("@BobotCangkangSpek", KpsDataHDR.BobotCangkangSpek)
            .AddWithValue("@BobotCangkangHasil", KpsDataHDR.BobotCangkangHasil)
            .AddWithValue("@BobotKapsulSpek", KpsDataHDR.BobotKapsulSpek)
            .AddWithValue("@BobotKapsulHasil", KpsDataHDR.BobotKapsulHasil)
            .AddWithValue("@PenyimpanganMinSpek", KpsDataHDR.PenyimpanganMinSpek)
            .AddWithValue("@PenyimpanganMinHasil", KpsDataHDR.PenyimpanganMinHasil)
            .AddWithValue("@PenyimpanganMaxSpek", KpsDataHDR.PenyimpanganMaxSpek)
            .AddWithValue("@PenyimpanganMaxHasil", KpsDataHDR.PenyimpanganMaxHasil)
            .AddWithValue("@WaktuHancurSpek", KpsDataHDR.WaktuHancurSpek)
            .AddWithValue("@WaktuHancurHasil", KpsDataHDR.WaktuHancurHasil)
            .AddWithValue("@KadarAirSpek", KpsDataHDR.KadarAirSpek)
            .AddWithValue("@KadarAirMassaHasil", KpsDataHDR.KadarAirMassaHasil)
            .AddWithValue("@KadarAirKapsulHasil", KpsDataHDR.KadarAirKapsulHasil)
            .AddWithValue("@KandunganMinHasil", KpsDataHDR.KandunganMinHasil)
            .AddWithValue("@KandunganMaxHasil", KpsDataHDR.KandunganMaxHasil)
            .AddWithValue("@KandunganRSDSpek", KpsDataHDR.KandunganRSDSpek)
            .AddWithValue("@KandunganRSDHasil", KpsDataHDR.KandunganRSDHasil)
            .AddWithValue("@KandunganAVSpek ", KpsDataHDR.KandunganAVSpek)
            .AddWithValue("@KandunganAVHasil", KpsDataHDR.KandunganAVHasil)

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

    Public Sub SaveKpsKadar(ByVal DataKpsKadar As KpsKadar)

        cmd.CommandText = "QA_SaveKpsKadar"
        With cmd.Parameters
            .AddWithValue("@ItemCode", DataKpsKadar.ItemCode)
            .AddWithValue("@Batch", DataKpsKadar.Batch)
            .AddWithValue("@KadarSpek", DataKpsKadar.KadarSpek)
            .AddWithValue("@KadarJenis", DataKpsKadar.KadarJenis)
            .AddWithValue("@KadarMassa", DataKpsKadar.KadarMassa)
            .AddWithValue("@KadarKapsul", DataKpsKadar.KadarKapsul)
            .AddWithValue("@LineID", DataKpsKadar.LineID)
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

    Public Sub SaveKpsDisolusi(ByVal DataKpsDisolusi As KpsDisolusi)

        cmd.CommandText = "QA_SaveKpsDisolusi"
        With cmd.Parameters
            .AddWithValue("@ItemCode", DataKpsDisolusi.ItemCode)
            .AddWithValue("@Batch", DataKpsDisolusi.Batch)
            .AddWithValue("@DisolusiSpek", DataKpsDisolusi.DisolusiSpek)
            .AddWithValue("@DisolusiJenis", DataKpsDisolusi.DisolusiJenis)
            .AddWithValue("@DisolusiMin", DataKpsDisolusi.DisolusiMin)
            .AddWithValue("@DisolusiMax", DataKpsDisolusi.DisolusiMax)
            .AddWithValue("DisolusiAvg", DataKpsDisolusi.DisolusiAvg)
            .AddWithValue("@LineID", DataKpsDisolusi.LineID)
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

    Public Sub DeleteKpsHDR(ByVal ItemCode As String, ByVal Batch As String)

        cmd.CommandText = "QA_DeleteKpsHDR"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

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

    Public Sub DeleteKpsDTL(ByVal LineID As Integer, ByVal TargetTable As Int16)

        cmd.CommandText = "QA_DeleteKpsDTL"
        cmd.Parameters.AddWithValue("@LineID", LineID)
        cmd.Parameters.AddWithValue("@TargetTable", TargetTable)

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

#Region "SYK"

    Public Function GetSYKFromAPR(ByVal ItemCode As String, ByVal Batch As String) As String
        Dim dr As SqlDataReader = Nothing
        Dim sReturn As String

        cmd.CommandText = "QA_GetSykAPR"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

        Try
            cn.Open()
            dr = cmd.ExecuteReader()
            dr.Read()

            sReturn = dr(0).ToString & "|" & Format(CDate(dr(1)), "dd-MMM-yyyy") & "|" & _
                dr(2).ToString & "|" & dr(3).ToString & "|" & _
                dr(4).ToString & "|" & dr(5).ToString

            Return sReturn

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Close()
            dr.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    Public Sub SaveSykHDR(ByVal SykDataHDR As SykHdr)

        cmd.CommandText = "QA_SaveSykHDR"

        With cmd.Parameters
            .AddWithValue("@ItemCode", SykDataHDR.ItemCode)
            .AddWithValue("@Batch", SykDataHDR.Batch)
            .AddWithValue("@BesarBatch", SykDataHDR.BesarBatch)
            .AddWithValue("@UoM", SykDataHDR.UoM)
            .AddWithValue("@pHSpek", SykDataHDR.pHSpek)
            .AddWithValue("@pHMassa", SykDataHDR.pHMassa)
            .AddWithValue("@pHBotol", SykDataHDR.pHBotol)
            .AddWithValue("@BobotSpek", SykDataHDR.BobotSpek)
            .AddWithValue("@BobotMassa", SykDataHDR.BobotMassa)
            .AddWithValue("@BobotBotol", SykDataHDR.BobotBotol)
            .AddWithValue("@ViskositasSpek", SykDataHDR.ViskositasSpek)
            .AddWithValue("@ViskositasMassa", SykDataHDR.ViskositasMassa)
            .AddWithValue("@ViskositasBotol", SykDataHDR.ViskositasBotol)
            .AddWithValue("@BobotIsiSpek", SykDataHDR.BobotIsiSpek)
            .AddWithValue("@BobotIsiHasil", SykDataHDR.BobotIsiHasil)
            .AddWithValue("@SimpangMinSpek", SykDataHDR.SimpangMinSpek)
            .AddWithValue("@SimpangMinHasil", SykDataHDR.SimpangMinHasil)
            .AddWithValue("@SimpangMaxSpek", SykDataHDR.SimpangMaxSpek)
            .AddWithValue("@SimpangMaxHasil", SykDataHDR.SimpangMaxHasil)
            .AddWithValue("@AirSpek", SykDataHDR.AirSpek)
            .AddWithValue("@AirBotol", SykDataHDR.AirBotol)
            .AddWithValue("@AirMassa", SykDataHDR.AirMassa)
            .AddWithValue("@AerobSpek", SykDataHDR.AerobSpek)
            .AddWithValue("@AerobHasil", SykDataHDR.AerobHasil)
            .AddWithValue("@KhamirSpek", SykDataHDR.KhamirSpek)
            .AddWithValue("@KhamirHasil", SykDataHDR.KhamirHasil)
            .AddWithValue("@Ecoli", SykDataHDR.Ecoli)
            .AddWithValue("@Salmonelia", SykDataHDR.Salmonelia)
            .AddWithValue("@Pseudomonas", SykDataHDR.Pseudomonas)
            .AddWithValue("@Staphylococcus", SykDataHDR.Staphylococcus)
            .AddWithValue("@MoistureSpek", SykDataHDR.MoistureSpek)
            .AddWithValue("@MoistureMassa", SykDataHDR.MoistureMassa)
            .AddWithValue("@MoistureSachet", SykDataHDR.MoistureSachet)
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

    Public Function GetSYK(ByVal TargetTable As SykTargetTable, ByVal ItemCode As String, ByVal Batch As String) As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "QA_GetDataSYK"
        cmd.Parameters.AddWithValue("@TargetTable", TargetTable)
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

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
            da.Dispose()
            dt.Dispose()
        End Try

    End Function

    Public Sub SaveSykDTL(ByVal DataSykDtl As SyrupDtl)

        cmd.CommandText = "QA_SaveSykDTL"
        With cmd.Parameters
            .AddWithValue("@ItemCode", DataSykDtl.ItemCode)
            .AddWithValue("@Batch", DataSykDtl.Batch)
            .AddWithValue("@Kadar", DataSykDtl.Kadar)
            .AddWithValue("@KadarSpek", DataSykDtl.KadarSpek)
            .AddWithValue("@KadarMassa", DataSykDtl.KadarMassa)
            .AddWithValue("@KadarBotol", DataSykDtl.KadarBotol)
            .AddWithValue("@LineID", DataSykDtl.LineID)
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

    Public Sub DeleteSykHDR(ByVal ItemCode As String, ByVal Batch As String)

        cmd.CommandText = "QA_DeleteSykHDR"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

        Try
            cn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Open()
            cmd.Parameters.Clear()
        End Try
    End Sub

    Public Sub DeleteSykDTL(ByVal LineID As Integer)

        cmd.CommandText = "QA_DeleteSykDTL"
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

#End Region

#Region "SYR"

    Public Function GetSYRFromAPR(ByVal ItemCode As String, ByVal Batch As String) As String
        Dim dr As SqlDataReader = Nothing
        Dim sReturn As String

        cmd.CommandText = "QA_GetSyrAPR"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

        Try
            cn.Open()
            dr = cmd.ExecuteReader()
            dr.Read()

            sReturn = dr(0).ToString & "|" & Format(CDate(dr(1)), "dd-MMM-yyyy") & "|" & _
                dr(2).ToString & "|" & dr(3).ToString & "|" & _
                dr(4).ToString & "|" & dr(5).ToString

            Return sReturn

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Close()
            dr.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    Public Sub SaveSyrHDR(ByVal SyrDataHDR As SyrHdr)

        cmd.CommandText = "QA_SaveSyrHDR"

        With cmd.Parameters
            .AddWithValue("@ItemCode", SyrDataHDR.ItemCode)
            .AddWithValue("@Batch", SyrDataHDR.Batch)
            .AddWithValue("@BesarBatch", SyrDataHDR.BesarBatch)
            .AddWithValue("@UoM", SyrDataHDR.UoM)
            .AddWithValue("@pHSpek", SyrDataHDR.pHSpek)
            .AddWithValue("@pHMassa", SyrDataHDR.pHMassa)
            .AddWithValue("@pHBotol", SyrDataHDR.pHBotol)
            .AddWithValue("@BobotSpek", SyrDataHDR.BobotSpek)
            .AddWithValue("@BobotMassa", SyrDataHDR.BobotMassa)
            .AddWithValue("@BobotBotol", SyrDataHDR.BobotBotol)
            .AddWithValue("@ViskositasSpek", SyrDataHDR.ViskositasSpek)
            .AddWithValue("@ViskositasMassa", SyrDataHDR.ViskositasMassa)
            .AddWithValue("@ViskositasBotol", SyrDataHDR.ViskositasBotol)
            .AddWithValue("@NettoVolumeSpek", SyrDataHDR.NettoVolumeSpek)
            .AddWithValue("@NettoVolumeHasil", SyrDataHDR.NettoVolumeHasil)
            .AddWithValue("@PenetralanSpek", SyrDataHDR.PenetralanSpek)
            .AddWithValue("@PenetralanHasil", SyrDataHDR.PenetralanHasil)
            .AddWithValue("@DefoamingSpek", SyrDataHDR.DefoamingSpek)
            .AddWithValue("@DefoamingHasil", SyrDataHDR.DefoamingHasil)
            .AddWithValue("@AerobSpek", SyrDataHDR.AerobSpek)
            .AddWithValue("@AerobHasil", SyrDataHDR.AerobHasil)
            .AddWithValue("@KhamirSpek", SyrDataHDR.KhamirSpek)
            .AddWithValue("@KhamirHasil", SyrDataHDR.KhamirHasil)
            .AddWithValue("@Ecoli", SyrDataHDR.Ecoli)
            .AddWithValue("@Salmonelia", SyrDataHDR.Salmonelia)
            .AddWithValue("@Pseudomonas", SyrDataHDR.Pseudomonas)
            .AddWithValue("@Staphylococcus", SyrDataHDR.Staphylococcus)

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

    Public Sub SaveSyrDTL(ByVal DataSykDtl As SyrupDtl)

        cmd.CommandText = "QA_SaveSyrDTL"
        With cmd.Parameters
            .AddWithValue("@ItemCode", DataSykDtl.ItemCode)
            .AddWithValue("@Batch", DataSykDtl.Batch)
            .AddWithValue("@Kadar", DataSykDtl.Kadar)
            .AddWithValue("@KadarSpek", DataSykDtl.KadarSpek)
            .AddWithValue("@KadarMassa", DataSykDtl.KadarMassa)
            .AddWithValue("@KadarBotol", DataSykDtl.KadarBotol)
            .AddWithValue("@LineID", DataSykDtl.LineID)
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

    Public Function GetSYR(ByVal TargetTable As SyrTargetTable, ByVal ItemCode As String, ByVal Batch As String) As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "QA_GetDataSYR"
        cmd.Parameters.AddWithValue("@TargetTable", TargetTable)
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

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
            da.Dispose()
            dt.Dispose()
        End Try
    End Function

    Public Sub DeleteSyrHDR(ByVal ItemCode As String, ByVal Batch As String)

        cmd.CommandText = "QA_DeleteSyrHDR"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

        Try
            cn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Open()
            cmd.Parameters.Clear()
        End Try
    End Sub

    Public Sub DeleteSyrDTL(ByVal LineID As Integer)

        cmd.CommandText = "QA_DeleteSyrDTL"
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

#End Region

#Region "INA"

    Public Function GetINAFromAPR(ByVal ItemCode As String, ByVal Batch As String) As String
        Dim dr As SqlDataReader = Nothing
        Dim sReturn As String

        cmd.CommandText = "QA_GetInaAPR"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

        Try
            cn.Open()
            dr = cmd.ExecuteReader()
            dr.Read()

            sReturn = dr(0).ToString & "|" & If(dr(1) Is DBNull.Value, "", Format(CDate(dr(1)), "dd-MMM-yyyy")) & "|" & _
                dr(2).ToString & "|" & dr(3).ToString & "|" & dr(4).ToString

            Return sReturn

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Close()
            dr.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    Public Function GetINA(ByVal TargetTable As InaTargetTable, ByVal ItemCode As String, ByVal Batch As String) As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "QA_GetDataINA"
        cmd.Parameters.AddWithValue("@TargetTable", TargetTable)
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

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
            da.Dispose()
            dt.Dispose()
        End Try
    End Function

    Public Sub SaveInaHDR(ByVal InaDataHDR As InaHdr)

        cmd.CommandText = "QA_SaveInaHDR"

        With cmd.Parameters
            .AddWithValue("@ItemCode", InaDataHDR.ItemCode)
            .AddWithValue("@Batch", InaDataHDR.Batch)
            .AddWithValue("@BesarBatch", InaDataHDR.BesarBatch)
            .AddWithValue("@UoM", InaDataHDR.UoM)
            .AddWithValue("@pHSpek", InaDataHDR.pHSpek)
            .AddWithValue("@pHMassa", InaDataHDR.pHMassa)
            .AddWithValue("@pHAmpul", InaDataHDR.pHAmpul)
            .AddWithValue("@VolumeSpek", InaDataHDR.VolumeSpek)
            .AddWithValue("@VolumeHasil", InaDataHDR.VolumeHasil)
            .AddWithValue("@Sterilitas", InaDataHDR.Sterilitas)
            .AddWithValue("@EndotoksinSpek", InaDataHDR.EndotoksinSpek)
            .AddWithValue("@EndotoksinHasil", InaDataHDR.EndotoksinHasil)
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

    Public Sub SaveInaDTL(ByVal DataInaDtl As InaDtl)

        cmd.CommandText = "QA_SaveInaDTL"
        With cmd.Parameters
            .AddWithValue("@ItemCode", DataInaDtl.ItemCode)
            .AddWithValue("@Batch", DataInaDtl.Batch)
            .AddWithValue("@Kadar", DataInaDtl.Kadar)
            .AddWithValue("@KadarSpek", DataInaDtl.KadarSpek)
            .AddWithValue("@KadarMassa", DataInaDtl.KadarMassa)
            .AddWithValue("@KadarAmpul", DataInaDtl.KadarAmpul)
            .AddWithValue("@LineID", DataInaDtl.LineID)
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

    Public Sub DeleteInaHDR(ByVal ItemCode As String, ByVal Batch As String)

        cmd.CommandText = "QA_DeleteInaHDR"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

        Try
            cn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Open()
            cmd.Parameters.Clear()
        End Try
    End Sub

    Public Sub DeleteInaDTL(ByVal LineID As Integer)

        cmd.CommandText = "QA_DeleteInaDTL"
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

#End Region

#Region "INV"

    Public Function GetINVFromAPR(ByVal ItemCode As String, ByVal Batch As String) As String
        Dim dr As SqlDataReader = Nothing
        Dim sReturn As String

        cmd.CommandText = "QA_GetInvAPR"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

        Try
            cn.Open()
            dr = cmd.ExecuteReader()
            dr.Read()

            sReturn = dr(0).ToString & "|" & Format(CDate(dr(1)), "dd-MMM-yyyy") & "|" & _
                dr(2).ToString & "|" & dr(3).ToString

            Return sReturn

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Close()
            dr.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    Public Function GetINV(ByVal TargetTable As InaTargetTable, ByVal ItemCode As String, ByVal Batch As String) As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "QA_GetDataINV"
        cmd.Parameters.AddWithValue("@TargetTable", TargetTable)
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

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
            da.Dispose()
            dt.Dispose()
        End Try
    End Function

    Public Sub SaveInvHDR(ByVal InvDataHDR As InvHdr)

        cmd.CommandText = "QA_SaveInvHDR"

        With cmd.Parameters
            .AddWithValue("@ItemCode", InvDataHDR.ItemCode)
            .AddWithValue("@Batch", InvDataHDR.Batch)
            .AddWithValue("@BesarBatch", InvDataHDR.BesarBatch)
            .AddWithValue("@UoM", InvDataHDR.UoM)
            .AddWithValue("@pHSpek", InvDataHDR.pHSpek)
            .AddWithValue("@pHHasil", InvDataHDR.pHHasil)
            .AddWithValue("@PervialSpek", InvDataHDR.PervialSpek)
            .AddWithValue("@PervialAvg", InvDataHDR.PervialAvg)
            .AddWithValue("@PervialMin", InvDataHDR.PervialMin)
            .AddWithValue("@PervialMax", InvDataHDR.PervialMax)
            .AddWithValue("@SusutSpek", InvDataHDR.SusutSpek)
            .AddWithValue("@SusutHasil", InvDataHDR.SusutHasil)
            .AddWithValue("@Sterilitas", InvDataHDR.Sterilitas)
            .AddWithValue("@EndotoksinSpek", InvDataHDR.EndotoksinSpek)
            .AddWithValue("@EndotoksinHasil", InvDataHDR.EndotoksinHasil)
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

    Public Sub SaveInvKadar(ByVal DataInvKadar As InvKadar)

        cmd.CommandText = "QA_SaveInvKadar"
        With cmd.Parameters
            .AddWithValue("@ItemCode", DataInvKadar.ItemCode)
            .AddWithValue("@Batch", DataInvKadar.Batch)
            .AddWithValue("@Kadar", DataInvKadar.Kadar)
            .AddWithValue("@KadarSpek", DataInvKadar.KadarSpek)
            .AddWithValue("@KadarHasil", DataInvKadar.KadarHasil)
            .AddWithValue("@LineID", DataInvKadar.LineID)
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

    Public Sub SaveInvBobot(ByVal DataInvBobot As InvBobot)

        cmd.CommandText = "QA_SaveInvBobot"
        With cmd.Parameters
            .AddWithValue("@ItemCode", DataInvBobot.ItemCode)
            .AddWithValue("@Batch", DataInvBobot.Batch)
            .AddWithValue("@JenisKeragamanBobot", DataInvBobot.JenisKeragamanBobot)
            .AddWithValue("@MinMaxSpek", DataInvBobot.MinMaxSpek)
            .AddWithValue("@MinHasil", DataInvBobot.MinHasil)
            .AddWithValue("@MaxHasil", DataInvBobot.MaxHasil)
            .AddWithValue("@RSDSpek", DataInvBobot.RSDSpek)
            .AddWithValue("@RSDHasil", DataInvBobot.RSDHasil)
            .AddWithValue("@AVSpek", DataInvBobot.AVSpek)
            .AddWithValue("@AVHasil", DataInvBobot.AVHasil)
            .AddWithValue("@LineID", DataInvBobot.LineID)
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

    Public Sub DeleteInvHDR(ByVal ItemCode As String, ByVal Batch As String)

        cmd.CommandText = "QA_DeleteInvHDR"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

        Try
            cn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Open()
            cmd.Parameters.Clear()
        End Try
    End Sub

    Public Sub DeleteInvKadar(ByVal LineID As Integer)

        cmd.CommandText = "QA_DeleteInvKadar"
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

    Public Sub DeleteInvBobot(ByVal LineID As Integer)

        cmd.CommandText = "QA_DeleteInvBobot"
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

#End Region

#Region "INF"

    Public Function GetINFFromAPR(ByVal ItemCode As String, ByVal Batch As String) As String
        Dim dr As SqlDataReader = Nothing
        Dim sReturn As String

        cmd.CommandText = "QA_GetInfAPR"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

        Try
            cn.Open()
            dr = cmd.ExecuteReader()
            dr.Read()

            sReturn = dr(0).ToString & "|" & Format(CDate(dr(1)), "dd-MMM-yyyy") & "|" & _
                dr(2).ToString & "|" & dr(3).ToString

            Return sReturn

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Close()
            dr.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    Public Function GetINF(ByVal TargetTable As InaTargetTable, ByVal ItemCode As String, ByVal Batch As String) As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "QA_GetDataINF"
        cmd.Parameters.AddWithValue("@TargetTable", TargetTable)
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

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
            da.Dispose()
            dt.Dispose()
        End Try
    End Function

    Public Sub SaveInfHDR(ByVal InaDataHDR As InaHdr)

        cmd.CommandText = "QA_SaveInaHDR"

        With cmd.Parameters
            .AddWithValue("@ItemCode", InaDataHDR.ItemCode)
            .AddWithValue("@Batch", InaDataHDR.Batch)
            .AddWithValue("@BesarBatch", InaDataHDR.BesarBatch)
            .AddWithValue("@UoM", InaDataHDR.UoM)
            .AddWithValue("@pHSpek", InaDataHDR.pHSpek)
            .AddWithValue("@pHMassa", InaDataHDR.pHMassa)
            .AddWithValue("@pHAmpul", InaDataHDR.pHAmpul)
            .AddWithValue("@VolumeSpek", InaDataHDR.VolumeSpek)
            .AddWithValue("@VolumeHasil", InaDataHDR.VolumeHasil)
            .AddWithValue("@Sterilitas", InaDataHDR.Sterilitas)
            .AddWithValue("@EndotoksinSpek", InaDataHDR.EndotoksinSpek)
            .AddWithValue("@EndotoksinHasil", InaDataHDR.EndotoksinHasil)
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

    Public Sub SaveInfDTL(ByVal DataInaDtl As InaDtl)

        cmd.CommandText = "QA_SaveInfDTL"
        With cmd.Parameters
            .AddWithValue("@ItemCode", DataInaDtl.ItemCode)
            .AddWithValue("@Batch", DataInaDtl.Batch)
            .AddWithValue("@Kadar", DataInaDtl.Kadar)
            .AddWithValue("@KadarSpek", DataInaDtl.KadarSpek)
            .AddWithValue("@KadarMassa", DataInaDtl.KadarMassa)
            .AddWithValue("@KadarAmpul", DataInaDtl.KadarAmpul)
            .AddWithValue("@LineID", DataInaDtl.LineID)
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

    Public Sub DeleteInfHDR(ByVal ItemCode As String, ByVal Batch As String)

        cmd.CommandText = "QA_DeleteInfHDR"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

        Try
            cn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Open()
            cmd.Parameters.Clear()
        End Try
    End Sub

    Public Sub DeleteInfDTL(ByVal LineID As Integer)

        cmd.CommandText = "QA_DeleteInfDTL"
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

#End Region

#Region "TAB"

    Public Function GetTABFromAPR(ByVal ItemCode As String, ByVal Batch As String) As String
        Dim dr As SqlDataReader = Nothing
        Dim sReturn As String

        cmd.CommandText = "QA_GetTabAPR"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

        Try
            cn.Open()
            dr = cmd.ExecuteReader()
            dr.Read()

            sReturn = dr(0).ToString & "|" & Format(CDate(dr(1)), "dd-MMM-yyyy") & "|" & _
                dr(2).ToString & "|" & dr(3).ToString & "|" & dr(4).ToString & "|" & _
                dr(5).ToString & "|" & dr(6).ToString & "|" & dr(7).ToString & "|" & _
                dr(8).ToString & "|" & dr(9).ToString & "|" & dr(10).ToString

            Return sReturn

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Close()
            dr.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    Public Function GetTAB(ByVal TargetTable As TabTargetTable, ByVal ItemCode As String, ByVal Batch As String) As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "QA_GetDataTAB"
        cmd.Parameters.AddWithValue("@TargetTable", TargetTable)
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

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
            da.Dispose()
            dt.Dispose()
        End Try
    End Function

    Public Sub SaveTabNonSalutHDR(ByVal TabDataHDR As TabHdr)

        cmd.CommandText = "QA_SaveTabNonSalutHDR"

        With cmd.Parameters
            .AddWithValue("@ItemCode", TabDataHDR.ItemCode)
            .AddWithValue("@Batch", TabDataHDR.Batch)
            .AddWithValue("@BesarBatch", TabDataHDR.BesarBatch)
            .AddWithValue("@UoM", TabDataHDR.UoM)
            .AddWithValue("@BobotAvgSpek", TabDataHDR.BobotAvgSpek)
            .AddWithValue("@BobotAvgHasil", TabDataHDR.BobotAvgHasil)
            .AddWithValue("@SimpangMaxSpek", TabDataHDR.SimpangMaxSpek)
            .AddWithValue("@SimpangMaxHasil", TabDataHDR.SimpangMaxHasil)
            .AddWithValue("@SimpangMinSpek", TabDataHDR.SimpangMinSpek)
            .AddWithValue("@SimpangMinHasil", TabDataHDR.SimpangMinHasil)
            .AddWithValue("@TebalSpek", TabDataHDR.TebalSpek)
            .AddWithValue("@TebalMin", TabDataHDR.TebalMin)
            .AddWithValue("@TebalMax", TabDataHDR.TebalMax)
            .AddWithValue("@KekerasanSpek", TabDataHDR.KekerasanSpek)
            .AddWithValue("@KekerasanMin ", TabDataHDR.KekerasanMin)
            .AddWithValue("@KekerasanMax", TabDataHDR.KekerasanMax)
            .AddWithValue("@KekerasanAvg", TabDataHDR.KekerasanAvg)
            .AddWithValue("@KeausanSpek", TabDataHDR.KeausanSpek)
            .AddWithValue("@KeausanMin", TabDataHDR.KeausanMin)
            .AddWithValue("@KeausanMax", TabDataHDR.KeausanMax)
            .AddWithValue("@MoistureSpek", TabDataHDR.MoistureSpek)
            .AddWithValue("@MoistureHasil", TabDataHDR.MoistureHasil)
            .AddWithValue("@WaktuHancurSpek", TabDataHDR.WaktuHancurSpek)
            .AddWithValue("@WaktuHancurHasil", TabDataHDR.WaktuHancurHasil)
            .AddWithValue("@PenetralanSpek", TabDataHDR.PenetralanSpek)
            .AddWithValue("@PenetralanHasil", TabDataHDR.PenetralanHasil)
            .AddWithValue("@DefoamingSpek", TabDataHDR.DefoamingSpek)
            .AddWithValue("@DefoamingHasil", TabDataHDR.DefoamingHasil)
            .AddWithValue("@AerobSpek", TabDataHDR.AerobSpek)
            .AddWithValue("@AerobHasil", TabDataHDR.AerobHasil)
            .AddWithValue("@KhamirSpek", TabDataHDR.KhamirSpek)
            .AddWithValue("@KhamirHasil", TabDataHDR.KhamirHasil)
            .AddWithValue("@Ecoli", TabDataHDR.Ecoli)
            .AddWithValue("@Salmonelia", TabDataHDR.Salmonelia)
            .AddWithValue("@Pseudomonas", TabDataHDR.Pseudomonas)
            .AddWithValue("@Staphylococcus", TabDataHDR.Staphylococcus)
            .AddWithValue("@UnitDosisSpek", TabDataHDR.UnitDosisSpek)
            .AddWithValue("@UnitDosisHasil", TabDataHDR.UnitDosisHasil)
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

    Public Sub SaveTabSalutHDR(ByVal TabDataHDR As TabHdr)

        cmd.CommandText = "QA_SaveTabSalutHDR"

        With cmd.Parameters
            .AddWithValue("@ItemCode", TabDataHDR.ItemCode)
            .AddWithValue("@Batch", TabDataHDR.Batch)
            .AddWithValue("@BesarBatch", TabDataHDR.BesarBatch)
            .AddWithValue("@UoM", TabDataHDR.UoM)
            .AddWithValue("@BobotAvgSpek", TabDataHDR.BobotAvgSpek)
            .AddWithValue("@BobotAvgHasil", TabDataHDR.BobotAvgHasil)
            .AddWithValue("@SimpangMaxSpek", TabDataHDR.SimpangMaxSpek)
            .AddWithValue("@SimpangMaxHasil", TabDataHDR.SimpangMaxHasil)
            .AddWithValue("@SimpangMinSpek", TabDataHDR.SimpangMinSpek)
            .AddWithValue("@SimpangMinHasil", TabDataHDR.SimpangMinHasil)
            .AddWithValue("@TebalSpek", TabDataHDR.TebalSpek)
            .AddWithValue("@TebalMin", TabDataHDR.TebalMin)
            .AddWithValue("@TebalMax", TabDataHDR.TebalMax)
            .AddWithValue("@KekerasanSpek", TabDataHDR.KekerasanSpek)
            .AddWithValue("@KekerasanMin ", TabDataHDR.KekerasanMin)
            .AddWithValue("@KekerasanMax", TabDataHDR.KekerasanMax)
            .AddWithValue("@KekerasanAvg", TabDataHDR.KekerasanAvg)
            .AddWithValue("@KeausanSpek", TabDataHDR.KeausanSpek)
            .AddWithValue("@KeausanMin", TabDataHDR.KeausanMin)
            .AddWithValue("@KeausanMax", TabDataHDR.KeausanMax)
            .AddWithValue("@MoistureSpek", TabDataHDR.MoistureSpek)
            .AddWithValue("@MoistureHasil", TabDataHDR.MoistureHasil)
            .AddWithValue("@WaktuHancurSpek", TabDataHDR.WaktuHancurSpek)
            .AddWithValue("@WaktuHancurHasil", TabDataHDR.WaktuHancurHasil)
            .AddWithValue("@TssBobotAvgSpek", TabDataHDR.TssBobotAvgSpek)
            .AddWithValue("@TssBobotAvgHasil", TabDataHDR.TssBobotAvgHasil)
            .AddWithValue("@TssSimpangMaxSpek", TabDataHDR.TssSimpangMaxSpek)
            .AddWithValue("@TssSimpangMaxHasil", TabDataHDR.TssSimpangMaxHasil)
            .AddWithValue("@TssSimpangMinSpek", TabDataHDR.TssSimpangMinSpek)
            .AddWithValue("@TssSimpangMinHasil", TabDataHDR.TssSimpangMinHasil)
            .AddWithValue("@TssTebalSpek", TabDataHDR.TssTebalSpek)
            .AddWithValue("@TssTebalMin", TabDataHDR.TssTebalMin)
            .AddWithValue("@TssTebalMax", TabDataHDR.TssTebalMax)
            .AddWithValue("@TssKekerasanSpek", TabDataHDR.TssKekerasanSpek)
            .AddWithValue("@TssKekerasanMin", TabDataHDR.TssKekerasanMin)
            .AddWithValue("@TssKekerasanMax", TabDataHDR.TssKekerasanMax)
            .AddWithValue("@TssKeausanSpek", TabDataHDR.TssKeausanSpek)
            .AddWithValue("@TssKeausanMin", TabDataHDR.TssKeausanMin)
            .AddWithValue("@TssKeausanMax", TabDataHDR.TssKeausanMax)
            .AddWithValue("@TssWaktuHancurSpek", TabDataHDR.TssWaktuHancurSpek)
            .AddWithValue("@TssWaktuHancurHasil", TabDataHDR.TssWaktuHancurHasil)
            .AddWithValue("@AerobSpek", TabDataHDR.AerobSpek)
            .AddWithValue("@AerobHasil", TabDataHDR.AerobHasil)
            .AddWithValue("@KhamirSpek", TabDataHDR.KhamirSpek)
            .AddWithValue("@KhamirHasil", TabDataHDR.KhamirHasil)
            .AddWithValue("@Ecoli", TabDataHDR.Ecoli)
            .AddWithValue("@Salmonelia", TabDataHDR.Salmonelia)
            .AddWithValue("@Pseudomonas", TabDataHDR.Pseudomonas)
            .AddWithValue("@Staphylococcus", TabDataHDR.Staphylococcus)
            .AddWithValue("@UnitDosisSpek", TabDataHDR.UnitDosisSpek)
            .AddWithValue("@UnitDosisHasil", TabDataHDR.UnitDosisHasil)
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

    Public Sub SaveTabKadar(ByVal DataTabKadar As TabKadar)

        cmd.CommandText = "QA_SaveTabKadar"
        With cmd.Parameters
            .AddWithValue("@ItemCode", DataTabKadar.ItemCode)
            .AddWithValue("@Batch", DataTabKadar.Batch)
            .AddWithValue("@Kadar", DataTabKadar.Kadar)
            .AddWithValue("@KadarSpek", DataTabKadar.KadarSpek)
            .AddWithValue("@Massa", DataTabKadar.Massa)
            .AddWithValue("@Kapsul", DataTabKadar.Kapsul)
            .AddWithValue("@LineID", DataTabKadar.LineID)
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

    Public Sub SaveTabKeseragaman(ByVal Keseragaman As JenisKeseragaman, _
        ByVal DataTabKeseragaman As TabKeseragaman)

        If Keseragaman = JenisKeseragaman.Bobot Then
            cmd.CommandText = "QA_SaveTabBobot"
        Else
            cmd.CommandText = "QA_SaveTabKandungan"
        End If

        With cmd.Parameters
            .AddWithValue("@ItemCode", DataTabKeseragaman.ItemCode)
            .AddWithValue("@Batch", DataTabKeseragaman.Batch)
            .AddWithValue("@Keseragaman", DataTabKeseragaman.Keseragaman)
            .AddWithValue("@MinMaxSpek", DataTabKeseragaman.MinMaxSpek)
            .AddWithValue("@MinHasil", DataTabKeseragaman.MinHasil)
            .AddWithValue("@MaxHasil", DataTabKeseragaman.MaxHasil)
            .AddWithValue("@RSDSpek", DataTabKeseragaman.RSDSpek)
            .AddWithValue("@RSDHasil", DataTabKeseragaman.RSDHasil)
            .AddWithValue("@AVSpek", DataTabKeseragaman.AVSpek)
            .AddWithValue("@AVHasil", DataTabKeseragaman.AVHasil)
            .AddWithValue("@LineID", DataTabKeseragaman.LineID)
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

    Public Sub SaveTabDisolusi(ByVal Disolusi As JenisDisolusi, ByVal DataTabDisolusi As TabDisolusi)

        If Disolusi = JenisDisolusi.Tablet Then
            cmd.CommandText = "QA_SaveTabDisolusi"
        Else
            cmd.CommandText = "QA_SaveTabTssDisolusi"
        End If

        With cmd.Parameters
            .AddWithValue("@ItemCode", DataTabDisolusi.ItemCode)
            .AddWithValue("@Batch", DataTabDisolusi.Batch)
            .AddWithValue("@Disolusi", DataTabDisolusi.Disolusi)
            .AddWithValue("@DisolusiSpek", DataTabDisolusi.DisolusiSpek)
            .AddWithValue("@MinHasil", DataTabDisolusi.MinHasil)
            .AddWithValue("@MaxHasil", DataTabDisolusi.MaxHasil)
            .AddWithValue("@AvgHasil", DataTabDisolusi.AvgHasil)
            .AddWithValue("@LineID", DataTabDisolusi.LineID)
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

    Public Sub DeleteTabHDR(ByVal ItemCode As String, ByVal Batch As String)

        cmd.CommandText = "QA_DeleteTabHDR"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@Batch", Batch)

        Try
            cn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Open()
            cmd.Parameters.Clear()
        End Try
    End Sub

    Public Sub DeleteTabKadar(ByVal LineID As Integer)

        cmd.CommandText = "QA_DeleteTabKadar"
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

    Public Sub DeleteTabKeseragaman(ByVal Keseragaman As JenisKeseragaman, _
        ByVal LineID As Integer)

        If Keseragaman = JenisKeseragaman.Bobot Then
            cmd.CommandText = "QA_DeleteTabBobot"
        Else
            cmd.CommandText = "QA_DeleteTabKandungan"
        End If

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

    Public Sub DeleteTabDisolusi(ByVal Disolusi As JenisDisolusi, _
        ByVal LineID As Integer)

        If Disolusi = JenisDisolusi.Tablet Then
            cmd.CommandText = "QA_DeleteTabDisolusi"
        Else
            cmd.CommandText = "QA_DeleteTabTssDisolusi"
        End If

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

#End Region

End Class
