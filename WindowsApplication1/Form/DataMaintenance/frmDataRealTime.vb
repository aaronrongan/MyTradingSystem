Imports MyTradingSystem.DataFeed
Public Class frmDataRealTime

    Private wind As New CDataFeedWind
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnDataRealtime.Click

        wind.Start()
        Dim dt As New DataTable
        dt = wind.GetPriceRealtime(TextBox1.Text)

        Dim list1 As Date() = wind.GetTimeList

        'For i = 0 To list1.Count - 1
        '    ListBox1.Items.Add(list1(i).ToString)
        'Next
        If Not IsNothing(dt) Then
            dt.Columns.Add("Time", GetType(System.String))
            dt.Columns("Time").SetOrdinal(0)

            For i = 0 To list1.Count - 1
                dt.Rows(i).Item("Time") = list1(i).ToString
            Next

        End If
       
        dgv1.DataSource = dt

       

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnDataMinute.Click


        Dim dt As New DataTable
        wind.Start()
        dt = wind.GetPriceMinutes(TextBox1.Text, "2015-12-04 09:50:00", "2015-12-04 15:00:00")

        Dim list1 As Date() = wind.GetTimeList

        'For i = 0 To list1.Count - 1
        '    ListBox1.Items.Add(list1(i).ToString)
        'Next
        If Not IsNothing(dt) Then


            dt.Columns.Add("Time", GetType(System.String))
            dt.Columns("Time").SetOrdinal(0)
            For i = 0 To list1.Count - 1
                dt.Rows(i).Item("Time") = list1(i).ToString
            Next
        End If

        dgv2.DataSource = dt


    End Sub

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Private Sub frmDataRealTime_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        wind.StopWind()
    End Sub

    Private Sub frmDataRealTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        wind = New CDataFeedWind



    End Sub
End Class