Imports System.IO
Imports System.Text

Namespace DataExport



    Public Class CDataExportCSVTXT
        Public Shared Function WriteLog(sr() As String) As Boolean

            'Dim fs As String = IO.File.ReadAllLines()


            Dim sFileName As String = Now().Year & "-" & Now().Month & "-" & Now().Day & "-" & Now().Hour & "-" & Now().Minute & "-" & Now().Second & ".csv"
            IO.File.WriteAllLines(GlobalVariables.g_LogFilePath & "\" & sFileName, sr, System.Text.Encoding.UTF8)
            Return True

        End Function
        Public Shared Function DataTableToCSV(table As DataTable, fullSavePath As String) ' tableheader As String, columname As String) As Boolean

            ArgumentChecked(table, fullSavePath)

            
                Dim _bufferLine As String = ""
            Dim _writerObj As StreamWriter = IO.File.CreateText(fullSavePath)  'New StreamWriter(fullSavePath, False, Encoding.UTF8) (VIP 用New SteamWrite无法写全文件，很奇怪)
            Try

                'If (String.IsNullOrEmpty(tableheader) = False) Then
                '    _writerObj.WriteLine(tableheader)
                'End If
                'If (String.IsNullOrEmpty(columname) = False) Then
                '    _writerObj.WriteLine(columname)
                'End If

                '写列标题

                For i = 0 To table.Columns.Count - 1
                    If i = 0 Then
                        _bufferLine = table.Columns(i).ColumnName
                    Else
                        _bufferLine += ","
                        _bufferLine += table.Columns(i).ColumnName
                    End If
                Next
                _writerObj.WriteLine(_bufferLine)

                For i = 0 To table.Rows.Count - 1
                    _bufferLine = ""
                    For j = 0 To table.Columns.Count - 1
                        If (j > 0) Then
                            _bufferLine += ","
                            _bufferLine += table.Rows(i)(j).ToString()
                        Else
                            _bufferLine = table.Rows(i)(j).ToString()
                        End If
                    Next
                    _writerObj.WriteLine(_bufferLine)
                    Debug.Print(i)
                Next

                Return True
                'Debug.Print(_bufferLine)
            Catch ex As Exception
                MsgBox(ex.Message)

                Return False
            Finally
                _writerObj.Close()
            End Try



        End Function


        '/ <summary>
        '/ 参数检查
        '/ </summary>
        '/ <param name="table"></param>
        '/ <param name="fullSavePath"></param>
        Private Shared Sub ArgumentChecked(table As DataTable, fullSavePath As String)

            If (IsNothing(table)) Then
                Throw New ArgumentNullException("table")
            End If
            If (String.IsNullOrEmpty(fullSavePath)) Then
                Throw New ArgumentNullException("fullSavePath")
            End If
            Dim _fileName As String '= CSharpToolV2.GetFileNameOnly(fullSavePath)
            'If (String.IsNullOrEmpty(_fileName)) Then
            'Throw New ArgumentException(String.Format("参数fullSavePath的值{0},不是正确的文件路径!", fullSavePath))
            'End If
            'If (_fileName.InvalidFileNameChars() = False) Then
            'Throw New ArgumentException(String.Format("参数fullSavePath的值{0},包含非法字符!", fullSavePath))
            'End If
        End Sub

        '/ <summary>
        '/ 将CSV文件数据导入到Datable中
        '/ </summary>
        '/ <param name="table"></param>
        '/ <param name="filePath">DataTable</param>
        '/ <param name="rowIndex">保存路径</param>
        '/ <returns>Datable</returns>
        Public Shared Function CSVToDatatable(table As DataTable, filePath As String, rowIndex As Integer) As DataTable

            ArgumentChecked(table, filePath)
            If (rowIndex < 0) Then
                Throw New ArgumentException("rowIndex")
            End If
            Dim reader As StreamReader = IO.File.OpenText(filePath) 'New StreamReader(filePath, Encoding.UTF8, False)

            Dim i As Integer = 0, j As Integer = 0
            reader.Peek()
            While (reader.Peek() > 0)

                j = j + 1
                Dim _line As String = reader.ReadLine()
                If (j >= rowIndex + 1) Then
                    Dim _split() As String = _line.Split(",")
                    Dim _row As DataRow = table.NewRow()
                    For i = 0 To _split.Length - 1
                        _row(i) = _split(i)
                    Next
                    table.Rows.Add(_row)
                End If

                Return table
            End While

        End Function
        Public Class CDataExportTxtLog

            Private m_LogLine As List(Of String)
            Private m_FileName As String


            Public Sub New(strEventDescription As String)
                m_LogLine = New List(Of String)
                m_FileName = Now().Year & "-" & Now().Month & "-" & Now().Day & "-" & Now().Hour & "-" & Now().Minute & "-" & Now().Second & ".csv"

                AddLog(strEventDescription)

            End Sub
            Public Sub AddLog(str As String)
                Dim strDateTime As String
                strDateTime = Now()
                m_LogLine.Add(String.Format("{0}: {1}", strDateTime, str))

            End Sub

            Public Sub ExportLog()
                IO.File.WriteAllLines(GlobalVariables.g_LogFilePath & "\" & m_FileName, m_LogLine, System.Text.Encoding.UTF8)


                'MsgBox("记录文件已生成，请见" & GlobalVariables.g_LogFilePath & "\" & m_FileName)

            End Sub


          

        End Class

    End Class

End Namespace
