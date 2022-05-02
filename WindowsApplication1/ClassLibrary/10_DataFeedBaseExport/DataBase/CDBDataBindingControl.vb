Imports System.Data.SqlTypes

Namespace DataBase
    Public Class CDBDataBindingControl
        '用指定表的指定列的值填充ComboBox控件
        Public Shared Sub BindComboBox(ByRef combo As ComboBox, ByVal tableName As String, _
                                        ByVal column As String, ByVal connStr As String, _
                                        Optional ByVal field As String = "", _
                                        Optional ByVal op As String = "", _
                                        Optional ByVal value As String = "")
            '创建CDBADODataTable对象
            Dim dt As CDBADODataTable = New CDBADODataTable(connStr)
            '设置SQL语句
            Dim SQLStr As String = "Select " & column & " from " & tableName
            '如果指定了查询条件，则把查询条件追加到SQL语句
            If Not field = "" Then
                SQLStr += " Where " & field & op & value
            End If
            '调用CDBADODataTable的CreateDataTable函数，得到DataTable表
            Dim table As DataTable = dt.CreateDataTable(SQLStr, tableName)

            '指定ComboBox显示DataTable的哪一列
            combo.DisplayMember = column
            '指定DataTable为ComboBox的数据源
            combo.DataSource = table
        End Sub
        '生成指定表的Index字段的值，显示在TextBox上
        Public Shared Sub FillIndexTextBox(ByRef txt As TextBox, ByVal tableName As String, ByVal Column As String, _
                                        ByVal connStr As String)
            '创建CDBADODataTable对象
            Dim dt As CDBADODataTable = New CDBADODataTable(connStr)
            '设置SQL语句
            Dim SQLStr As String = "Select TOP 1 * from " & tableName & "  ORDER BY " & Column & " DESC"
            '调用CDBADODataTable的CreateDataTable函数，得到DataTable表
            Dim table As DataTable = dt.CreateDataTable(SQLStr, tableName)
            '把最大的Index的值加一后在TextBox上显示出来
            txt.Text = CType(Integer.Parse(table.Rows(0).Item(Column)) + 1, String)

        End Sub

        '显示根据指定表的指定列的值，包含该值的记录由条件子句决定
        Public Shared Sub FillTextBox(ByRef txt As TextBox, ByVal tableName As String, ByVal Column As String, _
                                        ByVal connStr As String, ByVal field As String, ByVal value As String)
            '创建CDBADODataTable对象
            Dim dt As CDBADODataTable = New CDBADODataTable(connStr)
            '设置SQL语句
            Dim SQLStr As String = "Select " & Column & " from " & tableName & " WHERE " & field & "=" & value
            '调用CDBADODataTable的CreateDataTable函数，得到DataTable表
            Dim table As DataTable = dt.CreateDataTable(SQLStr, tableName)
            '显示查询得到的首行（一般也只有一行）指定列的值
            txt.Text = table.Rows(0).Item(Column).ToString().Trim()
        End Sub

        '根据指定的查询条件得到一条查询记录，设置ComboBox被选中项为该条记录某列的值
        Public Shared Sub SetComboSelectedIndex(ByRef combo As ComboBox, ByVal tableName As String, ByVal Column As String, _
                                        ByVal connStr As String, ByVal field As String, ByVal value As String)
            '创建CDBADODataTable对象
            Dim dt As CDBADODataTable = New CDBADODataTable(connStr)
            '设置SQL语句
            Dim SQLStr As String = "Select " & Column & " from " & tableName & " WHERE " & field & "=" & value
            '调用CDBADODataTable的CreateDataTable函数，得到DataTable表
            Dim table As DataTable = dt.CreateDataTable(SQLStr, tableName)
            '得到指定字段在ComboBox中的序号
            Dim nIndex = combo.FindStringExact(table.Rows(0).Item(Column))
            '设置ComboBox被选中的项
            combo.SelectedIndex = nIndex
        End Sub
        '根据指定表和指定查询条件填充ListView
        Public Shared Sub FillListView(ByRef lsv As ListView, ByVal tableName As String, ByVal num As Integer, _
                                        ByVal connStr As String, Optional ByVal field As String = "", _
                                        Optional ByVal op As String = "=", Optional ByVal value As String = "")
            '清空ListView
            lsv.Items.Clear()
            '设置SQL语句
            Dim SQLString As String = "SELECT * FROM " & tableName
            '如果指定了查询条件，则把查询条件追加到SQL语句
            If field <> "" Then
                SQLString += " Where " & field & op & value
            End If
            '创建CDBADODataTable对象
            Dim dt As CDBADODataTable = New CDBADODataTable(connStr)
            '调用CDBADODataTable的CreateDataTable函数，得到DataTable表
            Dim table As DataTable = dt.CreateDataTable(SQLString, tableName)
            '在循环中遍历DataTable表，逐行逐列把表中的内容加入到ListView控件中
            Dim UserRow As DataRow
            Dim LItem As ListViewItem
            '遍历每一行
            For Each UserRow In table.Rows
                LItem = New ListViewItem(UserRow(0).ToString.Trim())
                Dim i As Integer
                '遍历一行中的所有列
                For i = 1 To num - 1
                    LItem.SubItems.Add(UserRow(i).ToString().Trim())
                Next
                lsv.Items.Add(LItem)
            Next
        End Sub
        '根据指定表和指定查询条件填充ListBox
        Public Shared Sub FillListBox(ByRef lsb As ListBox, ByVal tableName As String, ByVal column As String, _
                                        ByVal connStr As String, Optional ByVal field As String = "", _
                                        Optional ByVal op As String = "=", Optional ByVal value As String = "")
            '清空ListBox
            lsb.Items.Clear()
            '设置SQL语句
            Dim SQLString As String = "SELECT * FROM " & tableName
            '如果指定了查询条件，则把查询条件追加到SQL语句
            If field <> "" Then
                SQLString += " Where " & field & op & value
            End If
            '创建CDBADODataTable对象
            Dim dt As CDBADODataTable = New CDBADODataTable(connStr)
            '调用CDBADODataTable的CreateDataTable函数，得到DataTable表
            Dim table As DataTable = dt.CreateDataTable(SQLString, tableName)

            '在循环中遍历DataTable表，逐行逐列把表中的内容加入到ListView控件中
            Dim UserRow As DataRow
            '遍历每一行
            For Each UserRow In table.Rows
                lsb.Items.Add(UserRow(column))
            Next
        End Sub

        ''' <summary>
        ''' 将数据DataTable绑定到DataGridView控件
        ''' </summary>
        Public Shared Sub BindDataGridView(ByRef dgv As DataGridView, ByVal oDT As DataTable, ByVal bFirstColumnAddded As Boolean)

            Try

                Dim iRow, iCol, iTotalRow, iTotalCol As Integer
                Dim strRowString() As String ' SqlString


                iTotalRow = oDT.Rows.Count
                iTotalCol = oDT.Columns.Count
                ReDim strRowString(iTotalCol)

                With dgv
                    If bFirstColumnAddded Then
                        .ColumnCount = oDT.Columns.Count + 1
                        .Columns(0).Name = "ID"
                        For iCol = 0 To iTotalCol - 1
                            .Columns(iCol + 1).Name = oDT.Columns(iCol).ColumnName
                        Next
                    Else
                        .ColumnCount = oDT.Columns.Count
                        For iCol = 0 To iTotalCol - 1
                            .Columns(iCol).Name = oDT.Columns(iCol).ColumnName
                        Next
                    End If
                    With .Rows
                        For iRow = 0 To iTotalRow - 1
                            If bFirstColumnAddded Then
                                strRowString(0) = iRow + 1
                                For iCol = 1 To iTotalCol
                                    'If Not DBNull.Value.Equals(oDT.Rows(iRow).Item(iCol - 1)) Then
                                    If oDT.Rows(iRow).Item(iCol - 1) IsNot Nothing Then
                                        strRowString(iCol) = oDT.Rows(iRow).Item(iCol - 1)
                                    Else
                                        strRowString(iCol) = ""
                                    End If
                                Next
                                .Add(strRowString)
                            Else
                                For iCol = 0 To iTotalCol - 1
                                    If Not IsDBNull(oDT.Rows(iRow).Item(iCol)) Then
                                        'strRowString(iCol) = DirectCast(oDT.Rows(iRow).Item(iCol).ToString, String)
                                        strRowString(iCol) = oDT.Rows(iRow).Item(iCol)
                                    Else
                                        strRowString(iCol) = ""
                                    End If
                                Next
                                .Add(strRowString)
                            End If
                        Next
                    End With
                End With

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End Sub
    End Class
End Namespace
