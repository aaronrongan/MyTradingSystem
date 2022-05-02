''' <summary>
''' 封装DataView的状态类，用设计模式实现查询不同状态的封装 
''' </summary>
''' <remarks></remarks>
Public MustInherit Class CDataView_State

    Protected m_form As frmDataView_HistoryData

    Public Sub New()

    End Sub
    Public Sub New(frm As Windows.Forms.Form)
        m_form = frm
    End Sub
    Public Sub Start()

    End Sub
    '
    Public Sub ExitState()

    End Sub

    Public Sub NextState(stateevent As Int16)

    End Sub

    Public Overridable Sub Enter()

    End Sub

End Class

Public Class CDataView_State_Initial
    Inherits CDataView_State

    Public Sub New(frm As Windows.Forms.Form)
        m_form = frm
    End Sub
    Public Overrides Sub Enter()
        m_form.FeedData()

        If m_form.GetDataCounts > 0 Then
            m_form.FillCandleChart()
            m_form.FillVolumeChart()
            m_form.FillMovingAverage()
            m_form.FillCustomIndicatorChart()
            m_form.FillSymbolListBox()
        End If
        

    End Sub

End Class

Public Class CDataView_State_Unchanged
    Inherits CDataView_State

    Public Sub New(frm As Windows.Forms.Form)
        m_form = frm
    End Sub
    Public Overridable Sub Enter()
        'm_form.CalculateData()
        'm_form.FillCandleChart()
        'm_form.FillVolumeChart()
        'm_form.FillMovingAverage()

        'Do nothing
    End Sub

End Class

Public Class CDataView_State_SymbolDateChanged
    Inherits CDataView_State

    Public Sub New(frm As Windows.Forms.Form)
        m_form = frm
    End Sub
    Public Overrides Sub Enter()
        'm_form.FeedData()
        If m_form.GetDataCounts > 0 Then
            m_form.FillCandleChart()
            m_form.FillVolumeChart()
            m_form.FillMovingAverage()
            m_form.FillCustomIndicatorChart()
            'm_form.FillStrategySignal()
            m_form.FillSymbolListBox()
        End If
       
    End Sub


End Class

''' <summary>
''' 证券的类型发生变化：股票、指数、基金
''' </summary>
''' <remarks></remarks>
Public Class CDataView_State_SymbolTypeChanged
    Inherits CDataView_State

    Public Sub New(frm As Windows.Forms.Form)
        m_form = frm
    End Sub
    Public Overrides Sub Enter()
        'm_form.FeedData()
        If m_form.GetDataCounts > 0 Then
            m_form.FillCandleChart()
            m_form.FillVolumeChart()
            m_form.FillMovingAverage()
            m_form.FillCustomIndicatorChart()
            'm_form.FillStrategySignal()
            m_form.FillSymbolListBox()
        End If

    End Sub


End Class

Public Class CDataView_State_MA_PARAChanged
    Inherits CDataView_State

    Public Sub New(frm As Windows.Forms.Form)
        m_form = frm
    End Sub
    Public Overrides Sub Enter()
        'm_form.FillCandleChart()
        'm_form.FillVolumeChart()
        m_form.FillMovingAverage()
        'm_form.FillCustomIndicatorChart()
    End Sub

End Class

Public Class CDataView_State_CUSTIDC_NAME_Chnaged
    Inherits CDataView_State

    Public Sub New(frm As Windows.Forms.Form)
        m_form = frm
    End Sub
    Public Overrides Sub Enter()
        'm_form.FillCandleChart()
        'm_form.FillVolumeChart()
        'm_form.FillMovingAverage()
        m_form.FillCustomIndicatorChart()
        'm_form.SetState()
    End Sub

End Class

Public Class CDataView_State_CUSTIDC_PAPRA_Changed
    Inherits CDataView_State


    Public Sub New(frm As Windows.Forms.Form)
        m_form = frm
    End Sub
    Public Overrides Sub Enter()

        m_form.FillCustomIndicatorChart(False)
    End Sub



End Class

Public Class CDataView_State_SMAShow
    Inherits CDataView_State

    Public Sub New(frm As Windows.Forms.Form)
        m_form = frm
    End Sub
    Public Overrides Sub Enter()

        m_form.ShowSMALines()
    End Sub


End Class

Public Class CDataView_State_SMAHide
    Inherits CDataView_State

    Public Sub New(frm As Windows.Forms.Form)
        m_form = frm
    End Sub
    Public Overrides Sub Enter()

        m_form.HideSMALines()
    End Sub


End Class

