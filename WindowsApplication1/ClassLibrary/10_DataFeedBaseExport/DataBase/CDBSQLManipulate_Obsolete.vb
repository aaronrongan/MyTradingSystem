Imports System.Data
Imports System.Data.SqlClient


Namespace DataBase

    '包含几大类的数据，原则为一个表设置为1个类，进行Insert/Update/Delete的操作
    'CDBSQLManipulate_StockPrice
    'CDBSQLManipulate_StockList

    Public Class CDBSQLManipulate_StockPrice
        Private m_dtStockPrice As DataTable

        Public Property StockPrice As Integer
            Get

            End Get
            Set(value As Integer)

            End Set
        End Property
        ''' <summary>
        ''' 保存Stock价格信息
        ''' </summary>
        Public Function InsertStockPrice() As Boolean

        End Function

        ''' <summary>
        ''' 更新Stock价格信息
        ''' </summary>
        Public Function UpdateStockPrice() As Boolean

        End Function

        ''' <summary>
        ''' 提取Stock价格信息
        ''' </summary>
        Public Function QueryStockPrice() As Boolean

        End Function

        Public Function DeleteStockPrice() As Boolean

        End Function

    End Class
    Public Class CDBSQLManipulate_StockList

        Private m_dtStockInfo As DataTable


        Public Property StockInfo As Integer
            Get

            End Get
            Set(value As Integer)

            End Set
        End Property

        ''' <summary>
        ''' 保存Stock列表信息，使用SQL中的存储过程
        ''' 使用多个字段分开作为传入参数
        ''' </summary>
        'Public Function InsertStockInfo(strSymbol As String, strFullName As String) As Boolean
        '    Try
        '        'Dim conSQL As SqlClient.SqlConnection
        '        'conSQL = New SqlClient.SqlConnection()
        '        'conSQL.ConnectionString = GlobalVariables.gSQLConnectionString
        '        'conSQL.Open()

        '        'Dim commSQL As SqlClient.SqlCommand = New SqlCommand()
        '        'commSQL.Connection = conSQL
        '        'commSQL.CommandType = CommandType.StoredProcedure
        '        'commSQL.CommandText = "dbo.InsertStockListInfo"

        '        'Dim paramSQL As New SqlClient.SqlParameter("@stocksymbol", SqlDbType.VarChar)
        '        'paramSQL.Direction = ParameterDirection.Input
        '        'paramSQL.Value = strSymbol
        '        'commSQL.Parameters.Add(paramSQL)

        '        'paramSQL = New SqlClient.SqlParameter("@stockfullname", SqlDbType.VarChar)
        '        'paramSQL.Value = strFullName
        '        'commSQL.Parameters.Add(paramSQL)

        '        'Dim datRead As SqlClient.SqlDataReader
        '        'datRead = commSQL.ExecuteReader()
        '        'Do While datRead.Read()
        '        '    MessageBox.Show(datRead(0).ToString)
        '        'Loop
        '        'datRead.Close()

        '        Dim arrInParaName(2) As String
        '        Dim arrInParaValue(2) As String
        '        Dim arrOutParaName(0) As String
        '        Dim arrOutParaValue(0) As String

        '        arrInParaName(0) = "@stocksymbol"
        '        arrInParaName(1) = "@stockfullname"
        '        arrInParaValue(0) = strSymbol
        '        arrInParaValue(1) = strFullName


        '        Dim obj As New CDBADOCommand(GlobalVariables.gSQLConnectionString)

        '        'obj.ExecSP("dbo.ISI_InsertStockInfo", arrInParaName, arrInParaValue, arrOutParaName, arrOutParaValue)

        '        Return True

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '        Return False
        '    End Try



        'End Function
        ''' <summary>
        ''' 保存Stock列表信息，使用SQL中的存储过程
        ''' 用一个字符串数组作为传入参数 // ??使用DataTable作为传入参数
        ''' </summary>
        ''' 
        Public Function InsertStockInfo(arr() As String) As Boolean
            'Dim strSQL As String ="Insert "


        End Function



        ''' <summary>
        ''' 更新Stock价格信息
        ''' </summary>
        Public Function UpdateStockInfo() As Boolean

        End Function

        ''' <summary>
        ''' 提取Stock列表信息
        ''' </summary>
        Public Function QueryStockInfo() As Boolean

        End Function



        Public Function DeleteStockInfo() As Boolean

        End Function

        ''' <summary>
        ''' 根据Symbol取得股票名称
        ''' </summary>
        Public Function GetStockFullNamebySymbol(strSymbol As String) As String
            Try
                Dim obj As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
                Dim arrParaName(1) As String
                Dim arrParaValue(1) As String
                Dim arrOutparaName(1) As String
                Dim arrOutParaValue(1) As String

                arrParaName(0) = "@Symbol"
                arrParaValue(0) = strSymbol
                arrOutparaName(0) = "@FullName"

                obj.ExecSP_Query("dbo.ISI_GetStockFullNamebySymbol", arrParaName, arrParaValue, arrOutparaName, arrOutParaValue)
                Return arrOutParaValue(0)

            Catch ex As Exception
                MsgBox(ex.Message)
                'Return False
                Return ""
            End Try
        End Function

        ''' <summary>
        ''' 根据股票名称取得股票代码
        ''' </summary>
        Public Sub QuerySymbolbyStockName()

        End Sub


    End Class
    Public Class CDBSQLManipulate_IndexList
        ''' <summary>
        ''' 保存Stock列表信息，使用SQL中的存储过程
        ''' 使用多个字段分开作为传入参数
        ''' </summary>
        Public Function InsertIndexListInfo(strSymbol As String, strFullName As String) As Boolean
            Try

                Dim arrInParaName(2) As String
                Dim arrInParaValue(2) As String

                arrInParaName(0) = "@IndexSymbol"
                arrInParaName(1) = "@IndexFullname"
                arrInParaValue(0) = strSymbol
                arrInParaValue(1) = strFullName

                Dim obj As New CDBADOCommand(GlobalVariables.gSQLConnectionString)

                obj.ExecSP_NoQuery("dbo.III_InsertIndexInfo", arrInParaName, arrInParaValue, StatementType.Insert)

                Return True

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try



        End Function

        ''' <summary>
        ''' 保存Stock列表信息，使用SQL中的存储过程
        ''' 用一个字符串数组作为传入参数 // ??使用DataTable作为传入参数
        ''' </summary>
        ''' 
        Public Function InsertIndexInfo(arr() As String) As Boolean
            'Dim strSQL As String ="Insert "


        End Function

    End Class

End Namespace

