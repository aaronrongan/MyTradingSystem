Imports System.Data.SqlTypes

Namespace DataBase
    Public Class CDBDataBindingControl
        '��ָ�����ָ���е�ֵ���ComboBox�ؼ�
        Public Shared Sub BindComboBox(ByRef combo As ComboBox, ByVal tableName As String, _
                                        ByVal column As String, ByVal connStr As String, _
                                        Optional ByVal field As String = "", _
                                        Optional ByVal op As String = "", _
                                        Optional ByVal value As String = "")
            '����CDBADODataTable����
            Dim dt As CDBADODataTable = New CDBADODataTable(connStr)
            '����SQL���
            Dim SQLStr As String = "Select " & column & " from " & tableName
            '���ָ���˲�ѯ��������Ѳ�ѯ����׷�ӵ�SQL���
            If Not field = "" Then
                SQLStr += " Where " & field & op & value
            End If
            '����CDBADODataTable��CreateDataTable�������õ�DataTable��
            Dim table As DataTable = dt.CreateDataTable(SQLStr, tableName)

            'ָ��ComboBox��ʾDataTable����һ��
            combo.DisplayMember = column
            'ָ��DataTableΪComboBox������Դ
            combo.DataSource = table
        End Sub
        '����ָ�����Index�ֶε�ֵ����ʾ��TextBox��
        Public Shared Sub FillIndexTextBox(ByRef txt As TextBox, ByVal tableName As String, ByVal Column As String, _
                                        ByVal connStr As String)
            '����CDBADODataTable����
            Dim dt As CDBADODataTable = New CDBADODataTable(connStr)
            '����SQL���
            Dim SQLStr As String = "Select TOP 1 * from " & tableName & "  ORDER BY " & Column & " DESC"
            '����CDBADODataTable��CreateDataTable�������õ�DataTable��
            Dim table As DataTable = dt.CreateDataTable(SQLStr, tableName)
            '������Index��ֵ��һ����TextBox����ʾ����
            txt.Text = CType(Integer.Parse(table.Rows(0).Item(Column)) + 1, String)

        End Sub

        '��ʾ����ָ�����ָ���е�ֵ��������ֵ�ļ�¼�������Ӿ����
        Public Shared Sub FillTextBox(ByRef txt As TextBox, ByVal tableName As String, ByVal Column As String, _
                                        ByVal connStr As String, ByVal field As String, ByVal value As String)
            '����CDBADODataTable����
            Dim dt As CDBADODataTable = New CDBADODataTable(connStr)
            '����SQL���
            Dim SQLStr As String = "Select " & Column & " from " & tableName & " WHERE " & field & "=" & value
            '����CDBADODataTable��CreateDataTable�������õ�DataTable��
            Dim table As DataTable = dt.CreateDataTable(SQLStr, tableName)
            '��ʾ��ѯ�õ������У�һ��Ҳֻ��һ�У�ָ���е�ֵ
            txt.Text = table.Rows(0).Item(Column).ToString().Trim()
        End Sub

        '����ָ���Ĳ�ѯ�����õ�һ����ѯ��¼������ComboBox��ѡ����Ϊ������¼ĳ�е�ֵ
        Public Shared Sub SetComboSelectedIndex(ByRef combo As ComboBox, ByVal tableName As String, ByVal Column As String, _
                                        ByVal connStr As String, ByVal field As String, ByVal value As String)
            '����CDBADODataTable����
            Dim dt As CDBADODataTable = New CDBADODataTable(connStr)
            '����SQL���
            Dim SQLStr As String = "Select " & Column & " from " & tableName & " WHERE " & field & "=" & value
            '����CDBADODataTable��CreateDataTable�������õ�DataTable��
            Dim table As DataTable = dt.CreateDataTable(SQLStr, tableName)
            '�õ�ָ���ֶ���ComboBox�е����
            Dim nIndex = combo.FindStringExact(table.Rows(0).Item(Column))
            '����ComboBox��ѡ�е���
            combo.SelectedIndex = nIndex
        End Sub
        '����ָ�����ָ����ѯ�������ListView
        Public Shared Sub FillListView(ByRef lsv As ListView, ByVal tableName As String, ByVal num As Integer, _
                                        ByVal connStr As String, Optional ByVal field As String = "", _
                                        Optional ByVal op As String = "=", Optional ByVal value As String = "")
            '���ListView
            lsv.Items.Clear()
            '����SQL���
            Dim SQLString As String = "SELECT * FROM " & tableName
            '���ָ���˲�ѯ��������Ѳ�ѯ����׷�ӵ�SQL���
            If field <> "" Then
                SQLString += " Where " & field & op & value
            End If
            '����CDBADODataTable����
            Dim dt As CDBADODataTable = New CDBADODataTable(connStr)
            '����CDBADODataTable��CreateDataTable�������õ�DataTable��
            Dim table As DataTable = dt.CreateDataTable(SQLString, tableName)
            '��ѭ���б���DataTable���������аѱ��е����ݼ��뵽ListView�ؼ���
            Dim UserRow As DataRow
            Dim LItem As ListViewItem
            '����ÿһ��
            For Each UserRow In table.Rows
                LItem = New ListViewItem(UserRow(0).ToString.Trim())
                Dim i As Integer
                '����һ���е�������
                For i = 1 To num - 1
                    LItem.SubItems.Add(UserRow(i).ToString().Trim())
                Next
                lsv.Items.Add(LItem)
            Next
        End Sub
        '����ָ�����ָ����ѯ�������ListBox
        Public Shared Sub FillListBox(ByRef lsb As ListBox, ByVal tableName As String, ByVal column As String, _
                                        ByVal connStr As String, Optional ByVal field As String = "", _
                                        Optional ByVal op As String = "=", Optional ByVal value As String = "")
            '���ListBox
            lsb.Items.Clear()
            '����SQL���
            Dim SQLString As String = "SELECT * FROM " & tableName
            '���ָ���˲�ѯ��������Ѳ�ѯ����׷�ӵ�SQL���
            If field <> "" Then
                SQLString += " Where " & field & op & value
            End If
            '����CDBADODataTable����
            Dim dt As CDBADODataTable = New CDBADODataTable(connStr)
            '����CDBADODataTable��CreateDataTable�������õ�DataTable��
            Dim table As DataTable = dt.CreateDataTable(SQLString, tableName)

            '��ѭ���б���DataTable���������аѱ��е����ݼ��뵽ListView�ؼ���
            Dim UserRow As DataRow
            '����ÿһ��
            For Each UserRow In table.Rows
                lsb.Items.Add(UserRow(column))
            Next
        End Sub

        ''' <summary>
        ''' ������DataTable�󶨵�DataGridView�ؼ�
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
