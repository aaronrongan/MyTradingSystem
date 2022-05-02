Public Class CRegExp
    Public Sub GetStockList(sStream As String)

        'Dim oRE As System.Text.RegularExpressions

        Dim sStr() As String

        sStr = Split(sStream, ",")

        MsgBox(UBound(sStr))

        Dim i As Integer

        For i = 1 To UBound(sStr)
            Debug.Print(sStr(i))
            'MsgBox(sStr(i))
        Next


    End Sub
End Class
