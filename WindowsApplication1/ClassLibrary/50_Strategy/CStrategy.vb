Imports MyTradingSystem.Trade
Imports MyTradingSystem.Indicator
Imports MyTradingSystem.DataEntity
Imports Steema.TeeChart

Namespace Strategy

#Region "Enum"
 
    Public Enum EStrategyMode As Integer
        MODE_LIVE = 2
        MODE_NULL = 1
        MODE_PLAYBACK = 4
        MODE_SIMULATED = 3
    End Enum

#End Region

#Region "Class"


    ''' <summary>
    ''' 绘制Strategy。在IStrategy上的装饰类
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface IStrategyPlotAxTchart

        ''' <summary>
        ''' 在AxTchart上绘制策略买卖点
        ''' </summary>
        ''' <remarks></remarks>
        Sub Plot(ByVal dt As DataTable, ByRef candle As Styles.Candle, ByVal canvaspos As Int16) '是否要把参数改为接口ITChart?

        Sub RemovePlot()

        Sub Show()

        Sub Hide()

    End Interface
    Public MustInherit Class CStrategy
        Implements IStrategy


        Protected m_PriceData As CDTDaily
        Protected m_DTStrategySignal As DataTable
        Protected m_DataColumns() As DataColumn
        Protected m_IDC As CIndicator
        Protected m_Signal As CTransactionSignal
        Protected m_PlotAxTChart As IStrategyPlotAxTchart      '用于绘图Showme
        ''' <summary>
        ''' 策略名称
        ''' </summary>
        ''' <remarks></remarks>
        Public m_StragetyName As String
        ''' <summary>
        ''' 策略详细描述
        ''' </summary>
        ''' <remarks></remarks>
        Public m_StragetyDescription As String

        Protected m_PriceType As EPriceType = EPriceType.Close  '计算用的价格类型，默认为收盘价

        ''' <summary>
        ''' 发送交易信号时间
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        'Public Event SendSignal(ByVal sender As Object, ByVal e As TradingEventArgs)
        Public Event TransactionSignal(ByVal sender As Object, ByVal e As TransactionSignalEventArgs)

        Public Overridable Sub PlotAxTChart(ByRef candle As Styles.Candle, ByVal canvaspos As Int16)
            m_PlotAxTChart.Plot(m_DTStrategySignal, candle, canvaspos)
        End Sub

        Public Overridable Sub Clear()
            m_PlotAxTChart.RemovePlot()
        End Sub
        Public Property PriceType As EPriceType
            Get
                PriceType = m_PriceType
            End Get
            Set(value As EPriceType)
                m_PriceType = value
            End Set
        End Property
        Public Sub New()
            m_PriceData = New CDTDaily
            m_DTStrategySignal = New DataTable

            ReDim m_DataColumns(0)

            '日期列
            m_DataColumns(0) = m_DTStrategySignal.Columns.Add("TheDate", GetType(System.String))
            m_DataColumns(0).AllowDBNull = False

            '设置第一列日期时间为主键
            m_DTStrategySignal.PrimaryKey = m_DataColumns

            '将原价格数据存进Strategy数据表DataTable
            m_DTStrategySignal.Columns.Add("OpenPrice", GetType(System.Double))
            m_DTStrategySignal.Columns.Add("HighPrice", GetType(System.Double))
            m_DTStrategySignal.Columns.Add("LowPrice", GetType(System.Double))
            m_DTStrategySignal.Columns.Add("ClosePrice", GetType(System.Double))

        End Sub
        Public Overridable Sub PopWindowParameterPlot(ByRef candle As Styles.Candle, ByVal canvaspos As Int16)

        End Sub
        Public Sub New(dt As CDTDaily)
           

            m_PriceData = dt
            m_DTStrategySignal = New DataTable

            ReDim m_DataColumns(0)

            '日期列
            m_DataColumns(0) = m_DTStrategySignal.Columns.Add("TheDate", GetType(System.String))
            m_DataColumns(0).AllowDBNull = False

            '设置第一列日期时间为主键
            m_DTStrategySignal.PrimaryKey = m_DataColumns

            '将原价格数据存进Strategy数据表DataTable
            m_DTStrategySignal.Columns.Add("OpenPrice", GetType(System.Double))
            m_DTStrategySignal.Columns.Add("HighPrice", GetType(System.Double))
            m_DTStrategySignal.Columns.Add("LowPrice", GetType(System.Double))
            m_DTStrategySignal.Columns.Add("ClosePrice", GetType(System.Double))

        End Sub

        Protected Overridable Sub Init()
            Try
                If m_DTStrategySignal.Rows.Count = 0 Then
                    For Each row As DataRow In m_PriceData.Rows
                        Dim rowMe As DataRow = m_DTStrategySignal.NewRow()
                        rowMe.Item("TheDate") = row.Item("TheDate")
                        m_DTStrategySignal.Rows.Add(rowMe)
                    Next

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            
        End Sub

        ''' <summary>
        ''' VIP 这里有风险，传入参数的顺序是要按照要求的，否则会出错
        ''' </summary>
        ''' <param name="paArray"></param>
        ''' <remarks></remarks>
        Public Overridable Sub SetDefaultParameters()
            CalculateAll()
        End Sub

        ''' <summary>
        ''' VIP 这里有风险，传入参数的顺序是要按照要求的，否则会出错
        ''' </summary>
        ''' <param name="paArray"></param>
        ''' <remarks></remarks>
        Public MustOverride Sub SetParameters(ByVal ParamArray paArray() As Double)


        ''' <summary>
        ''' 运行策略
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public MustOverride Sub Run(iDayIndex As Int16, bSendSignal As Boolean) Implements IStrategy.Run


        ''' <summary>
        ''' 运行策略
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public MustOverride Sub CalculateAll() Implements IStrategy.RunAll


        ''' <summary>
        ''' 运行策略，在TeeChart图形上显示出来
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Sub Showme(ByVal dt As DataTable, ByRef candle As Styles.Candle) Implements IStrategy.Showme
            m_PlotAxTChart.Plot(dt, candle, 0)
        End Sub


        Public Overridable Sub Setup() Implements IStrategy.Setup

        End Sub

        Protected Sub RaiseTransactionSignal(ByVal sender As Object, ByVal e As TransactionSignalEventArgs)
            RaiseEvent TransactionSignal(sender, e)
        End Sub

    End Class
#End Region
End Namespace
