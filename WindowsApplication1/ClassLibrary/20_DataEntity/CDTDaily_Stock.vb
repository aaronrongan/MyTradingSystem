Imports MyTradingSystem.DataEntity
Imports MyTradingSystem.DataBase
Imports MyTradingSystem.DataFeed
Imports System.Threading
Imports System.Data.SqlClient

Namespace DataEntity

    Public Class CDTDaily_Stock
        Inherits CDTDaily

        'Protected m_Col21Name As String = "OpenPrice_FA"



        '前复权数据
        Protected m_Col21Name As String = "OpenPrice_FA"
        Protected m_Col22Name As String = "HighPrice_FA"
        Protected m_Col23Name As String = "LowPrice_FA"
        Protected m_Col24Name As String = "ClosePrice_FA"

        '后复权数据
        Protected m_Col31Name As String = "OpenPrice_BA"
        Protected m_Col32Name As String = "HighPrice_BA"
        Protected m_Col33Name As String = "LowPrice_BA"
        Protected m_Col34Name As String = "ClosePrice_BA"

        Protected m_PriceAdjustedType As EPriceAdjustedType = EPriceAdjustedType.ForAdj

        Public Event InsertProgress(ByVal iProgress As Integer)


        Public Sub New()
            MyBase.New()

            Dim Col21 As DataColumn = Me.Columns.Add(m_Col21Name, GetType(System.Single))
            Dim Col22 As DataColumn = Me.Columns.Add(m_Col22Name, GetType(System.Single))
            Dim Col23 As DataColumn = Me.Columns.Add(m_Col23Name, GetType(System.Single))
            Dim Col24 As DataColumn = Me.Columns.Add(m_Col24Name, GetType(System.Single))

            Dim Col31 As DataColumn = Me.Columns.Add(m_Col31Name, GetType(System.Single))
            Dim Col32 As DataColumn = Me.Columns.Add(m_Col32Name, GetType(System.Single))
            Dim Col33 As DataColumn = Me.Columns.Add(m_Col33Name, GetType(System.Single))
            Dim Col34 As DataColumn = Me.Columns.Add(m_Col34Name, GetType(System.Single))

            '通联上的其他字段
            Me.Columns.Add("PreClosePrice", GetType(System.Single))
            Me.Columns.Add("ActPreClosePrice", GetType(System.Single))
            Me.Columns.Add("DealAmount", GetType(System.Single))
            Me.Columns.Add("TurnoverRate", GetType(System.Single))
            Me.Columns.Add("AccumAdjFactor", GetType(System.Single))
            Me.Columns.Add("NegMarketValue", GetType(System.Single))
            Me.Columns.Add("MarketValue", GetType(System.Single))
            Me.Columns.Add("PE", GetType(System.Single))
            Me.Columns.Add("PE1", GetType(System.Single))
            Me.Columns.Add("PB", GetType(System.Single))

            m_strSQLTableName = "StockPriceDaily"
            Me.TableName = m_strSQLTableName
        End Sub



        ''' <summary>
        ''' 插入一个股票所有数据到SQL，在CDB类存储过程中按行插入
        ''' </summary>
        ''' <param name="strSymbol"></param>
        ''' <remarks></remarks>
        Public Overloads Sub InsertTable2SQL(strSymbol As String, Optional ByVal PriceType As EPriceAdjustedType = EPriceAdjustedType.Normal)
            Try
                Dim obj As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
                If PriceType = EPriceAdjustedType.Normal Then
                    obj.ExecStoredProcedure_InsertTablebyRow("dbo.PSD_InsertStockDaily", Me)
                ElseIf PriceType = EPriceAdjustedType.ForAdj Then
                    obj.ExecStoredProcedure_InsertTablebyRow("dbo.PSD_InsertStockDaily", Me)
                ElseIf PriceType = EPriceAdjustedType.BacAdj Then
                    obj.ExecStoredProcedure_InsertTablebyRow("dbo.PSD_InsertStockDaily", Me)
                End If
            Catch

            End Try

        End Sub


        ''' <summary>
        ''' 插入一个股票所有数据到SQL，在本Function中按行插入，而CDB类存储过程中每次只执行一行
        ''' </summary>
        ''' <param name="strSymbol"></param>
        ''' <param name="PriceType"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function InsertTable2SQLbyRow(strSymbol As String, Optional ByVal PriceType As EPriceAdjustedType = EPriceAdjustedType.Normal) As Boolean
            Dim obj As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
            Try

                Dim iRowTotal As Integer
                Dim iValidRow As Integer = 0
                iRowTotal = Me.Rows.Count
                Dim iRow As Integer = 0

                For iRow = 0 To iRowTotal - 1
                    If (obj.ExecStoredProcedure_InsertRow("dbo.PSD_InsertStockDaily", Me, iRow) = True) Then
                        iValidRow = iValidRow + 1
                    End If
                    RaiseEvent InsertProgress(iRow + 1) '通知用户界面关于插入进展
                Next

                For iRow = 0 To iRowTotal - 1
                    If (obj.ExecStoredProcedure_InsertRow("dbo.PSD_InsertStockDaily", Me, iRow) = True) Then
                        iValidRow = iValidRow + 1
                    End If
                    RaiseEvent InsertProgress(iRow + 1) '通知用户界面关于插入进展
                Next

                If iValidRow > 0 Then
                    'MsgBox("导入成功。共导入" & iValidRow & "行")
                    Return True
                Else
                    'MsgBox("导入不成功")
                    Return False
                End If

            Catch ex As Exception
                'MsgBox(ex.Message)

                Return False
            End Try

        End Function

        ''' <summary>
        ''' 批量插入数据表
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <remarks></remarks>
        Public Overrides Function BulkInsertDataTable2SQL() As Boolean

            Dim obj1 As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
            Try

                Dim strMappingList As New SortedList(Of String, String)

                strMappingList.Add("SecurityID", "SecurityID")
                strMappingList.Add("Symbol", "Symbol")
                strMappingList.Add("TheDate", "TheDate")
                strMappingList.Add("PreClosePrice", "PreClosePrice")
                strMappingList.Add("ActPreClosePrice", "ActPreClosePrice")

                strMappingList.Add("OpenPrice", "OpenPrice")
                strMappingList.Add("HighPrice", "HighPrice")
                strMappingList.Add("LowPrice", "LowPrice")
                strMappingList.Add("ClosePrice", "ClosePrice")
                strMappingList.Add("TurnoverVolume", "TurnoverVolume")

                strMappingList.Add("TurnoverValue", "TurnoverValue")
                strMappingList.Add("DealAmount", "DealAmount")
                strMappingList.Add("TurnoverRate", "TurnoverRate")
                strMappingList.Add("AccumAdjFactor", "AccumAdjFactor")
                strMappingList.Add("NegMarketValue", "NegMarketValue")

                strMappingList.Add("MarketValue", "MarketValue")
                strMappingList.Add("PE", "PE")
                strMappingList.Add("PE1", "PE1")
                strMappingList.Add("PB", "PB")
                strMappingList.Add("OpenPrice_FA", "OpenPrice_FA")

                strMappingList.Add("HighPrice_FA", "HighPrice_FA")
                strMappingList.Add("LowPrice_FA", "LowPrice_FA")
                strMappingList.Add("ClosePrice_FA", "ClosePrice_FA")
                strMappingList.Add("OpenPrice_BA", "OpenPrice_BA")
                strMappingList.Add("HighPrice_BA", "HighPrice_BA")

                strMappingList.Add("LowPrice_BA", "LowPrice_BA")
                strMappingList.Add("ClosePrice_BA", "ClosePrice_BA")


                'obj1.BulkInsertDataTable(Me, "StockPriceDaily", strMappingList)

                If obj1.BulkInsertDataTable(Me, m_strSQLTableName, strMappingList) Then
                    Return True
                Else
                    Return False
                End If


            Catch ex As Exception
                'MsgBox(ex.Message)
                Return False
            Finally
                obj1 = Nothing
            End Try

        End Function

        ''' <summary>
        ''' 能否在Datatable中做好变更再一次性导入SQL?
        ''' </summary>
        Public Sub UploadCachedTable(ByVal TableName As String)
            Try

                'Dim obj As New DataBase.CDBADOSQLAdapter

                'obj.UploadCachedDataTable()
            Catch ex As Exception

            End Try
        End Sub

        ''' <summary>
        ''' 根据一个Symbol进行DataTable的维护，先从SQL读出datatable，然后进行循环比较update后，再批量用SQLAdapter进行维护 
        ''' </summary>
        ''' <param name="strSymbol"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdatePriceDailybySymbol2SQL(strSymbol As String) As Int32 '更新所有日期数据
            Try

                Dim iRow As Int16, iSourceTotalRow As Int16
                Dim dt As New DataTable
                Dim foundRows As DataRow()
                Dim newRow As DataRow
                Dim sa As New CDBADOSQLAdapter(GlobalVariables.gSQLConnectionString, Me.TableName)
                Dim ac As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
                Dim oDTP_FA As New CDTDaily_Stock
                Dim dbTDX As New CDataFeedTDX

                Dim strSelect As String
                '先生成SQL已有数据
                GetDailyPricebySymbolfromSQL(strSymbol)


                '得出前复权数据
                oDTP_FA = dbTDX.FeedStockDaily_General_TDX(strSymbol, EPriceAdjustedType.ForAdj)

                CombineDataTablePriceTDX(strSymbol, Me, oDTP_FA)
                'MsgBox(Me.Rows.Count)
                '得到TDX中的新价格数据(Day文件格式)
                'dt = GetNormalDailyPricebySymbol(strSymbol)
                'iSourceTotalRow = dt.Rows.Count

                ''1).查有没有多的数据，如有，则插入 2).已有的数据进行Update
                'For iRow = 0 To iSourceTotalRow - 1

                '    '注意：这里要加CDate,否则日期格式一个为2015-10-1 0:0:0，一个为2015-10-1，
                '    '反思：这几行代码没有效率, 因为symbol已经知道了
                '    '另外，因为日期本来就是排序的，所以应该不用select，而是直接顺序查找即可。
                '    strSelect = "TheDate='" & dt.Rows(iRow).Item("TheDate") & "'" ' and Symbol='" & strSymbol & "'"
                '    foundRows = Me.Select(strSelect)

                '    If foundRows.Length = 0 Then
                '        '未找到就插入
                '        'With newRow
                '        newRow = Me.NewRow()
                '        newRow.Item("TheDate") = dt.Rows(iRow).Item("TheDate")
                '        newRow.Item("Symbol") = strSymbol 'dt.Rows(iRow).Item("Symbol")
                '        newRow.Item("OpenPrice") = dt.Rows(iRow).Item("OpenPrice")
                '        newRow.Item("HighPrice") = dt.Rows(iRow).Item("HighPrice")
                '        newRow.Item("LowPrice") = dt.Rows(iRow).Item("LowPrice")
                '        newRow.Item("ClosePrice") = dt.Rows(iRow).Item("ClosePrice")
                '        newRow.Item("Volume") = dt.Rows(iRow).Item("Volume")
                '        newRow.Item("TotalAmount") = dt.Rows(iRow).Item("TotalAmount")
                '        Me.Rows.Add(newRow)


                '    ElseIf foundRows.Length = 1 Then
                '        '找到就Update
                '        Me.Rows(iRow).Item("OpenPrice") = dt.Rows(iRow).Item("OpenPrice")
                '        Me.Rows(iRow).Item("HighPrice") = dt.Rows(iRow).Item("HighPrice")
                '        Me.Rows(iRow).Item("LowPrice") = dt.Rows(iRow).Item("LowPrice")
                '        Me.Rows(iRow).Item("ClosePrice") = dt.Rows(iRow).Item("ClosePrice")
                '        Me.Rows(iRow).Item("Volume") = dt.Rows(iRow).Item("Volume")
                '        Me.Rows(iRow).Item("TotalAmount") = dt.Rows(iRow).Item("TotalAmount")
                '    End If
                'Next


                '先删除该Symbol再重新Bulk一次
                ac.Delete(Me.TableName, "Symbol", strSymbol)
                Me.BulkInsertDataTable2SQL()

                '最后进行SQL的重新Fill ， 为什么不能Fill
                'sa.UploadCachedDataTable2SQL(Me)


                Return 1
            Catch ex As Exception
                'MsgBox(ex.Message)
                Return -1
            End Try
        End Function

        ''' <summary>
        ''' 根据Symbol值得出DailyPrice的DataTable，以便后续操作
        ''' </summary>
        Public Function GetNormalDailyPricebySymbol(strSymbol As String) As DataTable

            'Dim df As New CDataFeedTDX

            'Return df.FeedTDX_PureDAYFormatFile(strSymbol)

        End Function

        ''' <summary>
        ''' 根据Symbol值得出DailyPrice的DataTable，以便后续操作，TXT格式文件
        ''' </summary>
        Public Function FeedAdjustedDailyPricebySymbol(strSymbol As String, Optional ByVal pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj) As CDTDaily_Stock

            Dim df As New CDataFeedTDX

            Return df.FeedStockDaily_General_TDX(strSymbol, pat)

        End Function



        ''' <summary>
        ''' 从TDX、通联中抓取对应前复权、正常日线数据，override基类，因为股票数据有前复权、后复权，所以需要合并2个数据
        ''' </summary>
        ''' <param name="stSymbol"></param>
        ''' <param name="pat"></param>
        ''' <param name="dtStartDate"></param>
        ''' <param name="dtEndDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function FeedDataTablePrice(strSymbol As String, Optional ByVal pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj, Optional ByVal dtStartDate As String = "", Optional ByVal dtEndDate As String = "") As Int32
            Dim oDTP_FA As New CDTDaily_Stock
            Dim oDTP_BA As New CDTDaily_Stock
            Dim dbTDX As New CDataFeedTDX
            Dim df As New DataFeed.CDataFeedDatayes_Price

            Try
                Dim dt As New DataTable
                dt = df.FeedStockDailyPriceDataTable(, Trim(strSymbol), "", dtStartDate, dtEndDate)

                If Not IsNothing(dt) Then
                    If dt.Rows.Count > 0 Then


                        Me.Rows.Clear()
                        AdaptDatafromDataTable(dt)  '将获取的数据转为CDTDailyXXX格式

                        '从TDX获取得出前复权数据()
                        oDTP_FA = dbTDX.FeedStockDaily_General_TDX(Trim(strSymbol), EPriceAdjustedType.ForAdj, dtStartDate, dtEndDate)

                        '如果TDX有前复权数据，则合并，
                        If oDTP_FA.Rows.Count <> 0 Then
                            '合并上面2个Datayes和前复权数据。后复权先不做。
                            CombineDataTablePriceTDX_Datayes(Trim(strSymbol), oDTP_FA)
                        Else '否则将前复权数据先用正常数据填充()
                            MakeFAVaueasNormal()
                        End If

                        Return dt.Rows.Count
                    Else
                        '通联没有数据
                        Return 0
                    End If

                    '通联没有数据
                    Return 0
                End If
            Catch ex As Exception
                Return 0
            End Try

        End Function

        ''' <summary>
        ''' 从TDX中抓取的正常、前复权、后复权数据进行合并，返回Me  As CDTDaily_Stock。后复权先不做。先合并前复权和后复权操作
        ''' </summary>
        ''' <param name="dtNormal"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CombineDataTablePriceTDX(strSymbol As String, ByRef dtNormal As CDTDaily_Stock, ByVal dtFA As CDTDaily_Stock, Optional ByVal dtBA As CDTDaily_Stock = Nothing)


            Dim strSelect As String
            Dim foundRow, foundRows(), NewRow As DataRow

            '1).查FA表格中在Me表格有没有现有数据，如没有，则插入到Me主表中 2).已有的数据进行Update
            For Each sourceRow As DataRow In dtFA.Rows
                strSelect = "TheDate='" & sourceRow.Item("TheDate") & "'" ' and Symbol='" & strSymbol & "'"
                Dim findvalues(1) As Object
                findvalues(0) = strSymbol
                findvalues(1) = sourceRow.Item("TheDate")

                ' foundRows = Me.Select(strSelect) 用Select太花时间
                foundRow = Me.Rows.Find(findvalues) '用主键而不是Select取查询

                'If foundRows.Length = 0 Then
                If foundRow Is Nothing Then
                    '未找到就插入
                    NewRow = Me.NewRow()
                    NewRow.Item("TheDate") = sourceRow.Item("TheDate")
                    NewRow.Item("Symbol") = strSymbol '
                    NewRow.Item("OpenPrice_FA") = sourceRow.Item("OpenPrice_FA")
                    NewRow.Item("HighPrice_FA") = sourceRow.Item("HighPrice_FA")
                    NewRow.Item("LowPrice_FA") = sourceRow.Item("LowPrice_FA")
                    NewRow.Item("ClosePrice_FA") = sourceRow.Item("ClosePrice_FA")
                    'NewRow.Item("Volume") = dtFA.Rows(iRow).Item("Volume")
                    'NewRow.Item("TotalAmount") = dtFA.Rows(iRow).Item("TotalAmount")
                    Me.Rows.Add(NewRow)

                    'ElseIf foundRows.Length = 1 Then
                Else
                    '找到就Update
                    foundRow.Item("OpenPrice_FA") = sourceRow.Item("OpenPrice_FA")
                    foundRow.Item("HighPrice_FA") = sourceRow.Item("HighPrice_FA")
                    foundRow.Item("LowPrice_FA") = sourceRow.Item("LowPrice_FA")
                    foundRow.Item("ClosePrice_FA") = sourceRow.Item("ClosePrice_FA")

                    'foundRows(0).Item("OpenPrice_FA") = sourceRow.Item("OpenPrice_FA")
                    'foundRows(0).Item("HighPrice_FA") = sourceRow.Item("HighPrice_FA")
                    'foundRows(0).Item("LowPrice_FA") = sourceRow.Item("LowPrice_FA")
                    'foundRows(0).Item("ClosePrice_FA") = sourceRow.Item("ClosePrice_FA")
                    'Me.Rows(iRow).Item("Volume") = dtFA.Rows(iRow).Item("Volume")
                    'Me.Rows(iRow).Item("TotalAmount") = dtFA.Rows(iRow).Item("TotalAmount")
                End If

            Next


        End Function

        ''' <summary>
        ''' 针对通联数据中的证券通用信息数据表
        ''' </summary>
        ''' <param name="dt_datayes"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overrides Function AdaptDatafromDataTable(ByVal dt_datayes As DataTable) As Boolean

            Try

                For Each row As DataRow In dt_datayes.Rows
                    Dim merow As DataRow = Me.NewRow

                    merow.Item("SecurityID") = row.Item("secID")
                    merow.Item("Symbol") = row.Item("ticker")
                    merow.Item("TheDate") = row.Item("tradeDate")
                    merow.Item("PreClosePrice") = row.Item("preClosePrice")
                    merow.Item("ActPreClosePrice") = row.Item("actPreClosePrice")

                    merow.Item("OpenPrice") = row.Item("openPrice")
                    merow.Item("HighPrice") = row.Item("highestPrice")
                    merow.Item("LowPrice") = row.Item("lowestPrice")
                    merow.Item("ClosePrice") = row.Item("closePrice")
                    merow.Item("TurnoverVolume") = row.Item("turnoverVol")

                    merow.Item("TurnoverValue") = row.Item("turnoverValue")
                    merow.Item("DealAmount") = row.Item("dealAmount")
                    merow.Item("TurnoverRate") = row.Item("turnoverRate")
                    merow.Item("AccumAdjFactor") = row.Item("accuAdjFactor")
                    merow.Item("NegMarketValue") = row.Item("negMarketValue")

                    merow.Item("MarketValue") = row.Item("marketValue")
                    merow.Item("PE") = row.Item("PE")
                    merow.Item("PE1") = row.Item("PE1")
                    merow.Item("PB") = row.Item("PB")
                    'merow.Item("") = row.Item("")

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

        ''' <summary>
        ''' 从TDX中抓取的前复权与通联的正常数据合并，返回MeAs CDTDaily_Stock。后复权先不做。
        ''' </summary>
        ''' <param name="dtNormal"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overrides Function CombineDataTablePriceTDX_Datayes(strSymbol As String, ByVal dtFA As CDTDaily_Stock, Optional ByVal dtBA As CDTDaily_Stock = Nothing)


            Dim strSelect As String
            Dim foundRow, foundRows(), NewRow As DataRow

            '1).查FA表格中在Me表格有没有现有数据，如没有，则插入到Me主表中 2).已有的数据进行Update
            For Each sourceRow As DataRow In dtFA.Rows
                strSelect = "TheDate='" & sourceRow.Item("TheDate") & "'" ' and Symbol='" & strSymbol & "'"
                Dim findvalues(1) As Object
                findvalues(0) = strSymbol
                findvalues(1) = sourceRow.Item("TheDate")

                foundRow = Me.Rows.Find(findvalues) '用主键而不是Select取查询，提高效率

                If foundRow Is Nothing Then
                    '不插入Datayes中没有的日期行数据
                    'NewRow = Me.NewRow()
                    'NewRow.Item("TheDate") = sourceRow.Item("TheDate")
                    'NewRow.Item("Symbol") = strSymbol '
                    'NewRow.Item("OpenPrice_FA") = sourceRow.Item("OpenPrice_FA")
                    'NewRow.Item("HighPrice_FA") = sourceRow.Item("HighPrice_FA")
                    'NewRow.Item("LowPrice_FA") = sourceRow.Item("LowPrice_FA")
                    'NewRow.Item("ClosePrice_FA") = sourceRow.Item("ClosePrice_FA")

                    'Me.Rows.Add(NewRow)

                Else
                    '找到就Update
                    foundRow.Item("OpenPrice_FA") = sourceRow.Item("OpenPrice_FA")
                    foundRow.Item("HighPrice_FA") = sourceRow.Item("HighPrice_FA")
                    foundRow.Item("LowPrice_FA") = sourceRow.Item("LowPrice_FA")
                    foundRow.Item("ClosePrice_FA") = sourceRow.Item("ClosePrice_FA")

                End If

            Next


        End Function

        ''' <summary>
        ''' 合并Datayes的正常价格和复权价格数据
        ''' </summary>
        ''' <param name="dt_datayes"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function CombineDataTablePrice_Datayes_Normal_PreAdj(strSymbol As String, ByVal dt_datayes_preadj As DataTable) As Boolean

            Try
                Dim strSelect As String
                Dim foundRow, foundRows(), NewRow As DataRow

                '1).查FA表格中在Me表格有没有现有数据，如没有，则插入到Me主表中 2).已有的数据进行Update
                For Each sourceRow As DataRow In dt_datayes_preadj.Rows
                    strSelect = "TheDate='" & sourceRow.Item("TheDate") & "'" ' and Symbol='" & strSymbol & "'"
                    Dim findvalues(1) As Object
                    findvalues(0) = strSymbol
                    findvalues(1) = sourceRow.Item("TheDate")

                    foundRow = Me.Rows.Find(findvalues) '用主键而不是Select取查询，提高效率

                    If Not IsNothing(foundRow) Then
                        '找到就Update
                        foundRow.Item("OpenPrice_FA") = sourceRow.Item("OpenPrice_FA")
                        foundRow.Item("HighPrice_FA") = sourceRow.Item("HighPrice_FA")
                        foundRow.Item("LowPrice_FA") = sourceRow.Item("LowPrice_FA")
                        foundRow.Item("ClosePrice_FA") = sourceRow.Item("ClosePrice_FA")
                    End If

                Next


                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Function

        ''' <summary>
        ''' 将前复权数据修改为和正常数据(因暂时没有复权数据)
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub MakeFAVaueasNormal()

            For Each row As DataRow In Me.Rows
                row.Item("OpenPrice_FA") = row.Item("OpenPrice")
                row.Item("HighPrice_FA") = row.Item("HighPrice")
                row.Item("LowPrice_FA") = row.Item("LowPrice")
                row.Item("ClosePrice_FA") = row.Item("ClosePrice")
            Next
        End Sub

        Public Function SetPriceAdjustedType(pat As EPriceAdjustedType) As Boolean

            m_PriceAdjustedType = pat
            
        End Function
        Public Overrides Function GetOpenPrice(index As Short) As Double

            Dim OpenPrice, OpenPrice_FA, OpenPrice_BA As Double

            If IsDBNull(Me.Rows(index).Item("OpenPrice")) Then
                OpenPrice = -1
            Else
                OpenPrice = Me.Rows(index).Item("OpenPrice")
            End If

            If IsDBNull(Me.Rows(index).Item("OpenPrice_FA")) Then
                OpenPrice_FA = OpenPrice
            Else
                OpenPrice_FA = Me.Rows(index).Item("OpenPrice_FA")
            End If

            If IsDBNull(Me.Rows(index).Item("OpenPrice_BA")) Then
                OpenPrice_BA = OpenPrice
            Else
                OpenPrice_BA = Me.Rows(index).Item("OpenPrice_BA")
            End If

            If m_PriceAdjustedType = EPriceAdjustedType.Normal Then
                Return OpenPrice
            ElseIf m_PriceAdjustedType = EPriceAdjustedType.ForAdj Then
                Return OpenPrice_FA
            ElseIf m_PriceAdjustedType = EPriceAdjustedType.BacAdj Then
                Return OpenPrice_BA
            End If

        End Function

        Public Overrides Function GetHighPrice(index As Short) As Double
            Dim HighPrice, HighPrice_FA, HighPrice_BA As Double

            If IsDBNull(Me.Rows(index).Item("HighPrice")) Then
                HighPrice = -1
            Else
                HighPrice = Me.Rows(index).Item("HighPrice")
            End If

            If IsDBNull(Me.Rows(index).Item("HighPrice_FA")) Then
                HighPrice_FA = HighPrice
            Else
                HighPrice_FA = Me.Rows(index).Item("HighPrice_FA")
            End If

            If IsDBNull(Me.Rows(index).Item("HighPrice_BA")) Then
                HighPrice_BA = HighPrice
            Else
                HighPrice_BA = Me.Rows(index).Item("HighPrice_BA")
            End If

            If m_PriceAdjustedType = EPriceAdjustedType.Normal Then
                Return HighPrice
            ElseIf m_PriceAdjustedType = EPriceAdjustedType.ForAdj Then
                Return HighPrice_FA
            ElseIf m_PriceAdjustedType = EPriceAdjustedType.BacAdj Then
                Return HighPrice_BA
            End If

        End Function

        Public Overrides Function GetLowPrice(index As Short) As Double
            Dim LowPrice, LowPrice_FA, LowPrice_BA As Double

            If IsDBNull(Me.Rows(index).Item("LowPrice")) Then
                LowPrice = -1
            Else
                LowPrice = Me.Rows(index).Item("LowPrice")
            End If

            If IsDBNull(Me.Rows(index).Item("LowPrice_FA")) Then
                LowPrice_FA = LowPrice
            Else
                LowPrice_FA = Me.Rows(index).Item("LowPrice_FA")
            End If

            If IsDBNull(Me.Rows(index).Item("LowPrice_BA")) Then
                LowPrice_BA = LowPrice
            Else
                LowPrice_BA = Me.Rows(index).Item("LowPrice_BA")
            End If

            If m_PriceAdjustedType = EPriceAdjustedType.Normal Then
                Return LowPrice
            ElseIf m_PriceAdjustedType = EPriceAdjustedType.ForAdj Then
                Return LowPrice_FA
            ElseIf m_PriceAdjustedType = EPriceAdjustedType.BacAdj Then
                Return LowPrice_BA
            End If
        End Function

        Public Overrides Function GetClosePrice(index As Short) As Double
            Dim ClosePrice, ClosePrice_FA, ClosePrice_BA As Double

            If IsDBNull(Me.Rows(index).Item("ClosePrice")) Then
                ClosePrice = -1
            Else
                ClosePrice = Me.Rows(index).Item("ClosePrice")
            End If

            If IsDBNull(Me.Rows(index).Item("ClosePrice_FA")) Then
                ClosePrice_FA = ClosePrice
            Else
                ClosePrice_FA = Me.Rows(index).Item("ClosePrice_FA")
            End If

            If IsDBNull(Me.Rows(index).Item("ClosePrice_BA")) Then
                ClosePrice_BA = ClosePrice
            Else
                ClosePrice_BA = Me.Rows(index).Item("ClosePrice_BA")
            End If

            If m_PriceAdjustedType = EPriceAdjustedType.Normal Then
                Return ClosePrice
            ElseIf m_PriceAdjustedType = EPriceAdjustedType.ForAdj Then
                Return ClosePrice_FA
            ElseIf m_PriceAdjustedType = EPriceAdjustedType.BacAdj Then
                Return ClosePrice_BA
            End If
        End Function


        Public Overrides Function GetVolume(index As Short) As Double

            If m_PriceAdjustedType = EPriceAdjustedType.Normal Then
                Return Me.Rows(index).Item("TurnoverVolume")
            ElseIf m_PriceAdjustedType = EPriceAdjustedType.ForAdj Then
                Return Me.Rows(index).Item("TurnoverVolume")
            ElseIf m_PriceAdjustedType = EPriceAdjustedType.BacAdj Then
                Return Me.Rows(index).Item("TurnoverVolume")
            End If
        End Function

        Public Overrides Function GetTurnoverValue(index As Short) As Double

            If m_PriceAdjustedType = EPriceAdjustedType.Normal Then
                Return Me.Rows(index).Item("TurnoverValue")
            ElseIf m_PriceAdjustedType = EPriceAdjustedType.ForAdj Then
                Return Me.Rows(index).Item("TurnoverValue")
            ElseIf m_PriceAdjustedType = EPriceAdjustedType.BacAdj Then
                Return Me.Rows(index).Item("TurnoverValue")
            End If
        End Function

        Protected Overrides Sub CopyDataRow(rowsource As DataRow, rowdest As DataRow)
           
            MyBase.CopyDataRow(rowsource, rowdest)

            rowdest("OpenPrice_FA") = rowsource("OpenPrice_FA")
            rowdest("HighPrice_FA") = rowsource("HighPrice_FA")
            rowdest("LowPrice_FA") = rowsource("LowPrice_FA")
            rowdest("ClosePrice_FA") = rowsource("ClosePrice_FA")



        End Sub

        'Protected Overrides Function compressDT(dp As EHistoryDataPeriodType) As CDTDaily
        '    Dim dt As New CDTDaily_Stock

        '    Dim bNewWeek As Boolean = True

        '    Dim HighPrice As Double
        '    Dim LowPrice As Double
        '    Dim TurnoverVolume As Double
        '    Dim TurnoverValue As Double

        '    Dim iCount As Integer = 0

        '    '第一行赋值
        '    Dim row As DataRow = dt.NewRow()

        '    CopyDataRow(Me.Rows(0), row)

        '    If m_PriceAdjustedType = EPriceAdjustedType.Normal Then
        '        HighPrice = Me.Rows(0).Item("HighPrice")
        '        LowPrice = Me.Rows(0).Item("LowPrice")
        '    ElseIf m_PriceAdjustedType = EPriceAdjustedType.ForAdj Then
        '        HighPrice = Me.Rows(0).Item("HighPrice_FA")
        '        LowPrice = Me.Rows(0).Item("LowPrice_FA")
        '    End If

        '    TurnoverVolume = Me.Rows(0).Item("TurnoverVolume")
        '    TurnoverValue = Me.Rows(0).Item("TurnoverValue")

        '    For i = 1 To Me.Rows.Count - 1

        '        Dim bSamePeriod As Boolean = IsSameDatePeriod(dp, Me.Rows(i - 1).Item("TheDate"), Me.Rows(i).Item("TheDate"))
        '        If bSamePeriod Then
        '            If m_PriceAdjustedType = EPriceAdjustedType.Normal Then
        '                If HighPrice < Me.Rows(i).Item("HighPrice") Then
        '                    HighPrice = Me.Rows(i).Item("HighPrice")
        '                End If

        '                If LowPrice > Me.Rows(i).Item("LowPrice") Then
        '                    LowPrice = Me.Rows(i).Item("LowPrice")
        '                End If
        '            ElseIf m_PriceAdjustedType = EPriceAdjustedType.ForAdj Then
        '                If HighPrice < Me.Rows(i).Item("HighPrice_FA") Then
        '                    HighPrice = Me.Rows(i).Item("HighPrice_FA")
        '                End If

        '                If LowPrice > Me.Rows(i).Item("LowPrice_FA") Then
        '                    LowPrice = Me.Rows(i).Item("LowPrice_FA")
        '                End If
        '            End If

        '            TurnoverVolume = TurnoverVolume + Me.Rows(i).Item("TurnoverVolume")
        '            TurnoverValue = TurnoverValue + Me.Rows(i).Item("TurnoverValue")
        '        Else
        '            'row(i-1)为上周最后一天，新增加上周数据行
        '            If m_PriceAdjustedType = EPriceAdjustedType.Normal Then
        '                row("HighPrice") = HighPrice
        '                row("LowPrice") = LowPrice
        '            ElseIf m_PriceAdjustedType = EPriceAdjustedType.ForAdj Then
        '                row("HighPrice_FA") = HighPrice
        '                row("LowPrice_FA") = LowPrice
        '            End If

        '            row("TurnoverVolume") = TurnoverVolume
        '            row("TurnoverValue") = TurnoverValue
        '            'If m_PriceAdjustedType = EPriceAdjustedType.Normal Then
        '            row("ClosePrice") = Me.Rows(i - 1).Item("ClosePrice")
        '            'ElseIf m_PriceAdjustedType = EPriceAdjustedType.ForAdj Then
        '            row("ClosePrice_FA") = Me.Rows(i - 1).Item("ClosePrice_FA")
        '            'End If

        '            dt.Rows.Add(row)

        '            '新周行赋值
        '            row = dt.NewRow()
        '            CopyDataRow(Me.Rows(i), row)

        '            If m_PriceAdjustedType = EPriceAdjustedType.Normal Then
        '                HighPrice = Me.Rows(i).Item("HighPrice")
        '                LowPrice = Me.Rows(i).Item("LowPrice")
        '            ElseIf m_PriceAdjustedType = EPriceAdjustedType.ForAdj Then
        '                HighPrice = Me.Rows(i).Item("HighPrice_FA")
        '                LowPrice = Me.Rows(i).Item("LowPrice_FA")
        '            End If

        '            TurnoverVolume = Me.Rows(i).Item("TurnoverVolume")
        '            TurnoverValue = Me.Rows(i).Item("TurnoverValue")

        '            If i = Me.Rows.Count - 1 Then
        '                dt.Rows.Add(row)
        '            End If
        '        End If

        '    Next

        '    Return dt

        'End Function


    End Class
End Namespace
