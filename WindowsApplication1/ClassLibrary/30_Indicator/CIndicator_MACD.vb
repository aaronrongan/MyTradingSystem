Imports MyTradingSystem.DataEntity
Imports Steema.TeeChart

Imports TicTacTec.TA.Library

Namespace Indicator

    ''' <summary>
    ''' 在AxTchart上绘制均线
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CIndicatorPlotAxTchart_MACD
        Implements IIndicatorPlotAxTchart



        Private m_DIFF, m_DEA As Steema.TeeChart.Styles.Line
        Private m_MACD As Steema.TeeChart.Styles.Volume

        Public Sub Hide() Implements IIndicatorPlotAxTchart.Hide

        End Sub

        Public Sub Plot(dt As DataTable, ByRef canvas As Chart, canvaspos As Short, Optional pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj) Implements IIndicatorPlotAxTchart.Plot
            Try

                m_DIFF = New Steema.TeeChart.Styles.Line(canvas)
                m_DIFF.CustomVertAxis = canvas.Axes.Custom(canvaspos)
                m_DIFF.Visible = True

                Dim iCount As Integer = 1

                With m_DIFF
                    For Each row As DataRow In dt.Rows
                        If row(1) <> -1 Then
                            .Add(iCount, row(1))

                        End If
                        'Debug.Print("Draw DIFF:" & iCount & ":" & row(1))
                        iCount += 1
                    Next

                End With

                m_DIFF.Color = Color.Red
                ''''''''''''''''''''''''''''''''''''''''''''
                m_DEA = New Steema.TeeChart.Styles.Line(canvas)
                m_DEA.CustomVertAxis = canvas.Axes.Custom(canvaspos) '.Left '.GetVertAxis
                m_DEA.Visible = True

                iCount = 1

                With m_DEA
                    For Each row As DataRow In dt.Rows
                        If row(2) <> -1 Then
                            .Add(iCount, row(2))
                        End If
                        'Debug.Print("Draw DEA:" & iCount & ":" & row(2))
                        iCount += 1
                    Next

                End With

                m_DEA.Color = Color.Blue
                ''''''''''''''''''''''''''''''''''''''''''''''
                m_MACD = New Steema.TeeChart.Styles.Volume(canvas)
                m_MACD.CustomVertAxis = canvas.Axes.Custom(canvaspos) '.Left '.GetVertAxis
                m_MACD.Visible = True
                m_MACD.UseOrigin = True

                iCount = 1
                'Dim vl As New Styles.ValueList(m_MACD, "MACD", dt.Rows.Count)
                ''MsgBox(vl.Capacity)
                ''vl.Capacity = 48
                'With m_MACD
                '    For Each row As DataRow In dt.Rows
                '        If row(3) <> -1 Then
                '            'vl.Item(1) = 3 ' row(3) * 2
                '            'vl(1) = 3
                '            'vl.Item(1) = 3
                '            'If row(3) > 0 Then
                '            '    .ColorRange(vl, iCount - 1, iCount - 1, Color.Red)
                '            'Else
                '            '    .ColorRange(vl, iCount - 1, iCount - 1, Color.Green)
                '            'End If
                '        End If
                '        iCount += 1
                '    Next
                '    ' m_MACD.DataSource = vl
                'End With
                'Dim cl As Styles.ColorList
                'cl.Add(Color.Red)
                'cl.Add(Color.Green)

                'TODO 如何实现单根线不同颜色
                With m_MACD
                    'm_MACD.ColorEach = True
                    For Each row As DataRow In dt.Rows
                        If row(3) <> -1 Then
                            .Add(iCount, row(3) * 2)      '放大2倍
                            If row(3) > 0 Then
                                '.ColorRange()
                                '.ValueColor()
                                .Brush.Color = Color.Red
                                .LinePen.Color = Color.Red
                                '.Pointer.Color = Color.Red
                            Else
                                '.ColorMember = Color.Green.ToString
                                .Brush.Color = Color.Green
                                .LinePen.Color = Color.Green
                                '.Pointer.Color = Color.Blue
                            End If
                            'Debug.Print("Draw MACD:" & iCount & ":" & row(3))

                        End If
                        iCount += 1
                    Next

                End With

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Public Sub RemovePlot(ByRef canvas As Chart) Implements IIndicatorPlotAxTchart.RemovePlot
            If Not IsNothing(m_DIFF) Then
                m_DIFF.Clear()
            End If

            If Not IsNothing(m_DEA) Then
                m_DEA.Clear()
            End If

            If Not IsNothing(m_MACD) Then
                m_MACD.Clear()
            End If

        End Sub

        Public Sub Show() Implements IIndicatorPlotAxTchart.Show

        End Sub
    End Class
    'MACD指标
    Public Class CIndicator_MACD
        Inherits CIndicator_MA

        'Public Shared Function Macd(startIdx As Integer, endIdx As Integer, inReal() As Single, optInFastPeriod As Integer, optInSlowPeriod As Integer, optInSignalPeriod As Integer, ByRef outBegIdx As Integer, ByRef outNBElement As Integer, outMACD() As Double, outMACDSignal() As Double, outMACDHist() As Double) As TicTacTec.TA.Library.Core.RetCode
        'Implements IIndicator

        Private m_PeriodsSlow As Int16 = 26   '默认为26
        Private m_PeriodsFast As Int16 = 12   '默认为12
        Private m_PeriodsSginal As Int16 = 9   '默认为9
        Public Sub New(ByVal dt As CDTDaily)

            MyBase.New(dt)
            m_PlotAxTChart = New CIndicatorPlotAxTchart_MACD

            m_PriceData = dt


            Dim strColumnName As String = "MACD" & m_PeriodsSlow & "_" & EPriceType.Close.ToString
            Me.Columns.Add(strColumnName, GetType(System.Double))

            strColumnName = "MACD" & m_PeriodsFast & "_" & EPriceType.Close.ToString
            Me.Columns.Add(strColumnName, GetType(System.Double))

            strColumnName = "MACD" & m_PeriodsSginal & "_" & EPriceType.Close.ToString
            Me.Columns.Add(strColumnName, GetType(System.Double))

            Init()

            Calculate()


        End Sub
        Public Overrides Sub SetDefaultParameters()
            Calculate()
        End Sub

        ''' <summary>
        ''' 设置参数，并重新计算
        ''' </summary>
        ''' <param name="period"></param>
        ''' <param name="pt"></param>
        ''' <remarks></remarks> 
        Public Overrides Sub SetParameters(ByVal ParamArray paArray() As Double)


            'Dim period As UInt16
            'period = paArray(0)
            ''如果参数相同，不需要重新计算设置
            'If period = m_PeriodsAverage And m_PriceType = pt Then
            '    Exit Sub
            'End If

            ''判断period是否有效
            'If period > Me.Rows.Count - 1 OrElse period = 1 Then
            '    MsgBox("无效均线间隔。已设置为默认值3。")
            '    m_PeriodsAverage = 3
            'Else
            '    m_PeriodsAverage = period
            'End If

            'm_PeriodsAverage = period
            'm_PriceType = pt

            Calculate()
        End Sub

        Protected Overrides Sub Calculate()
            Dim inputPrice() As Double
            Dim outputMACD() As Double
            Dim outputMACDSignal() As Double
            Dim outputMACDHist() As Double

            Dim BeginIndex As Int16, OutLength As Int16

            Try

                ReDim inputPrice(Me.Rows.Count - 1)
                ReDim outputMACD(Me.Rows.Count - 1)
                ReDim outputMACDSignal(Me.Rows.Count - 1)
                ReDim outputMACDHist(Me.Rows.Count - 1)

                SetInputValue(inputPrice)


                Dim retCode As Core.RetCode = Core.Macd(0, inputPrice.Length - 1, inputPrice, m_PeriodsFast, m_PeriodsSlow, m_PeriodsSginal, BeginIndex, OutLength, outputMACD, outputMACDSignal, outputMACDHist)

                SetOutputValue(BeginIndex, OutLength, outputMACD, 1)
                SetOutputValue(BeginIndex, OutLength, outputMACDSignal, 2)
                SetOutputValue(BeginIndex, OutLength, outputMACDHist, 3)

                If retCode <> ERetCode.Success Then
                    Throw New Exception("TALib computation error")
                End If

            Catch ex As Exception

            End Try
        End Sub


        ''' <summary>
        ''' 给指标的输出值赋值，每次输出1列
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overloads Sub SetOutputValue(ByVal beginindex As Int16, Outlength As Int16, ByVal outputPrice() As Double, ByVal iColumnNumber As Int16)
            Dim i As Int16 = 0

            '给Me对象赋值
            For Each row As DataRow In Me.Rows
                If i >= beginindex Then
                    Me.Rows(i).Item(iColumnNumber) = outputPrice(i - beginindex)
                Else
                    Me.Rows(i).Item(iColumnNumber) = -1
                End If
                'Debug.Print(i & ":" & Me.Rows(i).Item(iColumnNumber))
                i += 1
            Next
        End Sub

    End Class
End Namespace
