Public Class CDataPriceBASE
    Protected m_iRowCount As Integer
    Protected m_sTimeUnit As String  '时间类型   Tick/1d/5d/7d/30d/90d/180d/1m/1y

    Protected m_strDate As String

    Protected m_fOpenPrice As Single
    Protected m_fClosePrice As Single
    Private m_fHighPrice As Single
    Private m_fLowPrice As Single

    Private m_sIntervalSymbol As String    '默认为d，还可以为5d, mon, min, y, w, 1w
    Public Property IntervalSymbol() As String
        Get
            IntervalSymbol = m_sIntervalSymbol
        End Get

        Set(sIntervalSymbol As String)
            m_sIntervalSymbol = sIntervalSymbol
        End Set
    End Property
    Public Property OpenPrice() As Single
        Get
            OpenPrice = m_fOpenPrice
        End Get

        Set(fOpenPrice As Single)
            m_fOpenPrice = fOpenPrice
        End Set
    End Property

    Public Property ClosePrice() As Single
        Get
            ClosePrice = m_fClosePrice
        End Get

        Set(fClosePrice As Single)
            m_fClosePrice = fClosePrice
        End Set
    End Property

    Public Property HighPrice() As Single
        Get
            HighPrice = m_fHighPrice
        End Get

        Set(fHighPrice As Single)
            m_fHighPrice = fHighPrice
        End Set
    End Property

    Public Property LowPrice() As Single
        Get
            LowPrice = m_fLowPrice
        End Get

        Set(fLowPrice As Single)
            m_fLowPrice = fLowPrice
        End Set
    End Property


End Class
