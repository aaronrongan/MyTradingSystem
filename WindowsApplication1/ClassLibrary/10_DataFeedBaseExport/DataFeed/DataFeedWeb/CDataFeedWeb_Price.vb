Imports System.Xml
Imports System.Net
Imports System.Web
Imports System.IO
Imports System.Text.RegularExpressions
Imports MyTradingSystem.DataEntity

Namespace DataFeed



    Public Class CDataFeedWeb_Price
        Inherits CDataFeedWeb


        '从和讯服务器得出即时数据====================
        Public Sub GetHexun_Current(sSymbol As String, oxml As Object)

            'Dim oxml As Object
            'oxml = CreateObject("Microsoft.XMLHTTP")
            '沪深300
            oxml.Open("POST", "http://quote.tool.hexun.com/hqzx/quote.aspx?type=2&market=0&sorttype=3&updown=up&page=1&count=3000", False)
            oxml.send()

            'While xml.readystate <> 4
            '    DoEvents
            'Wend
            'MsgBox xml.Status

            Debug.Print(oxml.responseText)
            Debug.Print(oxml.Status)
            Debug.Print(oxml.responseXML.xml)

            'MakeHtm xml.responseText, ThisWorkbook.Path

            'Set xml = Nothing
        End Sub


        '从搜狐服务器得出即时数据====================有问题！！
        Public Sub GetSohu_Current(sSymbol As String, oxml As Object)

            'Dim oxml As Object
            'oxml = CreateObject("Microsoft.XMLHTTP")
            oxml.Open("POST", "http://hq.stock.sohu.com/hqindex/finaceindex/financeindexhq1.js", False)
            oxml.send()

            'While xml.readystate <> 4
            '    DoEvents
            'Wend
            'MsgBox xml.Status

            Debug.Print(oxml.responseText)
            Debug.Print(oxml.Status)
            Debug.Print(oxml.responseXML.xml)

            'MakeHtm(xml.responseText, ThisWorkbook.Path)


            oxml.Open("POST", "http://hq.stock.sohu.com/hqindex/finaceindex/financeindexhq2.js", False)
            oxml.send()

            'While xml.readystate <> 4
            '    DoEvents
            'Wend
            'MsgBox xml.Status

            Debug.Print(oxml.responseText)
            Debug.Print(oxml.Status)
            Debug.Print(oxml.responseXML.xml)

            'MakeHtm xml.responseText, ThisWorkbook.Path


            'worksheets(1)
            'Filter
            'Set xml = Nothing

        End Sub


        '从新浪服务器得出即时数据====================
        Public Sub GetSina_Current(sSymbol As String, oxml As Object)

            'Dim oxml As Object
            Dim sPrefix As String
            'oxml = CreateObject("Microsoft.XMLHTTP")
            sPrefix = GetCodePrefix_Postfix(sSymbol, "Sina")

            'xml.Open "POST", "http://hq.sinajs.cn/list=sh600151,sz002201, sz000830,s_sh000001,s_sz399001,s_sz399106,s_sz399107,s_sz399108", False

            oxml.Open("POST", "http://hq.sinajs.cn/list=" & sPrefix & sSymbol, False)

            oxml.send()

            'While xml.readystate <> 4
            '    DoEvents
            'Wend
            'MsgBox xml.Status

            'Debug.Print(oxml.responseText)
            'Debug.Print(oxml.Status)
            'Debug.Print(oxml.responseXML.xml)

            'makeHtm xml.responseText, ThisWorkbook.Path

            'Set xml = Nothing
        End Sub

        '获取股票日线数据
        '从Yahoo网站获取，保存至本地Stock日线数据(放在CDBTX类中)
        Public Function GetStockDailyPrice(strStockCode As String) As StreamReader
            Try

                Dim strWeb As String = ""
                'Dim oDTP As New CDTDaily

                Dim sFirstLetter As String = Left(strStockCode, 1)
                If sFirstLetter = "6" Then
                    strWeb = strStockCode & ".ss"
                ElseIf sFirstLetter = "0" Or sFirstLetter = "2" Or sFirstLetter = "3" Then
                    strWeb = strStockCode & ".sz"
                End If

                strWeb = "http://table.finance.yahoo.com/table.csv?s=" & strWeb
                Dim stream As IO.StreamReader = GetWebPage(strWeb, )

                Return stream

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Function

        '从Yahoo、Sina、Sohu、Hexun得到股票的即时、日线数据

        '用XMLHTTP实现读取网页
        Public Sub GetYahoo_Daily(sSymbol As String, oxml As Object)

            'Dim oxml1 As New MSXML2.XMLHTTP60

            'oxml1.

            Dim sPostfix As String

            'oxml = CreateObject("Microsoft.XMLHTTP")

            sPostfix = GetCodePrefix_Postfix(sSymbol, "Yahoo")

            oxml.Open("POST", "http://table.finance.yahoo.com/table.csv?s=" & sSymbol & sPostfix, False)
            oxml.send()

            Debug.Print(oxml.responseText)
            Debug.Print(oxml.Status)
            Debug.Print(oxml.responseXML.xml)

            'MakeHtm xml.responseText, ThisWorkbook.Path

            'worksheets(1)

            'Filter

            'Set xml = Nothing
        End Sub

    End Class

End Namespace
