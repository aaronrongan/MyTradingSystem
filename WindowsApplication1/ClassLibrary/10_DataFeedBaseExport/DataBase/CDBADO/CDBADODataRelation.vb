Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc

Namespace DataBase

    Public Class CDBADODataRelation
        Inherits CDBADOConnection

        '在构造函数中指定连接信息字符串
        Public Sub New(ByVal Str As String)
            ConnStr = Str
        End Sub

        Public Sub CreateDataRelation(ByVal Table1 As String, ByVal Table2 As String, _
                                        ByVal ColumnParent As String, ByVal ColumnChild As String, _
                                        ByRef parentBindSource As BindingSource, _
                                        ByRef childBindSource As BindingSource)

            '连接数据库
            Open()

            '设置查询语句
            Dim strSQL1 As String = "Select * from " + Table1

            '实例化Command和DataAdapter对象
#If OLEDB Then
            Dim cmd As OleDbCommand = New OleDbCommand(strSQL1, conn)
            Dim da As New OleDbDataAdapter()
#ElseIf ODBC Then
            Dim cmd As OdbcCommand = New OdbcCommand(strSQL1, conn)
            Dim da As New OdbcDataAdapter()
#Else
            Dim cmd As SqlCommand = New SqlCommand(strSQL1, conn)
            Dim da As New SqlDataAdapter()
#End If

            '设置执行的命令的类型
            cmd.CommandType = CommandType.Text
            '设置执行的命令
            da.SelectCommand = cmd
            '执行查询命令
            cmd.ExecuteNonQuery()

            '填充数据集
            Dim ds As New DataSet
            da.Fill(ds, Table1)

            '设置绑定控件的数据源
            parentBindSource.DataMember = Table1
            parentBindSource.DataSource = ds.Tables(Table1)

            '设置查询子表ＳＱＬ语句
            Dim strSQL2 As String = "Select * from " + Table2

            '实例化Command和DataAdapter对象
#If OLEDB Then
            Dim cmd2 As OleDbCommand = New OleDbCommand()
            Dim da2 As OleDbDataAdapter = New OleDbDataAdapter(strSQL2, conn)
#ElseIf ODBC Then
            Dim cmd2 As OdbcCommand = New OdbcCommand()
            Dim da2 As OdbcDataAdapter = New OdbcDataAdapter(strSQL2, conn)
#Else
            Dim cmd2 As SqlCommand = New SqlCommand(strSQL2, conn)
            Dim da2 As SqlDataAdapter = New SqlDataAdapter()
#End If

            '设置执行的命令的类型
            cmd2.CommandType = CommandType.Text
            '设置执行的命令
            da2.SelectCommand = cmd2
            '执行查询命令
            cmd2.ExecuteNonQuery()

            '填充数据源
            da2.Fill(ds, Table2)

            '建立数据表之间的关系
            Dim parentColumn As New DataColumn
            parentColumn = ds.Tables(Table1).Columns(ColumnParent)
            Dim childColumn As New DataColumn
            childColumn = ds.Tables(Table2).Columns(ColumnChild)
            Dim relClassStudent As Data.DataRelation = New Data.DataRelation("TypeProduct", parentColumn, childColumn)
            ds.Relations.Add(relClassStudent)

            '设置数据源
            childBindSource.DataMember = "TypeProduct"
            childBindSource.DataSource = parentBindSource

            '关闭数据库
            Close()

        End Sub
    End Class

End Namespace
