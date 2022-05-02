
Namespace DataEntity


    '指标的基础类
    Public Class CIDCBASE_Obsolete
        Protected m_colDTP As CDTDaily_Stock_Collection     '取得DataTablePrice数据，核心数据

        Protected m_iTimeSeriesTotalCount As Integer

        Public Property DataTablePrice As CDTDaily_Stock_Collection
            Get
                DataTablePrice = m_colDTP
            End Get
            Set(value As CDTDaily_Stock_Collection)
                m_colDTP = value
                m_iTimeSeriesTotalCount = m_colDTP.PriceData.Count

            End Set
        End Property

        Public Sub New(DataTablePrice As CDTDaily_Stock_Collection)

            If DataTablePrice Is Nothing Then

            Else
                m_colDTP = DataTablePrice
                m_iTimeSeriesTotalCount = Me.DataTablePrice.PriceData.Count
            End If


        End Sub

        Public Sub New(dtp As CDTDaily)

            If DataTablePrice Is Nothing Then

            Else
                m_colDTP = DataTablePrice
                m_iTimeSeriesTotalCount = Me.DataTablePrice.PriceData.Count
            End If


        End Sub

        '技术分析指标类
        '各个技术指标的计算
        '输入：原始价格
        '输出：需要的指标数据，如EMA



        '算法: 移动均线算法，
        '输入: 价格数组，需要计算的长度
        '输出：
        Public Function MovingAverage(Price() As Single, Length As Integer, iCurrentPos As Integer)

            Dim i As Integer
            Dim fTotal As Single

            For i = iCurrentPos - Length + 1 To iCurrentPos
                fTotal = fTotal + Price(i)
            Next

            MovingAverage = fTotal / Length


        End Function

        '算法: 加权移动均线算法，
        '输入: 价格数组，需要计算的长度
        '输出：
        Public Function EMA(RawPrice() As Single, Length As Integer) As Single

            If Length > 1 Then
                EMA = (2 / (Length + 1)) * RawPrice(Length) + ((Length - 1) / (Length + 1)) * EMA(RawPrice, Length - 1)
            Else
                EMA = RawPrice(1)
            End If

            'Exit Function

        End Function

        Public Function DIF(Price() As Single, ShortLen As Integer, LongLen As Integer) As Single
            DIF = EMA(Price, ShortLen) - EMA(Price, LongLen)
        End Function

        Public Function DEA(Price() As Single, ShortLen As Integer, LongLen As Integer, Length As Integer) As Single

            'DEA = EMA(DIF(Price, ShortLen, LongLen), Length)

        End Function

        Public Function MACD(Price() As Single, ShortLen As Integer, LongLen As Integer, Length As Integer) As Single

            'MACD = 2 * (DIF(Price, ShortLen, LongLen) - DEA(Price, ShortLen, LongLen, Length))

        End Function
        '***********************************************************************
        '* 平均值                                                 *
        '***********************************************************************
        Public Function Mean(k As Long, Arr() As Single)
            Dim Sum As Single
            Dim i As Integer

            Sum = 0
            For i = 1 To k
                Sum = Sum + Arr(i)
            Next i

            Mean = Sum / k

        End Function

        '标准差
        Public Function StdDev(k As Long, Arr() As Single)
            Dim i As Integer
            Dim avg As Single, SumSq As Single

            avg = Mean(k, Arr)
            For i = 1 To k
                SumSq = SumSq + (Arr(i) - avg) ^ 2
            Next i

            StdDev = Math.Sqrt(SumSq / (k - 1))

        End Function

        '测试数组、函数、递归算法. value(n)=value(n-1)+i, 3个数1,1,1
        '不要返回数组

        Public Function Digui_Test(iInput() As Single, iOutput() As Single) As Single  'As Single()
            Dim iTotal As Integer

            iTotal = UBound(iInput)

            'ReDim EMA(iTotal)

            Dim j As Integer

            Dim LowRawPrice() As Single
            ReDim LowRawPrice(iTotal - 1)

            '前一级的原始价格数据
            For j = 1 To iTotal - 1
                LowRawPrice(j) = iInput(j)
            Next

            For j = 2 To iTotal
                iOutput(j) = Digui_Test(LowRawPrice, iOutput) + iInput(j - 1)
            Next

            Exit Function

        End Function

        Public Function Digui_Test2(iInput() As Single, n As Integer) As Single

            If n > 1 Then
                Digui_Test2 = Digui_Test2(iInput, n - 1) + iInput(n)
            Else
                Digui_Test2 = iInput(1)
            End If

        End Function
    End Class

End Namespace
