Namespace DataEntity



    '均线指标
    Public Class CIDC_Average_Obsolete
        Inherits CIDCBASE_Obsolete

        Private m_arrAverage1() As Single       '第1根均线数组
        Private m_iAvgInt1 As Int32 = 3         '第1根均线的间隔，如3日线、5日线、7日线等、3分钟线等

        Private m_arrAverage2() As Single       '第2根均线
        Private m_iAvgInt2 As Int32 = 7         '第2根均线的间隔，如3日线、5日线、7日线等

        Private m_arrAverage3() As Single       '第3根均线
        Private m_iAvgInt3 As Int32 = 15        '第3根均线的间隔，如3日线、5日线、7日线等

        Private m_arrAverage4() As Single       '第4根均线
        Private m_iAvgInt4 As Int32 = 30        '第4根均线的间隔，如3日线、5日线、7日线等

        Private m_arrAverage5() As Single       '第5根均线
        Private m_iAvgInt5 As Int32 = 60        '第5根均线的间隔，如3日线、5日线、7日线等

        Private m_arrAverage6() As Single       '第6根均线
        Private m_iAvgInt6 As Int32 = 180       '第6根均线的间隔，如3日线、5日线、7日线等

        Private m_arrSell() As Date             '卖出信号日期
        Private m_arrBuy() As Date           '买入信号日期

        Private m_arrStatus() As String         '给每日计算有利、不利、Hold三种状态：Long、Short、Hold      

        Public ReadOnly Property ArrayAverage1() As Single()
            Get
                ArrayAverage1 = m_arrAverage1
            End Get
        End Property
        Public ReadOnly Property ArrayAverage2() As Single()
            Get
                ArrayAverage2 = m_arrAverage2
            End Get
        End Property

        Public ReadOnly Property ArrayAverage3() As Single()
            Get
                ArrayAverage3 = m_arrAverage3
            End Get
        End Property

        Public ReadOnly Property ArrayAverage4() As Single()
            Get
                ArrayAverage4 = m_arrAverage4
            End Get
        End Property
        Public ReadOnly Property ArrayAverage5() As Single()
            Get
                ArrayAverage5 = m_arrAverage5
            End Get
        End Property
        Public ReadOnly Property ArrayAverage6() As Single()
            Get
                ArrayAverage6 = m_arrAverage6
            End Get
        End Property

        Public Property AvgInt1() As Int32
            Get
                AvgInt1 = m_iAvgInt1
            End Get
            Set(value As Int32)
                m_iAvgInt1 = value
            End Set
        End Property
        Public Property AvgInt2() As Int32
            Get
                AvgInt2 = m_iAvgInt2
            End Get
            Set(value As Int32)
                m_iAvgInt2 = value
            End Set
        End Property

        Public Property AvgInt3() As Int32
            Get
                AvgInt3 = m_iAvgInt3
            End Get
            Set(value As Int32)
                m_iAvgInt3 = value
            End Set
        End Property
        Public Property AvgInt4() As Int32
            Get
                AvgInt4 = m_iAvgInt4
            End Get
            Set(value As Int32)
                m_iAvgInt4 = value
            End Set
        End Property
        Public Property AvgInt5() As Int32
            Get
                AvgInt5 = m_iAvgInt5
            End Get
            Set(value As Int32)
                m_iAvgInt5 = value
            End Set
        End Property

        Public Property AvgInt6() As Int32
            Get
                AvgInt6 = m_iAvgInt6
            End Get
            Set(value As Int32)
                m_iAvgInt6 = value
            End Set
        End Property

        Public ReadOnly Property BuySignal() As Date()
            Get
                BuySignal = m_arrBuy
            End Get

        End Property

        Public ReadOnly Property SellSignal() As Date()
            Get
                SellSignal = m_arrSell
            End Get

        End Property
        Public Sub New(ByRef DataTablePrice As CDTDaily_Stock_Collection)

            MyBase.New(DataTablePrice)

            CalculateAllAvgs("Close")
        End Sub

        Public Sub New(ByRef dt As CDTDaily)

            MyBase.New(dt)

            CalculateAllAvgs("Close")
        End Sub
        '计算各条均线数据
        '算法：数组均为n+1个，index从0~n，[0]不用，原因是方便直观索引，DTPrice的第n个即对应均线数组的第n个
        '如均线的参数为p, 则每组的有效数据个数为n-p+1。如3日均线，共10条参数，那么[0]、[1]、[2]均设置为-1，均线数目为8条，即从[3]到[10]
        '默认为Close均线

        Public Sub CalculateAllAvgs(Optional ByVal sPriceTage As String = "Close")

            '数组均为n+1个，index从0~n，[0]不用，原因是方便直观索引，DTPrice的第n个即对应均线数组的第n个，第0个数为-1，废弃不用

            If m_colDTP.PriceData.Count = 0 Then
                MsgBox("价格信息为空,请检查原始数据")
            End If

            ReDim m_arrAverage1(m_iTimeSeriesTotalCount)
            m_arrAverage1(0) = -1
            ReDim m_arrAverage2(m_iTimeSeriesTotalCount)
            m_arrAverage2(0) = -1
            ReDim m_arrAverage3(m_iTimeSeriesTotalCount)
            m_arrAverage3(0) = -1
            ReDim m_arrAverage4(m_iTimeSeriesTotalCount)
            m_arrAverage4(0) = -1
            ReDim m_arrAverage5(m_iTimeSeriesTotalCount)
            m_arrAverage5(0) = -1
            ReDim m_arrAverage6(m_iTimeSeriesTotalCount)
            m_arrAverage6(0) = -1

            '各条均线数组计算
            Dim fArrayPrice() As Single
            ReDim fArrayPrice(m_colDTP.PriceData.Count)
            fArrayPrice(0) = -1

            Dim i As Integer

            For i = 1 To m_colDTP.PriceData.Count
                fArrayPrice(i) = -1
                If sPriceTage = "Close" Then
                    fArrayPrice(i) = m_colDTP.PriceData.Item(i).ClosePrice_PreAdj
                ElseIf sPriceTage = "Open" Then
                    fArrayPrice(i) = m_colDTP.PriceData.Item(i).OpenPrice_PreAdj
                ElseIf sPriceTage = "High" Then
                    fArrayPrice(i) = m_colDTP.PriceData.Item(i).HgihPrice_PreAdj
                ElseIf sPriceTage = "Low" Then
                    fArrayPrice(i) = m_colDTP.PriceData.Item(i).LowPrice_PreAdj
                End If
            Next

            GetAvgArray(fArrayPrice, m_arrAverage1, m_iAvgInt1)
            GetAvgArray(fArrayPrice, m_arrAverage2, m_iAvgInt2)
            GetAvgArray(fArrayPrice, m_arrAverage3, m_iAvgInt3)
            GetAvgArray(fArrayPrice, m_arrAverage4, m_iAvgInt4)
            GetAvgArray(fArrayPrice, m_arrAverage5, m_iAvgInt5)
            GetAvgArray(fArrayPrice, m_arrAverage6, m_iAvgInt6)

        End Sub

        Private Sub GetAvgArray(ByRef fArrayPrice() As Single, ByRef arrAverage() As Single, ByVal iAvgInt As Int32)

            Dim i As Int32

            '从 第3/5/7个值开始计算
            For i = iAvgInt To m_iTimeSeriesTotalCount
                'arrAverage(i) = -1
                '如果当前序号i/均线的时长参数可以取整，则给当前均线赋值
                'If i >= iAvgInt Then
                arrAverage(i) = Me.MovingAverage(fArrayPrice, iAvgInt, i)
            Next

        End Sub
        '算法1：简便法(3日、15日线，第1根和第3根线)
        '1)	如果日线(黑线)始终在短线(绿线)上方，持有；
        '2)	如果短线(绿线)下跌低于中线(黄线)，卖出；
        '3)	如果短线(绿线)上升高于中线(黄线)，买入；

        Public Sub CalculateDailyStatus1()

            Dim i As Int32
            ReDim Me.m_arrStatus(Me.m_colDTP.PriceData.Count)
            Dim fThisdayPrice As Single
            Dim fShortdayPrice As Single
            Dim fLongdayPrice As Single
            Dim iLongDays As Integer
            Dim iShortDays As Integer

            Dim sOutputString() As String
            ReDim sOutputString(Me.m_colDTP.PriceData.Count)

            For i = 1 To Me.m_iAvgInt3 - 1
                Me.m_arrStatus(i) = "Hold"
                sOutputString(i) = i & "," & "Hold"
            Next

            For i = Me.m_iAvgInt3 To Me.m_colDTP.PriceData.Count
                fThisdayPrice = Me.m_colDTP.PriceData.Item(i).ClosePrice_PreAdj
                fShortdayPrice = Me.m_arrAverage1(i)
                fLongdayPrice = Me.m_arrAverage3(i)

                If fThisdayPrice > fShortdayPrice Or fThisdayPrice > fLongdayPrice Then
                    Me.m_arrStatus(i) = "Long"
                    sOutputString(i) = i & "," & Me.m_arrStatus(i)
                    iLongDays = iLongDays + 1
                ElseIf fThisdayPrice < fShortdayPrice Or fThisdayPrice < fLongdayPrice Then
                    Me.m_arrStatus(i) = "Short"
                    sOutputString(i) = i & "," & Me.m_arrStatus(i)
                    iShortDays = iShortDays + 1
                End If
            Next

            'MsgBox("Longdays:" & iLongDays)
            'MsgBox("Shortdays:" & iShortDays)
            CUtility.WriteLog(sOutputString)
        End Sub
    End Class

End Namespace
