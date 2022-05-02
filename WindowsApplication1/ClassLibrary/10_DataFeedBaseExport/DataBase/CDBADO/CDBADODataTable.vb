Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports MyTradingSystem.DataEntity

Namespace DataBase

    Public Class CDBADODataTable
        Inherits CDBADOConnection

        '在构造函数中指定连接信息字符串
        Public Sub New(ByVal str As String)
            ConnStr = str
        End Sub

        Public Function CreateDataTable(ByVal strSQL As String, ByVal table As String) As DataTable

            '连接数据库
            Open()

            '使用连接字符串和SqlConnection创建SqlDataAdapter的实例
#If OLEDB Then
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(strSQL, conn)
#ElseIf ODBC Then
            Dim da As OdbcDataAdapter = New OdbcDataAdapter(strSQL, conn)
#Else
            Dim da As SqlDataAdapter = New SqlDataAdapter(strSQL, conn)
#End If

            '创建DataSet对象
            Dim ds As New Data.DataSet()
            '填充DataSet
            da.Fill(ds)
            '关闭数据库
            Close()
            '返回DataTable
            Return ds.Tables(0)

        End Function

        Public Function GetDataTable(ByVal strSQL As String, ByVal ct As CommandType) As DataTable
            Try

            
            '连接数据库
            Open()

            '使用连接字符串和SqlConnection创建SqlDataAdapter的实例
#If OLEDB Then
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(strSQL, conn)
#ElseIf ODBC Then
            Dim da As OdbcDataAdapter = New OdbcDataAdapter(strSQL, conn)
#Else
            Dim da As SqlDataAdapter = New SqlDataAdapter(strSQL, conn)
#End If

            da.SelectCommand.CommandType = ct
            '创建DataSet对象
            Dim ds As New Data.DataSet()
            '填充DataSet
            da.Fill(ds)
            '关闭数据库
            Close()
                '返回DataTable
                'Debug.Print(ds.Tables(0).Rows.Count)
                Return ds.Tables(0)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' 根据指定的父类返回子类? 父类转子类、子类转父类，注意必须要用Fill(DataTable)，如果用Fill(DataSet)再引用一次就会无法传回数据，因为dt = ds.Tables(0)此时还是引用了Datatable，而不是子类
        ''' </summary>
        ''' <param name="strSQL"></param>
        ''' <param name="ct"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Sub FillDataTable(ByRef dt As DataTable, ByVal strSQL As String, ByVal ct As CommandType)
            Try

                '连接数据库
                Open()

                '使用连接字符串和SqlConnection创建SqlDataAdapter的实例
#If OLEDB Then
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(strSQL, conn)
#ElseIf ODBC Then
            Dim da As OdbcDataAdapter = New OdbcDataAdapter(strSQL, conn)
#Else
                Dim da As SqlDataAdapter = New SqlDataAdapter(strSQL, conn)
#End If

                da.SelectCommand.CommandType = ct
                '创建DataSet对象
                'Dim ds As New Data.DataSet()
                '填充DataSet
                da.Fill(dt)

                'dt = ds.Tables(0)
                '关闭数据库
                Close()
                '返回DataTable

                'Return ds.Tables(0)


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
    End Class

End Namespace
