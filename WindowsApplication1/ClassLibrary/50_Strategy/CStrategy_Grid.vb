Option Explicit On
Public Class CStrategy_Grid


    '类说明：网格法交易系统
    '仓位状态标志
    Public Enum EPosFlag
        Non = 0  '空仓
        O1 = 1  'O1在仓
        O2 = 2  'O2在仓
        O1O2 = 3  'O1、O2在仓
    End Enum

    '价格状态标志
    Public Enum EPriceFlag
        U2 = 0
        U1_U2 = 1
        U1 = 2
        OO = 3
        D1 = 4
        D1_D2 = 5
        D2 = 6
    End Enum

    'Private m_tpTestResult As SystemTestResult        '测试结果(Type数据）问题？要不要用零散值放在类中？

    Private m_fMaxiumPrice As Single  '买入时的最大价格, 用于计算最大仓位
    Private m_fMiniumPrice As Single  '买入时的最小价格,

    Private m_fPriceData As Collection    '原始价格数据

    Private m_fInterPercent As Single    '第一档的百分比
    Private m_fLimitPercent As Single '止盈的百分比

    Private m_fInterPercent_Minus As Single    '负第一档的百分比
    Private m_fLimitPercent_Minus As Single '止损的百分比

    Private m_iStocks As Integer    '每次测试的股数     '=============归为CPositionRules类===============

    'Private m_sngPDTest() As Single     '测试用价格数组变量

    'Private m_iTransTotNum As Integer    '交易次数
    'Private m_iTransPosNum As Integer    '盈利次数
    'Private m_iTransNegNum As Integer    '亏损次数

    'Private m_iTransDays As Integer            '总交易天数
    '
    'Private m_fTotalProLos As Integer          '总盈亏(含交易费)
    'Private m_fTotalProLos_NoCommiss  As Single    '总盈亏(不含交易费)
    '
    'Private m_fPLPercent As Single                '盈亏比例
    '
    'Private m_fStockVarPercent As Single          '测试期间股价变动

    '
    ''仓位状态标志
    'Public Enum EPosFlag
    '    Non = 0  '空仓
    '    O1 = 1  'O1在仓
    '    O2 = 2  'O2在仓
    '    O1O2 = 3  'O1、O2在仓
    'End Enum
    '
    ''价格状态标志
    'Public Enum EPriceFlag
    '    U2 = 0
    '    U1_U2 = 1
    '    U1 = 2
    '    OO = 3
    '    D1 = 4
    '    D1_D2 = 5
    '    D2 = 6
    'End Enum

    ''订单Type
    'Private Type Order
    '    iOrderNumber As Integer '仓位号
    '    iStock As Integer   '持股数
    '    fPosCost As Single '持仓成本
    'End Type


    'Public Type PriceData
    '    iCount  As Integer          '信息的行数
    '    arDate() As Date        '日期数组，和价格数组一一对应
    '    arClosePrice() As Single     '当日收盘价
    'End Type


    'Public Type GridTransaction
    '    oResult As TestResult

    'End Type

    'Dim m_tpTestResult As TestResult

    '实现网格算法
    '基本思路：状态机法
    '用2笔仓位做实验,
    '输入： 价格数组
    '输出： 测试结果



    '外部模块无法取这个值？
    'Public Property PriceData() As Single()
    '    Get
    '        PriceData = m_fPriceData
    '    End Get

    '    Set(sngPDTest As Single())

    '        Dim i, j As Integer

    '        i = UBound(sngPDTest)

    '        ReDim m_sngPDTest(i)

    '        For j = 1 To i
    '            m_sngPDTest(j) = sngPDTest(j)
    '        Next
    '    End Set
    'End Property

    Public ReadOnly Property AveragePrice() As Single
        Get
            '    Dim i, j As Integer
            '    Dim sngTotal As Single
            '
            '    i = UBound(m_sngPDTest)
            '
            '    For j = 1 To i
            '        sngTotal = sngTotal + m_sngPDTest(j)
            '    Next
            '
            '    AveragePrice = sngTotal / i
            AveragePrice = 0
        End Get
    End Property

    'Public Property Get TestResult() As SystemTestResult
    '        'TestResult = m_tpTestResult
    '    End Property



    '用网格法(收盘价)计算日线
    Public Sub GridCalculate(oPriceDataTable As CDTDaily_Stock_Collection, oPS As CPositionRules, oOrderSet As CDataTableOrder, oSTR As CStrategy_TestResult)

        Dim iCycleLimit As Integer  '每次循环次数，超过该次数全部清空
        'Dim fProLoss As Single      '盈亏额
        Dim bNewStart As Boolean    '是否全新开始，还是第一次空仓

        Dim iStock As Integer       '每笔股数
        Dim fO1_Cost As Single      'O1仓位的单位成本价格
        Dim fO2_Cost As Single      'O2仓位的单位成本价格
        Dim fCurrentOOPrice As Single   '当前基准价格

        Dim fStartPrice As Single   '起始一行价格
        Dim fEndPrice As Single     '最终一行的价格

        'oSTR.TransTotNum = 0
        'oSTR.TransPosNum = 0
        'oSTR.TransNegNum = 0

        Dim iRow As Integer
        Dim iRowTotal As Integer

        Dim fCurrentPrice As Single

        Dim ePosFlag As EPosFlag
        Dim ePriceFlag As EPriceFlag

        Dim sThisDate As String

        '初始变量
        iCycleLimit = 20
        'fProLoss = 0
        bNewStart = True


        m_fInterPercent = 0.03
        m_fLimitPercent = 0.1
        m_fInterPercent_Minus = -0.03
        m_fLimitPercent_Minus = -0.1

        ePosFlag = EPosFlag.Non    '起始为空仓
        ePriceFlag = EPriceFlag.OO     '起始位基准价格

        iRowTotal = oPriceDataTable.PriceData.Count

        For iRow = 1 To iRowTotal

            Dim oOrder1 As New CDataOrder
            Dim oOrder2 As New CDataOrder

            oOrder1.OrderNumber = 1
            oOrder2.OrderNumber = 2

            sThisDate = oPriceDataTable.PriceData.Item(iRow).ThisDate

            If fStartPrice = 0 Then
                fStartPrice = oPriceDataTable.PriceData.Item(iRow).ClosePrice_PreAdj
                oSTR.FirstDayCost = fStartPrice
            End If

            Debug.Print("Row" & iRow & ": BEGIN------------------")

            fCurrentPrice = oPriceDataTable.PriceData.Item(iRow).ClosePrice_PreAdj '取得当前收盘价格

            '如仓位为0,即第一次
            If ePosFlag = EPosFlag.Non Then
                fCurrentOOPrice = fCurrentPrice
            End If

            ePriceFlag = GetPriceLevel(fCurrentPrice, fCurrentOOPrice, m_fInterPercent, m_fLimitPercent, m_fInterPercent_Minus, m_fLimitPercent_Minus)

            '取得最大价格
            'If m_fMaxiumPrice < fCurrentPrice Then
            '    m_fMaxiumPrice = fCurrentPrice
            ' End If

            '状态机算法
            Select Case ePosFlag
                Case EPosFlag.Non
                    If ePriceFlag = EPriceFlag.OO Then
                        oOrder1.BuyOrder("1", fCurrentPrice, m_iStocks, sThisDate)
                        oOrderSet.OrderSet.Add(oOrder1)
                        If m_fMaxiumPrice < fCurrentPrice Then
                            m_fMaxiumPrice = fCurrentPrice
                        End If
                        ePosFlag = EPosFlag.O1
                    End If

                    'O1仓位状态
                Case EPosFlag.O1
                    Select Case ePriceFlag
                        Case EPriceFlag.U2, EPriceFlag.U1, EPriceFlag.D2
                            oOrder1.SellOrder("1", fCurrentPrice, m_iStocks, sThisDate)
                            oOrderSet.CloseOrder("1", fCurrentPrice, m_iStocks, sThisDate)

                            ePosFlag = EPosFlag.Non

                        Case EPriceFlag.D1
                            oOrder2.BuyOrder("2", fCurrentPrice, m_iStocks, sThisDate)

                            oOrderSet.OrderSet.Add(oOrder2)
                            '计算最大价位
                            If m_fMaxiumPrice < fCurrentPrice Then
                                m_fMaxiumPrice = fCurrentPrice
                            End If

                            ePosFlag = EPosFlag.O1O2

                    End Select

                    'O2仓位状态
                Case EPosFlag.O2
                    Select Case ePriceFlag
                        Case EPriceFlag.U2, EPriceFlag.U1, EPriceFlag.D2
                            oOrder2.SellOrder("2", fCurrentPrice, m_iStocks, sThisDate)
                            oOrderSet.CloseOrder("2", fCurrentPrice, m_iStocks, sThisDate)

                            ePosFlag = EPosFlag.Non

                        Case EPriceFlag.D1
                            oOrder1.BuyOrder("1", fCurrentPrice, m_iStocks, sThisDate)
                            '计算最大价位
                            oOrderSet.OrderSet.Add(oOrder1)
                            If m_fMaxiumPrice < fCurrentPrice Then
                                m_fMaxiumPrice = fCurrentPrice
                            End If
                            ePosFlag = EPosFlag.O1O2

                    End Select

                    ''O1O2仓位状态
                Case EPosFlag.O1O2
                    Select Case ePriceFlag
                        Case EPriceFlag.U2, EPriceFlag.D2
                            oOrder2.SellOrder("2", fCurrentPrice, m_iStocks, sThisDate)
                            oOrderSet.CloseOrder("2", fCurrentPrice, m_iStocks, sThisDate)

                            oOrder1.SellOrder("1", fCurrentPrice, m_iStocks, sThisDate)
                            oOrderSet.CloseOrder("1", fCurrentPrice, m_iStocks, sThisDate)

                            ePosFlag = EPosFlag.Non

                        Case EPriceFlag.U1

                            oOrder1.SellOrder("1", fCurrentPrice, m_iStocks, sThisDate)
                            oOrderSet.CloseOrder("1", fCurrentPrice, m_iStocks, sThisDate)

                            ePosFlag = EPosFlag.O2
                    End Select

            End Select


            If ePosFlag = EPosFlag.Non Then
                Debug.Print("No Order")
            ElseIf ePosFlag = EPosFlag.O1 Then
                Debug.Print("Order 1 In Place")
            ElseIf ePosFlag = EPosFlag.O2 Then
                Debug.Print("Order 2 In Place")
            ElseIf ePosFlag = EPosFlag.O1O2 Then
                Debug.Print("Both Order 1 & 2 In Place")

            End If

            Debug.Print("Row" & iRow & ": Current P/L is: " & oOrderSet.GetProfitLoss(fCurrentPrice))  ' oOrderSet.GetProfitLossbyOrderNumber("1", fCurrentPrice) + oOrderSet.GetProfitLossbyOrderNumber("2", fCurrentPrice)
            Debug.Print("Row" & iRow & ": END------------------" & vbCr)

            oOrder1 = Nothing
            oOrder2 = Nothing
        Next

        oSTR.LastDayCost = fCurrentPrice

        oSTR.TransDays = iRowTotal

        If m_fMaxiumPrice = 0 Or m_iStocks = 0 Then
            MsgBox("计算错误：m_fMaxiumPrice或iStock不能为0!")
            Exit Sub
        Else
            'oSTR.PLPercent = (oSTR.TotalProLos - 5 * oSTR.TransTotNum) / (m_fMaxiumPrice * 2 * m_iStocks)
        End If

        If fStartPrice = 0 Then
            MsgBox("计算错误：fStartPrice不能为0!")
            Exit Sub
        End If

        oSTR.StockVarPercent = (fEndPrice - fStartPrice) / fStartPrice

        oOrderSet.GetSystemTestResult(oSTR, fCurrentPrice)

        Debug.Print(oOrderSet.OrderSet.Count)
        '    Debug.Print "总交易天数:" & oSTR.TransDays
        '    Debug.Print "总交易次数:" & oSTR.TransTotNum
        '    Debug.Print "总盈利次数:" & oSTR.TransPosNum
        '    Debug.Print "总亏损次数:" & oSTR.TransNegNum
        '    Debug.Print "总盈亏(含交易费):" & Format(oSTR.TotalProLos, "0.00")
        '    Debug.Print "交易费:" & Format(oSTR.CommissionCost, "0.00")
        '    Debug.Print "最大单次盈利:" & oSTR.MaxiumProfit
        '    Debug.Print "最大单次亏损:" & oSTR.MaxiumLoss

        'Debug.Print "最高持仓成本:" & Format(oSTR.., "0.00")

        'Debug.Print "每100天的盈利:" & (fProLoss - 5 * iTransTotNum * 100) / iTransDays

        '    Debug.Print "盈利比例:" & Format(oSTR.PLPercent, "0.00%")
        '    Debug.Print "测试期间股价变动：" & Format((fEndPrice - fStartPrice) / fStartPrice, "0.00%")
    End Sub

    Private Function GetPriceLevel(fCurrentPrice As Single, fCurrentOOPrice As Single, fInterPercent As Single, fLimitPercent As Single, fInterPercent_Minus As Single, fLimitPercent_Minus As Single) As EPriceFlag

        Dim dU2 As Single
        Dim dU1 As Single
        Dim dOO As Single
        Dim dD1 As Single
        Dim dD2 As Single

        Dim dU1_U2 As Single
        Dim dU1_OO As Single
        Dim dOO_D1 As Single
        Dim dD1_D2 As Single

        Dim strLevel As String '用于Debug，当前价格的档位

        dOO = fCurrentOOPrice
        dU1 = dOO * (1 + fInterPercent)
        dU2 = dOO * (1 + fLimitPercent)
        dD1 = dOO * (1 + fInterPercent_Minus)
        dD2 = dOO * (1 + fLimitPercent_Minus)

        dU1_U2 = (dU1 + dU2) / 2
        dU1_OO = (dU1 + dOO) / 2
        dOO_D1 = (dOO + dD1) / 2
        dD1_D2 = (dD1 + dD2) / 2

        '返回7个价格区间中的一个
        If fCurrentPrice >= dU2 Then
            GetPriceLevel = EPriceFlag.U2
            strLevel = "U2"

        ElseIf fCurrentPrice >= dU1_U2 Then
            GetPriceLevel = EPriceFlag.U1_U2
            strLevel = "U1_U2"

        ElseIf fCurrentPrice >= dU1_OO Then
            GetPriceLevel = EPriceFlag.U1
            strLevel = "U1"

        ElseIf fCurrentPrice >= dOO_D1 Then
            GetPriceLevel = EPriceFlag.OO
            strLevel = "OO"

        ElseIf fCurrentPrice >= dD1_D2 Then
            GetPriceLevel = EPriceFlag.D1
            strLevel = "D1"

        ElseIf fCurrentPrice >= dD2 Then
            GetPriceLevel = EPriceFlag.D1_D2
            strLevel = "D1_D2"

        Else
            GetPriceLevel = EPriceFlag.D2
            strLevel = "D2"

        End If

        Debug.Print("Price is: " & fCurrentPrice & " ; Level: " & strLevel)

    End Function

    '卖出订单
    '输入:订单号(1或2)，卖价
    '输出：盈亏
    Private Sub SellOrder(oOrder As CDataOrder, fSellPrice As Single, fProLoss As Single, iStock As Integer)

        'm_tpTestResult.iTransTotNum = oOrder. + 1 '记录交易次数

        '    If fSellPrice > oOrder.EntryCost Then
        '        m_tpTestResult.iTransPosNum = m_tpTestResult.iTransPosNum + 1
        '    Else
        '        m_tpTestResult.iTransNegNum = m_tpTestResult.iTransNegNum + 1
        '    End If

        '    fProLoss = (fSellPrice - oOrder.EntryCost) * iStock + fProLoss

        '卖出后，Order清空
        oOrder.StockNumber = 0
        oOrder.EntryCost = 0

        If oOrder.iOrderNumber = 1 Then
            Debug.Print("Order 1 Sold :" & oOrder.EntryCost)
        ElseIf oOrder.iOrderNumber = 2 Then
            Debug.Print("Order 2 Sold :" & oOrder.EntryCost)
        End If


    End Sub

    '买入订单
    '输入：订单号(1或2)，买价
    '输出：
    Private Sub BuyOrder(oOrder As CDataOrder, fBuyPrice As Single, iStock As Integer)

        oOrder.StockNumber = iStock
        oOrder.EntryCost = fBuyPrice '不考虑手续费

        'If m_fMaxiumPrice < fBuyPrice Then
        '    m_fMaxiumPrice = fBuyPrice    '计算最大持仓成本
        'End If

        If oOrder.iOrderNumber = 1 Then
            Debug.Print("Order 1 Placed :" & oOrder.EntryCost)
        ElseIf oOrder.iOrderNumber = 2 Then
            Debug.Print("Order 2 Placed :" & oOrder.EntryCost)
        End If

    End Sub

    Public Sub GridMethod()

    End Sub

    Public Sub New()
        m_iStocks = 100
    End Sub

End Class
