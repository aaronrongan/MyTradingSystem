Imports System.IO
Imports Microsoft.VisualBasic.Strings
Imports MyTradingSystem.DataBase
Imports MyTradingSystem.DataFeed
Imports MyTradingSystem.DataEntity

Public Class frm_DataFeed

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub 数据库维护ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 数据库维护ToolStripMenuItem.Click
        Dim fPrice As Single


        fPrice = 11.3



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim oDF As New CDataFeedWeb_StockInfo
        Dim oRE As New CRegExp
        Dim oXml As New Object
        Dim sArray As String(,)

        'oDF.GetYahoo_Daily("002201")

        'oxml = CreateObject("Microsoft.XMLHTTP")

        'oDF.GetSina_Current("002201", oxml)
        sArray = oDF.GetStockCodeList()

        'oRE.GetStockList(oxml.responseText)

        'Debug.Print(oxml.responseText)
        'Debug.Print(oxml.Status)

        'Debug.Print(oxml.responseXML.xml)
        Dim sPath As String = "D:\StockList.txt"
        If System.IO.File.Exists(sPath) = True Then
            System.IO.File.Delete(sPath)
        End If

        For index2 = 0 To sArray.GetUpperBound(1) - 1
            'MsgBox(sArray(index1, index2))
            'Debug.Print(sArray(0, index2) & " " & sArray(1, index2))
            'Dim str As String = sArray(index1, index2)

            System.IO.File.AppendAllText(sPath, index2 + 1 & "," & sArray(0, index2) & "," & sArray(1, index2) & System.Environment.NewLine)

        Next

        oDF = Nothing
        oXml = Nothing
        oRE = Nothing
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim oWR As New CDataFeedWeb_IndexInfo
        Dim sArray As String(,)

        sArray = oWR.GetIndexList()

        If System.IO.File.Exists("D:\IndexList.txt") = True Then
            System.IO.File.Delete("D:\IndexList.txt")
        End If

        For index2 = 0 To sArray.GetUpperBound(1) - 1
            'MsgBox(sArray(index1, index2))
            'Debug.Print(sArray(0, index2) & " " & sArray(1, index2))
            'Dim str As String = sArray(index1, index2)

            '"\r\n"无效，只能用Newline
            System.IO.File.AppendAllText("D:\IndexList.txt", index2 + 1 & "," & sArray(0, index2) & "," & sArray(1, index2) & System.Environment.NewLine)

        Next
        'Next

        oWR = Nothing


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim oWR As New CDataFeedWeb_Price

        Dim oDT As New CDBTxt
        Dim oSR As IO.StreamReader

        Dim sFileName As String
        Dim sFilePath As String = GlobalVariables.g_TXTDBPath & "\Stocks"
        Dim sSymbolName As String
        Dim iCount As Integer = 0

        Dim sSymbolArray() As String = IO.File.ReadAllLines("d:\StockList.txt")

        Dim query = From eachline In sSymbolArray
                    Let data = eachline.Split(",")
                    Let code = data(1)
                    Select code

        On Error Resume Next
        For Each sSymbol As String In query
            If iCount < 200 Then
                sSymbolName = sSymbol
                sSymbolName = Mid(sSymbol, 4, sSymbolName.Length - 3)
                sFileName = sSymbolName & ".csv"

                If System.IO.File.Exists(sFilePath & "\" & sFileName) = True Then
                    If DateValue(IO.File.GetLastWriteTime(sFilePath & "\" & sFileName)) = Today() Then
                        MsgBox("今日已下载数据，该条" & sFileName & "数据不需要重新下载")
                        'Exit Sub
                        Continue For
                    End If
                    If MsgBox("发现重名文件，是否要替换?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        System.IO.File.Delete(sFilePath)
                        Continue For
                    End If
                End If

                oSR = oWR.GetStockDailyPrice(sSymbolName)

                oDT.Stream2CSV(oSR, sFilePath, sFileName)  '分行取再写这个方法太慢。。。。
                'For Each PriceData As String In oSR

                'Next
                'IO.File.WriteAllLines(sFilePath & "\" & sFileName, PriceData)
                'IO.File.WriteAllText(sFilePath & "\" & sFileName, oSR.ReadToEnd())
                iCount = iCount + 1
            End If
        Next


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim oDFT As New CDataFeedTDX
        'Dim oDTP As New CDTDaily_Stock_Collection
        Dim oDTP As New CDTDaily_Stock

        'oDTP = oDFT.GetStockDaily_dotNetMethod("000001", "1")
        'oDTP = oDFT.FeedStockDaily_TDX("000002")
        oDTP = oDFT.FeedStockDaily_General_TDX("000002")

        MsgBox(oDTP.Rows.Count)
    End Sub
End Class
