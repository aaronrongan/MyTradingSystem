Imports MyTradingSystem.DataEntity
Imports MyTradingSystem.DataBase
Imports MyTradingSystem.DataFeed

''' <summary>
''' 交易系统开机初始化
''' </summary>
''' <remarks></remarks>
Public Class CSystemInit


    ''' <summary>
    ''' 主界面启动时做的事：复权信息抓取、交易日历更新
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub SystemInit()

        UpdateTradingCalendar()

        Reminder()

        UpdateBlockInfo()

        UpdateConceptInfo()
    End Sub

    ''' <summary>
    ''' 更新交易日历
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub UpdateTradingCalendar()

        Dim df As New CDataFeedDatayes_General
        Dim db As New CDBADOCommand(GlobalVariables.gSQLConnectionString)


        df.FeedTradeCalendar()

    End Sub

    ''' <summary>
    ''' 更新板块信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub UpdateBlockInfo()

    End Sub

    ''' <summary>
    ''' 更新概念信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub UpdateConceptInfo()

    End Sub

    ''' <summary>
    ''' 提醒界面，如某股到达需要的价位
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub Reminder()

    End Sub



End Class
