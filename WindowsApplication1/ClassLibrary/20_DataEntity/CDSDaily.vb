
Imports MyTradingSystem.DataBase
Imports MyTradingSystem.DataFeed


Namespace DataEntity


    Public Class CDSDaily
        Inherits DataSet

        ''' <summary>
        ''' 数据集类型，如Fund/Stock/Index/Block
        ''' </summary>
        Protected m_SetCategory As String = "StockPriceDaily" '默认为Stock，还有FundPriceDaily、IndexPriceDaily类型
        ''' <summary>
        ''' Symbol集
        ''' </summary>
        Protected m_lstSymbols As List(Of String)
        ''' <summary>
        ''' DataInfo集，主要取其中的Symbol字段，和m_lstSymbols重合
        ''' </summary>
        Protected m_dtDataList As MyTradingSystem.DataEntity.CDTInfo
        ''' <summary>
        ''' 所有数据集，用过一个平面显示
        ''' </summary>
        Protected m_dtAllDataTable As CDTDaily

        ''' <summary>
        ''' 通知调用客户端更新进度
        ''' </summary>
        Public Event UpgradeProgress(ByVal iProgress As Integer)

        ''' <summary>
        ''' 通知调用客户端数据采集进度
        ''' </summary>
        Public Event FeedProgress(ByVal iProgress As Integer)

        ''' <summary>
        ''' 对应的基本信息列表
        ''' </summary>
        Protected m_dtInfo As CDTInfo

        ''' <summary>
        ''' 对应的价格信息表
        ''' </summary>
        Protected m_dtPrice As CDTDaily

        Public Event InsertProgress(ByVal iProgress As Integer)


#Region "Property"


        Public ReadOnly Property SymbolNumbers() As Integer
            Get
                SymbolNumbers = m_dtInfo.Rows.Count
            End Get
        End Property

        ''' <summary>
        ''' 将数据集中的数据集中到一个Dataview
        ''' </summary>
        Public ReadOnly Property CombinedAllDataTable() As DataTable
            Get
                CombinedAllDataTable = m_dtAllDataTable
            End Get

        End Property


#End Region

#Region "Constructor"

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub New()
            m_lstSymbols = New List(Of String)
            'm_dtInfo.GetWholeTable()

            'm_dtAllDataTable = New CDTDaily
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="srtCategory"></param>
        ''' <param name="dt"></param>
        ''' <remarks></remarks>
        Protected Sub New(srtCategory As String, dt As CDTDaily)

            'If srtCategory = "Stock" Or srtCategory = "Fund" Or srtCategory = "Index" Then
            '    m_SetCategory = srtCategory
            'Else
            '    m_SetCategory = "Stock"     '默认为Stock数据集
            'End If

            'Me.Tables.Add(dt)

            '默认为寻找所有Symbol List
            'm_dtInfo.GetWholeTable()

        End Sub

        ''' <summary>
        ''' 首次批量导入数据，按Symbol依次填入数据,默认为所有
        ''' </summary>
        Public ReadOnly Property CurrentDataTable()
            Get
                CurrentDataTable = m_dtPrice
            End Get
        End Property
#End Region

