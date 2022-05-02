Imports System.Threading
Imports MyTradingSystem.DataBase
Imports MyTradingSystem.DataEntity
Imports MyTradingSystem.DataFeed
Imports MyTradingSystem.DataExport
Imports System.Data.SqlClient

Public Class frmDataInsertSQL
    Private m_sArray As String(,)
    Private WithEvents m_oDTStockInfo As DataEntity.CDTInfo_Stock
    Private WithEvents m_oDTStockDaily As DataEntity.CDTDaily_Stock
    Private WithEvents m_oDTIndexDaily As DataEntity.CDTDaily_Index
    Private WithEvents m_oDTFundDaily As DataEntity.CDTDaily_Fund
    Private WithEvents m_oDTIndexInfo As DataEntity.CDTInfo_Index
    Private WithEvents m_oDTFundInfo As DataEntity.CDTInfo_Fund
    Private WithEvents m_oDTFundCompany As DataEntity.CDTInfo_FundCompany
    Private WithEvents m_oDSPrice As DataEntity.CDSDaily


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles ckbAllSymbol.CheckedChanged
        If ckbAllSymbol.Checked = True Then
            txtAskedSymbol.Enabled = False
            txtAskedSymbol.Text = ""
        Else
            txtAskedSymbol.Enabled = True
            txtAskedSymbol.Text = ""
        End If
    End Sub

    Private Sub btnDataInfoFeed_Click(sender As Object, e As EventArgs) Handles btnDataInfoFeed.Click
        'Dim oDF As New CDataFeedWeb

        Dim iRow, iCol As Integer, iTotalRow As Integer, iTotalCol As Integer

        If rbtStockList.Checked = True Then     '采集股票列表

            ' Dim obj1 As New DataEntity.CDataInfo_Stock

            dgvDataList.Rows.Clear()
            If m_oDTStockInfo.Rows.Count > 0 Then
                m_oDTStockInfo.Rows.Clear()
            End If

            Dim oDF = New CDataFeedWeb_StockInfo

            m_sArray = oDF.GetStockCodeList()

            iTotalCol = m_sArray.GetUpperBound(0)
            iTotalRow = m_sArray.GetUpperBound(1)

            '用m_sArray给DataTable赋值，仅限2个字段：Symbol+FullName
            For iRow = 0 To iTotalRow - 1
                Try
                    Dim oRow As DataRow = m_oDTStockInfo.NewRow()
                    For iCol = 1 To iTotalCol
                        oRow.Item(iCol) = m_sArray(iCol - 1, iRow)
                    Next
                    m_oDTStockInfo.Rows.Add(oRow)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next
            CDBDataBindingControl.BindDataGridView(dgvDataList, m_oDTStockInfo, False)
            lblDGV_Total.Text = "共计" & dgvDataList.RowCount - 1 & "条记录"

        ElseIf rbtFundList.Checked = True Then      '采集基金数据，3个字段：Symbol+FullName+Type

            m_oDTFundInfo.Rows.Clear()

            Dim dt As New DataTable
            m_oDTFundCompany.GetFundCompanyListfromSQL(dt)
            prgDGV.Minimum = 1
            prgDGV.Maximum = dt.Rows.Count
            dt = Nothing

            'CheckForIllegalCrossThreadCalls = False
            'Dim newThread As New System.Threading.Thread(AddressOf FeedAllFundInfo)
            'newThread.Start()
            '''''''''''''''''''''''''
            m_oDTFundInfo.Rows.Clear()
            Dim sw As New Stopwatch
            sw.Start()
            m_oDTFundInfo.FeedAllFundsInfofromWeb_EasyMoney()
            sw.Stop()

            dgvDataList.DataSource = m_oDTFundInfo

            lblDGV_Total.Text = "共计" & dgvDataList.RowCount - 1 & "条记录;" & " 本次采集共花费" & sw.ElapsedMilliseconds / 1000 & "秒"

            '''''''''''''''''''''''''


            'If oDF.GetFundList(m_oDTFundInfo) = True Then
            '    CDBDataBindingControl.BindDataGridView(dgvDataList, m_oDTFundInfo, False)
            '    lblDGV_Total.Text = "共计" & dgvDataList.RowCount - 1 & "条记录"
            'End If


        ElseIf rbtIndexList.Checked = True Then     '采集指数列表，仅限2个字段：Symbol+FullName

            dgvDataList.Rows.Clear()
            If m_oDTIndexInfo.Rows.Count > 0 Then
                m_oDTIndexInfo.Rows.Clear()
            End If

            'Dim obj1 As New DataBase.CDBSQLManipulate_IndexList

            Dim obj1 As New DataEntity.CDataInfo_Index
            Dim oDF = New CDataFeedWeb_IndexInfo
            oDF = New CDataFeedWeb_IndexInfo

            m_sArray = oDF.GetIndexList()

            iTotalCol = m_sArray.GetUpperBound(0)
            iTotalRow = m_sArray.GetUpperBound(1)

            '用m_sArray给DataTable赋值
            For iRow = 0 To iTotalRow - 1
                Try
                    Dim oRow As DataRow = m_oDTIndexInfo.NewRow()
                    For iCol = 1 To iTotalCol
                        oRow.Item(iCol) = m_sArray(iCol - 1, iRow)
                    Next

                    m_oDTIndexInfo.Rows.Add(oRow)
                Catch ex As Exception
                    'MsgBox(ex.Message)
                End Try
            Next

            CDBDataBindingControl.BindDataGridView(dgvDataList, m_oDTIndexInfo, False)
            lblDGV_Total.Text = "共计" & dgvDataList.RowCount - 1 & "条记录"

        ElseIf rbtFundCompany.Checked = True Then     '采集基金公司列表，

            dgvDataList.Rows.Clear()
            If m_oDTFundCompany.Rows.Count > 0 Then
                m_oDTFundCompany.Rows.Clear()
            End If

            'Dim obj1 As New DataBase.CDBSQLManipulate_IndexList
            Dim obj1 As New DataEntity.CDTInfo_FundCompany

            Dim oDF As New CDataFeedWeb_FundInfo
            oDF.GetFundCompanyInfo(m_oDTFundCompany)
            'm_sArray = oDF.GetIndexList()

            'iTotalCol = m_sArray.GetUpperBound(0)
            'iTotalRow = m_sArray.GetUpperBound(1)

            '用m_sArray给DataTable赋值
            'For iRow = 0 To iTotalRow - 1
            '    Try
            '        Dim oRow As DataRow = m_oDTIndexInfo.NewRow()
            '        For iCol = 1 To iTotalCol
            '            oRow.Item(iCol) = m_sArray(iCol - 1, iRow)
            '        Next

            '        m_oDTIndexInfo.Rows.Add(oRow)
            '    Catch ex As Exception
            '        'MsgBox(ex.Message)
            '    End Try
            'Next

            CDBDataBindingControl.BindDataGridView(dgvDataList, m_oDTFundCompany, False)
            lblDGV_Total.Text = "共计" & dgvDataList.RowCount - 1 & "条记录"

            ' ElseIf rbtFundList.Checked Then

            'm_oDTFundInfo.
        End If

        'oDF = Nothing
        'oDB = Nothing
    End Sub

    'Private Sub btnDataImportSQL_Click_Obsolete(sender As Object, e As EventArgs) 'Handles btnDataImportSQL.Click
    '    txtOutput.Text = ""

    '    Dim sOutput As String = ""
    '    Dim iRow As Integer, iRowTotal As Integer

    '    If rbtStockList.Checked = True Then
    '        Dim obj1 As New DataEntity.CDataInfo_Stock

    '        iRowTotal = m_sArray.GetUpperBound(1)
    '        prgBar.Minimum = 1
    '        prgBar.Maximum = iRowTotal
    '        prgBar.Value = 1
    '        For iRow = 0 To iRowTotal - 1
    '            obj1.InsertStockInfo(m_sArray(0, iRow), m_sArray(1, iRow))
    '        Next
    '        obj1 = Nothing
    '    ElseIf rbtIndexList.Checked = True Then
    '        Dim obj1 As New DataEntity.CDataInfo_Index

    '        iRowTotal = m_sArray.GetUpperBound(1)
    '        prgBar.Minimum = 1
    '        prgBar.Maximum = iRowTotal
    '        prgBar.Value = 1
    '        For iRow = 0 To iRowTotal - 1
    '            obj1.InsertIndexInfo(m_sArray(0, iRow), m_sArray(1, iRow))
    '            sOutput = sOutput & iRow + 1 & "," & m_sArray(0, iRow) & "," & m_sArray(1, iRow) & System.Environment.NewLine
    '            prgBar.Value = iRow + 1
    '        Next
    '        obj1 = Nothing

    '    End If

    '    txtOutput.Text = sOutput

    'End Sub

    Private Sub btnDataPriceImportSQL_Click(sender As Object, e As EventArgs) Handles btnDataPriceImportSQL.Click
        Try


            Dim strSymbol(0) As String

            'To be Done: 多只股票(非1只或全部)的填入
            If ckbAllSymbol.Checked = True Then ' 所有股票基金指数的遍历 
                strSymbol(0) = ""
            Else '单支股票基金指数
                If txtAskedSymbol.Text = "" Or Len(txtAskedSymbol.Text) <> 6 Then
                    MsgBox("代码为空")
                    Exit Sub
                Else    '导出单个股票日线数据
                    strSymbol(0) = txtAskedSymbol.Text
                End If
            End If

            If rbtStockDaily.Checked Then
                m_oDSPrice = New CDSDaily_Stock

            ElseIf rbtFundDaily.Checked Then
                m_oDSPrice = New CDSDaily_Fund

            ElseIf rbtIndexDaily.Checked Then
                m_oDSPrice = New CDSDaily_Index
            End If


            m_oDSPrice.FilterDataTables(strSymbol)    '必须先过滤一次
            If m_oDSPrice.SymbolNumbers >= 1 Then
                prgDGV.Minimum = 1
                prgDGV.Maximum = m_oDSPrice.SymbolNumbers

                'm_oDSPrice.BulkInsertDataTables(DataFeed.CDataFeedBASE.DataFeedType.TDX)
                CheckForIllegalCrossThreadCalls = False
                Dim newThread As New System.Threading.Thread(AddressOf Thread_BulkInsertStockDaily)
                newThread.Start()

            Else
                MsgBox("没有Symbol")
            End If

        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' 导入所有基金信息信息到SQL，为单独线程调用
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FeedAllFundInfo()
        m_oDTFundInfo.Rows.Clear()
        Dim sw As New Stopwatch
        sw.Start()
        m_oDTFundInfo.FeedAllFundsInfofromWeb_EasyMoney()
        sw.Stop()
        dgvDataList.DataSource = m_oDTFundInfo

        lblDGV_Total.Text = "共计" & dgvDataList.RowCount - 1 & "条记录;" & " 本次采集共花费" & sw.ElapsedMilliseconds / 1000 & "秒"
    End Sub


    ''' <summary>
    ''' 导入所有股票价格信息到SQL，为单独线程调用
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Thread_BulkInsertStockDaily()
        Dim sw As New Stopwatch
        sw.Start()
        m_oDSPrice.BulkInsertDataTables()
        dgvDataList.DataSource = m_oDSPrice.CurrentDataTable '显示当前对象的数据表DataTable
        sw.Stop()
        MsgBox(String.Format("本次导入共花费{0}秒", sw.ElapsedMilliseconds / 1000))
    End Sub

    ''' <summary>
    ''' 导入所有股票价格信息到SQL，为单独线程调用
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ImportAllStockDaily()
        Dim obj1 As New DataEntity.CDataInfo_Stock
        Dim lstSymbols As New List(Of String)
        'Dim strOutput As String
        Dim iRowTotal As Integer
        Dim iStockTotalNumbers As Integer = obj1.GetAllSymbols(lstSymbols)

        Dim iStockIndex As Integer, iOkCount As Integer = 0

        'iStockTotalNumbers = 1 ' 100

        prgBar.Minimum = 1
        prgBar.Maximum = iStockTotalNumbers
        prgBar.Value = 1
        Dim sw As New Stopwatch
        sw.Start()

        For iStockIndex = 0 To iStockTotalNumbers - 1
            Try
                Dim objDF As New DataFeed.CDataFeedTDX
                m_oDTStockDaily = objDF.FeedStockDaily_General_TDX(Trim(lstSymbols(iStockIndex))) ', CDate("2014-10-30"), CDate("2015-10-30"))
                iRowTotal = m_oDTStockDaily.Rows.Count

                prgBar.Value = 1
                'If (m_oDTStockDaily.InsertTable2SQLbyRow(lstSymbols(iStockIndex), DataEntity.CDTDaily.EPriceAdjustedType.ForAdj) = True) Then
                If (m_oDTStockDaily.BulkInsertDataTable2SQL()) Then
                    iOkCount = iOkCount + 1
                    txtOutput.Text = txtOutput.Text & lstSymbols(iStockIndex) & "导入成功" & System.Environment.NewLine
                Else
                    txtOutput.Text = txtOutput.Text & lstSymbols(iStockIndex) & "未能导入" & System.Environment.NewLine
                End If
                prgBar.Value = iStockIndex + 1

                objDF = Nothing
            Catch ex As Exception
                '========为什么不能跨线程调用控件  CheckForIllegalCrossThreadCalls = False
                txtOutput.Text = txtOutput.Text & lstSymbols(iStockIndex) & "未能导入" & System.Environment.NewLine
            End Try
        Next
        prgBar.Value = 1 '清零
        sw.Stop()
        MsgBox("本次导入共花费" & sw.ElapsedMilliseconds / 1000 & "秒。共有" & iStockTotalNumbers & "股票;本次共成功导入" & iOkCount & "股票价格信息")
    End Sub
    Private Sub btnGetStockFullName_Click(sender As Object, e As EventArgs) Handles btnGetStockFullName.Click
        'Dim obj1 As New DataBase.CDBSQLManipulate_StockList
        Dim obj1 As New DataEntity.CDTInfo_Stock
        txtStockName.Text = obj1.GetFullNamebySymbol(txtAskedSymbol.Text)

    End Sub

    Private Sub txtStockName_TextChanged(sender As Object, e As EventArgs) Handles txtStockName.TextChanged

        'If Len(txtStockName.Text) >= 4 Then
        '    Dim obj1 As New DataEntity.CDTInfo_Stock

        '    txtAskedSymbol.Text = obj1.GetStockSymbolbyFullName(txtStockName.Text)
        'End If
    End Sub
    Private Sub txtAskedSymbol_TextChanged(sender As Object, e As EventArgs) Handles txtAskedSymbol.TextChanged
        If Len(txtAskedSymbol.Text) = 6 Then
            If rbtStockDaily.Checked Then
                Dim obj1 As New DataEntity.CDTInfo_Stock
                txtStockName.Text = obj1.GetFullNamebySymbol(txtAskedSymbol.Text)
            ElseIf rbtIndexDaily.Checked Then
                Dim obj1 As New DataEntity.CDTInfo_Index
                txtStockName.Text = obj1.GetFullNamebySymbol(txtAskedSymbol.Text)
            ElseIf rbtFundDaily.Checked Then
                Dim obj1 As New DataEntity.CDTInfo_Fund
                txtStockName.Text = obj1.GetFullNamebySymbol(txtAskedSymbol.Text)
            End If
        End If
    End Sub

    Public Sub New()

        m_oDTStockInfo = New DataEntity.CDTInfo_Stock()
        m_oDTIndexInfo = New DataEntity.CDTInfo_Index()
        m_oDTStockDaily = New DataEntity.CDTDaily_Stock()
        m_oDTFundDaily = New DataEntity.CDTDaily_Fund()
        m_oDTIndexDaily = New DataEntity.CDTDaily_Index()
        m_oDTFundInfo = New DataEntity.CDTInfo_Fund()
        m_oDTFundCompany = New DataEntity.CDTInfo_FundCompany()
        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Private Sub frmDataImportSQL_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub m_oDTStockInfo_InsertProgress(iProgress As Integer) Handles m_oDTStockInfo.InsertProgress

        prgBar.Value = iProgress

        txtOutput.Text = txtOutput.Text & iProgress + 1 & "," & m_sArray(0, iProgress) & "," & m_sArray(1, iProgress) & System.Environment.NewLine
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim oDT As New DataEntity.CDTInfo_Stock
        'Dim obj As New DataBase.CDBDataBindingControl

        oDT.GetWholeTable()
        dgvDataList.DataSource = oDT
        'CDBDataBindingControl.BindDataGridView(dgvDataList, oDT.GetWholeTable(), False)

    End Sub

    '这个函数利用了多态功能，写的很简洁，可以对多个类型进行查询!!!!!很漂亮
    Private Sub btnDataPriceFeed_Click(sender As Object, e As EventArgs) Handles btnDataPriceFeed.Click
        Try

            Dim strSymbol(0) As String

            'To be Done: 多只股票(非1只、非全部)的填入
            If ckbAllSymbol.Checked = True Then ' 所有股票基金指数的遍历 
                strSymbol(0) = ""
                'dtsPrice.FilterDataTables()
                'dtsPrice.FeedDataTablesPrice(DataFeed.CDataFeedBASE.DataFeedType.TDX)
            Else '单支股票基金指数
                If txtAskedSymbol.Text = "" Or Len(txtAskedSymbol.Text) <> 6 Then
                    MsgBox("代码为空")
                    Exit Sub
                Else    '导出单个股票日线数据

                    strSymbol(0) = txtAskedSymbol.Text
                End If
            End If


            If rbtStockDaily.Checked Then
                m_oDSPrice = New CDSDaily_Stock

            ElseIf rbtFundDaily.Checked Then
                m_oDSPrice = New CDSDaily_Fund

            ElseIf rbtIndexDaily.Checked Then
                m_oDSPrice = New CDSDaily_Index
            End If

            m_oDSPrice.FilterDataTables(strSymbol)    '必须先过滤一次
            If m_oDSPrice.SymbolNumbers >= 1 Then
                prgDGV.Minimum = 1
                prgDGV.Maximum = m_oDSPrice.SymbolNumbers
                m_oDSPrice.FeedDataTablesPrice(EDataFeedType.TDX)
            Else
                MsgBox("没有Symbol")
            End If

            dgvDataList.DataSource = m_oDSPrice.CombinedAllDataTable
            lblDGV_Total.Text = "共计" & dgvDataList.RowCount - 1 & "条记录"

        Catch ex As Exception

        End Try

    End Sub

    Private Sub m_oDTStockDaily_InsertProgress(iProgress As Integer) Handles m_oDTStockDaily.InsertProgress
        prgBar.Value = iProgress

        'txtOutput.Text = txtOutput.Text & iProgress + 1 & "," & m_sArray(0, iProgress) & "," & m_sArray(1, iProgress) & System.Environment.NewLine
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs)
        'WebBrowser1.Url. = "www.sohu.com"
        'Debug.Print(WebBrowser1.Document.Body.InnerHtml)
        'WebBrowser1.Document.
    End Sub

    Private Sub m_oDTFundInfo_InsertProgress(iProgress As Integer) Handles m_oDTFundInfo.InsertProgress
        prgDGV.Value = iProgress
    End Sub


    Private Sub m_oDSPrice_FeedProgress(iProgress As Integer) Handles m_oDSPrice.FeedProgress
        prgDGV.Value = iProgress
    End Sub

    Private Sub m_oDSPrice_InsertProgress(iProgress As Integer) Handles m_oDSPrice.InsertProgress
        prgDGV.Value = iProgress
    End Sub

    Private Sub btnDataInfoImportSQL_Click(sender As Object, e As EventArgs) Handles btnDataInfoImportSQL.Click
        txtOutput.Text = ""

        Dim sOutput As String = ""
        Dim iRow As Integer, iRowTotal As Integer
        Dim sw As New Stopwatch
        Dim oDT As CDTInfo

        If rbtStockList.Checked = True Then     '导入股票列表
            'oDT = New CDTInfo_Stock
            'iRowTotal = m_sArray.GetUpperBound(1)

            'For iRow = 0 To iRowTotal - 1
            'sOutput = sOutput & iRow + 1 & "," & m_sArray(0, iRow) & "," & m_sArray(1, iRow) & System.Environment.NewLine
            'Next

            sw.Start()
            If m_oDTStockInfo.Rows.Count = 0 Then
            Else
                m_oDTStockInfo.Rows.Clear()
            End If
            'm_oDTStockInfo.BulkInsertDatTable2SQL()    针对网页数据抓取的数据
            'm_oDTStockInfo.UpgradeSecurityInfo_Simple()    针对通联数据中的证券通用信息的导入
            m_oDTStockInfo.UpgradeSecurityInfo_Full()       '针对通联数据中的股票项信息的导入


            sw.Stop()
            MsgBox(String.Format("本次导入共花费{0}秒", sw.ElapsedMilliseconds / 1000))

        ElseIf rbtFundList.Checked = True Then     '导入基金列表
            Dim bFlagSucceed As Boolean = False
            sw.Start()
            bFlagSucceed = m_oDTFundInfo.BulkInsertDatTable2SQL()
            sw.Stop()
            If bFlagSucceed Then
                MsgBox(String.Format("本次导入共花费{0}秒", sw.ElapsedMilliseconds / 1000))
            Else
                MsgBox("本次导入不成功")
            End If

        ElseIf rbtFundCompany.Checked = True Then     '导入基金公司列表

            Dim bFlagSucceed As Boolean = False
            sw.Start()
            bFlagSucceed = m_oDTFundCompany.BulkInsertDatTable2SQL()
            sw.Stop()
            If bFlagSucceed Then
                MsgBox(String.Format("本次导入共花费{0}秒", sw.ElapsedMilliseconds / 1000))
            Else
                MsgBox("本次导入不成功")
            End If

        ElseIf rbtIndexList.Checked = True Then     '导入指数列表数据
            iRowTotal = m_sArray.GetUpperBound(1)
            prgBar.Minimum = 1
            prgBar.Maximum = iRowTotal
            prgBar.Value = 1
            For iRow = 0 To iRowTotal - 1
                sOutput = sOutput & iRow + 1 & "," & m_sArray(0, iRow) & "," & m_sArray(1, iRow) & System.Environment.NewLine
                prgBar.Value = iRow + 1
            Next
            sw.Start()
            m_oDTIndexInfo.BulkInsertDatTable2SQL()
            sw.Stop()
            MsgBox("本次导入共用" & sw.ElapsedMilliseconds / 1000 & "秒")

            'ElseIf rbtStockDaily.Checked = True And m_oDTStockDaily.Columns.Count > 0 And ckbAllSymbol.Checked = False Then '导入单支股票数据
            '    iRowTotal = m_oDTStockDaily.Rows.Count
            '    prgBar.Minimum = 1
            '    prgBar.Maximum = iRowTotal
            '    prgBar.Value = 1
            '    m_oDTStockDaily.InsertTable2SQLbyRow(txtAskedSymbol.Text, DataEntity.CDTDaily.EPriceAdjustedType.ForAdj)

            'ElseIf (ckbAllSymbol.Checked = True And rbtStockDaily.Checked) Then    '将所有股票价格信息导入数据库
            '    'prgBar.CheckForIllegalCrossThreadCalls
            '    CheckForIllegalCrossThreadCalls = False
            '    Dim newThread As New System.Threading.Thread(AddressOf ImportAllStockDaily)

            '    'Dim threadstart As New ThreadStart(AddressOf test)
            '    newThread.Start()

        ElseIf rbtTradeCalendar.Checked Then
            'Dim dt As New DataTable
            'Dim dfDY As New CDataFeedDatayes_General
            'Dim db As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
            'dt = dfDY.GetTradeCalendarDataTable()
            'db.BulkInsertDataTable(dt, "TradeCalendar")

            CDTInfo_General.BulkInsertTradeCalendar()

        ElseIf rbtSecurityType.Checked Then
            Dim dt As New DataTable
            Dim dfDY As New CDataFeedDatayes_General
            dt = dfDY.GetSecurityTypeDataTable()
            dgvDataList.DataSource = dt
            CDTInfo_General.BulkInsertSecuritiesTypeInfo()

        ElseIf rbtSecurityInfo.Checked Then
            If txtSecuritySymbol.Text <> "" Then    '查询个股信息
                Dim dt As New DataTable
                Dim df As New CDataFeedDatayes_General
                dt = df.FeedSecurityInfoDataTable(, txtSecuritySymbol.Text)
                dgvDataList.DataSource = dt
                'm_oDTStockInfo.BulkInsertDatTable2SQL()

            End If

        ElseIf rbtSecurityTypeRelation.Checked Then
            Dim dt As New DataTable
            Dim df As New CDataFeedDatayes_General
            If txtSecurityTypeID.Text <> "" Then    '查询、插入板块下成分股信息

                dt = df.FeedSecurityTypeRelationDataTable(, , txtSecurityTypeID.Text)
                CDTInfo_General.BulkInsertSecuritiesTypeRelation(txtSecurityTypeID.Text)
                dgvDataList.DataSource = dt
            Else '查询、插入所有板块成分

                CDTInfo_General.BulkInsertAllSecuritiesTypeRelation()
            End If
        End If

        txtOutput.Text = sOutput
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim dfDY As New CDataFeedDatayes_General
        'Dim dfDY As New CDataFeedDatayes_Price
        'Dim dfDY As New CDataFeedDatayes_IndexInfo

        'Dim dt As New DataTable

        Try
            'dt = dfDY.FeedIndexInfoDataTable()
            'dgvDataList.DataSource = dt

            Dim gm As New CDataFeedGoldMiner

            gm.GetData()

            '''''''''''''''''''''''UpdateCommand Test''''''''''''''''''''''''''
            'Dim conn As SqlConnection = New SqlConnection(GlobalVariables.gSQLConnectionString)
            'Dim adapter As New System.Data.SqlClient.SqlDataAdapter()
            'Dim strCommand As String

            'strCommand = "Update StockInfo Set SecurityID=@SecurityID Where Symbol='000001'"
            'Dim Command As SqlCommand = New SqlCommand(strCommand, conn)
            'Command.Parameters.Add("@SecurityID", SqlDbType.NChar, 15, "SecurityID")

            'adapter.UpdateCommand = Command

            'Dim dt As New CDTInfo_Stock
            'dt.GetWholeTable()
            'Dim datarow() As DataRow
            'ReDim datarow(0)

            'datarow(0) = dt.Rows(0)
            'datarow(0).Item("SecurityID") = "111112"

            'adapter.Update(datarow)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class