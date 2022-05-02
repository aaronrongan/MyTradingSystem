

Namespace Indicator



    Public Class CIndicatorPlotSets
        Implements Collections.Generic.IDictionary(Of EIndicatorName, IIndicator)


        Public Sub Add(item As KeyValuePair(Of EIndicatorName, IIndicator)) Implements ICollection(Of KeyValuePair(Of EIndicatorName, IIndicator)).Add

        End Sub

        Public Sub Clear() Implements ICollection(Of KeyValuePair(Of EIndicatorName, IIndicator)).Clear

        End Sub

        Public Function Contains(item As KeyValuePair(Of EIndicatorName, IIndicator)) As Boolean Implements ICollection(Of KeyValuePair(Of EIndicatorName, IIndicator)).Contains

        End Function

        Public Sub CopyTo(array() As KeyValuePair(Of EIndicatorName, IIndicator), arrayIndex As Integer) Implements ICollection(Of KeyValuePair(Of EIndicatorName, IIndicator)).CopyTo

        End Sub

        Public ReadOnly Property Count As Integer Implements ICollection(Of KeyValuePair(Of EIndicatorName, IIndicator)).Count
            Get

            End Get
        End Property

        Public ReadOnly Property IsReadOnly As Boolean Implements ICollection(Of KeyValuePair(Of EIndicatorName, IIndicator)).IsReadOnly
            Get

            End Get
        End Property

        Public Function Remove(item As KeyValuePair(Of EIndicatorName, IIndicator)) As Boolean Implements ICollection(Of KeyValuePair(Of EIndicatorName, IIndicator)).Remove

        End Function

        Public Sub Add1(key As EIndicatorName, value As IIndicator) Implements IDictionary(Of EIndicatorName, IIndicator).Add

        End Sub

        Public Function ContainsKey(key As EIndicatorName) As Boolean Implements IDictionary(Of EIndicatorName, IIndicator).ContainsKey

        End Function

        Default Public Property Item(key As EIndicatorName) As IIndicator Implements IDictionary(Of EIndicatorName, IIndicator).Item
            Get

            End Get
            Set(value As IIndicator)

            End Set
        End Property

        Public ReadOnly Property Keys As ICollection(Of EIndicatorName) Implements IDictionary(Of EIndicatorName, IIndicator).Keys
            Get

            End Get
        End Property

        Public Function Remove1(key As EIndicatorName) As Boolean Implements IDictionary(Of EIndicatorName, IIndicator).Remove

        End Function

        Public Function TryGetValue(key As EIndicatorName, ByRef value As IIndicator) As Boolean Implements IDictionary(Of EIndicatorName, IIndicator).TryGetValue

        End Function

        Public ReadOnly Property Values As ICollection(Of IIndicator) Implements IDictionary(Of EIndicatorName, IIndicator).Values
            Get

            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator(Of KeyValuePair(Of EIndicatorName, IIndicator)) Implements IEnumerable(Of KeyValuePair(Of EIndicatorName, IIndicator)).GetEnumerator

        End Function

        Public Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator

        End Function
    End Class

End Namespace
