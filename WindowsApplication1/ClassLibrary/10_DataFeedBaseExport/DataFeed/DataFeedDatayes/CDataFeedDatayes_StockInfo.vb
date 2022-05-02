Namespace DataFeed

Public Class CDataFeedDatayes_StockInfo
inherits CDataFeedDatayes

        ''' <summary>
        ''' 获取证券信息，证券类型，可供选择类型：E 股票,B 债券,F 基金,IDX 指数,FU 期货,OP 期权；默认为 E。
        ''' </summary>
        Public Function FeedEquityInfo(Optional equTypeCD As String = "A", Optional secID As String = "", Optional ticker As String = "", Optional listStatusCD As String = "") As String
            m_URL = String.Format("/api/equity/getEqu.json?field=&listStatusCD={0}&secID={1}&ticker={2}&equTypeCD={3}", listStatusCD, secID, ticker, equTypeCD)
            Return GetData(m_URL)
        End Function

        ''' <summary>
        ''' 获取证券信息
        ''' </summary>
        ''' 
        Public Function FeedEquityInfoDataTable(Optional equTypeCD As String = "A", Optional secID As String = "", Optional ticker As String = "", Optional listStatusCD As String = "") As DataTable
            Try

                Dim stringRaw As String = FeedEquityInfo(equTypeCD, secID, ticker, listStatusCD)

                If AssessReturnMsg(stringRaw) = False Then
                    Return Nothing
                    Exit Function
                End If

                Dim dt As New DataTable

                dt.Columns.Add("secID", GetType(System.String))
                dt.Columns.Add("ticker", GetType(System.String))
                dt.Columns.Add("exchangeCD", GetType(System.String))
                dt.Columns.Add("ListSectorCD", GetType(System.Int32))
                dt.Columns.Add("ListSector", GetType(System.String))
                dt.Columns.Add("transCurrCD", GetType(System.String))
                dt.Columns.Add("secShortName", GetType(System.String))
                dt.Columns.Add("secFullName", GetType(System.String))
                dt.Columns.Add("listStatusCD", GetType(System.String))
                dt.Columns.Add("listDate", GetType(System.DateTime))

                dt.Columns.Add("delistDate", GetType(System.DateTime))
                dt.Columns.Add("equTypeCD", GetType(System.String))
                dt.Columns.Add("equType", GetType(System.String))
                dt.Columns.Add("exCountryCD", GetType(System.String))
                dt.Columns.Add("partyID", GetType(System.Int64))
                dt.Columns.Add("totalShares", GetType(System.Double))
                dt.Columns.Add("nonrestFloatShares", GetType(System.Double))
                dt.Columns.Add("nonrestfloatA", GetType(System.Double))
                dt.Columns.Add("officeAddr", GetType(System.String))
                dt.Columns.Add("primeOperating", GetType(System.String))

                dt.Columns.Add("endDate", GetType(System.DateTime))
                dt.Columns.Add("TShEquity", GetType(System.Double))


                DatayesJsonToDataTable(stringRaw, dt)

                Return dt

            Catch ex As Exception

            End Try

        End Function

End Class
End Namespace