Imports MyTradingSystem.DataBase
Imports MyTradingSystem.DataFeed
Imports MyTradingSystem.DataEntity
Imports MyTradingSystem.Indicator

Public Class frm_IDCMA

    '要重写
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim oPriceDataTable As New CDTDaily_Stock_Collection
        Dim oPriceDataTable As New CDTDaily_Stock

        Dim sFileName As String = GlobalVariables.GetStockCodePrePostfix(txt_Code1.Text, GlobalVariables.EDataFeedSource.TDX_FQ) & txt_Code1.Text & ".txt"
        Dim strDataFilePath As String = GlobalVariables.g_TDXPath_Daily_FA & "\" & sFileName
        Dim oDFT As New CDataFeedTDX

        '1-取得PriceData
        oPriceDataTable = oDFT.FeedStockDaily_General_TDX(Trim(txt_Code1.Text))
        Dim oAvg As CIDC_Average_Obsolete

        oAvg = New CIDC_Average_Obsolete(oPriceDataTable)

        Dim arrAvg1(oAvg.ArrayAverage1.Count) As Single
        Dim arrAvg2(oAvg.ArrayAverage1.Count) As Single
        Dim arrAvg3(oAvg.ArrayAverage1.Count) As Single
        Dim arrAvg4(oAvg.ArrayAverage1.Count) As Single
        Dim arrAvg5(oAvg.ArrayAverage1.Count) As Single
        Dim arrAvg6(oAvg.ArrayAverage1.Count) As Single

        arrAvg1 = oAvg.ArrayAverage1

        MsgBox(oPriceDataTable.Rows.Count)
        MsgBox(arrAvg1.Count)

        Dim strArrInput() As String = {""}
        Dim strInput As String
        Dim strOutput As String

        ''''''待修改   oPriceDataTable.Print2StringArray(strArrInput)
        strInput = Join(strArrInput, System.Environment.NewLine)
        txt_Input.Text = strInput

        Dim i As Integer
        For i = 0 To arrAvg1.Count - 1
            strOutput = strOutput & arrAvg1(i) & System.Environment.NewLine
        Next
        txt_Output1.Text = strOutput

        strOutput = ""
        arrAvg2 = oAvg.ArrayAverage2
        For i = 0 To arrAvg2.Count - 1
            strOutput = strOutput & arrAvg2(i) & System.Environment.NewLine
        Next
        txt_Output2.Text = strOutput

        strOutput = ""
        arrAvg3 = oAvg.ArrayAverage3
        For i = 0 To arrAvg3.Count - 1
            strOutput = strOutput & arrAvg3(i) & System.Environment.NewLine
        Next
        txt_Output3.Text = strOutput

        strOutput = ""
        arrAvg4 = oAvg.ArrayAverage4
        For i = 0 To arrAvg4.Count - 1
            strOutput = strOutput & arrAvg4(i) & System.Environment.NewLine
        Next
        txt_Output4.Text = strOutput

        strOutput = ""
        arrAvg5 = oAvg.ArrayAverage5
        For i = 0 To arrAvg5.Count - 1
            strOutput = strOutput & arrAvg5(i) & System.Environment.NewLine
        Next
        txt_Output5.Text = strOutput

        strOutput = ""
        arrAvg6 = oAvg.ArrayAverage6
        For i = 0 To arrAvg6.Count - 1
            strOutput = strOutput & arrAvg6(i) & System.Environment.NewLine
        Next
        txt_Output6.Text = strOutput

        '写入一个CSV文件，便于绘图
        Dim strOutput2File() As String

        ReDim strOutput2File(oAvg.DataTablePrice.PriceData.Count)

        For i = 1 To oAvg.DataTablePrice.PriceData.Count
            strOutput2File(i) = oAvg.DataTablePrice.PriceData.Item(i).Thisdate
            strOutput2File(i) = strOutput2File(i) & "," & oAvg.DataTablePrice.PriceData.Item(i).ClosePrice_PreAdj
            strOutput2File(i) = strOutput2File(i) & "," & arrAvg1(i)
            strOutput2File(i) = strOutput2File(i) & "," & arrAvg2(i)
            strOutput2File(i) = strOutput2File(i) & "," & arrAvg3(i)
            strOutput2File(i) = strOutput2File(i) & "," & arrAvg4(i)
            strOutput2File(i) = strOutput2File(i) & "," & arrAvg5(i)
            strOutput2File(i) = strOutput2File(i) & "," & arrAvg6(i)
            'strOutput2File(i) = strOutput2File(i) & System.Environment.NewLine
        Next

        CUtility.WriteLog(strOutput2File)

        oAvg.CalculateDailyStatus1()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try


            Dim dt As New CDTDaily_Stock

            dt.GetDailyPricebySymbolDatesfromSQL(txt_Code1.Text, dtp_StartDate.Text, dtp_EndDate.Text)

            Dim idc As New CIndicator_SMA(dt)

            'idc.Calculate()    'VIP，不应将计算过程暴露给客户，应该将该过程隐藏在初始化或者Get时

            Dim sl As New SortedList(Of Date, Single)
            sl = idc.GetAverageSortedList()
            MsgBox(sl.Count)

            Dim sArray() As String
            ReDim sArray(sl.Count)

            Dim iCount As Int16
            For Each d In sl
                sArray(iCount) = sl.Item(sl.Keys(iCount))
                iCount += 1
            Next
            'ListBox1.DataSource = sArray

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try

            Dim dt As New CDTDaily_Stock

            dt.GetDailyPricebySymbolDatesfromSQL(txt_Code1.Text, dtp_StartDate.Text, dtp_EndDate.Text)

            txt_Input.Text = ""

            For Each dr As DataRow In dt.Rows
                If (dt.TableName <> "StockPriceDaily") Then
                    txt_Input.Text = txt_Input.Text & dr("ClosePrice") & Environment.NewLine
                Else
                    txt_Input.Text = txt_Input.Text & dr("ClosePrice_FA") & Environment.NewLine
                End If
            Next

            Dim idc As New CIndicator_SMA(dt)

            'idc.Calculate()

            'Dim out As Double()
            'Dim beginindex As Int16
            'Dim outlength As Int16
            'Dim sl As New SortedList(Of Date, Double)

            'sl = idc.SetSMA()
            'out = idc.GetSMA(beginindex, outlength)

            'sl = idc.GetSMA()
            'MsgBox(out.Count)

            'Dim sArray() As String
            'ReDim sArray(idc.Rows.Count - 1)
        
            'idc.PeriodsAverage = nudPeriod.Text
            idc.SetParameters(EPriceType.Close, CSng(nudPeriod.Text)) '

            'Dim iCount As Int16
            'For Each dr As DataRow In idc.Rows
            '    sArray(iCount) = dr.Item(1)
            '    iCount += 1
            'Next

            'ListBox1.DataSource = sArray

            dgvAverage.DataSource = idc
        Catch ex As Exception

        End Try

    End Sub

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。


    End Sub

    Private Sub frm_IDCMA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtp_StartDate.Text = Today().AddDays(-30)
        dtp_EndDate.Text = Today()
    End Sub
End Class