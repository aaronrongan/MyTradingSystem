Imports Steema.TeeChart
Imports MyTradingSystem.Indicator
Imports MyTradingSystem.DataEntity
Imports MyTradingSystem.Trade

Namespace Strategy
    Public Class CStrategyPlotAxTchartMACD
        Implements IStrategyPlotAxTchart



        'Private m_SMALine As Steema.TeeChart.Styles.Line

        Public Sub Hide() Implements IStrategyPlotAxTchart.Hide
            'If Not IsNothing(m_SMALine) Then
            '    m_SMALine.Visible = False
            'End If
        End Sub

        'Public Sub Plot(dt As DataTable, ByRef canvas As Chart, canvaspos As Short, Optional pat As DataEntity.EPriceAdjustedType = DataEntity.EPriceAdjustedType.ForAdj) Implements IStrategyPlotAxTchart.Plot
        '    Try

        '        m_SMALine = New Steema.TeeChart.Styles.Line(canvas)
        '        m_SMALine.CustomVertAxis = canvas.Axes.Custom(canvaspos) '.Left '.GetVertAxis
        '        m_SMALine.Visible = True


        '        Dim iCount As Integer = 1

        '        With m_SMALine
        '            For Each row As DataRow In dt.Rows
        '                If row(1) <> -1 Then
        '                    .Add(iCount, row(1))

        '                End If
        '                iCount += 1
        '            Next

        '        End With

        '        m_SMALine.Color = Color.Red

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
        'End Sub

        Public Sub RemovePlot() Implements IStrategyPlotAxTchart.RemovePlot
            'If Not IsNothing(m_SMALine) Then

            '    m_SMALine.Clear()
            'End If
        End Sub

        Public Sub Show() Implements IStrategyPlotAxTchart.Show
            'If Not IsNothing(m_SMALine) Then
            '    m_SMALine.Visible = True
            'End If
        End Sub

        Public Sub Plot(dt As DataTable, ByRef candle As Styles.Candle, ByVal canvaspos As Int16) Implements IStrategyPlotAxTchart.Plot
            Try

            Catch ex As Exception

            End Try
        End Sub
    End Class

    Public Class CStrategy_MACDCrossover


        Inherits CStrategy

        Public m_FastPeriod As Int16 = 12
        Public m_SlowPeriod As Int16 = 26
        Public m_MACD As Int16 = 9

        Public Shadows Event SendSignal(ByVal sender As Object, ByVal e As TradingEventArgs)

        ''' <summary>
        ''' 运行策略，单步执行，返回Trading类一个信号
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <param name="iDayIndex"></param>
        ''' <remarks></remarks>
        Public Overrides Sub Run(iDayIndex As Int16, bSendSignal As Boolean)
            ''MyBase.Run(dt, iDayIndex)

            ''计算指标
            'm_IDC = CIndicatorFactory.CreateIndicator(EIndicatorName.MACD, dt)
            ''m_IDC.SetDefaultParameters()
            'm_IDC.SetParameters(m_FastPeriod, m_SlowPeriod, m_MACD)

            ''VIP
            ''快线超过慢线时，发出Buy信号，否则发出Sell信号
            'If (m_IDC.Rows(iDayIndex).Item(1) > m_IDC.Rows(iDayIndex).Item(2)) Then
            '    ' 发出 "Buy"信号
            '    m_Signal.SignalType = ETransactionSignalType.BuyLongCross
            '    m_Signal.TradingPrice = dt.Rows(iDayIndex).Item("ClosePrice")

            '    RaiseEvent SendSignal(Me, New TradingEventArgs(m_Signal))
            'ElseIf (m_IDC.Rows(iDayIndex).Item(1) < m_IDC.Rows(iDayIndex).Item(2)) Then
            '    ' 发出 "Sell"信号
            '    m_Signal.SignalType = ETransactionSignalType.SellLongCross
            '    RaiseEvent SendSignal(Me, New TradingEventArgs(m_Signal))
            'End If
        End Sub

        ''' <summary>
        ''' 运行策略，独立运行，得出所有的交易信号
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <param name="iDayIndex"></param>
        ''' <remarks></remarks>
        Public Overrides Sub CalculateAll()
            ''MyBase.Run(dt, iDayIndex)

            ''计算指标
            'm_IDC = CIndicatorFactory.CreateIndicator(EIndicatorName.SMA2, m_PriceData)
            'm_IDC.SetDefaultParameters()

            'Dim iDayIndex As Int16 = 0
            'For iDayIndex = 0 To m_PriceData.Rows.Count
            '    Run(m_PriceData, iDayIndex)
            'Next

            ''VIP
            ''快线超过慢线时，发出Buy信号，否则发出Sell信号
            'If (m_IDC.Rows(iDayIndex).Item(1) > m_IDC.Rows(iDayIndex).Item(2)) Then
            '    ' 发出 "Buy"信号
            '    m_Signal.SignalType = ETransactionSignalType.BuyLongCross
            '    m_Signal.TradingPrice = m_PriceData.Rows(iDayIndex).Item("ClosePrice")

            '    RaiseEvent SendSignal(Me, New TradingEventArgs(m_Signal))
            'ElseIf (m_IDC.Rows(iDayIndex).Item(1) < m_IDC.Rows(iDayIndex).Item(2)) Then
            '    ' 发出 "Sell"信号
            '    m_Signal.SignalType = ETransactionSignalType.SellLongCross
            '    RaiseEvent SendSignal(Me, New TradingEventArgs(m_Signal))
            'End If
        End Sub

        ''' <summary>
        ''' 设置参数，并重新计算
        ''' </summary>
        ''' <param name="period"></param>
        ''' <param name="pt"></param>
        ''' <remarks></remarks> 
        Public Overrides Sub SetParameters(ByVal ParamArray paArray() As Double)


            'Dim FastPeriod, SlowPeriod As UInt16

            'FastPeriod = paArray(0)
            'SlowPeriod = paArray(1)

            ''如果参数相同，不需要重新计算设置
            'If FastPeriod = m_FastPeriod And SlowPeriod = m_SlowPeriod Then
            '    Exit Sub
            'End If

            ' ''判断period是否有效
            ''If period > Me.Rows.Count - 1 OrElse period = 1 Then
            ''    MsgBox("无效均线间隔。已设置为默认值3。")
            ''    m_PeriodsAverage = 3
            ''Else
            ''    m_PeriodsAverage = period
            ''End If

            'm_FastPeriod = FastPeriod
            'm_SlowPeriod = SlowPeriod

            'CalculateAll()
        End Sub

    End Class
End Namespace
