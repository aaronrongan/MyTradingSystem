Imports MyTradingSystem.DataEntity
Imports TicTacTec.TA.Library
Imports Steema.TeeChart

Namespace Indicator
   
   

    ''' <summary>
    ''' 在AxTchart上绘制均线
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CIndicatorPlotAxTchart_SMA
        Implements IIndicatorPlotAxTchart

        Private m_SMALine As Steema.TeeChart.Styles.Line

        Public Sub Plot(dt As DataTable, ByRef canvas As Chart, ByVal canvaspos As Int16, Optional pat As EPriceAdjustedType = DataEntity.EPriceAdjustedType.ForAdj) Implements IIndicatorPlotAxTchart.Plot
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


                m_SMALine = New Steema.TeeChart.Styles.Line(canvas)
                m_SMALine.CustomVertAxis = canvas.Axes.Custom(canvaspos) '.Left '.GetVertAxis
                m_SMALine.Visible = True

                'SMALine1.Clear()

                'Dim idc As New CIndicator_SMA(m_DataTableStockDaily)
                'idc.SetParameters(EPriceType.Close, 10)

                Dim iCount As Integer = 0

                With m_SMALine
                    For Each row As DataRow In dt.Rows
                        If row(1) <> -1 Then
                            .Add(iCount, row(1))

                        End If
                        iCount += 1
                    Next

                End With

                'SMALine1.Title = "Product10 Stock"
                m_SMALine.Color = Color.Red

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        'Public Sub PlotCandleChart(dt As DataTable, ByRef canvas As TeeChart.Styles.Candle, Optional pat As EPriceAdjustedType = DataEntity.EPriceAdjustedType.ForAdj) Implements IIndicatorPlotAxTchart.PlotCandleChart

        'End Sub

        'Public Sub PlotLineChart(dt As DataTable, ByRef canvas As TeeChart.Styles.Line, Optional pat As EPriceAdjustedType = DataEntity.EPriceAdjustedType.ForAdj) Implements IIndicatorPlotAxTchart.PlotLineChart

        'End Sub

        'Public Sub PlotVolumeChart(dt As DataTable, ByRef canvas As TeeChart.Styles.Line) Implements IIndicatorPlotAxTchart.PlotVolumeChart

        'End Sub

        Public Sub RemovePlot(ByRef canvas As Chart) Implements IIndicatorPlotAxTchart.RemovePlot
            If Not IsNothing(m_SMALine) Then
                'canvas.Series.Remove(m_SMALine)
                m_SMALine.Clear()
            End If
        End Sub



        'Public Sub PopWindowParameterPlot(dt As DataTable, ByRef canvas As Chart, canvaspos As Short, Optional pat As EPriceAdjustedType = DataEntity.EPriceAdjustedType.ForAdj) Implements IIndicatorPlotAxTchart.PopWindowParameterPlot
        '    frm_IndicatorSetup_SMA.ShowDialog()


        'End Sub

        'Public Sub PopWindowParameterPlot(dt As DataTable, ByRef canvas As Chart, canvaspos As Short, Optional pat As EPriceAdjustedType = DataEntity.EPriceAdjustedType.ForAdj) Implements IIndicatorPlotAxTchart.PopWindowParameterPlot

        'End Sub

        Public Sub Hide() Implements IIndicatorPlotAxTchart.Hide
            If Not IsNothing(m_SMALine) Then
                m_SMALine.Visible = False
            End If
        End Sub

        Public Sub Show() Implements IIndicatorPlotAxTchart.Show
            If Not IsNothing(m_SMALine) Then
                m_SMALine.Visible = True
            End If
        End Sub
    End Class
    ''' <summary>
    ''' 单根均线指标
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CIndicator_SMA
        Inherits CIndicator_MA

        ''' <summary>
        ''' 周期
        ''' </summary>
        ''' <remarks></remarks>
        Private m_PeriodsAverage As Int16 = 3   '默认为3

        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(dt As CDTDaily)
            MyBase.New(dt)
            m_PlotAxTChart = New CIndicatorPlotAxTchart_SMA

            m_PriceData = dt


            Dim strColumnName As String = EMAType.SMA.ToString & m_PeriodsAverage & "_" & EPriceType.Close.ToString
            Me.Columns.Add(strColumnName, GetType(System.Double))

            Init()

            Calculate()

        End Sub
        'Public Overrides Sub SetDefaultParameters(pt As EPriceType)
        '    Calculate()
        'End Sub

        ''' <summary>
        ''' 设置参数，并重新计算
        ''' </summary>
        ''' <param name="period"></param>
        ''' <param name="pt"></param>
        ''' <remarks></remarks> 
        Public Overrides Sub SetParameters(ByVal ParamArray paArray() As Double)
            'Init()

            Dim period As UInt16
            period = paArray(0)
            '如果参数相同，不需要重新计算设置
            If period = m_PeriodsAverage And m_PriceType = m_PriceType Then
                Exit Sub
            End If

            '判断period是否有效
            If period > Me.Rows.Count - 1 OrElse period = 1 Then
                MsgBox("无效均线间隔。已设置为默认值3。")
                m_PeriodsAverage = 3
            Else
                m_PeriodsAverage = period
            End If

            m_PeriodsAverage = period
            'm_PriceType = m_PriceType

            Calculate()
        End Sub

        ''' <summary>
        ''' 设置参数，并重新计算
        ''' </summary>
        ''' <param name="period"></param>
        ''' <param name="pt"></param>
        ''' <remarks></remarks> 
        Public Overloads Sub SetParameters(Optional period As Int16 = 3, Optional pt As EPriceType = EPriceType.Close)

            Init()
            '如果参数相同，不需要重新计算设置
            If period = m_PeriodsAverage And m_PriceType = pt Then
                Exit Sub
            End If

            '判断period是否有效
            If period > Me.Rows.Count - 1 OrElse period = 1 Then
                MsgBox("无效均线间隔。已设置为默认值3。")
                m_PeriodsAverage = 3
            Else
                m_PeriodsAverage = period
            End If

            m_PeriodsAverage = period
            m_PriceType = pt

            Calculate()
        End Sub


        ''' <summary>
        ''' 计算指标
        ''' </summary>
        ''' <param name="pt"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub Calculate()
            Dim inputPrice() As Double
            Dim outputPrice() As Double
            'Dim sl_out As New SortedList(Of Date, Double)
            Dim BeginIndex As Int16, OutLength As Int16

            Try
                '初始化，设置好日期 ，将DataTable设置到初始状态，如增加和m_PriceData相同数目的行、删除除TheDate以外的列
                'Init()

                ReDim inputPrice(Me.Rows.Count - 1)
                ReDim outputPrice(Me.Rows.Count - 1)

                SetInputValue(inputPrice)

                Dim retCode As Core.RetCode = Core.Sma(0, inputPrice.Length - 1, inputPrice, m_PeriodsAverage, BeginIndex, OutLength, outputPrice)

                SetOutputValue(BeginIndex, OutLength, outputPrice, 1, m_PeriodsAverage)

                If retCode <> ERetCode.Success Then
                    Throw New Exception("TALib computation error")
                End If

            Catch ex As Exception

            End Try
        End Sub
        '
        ''' <summary>
        ''' 计算简单平均均线值
        ''' </summary>
        ''' <param name="pt"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SetSMA(Optional pt As EPriceType = EPriceType.Close) As SortedList(Of DateTime, Double) 'Double() 'ByRef BeginIndex As Int16, ByRef OutLength As Int16,
            Dim inputPrice() As Double
            Dim out() As Double
            Dim sl_out As New SortedList(Of Date, Double)
            Dim BeginIndex As Int16, OutLength As Int16

            Try

                If Me.Columns.Count > 1 Then    '如已有参数，删除之前的栏和值
                    Me.Columns.RemoveAt(1)
                    m_ParaDictionary.Remove("PeriodsAverage")
                Else
                    '增加参数
                    'ReDim Preserve m_DataColumn(1)
                    Dim dc As DataColumn
                    Dim strColumnName As String = "SMA_" & m_PeriodsAverage & "_" & pt.ToString

                    dc = Me.Columns.Add(strColumnName, GetType(System.Double))

                    'Me.Columns.Add(dc)
                    'm_DataColumn(1).AllowDBNull = False
                    'Me.Columns.Add(m_DataColumn(1))
                    'm_ParaNameList.Add("PeriodsAverage")
                    'm_ParaValueList.Add(m_PeriodsAverage)
                    m_ParaDictionary.Add("PeriodsAverage", m_PeriodsAverage)

                End If


                If Me.Rows.Count > 0 Then
                    ReDim inputPrice(Me.Rows.Count - 1)
                    'ReDim out(Me.Rows.Count - m_PeriodsAverage)
                    ReDim out(Me.Rows.Count - 1)

                    Dim i As Integer = 0

                    For Each row As DataRow In Me.Rows
                        'If m_PriceData.TableName <> "StockPriceDaily" Then
                        '    If pt = EPriceType.Open Then
                        '        inputPrice(i) = m_PriceData.Rows(i).Item("OpenPrice")
                        '    ElseIf pt = EPriceType.High Then
                        '        inputPrice(i) = m_PriceData.Rows(i).Item("HighPrice")
                        '    ElseIf pt = EPriceType.Low Then
                        '        inputPrice(i) = m_PriceData.Rows(i).Item("LowPrice")
                        '    ElseIf pt = EPriceType.Close Then
                        '        inputPrice(i) = m_PriceData.Rows(i).Item("ClosePrice")
                        '    End If
                        'Else
                        '    If pt = EPriceType.Open Then
                        '        inputPrice(i) = m_PriceData.Rows(i).Item("OpenPrice_FA")
                        '    ElseIf pt = EPriceType.High Then
                        '        inputPrice(i) = m_PriceData.Rows(i).Item("HighPrice_FA")
                        '    ElseIf pt = EPriceType.Low Then
                        '        inputPrice(i) = m_PriceData.Rows(i).Item("LowPrice_FA")
                        '    ElseIf pt = EPriceType.Close Then
                        '        inputPrice(i) = m_PriceData.Rows(i).Item("ClosePrice_FA")
                        '    End If
                        'End If

                        If pt = EPriceType.Open Then
                            inputPrice(i) = m_PriceData.GetOpenPrice(i)
                        ElseIf pt = EPriceType.High Then
                            inputPrice(i) = m_PriceData.GetHighPrice(i)
                        ElseIf pt = EPriceType.Low Then
                            inputPrice(i) = m_PriceData.GetLowPrice(i)
                        ElseIf pt = EPriceType.Close Then
                            inputPrice(i) = m_PriceData.GetClosePrice(i)
                        End If


                        i += 1
                    Next

                    Dim retCode As Core.RetCode = SMA(0, inputPrice.Length - 1, inputPrice, m_PeriodsAverage, BeginIndex, OutLength, out)

                    ' Dim retCode As Core.RetCode = Core.Sma(0, inputPrice.Length - 1, inputPrice, m_PeriodsAverage, BeginIndex, OutLength, out)

                    i = 0

                    For Each row As DataRow In Me.Rows
                        If i >= BeginIndex Then
                            ' sl_out.Add(row.Item("TheDate"), out(i - m_PeriodsAverage + 1))
                            Me.Rows(i).Item(1) = out(i - m_PeriodsAverage + 1)
                        Else
                            ' sl_out.Add(row.Item("TheDate"), -1)
                            Me.Rows(i).Item(1) = -1
                        End If
                        i += 1
                    Next


                    If retCode <> ERetCode.Success Then
                        Throw New Exception("TALib computation error")
                    End If
                    Return sl_out
                Else
                    Return Nothing
                End If

            Catch ex As Exception
                Return Nothing
            End Try

        End Function


        ''' <summary>
        ''' 计算Simple Moving Average值
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function SMA(startIndex As Int16, endIndex As Int16, inValue() As Double, inPeriodsAverage As Int16, outBeginIndex As Int16, outLength As Int16, ByRef outValue() As Double) As Core.RetCode

            Return Core.Sma(startIndex, endIndex, inValue, inPeriodsAverage, outBeginIndex, outLength, outValue)

        End Function
        ''' <summary>
        ''' 得到某天的均线数据，以数组形式呈现，指定EPriceType、间隔长度
        ''' </summary>
        ''' <param name="thedate"></param>
        ''' <param name="EPriceType"></param>
        ''' <param name="Len"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAverageArray(Optional pt As EPriceType = EPriceType.Close) As Single()
            Dim array() As Single

            ReDim array(Me.Rows.Count - 1)

            Dim i As Integer = 0
            For Each row As DataRow In Me.Rows
                If pt = EPriceType.Open Then
                    array(i) = row.Item(1)
                ElseIf pt = EPriceType.High Then
                    array(i) = row.Item(2)
                ElseIf pt = EPriceType.Low Then
                    array(i) = row.Item(3)
                ElseIf pt = EPriceType.Close Then
                    array(i) = row.Item(4)
                End If
                i += 1
            Next


        End Function

        ''' <summary>
        ''' 得到某天的均线数据，，以SortedList形式呈现，指定EPriceType、间隔长度，按SortedList排列
        ''' </summary>
        ''' <param name="thedate"></param>
        ''' <param name="EPriceType"></param>
        ''' <param name="Len"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAverageSortedList(Optional pt As EPriceType = EPriceType.Close) As SortedList(Of Date, Single)


            Dim sl As New SortedList(Of Date, Single)

            Dim i As Integer = 0
            For Each row As DataRow In Me.Rows
                If pt = EPriceType.Open Then
                    sl.Add(CDate(row.Item(0)), row.Item(1))
                ElseIf pt = EPriceType.High Then
                    sl.Add(CDate(row.Item(0)), row.Item(2))
                ElseIf pt = EPriceType.Low Then
                    sl.Add(CDate(row.Item(0)), row.Item(3))
                ElseIf pt = EPriceType.Close Then
                    sl.Add(CDate(row.Item(0)), row.Item(4))
                End If
                i += 1
            Next
            Return sl

        End Function


        ' ''' <summary>
        ' ''' 参数重新调整后进行初始化列
        ' ''' </summary>
        ' ''' <remarks></remarks>
        'Public Overrides Sub Init()

        '    Dim strColumnName As String


        '    '删除处日期以外现有列数据
        '    For Each col As DataColumn In Me.Columns
        '        Dim strName As String = col.ColumnName

        '        If strName <> "TheDate" Then
        '            Me.Columns.Remove(strName)
        '        End If
        '    Next

        '    ReDim Preserve m_DataColumn(m_ParaValueList.Count)

        '    '增加需要的参数列
        '    Dim i As Integer = 1
        '    For Each mt As UInteger In m_ParaValueList
        '        For j = 1 To 4
        '            If i Mod 4 = 1 Then
        '                strColumnName = String.Format("{0}{1}均线_Open", mt, m_IntervalType)
        '            ElseIf i Mod 4 = 2 Then
        '                strColumnName = String.Format("{0}{1}均线_High", mt, m_IntervalType)
        '            ElseIf i Mod 4 = 3 Then
        '                strColumnName = String.Format("{0}{1}均线_Low", mt, m_IntervalType)
        '            ElseIf i Mod 4 = 0 Then
        '                strColumnName = String.Format("{0}{1}均线_Close", mt, m_IntervalType)
        '            End If
        '            j += 1
        '            i += 1
        '            m_ParaNameList.Add(strColumnName)
        '            m_DataColumn(i).ColumnName = strColumnName
        '            m_DataColumn(i).DataType = GetType(System.Single)
        '            Me.Columns.Add(m_DataColumn(i))
        '        Next
        '        'i += 4
        '    Next
        'End Sub

        ''' <summary>
        ''' 参数重新调整后进行初始化列
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Function Init(Optional Period As UInt16 = 3) As Integer

            'Dim strColumnName As String


            '删除处日期以外现有列数据
            'For Each col As DataColumn In Me.Columns
            '    Dim strName As String = col.ColumnName

            '    If strName <> "TheDate" Then
            '        Me.Columns.Remove(strName)
            '    End If
            'Next

            'ReDim Preserve m_DataColumn(4) ' m_ParaValueList.Count * 4)

            '增加需要的参数列
            'Dim i As Integer = 1
            'For Each mt As UInteger In m_ParaValueList
            'For i = 1 To 4
            '    If i Mod 4 = 1 Then
            '        strColumnName = String.Format("{0}{1}均线_Open", m_IntervalNumber, m_IntervalType)
            '    ElseIf i Mod 4 = 2 Then
            '        strColumnName = String.Format("{0}{1}均线_High", m_IntervalNumber, m_IntervalType)
            '    ElseIf i Mod 4 = 3 Then
            '        strColumnName = String.Format("{0}{1}均线_Low", m_IntervalNumber, m_IntervalType)
            '    ElseIf i Mod 4 = 0 Then
            '        strColumnName = String.Format("{0}{1}均线_Close", m_IntervalNumber, m_IntervalType)
            '    End If
            '    'j += 1
            '    m_ParaNameList.Add(strColumnName)
            '    m_DataColumn(i) = New DataColumn
            '    m_DataColumn(i).ColumnName = strColumnName
            '    m_DataColumn(i).DataType = GetType(System.Single)
            '    Me.Columns.Add(m_DataColumn(i))
            'Next

            ''增加和m_PriceData相同数目的行
            'If Me.Rows.Count = 0 Then
            '    For Each row As DataRow In m_PriceData.Rows
            '        Dim rowMe As DataRow = Me.NewRow()
            '        rowMe.Item("TheDate") = row.Item("TheDate")
            '        Me.Rows.Add(rowMe)
            '    Next
            '    'm_ParaDictionary.Clear()  '参数字典清空
            'End If

            '增加第一列日期列
            MyBase.Init()

            If Me.Rows.Count > 0 Then
                '如已有参数，删除之前的栏和值
                'If Me.Columns.Count > 1 Then
                'Me.Columns.RemoveAt(1)
                ' m_ParaDictionary.Remove("PeriodsAverage")
                'Else

                Dim strColumnName As String = EMAType.SMA & m_PeriodsAverage & "_" & m_PriceType.ToString
                Me.Columns(1).ColumnName = strColumnName

                'Me.Columns.Add(strColumnName, GetType(System.Double))
                'm_ParaDictionary.Add("PeriodsAverage", m_PeriodsAverage)

                'End If
            End If

            Return Me.Rows.Count

        End Function

        'Protected Sub Calculate()

        '    'Dim j As Integer = 0
        '    ''For Each mt As UInteger In m_ParaValueList

        '    'Dim i As Integer = 1, iRow As Integer
        '    '' For Each col As DataColumn In Me.Columns
        '    'For Each row As DataRow In Me.Rows
        '    '    row.Item(m_ParaNameList(0)) = MovingAverage(m_OpenPrice, m_IntervalNumber, iRow)
        '    '    row.Item(m_ParaNameList(1)) = MovingAverage(m_HighPrice, m_IntervalNumber, iRow)
        '    '    row.Item(m_ParaNameList(2)) = MovingAverage(m_LowPrice, m_IntervalNumber, iRow)
        '    '    row.Item(m_ParaNameList(3)) = MovingAverage(m_ClosePrice, m_IntervalNumber, iRow)
        '    '    iRow += 1
        '    'Next

        '    ''Next


        'End Sub

        ''' <summary>
        '''   '技术分析指标类
        '''各个技术指标的计算
        '''输入：原始价格
        '''输出：需要的指标数据，如EMA
        '''算法: 移动均线算法，
        '''输入: 价格数组，需要计算的长度
        '''输出：
        ''' </summary>
        ''' <param name="Price"></param>
        ''' <param name="Length"></param>
        ''' <param name="iCurrentPos"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function MovingAverage(Price() As Single, Length As Integer, iCurrentPos As Integer)

            Dim i As Integer
            Dim fTotal As Single

            i = iCurrentPos - Length + 1
            If i >= 0 Then

                For i = iCurrentPos - Length + 1 To iCurrentPos

                    fTotal = fTotal + Price(i)

                Next

                MovingAverage = fTotal / Length
            Else
                MovingAverage = -1      '无效数据
            End If


        End Function

        Public Overrides Sub PopWindowParameterPlot(ByRef canvas As Chart, ByVal canvaspos As Int16, Optional pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj)
            frm_IndicatorSetup_SMA.ShowDialog()

            Dim para1 As Int16 = frm_IndicatorSetup_SMA.m_PeriodsAverage

            frm_IndicatorSetup_SMA.Dispose()

            SetParameters(EPriceType.Close, para1)

            m_PlotAxTChart.Plot(Me, canvas, canvaspos, pat)
        End Sub

        ' ''' <summary>
        ' ''' 通过策略模式实现接口中定义的PlotAxTChart
        ' ''' </summary>
        ' ''' <param name="canvas"></param>
        ' ''' <param name="pat"></param>
        ' ''' <remarks></remarks>
        'Public Overloads Overrides Sub PlotAxTChart(ByRef canvas As TeeChart.TChart, Optional pat As EPriceAdjustedType = DataEntity.EPriceAdjustedType.ForAdj)
        '    m_PlotAxTChart.Plot(Me, canvas, pat)
        'End Sub
    End Class
End Namespace
