Public Class CDataPrice_Stock
    Inherits CDataPriceBASE
    'Option Explicit

    '日线数据类，包含日期、O、H、L、C、V、AdjC的数组，注意数组很难用上

    '用一个PriceData，再用一个上级PriceDataTable类

    'Private Type PriceData
    '    iCount  As Integer          '信息的行数
    '    arDate() As Date        '日期数组，和价格数组一一对应
    '    arClosePrice() As Single     '当日收盘价
    'End Type


    '==========在类模组中，数组似乎很难作为返回值传递
    'Private m_arDate() As String
    'Private m_arOpenPrice() As Single
    'Private m_arClosePrice() As Single
    'Private m_arHighPrice() As Single
    'Private m_arLowPrice() As Single

    'Private m_colDate As Collection
    'Private m_colOpenPrice As Collection
    'Private m_colClosePrice As Collection
    'Private m_colHighPrice As Collection
    'Private m_colLowPrice As Collection
    'Private m_colVolume As Collection
    'Private m_colAdjClosePrice As Collection


    Private m_fOpenPrice_PreAdj As Single
    Private m_fOpenPrice_PosAdj As Single

    Private m_fClosePrice_PreAdj As Single
    Private m_fClosePrice_PosAdj As Single

    Private m_fHighPrice_PreAdj As Single
    Private m_fHighPrice_PosAdj As Single

    Private m_fLowPrice_PreAdj As Single
    Private m_fLowPrice_PosAdj As Single

    Private m_fTurnoverValue As Single   '成交额

    Private m_fTurnoverVolume As Single   '成交量

    Private m_fVariation As Single '与昨日比涨跌幅

    Private m_fTodayVariation As Single '当日涨跌幅


    Public Property TurnoverValue() As String
        Get
            TurnoverValue = m_fTurnoverValue
        End Get

        Set(fTurnoverValue As String)
            m_fTurnoverValue = fTurnoverValue
        End Set
    End Property

    Public Property ThisDate() As String
        Get
            ThisDate = m_strDate
        End Get

        Set(strDate As String)
            m_strDate = strDate
        End Set
    End Property

    Public Property OpenPrice_PreAdj() As Single
        Get
            OpenPrice_PreAdj = m_fOpenPrice_PreAdj
        End Get

        Set(fOpenPrice_PreAdj As Single)
            m_fOpenPrice_PreAdj = fOpenPrice_PreAdj
        End Set
    End Property
    Public Property OpenPrice_PosAdj() As Single
        Get
            OpenPrice_PosAdj = m_fOpenPrice_PosAdj
        End Get

        Set(fOpenPrice_PosAdj As Single)
            m_fOpenPrice_PosAdj = fOpenPrice_PosAdj
        End Set
    End Property

    Public Property ClosePrice_PreAdj() As Single
        Get
            ClosePrice_PreAdj = m_fClosePrice_PreAdj
        End Get

        Set(fClosePrice_PreAdj As Single)
            m_fClosePrice_PreAdj = fClosePrice_PreAdj
        End Set
    End Property
    Public Property ClosePrice_PosAdj() As Single
        Get
            ClosePrice_PosAdj = m_fClosePrice_PosAdj
        End Get

        Set(fClosePrice_PosAdj As Single)
            m_fClosePrice_PosAdj = fClosePrice_PosAdj
        End Set
    End Property


    Public Property HighPrice_PreAdj() As Single
        Get
            HighPrice_PreAdj = m_fHighPrice_PreAdj
        End Get

        Set(fHighPrice_PreAdj As Single)
            m_fHighPrice_PreAdj = fHighPrice_PreAdj
        End Set
    End Property
    Public Property HighPrice_PosAdj() As Single
        Get
            HighPrice_PosAdj = m_fHighPrice_PosAdj
        End Get

        Set(fHighPrice_PosAdj As Single)
            m_fHighPrice_PosAdj = fHighPrice_PosAdj
        End Set
    End Property



    Public Property LowPrice_PreAdj() As Single
        Get
            LowPrice_PreAdj = m_fLowPrice_PreAdj
        End Get

        Set(fLowPrice_PreAdj As Single)
            m_fLowPrice_PreAdj = fLowPrice_PreAdj
        End Set
    End Property
    Public Property LowPrice_PosAdj() As Single
        Get
            LowPrice_PosAdj = m_fLowPrice_PosAdj
        End Get

        Set(fLowPrice_PosAdj As Single)
            m_fLowPrice_PosAdj = fLowPrice_PosAdj
        End Set
    End Property

    Public Property TurnoverVolume() As Single
        Get
            TurnoverVolume = m_fTurnoverVolume
        End Get

        Set(colVolume As Single)
            m_fTurnoverVolume = colVolume
        End Set
    End Property

    'Public Property AdjClosePrice() As Single
    '    Get
    '        AdjClosePrice = m_fClosePrice_PreAdj
    '    End Get

    '    Set(fClosePrice As Single)
    '        m_fClosePrice_PreAdj = fClosePrice
    '    End Set
    'End Property

    Public ReadOnly Property Variation() As Single
        Get
            Variation = m_fVariation
        End Get
    End Property

    Public ReadOnly Property TodayVariation() As Single

        Get
            TodayVariation = m_fTodayVariation
        End Get

    End Property

    Public Sub New()

        m_sTimeUnit = "1d"
    End Sub

    Public Sub Finanlize()


    End Sub

    'insert snippet

End Class
