Imports MyTradingSystem.DataEntity
Imports Steema.TeeChart

Imports TicTacTec.TA.Library


Namespace Indicator


    Public Class CIndicatorPlotAxTchart_BBand
        Implements IIndicatorPlotAxTchart

        Private m_LineUp As Steema.TeeChart.Styles.Line
        Private m_LineMd As Steema.TeeChart.Styles.Line
        Private m_LineDn As Steema.TeeChart.Styles.Line

        Public Sub Hide() Implements IIndicatorPlotAxTchart.Hide

        End Sub

        Public Sub Plot(dt As DataTable, ByRef canvas As Chart, canvaspos As Short, Optional pat As EPriceAdjustedType = DataEntity.EPriceAdjustedType.ForAdj) Implements IIndicatorPlotAxTchart.Plot
            Try

                m_LineUp = New Steema.TeeChart.Styles.Line(canvas)
                m_LineMd = New Steema.TeeChart.Styles.Line(canvas)
                m_LineDn = New Steema.TeeChart.Styles.Line(canvas)
                m_LineUp.CustomVertAxis = canvas.Axes.Custom(canvaspos)
                m_LineMd.CustomVertAxis = canvas.Axes.Custom(canvaspos)
                m_LineDn.CustomVertAxis = canvas.Axes.Custom(canvaspos)


                Dim iCount As Integer = 0

                With m_LineDn
                    For Each row As DataRow In dt.Rows
                        If row(1) <> -1 Then
                            .Add(iCount, row(1))
                        End If
                        iCount += 1
                    Next
                End With

                iCount = 0
                With m_LineMd
                    For Each row As DataRow In dt.Rows
                        If row(2) <> -1 Then
                            .Add(iCount, row(2))
                        End If
                        iCount += 1
                    Next
                End With

                'iCount = 1 ?
                iCount = 0
                With m_LineUp
                    For Each row As DataRow In dt.Rows
                        If row(3) <> -1 Then
                            .Add(iCount, row(3))
                        End If
                        iCount += 1
                    Next
                End With

                m_LineUp.Color = Color.Magenta
                m_LineMd.Color = Color.Navy
                m_LineDn.Color = Color.Magenta

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Public Sub RemovePlot(ByRef canvas As Chart) Implements IIndicatorPlotAxTchart.RemovePlot
            If Not IsNothing(m_LineUp) Then
                canvas.Series.Remove(m_LineUp)
            End If

            If Not IsNothing(m_LineMd) Then
                canvas.Series.Remove(m_LineMd)
            End If

            If Not IsNothing(m_LineDn) Then
                canvas.Series.Remove(m_LineDn)
            End If
        End Sub

        Public Sub Show() Implements IIndicatorPlotAxTchart.Show
            If Not IsNothing(m_LineUp) Then
                m_LineUp.Visible = True
            End If

            If Not IsNothing(m_LineMd) Then
                m_LineMd.Visible = True
            End If

            If Not IsNothing(m_LineDn) Then
                m_LineDn.Visible = True
            End If
        End Sub
    End Class

    Public Class CIndicator_BBand
        Inherits CIndicatorPrice

        '参数定义
        Private m_Period As Double = 20   '周期，默认为20

        Private m_NbDevUp As Double = 2     '上宽度

        Private m_NbDevDn As Double = 2   '下宽度

        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal dt As CDTDaily)

            MyBase.New(dt)
            m_PlotAxTChart = New CIndicatorPlotAxTchart_BBand

            m_PriceData = dt

            Dim strColumnName As String = "BBand Period" & m_Period & "_" & EPriceType.Close.ToString
            Me.Columns.Add(strColumnName, GetType(System.Double))

            strColumnName = "BBand Up Width" & m_NbDevUp
            Me.Columns.Add(strColumnName, GetType(System.Double))

            strColumnName = "BBand Down Width" & m_NbDevDn
            Me.Columns.Add(strColumnName, GetType(System.Double))

            Init()

            Calculate()


        End Sub

        Protected Overrides Function Init(Optional Period As UShort = 3) As Integer
            '增加和m_PriceData相同数目的行
            'm_PriceData.Rows.Clear()
            Try

                Period = m_Period

                If Me.Rows.Count = 0 Then
                    For Each row As DataRow In m_PriceData.Rows
                        Dim rowMe As DataRow = Me.NewRow()
                        rowMe.Item("TheDate") = row.Item("TheDate")
                        Me.Rows.Add(rowMe)
                    Next

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Function

        Protected Overrides Sub Calculate()
            Dim inputPrice() As Double
            Dim outputUpperBand() As Double
            Dim outputMidBand() As Double
            Dim outputLowBand() As Double

            Dim optInTimePeriod As Integer = m_Period
            Dim optInNbDevUp As Double = m_NbDevUp
            Dim optInNbDevDn As Double = m_NbDevDn
            Dim optInMAType As Core.MAType = Core.MAType.Sma

            Dim BeginIndex As Int16, OutLength As Int16

            Try

                ReDim inputPrice(Me.Rows.Count - 1)
                ReDim outputUpperBand(Me.Rows.Count - 1)
                ReDim outputMidBand(Me.Rows.Count - 1)
                ReDim outputLowBand(Me.Rows.Count - 1)

                SetInputValue(inputPrice)

                'Dim retCode1 As Core.RetCode = Core.Macd(0, inputPrice.Length - 1, inputPrice, m_PeriodsFast, m_PeriodsSlow, m_PeriodsSginal, BeginIndex, OutLength, outputMACD, outputMACDSignal, outputMACDHist)
                Dim retCode As Core.RetCode = Core.Bbands(0, inputPrice.Length - 1, inputPrice,
                                                          optInTimePeriod, optInNbDevUp, optInNbDevDn, optInMAType,
                                                          BeginIndex, OutLength,
                                                          outputUpperBand, outputMidBand, outputLowBand)

                SetOutputValue(BeginIndex, OutLength, outputUpperBand, 1, m_Period)
                SetOutputValue(BeginIndex, OutLength, outputMidBand, 2, m_Period)
                SetOutputValue(BeginIndex, OutLength, outputLowBand, 3, m_Period)

                If retCode <> ERetCode.Success Then
                    Throw New Exception("TALib computation error")
                End If

            Catch ex As Exception

            End Try
        End Sub
        ''' <summary>
        ''' 给指标的输入值赋值
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub SetInputValue(ByRef inputPrice() As Double, Optional pt As EPriceType = EPriceType.Close)
            Dim i As Integer = 0

            For Each row As DataRow In Me.Rows
                If pt = EPriceType.Open Then
                    inputPrice(i) = m_PriceData.GetOpenPrice(i)
                ElseIf pt = EPriceType.High Then
                    inputPrice(i) = m_PriceData.GetHighPrice(i)
                ElseIf pt = EPriceType.Low Then
                    inputPrice(i) = m_PriceData.GetLowPrice(i)
                ElseIf pt = EPriceType.Close Then
                    inputPrice(i) = m_PriceData.GetLowPrice(i)
                End If

                i += 1
            Next
        End Sub

        ''' <summary>
        ''' 给指标的输出值赋值，每次输出1列
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub SetOutputValue(ByVal beginindex As Int16, Outlength As Int16, ByVal outputPrice() As Double, ByVal iColumnNumber As Int16, ByVal PeriodsAverage As Int16)
            Dim i As Int16 = 0

            '如果均线周期比数据长度还长，则Indicator均取-1，无效值
            If Outlength = 0 Then
                For Each row As DataRow In Me.Rows
                    Me.Rows(i).Item(iColumnNumber) = -1
                    i += 1
                Next
            Else
                '给Me对象赋值
                For Each row As DataRow In Me.Rows
                    If i > beginindex Then
                        Me.Rows(i).Item(iColumnNumber) = outputPrice(i - PeriodsAverage + 1)
                    Else
                        Me.Rows(i).Item(iColumnNumber) = -1
                    End If
                    i += 1
                Next
            End If


        End Sub

        ''' <summary>
        ''' 设置参数，并重新计算
        ''' </summary>
        ''' <param name="period"></param>
        ''' <param name="pt"></param>
        ''' <remarks></remarks> 
        Public Overrides Sub SetParameters(ByVal ParamArray paArray() As Double)


            Dim period, upwidth, downwidth As UInt16
            period = paArray(0)
            upwidth = paArray(1)
            downwidth = paArray(2)

            '如果参数相同，不需要重新计算设置
            If period = m_Period And upwidth = m_NbDevUp And downwidth = m_NbDevDn Then ' And m_PriceType = pt 
                Exit Sub
            End If

            ''判断periodFast是否有效
            'If periodfast > Me.Rows.Count - 1 OrElse periodfast = 1 Then
            '    MsgBox("无效均线间隔。已设置为默认值3。")
            '    m_PeriodsAverage_Fast = 3
            'Else
            '    m_PeriodsAverage_Fast = periodfast
            'End If

            ''判断periodMid是否有效
            'If periodmid > Me.Rows.Count - 1 OrElse periodmid = 1 Then
            '    MsgBox("无效均线间隔。已设置为默认值7。")
            '    m_PeriodsAverage_Mid = 7
            'Else
            '    m_PeriodsAverage_Mid = periodmid
            'End If


            ''判断periodSlow是否有效
            'If periodslow > Me.Rows.Count - 1 OrElse periodslow = 1 Then
            '    MsgBox("无效均线间隔。已设置为默认值15。")
            '    m_PeriodsAverage_Slow = 15
            'Else
            '    m_PeriodsAverage_Slow = periodslow
            'End If


            m_Period = period
            m_NbDevUp = upwidth
            m_NbDevDn = downwidth

            'm_PriceType = m_PriceType

            Calculate()
        End Sub
        '
        ''' <summary>
        ''' 设置参数，并计算
        ''' </summary>
        ''' <param name="pt"></param>
        ''' <remarks></remarks>
        Public Overloads Sub SetParameters(period As Int16, upwidth As Int16, downwidth As Int16, Optional pt As EPriceType = EPriceType.Close)

            '如果参数相同，不需要重新计算设置
            If period = m_Period And upwidth = m_NbDevUp And downwidth = m_NbDevDn And m_PriceType = pt Then
                Exit Sub
            End If

            ''判断periodFast是否有效
            'If periodFast > Me.Rows.Count - 1 OrElse periodFast = 1 Then
            '    MsgBox("无效均线间隔。已设置为默认值3。")
            '    m_PeriodsAverage_Fast = 3
            'Else
            '    m_PeriodsAverage_Fast = periodFast
            'End If

            ''判断periodMid是否有效
            'If periodMid > Me.Rows.Count - 1 OrElse periodMid = 1 Then
            '    MsgBox("无效均线间隔。已设置为默认值7。")
            '    m_PeriodsAverage_Mid = 7
            'Else
            '    m_PeriodsAverage_Mid = periodMid
            'End If


            ''判断periodSlow是否有效
            'If periodSlow > Me.Rows.Count - 1 OrElse periodSlow = 1 Then
            '    MsgBox("无效均线间隔。已设置为默认值15。")
            '    m_PeriodsAverage_Slow = 15
            'Else
            '    m_PeriodsAverage_Slow = periodSlow
            'End If


            m_Period = period
            m_NbDevUp = upwidth
            m_NbDevDn = downwidth

            m_PriceType = pt

            Calculate()
        End Sub

    End Class

End Namespace
