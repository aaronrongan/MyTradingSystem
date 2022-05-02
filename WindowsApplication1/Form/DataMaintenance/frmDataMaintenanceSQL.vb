Imports MyTradingSystem.DataBase
Imports MyTradingSystem.DataFeed
Imports MyTradingSystem.DataEntity
Public Class frmDataMaintenanceSQL

    Private WithEvents m_oDTStockInfo As DataEntity.CDTInfo_Stock
    Private WithEvents m_oDTStockDaily As DataEntity.CDTDaily_Stock
    Private WithEvents m_oDTIndexInfo As DataEntity.CDTInfo_Index
    Private WithEvents m_oDTFundInfo As DataEntity.CDTInfo_Fund
    Private WithEvents m_oDTFundCompany As DataEntity.CDTInfo_FundCompany
    Private WithEvents m_oDSPriceDaily As DataEntity.CDSDaily

    Dim sw As New Stopwatch
    Dim m_iProgress As Int32 = 1

    Private Sub btnDataFeed_Price_Click(sender As Object, e As EventArgs) Handles btnDataFeed_Price.Click

        Try

            Dim oDF As New DataFeed.CDataFeedTDX

            If rbtStockDaily.Checked And Len(txtAskedSymbol.Text) = 6 Then
                m_oDTStockDaily.Rows.Clear()
                m_oDTStockDaily = oDF.FeedStockDaily_General_TDX(txtAskedSymbol.Text)
                dgvDataList.DataSource = m_oDTStockDaily

                lblDGV_Total.Text = "共计" & dgvDataList.RowCount - 1 & "条记录"

            ElseIf rbtStockDaily_FA.Checked And Len(txtAskedSymbol.Text) = 6 Then
                m_oDTStockDaily.Rows.Clear()
                m_oDTStockDaily = oDF.FeedStockDaily_General_TDX(txtAskedSymbol.Text, EPriceAdjustedType.ForAdj)
                dgvDataList.DataSource = m_oDTStockDaily

            ElseIf rbtStockDaily.Checked And ckbAllSymbol.Checked Then '更新所有股票日线数据
                m_oDSPriceDaily = New CDSDaily_Stock
                sw.Start()
                prgBar.Value = 1
                prgBar.Minimum = 1
                prgBar.Maximum = 2900    '本应从数据库读取，这里因已知，直接写上数值

                BackgroundWorker1.RunWorkerAsync()

            ElseIf rbtIndexDaily.Checked And ckbAllSymbol.Checked Then '更新所有指数日线数据



                m_oDSPriceDaily = New CDSDaily_Index
                Dim sw As New Stopwatch
                sw.Start()
                m_oDSPriceDaily.UpgradeData()
                sw.Stop()

                MsgBox(" 本次采集共花费" & sw.ElapsedMilliseconds / 1000 & "秒")

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()
        m_oDTStockInfo = New DataEntity.CDTInfo_Stock()
        m_oDTIndexInfo = New DataEntity.CDTInfo_Index()
        m_oDTStockDaily = New DataEntity.CDTDaily_Stock()
        m_oDTFundInfo = New DataEntity.CDTInfo_Fund()
        m_oDTFundCompany = New DataEntity.CDTInfo_FundCompany()
        'm_oDSPriceDaily = New CDSDaily_Stock
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Private Sub txtAskedSymbol_TextChanged(sender As Object, e As EventArgs) Handles txtAskedSymbol.TextChanged
        Dim obj1 As CDTInfo

        If Len(txtAskedSymbol.Text) = 6 Then
            If rbtStockDaily.Checked Then
                obj1 = New DataEntity.CDTInfo_Stock
            ElseIf rbtIndexDaily.Checked Then
                obj1 = New DataEntity.CDTInfo_Index
            ElseIf rbtFundDaily.Checked Then
                obj1 = New DataEntity.CDTInfo_Fund
            End If

            txtStockName.Text = Trim(obj1.GetFullNamebySymbol(txtAskedSymbol.Text))

        End If
    End Sub

    Private Sub btnDataImportSQL_Click(sender As Object, e As EventArgs) Handles btnDataImportSQL.Click
        Try


            If rbtStockDaily.Checked = True And ckbAllSymbol.Checked = False Then
                If ckbAllSymbol.Checked = False Then '更新单个数据
                    'm_oDTStockDaily.Rows.Clear()
                    'm_oDTStockDaily.BulkInsertDatTable2SQL()   '不能用BulkInsert更新

                    'm_oDTStockDaily.

                Else '更新所有数据

                End If
            ElseIf rbtStockDaily.Checked And ckbAllSymbol.Checked Then
                CheckForIllegalCrossThreadCalls = False
                Dim newThread As New System.Threading.Thread(AddressOf ImportAllStockDaily)

                'Dim threadstart As New ThreadStart(AddressOf test)
                newThread.Start()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim dt As New CDTDaily_Stock

        'm_oDTStockDaily.GetDailyPricebySymbolfromSQL("000001")

        m_oDTStockDaily.Rows.Clear()
        Dim sw As New Stopwatch
        sw.Start()
        m_oDTStockDaily.UpdatePriceDailybySymbol2SQL(txtAskedSymbol.Text)
        sw.Stop()
        MsgBox("本次导入共花费" & sw.ElapsedMilliseconds / 1000 & "秒")

        'dgvDataList.Rows.Clear()
        Dim dv As New DataView(m_oDTStockDaily)
        dv.Sort = "TheDate ASC"
        dgvDataList.DataSource = dv

        'dgvDataList.Sort(3)
        'CDBDataBindingControl.BindDataGridView(dgvDataList, m_oDTStockDaily, False)
        lblDGV_Total.Text = "共计" & dgvDataList.RowCount - 1 & "条记录"

    End Sub

    Private Sub ImportAllStockDaily()
        Dim obj1 As New DataEntity.CDTInfo_Stock
        Dim lstSymbols As New List(Of String)

        Dim iStockTotalNumbers As Integer = obj1.GetAllSymbolList(lstSymbols)

        Dim iStockIndex As Integer, iOkCount As Integer = 0

        'iStockTotalNumbers = 1 ' 100
        Try


            prgBar.Minimum = 1
            prgBar.Maximum = iStockTotalNumbers
            prgBar.Value = 1
            Dim sw As New Stopwatch
            sw.Start()

            prgBar.Value = 1

            For iStockIndex = 0 To iStockTotalNumbers - 1
                Try
                    'Dim objDF As New DataFeed.CDataFeedTDX
                    'm_oDTStockDaily = objDF.FeedStockDaily_General_TDX(Trim(lstSymbols(iStockIndex))) ', CDate("2014-10-30"), CDate("2015-10-30"))
                    'iRowTotal = m_oDTStockDaily.Rows.Count

                    'If (m_oDTStockDaily.InsertTable2SQLbyRow(lstSymbols(iStockIndex), DataEntity.CDTDaily.EPriceAdjustedType.ForAdj) = True) Then
                    If (m_oDTStockDaily.UpdatePriceDailybySymbol2SQL(Trim(lstSymbols(iStockIndex)))) Then
                        iOkCount = iOkCount + 1
                        txtOutput.Text = txtOutput.Text & lstSymbols(iStockIndex) & "导入成功" & System.Environment.NewLine
                    Else
                        txtOutput.Text = txtOutput.Text & lstSymbols(iStockIndex) & "未能导入" & System.Environment.NewLine
                    End If
                    prgBar.Value = iStockIndex + 1

                    'objDF = Nothing
                Catch ex As Exception
                    '========为什么不能跨线程调用控件  CheckForIllegalCrossThreadCalls = False
                    txtOutput.Text = txtOutput.Text & lstSymbols(iStockIndex) & "未能导入" & System.Environment.NewLine
                End Try
            Next
            prgBar.Value = 1 '清零
            sw.Stop()
            MsgBox("本次导入共花费" & sw.ElapsedMilliseconds / 1000 & "秒。共有" & iStockTotalNumbers & "股票;本次共成功导入" & iOkCount & "股票价格信息")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnDataInfoImportSQL_Click(sender As Object, e As EventArgs) Handles btnDataInfoImportSQL.Click
        If rbtStockList.Checked Then
            Dim db As New CDTInfo_Stock

            db.UpgradeSecurityInfo_Full()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork


        'm_oDSPriceDaily.UpgradeData()      该语句为第一次大批量采集用
        m_oDSPriceDaily.FillDataMissingDays() '该语句为日常维护用

        BackgroundWorker1.ReportProgress(m_iProgress / 2900)

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        prgBar.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        sw.Stop()

        MsgBox(" 本次采集共花费" & sw.ElapsedMilliseconds / 1000 & "秒")
    End Sub

    Private Sub m_oDSPriceDaily_UpgradeProgress(iProgress As Integer) Handles m_oDSPriceDaily.UpgradeProgress
        m_iProgress = iProgress
    End Sub
End Class