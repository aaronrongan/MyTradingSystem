Namespace DataEntity


    Public Class CDSDaily_Stock
        Inherits CDSDaily

        Public Sub New()
            MyBase.New()

            m_SetCategory = "StockPriceDaily"
            m_dtAllDataTable = New CDTDaily_Stock

            m_dtInfo = New CDTInfo_Stock

            m_dtPrice = New CDTDaily_Stock

        End Sub

        ''' <summary>
        ''' 新增一个m_dtPrice，为什么不能多态实现？
        ''' </summary>
        'Public Overrides Function CreateDataTablePriceInstance() As Object
        '    Return New CDTDaily_Stock

        'End Function

        Public Overrides Function CreateDataTablePriceInstance()
            m_dtPrice = New CDTDaily_Stock
            'Return New CDTDaily_Stock
        End Function
        'Public Overrides Function test1()

        ''' <summary>
        ''' 批量更新价格数据
        ''' 
        ''' </summary>
        Public Overrides Sub UpgradeData()
            Try

                Dim iCount As UInt16 = 0
                If Not IsNothing(m_dtInfo) Then
                    m_dtInfo.Rows.Clear()
                End If

                m_dtInfo.GetWholeTable()
                'Dim bFindStartPos As Boolean = True

                Dim iRow As Int16 = 0
                For Each row As DataRow In m_dtInfo.Rows
                    'Me.CreateDataTablePriceInstance()   '需要释放

                    'If iRow >= 1500 Then
                    'If iRow < 3000 Then
                    If m_dtPrice.TableName = "StockPriceDaily" Then  '股票信息 
                        m_dtPrice = New CDTDaily_Stock

                        'If bFindStartPos Then

                        If m_dtPrice.isRecordExistbySymbol(Trim(row.Item("Symbol"))) = True Then
                            'Dim df As New DataFeed.CDataFeedDatayes_Price

                            'Dim dt As New DataTable
                            'dt = df.FeedStockDailyPriceDataTable(, Trim(row.Item("Symbol")), , )
                            'If Not IsNothing(dt) Then
                            '    m_dtPrice.Rows.Clear()
                            '    m_dtPrice.AdaptDatafromDataTable(dt)

                            '得出TDX的前复权数据 +通联的正常价格数据
                            m_dtPrice.FeedDataTablePrice(row.Item("Symbol"))

                            If m_dtPrice.Rows.Count > 0 Then
                                m_dtPrice.DeleteDataTablebySymbol(Trim(row.Item("Symbol"))) '更新前，先删除原有记录

                                m_dtPrice.BulkInsertDataTable2SQL()

                            End If

                            '抓取前复权数据并合并 (VIP!!!!需要通联的付费)
                            'dt = df.FeedStockDailyPriceDataTablePreAdj(, Trim(row.Item("Symbol")))
                            'm_dtPrice.CombineDataTablePrice_Datayes_Normal_PreAdj(Trim(row.Item("Symbol")), dt)

                            'm_dtPrice.UpgradeData()  'UpdateCommand/InsertCommand方式太慢，4000条要70s，还是用BulkInsert最快
                            'End If
                            'Else
                            '    If Trim(row.Item("Symbol")) = "200002" Then
                            '        bFindStartPos = True
                            '    End If
                            'End If

                            'End If
                            'Else
                            'Exit For
                            'End If
                        End If
                        iRow += 1
                    End If
                    ' m_dtPrice = Nothing
                    '    Dim dt As New DataTable

                    '    If Me.TableName = "StockInfo" Then  '股票信息
                    '        Dim df As New DataFeed.CDataFeedDatayes_StockInfo

                    '        dt = df.FeedEquityInfoDataTable(, , lstenu.Trim)

                    '    ElseIf Me.TableName = "FundInfo" Then  '基金信息
                    '        Dim df As New DataFeed.CDataFeedDatayes_FundInfo
                    '        'dt = df.FeedSecurityInfoDataTable("F", lstenu)
                    '    ElseIf Me.TableName = "BondInfo" Then  '债券信息
                    '        Dim df As New DataFeed.CDataFeedDatayes_BundInfo
                    '        'dt = df.FeedSecurityInfoDataTable("B", lstenu)
                    '    ElseIf Me.TableName = "IndexInfo" Then  '指数信息
                    '        Dim df As New DataFeed.CDataFeedDatayes_IndexInfo
                    '        'dt = df.FeedSecurityInfoDataTable("IDX", lstenu)
                    '    ElseIf Me.TableName = "FutureInfo" Then  '期货信息
                    '        Dim df As New DataFeed.CDataFeedDatayes_FuntureInfo
                    '        'dt = df.FeedSecurityInfoDataTable("FU", lstenu)
                    '    ElseIf Me.TableName = "OptionInfo" Then  '期权信息
                    '        Dim df As New DataFeed.CDataFeedDatayes_OptionInfo
                    '        'dt = df.FeedSecurityInfoDataTable("OP", lstenu)
                    '    End If

                    '    If Not IsNothing(dt) Then
                    '        If dt.Rows.Count > 0 Then

                    '            AdaptDatafromDataTable(dt)  ' 将Datayes的数据转为CDatatable的格式
                    '        End If
                    '    End If
                    '    iCount += 1
                    '    'If iCount > 50 Then
                    '    'Exit For
                    '    'End If
                Next

                'UpgradeData(Me) '一次性导入，而不是像_Simple一样，一次只导入一个
            Catch ex As Exception

            End Try

        End Sub
        'End Function

    End Class

End Namespace
