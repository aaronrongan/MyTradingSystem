'类说明

'文件读写类
'可以打开一个CSV文件，进行读取数据，返回一个价格数组
'也可以对csv、TXT进行写操作，补充当日数据
'可以对Excel文件进行读写

Namespace DataBase


    Public Class CDBTxt
        Private m_sInputFileName As String

        Private m_sInputFilePath As String

        Private m_sOutputFileName As String

        Private m_sOutputFilePath As String

        Private m_arrPriceData() As Single      '原始价格数据

        '从CSV文件得到价格数据数组，并转置为正常日期排序

        Public Function GetPriceDatafromYahooCSV(strFileWholePath As String, oPriceDataTable As CDTDaily_Stock_Collection) 'As CPriceDataTable
            'Dim iFileNumber1  As Integer
            'Dim b  As MyType

            'iFileNumber1 = FreeFile

            'Open "sz000625.day" For Binary Access Read As #FileNumber1

            'Open strFileWholePath For Input Access Read As #iFileNumber1

            'Open strFileWholePath For Input As #iFileNumber1

            'Do While Not EOF(iFileNumber1)
            'Get iFileNumber1, , b
            'Line Input #iFileNumber1, sLineString
            'Debug.Print sLineString
            'Input #iFileNumber1, sDate, sngOpen, snHigh, sngLow, sngClose, sngVolume, sngAdjClose
            'If iCount > 1 Then
            '  Debug.Print sDate, sngOpen, snHigh, sngLow, sngClose, sngVolume, sngAdjClose
            'End If
            '      Cells(i, 1) = b.a1
            '      Cells(i, 2) = b.a2
            '      Cells(i, 3) = b.a3
            '      Cells(i, 4) = b.a4
            '      Cells(i, 5) = b.a5
            '      Cells(i, 6) = b.a6
            '      Cells(i, 7) = b.a7
            '      Cells(i, 8) = b.a8

            'iCount = iCount + 1
            'Loop
            'Close #iFileNumber1

            'Dim oPriceDataTable As New CPriceDataTable

            Dim iCount As Integer
            iCount = 1

            Dim sLineString As String

            Dim sSplit As Object

            '    Dim sDate As String
            '    Dim sngOpen As Single
            '    Dim snHigh As Single
            '    Dim sngLow As Single
            '    Dim sngClose As Single
            '    Dim sngVolume As Single
            '    Dim sngAdjClose As Single

            Dim myFso As Object = CreateObject("Scripting.FileSystemObject")
            Dim myTxt As Object = myFso.OpenTextFile(strFileWholePath, 1)

            Do Until myTxt.AtEndOfStream
                sLineString = myTxt.Readline
                sSplit = Split(sLineString, ",")


                '        If iCount = 2 Then
                '
                '            oPriceData.ThisDate = sSplit(0)
                '            oPriceData.OpenPrice = sSplit(1)
                '            oPriceData.HighPrice = sSplit(2)
                '            oPriceData.LowPrice = sSplit(3)
                '            oPriceData.ClosePrice = sSplit(4)
                '            oPriceData.Volume = sSplit(5)
                '            oPriceData.CloseAdjPrice = sSplit(6)
                '            oPriceDataTable.PriceData.Add oPriceData

                'Set oPriceData = Nothing
                If iCount > 1 Then
                    '如果当天价格数据不为0，且不与前一天相同，才做保存
                    'If sSplit(1) <> 0 And sSplit(1) <> oPriceDataTable.PriceData.Item(iCount - 1).OpenPrice Then

                    'Dim oPriceData As New CPriceData    '必须有这句，否则oPriceData不会清空，奇怪的问题
                    Dim oPriceData As New CDataPrice_Stock
                    oPriceData.ThisDate = sSplit(0)
                    oPriceData.OpenPrice = sSplit(1)
                    oPriceData.HighPrice = sSplit(2)
                    oPriceData.LowPrice = sSplit(3)
                    oPriceData.ClosePrice = sSplit(4)
                    oPriceData.TurnoverVolume = sSplit(5)
                    oPriceData.ClosePrice_PreAdj = sSplit(6)

                    oPriceDataTable.PriceData.Add(oPriceData)

                    'Debug.Print oPriceDataTable.PriceData.Count
                    'Debug.Print oPriceDataTable.PriceData.Item(oPriceDataTable.PriceData.Count).ThisDate

                    oPriceData = Nothing
                    'End If
                End If
                '            oPriceData.ThisDate.Add sSplit(0)
                '            oPriceData.OpenPrice.Add sSplit(1)
                '            oPriceData.HighPrice.Add sSplit(2)
                '            oPriceData.LowPrice.Add sSplit(3)
                '            oPriceData.ClosePrice.Add sSplit(4)
                '            oPriceData.Volume.Add sSplit(5)
                '            oPriceData.CloseAdjPrice.Add sSplit(6)

                'ReDim Preserve arrDate(iCount)
                'ReDim Preserve arrClosePrice(iCount)

                'arrDate(iCount - 1) = sDate
                'arrClosePrice(iCount - 1) = sngAdjClose
                'colDate.Add sDate
                'colClosePrice.Add sngAdjClose

                '            oPriceData.ThisDate.Add sDate
                '            oPriceData.CloseAdjPrice.Add sngAdjClose

                'Debug.Print oPriceData.ThisDate.Item(iCount - 1)
                'Debug.Print oPriceData.CloseAdjPrice.Item(iCount - 1)



                iCount = iCount + 1
            Loop


            'Debug.Print oPriceData.CloseAdjPrice
            'Debug.Print oPriceDataTable.PriceData.Count

            oPriceDataTable.TransposeDateOrder(True)

            oPriceDataTable.DeleteRedundantPriceData()

            '    Debug.Print oPriceDataTable.PriceData.Count
            '    Debug.Print oPriceDataTable.PriceData.Item(1).ThisDate
            '    Debug.Print oPriceDataTable.PriceData.Item(2).ThisDate
            '    Debug.Print oPriceDataTable.PriceData.Item(oPriceDataTable.PriceData.Count).ThisDate

            myTxt.Close()


            myTxt = Nothing
            myFso = Nothing

        End Function

        '从Yahoo网址生成csv文件输出到本地
        Public Function GetPricefromYahoo()
            Dim xml As New MSXML2.XMLHTTP

            xml.open("POST", "http://table.finance.yahoo.com/table.csv?s=000001.sz", False)
            xml.send()

            'While xml.readystate <> 4
            '    DoEvents
            'Wend
            'MsgBox xml.Status

            Debug.Print(xml.responseText)
            Debug.Print(xml.status)
            Debug.Print(xml.responseXML.xml)

            'MakeHtm(xml.responseText, ThisWorkbook.Path)
        End Function

        Private Sub MakeHtm(inputed_string As String, log_path As String)
            Dim objFSO, logfile, logtext, log_folder

            objFSO = CreateObject("Scripting.FileSystemObject")
            On Error Resume Next
            log_folder = objFSO.CreateFolder(log_path)

            If objFSO.FileExists(log_path & "\temp_source.csv") = 0 Then
                logfile = objFSO.CreateTextFile(log_path & "\temp_source.csv", True, -1)
            End If
            log_folder = Nothing
            logfile = Nothing

            logtext = objFSO.OpenTextFile(log_path & "\temp_source.csv", 2, True, -1)
            logtext.Write(inputed_string)
            logtext.Close()

            objFSO = Nothing
        End Sub

        'Public Async Sub Stream2CSV(stream As IO.StreamReader, sFilePath As String, sFileName As String)
        Public Sub Stream2CSV(stream As IO.StreamReader, sFilePath As String, sFileName As String)
            'On Error Resume Next
            Try
                Dim strLine As String
                Dim sWholePath As String
                sWholePath = sFilePath & "\" & sFileName

                If System.IO.File.Exists(sWholePath) = True Then
                    If DateValue(IO.File.GetLastWriteTime(sFilePath)) = Today() Then
                        MsgBox("今日已下载数据，该条" & sFileName & "数据不需要重新下载")
                        Exit Sub

                    End If
                    If MsgBox("发现重名文件，是否要替换?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        System.IO.File.Delete(sFilePath)
                        Exit Sub
                    End If
                End If

                If stream Is Nothing Then
                    MsgBox("无法下载该文件: " & sFileName)
                    Exit Sub
                Else
                    'IO.File.WriteAllText(sWholePath, Await stream.ReadToEndAsync())
                    IO.File.WriteAllLines(sWholePath, stream.ReadToEndAsync())
                    'IO.File.WriteAllText(sWholePath, stream.ReadToEnd())
                End If
                'While Not stream.EndOfStream
                '    strLine = stream.ReadLine()
                '    If strLine = "" Then
                '        Exit Sub
                '    End If
                '    IO.File.AppendAllText(sWholePath, strLine & System.Environment.NewLine)
                'End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Public Sub String2CSV(inputed_string As String, sFilePath As String, sFileName As String)
            Dim objFSO, logfile, logtext, log_folder

            objFSO = CreateObject("Scripting.FileSystemObject")
            On Error Resume Next
            log_folder = objFSO.CreateFolder(sFilePath)

            If objFSO.FileExists(sFilePath & "\" & sFileName) = 0 Then
                logfile = objFSO.CreateTextFile(sFilePath & "\" & sFileName, True, -1)
            End If
            log_folder = Nothing
            logfile = Nothing

            logtext = objFSO.OpenTextFile(sFilePath & "\" & sFileName, 2, True, -1)
            logtext.Write(inputed_string)
            logtext.Close()

            objFSO = Nothing
        End Sub
    End Class
End Namespace
