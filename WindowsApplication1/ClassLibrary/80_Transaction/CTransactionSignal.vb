Namespace Trade

    Public Enum ETransactionSignalType
        Invalid = -1
        Directionless = 0
        BuyLongCross = 1
        SellLongCross = 2
        Bullish = 3
        Bearish = 4
        Volation = 5
    End Enum

    Public Class TransactionSignalEventArgs
        Inherits EventArgs

        Public ReadOnly msgData As String
        Protected m_Signal As CTransactionSignal

        Public Sub New(ByVal msg As String)
            msgData = msg
        End Sub

        Public Sub New(ByVal signal As CTransactionSignal)
            m_Signal = signal
        End Sub

        Public Function getSignal() As CTransactionSignal
            Return m_Signal
        End Function



    End Class

    Public Delegate Sub TransactionSignalDelegate(ByVal sender As Object, ByVal e As TransactionSignalEventArgs)

    Public Class CTransactionSignal

        Protected m_SignalType As ETransactionSignalType
        Protected m_TradingPrice As Double
        Protected m_SignalDateTime As DateTime


        'Protected 
        Public Property TradingPrice As Double
            Get
                TradingPrice = m_TradingPrice
            End Get
            Set(value As Double)
                m_TradingPrice = value
            End Set
        End Property

        Public Property SignalType As ETransactionSignalType
            Get
                SignalType = m_SignalType
            End Get
            Set(value As ETransactionSignalType)
                m_SignalType = value
            End Set


        End Property

        Public Property SignalDateTime As DateTime
            Get
                SignalDateTime = m_SignalDateTime
            End Get
            Set(value As DateTime)
                m_SignalDateTime = value
            End Set
        End Property
    End Class

End Namespace
