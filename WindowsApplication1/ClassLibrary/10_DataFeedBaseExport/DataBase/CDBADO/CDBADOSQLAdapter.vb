
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Data
Imports MyTradingSystem.DataEntity

Namespace DataBase


    Public Class CDBADOSQLAdapter
        Inherits CDBADOConnection

        Private m_SQLAdapter As SqlClient.SqlDataAdapter
        Private m_Dataset As DataSet
        Private m_DataTable As DataTable
        Private m_DataTableName As String

        ''' <summary>
        ''' 直接选择整个Table
        ''' </summary>
        ''' <param name="strCon"></param>
        ''' <param name="strTableName"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal strCon As String, ByVal strTableName As String)
            Try


                ConnStr = strCon
                m_DataTableName = strTableName
                m_SQLAdapter = New SqlClient.SqlDataAdapter("Select * from " & strTableName, ConnStr)
                m_SQLAdapter.SelectCommand.CommandType = CommandType.Text

            Catch ex As Exception

            End Try
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="strCommandText"></param>
        ''' <param name="strCommandType"></param>
        ''' <param name="strCon"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal strCommandText As String, ByVal strCommandType As CommandType, ByVal strCon As String)
            ConnStr = strCon
            m_SQLAdapter = New SqlClient.SqlDataAdapter(strCommandText, strCon)
            m_SQLAdapter.SelectCommand.CommandType = strCommandType
            m_DataTable = New DataTable
        End Sub

        Public Sub UpdateTable(ByVal strTableName As String, ByVal dt As DataTable)
            Try

                Open()

                Dim commandBulider As SqlCommandBuilder = New SqlCommandBuilder(m_SQLAdapter)
                commandBulider.ConflictOption = ConflictOption.OverwriteChanges

                m_SQLAdapter.UpdateBatchSize = 5000 '设置批量更新的每次处理条数
                m_SQLAdapter.SelectCommand.Transaction = conn.BeginTransaction() '开始事务 
                'm_SQLAdapter.

                m_SQLAdapter.Update(dt)
                m_SQLAdapter.SelectCommand.Transaction.Commit() '提交事务 

            Catch ex As Exception
                If m_SQLAdapter.SelectCommand IsNot Nothing And m_SQLAdapter.SelectCommand.Transaction IsNot Nothing Then
                    m_SQLAdapter.SelectCommand.Transaction.Rollback()
                End If

            Finally

                Close()
            End Try

        End Sub

        ''' <summary>
        ''' 根据set/where的值更新数据行，也同样适用于广义
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <param name="strTableName"></param>
        ''' <param name="setParaName"></param>
        ''' <param name="setParaValue"></param>
        ''' <param name="whereParaName"></param>
        ''' <param name="whereParaValue"></param>
        ''' <remarks></remarks>
        Public Sub UpgradeTable(ByVal rows() As DataRow, ByVal strTableName As String, ByVal setParaName() As String, ByVal setParaValue() As String, ByVal whereParaName() As String, ByVal whereParaValue() As String)
            Try


                Open()

                Dim strCommand As String
                'strCommand = String.Format("UPDATE {0} SET CustomerID = @CustomerID, CompanyName = @CompanyName  WHERE CustomerID = @oldCustomerID", strTableName, )

                Dim iArray As Integer
                Dim strSet As String
                Dim strWhere As String

                For Each strPara As String In setParaName
                    strSet = strPara + "=@" + strPara + ","
                Next
                strSet = Left(strSet, Len(strSet) - 1)  '去除最后一个,

                For Each strPara As String In whereParaName
                    strWhere = strPara + "=@" + strPara + ","
                Next
                strWhere = Left(strWhere, Len(strWhere) - 1)  '去除最后一个,

                strCommand = String.Format("UPDATE {0} SET {1}  WHERE {2}", strTableName, strSet, strWhere)

                Dim Command As SqlCommand = New SqlCommand(strCommand, conn)

                ' Add the parameters for the UpdateCommand.

                Command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID")
                Command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40, "CompanyName")
                Dim parameter As SqlParameter = Command.Parameters.Add( _
                    "@oldCustomerID", SqlDbType.NChar, 5, "CustomerID")
                parameter.SourceVersion = DataRowVersion.Original

                m_SQLAdapter.UpdateCommand = Command

                m_SQLAdapter.Update(rows)

            Catch ex As Exception

            End Try

        End Sub
        ''' <summary>
        ''' 得到SQL数据表的表格式
        ''' </summary>
        ''' <param name="strTableName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSQLTableSchema(ByVal strTableName As String) As DataTable
            Dim dt As New DataTable
            'm_SQLAdapter.
            m_SQLAdapter.FillSchema(dt, SchemaType.Mapped)

            Open()

            Return dt
            Close()

        End Function


        Public Function ExecQuery(ByVal strTableName As String, Optional ByVal pas As SqlParameterCollection = Nothing) As DataTable
            Try
                Open()

                'm_SQLAdapter.SelectCommand.CommandType = ct
                'm_SQLAdapter.SelectCommand.CommandText = strSQL

                Dim i As Integer, iParTotal As Integer

                If Not IsNothing(pas) Then
                    iParTotal = pas.Count
                    For i = 0 To iParTotal
                        m_SQLAdapter.SelectCommand.Parameters.Add(pas(i))
                    Next
                End If

                'Dim ds = New DataSet

                'm_SQLAdapter.Fill(ds, strTableName)
                m_SQLAdapter.Fill(m_DataTable)

                m_DataTable.TableName = strTableName

                Return m_DataTable

            Catch ex As Exception
                Return Nothing
            Finally
                Close()
            End Try
        End Function

        ''' <summary>
        ''' 从SQL中得出现有的数据库内容，打开数据链接后，不要close()。父类转子类、子类转父类？
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataTablebySymbolfromSQL(ByVal strSymbol As String, ByRef dt As DataTable) As Boolean
            Try
                Open()
                'Dim dt As New CDTDaily_Stock
                Dim cmd As SqlCommand = New SqlCommand()
                Dim strSQL As String = "Select * from " & m_DataTableName & " where Symbol=" & strSymbol

                m_SQLAdapter = New SqlClient.SqlDataAdapter(strSQL, ConnStr)

                '''''''''''''''''''''''''
                '设置select查询命令
                '    Dim selectCMD As SqlCommand = New SqlCommand("select  SNo,SName,SAge from Student", conn)
                '    'Insert命令
                '    Dim insertCMD As SqlCommand = New SqlCommand("insert into Student(SNo,SName,SAge) values(@SNo,@SName,@SAge)", conn)
                '    'Update命令
                '    Dim updateCMD As SqlCommand = New SqlCommand("update Student Set SName=@SName,SAge=@SAge where SNo=@SNo", conn)
                '    'Delete命令
                '    Dim deleteCMD As SqlCommand = New SqlCommand("delete from Student where SNo=@SNo", conn)

                '    '给Insert,Update,Delete三个命令添加参数
                '    SqlParameter(paraSNo1, paraSNo2, paraSNo3) '第二个指定参数值的来源,这里的SNo是指DataTable中的列名
                '    paraSNo1 = New SqlParameter("@SNo", "SNo")
                '    paraSNo2 = New SqlParameter("@SNo", "SNo")
                '    paraSNo3 = New SqlParameter("@SNo", "SNo")
                '    paraSNo1.SourceVersion = DataRowVersion.Current '指定SourceVersion确定参数值是列的当前值(Current)，还是原始值(Original)，还是建议值(Proposed)
                '    paraSNo2.SourceVersion = DataRowVersion.Current
                '    paraSNo3.SourceVersion = DataRowVersion.Current

                '    SqlParameter(paraSName1, paraSName2, paraSName3)
                '    paraSName1 = New SqlParameter("@SName", "SName")
                '    paraSName2 = New SqlParameter("@SName", "SName")
                '    paraSName3 = New SqlParameter("@SName", "SName")
                '    paraSName1.SourceVersion = DataRowVersion.Current
                '    paraSName2.SourceVersion = DataRowVersion.Current
                '    paraSName3.SourceVersion = DataRowVersion.Current

                '    SqlParameter(paraSAge1, paraSAge2, paraSAge3)
                '    paraSAge1 = New SqlParameter("@SAge", "SAge")
                '    paraSAge2 = New SqlParameter("@SAge", "SAge")
                '    paraSAge3 = New SqlParameter("@SAge", "SAge")
                '    paraSAge1.SourceVersion = DataRowVersion.Current
                '    paraSAge2.SourceVersion = DataRowVersion.Current
                '    paraSAge3.SourceVersion = DataRowVersion.Current

                'insertCMD.Parameters.AddRange(new SqlParameter[] { paraSNo1, paraSName1, paraSAge1 })
                'updateCMD.Parameters.AddRange(new SqlParameter[] { paraSNo2, paraSName2, paraSAge2 })
                'deleteCMD.Parameters.AddRange(new SqlParameter[] { paraSNo3, paraSName3, paraSAge3 })
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                'm_Dataset = New DataSet()

                'm_SQLAdapter.FillSchema(m_Dataset, SchemaType.Source)

                'dt = m_Dataset.Tables.Add(m_DataTableName)

                'm_SQLAdapter.FillSchema(m_DataTable, SchemaType.Source)

                'm_SQLAdapter.Fill(m_DataTable)

                'm_SQLAdapter.FillSchema(dt, SchemaType.Source)

                m_SQLAdapter.Fill(dt)

                'Dim newRow As DataRow = dt.NewRow()

                'newRow.Item("TheDate") = "1996/12/30"
                'newRow.Item("Symbol") = "000001"
                'dt.Rows.Add(newRow)

                'Dim cb As SqlCommandBuilder = New SqlCommandBuilder(m_SQLAdapter) ''VIP，这点很关键，自动创建commandbuilder
                'm_SQLAdapter.Update(dt.GetChanges())
                'dt.AcceptChanges()

                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            Finally
                'Close()

            End Try

        End Function
        ''' <summary>
        ''' 从SQL中得出现有的数据库内容，打开数据链接后，不要close()。父类转子类、子类转父类？
        ''' 注意：这里的字段映射，Stock/Index/Fund都不一样
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataTablebySymbolDatesfromSQL(ByVal strSymbol As String, ByVal BeginDate As DateTime, ByVal EndDate As DateTime, ByRef dt As DataTable) As Boolean
            Try
                Open()
                'Dim dt As New CDTDaily_Stock
                Dim cmd As SqlCommand = New SqlCommand()
                ' Dim strSQL As String = "Select * from " & m_DataTableName & " where Symbol=" & strSymbol
                Dim strSQL As String = String.Format("Select * from {0} where Symbol='{1}' and TheDate>='{2}' and TheDate<='{3}'", m_DataTableName, strSymbol, CDate(BeginDate).Date, CDate(EndDate).Date)

                m_SQLAdapter = New SqlClient.SqlDataAdapter(strSQL, ConnStr)

                m_SQLAdapter.Fill(dt)

                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            Finally
                'Close()

            End Try

        End Function


        ''' <summary>
        ''' Initializes a SqlCommand object based on a stored procedure name
        ''' and a SqlTransaction instance.  Verifies that the stored procedure
        ''' name is valid, and then tries to get the SqlCommand object from 
        ''' cache.  If it is not already in cache, then the SqlCommand object
        ''' is initialized and placed into cache.
        ''' </summary>
        ''' <param name="transaction">The transaction that the stored procedure 
        ''' will be executed under.</param>
        ''' <param name="spName">The name of the stored procedure to execute.</param>
        ''' <returns>An initialized SqlCommand object.</returns>
        Public Function GetSqlCommand(ByVal spName As String) As SqlCommand
            'Dim command As SqlCommand = Nothing

            '' Get the name of the stored procedure
            'If spName.Length < 1 Or spName.Length > 127 Then
            '    Throw New ArgumentOutOfRangeException("spName", _
            '        "Stored procedure name must be from 1 - 128 characters.")
            'End If

            '' See if the command object is already in memory
            'Dim hashKey As String = Me._connectionString & ":" & spName
            'command = CType(_commandParametersHashTable(hashKey), SqlCommand)
            'If command Is Nothing Then
            '    ' It was not in memory
            '    ' Initialize the SqlCommand
            '    command = New SqlCommand(spName, GetSqlConnection(transaction))

            '    ' Tell the SqlCommand that we are using a stored procedure
            '    command.CommandType = CommandType.StoredProcedure

            '    ' Build the parameters, if there are any
            '    BuildParameters(command)

            '    ' Put the SqlCommand instance into memory
            '    Me._commandParametersHashTable(hashKey) = command
            'Else
            '    ' It was in memory, but we still need to set the 
            '    ' connection property
            '    command.Connection = GetSqlConnection(transaction)
            'End If

            '' Return the initialized SqlCommand instance
            'Return command
        End Function

        ''' <summary>
        ''' Executes a stored procedure with or without parameters and returns an 
        ''' IDictionary instance with the stored procedure's output parameter 
        ''' name(s) and value(s).
        ''' </summary>
        ''' <param name="transaction">The transaction that the stored procedure 
        ''' will be executed under.</param>
        ''' <param name="spName">The name of the stored procedure to execute.</param>
        ''' <param name="paramValues">A name-value pair of stored procedure parameter 
        ''' name(s) and value(s).</param>
        ''' <returns>An IDictionary object.</returns>
        Public Function ExecSpOutputValues(ByVal spName As String, _
                                           ByVal paramValues As IDictionary) As IDictionary

            'Dim command As SqlCommand = Nothing
            'Try
            '    ' Get the initialized SqlCommand instance
            '    command = GetSqlCommand(transaction, spName)

            '    ' Set the parameter values for the SqlCommand
            '    SetParameterValues(command, paramValues)

            '    ' Run the stored procedure
            '    RunSp(command)

            '    ' Get the output values
            '    Dim outputParams As New Hashtable()
            '    Dim param As SqlParameter
            '    For Each param In command.Parameters
            '        If param.Direction = ParameterDirection.Output _
            '            Or param.Direction = ParameterDirection.InputOutput Then
            '            outputParams.Add(param.ParameterName, param.Value)
            '        End If
            '    Next param

            '    Return outputParams
            'Catch e As Exception
            '    'LogError(e)
            '    Throw New Exception(ExceptionMsg, e)
            'Finally
            '    ' Close and release resources
            '    DisposeCommand(command)
            'End Try
        End Function
        ''' <summary>
        ''' 将更新处理后的Datatable重新更新回SQL
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UploadCachedDataTable2SQL(dt As DataTable) As Boolean
            Try
                'Open()

                'Dim scmd As SqlCommand = New SqlCommand() '定义一个SqlCommand的实例，以便绑定  
                'scmd.CommandType = CommandType.Text
                ''scmd.Connection = New SqlConnection(con)

                'scmd.Parameters.Add("@acc_title_id", SqlDbType.Int, 4, "acc_title_id") '重要的地方，将dt的列写到参数中去  
                'scmd.Parameters.Add("@acc_std_title_id", SqlDbType.Int, 4, "acc_std_title_id")
                'scmd.Parameters.Add("@back_id", SqlDbType.Int, 4, "back_id")

                'scmd.CommandText = String.Format("update t_std_acc_title_ent_acc_title set acc_title_id=@acc_title_id where acc_std_title_id = @acc_std_title_id and acc_id = {0} and acc_title_id=@back_id", eleid) '/更新操作对应的sql语句  
                'm_SQLAdapter.UpdateCommand = scmd '设置SqlDataAdapter执行Update操作时使用的对象  
                ''还需要设置另外那三个SqlCommand对象，方法类似，这里就不赘述了。  

                '设置3个命令。不需要SelectCommand?
                'm_SQLAdapter.SelectCommand.CommandText = "Select * from " & m_DataTableName & " where Symbol='000001'"
                'm_SQLAdapter.UpdateCommand=
                'm_SQLAdapter.InsertCommand=
                'm_SQLAdapter.DeleteCommand=

                ''!!!!!，这点很关键，自动创建commandbuilder

                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(m_SQLAdapter)
                m_SQLAdapter.Update(dt.GetChanges())

                dt.AcceptChanges()

                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            Finally
                Close()
            End Try

        End Function

        Public Property TheDataTable() As DataTable
            Get
                TheDataTable = m_DataTable
            End Get
            Set(value As DataTable)
                m_DataTable = value
            End Set
        End Property


        Public Property DataTableName() As String
            Get
                DataTableName = m_DataTableName
            End Get
            Set(value As String)
                m_DataTableName = value
            End Set
        End Property

        ''' <summary>
        ''' Disposes a SqlCommand and its underlying SqlConnection.
        ''' </summary>
        ''' <param name="command"></param>
        Private Sub DisposeCommand(ByVal command As SqlCommand)
            If Not (command Is Nothing) Then
                If Not (command.Connection Is Nothing) Then
                    command.Connection.Close()
                    command.Connection.Dispose()
                End If
                command.Dispose()
            End If
        End Sub

    End Class
  

End Namespace
