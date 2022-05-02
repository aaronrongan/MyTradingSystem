Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports MyTradingSystem.DataEntity

Namespace DataBase

    Public Class CDBADODataTable
        Inherits CDBADOConnection

        '�ڹ��캯����ָ��������Ϣ�ַ���
        Public Sub New(ByVal str As String)
            ConnStr = str
        End Sub

        Public Function CreateDataTable(ByVal strSQL As String, ByVal table As String) As DataTable

            '�������ݿ�
            Open()

            'ʹ�������ַ�����SqlConnection����SqlDataAdapter��ʵ��
#If OLEDB Then
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(strSQL, conn)
#ElseIf ODBC Then
            Dim da As OdbcDataAdapter = New OdbcDataAdapter(strSQL, conn)
#Else
            Dim da As SqlDataAdapter = New SqlDataAdapter(strSQL, conn)
#End If

            '����DataSet����
            Dim ds As New Data.DataSet()
            '���DataSet
            da.Fill(ds)
            '�ر����ݿ�
            Close()
            '����DataTable
            Return ds.Tables(0)

        End Function

        Public Function GetDataTable(ByVal strSQL As String, ByVal ct As CommandType) As DataTable
            Try

            
            '�������ݿ�
            Open()

            'ʹ�������ַ�����SqlConnection����SqlDataAdapter��ʵ��
#If OLEDB Then
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(strSQL, conn)
#ElseIf ODBC Then
            Dim da As OdbcDataAdapter = New OdbcDataAdapter(strSQL, conn)
#Else
            Dim da As SqlDataAdapter = New SqlDataAdapter(strSQL, conn)
#End If

            da.SelectCommand.CommandType = ct
            '����DataSet����
            Dim ds As New Data.DataSet()
            '���DataSet
            da.Fill(ds)
            '�ر����ݿ�
            Close()
                '����DataTable
                'Debug.Print(ds.Tables(0).Rows.Count)
                Return ds.Tables(0)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' ����ָ���ĸ��෵������? ����ת���ࡢ����ת���࣬ע�����Ҫ��Fill(DataTable)�������Fill(DataSet)������һ�ξͻ��޷��������ݣ���Ϊdt = ds.Tables(0)��ʱ����������Datatable������������
        ''' </summary>
        ''' <param name="strSQL"></param>
        ''' <param name="ct"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Sub FillDataTable(ByRef dt As DataTable, ByVal strSQL As String, ByVal ct As CommandType)
            Try

                '�������ݿ�
                Open()

                'ʹ�������ַ�����SqlConnection����SqlDataAdapter��ʵ��
#If OLEDB Then
            Dim da As OleDbDataAdapter = New OleDbDataAdapter(strSQL, conn)
#ElseIf ODBC Then
            Dim da As OdbcDataAdapter = New OdbcDataAdapter(strSQL, conn)
#Else
                Dim da As SqlDataAdapter = New SqlDataAdapter(strSQL, conn)
#End If

                da.SelectCommand.CommandType = ct
                '����DataSet����
                'Dim ds As New Data.DataSet()
                '���DataSet
                da.Fill(dt)

                'dt = ds.Tables(0)
                '�ر����ݿ�
                Close()
                '����DataTable

                'Return ds.Tables(0)


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
    End Class

End Namespace
