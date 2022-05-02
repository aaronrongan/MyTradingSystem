Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc

Namespace DataBase

    Public Class CDBADODataReader
        Inherits CDBADOConnection

        '�ڹ��캯����ָ��������Ϣ�ַ���
        Public Sub New(ByVal str As String)
            ConnStr = str
        End Sub

#If OLEDB Then
        Public Function CreateDataReader(ByVal strSQL As String) As OleDbDataReader

            '�����ݿ�����
            Open()

            '����OleDbCommand�Ķ���
            Dim cmd As OleDbCommand = New OleDbCommand()

            'ExecuteReaderִ��SQL��䲢����OleDbDataReader
            Dim dr As OleDbDataReader = cmd.ExecuteReader()

            '����DataReader
            Return dr

        End Function
#ElseIf ODBC Then
        Public Function CreateDataReader(ByVal strSQL As String) As OdbcDataReader

            '�����ݿ�����
            Open()

            '����odbcCommand�Ķ���
            Dim cmd As OdbcCommand = New OdbcCommand()

            'ExecuteReaderִ��SQL��䲢����odbcDataReader
            Dim dr As OdbcDataReader = cmd.ExecuteReader()

            '����DataReader
            Return dr

        End Function
#Else
        Public Function CreateDataReader(ByVal strSQL As String) As SqlDataReader

            '�����ݿ�����
            Open()

            '����SqlCommand�Ķ���
            Dim cmd As SqlCommand = New SqlCommand(strSQL, conn)

            'ExecuteReaderִ��SQL��䲢����SqlDataReader
            Dim dr As SqlDataReader = cmd.ExecuteReader()

            '����DataReader
            Return dr


        End Function
#End If


        Public Function GetDataReader(ByVal strSQL As String) As SqlDataReader

            '�����ݿ�����
            Open()

            '����SqlCommand�Ķ���
            Dim cmd As SqlCommand = New SqlCommand(strSQL, conn)

            'ExecuteReaderִ��SQL��䲢����SqlDataReader
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            '����DataReader
            Return dr


        End Function

    End Class

End Namespace
