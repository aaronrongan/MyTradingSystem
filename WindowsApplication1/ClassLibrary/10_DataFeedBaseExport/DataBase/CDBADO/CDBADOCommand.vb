Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc

Namespace DataBase

    Public Class CDBADOCommand
        Inherits CDBADOConnection

        '在构造函数中指定连接信息字符串
        Public Sub New(ByVal str As String)
            ConnStr = str
        End Sub
       
        Public Function Insert(ByVal strSQL As String) As Integer

            '连接数据库
            Open()

            '创建SqlCommand实例
#If OLEDB Then
            Dim cmd As OleDbCommand = New OleDbCommand(strSQL, conn)
#ElseIf ODBC Then
            Dim cmd As OdbcCommand = New OdbcCommand(strSQL, conn)
#Else
            Dim cmd As SqlCommand = New SqlCommand(strSQL, conn)
#End If

            'count表示受影响的行数，初始化为0
            Dim count As Integer = 0

            '执行SQL命令
            count = cmd.ExecuteNonQuery()

            '关闭数据库
            Close()

            Return count

        End Function

        Public Function Delete(ByVal table As String, ByVal row As String, ByVal value As String) As Integer

            '连接数据库
            Open()

            '创建SQL命令
            Dim strSQL As String = "Delete From " + table + " Where " + row + "=" + value
            '创建SqlCommand实例
#If OLEDB Then
            Dim cmd As OleDbCommand = New OleDbCommand(strSQL, conn)
#ElseIf ODBC Then
            Dim cmd As OdbcCommand = New OdbcCommand(strSQL, conn)
#Else
            Dim cmd As SqlCommand = New SqlCommand(strSQL, conn)
#End If

            'count表示受影响的行数，初始化为0
            Dim count As Integer = 0

            '执行SQL命令
            count = cmd.ExecuteNonQuery()

            '关闭数据库
            Close()

            Return count

        End Function

        Public Function TruncateTable(ByVal TableName As String) As Integer

            '连接数据库
            Open()

            '创建SQL命令
            Dim strSQL As String = "Truncate From " & TableName
            '创建SqlCommand实例
#If OLEDB Then
            Dim cmd As OleDbCommand = New OleDbCommand(strSQL, conn)
#ElseIf ODBC Then
            Dim cmd As OdbcCommand = New OdbcCommand(strSQL, conn)
#Else
            Dim cmd As SqlCommand = New SqlCommand(strSQL, conn)
#End If

            'count表示受影响的行数，初始化为0
            Dim count As Integer = 0

            '执行SQL命令
            count = cmd.ExecuteNonQuery()

            '关闭数据库
            Close()

            Return count

        End Function

        Public Function Update(ByVal table As String, ByVal strContent As String, ByVal row As String, ByVal value As String) As Integer

            '连接数据库
            Open()

            '创建SQL命令
            Dim strSQL As String = "Update " + table + " Set " + strContent + " Where " + row + "=" + value

            '创建SqlCommand实例
#If OLEDB Then
            Dim cmd As OleDbCommand = New OleDbCommand(strSQL, conn)
#ElseIf ODBC Then
            Dim cmd As OdbcCommand = New OdbcCommand(strSQL, conn)
#Else
            Dim cmd As SqlCommand = New SqlCommand(strSQL, conn)
