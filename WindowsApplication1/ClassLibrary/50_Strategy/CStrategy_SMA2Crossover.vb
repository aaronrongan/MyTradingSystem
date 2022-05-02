Imports Steema.TeeChart
Imports MyTradingSystem.Indicator
Imports MyTradingSystem.DataEntity
Imports MyTradingSystem.Trade

Namespace Strategy

    Public Class CStrategyPlotAxTchart_SMA2
        Implements IStrategyPlotAxTchart


        Private m_SMA2Image_Buy As Steema.TeeChart.Styles.ImagePoint
        Private m_SMA2Image_Sell As Steema.TeeChart.Styles.ImagePoint

        Public Sub Hide() Implements IStrategyPlotAxTchart.Hide
            'If Not IsNothing(m_SMALine) Then
            '    m_SMALine.Visible = False
            'End If
        End Sub

        ''' <summary>
        ''' 用图像来显示Buy、Sell信号
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <param name="candle"></param>
        ''' <remarks></remarks>
        Public Sub Plot(dt As DataTable, ByRef candle As Styles.Candle, ByVal canvaspos As Int16) Implements IStrategyPlotAxTchart.Plot
            Try
                Dim iCount As Int16 = 0
                m_SMA2Image_Buy = New Steema.TeeChart.Styles.ImagePoint(candle.Chart)
                m_SMA2Image_Sell = New Steema.TeeChart.Styles.ImagePoint(candle.Chart)

                m_SMA2Image_Buy.CustomVertAxis = candle.Chart.Axes.Custom(canvaspos)
                m_SMA2Image_Sell.CustomVertAxis = candle.Chart.Axes.Custom(canvaspos)

                Dim s As String = "Steema.TeeChart.Samples.euro-coin.jpg"

                Dim stream As System.IO.Stream = System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(s)
               
                m_SMA2Image_Buy.PointImage = Image.FromFile("C:\MyDocuments\我的坚果云\MyProjects\MyTradingSystem\WindowsApplication1\WindowsApplication1\Resources\Buy.ico") ' Image.FromStream(stream)
                m_SMA2Image_Sell.PointImage = Image.FromFile("C:\MyDocuments\我的坚果云\MyProjects\MyTradingSystem\WindowsApplication1\WindowsApplication1\Resources\Sell.ico")

                m_SMA2Image_Buy.Pointer.HorizSize = 8
                m_SMA2Image_Buy.Pointer.VertSize = 8

                m_SMA2Image_Sell.Pointer.HorizSize = 8
                m_SMA2Image_Sell.Pointer.VertSize = 8
             
                For iCount = 0 To dt.Rows.Count - 1

                    If dt.Rows(iCount).Item("Signal") = ETransactionSignalType.BuyLongCross Then
                        m_SMA2Image_Buy.Add(iCount, dt.Rows(iCount).Item("HighPrice") * 1.02)
                        Debug.Print(dt.Rows(iCount).Item("TheDate"))
                    ElseIf dt.Rows(iCount).Item("Signal") = ETransactionSignalType.SellLongCross Then
                        m_SMA2Image_Sell.Add(iCount, dt.Rows(iCount).Item("LowPrice") * 0.98)
                        Debug.Print(dt.Rows(iCount).Item("TheDate"))
                    End If



                Next

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Public Sub Plot_withLabel(dt As DataTable, ByRef candle As Styles.Candle) 'Implements IStrategyPlotAxTchart.Plot
            Try
                Dim iCount As Int16 = 0
                With candle.Marks
                    'For Each it As Steema.TeeChart.Styles.MarksItem In .Items
                    '    'CType(it, Steema.TeeChart.Styles.Candle).Visible = False
                    '    it.Visible = False
                    'Next

                    '必须先将所有的marks置为true
                    .Visible = True
                    .Style = Styles.MarksStyles.Label
                    '.Style = Styles.MarksStyles.XValue
                    .Font.Size = 12
                    .Callout.Length = 50
                    For iCount = 0 To dt.Rows.Count - 1
                        .Items(iCount).Visible = False
                        If dt.Rows(iCount).Item(1) = ETransactionSignalType.BuyLongCross Then
                            '.Series.XValues(iCount) = 100
                            candle.Labels(iCount) = "B"
                            .Items(iCount).Font.Color = Color.Red
                            .Items(iCount).Visible = True
                        ElseIf dt.Rows(iCount).Item(1) = ETransactionSignalType.SellLongCross Then
                            candle.Labels(iCount) = "S"
                            '.Series.XValues(iCount) = -100
                            .Items(iCount).Font.Color = Color.Green
                            .Items(iCount).Visible = True
                        End If
                        'Debug.Print(candle.XValues(iCount))
                    Next

                End With

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Public Sub RemovePlot() Implements IStrategyPlotAxTchart.RemovePlot
            If Not IsNothing(m_SMA2Image_Buy) Then
                m_SMA2Image_Buy.Clear()
            End If
            If Not IsNothing(m_SMA2Image_Sell) Then
                m_SMA2Image_Sell.Clear()
            End If

        End Sub

        Public Sub Show() Implements IStrategyPlotAxTchart.Show
            'If Not IsNothing(m_SMALine) Then
            '    m_SMALine.Visible = True
            'End If
        End Sub
    End Class
    ''' <summary>
    ''' 策略：用MA交叉方法卖出
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CStrategy_SMA2Crossover

        Inherits CStrategy

        Protected m_FastPeriod As Int16 = 9
        Protected m_SlowPeriod As Int16 = 3

        'Public Shadows Event TransactionSignal(ByVal sender As Object, ByVal e As TransactionSignalEventArgs)
        'Public Shadows Event SendSignal(ByVal sender As Object, ByVal e As TradingEventArgs)

        'Public Event SendSignal As TradingEventArgs
        'Public WithEvents TradingEvent As CQuantTrading

        Public Function Test()
            Dim idcf As New CStrategyFactory
            Dim dt As New DataTable

            'idcf.CreateIndicator(EIndicatorName.SMA, dt)


        End Function

        Public Sub New()
            MyBase.New()
        End Sub


        Public Sub New(dt As CDTDaily)
            MyBase.New(dt)
            m_PlotAxTChart = New CStrategyPlotAxTchart_SMA2

            m_Signal = New CTransactionSignal

            Init()
        End Sub
        Public ReadOnly Property FastPeriod As Int16
            Get
                FastPeriod = m_FastPeriod
            End Get
        End Property

        Public ReadOnly Property SlowPeriod As Int16
            Get
                SlowPeriod = m_SlowPeriod
            End Get
        End Property
     
        Protected Overrides Sub Init()

            MyBase.Init()
            m_StragetyName = "均线交叉策略"

            Dim strColumnName As String = "Signal"

            If m_PriceData.Rows.Count > 0 Then

                m_DTStrategySignal.Columns.Add(strColumnName, GetType(ETransactionSignalType))

            End If

            '计算指标
            'SetupIndicator()
            'm_IDC = CIndicatorFactory.CreateIndicator(EIndicatorName.SMA2, m_PriceData)
            'm_IDC.SetDefaultParameters()

            '这里要注意指标的赋值要重新写
            'm_IDC.SetParameters(m_FastPeriod, m_SlowPeriod)

            'CalculateAll()

        End Sub
        ''' <summary>
        ''' 运行策略，每次只运行1天的数据
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <param name="iDayIndex"></param>
        ''' <remarks></remarks>
        Public Overrides Sub Run(iDayIndex As Int16, bSendSignal As Boolean)
            Try

                Dim bBullBear, bLastBullBear As Boolean '找出指标线切换点


                m_DTStrategySignal.Rows(iDayIndex).Item("OpenPrice") = m_PriceData.GetOpenPrice(iDayIndex)
                m_DTStrategySignal.Rows(iDayIndex).Item("HighPrice") = m_PriceData.GetHighPrice(iDayIndex)
                m_DTStrategySignal.Rows(iDayIndex).Item("LowPrice") = m_PriceData.GetLowPrice(iDayIndex)
                m_DTStrategySignal.Rows(iDayIndex).Item("ClosePrice") = m_PriceData.GetClosePrice(iDayIndex)

                'VIP 此处错误：m_IDC.Row(3).Item(2)为Null值，为什么？
                If m_IDC.Rows(iDayIndex).Item(1) <> -1 And m_IDC.Rows(iDayIndex).Item(2) <> -1 Then
                    If (m_IDC.Rows(iDayIndex).Item(1) > m_IDC.Rows(iDayIndex).Item(2)) Then

                        m_DTStrategySignal.Rows(iDayIndex).Item("Signal") = ETransactionSignalType.Bullish

                        bBullBear = True

                    ElseIf (m_IDC.Rows(iDayIndex).Item(1) < m_IDC.Rows(iDayIndex).Item(2)) Then

                        m_DTStrategySignal.Rows(iDayIndex).Item("Signal") = ETransactionSignalType.Bearish
                        bBullBear = False

                    Else 'VIP 这里的无方向要重写，什么叫无方向？。。。
                        m_DTStrategySignal.Rows(iDayIndex).Item("Signal") = ETransactionSignalType.Directionless
                    End If


                    If m_DTStrategySignal.Rows(iDayIndex - 1).Item("Signal") <> ETransactionSignalType.Invalid Then

                        If m_DTStrategySignal.Rows(iDayIndex - 1).Item("Signal") = ETransactionSignalType.Bullish Or m_DTStrategySignal.Rows(iDayIndex - 1).Item("Signal") = ETransactionSignalType.BuyLongCross Then
                            bLastBullBear = True
                        ElseIf m_DTStrategySignal.Rows(iDayIndex - 1).Item("Signal") = ETransactionSignalType.Bearish Or m_DTStrategySignal.Rows(iDayIndex - 1).Item("Signal") = ETransactionSignalType.SellLongCross Then
                            bLastBullBear = False
                        End If

                        If bBullBear = True And bLastBullBear = False Then
                            m_DTStrategySignal.Rows(iDayIndex).Item("Signal") = ETransactionSignalType.BuyLongCross

                            m_Signal.SignalDateTime = CDate(m_PriceData.Rows(iDayIndex).Item("TheDate"))
                            m_Signal.SignalType = ETransactionSignalType.BuyLongCross
                            m_Signal.TradingPrice = m_DTStrategySignal.Rows(iDayIndex).Item("ClosePrice")
                            If bSendSignal = True Then
                                RaiseTransactionSignal(Me, New TransactionSignalEventArgs(m_Signal))
                            End If


                        ElseIf bBullBear = False And bLastBullBear = True Then

                            m_DTStrategySignal.Rows(iDayIndex).Item("Signal") = ETransactionSignalType.SellLongCross
                            m_Signal.SignalDateTime = CDate(m_PriceData.Rows(iDayIndex).Item("TheDate"))
                            m_Signal.SignalType = ETransactionSignalType.SellLongCross
                            m_Signal.TradingPrice = m_DTStrategySignal.Rows(iDayIndex).Item("ClosePrice")
                            If bSendSignal = True Then
                                RaiseTransactionSignal(Me, New TransactionSignalEventArgs(m_Signal))
                            End If
                        End If
                    End If

                Else
                    m_DTStrategySignal.Rows(iDayIndex).Item("Signal") = ETransactionSignalType.Invalid

                End If

                'VIP
                '快线超过慢线时，发出Buy信号，否则发出Sell信号
                'If m_IDC.Rows(iDayIndex).Item(1) <> -1 And m_IDC.Rows(iDayIndex).Item(2) <> -1 Then
                '    If (m_IDC.Rows(iDayIndex).Item(1) > m_IDC.Rows(iDayIndex).Item(2)) Then
                '        ' 发出 "Buy"信号
                '        m_Signal.SignalType = ETransactionSignalType.BuyLongCross
                '        m_Signal.TradingPrice = dt.Rows(iDayIndex).Item("ClosePrice")

                '        RaiseTransactionSignal(Me, New TransactionSignalEventArgs(m_Signal))
                '    ElseIf (m_IDC.Rows(iDayIndex).Item(1) < m_IDC.Rows(iDayIndex).Item(2)) Then
                '        ' 发出 "Sell"信号
                '        m_Signal.SignalType = ETransactionSignalType.SellLongCross
                '        RaiseTransactionSignal(Me, New TransactionSignalEventArgs(m_Signal))
                '    End If
                'End If


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        ''' <summary>
        ''' 运行策略，独立运行，得出所有的交易信号，放到Signal Data表中
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <param name="iDayIndex"></param>
        ''' <remarks></remarks>
        Public Overrides Sub CalculateAll()

            Try
                'Dim bBullBear, bLastBullBear, bFirstItem As Boolean '找出指标线切换点
                'bFirstItem = True

                '计算指标 .这里和Init中的设置IDC有重叠，要修改

                'SetupIndicator()

                Dim iDayIndex As Int16 = 0
                For iDayIndex = 0 To m_PriceData.Rows.Count - 1
                    Run(iDayIndex, False)

                    'm_DTStrategySignal.Rows(iDayIndex).Item("OpenPrice") = m_PriceData.GetOpenPrice(iDayIndex)
                    'm_DTStrategySignal.Rows(iDayIndex).Item("HighPrice") = m_PriceData.GetHighPrice(iDayIndex)
                    'm_DTStrategySignal.Rows(iDayIndex).Item("LowPrice") = m_PriceData.GetLowPrice(iDayIndex)
                    'm_DTStrategySignal.Rows(iDayIndex).Item("ClosePrice") = m_PriceData.GetClosePrice(iDayIndex)

                    ''VIP
                    ''快线超过慢线时，发出Buy信号，否则发出Sell信号
                    'If m_IDC.Rows(iDayIndex).Item(1) <> -1 And m_IDC.Rows(iDayIndex).Item(2) <> -1 Then
                    '    If (m_IDC.Rows(iDayIndex).Item(1) > m_IDC.Rows(iDayIndex).Item(2)) Then

                    '        m_DTStrategySignal.Rows(iDayIndex).Item("Signal") = ETransactionSignalType.Bullish

                    '        bBullBear = True

                    '    ElseIf (m_IDC.Rows(iDayIndex).Item(1) < m_IDC.Rows(iDayIndex).Item(2)) Then

                    '        m_DTStrategySignal.Rows(iDayIndex).Item("Signal") = ETransactionSignalType.Bearish
                    '        bBullBear = False
                    '    Else
                    '        m_DTStrategySignal.Rows(iDayIndex).Item("Signal") = ETransactionSignalType.Directionless
                    '    End If

                    '    If bFirstItem = True Then
                    '        bFirstItem = False
                    '    Else
                    '        If bBullBear = True And bLastBullBear = False Then
                    '            m_DTStrategySignal.Rows(iDayIndex).Item("Signal") = ETransactionSignalType.BuyLongCross
                    '        ElseIf bBullBear = False And bLastBullBear = True Then
                    '            m_DTStrategySignal.Rows(iDayIndex).Item("Signal") = ETransactionSignalType.SellLongCross
                    '        End If
                    '    End If
                    '    bLastBullBear = bBullBear
                    'Else
                    '    m_DTStrategySignal.Rows(iDayIndex).Item("Signal") = -1
                    'End If
                Next

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub

        ''' <summary>
        ''' 设置参数，并重新计算
        ''' </summary>
        ''' <param name="period"></param>
        ''' <param name="pt"></param>
        ''' <remarks></remarks> 
        Public Overrides Sub SetParameters(ByVal ParamArray paArray() As Double)


            Dim FastPeriod, SlowPeriod As UInt16

            FastPeriod = paArray(0)
            SlowPeriod = paArray(1)

            '如果参数相同，不需要重新计算设置
            If FastPeriod = m_FastPeriod And SlowPeriod = m_SlowPeriod Then
                Exit Sub
            End If

            ''判断period是否有效
            'If period > Me.Rows.Count - 1 OrElse period = 1 Then
            '    MsgBox("无效均线间隔。已设置为默认值3。")
            '    m_PeriodsAverage = 3
            'Else
            '    m_PeriodsAverage = period
            'End If

            m_FastPeriod = FastPeriod
            m_SlowPeriod = SlowPeriod

            SetupIndicator()

            'CalculateAll()
        End Sub
        Public Overrides Sub PopWindowParameterPlot(ByRef candle As Styles.Candle, ByVal canvaspos As Int16)
            frm_StrategySMA2_Setup.ShowDialog()

            Dim para1 As Int16 = frm_StrategySMA2_Setup.m_FastPeriods
            Dim para2 As Int16 = frm_StrategySMA2_Setup.m_SlowPeriods

            frm_StrategySMA2_Setup.Dispose()

            SetParameters(para1, para2)
            CalculateAll()
            m_PlotAxTChart.Plot(m_DTStrategySignal, candle, canvaspos)
        End Sub
        Public Overrides Sub Setup()

        End Sub

        Protected Sub SetupIndicator()
            '计算指标 .这里和Init中的设置IDC有重叠，要修改
            m_IDC = CIndicatorFactory.CreateIndicator(EIndicatorName.SMA2, m_PriceData)
            'm_IDC.SetDefaultParameters()
            m_IDC.SetParameters(m_FastPeriod, m_SlowPeriod)

        End Sub

    End Class
End Namespace
