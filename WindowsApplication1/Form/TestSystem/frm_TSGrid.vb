Imports MyTradingSystem.DataBase
Imports MyTradingSystem.DataFeed




Public Class frm_TSGrid

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '交易测试结果

        Dim oPS As New CPositionRules        '仓位管理策略

        Dim iRow As Integer, j As Integer

        Dim iTestNumber As Integer
        Dim sStartDate As String
        Dim sEndDate As String

        Dim strDataFilePath As String
        Dim sOutputString1 As String
        Dim sOutputString2 As String

        sOutputString1 = "股票代码,总交易天数,总交易次数,盈利次数,亏损次数,总盈亏(含交易费),最高单次盈利,最高单次亏损,盈利比例,测试期间股价变动,交易费,交易结果" ' 首行

        iTestNumber = Me.txt_Numbers.Value
        sStartDate = Me.dtp_StartDate.Value.Date
        sEndDate = Me.dtp_EndDate.Value.Date

        Dim iCount As Int16 = 0
        For iCount = 1 To 1

            If CheckBox1.Checked = True Then
                Dim oSTR As New CStrategy_TestResult
                Dim oOrderSets As New CDataTableOrder     '交易订单集合
                Dim oGrid As New CStrategy_Grid
                Dim oFileRW As New CDBTxt
                Dim oDFT As New CDataFeedTDX
                Dim oPriceDataTable As New CDTDaily_Stock_Collection  '日线价格数据
                'Dim oPriceDataTable As New DataEntity.CDTDaily_Stock  '日线价格数据

                Dim sFileName As String = GlobalVariables.GetStockCodePrePostfix(txt_Code1.Text, GlobalVariables.EDataFeedSource.TDX_FQ) & txt_Code1.Text & ".txt"
                strDataFilePath = GlobalVariables.g_TDXPath_Daily_FA & "\" & sFileName

                '1-取得PriceData
                'oPriceDataTable = oDFT.FeedStockDaily_TDX(txt_Code1.Text)

                If oPriceDataTable.FilterDataTablebyDate(sStartDate, sEndDate, iTestNumber) = False Then
                    MsgBox("Filter数据出错")
                    Exit Sub
                End If

                '2.网格计算
                oGrid.GridCalculate(oPriceDataTable, oPS, oOrderSets, oSTR)
                sOutputString1 = sOutputString1 & System.Environment.NewLine

                '3.结果放置
                sOutputString1 = sOutputString1 & txt_Code1.Text

                oSTR.Print2String(sOutputString1)
                rtxt1.Text = sOutputString1
                Dim sOut() As String = Split(sOutputString1, System.Environment.NewLine)
                CUtility.WriteLog(sOut)

                '4.打印所有历史订单
                Dim m As Integer, n As Integer
                m = oOrderSets.OrderSet.Count

                sOutputString2 = "订单序号" & ", " & "买入日期" & ", " & "买入成本" & ", " & "卖出日期" & ", " & "卖出成本" & ", " & "盈亏" & "，" & "最新成本" & System.Environment.NewLine

                '显示发生的订单买卖日期
                For n = 1 To m
                    sOutputString2 = sOutputString2 & n

                    sOutputString2 = sOutputString2 & ", " & oOrderSets.OrderSet(n).EntryDate()
                    sOutputString2 = sOutputString2 & ", " & oOrderSets.OrderSet(n).EntryCost

                    If oOrderSets.OrderSet(n).OrderClosed = True Then
                        sOutputString2 = sOutputString2 & ", " & oOrderSets.OrderSet(n).ExitDate
                        sOutputString2 = sOutputString2 & ", " & oOrderSets.OrderSet(n).ExitCost
                        sOutputString2 = sOutputString2 & ", " & FormatNumber((oOrderSets.OrderSet(n).ExitCost - oOrderSets.OrderSet(n).EntryCost) * oOrderSets.OrderSet(n).StockNumber, 2)
                        sOutputString2 = sOutputString2 & ", " & "-" & System.Environment.NewLine
                    Else
                        sOutputString2 = sOutputString2 & ", " & "未卖出"
                        sOutputString2 = sOutputString2 & ", " & "未卖出"
                        sOutputString2 = sOutputString2 & ", " & "(浮动盈亏)" & FormatNumber((oSTR.LastDayCost - oOrderSets.OrderSet(n).EntryCost) * oOrderSets.OrderSet(n).StockNumber, 2)
                        sOutputString2 = sOutputString2 & ", " & oSTR.LastDayCost & System.Environment.NewLine
                    End If

                Next
                rtxt2.Text = sOutputString2

                'Debug.Print(sOutputString1)

                oSTR = Nothing
                oOrderSets = Nothing
                oGrid = Nothing
                oFileRW = Nothing
                oPriceDataTable = Nothing

            End If
        Next

        '4.Object关闭
    End Sub




End Class

