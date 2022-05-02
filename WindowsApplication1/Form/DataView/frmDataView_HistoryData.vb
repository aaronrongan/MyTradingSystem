Imports MyTradingSystem.Indicator
Imports MyTradingSystem.Strategy
Imports MyTradingSystem.DataBase
Imports MyTradingSystem.DataEntity
Imports MyTradingSystem.Trade
Imports MyTradingSystem.DataFeed
Imports Steema.TeeChart

Public Class frmDataView_HistoryData

    Private m_tcm As CTeeChartManaged
    'Private m_DTDaily As CDTDaily_Stock
    Private m_DTDaily As CDTDaily

    Private m_CurrentSymbol As String
    Private m_CurrentSymbolType As String

    'Private m_indicatorSets As Dictionary(Of EIndicatorName, CIndicator)  'CIndicatorSets
    'Private m_idcplotSMA As CIndicatorPlotAxTchart_SMA 'CIndicator_SMA3
    Private m_idcSMA As CIndicator_SMA
    Private m_idcSMA2 As CIndicator_SMA2
    Private m_idcSMA3 As CIndicator_SMA3
    Private m_idcCustom As CIndicator       '自定义显示的Indicator
    Private m_pat As EPriceAdjustedType     '复权标志
    Private m_SMATag As Integer             '显示单根、双根、三根均线
    Private m_ShowSMA As Boolean = True
    Private m_PeriodType As EHistoryDataPeriodType = EHistoryDataPeriodType.Daily

    Private m_FormInitialized As Boolean = False

    'Private m_compressOHLC1 As Steema.TeeChart.Functions.CompressOHLC

    Private m_tsCurrent As CStrategy      '自定义当前显示的TradingStrategy
    Private m_tsList() As CStrategy      '自定义显示的TradingStrategy组合

    '窗体状态
    Private m_State As CDataView_State  'frmDataView_State        '状态
    Private m_StateInitial As New CDataView_State_Initial(Me)
    Private m_StateUnchanged As New CDataView_State_Unchanged(Me)
    Private m_StateSymbolDateChanged As New CDataView_State_SymbolDateChanged(Me)
    Private m_State_SymbolTypeChanged As New CDataView_State_SymbolTypeChanged(Me)

    Private m_StateMA_PARAChanged As New CDataView_State_MA_PARAChanged(Me)
    Private m_StateCUSTIDC_Name_Changed As New CDataView_State_CUSTIDC_NAME_Chnaged(Me)
    Private m_StateCUSTIDC_Para_Changed As New CDataView_State_CUSTIDC_PAPRA_Changed(Me)
    Private m_State_SMAShow As New CDataView_State_SMAShow(Me)
    Private m_State_SMAHide As New CDataView_State_SMAHide(Me)




    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()
        m_FormInitialized = True

        m_tcm = New CTeeChartManaged
        m_DTDaily = New CDTDaily_Stock
        m_idcSMA = New CIndicator_SMA
        m_idcSMA2 = New CIndicator_SMA2
        m_idcSMA3 = New CIndicator_SMA3
        m_CurrentSymbolType = "Stock"       '默认为股票
        m_CurrentSymbol = "000001"            '默认为平安银行

        'm_compressOHLC1 = New Functions.CompressOHLC

        'Candle1.Function = m_compressOHLC1

        'Candle1.RecalcOptions = CType((((Steema.TeeChart.Styles.RecalcOptions.OnDelete Or Steema.TeeChart.Styles.RecalcOptions.OnModify) _
        '    Or Steema.TeeChart.Styles.RecalcOptions.OnInsert) _
        '    Or Steema.TeeChart.Styles.RecalcOptions.OnClear), Steema.TeeChart.Styles.RecalcOptions)

        'm_StateInitial = New CDataView_State_Initial(Me)


        'm_State = m_StateInitial

        'm_idcCustom = New CIndicator
        'm_SMALine1 = New Steema.TeeChart.Styles.Line(Candle1.Chart)


    End Sub

 
    Private Sub FillIndicatorListBox()

        Dim names() As String = CType([Enum].GetNames(GetType(EIndicatorName)), String())

        For Each na In names
            ListBox1.Items.Add(na.ToString)
        Next
        ListBox1.SelectedIndex = 0

    End Sub

    Private Sub FillStragetyListBox()
        Dim names() As String = CType([Enum].GetNames(GetType(EStrategyName)), String())
        For Each na In names
            ListBox2.Items.Add(na.ToString)
        Next
        ListBox2.SelectedIndex = 1  '默认SMA2策略
    End Sub

    Private Sub frmDataView_StockHistoryData_2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtp_StartDate.Text = Today().AddDays(-150)
        dtp_EndDate.Text = Today()

       
        FillIndicatorListBox()
        FillStragetyListBox()
        FillCandleStyleCombox()
        FillDataPeriodCombox()

        FillSymbolListBox()

        SetState(m_StateInitial)
        m_State.Enter()
        SetState(m_StateUnchanged)

        'If m_DataTableStockDaily.Rows.Count > 0 Then
        '    'FillCandleChart()
        '    'FillVolumeChart()
        '    ''FillCustomIndicatorChart()       '默认显示MACD指标



        '    '起始自定义指标设置为SMA ,以后应该改为MACD
        '    m_idcCustom = CIndicatorFactory.CreateIndicator(EIndicatorName.SMA, m_DataTableStockDaily)
        '    m_idcCustom.SetParameters(EPriceType.Close, nudPeriod.Value)

        '    'If Not IsNothing(m_idcCustom) Then
        '    'm_idcCustom.PlotAxTChart(Line1.Chart, 2)
        '    'End If

        '    'm_State.HandleEvent(frmDataView_State.EfrmDataView_Events.INITIAL)

        '    m_State.Enter()
        '    SetState(m_StateUnchanged)
        'End If



    End Sub
    ''' <summary>
    ''' 填充代码列表
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FillSymbolListBox()

        Dim LastSymbol As String
        '前次留存的Symbol
        LastSymbol = txtSymbol_.Text
        txtSymbol_.Items.Clear()

        If Len(LastSymbol) > 0 Then
            If m_State Is m_State_SymbolTypeChanged Then

            Else
                txtSymbol_.Items.Add(LastSymbol)
            End If
        End If

        Dim listFavoriteSymbol As List(Of String)

        If rbtBond.Checked Then
            'SymbolType = "Bond"
            m_CurrentSymbolType = "Bond"
            listFavoriteSymbol = CDataFeedCSV.GetFavoriteList("Bond")
        ElseIf rbtFund.Checked Then
            m_CurrentSymbolType = "Fund"
            listFavoriteSymbol = CDataFeedCSV.GetFavoriteList("Fund")
        ElseIf rbtIndex.Checked Then
            m_CurrentSymbolType = "Index"
            listFavoriteSymbol = CDataFeedCSV.GetFavoriteList("Index")
        Else
            m_CurrentSymbolType = "Stock"
            listFavoriteSymbol = CDataFeedCSV.GetFavoriteList("Stock")
        End If


        'Console.WriteLine(listSymbol.Count)
        For Each symbol As String In listFavoriteSymbol
            '如果Favorite列表中的Symbol不与上次留存的一样，就加入，否则不加入
            If symbol.Split(",")(0) <> LastSymbol Then
                txtSymbol_.Items.Add(symbol.Split(",")(0) & " " & symbol.Split(",")(1))
            End If
            'txtSymbol_.Items.
            'txtSymbolShortName_.Items.Add(symbol.Split(",")(1))
        Next

        txtSymbol_.SelectedIndex = 0


    End Sub
    ''' <summary>
    ''' 获取当前的价格数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDataCounts() As Integer
        Return m_DTDaily.GetCompressDT(m_PeriodType).Rows.Count
    End Function
    Public Sub FeedData()
        '获取价格数据
        'm_DTDaily.GetDataTablePrice(txtSymbol.Text, dtp_StartDate.Text, dtp_EndDate.Text)

        Dim Symbol As String
        Symbol = txtSymbol_.Text

        If Symbol.Length >= 6 Then
            Symbol = Symbol.Substring(0, 6)
            m_DTDaily.GetDataTablePrice(Symbol, dtp_StartDate.Text, dtp_EndDate.Text)

            m_DTDaily.RemoveSilentPrice()

            m_pat = EPriceAdjustedType.ForAdj
        End If
    End Sub
    Private Sub FillCandleStyleCombox()
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Items.AddRange(New Object() {"Stick", "Bar", "Open Close", "Line"})
        'Me.ComboBox1.Location = New System.Drawing.Point(187, 9)
        'Me.ComboBox1.Name = "comboBox1"
        'Me.ComboBox1.Size = New System.Drawing.Size(100, 21)
        Me.ComboBox1.SelectedIndex = 0

    End Sub

    Private Sub FillDataPeriodCombox()
        Me.ComboBox2.Items.AddRange(New Object() {"Daily", "Weekly", "Monthly", "Bi-monthly", "Quarterly", "Yearly"})
        'Me.ComboBox2.Location = New System.Drawing.Point(168, 9)
        Me.ComboBox2.Name = "comboBox2"
        'Me.ComboBox2.Size = New System.Drawing.Size(146, 21)
        Me.ComboBox2.TabIndex = 1
        'Me.ComboBox2.Text = "Daily"
        Me.ComboBox2.SelectedIndex = 0




    End Sub

    Friend Sub FillCandleChart()
        'Candle1.FillSampleValues()

        'm_idcSMA = New CIndicator_SMA(m_DataTableStockDaily)
        'm_idcSMA3 = New CIndicator_SMA3(m_DataTableStockDaily)

        'm_idcSMA.SetParameters(EPriceType.Close, 3)
        'm_idcSMA3.SetParameters(EPriceType.Close, 3, 10, 15)

        'm_tcm.InitCandleGraph(Candle1)
        'm_tcm.AddCandlePrice(Candle1, m_DataTableStockDaily, EPriceAdjustedType.ForAdj)


        'm_idcSMA3.PlotAxTChart(Candle1)


        Candle1.Clear()


        Try


            Dim labels As New Styles.StringList
            Dim dv As New Styles.ValueList

            Dim iCount As Integer = 0
            If Not IsNothing(m_DTDaily) Then

                With Candle1
                    ' VIP ---这里代码太长，要重写，简洁，最好用一个通用接口，直接将数据赋值给.Add
                    For Each row As DataRow In m_DTDaily.GetCompressDT(m_PeriodType).Rows
                        Dim openprice, highprice, lowprice, closeprice As Double

                        '此处为重构代码，将'===中的代码重写，清楚很多
                        m_DTDaily.SetPriceAdjustedType(m_pat)
                        'TODO VIP 这里的代码要修改
                        With m_DTDaily.GetCompressDT(m_PeriodType)
                            openprice = .GetOpenPrice(iCount)
                            highprice = .GetHighPrice(iCount)
                            lowprice = .GetLowPrice(iCount)
                            closeprice = .GetClosePrice(iCount)
                        End With
                        'openprice = m_DTDaily.GetCompressDT(m_PeriodType).GetOpenPrice(iCount)
                        'highprice = m_DTDaily.GetCompressDT(m_PeriodType).GetHighPrice(iCount)
                        'lowprice = m_DTDaily.GetCompressDT(m_PeriodType).GetLowPrice(iCount)
                        'closeprice = m_DTDaily.GetCompressDT(m_PeriodType).GetClosePrice(iCount)
                        '================================================================
                        'If m_pat = EPriceAdjustedType.Normal Then

                        '    openprice = row.Item("OpenPrice")
                        '    highprice = row.Item("HighPrice")
                        '    lowprice = row.Item("LowPrice")
                        '    closeprice = row.Item("ClosePrice")


                        'ElseIf m_pat = EPriceAdjustedType.ForAdj Then

                        '    If IsDBNull(row.Item("OpenPrice_FA")) Then
                        '        openprice = row.Item("ActPreClosePrice")  '("OpenPrice")
                        '        highprice = openprice 'row.Item("HighPrice")
                        '        lowprice = openprice 'row.Item("LowPrice")
                        '        closeprice = openprice 'row.Item("OpenPrice") 'row.Item("ClosePrice")
                        '    ElseIf row.Item("OpenPrice_FA") = 0 Then
                        '        openprice = row.Item("ActPreClosePrice")  '("OpenPrice")
                        '        highprice = openprice 'row.Item("HighPrice")
                        '        lowprice = openprice 'row.Item("LowPrice")
                        '        closeprice = openprice '
                        '    Else
                        '        openprice = row.Item("OpenPrice_FA")
                        '        highprice = row.Item("HighPrice_FA")
                        '        lowprice = row.Item("LowPrice_FA")
                        '        closeprice = row.Item("ClosePrice_FA")
                        '    End If


                        'ElseIf m_pat = EPriceAdjustedType.BacAdj Then

                        '    If IsDBNull(row.Item("OpenPrice_BA")) Then
                        '        openprice = openprice
                        '        highprice = openprice
                        '        lowprice = openprice
                        '        closeprice = openprice
                        '    ElseIf row.Item("OpenPrice_BA") = 0 Then
                        '        openprice = row.Item("ActPreClosePrice")  '("OpenPrice")
                        '        highprice = openprice 'row.Item("HighPrice")
                        '        lowprice = openprice 'row.Item("LowPrice")
                        '        closeprice = openprice '
                        '    Else
                        '        openprice = row.Item("OpenPrice_BA")
                        '        highprice = row.Item("HighPrice_BA")
                        '        lowprice = row.Item("LowPrice_BA")
                        '        closeprice = row.Item("ClosePrice_BA")
                        '    End If

                        'End If
                        '================================================================
                        .Add(iCount, openprice, highprice, lowprice, closeprice)
                        '.Add(CDate(row.Item("TheDate")), openprice, highprice, lowprice, closeprice)
                        '.XValues(iCount) = CDate(row.Item("TheDate")).ToOADate

                        '.YValues(iCount).=
                        '.Add(CDate("2015-12-1").AddDays(iCount), openprice, highprice, lowprice, closeprice)
                        'Debug.Print(CDate("2015-12-1").AddDays(iCount))
                        labels.Add(CDate(row.Item("TheDate")).ToShortDateString)
                        '.Marks.Style=
                        iCount += 1
                    Next

                    .GetHorizAxis.Labels.Angle = 90

                    .Labels = labels

                End With
            End If
            'Candle2 = Candle1

            ' PlotSMA()
            'FillMovingAverage()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Friend Sub FillMovingAverage()
        CleanAllMALines()




        If rdoSMA.Checked Then

            m_idcSMA = CIndicatorFactory.CreateIndicator(EIndicatorName.SMA, m_DTDaily.GetCompressDT(m_PeriodType))
            m_idcSMA.SetParameters(nudPeriod.Value)
            m_idcSMA.PlotAxTChart(Candle1.Chart, 0)

        ElseIf rdoSMA2.Checked Then

            m_idcSMA2 = CIndicatorFactory.CreateIndicator(EIndicatorName.SMA2, m_DTDaily.GetCompressDT(m_PeriodType))
            m_idcSMA2.SetParameters(nudPeriodFast2.Value, nudPeriodSlow2.Value)
            m_idcSMA2.PlotAxTChart(Candle1.Chart, 0)

        ElseIf rdoSMA3.Checked Then

            m_idcSMA3 = CIndicatorFactory.CreateIndicator(EIndicatorName.SMA3, m_DTDaily.GetCompressDT(m_PeriodType))
            m_idcSMA3.SetParameters(nudPeriodFast3.Value, nudPeriodMid3.Value, nudPeriodSlow3.Value)
            m_idcSMA3.PlotAxTChart(Candle1.Chart, 0)

        End If

        If CheckBox2.Checked Then
            ShowSMALines()
        Else
            HideSMALines()
        End If

    End Sub

    Friend Sub ShowSMALines()
        If Not IsNothing(m_idcSMA) Then
            m_idcSMA.Show()
        End If
        If Not IsNothing(m_idcSMA2) Then
            m_idcSMA2.Show()
        End If
        If Not IsNothing(m_idcSMA3) Then
            m_idcSMA3.Show()
        End If
    End Sub

    Friend Sub HideSMALines()
        If Not IsNothing(m_idcSMA) Then
            m_idcSMA.Hide()
        End If
        If Not IsNothing(m_idcSMA2) Then
            m_idcSMA2.Hide()
        End If
        If Not IsNothing(m_idcSMA3) Then
            m_idcSMA3.Hide()
        End If
    End Sub

    ''' <summary>
    ''' '将价格线之外的均线全部删除
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub CleanAllMALines()

        If Not IsNothing(m_idcSMA) Then
            m_idcSMA.RemoveAxTChart(Candle1.Chart)
        End If

        If Not IsNothing(m_idcSMA2) Then
            m_idcSMA2.RemoveAxTChart(Candle1.Chart)
        End If

        If Not IsNothing(m_idcSMA3) Then
            m_idcSMA3.RemoveAxTChart(Candle1.Chart)
        End If


    End Sub

    ''' <summary>
    ''' '将价格线之外的均线全部删除
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub ClearCustomIndicatorChart()

        '考虑一般性(比如布林带同时在Candle1、Indicator 3上，将自定义指标从1、3图上都要删除
        If Not IsNothing(m_idcCustom) Then
            'm_idcCustom.RemoveAxTChart(Candle1.Chart)
            m_idcCustom.RemoveAxTChart(Line1.Chart)
        End If

        '布林带显示在价格图上，也要删除
        'If ListBox1.SelectedIndex = EIndicatorName.BBand Then
        '    m_idcCustom.RemoveAxTChart(Candle1.Chart)
        'End If

    End Sub

    ''' <summary>
    ''' '将价格线之外的均线全部删除
    ''' 算法有问题，删除时总会漏删或出错
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CleanAllSeriesexceptCandle()
        Dim iCount As Int16 = 0
        Dim s() As Styles.Series
        ReDim s(Candle1.Chart.CountActiveSeries - 3)

        Dim iRemovedCount As Int16 = 0

        '
        For iCount = 0 To Candle1.Chart.CountActiveSeries - 1
            'Candle1.Chart.Series.RemoveAt(iCount)
            Dim SeriesString As String = Candle1.Chart.Item(iCount).ToString
            If SeriesString <> Volume1.ToString AndAlso SeriesString <> Candle1.ToString AndAlso SeriesString <> Line1.ToString Then
                'MsgBox(Candle1.Chart.Item(iCount).ToString)
                s(iRemovedCount) = Candle1.Chart.Series(iCount)
                iRemovedCount += 1
            End If
        Next

        For iCount = 0 To iRemovedCount - 1

        Next

        'For Each item In Candle1.Chart.Series.

        'Next


    End Sub
    'Private Sub PlotSMA()

    '    Dim SMALine1 As New Steema.TeeChart.Styles.Line(TChart1.Chart)
    '    SMALine1.CustomVertAxis = Candle1.GetVertAxis
    '    SMALine1.Clear()

    '    Dim idc As New CIndicator_SMA(m_DataTableStockDaily)
    '    idc.SetParameters(EPriceType.Close, 10)

    '    Dim iCount As Integer = 1

    '    With SMALine1
    '        For Each row As DataRow In idc.Rows
    '            If row(1) <> -1 Then
    '                .Add(row(1))
    '            End If
    '            iCount += 1
    '        Next

    '    End With

    '    'SMALine1.Title = "Product10 Stock"
    '    SMALine1.Color = Color.Red

    'End Sub
    Friend Sub FillVolumeChart()
        'Volume1.FillSampleValues()
        Volume1.Clear()

        Try

            Volume1.Marks.Visible = False

            Dim min As Double = 1.0E+20
            Dim max As Double = 0
            Dim value As Double = 0
            Dim volume As Double
            Dim iCount As Int16 = 0
            If Not IsNothing(m_DTDaily) Then


                With m_DTDaily.GetCompressDT(m_PeriodType)
                    For Each row As DataRow In .Rows
                        Try
                            '这里也需要重构
                            '此处为重构代码，将'===中的代码重写，清楚很多


                            m_DTDaily.SetPriceAdjustedType(EPriceAdjustedType.Normal)
                            volume = .GetVolume(iCount)
                            Volume1.Add(volume)
                            'Debug.Print(volume)
                            '========================================================
                            'If m_pat = EPriceAdjustedType.Normal Then
                            '    If Not IsDBNull(row.Item("TurnoverVolume")) Then
                            '        'value = row.Item("TurnoverVolume")
                            '        .Add(row.Item("TurnoverVolume"))
                            '    End If
                            'ElseIf m_pat = EPriceAdjustedType.ForAdj Then
                            '    'If Not IsDBNull(row.Item("TurnoverVolume_FA")) Then
                            '    '    'value = row.Item("TurnoverVolume_FA")
                            '    '    .Add(row.Item("TurnoverVolume_FA"))
                            '    'End If
                            '    'VIP Volume类没有前复权之分？
                            '    If Not IsDBNull(row.Item("TurnoverVolume")) Then
                            '        .Add(row.Item("TurnoverVolume"))
                            '    End If
                            'ElseIf m_pat = EPriceAdjustedType.BacAdj Then
                            '    'If Not IsDBNull(row.Item("TurnoverVolume_BA")) Then
                            '    'value = row.Item("TurnoverVolume_BA")
                            '    .Add(row.Item("TurnoverVolume_BA"))
                            '    'End If
                            'End If
                            '========================================================

                            If min > value Then
                                min = value
                            End If
                            If max < value Then
                                max = value
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                        iCount += 1
                    Next
                End With
                

                'chart.Axis.Left.SetMinMax(min - (max - min) * 0.2, max + (max - min) * 0.2)
                'End With
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Friend Sub SetState(state As CDataView_State)
        m_State = state
    End Sub
    Friend Sub FillCustomIndicatorChart(Optional bDefaultPara As Boolean = True)


        ClearCustomIndicatorChart()


        '这里用到了设计模式中的简单工厂模式
        m_idcCustom = CIndicatorFactory.CreateIndicator(ListBox1.SelectedIndex, m_DTDaily.GetCompressDT(m_PeriodType))
        

        If Not IsNothing(m_idcCustom) Then
            If bDefaultPara = True Then
                m_idcCustom.SetDefaultParameters()
                '布林带绘制在chart 0上，和价格信息同时显示
                If ListBox1.SelectedIndex = EIndicatorName.BBand Then
                    m_idcCustom.PlotAxTChart(Line1.Chart, 0)
                    'm_idcCustom.PlotAxTChart(Line1.Chart, 2)
                Else
                    m_idcCustom.PlotAxTChart(Line1.Chart, 2)
                End If

            Else
                m_idcCustom.PopWindowParameterPlot(Line1.Chart, 2, EPriceAdjustedType.ForAdj)

            End If
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'CleanAllSeriesexceptCandle()        '将Candle1、Volume1、Line1之外的线全部删除



        '获取价格数据
        'm_DTDaily.GetDataTablePrice(txtSymbol.Text, dtp_StartDate.Text, dtp_EndDate.Text)
        'm_DTDaily.RemoveSilentPrice()
        If rbtStock.Checked Then
            m_DTDaily = New CDTDaily_Stock
        ElseIf rbtIndex.Checked Then
            m_DTDaily = New CDTDaily_Index
        ElseIf rbtFund.Checked Then
            m_DTDaily = New CDTDaily_Fund
        End If

        'VIP TODO 这里的代码要修改，为什么2次执行FeedData()，因为进入状态时又抓取一次数据
        FeedData()

        If m_DTDaily.GetCompressDT(m_PeriodType).Rows.Count > 0 Then
            m_State.Enter()
            SetState(m_StateUnchanged)
            'FillCandleChart()

            'FillVolumeChart()

            'BUG: 如果日期变换，才需要更改自定义指标栏，如果只是参数变，应该不动自定义指标栏。并且只有开始才需要设置，以后不应该弹出参数设置对话框。
            '用事件来解决？
            'FillCustomIndicatorChart()
        End If




    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        If CheckBox1.Checked Then
            m_pat = EPriceAdjustedType.ForAdj
        Else
            m_pat = EPriceAdjustedType.Normal
        End If

    End Sub

    ' processDirtyStateEvent(int)
    ' Set current state and perform entry actions for the state
    'Private Sub gotoState(ByVal newState As Integer)
    '    Select Case newState
    '        Case frmDataView_State.EfrmDataView_Events.UNCHANGED

    '        Case FILE_DIRTY

    '        Case BOTH_DIRTY

    '        Case PARAM_DIRTY

    '    End Select
    '    state = newState



    Private Sub SymbolDate_ValueChanged(sender As Object, e As EventArgs) Handles dtp_StartDate.ValueChanged, dtp_EndDate.ValueChanged
        SetState(m_StateSymbolDateChanged)

        'txtSymbolShortName.Text = GetSecurityShortName()
        ''m_State.Enter()
        ''SetState(m_StateUnchanged)
    End Sub


    Private Sub nudPeriod_ValueChanged(sender As Object, e As EventArgs) Handles nudPeriod.ValueChanged, nudPeriodSlow2.ValueChanged, nudPeriodFast3.ValueChanged, _
        nudPeriodMid3.ValueChanged, nudPeriodFast2.ValueChanged, nudPeriodSlow3.ValueChanged

        SetState(m_StateMA_PARAChanged)
        'm_State.Enter()
        'SetState(m_StateUnchanged)
    End Sub


    Private Sub rdoSMA2_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSMA.CheckedChanged, rdoSMA2.CheckedChanged, rdoSMA3.CheckedChanged
        CheckBox2.Checked = True
        SetState(m_StateMA_PARAChanged)
        'm_State.Enter()
        'SetState(m_StateUnchanged)
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

        '逻辑关系有问题，切换不同的均线类型和可视性时，会多出几条均线
        If m_FormInitialized Then
            If CheckBox2.Checked Then
                'If Not IsNothing(m_idcSMA) Then
                '    m_idcSMA.Show()
                'End If
                'If Not IsNothing(m_idcSMA2) Then
                '    m_idcSMA2.Show()
                'End If
                'If Not IsNothing(m_idcSMA3) Then
                '    m_idcSMA3.Show()
                'End If
                m_ShowSMA = True

                SetState(m_State_SMAShow)
                m_State.Enter()
                SetState(m_StateUnchanged)
            Else
                'If Not IsNothing(m_idcSMA) Then
                '    m_idcSMA.Hide()
                'End If
                'If Not IsNothing(m_idcSMA2) Then
                '    m_idcSMA2.Hide()
                'End If
                'If Not IsNothing(m_idcSMA3) Then
                '    m_idcSMA3.Hide()
                'End If
                m_ShowSMA = False

                SetState(m_State_SMAHide)
                m_State.Enter()
                SetState(m_StateUnchanged)
            End If
        End If


    End Sub
  
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        FillCustomIndicatorChart()
    End Sub

 

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        FillCustomIndicatorChart(False)
    End Sub


    Friend Sub FillStrategySignal()
        RemoveStrategySignal()

        m_tsCurrent = CStrategyFactory.CreateStrategy(ListBox2.SelectedIndex, m_DTDaily.GetCompressDT(m_PeriodType))
        m_tsCurrent.PopWindowParameterPlot(Candle1, 0)

        'm_tsCurrent.SetDefaultParameters()
        'm_tsCurrent.PlotAxTChart(Candle1, 0)

    End Sub

    Friend Sub RemoveStrategySignal()
        If Not IsNothing(m_tsCurrent) Then
            m_tsCurrent.Clear()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click


        'Dim trade As New CQuantTrade_BT_001()
        'trade.Init(m_DataTableStockDaily)
        ' trade.Run()
        FillStrategySignal()

       
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Candle1.Style = CType(ComboBox1.SelectedIndex, Styles.CandleStyles)


    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        'Candle1.Function = m_compressOHLC1

        'Select Case ComboBox2.SelectedIndex
        '    Case 0
        '        m_compressOHLC1.Compress = Steema.TeeChart.Functions.CompressionPeriod.ocDay
        '    Case 1
        '        m_compressOHLC1.Compress = Steema.TeeChart.Functions.CompressionPeriod.ocWeek
        '    Case 2
        '        m_compressOHLC1.Compress = Steema.TeeChart.Functions.CompressionPeriod.ocMonth
        '    Case 3
        '        m_compressOHLC1.Compress = Steema.TeeChart.Functions.CompressionPeriod.ocBiMonth
        '    Case 4
        '        m_compressOHLC1.Compress = Steema.TeeChart.Functions.CompressionPeriod.ocQuarter
        '    Case 5
        '        m_compressOHLC1.Compress = Steema.TeeChart.Functions.CompressionPeriod.ocYear
        'End Select

        m_PeriodType = ComboBox2.SelectedIndex
        SetState(m_StateSymbolDateChanged)
    End Sub

   

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        RemoveStrategySignal()
    End Sub

    ' ''' <summary>
    ' ''' 对股票而言，要看的都是前复权数据
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
    '    'm_bForAdjusted = CheckBox1.Checked

    '    'If m_FormInitialized Then 'Me.created
    '    '    If m_bForAdjusted Then
    '    '        m_DataTableStockDaily.SetPriceAdjustedType(EPriceAdjustedType.ForAdj)
    '    '    Else
    '    '        m_DataTableStockDaily.SetPriceAdjustedType(EPriceAdjustedType.Normal)
    '    '    End If
    '    '    SetState(m_StateSymbolDateChanged)
    '    '    m_State.Enter()
    '    '    SetState(m_StateUnchanged)
    '    'End If



    'End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        '导出当前图表数据(价格、均线)为CVS格式

        'm_DTDaily.GetCompressDT(m_PeriodType).WriteXml("D:\1.xml")
        DataGridView1.DataSource = m_DTDaily.GetCompressDT(m_PeriodType)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim trade As New CQuantTrade_BT_001
        trade.Init(m_DTDaily.GetCompressDT(ComboBox2.SelectedIndex))
       
        trade.SetParameters(nudPeriodFast2.Value, nudPeriodSlow2.Value)

        trade.Run()

    End Sub


    Private Sub txtSymbolShortName_TextChanged(sender As Object, e As EventArgs) Handles txtSymbolShortName.TextChanged
        txtSymbolShortName.Text = GetSecurityShortName()

    End Sub

    ''' <summary>
    ''' 根据证券代码得出证券名称
    ''' </summary>
    ''' <param name="SymbolType"></param>
    ''' <param name="Symbol"></param>
    ''' <remarks></remarks>
    Private Function GetSecurityShortName() As String
        'Dim dtinof As New CDTInfo_Fund
        Dim SymbolType, Symbol As String

        If rbtBond.Checked Then
            m_CurrentSymbolType = "Bond"
        ElseIf rbtFund.Checked Then
            SymbolType = "Fund"
        ElseIf rbtIndex.Checked Then
            m_CurrentSymbolType = "Index"
        Else
            m_CurrentSymbolType = "Stock"
        End If

        'Symbol = txtSymbol.Text
        If Len(txtSymbol_.Text) >= 6 Then
            'Symbol = txtSymbol_.Text.Substring(0, 6)
            m_CurrentSymbol = txtSymbol_.Text.Substring(0, 6)
            Return CDTInfo.GetShortNamebySymbol(m_CurrentSymbolType, m_CurrentSymbol)
        Else
            m_CurrentSymbol = ""
            Return ""
        End If


    End Function

    ''' <summary>
    ''' 证券类型改变，状态(Symbol)也随之变化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbtIndex_CheckedChanged(sender As Object, e As EventArgs) Handles rbtIndex.CheckedChanged
        'SetState(m_StateSymbolDateChanged)
        SetState(m_State_SymbolTypeChanged)
        FillSymbolListBox()

        txtSymbolShortName.Text = GetSecurityShortName()
    End Sub

    Private Sub rbtStock_CheckedChanged(sender As Object, e As EventArgs) Handles rbtStock.CheckedChanged
        'SetState(m_StateSymbolDateChanged)
        SetState(m_State_SymbolTypeChanged)

        FillSymbolListBox()

        txtSymbolShortName.Text = GetSecurityShortName()
    End Sub

    Private Sub rbtFund_CheckedChanged(sender As Object, e As EventArgs) Handles rbtFund.CheckedChanged
        'SetState(m_StateSymbolDateChanged)
        SetState(m_State_SymbolTypeChanged)
        FillSymbolListBox()
        txtSymbolShortName.Text = GetSecurityShortName()
    End Sub

    Private Sub rbtBond_CheckedChanged(sender As Object, e As EventArgs) Handles rbtBond.CheckedChanged
        'SetState(m_StateSymbolDateChanged)
        SetState(m_State_SymbolTypeChanged)
        FillSymbolListBox()
        txtSymbolShortName.Text = GetSecurityShortName()
    End Sub

    

    Private Sub txtSymbol__SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtSymbol_.SelectedIndexChanged
        SetState(m_StateSymbolDateChanged)

        txtSymbolShortName.Text = GetSecurityShortName()

    End Sub

    Private Sub txtSymbol__TextChanged(sender As Object, e As EventArgs) Handles txtSymbol_.TextChanged
        SetState(m_StateSymbolDateChanged)

        txtSymbolShortName.Text = GetSecurityShortName()
    End Sub
End Class