Imports MyTradingSystem.DataBase
Imports System.Data.SqlTypes
Imports MyTradingSystem.DataFeed

Namespace DataEntity

    Public Class CDTInfo
        Inherits System.Data.DataTable


        Protected m_Col0Name As String = "SecurityID"
        Protected m_Col1Name As String = "Symbol"
        Protected m_Col2Name As String = "ShortName"


        Protected m_strSQLTableName As String       '对应的数据表名


        Protected Sub New()

            Try

                'Dim Col1 As DataColumn = Me.Columns.Add(m_Col1Name, GetType(System.String))
                'Dim Col1 As DataColumn = Me.Columns.Add(m_Col1Name, GetType(SqlString)) '无法转为SQL 的nchar??????

                Dim Col0 As DataColumn = Me.Columns.Add(m_Col0Name, GetType(System.String)) '无法转为SQL 的nchar??????
                'Col0.AutoIncrement = True
                'Col0.AutoIncrementSeed = 1
                'Col0.AutoIncrementStep = 1
                Col0.AllowDBNull = False
                Col0.Unique = True

                Dim Col1 As DataColumn = Me.Columns.Add(m_Col1Name, GetType(System.String)) '无法转为SQL 的nchar??????

                Col1.AllowDBNull = False
                Col1.Unique = True

                Dim Col2 As DataColumn = Me.Columns.Add(m_Col2Name, GetType(System.String)) 'CUtility.SQLDBType2SystemType(SqlDbType.NChar)
                Col2.AllowDBNull = False
                Col2.Unique = True

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub



        ''' <summary>
        ''' 能否直接从SQL导出一个DataTable
        ''' </summary>
        ''' <param name="strTableName"></param>
        ''' <param name="bFromSQL"></param>
        ''' <remarks></remarks>
        Protected Sub New(ByVal strTableName As String, ByVal bFromSQL As Boolean)
            'Try
            '    If bFromSQL = False Then ' 新创建一个数据表
            '        Me.TableName = strTableName

            '        Dim Col1 As DataColumn = Me.Columns.Add(m_Col1Name, GetType(System.String))
            '        Col1.AllowDBNull = False
            '        Col1.Unique = True

            '        Dim Col2 As DataColumn = Me.Columns.Add(m_Col2Name, GetType(System.String))
            '        Col2.AllowDBNull = False
            '        Col2.Unique = True

            '    ElseIf bFromSQL = True Then       '从SQL数据库得到现成的数据库结构

            '        Me.TableName = strTableName

            '        Dim objAdapter As New DataBase.CDBADOSQLAdapter(GlobalVariables.gSQLConnectionString)

            '        objAdapter.DataTableName = strTableName

            '        Me = objAdapter.GetCachedDataTablefromSQL() '从数据库得到现成的数据库结构

            '        Me.Clear()      '将该数据库清空，准备放新数据

            '        objAdapter = Nothing

            '    End If
            'Catch ex As Exception
            '    MsgBox(ex.Message)

            'End Try
        End Sub


        ''' <summary>
        ''' 传回整个数据表，父类转子类的引用。要直接将终端对象赋值给最终Fill(dt)，否则将出现CDatatable无法转换为子类的错误
        ''' </summary>
        ''' <param name="strTableName"></param>
        ''' <remarks></remarks>
        Public Sub GetWholeTable(Optional strTableName As String = "") 'As  ' DataTable

            Try
                Dim obj As New CDBADODataTable(GlobalVariables.gSQLConnectionString)
                'Dim dt As New CDTInfo

                If strTableName = "" Then
                    strTableName = Me.TableName
                End If

                'Return (obj.GetDataTable("select * from " & strTableName, CommandType.Text))

                obj.FillDataTable(Me, String.Format("select * from {0} order by Symbol ", strTableName), CommandType.Text)

            Catch ex As Exception
                MsgBox(ex.Message)
                'Return Nothing
            End Try

        End Sub
        ''' <summary>
        ''' 传回数据表，父类转子类的引用。要直接将终端对象赋值给最终Fill(dt)，否则将出现CDatatable无法转换为子类的错误。该表仅有1行，即符合Symbol
        ''' </summary>
        ''' <param name="strTableName"></param>
        ''' <remarks></remar
        Public Sub GetDataTablebySymbol(strTableName As String, ByVal strSymbol As String)

            Try
                Dim obj As New CDBADODataTable(GlobalVariables.gSQLConnectionString)
                'Dim dt As New CDTInfo

                If strTableName = "" Then
                    strTableName = Me.TableName
                End If

                'Return (obj.GetDataTable("select * from " & strTableName, CommandType.Text))

                obj.FillDataTable(Me, String.Format("select * from {0} where Symbol='{1}'", strTableName, strSymbol), CommandType.Text)

            Catch ex As Exception
                MsgBox(ex.Message)
                'Return Nothing
            End Try

        End Sub

        ''' <summary>
        ''' 得到Symbol List
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function GetAllSymbolList(ByRef lstSymbols As List(Of String)) As Integer
            Try
                'Dim strSymbols() As String
                Dim iRow As Integer
                Dim objReader As SqlClient.SqlDataReader
                Dim objData As New DataBase.CDBADODataReader(GlobalVariables.gSQLConnectionString)

                objReader = objData.CreateDataReader("select Symbol from " & Me.TableName)

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

        ''' <summary>
        ''' 调用单行语句返回值，
        ''' </summary>
        ''' <param name="strSymbol"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFullNamebySymbol(strSymbol As String) As String
            Try
                Dim obj As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
                Dim arrParaName(1) As String
                Dim arrParaValue(1) As String
                Dim arrOutparaName(1) As String
                Dim arrOutParaValue(1) As String


                arrParaName(0) = "@" & Me.m_Col1Name
                arrParaValue(0) = strSymbol
                arrOutparaName(0) = "@" & Me.m_Col2Name
                arrOutParaValue(0) = ""

                Dim strEP As String

                If Me.TableName = "StockInfo" Then
                    strEP = "dbo.ISI_GetStockFullNamebySymbol"
                ElseIf Me.TableName = "IndexInfo" Then
                    strEP = "dbo.III_GetIndexFullNamebySymbol"
                ElseIf Me.TableName = "FundInfo" Then
                    strEP = "dbo.IFI_GetFundFullNamebySymbol"
                End If

                'Return obj.ExecSP_Scalar(strEP, arrParaName, arrParaValue, arrOutparaName, arrOutParaValue)  ' Then

                obj.ExecSP_Query(strEP, arrParaName, arrParaValue, arrOutparaName, arrOutParaValue)

                Return arrOutParaValue(0)


                'Else

                'End If

                'Dim strReturn As String = CType(obj.ExecSP_Scalar("dbo.GetStockFullNamebySymbol", arrParaName, arrParaValue, arrOutparaName), String)

            Catch ex As Exception
                MsgBox(ex.Message)
                'Return False
                Return ""
            End Try
        End Function

        ''' <summary>
        ''' 批量插入数据表，必须保证DataTable结构和SQL中的一致，否则会出错
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <remarks></remarks>
        Public Overloads Function BulkInsertDatTable2SQL() As Boolean
            Try
                Dim obj As New CDBADOCommand(GlobalVariables.gSQLConnectionString)

                If obj.BulkInsertDataTable(Me, m_strSQLTableName) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            Finally

            End Try

        End Function


        ''' <summary>
        ''' 获取证券信息，存入SQL。因历史原因，根据现有StockInfo中的Symbol，更新SecID、ShortName、上市日期等信息。而不是根据外部的Symbol List来更新，可能以后加一个重载函数实现
        ''' 算法:'仅对通联数据中的通用信息导入
        '''获取现有SymbolList
        '''对每个Symbol，调用FeedDatayes函数
        ''''填充回SQL。能否用Fill?Update?函数
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpgradeSecurityInfo_Simple() As Boolean
            Try
                Dim lst As New List(Of String)
                GetAllSymbolList(lst)

                For Each lstenu In lst
                    Dim df As New DataFeed.CDataFeedDatayes_General
                    Dim dt As New DataTable

                    If Me.TableName = "StockInfo" Then  '股票信息
                        If lstenu.Trim = "000991" Then
                            MsgBox("000991 is here")
                        End If
                        dt = df.FeedSecurityInfoDataTable(, lstenu)

                    ElseIf Me.TableName = "FundInfo" Then  '基金信息
                        dt = df.FeedSecurityInfoDataTable("F", lstenu)
                    ElseIf Me.TableName = "BondInfo" Then  '债券信息
                        dt = df.FeedSecurityInfoDataTable("B", lstenu)
                    ElseIf Me.TableName = "IndexInfo" Then  '债券信息
                        dt = df.FeedSecurityInfoDataTable("IDX", lstenu)
                    ElseIf Me.TableName = "FutureInfo" Then  '期货信息
                        dt = df.FeedSecurityInfoDataTable("FU", lstenu)
                    ElseIf Me.TableName = "OptionInfo" Then  '期货信息
                        dt = df.FeedSecurityInfoDataTable("OP", lstenu)
                    End If

                    AdaptDatafromDataTable(dt)  ' 将Datayes的数据转为CDatatable的格式

                    UpgradeData(Me)
                Next

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
        'Public MustOverride Function UpgradeData(dt As CDTInfo) As Boolean
        Public Overridable Function UpgradeData(dt As CDTInfo) As Boolean

        End Function

        ''' <summary>
        ''' 将DataFeed获取的数据转换为实际数据格式
        ''' 算法:
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        'Protected MustOverride Function AdaptDatafromDataTable(dt_datayes As DataTable) As Boolean
        Protected Overridable Function AdaptDatafromDataTable(dt_datayes As DataTable) As Boolean

        End Function


        ''' <summary>
        ''' 获取证券信息，存入SQL。因历史原因，根据现有StockInfo中的Symbol，更新SecID、ShortName、上市日期等信息。而不是根据外部的Symbol List来更新，可能以后加一个重载函数实现
        ''' 算法:'对通联数据中的股票详细信息导入
        '''获取现有SymbolList
        '''对每个Symbol，调用FeedDatayes函数
        ''''填充回SQL。能否用Fill?Update?函数
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpgradeSecurityInfo_Full() As Boolean
            Try
                Dim lst As New List(Of String)
                Dim dt_full As New DataTable    '设置一个DataTable将每次获得的DataRow增加到DataTable_Full中，最后一次性导入
                GetAllSymbolList(lst)

                Dim iCount As UInt16 = 0
                For Each lstenu In lst

                    Dim dt As New DataTable

                    If Me.TableName = "StockInfo" Then  '股票信息
                        Dim df As New DataFeed.CDataFeedDatayes_StockInfo

                        dt = df.FeedEquityInfoDataTable(, , lstenu.Trim)

                    ElseIf Me.TableName = "FundInfo" Then  '基金信息
                        Dim df As New DataFeed.CDataFeedDatayes_FundInfo
                        'dt = df.FeedSecurityInfoDataTable("F", lstenu)
                    ElseIf Me.TableName = "BondInfo" Then  '债券信息
                        Dim df As New DataFeed.CDataFeedDatayes_BundInfo
                        'dt = df.FeedSecurityInfoDataTable("B", lstenu)
                    ElseIf Me.TableName = "IndexInfo" Then  '指数信息
                        Dim df As New DataFeed.CDataFeedDatayes_IndexInfo
                        'dt = df.FeedSecurityInfoDataTable("IDX", lstenu)
                    ElseIf Me.TableName = "FutureInfo" Then  '期货信息
                        Dim df As New DataFeed.CDataFeedDatayes_FuntureInfo
                        'dt = df.FeedSecurityInfoDataTable("FU", lstenu)
                    ElseIf Me.TableName = "OptionInfo" Then  '期权信息
                        Dim df As New DataFeed.CDataFeedDatayes_OptionInfo
                        'dt = df.FeedSecurityInfoDataTable("OP", lstenu)
                    End If

                    If Not IsNothing(dt) Then
                        If dt.Rows.Count > 0 Then

                            AdaptDatafromDataTable(dt)  ' 将Datayes的数据转为CDatatable的格式
                        End If
                    End If
                    iCount += 1
                    'If iCount > 50 Then
                    'Exit For
                    'End If
                Next

                UpgradeData(Me) '一次性导入，而不是像_Simple一样，一次只导入一个

            Catch ex As Exception
                Return False

            End Try

        End Function

        ''' <summary>
        ''' 传回整个数据表，父类转子类的引用。要直接将终端对象赋值给最终Fill(dt)，否则将出现CDatatable无法转换为子类的错误
        ''' </summary>
        ''' <param name="strTableName"></param>
        ''' <remarks></remarks>
        Public Function GetSymbolList(Optional strTableName As String = "") As List(Of String) 'As  ' DataTable

            Try
                Dim symbollist As New List(Of String)
                Dim paravalue As New Hashtable

                Dim obj As New CDBSqlServerWrapper(GlobalVariables.gSQLConnectionString)

                If strTableName = "" Then
                    strTableName = Me.TableName
                End If

                Dim rd As System.Data.SqlClient.SqlDataReader

                If Me.TableName = "StockInfo" Then
                    rd = obj.ExecSpReturnDataReader("ISI_GetSymbolList", paravalue)
                End If


                Do While rd.Read()
                    symbollist.Add(Trim(rd.GetString(0)))
                Loop
                Return symbollist
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try

        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="strSymbol"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetShortNamebySymbol(ByVal SymbolType As String, ByVal strSymbol As String) As String
            Try
                Dim obj As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
                Dim arrParaName(1) As String
                Dim arrParaValue(1) As String
                Dim arrOutparaName(1) As String
                Dim arrOutParaValue(1) As String


                arrParaName(0) = "@Symbol"
                arrParaValue(0) = strSymbol
                arrOutparaName(0) = "@ShortName"
                arrOutParaValue(0) = ""

                Dim strEP As String

                If SymbolType = "Stock" Then
                    strEP = "dbo.ISI_GetStockShortNamebySymbol"
                ElseIf SymbolType = "Index" Then
                    strEP = "dbo.III_GetIndexShortNamebySymbol"
                ElseIf SymbolType = "Fund" Then
                    strEP = "dbo.IFI_GetFundShortNamebySymbol"
                End If

                'Return obj.ExecSP_Scalar(strEP, arrParaName, arrParaValue, arrOutparaName, arrOutParaValue)  ' Then

                obj.ExecSP_Query(strEP, arrParaName, arrParaValue, arrOutparaName, arrOutParaValue)

                Return arrOutParaValue(0)


                'Else

                'End If

                'Dim strReturn As String = CType(obj.ExecSP_Scalar("dbo.GetStockFullNamebySymbol", arrParaName, arrParaValue, arrOutparaName), String)

            Catch ex As Exception
                MsgBox(ex.Message)
                'Return False
                Return ""
            End Try
        End Function

    End Class

End Namespace
