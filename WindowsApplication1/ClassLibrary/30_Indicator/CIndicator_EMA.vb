

Imports MyTradingSystem.DataEntity
Imports Steema.TeeChart
Imports TicTacTec.TA.Library

Namespace Indicator


    Public Class CIndicatorPlotAxTchart_EMA
        Implements IIndicatorPlotAxTchart

        Private m_EMALine As Steema.TeeChart.Styles.Line

        Public Sub Plot(dt As DataTable, ByRef canvas As Chart, ByVal canvaspos As Int16, Optional pat As EPriceAdjustedType = DataEntity.EPriceAdjustedType.ForAdj) Implements IIndicatorPlotAxTchart.Plot

            Try

                m_EMALine = New Steema.TeeChart.Styles.Line(canvas)
                m_EMALine.CustomVertAxis = canvas.Axes.Custom(canvaspos) '.Left '.GetVertAxis
                m_EMALine.Visible = True


                Dim iCount As Integer = 1

                With m_EMALine
                    For Each row As DataRow In dt.Rows
                        If row(1) <> -1 Then
                            .Add(iCount, row(1))

                        End If
                        iCount += 1
                    Next

                End With


                m_EMALine.Color = Color.Red

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub


        Public Sub RemovePlot(ByRef canvas As Chart) Implements IIndicatorPlotAxTchart.RemovePlot
            If Not IsNothing(m_EMALine) Then
                canvas.Series.Remove(m_EMALine)
            End If
        End Sub




        Public Sub Hide() Implements IIndicatorPlotAxTchart.Hide
            If Not IsNothing(m_EMALine) Then
                m_EMALine.Visible = False
            End If
        End Sub

        Public Sub Show() Implements IIndicatorPlotAxTchart.Show
            If Not IsNothing(m_EMALine) Then
                m_EMALine.Visible = True
            End If
        End Sub
    End Class
    Public Class CIndicator_EMA

        Inherits CIndicator_MA

        Private m_TimePeriod As Int16 = 3
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(dt As CDTDaily)
            MyBase.New(dt)
            m_PlotAxTChart = New CIndicatorPlotAxTchart_SMA

            m_PriceData = dt


            Dim strColumnName As String = EMAType.EMA.ToString & m_TimePeriod & "_" & EPriceType.Close.ToString
            Me.Columns.Add(strColumnName, GetType(System.Double))

            Init()

            Calculate()

        End Sub

        Public Overrides Sub SetParameters(ByVal ParamArray paArray() As Double)
            'Init()

            Dim period As UInt16
            period = paArray(0)
            '如果参数相同，不需要重新计算设置
            If period = m_TimePeriod And m_PriceType = m_PriceType Then
                Exit Sub
            End If

            '判断period是否有效
            If period > Me.Rows.Count - 1 OrElse period = 1 Then
                MsgBox("无效均线间隔。已设置为默认值3。")
                m_TimePeriod = 3
            Else
                m_TimePeriod = period
            End If

            m_TimePeriod = period
            m_PriceType = m_PriceType

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
            If period = m_TimePeriod And m_PriceType = pt Then
                Exit Sub
            End If

            '判断period是否有效
            If period > Me.Rows.Count - 1 OrElse period = 1 Then
                MsgBox("无效均线间隔。已设置为默认值3。")
                m_TimePeriod = 3
            Else
                m_TimePeriod = period
            End If

            m_TimePeriod = period
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
            Dim BeginIndex As Int16, OutLength As Int16

            Try

                ReDim inputPrice(Me.Rows.Count - 1)
                ReDim outputPrice(Me.Rows.Count - 1)

                SetInputValue(inputPrice)

                Dim retCode As Core.RetCode = Core.Ema(0, inputPrice.Length - 1, inputPrice, m_TimePeriod, BeginIndex, OutLength, outputPrice)
                SetOutputValue(BeginIndex, OutLength, outputPrice, 1, m_TimePeriod)

                If retCode <> ERetCode.Success Then
                    Throw New Exception("TALib computation error")
                End If

            Catch ex As Exception

            End Try
        End Sub

        Public Overrides Sub PopWindowParameterPlot(ByRef canvas As Chart, ByVal canvaspos As Int16, Optional pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj)
            '借用SMA的指标设置窗口
            frm_IndicatorSetup_SMA.ShowDialog()

            Dim para1 As Int16 = frm_IndicatorSetup_SMA.m_PeriodsAverage

            frm_IndicatorSetup_SMA.Dispose()

            SetParameters(EPriceType.Close, para1)

            m_PlotAxTChart.Plot(Me, canvas, canvaspos, pat)
        End Sub
    End Class
End Namespace
