Imports MyTradingSystem.DataBase
Imports MyTradingSystem.DataEntity

Namespace DataFeed

    Public Class CDataFeedMatlabFaruto

        ''' <summary>
        ''' 获取基金净值数据
        ''' </summary>
        Public Sub FeedFundNetValue(ByRef oDTP As CDTDaily, strSymbol As String, Optional ByVal dtStartDate As String = "", Optional ByVal dtEndDate As String = "")

            Dim oDTPRow As DataRow
            Dim sWholeFileName As String
            Dim sPrefix As String

            If oDTP.TableName = "FundPriceDaily" Then
                sWholeFileName = GlobalVariables.g_MatlabFarutoPath_FundNetValue & "\" & strSymbol & ".csv" 'TDX的基金数据无效，采用Matlab Faruto导出的数据
            End If

            Try

                If IO.File.Exists(sWholeFileName) = False Then
                    Exit Sub
                End If

                Dim dt As New DataTable

                dt = FeedParse_FundNetValue(sWholeFileName, dtStartDate, dtEndDate)

                Dim iRowTotal As Int16, i As Int16

                iRowTotal = dt.Rows.Count

                For Each dtRow In dt.Rows
                    oDTPRow = oDTP.NewRow
                    oDTPRow.Item("Symbol") = strSymbol
                    oDTPRow.Item("TheDate") = dtRow.Item("TheDate")
                    oDTPRow.Item("NetValue") = dtRow.Item("NetValue")
                    oDTPRow.Item("AccuNetValue") = dtRow.Item("AccuNetValue")
                    oDTP.Rows.Add(oDTPRow)
                Next


            Catch ex As Exception
                MsgBox(ex.Message)


            End Try

        End Sub

        ''' <summary>
        ''' 获取除权除息数据
        ''' </summary>
        Public Sub FeedXRDData()

        End Sub

        ''' <summary>
        ''' 解析基金净值Txt文件
        ''' </summary>
        ''' <param name="strSymbol"></param>
        ''' <param name="dtStartDate"></param>
        ''' <param name="dtEndDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function FeedParse_FundNetValue(ByVal sFileWholeName As String, Optional ByVal dtStartDate As String = "", Optional ByVal dtEndDate As String = "") As DataTable

            Dim dt As New DataTable
            Dim oRow As DataRow

            dt.Columns.Add("NetValue", GetType(System.String))
            dt.Columns.Add("AccuNetValue", GetType(System.Single))
            dt.Columns.Add("TheDate", GetType(System.String))

            Dim sLine() As String
            Dim i As Int16 = 0

            For Each line As String In IO.File.ReadLines(sFileWholeName)
                If i > 0 Then
                    If line.Contains(",") Then
                        oRow = dt.NewRow()
                        sLine = Split(line, ",")
                        oRow.Item("TheDate") = Left(sLine(0), 4) & "/" & Mid(sLine(0), 5, 2) & "/" & Right(sLine(0), 2)
                        oRow.Item("NetValue") = sLine(1)
                        oRow.Item("AccuNetValue") = sLine(2)


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
                Else
                    i += 1
                End If


            Next line

            Return dt

        End Function


    End Class

End Namespace
