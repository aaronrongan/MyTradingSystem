Imports MyTradingSystem.DataEntity
Imports Steema.TeeChart


Namespace Indicator

    Public Enum EMAType

        SMA = 0
        EMA = 1
        WMA = 2
        DEMA = 3
        TEMA = 4
        TRIMA = 5
        KAMA = 6
        MAMA = 7
        T3 = 8

    End Enum

    Public MustInherit Class CIndicator_MA
        Inherits CIndicatorPrice

        Protected m_IndicatorName As String '= "单均线"




        '加入绘图，使用策略模式
        'Protected m_PlotAxTChart As IIndicatorPlotAxTchart

        Protected MustOverride Overrides Sub Calculate()

        Protected Overrides Function Init(Optional Period As UShort = 3) As Integer
            '增加和m_PriceData相同数目的行
            'm_PriceData.Rows.Clear()
            Try
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

        'Public Overrides Sub PlotAxTChart(ByRef canvas As TeeChart.Chart, Optional pat As EPriceAdjustedType = DataEntity.EPriceAdjustedType.ForAdj)
        '    m_PlotAxTChart.Plot(Me, canvas, pat)
        'End Sub

        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(dt As CDTDaily)
            MyBase.New(dt)

            m_PriceData = dt

        End Sub
        ''' <summary>
        ''' 给指标的输入值赋值
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub SetInputValue(ByRef inputPrice() As Double, Optional pt As EPriceType = EPriceType.Close)
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

    End Class
End Namespace

