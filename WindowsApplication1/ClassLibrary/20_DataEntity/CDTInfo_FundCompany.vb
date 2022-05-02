Imports MyTradingSystem.DataBase
Imports MyTradingSystem.DataFeed
Imports System.Data.SqlClient


Namespace DataEntity


    Public Class CDTInfo_FundCompany
        Inherits DataTable

        Protected m_TableName As String = "FundCompany"     '数据表名称

        Protected m_Col0Name As Int32                       'ID，自动增量
        Protected m_Col1Name As String = "FullName"        '基金公司全名
        Protected m_Col2Name As String = "ShortName"       '基金公司简称
        Protected m_Col3Name As String = "FoundDate"       '基金公司成立时间
        Protected m_Col4Name As String = "GeneralManager"  '总经理
        Protected m_Col5Name As String = "Volume"          '资产规模
        Protected m_Col6Name As String = "FundsNumber"     '拥有的基金数目
        Protected m_Col7Name As String = "UpdatedDate"     '情况更新时间
        Protected m_Col8Name As String = "RateHaitong"     '海通评级
        Protected m_Col9Name As String = "Website"         '基金公司网址
        Protected m_Col10Name As String = "EastMoneyID"    '东方财富网编号
        Protected m_Col11Name As String = "THSID"          '同花顺编号
        Protected m_Col12Name As String = "PYAbbre"        '拼音简写

        Private m_strSQLTableName As String
        ''' <summary>
        ''' 包含ID、基金公司名称、东方财富网ID号，供其它类调用
        ''' </summary>
        Private m_dtFundCompanyList1 As DataTable

        ''' <summary>
        ''' 初始化，如属性信息、Datatable创建
        ''' </summary>
        Public Sub New()

            Try
                Dim Col0 As DataColumn = Me.Columns.Add(m_Col0Name, GetType(System.Int32)) '无法转为SQL 的nchar??????
                Col0.AutoIncrement = True
                Col0.AutoIncrementSeed = 1
                Col0.AutoIncrementStep = 1

                Dim Col1 As DataColumn = Me.Columns.Add(m_Col1Name, GetType(System.String)) 'CUtility.SQLDBType2SystemType(SqlDbType.NChar)
                Col1.AllowDBNull = False
                Col1.Unique = True

                Dim Col2 As DataColumn = Me.Columns.Add(m_Col2Name, GetType(System.String)) 'CUtility.SQLDBType2SystemType(SqlDbType.NChar)
                Dim Col3 As DataColumn = Me.Columns.Add(m_Col3Name, GetType(System.DateTime))
                Dim Col4 As DataColumn = Me.Columns.Add(m_Col4Name, GetType(System.String))
                Dim Col5 As DataColumn = Me.Columns.Add(m_Col5Name, GetType(System.Single))
                Dim Col6 As DataColumn = Me.Columns.Add(m_Col6Name, GetType(System.Int32))
                Dim Col7 As DataColumn = Me.Columns.Add(m_Col7Name, GetType(System.DateTime))
                Dim Col8 As DataColumn = Me.Columns.Add(m_Col8Name, GetType(System.String))
                Dim Col9 As DataColumn = Me.Columns.Add(m_Col9Name, GetType(System.String))
                Dim Col10 As DataColumn = Me.Columns.Add(m_Col10Name, GetType(System.String))
                Dim Col11 As DataColumn = Me.Columns.Add(m_Col11Name, GetType(System.String))
                Dim Col12 As DataColumn = Me.Columns.Add(m_Col12Name, GetType(System.String))

                Me.TableName = m_TableName
                m_strSQLTableName = m_TableName

            Catch ex As Exception

            End Try

        End Sub

        ''' <summary>
        ''' 批量插入SQL
        ''' </summary>
        Public Overloads Function BulkInsertDatTable2SQL() As Boolean
            Dim obj1 As New CDBADOCommand(GlobalVariables.gSQLConnectionString)
            Try


                If obj1.BulkInsertDataTable(Me, m_strSQLTableName) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            Finally
                obj1 = Nothing
            End Try

        End Function

        ''' <summary>
        ''' 得到该基金公司的数据网页(东方财富网)
        ''' </summary>
        Public Function GetFundComanyWebPage_EasyMoney(strSymbol As String) As String
            Return "http://fund.eastmoney.com/company/" & strSymbol & ".html"
        End Function

        ''' <summary>
        ''' 更新每个基金公司的数据
        ''' </summary>
        Public Function UpdateFundCompanyInfo2SQL() As Boolean

            Return True

        End Function

        ''' <summary>
        ''' 从数据库得到基金公司的ID、基金名称、东方财富编码
        ''' </summary>
        Public Function GetFundCompanyListfromSQL(ByRef dt As DataTable) As Boolean


            Try
                Dim sda As New CDBADOSQLAdapter("dbo.IFC_GetFundCompanyIDFullNameEasyMoneyIDList", CommandType.StoredProcedure, GlobalVariables.gSQLConnectionString)

                'Dim dt As New DataTable()

                'Dim pas As New SqlParameterCollection, pa As New SqlParameter

                dt = sda.ExecQuery(Me.TableName)

                'MsgBox(dt.Rows.Count)
                Return True

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try


        End Function

        ''' <summary>
        ''' 从数据库得到基金公司的ID、基金名称、东方财富编码
        ''' </summary>
        Public Function GetSymbolNameCodefromSQL(ByRef dt As DataTable) As Boolean


            Try
                Dim sda As New CDBADOSQLAdapter("dbo.IFC_GetFundCompanyIDFullNameEasyMoneyIDList", CommandType.StoredProcedure, GlobalVariables.gSQLConnectionString)

                'Dim dt As New DataTable()

                'Dim pas As New SqlParameterCollection, pa As New SqlParameter

                dt = sda.ExecQuery(Me.TableName)

                'MsgBox(dt.Rows.Count)
                Return True

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try


        End Function

    End Class
End Namespace
