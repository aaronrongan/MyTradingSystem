Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.Diagnostics


Namespace DataExport


    Public Class CDataExportExcel
        ' DataTable导出Excel


        'Public Shared Sub OutDataToExcel(ByVal srcDataTable As System.Data.DataTable, excelFilePath As String)
        ''' <summary>
        ''' '把数据表的内容导出到Excel文件中  ,
        ''' </summary>
        ''' <param name="srcDataTable"></param>
        ''' <param name="excelFilePath"></param>
        ''' <remarks></remarks>
        Public Shared Sub DataTableToExcel(ByVal srcDataTable As System.Data.DataTable, excelFilePath As String)
            Dim xlApp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application()
            Dim missing As Object = System.Reflection.Missing.Value

            '导出到execl   
            Try

                If xlApp Is Nothing Then
                    MessageBox.Show("无法创建Excel对象，可能您的电脑未安装Excel!")
                    Return
                End If

                Dim xlBooks As Microsoft.Office.Interop.Excel.Workbooks = xlApp.Workbooks
                Dim xlBook As Microsoft.Office.Interop.Excel.Workbook = xlBooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet)
                Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = xlBook.Worksheets(1)


                '让后台执行设置为不可见，为true的话会看到打开一个Excel，然后数据在往里写  
                xlApp.Visible = False

                '  object[,] objData = new object[srcDataTable.Rows.Count + 1, srcDataTable.Columns.Count]  
                Dim objData(,) As Object

                ReDim objData(srcDataTable.Rows.Count + 1, srcDataTable.Columns.Count)

                '首先将数据写入到一个二维数组中  
                For i = 0 To srcDataTable.Columns.Count
                    objData(0, i) = srcDataTable.Columns(i).ColumnName
                Next

                If srcDataTable.Rows.Count > 0 Then

                    For i = 0 To srcDataTable.Rows.Count - 1
                        For j = 0 To srcDataTable.Columns.Count - 1
                            objData(i + 1, j) = srcDataTable.Rows(i)(j)
                        Next
                    Next
                End If

                Dim startCol As String = "A"

                Dim iCnt As Integer = (srcDataTable.Columns.Count / 26)

                Dim endColSignal As String 'g= (iCnt == 0 ? "" : ((char)('A' + (iCnt - 1))).ToString())  
                If iCnt = 0 Then
                    endColSignal = ""
                Else
                    endColSignal = "A" + (iCnt - 1)
                End If
                Dim endCol As String

                'endCol= endColSignal + ((string)("A" + srcDataTable.Columns.Count - iCnt * 26 - 1)).ToString()  
                endCol = endColSignal + "A" + srcDataTable.Columns.Count - iCnt * 26 - 1

                Dim Range As Excel.Range = xlSheet.get_Range(startCol + "1", endCol + (srcDataTable.Rows.Count - iCnt * 26 + 1).ToString())

                Range.Value = objData '给Exccel中的Range整体赋值  
                Range.EntireColumn.AutoFit() '设定Excel列宽度自适应  
                xlSheet.get_Range(startCol + "1", endCol + "1").Font.Bold = 1 'Excel文件列名 字体设定为Bold  

                '设置禁止弹出保存和覆盖的询问提示框  
                xlApp.DisplayAlerts = False
                xlApp.AlertBeforeOverwriting = False

                If xlSheet IsNot Nothing Then

                    xlSheet.SaveAs(excelFilePath, missing, missing, missing, missing, missing, missing, missing, missing, missing)
                    'xlApp.Quit()  
                    'Kill(xlApp)
                    xlApp.ActiveWorkbook.Close()
                    xlApp.Quit()
                    xlApp = Nothing
                End If

            Catch ex As Exception
                xlApp.ActiveWorkbook.Close()
                xlApp.Quit()
                xlApp = Nothing
                'Dim myProcess As new Process = System.Diagnostics.Process.GetProcessesByName("EXCEL")
                'For Each inst In myProcess
                '    'If inst.Handle.ToInt32 = myExcel.Hinstance Then

                '    p = System.Diagnostics.Process.GetProcessById(inst.Id)
                '    p.Kill()
                '    'End If
                Throw ex
            End Try


        End Sub

    End Class

End Namespace
