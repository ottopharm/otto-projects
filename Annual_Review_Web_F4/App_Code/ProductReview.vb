Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class ProductReview

    Private cn As SqlConnection
    Private cmd As SqlCommand

    Public Sub New()

        cn = New SqlConnection( _
            ConfigurationManager.ConnectionStrings("csOtto").ConnectionString)
        cmd = New SqlCommand
        cmd.Connection = cn
        cmd.CommandType = Data.CommandType.StoredProcedure

    End Sub

    Public Function GetItemNameByCode(ByVal ItemCode As String) As String
        Dim sItemName As String

        cmd.CommandText = "Shared_GetItemNameByCode"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)

        Try
            cn.Open()
            sItemName = "" & cmd.ExecuteScalar
            Return sItemName

        Catch ex As SqlException
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    Public Function GetProductReview(ByVal DeptID As String, ByVal ProdID As String, ByVal Batch As String) As Data.DataTable
        Dim dt As New Data.DataTable
        Dim da As New SqlDataAdapter

        cmd.CommandText = "Shared_GetProdReview"
        With cmd.Parameters
            .AddWithValue("@DeptID", DeptID)
            .AddWithValue("@ProdID", ProdID)
            .AddWithValue("@Batch", Batch)
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

    Public Function GetProductReview(ByVal ItemCode As String, ByVal Batch As String, ByVal FromDate As Date, ByVal ToDate As Date) As Data.DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New Data.DataTable

        cmd.CommandText = "QA_GetProdReviewByPeriod"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ItemCode)
            .AddWithValue("@Batch", Batch)
            .AddWithValue("@FromDate", FromDate)
            .AddWithValue("ToDate", ToDate)
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

    Public Sub QC_UpdateProdReview(ByVal ProdID As String, ByVal Batch As String, ByVal Batch1 As Decimal, ByVal Batch2 As Integer, _
        ByVal ED As String, ByVal TglCPB As String, ByVal tglCKB As String, ByVal NoDocCPB As String, ByVal TglDocCPB As String, ByVal KetCPB As String, _
        ByVal NoDocCPBP As String, ByVal TglDocCPBP As String, ByVal KetCPBP As String, ByVal NoDocCKBP As String, ByVal TglDocCKBP As String, _
        ByVal KetCKBP As String, ByVal NoDocCKBS As String, ByVal TglDocCKBS As String, ByVal KetCKBS As String)

        cmd.CommandText = "QC_UpdateProdReview"

        With cmd.Parameters
            .AddWithValue("@ItemCode", ProdID.ToUpper)
            .AddWithValue("@Batch", Batch.ToUpper)
            .AddWithValue("@Batch1", Batch1)
            .AddWithValue("@Batch2", Batch2)
            .AddWithValue("@ED", ED)
            .AddWithValue("@TglCPB_QC", TglCPB)
            .AddWithValue("@TglCKB_QC", tglCKB)
            .AddWithValue("@NoDocCPB", NoDocCPB)
            .AddWithValue("@TglDocCPB", TglDocCPB)
            .AddWithValue("@KetCPB", KetCPB)
            .AddWithValue("@NoDocCPBP", NoDocCPBP)
            .AddWithValue("@KetCPBP", KetCPBP)
            .AddWithValue("@NoDocCKBP", NoDocCKBP)
            .AddWithValue("@KetCKBP", KetCKBP)
            .AddWithValue("@NoDocCKBS", NoDocCKBS)
            .AddWithValue("@KetCKBS", KetCKBS)

            'If Not String.IsNullOrEmpty(TglDocCPB) Then
            '    .AddWithValue("@TglDocCPB", TglDocCPB)
            'End If

            If Not String.IsNullOrEmpty(TglDocCPBP) Then
                .AddWithValue("@TglDocCPBP", TglDocCPBP)
            End If

            If Not String.IsNullOrEmpty(TglDocCKBP) Then
                .AddWithValue("@TglDocCKBP", TglDocCKBP)
            End If

            If Not String.IsNullOrEmpty(TglDocCKBS) Then
                .AddWithValue("@TglDocCKBS", TglDocCKBS)
            End If

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

    Public Sub QA_UpdateProdReview(ByVal ProdID As String, ByVal Batch As String, ByVal TglCPB_QA As String, ByVal TglCKB_QA As String, ByVal TglCPBCKAB_QA As String, ByVal TglCoA_QA As String, _
        ByVal TglGudang As String, ByVal Deviasi As String, ByVal KetCPB As String, ByVal KetCPBP As String, ByVal KetCKBP As String, ByVal KetCKBS As String, ByVal Keluhan As String, ByVal HULS As String)

        cmd.CommandText = "QA_UpdateProdReview"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ProdID.ToUpper)
            .AddWithValue("@Batch", Batch.ToUpper)
            .AddWithValue("@TglCPB_QA", TglCPB_QA)
            .AddWithValue("@TglCKB_QA", TglCKB_QA)
            .AddWithValue("@TglCPBCKB_QA", TglCPBCKAB_QA)
            .AddWithValue("@TglCoA_QA", TglCoA_QA)
            .AddWithValue("@TglGudang", TglGudang)
            .AddWithValue("@Deviasi", Deviasi)
            .AddWithValue("@Keluhan", Keluhan)
            .AddWithValue("@KetCPB", KetCPB)
            .AddWithValue("@KetCPBP", KetCPBP)
            .AddWithValue("@KetCKBP", KetCKBP)
            .AddWithValue("@KetCKBS", KetCKBS)
            .AddWithValue("@HULS", HULS)
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

    Public Sub ProdOIL_UpdateProdReview(ByVal ProdID As String, ByVal Batch As String, ByVal ProdDate As Date, ByVal PBAJam As Decimal, ByVal PBARendemen As Decimal, _
        ByVal OilJamMix As Decimal, ByVal OilJamFill As Decimal)

        cmd.CommandText = "Prod_UpdateProdReview"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ProdID.ToUpper)
            .AddWithValue("@Batch", Batch.ToUpper)
            .AddWithValue("@TglProd", ProdDate)
            .AddWithValue("@PBAJam", PBAJam)
            .AddWithValue("@PBARendemen", PBARendemen)
            .AddWithValue("@ProdCategory", Mid(ProdID, 1, 3).ToUpper)
            .AddWithValue("@OilJamMix", OilJamMix)
            .AddWithValue("@OilJamFill", OilJamFill)
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

    Public Sub ProdSYR_ProductReview(ByVal ProdID As String, ByVal Batch As String, ByVal ProdDate As Date, ByVal PBAJam As Decimal, ByVal PBARendemen As Decimal, _
        ByVal CMC As Integer, ByVal Avicel As Integer, ByVal Xanthan As Integer, ByVal SyrJamMix As Decimal, ByVal SyrJamFill As Decimal)

        cmd.CommandText = "Prod_UpdateProdReview"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ProdID.ToUpper)
            .AddWithValue("@Batch", Batch.ToUpper)
            .AddWithValue("@TglProd", ProdDate)
            .AddWithValue("@PBAJam", PBAJam)
            .AddWithValue("@PBARendemen", PBARendemen)
            .AddWithValue("@ProdCategory", Mid(ProdID, 1, 3).ToUpper)
            .AddWithValue("@CMC", CMC)
            .AddWithValue("@Avicel", Avicel)
            .AddWithValue("@Xanthan", Xanthan)
            .AddWithValue("@SyrJamMix", SyrJamMix)
            .AddWithValue("@SyrJamFill", SyrJamFill)
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

    Public Sub ProdINA_ProductReview(ByVal ProdID As String, ByVal Batch As String, ByVal ProdDate As Date, ByVal PBAJam As Decimal, ByVal PBARendemen As Decimal, _
        ByVal InaJamFill As Decimal, ByVal InaBsCuci As Int16, ByVal InaBsFill As Int16, ByVal InaBsClarity As Int16, ByVal InaHasilBaik As Integer)

        cmd.CommandText = "Prod_UpdateProdReview"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ProdID.ToUpper)
            .AddWithValue("@Batch", Batch.ToUpper)
            .AddWithValue("@TglProd", ProdDate)
            .AddWithValue("@PBAJam", PBAJam)
            .AddWithValue("@PBARendemen", PBARendemen)
            .AddWithValue("@ProdCategory", Mid(ProdID, 1, 3).ToUpper)
            .AddWithValue("@InaJamFill", InaJamFill)
            .AddWithValue("@InaBsCuci", InaBsCuci)
            .AddWithValue("@InaBsFill", InaBsFill)
            .AddWithValue("@InaBsClarity", InaBsClarity)
            .AddWithValue("@InaHasilBaik", InaHasilBaik)
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

    Public Sub ProdINV_ProductReview(ByVal ProdID As String, ByVal Batch As String, ByVal ProdDate As Date, ByVal PBAJam As Decimal, ByVal PBARendemen As Decimal)

        cmd.CommandText = "Prod_UpdateProdReview"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ProdID.ToUpper)
            .AddWithValue("@Batch", Batch.ToUpper)
            .AddWithValue("@TglProd", ProdDate)
            .AddWithValue("@PBAJam", PBAJam)
            .AddWithValue("@PBARendemen", PBARendemen)
            .AddWithValue("@ProdCategory", Mid(ProdID, 1, 3).ToUpper)
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

    Public Sub ProdSYK_ProductReview(ByVal ProdID As String, ByVal Batch As String, ByVal ProdDate As Date, ByVal PBAJam As Decimal, ByVal PBARendemen As Decimal, _
        ByVal SykJamFill As Decimal, ByVal SykJamMix As Decimal)

        cmd.CommandText = "Prod_UpdateProdReview"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ProdID.ToUpper)
            .AddWithValue("@Batch", Batch.ToUpper)
            .AddWithValue("@TglProd", ProdDate)
            .AddWithValue("@PBAJam", PBAJam)
            .AddWithValue("@PBARendemen", PBARendemen)
            .AddWithValue("@ProdCategory", Mid(ProdID, 1, 3).ToUpper)
            .AddWithValue("@SykJamMix", SykJamMix)
            .AddWithValue("@SykJamFill", SykJamFill)
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

    Public Sub ProdTAB_ProductReview(ByVal ProdID As String, ByVal Batch As String, ByVal ProdDate As Date, ByVal PBAJam As Decimal, ByVal PBARendemen As Decimal, _
        ByVal GranTotAir As Decimal, ByVal GranTotAlk As Decimal, ByVal GranTotMix As Decimal, ByVal FBDLot1 As Decimal, ByVal FBDLot1Mc As Decimal, _
        ByVal FBDLot2 As Decimal, ByVal FBDLot2Mc As Decimal, ByVal FBDLot3 As Decimal, ByVal FBDLot3Mc As Decimal, ByVal FBDLot4 As Decimal, ByVal FBDLot4Mc As Decimal, _
        ByVal FBDLot5 As Decimal, ByVal FBDLot5Mc As Decimal, ByVal WaktuCetak As Decimal, ByVal CoatLot1 As Decimal, ByVal CoatLot2 As Decimal, _
        ByVal CoatLot3 As Decimal, ByVal CoatLot4 As Decimal, ByVal PGA As Decimal)

        cmd.CommandText = "Prod_UpdateProdReview"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ProdID.ToUpper)
            .AddWithValue("@Batch", Batch.ToUpper)
            .AddWithValue("@TglProd", ProdDate)
            .AddWithValue("@PBAJam", PBAJam)
            .AddWithValue("@PBARendemen", PBARendemen)
            .AddWithValue("@ProdCategory", Mid(ProdID, 1, 3).ToUpper)
            .AddWithValue("@GranTotAir", GranTotAir)
            .AddWithValue("@GranTotAlk", GranTotAlk)
            .AddWithValue("@GranTotMix", GranTotMix)
            .AddWithValue("@FBDLot1", FBDLot1)
            .AddWithValue("@FBDLot1Mc", FBDLot1Mc)
            .AddWithValue("@FBDLot2", FBDLot2)
            .AddWithValue("@FBDLot2Mc", FBDLot2Mc)
            .AddWithValue("@FBDLot3", FBDLot3)
            .AddWithValue("@FBDLot3Mc", FBDLot3Mc)
            .AddWithValue("@FBDLot4", FBDLot4)
            .AddWithValue("@FBDLot4Mc", FBDLot4Mc)
            .AddWithValue("@FBDLot5", FBDLot5)
            .AddWithValue("@FBDLot5Mc", FBDLot5Mc)
            .AddWithValue("@WaktuCetak", WaktuCetak)
            .AddWithValue("@CoatLot1", CoatLot1)
            .AddWithValue("@CoatLot2", CoatLot2)
            .AddWithValue("@CoatLot3", CoatLot3)
            .AddWithValue("@CoatLot4", CoatLot4)
            .AddWithValue("@PGA", PGA)
        End With

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

    Public Sub ProdMOT_ProductReview(ByVal ProdID As String, ByVal Batch As String, ByVal ProdDate As Date, ByVal MotFill As Decimal, ByVal MotBsCuci As Int16, _
        ByVal MotBsFill As Int16, ByVal MotBsClarity As Int16, ByVal MotHasilBaik As Int16, _
        ByVal MotCMC As Integer, ByVal MotAvicel As Integer, ByVal MotXanthan As Integer, ByVal MotMix As Decimal, ByVal MotFill2 As Decimal)

        cmd.CommandText = "Prod_UpdateProdReview"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ProdID.ToUpper)
            .AddWithValue("@Batch", Batch)
            .AddWithValue("@TglProd", ProdDate)
            .AddWithValue("@MotFill", MotFill)
            .AddWithValue("@MotBsCuci", MotBsCuci)
            .AddWithValue("@MotBsFill", MotBsFill)
            .AddWithValue("@MotBsClarity", MotBsClarity)
            .AddWithValue("@MotHasilBaik", MotHasilBaik)
            .AddWithValue("@MotCMC", MotCMC)
            .AddWithValue("@MotAvicel", MotAvicel)
            .AddWithValue("@MotXanthan", MotXanthan)
            .AddWithValue("@MotMix", MotMix)
            .AddWithValue("@MotFill2", MotFill2)
            .AddWithValue("ProdCategory", "MOT")
        End With

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

    Public Sub ProdG_ProductReview(ByVal ProdID As String, ByVal Batch As String, ByVal ProdDate As Date, ByVal GTotAir As Int16, ByVal GtotAlk As Decimal, ByVal GTotMix As Decimal, _
        ByVal GLot1 As Decimal, ByVal GLot1Mc As Decimal, ByVal GLot2 As Decimal, ByVal GLot2Mc As Decimal, ByVal GLot3 As Decimal, ByVal GLot3Mc As Decimal, _
        ByVal GLot4 As Decimal, ByVal GLot4Mc As Decimal, ByVal GLot5 As Decimal, ByVal GLot5Mc As Decimal)

        cmd.CommandText = "Prod_UpdateProdReview"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ProdID.ToUpper)
            .AddWithValue("@Batch", Batch)
            .AddWithValue("@TglProd", ProdDate)
            .AddWithValue("@GTotAir", GTotAir)
            .AddWithValue("@GTotAlk", GtotAlk)
            .AddWithValue("@GTotMix", GTotMix)
            .AddWithValue("@GLot1", GLot1)
            .AddWithValue("@GLot1Mc", GLot1Mc)
            .AddWithValue("@GLot2", GLot2)
            .AddWithValue("@GLot2Mc", GLot2Mc)
            .AddWithValue("@GLot3", GLot3)
            .AddWithValue("@GLot3Mc", GLot3Mc)
            .AddWithValue("@GLot4", GLot4)
            .AddWithValue("@GLot4Mc", GLot4Mc)
            .AddWithValue("@GLot5", GLot5)
            .AddWithValue("@GLot5Mc", GLot5Mc)
            .AddWithValue("@ProdCategory", "G")
        End With

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

    Public Function GetTglDoc(ByVal ItemCode As String, ByVal NoDoc As String, ByVal DocType As String, ByVal Batch As String) As String
        Dim sTglDoc As String
        Dim calTglDoc As String

        cmd.CommandText = "QC_GetTglDoc"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ItemCode)
            .AddWithValue("@NoDoc", NoDoc)
            .AddWithValue("@DocType", DocType)
            .AddWithValue("@Batch", Batch)
        End With

        Try
            cn.Open()
            calTglDoc = cmd.ExecuteScalar
            sTglDoc = If(calTglDoc Is Nothing, String.Empty, Format(CDate(calTglDoc), "dd-MMM-yy"))
            Return sTglDoc

        Catch ex As Exception
            Throw ex
        Finally
            cn.Close()
            cmd.Parameters.Clear()
        End Try

    End Function

    Public Function GetMasterListByCode(ByVal ItemCode As String, ByVal Dept As String) As Data.DataTable
        Dim dt As New Data.DataTable
        Dim da As New SqlDataAdapter

        cmd.CommandText = "Shared_GetMasterListDnByCode"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ItemCode)
            .AddWithValue("@Dept", Dept)
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
        End Try

    End Function

    Public Sub SaveMasterListProduk(ByVal ProdID As String, ByVal IsActive As Boolean, ByVal NIE As String, _
        ByVal Golongan As String, ByVal TglNIE As Date, ByVal EDNIE As String, ByVal Komposisi As String, _
        ByVal UmurProduk As Decimal, ByVal Kemasan As String)

        cmd.CommandText = "Shared_SaveMasterListDn"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ProdID.ToUpper)
            .AddWithValue("@Golongan", Golongan)
            .AddWithValue("@IsActive", IsActive)
            .AddWithValue("@NIE", NIE)
            .AddWithValue("@TglNIE", TglNIE)
            .AddWithValue("@EDNIE", EDNIE)
            .AddWithValue("@Komposisi", Komposisi)
            .AddWithValue("@Kemasan", Kemasan)
            .AddWithValue("@UmurProduk", UmurProduk)
            .AddWithValue("@Dept", "QA")
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

    Public Sub SaveMasterListProduk(ByVal ProdID As String, ByVal IsTollOut As Boolean, ByVal IsInHouse As Boolean, _
        ByVal BatchSize As String, ByVal KondisiSimpan As String, ByVal NoCPB As String, ByVal TglCPB As String, _
        ByVal NoCKB As String, ByVal TglCKB As String, ByVal NoPBPOJ As String, ByVal TglPBPOJ As String, ByVal RefPBPOJ As String)

        cmd.CommandText = "Shared_SaveMasterListDn"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ProdID.ToUpper)
            .AddWithValue("@IsTollOut", IsTollOut)
            .AddWithValue("@IsInHouse", IsInHouse)
            .AddWithValue("@BatchSize", BatchSize)
            .AddWithValue("@KondisiSimpan", KondisiSimpan)
            .AddWithValue("@NoCPB", NoCPB)
            .AddWithValue("@TglCPB", TglCPB)
            .AddWithValue("@NoCKB", NoCKB)
            .AddWithValue("@TglCKB", TglCKB)
            .AddWithValue("@NoPBPOJ", NoPBPOJ)
            .AddWithValue("@TglPBPOJ", TglPBPOJ)
            .AddWithValue("@RefPBPOJ", RefPBPOJ)
            .AddWithValue("@Dept", "RD")
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

    Public Sub SaveProdSpek(ByVal Parameter As String, ByVal Spesifikasi As String, _
        ByVal IsInsert As Boolean, Optional ByVal ItemCode As String = Nothing, Optional ByVal LineID As Integer = 0)

        cmd.CommandText = "Shared_SaveProdSpek"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ItemCode)
            .AddWithValue("@Parameter", Parameter)
            .AddWithValue("@Spesifikasi", Spesifikasi)
            .AddWithValue("@IsInsert", IsInsert)
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

    Public Sub SaveProdSpek(ByVal Parameter As String, ByVal Spesifikasi As String, _
        ByVal IsInsert As Boolean, ByVal LineID As Integer)

        cmd.CommandText = "Shared_SaveProdSpek"
        With cmd.Parameters
            .AddWithValue("@Parameter", Parameter)
            .AddWithValue("@Spesifikasi", Spesifikasi)
            .AddWithValue("@IsInsert", IsInsert)
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

    Public Sub UpdatePBPOJ(ByVal ItemCode As String, ByVal NoPBPOJ As String, ByVal TglPBPOJ As String, ByVal RefPBPOJ As String)

        cmd.CommandText = "Shared_UpdatePBPOJ"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)
        cmd.Parameters.AddWithValue("@NoPBPOJ", NoPBPOJ)
        cmd.Parameters.AddWithValue("@TglPBPOJ", If(TglPBPOJ = "", Nothing, CDate(TglPBPOJ)))
        cmd.Parameters.AddWithValue("@RefPBPOJ", RefPBPOJ)

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

    Public Function GetProdukSpek(ByVal ItemCode As String) As Data.DataTable
        Dim dt As New Data.DataTable
        Dim da As New SqlDataAdapter

        cmd.CommandText = "Shared_GetSpekByItemCode"
        With cmd.Parameters
            .AddWithValue("@ItemCode", ItemCode)
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
        End Try

    End Function

    Public Function GetProdukPBPOJ(ByVal ItemCode As String) As List(Of String)
        Dim PBPOJ As New List(Of String)
        Dim dr As SqlDataReader

        cmd.CommandText = "Shared_GetPBPOJByItemCode"
        cmd.Parameters.AddWithValue("@ItemCode", ItemCode)

        Try
            cn.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                PBPOJ.Add("" & dr(0))    'NoPBPOJ
                PBPOJ.Add("" & dr(1))    'TglPBPOJ
                PBPOJ.Add("" & dr(2))    'RefPBPOJ
            End If

            Return PBPOJ

        Catch ex As SqlException
            Throw ex

        Finally
            cn.Close()
            dr.Close()
            cmd.Parameters.Clear()
        End Try


    End Function

    Public Sub DeleteProdSpek(ByVal LineID As Integer)

        cmd.CommandText = "Shared_DelProdSpek"
        With cmd.Parameters
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

    Public Sub ModMasterList(ByVal ProdukID As String, ByVal BatchSize As String, ByVal UmurProduk As Decimal, ByVal NoCPB As String, _
        ByVal TglCPB As Date, ByVal NoCKB As String, ByVal TglCKB As Date, ByVal IsUpdate As Boolean)

        cmd.CommandText = "RD_ModMasterList"
        With cmd.Parameters
            .AddWithValue("@ModType", "1")
            .AddWithValue("@IsUpdate", IsUpdate)
            .AddWithValue("@ItemCode", ProdukID)
            .AddWithValue("@BatchSize", BatchSize)
            .AddWithValue("@UmurProduk", UmurProduk)
            .AddWithValue("@NoCPB", NoCPB)
            .AddWithValue("@NoCKB", NoCKB)
            .AddWithValue("@TglCPB", TglCPB)
            .AddWithValue("@TglCKB", TglCKB)
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

    Public Sub DeleteBatchSize(ByVal ProdukID As String, ByVal IsUpdate As Boolean)

        cmd.CommandText = "RD_ModMasterList"
        With cmd.Parameters
            .AddWithValue("@ModType", "1")
            .AddWithValue("@IsUpdate", IsUpdate)
            .AddWithValue("@ItemCode", ProdukID)
            .AddWithValue("@BatchSize", "")
            .AddWithValue("@NoCPB", "")
            .AddWithValue("@NoCKB", "")
            .AddWithValue("@TglCPB", "")
            .AddWithValue("@TglCKB", "")
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

