Imports MyTradingSystem.DataEntity
Imports MyTradingSystem.DataBase
Imports MyTradingSystem.DataFeed
Imports System.Data.SqlClient


Namespace DataEntity


    Public Class CDTDaily_Index
        Inherits CDTDaily

        Public Event InsertProgress(ByVal iProgress As Integer)

        'indexID,tradeDate,ticker,preClosePrice,openIndex,highestIndex,lowestIndex,closeIndex,turnoverVol,turnoverValue,CHG,CHGPct

        Public Sub New()
            MyBase.New()

            m_strSQLTableName = "IndexPriceDaily"
            Me.TableName = m_strSQLTableName


            '通联上的其他字段
            Me.Columns.Add("preClosePrice", GetType(System.Single))
            Me.Columns.Add("CHG", GetType(System.Single))
            Me.Columns.Add("CHGPct", GetType(System.Single))

        End Sub

        'Public Overrides Function GetOpenPrice(index As Short) As Double
        '    'Return Me.Rows(index).Item("openIndex")
        '    Return Me.Rows(index).Item("OpenPrice")
        'End Function

        'Public Overrides Function GetHighPrice(index As Short) As Double
        '    'Return Me.Rows(index).Item("highestIndex")
        '    Return Me.Rows(index).Item("HighPrice")
        'End Function

        'Public Overrides Function GetLowPrice(index As Short) As Double
        '    'Return Me.Rows(index).Item("lowestIndex")
        '    Return Me.Rows(index).Item("LowPrice")
        'End Function

        'Public Overrides Function GetClosePrice(index As Short) As Double
        '    'Return Me.Rows(index).Item("closeIndex")
        '    Return Me.Rows(index).Item("ClosePrice")
        'End Function

        'Public Overrides Function GetVolume(index As Short) As Double
        '    'Return Me.Rows(index).Item("turnoverVol")
        '    Return Me.Rows(index).Item("TurnoverVolume")
        'End Function

        'Public Overrides Function GetTurnoverValue(index As Short) As Double
        '    'Return Me.Rows(index).Item("turnoverValue")
        '    Return Me.Rows(index).Item("TurnoverValue")
        'End Function

        ''' <summary>
        ''' 批量插入数据表
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <remarks></remarks>
        Public Overrides Function BulkInsertDataTable2SQL() As Boolean

            Dim obj1 As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
            Try

                Dim strMappingList As New SortedList(Of String, String)

                strMappingList.Add("SecurityID", "indexID")
                strMappingList.Add("Symbol", "Symbol")
                strMappingList.Add("TheDate", "TheDate")

                strMappingList.Add("preClosePrice", "preClosePrice")
                strMappingList.Add("OpenPrice", "openIndex")
                strMappingList.Add("HighPrice", "highestIndex")
                strMappingList.Add("LowPrice", "lowestIndex")
                strMappingList.Add("ClosePrice", "closeIndex")

                strMappingList.Add("TurnoverVolume", "turnoverVol")
                strMappingList.Add("TurnoverValue", "turnoverVol")

                strMappingList.Add("CHG", "CHG")
                strMappingList.Add("CHGPct", "CHGPct")

                If obj1.BulkInsertDataTable(Me, m_strSQLTableName, strMappingList) Then
                    Return True
                Else
                    Return False
                End If


            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            Finally
                obj1 = Nothing
            End Try

        End Function


        ''' <summary>
        ''' 根据Symbol、日期值从SQL数据库得出一个数据库现有的表，用多态实现，这样可以对子类进行代码复用
        ''' 这里的子类需要重写，因为数据库的字段和DTIndex不一样，要重新映射
        ''' </summary>
        Public Overrides Function GetDataTablePrice(strSymbol As String, strBeginDate As String, strEndDate As String) As Boolean

            Try
                'Dim dt As New CDTDaily

                Dim objSA As New CDBADOSQLAdapter(GlobalVariables.gSQLConnectionString, Me.TableName)

                '取数据前先把之前的数据清空
                Me.Rows.Clear()

                Dim dt_sql As New DataTable

                objSA.GetDataTablebySymbolDatesfromSQL(strSymbol, strBeginDate, strEndDate, dt_sql)

                ReMapDataColumns(dt_sql)


                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False


            End Try

        End Function

        Private Sub ReMapDataColumns(dt_sql As DataTable)
            Try

                For Each row As DataRow In dt_sql.Rows
                    Dim merow As DataRow = Me.NewRow

                    merow.Item("SecurityID") = row.Item("indexID")
                    merow.Item("Symbol") = row.Item("Symbol")
                    merow.Item("TheDate") = row.Item("TheDate")

                    merow.Item("preClosePrice") = row.Item("preClosePrice")

                    merow.Item("OpenPrice") = row.Item("openIndex")
                    merow.Item("HighPrice") = row.Item("highestIndex")
                    merow.Item("LowPrice") = row.Item("lowestIndex")
                    merow.Item("ClosePrice") = row.Item("closeIndex")
                    merow.Item("TurnoverVolume") = row.Item("turnoverVol")
                    merow.Item("TurnoverValue") = row.Item("turnoverValue")
                    merow.Item("CHG") = row.Item("CHG")
                    merow.Item("CHGPct") = row.Item("CHGPct")



                    Me.Rows.Add(merow)
                Next


            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End Sub

        ''' <summary>
        ''' 从Datayes中抓取对应指数数据，override基类
        ''' </summary>
        ''' <param name="stSymbol"></param>
        ''' <param name="pat"></param>
        ''' <param name="dtStartDate"></param>
        ''' <param name="dtEndDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function FeedDataTablePrice(strSymbol As String, Optional ByVal pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj, Optional ByVal dtStartDate As String = "", Optional ByVal dtEndDate As String = "") As Int32

            Dim dbDatayes As New CDataFeedDatayes_Price
            Dim dt As New DataTable
            pat = EPriceAdjustedType.Normal

            Try

                dt = dbDatayes.FeedIndexDailyPriceDataTable()

                AdaptDatafromDataTable(dt)

                Return dt.Rows.Count
            Catch ex As Exception
                Return 0
            End Try

        End Function

        ''' <summary>
        ''' 针对通联数据导入时中的证券通用信息数据表
        ''' </summary>
        ''' <param name="dt_datayes"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overrides Function AdaptDatafromDataTable(ByVal dt_datayes As DataTable) As Boolean

            Try

                For Each row As DataRow In dt_datayes.Rows
                    Dim merow As DataRow = Me.NewRow

                    merow.Item("SecurityID") = row.Item("indexID")
                    merow.Item("Symbol") = row.Item("ticker")
                    merow.Item("TheDate") = row.Item("tradeDate")

                    merow.Item("preClosePrice") = row.Item("preCloseIndex")

                    merow.Item("OpenPrice") = row.Item("openIndex")
                    merow.Item("HighPrice") = row.Item("highestIndex")
                    merow.Item("LowPrice") = row.Item("lowestIndex")
                    merow.Item("ClosePrice") = row.Item("closeIndex")
                    merow.Item("TurnoverVolume") = row.Item("turnoverVol")

                    merow.Item("TurnoverValue") = row.Item("turnoverValue")
                    merow.Item("CHG") = row.Item("CHG")
                    merow.Item("CHGPct") = row.Item("CHGPct")

                    Me.Rows.Add(merow)
                Next

                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Function

        ''' <summary>
        ''' 更新SQL数据，按一条条，通联数据中的完整数据格式
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function UpgradeData() As Boolean
            Try

                Dim strCommand As String

                Dim conn As SqlConnection = New SqlConnection(GlobalVariables.gSQLConnectionString)
                Dim adapter As New System.Data.SqlClient.SqlDataAdapter()

                Dim strExistingDates As New SortedList(Of Date, Int16)

                'strCommand = "Select * from StockPriceDaily WHERE Symbol=@Symbol and TheDate=@TheDate"
                'Dim Command_Select As SqlCommand = New SqlCommand(strCommand, conn)
                'With Command_Select.Parameters
                '    Dim parameter1 As SqlParameter = .Add("@Symbol", SqlDbType.NChar, 10, "Symbol")
                '    'parameter1.SourceColumn = "Symbol"
                '    'parameter1.SourceVersion = DataRowVersion.Original ' DataRowVersion.Current
                '    Dim parameter2 As SqlParameter = .Add("@TheDate", SqlDbType.Date, 4, "TheDate")
                '    'parameter2.SourceColumn = "TheDate"
                '    'parameter2.SourceVersion = DataRowVersion.Original
                'End With
                'adapter.SelectCommand = Command_Select      '使用自动生成Update/Delete命令之前必须设置好Select命令


                strExistingDates = GetExistingDateListbySymbol(Me.Rows(0).Item("Symbol").ToString)
                '查找应该设置为新加行、还是更新行
                For Each row As DataRow In Me.Rows
                    row.AcceptChanges()

                    If strExistingDates.ContainsKey(CDate(row("TheDate"))) Then
                        'If CDate(row("TheDate")) = CDate("2015-11-18") Then
                        '    MsgBox("stop here")
                        'End If
                        row.SetModified()
                    Else
                        row.SetAdded()
                    End If
                Next



                'Dim builder As New SqlCommandBuilder(adapter) '自动生成命令 ，似乎速度很快，11s对60s。其实是有的行没有更新？

                'adapter.InsertCommand = New SqlCommand()
                'adapter.InsertCommand = builder.GetInsertCommand()
                'adapter.UpdateCommand = New SqlCommand()
                'adapter.UpdateCommand = builder.GetUpdateCommand()

                '    'adapter.DeleteCommand = New SqlCommand()
                '    'adapter.DeleteCommand = builder.GetDeleteCommand()


                strCommand = "UPDATE StockPriceDaily SET SecurityID=@SecurityID,PreClosePrice=@PreClosePrice,ActPreClosePrice=@ActPreClosePrice,OpenPrice=@OpenPrice, " & _
                                          "HighPrice =@HighPrice,  LowPrice=@LowPrice,ClosePrice=@ClosePrice, TurnoverVolume=@TurnoverVolume,TurnoverValue=@TurnoverValue," & _
                                            "DealAmount =@DealAmount, TurnoverRate=@TurnoverRate,AccumAdjFactor=@AccumAdjFactor,NegMarketValue=@NegMarketValue,MarketValue=@MarketValue," & _
                                            " PE=@PE,PE1=@PE1,PB=@PB " & _
                                            " WHERE Symbol=@Symbol and TheDate=@TheDate"
                Dim Command_Update As SqlCommand = New SqlCommand(strCommand, conn)


                ' Add the parameters for the UpdateCommand.
                With Command_Update.Parameters
                    .Add("@SecurityID", SqlDbType.NChar, 15, "SecurityID")
                    .Add("@Symbol", SqlDbType.NChar, 10, "Symbol")
                    'Dim parameter As SqlParameter = .Add("@Symbol", SqlDbType.NChar, 10, "Symbol")
                    'parameter.SourceVersion = DataRowVersion.Current  '??????????Original
                    .Add("@TheDate", SqlDbType.Date, 4, "TheDate")
                    .Add("@PreClosePrice", SqlDbType.SmallMoney, 4, "PreClosePrice")
                    .Add("@ActPreClosePrice", SqlDbType.SmallMoney, 4, "ActPreClosePrice")
                    .Add("@OpenPrice", SqlDbType.SmallMoney, 4, "OpenPrice")


                    .Add("@HighPrice", SqlDbType.SmallMoney, 4, "HighPrice")
                    .Add("@LowPrice", SqlDbType.SmallMoney, 4, "LowPrice")
                    .Add("@ClosePrice", SqlDbType.SmallMoney, 4, "ClosePrice")
                    .Add("@TurnoverVolume", SqlDbType.Real, 8, "TurnoverVolume")
                    .Add("@TurnoverValue", SqlDbType.Real, 8, "TurnoverValue")

                    .Add("@DealAmount", SqlDbType.Int, 8, "DealAmount")
                    .Add("@TurnoverRate", SqlDbType.Real, 4, "TurnoverRate")
                    .Add("@AccumAdjFactor", SqlDbType.Real, 4, "AccumAdjFactor")
                    .Add("@NegMarketValue", SqlDbType.Real, 8, "NegMarketValue")
                    .Add("@MarketValue", SqlDbType.Real, 8, "MarketValue")

                    .Add("@PE", SqlDbType.Real, 4, "PE")
                    .Add("@PE1", SqlDbType.Real, 4, "PE1")
                    .Add("@PB", SqlDbType.Real, 4, "PB")

                End With

                adapter.UpdateCommand = Command_Update

                ''

                strCommand = String.Format("Insert into StockPriceDaily (SecurityID,Symbol,TheDate, PreClosePrice,ActPreClosePrice,OpenPrice,  " & _
                                           "HighPrice,LowPrice,ClosePrice, TurnoverVolume,TurnoverValue,  " & _
                                           " DealAmount , TurnoverRate,AccumAdjFactor,NegMarketValue,MarketValue, PE,PE1,PB)" & _
                                           " Values (@SecurityID,@Symbol,@TheDate, @PreClosePrice,@ActPreClosePrice,@OpenPrice, " & _
                                           " @HighPrice,@LowPrice,@ClosePrice, @TurnoverVolume,@TurnoverValue, " & _
                                           " @DealAmount , @TurnoverRate,@AccumAdjFactor,@NegMarketValue,@MarketValue, @PE, @PE1, @PB)")
                Dim Command_Insert As SqlCommand = New SqlCommand(strCommand, conn)


                With Command_Insert.Parameters
                    .Add("@SecurityID", SqlDbType.NChar, 15, "SecurityID")
                    .Add("@Symbol", SqlDbType.NChar, 10, "Symbol")
                    .Add("@TheDate", SqlDbType.Date, 4, "TheDate")
                    .Add("@PreClosePrice", SqlDbType.SmallMoney, 4, "PreClosePrice")
                    .Add("@ActPreClosePrice", SqlDbType.SmallMoney, 4, "ActPreClosePrice")
                    .Add("@OpenPrice", SqlDbType.SmallMoney, 4, "OpenPrice")

                    .Add("@HighPrice", SqlDbType.SmallMoney, 4, "HighPrice")
                    .Add("@LowPrice", SqlDbType.SmallMoney, 4, "LowPrice")
                    .Add("@ClosePrice", SqlDbType.SmallMoney, 4, "ClosePrice")
                    .Add("@TurnoverVolume", SqlDbType.Real, 4, "TurnoverVolume")
                    .Add("@TurnoverValue", SqlDbType.Real, 4, "TurnoverValue")

                    .Add("@DealAmount", SqlDbType.Int, 8, "DealAmount")
                    .Add("@TurnoverRate", SqlDbType.Real, 4, "TurnoverRate")
                    .Add("@AccumAdjFactor", SqlDbType.Real, 4, "AccumAdjFactor")
                    .Add("@NegMarketValue", SqlDbType.Real, 8, "NegMarketValue")
                    .Add("@MarketValue", SqlDbType.Real, 8, "MarketValue")

                    .Add("@PE", SqlDbType.Real, 4, "PE")
                    .Add("@PE1", SqlDbType.Real, 4, "PE1")
                    .Add("@PB", SqlDbType.Real, 4, "PB")
                End With

                adapter.InsertCommand = Command_Insert


                adapter.Update(Me)

                'adapter.ContinueUpdateOnError = True

                'parameter.SourceColumn = "CategoryID"
                'parameter.SourceVersion = DataRowVersion.Original

                'adapter.Update(Me.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
                'adapter.Update(Me.Select(Nothing, Nothing, DataViewRowState.Added))



            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Function


        ' ''' <summary>
        ' ''' 删除停盘的数据行，特征为价格与前一天完全一样
        ' ''' </summary>
        'Public Overrides Function RemoveSilentPrice() As Boolean

        '    Try
        '        Dim lastrow As DataRow
        '        lastrow = Me.Rows(0)

        '        Dim iFirstRowTag As Boolean = True

        '        For Each row As DataRow In Me.Rows
        '            If iFirstRowTag = False Then
        '                If row("openIndex") = 0 Or row("closeIndex") = lastrow("closeIndex") Then

        '                    row.Delete()

        '                Else
        '                    lastrow = row
        '                End If
        '            Else
        '                iFirstRowTag = False
        '            End If
        '        Next
        '        Me.AcceptChanges()
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '        Return False


        '    End Try

        'End Function

        'Protected Overrides Function compressDT(dp As EHistoryDataPeriodType) As CDTDaily
        '    Dim dt As New CDTDaily

        '    Dim HighPrice As Double
        '    Dim LowPrice As Double
        '    Dim TurnoverVolume As Double
        '    Dim TurnoverValue As Double

        '    Dim iCount As Integer = 0

        '    '第一行赋值
        '    Dim row As DataRow = dt.NewRow()

        '    CopyDataRow(Me.Rows(0), row)

        '    HighPrice = Me.Rows(0).Item("highestIndex")
        '    LowPrice = Me.Rows(0).Item("lowestIndex")
        '    TurnoverVolume = Me.Rows(0).Item("turnoverVol")
        '    TurnoverValue = Me.Rows(0).Item("turnoverValue")

        '    For i = 1 To Me.Rows.Count - 1
        '        Dim bSamePeriod As Boolean = IsSameDatePeriod(dp, Me.Rows(i - 1).Item("TheDate"), Me.Rows(i).Item("TheDate"))
        '        If bSamePeriod Then
        '            If HighPrice < Me.Rows(i).Item("highestIndex") Then
        '                HighPrice = Me.Rows(i).Item("highestIndex")
        '            End If

        '            If LowPrice > Me.Rows(i).Item("lowestIndex") Then
        '                LowPrice = Me.Rows(i).Item("lowestIndex")
        '            End If

        '            TurnoverVolume = TurnoverVolume + Me.Rows(i).Item("turnoverVol")
        '            TurnoverValue = TurnoverValue + Me.Rows(i).Item("turnoverValue")
        '        Else
        '            'row(i-1)为上周期最后一天，新增加上周期数据行
        '            row("highestIndex") = HighPrice
        '            row("lowestIndex") = LowPrice
        '            row("turnoverVol") = TurnoverVolume
        '            row("turnoverValue") = TurnoverValue
        '            row("closeIndex") = Me.Rows(i - 1).Item("closeIndex")
        '            dt.Rows.Add(row)

        '            '新周期行赋值
        '            row = dt.NewRow()
        '            CopyDataRow(Me.Rows(i), row)

        '            HighPrice = Me.Rows(i).Item("highestIndex")
        '            LowPrice = Me.Rows(i).Item("lowestIndex")
        '            TurnoverVolume = Me.Rows(i).Item("turnoverVol")
        '            TurnoverValue = Me.Rows(i).Item("turnoverValue")

        '            If i = Me.Rows.Count - 1 Then
        '                dt.Rows.Add(row)
        '            End If
        '        End If


        '    Next

        '    Return dt

        'End Function

    End Class
End Namespace
