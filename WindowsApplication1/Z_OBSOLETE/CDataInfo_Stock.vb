Imports MyTradingSystem.DataBase

Namespace DataEntity

    '股票基本信息列表类，保存如股票代码、股票名称、上市时间、目前活跃度评分、所属沪深股市、流通股、总股本等
    Public Class CDataInfo_Stock
        'Inherits System.Data.DataRow


        Protected m_sSymbol As String   '股票名称
        Protected m_sFullName As String '股票名称

        Protected m_dataRow As DataRow
        Public Sub New()
            'm_dataRow.SetField(0,"0000"

        End Sub
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
        '从数据库根据Code(Symbol)得出股票名称
        Public Function GetFullNamebySymbol(sSymbol As String) As String



            Return ""
        End Function


        Public Function InsertStockInfo(strSymbol As String, strFullName As String) As Boolean
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

                arrInParaName(0) = "@stocksymbol"
                arrInParaName(1) = "@stockfullname"
                arrInParaValue(0) = strSymbol
                arrInParaValue(1) = strFullName


                Dim obj As New CDBADOCommand(GlobalVariables.gSQLConnectionString)

                'obj.ExecSP("dbo.InsertStockInfo", arrInParaName, arrInParaValue, arrOutParaName, arrOutParaValue)

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

                arrParaName(0) = "@Symbol"
                arrParaValue(0) = strSymbol
                arrOutparaName(0) = "@FullName"

                obj.ExecSP_Query("dbo.GetStockFullNamebySymbol", arrParaName, arrParaValue, arrOutparaName, arrOutParaValue)
                Return arrOutParaValue(0)

            Catch ex As Exception
                MsgBox(ex.Message)
                'Return False
                Return ""
            End Try
        End Function

        Public Function GetAllSymbols(ByRef lstSymbols As List(Of String)) As Integer
            Try
                'Dim strSymbols() As String
                Dim iRow, iTotalRows As Integer
                Dim objReader As SqlClient.SqlDataReader
                Dim objData As New DataBase.CDBADODataReader(GlobalVariables.gSQLConnectionString)

                objReader = objData.CreateDataReader("select Symbol from StockInfo")
                'iTotalRows = objReader.
                'ReDim strSymbols(iTotalRows)

                While objReader.Read()
                    lstSymbols.Add(objReader.Item(0).ToString)
                    iRow = iRow + 1
                End While

                objData = Nothing
                objReader.Close()

                Return iRow
            Catch ex As Exception
                'MsgBox(ex.Message)
                Return Nothing
            End Try
        End Function
    End Class
End Namespace
