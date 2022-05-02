Public Class CStatistic



    '统计每个月的涨跌概率
    Public Sub CountMonthUD()
        Dim iRow As Long
        Dim iRowTotal As Long

        Dim dThisDate As Date

        Dim iMonthUp(12) As Integer
        Dim iMonthDown(12) As Integer

        Dim iCurrentMonth As Integer


        'iRowTotal = Worksheets("九鼎测试数据").UsedRange.Rows.Count
        Debug.Print("Total Rows:" & iRowTotal)

        For iRow = 2 To iRowTotal

            '取得本行日期
            'dThisDate = CDate(Cells(iRow, 1))

            'iCurrentMonth = Month(dThisDate)

            'If Cells(iRow, 8) > 0 Then
            '    iMonthUp(iCurrentMonth) = iMonthUp(iCurrentMonth) + 1
            'Else
            '    iMonthDown(iCurrentMonth) = iMonthDown(iCurrentMonth) + 1
            'End If

            'End Select
        Next

        For iRow = 1 To 12
            'Cells(29 + iRow, "M") = iMonthUp(iRow)
            'Cells(29 + iRow, "N") = iMonthDown(iRow)
            'Cells(29 + iRow, "O") = iMonthUp(iRow) / (iMonthUp(iRow) + iMonthDown(iRow)) '上涨概率

        Next
    End Sub

End Class
