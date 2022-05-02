Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc

Namespace DataBase

    Public Class CDBADODataRelation
        Inherits CDBADOConnection

        '�ڹ��캯����ָ��������Ϣ�ַ���
        Public Sub New(ByVal Str As String)
            ConnStr = Str
        End Sub

        Public Sub CreateDataRelation(ByVal Table1 As String, ByVal Table2 As String, _
                                        ByVal ColumnParent As String, ByVal ColumnChild As String, _
                                        ByRef parentBindSource As BindingSource, _
                                        ByRef childBindSource As BindingSource)

            '�������ݿ�
            Open()

            '���ò�ѯ���
            Dim strSQL1 As String = "Select * from " + Table1

            'ʵ����Command��DataAdapter����
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

            '����ִ�е����������
            cmd.CommandType = CommandType.Text
            '����ִ�е�����
            da.SelectCommand = cmd
            'ִ�в�ѯ����
            cmd.ExecuteNonQuery()

            '������ݼ�
            Dim ds As New DataSet
            da.Fill(ds, Table1)

            '���ð󶨿ؼ�������Դ
            parentBindSource.DataMember = Table1
            parentBindSource.DataSource = ds.Tables(Table1)

            '���ò�ѯ�ӱ�ӣѣ����
            Dim strSQL2 As String = "Select * from " + Table2

            'ʵ����Command��DataAdapter����
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

            '����ִ�е����������
            cmd2.CommandType = CommandType.Text
            '����ִ�е�����
            da2.SelectCommand = cmd2
            'ִ�в�ѯ����
            cmd2.ExecuteNonQuery()

            '�������Դ
            da2.Fill(ds, Table2)

            '�������ݱ�֮��Ĺ�ϵ
            Dim parentColumn As New DataColumn
            parentColumn = ds.Tables(Table1).Columns(ColumnParent)
            Dim childColumn As New DataColumn
            childColumn = ds.Tables(Table2).Columns(ColumnChild)
            Dim relClassStudent As Data.DataRelation = New Data.DataRelation("TypeProduct", parentColumn, childColumn)
            ds.Relations.Add(relClassStudent)

            '��������Դ
            childBindSource.DataMember = "TypeProduct"
            childBindSource.DataSource = parentBindSource

            '�ر����ݿ�
            Close()

        End Sub
    End Class

End Namespace
