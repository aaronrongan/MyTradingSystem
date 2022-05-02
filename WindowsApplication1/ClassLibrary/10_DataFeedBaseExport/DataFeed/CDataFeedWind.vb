Imports WAPIWrapperCSharp

Imports System.Data

Namespace DataFeed


    Public Class CDataFeedWind
        Private m_WindAPI As WAPIWrapperCSharp.WindAPI
        Private m_WindData As WindData



        ''' <summary>
        ''' 将查询的字段转为DataTable格式, 一维格式
        ''' </summary>
        ''' <param name="strQueryType"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function WindData2DataTable_1D() As DataTable
            Try

                Dim dt As New DataTable

                'm_WindData = m_WindAPI.tquery(strQueryType)

                Dim FieldArray As String()

                If (m_WindData.errorCode = 0) Then
                    Dim fl As Int16 = m_WindData.GetFieldLength

                    ReDim FieldArray(fl)

                    For i = 0 To fl - 1
                        dt.Columns.Add(m_WindData.fieldList(i), GetType(System.String))
                    Next

                    Try
                        Dim iRowTotal As Int16 = m_WindData.GetDataLength / fl
                        Dim row As DataRow

                        For i = 0 To iRowTotal - 1
                            row = dt.NewRow
                            For j = 0 To fl - 1

                                Dim str As String = m_WindData.data(j)
                                row(j) = str

                            Next
                            dt.Rows.Add(row)
                        Next
                    Catch ex As Exception

                    End Try

                    WindData2DataTable_1D = dt
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                RaiseError()
            End Try

        End Function

        ''' <summary>
        ''' 将查询的字段转为DataTable格式, 二维格式
        ''' </summary>
        ''' <param name="strQueryType"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function WindData2DataTable_2D() As DataTable
            Try

                Dim dt As New DataTable

                'm_WindData = m_WindAPI.tquery(strQueryType)

                Dim FieldArray As String()

                If (m_WindData.errorCode = 0) Then
                    Dim fl As Int16 = m_WindData.GetFieldLength

                    ReDim FieldArray(fl)

                    For i = 0 To fl - 1
                        dt.Columns.Add(m_WindData.fieldList(i), GetType(System.String))
                    Next

                    Try
                        Dim iRowTotal As Int16 = m_WindData.GetDataLength / fl
                        Dim row As DataRow

                        For i = 0 To iRowTotal - 1
                            row = dt.NewRow
                            For j = 0 To fl - 1

                                Dim str As String = m_WindData.data(j, i)
                                row(j) = str

                            Next
                            dt.Rows.Add(row)
                        Next
                    Catch ex As Exception

                    End Try

                    WindData2DataTable_2D = dt
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                RaiseError()
            End Try

        End Function

        Public Sub New()
            m_WindAPI = New WindAPI
            m_WindData = New WindData


        End Sub


        Protected Overrides Sub Finalize()
            MyBase.Finalize()

            m_WindAPI.stop()
        End Sub

        Private Sub RaiseError()
            If m_WindData.errorCode <> 0 Then
                MsgBox("错误:" & m_WindAPI.getErrorMsg(m_WindData.errorCode))
            End If
        End Sub

        Public Function GetErrorCode() As Integer
            Return m_WindData.errorCode
        End Function

        Public Sub Start()
            m_WindAPI.start()
        End Sub

        Public Function IsConnected() As Boolean
            Return m_WindAPI.isconnected

        End Function

        Public Function GetPriceDaily(strSymbol As String, BeginDate As String, EndDate As String) As DataTable
            strSymbol = strSymbol & GetSymbolPostFix(strSymbol)
            m_WindData = m_WindAPI.wsd(strSymbol, "open, high, low, close", CDate(BeginDate), CDate(EndDate), "")


            Return WindData2DataTable_1D()

        End Function

        Public Function GetPriceRealtime(strSymbol As String) As DataTable

            strSymbol = strSymbol & GetSymbolPostFix(strSymbol)

            ' m_WindData = m_WindAPI.wsq(strSymbol, "rt_open,rt_low,rt_last,rt_last_amt,rt_last_vol,rt_latest,rt_vol,rt_amt,rt_chg,rt_pct_chg,rt_high_limit,rt_low_limit,rt_swing,rt_vwap,rt_upward_vol,rt_downward_vol,rt_bsize_total,rt_asize_total,rt_vol_ratio", "")

            m_WindData = m_WindAPI.wsq(strSymbol, "rt_ask1,rt_ask2,rt_ask3,rt_ask4,rt_ask5,rt_ask6,rt_ask7,rt_ask8,rt_ask9,rt_ask10,rt_bid1,rt_bid2,rt_bid3,rt_bid4,rt_bid5,rt_bid6,rt_bid7,rt_bid8,rt_bid9,rt_bid10,rt_bsize1,rt_bsize2,rt_bsize10,rt_asize9,rt_asize10", "")
            Return WindData2DataTable_1D()

        End Function

        '跳价不提供
        'Public Function GetPriceTick(strSymbol As String, BeginDate As String, EndDate As String) As DataTable

        '    m_WindData = m_WindAPI.wst(strSymbol, "rt_open, rt_high, rt_low, rt_close", CDate(BeginDate), CDate(EndDate), "")


        '    Return WindData2DataTable_1D()

        'End Function

        Public Function GetPriceMinutes(strSymbol As String, BeginDate As String, EndDate As String) As DataTable
            strSymbol = strSymbol & GetSymbolPostFix(strSymbol)

            m_WindData = m_WindAPI.wsi(strSymbol, "open,high,low,close,volume,amt,chg,pct_chg,oi,BIAS,BOLL", BeginDate, EndDate, "")


            Return WindData2DataTable_1D()

        End Function

        Public Function GetPortforlio(pfName As String, strViewName As String, strOptions As String) As DataTable

            m_WindData = m_WindAPI.wpf(pfName, strViewName, strOptions)


            Return WindData2DataTable_1D()

        End Function

        Public Function GetTimeList() As Date()

            'Dim list As Date()
            'Dim outputString As String
            'Dim iTotalCount As Int16 = m_WindData.timeList.Count
            'ReDim list(iTotalCount)

            'For i = 0 To iTotalCount - 1
            '    list(i) = m_WindData.timeList(i)
            'Next

            Return m_WindData.timeList 'list

        End Function

        Public Function GetFieldList() As String()
            Return m_WindData.fieldList
        End Function

        Public Function GetCodeList() As String()
            Return m_WindData.codeList
        End Function

        Public Function GetSymbolPostFix(strSymbol As String) As String
            If strSymbol.Length = 6 Then
                If strSymbol.Substring(0, 1) = "0" Or strSymbol.Substring(0, 1) = "3" Then
                    GetSymbolPostFix = ".SZ"
                ElseIf strSymbol.Substring(0, 1) = "6" Then
                    GetSymbolPostFix = ".SH"
                End If
            End If
        End Function

        Public Sub StopWind()
            m_WindAPI.stop()
        End Sub



    End Class

End Namespace
