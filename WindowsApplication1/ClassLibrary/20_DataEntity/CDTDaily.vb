
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports MyTradingSystem.DataBase
Imports MyTradingSystem.DataFeed



Namespace DataEntity

#Region "Enum and Structure"

    Public Enum EPriceAdjustedType As Integer
        ForAdj = -1
        Normal = 0
        BacAdj = 1
    End Enum

    Public Enum EHistoryDataPeriodType As Integer
        Daily = 0
        Weekly = 1
        Monthly = 2
        Bimonthly = 3
        Quarterly = 4
        Yearly = 5
    End Enum


    Public Structure Price
        Public TheTime As DateTime  '日期或日内时间
        Public OpenPrice As Single
        Public HighPrice As Single
        Public LowPrice As Single
        Public ClosePrice As Single
        Public Amount As Single
        Public Volume As Single
    End Structure
#End Region

    Public Class DailyBarEventArgs
        Inherits System.EventArgs

    End Class
    ''' <summary>
    ''' 日线数据表
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CDTDaily
        Inherits System.Data.DataTable
        Implements IDTPrice



        Protected m_Col0Name As String = "SecurityID"
        Protected m_Col1Name As String = "Symbol"
        Protected m_Col2Name As String = "TheDate"
        Protected m_Col3Name As String = "OpenPrice"
        Protected m_Col4Name As String = "HighPrice"
        Protected m_Col5Name As String = "LowPrice"
        Protected m_Col6Name As String = "ClosePrice"
        Protected m_Col7Name As String = "TurnoverVolume"
        Protected m_Col8Name As String = "TurnoverValue"

        Protected m_Col9Name As String      '预留
        Protected m_Col10Name As String      '预留
        Protected m_Col11Name As String      '预留
        Protected m_Col12Name As String      '预留
        Protected m_Co113Name As String

        Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker      '预留

        Protected m_strSQLTableName As String       '对应的数据表名

