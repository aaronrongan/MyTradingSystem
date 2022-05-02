
Imports System.Xml
Imports System.Net
Imports System.Web
Imports System.IO
Imports System.Text.RegularExpressions
Imports MyTradingSystem.DataEntity

Namespace DataFeed

    Public Class CDataFeedWeb_IndexInfo
        Inherits CDataFeedWeb

        'Option Explicit
        '从网页免费源抓取数据

        '抓取指数列表
        '分3步，分别从上证、中证、深证的对应网页抓取数据
        '输入：
        '输出： 代码，名称

        '上证系列指数     .shtml\?INDEX_Code=[\w|\d]+\">\w+               http://www.sse.com.cn/market/sseindex/indexlist/
        '中证             code=[\w|\d]+&&subdir=1" class="a14">\w+        http://www.csindex.com.cn/sseportal/csiportal/zs/indexreport.do?type=1
        '深证             无效 zs/\d+/t\d+_\d+.htm" target="_blank">[^\d|^a-z][\w]+</a>       但要修改其中的PageNum=1~17
        '                      <u>.{1,8}</u>  其中的单数为代码，双数为名称  http://www.szse.cn/szseWeb/FrontController.szse?ACTIONID=7&AJAX=AJAX-TRUE&CATALOGID=1812&tab1PAGENUM=3&tab1PAGECOUNT=17&tab1RECORDCOUNT=164&TABKEY=tab1 
        Public Function GetIndexList() As String(,)

            Dim sArray(2, 0) As String     '存储代码和名称变量
            Dim strWebResponse As String
            Dim strPattern As String
            Dim iTotal As Integer = 0
            Dim jTotal As Integer = 2
            Dim iStart1 As Integer, iStart2 As Integer, iStringLength As Integer
            Dim iPrev As Integer

            Dim i As Integer, j As Integer, k As Integer

            '========================上证指数==============================
            strWebResponse = GetWebPage(m_strPageAddress_Index1, m_strPageCoding_Index1).ReadToEnd
            strPattern = m_strPagePattern_Index1

            iPrev = 0
            'i = iPrev
            iTotal = Regex.Matches(strWebResponse, strPattern).Count
            ReDim Preserve sArray(2, iTotal + iPrev)
            For Each match As Match In Regex.Matches(strWebResponse, strPattern)
                'Debug.Print(match.Value)
                iStart1 = InStr(match.Value, "=") + 1
                sArray(0, i) = Mid(match.Value, iStart1, 6)     '指数代码 "ZS." &
                'Debug.Print(sArray(0, i))

                iStart2 = InStr(match.Value, ">") + 1
                iStringLength = Len(match.Value)
                sArray(1, i) = Right(match.Value, iStringLength - iStart2 + 1)  '指数名称
                'Debug.Print(sArray(1, i))
                i = i + 1
            Next

            Debug.Print("上证总数：" & iTotal)

            '========================囯证指数==============================
            strWebResponse = GetWebPage(m_strPageAddress_Index2, m_strPageCoding_Index2).ReadToEnd
            strPattern = m_strPagePattern_Index2
            'i = i - 2   '因为数组索引要小一位
            iPrev = sArray.GetUpperBound(1)
            i = iPrev
            iTotal = Regex.Matches(strWebResponse, strPattern).Count
            ReDim Preserve sArray(2, iTotal + iPrev)
            For Each match As Match In Regex.Matches(strWebResponse, strPattern)

                iStart1 = InStr(match.Value, "=") + 1
                sArray(0, i) = Mid(match.Value, iStart1, 6)     '指数代码 "ZS." &

                iStart2 = InStr(match.Value, ">") + 1
                iStringLength = Len(match.Value)
                sArray(1, i) = Right(match.Value, iStringLength - iStart2 + 1)  '指数名称

                i = i + 1
            Next

            Debug.Print("国证总数：" & iTotal)

            '========================深证指数==============================
            Dim iPageNum As Integer
            Dim szWebUrl As String

            iPrev = sArray.GetUpperBound(1)
            i = iPrev
            iTotal = 0
            For iPageNum = 1 To 17
                szWebUrl = "http://www.szse.cn/szseWeb/FrontController.szse?ACTIONID=7&AJAX=AJAX-TRUE&CATALOGID=1812&tab1PAGENUM=" & iPageNum & "&tab1PAGECOUNT=17&tab1PAGECOUNT=17&tab1RECORDCOUNT=164&TABKEY=tab1"
                strWebResponse = GetWebPage(szWebUrl, "GB2312").ReadToEnd
                strPattern = "<u>.{1,10}</u>"
                iTotal = iTotal + Regex.Matches(strWebResponse, strPattern).Count / 2
            Next

            ReDim Preserve sArray(2, iTotal + iPrev)
            'i = i - 1   '因为数组索引要小一位
            For iPageNum = 1 To 17
                szWebUrl = "http://www.szse.cn/szseWeb/FrontController.szse?ACTIONID=7&AJAX=AJAX-TRUE&CATALOGID=1812&tab1PAGENUM=" & iPageNum & "&tab1PAGECOUNT=17&tab1PAGECOUNT=17&tab1RECORDCOUNT=164&TABKEY=tab1"
                strWebResponse = GetWebPage(szWebUrl, "GB2312").ReadToEnd

                strPattern = m_strPagePattern_Index3
                Dim bCode As Boolean = True
                For Each match As Match In Regex.Matches(strWebResponse, strPattern)
                    'Debug.Print(match.Value)
                    If bCode = True Then
                        iStart1 = InStr(match.Value, ">") + 1
                        sArray(0, i) = Mid(match.Value, iStart1, 6)          '指数代码 "ZS." &
                        bCode = False
                        'Debug.Print(sArray(0, i))
                    Else
                        iStart1 = InStr(match.Value, ">") + 1
                        iStart2 = InStr(match.Value, "/") + 1
                        iStringLength = iStart2 - iStart1 - 2
                        sArray(1, i) = Mid(match.Value, iStart1, iStringLength)  '指数名称
                        bCode = True
                        'Debug.Print(sArray(1, i))
                        i = i + 1
                    End If
                Next

                'k = sArray.GetUpperBound(1) - j
            Next
            Debug.Print("深证总数：" & iTotal)

            Return sArray
        End Function

    End Class

End Namespace

