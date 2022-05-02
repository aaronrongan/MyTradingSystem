Imports System.Xml
Imports System.Net
Imports System.Web
Imports System.IO
Imports System.Text.RegularExpressions
Imports MyTradingSystem.DataEntity

Namespace DataFeed



    Public Class CDataFeedWeb_FundInfo
        Inherits CDataFeedWeb
        ''' <summary>
        ''' 获取基金列表 编码+名称+类型
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFundList(dt As DataTable) As Boolean
            Dim sArray(2, 0) As String     '存储代码和名称变量
            Dim strWebResponse As String
            Dim strPattern As String
            Dim iTotal As Integer = 0
            Dim jTotal As Integer = 2
            Dim iStart1 As Integer, iStart2 As Integer, iStringLength As Integer, iEnd2 As Integer
            Dim iPrev As Integer
            Dim iRow As Integer = 0

            Dim i As Integer, j As Integer, k As Integer

            Try

                '========================基金列表==============================
                strWebResponse = GetWebPage(m_strPageAddress_Fund1, m_strPageCoding_Fund1).ReadToEnd
                strPattern = m_strPagePattern_Fund1_3
                Debug.Print(strWebResponse)
                iPrev = 0

                iTotal = Regex.Matches(strWebResponse, strPattern).Count
                ReDim Preserve sArray(2, iTotal + iPrev)
                For Each match As Match In Regex.Matches(strWebResponse, strPattern)

                    'iStart1 = InStr(match.Value, "=") + 1
                    'sArray(0, i) = Left(match.Value, 6)
                    Dim oRow As DataRow = dt.NewRow()

                    oRow.Item(1) = Left(match.Value, 6) '基金编码

                    iStart2 = InStr(match.Value, ">") + 1 '首字符开始位置
                    iEnd2 = InStr(match.Value, "/a></td>")
                    iStringLength = iEnd2 - iStart2 'Len(match.Value)
                    'sArray(1, i) = Mid(match.Value, iStart2, iStringLength - 1)
                    oRow.Item(2) = Mid(match.Value, iStart2, iStringLength - 1) '基金名称

                    dt.Rows.Add(oRow)

                    i = i + 1
                Next

                Return True
            Catch ex As Exception
                Return False
            End Try


        End Function


        ''' <summary>
        ''' 读取基金公司信息
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFundCompanyInfo(dt As CDTInfo_FundCompany) As Boolean

            Try
                Dim sArray(12) As String     '存储代码和名称变量
                Dim strWebResponse As String
                Dim strPattern As String
                Dim iTotal As Integer = 0
                Dim jTotal As Integer = 2
                Dim iPrev As Integer
                Dim iRow As Integer = 0

                Dim i As Integer, j As Integer, k As Integer

                Try

                    '========================基金列表==============================
                    strWebResponse = GetWebPage(m_strPageAddress_FundCompany, m_strPageCoding_FundCompany).ReadToEnd
                    strPattern = m_strPagePattern_FundCompany
                    Debug.Print(strWebResponse)
                    iPrev = 0
                    iTotal = Regex.Matches(strWebResponse, strPattern).Count

                    '取得如['80000220','南方基金管理有限公司','1998-03-06','118','杨小松','NFJJ','','2807.14','★★★★','南方基金','15','2015/11/13 0:00:00']

                    For Each match As Match In Regex.Matches(strWebResponse, strPattern)

                        Dim oRow As DataRow = dt.NewRow()
                        Dim strRequired As String

                        'Protected m_Col11Name As String = "FullName"        '基金公司全名
                        'Protected m_Col12Name As String = "ShortName"       '基金公司简称
                        'Protected m_Col13Name As String = "FoundDate"       '基金公司成立时间
                        'Protected m_Col14Name As String = "GeneralManager"  '总经理
                        'Protected m_Col15Name As String = "Volume"          '资产规模
                        'Protected m_Col16Name As String = "FundsNumber"     '拥有的基金数目
                        'Protected m_Col17Name As String = "UpdatedDate"     '情况更新时间
                        'Protected m_Col18Name As String = "RateHaitong"     '海通评级
                        'Protected m_Col19Name As String = "Website"         '基金公司网址
                        'Protected m_Col110Name As String = "EastMoneyID"    '东方财富网编号
                        'Protected m_Col111Name As String = "THSID"          '同花顺编号
                        'Protected m_Col112Name As String = "PYAbbre"        '拼音简写

                        strRequired = Mid(match.Value, 2, Len(match.Value) - 2) '将前后[]字符去除

                        sArray = Split(strRequired, ",")

                        oRow.Item(1) = Mid(sArray(1), 2, Len(sArray(1)) - 2) 'FullName
                        oRow.Item(2) = Mid(sArray(9), 2, Len(sArray(9)) - 2) 'ShortName
                        oRow.Item(3) = Mid(sArray(2), 2, Len(sArray(2)) - 2) '基金公司成立时间
                        oRow.Item(4) = Mid(sArray(4), 2, Len(sArray(4)) - 2) '总经理

                        If sArray(7) <> "''" Then
                            oRow.Item(5) = Mid(sArray(7), 2, Len(sArray(7)) - 2) '资产规模
                        Else
                            oRow.Item(5) = 0 '"Empty"
                        End If

                        If sArray(3) <> "''" Then
                            oRow.Item(6) = Mid(sArray(3), 2, Len(sArray(3)) - 2) '拥有的基金数目
                        Else
                            oRow.Item(6) = 0
                        End If

                        If sArray(11) <> "''" Then
                            oRow.Item(7) = Mid(sArray(11), 2, Len(sArray(11)) - 2) '情况更新时间
                        Else
                            oRow.Item(7) = DBNull.Value
                        End If

                        oRow.Item(8) = Mid(sArray(8), 2, Len(sArray(8)) - 2) '海通评级
                        oRow.Item(10) = Mid(sArray(0), 2, Len(sArray(0)) - 2) '东方财富网编号
                        oRow.Item(12) = Mid(sArray(5), 2, Len(sArray(5)) - 2) '拼音简写

                        dt.Rows.Add(oRow)

                        i = i + 1
                    Next

                    Return True
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False
                End Try

                Return True
            Catch ex As Exception
                Return Nothing
            End Try


        End Function


        ''' <summary>
        ''' 抓取基金公司列表，ID+FullName+ShortName
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFundCompanyList(dt As DataTable) As Boolean
            Dim sArray(2, 0) As String     '存储代码和名称变量
            Dim strWebResponse As String
            Dim strPattern As String
            Dim iTotal As Integer = 0
            Dim jTotal As Integer = 2
            Dim iStart1 As Integer, iStart2 As Integer, iStringLength As Integer, iEnd2 As Integer
            Dim iPrev As Integer
            Dim iRow As Integer = 0

            Dim i As Integer, j As Integer, k As Integer

            Try


                '========================基金列表==============================
                strWebResponse = GetWebPage(m_strPageAddress_Fund1, m_strPageCoding_Fund1).ReadToEnd
                strPattern = m_strPagePattern_Fund1_1
                Debug.Print(strWebResponse)
                iPrev = 0

                iTotal = Regex.Matches(strWebResponse, strPattern).Count
                ReDim Preserve sArray(2, iTotal + iPrev)
                For Each match As Match In Regex.Matches(strWebResponse, strPattern)

                    'iStart1 = InStr(match.Value, "=") + 1
                    'sArray(0, i) = Left(match.Value, 6)
                    Dim oRow As DataRow = dt.NewRow()

                    oRow.Item(1) = Left(match.Value, 6) '基金公司名称



                    dt.Rows.Add(oRow)

                    i = i + 1
                Next


                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function


    End Class

End Namespace