#Region "Constructor"
        ''' <summary>
        ''' 给本数据表进行创建，表名即为如StockPrice, IndexPrice
        ''' </summary>
        Public Sub New()

            Try

                Dim Col0 As DataColumn = Me.Columns.Add(m_Col0Name, GetType(System.String))
                'Col0.AllowDBNull = False
                'Col0.AutoIncrement = True
                'Col0.AutoIncrementSeed = 1
                'Col0.AutoIncrementStep = 1

                Dim Col1 As DataColumn = Me.Columns.Add(m_Col1Name, GetType(System.String))
                Col1.AllowDBNull = False


                Dim Col2 As DataColumn = Me.Columns.Add(m_Col2Name, GetType(System.DateTime))  '后期再转换为DateTime
                Col2.AllowDBNull = False

                '设置主键
                Dim colPrimary(2) As DataColumn
                colPrimary(0) = Col1
                colPrimary(1) = Col2

                '  DataColumn[] cols = new DataColumn[] 
                'dt_smartgrid.Columns["A"], dt_smartgrid.Columns["B"] };dt.PrimaryKey=cols;

                Me.PrimaryKey = colPrimary


                Dim Col3 As DataColumn = Me.Columns.Add(m_Col3Name, GetType(System.Single))

                Dim Col4 As DataColumn = Me.Columns.Add(m_Col4Name, GetType(System.Single))

                Dim Col5 As DataColumn = Me.Columns.Add(m_Col5Name, GetType(System.Single))

                Dim Col6 As DataColumn = Me.Columns.Add(m_Col6Name, GetType(System.Single))

                Dim Col7 As DataColumn = Me.Columns.Add(m_Col7Name, GetType(System.Double))

                Dim Col8 As DataColumn = Me.Columns.Add(m_Col8Name, GetType(System.Double))

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

#End Region


#Region "Public Methods"

        ''' <summary>
        ''' 批量插入数据表
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <remarks></remarks>
        Public Overridable Function BulkInsertDataTable2SQL() As Boolean

            Dim obj1 As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
            Try


                If obj1.BulkInsertDataTable(Me, m_strSQLTableName) Then
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
        ''' 根据Symbol值得出一个数据库现有的表，用多态实现，这样可以对子类进行代码复用，父类转子类、子类转父类？
        ''' </summary>
        ''' <param name="strSymbol"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDailyPricebySymbolfromSQL(ByVal strSymbol As String) As Boolean

            Try
                Dim objSA As New CDBADOSQLAdapter(GlobalVariables.gSQLConnectionString, Me.TableName)

                objSA.GetDataTablebySymbolfromSQL(strSymbol, Me)

                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Function

        ''' <summary>
        ''' 根据Symbol值得出一个数据库现有的表，用多态实现，这样可以对子类进行代码复用，父类转子类、子类转父类？
        ''' </summary>
        ''' <param name="strSymbol"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDailyPricebySymbolDatesfromSQL(ByVal strSymbol As String, ByVal BeginDate As String, ByVal EndDate As String) As Boolean

            Try
                Dim objSA As New CDBADOSQLAdapter(GlobalVariables.gSQLConnectionString, Me.TableName)

                objSA.GetDataTablebySymbolDatesfromSQL(strSymbol, CDate(BeginDate), CDate(EndDate), Me)

                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Function

        ''' <summary>
        ''' 删除数据表操作
        ''' </summary>
        Public Sub TruncateDataTable()

            Try
                MsgBox(String.Format("即将删除表{0}，请谨慎操作!", Me.TableName))

                Dim cmd As New CDBADOCommand(GlobalVariables.gSQLConnectionString)

                cmd.TruncateTable(Me.TableName)

            Catch ex As Exception

            End Try
        End Sub

        ''' <summary>
        ''' 删除指定Symbol相关数据表操作
        ''' </summary>
        Public Sub DeleteDataTablebySymbol(strSymbol As String)

            Try
                'MsgBox(String.Format("即将删除表{0}中的{1}，请谨慎操作!", Me.TableName, strSymbol))

                Dim cmd As New CDBADOCommand(GlobalVariables.gSQLConnectionString)

                cmd.Delete(Me.TableName, "Symbol", strSymbol)

            Catch ex As Exception

            End Try
        End Sub

        ''' <summary>
        ''' 根据条件采集数据，作为TDX、Datayes、Wind等多种来源的集合类
        ''' </summary>
        Public Sub FeedDataTable()

        End Sub

        ''' <summary>
        ''' 更新数据，可以用作一个上层类，用作每日更新、后台更新、定期更新等作用
        ''' </summary>
        Public Sub UpgradeDataTable()

        End Sub

        ''' <summary>
        ''' 根据Symbol、日期值从SQL数据库得出一个数据库现有的表，用多态实现，这样可以对子类进行代码复用
        ''' </summary>
        Public Overridable Function GetDataTablePrice(strSymbol As String, strBeginDate As String, strEndDate As String) As Boolean

            Try
                'Dim dt As New CDTDaily

                Dim objSA As New CDBADOSQLAdapter(GlobalVariables.gSQLConnectionString, Me.TableName)

                '取数据前先把之前的数据清空
                Me.Rows.Clear()

                objSA.GetDataTablebySymbolDatesfromSQL(strSymbol, strBeginDate, strEndDate, Me)

                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False


            End Try

        End Function

        ''' <summary>
        ''' 删除停盘的数据行，特征为价格与前一天完全一样
        ''' </summary>
        Public Overridable Function RemoveSilentPrice() As Boolean

            Try
                Dim lastrow As DataRow
                lastrow = Me.Rows(0)

                Dim iFirstRowTag As Boolean = True

                Dim iRow As Integer = 0
                Dim iLastRow As Integer = 0

                Dim LastRowClosePrice As Double = Me.GetClosePrice(0)

                For Each row As DataRow In Me.Rows
                    If iFirstRowTag = False Then
                        If row("OpenPrice") = 0 Or row("ClosePrice") = lastrow("ClosePrice") Then

                            row.Delete()

                        Else
                            lastrow = row
                        End If
                    Else
                        iFirstRowTag = False
                    End If

                    'If iFirstRowTag = False Then

                    'If iRow > 0 Then
                    '    If Me.GetOpenPrice(iRow) = 0 Or Me.GetClosePrice(iRow) = LastRowClosePrice Then
                    '        row.Delete()
                    '    Else
                    '        'iLastRow = iRow
                    '        LastRowClosePrice = Me.GetClosePrice(iRow)
                    '    End If
                    '    'Else
                    '    '    iFirstRowTag = False
                    'End If
                    iRow += 1
                Next
                Me.AcceptChanges()

                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False


            End Try

        End Function

        ''' <summary>
        ''' 从TDX、MatlabFaruto、通联中抓取对应数据
        ''' </summary>
        ''' <param name="stSymbol"></param>
        ''' <param name="pat"></param>
        ''' <param name="dtStartDate"></param>
        ''' <param name="dtEndDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FeedDataTablePrice_Obsolete(strSymbol As String, Optional ByVal pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj, Optional ByVal dtStartDate As String = "", Optional ByVal dtEndDate As String = "")
            'Dim oDTP As New CDTDaily
            Dim dbTDX As New CDataFeedTDX

            Try
                'If Me.TableName <> "FundDailyPrice" Then
                dbTDX.FeedDataTablePrice_TDX(Me, strSymbol, dtStartDate, dtEndDate)
                'ElseIf Me.TableName = "FundDailyPrice" Then

                'End If

                'Return oDTP
            Catch ex As Exception
                Return Nothing
            End Try

        End Function



        ''' <summary>
        ''' 将Datatable简化为一个日期、价格数据表，供TeeChart或其它图形输出使用
        ''' </summary>
        ''' <param name="stSymbol"></param>
        ''' <param name="pat"></param>
        ''' <param name="dtStartDate"></param>
        ''' <param name="dtEndDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function GetUnifiedPriceDataTable() As DataTable
            Try


            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        ''' <summary>
        ''' 更新SQL数据，按一条条
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function UpgradeData() As Boolean

        End Function


        ''' <summary>
        ''' 更新SQL数据，按一条条
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function UpgradeData(dt As CDTInfo) As Boolean

        End Function

        ''' <summary>
        ''' 根据Symbol、TheDate判断数据库中是否存在该记录
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function isRecordExist(strSymbol As String, strDate As String) As Boolean

            Try

                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function

        ''' <summary>
        ''' 根据Symbol、TheDate判断数据库中是否存在该记录
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function isRecordExistbySymbol(strSymbol As String) As Boolean

            Try

                Dim InParName(1) As String
                Dim InParValue(1) As String
                Dim OutParName(1) As String
                Dim OutParValue(1) As String

                InParName(0) = "Symbol"
                InParValue(0) = strSymbol
                OutParName(0) = "outPara"
                OutParValue(0) = ""

                Dim dbcommand As New CDBADOCommand(GlobalVariables.gSQLConnectionString)

                If Me.TableName = "StockPriceDaily" Then
                    dbcommand.ExecSP_Query("PSD_IsRecordExistbySymbol", InParName, InParValue, OutParName, OutParValue)
                End If

                Return CInt(OutParValue(0))


            Catch ex As Exception
                Return False
            End Try

        End Function

        ''' <summary>
        ''' 根据Symbol取得数据库中最近的日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetLatestDatebySymbol(symbol As String) As String

            Dim InParName(1) As String
            Dim InParValue(1) As String
            Dim OutParName(1) As String
            Dim OutParValue(1) As String

            InParName(0) = "Symbol"
            InParValue(0) = symbol
            OutParName(0) = "LatestDay"
            OutParValue(0) = ""

            Dim dbcommand As New CDBADOCommand(GlobalVariables.gSQLConnectionString)

            dbcommand.ExecSP_Query("PSD_GetLatestDaybySymbol", InParName, InParValue, OutParName, OutParValue)

            Return OutParValue(0)
        End Function


        ''' <summary>
        ''' 根据Symbol取得数据库中日期列表，以判断是否需要更新
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetExistingDateListbySymbol(symbol As String) As SortedList(Of Date, Int16)

            Dim result As New SortedList(Of Date, Int16)
            'Dim result1 As List(Of String)

            'Dim InParName(1) As String
            'Dim InParValue(1) As String
            'Dim OutParName(1) As String
            'Dim OutParValue(1) As String

            'InParName(0) = "Symbol"
            'InParValue(0) = symbol
            'OutParName(0) = "LatestDay"
            'OutParValue(0) = ""

            'Dim dbcommand As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
            Dim rdrDateList As SqlClient.SqlDataReader
            Dim adoReader As New CDBADODataReader(GlobalVariables.gSQLConnectionString)

            rdrDateList = adoReader.GetDataReader("Select TheDate from StockPriceDaily where Symbol='" & symbol & "'")

            Do While rdrDateList.Read()
                result.Add(rdrDateList.GetDateTime(0), 0)
            Loop

            rdrDateList.Close()

            'dbcommand.ExecSP_Query("PSD_GetLatestDaybySymbol", InParName, InParValue, OutParName, OutParValue)

            Return result
        End Function


        Public Overridable Function FeedDataTablePrice_Datayes_TDX(strSymbol As String, Optional ByVal pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj, Optional ByVal dtStartDate As String = "", Optional ByVal dtEndDate As String = "")

        End Function

        Public Overridable Function CombineDataTablePrice_Datayes_Normal_PreAdj(strSymbol As String, ByVal dt_datayes_preadj As DataTable) As Boolean

        End Function

        Public Overridable Function FeedDataTablePrice(strSymbol As String, Optional ByVal pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj, Optional ByVal dtStartDate As String = "", Optional ByVal dtEndDate As String = "") As Int32

        End Function

        ''' <summary>
        ''' 保存近期不全的日期数据。如果bLastest为false,则为查找所有日期数据
        ''' Step 1.查找不全的日期列表;
        ''' Step 2.查找通联数据;
        ''' Step 3.最后保存到数据库
        ''' 目前先实现补充近期缺少的日期数据，以后再实现所有缺少的数据
        ''' </summary>
        ''' <param name="strSymbol"></param>
        ''' <param name="strDays"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FillDataMissingDays(strSymbol As String, Optional bLastest As Boolean = True) As Boolean
            Try

                Me.Rows.Clear()

                Dim latestday As String = GetLatestDatebySymbol(strSymbol)

                Dim latestTradingDay As String = GetLatestTradingDay()

                If latestday <> "" Then

                    If latestday < latestTradingDay Then 'Today()

                        FeedDataTablePrice(strSymbol, EPriceAdjustedType.Normal, CDate(latestday).AddDays(1).ToString("yyyyMMdd"), CDate(latestTradingDay).ToString("yyyyMMdd")) '只有写成yyyyMMdd，才能显示20151203，否则就是20150003，很奇怪

                        If Me.Rows.Count > 0 Then
                            BulkInsertDataTable2SQL()
                        End If

                    End If
                End If



            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Function

        ''' <summary>
        ''' 传回整个数据表，父类转子类的引用。要直接将终端对象赋值给最终Fill(dt)，否则将出现CDatatable无法转换为子类的错误
        ''' </summary>
        ''' <param name="strTableName"></param>
        ''' <remarks></remarks>
        Public Function GetSymbolList(Optional strTableName As String = "") As List(Of String) 'As  ' DataTable

            Try
                Dim symbollist As New List(Of String)
                Dim paravalue As New Hashtable

                Dim obj As New CDBSqlServerWrapper(GlobalVariables.gSQLConnectionString)

                If strTableName = "" Then
                    strTableName = Me.TableName
                End If

                Dim rd As System.Data.SqlClient.SqlDataReader

                If Me.TableName = "StockPriceDaily" Then
                    rd = obj.ExecSpReturnDataReader("PSD_GetSymbolList", paravalue)
                End If


                Do While rd.Read()
                    symbollist.Add(Trim(rd.GetString(0)))
                Loop
                Return symbollist
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try

        End Function


        ''' <summary>
        ''' 得出最近的交易日
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetLatestTradingDay() As String
            Try


                'Dim obj As New CDBSqlServerWrapper(GlobalVariables.gSQLConnectionString)

                'Dim paravalue As New Hashtable
                'paravalue.Add("@LatestDay", 0)

                ''Dim command As System.Data.SqlClient.SqlCommand
                ''command.Parameters.Add()

                ''obj.SetParameterValues(, paravalue)

                'obj.ExecSp("ITC_GetLastestTradingDay", paravalue)

                ''obj.ExecSpOutputValues()

                'Return paravalue("@LastestDay")
                '=======================================================

                'Dim conn As SqlConnection = New SqlConnection(GlobalVariables.gSQLConnectionString)

                'Dim command As SqlCommand = New SqlCommand("ITC_GetLastestTradingDay", conn)

                ''Tell the command we are calling a stored procedure
                'command.CommandType = CommandType.StoredProcedure

                ''Add the @au_id parameter information to the command

                ''command.Parameters.Add(New SqlParameter("@LatestDay", Today()))

                ''The reader requires an open connection
                'command.Connection.Open()

                ''Execute the sql and return the reader
                'Dim dr As SqlDataReader = command.ExecuteReader(CommandBehavior.CloseConnection)

                'dr.Read()
                ''Dim d As Date = dr.GetDateTime(0).Date


                'Return d.Year + d.Month + d.Day  '返回YYYYMMDD格式

                '==========================================
                Dim InParName(0) As String
                Dim InParValue(0) As String
                Dim OutParName(1) As String
                Dim OutParValue(1) As String

                OutParName(0) = "LatestDay"
                OutParValue(0) = ""

                Dim dbcommand As New CDBADOCommand(GlobalVariables.gSQLConnectionString)

                dbcommand.ExecSP_Query("ITC_GetLastestTradingDay", InParName, InParValue, OutParName, OutParValue)

                Return OutParValue(0)

            Catch ex As Exception
                MsgBox(ex.Message)
                Return ""
            End Try

        End Function
