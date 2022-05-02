Imports System.Data
Imports System.Data.SqlClient
Imports MyTradingSystem.DataBase
Namespace DataEntity

    Public Class CDTInfo_Stock
        Inherits CDTInfo



        'Protected Shadows m_Col2Name As String = "ShortName"    '数据库应为ShortName

        Private m_DataRow As DataRow

        Public Event InsertProgress(ByVal iProgress As Integer)

        Public Sub New()
            MyBase.New()
            m_strSQLTableName = "StockInfo"
            Me.TableName = m_strSQLTableName

            Me.Columns.Add("ChineseSpell", GetType(System.String))
            Me.Columns.Add("ExchangeCD", GetType(System.String))
            Me.Columns.Add("AssetClass", GetType(System.String))
            Me.Columns.Add("StatusCD", GetType(System.String))
            Me.Columns.Add("ListDate", GetType(System.String))

            Me.Columns.Add("CurrencyCD", GetType(System.String))
            Me.Columns.Add("ISIN", GetType(System.String))
            Me.Columns.Add("PartyID", GetType(System.String))

            Me.Columns.Add("ListSectorCD", GetType(System.String))
            Me.Columns.Add("ListSector", GetType(System.String))
            Me.Columns.Add("FullName", GetType(System.String))
            Me.Columns.Add("DelistDate", GetType(System.String))

            Me.Columns.Add("TotalShares", GetType(System.Double))
            Me.Columns.Add("NonrestFloatShares", GetType(System.Double))
            Me.Columns.Add("NonrestFloatAShares", GetType(System.Double))
            Me.Columns.Add("OfficeAddress", GetType(System.String))
            Me.Columns.Add("PrimeOperation", GetType(System.String))

            Me.Columns.Add("EndDate", GetType(System.String))
            Me.Columns.Add("ShareHolderEquity", GetType(System.Double))
            Me.Columns.Add("EquTypeCD", GetType(System.String))
            Me.Columns.Add("EquType", GetType(System.String))
            Me.Columns.Add("ExCountryCD", GetType(System.String))


        End Sub


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
        ''' 插入整个表的数据到SQL数据库
        ''' </summary>
        Public Function Insert2SQL() As Boolean
            Try
                Dim obj As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
                'obj.ExecSP_NoQuery("dbo.InsertStockInfo")
                'ExecStoredProcedure_NoQuery("dbo.InsertStockInfo")
                obj.ExecStoredProcedure_InsertTablebyRow("dbo.InsertStockInfo", Me)
                obj = Nothing
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Function

        ''' <summary>
        ''' 每次插入一行数据到SQL
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Insert2SQLbyRow() As Boolean
            Try
                Dim obj As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
                'obj.ExecSP_NoQuery("dbo.InsertStockInfo")
                'ExecStoredProcedure_NoQuery("dbo.InsertStockInfo")

                Dim i As Integer, iTotalRow As Integer
                iTotalRow = Me.Rows.Count
                For i = 0 To iTotalRow - 1
                    obj.ExecStoredProcedure_InsertRow("dbo.InsertStockInfo", Me, i)
                    RaiseEvent InsertProgress(i + 1)
                Next
                obj = Nothing
                Return True
            Catch ex As Exception
                If ex.HResult <> -2146232060 Then
                    MsgBox(ex.Message)
                Else
                    Console.WriteLine(ex.Message)
                End If

                Return False
            End Try

        End Function

        ''' <summary>
        ''' OBSOLETE
        ''' </summary>
        ''' <param name="spName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExecStoredProcedure_NoQuery(spName As String) As Boolean
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

                For j = 0 To iTotalCol - 1
                    arrInParaName(j) = "@" & Me.Columns(j).ColumnName
                Next

                For i = 0 To iTotalRow - 1
                    For j = 0 To iTotalCol - 1
                        arrInParaValue(j) = Me.Rows(i).Item(j)
                    Next
                    obj.ExecSP_NoQuery("dbo.InsertStockInfo", arrInParaName, arrInParaValue, System.Data.StatementType.Delete)
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

        ''' <summary>
        ''' 批量保存将一个表全部保存到SQL数据库
        ''' </summary>
        Public Sub BulkInsertTable2SQL(dt As DataTable)

        End Sub


        ''' <summary>
        ''' 从网页抓取列表清单，代码+名称
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSymbolListfromWeb() As SortedList
            Dim oDF As New DataFeed.CDataFeedWeb_StockInfo
            Dim sl As New SortedList

            sl = oDF.GetStockCodeSortedList()

            Return sl

        End Function
        Public Function GetStockSymbolbyFullName(strFullName As String) As String
            Try
                Dim obj As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
                Dim arrParaName(1) As String
                Dim arrParaValue(1) As String
                Dim arrOutparaName(1) As String
                Dim arrOutparaValue(1) As String

                arrParaName(0) = "@" & Me.m_Col2Name
                arrParaValue(0) = strFullName
                arrOutparaName(0) = "@" & Me.m_Col1Name
                arrOutparaValue(0) = ""

                'Dim strReturn As String = CType(obj.ExecSP_Scalar("dbo.ISI_GetStockSymbolbyFullName", arrParaName, arrParaValue, arrOutparaValue), String)
                obj.ExecSP_Query("dbo.ISI_GetStockSymbolbyFullName", arrParaName, arrParaValue, arrOutparaName, arrOutparaValue)

                Return arrOutparaValue(0)

            Catch ex As Exception
                MsgBox(ex.Message)
                'Return False
                Return ""
            End Try
        End Function



        ''' <summary>
        ''' 针对通联数据中的证券通用信息数据表
        ''' </summary>
        ''' <param name="dt_datayes"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function AdaptDatafromDataTable_Simple(ByVal dt_datayes As DataTable) As Boolean

            Try

                For Each row As DataRow In dt_datayes.Rows
                    Dim merow As DataRow = Me.NewRow

                    merow.Item("SecurityID") = row.Item("secID")
                    merow.Item("Symbol") = row.Item("ticker")
                    merow.Item("ShortName") = row.Item("secShortName")
                    merow.Item("ChineseSpell") = row.Item("cnSpell")
                    merow.Item("ExchangeCD") = row.Item("exchangeCD")
                    merow.Item("AssetClass") = row.Item("assetClass")
                    merow.Item("StatusCD") = row.Item("listStatusCD")
                    merow.Item("ListDate") = row.Item("listDate")
                    merow.Item("CurrencyCD") = row.Item("transCurrCD")
                    merow.Item("ISIN") = row.Item("ISIN")
                    merow.Item("PartyID") = row.Item("partyID")

                    Me.Rows.Add(merow)
                Next

                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function
        ''' <summary>
        ''' 更新SQL数据，按一条条
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpgradeData_Simple(dt As CDTInfo) As Boolean
            Try


                Dim strCommand As String
                'strCommand = String.Format("UPDATE {0} SET CustomerID = @CustomerID, CompanyName = @CompanyName  WHERE CustomerID = @oldCustomerID", strTableName, )
                Dim conn As SqlConnection = New SqlConnection(GlobalVariables.gSQLConnectionString)
                Dim adapter As New System.Data.SqlClient.SqlDataAdapter()

                Dim Command_Update As SqlCommand = New SqlCommand(strCommand, conn)

                strCommand = String.Format("UPDATE StockInfo SET SecurityID=@SecurityID," & _
                                          "ShortName=@ShortName, ChineseSpell=@ChineseSpell," & _
                                          "ExchangeCD =@ExchangeCD, AssetClass=@AssetClass, StatusCD=@StatusCD," & _
                                            "ListDate =@ListDate, CurrencyCD=@CurrencyCD," & _
                                            "ISIN =@ISIN, PartyID=@PartyID " & _
                                            "WHERE Symbol=@Symbol")


                ' Add the parameters for the UpdateCommand.
                Command_Update.Parameters.Add("@SecurityID", SqlDbType.NChar, 15, "SecurityID")
                Command_Update.Parameters.Add("@Symbol", SqlDbType.NChar, 10, "Symbol")
                Command_Update.Parameters.Add("@ShortName", SqlDbType.NChar, 20, "ShortName")
                Command_Update.Parameters.Add("@ChineseSpell", SqlDbType.NChar, 10, "ChineseSpell")
                Command_Update.Parameters.Add("@ExchangeCD", SqlDbType.NChar, 10, "ExchangeCD")
                Command_Update.Parameters.Add("@AssetClass", SqlDbType.NChar, 2, "AssetClass")
                Command_Update.Parameters.Add("@StatusCD", SqlDbType.NChar, 2, "StatusCD")
                Command_Update.Parameters.Add("@ListDate", SqlDbType.Date, 4, "ListDate")
                Command_Update.Parameters.Add("@CurrencyCD", SqlDbType.NChar, 10, "CurrencyCD")
                Command_Update.Parameters.Add("@ISIN", SqlDbType.NChar, 20, "ISIN")
                Command_Update.Parameters.Add("@PartyID", SqlDbType.Int, 4, "PartyID")


                'Dim parameter As SqlParameter = Command.Parameters.Add( _
                '    "@oldCustomerID", SqlDbType.NChar, 5, "CustomerID")
                'parameter.SourceVersion = DataRowVersion.Original

                adapter.UpdateCommand = Command_Update

                Dim Command_Insert As SqlCommand = New SqlCommand(strCommand, conn)

                '"Insert into dbo.StockInfo(Symbol,FullName) Values(@Symbol,@Fullname)"

                strCommand = String.Format("Insert into StockInfo (SecurityID,ShortNamem,ChineseSpell,ExchangeCD,AssetClass, StatusCD,ListDate,CurrencyCD,ISIN,PartyID) " & _
                                           "Values(@SecurityID,@ShortName, @ChineseSpell,@ExchangeCD,@AssetClass, @StatusCD, @ListDate, @CurrencyCD, @ISIN, @PartyID)")


                ' Add the parameters for the InsertCommand.
                Command_Insert.Parameters.Add("@SecurityID", SqlDbType.NChar, 15, "SecurityID")
                Command_Insert.Parameters.Add("@Symbol", SqlDbType.NChar, 10, "Symbol")
                Command_Insert.Parameters.Add("@ShortName", SqlDbType.NChar, 20, "ShortName")
                Command_Insert.Parameters.Add("@ChineseSpell", SqlDbType.NChar, 10, "ChineseSpell")
                Command_Insert.Parameters.Add("@ExchangeCD", SqlDbType.NChar, 10, "ExchangeCD")
                Command_Insert.Parameters.Add("@AssetClass", SqlDbType.NChar, 2, "AssetClass")
                Command_Insert.Parameters.Add("@StatusCD", SqlDbType.NChar, 2, "StatusCD")
                Command_Insert.Parameters.Add("@ListDate", SqlDbType.Date, 4, "ListDate")
                Command_Insert.Parameters.Add("@CurrencyCD", SqlDbType.NChar, 10, "CurrencyCD")
                Command_Insert.Parameters.Add("@ISIN", SqlDbType.NChar, 20, "ISIN")
                Command_Insert.Parameters.Add("@PartyID", SqlDbType.Int, 4, "PartyID")      'VIP 如果用Small就会报错，因为小于32000多
                adapter.InsertCommand = Command_Insert

                adapter.Update(dt)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Function


        ''' <summary>
        ''' 针对通联数据中的证券通用信息数据表
        ''' </summary>
        ''' <param name="dt_datayes"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overrides Function AdaptDatafromDataTable(ByVal dt_datayes As DataTable) As Boolean

            Try

                For Each row As DataRow In dt_datayes.Rows
                    Dim merow As DataRow = Me.NewRow

                    merow.Item("SecurityID") = row.Item("secID")
                    merow.Item("Symbol") = row.Item("ticker")
                    merow.Item("ExchangeCD") = row.Item("exchangeCD")
                    merow.Item("ListSectorCD") = row.Item("ListSectorCD")
                    merow.Item("ListSector") = row.Item("ListSector")

                    merow.Item("CurrencyCD") = row.Item("transCurrCD")
                    merow.Item("ShortName") = row.Item("secShortName")
                    merow.Item("FullName") = row.Item("secFullName")
                    merow.Item("StatusCD") = row.Item("listStatusCD")
                    merow.Item("ListDate") = row.Item("listDate")

                    merow.Item("DelistDate") = row.Item("delistDate")
                    merow.Item("EquTypeCD") = row.Item("equTypeCD")
                    merow.Item("EquType") = row.Item("equType")
                    merow.Item("ExCountryCD") = row.Item("exCountryCD")
                    merow.Item("PartyID") = row.Item("partyID")

                    merow.Item("TotalShares") = row.Item("totalShares")
                    merow.Item("NonrestFloatShares") = row.Item("nonrestFloatShares")
                    merow.Item("NonrestFloatAShares") = row.Item("nonrestfloatA")
                    merow.Item("OfficeAddress") = row.Item("officeAddr")
                    merow.Item("PrimeOperation") = row.Item("primeOperating")

                    merow.Item("EndDate") = row.Item("endDate")
                    merow.Item("ShareHolderEquity") = row.Item("TShEquity")

                    Me.Rows.Add(merow)
                Next

                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Function

        ''' <summary>
        ''' 更新SQL数据，按一条条，通联数据中的完整数据
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function UpgradeData(dt As CDTInfo) As Boolean
            Try

                Dim strCommand As String

                Dim conn As SqlConnection = New SqlConnection(GlobalVariables.gSQLConnectionString)
                Dim adapter As New System.Data.SqlClient.SqlDataAdapter()

                Dim Command_Update As SqlCommand = New SqlCommand(strCommand, conn)

                strCommand = String.Format("UPDATE StockInfo SET SecurityID=@SecurityID,ExchangeCD=@ExchangeCD,ListSectorCD=@ListSectorCD,ListSector=@ListSector, " & _
                                          "CurrencyCD =@CurrencyCD,  ShortName=@ShortName,FullName=@FullName, StatusCD=@StatusCD,ListDate=@ListDate," & _
                                            "DelistDate =@DelistDate, EquTypeCD=@EquTypeCD,EquType=@EquType,ExCountryCD=@ExCountryCD,PartyID=@PartyID," & _
                                            " TotalShares=@TotalShares, NonrestFloatShares=@NonrestFloatShares,NonrestFloatAShares=@NonrestFloatAShares,OfficeAddress=@OfficeAddress,PrimeOperation=@PrimeOperation," & _
                                            " EndDate=@EndDate, ShareHolderEquity=@ShareHolderEquity" & _
                                            " WHERE Symbol=@Symbol")


                ' Add the parameters for the UpdateCommand.
                With Command_Update.Parameters
                    .Add("@SecurityID", SqlDbType.NChar, 15, "SecurityID")
                    .Add("@Symbol", SqlDbType.NChar, 10, "Symbol")
                    .Add("@ExchangeCD", SqlDbType.NChar, 10, "ExchangeCD")
                    .Add("@ListSectorCD", SqlDbType.NChar, 10, "ListSectorCD")
                    .Add("@ListSector", SqlDbType.NChar, 10, "ListSector")

                    .Add("@CurrencyCD", SqlDbType.NChar, 10, "CurrencyCD")
                    .Add("@ShortName", SqlDbType.NChar, 10, "ShortName")
                    .Add("@FullName", SqlDbType.NChar, 20, "FullName")
                    .Add("@StatusCD", SqlDbType.NChar, 2, "StatusCD")
                    .Add("@ListDate", SqlDbType.Date, 4, "ListDate")

                    .Add("@DelistDate", SqlDbType.Date, 4, "DelistDate")
                    .Add("@EquTypeCD", SqlDbType.NChar, 10, "EquTypeCD")
                    .Add("@EquType", SqlDbType.NChar, 10, "EquType")
                    .Add("@ExCountryCD", SqlDbType.NChar, 10, "ExCountryCD")
                    .Add("@PartyID", SqlDbType.BigInt, 8, "PartyID")

                    .Add("@TotalShares", SqlDbType.BigInt, 8, "TotalShares")
                    .Add("@NonrestFloatShares", SqlDbType.BigInt, 8, "NonrestFloatShares")
                    .Add("@NonrestFloatAShares", SqlDbType.BigInt, 8, "NonrestFloatAShares")
                    .Add("@OfficeAddress", SqlDbType.NVarChar, 100, "OfficeAddress")
                    .Add("@PrimeOperation", SqlDbType.NVarChar, 100, "PrimeOperation")

                    .Add("@EndDate", SqlDbType.Date, 4, "EndDate")
                    .Add("@ShareHolderEquity", SqlDbType.Real, 8, "ShareHolderEquity")
                End With
                adapter.UpdateCommand = Command_Update

                Dim Command_Insert As SqlCommand = New SqlCommand(strCommand, conn)


                strCommand = String.Format("Insert into StockInfo (SecurityID,Symbol,ExchangeCD, ListSectorCD,ListSector,CurrencyCD,ShortName,FullName,StatusCD,ListDate, " & _
                                           " DelistDate, EquTypeCD,EquType,ExCountryCD,PartyID,TotalShares,NonrestFloatShares,NonrestFloatAShares,OfficeAddress,PrimeOperation,EndDate,ShareHolderEquity " & _
                                           "Values(@SecurityID,@Symbol, @ExchangeCD,@ListSectorCD,@CurrencyCD,@ShortName,@FullName,@StatusCD,ListDate, ") & _
                                            " @DelistDate, @EquTypeCD,@EquType,@ExCountryCD,@PartyID,@TotalShares,@NonrestFloatShares,@NonrestFloatAShares,@OfficeAddress,@PrimeOperation,@EndDate,@ShareHolderEquity "

                With Command_Insert.Parameters
                    .Add("@SecurityID", SqlDbType.NChar, 15, "SecurityID")
                    .Add("@Symbol", SqlDbType.NChar, 10, "Symbol")
                    .Add("@ExchangeCD", SqlDbType.NChar, 10, "ExchangeCD")
                    .Add("@ListSectorCD", SqlDbType.NChar, 10, "ListSectorCD")
                    .Add("@ListSector", SqlDbType.NChar, 10, "ListSector")

                    .Add("@CurrencyCD", SqlDbType.NChar, 10, "CurrencyCD")
                    .Add("@ShortName", SqlDbType.NChar, 10, "ShortName")
                    .Add("@FullName", SqlDbType.NChar, 20, "FullName")
                    .Add("@StatusCD", SqlDbType.NChar, 2, "StatusCD")
                    .Add("@ListDate", SqlDbType.Date, 4, "ListDate")

                    .Add("@DelistDate", SqlDbType.Date, 4, "DelistDate")
                    .Add("@EquTypeCD", SqlDbType.NChar, 10, "EquTypeCD")
                    .Add("@EquType", SqlDbType.NChar, 10, "EquType")
                    .Add("@ExCountryCD", SqlDbType.NChar, 10, "ExCountryCD")
                    .Add("@PartyID", SqlDbType.BigInt, 8, "PartyID")

                    .Add("@TotalShares", SqlDbType.BigInt, 8, "TotalShares")
                    .Add("@NonrestFloatShares", SqlDbType.BigInt, 8, "NonrestFloatShares")
                    .Add("@NonrestFloatAShares", SqlDbType.BigInt, 8, "NonrestFloatAShares")
                    .Add("@OfficeAddress", SqlDbType.NVarChar, 100, "OfficeAddress")
                    .Add("@PrimeOperation", SqlDbType.NVarChar, 100, "PrimeOperation")

                    .Add("@EndDate", SqlDbType.Date, 4, "EndDate")
                    .Add("@ShareHolderEquity", SqlDbType.Real, 8, "ShareHolderEquity")
                End With


                adapter.InsertCommand = Command_Insert

                adapter.Update(dt)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Function
    End Class
End Namespace