#End If

            'count表示受影响的行数，初始化为0
            Dim count As Integer = 0

            '执行SQL命令
            count = cmd.ExecuteNonQuery()

            '关闭数据库
            Close()

            Return count

        End Function

        'Public Sub OpenConnection()
        '    MyBase.Open()
        'End Sub

        'Public Sub CloseConnection()
        '    If conn.State = ConnectionState.Open Then
        '        conn.Close()
        '    End If

        'End Sub
        ''' <summary>
        ''' 批量导入数据表，将一个Datatable一次性batch导入 SQL，效率极高
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <remarks></remarks>
        Public Function BulkInsertDataTable(ByRef dt As DataTable, ByVal strSQLTableName As String) As Boolean
            Try

                '连接数据库
                Open()

                '定义BulkCopy格式
                Dim bulkCopy As New SqlBulkCopy(conn)

                bulkCopy.DestinationTableName = strSQLTableName
                bulkCopy.BatchSize = dt.Rows.Count

                '连接数据库
                If conn.State = ConnectionState.Closed Then
                    Open()
                End If

                If dt IsNot Nothing And dt.Rows.Count <> 0 Then
                    bulkCopy.WriteToServer(dt)
                End If

                Return True

            Catch ex As Exception
                MsgBox(ex.Message)
                If ex.HResult <> -2146232060 Then       '如果数值重复，不用报警
                    MsgBox(ex.Message)
                Else
                    Return False
                End If
            Finally
                If dt IsNot Nothing Then
                    dt = Nothing
                End If
                Close()
            End Try
        End Function

        ''' <summary>
        ''' 批量导入数据表，将一个Datatable一次性batch导入 SQL，效率极高
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <remarks></remarks>
        Public Function BulkInsertDataTable(ByRef dt As DataTable, ByVal strSQLTableName As String, ByVal ColMapping As SqlBulkCopyColumnMapping) As Boolean
            Try

                '连接数据库
                Open()

                '定义BulkCopy格式
                Dim bulkCopy As New SqlBulkCopy(conn)

                bulkCopy.DestinationTableName = strSQLTableName
                bulkCopy.BatchSize = dt.Rows.Count


                '连接数据库
                If conn.State = ConnectionState.Closed Then
                    Open()
                End If

                If dt IsNot Nothing And dt.Rows.Count <> 0 Then
                    bulkCopy.WriteToServer(dt)
                End If

                Return True

            Catch ex As Exception
                MsgBox(ex.Message)
                If ex.HResult <> -2146232060 Then       '如果数值重复，不用报警
                    MsgBox(ex.Message)
                Else
                    Return False
                End If
            Finally
                If dt IsNot Nothing Then
                    dt = Nothing
                End If
                Close()
            End Try
        End Function

        'Public Sub OpenConnection()
        '    MyBase.Open()
        'End Sub

        'Public Sub CloseConnection()
        '    If conn.State = ConnectionState.Open Then
        '        conn.Close()
        '    End If

        'End Sub
        ''' <summary>
        ''' 批量导入数据表，将一个Datatable一次性batch导入 SQL，效率极高，该函数过载，可以用Mapping来实现映射功能
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <remarks></remarks>
        Public Function BulkInsertDataTable(ByRef dt As DataTable, ByVal strSQLTableName As String, ByVal strMappingList As SortedList(Of String, String)) As Boolean
            Try

                '连接数据库
                Open()

                '定义BulkCopy格式
                Dim bulkCopy As New SqlBulkCopy(conn)

                bulkCopy.DestinationTableName = strSQLTableName
                bulkCopy.BatchSize = dt.Rows.Count

                '连接数据库
                If conn.State = ConnectionState.Closed Then
                    Open()
                End If

                Dim iCount As Int16 = 0
                Do While iCount < strMappingList.Count
                    Dim mapID As New SqlBulkCopyColumnMapping(strMappingList.Keys(iCount), strMappingList.Item(strMappingList.Keys(iCount)))
                    bulkCopy.ColumnMappings.Add(mapID)
                    iCount += 1
                Loop

                'For Each lst As SortedList(Of String, String) In strMappingList.Item   'VIP?SortedList的List如何写在For Each中？

                'Next
               

                If dt IsNot Nothing And dt.Rows.Count <> 0 Then
                    bulkCopy.WriteToServer(dt)
                End If

                Return True

            Catch ex As Exception
                'MsgBox(ex.Message)
                If ex.HResult <> -2146232060 Then       '如果数值重复，不用报警
                    MsgBox(ex.Message)
                Else
                    Return False
                End If
            Finally
                If dt IsNot Nothing Then
                    dt = Nothing
                End If
                Close()
            End Try
        End Function

        ''' <summary>
        ''' 插入式存储过程的调用，注意这里嵌套try catch的使用，一次插入一行，
        ''' 注意：不能用于批量导入，否则太慢
        ''' </summary>
        ''' <param name="spName"></param>
        ''' <param name="dt"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>

        Public Function ExecStoredProcedure_InsertRow(ByVal spName As String, ByRef dt As DataTable, ByVal iRow As Integer) As Boolean

            Try
                '连接数据库
                If conn.State = ConnectionState.Closed Then
                    Open()
                End If

                '创建SQL命令
                Dim i As Integer, j As Integer, iTotalCol As Integer = dt.Columns.Count

                '每次插一行数据

                Dim cmd As SqlCommand = New SqlCommand(spName, conn) '必须要把conn和Command对象绑定在一起
                cmd.CommandType = CommandType.StoredProcedure
                For j = 0 To iTotalCol - 1
                    Dim paramSQL As New SqlClient.SqlParameter()
                    paramSQL.Direction = ParameterDirection.Input
                    paramSQL.DbType = CUtility.SystemType2DBType(dt.Columns(j).DataType)
                    paramSQL.ParameterName = "@" & dt.Columns(j).ColumnName
                    paramSQL.Value = dt.Rows(iRow).Item(j)
                    cmd.Parameters.Add(paramSQL)
                    paramSQL = Nothing
                Next

                'count表示受影响的行数，初始化为0
                Dim count As Integer = 0
                '执行SQL命令
                count = cmd.ExecuteNonQuery()
                cmd = Nothing

                '关闭数据库
                'If conn.State = ConnectionState.Open Then
                'Close()
                'End If

                Return True
            Catch ex As Exception
                If ex.HResult <> -2146232060 Then
                    MsgBox(ex.Message)
                Else
                    'Console.WriteLine(ex.Message)
                End If
                Return False
            Finally
                If conn.State = ConnectionState.Open Then
                    Close()
                End If
            End Try
        End Function
        ''' <summary>
        ''' 插入式存储过程的调用，注意这里嵌套try catch的使用，一次插入一张表
        ''' </summary>
        ''' <param name="spName"></param>
        ''' <param name="dt"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExecStoredProcedure_InsertTablebyRow(ByVal spName As String, ByVal dt As DataTable) As Integer

            Try
                '连接数据库
                Open()

                '创建SQL命令
                Dim i As Integer, j As Integer, iTotalRow As Integer = dt.Rows.Count, iTotalCol As Integer = dt.Columns.Count

                '每次插一行数据
                For i = 0 To iTotalRow - 1
                    Try
                        Dim cmd As SqlCommand = New SqlCommand(spName, conn) '必须要把conn和Command对象绑定在一起
                        cmd.CommandType = CommandType.StoredProcedure
                        For j = 0 To iTotalCol - 1
                            Dim paramSQL As New SqlClient.SqlParameter()

                            paramSQL.Direction = ParameterDirection.Input

                            '==============================================
                            'Dim tc As System.ComponentModel.TypeConverter
                            'tc = System.ComponentModel.TypeDescriptor.GetConverter(paramSQL.DbType)

                            'If tc.CanConvertFrom(dt.Columns(j).DataType) Then
                            'paramSQL.DbType = tc.ConvertFrom(dt.Columns(j).DataType.Name)
                            ' Else
                            ''Try brute force   
                            'Try
                            'paramSQL.DbType = tc.ConvertFrom(dt.Columns(j).DataType)
                            'Catch
                            'Do Nothing   
                            'End Try
                            'End If
                            'System.DataType到System.Data.DBType的类型转换!!!
                            '================================================
                            'paramSQL.DbType = dt.Columns(j).DataType ' DbType.String
                            paramSQL.DbType = CUtility.SystemType2DBType(dt.Columns(j).DataType)
                            paramSQL.ParameterName = "@" & dt.Columns(j).ColumnName
                            paramSQL.Value = dt.Rows(i).Item(j)
                            cmd.Parameters.Add(paramSQL)
                            paramSQL = Nothing
                        Next

                        'count表示受影响的行数，初始化为0
                        Dim count As Integer = 0
                        '执行SQL命令
                        count = cmd.ExecuteNonQuery()
                        cmd = Nothing
                    Catch ex As Exception
                        If ex.HResult <> -2146232060 Then
                            MsgBox(ex.Message)
                        Else
                            Console.WriteLine(ex.Message & ":Row" & i & "   :" & dt.Rows(i).Item(j))
                        End If
                    End Try
                Next

                Return 1

            Catch ex As Exception
                Close()
                Return 0
            Finally
                '关闭数据库
                Close()
            End Try


        End Function
        ''' <summary>
        ''' 执行增加、删除、更新的操作
        ''' </summary>
        ''' <param name="spName"></param>
        ''' <param name="arrParaName"></param>
        ''' <param name="arrParaValue"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExecSP_NoQuery(ByVal spName As String, ByVal arrParaName() As String, ByVal arrParaValue() As String, ByVal typeST As System.Data.StatementType) As Integer
            Try
                '连接数据库
                Open()

                '创建SQL命令
#If OLEDB Then
            Dim cmd As OleDbCommand = New OleDbCommand(strSQL, conn)
#ElseIf ODBC Then
            Dim cmd As OdbcCommand = New OdbcCommand(strSQL, conn)
#Else
                Dim cmd As SqlCommand = New SqlCommand(spName, conn) '必须要把conn和Command对象绑定在一起
#End If
                cmd.CommandType = CommandType.StoredProcedure

                Dim i, iInParaTotal As Integer

                iInParaTotal = UBound(arrParaName)
                If iInParaTotal > 0 Then
                    For i = 0 To iInParaTotal - 1
                        Dim paramSQL As New SqlClient.SqlParameter()
                        paramSQL.Direction = ParameterDirection.Input
                        paramSQL.DbType = DbType.String
                        paramSQL.ParameterName = arrParaName(i)
                        paramSQL.Value = arrParaValue(i)
                        cmd.Parameters.Add(paramSQL)
                        paramSQL = Nothing
                    Next
                End If

                'count表示受影响的行数，初始化为0
                Dim count As Integer = 0

                '执行SQL命令
                count = cmd.ExecuteNonQuery()

                

                Return count
            Catch ex As Exception
                MsgBox(ex.Message)
                Return 0
            Finally
                '关闭数据库
                Close()
            End Try
        End Function
        ''' <summary>
        ''' 执行查阅的操作，需要返回值，返回
        ''' </summary>
        ''' <param name="spName"></param>
        ''' <param name="arrInParaName"></param>
        ''' <param name="arrInParaValue"></param>
        ''' <param name="arrOutParaName"></param>
        ''' <param name="arrOutParaValue"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExecSP_Query(ByVal spName As String, ByVal arrInParaName() As String, ByVal arrInParaValue() As String, ByVal arrOutParaName() As String, ByRef arrOutParaValue() As String) As Integer
            Try

                '连接数据库
                Open()

                '创建SQL命令
#If OLEDB Then
            Dim cmd As OleDbCommand = New OleDbCommand(strSQL, conn)
#ElseIf ODBC Then
            Dim cmd As OdbcCommand = New OdbcCommand(strSQL, conn)
#Else
                Dim cmd As SqlCommand = New SqlCommand(spName, conn) '必须要把conn和Command对象绑定在一起
#End If
                cmd.CommandType = CommandType.StoredProcedure

                Dim i, iInParaTotal, iOutParaTotal As Integer

                iInParaTotal = UBound(arrInParaName)
                If iInParaTotal > 0 Then
                    For i = 0 To iInParaTotal - 1
                        Dim paramSQL As New SqlClient.SqlParameter()
                        paramSQL.Direction = ParameterDirection.Input
                        paramSQL.DbType = DbType.String
                        paramSQL.ParameterName = arrInParaName(i)
                        paramSQL.Value = arrInParaValue(i)
                        cmd.Parameters.Add(paramSQL)
                        paramSQL = Nothing
                    Next
                End If

                iOutParaTotal = UBound(arrOutParaName)
                ' ReDim outparamSQL(iTotal)
                If iOutParaTotal > 0 Then
                    'ReDim outparamSQL(iTotal - 1)
                    For i = 0 To iOutParaTotal - 1
                        Dim outparamSQL = New SqlClient.SqlParameter(arrOutParaName(i), SqlDbType.VarChar, 20)  '必须用三参数new，如果用New()会报错，size属性为0
                        outparamSQL.Direction = ParameterDirection.Output
                        outparamSQL.Value = arrOutParaValue(i)
                        outparamSQL = cmd.Parameters.Add(outparamSQL)

                        outparamSQL = Nothing
                    Next
                End If

                'count表示受影响的行数，初始化为0
                Dim count As Integer = 0

                '执行SQL命令
                count = cmd.ExecuteNonQuery()

                If iOutParaTotal > 0 Then
                    For i = 0 To iOutParaTotal - 1
                        arrOutParaValue(i) = cmd.Parameters(iInParaTotal + i).Value
                    Next
                End If

                '返回参数值
                'If iOutParaTotal > 0 Then

                '    For i = 0 To iOutParaTotal - 1
                '        arrOutParaValue(i) = cmd.Parameters(iInParaTotal + i).Value
                '    Next
                'End If
                

                Return count
            Catch ex As Exception
                'MsgBox(ex.Message)
                Return Nothing
            Finally
                '关闭数据库
                Close()
            End Try
        End Function

        ''' <summary>
        ''' '查询语句，返回单个数据，使用ExecuteScalar高效
        ''' </summary>
        ''' <param name="spName"></param>
        ''' <param name="arrParaName"></param>
        ''' <param name="arrParaValue"></param>
        ''' 
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExecSP_Scalar(ByVal spName As String, ByVal arrParaName() As String, ByVal arrParaValue() As Object, ByVal arrOutParaName As String, ByRef arrOutParaValue As Object) As Object
            Try
                '连接数据库
                Open()

                '创建SQL命令
