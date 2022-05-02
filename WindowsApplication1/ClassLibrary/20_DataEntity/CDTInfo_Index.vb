Imports System.Data
Imports MyTradingSystem.DataBase

Namespace DataEntity

    Public Class CDTInfo_Index
        Inherits CDTInfo



        'Private m_DataRow As DataRow

        'Event InsertProgress As eve

        '从数据库读出Info列表；
        '根据筛选条件过滤列表；
        '将StockInfo写入数据库；

        'Private m_colStockInfo As Collection

        'Public Property StockInfoTable() As Collection
        '    Get
        '        StockInfoTable = m_colStockInfo
        '    End Get

        '    Set(value As Collection)
        '        m_colStockInfo = value
        '    End Set
        'End Property

        ''' <summary>
        ''' 一次性插入一张表到SQL中
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertDataTable2SQL() As Boolean
            Dim obj1 As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
            Try

                'obj.ExecSP_NoQuery("dbo.ISI_InsertStockInfo")
                'ExecStoredProcedure_NoQuery("dbo.ISI_InsertStockInfo")
                obj1.ExecStoredProcedure_InsertTablebyRow("dbo.III_InsertIndexInfo", Me)
                Return True
            Catch ex As Exception
                Return False
            Finally
                obj1 = Nothing
            End Try

        End Function

        Public Sub New()
            MyBase.New()
            m_strSQLTableName = "IndexInfo"
            Me.TableName = m_strSQLTableName

        End Sub
        ''' <summary>
        ''' 每次插入一行数据到SQL
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertDataTable2SQLbyRow() As Boolean
            Try
                Dim obj As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
                'obj.ExecSP_NoQuery("dbo.ISI_InsertStockInfo")
                'ExecStoredProcedure_NoQuery("dbo.ISI_InsertStockInfo")

                Dim i As Integer, iTotalRow As Integer
                iTotalRow = Me.Rows.Count
                For i = 0 To iTotalRow - 1
                    obj.ExecStoredProcedure_InsertRow("dbo.III_InsertIndexInfo", Me, i)
                Next
                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function

        ''' <summary>
        ''' 每次插入一行数据到SQL
        ''' </summary>

        Public Function Insert2SQL_OBSOLETE() As Boolean
            Try
                'Dim conSQL As SqlClient.SqlConnection
                'conSQL = New SqlClient.SqlConnection()
                'conSQL.ConnectionString = GlobalVariables.gSQLConnectionString
                'conSQL.Open()

                'Dim commSQL As SqlClient.SqlCommand = New SqlCommand()
                'commSQL.Connection = conSQL
                'commSQL.CommandType = CommandType.StoredProcedure
                'commSQL.CommandText = "dbo.InsertStockListInfo"

                'Dim paramSQL As New SqlClient.SqlParameter("@stocksymbol", SqlDbType.VarChar)
                'paramSQL.Direction = ParameterDirection.Input
                'paramSQL.Value = strSymbol
                'commSQL.Parameters.Add(paramSQL)

                'paramSQL = New SqlClient.SqlParameter("@stockfullname", SqlDbType.VarChar)
                'paramSQL.Value = strFullName
                'commSQL.Parameters.Add(paramSQL)

                'Dim datRead As SqlClient.SqlDataReader
                'datRead = commSQL.ExecuteReader()
                'Do While datRead.Read()
                '    MessageBox.Show(datRead(0).ToString)
                'Loop
                'datRead.Close()

                Dim arrInParaName(0) As String
                Dim arrInParaValue(0) As String
                Dim arrOutParaName(0) As String
                Dim arrOutParaValue(0) As String
                Dim obj As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
                Dim i As Integer, j As Integer, iTotalRow As Integer = Me.Rows.Count, iTotalCol As Integer = Me.Columns.Count

                'arrInParaName(0) = "@" & m_Col1Name
                'arrInParaName(1) = "@" & m_Col2Name


                ReDim arrInParaName(iTotalCol)
                ReDim arrInParaValue(iTotalCol)
                'ReDim arrOutParaValue(iTotalCol)
                'ReDim arrOutParaValue(iTotalCol)

                For j = 0 To iTotalCol
                    arrInParaName(j) = "@" & Me.Columns(j).ColumnName
                Next

                For i = 0 To iTotalRow
                    For j = 0 To iTotalCol
                        arrInParaValue(j) = Me.Rows(i).Item(j)
                    Next
                    'obj.ExecSP("dbo.III_InsertIndexInfo", arrInParaName, arrInParaValue, arrOutParaName, arrOutParaValue)
                Next

                Return True

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End Function

        ''' <summary>
        ''' 将一个表全部保存到SQL数据库
        ''' </summary>
        Public Sub InsertTable2SQL()

        End Sub

        'Public Sub AddRow(ByVal)

        Protected Overrides Function AdaptDatafromDataTable(dt_datayes As DataTable) As Boolean

        End Function

        Public Overrides Function UpgradeData(dt As CDTInfo) As Boolean

        End Function
    End Class
End Namespace
