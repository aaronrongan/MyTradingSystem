
Imports MyTradingSystem.DataEntity
Imports Steema.TeeChart

Namespace Strategy

    ''' <summary>
    ''' 市场方向: 趋势、无序和突变系统
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum EMarketPosition
        Trending = 1
        Directionless = 2
        Volatility = 3
    End Enum

    Public Interface IStrategy

        Sub Setup()
        ''' <summary>
        ''' 根据价格数据和当前日期进行策略计算
        ''' 
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <param name="iDayIndex"></param>
        ''' <remarks></remarks>
        Sub Run(iDayIndex As Int16, bSendSignal As Boolean)

        ''' <summary>
        ''' 独立根据价格数据进行策略计算，不放在Trading类中，用于绘制策略图形
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <param name="iDayIndex"></param>
        ''' <remarks></remarks>
        Sub RunAll()

        Sub Showme(dt As DataTable, ByRef candle As Styles.Candle)

        'Sub ReEntry()
        'Sub Setup
        'Sub Entry
        'Sub Exit()

    End Interface
End Namespace