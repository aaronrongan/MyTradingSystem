''' <summary>
Imports MyTradingSystem.DataEntity
Imports Steema
Imports TeeChart.ESeriesClass
Imports TeeChart.EFunctionType
Imports TeeChart.EFunctionPeriodStyle
Imports TeeChart.EFunctionPeriodAlign
Imports MyTradingSystem.Indicator

''' TeeChart封装类
''' </summary>
''' <remarks></remarks>
Public Class CTeeChartManaged

    ''' <summary>
    ''' 指标的集合
    ''' </summary>
    ''' <remarks></remarks>
    Private m_IndicatorSet As CIndicatorSets
    Private m_IndicatorPlotSet As CIndicatorPlotSets

    Public Property CIndicatorSets As MyTradingSystem.Indicator.CIndicatorSets
        Get

        End Get
        Set(value As MyTradingSystem.Indicator.CIndicatorSets)

        End Set
    End Property

    Public Sub InitCandleGraph(chart As TeeChart.TChart)
        chart.Update()
        chart.Legend.Visible = False
        chart.Aspect.View3D = False
        chart.Axes.Bottom.Labels.Angle = 90
    End Sub

    ''' <summary>
    ''' 在TxChart上删除所有的Indicators
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub ClearIndicators(ByRef chart As TeeChart.TChart)



    End Sub

    ''' <summary>
    ''' 在TxChart上删除某个指定的的Indicator
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub ClearIndicator(ByRef chart As TeeChart.TChart, ByVal IndicatorName As String)



    End Sub
    ''' <summary>
    ''' 在TxChart上绘制所有的Indicators
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub PlotIndicators(ByRef chart As TeeChart.TChart)

        'For Each idc As IIndicatorPlot In m_IndicatorPlotSet.Values.ToList
        '    idc.Plot(chart)
        'Next

    End Sub
    ''' <summary>
    ''' 将DataTable中的数据填充到Teechart
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AddCandlePricefromDataTable(ByRef chart As TeeChart.TChart, ByVal dt As CDTDaily, Optional ByVal pat As PriceAdjustedType = PriceAdjustedType.Normal)
        Try

            'Dim serial As TeeChart.ICandleSeries
            chart.AddSeries(TeeChart.ESeriesClass.scCandle)
            Dim Count As Integer = 1
            If Not IsNothing(dt) Then
                With chart
                    .Series(0).asCandle.DownCloseColor = &HFF00
                    .Series(0).asCandle.UpCloseColor = &HFF
                    '.ColorStyle = TeeChart.ECandleColorStyle.cssRelativeToOpen
                    .Series(0).asCandle.CandleWidth = 10
                    .Axis.Left.Labels.Visible = False
                    .Axis.Right.Labels.Add(1, "10")
                    .Axis.Right.Labels.Add(2, "20")
                    .Axis.Right.Labels.Visible = True
                    For Each row As DataRow In dt.Rows
                        Dim openprice, highprice, lowprice, closeprice As Single

                        If pat = PriceAdjustedType.Normal Then
                            '.Series(0).asCandle.AddCandle(Count, row.Item("OpenPrice"), row.Item("HighPrice"), row.Item("LowPrice"), row.Item("ClosePrice"))
                            openprice = row.Item("OpenPrice")
                            highprice = row.Item("HighPrice")
                            lowprice = row.Item("LowPrice")
                            closeprice = row.Item("ClosePrice")

                        ElseIf pat = PriceAdjustedType.ForAdj Then
                            '.asCandle.AddCandle(CDate(row.Item("TheDate")).ToOADate, row.Item("OpenPrice_FA"), row.Item("HighPrice_FA"), row.Item("LowPrice_FA"), row.Item("ClosePrice_FA"))

                            '.Series(0).asCandle.AddCandle(Count, row.Item("OpenPrice_FA"), row.Item("HighPrice_FA"), row.Item("LowPrice_FA"), row.Item("ClosePrice_FA"))

                            If IsDBNull(row.Item("OpenPrice_FA")) Then
                                openprice = row.Item("ActPreClosePrice")  '("OpenPrice")
                                highprice = openprice 'row.Item("HighPrice")
                                lowprice = openprice 'row.Item("LowPrice")
                                closeprice = openprice 'row.Item("OpenPrice") 'row.Item("ClosePrice")
                            ElseIf row.Item("OpenPrice_FA") = 0 Then
                                openprice = row.Item("ActPreClosePrice")  '("OpenPrice")
                                highprice = openprice 'row.Item("HighPrice")
                                lowprice = openprice 'row.Item("LowPrice")
                                closeprice = openprice '
                            Else
                                openprice = row.Item("OpenPrice_FA")
                                highprice = row.Item("HighPrice_FA")
                                lowprice = row.Item("LowPrice_FA")
                                closeprice = row.Item("ClosePrice_FA")
                            End If


                        ElseIf pat = PriceAdjustedType.BacAdj Then
                            '.Series(0).asCandle.AddCandle(Count, row.Item("OpenPrice_BA"), row.Item("HighPrice_BA"), row.Item("LowPrice_BA"), row.Item("ClosePrice_BA"))

                            If IsDBNull(row.Item("OpenPrice_BA")) Then
                                openprice = openprice
                                highprice = openprice
                                lowprice = openprice
                                closeprice = openprice
                            ElseIf row.Item("OpenPrice_BA") = 0 Then
                                openprice = row.Item("ActPreClosePrice")  '("OpenPrice")
                                highprice = openprice 'row.Item("HighPrice")
                                lowprice = openprice 'row.Item("LowPrice")
                                closeprice = openprice '
                            Else
                                openprice = row.Item("OpenPrice_BA")
                                highprice = row.Item("HighPrice_BA")
                                lowprice = row.Item("LowPrice_BA")
                                closeprice = row.Item("ClosePrice_BA")
                            End If

                        End If

                        .Series(0).asCandle.AddCandle(Count, openprice, highprice, lowprice, closeprice)

                        .Axis.Bottom.Labels.Add(Count, row.Item("TheDate"))
                        Count += 1
                    Next

                End With
            End If

            '加入Bolling()
            'Dim iIndex As Int16 = chart.AddSeries(scFastLine)
            'chart.Series(iIndex).SetFunction(TeeChart.EFunctionType.tfBollinger)
            'chart.Series(iIndex).DataSource = chart.Series(0)
            'chart.Series(iIndex).FunctionType.asBollinger.LowBand.Color = &HEE 'vbCyan
            'chart.Series(iIndex).Color = &HEE ' vbCyan
            'chart.Series(iIndex).FunctionType.asBollinger.Deviation = 3
            'chart.Series(iIndex).FunctionType.asBollinger.Exponential = False
            'chart.Series(iIndex).FunctionType.PeriodAlign = paLast
            'chart.Series(iIndex).FunctionType.PeriodStyle = psNumPoints
            'chart.Series(iIndex).FunctionType.Period = 2
            'chart.Series(iIndex).CheckDataSource()

            ''加入移动均线
            'chart.AddSeries(scFastLine)
            'chart.Series(2).SetFunction(tfMovavg)
            'chart.Series(2).DataSource = chart.Series(0)
            'chart.Series(2).FunctionType.asMovAvg.Weighted = True 'vbCyan
            'chart.Series(2).Color = &HEE ' vbCyan
            ''chart.Series(2).FunctionType.asMovAvg
            'chart.Series(2).CheckDataSource()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 将DataTable中的数据填充到Teechart
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AddCandleVolumefromDataTable(ByRef chart As TeeChart.TChart, ByVal dt As CDTDaily, Optional ByVal pat As PriceAdjustedType = PriceAdjustedType.Normal)
        Try

            'Dim serial As TeeChart.ICandleSeries
            chart.AddSeries(TeeChart.ESeriesClass.scBar)
            chart.Series(0).asBar.AutoBarSize = True
            chart.Series(0).asBar.BarPen.Color = &HFF
            chart.Series(0).Marks.Visible = False
            'chart.Axis.Left.Labels.Visible = False
            chart.Series(0).asBar.BarBrush.Color = &HFE   '红色
            'chart.Series(0).asBar.BarBrush.BackColor = &HFF   '红色
            Dim min As Double = 1.0E+20
            Dim max As Double = 0
            Dim value As Double = 0

            If Not IsNothing(dt) Then
                With chart.Series(0)
                    '.asBar.BarWidthPercent = 20 ' (1 / dt.Rows.Count) * 100
                    '.asBar.AutoBarSize = True
                    '.asBar.BarPen.Color = &HFF      '红色

                    For Each row As DataRow In dt.Rows
                        Try

                            If pat = PriceAdjustedType.Normal Then
                                If Not IsDBNull(row.Item("TurnoverVolume")) Then
                                    value = row.Item("TurnoverVolume")
                                End If
                            ElseIf pat = PriceAdjustedType.ForAdj Then
                                If Not IsDBNull(row.Item("TurnoverVolume_FA")) Then
                                    value = row.Item("TurnoverVolume_FA")
                                End If
                            ElseIf pat = PriceAdjustedType.BacAdj Then
                                If Not IsDBNull(row.Item("TurnoverVolume_BA")) Then
                                    value = row.Item("TurnoverVolume_BA")
                                End If
                            End If
                            .Add(value, row.Item("TheDate"), 0)
                            If min > value Then
                                min = value
                            End If
                            If max < value Then
                                max = value
                            End If
                        Catch ex As Exception

                        End Try
                    Next

                    chart.Axis.Left.SetMinMax(min - (max - min) * 0.2, max + (max - min) * 0.2)
                End With
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 将均线添加到Teechart
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AddIndicator(ByRef chart As TeeChart.TChart, ByVal idc As CIndicator)
        Try

            'Dim serial As TeeChart.ICandleSeries
            chart.AddSeries(TeeChart.ESeriesClass.scLine)
            Dim iCount As Integer = 1
            If Not IsNothing(idc) Then
                With chart
                    '.Series(1).asCandle.DownCloseColor = &HFF00
                    '.Series(1).asCandle.UpCloseColor = &HFF
                    '.ColorStyle = TeeChart.ECandleColorStyle.cssRelativeToOpen
                    '.Series(1).asCandle.CandleWidth = 10
                    For Each row As DataRow In idc.Rows

                        If row.Item(1) <> -1 Then
                            .Series(1).AddXY(iCount, row.Item(1), "", iCount)
                        End If


                        'Dim openprice, highprice, lowprice, closeprice As Single


                        '.Series(0).asCandle.AddCandle(Count, row.Item("OpenPrice"), row.Item("HighPrice"), row.Item("LowPrice"), row.Item("ClosePrice"))
                        'openprice = row.Item("OpenPrice")
                        'highprice = row.Item("HighPrice")
                        'lowprice = row.Item("LowPrice")
                        'closeprice = row.Item("ClosePrice")

                        '.Series(0).asCandle.AddCandle(Count, openprice, highprice, lowprice, closeprice)

                        '.Axis.Bottom.Labels.Add(Count, row.Item("TheDate"))
                        iCount += 1
                    Next

                End With
            End If

            ''加入Bolling()
            'chart.AddSeries(scFastLine)
            'chart.Series(1).SetFunction(TeeChart.EFunctionType.tfBollinger)
            'chart.Series(1).DataSource = chart.Series(0)
            'chart.Series(1).FunctionType.asBollinger.LowBand.Color = &HEE 'vbCyan
            'chart.Series(1).Color = &HEE ' vbCyan
            'chart.Series(1).FunctionType.asBollinger.Deviation = 3
            'chart.Series(1).FunctionType.asBollinger.Exponential = False
            'chart.Series(1).FunctionType.PeriodAlign = paLast
            'chart.Series(1).FunctionType.PeriodStyle = psNumPoints
            'chart.Series(1).FunctionType.Period = 2
            'chart.Series(1).CheckDataSource()

            ''加入移动均线
            'chart.AddSeries(scFastLine)
            'chart.Series(2).SetFunction(tfMovavg)
            'chart.Series(2).DataSource = chart.Series(0)
            'chart.Series(2).FunctionType.asMovAvg.Weighted = True 'vbCyan
            'chart.Series(2).Color = &HEE ' vbCyan
            ''chart.Series(2).FunctionType.asMovAvg
            'chart.Series(2).CheckDataSource()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 将均线添加到Teechart
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RemoveIndicator(ByRef chart As TeeChart.TChart, ByVal idc As CIndicator)
        Try

            'Dim serial As TeeChart.ICandleSeries
            chart.AddSeries(TeeChart.ESeriesClass.scLine)
            Dim iCount As Integer = 1
            If Not IsNothing(idc) Then
                With chart
                    '.Series(1).asCandle.DownCloseColor = &HFF00
                    '.Series(1).asCandle.UpCloseColor = &HFF
                    '.ColorStyle = TeeChart.ECandleColorStyle.cssRelativeToOpen
                    '.Series(1).asCandle.CandleWidth = 10
                    For Each row As DataRow In idc.Rows

                        If row.Item(1) <> -1 Then
                            .Series(1).AddXY(iCount, row.Item(1), "", iCount)
                        End If


                        'Dim openprice, highprice, lowprice, closeprice As Single


                        '.Series(0).asCandle.AddCandle(Count, row.Item("OpenPrice"), row.Item("HighPrice"), row.Item("LowPrice"), row.Item("ClosePrice"))
                        'openprice = row.Item("OpenPrice")
                        'highprice = row.Item("HighPrice")
                        'lowprice = row.Item("LowPrice")
                        'closeprice = row.Item("ClosePrice")

                        '.Series(0).asCandle.AddCandle(Count, openprice, highprice, lowprice, closeprice)

                        '.Axis.Bottom.Labels.Add(Count, row.Item("TheDate"))
                        iCount += 1
                    Next

                End With
            End If

            ''加入Bolling()
            'chart.AddSeries(scFastLine)
            'chart.Series(1).SetFunction(TeeChart.EFunctionType.tfBollinger)
            'chart.Series(1).DataSource = chart.Series(0)
            'chart.Series(1).FunctionType.asBollinger.LowBand.Color = &HEE 'vbCyan
            'chart.Series(1).Color = &HEE ' vbCyan
            'chart.Series(1).FunctionType.asBollinger.Deviation = 3
            'chart.Series(1).FunctionType.asBollinger.Exponential = False
            'chart.Series(1).FunctionType.PeriodAlign = paLast
            'chart.Series(1).FunctionType.PeriodStyle = psNumPoints
            'chart.Series(1).FunctionType.Period = 2
            'chart.Series(1).CheckDataSource()

            ''加入移动均线
            'chart.AddSeries(scFastLine)
            'chart.Series(2).SetFunction(tfMovavg)
            'chart.Series(2).DataSource = chart.Series(0)
            'chart.Series(2).FunctionType.asMovAvg.Weighted = True 'vbCyan
            'chart.Series(2).Color = &HEE ' vbCyan
            ''chart.Series(2).FunctionType.asMovAvg
            'chart.Series(2).CheckDataSource()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
