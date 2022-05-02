Namespace DataFeed

Public Class CDataFeedDatayes_IndexInfo
inherits CDataFeedDatayes


        ''' <summary>
        ''' 获取证券信息，证券类型，可供选择类型：E 股票,B 债券,F 基金,IDX 指数,FU 期货,OP 期权；默认为 E。
        ''' </summary>
        Public Function FeedIndexInfo(Optional secID As String = "", Optional ticker As String = "") As String
            m_URL = String.Format("/api/idx/getIdx.json?field=&ticker={0}&secID={1}", secID, ticker)
            Return GetData(m_URL)
        End Function

        ''' <summary>
        ''' 获取证券信息
        ''' </summary>
        ''' 
        Public Function FeedIndexInfoDataTable(Optional secID As String = "", Optional ticker As String = "") As DataTable
            Try

                Dim stringRaw As String = FeedIndexInfo(secID, ticker)

                If AssessReturnMsg(stringRaw) = False Then
                    Return Nothing
                    Exit Function
                End If

                Dim dt As New DataTable

                dt.Columns.Add("secID", GetType(System.String))
                dt.Columns.Add("publishDate", GetType(System.DateTime))
                dt.Columns.Add("secShortName", GetType(System.String))
                dt.Columns.Add("ticker", GetType(System.String))
                dt.Columns.Add("indexTypeCD", GetType(System.String))
                dt.Columns.Add("indexType", GetType(System.String))

                dt.Columns.Add("pubOrgCD", GetType(System.Int64))
                dt.Columns.Add("porgFullName", GetType(System.String))
                dt.Columns.Add("baseDate", GetType(System.DateTime))
                dt.Columns.Add("basePoint", GetType(System.Double))
                dt.Columns.Add("endDate", GetType(System.DateTime))

                DatayesJsonToDataTable(stringRaw, dt)

                Return dt

            Catch ex As Exception

            End Try

        End Function

End Class
End Namespace