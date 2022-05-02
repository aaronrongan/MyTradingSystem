Namespace DataFeed

Public Class CDataFeedDatayes_Price
inherits CDataFeedDatayes


        Public Function FeedStockDailyPrice(Optional secID As String = "", Optional strSymbol As String = "", Optional strTradeDate As String = "", Optional BeginDate As String = "", Optional EndDate As String = "") As String
            'secID   String()    3:          选1()    证券内部编码，可通过交易代码在getSecID获取到。（可多值输入，最多输入50只）
            'ticker()    string 3:          选1() 股票交易代码, 如 '000001'（可多值输入，最多输入50只）
            'tradeDate()     Date    3:          选1()    输入一个日期，不输入其他请求参数，可获取到一天全部沪深股票日行情数据，输入格式“YYYYMMDD”
            'BeginDate   Date()            否()   起始日期，输入格式“YYYYMMDD”
            'EndDate Date            否() 截止日期，输入格式“YYYYMMDD”
            'field() string  是() 可选参数，用","分隔,默认为空，返回全部字段，不选即为默认值。返回字段见下方

            '返回字段
            Dim strField As String = "secID,tradeDate,ticker,preClosePrice,actPreClosePrice,openPrice,highestPrice,lowestPrice,closePrice,turnoverVol,turnoverValue,dealAmount,turnoverRate,accuAdjFactor,negMarketValue,marketValue,PE,PE1,PB"

            m_URL = String.Format("/api/market/getMktEqud.json?field={0}&beginDate={1}&endDate={2}&secID={3}&ticker={4}&tradeDate={5}", strField, BeginDate, EndDate, secID, strSymbol, strTradeDate)



            Return GetData(m_URL)
        End Function

        ''' <summary>
        ''' 读取股票日线数据
        ''' </summary>
        ''' <param name="secID"></param>
        ''' <param name="strSymbol"></param>
        ''' <param name="strTradeDate"></param>
        ''' <param name="BeginDate"></param>
        ''' <param name="EndDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FeedStockDailyPriceDataTable(Optional secID As String = "", Optional strSymbol As String = "", Optional strTradeDate As String = "", Optional BeginDate As String = "", Optional EndDate As String = "") As DataTable
            Try

                Dim stringRaw As String = FeedStockDailyPrice(secID, strSymbol, strTradeDate, BeginDate, EndDate)
                Debug.Print(stringRaw)
                If AssessReturnMsg(stringRaw) = False Then
                    Return Nothing
                    Exit Function
                End If

                Dim dt As New DataTable

                dt.Columns.Add("secID", GetType(System.String))

                dt.Columns.Add("tradeDate", GetType(System.String))


                dt.Columns.Add("ticker", GetType(System.String))
                dt.Columns.Add("preClosePrice", GetType(System.Double))
                dt.Columns.Add("actPreClosePrice", GetType(System.Double))
                dt.Columns.Add("openPrice", GetType(System.Double))

                dt.Columns.Add("highestPrice", GetType(System.Double))
                dt.Columns.Add("lowestPrice", GetType(System.Double))
                dt.Columns.Add("closePrice", GetType(System.Double))
                dt.Columns.Add("turnoverVol", GetType(System.Double))
                dt.Columns.Add("turnoverValue", GetType(System.Double))

                dt.Columns.Add("dealAmount", GetType(System.Double))
                dt.Columns.Add("turnoverRate", GetType(System.Double))
                dt.Columns.Add("accuAdjFactor", GetType(System.Double))
                dt.Columns.Add("negMarketValue", GetType(System.Double))
                dt.Columns.Add("marketValue", GetType(System.Double))

                dt.Columns.Add("PE", GetType(System.Double))
                dt.Columns.Add("PE1", GetType(System.Double))
                dt.Columns.Add("PB", GetType(System.Double))

                DatayesJsonToDataTable(stringRaw, dt)

                Return dt

            Catch ex As Exception

            End Try

        End Function

        Public Function FeedIndexDailyPrice(Optional secID As String = "", Optional strSymbol As String = "", Optional strTradeDate As String = "", Optional BeginDate As String = "", Optional EndDate As String = "") As String
            'secID   String()    3:          选1()    证券内部编码，可通过交易代码在getSecID获取到。（可多值输入，最多输入50只）
            'ticker()    string 3:          选1() 股票交易代码, 如 '000001'（可多值输入，最多输入50只）
            'tradeDate()     Date    3:          选1()    输入一个日期，不输入其他请求参数，可获取到一天全部沪深股票日行情数据，输入格式“YYYYMMDD”
            'BeginDate   Date()            否()   起始日期，输入格式“YYYYMMDD”
            'EndDate Date            否() 截止日期，输入格式“YYYYMMDD”
            'field() string  是() 可选参数，用","分隔,默认为空，返回全部字段，不选即为默认值。返回字段见下方

            '返回字段
            Dim strField As String = "indexID,tradeDate,ticker,preCloseIndex,openIndex,highestIndex,lowestIndex,closeIndex,turnoverVol,turnoverValue,CHG,CHGPct"

            m_URL = String.Format("/api/market/getMktIdxd.json?field={0}&beginDate={1}&endDate={2}&indexID={3}&ticker={4}&tradeDate={5}", strField, BeginDate, EndDate, secID, strSymbol, strTradeDate)



            Return GetData(m_URL)
        End Function

        ''' <summary>
        ''' 读取指数日线数据
        ''' </summary>
        ''' <param name="secID"></param>
        ''' <param name="strSymbol"></param>
        ''' <param name="strTradeDate"></param>
        ''' <param name="BeginDate"></param>
        ''' <param name="EndDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FeedIndexDailyPriceDataTable(Optional secID As String = "", Optional strSymbol As String = "", Optional strTradeDate As String = "", Optional BeginDate As String = "", Optional EndDate As String = "") As DataTable
            Try

                Dim stringRaw As String = FeedIndexDailyPrice(secID, strSymbol, strTradeDate, BeginDate, EndDate)
                Debug.Print(stringRaw)
                If AssessReturnMsg(stringRaw) = False Then
                    Return Nothing
                    Exit Function
                End If

                Dim dt As New DataTable

                dt.Columns.Add("indexID", GetType(System.String))
                dt.Columns.Add("tradeDate", GetType(System.String))
                dt.Columns.Add("ticker", GetType(System.String))

                dt.Columns.Add("preCloseIndex", GetType(System.Double))

                dt.Columns.Add("openIndex", GetType(System.Double))

                dt.Columns.Add("highestIndex", GetType(System.Double))
                dt.Columns.Add("lowestIndex", GetType(System.Double))
                dt.Columns.Add("closeIndex", GetType(System.Double))
                dt.Columns.Add("turnoverVol", GetType(System.Double))
                dt.Columns.Add("turnoverValue", GetType(System.Double))

                dt.Columns.Add("CHG", GetType(System.Double))
                dt.Columns.Add("CHGPct", GetType(System.Double))

                DatayesJsonToDataTable(stringRaw, dt)

                Return dt

            Catch ex As Exception

            End Try

        End Function

        ''' <summary>
        ''' 读取股票日线数据，前复权
        ''' </summary>
        ''' <param name="secID"></param>
        ''' <param name="strSymbol"></param>
        ''' <param name="strTradeDate"></param>
        ''' <param name="BeginDate"></param>
        ''' <param name="EndDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FeedStockDailyPricePreAdj(Optional secID As String = "", Optional strSymbol As String = "", Optional strTradeDate As String = "", Optional BeginDate As String = "", Optional EndDate As String = "") As String
            'secID   String()    3:          选1()    证券内部编码，可通过交易代码在getSecID获取到。（可多值输入，最多输入50只）
            'ticker()    string 3:          选1() 股票交易代码, 如 '000001'（可多值输入，最多输入50只）
            'tradeDate()     Date    3:          选1()    输入一个日期，不输入其他请求参数，可获取到一天全部沪深股票日行情数据，输入格式“YYYYMMDD”
            'BeginDate   Date()            否()   起始日期，输入格式“YYYYMMDD”
            'EndDate Date            否() 截止日期，输入格式“YYYYMMDD”
            'field() string  是() 可选参数，用","分隔,默认为空，返回全部字段，不选即为默认值。返回字段见下方

            '返回字段
            Dim strField As String = "secID,tradeDate,ticker,openPrice,highestPrice,lowestPrice,closePrice,turnoverVol,turnoverValue"

            m_URL = String.Format("/api/market/getMktEqudAdj.json?field={0}&secID={1}&ticker={2}&beginDate={3}&endDate={4}&tradeDate={5}", strField, secID, strSymbol, BeginDate, EndDate, strTradeDate)



            Return GetData(m_URL)
        End Function

        ''' <summary>
        ''' 读取股票日线数据，前复权
        ''' </summary>
        ''' <param name="secID"></param>
        ''' <param name="strSymbol"></param>
        ''' <param name="strTradeDate"></param>
        ''' <param name="BeginDate"></param>
        ''' <param name="EndDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FeedStockDailyPriceDataTablePreAdj(Optional secID As String = "", Optional strSymbol As String = "", Optional strTradeDate As String = "", Optional BeginDate As String = "", Optional EndDate As String = "") As DataTable
            Try

                Dim stringRaw As String = FeedStockDailyPricePreAdj(secID, strSymbol, strTradeDate, BeginDate, EndDate)
                Debug.Print(stringRaw)
                If AssessReturnMsg(stringRaw) = False Then
                    Return Nothing
                    Exit Function
                End If

                Dim dt As New DataTable

                dt.Columns.Add("secID", GetType(System.String))
                dt.Columns.Add("tradeDate", GetType(System.String))
                dt.Columns.Add("ticker", GetType(System.String))
                dt.Columns.Add("openPrice", GetType(System.Double))

                dt.Columns.Add("highestPrice", GetType(System.Double))
                dt.Columns.Add("lowestPrice", GetType(System.Double))
                dt.Columns.Add("closePrice", GetType(System.Double))
                dt.Columns.Add("turnoverVol", GetType(System.Double))
                dt.Columns.Add("turnoverValue", GetType(System.Double))

                DatayesJsonToDataTable(stringRaw, dt)

                Return dt

            Catch ex As Exception

            End Try

        End Function

        Public Sub New()

        End Sub
    End Class
End Namespace