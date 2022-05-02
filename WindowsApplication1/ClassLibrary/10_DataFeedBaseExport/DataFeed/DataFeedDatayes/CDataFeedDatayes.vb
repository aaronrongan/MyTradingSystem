
Imports System.Web
Imports System.Net
Imports System.Xml
Imports System.IO
Imports System.Text.RegularExpressions
Imports DatayesInterface2Managed
Imports System.Runtime.InteropServices
Imports System.Text

Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

'Private Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (Destination As Any, ByVal Source As Long, ByVal Length As Long)

'Public Declare Sub HelloWorld Lib "DatayesInterface2Managed.dll" ()

'<DllImport(\"Data.dll\")> 
'Private Shared Function ConnectPlayServer(ByVal Address As String, ByVal Port As Integer, ByVal DataPort As Integer, ByVal Username As String) As Boolean

'End Function

'Private Declare Auto Function a Lib \"Lib.dll\" (ByVal i As Integer) As String2.

Namespace DataFeed


    Public Class CDataFeedDatayes
        '<DllImport("DatayesInterface2Managed.dll", CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.StdCall, EntryPoint:="init", SetLastError:=True)> Public Shared Sub Init(ByVal token As String)
       
        ' End Sub

        '<DllImport("DatayesInterface2Managed.dll", CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.StdCall, EntryPoint:="getdata", SetLastError:=True)> Public Shared Function GetData(ByVal inputURL As String, <Out> ByVal output As StringBuilder) As Integer ', <Out> ByVal charlen As Long
       
        'End Function

        Protected m_Datayes As CDataClient
        Protected token As String = "e80a5f5fd83775e0e396379955dded5f2928894f247181e860eb44f553589d3a"
        Protected m_URL As String

        'Private lpszAgent As String = "WinInetGet/0.1"
        ''private  hInternet = InternetOpen(lpszAgent,INTERNET_OPEN_TYPE_PRECONFIG, NULL, NULL, 0);
        'Private lpszVerb As String = "GET"
        'Private serverDomain As String = "http://api.wmcloud.com"

        'Private port As Int16 = 443

        Public Sub New()
            m_Datayes = New CDataClient
            m_Datayes.init(token)
        End Sub


        Protected Overrides Sub Finalize()
            MyBase.Finalize()
            m_Datayes = Nothing
        End Sub


        ''' <summary>
        ''' 封装C++的GetData
        ''' </summary>
        ''' <param name="URL"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetData(URL) As String

            Return m_Datayes.getData(URL)
        End Function


        ''' <summary>
        ''' 测试C++封装类，花费了1天半，先是想用HTTPRequest类，后来又用C++ dllexport，又用DllImport，最后修改传出参数，搞定
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function TestDatayes()

            Dim a As New CDataClient
            'Dim strResult As New StringBuilder ' String = "0000"
            'strResult.Capacity = 1024
            'Dim strResult1() As String
            'ReDim strResult1(1024)
            ' String = "0000"
            'Dim charResult As Char() = ("0")
            Dim lngMemory As Long
            'Dim byteArray() As Byte
            'Dim byteAllData() As Byte
            'Dim lngDataCount As Long
            'Dim lngIsOver As Long
            'Dim i As Long
            'Dim lngReadSize As Long
            'Dim strReturnString As String
            'Dim lngLoopCount As Long
            'Dim lngAddress As Long

            'ReDim charResult(100)

            Dim lngI As Long

            Dim i As Integer = a.init(token)
            'MsgBox(i)
            ' Dim j As Long = a.getData("/api/macro/getChinaDataGDP.csv?field=&indicID=M010000002&indicName=&beginDate=&endDate=", lngMemory)
            'Dim str As String = a.getData("/api/macro/getChinaDataGDP.csv?field=&indicID=M010000002&indicName=&beginDate=&endDate=")

            'Init(token)
            'GetData("/api/macro/getChinaDataGDP.csv?field=&indicID=M010000002&indicName=&beginDate=&endDate=", strResult)

            'a.getData("/api/macro/getChinaDataGDP.csv?field=&indicID=M010000002&indicName=&beginDate=&endDate=", strResult)
            'a.getData("/api/macro/getChinaDataGDP.csv?field=&indicID=M010000002&indicName=&beginDate=&endDate=", lngMemory)

            'Do
            '    '每次从内存中复制出 lngReadSize 个字节，这个 lngReadSize 是自己定义的，多少无所谓
            '    ReDim byteArray(lngReadSize - 1)

            '    lngAddress = CLng(lngReadSize * lngLoopCount)
            '    '从返回的内存指针中复制 lngReadSize 个字节到自己分配的数组空间中
            '    CopyMemory(byteArray(0), lngMemory + lngAddress, lngReadSize)

            '    '开始判断数据结束符
            '    For i = 0 To lngReadSize - 1
            '        If lngDataCount = 0 Then
            '            ReDim byteAllData(lngDataCount)
            '        Else
            '            ReDim Preserve byteAllData(lngDataCount)
            '        End If
            '        byteAllData(lngDataCount) = byteArray(i)
            '        lngDataCount = lngDataCount + 1
            '        If byteArray(i) = 0 Then
            '            '找到字符串结束符,退出过程
            '            lngIsOver = 1
            '            Exit For
            '        End If
            '    Next i
            '    lngLoopCount = lngLoopCount + 1
            'Loop While lngIsOver = 0
            ''重新设置数组大小，把最后的 0 去掉
            'ReDim Preserve byteAllData(lngDataCount - 1)

            ''通过StrConv函数将字节数组中的数据转换成字符串类型
            'strReturnString = StrConv(byteAllData, vbUnicode)

            'Debug.Print(strResult.ToString)

        End Function

        ''' <summary>
        ''' 尝试用VB的HttpRequestHeader实现Datayes的GetData功能，不成功。以后查看其代码
        ''' </summary>
        ''' <param name="URL"></param>
        ''' <param name="strResult"></param>
        ''' <param name="sEncode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetData_Obsolete(ByVal URL As String, ByVal strResult As String, Optional sEncode As String = "UTF8") As StreamReader

            'Dim authHeadVal As String = "Authorization: Bearer " + token '"Basic " + base64BearerTokenCreds
            'Dim authHeadVal As String = "Bearer " + token

            'URL = serverDomain + "/data/v1" + URL

            'Dim urlobj As New Uri(URL)

            'httpClient.DefaultRequestHeaders.Authorization = New System.Net.Http.Headers.AuthenticationHeaderValue(authHeadVal)



            'Dim ahv As System.Net.HttpRequestHeader 'System.Net.HttpRequestHeader

            'Dim wr1 As System.Net.WebRequest
            'Dim header As New System.Net.HttpRequestHeader
            ''header.
            ''header.Authorization = authHeadVal
            'wr1.Headers.Add(header, authHeadVal)
            ''Dim wr2 As System.Net.HttpWebRequest


            'Dim wr3 As New System.Net.Http.HttpClient
            'wr3.DefaultRequestHeaders.Add("Authorization", authHeadVal)

            'wr3.BaseAddress = urlobj
            'wr3.GetStreamAsync(URL)


            'header.Authorization()
            'wr.Headers.Add(header)

            'Dim srchRequest As New System.Net.HttpWebRequest
            'Dim authHdr As String = String.Format(srchHeaderFormat, twitAuthResponse.token_type, twitAuthResponse.access_token)
            'srchRequest.DefaultRequestHeaders.Add("Authorization", authHdr)

            'srchRequest.de()


            Dim httpReq As HttpWebRequest
            Dim httpResp As HttpWebResponse
            Dim httpURL As New Uri(URL)


            Dim oXD As New XmlDocument
            Dim reader As IO.StreamReader

            Try


                httpReq = CType(WebRequest.Create(httpURL), HttpWebRequest)
                httpReq.Method = "GET"

                httpResp = CType(httpReq.GetResponse(), HttpWebResponse)
                httpReq.KeepAlive = False



                If sEncode = "UTF8" Or sEncode = "" Then
                    reader = New IO.StreamReader(httpResp.GetResponseStream, System.Text.Encoding.UTF8)
                ElseIf sEncode = "GB2312" Then
                    reader = New IO.StreamReader(httpResp.GetResponseStream, System.Text.Encoding.GetEncoding("gb2312"))
                End If


                Return reader

            Catch ex As Exception

            Finally
                reader = Nothing
            End Try
        End Function
        ' <summary>
        '/ 将json转换为DataTable
        '/ </summary>
        '/ <param name="strJson">得到的json</param>
        '/ <returns></returns>
        Public Function DatayesJsonToDataTable(ByVal strJson As String, ByRef tb As DataTable) As Boolean
            Try


                '转换json格式
                'strJson = strJson.Replace(",""", "*""")
                'strJson = strJson.Replace(""":", """#").ToString()


                '取出表名   
                ' var rg = new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase)

                'dim rg as regex= new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase)
                Dim rg As Regex '= New Regex("(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase)
                'Dim strName As String = rg.Match(strJson).Value

                'If IsNothing(tb) Then
                'tb = New datatalbe
                'End If

                'Dim tb As DataTable = Nothing

                '去除表名   
                strJson = strJson.Substring(strJson.IndexOf("[") + 1)

                ' strJson = strJson.Substring(0, strJson.IndexOf("]")) 当字符串中出现]时出错，应该倒数后2个字符去除即可
                strJson = strJson.Substring(0, strJson.Length - 2)

                '获取数据   
                'rg = new Regex(@"(?<={)[^}]+(?=})")

                'rg = New Regex("(?<={)[^}]+(?=})")

                rg = New Regex("\{.*?\}")
                Dim mc As MatchCollection = rg.Matches(strJson)

                For i = 0 To mc.Count - 1

                    Dim strRow As String = mc(i).Value

                    strRow = strRow.Replace("{", "").Replace("}", "").ToString & ","    '去除左右刮号 ''''''''''''注意：VIP，如果字段中含有{}刮号也会导致出错

                    'strRow = strRow.Replace("""", "").ToString '去除上下引号          ''''''''''''VIP程序错误，把上下引号去除了，导致字段中含有,的划分多余字段。引号应该到最后再去除。

                    'Dim strRows() As String = strRow.Split(",")             ''''''''''''VIP程序错误，把上下引号去除了，导致字段中含有,的划分多余字段。引号应该到最后再去除。

                    Dim rgsub = New Regex("(\""\b.*?\"":)((\"".*?\""\,)|(\d|\.|-){0,100},)") '''VIP 要能区分中间的逗号、"、数字....{"typeID":"101","typeName":"证券,32,板块","parentID":18.21,"typeLevel":221,"typeLevel":.221},

                    Dim strRows As MatchCollection = rgsub.Matches(strRow)
                    Dim iRowCount As Int16 = 0

                    '创建表，增加表列。如果在函数调用外已经定义好列数目和列名，则不用再加列。目的是防止有些返回字符串出现遗漏字段。
                    If tb.Columns.Count = 0 Then

                        'tb = New DataTable()
                        'tb.TableName = strName

                        'For Each str As String In strRows
                        Dim strheader As String
                        For iRowCount = 0 To strRows.Count - 1
                            strheader = strRows(iRowCount).Value
                            Dim dc As DataColumn = New DataColumn()

                            Dim strCell() As String

                            If iRowCount < strRows.Count - 1 Then
                                strCell = strheader.Substring(0, strheader.Length - 1).Split(":")        '把,"都考虑进去才行，最后一个子列不需要去除,其它都需要去除,
                            Else
                                strCell = strheader.Split(":")
                            End If
                            iRowCount += 1
                            dc.ColumnName = strCell(0)
                            tb.Columns.Add(dc)
                        Next
                        tb.AcceptChanges()
                    End If


                    '增加内容   
                    Dim dr As DataRow = tb.NewRow()

                    Dim strIndexValues As String
                    For iRowCount = 0 To strRows.Count - 1
                        Try

                        
                            strIndexValues = strRows(iRowCount).Value       ' 形如"TShEquity":-573835461.42, 或"exchangeCD":"XSHE",

                            Dim strCell() As String

                            'If iRowCount < strRows.Count - 1 Then
                            strCell = strIndexValues.Substring(0, strIndexValues.Length - 1).Split(":")        '把,"都考虑进去才行，去除最后一个,
                            'Else
                            'strCell = strIndexValues.Split(":")
                            ' End If

                            Dim strIndex As String
                            Dim strValue As String
                            strIndex = strCell(0)
                            strValue = strCell(1)

                            '去除首尾的""
                            If Left(strIndex, 1) = """" Then
                                strIndex = strIndex.Substring(1)
                            End If
                            If Right(strIndex, 1) = """" Then
                                strIndex = strIndex.Substring(0, strIndex.Length - 1)
                            End If

                            If Left(strValue, 1) = """" Then
                                strValue = strValue.Substring(1)
                            End If
                            If Right(strValue, 1) = """" Then
                                strValue = strValue.Substring(0, strValue.Length - 1)
                            End If

                            '如果列名相同才加入数据，否则跳过
                            Dim iTemp As Integer = iRowCount
                            Do Until strIndex = tb.Columns(iTemp).ColumnName And iTemp <= tb.Columns.Count - 1
                                iTemp += 1
                            Loop
                            dr(iTemp) = strValue

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                        'iRowCount += 1
                    Next

                    '以下程序错误，因为未能正确区分""中的，
                    'For r = 0 To strRows.Length - 1
                    '    'For Each str As String In strRows

                    '    Dim strCell() As String = strRows(r).Split(":")

                    '    'dc.ColumnName = strCell(0)
                    '    'tb.Columns.Add(dc)

                    '    Dim strIndex As String
                    '    Dim strValue As String
                    '    strIndex = strCell(0)
                    '    strValue = strCell(1)

                    '    '去除首尾的""
                    '    If Left(strIndex, 1) = """" Then
                    '        strIndex = strIndex.Substring(1)
                    '    End If
                    '    If Right(strIndex, 1) = """" Then
                    '        strIndex = strIndex.Substring(0, strIndex.Length - 1)
                    '    End If

                    '    If Left(strValue, 1) = """" Then
                    '        strValue = strValue.Substring(1)
                    '    End If
                    '    If Right(strValue, 1) = """" Then
                    '        strValue = strValue.Substring(0, strValue.Length - 1)
                    '    End If

                    '    '如果列名相同才加入数据，否则跳过
                    '    Dim iTemp As Integer = r
                    '    Do Until strIndex = tb.Columns(iTemp).ColumnName And iTemp <= strRows.Count
                    '        iTemp += 1
                    '    Loop
                    '    dr(iTemp) = strValue
                    '    'If strCell(0) = tb.Columns(r).ColumnName Then

                    '    '    dr(r) = strCell(1)
                    '    'Else
                    '    '    'dr(r) = "-1"
                    '    'End If
                    '    'Next

                    '    'dr(r) = strRows(r).Split("#")(1).Trim().Replace("，", ",").Replace("：", ":").Replace("\""", "")
                    '    'Dim str, str1 As String
                    '    'str1 = str.Split("#")
                    'Next
                    Try

                   
                    tb.Rows.Add(dr)
                        tb.AcceptChanges()

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                Next

                Return True


            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End Function
        ' <summary>
        '/ 将json转换为DataTable
        '/ </summary>
        '/ <param name="strJson">得到的json</param>
        '/ <returns></returns>
        Public Function DatayesCSVToDataTable(ByVal strJson As String) As DataTable

            '转换json格式
            strJson = strJson.Replace(",""", "*""")
            strJson = strJson.Replace(""":", """#").ToString()

            '取出表名   
            ' var rg = new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase)

            'dim rg as regex= new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase)
            Dim rg As Regex = New Regex("(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase)
            Dim strName As String = rg.Match(strJson).Value
            Dim tb As DataTable = Nothing

            '去除表名   
            strJson = strJson.Substring(strJson.IndexOf("[") + 1)
            strJson = strJson.Substring(0, strJson.IndexOf("]"))

            '获取数据   
            'rg = new Regex(@"(?<={)[^}]+(?=})")
            rg = New Regex("(?<={)[^}]+(?=})")

            Dim mc As MatchCollection = rg.Matches(strJson)

            For i = 0 To mc.Count - 1

                Dim strRow As String = mc(i).Value
                Dim strRows() As String = strRow.Split("*")

                '创建表   
                If IsNothing(tb) Then

                    tb = New DataTable()
                    tb.TableName = strName
                    For Each str As String In strRows

                        Dim dc As DataColumn = New DataColumn()
                        Dim strCell() As String = str.Split("#")

                        If strCell(0).Substring(0, 1) = "\" Then

                            Dim a As Integer = strCell(0).Length
                            dc.ColumnName = strCell(0).Substring(1, a - 2)

                        Else

                            dc.ColumnName = strCell(0)

                            tb.Columns.Add(dc)
                        End If
                    Next
                    tb.AcceptChanges()
                End If


                '增加内容   
                Dim dr As DataRow = tb.NewRow()
                For r = 0 To strRows.Length - 1
                    dr(r) = strRows(r).Split("#")(1).Trim().Replace("，", ",").Replace("：", ":").Replace("\""", "")
                    'Dim str, str1 As String
                    'str1 = str.Split("#")
                Next
                tb.Rows.Add(dr)
                tb.AcceptChanges()
            Next

            Return tb
        End Function
        ' <summary>
        '/ 将json转换为DataTable，用标准类Json做
        '/ </summary>
        '/ <param name="strJson">得到的json</param>
        '/ <returns></returns>
        Public Function DatayesJsonToDataTable2(ByVal strJson As String, ByRef tb As DataTable) As Boolean
            Try
              

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End Function
        Public Function AssessReturnMsg(strRaw As String) As Boolean
            If strRaw.Contains("""retCode"":-1") Or strRaw.Contains("""retCode"":-2") Then
                Return False
            Else
                Return True
            End If

        End Function
    End Class

End Namespace
