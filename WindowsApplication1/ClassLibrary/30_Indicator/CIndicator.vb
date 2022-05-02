
Imports MyTradingSystem.DataEntity
Imports TicTacTec.TA.Library
Imports TeeChart
Imports Steema.TeeChart

Namespace Indicator


    ' ''' <summary>
    ' ''' 绘制Indicator。基于IIndicator上的策略类模式
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Public Interface IIndicatorPlot

    '    'Property m_idc As IIndicator

    '    'Property m_idc As CIndicator    '这个Indicator如何用？如何赋值? 

    '    ''' <summary>
    '    ''' 包含DataTable数据类型
    '    ''' </summary>
    '    ''' <value></value>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>


    '    'Property IntervalType As String
    '    'Property IntervalNumbers As UInteger

    '    ''' <summary>
    '    ''' 在AxHost上绘制指标， 'TeeChart.TChart是AxHost的子类
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Sub Plot(ByRef canvas As System.Windows.Forms.AxHost)     'TeeChart.TChart是AxHost的子类

    'End Interface

    ''' <summary>
    ''' 绘制Indicator。在IIndicator上的装饰类
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface IIndicatorPlotAxTchart


        'Property m_Indicator As CIndicator
        ''' <summary>
        ''' 在AxTchart上绘制指标
        ''' </summary>
        ''' <remarks></remarks>
        Sub Plot(ByVal dt As DataTable, ByRef canvas As Chart, ByVal canvaspos As Int16, Optional pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj) '是否要把参数改为接口ITChart?

        Sub RemovePlot(ByRef canvas As Chart)

        Sub Show()

        Sub Hide()


        ''' <summary>
        ''' 弹出参数设置窗口，并且绘图
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <param name="canvas"></param>
        ''' <param name="canvaspos"></param>
        ''' <param name="pat"></param>
        ''' <remarks></remarks>
        'Sub PopWindowParameterPlot(ByVal dt As DataTable, ByRef canvas As Chart, ByVal canvaspos As Int16, Optional pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj)
        'Sub PlotCandleChart(ByVal dt As DataTable, ByRef canvas As Styles.Candle, Optional pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj)

        'Sub PlotLineChart(ByVal dt As DataTable, ByRef canvas As Styles.Line, Optional pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj)

        'Sub PlotVolumeChart(ByVal dt As DataTable, ByRef canvas As Styles.Line)
    End Interface

    Public Interface IIndicator
        'Inherits System.Data.
        Property IntervalType As String
        Property IntervalNumbers As UInteger

        Property PriceData As CDTDaily        '原始价格信息表

        ReadOnly Property IndicatorValue As DataTable  '指标信息表，第1列为日期时间，后面依次为各档指标值

        ReadOnly Property IndicatorName As String         '指标名称
        ReadOnly Property IndicatorTip As String         '指标描述

        Property ParameterDic As SortedDictionary(Of String, Single)    '参数值，如(FastLine, 10)。可以把参数名改为Enum列举型

        'WriteOnly Property m_idcPlot As IIndicatorPlot      '用于绘图

        WriteOnly Property m_idcPlotTeeChart As IIndicatorPlotAxTchart     '用于绘图
        'Sub Init()

        'Sub Calculate()

        ''' <summary>
        ''' 设置参数值
        ''' </summary>
        ''' <remarks></remarks>
        Sub setParameters()

        ''' <summary>
        ''' 获取指标值，即DataTable从1列到...列
        ''' </summary>
        ''' <remarks></remarks>
        Sub getIndicator()

        ''' <summary>
        ''' 在一个控件上绘制图形
        ''' </summary>
        ''' <param name="canvas"></param>
        ''' <remarks></remarks>
        Sub Plot(ByRef canvas As System.Windows.Forms.AxHost)

        Sub PlotTeeChart(ByRef canvas As TChart)

        Event On_DailyBar()
        Event On_IntraBar()

    End Interface
    Public Enum EPriceType
        Open = 0
        High = 1
        Low = 2
        Close = 3
    End Enum

    Public Enum ERetCode
        AllocErr = 3
        BadObject = 15
        BadParam = 2
        FuncNotFound = 5
        GroupNotFound = 4
        InputNotAllInitialize = 10
        InternalError = 5000
        InvalidHandle = 6
        InvalidListType = 14
        InvalidParamFunction = 9
        InvalidParamHolder = 7
        InvalidParamHolderType = 8
        LibNotInitialize = 1
        NotSupported = 16
        OutOfRangeEndIndex = 13
        OutOfRangeStartIndex = 12
        OutputNotAllInitialize = 11
        Success = 0
        UnknownErr = 65535
    End Enum

    'Public MustInherit Class CIndicatorPlotAxTchart
    '    Implements IIndicatorPlot

    '    Public MustOverride Sub PlotAxTChart(ByRef canvas As TChart, Optional pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj)

    '    Public MustOverride Sub PlotCandleTChart(ByRef canvas As Styles.Candle, Optional pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj)

    '    Public Sub Plot(ByRef canvas As AxHost) Implements IIndicatorPlot.Plot

    '    End Sub
    'End Class

    'Public MustInherit Class CIndicatorPlot
    '    Public MustOverride Sub Plot(ByRef canvas As System.Windows.Forms.AxHost)
    '    Protected m_idc As CIndicator

    'End Class

    ''' <summary>
    ''' 价格类技术指标
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class CIndicatorPrice
        Inherits CIndicator

        Protected m_PriceData As CDTDaily
        Protected m_PriceType As EPriceType = EPriceType.Close  '计算用的价格类型，默认为收盘价

        'Protected m_PlotAxTChart As IIndicatorPlotAxTchart

        Public Property PriceType As EPriceType
            Get
                PriceType = m_PriceType
            End Get
            Set(value As EPriceType)
                m_PriceType = value
            End Set
        End Property
        Public Sub New()
            m_PriceData = New CDTDaily


            ReDim m_DataColumns(0)

            '日期列
            m_DataColumns(0) = Me.Columns.Add("TheDate", GetType(System.String))
            m_DataColumns(0).AllowDBNull = False

            '设置第一列日期时间为主键
            Me.PrimaryKey = m_DataColumns

        End Sub
        Public Sub New(dt As CDTDaily)
            '取得原始价格数据
            'm_PriceData = New CDTDaily

            'm_ParaNameList = New List(Of String)
            'm_ParaValueList = New List(Of UInt16)
            m_ParaDictionary = New Dictionary(Of String, Double)

            m_PriceData = dt

            ReDim m_DataColumns(0)

            '日期列
            m_DataColumns(0) = Me.Columns.Add("TheDate", GetType(System.String))
            m_DataColumns(0).AllowDBNull = False

            '设置第一列日期时间为主键
            Me.PrimaryKey = m_DataColumns

            'InitOHLCPriceArray()

        End Sub

        

    End Class

    ''' <summary>
    ''' 货币类技术指标
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class CIndicatorMonetary

    End Class

    ''' <summary>
    ''' 市场情绪类大势技术指标
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class CIndicatorSentiment

    End Class

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class CIndicatorMomentum

    End Class


    Public MustInherit Class CIndicator
        Inherits DataTable
        'Implements IIndicator


        'Protected m_ParaNameList As List(Of String)           '参数名
        'Protected m_ParaValueList As List(Of UInt16)          '参数值

        'Protected m_idcPlot As CIndicatorPlotAxTchart      '用于绘图
        Protected m_PlotAxTChart As IIndicatorPlotAxTchart      '用于绘图

        Protected m_ParaDictionary As Dictionary(Of String, Double) '技术指标参数字典

        Protected m_DataColumns() As DataColumn                  'Indicator的栏，如SMA7

        Protected m_IntervalType As String = "日"               '间隔类型，如"分"钟、小"时"h、"天"d、"周"w、"月"m、"年"y，默认为天
        Protected m_IntervalNumber As UInt16 = 3                 '间隔长度，默认为3

        'Protected m_OpenPrice() As Single
        'Protected m_HighPrice() As Single
        'Protected m_LowPrice() As Single
        'Protected m_ClosePrice() As Single MustOverride
        Public Overridable Sub PlotAxTChart(ByRef canvas As Chart, ByVal canvaspos As Int16, Optional pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj)
            m_PlotAxTChart.Plot(Me, canvas, canvaspos, pat)
        End Sub
        Public Overridable Sub PopWindowParameterPlot(ByRef canvas As Chart, ByVal canvaspos As Int16, Optional pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj)
            'm_PlotAxTChart.PopWindowParameterPlot(Me, canvas, canvaspos, pat)
        End Sub
        Public Overridable Sub RemoveAxTChart(ByRef canvas As Chart)
            If Not IsNothing(m_PlotAxTChart) Then
                m_PlotAxTChart.RemovePlot(canvas)
            End If
        End Sub

        Public Overridable Sub Show()
            If Not IsNothing(m_PlotAxTChart) Then
                m_PlotAxTChart.Show()
            End If
        End Sub

        Public Overridable Sub Hide()
            If Not IsNothing(m_PlotAxTChart) Then
                m_PlotAxTChart.Hide()
            End If
        End Sub


        Public Sub New()

        End Sub

        ' ''' <summary>
        ' ''' 初始化Open/High/Low/Close Price价格数组，为后续计算做好准备
        ' ''' </summary>
        ' ''' <remarks></remarks>
        'Public Overridable Sub InitOHLCPriceArray()
        '    Try


        '        With m_PriceData

        '            ReDim m_OpenPrice(.Rows.Count - 1)
        '            ReDim m_HighPrice(.Rows.Count - 1)
        '            ReDim m_LowPrice(.Rows.Count - 1)
        '            ReDim m_ClosePrice(.Rows.Count - 1)

        '            Dim i As UInteger = 0

        '            For Each dr As DataRow In .Rows
        '                If (.TableName <> "StockPriceDaily") Then
        '                    m_OpenPrice(i) = dr.Item("OpenPrice")
        '                    m_HighPrice(i) = dr.Item("HighPrice")
        '                    m_LowPrice(i) = dr.Item("LowPrice")
        '                    m_ClosePrice(i) = dr.Item("ClosePrice")
        '                Else
        '                    m_OpenPrice(i) = dr.Item("OpenPrice_FA")
        '                    m_HighPrice(i) = dr.Item("HighPrice_FA")
        '                    m_LowPrice(i) = dr.Item("LowPrice_FA")
        '                    m_ClosePrice(i) = dr.Item("ClosePrice_FA")
        '                End If
        '                i += 1
        '            Next
        '        End With

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
        'End Sub

        ''' <summary>
        ''' 参数重新调整后进行初始化列
        ''' </summary>
        ''' <remarks></remarks>
        Protected MustOverride Function Init(Optional Period As UInt16 = 3) As Integer
        Protected MustOverride Sub Calculate()


        ''' <summary>
        ''' VIP 这里有风险，传入参数的顺序是要按照要求的，否则会出错
        ''' </summary>
        ''' <param name="paArray"></param>
        ''' <remarks></remarks>
        Public Overridable Sub SetParameters(ByVal ParamArray paArray() As Double)

        End Sub

        Public Overridable Sub SetDefaultParameters()
            Calculate()
        End Sub

        Public Property IntervalNumbers As UInteger
            Get
                IntervalNumbers = m_IntervalType
            End Get
            Set(value As UInteger)
                m_IntervalNumber = value
            End Set
        End Property

        Public Property IntervalType As String
            Get
                IntervalType = m_IntervalType
            End Get
            Set(value As String)
                m_IntervalType = value
            End Set
        End Property



        'Public Overridable Sub PlotAxTchart(ByRef canvas As TeeChart.TChart, Optional pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj)
        '    m_idcPlot.PlotAxTChart(canvas)
        'End Sub

    End Class
    '    Property IntervalType As String
    '    Property IntervalNumbers As UInteger
    '    Sub Init()

    '    Sub Calculate()

    'End Interface

End Namespace
