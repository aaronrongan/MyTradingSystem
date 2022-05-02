
Imports MyTradingSystem.Indicator
Imports MyTradingSystem.Strategy
Imports MyTradingSystem.DataEntity


Namespace Trade

    ''' <summary>
    ''' 事件类，在日期时间变更时处理
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TradingEventArgs
        Inherits EventArgs

        Public ReadOnly msgData As String
        Protected m_Signal As CTransactionSignal
        Protected m_cmd As CTransactionCommand
        Public Sub New(ByVal msg As String)
            msgData = msg
        End Sub

        Public Sub New(ByVal signal As CTransactionSignal)
            m_Signal = signal
        End Sub

        Public Sub New(ByVal cmd As CTransactionCommand)
            m_cmd = cmd
        End Sub

        Public Function getSignal() As CTransactionSignal
            Return m_Signal
        End Function

    End Class

    'Public Delegate Sub TradingDelegate(ByVal sender As Object, ByVal e As TradingEventArgs)
    'Public Delegate Sub TradingEventArgs(ByVal sender As Object, ByVal e As TradingEventArgs)

    ''' <summary>
    ''' 量化交易模块
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class CQuantTrading

        '盈亏目标目标是什么？交易时间是多少？
        Protected m_Strategy As CStrategy
        Protected m_Symbol As String
        Protected m_SecurityType As ESecurityType
        Protected m_Data As CDTDaily

        Protected m_PerfReport As CPerformance
        Protected m_Cash As CCash
        Protected m_Position As CPosition
        Protected m_Transaction As CTransaction
        Protected m_TransactionLog As CTransactionLog
        Protected m_Order As COrder
        Protected m_OrderSet As COrderSet


        '回溯策略的基本参数
        Protected m_StartDate As DateTime
        Protected m_EndDate As DateTime
        Protected m_SecPool As List(Of String)  '股票池
        Protected m_Benchmark As CBenchMark         '参考股票
        Protected m_RefreshRate As Integer      '更新频率，调仓频率


        ''' <summary>
        ''' 事件处理类，在日期时间变更时处理
        ''' </summary>
        ''' <remarks></remarks>
        Protected WithEvents OnTradingEvent As CStrategy



        Public Sub New()
            m_Cash = New CCash
            m_Position = New CPosition
            m_Order = New COrder
            m_OrderSet = New COrderSet
            m_Transaction = New CTransaction
        End Sub

        Protected Sub FillData(dt As CDTDaily)
            m_Data = dt
        End Sub

        ''' <summary>
        ''' 策略交易初始化:选取哪些股票(SymbolList、起始时间、结束时间、Benchmark是什么)
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <remarks></remarks>
        Public Overridable Sub Init(dt As CDTDaily)
            FillData(dt)
        End Sub

        Public Overridable Sub Transaction()

        End Sub
        Public Overridable Sub Run()

        End Sub

        Public Overridable Function getPerformanceReport() As CPerformance

        End Function

        Public Overridable Function getTransactionLog() As CTransactionLog

        End Function

        ''' <summary>
        ''' VIP 这里有风险，传入参数的顺序是要按照要求的，否则会出错
        ''' </summary>
        ''' <param name="paArray"></param>
        ''' <remarks></remarks>
        Public Overridable Sub SetParameters(ByVal ParamArray paArray() As Double)

        End Sub

    End Class

End Namespace
