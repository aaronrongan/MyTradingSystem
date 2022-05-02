
Namespace Trade


    Public Class COrderSet
        Protected m_OrderSet As List(Of COrder)

        Public Sub New()
            m_OrderSet = New List(Of COrder)
        End Sub

        Public Sub Add(order As COrder)
            m_OrderSet.Add(order)
        End Sub

        Public Sub Remove(order As COrder)
            m_OrderSet.Remove(order)
        End Sub

        Public Function Count() As Integer
            Return m_OrderSet.Count
        End Function

        Public Function Print()
            For Each order In m_OrderSet
                Debug.Print("Date:{0},OrderType:{1}, Position:{2}, Price:{3}", order.orderdatetime, order.side, order.position, order.price)
            Next

        End Function
    End Class

End Namespace
