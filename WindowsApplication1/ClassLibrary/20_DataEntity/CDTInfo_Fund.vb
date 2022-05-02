Imports MyTradingSystem.DataBase
Imports System.IO
Imports System.Text.RegularExpressions
Imports MyTradingSystem.DataFeed

Namespace DataEntity


    Public Class CDTInfo_Fund
        Inherits CDTInfo



        ''' <summary>
        ''' 类型1(大分类，如普通基金、货币基金、理财型、封闭、其它型)
        ''' </summary>
        Private m_Col11Name As String = "Type1"    '基金类型-开放、封闭
        ''' <summary>
        ''' 类型2(子分类，如股票型、债券、ETF、混合型)
        ''' </summary>
        Private m_Col12Name As String = "Type2"
        ''' <summary>
        ''' 所属基金公司ID
        ''' </summary>
        Private m_Col13Name As String = "FundCompanyID"
        ''' <summary>
        ''' 基金经理
        ''' </summary>
        Private m_Col14Name As String = "Manager"
        ''' <summary>
        ''' 基金规模
        ''' </summary>
        Private m_Col15Name As String = "Volume"
        ''' <summary>
        ''' 成立日期
        ''' </summary>
        Private m_Col16Name As String = "FoundDate"
        ''' <summary>
        ''' 返回简明列表，包含基金ID、Symbol,Name
        ''' </summary>
        Private m_dtFundIDSymbolNameList As DataTable
        ''' <summary>
        ''' 简称
        ''' </summary>
        Private m_Col17Name As String = "ShortName"    '基金类型
        ''' <summary>
        ''' 
        ''' 简称
        ''' </summary>
        Private m_Col18Name As String = "SubscribeStatus"    '基金类型
        Public Event InsertProgress(ByVal iProgress As Integer)

        Public Sub New()
            MyBase.New()

            Try
                Dim Col11 As DataColumn = Me.Columns.Add(m_Col11Name, GetType(System.String))

                Dim Col12 As DataColumn = Me.Columns.Add(m_Col12Name, GetType(System.String))

                Dim Col13 As DataColumn = Me.Columns.Add(m_Col13Name, GetType(System.String))

                Dim Col14 As DataColumn = Me.Columns.Add(m_Col14Name, GetType(System.String))

                Dim Col15 As DataColumn = Me.Columns.Add(m_Col15Name, GetType(System.Single))

                Dim Col16 As DataColumn = Me.Columns.Add(m_Col16Name, GetType(System.DateTime))

                Dim Col17 As DataColumn = Me.Columns.Add(m_Col17Name, GetType(System.String))

                Dim Col18 As DataColumn = Me.Columns.Add(m_Col18Name, GetType(System.String))

                m_strSQLTableName = "FundInfo"
                Me.TableName = m_strSQLTableName

            Catch ex As Exception

            End Try
        End Sub

        ''' <summary>
        ''' 将网页采集得的基金信息数组填充到DataTable
        ''' </summary>
        ''' <param name="sArray"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FillTablefromArray(sArray(,) As String) As Boolean
            Try

            Catch ex As Exception

            Finally

            End Try


        End Function



        ''' <summary>
        ''' 每次插入一行基金数据到SQL
        ''' </summary>
        Public Sub InsertTable2SQLbyRow()

        End Sub

        ''' <summary>
        ''' 根据基金编码得到该基金的数据网页
        ''' </summary>
        Private Function GetFundWebPage() As String

        End Function


        ''' <summary>
        ''' 对基金公司进行遍历，抓取所有基金信息，基于GetMutiFundInfobyCompanyfromWeb_EasyMoney
        ''' </summary>
        Public Sub FeedAllFundsInfofromWeb_EasyMoney()

            Dim strWebResponse As String
            Dim objDFW As New DataFeed.CDataFeedWeb
            Dim objFC As New CDTInfo_FundCompany
            Dim dt As New DataTable     '基金公司列表

            '找出基金公司列表，第2个字段为symbol
            objFC.GetFundCompanyListfromSQL(dt)

            Dim i As Int16, iTotal As Int16 = dt.Rows.Count
            'iTotal = 10
            Dim strCompanyURL As String
            Dim strCompanyID As String
            '第一次大循环，搜索各个基金公司
            For i = 0 To iTotal - 1
                Try
                    strCompanyURL = objFC.GetFundComanyWebPage_EasyMoney(Trim(dt.Rows(i).Item(2)))
                    strCompanyID = Trim(dt.Rows(i).Item(0))
                    strWebResponse = CDataFeedWeb.GetWebPage(strCompanyURL, "GB2312").ReadToEnd

                    'If InStr(Trim(dt.Rows(i).Item(1)), "银华") Then
                    FeedMutiFundInfobyCompanyfromWeb_EasyMoney(strWebResponse, strCompanyID)
                    RaiseEvent InsertProgress(i + 1)
                    'End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next


        End Sub


        ''' <summary>
        ''' 从网页得到某个基金公司所有基金的数据，基于GetFundInfofromWeb_EasyMoney做循环
        ''' </summary>
        Private Sub FeedMutiFundInfobyCompanyfromWeb_EasyMoney(ByVal strWebResponse As String, ByVal strCompanyID As String)
            Dim strPattern1 As String = "\[\w{2,3}基金\].*?(<div class=\""s6\""></div>)" '区分新发、普通、理财、其它、封闭类别"
            Dim strTag As String
            Dim iCategory As Int16 = 0

            For Each match As Match In Regex.Matches(strWebResponse, strPattern1)   '第一次分层

                strWebResponse = match.Value
                strTag = Mid(strWebResponse, 2, 2)

                If strTag = "新发" Then

                    FeedFundInfofromWeb_NewFund_EasyMoney(strWebResponse, strCompanyID)

                ElseIf strTag = "普通" Then
                    FeedFundInfofromWeb_CurrentFund_EasyMoney(1, strWebResponse, strCompanyID)

                ElseIf strTag = "货币" Then
                    FeedFundInfofromWeb_CurrentFund_EasyMoney(2, strWebResponse, strCompanyID)

                ElseIf strTag = "理财" Then
                    FeedFundInfofromWeb_CurrentFund_EasyMoney(3, strWebResponse, strCompanyID)

                ElseIf strTag = "封闭" Then
                    FeedFundInfofromWeb_CurrentFund_EasyMoney(4, strWebResponse, strCompanyID)

                ElseIf strTag = "其他" Then
                    FeedFundInfofromWeb_CurrentFund_EasyMoney(5, strWebResponse, strCompanyID)

                End If

                'iCategory = iCategory + 1

                ''Debug.Print(match.Value)
                'iStart1 = InStr(match.Value, "=") + 1
                'sArray(0, i) = Mid(match.Value, iStart1, 6)
                ''Debug.Print(sArray(0, i))

                'iStart2 = InStr(match.Value, ">") + 1
                'iStringLength = Len(match.Value)
                'sArray(1, i) = Right(match.Value, iStringLength - iStart2 + 1)  '
                ''Debug.Print(sArray(1, i))
                'i = i + 1
            Next


            'Debug.Print("上证总数：" & iTotal)
            'Debug.Print(strWebResponse)


        End Sub

        ''' <summary>
        ''' 返回简明信息列表
        ''' </summary>
        Public Function GetFundIDSymbolFullNameList() As DataTable

        End Function

        ''' <summary>
        ''' 采集普通、货币等基金类型数据，
        ''' </summary>
        Private Sub FeedFundInfofromWeb_CurrentFund_EasyMoney(ByVal iType As Integer, ByVal strWebResponse As String, ByVal strCompanyID As String) '区分普通、货币、其它等中的100多只基金<td>

            Dim strPattern2_CurrentFund As String = "(<td title=.*?</tr>)"

            For Each match As Match In Regex.Matches(strWebResponse, strPattern2_CurrentFund) '第2次分层
                If iType = 1 Or iType = 5 Then
                    FeedEachFundInfofromWeb_CurrentFund_EasyMoney_A(iType, match.Value, strCompanyID)
                ElseIf iType = 2 Or iType = 3 Then
                    FeedEachFundInfofromWeb_CurrentFund_EasyMoney_B(iType, match.Value, strCompanyID)
                ElseIf iType = 4 Then '封闭基金
                    FeedEachFundInfofromWeb_CurrentFund_EasyMoney_C(iType, match.Value, strCompanyID)
                End If
            Next
        End Sub



        ''' <summary>
        ''' 从网页解析得到每只新发基金的数据
        ''' </summary>
        Private Function FeedEachFundInfofromWeb_NewFund_EasyMoney(ByVal strWebResponse As String, ByVal strCompanyID As String) As Boolean
            Dim strPattern2_NewFund As String = "<td.*?(</td>)"
            Dim m As Match
            Dim iCount As Int16 = 0

            Try
                Dim oRow As DataRow = Me.NewRow()
                For Each match As Match In Regex.Matches(strWebResponse, strPattern2_NewFund)   '第2次分层

                    oRow.Item("Type1") = "新发基金"

                    'Do While iCount < 12
                    If iCount = 0 Then      '如<td title="中银战略新兴产业股票" class="txt_left"><a href="http://fund.eastmoney.com/001677.html">中银战略新兴产业股票</a></br>001677</td>
                        m = Regex.Match(match.Value, "html\"">.*?</a>")     '基金名称，m= html">中银战略新兴产业股票</a>
                        oRow.Item("FullName") = Mid(m.Value, 7, Len(m.Value) - 11)

                        m = Regex.Match(match.Value, "</br>.*</td>")  '基金代码，m= </br>001677</td>
                        oRow.Item("Symbol") = Mid(m.Value, 5, Len(m.Value) - 8)

                    ElseIf iCount = 2 Then '如<td> <a href="/......</sapn><td>股票型</td>
                        m = Regex.Match(match.Value, "<td>.*</td>")  '基金类型，m= <td>股票型</td>
                        If m.Value <> "" Then
                            oRow.Item("Type2") = Mid(m.Value, 4, Len(m.Value) - 9)
                        End If

                    ElseIf iCount = 4 Then  '<td><a href="http://fund.eastmoney.com/f10/jjjl_001677.html">钱亚风云</a></td>
                        m = Regex.Match(match.Value, "html"">.*</a>")  '基金经理，m= html">钱亚风云</a>
                        If m.Value <> "" Then
                            oRow.Item("Manager") = Mid(m.Value, 7, Len(m.Value) - 11)
                        End If
                    Else

                    End If
                    iCount = iCount + 1
                    'Loop

                Next
                Me.Rows.Add(oRow)
                Return True
            Catch ex As Exception
                'MsgBox(ex.Message)
                Return False
            End Try

        End Function
        ''' <summary>
        ''' 从网页解析得到每只新发基金的数据
        ''' </summary>
        Private Function FeedFundInfofromWeb_NewFund_EasyMoney(ByVal strWebResponse As String, ByVal strCompanyID As String) As Boolean
            Dim strPattern2_CurrentFund As String = "(<td title=.*?</tr>)"
            Try

                For Each match As Match In Regex.Matches(strWebResponse, strPattern2_CurrentFund) '第2次分层
                    FeedEachFundInfofromWeb_NewFund_EasyMoney(match.Value, strCompanyID)
                Next
                Return True

            Catch ex As Exception
                Return False

            End Try
        End Function
        ''' <summary>
        ''' 从网页解析得到每只基金的数据，适用普通、其它型
        ''' </summary>
        Private Sub FeedEachFundInfofromWeb_CurrentFund_EasyMoney_A(iType As String, ByVal strWebResponse As String, ByVal strCompanyID As String) '普通基金、其它基金
            Dim strPattern3_CurrentFund As String = "<td.*?(</td>)"
            Dim iCount As Integer = 0
            Dim m As Match
            Dim oRow As DataRow
            oRow = Me.NewRow()
            Try


                For Each match As Match In Regex.Matches(strWebResponse, strPattern3_CurrentFund)   '第3次分层

                    oRow.Item("FundCompanyID") = strCompanyID
                    Try

                        If iCount = 0 Then      '如<td title="中银上证国企100ETF" class="txt_left"><a href="http://fund.eastmoney.com/510270.html">中银上证国企100ETF</a></br>510270</td>

                            m = Regex.Match(match.Value, "html\"">.*?</a>")     '基金名称，m= html">中银战略新兴产业股票</a>
                            oRow.Item("FullName") = Mid(m.Value, 7, Len(m.Value) - 10)

                            m = Regex.Match(match.Value, "</br>.*</td>")  '基金代码
                            oRow.Item("Symbol") = Mid(m.Value, 6, Len(m.Value) - 10)
                            '该Volume获取是否会占用时间?
                            oRow.Item("Volume") = FeedFundInfo_VolumefromWebPage(oRow.Item("Symbol"))
                        ElseIf iCount = 2 Then '如<td>ETF-场内</td>
                            m = Regex.Match(match.Value, "<td>.*</td>")  '基金类型，m= <td>股票型</td>
                            oRow.Item("Type2") = Mid(m.Value, 5, Len(m.Value) - 9)

                        ElseIf iCount = 9 Then  '如<td><a href="http://fund.eastmoney.com/f10/jjjl_510270.html">赵建忠</a></td>
                            m = Regex.Match(match.Value, "html"">.*</a>")  '基金经理，m= html">赵建忠</a>
                            If m.Value <> "" Then
                                oRow.Item("Manager") = Mid(m.Value, 7, Len(m.Value) - 10)
                            End If

                        ElseIf iCount = 10 Then  '如<td>限大额</td>
                            m = Regex.Match(match.Value, "<td>.*</td>") '申购状态
                            If m.Value <> "" Then
                                oRow.Item("SubscribeStatus") = Mid(m.Value, 5, Len(m.Value) - 9)
                            Else

                            End If

                            If iType = 1 Then
                                oRow.Item("Type1") = "普通型基金"
                            ElseIf iType = 5 Then
                                oRow.Item("Type1") = "其他基金"
                            End If

                        End If

                        iCount = iCount + 1
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try
                Next

                Me.Rows.Add(oRow)

            Catch ex As Exception

            End Try
        End Sub

        ''' <summary>
        ''' 从网页解析得到每只基金的数据，适用货币、理财、封闭型
        ''' </summary>
        Private Sub FeedEachFundInfofromWeb_CurrentFund_EasyMoney_B(iType As String, ByVal strWebResponse As String, ByVal strCompanyID As String) '普通基金、其它基金
            Dim strPattern3_CurrentFund As String = "<td.*?(</td>)"
            Dim iCount As Integer = 0
            Dim m As Match
            Dim oRow As DataRow
            oRow = Me.NewRow()
            Try

                oRow.Item("FundCompanyID") = strCompanyID
                For Each match As Match In Regex.Matches(strWebResponse, strPattern3_CurrentFund)   '第3次分层
                    'Debug.Print(match.Value)

                    Try

                        If iCount = 0 Then      '如<td title="中银上证国企100ETF" class="txt_left"><a href="http://fund.eastmoney.com/510270.html">中银上证国企100ETF</a></br>510270</td>


                            m = Regex.Match(match.Value, "html\"">.*?</a>")     '基金名称，m= html">中银战略新兴产业股票</a>
                            oRow.Item("FullName") = Mid(m.Value, 7, Len(m.Value) - 10)

                            m = Regex.Match(match.Value, "</br>.*</td>")  '基金代码
                            oRow.Item("Symbol") = Mid(m.Value, 6, Len(m.Value) - 10)

                            oRow.Item("Volume") = FeedFundInfo_VolumefromWebPage(oRow.Item("Symbol"))
                            'ElseIf iCount = 2 Then '如<td>ETF-场内</td>
                            'm = Regex.Match(match.Value, "<td>.*</td>")  '基金类型，m= <td>股票型</td>
                            'oRow.Item("Type2") = Mid(m.Value, 5, Len(m.Value) - 9)

                        ElseIf iCount = 8 Then  '如<td><a href="http://fund.eastmoney.com/f10/jjjl_510270.html">赵建忠</a></td>
                            m = Regex.Match(match.Value, "html"">.*</a>")  '基金经理，m= html">赵建忠</a>
                            If m.Value <> "" Then
                                oRow.Item("Manager") = Mid(m.Value, 7, Len(m.Value) - 10)
                            End If

                        ElseIf iCount = 9 Then  '如<td>限大额</td>
                            m = Regex.Match(match.Value, "<td>.*</td>") '申购状态
                            If m.Value <> "" Then
                                oRow.Item("SubscribeStatus") = Mid(m.Value, 5, Len(m.Value) - 9)
                            Else

                            End If
                            If iType = 2 Then
                                oRow.Item("Type1") = "货币基金"
                            ElseIf iType = 3 Then
                                oRow.Item("Type1") = "理财基金"
                            ElseIf iType = 4 Then
                                oRow.Item("Type1") = "封闭基金"
                            End If

                        End If

                        iCount = iCount + 1
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try
                Next

                Me.Rows.Add(oRow)

            Catch ex As Exception

            End Try
        End Sub

        ''' <summary>
        ''' 封闭基金解析
        ''' </summary>
        ''' <param name="iType"></param>
        ''' <param name="strWebResponse"></param>
        ''' <param name="strCompanyID"></param>
        ''' <remarks></remarks>
        Private Sub FeedEachFundInfofromWeb_CurrentFund_EasyMoney_C(iType As String, ByVal strWebResponse As String, ByVal strCompanyID As String) '封闭基金
            Dim strPattern3_CurrentFund As String = "<td.*?(</td>)"
            Dim iCount As Integer = 0
            Dim m As Match
            Dim oRow As DataRow
            oRow = Me.NewRow()
            Try

                oRow.Item("FundCompanyID") = strCompanyID

                For Each match As Match In Regex.Matches(strWebResponse, strPattern3_CurrentFund)   '第3次分层

                    Try

                        If iCount = 0 Then      '如<td title="中银上证国企100ETF" class="txt_left"><a href="http://fund.eastmoney.com/510270.html">中银上证国企100ETF</a></br>510270</td>

                            m = Regex.Match(match.Value, "html\"">.*?</a>")     '基金名称，m= html">中银战略新兴产业股票</a>
                            oRow.Item("FullName") = Mid(m.Value, 7, Len(m.Value) - 10)

                            m = Regex.Match(match.Value, "</br>.*</td>")  '基金代码
                            oRow.Item("Symbol") = Mid(m.Value, 6, Len(m.Value) - 10)

                        ElseIf iCount = 8 Then  '如<td><a href="http://fund.eastmoney.com/f10/jjjl_510270.html">赵建忠</a></td>
                            m = Regex.Match(match.Value, "html"">.*</a>")  '基金经理，m= html">赵建忠</a>
                            If m.Value <> "" Then
                                oRow.Item("Manager") = Mid(m.Value, 7, Len(m.Value) - 10)
                            End If

                        End If

                        If iType = 4 Then
                            oRow.Item("Type1") = "封闭基金"
                            iCount = iCount + 1
                        End If
                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try
                Next

                Me.Rows.Add(oRow)

            Catch ex As Exception

            End Try
        End Sub

        ''' <summary>
        ''' 根据基金编码得出基金网址，为采集其中的基金数据做好准备
        ''' </summary>
        Public Function GetFundWebURL_EasyMoney(strSymbol As String) As String
            Return "http://fund.eastmoney.com/" & strSymbol & ".html"
        End Function

        ''' <summary>
        ''' 从基金网页采集其中的规模数据
        ''' </summary>
        Public Function FeedFundInfo_VolumefromWebPage(strSymbol As String) As Single
            Try


                Dim strPattern1 As String = "html'>规.*模.*?(<td>).*?(</td>)"
                Dim strPattern2 As String = "\d.+<"

                Dim iCount As Integer = 0
                Dim m1, m2 As Match
                Dim strWebURL As String = GetFundWebURL_EasyMoney(strSymbol)

                Dim strWebResponse As String = CDataFeedWeb.GetWebPage(strWebURL, "GB2312").ReadToEnd

                m1 = Regex.Match(strWebResponse, strPattern1)   'html'>规.*模.*?(<td>).*?(</td>)
                Dim strResult As String

                If m1.Value <> "" Then
                    m2 = Regex.Match(m1.Value, strPattern2) '如7.65亿元（15-09-30）<
                    If m2.Value <> "" Then

                        Dim iPos As Int16 = InStr(m2.Value, "亿")

                        strResult = Left(m2.Value, iPos - 1)
                        Return CSng(strResult)

                    Else
                        Return 0
                    End If
                Else
                    Return 0

                End If

            Catch ex As Exception
                Return -1
            End Try
        End Function

        Protected Overrides Function AdaptDatafromDataTable(dt_datayes As DataTable) As Boolean

        End Function

        Public Overrides Function UpgradeData(dt As CDTInfo) As Boolean

        End Function
    End Class
End Namespace
