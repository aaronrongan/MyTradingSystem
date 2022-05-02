
Namespace Trade
    Public Enum ETransactionCommandType
        BuyLong = 0
        SellLong = 1
        BuyShort = 2
        SellShort = 3
    End Enum
    Public Class TransactionCmdEventArgs
        Inherits EventArgs


        Protected m_cmd As CTransactionCommand


        Public Sub New(ByVal cmd As CTransactionCommand)
            m_cmd = cmd
        End Sub

        Public Function getCommmand() As CTransactionCommand
            Return m_cmd
        End Function

    End Class

    Public Delegate Sub TransactionCmdDelegate(ByVal sender As Object, ByVal e As TransactionCmdEventArgs)
    Public Class CTransactionCommand
        Public TransactionType As ETransactionCommandType
        Public TransactionPosition As Int32 = 100       '仓位，默认100，即1手
        Public TransactionPrice As Double
        Public TransactionDateTime As DateTime

        Public Sub New()

        End Sub
    End Class

End Namespace
