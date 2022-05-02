Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc

Namespace DataBase

    Public Class CDBADOConnection

        '����һ���ܱ��������洢�������ݿ����Ϣ
        Protected ConnStr As String

        '�����������ݿ����ӵ�˽�г�Ա
#If OLEDB Then
        Protected conn As OleDbConnection
#ElseIf ODBC Then
        Protected conn As OdbcConnection
#Else
        Protected conn As SqlConnection
#End If

        Protected Sub Open()

            '�ж������ַ����Ƿ�Ϊ��
            If ConnStr Is Nothing Or ConnStr = "" Then
                MsgBox("�����ַ���Ϊָ������ָ�������ַ���")
                Return
            End If

            'ʵ����SqlConnection��
#If OLEDB Then
            conn = New OleDbConnection(ConnStr)
#ElseIf ODBC Then
            conn = New OdbcConnection(ConnStr)
#Else
            conn = New SqlConnection(ConnStr)
#End If
            '�����ݿ�
            conn.Open()

        End Sub

        Protected Overridable Sub Close()
            '�ر�����
            conn.Close()
        End Sub

    End Class

End Namespace