#Region "Public Methods"
        ''' <summary>
        ''' 从网页、通达信、通联、Wind根据制定的Symbol清单或日期条件或其它条件获取指定数据表集，默认为所有
        ''' </summary>
        Public Sub FeedDataTablesPrice(Optional ByVal dfs As EDataFeedType = EDataFeedType.TDX)

            'Dim dtInfo As CDTInfo
            'Dim dtPrice As Object 'CDTDaily
            Dim dftTDX As New DataFeed.CDataFeedTDX

            Try

                'If m_SetCategory = "StockPriceDaily" Then
                '    dtInfo = New CDTInfo_Stock
                'ElseIf m_SetCategory = "FundPriceDaily" Then
                '    dtInfo = New CDTInfo_Fund
                'ElseIf m_SetCategory = "IndexPriceDaily" Then
                '    dtInfo = New CDTInfo_Index
                'End If

                '得到所有的Symbol List和填充dtInfo
                'm_dtInfo.GetAllSymbolList(m_lstSymbols)

                Dim icount As Integer = 0


                For Each row As DataRow In m_dtInfo.Rows

                    '如何用多态方法实现()
                    'If m_SetCategory = "StockPriceDaily" Then
                    '    dtPrice = New CDTDaily_Stock
                    'ElseIf m_SetCategory = "FundPriceDaily" Then
                    '    dtPrice = New CDTDaily_Fund
                    'ElseIf m_SetCategory = "IndexPriceDaily" Then
                    '    dtPrice = New CDTDaily_Index
                    'End If


                    Me.CreateDataTablePriceInstance()

                    ' m_dtPrice =New myclass()
                    'Convert.ChangeType(m_dtAllDataTable,)

                    '新增一个m_dtPrice对象
                    'Debug.Print(Me.ToString)
                    'm_dtPrice = CreateDataTablePriceInstance()
                    'm_dtPrice= New 

                    'If dfs = CDataFeedBASE.DataFeedType.TDX Then
                    'm_dtPrice.FeedDataTablePricefromTDX(Trim(row.Item("Symbol")))
                    'End If
                    m_dtPrice.FeedDataTablePrice(Trim(row.Item("Symbol")))

                    m_dtPrice.TableName = Trim(row.Item("Symbol"))

                    'For Each rowPrice As DataRow In m_dtPrice.Rows
                    'm_dtAllDataTable.Rows.Add(rowPrice)
                    'Next

                    '合并表
                    m_dtAllDataTable.Merge(m_dtPrice)

                    Me.Tables.Add(m_dtPrice)
                    'dtPrice = Nothing
                    m_dtPrice = Nothing

                    RaiseEvent FeedProgress(Me.Tables.Count)

                    icount += 1
                    If icount > 10 Then
                        Exit For
                    End If
                Next


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub


        ''' <summary>
        ''' 新增一个m_dtPrice
        ''' </summary>
        Public Overridable Function CreateDataTablePriceInstance()
            m_dtPrice = New CDTDaily

        End Function



        ''' <summary>
        ''' 批量更新价格数据
        ''' 
        ''' </summary>
        Public Overridable Sub UpgradeData()


        End Sub


        ''' <summary>
        ''' 首次批量导入数据，按Symbol依次填入数据,默认为所有
        ''' </summary>
        Public Sub BulkInsertDataTables(Optional ByVal dfs As EDataFeedType = EDataFeedType.TDX)
            Dim log As New DataExport.CDataExportCSVTXT.CDataExportTxtLog("批量插入数据日志")

            Try
                Dim iCount As Int16 = 0


                '根据m_dtInfo的列表进行插入
                For Each row As DataRow In m_dtInfo.Rows
                    Try


                        Me.CreateDataTablePriceInstance()       '创建一个m_dtPrice

                        '先Delete原来Symbol数据, 再取新数据, 最后BulkInsert
                        m_dtPrice.DeleteDataTablebySymbol(Trim(row.Item("Symbol")))

                        'If dfs = CDataFeedBASE.DataFeedType.TDX Then
                        'm_dtPrice.FeedDataTablePrice(Trim(row.Item("Symbol")))
                        'End If

                        m_dtPrice.FeedDataTablePrice(Trim(row.Item("Symbol")))

                        m_dtPrice.BulkInsertDataTable2SQL()
                        m_dtPrice = Nothing

                        iCount += 1

                        log.AddLog(Trim(row.Item("Symbol") & "导入成功"))

                        RaiseEvent InsertProgress(iCount)
                    Catch ex As Exception
                        log.AddLog(Trim(row.Item("Symbol") & "导入不成功"))
                    End Try
                Next

            Catch ex As Exception
                log.AddLog("批量导入SQL出错")
            Finally
                log.ExportLog()
            End Try

        End Sub



        ''' <summary>
        ''' 一次性删除所有或指定相关数据表操作
        ''' </summary>
        Public Sub TruncateDataTables(dtInfo As MyTradingSystem.DataEntity.CDTInfo)

            'Try

            '    Dim dtPrice As New CDTDaily  '如果不用New，直接赋值会出什么问题？
            '    Dim strSymbol As String

            '    For Each dr As DataRow In dtInfo.Rows
            '        strSymbol = dr.Item("Symbol")
            '        dtPrice = Me.Tables(strSymbol)      '有问题，如何保证类型正确？Datatable->子类?
            '        dtPrice.TruncateDataTable()
            '    Next

            'Catch ex As Exception

            'End Try
        End Sub

        ''' <summary>
        ''' 删除指定Symbol所有或指定相关数据表操作
        ''' </summary>
        Public Sub DeleteDataTablebySymbol(dtInfo As MyTradingSystem.DataEntity.CDTInfo)

            Try

                Dim dtPrice As New CDTDaily  '如果不用New，直接赋值会出什么问题？
                Dim strSymbol As String

                For Each dr As DataRow In dtInfo.Rows
                    strSymbol = dr.Item("Symbol")
                    dtPrice = Me.Tables(strSymbol)      '有问题，如何保证类型正确？Datatable->子类?
                    dtPrice.DeleteDataTablebySymbol(strSymbol)
                Next

            Catch ex As Exception

            End Try
        End Sub


        ''' <summary>
        ''' 批量从SQL数据库获得指定数据表集，如指定日期内、指定Symbol
        ''' </summary>
        ''' <param name="dtInfo">需要的Symbol清单</param>
        Public Sub GetDataTables(dtInfo As CDTInfo)

        End Sub

        ''' <summary>
        ''' 设置过滤条件，哪些是需要的，先设置为Symbol、日期。针对多个Symbol
        ''' </summary>
        Public Sub FilterDataTables(ByVal strSymbol() As String)
            If UBound(strSymbol) = 0 And strSymbol(0) <> "" Then '当1个商品

                m_dtInfo.GetDataTablebySymbol(m_dtInfo.TableName, strSymbol(0))

            ElseIf strSymbol(0) = "" Then '所有商品
                m_dtInfo.GetWholeTable()

            Else ' 多只商品

            End If
        End Sub

        Public Sub FillDataMissingDays()
            'If Me.m_SetCategory = "StockPriceDaily" Then
            'm_dtPrice = CType(Me, CDTDaily_Stock) ' New CDTDaily_Stock
            'End If


            Dim SymbolList As List(Of String) = m_dtPrice.GetSymbolList ' m_dtInfo.GetSymbolList() 'GetWholeTable()

            'Dim bgw As New System.

            Dim iCount As Int32 = 1
            For Each symbol As String In SymbolList ' m_dtInfo.Rows
                m_dtPrice.FillDataMissingDays(symbol, True)
                RaiseEvent UpgradeProgress(iCount)
                iCount += 1
            Next
        End Sub



#End Region

    End Class

End Namespace
