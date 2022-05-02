Imports Strategy

Namespace Trade



    Public Delegate Sub TradeLoginCallback()
    Public Delegate Sub TradeErrorCallback()
    Public Delegate Sub TradeExecRptCallback() 'res As GMSDK.ExecRpt
    Public Delegate Sub TradeOrderCancelledCallback(res As COrder)
    Public Delegate Sub TradeOrderCancelRejectedCallback() 'res As GMSDK.ExecRpt
    Public Delegate Sub TradeOrderFilledCallback(res As COrder)
    Public Delegate Sub TradeOrderNewCallback(res As COrder)
    Public Delegate Sub TradeOrderPartiallyFilledCallback(res As COrder)
    Public Delegate Sub TradeOrderRejectedCallback(res As COrder)
    Public Delegate Sub TradeOrderStatusCallback(res As COrder)
    Public Delegate Sub TDOrderStopExecutedCallback(res As COrder)

    'Public Delegate Sub StrategySignal(ByVal sender As Object, ByVal e As TradingEventArgs)


    Public Class CTransaction

        Public Event ErrorEvent(error_code As Integer, error_msg As String)
        Public Event ExecRptEvent() 'res As GMSDK.ExecRpt
        Public Event LoginEvent()
        Public Event OrderCancelledEvent(res As COrder)
        Public Event OrderCancelRejectedEvent() 'res As GMSDK.ExecRpt
        Public Event OrderFilledEvent(res As COrder)
        Public Event OrderNewEvent(res As COrder)
        Public Event OrderPartiallyFilledEvent(res As COrder)
        Public Event OrderRejectedEvent(res As COrder)
        Public Event OrderStatusEvent(res As COrder)
        Public Event OrderStopExecutedEvent(res As COrder)

        'Public WithEvents PlaceOrder ' As VIP 注意区分PlaceOrder不是一个Event，而是一个动作，Event一般用于回馈调用者一个事件。一定要分清谁是consumer，谁是producer

        '交易策略发出信号
        'Public Event OnStrategySignal As StrategySignal

        'Protected m_Signal As CTransactionSignal
        Public Sub Close()

        End Sub

        Public Function CancelOrder(cl_ord_id As String) As Integer

        End Function

        Public Function CancelOrderSync(cl_ord_id As String) As Integer

        End Function

        Public Function CloseLong(exchange As String, sec_id As String, price As Double, volume As Double) As COrder

        End Function

        Public Function CloseLongSync(exchange As String, sec_id As String, price As Double, volume As Double) As COrder

        End Function

        Public Function CloseLongYesterday(exchange As String, sec_id As String, price As Double, volume As Double) As COrder

        End Function

        Public Function CloseLongYesterdaySync(exchange As String, sec_id As String, price As Double, volume As Double) As COrder

        End Function

        Public Function CloseShort(exchange As String, sec_id As String, price As Double, volume As Double) As COrder


        End Function

        Public Function CloseShortSync(exchange As String, sec_id As String, price As Double, volume As Double) As COrder

        End Function

        Public Function CloseShortYesterday(exchange As String, sec_id As String, price As Double, volume As Double) As COrder

        End Function

        Public Function CloseShortYesterdaySync(exchange As String, sec_id As String, price As Double, volume As Double) As COrder

        End Function

        Public Function GetCash() As CCash

        End Function

        Public Function GetPerformance() As CPerformance

        End Function

        Public Function GetOrder(cl_ord_id As String) As COrder

        End Function

        Public Function GetPosition(exchange As String, sec_id As String, side As Byte) As CPositionRules

        End Function

        Public Function GetPositions() As System.Collections.Generic.List(Of CPositionRules)

        End Function

        Public Function GetUnfinishedOrdes() As System.Collections.Generic.List(Of COrder)

        End Function

        Public Function Init(username As String, password As String, strategy_id As String, Optional td_addr As String = "") As Integer

        End Function

        Public Function InitEx(username As String, password As String, strategy_id As String, Optional td_addr As String = "", Optional md_addr As String = "") As Integer

        End Function

        Public Function OpenLong(exchange As String, sec_id As String, price As Double, volume As Double) As COrder

        End Function

        Public Function OpenLongSync(exchange As String, sec_id As String, price As Double, volume As Double) As COrder

        End Function

        Public Function OpenShort(exchange As String, sec_id As String, price As Double, volume As Double) As COrder

        End Function

        Public Function OpenShortSync(exchange As String, sec_id As String, price As Double, volume As Double) As COrder

        End Function

        Public Function PlaceOrderRequest(cmd As CTransactionCommand) As COrder
            'MsgBox("请求订单")

            Dim bOrderSucceed As Boolean = True

            If bOrderSucceed = True Then
                '发送消息给QuantTrade 对象，通知Transaction成功记录
                Return PlaceOrder(cmd)
            Else
                '发送消息给QuantTrade 对象，通知Transaction失败记录
            End If
        End Function
        Protected Function PlaceOrder(cmd As CTransactionCommand) As COrder
            'MsgBox("订单已下")
            Dim order As New COrder

            order.orderdatetime = cmd.TransactionDateTime
            If cmd.TransactionType = ETransactionCommandType.BuyLong Then
                order.side = EOrderSide.Buy
            ElseIf cmd.TransactionType = ETransactionCommandType.SellLong Then
                order.side = EOrderSide.Sell
            End If
            order.price = cmd.TransactionPrice
            order.position = cmd.TransactionPosition

            Return order
        End Function

        Public Function PlaceOrderSync(order As GMSDK.Order) As COrder

        End Function

        Public Function Reconnect() As Integer

        End Function

        Public Function Run() As Integer

        End Function

        Public Function StrError(errorno As Integer) As String


        End Function



    End Class

End Namespace
