Imports MyTradingSystem.DataEntity

Namespace Indicator


    Public Class CDataSetIndicators
        Inherits DataSet

        Protected m_Symbol As String
        Protected m_BeginDateTime As String
        Protected m_EndDateTime As String

        Private m_IndicatorList As List(Of CIndicator)
        'Private m_PriceDataTable As CDTDaily     '原始价格数据

        Private m_IntervalType As String = "日"               '间隔类型，如分钟i、小时h、天d、周w、月m、年y，默认为天
        Private m_IntervalNumber As UInt16 = 1                  '间隔长度，默认为1

        ''' <summary>
        ''' 原始价格信息加入初始表
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <remarks></remarks>
        Public Sub New(dt As CDTDaily)
            Me.Tables.Add(dt)
        End Sub

        ''' <summary>
        ''' 增加Indicator
        ''' </summary>
        ''' <param name="idc"></param>
        ''' <remarks></remarks>
        Public Sub AddIndicator(ByRef idc As CIndicator)
            idc.IntervalNumbers = m_IntervalNumber
            idc.IntervalNumbers = m_IntervalType
            m_IndicatorList.Add(idc)
        End Sub

        ''' <summary>
        ''' 删除Indicator
        ''' </summary>
        ''' <param name="idc"></param>
        ''' <remarks></remarks>
        Public Sub RemoveIndicator(ByRef idc As CIndicator)
            'idc.IntervalNumbers = m_IntervalNumber
            'idc.IntervalNumbers = m_IntervalType
            m_IndicatorList.Remove(idc)
        End Sub

        ''' <summary>
        ''' 重新计算所有Indicators数据
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CalculateAll()
            For Each idc In m_IndicatorList

                'idc.Calculate()
            Next
        End Sub

    End Class

End Namespace
