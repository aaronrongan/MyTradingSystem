Imports MyTradingSystem.DataBase
Imports MyTradingSystem.DataEntity
Imports MyTradingSystem.Indicator

Public Class frmDataView_StockHistoryData_Obsolete_OldTeeChart

    'Private dt As New CDTDaily_Stock
    Private m_tcm As CTeeChartManaged
    Private m_DataTableStockDaily As CDTDaily_Stock
    Private m_indicatorSets As Dictionary(Of EIndicatorName, CIndicator)  'CIndicatorSets
    Private m_idcplotSMA As CIndicatorPlotAxTchart_SMA 'CIndicator_SMA3
    Private m_idcSMA As CIndicator_SMA
    Private m_idcSMA2 As CIndicator_SMA2
    Private m_idcSMA3 As CIndicator_SMA3


    Private Sub frmDataView_StockHistoryData_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'm_DataTableStockDaily = New CDTDaily_Stock()

        dtp_StartDate.Text = Today().AddDays(-30)
        dtp_EndDate.Text = Today()
        'Dim arr() As Int32 = {10, 20, 30, 10, 50}

        'AxTChart_Candle.Name = "Candle"
        'Dim scClass As TeeChart.ESeriesClass
        'Dim obj1 As TeeChart.ICandleSeries

        'AxTChart_Candle.AddSeries(scClass)

        'MsgBox(AxTChart_Candle.Series(0).SeriesType)

        'AxTChart_Candle.Series(0).YValues.

        'With AxTChart_Candle.Series(0)
        '.Add(20, "Apple", 1)
        '.Add(10, "organge", 2)

        '.AddArray(5, arr)
        'End With

        'AxTChart_Candle.Series()
        'AxTChart_Volumn.Name = "Volumn"
        'With AxTChart_Volumn.Series(0)
        '.SeriesType = TeeChart.ESeriesClass.scCandle
        '.Add(10, "Apple", 1)
        '.Add(10, "organge", 2)
        'End With

        'AxTChart_Candle.ClearChart()
        'AxTChart_Candle.Aspect.View3D = False

        'm_DataTableStockDaily.GetDataTablePrice(txtSymbol.Text, dtp_StartDate.Text, dtp_EndDate.Text)
        'm_DataTableStockDaily.RemoveSilentPrice()
        'm_idcSMA3 = New CIndicator_SMA3(m_DataTableStockDaily)
        'm_idcSMA3.SetParameters(EPriceType.Close, 3, 10, 15)

        'm_tcm.InitCandleGraph(AxTChart_Candle)
        'm_tcm.InitCandleGraph(AxTChart_Indicator)

        'm_tcm.AddCandlePricefromDataTable(AxTChart_Candle, m_DataTableStockDaily, EPriceAdjustedType.ForAdj)

        'm_idcSMA3.PlotAxTChart(AxTChart_Candle)

        'm_tcm.AddCandleVolumefromDataTable(AxTChart_Volume, m_DataTableStockDaily, EPriceAdjustedType.Normal)

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        m_DataTableStockDaily.GetDataTablePrice(txtSymbol.Text, dtp_StartDate.Text, dtp_EndDate.Text)

        m_DataTableStockDaily.RemoveSilentPrice()
        m_idcSMA = New CIndicator_SMA(m_DataTableStockDaily)
        m_idcSMA3 = New CIndicator_SMA3(m_DataTableStockDaily)

        m_idcSMA.SetParameters(EPriceType.Close, 3)
        m_idcSMA3.SetParameters(EPriceType.Close, 3, 10, 15)

        'm_indicatorSets.Add(EIndicatorName.SMA3, m_idcSMA3)

        m_tcm.InitCandleGraph(AxTChart_Candle)
        m_tcm.InitCandleGraph(AxTChart_Indicator)

        'AxTChart_Candle.AddSeries(TeeChart.ESeriesClass.scCandle)

        m_tcm.AddCandlePricefromDataTable(AxTChart_Candle, m_DataTableStockDaily, EPriceAdjustedType.ForAdj)

        'm_idcSMA.PlotAxTChart(AxTChart_Candle)
        'm_idcSMA3.PlotAxTChart(AxTChart_Candle)

        m_tcm.AddCandleVolumefromDataTable(AxTChart_Volume, m_DataTableStockDaily, EPriceAdjustedType.Normal)

    End Sub


    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Try


            'If CheckBox2.Checked Then
            '    Dim idc As New CIndicator_SMA(m_DataTableStockDaily)
            '    'Dim idc As CIndicator_MA()

            '    'idc.PeriodsAverage = nudPeriod.Value

            '    idc.SetParameters(nudPeriodSlow3.Value)

            '    m_tcm.AddIndicator(AxTChart_Candle, idc)

            'Else
            '    AxTChart_Candle.Series(1).Delete(1)
            'End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

        m_tcm = New CTeeChartManaged
        m_DataTableStockDaily = New CDTDaily_Stock
        'm_idcSMA = New CIndicator_SMA(m_DataTableStockDaily)

    End Sub

End Class