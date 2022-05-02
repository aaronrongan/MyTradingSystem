
'指数基本信息列表类，保存如指数代码、指数名称、上市时间、目前活跃度评分等
Imports MyTradingSystem.DataBase

Namespace DataEntity
    Public Class CDataInfo_Index


        Protected m_sSymbol As String   '指数名称
        Protected m_sFullName As String '指数名称


        Public Property Symbol() As String
            Get
                Symbol = m_sSymbol
            End Get
            Set(value As String)
                m_sSymbol = value
            End Set
        End Property

        Public Property FullName() As String
            Get
                FullName = m_sFullName
            End Get
            Set(value As String)
                m_sFullName = value
            End Set
        End Property
        '从数据库根据Code(Symbol)得出指数名称
        Public Function GetFullNamebySymbol(sSymbol As String) As String



            Return ""
        End Function

        Public Function SaveDatabase() As Boolean

            Return 0
        End Function

        Public Function InsertIndexInfo(strSymbol As String, strFullName As String) As Boolean
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

                Dim arrInParaName(2) As String
                Dim arrInParaValue(2) As String
                Dim arrOutParaName(0) As String
                Dim arrOutParaValue(0) As String

                arrInParaName(0) = "@indexsymbol"
                arrInParaName(1) = "@indexfullname"
                arrInParaValue(0) = strSymbol
                arrInParaValue(1) = strFullName

                Dim obj As New CDBADOCommand(GlobalVariables.gSQLConnectionString)

                'obj.ExecSP("dbo.III_InsertIndexInfo", arrInParaName, arrInParaValue, arrOutParaName, arrOutParaValue)

                Return True

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try



        End Function

        Public Function GetStockFullNamebySymbol(strSymbol As String) As String
            Try
                Dim obj As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
                Dim arrParaName(1) As String
                Dim arrParaValue(1) As String
                Dim arrOutparaName(1) As String
                Dim arrOutParaValue(1) As String

                arrParaName(0) = "@indexsymbol"
                arrParaValue(0) = strSymbol
                arrOutparaName(0) = "@indexfullname"

                obj.ExecSP_Query("dbo.QueryIndexFullNamebySymbol", arrParaName, arrParaValue, arrOutparaName, arrOutParaValue)
                Return arrOutParaValue(0)

            Catch ex As Exception
                MsgBox(ex.Message)
                'Return False
                Return ""
            End Try
        End Function
    End Class
End Namespace
