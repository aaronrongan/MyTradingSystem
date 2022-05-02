Imports System.IO
Imports MyTradingSystem.DataEntity

Namespace DataFeed


    '从通达信获取数据
    Public Class CDataFeedTDX

        Private Structure PriceStructure
            'Dim a1 As Single '标志码
            'Dim a2 As Single '日期 
            'Dim a3 As Single '开盘价 
            'Dim a4 As Single '最高价 
            'Dim a5 As Single '最低价 
            'Dim a6 As Single '收盘价 
            'Dim a7 As Single '成交金额 
            'Dim a8 As Single '成交量  

            Dim a1 As Int32  '日期
            Dim a2 As Int32  '开盘价
            Dim a3 As Int32   '最高价
            Dim a4 As Int32   '最低价
            Dim a5 As Int32   '收盘价
            Dim a6 As Int32    '成交金额
            Dim a7 As Int32   '成交量
            Dim a8 As Int32    '保留
        End Structure
        '用传统的VB FileGet方法，关键在Int32数据格式的定义)
        '读取通达信导出的前复权日线数据，可能需要每日更新
        Public Function FeedStockDaily_FA_TDX_Obsolete(strCode As String) As CDTDaily_Stock

            Try

                Dim oDTP As New CDTDaily_Stock

                Dim sWholeFileName As String
                Dim sPrefix As String

                sPrefix = GlobalVariables.GetStockCodePrePostfix(strCode, GlobalVariables.EDataFeedSource.TDX_FQ)
                sWholeFileName = GlobalVariables.g_TDXPath_Daily_FA & "\" & sPrefix & strCode & ".txt"

                Dim sLine() As String

                If IO.File.Exists(sWholeFileName) = False Then
                    'MsgBox("没有" & strCode & "数据")
                    Return Nothing
                    Exit Function
                End If


                For Each line As String In IO.File.ReadLines(sWholeFileName)
                    Dim oDT As New CDataPrice_Stock

                    If line.Contains(",") Then
                        sLine = Split(line, ",")

                        'oDT.ThisDate = sLine(0)
                        'oDT.ClosePrice_PreAdj = sLine(1)
                        'oDT.HighPrice_PreAdj = sLine(2)
                        'oDT.LowPrice_PreAdj = sLine(3)
                        'oDT.ClosePrice_PreAdj = sLine(4)
                        'oDT.Volume = sLine(5)
                        'oDT.Amount = sLine(6)
                        'oDTP.PriceData.Add(oDT)
                        Dim oRow As DataRow = oDTP.NewRow()

                        oRow.Item("Symbol") = strCode
                        oRow.Item("TheDate") = sLine(0)
                        oRow.Item("OpenPrice_FA") = sLine(1)
                        oRow.Item("HighPrice_FA") = sLine(2)
                        oRow.Item("LowPrice_FA") = sLine(3)
                        oRow.Item("ClosePrice_FA") = sLine(4)
                        oRow.Item("TurnoverVolume") = sLine(5)
                        oRow.Item("TotalAmount") = sLine(6)


                        oDTP.Rows.Add(oRow)
                    End If
                    oDT = Nothing
                Next line

                Return oDTP

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Function

        '用传统的VB FileGet方法，关键在Int32数据格式的定义)
        '读取通达信导出的前复权日线数据，可能需要每日更新
        Public Function FeedStockDaily_FA_TDX_Obsolete(strCode As String, dtStartDate As Date, dtEndDate As Date) As CDTDaily_Stock

            Try

                Dim oDTP As New CDTDaily_Stock

                Dim sWholeFileName As String
                Dim sPrefix As String

                sPrefix = GlobalVariables.GetStockCodePrePostfix(strCode, GlobalVariables.EDataFeedSource.TDX_FQ)
                sWholeFileName = GlobalVariables.g_TDXPath_Daily_FA & "\" & sPrefix & strCode & ".txt"

                Dim sLine() As String

                If IO.File.Exists(sWholeFileName) = False Then
                    'MsgBox("没有" & strCode & "数据")
                    Return Nothing
                    Exit Function
                End If


                For Each line As String In IO.File.ReadLines(sWholeFileName)
                    Dim oDT As New CDataPrice_Stock

                    If line.Contains(",") Then
                        sLine = Split(line, ",")

                        'oDT.ThisDate = sLine(0)
                        'oDT.ClosePrice_PreAdj = sLine(1)
                        'oDT.HighPrice_PreAdj = sLine(2)
                        'oDT.LowPrice_PreAdj = sLine(3)
                        'oDT.ClosePrice_PreAdj = sLine(4)
                        'oDT.TurnoverVolume = sLine(5)
                        'oDT.Amount = sLine(6)
                        'oDTP.PriceData.Add(oDT)
                        If CDate(sLine(0)) >= dtStartDate And CDate(sLine(0)) <= dtEndDate Then '判断是否在需要的日期内
                            Dim oRow As DataRow = oDTP.NewRow()

                            oRow.Item("Symbol") = strCode
                            oRow.Item("TheDate") = sLine(0)
                            oRow.Item("OpenPrice_FA") = sLine(1)
                            oRow.Item("HighPrice_FA") = sLine(2)
                            oRow.Item("LowPrice_FA") = sLine(3)
                            oRow.Item("ClosePrice_FA") = sLine(4)
                            oRow.Item("TurnoverVolume") = sLine(5)
                            oRow.Item("TurnoverValue") = sLine(6)
                            oDTP.Rows.Add(oRow)
                        End If
                    End If
                    oDT = Nothing
                Next line

                Return oDTP

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Function
        ''' <summary>
        ''' 抓取TDX的日线数据，非复权
        ''' </summary>
        ''' <param name="strCode"></param>
        ''' <param name="strFilename"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FeedStockDaily_OBSOLETE(strCode As String, strFilename As String) As CDTDaily_Stock_Collection
            Dim oDTP As New CDTDaily_Stock_Collection
            Dim oDT As New CDataPrice_Stock
            Dim ps As PriceStructure
            'Dim binReader As New IO.BinaryReader

            Dim blockFile(4) As Byte
            Dim blockLine(32) As Byte
            'strFilename = "D:\sz000001.day"
            Dim file_num As Integer = FreeFile()
            FileSystem.FileOpen(file_num, strFilename, OpenMode.Binary)

            While Not EOF(file_num)
                FileGet(file_num, ps)
                oDT.ThisDate = ps.a1
                oDT.OpenPrice = ps.a2
                oDT.HighPrice = ps.a3
                oDT.LowPrice = ps.a4
                oDT.ClosePrice = ps.a5
                oDT.TurnoverVolume = ps.a6
                oDT.TurnoverValue = ps.a7

                oDTP.PriceData.Add(oDT)
            End While

            Return oDTP
        End Function

        ''' <summary>
        ''' 抓取TDX的日线数据，非复权，为*.day二进制格式
        ''' </summary>
        ''' <param name="strCode"></param>
        ''' <param name="dtStartDate"></param>
        ''' <param name="dtEndDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FeedNormalStockDaily_TDX(strSymbol As String, Optional ByVal dtStartDate As String = "", Optional ByVal dtEndDate As String = "") As CDTDaily_Stock

            Dim oDTP As New CDTDaily_Stock
            Dim oDTPRow As DataRow
            Dim sWholeFileName As String
            Dim sPrefix As String

            sPrefix = GlobalVariables.GetStockCodePrePostfix(strSymbol, GlobalVariables.EDataFeedSource.TDX_Normal)
            If InStr(sPrefix, "SZ") Then
                sWholeFileName = GlobalVariables.g_TDXPath_DailySZ & "\" & sPrefix & strSymbol & ".day"
            ElseIf InStr(sPrefix, "SH") Then
                sWholeFileName = GlobalVariables.g_TDXPath_DailySH & "\" & sPrefix & strSymbol & ".day"
            End If

            If IO.File.Exists(sWholeFileName) = False Then
                'MsgBox("没有" & strSymbol & "数据")
                Return Nothing
                Exit Function
            End If

            Try

                Dim dt As New DataTable

                dt = FeedParseTDX_DAYFormatFile(sWholeFileName, dtStartDate, dtEndDate)

                Dim iRowTotal As Int16, i As Int16

                iRowTotal = dt.Rows.Count

                For i = 0 To iRowTotal - 1
                    oDTPRow = oDTP.NewRow
                    oDTPRow.Item("Symbol") = strSymbol
                    oDTPRow.Item("TheDate") = dt.Rows(i).Item("TheDate")
                    oDTPRow.Item("OpenPrice") = dt.Rows(i).Item("OpenPrice")
                    oDTPRow.Item("HighPrice") = dt.Rows(i).Item("HighPrice")
                    oDTPRow.Item("LowPrice") = dt.Rows(i).Item("LowPrice")
                    oDTPRow.Item("ClosePrice") = dt.Rows(i).Item("ClosePrice")
                    oDTP.Rows.Add(oDTPRow)
                Next



                'For Each line As String In IO.File.ReadLines(sWholeFileName)
                '    Dim oDT As New CDataPrice_Stock

                '    If line.Contains(",") Then
                '        sLine = Split(line, ",")

                '        'oDT.ThisDate = sLine(0)
                '        'oDT.ClosePrice_PreAdj = sLine(1)
                '        'oDT.HighPrice_PreAdj = sLine(2)
                '        'oDT.LowPrice_PreAdj = sLine(3)
                '        'oDT.ClosePrice_PreAdj = sLine(4)
                '        'oDT.Volume = sLine(5)
                '        'oDT.Amount = sLine(6)
                '        'oDTP.PriceData.Add(oDT)
                '        If CDate(sLine(0)) >= dtStartDate And CDate(sLine(0)) <= dtEndDate Then '判断是否在需要的日期内
                '            Dim oRow As DataRow = oDTP.NewRow()

                '            oRow.Item("Symbol") = strCode
                '            oRow.Item("TheDate") = sLine(0)
                '            oRow.Item("OpenPrice_FA") = sLine(1)
                '            oRow.Item("HighPrice_FA") = sLine(2)
                '            oRow.Item("LowPrice_FA") = sLine(3)
                '            oRow.Item("ClosePrice_FA") = sLine(4)
                '            oRow.Item("Volume") = sLine(5)
                '            oRow.Item("TotalAmount") = sLine(6)
                '            oDTP.Rows.Add(oRow)
                '        End If
                '    End If
                '    oDT = Nothing
                'Next line

                Return oDTP

            Catch ex As Exception
                MsgBox(ex.Message)


                Return Nothing

            End Try
        End Function

        ''' <summary>
        ''' 抓取TDX的非复权日线数据，为*.day二进制格式
        ''' </summary>
        ''' <param name="strCode"></param>
        ''' <param name="dtStartDate"></param>
        ''' <param name="dtEndDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FeedDataTablePrice_TDX(ByRef oDTP As CDTDaily, strSymbol As String, Optional ByVal dtStartDate As String = "", Optional ByVal dtEndDate As String = "")
            Dim oDTPRow As DataRow
            Dim sWholeFileName As String
            Dim sPrefix As String

            If oDTP.TableName = "StockPriceDaily" Then
                sPrefix = GlobalVariables.GetStockCodePrePostfix(strSymbol, GlobalVariables.EDataFeedSource.TDX_Normal)
                If InStr(sPrefix, "SZ") Then
                    sWholeFileName = GlobalVariables.g_TDXPath_DailySZ & "\" & sPrefix & strSymbol & ".day"
                ElseIf InStr(sPrefix, "SH") Then
                    sWholeFileName = GlobalVariables.g_TDXPath_DailySH & "\" & sPrefix & strSymbol & ".day"
                End If

            ElseIf oDTP.TableName = "FundPriceDaily" Then       'TDX的基金数据无效
                'If IO.File.Exists(GlobalVariables.g_TDXPath_DailyExtended & "\33#" & strSymbol & ".day") Then
                'sWholeFileName = GlobalVariables.g_TDXPath_DailyExtended & "\33#" & strSymbol & ".day"
                'End If
                'sWholeFileName = GlobalVariables.g_TDXPath_DailyExtended & "\33#" & strSymbol & ".day"

            ElseIf oDTP.TableName = "IndexPriceDaily" Then
                sPrefix = GlobalVariables.GetIndexCodePrePostfix(strSymbol, GlobalVariables.EDataFeedSource.TDX_Normal)
                If InStr(sPrefix, "SZ") Then
                    sWholeFileName = GlobalVariables.g_TDXPath_DailySZ & "\" & sPrefix & strSymbol & ".day"
                    '先在\vipdoc\sz\lday中找，没有的话在g_TDXPath_DailyExtended中找
                    If IO.File.Exists(sWholeFileName) = False Then
                        sWholeFileName = GlobalVariables.g_TDXPath_DailyExtended & "\" & sPrefix & strSymbol & ".day"
                    End If
                ElseIf InStr(sPrefix, "SH") Then
                    sWholeFileName = GlobalVariables.g_TDXPath_DailySH & "\" & sPrefix & strSymbol & ".day"
                    '先在\vipdoc\sh\lday中找，没有的话说明是扩展数据，就在g_TDXPath_DailyExtended中找
                    If IO.File.Exists(sWholeFileName) = False Then
                        sWholeFileName = GlobalVariables.g_TDXPath_DailyExtended & "\" & sPrefix & strSymbol & ".day"
                    End If
                End If
            End If


            If IO.File.Exists(sWholeFileName) = False Then
                'MsgBox("没有" & strSymbol & "数据")
                Return Nothing
                Exit Function
            End If

            Try
                Dim dt As New DataTable

                dt = FeedParseTDX_DAYFormatFile(sWholeFileName, dtStartDate, dtEndDate)

                Dim iRowTotal As Int16, i As Int16

                iRowTotal = dt.Rows.Count

                For Each dtRow In dt.Rows
                    oDTPRow = oDTP.NewRow
                    oDTPRow.Item("Symbol") = strSymbol
                    oDTPRow.Item("TheDate") = dtRow.Item("TheDate")
                    oDTPRow.Item("OpenPrice") = dtRow.Item("OpenPrice")
                    oDTPRow.Item("HighPrice") = dtRow.Item("HighPrice")
                    oDTPRow.Item("LowPrice") = dtRow.Item("LowPrice")
                    oDTPRow.Item("ClosePrice") = dtRow.Item("ClosePrice")
                    oDTPRow.Item("Volume") = dtRow.Item("Volume")
                    oDTPRow.Item("TotalAmount") = dtRow.Item("TotalAmount")
                    oDTP.Rows.Add(oDTPRow)
                Next

                Return oDTP

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing

            End Try
        End Function

        ''' <summary>
        ''' 从TDX的二进制文件得到价格信息
        ''' </summary>
        ''' <param name="strSymbol"></param>
        ''' <param name="dtStartDate"></param>
        ''' <param name="dtEndDate"></param>
        ''' <param name="strCategory"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function FeedTDX_PureDAYFormatFile(ByVal strSymbol As String, Optional ByVal dtStartDate As String = "", Optional ByVal dtEndDate As String = "", Optional ByVal strCategory As String = "Stock") As DataTable
            Try
                'Dim oDTP As New CDTDaily_Stock

                Dim sWholeFileName As String
                Dim sPrefix As String

                If strCategory = "Stock" Then
                    sPrefix = GlobalVariables.GetStockCodePrePostfix(strSymbol, GlobalVariables.EDataFeedSource.TDX_Normal)
                    If InStr(sPrefix, "SZ") Then
                        sWholeFileName = GlobalVariables.g_TDXPath_DailySZ & "\" & sPrefix & strSymbol & ".day"
                    ElseIf InStr(sPrefix, "SH") Then
                        sWholeFileName = GlobalVariables.g_TDXPath_DailySH & "\" & sPrefix & strSymbol & ".day"
                    End If

                ElseIf strCategory = "Fund" Then
                    'sPrefix = GlobalVariables.GetFundCodePrePostfix(strSymbol, GlobalVariables.EDataFeedSource.TDX_Normal)
                    'sWholeFileName = GlobalVariables.g_TDXPath_DailyExtended & "\33#" & strSymbol & ".day"
                    If IO.File.Exists(GlobalVariables.g_TDXPath_DailyExtended & "\33#" & strSymbol & ".day") Then
                        sWholeFileName = GlobalVariables.g_TDXPath_DailyExtended & "\34#" & strSymbol & ".day"
                    End If

                ElseIf strCategory = "Index" Then
                    sPrefix = GlobalVariables.GetIndexCodePrePostfix(strSymbol, GlobalVariables.EDataFeedSource.TDX_Normal)
                    If InStr(sPrefix, "SZ") Then
                        sWholeFileName = GlobalVariables.g_TDXPath_DailySZ & "\" & sPrefix & strSymbol & ".day"
                        '先在\vipdoc\sz\lday中找，没有的话在g_TDXPath_DailyExtended中找
                        If IO.File.Exists(sWholeFileName) = False Then
                            sWholeFileName = GlobalVariables.g_TDXPath_DailyExtended & "\" & sPrefix & strSymbol & ".day"
                        End If
                    ElseIf InStr(sPrefix, "SH") Then
                        sWholeFileName = GlobalVariables.g_TDXPath_DailySH & "\" & sPrefix & strSymbol & ".day"
                        '先在\vipdoc\sh\lday中找，没有的话说明是扩展数据，就在g_TDXPath_DailyExtended中找
                        If IO.File.Exists(sWholeFileName) = False Then
                            sWholeFileName = GlobalVariables.g_TDXPath_DailyExtended & "\" & sPrefix & strSymbol & ".day"
                        End If
                    End If
                End If

                If IO.File.Exists(sWholeFileName) = False Then
                    'MsgBox("没有" & strSymbol & "数据")
                    Return Nothing
                    Exit Function
                End If

                Dim dt As New DataTable

                dt = FeedParseTDX_DAYFormatFile(sWholeFileName, dtStartDate, dtEndDate)
                Return dt

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        ''' <summary>
        ''' 解析Day文件二进制格式，适用于股票、基金、指数
        ''' </summary>
        ''' <param name="strSymbol"></param>
        ''' <param name="dtStartDate"></param>
        ''' <param name="dtEndDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function FeedParseTDX_DAYFormatFile(ByVal sFileWholeName As String, Optional ByVal dtStartDate As String = "", Optional ByVal dtEndDate As String = "") As DataTable


            Dim FS As New System.IO.FileStream(sFileWholeName, IO.FileMode.Open)
            Dim Br As New System.IO.BinaryReader(FS) ', System.Text.Encoding.UTF32)
            Dim dt As New DataTable

            dt.Columns.Add("TheDate", GetType(System.String))
            dt.Columns.Add("OpenPrice", GetType(System.Single))
            dt.Columns.Add("HighPrice", GetType(System.Single))
            dt.Columns.Add("LowPrice", GetType(System.Single))
            dt.Columns.Add("ClosePrice", GetType(System.Single))
            dt.Columns.Add("Volume", GetType(System.Single))
            dt.Columns.Add("TotalAmount", GetType(System.Single))

            Dim oRow As DataRow

            '''''为什么要把价格 /100????
            Try
                For i = 1 To FS.Length / 32
                    oRow = dt.NewRow()
                    Dim strDate As String = Br.ReadInt32
                    strDate = Left(strDate, 4) & "/" & Mid(strDate, 5, 2) & "/" & Right(strDate, 2)
                    oRow.Item("TheDate") = strDate
                    oRow.Item("OpenPrice") = Br.ReadInt32 / 100
                    oRow.Item("HighPrice") = Br.ReadInt32 / 100
                    oRow.Item("LowPrice") = Br.ReadInt32 / 100
                    oRow.Item("ClosePrice") = Br.ReadInt32 / 100
                    oRow.Item("Volume") = Br.ReadInt32
                    oRow.Item("TotalAmount") = Br.ReadInt32
                    Br.ReadInt32()

                    If dtStartDate <> "" And dtEndDate <> "" Then
                        If oRow.Item("TheDate") >= dtStartDate And oRow.Item("TheDate") <= dtEndDate Then
                            dt.Rows.Add(oRow)
                        End If
                    ElseIf dtStartDate = "" And dtEndDate <> "" Then
                        If oRow.Item("TheDate") <= dtEndDate Then
                            dt.Rows.Add(oRow)
                        End If
                    ElseIf dtStartDate <> "" And dtEndDate = "" Then
                        If oRow.Item("TheDate") >= dtStartDate Then
                            dt.Rows.Add(oRow)
                        End If
                    ElseIf dtStartDate = "" And dtEndDate = "" Then
                        dt.Rows.Add(oRow)
                    End If

                Next
                Return dt
            Catch
                Return Nothing

            Finally
                FS.Close()
                FS = Nothing
                Br.Close()
                Br = Nothing
            End Try
        End Function

        '读取通达信导出的前复权日线TXT格式文本数据，需要每日更新。可以根据调用函数文件目录选择普通、前复权、或后复权格式数据
        Private Function FeedParseTDX_TXTFormatFile(ByVal sFileWholeName As String, Optional ByVal dtStartDate As String = "", Optional ByVal dtEndDate As String = "") As DataTable

            Dim dt As New DataTable
            Dim oRow As DataRow

            dt.Columns.Add("TheDate", GetType(System.String))
            dt.Columns.Add("OpenPrice", GetType(System.Single))
            dt.Columns.Add("HighPrice", GetType(System.Single))
            dt.Columns.Add("LowPrice", GetType(System.Single))
            dt.Columns.Add("ClosePrice", GetType(System.Single))
            dt.Columns.Add("TurnoverVolume", GetType(System.Single))
            dt.Columns.Add("TurnoverValue", GetType(System.Single))

            Dim sLine() As String

            For Each line As String In IO.File.ReadLines(sFileWholeName)
                'Dim oDT As New CDataPrice_Stock

                If line.Contains(",") Then
                    oRow = dt.NewRow()
                    sLine = Split(line, ",")
                    oRow.Item("TheDate") = sLine(0)
                    oRow.Item("OpenPrice") = sLine(1)
                    oRow.Item("HighPrice") = sLine(2)
                    oRow.Item("LowPrice") = sLine(3)
                    oRow.Item("ClosePrice") = sLine(4)
                    oRow.Item("TurnoverVolume") = sLine(5)
                    oRow.Item("TurnoverValue") = sLine(6)

                    If dtStartDate <> "" And dtEndDate <> "" Then
                        If oRow.Item("TheDate") >= dtStartDate And oRow.Item("TheDate") <= dtEndDate Then
                            dt.Rows.Add(oRow)
                        End If
                    ElseIf dtStartDate = "" And dtEndDate <> "" Then
                        If oRow.Item("TheDate") <= dtEndDate Then
                            dt.Rows.Add(oRow)
                        End If
                    ElseIf dtStartDate <> "" And dtEndDate = "" Then
                        If oRow.Item("TheDate") >= dtStartDate Then
                            dt.Rows.Add(oRow)
                        End If
                    ElseIf dtStartDate = "" And dtEndDate = "" Then
                        dt.Rows.Add(oRow)
                    End If
                End If

            Next line

            Return dt

        End Function
        ''' <summary>
        ''' 得出股票前、后、正常复权数据，从TXT格式读取
        ''' </summary>
        ''' <param name="strCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FeedStockDaily_General_TDX(strSymbol As String, Optional ByVal pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj, Optional ByVal dtStartDate As String = "", Optional ByVal dtEndDate As String = "") As CDTDaily_Stock
            Dim oDTP As New CDTDaily_Stock
            Dim oDTPRow As DataRow
            Dim dt As New DataTable
            Dim sWholeFileName As String
            Dim sPrefix As String

            Try

                sPrefix = GlobalVariables.GetStockCodePrePostfix(strSymbol, GlobalVariables.EDataFeedSource.TDX_FQ)
                If pat = EPriceAdjustedType.ForAdj Then
                    sWholeFileName = GlobalVariables.g_TDXPath_Daily_FA & "\" & sPrefix & strSymbol & ".txt"
                ElseIf pat = EPriceAdjustedType.Normal Then
                    sWholeFileName = GlobalVariables.g_TDXPath_Daily_Normal & "\" & sPrefix & strSymbol & ".txt"
                ElseIf pat = EPriceAdjustedType.BacAdj Then
                    sWholeFileName = GlobalVariables.g_TDXPath_Daily_Normal & "\" & sPrefix & strSymbol & ".txt"
                End If

                If IO.File.Exists(sWholeFileName) = False Then
                    'MsgBox("没有" & strSymbol & "数据")
                    Return Nothing
                    Exit Function
                End If

                dt = FeedParseTDX_TXTFormatFile(sWholeFileName, dtStartDate, dtEndDate)

                Dim iRowTotal As Int16, i As Int16

                iRowTotal = dt.Rows.Count

                For i = 0 To iRowTotal - 1
                    oDTPRow = oDTP.NewRow
                    oDTPRow.Item("Symbol") = strSymbol
                    If pat = EPriceAdjustedType.ForAdj Then
                        oDTPRow.Item("TheDate") = dt.Rows(i).Item("TheDate")
                        oDTPRow.Item("OpenPrice_FA") = dt.Rows(i).Item("OpenPrice")
                        oDTPRow.Item("HighPrice_FA") = dt.Rows(i).Item("HighPrice")
                        oDTPRow.Item("LowPrice_FA") = dt.Rows(i).Item("LowPrice")
                        oDTPRow.Item("ClosePrice_FA") = dt.Rows(i).Item("ClosePrice")

                    ElseIf pat = EPriceAdjustedType.BacAdj Then
                        oDTPRow.Item("TheDate") = dt.Rows(i).Item("TheDate")
                        oDTPRow.Item("OpenPrice_BA") = dt.Rows(i).Item("OpenPrice")
                        oDTPRow.Item("HighPrice_BA") = dt.Rows(i).Item("HighPrice")
                        oDTPRow.Item("LowPrice_BA") = dt.Rows(i).Item("LowPrice")
                        oDTPRow.Item("ClosePrice_BA") = dt.Rows(i).Item("ClosePrice")
                    ElseIf pat = EPriceAdjustedType.Normal Then
                        oDTPRow.Item("TheDate") = dt.Rows(i).Item("TheDate")
                        oDTPRow.Item("OpenPrice") = dt.Rows(i).Item("OpenPrice")
                        oDTPRow.Item("HighPrice") = dt.Rows(i).Item("HighPrice")
                        oDTPRow.Item("LowPrice") = dt.Rows(i).Item("LowPrice")
                        oDTPRow.Item("ClosePrice") = dt.Rows(i).Item("ClosePrice")
                    End If
                    oDTPRow.Item("TurnoverVolume") = dt.Rows(i).Item("TurnoverVolume")
                    oDTPRow.Item("TurnoverValue") = dt.Rows(i).Item("TurnoverValue")

                    oDTP.Rows.Add(oDTPRow)
                Next

                Return oDTP

            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        '读取通达信导出的前复权日线数据，可能需要每日更新
        Public Function GetStockDaily_QFQ_Obsolete(strCode As String) As CDTDaily_Stock_Collection
            Dim oDTP As New CDTDaily_Stock_Collection


            Dim sWholeFileName As String
            Dim sPrefix As String

            sPrefix = GlobalVariables.GetStockCodePrePostfix(strCode, GlobalVariables.EDataFeedSource.TDX_FQ)
            sWholeFileName = GlobalVariables.g_TDXPath_Daily_FA & "\" & sPrefix & strCode & ".txt"

            Dim sLine() As String

            If IO.File.Exists(sWholeFileName) = False Then
                MsgBox("没有" & strCode & "数据")
                Return Nothing
                Exit Function
            End If


            For Each line As String In IO.File.ReadLines(sWholeFileName)
                Dim oDT As New CDataPrice_Stock

                If line.Contains(",") Then
                    sLine = Split(line, ",")
                    oDT.ThisDate = sLine(0)
                    oDT.ClosePrice_PreAdj = sLine(1)
                    oDT.HighPrice_PreAdj = sLine(2)
                    oDT.LowPrice_PreAdj = sLine(3)
                    oDT.ClosePrice_PreAdj = sLine(4)
                    oDT.TurnoverVolume = sLine(5)
                    oDT.TurnoverValue = sLine(6)
                    oDTP.PriceData.Add(oDT)
                End If
                oDT = Nothing
            Next line

            Return oDTP

        End Function

        '为除权数据
        Public Function GetStockDaily_dotNetMethod_SampleCode(strCode As String, strFilename As String) As CDTDaily_Stock_Collection
            Dim oDTP As New CDTDaily_Stock_Collection
            Dim oDT As New CDataPrice_Stock

            'Dim binReader As New IO.BinaryReader

            Dim byFile() As Byte
            Dim blockFile(4) As Byte
            Dim blockLine(32) As Byte
            strFilename = "D:\sz000001.day"

            'Dim fs As IO.FileStream = IO.File.OpenRead(strFilename)
            'byFile = IO.File.ReadAllBytes(strFilename)

            Dim FS As New System.IO.FileStream(strFilename, IO.FileMode.Open)

            Dim Br As New System.IO.BinaryReader(FS) ', System.Text.Encoding.UTF32)

            'blockFile = Br.ReadBytes(4)
            'oDT.ThisDate = Br.ReadInt32
            'Debug.Print(oDT.ThisDate)
            'While Not FS.Length

            'End While
            For i = 1 To FS.Length / 32
                oDT.ThisDate = Br.ReadInt32
                Debug.Print(oDT.ThisDate)
                oDT.OpenPrice = Br.ReadInt32
                Debug.Print(oDT.OpenPrice)
                oDT.HighPrice = Br.ReadInt32
                oDT.LowPrice = Br.ReadInt32
                oDT.ClosePrice = Br.ReadInt32
                oDT.TurnoverVolume = Br.ReadInt32
                oDT.TurnoverValue = Br.ReadInt32
                Br.ReadInt32()

            Next

            For i = 1 To byFile.Count / 8
                oDT.ThisDate = System.Text.Encoding.UTF32.GetString(Br.ReadBytes(4))
                Debug.Print(oDT.ThisDate)

            Next
            'byFile = IO.File.ReadAllBytes(strFilename)


            'IO.File.read()
            'For i = 0 To byFile.GetUpperBound(0) / 32 - 1 '/32为有多少行或多少日数据

            'For j = 0 To 3
            '    string1 = byFile(j + i * 32)
            'Next

            'oDT.ThisDate = string1
            'Debug.Print(string1)
            'For j = 1 To 8
            'fs.Read(blockFile, i + j, 4)

            'oDT.OpenPrice =
            'oDT.HighPrice =
            'oDT.LowPrice =
            'oDT.ClosePrice =
            'oDT.Amount =
            'oDT.LowPrice = 
            'Next
            'oDT.ThisDate = bFile(1 + 8 * i)
            'oDT.OpenPrice = bFile(2 + 8 * i)
            'oDT.HighPrice = bFile(3 + 8 * i)
            'oDT.LowPrice = bFile(4 + 8 * i)
            'oDT.ClosePrice = bFile(5 + 8 * i)
            'oDT.Amount = bFile(6 + 8 * i)
            'oDT.LowPrice = bFile(7 + 8 * i)

            'Cells(i, 1) = b.a1
            'Cells(i, 2) = b.a2
            'Cells(i, 3) = b.a3
            'Cells(i, 4) = b.a4
            'Cells(i, 5) = b.a5
            'Cells(i, 6) = b.a6
            'Cells(i, 7) = b.a7
            'Cells(i, 8) = b.a8
            'a1 As Long '标示码 a2 As Long '日期 a3 As Single '开盘价 a4 As Single '最高价 a5 As Single '最低价 a6 As Single '收盘价 a7 As Single '成交金额 a8 As Long '成交量
            'Next

            Return oDTP
        End Function
        Public Function GetStockDaily2Stream(strCode As String) As IO.StreamReader


            Return Nothing
        End Function

        ''' <summary>
        ''' '得到指数价格数据 OBSOLETE
        ''' </summary>
        ''' <param name="strCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetIndexDaily(strCode As String) As CDTDaily_Index
            'Dim oDTP As New CDTDaily_Index

            'Dim sWholeFileName As String
            'Dim sPrefix As String

            'sPrefix = GlobalVariables.GetStockCodePrePostfix(strCode, GlobalVariables.EDataFeedSource.TDX_FQ)
            'sWholeFileName = GlobalVariables.g_TDXPath_Daily_FA & "\" & sPrefix & strCode & ".txt"


            'If IO.File.Exists(sWholeFileName) = False Then
            '    MsgBox("没有" & strCode & "数据")
            '    Return Nothing
            '    Exit Function
            'End If

            ' '''''''''''''
            ''待加入数据
            ' '''''''''''''


            'Return oDTP

        End Function


        ''' <summary>
        ''' 从TDX读出数据，进行比对，如果有新的，则更新该Datatable
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateStockDaily_TDX(ByVal strSymbol As String, ByRef dt As CDTDaily_Stock) As Boolean
            Dim i, iTotal As Integer


            Try
                iTotal = dt.Rows.Count


            Catch ex As Exception

            End Try


        End Function
    End Class
End Namespace
