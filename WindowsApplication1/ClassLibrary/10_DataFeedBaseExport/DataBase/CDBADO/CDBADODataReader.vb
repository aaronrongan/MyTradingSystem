Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc

Namespace DataBase

    Public Class CDBADODataReader
        Inherits CDBADOConnection

        '在构造函数中指定连接信息字符串
        Public Sub New(ByVal str As String)
            ConnStr = str
        End Sub

#If OLEDB Then
        Public Function CreateDataReader(ByVal strSQL As String) As OleDbDataReader

            '打开数据库连接
            Open()

            '创建OleDbCommand的对象
            Dim cmd As OleDbCommand = New OleDbCommand()

            'ExecuteReader执行SQL语句并返回OleDbDataReader
            Dim dr As OleDbDataReader = cmd.ExecuteReader()

            '返回DataReader
            Return dr

        End Function
#ElseIf ODBC Then
        Public Function CreateDataReader(ByVal strSQL As String) As OdbcDataReader

            '打开数据库连接
            Open()

            '创建odbcCommand的对象
            Dim cmd As OdbcCommand = New OdbcCommand()

            'ExecuteReader执行SQL语句并返回odbcDataReader
            Dim dr As OdbcDataReader = cmd.ExecuteReader()

            '返回DataReader
            Return dr

        End Function
#Else
        Public Function CreateDataReader(ByVal strSQL As String) As SqlDataReader

            '打开数据库连接
            Open()

            '创建SqlCommand的对象
            Dim cmd As SqlCommand = New SqlCommand(strSQL, conn)

            'ExecuteReader执行SQL语句并返回SqlDataReader
            Dim dr As SqlDataReader = cmd.ExecuteReader()

            '返回DataReader
            Return dr


        End Function
#End If


        Public Function GetDataReader(ByVal strSQL As String) As SqlDataReader

            '打开数据库连接
            Open()

            '创建SqlCommand的对象
            Dim cmd As SqlCommand = New SqlCommand(strSQL, conn)

            'ExecuteReader执行SQL语句并返回SqlDataReader
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            '返回DataReader
            Return dr


        End Function

    End Class

End Namespace
