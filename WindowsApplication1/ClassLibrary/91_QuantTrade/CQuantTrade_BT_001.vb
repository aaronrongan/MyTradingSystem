Imports MyTradingSystem.Indicator
Imports MyTradingSystem.Strategy
Imports MyTradingSystem.DataEntity

Namespace Trade



    ''' <summary>
    ''' 交易实例类，第一个。回归测试BT:Backting
    ''' 运用简单的均线交叉信号进行模式
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CQuantTrade_BT_001
        Inherits CQuantTrading

        Protected Shadows WithEvents m_Strategy As CStrategy '_SMA2Crossover

        Protected m_FastPeriod As Int16 = 9
        Protected m_SlowPeriod As Int16 = 3
        'Private Shadows WithEvents m_Transaction As CTransaction

        'Private m_Cmd

        'Private Event onTransaction As TransactionCmdDelegate '(ByVal sender As Object, ByVal e As TradingEventArgs) 
        'VIP 注意区分PlaceOrder不是一个Event，而是一个动作，Event一般用于回馈调用者一个事件。一定要分清谁是consumer，谁是producer
        Public Sub New()
            MyBase.New()

            'AddHandler Me.onTransaction, AddressOf ExecTransaction

        End Sub

        Public Overrides Sub Init(dt As CDTDaily)
            MyBase.Init(dt)


            m_Strategy = CStrategyFactory.CreateStrategy(EStrategyName.SMA2Crossover, dt)

            ' m_Strategy.Setup()
        End Sub
        '逻辑关系：发送事件给Strategy进行执行, Strategy执行后也会发送事件给Transaction执行
        Public Overrides Sub Run()
            MyBase.Run()

            m_Strategy.SetParameters(m_FastPeriod, m_SlowPeriod)

            For i = 0 To m_Data.Rows.Count - 1
                '对于回归测试可以直接用这个简单形式，如果是复杂的模拟盘、实盘，是否有多种Event要处理？是否要用RaiseEvent? 
                m_Strategy.Run(i, True)
            Next

            m_OrderSet.Print()
            'MsgBox m_OrderSet

        End Sub

        Public Overrides Sub SetParameters(ByVal ParamArray paArray() As Double)
            m_FastPeriod = paArray(0)
            m_SlowPeriod = paArray(1)
        End Sub
        'Public Property FastPeriod As Int16
        '    Get
        '        FastPeriod = m_FastPeriod
        '    End Get
        '    Set(value As Int16)
        '        m_FastPeriod = value
        '    End Set
        'End Property

        'Public Property SlowPeriod As Int16
        '    Get
        '        SlowPeriod = m_SlowPeriod
        '    End Get
        '    Set(value As Int16)
        '        m_SlowPeriod = value
        '    End Set
        'End Property

        Public Overrides Function getPerformanceReport() As CPerformance

        End Function


        Private Sub m_Strategy_TransactionSignal(sender As Object, e As TransactionSignalEventArgs) Handles m_Strategy.TransactionSignal

            Dim cmd As New CTransactionCommand

            Dim ea As TransactionCmdEventArgs

            Select Case e.getSignal.SignalType
                Case ETransactionSignalType.BuyLongCross
                    MsgBox("买入点时间：" & e.getSignal.SignalDateTime)

                    cmd.TransactionType = ETransactionCommandType.BuyLong
                    cmd.TransactionPrice = e.getSignal.TradingPrice
                    cmd.TransactionDateTime = e.getSignal.SignalDateTime

                    ea = New TransactionCmdEventArgs(cmd)

                    'RaiseEvent onTransaction(Me, ea)

                    ExecTransaction(Me, ea)

                Case ETransactionSignalType.SellLongCross
                    MsgBox("卖出点时间：" & e.getSignal.SignalDateTime)
                    cmd.TransactionType = ETransactionCommandType.SellLong
                    cmd.TransactionPrice = e.getSignal.TradingPrice
                    ea = New TransactionCmdEventArgs(cmd)
                    'RaiseEvent onTransaction(Me, ea)

                    ExecTransaction(Me, ea)
            End Select
        End Sub

        Protected Sub ExecTransaction(ByVal sender As Object, e As TransactionCmdEventArgs)

            '注意这里最好有反馈事件，如果PlaceOrder成功如何，如果不成功会如何。可以用COrderRequest、COrder区分请求订单、与成交订单

            m_Order = m_Transaction.PlaceOrderRequest(e.getCommmand)
            m_OrderSet.Add(m_Order)
            'RaiseEvent onTransaction(Me, e)

        End Sub
    End Class

End Namespace
