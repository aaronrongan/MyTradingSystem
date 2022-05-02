
Namespace Strategy
    Public Enum EStrategyName
        SMACrossover = 0
        SMA2Crossover = 1
        SMA3Crossover = 2
        MACDCrossover = 3
        TrendlineAutomatic = 4
        TrendFollower = 5
        Spread = 6
        PivotPoints = 7
        ChannelBreakout = 8
        VolatilityExpansion = 9
    End Enum
    ''' <summary>
    ''' 策略工厂类，这里为简单工厂类
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CStrategyFactory
        Public Sub New()

        End Sub
        'Public MustOverride Function CreateIndicator(idc As EIndicatorName, dt As DataTable) As CIndicator

        'End Function
        Public Shared Function CreateStrategy(ts As EStrategyName) As CStrategy

            Select Case ts
                Case EStrategyName.SMA2Crossover
                    Return New CStrategy_SMA2Crossover()
                Case EStrategyName.MACDCrossover
                    Return New CStrategy_MACDCrossover()
                    ' Case EStrategyName.
                    '    Return New CIndicator_SMA3()
                Case Else
                    Return Nothing
            End Select

        End Function
        Public Shared Function CreateStrategy(ts As EStrategyName, dt As DataTable) As CStrategy


            Select Case ts
                Case EStrategyName.SMA2Crossover
                    Return New CStrategy_SMA2Crossover(dt)
                Case EStrategyName.MACDCrossover
                    'Return New CStrategy_MACDCrossover(dt)
                    ' Case EStrategyName.
                    '    Return New CIndicator_SMA3()
                Case Else
                    Return Nothing

            End Select

        End Function
    End Class
End Namespace
