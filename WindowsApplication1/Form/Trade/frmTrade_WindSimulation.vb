Imports WAPIWrapperCSharp
Imports MyTradingSystem.Trade

Public Class frmTrade_WindSimulation

    'Private m_WindAPI As WAPIWrapperCSharp.WindAPI
    'Private m_winddata As WAPIWrapperCSharp.WindData

    'Private m_orderSymbol As String
    'Private m_BuyorSell As String
    'Private m_orderPrice As Single
    'Private m_orderShares As Single
    'Private m_orderType As String


    Private m_pbLogon_min As Int16 = 1
    Private m_pbLogon_max As Int16 = 100

    Private m_Wind As CTrade_Simulation_Wind

    Private m_bLogoning As Boolean = False

#Region "PrimaryThread"


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnLogon.Click

        If m_bLogoning = False Then '开始登陆
            'pbLogon.Value = 1

            btnLogon.Text = "取消登陆"
            lblLogonStatus.Text = "登陆中"
            BackgroundWorker1.RunWorkerAsync()


        Else '取消登陆
            m_bLogoning = False
            btnLogon.Text = "登陆"
            lblLogonStatus.Text = "未登陆"
            BackgroundWorker1.CancelAsync()

        End If
        'm_WindAPI.start()
        'lblLogonStatus.Text = "登陆中......"
        'm_winddata = m_WindAPI.tlogon("00000010", "0", "M:1365182978301", "000000", "SHSZ")

        'If (m_winddata.errorCode = 0) Then
        '    lblLogonStatus.Text = "登陆成功"
        'Else
        '    lblLogonStatus.Text = "登陆不成功。错误代码:" + m_winddata.errorCode
        'End If
    End Sub


    Private Sub btnOrder_Click(sender As Object, e As EventArgs)
        If rbtBuy.Checked Then
            m_Wind.PlaceOrder()
        ElseIf rbtSell.Checked Then
            m_Wind.PlaceOrder()
        End If


        'If (m_winddata.errorCode = 0) Then
        '    m_winddata.GetLogonId()

        '    m_orderSymbol = txtSymbol.Text & ".SZ"
        '    m_BuyorSell = "Buy"
        '    m_orderPrice = txtPrice.Text
        '    m_orderShares = txtVolume.Text
        '    m_orderType = "OrderType=BOC"

        '    m_winddata = m_WindAPI.torder(m_orderSymbol, m_BuyorSell, CStr(m_orderPrice), CStr(m_orderShares), m_orderType)


        '    MsgBox(m_winddata.GetErrorMsg)

        'Else
        '    MsgBox("登陆错误")
        'End If
    End Sub

    Private Sub frmTrade_WindSimulation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'm_WindAPI = New WAPIWrapperCSharp.WindAPI
        'm_winddata = New WAPIWrapperCSharp.WindData

        m_Wind = New CTrade_Simulation_Wind

        FillComboboxOrderType()

        'txtQueryResult.Text = String.Format("Code Length: {0} \n ; Field Length: {1}; %n Data Length: {2}; LogonID: {3} {4}", m_winddata.GetCodeLength(), m_winddata.GetFieldLength, m_winddata.GetDataLength(), m_winddata.GetLogonId(), System.Environment.NewLine)

    End Sub

    Private Sub FillComboboxOrderType()
        cbxOrderType.Items.Add("BOC")
        cbxOrderType.Items.Add("LMT")
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQueryCapital.Click
        Dim dt As New DataTable
        dt = m_Wind.QueryCapital()

        dgvCapital.DataSource = dt

        'm_winddata = Query("Capital")

        'GetDataString("Capital")
        'm_winddata.getDataByFunc("tquery")

        'txtQueryResult.Text = m_winddata.getDataByFunc("tquery")
    End Sub

    Private Function GetDataString(strFun As String) As Boolean
        'Try


        '    m_winddata = m_WindAPI.tquery(strFun)
        '    'Dim strResult(,) As String
        '    'txtQueryResult.Text = String.Format("Code Length: {0} \n ; Field Length: {1}; %n Data Length: {2}; LogonID: {3}", m_winddata.GetCodeLength(), m_winddata.GetFieldLength, m_winddata.GetDataLength(), m_winddata.GetLogonId())
        '    txtQueryResult.Text = txtQueryResult.Text + String.Format("Code Length: {0} \n ; Field Length: {1}; %n Data Length: {2}; LogonID: {3} {4}", m_winddata.GetCodeLength(), m_winddata.GetFieldLength, m_winddata.GetDataLength(), m_winddata.GetLogonId(), System.Environment.NewLine)

        '    'Dim resultstring As String
        '    'txtQueryResult.Text = txtQueryResult.Text + m_winddata.fieldList

        '    'Dim resultstring As String = WindDataMethod.WindDataToString(m_winddata, strFun)
        '    'txtQueryResult.Text = txtQueryResult.Text + resultstring + System.Environment.NewLine
        '    If (m_winddata.errorCode = 0) Then

        '        'Dim lRecordCount As Int16 = m_winddata.GetCodeLength
        '        'For i = 0 To lRecordCount - 1
        '        Try
        '            Dim fl As Int16 = m_winddata.GetFieldLength
        '            For j = 0 To fl - 1
        '                Dim var As Object
        '                ''m_winddata.GetTradeItem(i, j, var)
        '                Dim str As String = m_winddata.data(j, 0)
        '                str = j & "行:" + str + System.Environment.NewLine
        '                txtQueryResult.Text = txtQueryResult.Text + str
        '            Next
        '        Catch ex As Exception

        '        End Try

        '        'Next

        '    End If
        '    Return True

        'Catch ex As Exception
        '    Return False
        'End Try

        'txtQueryResult.Text = txtQueryResult.Text + resultstring

        'If (m_winddata.errorCode = 0) Then

        '    Dim lRecordCount As Int16 = m_winddata.GetDataLength
        '    For i = 0 To lRecordCount - 1
        '        Dim fl As Int16 = m_winddata.GetFieldLength
        '        For j = 0 To fl - 1
        '            Dim var As Object
        '            'm_winddata.GetTradeItem(i, j, var)
        '            'Dim str As String = Cstr()

        '        Next
        '    Next

        'End If

    End Function
    Private Function Query(strFun As String) As WindData


        ''Dim strResult(,) As String
        'txtQueryResult.Text = String.Format("Code Length: {0} \n ; Field Length: {1}; %n Data Length: {2}; LogonID: {3}", m_winddata.GetCodeLength(), m_winddata.GetFieldLength, m_winddata.GetDataLength(), m_winddata.GetLogonId())


        'Dim resultstring As String = WindDataMethod.WindDataToString(m_winddata, strFun)

        'txtQueryResult.Text = txtQueryResult.Text + resultstring

        'If (m_winddata.errorCode = 0) Then

        '    Dim lRecordCount As Int16 = m_winddata.GetDataLength
        '    For i = 0 To lRecordCount - 1
        '        Dim fl As Int16 = m_winddata.GetFieldLength
        '        For j = 0 To fl - 1
        '            Dim var As Object
        '            ''m_winddata.GetTradeItem(i, j, var)
        '            Dim str As String = m_winddata.data(i, j)
        '            Debug.Print(str)
        '        Next
        '    Next

        'End If
        'Return m_WindAPI.tquery(strFun)
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        m_Wind.Logout()
        'm_WindAPI.tlogout()
        'm_WindAPI.stop()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnQueryPosition.Click
        'GetDataString("Position")      '持仓查询
        Dim dt As New DataTable
        dt = m_Wind.QueryPosition()

        dgvPosition.DataSource = dt
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnQueryOrder.Click
        'GetDataString("Order")
        Dim dt As New DataTable
        dt = m_Wind.QueryOrder()

        dgvOrder.DataSource = dt
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnQueryTrade.Click
        'GetDataString("Trade")
        Dim dt As New DataTable
        dt = m_Wind.QueryTrade()

        dgvTrade.DataSource = dt
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnQueryAccount.Click
        'GetDataString("Account")

        Dim dt As New DataTable
        dt = m_Wind.QueryAccount()

        dgvAccount.DataSource = dt
    End Sub


    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        'pbLogon.Value = e.ProgressPercentage
        lblLogonStatus.Text = e.UserState
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'If m_winddata.errorCode = 0 Then
        '    lblLogonStatus.Text = "已登陆"
        'Else
        '    lblLogonStatus.Text = "未登陆。登陆错误"
        'End If

        If m_Wind.GetErrorCode = 0 Then
            lblLogonStatus.Text = "已登陆"
        Else
            lblLogonStatus.Text = "未登陆。登陆错误"
        End If
    End Sub



    Private Sub btnOrder_Click_1(sender As Object, e As EventArgs) Handles btnOrder.Click


        m_Wind.OrderSymbol = txtSymbol.Text
        If rbtBuy.Checked Then
            m_Wind.OrderBuyorSell = "Buy"
        ElseIf rbtSell.Checked Then
            m_Wind.OrderBuyorSell = "Sell"
        End If
        m_Wind.OrderType = cbxOrderType.Text
        m_Wind.OrderPrice = txtPrice.Text
        m_Wind.OrderVolume = txtVolume.Text

        m_Wind.PlaceOrder()

    End Sub

#End Region

#Region "Background Thread"
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If m_bLogoning = False Then
            m_Wind.Logon("Stock")
            m_bLogoning = True
            'If BackgroundWorker1.CancellationPending = False Then

            '    System.Threading.Thread.Sleep(20000)
            '    '将信息显示到前台UI
            '    BackgroundWorker1.ReportProgress(0, "停顿时间：" + DateTime.Now.ToString("HH:mm:ss"))

            'End If
        End If

        If BackgroundWorker1.CancellationPending Then
            m_bLogoning = False
            Exit Sub
        End If

    End Sub



#End Region

End Class