#End Region


#Region "Protected Methods"

        Protected Overridable Function CombineDataTablePriceTDX_Datayes(strSymbol As String, ByVal dtFA As CDTDaily_Stock, Optional ByVal dtBA As CDTDaily_Stock = Nothing)

        End Function

        ''' <summary>
        ''' 针对通联数据中的证券通用信息数据表
        ''' </summary>
        ''' <param name="dt_datayes"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overridable Function AdaptDatafromDataTable(ByVal dt_datayes As DataTable) As Boolean

        End Function

#End Region

#Region "Private_Methods"

        ''' <summary>
        ''' 查找近期不全的日期。如果bLastest为false,则为查找所有日期数据
        ''' </summary>
        ''' <param name="strSymbol"></param>
        ''' <param name="strDays"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetMissingDays(strSymbol As String, Optional bLastest As Boolean = True) As String()

            Dim strExistingLastday As String

            Dim strToday As String



        End Function

#End Region

        Private Sub InitializeComponent()
            Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub


        Public Overridable Function GetOpenPrice(index As Short) As Double Implements IDTPrice.GetClosePrice
            Return Me.Rows(index).Item("OpenPrice")
        End Function

        Public Overridable Function GetHighPrice(index As Short) As Double Implements IDTPrice.GetHighPrice
            Return Me.Rows(index).Item("HighPrice")
        End Function



        Public Overridable Function GetLowPrice(index As Short) As Double Implements IDTPrice.GetLowPrice
            Return Me.Rows(index).Item("LowPrice")
        End Function

        Public Overridable Function GetClosePrice(index As Short) As Double Implements IDTPrice.GetOpenPrice
            Return Me.Rows(index).Item("ClosePrice")
        End Function

        Public Overridable Function GetVolume(index As Short) As Double Implements IDTPrice.GetVolume
            Return Me.Rows(index).Item("TurnoverVolume")
        End Function

        Public Overridable Function GetTurnoverValue(index As Short) As Double
            Return Me.Rows(index).Item("TurnoverValue")
        End Function

        Public Function GetCompressDT(pt As EHistoryDataPeriodType) As CDTDaily Implements IDTPrice.GetCompressDT
            If pt = EHistoryDataPeriodType.Daily Then
                Return Me
            Else
                Return compressDT(pt)
            End If

        End Function

        ''' <summary>
        ''' 将日线数据压缩为周、月、年数据。这里的数据获取有问题，首先是Stock、Index、Fund的字段都不一样，第二，Stock的XXXPrice与XXXPrice_FA也不一样，如何保证？
        ''' </summary>
        ''' <param name="dp"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overridable Function compressDT(dp As EHistoryDataPeriodType) As CDTDaily
            Dim dt As CDTDaily

            If Me.TableName = "StockPriceDaily" Then
                dt = New CDTDaily_Stock
            ElseIf Me.TableName = "IndexPriceDaily" Then
                dt = New CDTDaily_Index
            ElseIf Me.TableName = "FundPriceDaily" Then
                dt = New CDTDaily_Fund
            End If


            Dim HighPrice As Double
            Dim LowPrice As Double
            Dim TurnoverVolume As Double
            Dim TurnoverValue As Double

            Dim iCount As Integer = 0

            '第一行赋值
            'Dim row As DataRow = dt.NewRow()
            Dim row As DataRow = dt.NewRow()

            Try

                '如何复制数据行?
                CopyDataRow(Me.Rows(0), row)
                'row.ItemArray = Me.Rows(0).ItemArray

                HighPrice = Me.GetHighPrice(0) ' Me.Rows(0).Item("HighPrice")
                LowPrice = Me.GetLowPrice(0) 'Me.Rows(0).Item("LowPrice")
                TurnoverVolume = Me.GetVolume(0) '  Me.Rows(0).Item("TurnoverVolume")
                TurnoverValue = Me.GetTurnoverValue(0) 'Me.Rows(0).Item("TurnoverValue")

                For i = 1 To Me.Rows.Count - 1
                    Dim bSamePeriod As Boolean = IsSameDatePeriod(dp, Me.Rows(i - 1).Item("TheDate"), Me.Rows(i).Item("TheDate"))
                    If bSamePeriod Then
                        'If HighPrice < Me.Rows(i).Item("HighPrice") Then
                        '    HighPrice = Me.Rows(i).Item("HighPrice")
                        'End If

                        'If LowPrice > Me.Rows(i).Item("LowPrice") Then
                        '    LowPrice = Me.Rows(i).Item("LowPrice")
                        'End If

                        If HighPrice < Me.GetHighPrice(i) Then
                            HighPrice = Me.GetHighPrice(i)
                        End If

                        If LowPrice > Me.GetLowPrice(i) Then
                            LowPrice = Me.GetLowPrice(i)
                        End If

                        TurnoverVolume = TurnoverVolume + Me.GetVolume(i)
                        TurnoverValue = TurnoverValue + Me.GetTurnoverValue(i)
                    Else
                        'row(i-1)为上周期最后一天，新增加上周期数据行
                        row("HighPrice") = HighPrice
                        row("LowPrice") = LowPrice
                        row("TurnoverVolume") = TurnoverVolume
                        row("TurnoverValue") = TurnoverValue
                        'row("ClosePrice") = Me.Rows(i - 1).Item("ClosePrice")
                        row("ClosePrice") = Me.GetClosePrice(i - 1)
                        dt.Rows.Add(row)

                        '新周期行赋值
                        row = dt.NewRow()
                        'row = Me.NewRow()
                        CopyDataRow(Me.Rows(i), row)

                        HighPrice = Me.GetHighPrice(i)
                        LowPrice = Me.GetLowPrice(i)
                        TurnoverVolume = Me.GetVolume(i)
                        TurnoverValue = Me.GetTurnoverValue(i)

                        If i = Me.Rows.Count - 1 Then
                            dt.Rows.Add(row)
                        End If
                    End If


                Next

                Return dt
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Function
        Public Overridable Function SetPriceAdjustedType(pat As EPriceAdjustedType) As Boolean



        End Function
        Protected Function IsSameDatePeriod(dp As EHistoryDataPeriodType, date1 As Date, date2 As Date) As Boolean
            Select Case dp
                Case EHistoryDataPeriodType.Weekly
                    Return IsSameWeek(date1, date2)
                Case EHistoryDataPeriodType.Monthly
                    Return IsSameMonth(date1, date2)
                Case EHistoryDataPeriodType.Quarterly
                    Return IsSameQuarter(date1, date2)
                Case EHistoryDataPeriodType.Yearly
                    Return IsSameYear(date1, date2)
                Case Else
                    Return False
            End Select


        End Function

        Protected Function IsSameWeek(date1 As Date, date2 As Date) As Boolean
            Select Case date1.DayOfWeek
                Case DayOfWeek.Monday
                    If DateDiff(DateInterval.Day, date1, date2) >= 7 Then
                        Return False
                    End If
                Case DayOfWeek.Tuesday
                    If DateDiff(DateInterval.Day, date1, date2) >= 6 Then
                        Return False
                    End If
                Case DayOfWeek.Wednesday
                    If DateDiff(DateInterval.Day, date1, date2) >= 5 Then
                        Return False
                    End If
                Case DayOfWeek.Thursday
                    If DateDiff(DateInterval.Day, date1, date2) >= 4 Then
                        Return False
                    End If
                Case DayOfWeek.Friday
                    If DateDiff(DateInterval.Day, date1, date2) >= 3 Then
                        Return False
                    End If
                Case DayOfWeek.Saturday
                    If DateDiff(DateInterval.Day, date1, date2) >= 2 Then
                        Return False
                    End If
                Case DayOfWeek.Sunday
                    If DateDiff(DateInterval.Day, date1, date2) >= 1 Then
                        Return False
                    End If
            End Select

            Return True
        End Function

        Protected Function IsSameMonth(date1 As Date, date2 As Date) As Boolean
            If date1.Month = date2.Month Then
                Return True
            Else
                Return False
            End If
        End Function

        Protected Function IsSameQuarter(date1 As Date, date2 As Date) As Boolean
            If date1.Month - date2.Month <= 3 Then
                Return True
            Else
                Return False
            End If
        End Function

        Protected Function IsSameYear(date1 As Date, date2 As Date) As Boolean
            If date1.Year = date2.Year Then
                Return True
            Else
                Return False
            End If
        End Function

        Protected Overridable Sub CopyDataRow(rowsource As DataRow, rowdest As DataRow)
            Try
                'rowdest.ItemArray = rowdest.ItemArray

                rowdest("SecurityID") = rowsource("SecurityID")
                rowdest("Symbol") = rowsource("Symbol")
                rowdest("TheDate") = rowsource("TheDate")
                rowdest("OpenPrice") = rowsource("OpenPrice")
                rowdest("HighPrice") = rowsource("HighPrice")
                rowdest("LowPrice") = rowsource("LowPrice")
                rowdest("ClosePrice") = rowsource("ClosePrice")
                rowdest("TurnoverVolume") = rowsource("TurnoverVolume")
                rowdest("TurnoverValue") = rowsource("TurnoverValue")

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
           

        End Sub
    End Class

   
End Namespace
