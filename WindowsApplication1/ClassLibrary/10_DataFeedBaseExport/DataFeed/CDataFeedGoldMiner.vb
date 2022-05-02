Imports System.Xml
Imports System.Net
Imports System.Web
Imports System.IO
Imports System.Text.RegularExpressions
Imports MyTradingSystem.DataEntity
Imports GMSDK

Imports MyTradingSystem.Strategy

Namespace DataFeed


    Public Class CDataFeedGoldMiner

        Public Sub GetData()
            Try


                Dim md As MdApi = MdApi.Instance

                Dim i As Integer = md.Init("13651829783", "aaronmyquant")
                'MsgBox(i)
                Dim mds As New GMSDK.Strategy

                Dim dblist As New List(Of DailyBar)
                Dim dblisttick As New List(Of Tick)


                'dblist =
                i = mds.Init("13651829783", "aaronmyquant", "0", "000001")
                dblisttick = mds.GetLastTicks("SZSE.000001")
                dblist = mds.GetDailyBars("SZSE.000001", "2015-12-03", "2015-12-03")

                For Each db As GMSDK.Tick In dblisttick
                    Debug.Print(db.last_price)
                Next

                For Each db As GMSDK.DailyBar In dblist
                    Debug.Print(db.open & "," & db.close)
                Next

            Catch ex As Exception

            End Try
        End Sub


    End Class
End Namespace
