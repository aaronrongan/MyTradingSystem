

Option Explicit On 
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Collections
Imports System.Diagnostics

Namespace DataBase

    ''' <summary>
    ''' This class wraps stored procedure calls to SQL Server.  It requires that all
    ''' stored procedures and their parameters be defined in an XML document before 
    ''' calling any of its methods.  The XML can be passed in as an XmlDocument 
    ''' instance or as a string of XML.  The only exceptions to this rule are 
    ''' stored procedures that do not have parameters.  This class also caches 
    ''' SqlCommand objects.  Each time a stored procedure is executed, a SqlCommand
    ''' object is built and cached into memory so that the next time the stored 
    ''' procedure is called the SqlCommand object can be retrieved from memory.
    ''' </summary>
    Public NotInheritable Class CDBSqlServerWrapper 'StoredProcedureHelper

        Private _connectionString As String = ""
        Private _spParamXml As String = ""
        Private _spParamXmlDoc As XmlDocument = Nothing
        Private _spParamXmlNode As XmlNode = Nothing
        Private _commandParametersHashTable As New Hashtable()

        Private Const ExceptionMsg As String = "There was an error in the method.  " _
            & "Please see the Windows Event Viewer Application log for details"

#Region "Public Instance Constructors"

        ''' <summary>
        ''' Default constructor.
        ''' </summary>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Overloaded constructor.
        ''' </summary>
        ''' <param name="connectionString">The connection string to the 
        ''' SQL Server database.</param>
        Public Sub New(ByVal connectionString As String)
            Me._connectionString = connectionString
        End Sub

        ''' <summary>
        ''' Overloaded constructor.
        ''' </summary>
        ''' <param name="connectionString">The connection string to the 
        ''' SQL Server database.</param>
        ''' <param name="spParamXml">A valid XML string which conforms to 
        ''' the correct schema for stored procedure(s) and their 
        ''' associated parameter(s).</param>
        Public Sub New(ByVal connectionString As String, ByVal spParamXml As String)
            Me.New(connectionString)
            Me._spParamXml = spParamXml
            Me._spParamXmlDoc = New XmlDocument
            Try
                Me._spParamXmlDoc.LoadXml(spParamXml)
                Me._spParamXmlNode = Me._spParamXmlDoc.DocumentElement
            Catch e As XmlException
                LogError(e)
                Throw New Exception(ExceptionMsg, e)
            End Try
        End Sub

        ''' <summary>
        ''' Overloaded constructor.
        ''' </summary>
        ''' <param name="connectionString">The connection string to the SQL Server database.</param>
        ''' <param name="spParamXmlDoc">An XML document instance which contains the stored 
        ''' procedure(s) and their associated parameter(s).</param>
        Public Sub New(ByVal connectionString As String, ByVal spParamXmlDoc As XmlDocument)
            Me.New(connectionString)
            Me._spParamXmlDoc = spParamXmlDoc
            Me._spParamXmlNode = Me._spParamXmlDoc.DocumentElement
        End Sub

        ''' <summary>
        ''' Overloaded constructor.
        ''' </summary>
        ''' <param name="spParamXmlDoc">An XML document instance which contains the stored 
        ''' procedure(s) and their associated parameter(s).</param>
        Public Sub New(ByVal spParamXmlDoc As XmlDocument)
            Me.New("", spParamXmlDoc)
        End Sub

        ''' <summary>
        ''' Overloaded constructor.
        ''' </summary>
        ''' <param name="connectionString">The connection string to the SQL Server database.</param>
        ''' <param name="spParamXmlNode">An XML document instance which contains the stored 
        ''' procedure(s) and their associated parameter(s).</param>
        Public Sub New(ByVal connectionString As String, ByVal spParamXmlNode As XmlNode)
            Me.New(connectionString)
            Me._spParamXmlNode = spParamXmlNode
        End Sub

        ''' <summary>
        ''' Overloaded constructor.
        ''' </summary>
        ''' <param name="spParamXmlNode">An XmlNode instance which contains the stored 
        ''' procedure(s) and their associated parameter(s).</param>
        Public Sub New(ByVal spParamXmlNode As XmlNode)
            Me.New("", spParamXmlNode)
        End Sub

