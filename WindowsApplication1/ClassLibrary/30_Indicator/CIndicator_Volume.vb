
Imports Steema.TeeChart
Namespace Indicator



    ''' <summary>
    ''' 交易量指标
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CIndicator_Volume
        Inherits CIndicatorPrice


        Protected Overrides Sub Calculate()

        End Sub

        Protected Overrides Function Init(Optional Period As UShort = 3) As Integer

        End Function

        Public Overrides Sub PlotAxTChart(ByRef canvas As Chart, ByVal canvaspos As Int16, Optional pat As DataEntity.EPriceAdjustedType = DataEntity.EPriceAdjustedType.ForAdj)

        End Sub
    End Class

End Namespace
