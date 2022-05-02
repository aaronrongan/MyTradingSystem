Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc

Namespace DataBase

    Public Class CDBADOConnection

        '声明一个受保护变量存储连接数据库的信息
        Protected ConnStr As String

        '声明用于数据库连接的私有成员
#If OLEDB Then
        Protected conn As OleDbConnection
#ElseIf ODBC Then
        Protected conn As OdbcConnection
#Else
        Protected conn As SqlConnection
#End If

        Protected Sub Open()

            '判断连接字符串是否为空
            If ConnStr Is Nothing Or ConnStr = "" Then
                MsgBox("连接字符串为指定，请指定连接字符串")
                Return
            End If

            '实例化SqlConnection类
#If OLEDB Then
            conn = New OleDbConnection(ConnStr)
#ElseIf ODBC Then
            conn = New OdbcConnection(ConnStr)
#Else
            conn = New SqlConnection(ConnStr)
#End If
            '打开数据库
            conn.Open()

        End Sub

        Protected Overridable Sub Close()
            '关闭连接
            conn.Close()
        End Sub

    End Class

End Namespace

