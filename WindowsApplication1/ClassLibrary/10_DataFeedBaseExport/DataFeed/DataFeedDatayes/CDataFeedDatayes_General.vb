


Namespace DataFeed


    Public Class CDataFeedDatayes_General
        Inherits CDataFeedDatayes



        ' ''' <summary>
        ' ''' 获取证券基本信息
        ' ''' </summary>
        'Public Function FeedSecuritiesInfo() As String
        '    m_URL = "/api/master/getSecID.json?field=&assetClass=&ticker=000001,600000&partyID=&cnSpell="
        '    Return GetData(m_URL)
        'End Function

        ''' <summary>
        ''' 获取行业分类
        ''' </summary>
        Public Function GetIndustryClassification() As String

        End Function

        ''' <summary>
        ''' 获取概念分类
        ''' </summary>
        Public Function GetConceptClassification() As String

        End Function

        ' ''' <summary>
        ' ''' 获取板块分类
        ' ''' </summary>
        'Public Function GetSecurityType() As String
        '    m_URL = "/api/master/getSecType.json?field="
        '    Return GetData(m_URL)
        'End Function

        ' ''' <summary>
        ' ''' 获取板块分类
        ' ''' </summary>
        'Public Function GetBlockClassificationDataTable() As DataTable
        '    Try


        '    Dim stringRaw As String = GetBlockClassification()

        '    Dim dt As New DataTable

        '    'dt.Columns.Add()
        '    DatayesJsonToDataTable(stringRaw, dt)

        '        Return dt

        '    Catch ex As Exception

        '    End Try

        'End Function

        ''' <summary>
        ''' 获取证券分类
        ''' </summary>
        Public Function GetSecurityType() As String
            m_URL = "/api/master/getSecType.json?field="
            Return GetData(m_URL)
        End Function

        ''' <summary>
        ''' 获取板块分类
        ''' </summary>
        Public Function GetSecurityTypeDataTable() As DataTable
            Try


                Dim stringRaw As String = GetSecurityType()

                Dim dt As New DataTable

                dt.Columns.Add("typeID", GetType(System.String))
                dt.Columns.Add("typeName", GetType(System.String))
                dt.Columns.Add("parentID", GetType(System.String))
                dt.Columns.Add("typeLevel", GetType(System.Int16))
               
                DatayesJsonToDataTable(stringRaw, dt)

                Return dt

            Catch ex As Exception

            End Try

        End Function

        ''' <summary>
        ''' 获取证券交易日历，默认为股市
        ''' </summary>
        Public Function FeedTradeCalendar(Optional ByVal exchangeCD As String = "XSHG,XSHE", Optional BeginDate As String = "", Optional EndDate As String = "") As String
            m_URL = String.Format("/api/master/getTradeCal.json?field=&exchangeCD={0}&beginDate={1}&endDate={2}", exchangeCD, BeginDate, EndDate)
            Return GetData(m_URL)
        End Function


        ''' <summary>
        ''' 获取证券交易日历，默认为股市，返回DataTable
        ''' </summary>
        Public Function FeedTradeCalendarDataTable(Optional ByVal exchangeCD As String = "XSHG", Optional BeginDate As String = "", Optional EndDate As String = "") As DataTable
            Dim stringRaw As String = FeedTradeCalendar(exchangeCD, BeginDate, EndDate)
            If AssessReturnMsg(stringRaw) = False Then
                Return Nothing
                Exit Function
            End If
            Dim dt As New DataTable

            dt.Columns.Add("exchangeCD", GetType(System.String))
            dt.Columns.Add("calendarDate", GetType(System.String))
            dt.Columns.Add("isOpen", GetType(System.Int16))
            dt.Columns.Add("prevTradeDate", GetType(System.String))
            dt.Columns.Add("isWeekEnd", GetType(System.Int16))
            dt.Columns.Add("isMonthEnd", GetType(System.Int16))
            dt.Columns.Add("isQuarterEnd", GetType(System.Int16))
            dt.Columns.Add("isYearEnd", GetType(System.Int16))

            DatayesJsonToDataTable(stringRaw, dt)
            Return dt
        End Function

        ''' <summary>
        ''' 获取证券信息，证券类型，可供选择类型：E 股票,B 债券,F 基金,IDX 指数,FU 期货,OP 期权；默认为 E。
        ''' </summary>
        Public Function FeedSecurityInfo(Optional assetClass As String = "E", Optional strSymbol As String = "000001", Optional PartyID As String = "", Optional cnSpell As String = "") As String
            m_URL = String.Format("/api/master/getSecID.json?field=&assetClass={0}&ticker={1}&partyID={2}&cnSpell={3}", assetClass, strSymbol, PartyID, cnSpell)
            Return GetData(m_URL)
        End Function

        ''' <summary>
        ''' 获取证券信息
        ''' </summary>
        ''' 
        Public Function FeedSecurityInfoDataTable(Optional assetClass As String = "E", Optional strSymbol As String = "000001", Optional PartyID As String = "", Optional cnSpell As String = "") As DataTable
            Try


                Dim stringRaw As String = FeedSecurityInfo(assetClass, strSymbol.Trim, PartyID, cnSpell)

                If AssessReturnMsg(stringRaw) = False Then
                    Return Nothing
                    Exit Function
                End If

                Dim dt As New DataTable

                dt.Columns.Add("secID", GetType(System.String))
                dt.Columns.Add("ticker", GetType(System.String))
                dt.Columns.Add("secShortName", GetType(System.String))
                dt.Columns.Add("cnSpell", GetType(System.String))
                dt.Columns.Add("exchangeCD", GetType(System.String))
                dt.Columns.Add("assetClass", GetType(System.String))
                dt.Columns.Add("listStatusCD", GetType(System.String))
                dt.Columns.Add("listDate", GetType(System.String))
                dt.Columns.Add("transCurrCD", GetType(System.String))
                dt.Columns.Add("ISIN", GetType(System.String))
                dt.Columns.Add("partyID", GetType(System.String))

                DatayesJsonToDataTable(stringRaw, dt)

                Return dt

            Catch ex As Exception

            End Try

        End Function

        ''' <summary>
        ''' 获取证券板块成分
        ''' </summary>
        Public Function FeedSecurityTypeRelation(Optional secID As String = "", Optional strSymbol As String = "", Optional typeID As String = "") As String
            m_URL = String.Format("/api/master/getSecTypeRel.json?field=&typeID={0}&secID={1}&ticker={2}", typeID, secID, strSymbol)
            Return GetData(m_URL)
        End Function

        ''' <summary>
        ''' 获取证券板块成分
        ''' </summary>
        ''' 
        Public Function FeedSecurityTypeRelationDataTable(Optional secID As String = "", Optional strSymbol As String = "", Optional typeID As String = "") As DataTable
            Try

                ' strSymbol = "000001"
                Dim stringRaw As String = FeedSecurityTypeRelation(secID, strSymbol, typeID)
                If AssessReturnMsg(stringRaw) = False Then
                    'MsgBox("无返回数据")
                    Return Nothing
                    Exit Function
                End If
                Dim dt As New DataTable


                dt.Columns.Add("typeID", GetType(System.String))
                dt.Columns.Add("typeName", GetType(System.String))
                dt.Columns.Add("secID", GetType(System.String))
                dt.Columns.Add("ticker", GetType(System.String))
                dt.Columns.Add("exchangeCD", GetType(System.String))
                dt.Columns.Add("secShortName", GetType(System.String))

                DatayesJsonToDataTable(stringRaw, dt)

                Return dt

            Catch ex As Exception

            End Try

        End Function

    End Class

End Namespace