#If OLEDB Then
            Dim cmd As OleDbCommand = New OleDbCommand(strSQL, conn)
#ElseIf ODBC Then
            Dim cmd As OdbcCommand = New OdbcCommand(strSQL, conn)
#Else
                Dim cmd As SqlCommand = New SqlCommand(spName, conn) '必须要把conn和Command对象绑定在一起
#End If
                cmd.CommandType = CommandType.StoredProcedure

                Dim i, iInParaTotal As Integer
                Dim paramSQL As SqlClient.SqlParameter

                iInParaTotal = UBound(arrParaName)
                If iInParaTotal > 0 Then
                    For i = 0 To iInParaTotal - 1
                        paramSQL = New SqlClient.SqlParameter()
                        paramSQL.Direction = ParameterDirection.Input
                        paramSQL.DbType = DbType.String
                        paramSQL.ParameterName = arrParaName(i)
                        paramSQL.Value = arrParaValue(i)
                        cmd.Parameters.Add(paramSQL)
                        paramSQL = Nothing
                    Next
                End If

                paramSQL = New SqlClient.SqlParameter(arrOutParaName, SqlDbType.VarChar, 20)  '必须用三参数new，如果用New()会报错，size属性为0
                paramSQL.Direction = ParameterDirection.Output
                paramSQL.Value = arrOutParaValue
                cmd.Parameters.Add(paramSQL)

                '执行SQL命令
                Return cmd.ExecuteScalar()
                'Return cmd.Parameters(arrOutParaName).Value

                'Return count
            Catch ex As Exception
                MsgBox(ex.Message)
                Return 0
            Finally
                '关闭数据库
                Close()
            End Try
        End Function
    End Class

End Namespace