#End Region

#Region "Public Properties"

        ''' <summary>
        ''' The connection string to the SQL Server database.
        ''' </summary>
        Public Property ConnectionString() As String
            Get
                Return Me._connectionString
            End Get
            Set(ByVal Value As String)
                Me._connectionString = Value
            End Set
        End Property

        ''' <summary>
        ''' A valid XML string which conforms to the correct schema for 
        ''' stored procedure(s) and their associated parameter(s).
        ''' </summary>
        Public Property SpParamXml() As String
            Get
                Return Me._spParamXml
            End Get
            Set(ByVal Value As String)
                Me._spParamXml = Value
                ' Set the XmlDocument instance to null, since
                ' an XML string is being passed in.
                Me._spParamXmlDoc = Nothing
                Try
                    Me._spParamXmlDoc.LoadXml(Me._spParamXml)
                    Me._spParamXmlNode = Me._spParamXmlDoc.DocumentElement
                Catch e As XmlException
                    LogError(e)
                    Throw New Exception(ExceptionMsg)
                End Try
            End Set
        End Property

        ''' <summary>
        ''' An XML document instance which contains the stored 
        ''' procedure(s) and their associated parameter(s).
        ''' </summary>
        Public Property SpParamXmlDoc() As XmlDocument
            Get
                Return Me._spParamXmlDoc
            End Get
            Set(ByVal Value As XmlDocument)
                Me._spParamXmlDoc = Value
            End Set
        End Property

#End Region

#Region "Public Methods"

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
        Public Function GetSqlCommand(ByVal transaction As SqlTransaction, _
            ByVal spName As String) As SqlCommand
            Dim command As SqlCommand = Nothing

            ' Get the name of the stored procedure
            If spName.Length < 1 Or spName.Length > 127 Then
                Throw New ArgumentOutOfRangeException("spName", _
                    "Stored procedure name must be from 1 - 128 characters.")
            End If

            ' See if the command object is already in memory
            Dim hashKey As String = Me._connectionString & ":" & spName
            command = CType(_commandParametersHashTable(hashKey), SqlCommand)
            If command Is Nothing Then
                ' It was not in memory
                ' Initialize the SqlCommand
                command = New SqlCommand(spName, GetSqlConnection(transaction))

                ' Tell the SqlCommand that we are using a stored procedure
                command.CommandType = CommandType.StoredProcedure

                ' Build the parameters, if there are any
                BuildParameters(command)

                ' Put the SqlCommand instance into memory
                Me._commandParametersHashTable(hashKey) = command
            Else
                ' It was in memory, but we still need to set the 
                ' connection property
                command.Connection = GetSqlConnection(transaction)
            End If

            ' Return the initialized SqlCommand instance
            Return command
        End Function

        ''' <summary>
        ''' Overload.  Initializes a SqlCommand object based on a stored 
        ''' procedure name, with no SqlTransaction instance.
        ''' Verifies that the stored procedure name is valid, and then tries 
        ''' to get the SqlCommand object from cache.  If it is not already in 
        ''' cache, then the SqlCommand object is initialized and placed into cache.
        ''' </summary>
        ''' <param name="spName">The name of the stored procedure to execute.</param>
        ''' <returns>An initialized SqlCommand object.</returns>
        Public Function GetSqlCommand(ByVal spName As String) As SqlCommand
            ' Return the initialized SqlCommand instance
            Return GetSqlCommand(Nothing, spName)
        End Function

        ''' <summary>
        ''' Traverses the SqlCommand's SqlParameters collection and sets the values 
        ''' for all of the SqlParameter(s) objects whose direction is not Output and 
        ''' whose name matches the name in the dictValues IDictionary that was 
        ''' passed in. 
        ''' </summary>
        ''' <param name="command">An initialized SqlCommand object.</param>
        ''' <param name="dictValues">A name-value pair of stored procedure parameter 
        ''' name(s) and value(s).</param>
        Public Sub SetParameterValues(ByVal command As SqlCommand, _
            ByVal dictValues As IDictionary)
            If command Is Nothing Then
                Throw New ArgumentNullException("command", _
                    "The command argument cannot be null.")
            End If
            ' Traverse the SqlCommand's SqlParameters collection
            Dim parameter As SqlParameter
            For Each parameter In command.Parameters
                ' Do not set Output parameters
                If parameter.Direction <> ParameterDirection.Output Then
                    ' Set the initial value to DBNull
                    parameter.Value = TypeCode.DBNull
                    ' If there is a match, then update the parameter value
                    If dictValues.Contains(parameter.ParameterName) Then
                        parameter.Value = dictValues(parameter.ParameterName)
                    Else
                        ' There was not a match
                        ' If the parameter value cannot be null, throw an exception
                        If Not parameter.IsNullable Then
                            Throw New ArgumentNullException(parameter.ParameterName, _
                                "Error getting the value for the " _
                                & parameter.ParameterName & " parameter.")
                        End If
                    End If
                End If
            Next parameter
        End Sub

        ''' <summary>
        ''' Executes a stored procedure with or without parameters and returns a 
        ''' populated DataSet object.
        ''' </summary>
        ''' <param name="spName">The name of the stored procedure to execute.</param>
        ''' <param name="dataSetName">An optional name for the DataSet instance.</param>
        ''' <param name="paramValues">A name-value pair of stored procedure parameter 
        ''' name(s) and value(s).</param>
        ''' <returns>A populated DataSet object.</returns>
        Public Function ExecSpReturnDataSet(ByVal spName As String, _
                                            ByVal dataSetName As String, _
                                            ByVal paramValues As IDictionary) As DataSet
            Dim command As SqlCommand = Nothing
            Try
                ' Get the initialized SqlCommand instance
                command = GetSqlCommand(spName)

                ' Set the parameter values for the SqlCommand
                SetParameterValues(command, paramValues)

                ' Initialize the SqlDataAdapter with the SqlCommand object
                Dim sqlDA As New SqlDataAdapter(command)

                ' Initialize the DataSet
                Dim ds As New DataSet()

                ' Try to set the name of the DataSet
                If Not (dataSetName Is Nothing) Then
                    If dataSetName.Length > 0 Then
                        ds.DataSetName = dataSetName
                    End If
                End If

                ' Fill the DataSet
                sqlDA.Fill(ds)

                ' Return the DataSet
                Return ds
            Catch e As Exception
                LogError(e)
                Throw New Exception(ExceptionMsg, e)
            Finally
                ' Close and release resources
                DisposeCommand(command)
            End Try
        End Function

        ''' <summary>
        ''' Executes a stored procedure with or without parameters and returns a 
        ''' populated DataTable object.
        ''' </summary>
        ''' <param name="spName">The name of the stored procedure to execute.</param>
        ''' <param name="dataTableName">An optional name for the DataTable instance.</param>
        ''' <param name="paramValues">A name-value pair of stored procedure parameter 
        ''' name(s) and value(s).</param>
        ''' <returns>A populated DataTable object.</returns>
        Public Function ExecSpReturnDataTable(ByVal spName As String, _
                                              ByVal dataTableName As String, _
                                              ByVal paramValues As IDictionary) As DataTable
            Dim command As SqlCommand = Nothing
            Try
                ' Get the initialized SqlCommand instance
                command = GetSqlCommand(spName)

                ' Set the parameter values for the SqlCommand
                SetParameterValues(command, paramValues)

                ' Initialize the SQLDataAdapter with the SQLCommand object
                Dim sqlDA As New SqlDataAdapter(command)

                ' Initialize the DataTable
                Dim dt As New DataTable()

                If Not (dataTableName Is Nothing) Then
                    If dataTableName.Length > 0 Then
                        dt.TableName = dataTableName
                    End If
                End If

                ' Fill the DataTable
                sqlDA.Fill(dt)

                ' Return the DataTable
                Return dt
            Catch e As Exception
                LogError(e)
                Throw New Exception(ExceptionMsg, e)
            Finally
                ' Close and release resources
                DisposeCommand(command)
            End Try
        End Function

        ''' <summary>
        ''' Executes a stored procedure with or without parameters and returns a 
        ''' SqlDataReader instance with a live connection to the database.  It is
        ''' very important to call the Close method of the SqlDataReader as soon 
        ''' as possible after using it.
        ''' </summary>
        ''' <param name="spName">The name of the stored procedure to execute.</param>
        ''' <param name="paramValues">A name-value pair of stored procedure parameter 
        ''' name(s) and value(s).</param>
        ''' <returns>A SqlDataReader object.</returns>
        Public Function ExecSpReturnDataReader(ByVal spName As String, _
                                               ByVal paramValues As IDictionary) As SqlDataReader
            Dim command As SqlCommand = Nothing
            Try
                ' Get the initialized SqlCommand instance
                command = GetSqlCommand(spName)

                ' Set the parameter values for the SqlCommand
                SetParameterValues(command, paramValues)

                ' Open the connection
                command.Connection.Open()

                ' Execute the sp and return the SqlDataReader
                Return command.ExecuteReader(CommandBehavior.CloseConnection)
            Catch e As Exception
                LogError(e)
                Throw New Exception(ExceptionMsg, e)
            End Try
        End Function

        ''' <summary>
        ''' Executes a stored procedure with or without parameters and returns an 
        ''' XmlReader instance with a live connection to the database.  It is
        ''' very important to call the Close method of the XmlReader as soon 
        ''' as possible after using it.  Only use this method when calling stored 
        ''' procedures that return XML results (FOR XML ...). 
        ''' </summary>
        ''' <param name="spName">The name of the stored procedure to execute.</param>
        ''' <param name="paramValues">A name-value pair of stored procedure parameter 
        ''' name(s) and value(s).</param>
        ''' <returns>An XmlReader object.</returns>
        Public Function ExecSpReturnXmlReader(ByVal spName As String, _
                                              ByVal paramValues As IDictionary) As XmlReader
            Dim command As SqlCommand = Nothing
            Try
                ' Get the initialized SqlCommand instance
                command = GetSqlCommand(spName)

                ' Set the parameter values for the SqlCommand
                SetParameterValues(command, paramValues)

                ' Open the connection
                command.Connection.Open()

                ' Execute the sp and return the XmlReader
                Return command.ExecuteXmlReader()
            Catch e As Exception
                LogError(e)
                Throw New Exception(ExceptionMsg, e)
            End Try
        End Function

        '''' <summary>
        '''' Executes a stored procedure with or without parameters and returns an 
        '''' SqlRecord instance. 
        '''' </summary>
        '''' <param name="spName">The name of the stored procedure to execute.</param>
        '''' <param name="paramValues">A name-value pair of stored procedure parameter 
        '''' name(s) and value(s).</param>
        '''' <returns>An SqlRecord object.</returns>
        'Public Function ExecSpReturnRecord(ByVal spName As String, _
        '                                      ByVal paramValues As IDictionary) As SqlRecord
        '    Dim command As SqlCommand = Nothing
        '    Try
        '        ' Get the initialized SqlCommand instance
        '        command = GetSqlCommand(spName)

        '        ' Set the parameter values for the SqlCommand
        '        SetParameterValues(command, paramValues)

        '        ' Open the connection
        '        command.Connection.Open()

        '        ' Execute the sp and return the XmlReader
        '        Return command.ExecuteRow()
        '    Catch e As Exception
        '        LogError(e)
        '        Throw New Exception(ExceptionMsg, e)
        '    Finally
        '        ' Close and release resources
        '        DisposeCommand(command)
        '    End Try
        'End Function

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
        Public Function ExecSpOutputValues(ByVal transaction As SqlTransaction, _
                                           ByVal spName As String, _
                                           ByVal paramValues As IDictionary) As IDictionary

            Dim command As SqlCommand = Nothing
            Try
                ' Get the initialized SqlCommand instance
                command = GetSqlCommand(transaction, spName)

                ' Set the parameter values for the SqlCommand
                SetParameterValues(command, paramValues)

                ' Run the stored procedure
                RunSp(command)

                ' Get the output values
                Dim outputParams As New Hashtable()
                Dim param As SqlParameter
                For Each param In command.Parameters
                    If param.Direction = ParameterDirection.Output _
                        Or param.Direction = ParameterDirection.InputOutput Then
                        outputParams.Add(param.ParameterName, param.Value)
                    End If
                Next param
                Return outputParams
            Catch e As Exception
                LogError(e)
                Throw New Exception(ExceptionMsg, e)
            Finally
                ' Close and release resources
                DisposeCommand(command)
            End Try
        End Function

        ''' <summary>
        ''' Overload 1.  Executes a stored procedure with or without parameters and returns an 
        ''' IDictionary instance with the stored procedure's output parameter 
        ''' name(s) and value(s).
        ''' </summary>
        ''' <param name="spName">The name of the stored procedure to execute.</param>
        ''' <param name="paramValues">A name-value pair of stored procedure parameter 
        ''' name(s) and value(s).</param>
        ''' <returns>An IDictionary object.</returns>
        Public Function ExecSpOutputValues(ByVal spName As String, _
                                           ByVal paramValues As IDictionary) As IDictionary
            Return ExecSpOutputValues(Nothing, spName, paramValues)
        End Function

        ''' <summary>
        ''' Executes a stored procedure with or without parameters that 
        ''' does not return output values or a resultset.
        ''' </summary>
        ''' <param name="transaction">The transaction that the stored procedure 
        ''' will be executed under.</param>
        ''' <param name="spName">The name of the stored procedure to execute.</param>
        ''' <param name="paramValues">A name-value pair of stored procedure parameter 
        ''' name(s) and value(s).</param>
        Public Sub ExecSp(ByVal transaction As SqlTransaction, _
                          ByVal spName As String, _
                          ByVal paramValues As IDictionary)
            Dim command As SqlCommand = Nothing
            Try
                ' Get the initialized SqlCommand instance
                command = GetSqlCommand(transaction, spName)

                ' Set the parameter values for the SqlCommand
                SetParameterValues(command, paramValues)

                ' Run the stored procedure
                RunSp(command)
            Catch e As Exception
                LogError(e)
                Throw New Exception(ExceptionMsg, e)
            Finally
                ' Close and release resources
                DisposeCommand(command)
            End Try
        End Sub

        ''' <summary>
        ''' Overload 1.  Executes a stored procedure with or without parameters that 
        ''' does not return output values or a resultset.
        ''' </summary>
        ''' <param name="spName">The name of the stored procedure to execute.</param>
        ''' <param name="paramValues">A name-value pair of stored procedure parameter 
        ''' name(s) and value(s).</param>
        Public Sub ExecSp(ByVal spName As String, _
                          ByVal paramValues As IDictionary)
            ExecSp(Nothing, spName, paramValues)
        End Sub

#End Region

#Region "Private Methods"

        ''' <summary>
        ''' Helper method that tries to derive a SqlConnection from a 
        ''' SqlTransaction instance. If the SqlTransaction is null, then 
        ''' a new SqlConnection is created.
        ''' </summary>
        ''' <param name="transaction">A SqlTransaction object.</param>
        Private Function GetSqlConnection(ByVal transaction As SqlTransaction) As SqlConnection
            Dim connection As SqlConnection = Nothing
            If Not transaction Is Nothing Then
                connection = transaction.Connection
            Else
                connection = New SqlConnection(Me._connectionString)
            End If
            Return connection
        End Function

        ''' <summary>
        ''' Finds the parameter information for the stored procedure from the 
        ''' stored procedures XML document and then uses that information to 
        ''' build and append the parameter(s) for the SqlCommand's 
        ''' SqlParameters collection.
        ''' </summary>
        ''' <param name="command">An initialized SqlCommand object.</param>
        Private Sub BuildParameters(ByVal command As SqlCommand)
            ' See if there is an XmlNode of parameter(s) for the stored procedure
            If Me._spParamXmlNode Is Nothing Then
                ' No parameters to add, so exit
                Return
            End If

            ' Clear the parameters collection for the SqlCommand
            command.Parameters.Clear()

            ' Get the node list of <Parameter>'s for the stored procedure
            Dim xpathQuery As String = "//StoredProcedure[@name='" & command.CommandText & "']/Parameters/Parameter"
            Dim parameterNodes As XmlNodeList = Me._spParamXmlNode.SelectNodes(xpathQuery)

            For Each parameterNode As XmlElement In parameterNodes
                ' Get the attribute values for the <Parameter> element.
                ' name
                Dim parameterName As String = parameterNode.GetAttribute("name")
                If parameterName.Length = 0 Then
                    Throw New ArgumentNullException("name", "Error getting the 'name' " _
                        & "attribute for the <Parameter> element.")
                End If

                ' size
                Dim parameterSize As Integer = 0
                If parameterNode.GetAttribute("size").Length = 0 Then
                    Throw New ArgumentNullException("size", "Error getting the 'size' " _
                        & "attribute for the <Parameter> element.")
                Else
                    parameterSize = Convert.ToInt32(parameterNode.GetAttribute("size"))
                End If

                ' datatype
                Dim sqlDataType As SqlDbType
                If parameterNode.GetAttribute("datatype").Length = 0 Then
                    Throw New ArgumentNullException("datatype", "Error getting the 'datatype' " _
                        & "attribute for the <Parameter> element.")
                Else
                    sqlDataType = CType([Enum].Parse(GetType(SqlDbType), _
                        parameterNode.GetAttribute("datatype"), True), SqlDbType)
                End If

                ' direction
                Dim parameterDirection As ParameterDirection = parameterDirection.Input
                If parameterNode.GetAttribute("direction").Length > 0 Then
                    parameterDirection = CType([Enum].Parse(GetType(ParameterDirection), _
                        parameterNode.GetAttribute("direction"), True), ParameterDirection)
                End If

                ' Get the optional attribute values for the <Parameter> element

                ' isNullable
                Dim isNullable As Boolean = False
                Try
                    If parameterNode.GetAttribute("isNullable").Length > 0 Then
                        isNullable = Boolean.Parse(parameterNode.GetAttribute("isNullable"))
                    End If
                Catch
                End Try

                ' sourceColumn -- This must map to the name of a column in a DataSet.
                Dim sourceColumn As String = ""
                Try
                    If parameterNode.GetAttribute("sourceColumn").Length > 0 Then
                        sourceColumn = parameterNode.GetAttribute("sourceColumn")
                    End If
                Catch
                End Try

                ' Create the parameter object.  Pass in the name, datatype,
                ' and size to the constructor.
                Dim sqlParameter As SqlParameter = New SqlParameter(parameterName, _
                    sqlDataType, parameterSize)

                'Set the direction of the parameter.
                sqlParameter.Direction = parameterDirection

                ' If the optional attributes have values, then set them.
                ' IsNullable
                If isNullable Then
                    sqlParameter.IsNullable = isNullable
                End If
                ' SourceColumn
                sqlParameter.SourceColumn = sourceColumn

                ' Add the parameter to the SqlCommand's parameter collection
                command.Parameters.Add(sqlParameter)
            Next parameterNode
        End Sub

        ''' <summary>
        ''' Opens the SqlCommand object's underlying SqlConnection and calls 
        ''' the SqlCommand's ExecuteNonQuery method.
        ''' </summary>
        ''' <param name="command">An initialized SqlCommand object.</param>
        Private Sub RunSp(ByRef command As SqlCommand)
            ' Open the connection
            command.Connection.Open()

            ' Execute the stored procedure
            command.ExecuteNonQuery()
        End Sub

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

        ''' <summary>
        ''' Logs any errors to the Windows Event Viewer Application log, 
        ''' using the type name of this class as the source for the log entry.
        ''' </summary>
        ''' <param name="e">Any type of Exception instance.</param>
        Private Sub LogError(ByVal e As Exception)
            ' Capture all information about the error to the event log
            Try
                EventLog.WriteEntry(Me.GetType().ToString(), e.ToString(), EventLogEntryType.Error)
            Catch
            End Try
        End Sub

#End Region

    End Class

End Namespace
