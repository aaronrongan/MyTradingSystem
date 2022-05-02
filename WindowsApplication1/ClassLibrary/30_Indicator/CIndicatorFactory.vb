Namespace Indicator


    Public Enum EIndicatorName
        SMA = 0     '�����ƶ�����
        SMA2 = 1    '˫���ƶ�����
        SMA3 = 2    '�����ƶ�����
        EMA = 3     'EMA
        MACD = 4    'MACD
        ''' <summary>
        ''' '���ִ�
        ''' </summary>
        ''' <remarks></remarks>
        ''' 
        BBand = 5   '���ִ�
        KDJ = 6
        RSI = 7
        WR = 8      'W&R
        DMI = 9
    End Enum
    ''' <summary>
    ''' ָ�깤���࣬����Ϊ�򵥹�����
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CIndicatorFactory

        Public Sub New()

        End Sub
        'Public MustOverride Function CreateIndicator(idc As EIndicatorName, dt As DataTable) As CIndicator

        'End Function
        Public Shared Function CreateIndicator(idc As EIndicatorName) As CIndicator

            Select Case idc
                Case EIndicatorName.SMA
                    Return New CIndicator_SMA()
                Case EIndicatorName.SMA2
                    Return New CIndicator_SMA2()
                Case EIndicatorName.SMA3
                    Return New CIndicator_SMA3()
                Case EIndicatorName.BBand
                    Return New CIndicator_BBand()
                Case Else
                    Return Nothing
            End Select

        End Function
        Public Shared Function CreateIndicator(idc As EIndicatorName, dt As DataTable) As CIndicator

            Select Case idc
                Case EIndicatorName.SMA
                    Return New CIndicator_SMA(dt)
                Case EIndicatorName.SMA2
                    Return New CIndicator_SMA2(dt)
                Case EIndicatorName.SMA3
                    Return New CIndicator_SMA3(dt)
                Case EIndicatorName.EMA
                    Return New CIndicator_EMA(dt)
                Case EIndicatorName.MACD
                    Return New CIndicator_MACD(dt)
                Case EIndicatorName.BBand
                    Return New CIndicator_BBand(dt)
                Case Else
                    Return Nothing
            End Select

        End Function

    End Class

   

End Namespace
