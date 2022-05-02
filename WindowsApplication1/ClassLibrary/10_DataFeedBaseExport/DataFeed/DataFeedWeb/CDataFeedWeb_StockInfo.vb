Imports System.Xml
Imports System.Net
Imports System.Web
Imports System.IO
Imports System.Text.RegularExpressions
Imports MyTradingSystem.DataEntity

Namespace DataFeed



    Public Class CDataFeedWeb_StockInfo
        Inherits CDataFeedWeb

        '抓取股票代码 ，用XML做对象
        '匹配码：  /s..\d{5}.html">.{4,13}      http://quote.eastmoney.com/stocklist.html
        Public Sub GetStockCodeList_v1(oxml As Object)

            'oxml.Open("Get", "http://quote.eastmoney.com/stocklist.html", False)
            'oxml.send()

            'Debug.Print(oxml.responseText)
            'Debug.Print(oxml.Status)
            'Debug.Print(oxml.responseXML.xml)

            On Error Resume Next
            Dim oDoc As New Object
            Dim MS As New Object
            Dim ss As New Object
            Dim isGB2312 As Boolean
            Dim oWebContent As New Object
            Dim sWebContent As String
            isGB2312 = True

            'oDoc = CreateObject("htmlfile")
            'MS = CreateObject("MSScriptControl.ScriptControl")
            'MS.Language = "JScript"
            With CreateObject("Microsoft.XMLHTTP")
                .Open("GET", "http://quote.eastmoney.com/stocklist.html", False)
                .Send()
                'oDoc.body.innerHTML = .responseBody 'responseText
                'ss = oDoc.body.innerText
                'Microsoft.VisualBasic.FileOpen( "D:\文本.txt" For Append As #1

                'Print #1, ss
                'Close #1

                If isGB2312 Then
                    oWebContent = .ResponseBody
                    sWebContent = System.Text.Encoding.Default.GetString(oWebContent)
                    Debug.Print(sWebContent)
                Else
                    oWebContent = .ResponseText
                    sWebContent = oWebContent.ToString
                    Debug.Print(sWebContent)
                End If
            End With
        End Sub


        '抓取股票代码  ， 用SortedList作为参数
        '匹配码：        http://quote.eastmoney.com/stocklist.html (sh6|sz0|sz2|sz3|sz6).+html">.+\(
        Public Function GetStockCodeSortedList() As SortedList
            Dim sl As SortedList     '存储代码和名称变量
            Dim strWebResponse As String
            Dim strPattern As String
            Dim strSymbol, strFullName As String

            Dim iTotal As Integer = 0
            Dim jTotal As Integer = 2
            Dim iStart2 As Integer, iStringLength As Integer
            Dim iPrev As Integer

            Dim i As Integer

            '========================股票代码及名称==============================
            strWebResponse = GetWebPage(m_strPageAddress_Stock1, m_strPageCoding_Stock1).ReadToEnd
            strPattern = m_strPagePattern_Stock1

            iPrev = 0
            iTotal = Regex.Matches(strWebResponse, strPattern).Count

            For Each match As Match In Regex.Matches(strWebResponse, strPattern)

                iStringLength = Len(match.Value)
                If Left(match.Value, 2) = "sh" Then
                    strSymbol = Mid(match.Value, 3, 6)     '股票代码

                ElseIf Left(match.Value, 2) = "sz" Then
                    strSymbol = Mid(match.Value, 3, 6)     '股票代码

                End If
                iStart2 = InStr(match.Value, ">")
                strFullName = Mid(match.Value, 16, iStringLength - iStart2 - 1)  '股票名称
                sl.Add(strSymbol, strFullName)
                i = i + 1
            Next

            Return sl
        End Function

        '抓取股票代码  
        '匹配码：        http://quote.eastmoney.com/stocklist.html (sh6|sz0|sz2|sz3|sz6).+html">.+\(
        Public Function GetStockCodeList() As String(,)
            Dim sArray(2, 0) As String     '存储代码和名称变量
            Dim strWebResponse As String
            Dim strPattern As String
            Dim iTotal As Integer = 0
            Dim jTotal As Integer = 2
            Dim iStart1 As Integer, iStart2 As Integer, iStringLength As Integer
            Dim iPrev As Integer

            Dim i As Integer

            '========================股票代码及名称==============================
            strWebResponse = GetWebPage(m_strPageAddress_Stock1, m_strPageCoding_Stock1).ReadToEnd
            strPattern = m_strPagePattern_Stock1

            iPrev = 0
            iTotal = Regex.Matches(strWebResponse, strPattern).Count
            ReDim Preserve sArray(2, iTotal + iPrev)
            For Each match As Match In Regex.Matches(strWebResponse, strPattern)
                'Debug.Print(match.Value)
                iStringLength = Len(match.Value)
                If Left(match.Value, 2) = "sh" Then
                    sArray(0, i) = Mid(match.Value, 3, 6)     '股票代码
                    Debug.Print(sArray(0, i))
                ElseIf Left(match.Value, 2) = "sz" Then
                    sArray(0, i) = Mid(match.Value, 3, 6)     '股票代码
                    Debug.Print(sArray(0, i))
                End If
                iStart2 = InStr(match.Value, ">")
                sArray(1, i) = Mid(match.Value, 16, iStringLength - iStart2 - 1)  '股票名称
                Debug.Print(sArray(1, i))
                i = i + 1
            Next

            Debug.Print("总数：" & iTotal)
            Return sArray
        End Function
    End Class

End Namespace

