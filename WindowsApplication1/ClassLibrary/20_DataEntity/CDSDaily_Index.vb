Namespace DataEntity


    Public Class CDSDaily_Index
        Inherits CDSDaily

        Public Sub New()
            MyBase.New()

            m_SetCategory = "IndexPriceDaily"
            m_dtAllDataTable = New CDTDaily_Stock

            m_dtInfo = New CDTInfo_Index

            'm_dtPrice = New CDTDaily_Index
        End Sub

        ''' <summary>
        ''' 新增一个m_dtPrice
        ''' </summary>
        Public Overrides Function CreateDataTablePriceInstance()
            m_dtPrice = New CDTDaily_Index

        End Function



        ''' <summary>
        ''' 新增一个m_dtPrice
        ''' </summary>
        'Public Overrides Function UpgradeData2SQL()
        '    m_dtPrice = New CDTDaily_Index

        'End Function
        'Public Overrides Function test1()

        ''' <summary>
        ''' 批量更新指数价格数据
        ''' 
        ''' </summary>
        Public Overrides Sub UpgradeData()
            Try

                Dim iCount As UInt16 = 0
                If Not IsNothing(m_dtInfo) Then
                    m_dtInfo.Rows.Clear()
                End If

                m_dtInfo.GetWholeTable()


                Dim iRow As Int16 = 0
                For Each row As DataRow In m_dtInfo.Rows

                    If m_dtPrice.TableName = "IndexPriceDaily" Then  '指数信息 
                        m_dtPrice = New CDTDaily_Index

                        If m_dtPrice.isRecordExistbySymbol(Trim(row.Item("Symbol"))) = True Then

                            m_dtPrice.FeedDataTablePrice(row.Item("Symbol"))

                            If m_dtPrice.Rows.Count > 0 Then
                                m_dtPrice.DeleteDataTablebySymbol(Trim(row.Item("Symbol"))) '更新前，先删除原有记录

                                m_dtPrice.BulkInsertDataTable2SQL()

                            End If


                        End If
                        iRow += 1
                    End If
                Next
            Catch ex As Exception

            End Try

        End Sub

    End Class

End Namespace

