Public Class CStrategy_TestResult
    ' Option Explicit

    '测试结果类，可以从CDataOrderSet中推导。本类其实就是一个UDT，做类似乎多余，但为了兼容以后的VB.net，于是做成类形式

    Private m_iTransDays As Integer      '总交易天数
    Private m_iTransTotNum As Integer      '总交易次数
    Private m_iTransPosNum As Integer     '总盈利次数
    Private m_iTransNegNum As Integer               '总亏损次数
    Private m_fTotalProLos As Single                 '总盈亏(含交易费)
    Private m_fTotalProLos_NoCommiss As Single       '总盈亏(不含交易费)
    Private m_fCommissionCost As Single             '所有的交易费用
    Private m_fPLPercent As Single                 '盈亏比例

    Private m_fStockVarPercent As Single          '测试期间股价变动

    Private m_oOrderSet As CDataTableOrder        '测试期间发生的订单集合

    Private m_fMaxiumProfit As Single       '单次最大盈利
    Private m_fMaxiumLoss As Single         '单次最大亏损

    Private m_fFirstDayCost As Single      '第一天的股价
    Private m_fLastDayCost As Single       '最后一天的股价

    Public Property LastDayCost() As Single
        Get
            LastDayCost = m_fLastDayCost
        End Get

        Set(fLastDayCost As Single)
            m_fLastDayCost = fLastDayCost
        End Set
    End Property

    Public Property FirstDayCost() As Single
        Get
            FirstDayCost = m_fFirstDayCost
        End Get

        Set(fFirstDayCost As Single)
            m_fFirstDayCost = fFirstDayCost
        End Set
    End Property

    Public Property MaxiumLoss() As Single
        Get
            MaxiumLoss = m_fMaxiumLoss
        End Get

        Set(fMaxiumLoss As Single)
            m_fMaxiumLoss = fMaxiumLoss
        End Set
    End Property

    Public Property MaxiumProfit() As Single
        Get
            MaxiumProfit = m_fMaxiumProfit
        End Get

        Set(fMaxiumProfit As Single)
            m_fMaxiumProfit = fMaxiumProfit
        End Set
    End Property

    Public Property OrderSet() As CDataTableOrder
        Get
            OrderSet = m_oOrderSet
        End Get

        Set(oOrderSet As CDataTableOrder)
            m_oOrderSet = oOrderSet
        End Set
    End Property

    Public Property StockVarPercent() As Single
        Get
            StockVarPercent = m_fStockVarPercent
        End Get

        Set(fStockVarPercent As Single)
            m_fStockVarPercent = fStockVarPercent
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

    Public Property PLPercent() As Single
        Get
            PLPercent = m_fPLPercent
        End Get

        Set(fPLPercent As Single)
            m_fPLPercent = fPLPercent
        End Set
    End Property

    Public Property TotalProLos() As Single
        Get
            TotalProLos = m_fTotalProLos
        End Get

        Set(fTotalProLos As Single)
            m_fTotalProLos = fTotalProLos
        End Set
    End Property

    Public Property TotalProLos_NoCommiss() As Single
        Get
            TotalProLos_NoCommiss = m_fTotalProLos_NoCommiss
        End Get

        Set(fTotalProLos_NoCommiss As Single)
            m_fTotalProLos_NoCommiss = fTotalProLos_NoCommiss
        End Set
    End Property

    Public Property TransNegNum() As Integer
        Get
            TransNegNum = m_iTransNegNum
        End Get

        Set(iTransNegNum As Integer)
            m_iTransNegNum = iTransNegNum
        End Set
    End Property

    Public Property TransPosNum() As Integer
        Get
            TransPosNum = m_iTransPosNum
        End Get

        Set(iTransPosNum As Integer)
            m_iTransPosNum = iTransPosNum
        End Set
    End Property

    Public Property TransDays() As Integer
        Get
            TransDays = m_iTransDays
        End Get

        Set(iTransDays As Integer)
            m_iTransDays = iTransDays
        End Set
    End Property

    Public Property TransTotNum() As Integer
        Get
            TransTotNum = m_iTransTotNum
        End Get

        Set(iTransTotNum As Integer)
            m_iTransTotNum = iTransTotNum
        End Set
    End Property

    Public Sub Print2String(ByRef sOutputString As String)

        sOutputString = sOutputString & "," & Me.TransDays
        sOutputString = sOutputString & "," & Me.TransTotNum
        sOutputString = sOutputString & "," & Me.TransPosNum
        sOutputString = sOutputString & "," & Me.TransNegNum
        sOutputString = sOutputString & "," & Me.TotalProLos
        sOutputString = sOutputString & "," & FormatNumber(Me.MaxiumProfit, 2)
        sOutputString = sOutputString & "," & FormatNumber(Me.MaxiumLoss, 2)
        sOutputString = sOutputString & "," & FormatPercent(Me.PLPercent, 2)
        sOutputString = sOutputString & "," & FormatPercent(Me.StockVarPercent, 2)
        sOutputString = sOutputString & "," & Me.CommissionCost
        If Me.PLPercent < Me.StockVarPercent Then
            sOutputString = sOutputString & "," & "Bad"
        Else
            sOutputString = sOutputString & "," & "Good"
        End If
        sOutputString = sOutputString & System.Environment.NewLine
    End Sub
End Class
