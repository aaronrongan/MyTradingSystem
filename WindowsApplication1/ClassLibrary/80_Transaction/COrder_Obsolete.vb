Public Class COrder_Obsolete


    'Type 无法在Class中使用，改用类实现

    Private m_iOrderNumber As Integer    '简易型订单号，简单的如1/2/3...

    Private m_strStockCode As String   '持仓代码，如002001

    Private m_iOrderType As Integer     '-1为Sell，1为Buy, 0为双向Close订单, 2为预留功能如送股

    Private m_sOrderNumber As String    '长字符串型订单号，便于管理编号

    Private m_iStock As Integer      '买卖股数，100的整数，问题：但是债券不是100的整数

    Private m_fEntryCost As Single    '持仓成本单价

    Private m_fExitCost As Single    '平仓单价

    Private m_fCommissionCost As Single     '交易费

    Private m_sEntryDate As Date     '进仓日期

    Private m_sExitDate As Date      '平仓日期

    Private m_bOrderClosed As Boolean   '是否平仓

    Public Property ExitDate() As Date
        Get
            ExitDate = m_sExitDate
        End Get
        Set(sExitDate As Date)
            m_sExitDate = sExitDate
        End Set
    End Property


    Public Property EntryDate() As Date
        Get
            EntryDate = m_sEntryDate
        End Get
        Set(sEntryDate As Date)
            m_sEntryDate = sEntryDate
        End Set
    End Property



    Public Property CommissionCost() As Single
        Get
            CommissionCost = m_fCommissionCost
        End Get
        Set(fCommissionCost As Single)
            m_fCommissionCost = fCommissionCost
        End Set
    End Property




    Public Property OrderClosed() As Boolean
        Get
            OrderClosed = m_bOrderClosed
        End Get
        Set(bOrderClosed As Boolean)
            m_bOrderClosed = bOrderClosed
        End Set
    End Property


    Public Property StockCode() As String
        Get
            StockCode = m_strStockCode

        End Get
        Set(strStockCode As String)
            m_strStockCode = strStockCode
        End Set
    End Property



    Public Property OrderType() As Integer
        Get
            OrderType = m_iOrderType
        End Get
        Set(iType As Integer)
            m_iOrderType = iType
        End Set
    End Property


    Public Property StockNumber() As Single
        Get
            StockNumber = m_iStock
        End Get
        Set(iStock As Single)
            m_iStock = iStock
        End Set
    End Property


    Public Property ExitCost() As Single
        Get
            ExitCost = m_fExitCost
        End Get
        Set(fExitCost As Single)
            m_fExitCost = fExitCost
        End Set
    End Property

    Public Property EntryCost() As Single
        Get
            EntryCost = m_fEntryCost
        End Get
        Set(fEntryCost As Single)
            m_fEntryCost = fEntryCost
        End Set
    End Property

    Public Property OrderNumber() As String
        Get
            OrderNumber = m_sOrderNumber
        End Get
        Set(sOrderNumber As String)
            m_sOrderNumber = sOrderNumber
        End Set
    End Property

    Public Property iOrderNumber() As Integer
        Get
            OrderNumber = m_iOrderNumber
        End Get
        Set(iOrderNumber As Integer)
            m_iOrderNumber = iOrderNumber
        End Set
    End Property


    '卖出订单
    '输入:订单号(1或2)，卖价
    '输出：盈亏
    'Public Sub SellOrder(oOrder As COrder, fSellPrice As Single, fProLoss As Single, m_iStock As Integer)
    'Public Sub SellOrder(fSellPrice As Single, fProLoss As Single, iStock As Integer, sDate As String)

    Public Sub SellOrder(sOrderNumber As String, fSellPrice As Single, iStock As Integer, sDate As String)
        'iTransTotNum = iTransTotNum + 1 '记录交易次数 !!!!如何和总交易次数放在一起？

        '该段语句放到上一层更适合
        '    If fSellPrice > m_fEntryCost Then
        '        iTransPosNum = m_iTransPosNum + 1
        '    Else
        '        iTransNegNum = m_iTransNegNum + 1
        '    End If

        'fProLoss = (fSellPrice - m_fEntryCost) * m_iStock + fProLoss

        '卖出后，Order清空??
        m_sOrderNumber = sOrderNumber
        m_iStock = iStock

        'm_fEntryCost = 0 '?

        'm_bOrderClosed = True

        m_iOrderType = -1

        'OrderClosed

        m_fExitCost = fSellPrice

        m_sExitDate = CDate(sDate)

        '交易费计算，不到5元按5元计算，统一简化为千分之六

        m_fCommissionCost = GetCommisionCost(iStock, fSellPrice, True)


        '    If m_iOrderNumber = 1 Then
        '        Debug.Print "Order 1 Sold :" & m_fEntryCost
        '    ElseIf m_iOrderNumber = 2 Then
        '        Debug.Print "Order 2 Sold :" & m_fEntryCost
        '    End If

        Debug.Print("Order " & m_sOrderNumber & " Sold with Exit Cost " & m_fExitCost)

    End Sub

    '买入订单
    '输入：订单号(1或2)，买价
    '输出：
    'Public Sub BuyOrder(oOrder As COrder, fBuyPrice As Single, m_iStock As Integer)

    Public Sub BuyOrder(sOrderNumber As String, fBuyPrice As Single, iStock As Integer, sDate As String)

        m_sOrderNumber = sOrderNumber
        m_iOrderType = 1
        m_iStock = iStock
        m_fEntryCost = fBuyPrice '不考虑手续费
        m_sEntryDate = CStr(CDate(sDate))
        m_bOrderClosed = False

        '放入上一层判断，数据不要耦合
        'If fMaxiumPrice < fBuyPrice Then
        '    fMaxiumPrice = fBuyPrice    '计算最大持仓成本
        'End If

        m_fCommissionCost = GetCommisionCost(iStock, fBuyPrice, False)

        Debug.Print("Order " & m_sOrderNumber & " Placed with Entry Cost " & m_fEntryCost)

    End Sub



    Public Sub New()
        'm_bInStock = False  '初始持仓为0
        m_bOrderClosed = False
    End Sub


    Public Function GetCommisionCost(iStockNumbers As Integer, fUnitCost As Single, bSell As Boolean) As Single

        '           佣金                印花税          其它杂费如过户费
        '   卖出    0.002，不足按5元    按0.001         按0.001 ???
        '   买入    0.002，不足按5元    无              按0.001

        Dim fCommission As Single
        Dim fPrint As Single
        Dim fOtherCost As Single


        fCommission = 0.002 * iStockNumbers * fUnitCost

        If bSell Then
            fPrint = 0.001 * iStockNumbers * fUnitCost
        Else
            fPrint = 0
        End If

        fOtherCost = 0.001 * iStockNumbers * fUnitCost

        If fCommission < 5 Then
            fCommission = 5
        End If

        GetCommisionCost = fCommission + fPrint + fOtherCost

    End Function

End Class
