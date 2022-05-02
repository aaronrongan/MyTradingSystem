
Imports TicTacTec.TA.Library
Imports MyTradingSystem.DataEntity
Imports Steema.TeeChart

Namespace Indicator


    ''' <summary>
    ''' 在AxTchart上绘制均线
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CIndicatorPlotAxTchart_SMA2
        Implements IIndicatorPlotAxTchart


        Private m_SMALineSlow As Steema.TeeChart.Styles.Line
        Private m_SMALineFast As Steema.TeeChart.Styles.Line

        Public Sub Plot(dt As DataTable, ByRef canvas As Chart, ByVal canvaspos As Int16, Optional pat As EPriceAdjustedType = DataEntity.EPriceAdjustedType.ForAdj) Implements IIndicatorPlotAxTchart.Plot
            'Dim iSeriesTotalNumber As Int16
            ''iSeriesTotalNumber = canvas.SeriesCount
            'Dim Count As Integer = 1
            'Dim iNewSeriesIndex1 As Int16
            'Dim iNewSeriesIndex2 As Int16
            ''iNewSeriesIndex1 = canvas.AddSeries(Global.TeeChart.ESeriesClass.scLine)
            ''iNewSeriesIndex2 = canvas.AddSeries(Global.TeeChart.ESeriesClass.scLine)

            'With canvas
            '    For Each row As DataRow In dt.Rows
            '        If row(1) <> -1 Then
            '            '.Series(iNewSeriesIndex1).AddXY(Count, row(1), "", 10)

            '        End If
            '        If row(2) <> -1 Then
            '            '.Series(iNewSeriesIndex2).AddXY(Count, row(2), "", 10)
            '        End If

            '        Count += 1
            '    Next

            'End With

            'Dim iSeriesTotalNumber As Int16
            'iSeriesTotalNumber = canvas.Series.Count
            'Dim Count As Integer = 1
            'Dim iNewSeriesIndex As Int16
            ''iNewSeriesIndex = canvas.AddSeries(Global.TeeChart.ESeriesClass.scLine)

            ''  iNewSeriesIndex = canvas.Series.Add()

            'With canvas
            '    For Each row As DataRow In dt.Rows
            '        If row(1) <> -1 Then
            '            '            .Series(iNewSeriesIndex).AddXY(Count, row(1), "", 10)
            '        End If
            '        Count += 1
            '    Next

            'End With
            Try

                m_SMALineFast = New Steema.TeeChart.Styles.Line(canvas)
                m_SMALineSlow = New Steema.TeeChart.Styles.Line(canvas)
                m_SMALineFast.CustomVertAxis = canvas.Axes.Custom(canvaspos)
                m_SMALineSlow.CustomVertAxis = canvas.Axes.Custom(canvaspos)


                'VIP 这里的iCount应该是0还是1？，坐标从0开始还是从1开始？
                Dim iCount As Integer = 0

                With m_SMALineFast
                    For Each row As DataRow In dt.Rows
                        If row(1) <> -1 Then
                            .Add(iCount, row(1))
                        End If
                        iCount += 1
                    Next
                End With

                iCount = 0
                With m_SMALineSlow
                    For Each row As DataRow In dt.Rows
                        If row(2) <> -1 Then
                            .Add(iCount, row(2))
                        End If
                        iCount += 1
                    Next
                End With

                m_SMALineSlow.Color = Color.Green
                m_SMALineFast.Color = Color.Red
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        'Public Sub PlotCandleChart(dt As DataTable, ByRef canvas As Styles.Candle, Optional pat As EPriceAdjustedType = DataEntity.EPriceAdjustedType.ForAdj) Implements IIndicatorPlotAxTchart.PlotCandleChart

        'End Sub

        'Public Sub PlotLineChart(dt As DataTable, ByRef canvas As Styles.Line, Optional pat As EPriceAdjustedType = DataEntity.EPriceAdjustedType.ForAdj) Implements IIndicatorPlotAxTchart.PlotLineChart

        'End Sub

        'Public Sub PlotVolumeChart(dt As DataTable, ByRef canvas As Styles.Line) Implements IIndicatorPlotAxTchart.PlotVolumeChart

        'End Sub

        Public Sub RemovePlot(ByRef canvas As Chart) Implements IIndicatorPlotAxTchart.RemovePlot

            If Not IsNothing(m_SMALineSlow) Then
                canvas.Series.Remove(m_SMALineSlow)
            End If

            If Not IsNothing(m_SMALineFast) Then
                canvas.Series.Remove(m_SMALineFast)
            End If

        End Sub

        Public Sub Hide() Implements IIndicatorPlotAxTchart.Hide
            If Not IsNothing(m_SMALineSlow) Then
                m_SMALineSlow.Visible = False
            End If

            If Not IsNothing(m_SMALineFast) Then
                m_SMALineFast.Visible = False
            End If
        End Sub

        Public Sub Show() Implements IIndicatorPlotAxTchart.Show
            If Not IsNothing(m_SMALineSlow) Then
                m_SMALineSlow.Visible = True
            End If

            If Not IsNothing(m_SMALineFast) Then
                m_SMALineFast.Visible = True
            End If
        End Sub
    End Class

    Public Class CIndicator_SMA2
        Inherits CIndicator_MA



        Private m_PeriodsAverage_Fast As Int16 = 3   '默认为3
        Private m_PeriodsAverage_Slow As Int16 = 15  '默认为15


        'Private Property PeriodsAverage_Fast As Int16
        '    Get
        '        PeriodsAverage_Fast = m_PeriodsAverage_Fast
        '    End Get
        '    Set(value As Int16)
        '        If value > Me.Rows.Count - 1 OrElse value = 1 Then
        '            MsgBox("无效均线间隔。已设置为默认值3。")
        '            m_PeriodsAverage_Fast = 3
        '        Else
        '            m_PeriodsAverage_Fast = value
        '        End If
        '    End Set
        'End Property

        'Private Property PeriodsAverage_Slow As Int16
        '    Get
        '        PeriodsAverage_Slow = m_PeriodsAverage_Slow
        '    End Get
        '    Set(value As Int16)
        '        If value > Me.Rows.Count - 1 OrElse value = 1 Then
        '            MsgBox("无效均线间隔。已设置为默认值3。")
        '            m_PeriodsAverage_Slow = 3
        '        Else
        '            m_PeriodsAverage_Slow = value
        '        End If
        '    End Set
        'End Property
        'Private m_IntervalNumberList As List(Of UInt16)

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(dt As CDTDaily)
            MyBase.New(dt)

            m_PlotAxTChart = New CIndicatorPlotAxTchart_SMA2
            m_IndicatorName = "双均线"

            Dim strColumnName As String = EMAType.SMA.ToString & m_PeriodsAverage_Fast & "_" & EPriceType.Close.ToString
            Me.Columns.Add(strColumnName, GetType(System.Double))

            strColumnName = EMAType.SMA.ToString & m_PeriodsAverage_Slow & "_" & EPriceType.Close.ToString
            Me.Columns.Add(strColumnName, GetType(System.Double))

            Init()

            Calculate()

        End Sub

        ''' <summary>
        ''' 设置参数，并重新计算
        ''' </summary>
        ''' <param name="period"></param>
        ''' <param name="pt"></param>
        ''' <remarks></remarks> 
        Public Overrides Sub SetParameters(ByVal ParamArray paArray() As Double)
            'Init()

            Dim periodslow, periodfast As UInt16
            periodfast = paArray(0)
            periodslow = paArray(1)


            '如果参数相同，不需要重新计算设置
            If periodfast = m_PeriodsAverage_Fast And periodslow = m_PeriodsAverage_Slow Then  'And m_PriceType = pt 
                Exit Sub
            End If

            '判断periodFast是否有效
            If periodfast > Me.Rows.Count - 1 OrElse periodfast = 1 Then
                MsgBox("无效均线间隔。已设置为默认值3。")
                m_PeriodsAverage_Fast = 3
            Else
                m_PeriodsAverage_Fast = periodfast
            End If


            '判断periodSlow是否有效
            If periodslow > Me.Rows.Count - 1 OrElse periodslow = 1 Then
                MsgBox("无效均线间隔。已设置为默认值15。")
                m_PeriodsAverage_Slow = 15
            Else
                m_PeriodsAverage_Slow = periodslow
            End If

            m_PeriodsAverage_Fast = periodfast

            m_PeriodsAverage_Slow = periodslow

            'm_PriceType = pt

            Calculate()
        End Sub
        ''' <summary>
        ''' 设置参数，并计算
        ''' </summary>
        ''' <param name="pt"></param>
        ''' <remarks></remarks>
        Public Overloads Sub SetParameters(periodFast As Int16, periodSlow As Int16, Optional pt As EPriceType = EPriceType.Close)

            '如果参数相同，不需要重新计算设置
            If periodFast = m_PeriodsAverage_Fast And periodSlow = m_PeriodsAverage_Slow And m_PriceType = pt Then
                Exit Sub
            End If

            '判断period是否有效
            If periodFast > Me.Rows.Count - 1 OrElse periodFast = 1 Then
                MsgBox("无效均线间隔。已设置为默认值3。")
                m_PeriodsAverage_Fast = 3
            Else
                m_PeriodsAverage_Fast = periodFast
            End If

            '判断period是否有效
            If periodSlow > Me.Rows.Count - 1 OrElse periodSlow = 1 Then
                MsgBox("无效均线间隔。已设置为默认值15。")
                m_PeriodsAverage_Slow = 15
            Else
                m_PeriodsAverage_Slow = periodSlow
            End If


            m_PeriodsAverage_Fast = periodFast
            m_PeriodsAverage_Slow = periodSlow

            m_PriceType = pt

            Calculate()
        End Sub
        '



        'Public Overrides Sub PlotAxTChart(ByRef canvas As TeeChart.TChart, Optional pat As EPriceAdjustedType = DataEntity.EPriceAdjustedType.ForAdj)
        '    m_PlotAxTChart.Plot(Me, canvas, pat)
        'End Sub

        Protected Overrides Sub Calculate()
            Dim inputPrice() As Double
            Dim outputPriceFast() As Double
            Dim outputPriceSlow() As Double
            Dim BeginIndex As Int16, OutLength As Int16

            Try
                '初始化，设置好日期 ，将DataTable设置到初始状态，如增加和m_PriceData相同数目的行、删除除TheDate以外的列
                ' Init()

                ReDim inputPrice(Me.Rows.Count - 1)
                ReDim outputPriceFast(Me.Rows.Count - 1)
                ReDim outputPriceSlow(Me.Rows.Count - 1)

                SetInputValue(inputPrice)

                Dim retCode As Core.RetCode = Core.Sma(0, inputPrice.Length - 1, inputPrice, m_PeriodsAverage_Fast, BeginIndex, OutLength, outputPriceFast)
                If retCode <> ERetCode.Success Then
                    Throw New Exception("TALib computation error")
                End If
                SetOutputValue(BeginIndex, OutLength, outputPriceFast, 1, m_PeriodsAverage_Fast)

                retCode = Core.Sma(0, inputPrice.Length - 1, inputPrice, m_PeriodsAverage_Slow, BeginIndex, OutLength, outputPriceSlow)
                SetOutputValue(BeginIndex, OutLength, outputPriceSlow, 2, m_PeriodsAverage_Slow)
                If retCode <> ERetCode.Success Then
                    Throw New Exception("TALib computation error")
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Protected Overrides Function Init(Optional Period As UShort = 3) As Integer
            MyBase.Init()

            If Me.Rows.Count > 0 Then


                Dim strColumnName As String = EMAType.SMA & m_PeriodsAverage_Fast & "_" & m_PriceType.ToString
                Me.Columns(1).ColumnName = strColumnName

                strColumnName = EMAType.SMA & m_PeriodsAverage_Slow & "_" & m_PriceType.ToString
                Me.Columns(2).ColumnName = strColumnName

            End If

            Return Me.Rows.Count
        End Function

        'Public Overrides Sub PlotAxTChart(ByRef canvas As Chart, Optional pat As EPriceAdjustedType = DataEntity.EPriceAdjustedType.ForAdj)
        '    m_PlotAxTChart.Plot(Me, canvas, pat)
        'End Sub

      
    End Class
End Namespace
