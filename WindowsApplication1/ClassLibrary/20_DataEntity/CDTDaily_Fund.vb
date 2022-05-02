Imports MyTradingSystem.DataBase
Imports MyTradingSystem.DataFeed

Namespace DataEntity


    Public Class CDTDaily_Fund
        Inherits CDTDaily

        Public Event InsertProgress(ByVal iProgress As Integer)

        Protected m_Col21Name As String = "NetValue"
        Protected m_Col22Name As String = "AccuNetValue"




        Public Sub New()
            MyBase.New()

            Me.Columns.Add(m_Col21Name, GetType(System.Single))
            Me.Columns.Add(m_Col22Name, GetType(System.Single))

            Me.Columns.Add("preClosePrice", GetType(System.Single))
            Me.Columns.Add("CHG", GetType(System.Single))
            Me.Columns.Add("CHGPct", GetType(System.Single))

            m_strSQLTableName = "FundPriceDaily"
            Me.TableName = m_strSQLTableName
        End Sub

        ''' <summary>
        ''' 从TDX、MatlabFaruto、通联中抓取对应数据，基金无法从TDX中获取，而是从Matlab中获取
        ''' </summary>
        ''' <param name="stSymbol"></param>
        ''' <param name="pat"></param>
        ''' <param name="dtStartDate"></param>
        ''' <param name="dtEndDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>

        Public Overrides Function FeedDataTablePrice(strSymbol As String, Optional ByVal pat As EPriceAdjustedType = EPriceAdjustedType.ForAdj, Optional ByVal dtStartDate As String = "", Optional ByVal dtEndDate As String = "") As Int32

            Dim dfFM As New CDataFeedMatlabFaruto

            Try

                dfFM.FeedFundNetValue(Me, strSymbol, dtStartDate, dtEndDate)

                Return Me.Rows.Count
            Catch ex As Exception
                Return 0
            End Try

        End Function


        Public Overrides Function GetOpenPrice(index As Short) As Double
            Return Me.Rows(index).Item("OpenPrice")
        End Function

        Public Overrides Function GetHighPrice(index As Short) As Double
            Return Me.Rows(index).Item("HighPrice")
        End Function

        Public Overrides Function GetLowPrice(index As Short) As Double
            Return Me.Rows(index).Item("LowPrice")
        End Function

        Public Overrides Function GetClosePrice(index As Short) As Double
            Return Me.Rows(index).Item("ClosePrice")
        End Function

        Public Overrides Function GetVolume(index As Short) As Double
            Return Me.Rows(index).Item("TurnoverVolume")
        End Function

        Public Overrides Function GetTurnoverValue(index As Short) As Double
            Return Me.Rows(index).Item("TurnoverValue")
        End Function
        ''' <summary>
        ''' 根据Symbol、日期值从SQL数据库得出一个数据库现有的表，用多态实现，这样可以对子类进行代码复用
        ''' 这里的子类需要重写，因为数据库的字段和DTFund不一样，要重新映射
        ''' </summary>
        Public Overrides Function GetDataTablePrice(strSymbol As String, strBeginDate As String, strEndDate As String) As Boolean

            Try
                'Dim dt As New CDTDaily

                Dim objSA As New CDBADOSQLAdapter(GlobalVariables.gSQLConnectionString, Me.TableName)

                '取数据前先把之前的数据清空
                Me.Rows.Clear()

                Dim dt_sql As New DataTable

                objSA.GetDataTablebySymbolDatesfromSQL(strSymbol, strBeginDate, strEndDate, dt_sql)

                ReMapDataColumns(dt_sql)


                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False


            End Try

        End Function
        Private Sub ReMapDataColumns(dt_sql As DataTable)
            Try

                For Each row As DataRow In dt_sql.Rows
                    Dim merow As DataRow = Me.NewRow

                    merow.Item("SecurityID") = row.Item("fundID")
                    merow.Item("Symbol") = row.Item("Symbol")
                    merow.Item("TheDate") = row.Item("TheDate")

                    merow.Item("preClosePrice") = row.Item("preClosePrice")

                    merow.Item("OpenPrice") = row.Item("OpenPrice")
                    merow.Item("HighPrice") = row.Item("HighPrice")
                    merow.Item("LowPrice") = row.Item("LowPrice")
                    merow.Item("ClosePrice") = row.Item("ClosePrice")
                    merow.Item("TurnoverVolume") = row.Item("TurnoverVolume")
                    merow.Item("TurnoverValue") = row.Item("TurnoverValue")
                    merow.Item("CHG") = row.Item("CHG")
                    merow.Item("CHGPct") = row.Item("CHGPct")



                    Me.Rows.Add(merow)
                Next


            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End Sub

    End Class

   
End Namespace
