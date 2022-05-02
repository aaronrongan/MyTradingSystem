Imports System.Xml
Imports System.Net
Imports System.Web
Imports System.IO
Imports System.Text.RegularExpressions
Imports MyTradingSystem.DataEntity

'GetWebPage为基础函数，返回网页字符串数值
'供其它抓取函数调用。
'正则表达式放在相关的抓取函数中

Namespace DataFeed


    Public Class CDataFeedWeb


        Protected m_strPageAddress_Index1 As String = "http://www.sse.com.cn/market/sseindex/indexlist/"
        Protected m_strPageCoding_Index1 As String = "UTF8"
        Protected m_strPagePattern_Index1 As String = ".shtml\?INDEX_Code=[\w|\d]+\"">\w+"

        Protected m_strPageAddress_Index2 As String = "http://www.csindex.com.cn/sseportal/csiportal/zs/indexreport.do?type=1"
        Protected m_strPageCoding_Index2 As String = "GB2312"
        Protected m_strPagePattern_Index2 As String = "code=[\w|\d]+&&subdir=1"" class=""a14"">\w+"

        Protected m_strPageAddress_Index3 As String '2段字符串+中间一个变量如何拼起来？
        Protected m_strPageCoding_Index3 As String
        Protected m_strPagePattern_Index3 As String = "<u>.{1,10}</u>"

        Protected m_strPageAddress_Stock1 As String = "http://quote.eastmoney.com/stocklist.html"
        Protected m_strPageCoding_Stock1 As String = "GB2312"
        Protected m_strPagePattern_Stock1 As String = "(sh6|sz0|sz2|sz3|sz6).+html"">.+\("

        Protected m_strPageAddress_Fund1 As String = "http://fund.10jqka.com.cn/datacenter/jjgspm/" '"http://fund.10jqka.com.cn/datacenter/all/"
        Protected m_strPageCoding_Fund1 As String = "GB2312"
        '分3层解析
        Protected m_strPagePattern_Fund1_1 As String = "<h3>.*?</table>\r"        '第1层取出68个基金，并取出每个基金公司名，如B-XX基金
        Protected m_strPagePattern_Fund1_2 As String = "<caption>.*?</table>"     '第2层取出2段，并取出开放式、封闭式基金，类型 
        Protected m_strPagePattern_Fund1_3 As String = "\d{6}/"" target='_blank'>[\w,\(,\/,\)]+</a></td>" '= \d{6}/" target='_blank'>[\w,\(,\/,\)]+</a></td> '第3层取出旗下各公司的名称

        Protected m_strPageAddress_FundCompany As String = "http://fund.eastmoney.com/Data/FundRankScale.aspx?v=0.18060004990547895"
        Protected m_strPageCoding_FundCompany As String = "UTF8"
        Protected m_strPagePattern_FundCompany As String = "\['[\w,\W].*?\]"


        '用.net专有的HttpWebRequest类实现，而不是经典的Microsoft.XMLHttp
        Public Shared Function GetWebPage(sURL As String, Optional sEncode As String = "UTF8") As StreamReader
            Dim url As String = sURL
            Dim httpReq As HttpWebRequest
            Dim httpResp As HttpWebResponse
            Dim httpURL As New Uri(url)
            'Dim oDoc As Object
            'Dim oStream As New StreamWriter

            Dim oXD As New XmlDocument

            On Error Resume Next
            'oDoc = CreateObject("htmlfile")

            httpReq = CType(WebRequest.Create(httpURL), HttpWebRequest)
            httpReq.Method = "GET"

            httpResp = CType(httpReq.GetResponse(), HttpWebResponse)
            httpReq.KeepAlive = False

            Dim reader As IO.StreamReader

            If sEncode = "UTF8" Or sEncode = "" Then
                reader = New IO.StreamReader(httpResp.GetResponseStream, System.Text.Encoding.UTF8)
            ElseIf sEncode = "GB2312" Then
                reader = New IO.StreamReader(httpResp.GetResponseStream, System.Text.Encoding.GetEncoding("gb2312"))
            End If

            'Dim respHTML As String = reader.ReadToEnd()  'respHTML就是网页内容

            'respHTML = WebUtility.HtmlDecode(respHTML)

            'respHTML = System.Text.RegularExpressions.Regex.Replace(respHTML, "<[^>]*>", "")

            'File.WriteAllText("D:\1.txt", respHTML)

            'respHTML = System.Text.RegularExpressions.Regex.Replace(respHTML, "<[^>]*>", "")

            'File.WriteAllText("D:\2.txt", respHTML)
            'reader.
            Return reader
            reader = Nothing
            ' = reader.ReadToEnd()
            'oXD.
            ''oXD.Load(sURL)
            'Debug.Print(oXD.InnerText)
            'oDoc.body.innerhtml = "test"
            'Debug.Print(oDoc.body.innerhtml)

        End Function
        Public Sub FeedDatafromSina(sSymbol As String, sStartDate As String, sEndDate As String)


        End Sub
       
        '用Reg Expression计算符合匹配的字符串，放入数组中 。
        '该函数有问题，匹配无法做到相同，看来只能分开
        Private Sub GetDataArray(ByRef sArray(,) As String, strPattern As String, sStream As String)

            Dim iTotal As Integer
            Dim jTotal As Integer = 2
            Dim iStart1 As Integer, iStart2 As Integer, iStringLength As Integer
            Dim iPrev As Integer

            iPrev = sArray.GetUpperBound(1)

            Dim i As Integer = iPrev

            ReDim Preserve sArray(2, iTotal + iPrev)
            iTotal = Regex.Matches(sStream, strPattern).Count
            For Each match As Match In Regex.Matches(sStream, strPattern)
                'Debug.Print(match.Value)
                iStart1 = InStr(match.Value, "=") + 1
                sArray(0, i) = "ZS." & Mid(match.Value, iStart1, 6)     '指数代码
                'Debug.Print(sArray(0, i))

                iStart2 = InStr(match.Value, ">") + 1
                iStringLength = Len(match.Value)
                sArray(1, i) = Right(match.Value, iStringLength - iStart2 + 1)
                'Debug.Print(sArray(1, i))
                i = i + 1
            Next

        End Sub


        Protected Function GetCodePrefix_Postfix(sSymbol As String, sSource As String) As String

            If sSource = "Sohu" Then
                'End
            End If

            If sSource = "Yahoo" Then
                '上证股票(6...)是股票代码后面加上.ss，深证股票(0/2/3)是股票代码后面加上.sz

                If Left(sSymbol, 1) = "6" Then
                    GetCodePrefix_Postfix = ".ss"
                ElseIf Left(sSymbol, 1) = "0" Or Left(sSymbol, 1) = "2" Or Left(sSymbol, 1) = "3" Then
                    GetCodePrefix_Postfix = ".sz"
                End If
            End If

            If sSource = "Sina" Then
                If Left(sSymbol, 1) = "6" Then
                    GetCodePrefix_Postfix = "sh"
                ElseIf Left(sSymbol, 1) = "0" Or Left(sSymbol, 1) = "2" Or Left(sSymbol, 1) = "3" Then
                    GetCodePrefix_Postfix = "sz"
                End If
            End If

        End Function

        '基本方法，从网页读取需要的数据，并进行正则表达式提取
        '注意编码方式、GB还有Unicode
        Public Sub URLRead()

        End Sub


    End Class
End Namespace
