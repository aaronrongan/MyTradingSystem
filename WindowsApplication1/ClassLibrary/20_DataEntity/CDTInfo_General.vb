Imports MyTradingSystem.DataFeed
Imports MyTradingSystem.DataBase

Namespace DataEntity


    Public Enum ESecurityType
        Stock = 0
        Index = 1
        Fund = 2
        Bond = 3

    End Enum
    ''' <summary>
    ''' 总体信息，如交易日历
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CDTInfo_General

        ''' <summary>
        ''' 批量插入交易日历，19910101有问题，因为会导致第一行列数目为7证券交易所。可选：XSHG，XSHE，CCFX，XDCE，XSGE，XZCE，XHKG。XSHG表示上海证券交易所，XSHE表示深圳证券交易所，CCFX表示中国金融期货交易所，XDCE表示大连商品交易所，XSGE表示上海期货交易所，XZCE表示郑州商品交易所，XHKG表示香港证券交易所。可同时输入多个证券交易所
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub BulkInsertTradeCalendar(Optional ByVal exchangeCD As String = "XSHG", Optional BeginDate As String = "", Optional EndDate As String = "")
            Dim dt As New DataTable
            Dim dfDY As New CDataFeedDatayes_General
            Dim db As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
            dt = dfDY.FeedTradeCalendarDataTable(exchangeCD, "20160101", EndDate)  '不能写成2016-01-01
            'db.TruncateTable("TradeCalendar
            db.BulkInsertDataTable(dt, "TradeCalendar")

        End Sub

        ''' <summary>
        ''' 批量插入证券类型数据表
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub BulkInsertSecuritiesTypeInfo(Optional ByVal exchangeCD As String = "XSHG", Optional BeginDate As String = "", Optional EndDate As String = "")
            Dim dt As New DataTable
            Dim dfDY As New CDataFeedDatayes_General
            Dim db As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
            dt = dfDY.GetSecurityTypeDataTable()

            Dim strMappingList As New SortedList(Of String, String)

            strMappingList.Add("typeID", "ID")
            strMappingList.Add("typeName", "FullName")
            strMappingList.Add("parentID", "ParentID")
            strMappingList.Add("typeLevel", "Level")

            db.BulkInsertDataTable(dt, "SecurityTypeInfo", strMappingList)

        End Sub

        ''' <summary>
        ''' 批量插入证券类型成分关系数据表，根据单个typeID
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub BulkInsertSecuritiesTypeRelation(typeID As String)

            Dim dt As New DataTable
            Dim dfDY As New CDataFeedDatayes_General
            Dim db As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
            dt = dfDY.FeedSecurityTypeRelationDataTable(, , typeID)

            If Not IsNothing(dt) Then


                Dim strMappingList As New SortedList(Of String, String)


                strMappingList.Add("typeID", "TypeID")
                strMappingList.Add("secID", "SecurityID")
                strMappingList.Add("ticker", "Symbol")
                strMappingList.Add("exchangeCD", "ExchangeCD")

                db.BulkInsertDataTable(dt, "SecurityTypeRelation", strMappingList)
            End If

        End Sub


        ''' <summary>
        ''' 批量插入证券类型成分关系数据表，遍历所有的typeID
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub BulkInsertAllSecuritiesTypeRelation()

            Dim dt As New DataTable
            Dim dfDY As New CDataFeedDatayes_General
            Dim db As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
            dt = dfDY.GetSecurityTypeDataTable()

            For Each row As DataRow In dt.Rows

                BulkInsertSecuritiesTypeRelation(row.Item("typeID"))
            Next

        End Sub
    End Class

End Namespace
