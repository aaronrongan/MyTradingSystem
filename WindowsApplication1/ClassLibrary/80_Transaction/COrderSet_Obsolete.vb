Public Class COrderSet_Obsolete


    '订单集合

    '可以求出该订单中的盈亏


    Private m_colOrders As Collection

    '根据代码、日期，返回Order的集合
    Public Function GetOrdersByCode_Date(sCode As String, sDate As String) As Collection


    End Function

    '求出当前Order集的Profit/Loss
    Public Function GetProfitLoss(fCurrentCost As Single) As Single
        Dim i As Integer, j As Integer
        Dim oOrder As New COrder_Obsolete
        Dim fPL As Integer

        Dim fSinglePL As Single         '单次盈亏

        i = m_colOrders.Count

        If i = 0 Then
            MsgBox("记录为空!")
            Return -1
        End If

        For j = 1 To i
            oOrder = m_colOrders.Item(j)
            With oOrder
                If oOrder.OrderClosed = True Then
                    fSinglePL = (.ExitCost - .EntryCost) * .StockNumber - .CommissionCost
                    fPL = fPL + fSinglePL
                Else
                    If .OrderType = 1 Then '如果为买入订单，则计算浮动盈亏
                        fPL = fPL + (fCurrentCost - .EntryCost) * .StockNumber
                    End If
                End If

            End With
        Next

        GetProfitLoss = fPL

        oOrder = Nothing
    End Function

    '求出当前Order集的某股的Profit/Loss

    Public Function GetProfitLossbyOrderNumber(sOrderNumber As String, fCurrentCost As Single) As Single
        Dim i As Integer, j As Integer
        Dim oOrder As New COrder_Obsolete
        Dim fPL As Single   '
        'Dim bPositionEven As Boolean

        Dim iRemainingStocks As Integer
        Dim fActualPL As Single


        Dim iSellStockNumbers As Integer
        Dim iBuyStockNumbers As Integer

        'bPositionEven = True
        i = m_colOrders.Count
        iRemainingStocks = 0

        If i = 0 Then
            MsgBox("记录为空!")
            Exit Function
        End If

        For j = 1 To i
            oOrder = m_colOrders.Item(j)

            If oOrder.OrderNumber = sOrderNumber Then
                If oOrder.OrderType = 1 Then '买入型订单
                    iBuyStockNumbers = iBuyStockNumbers + oOrder.StockNumber

                    'bPositionEven = False
                    fPL = fPL - oOrder.EntryCost * oOrder.StockNumber - oOrder.CommissionCost

                    'iRemainingStocks = iRemainingStocks + iBuyStockNumbers

                ElseIf oOrder.OrderType = -1 Then '卖出型订单
                    iSellStockNumbers = iSellStockNumbers + oOrder.StockNumber
                    fPL = fPL + oOrder.ExitCost * oOrder.StockNumber - oOrder.CommissionCost
                    'iRemainingStocks = iRemainingStocks - iSellStockNumbers

                    'bPositionEven = True
                End If
            End If
        Next

        iRemainingStocks = iBuyStockNumbers - iSellStockNumbers

        If iRemainingStocks < 0 Then
            MsgBox("剩余股数小于0，程序错误！")
            Exit Function
        ElseIf iRemainingStocks = 0 Then
            GetProfitLossbyOrderNumber = fPL
        Else

            '扣除最后一次的买入费用重新计算fActualPL实际盈亏
            fActualPL = fPL + iRemainingStocks * oOrder.EntryCost

            '持仓单位成本 = 盈余资金 / 剩余股份
            '浮动盈亏=(现有单价价位-最后一笔成本)*剩余股份
            GetProfitLossbyOrderNumber = fActualPL + (fCurrentCost - oOrder.EntryCost) * iRemainingStocks
        End If

        oOrder = Nothing

    End Function

    '根据当前Order集求出测试结果

    Public Sub GetSystemTestResult(oSTR As CSystemTR, fCurrentPrice As Single)

        Dim i As Integer, j As Integer
        Dim oOrder As New COrder_Obsolete
        Dim fPL As Integer
        Dim iPosNumbers As Integer
        Dim iNegNumbers As Integer
        Dim fMaxiumEntryPrice As Single
        Dim fMaxiumProfit As Single     '单次最大盈利
        Dim fMaxiumLoss As Single       '单次最大亏损
        Dim fSinglePL As Single         '单次盈亏

        i = m_colOrders.Count

        If i = 0 Then
            MsgBox("记录为空!")
            Exit Sub
        End If

        For j = 1 To i
            oOrder = m_colOrders.Item(j)
            With oOrder
                If oOrder.OrderClosed = True Then
                    fSinglePL = (.ExitCost - .EntryCost) * .StockNumber - .CommissionCost

                    If fSinglePL > 0 Then
                        iPosNumbers = iPosNumbers + 1
                        If fMaxiumProfit < fSinglePL Then
                            fMaxiumProfit = fSinglePL
                        End If
                    Else
                        iNegNumbers = iNegNumbers + 1
                        If fMaxiumLoss > fSinglePL Then
                            fMaxiumLoss = fSinglePL
                        End If
                    End If

                    fPL = fPL + fSinglePL

                    '计算最大的成本
                    If fMaxiumEntryPrice < .EntryCost Then
                        fMaxiumEntryPrice = .EntryCost
                    End If

                    '如果没有平仓，计算浮动盈亏
                Else
                    If oOrder.OrderType = 1 Then '如果为买入订单，计算浮动盈亏
                        fPL = fPL + (fCurrentPrice - oOrder.EntryCost) * oOrder.StockNumber
                    End If
                End If

            End With
        Next

        '计算总交易天数、盈利天数、亏损天数等数据"
        oSTR.CommissionCost = GetAllCommissionCost
        oSTR.TransTotNum = m_colOrders.Count
        oSTR.TransPosNum = iPosNumbers
        oSTR.TransNegNum = iNegNumbers
        oSTR.TransTotNum = iPosNumbers + iNegNumbers
        oSTR.TotalProLos = fPL
        If fMaxiumEntryPrice <> 0 And oOrder.StockNumber <> 0 Then
            oSTR.PLPercent = fPL / (fMaxiumEntryPrice * 2 * oOrder.StockNumber) '!!!有问题，StockNumber如果每次不一样，如何计算？算每次盈利的平均数？
        Else
            oSTR.PLPercent = -1
        End If
        oSTR.MaxiumProfit = fMaxiumProfit
        oSTR.MaxiumLoss = fMaxiumLoss
        If oSTR.FirstDayCost <> 0 Then
            oSTR.StockVarPercent = (oSTR.LastDayCost - oSTR.FirstDayCost) / oSTR.FirstDayCost
        Else
            MsgBox("oSTR.FirstDayCost不能为0")
        End If

        oOrder = Nothing

    End Sub

    Public Property OrderSet() As Collection
        Get
            OrderSet = m_colOrders
        End Get
        Set(colOrders As Collection)
            m_colOrders = colOrders
        End Set
    End Property

    Public Sub New()
        m_colOrders = New Collection
    End Sub

    Public Function GetAllCommissionCost() As Single
        Dim i As Integer, j As Integer
        Dim oOrder As New COrder_Obsolete
        Dim fCommissionCost As Single

        i = m_colOrders.Count

        If i = 0 Then
            MsgBox("记录为空!")
            Exit Function
        End If

        For j = 1 To i
            oOrder = m_colOrders.Item(j)
            fCommissionCost = fCommissionCost + oOrder.CommissionCost
        Next
        GetAllCommissionCost = fCommissionCost
    End Function

    '搜索现有的Order集，对一个现有的同OrderNumber的Order进行平仓
    Public Sub CloseOrder(sOrderNumber As String, fSellPrice As Single, iStock As Integer, sDate As String)

        Dim i As Integer, j As Integer
        Dim oOrder As New COrder_Obsolete

        i = m_colOrders.Count

        If i = 0 Then
            MsgBox("记录为空!")
            Exit Sub
        End If

        For j = 1 To i
            oOrder = m_colOrders.Item(j)
            If oOrder.OrderNumber = sOrderNumber And oOrder.OrderClosed = False Then
                If oOrder.StockNumber = iStock Then
                    oOrder.OrderType = 0
                    oOrder.ExitCost = fSellPrice
                    Debug.Print(sDate)
                    oOrder.ExitDate = CDate(sDate)
                    '交易费为之前的买入交易费+本次的卖出交易费
                    oOrder.CommissionCost = oOrder.CommissionCost + oOrder.GetCommisionCost(iStock, fSellPrice, True)
                    oOrder.OrderClosed = True
                Else
                    MsgBox("卖出和买入仓位不相等，可能会产生错误。请检查程序。")
                End If

            End If

        Next

        Debug.Print("Order " & sOrderNumber & " Closed with Exit Cost " & fSellPrice)

    End Sub



End Class
