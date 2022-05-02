Public Class CDTDaily_Stock_Collection
    'Option Explicit
    'Inherits System.Data.DataSet
    'Inherits CollectionBase

    Private m_colPriceData As Collection
    Private m_bDateNormalOrder As Boolean   '日期是否升序

    Public Property PriceData() As Collection
        Get
            PriceData = m_colPriceData
        End Get

        Set(colPriceData As Collection)
            m_colPriceData = colPriceData
        End Set
    End Property

    Public Sub New()
        m_colPriceData = New Collection

        m_bDateNormalOrder = False
        'Me.Tables()

    End Sub

    'Public Sub finalize()
    '    'm_colPriceData = Nothing
    'End Sub


    '将日期转置
    Public Sub TransposeDateOrder(bNormalOrder As Boolean)

        Dim iCount As Integer
        iCount = m_colPriceData.Count

        Dim PriceData1 As New CDataPrice_Stock
        Dim PriceData2 As New CDataPrice_Stock
        Dim colNewPriceTable As New Collection

        If iCount = 0 Then
            MsgBox("内部无记录。无需转置。")
        ElseIf iCount = 1 Then
            MsgBox("内部仅1条记录。无需转置。")
        ElseIf iCount > 1 Then
            PriceData1 = m_colPriceData.Item(1)
            PriceData2 = m_colPriceData.Item(2)
            If PriceData1.ThisDate > PriceData2.ThisDate Then '如果现为降序
                If bNormalOrder = False Then
                    'MsgBox("日期已为升序，无需转置")
                Else
                    '转置
                    Transpose(m_colPriceData, colNewPriceTable)
                    m_bDateNormalOrder = bNormalOrder
                End If
            Else '如果现为降序
                If bNormalOrder = True Then
                    'MsgBox("日期已为降序，无需转置")
                Else
                    '转置
                    Transpose(m_colPriceData, colNewPriceTable)
                    m_bDateNormalOrder = bNormalOrder
                End If
            End If
            '进行转置

        End If

        PriceData1 = Nothing
        PriceData2 = Nothing
        colNewPriceTable = Nothing
    End Sub

    '对2个集合进行头尾转置
    Private Sub Transpose(colPriceData1 As Collection, colPriceData2 As Collection)
        Dim i As Integer, j As Integer

        i = colPriceData1.Count

        For j = 1 To i
            colPriceData2.Add(colPriceData1.Item(i - j + 1))
        Next

        colPriceData1 = colPriceData2
    End Sub

    '对现有价格数据进行条件选择，如某段日期内，或指定次数
    '规则：
    '3个变量：起始日期、最终日期、次数。算法见设计规格书。该函数不改变当前对象，而是求一个新PriceDataTable

    Public Function GetNewFilterDataTablebyDate(Optional sStartDate As String = "", Optional sEndDate As String = "", Optional iTotalNumber As Integer = 0) As CDTDaily_Stock_Collection

        Dim oPriceDataTable As New CDTDaily_Stock_Collection


        Dim sDBStartDate As String  '数据库起始日期
        Dim sDBEndDate As String  '数据库终止日期

        '判断iTotalNumber、Date的输入有效性
        If JudgeDateNumberValid(sStartDate, sEndDate, iTotalNumber) = False Then
            MsgBox("输入日期或次数有误，请重新输入！")
            Exit Function
        End If


        '判断是否有数据
        If m_colPriceData.Count = 0 Then
            MsgBox("价格数据表为空！")
            Return Nothing
            Exit Function
        End If

        '判断转置矩阵
        If m_bDateNormalOrder = False Then
            TransposeDateOrder(True)
        End If


        '数据库实际起始和终止日期
        sDBStartDate = m_colPriceData.Item(1).ThisDate
        sDBEndDate = m_colPriceData.Item(m_colPriceData.Count).ThisDate

        '进行筛选=================

        Dim iSelectionType As Integer

        If sStartDate = "" And sEndDate = "" And iTotalNumber = 0 Then
            iSelectionType = 1
        ElseIf sStartDate <> "" And sEndDate = "" And iTotalNumber = 0 Then
            iSelectionType = 2
        ElseIf sStartDate = "" And sEndDate <> "" And iTotalNumber = 0 Then
            iSelectionType = 3
        ElseIf sStartDate = "" And sEndDate = "" And iTotalNumber > 0 Then
            iSelectionType = 4
        ElseIf sStartDate <> "" And sEndDate <> "" And iTotalNumber = 0 Then
            iSelectionType = 5
        ElseIf sStartDate = "" And sEndDate <> "" And iTotalNumber <> 0 Then
            iSelectionType = 6
        ElseIf sStartDate <> "" And sEndDate = "" And iTotalNumber <> 0 Then
            iSelectionType = 7
        ElseIf sStartDate <> "" And sEndDate <> "" And iTotalNumber <> 0 Then
            iSelectionType = 8
        End If


        '做矩阵判断，分别求出各种状况的起始日期和终止日期
        Select Case iSelectionType
            Case 1
                oPriceDataTable = Me
                '    Case 2:
                '        sEndDate = sDBEndDate
                '        FilterDataTablebyStartDate_EndDate2 sStartDate, sEndDate, oPriceDataTable
                '    Case 3:
                '        sStartDate = sDBStartDate
                '        FilterDataTablebyStartDate_EndDate2 sStartDate, sEndDate, oPriceDataTable
                '    Case 4:
                '        sStartDate = sDBStartDate
                '        FilterDataTablebyStartDate_Number sStartDate, iTotalNumber, oPriceDataTable
                '    Case 5:
                '        FilterDataTablebyStartDate_EndDate2 sStartDate, sEndDate, oPriceDataTable
                '    Case 6:
                '        FilterDataTablebyEndDate_Number sEndDate, iTotalNumber, oPriceDataTable
                '    Case 7, 8:
                '        FilterDataTablebyStartDate_Number sStartDate, iTotalNumber, oPriceDataTable

            Case 2
                sEndDate = sDBEndDate
            Case 3
                sStartDate = sDBStartDate
            Case 4
                sStartDate = sDBStartDate
                LookupEndDate(sStartDate, sEndDate, iTotalNumber)
            Case 5
            Case 6
                'sStartDate = LookupStartDate(sEndDate, iTotalNumber)
                LookupStartDate(sStartDate, sEndDate, iTotalNumber)
            Case 7, 8
                'sEndDate = LookupEndDate(sStartDate, iTotalNumber)
                LookupEndDate(sStartDate, sEndDate, iTotalNumber)
        End Select


        FilterDataTablebyStartDate_EndDate2(sStartDate, sEndDate, oPriceDataTable)
        '======================================

        GetNewFilterDataTablebyDate = oPriceDataTable

        oPriceDataTable = Nothing

    End Function

    '对现有价格数据进行条件选择，如某段日期内，或指定次数
    '规则：
    '3个变量：起始日期、最终日期、次数。算法见设计规格书

    '与GetFilterDataTablebyDate2区别在于该函数修改整个当前对象，而不是返回一个新对象。这个函数应该更合理些

    Public Function FilterDataTablebyDate(Optional ByRef sStartDate As String = "", Optional ByRef sEndDate As String = "", Optional iTotalNumber As Integer = 0) As Boolean

        Dim colNewPriceData As New Collection

        Dim sDBStartDate As String  '数据库起始日期
        Dim sDBEndDate As String  '数据库终止日期

        If JudgeDateNumberValid(sStartDate, sEndDate, iTotalNumber) = False Then
            Return False
            Exit Function
        End If

        '判断iTotalNumber、Date的输入有效性
        If iTotalNumber < 0 Then
            MsgBox("数目不能为空！")
            Return False
            Exit Function
        End If

        '判断是否有数据
        If m_colPriceData.Count = 0 Then
            MsgBox("价格数据表为空！")
            Return False
            Exit Function
        End If

        '判断转置矩阵
        If m_bDateNormalOrder = False Then
            TransposeDateOrder(True)
        End If


        '数据库实际起始和终止日期
        sDBStartDate = m_colPriceData.Item(1).ThisDate
        sDBEndDate = m_colPriceData.Item(m_colPriceData.Count).ThisDate

        '进行筛选=================

        Dim iSelectionType As Integer

        If sStartDate = "" And sEndDate = "" And iTotalNumber = 0 Then
            iSelectionType = 1
        ElseIf sStartDate <> "" And sEndDate = "" And iTotalNumber = 0 Then
            iSelectionType = 2
        ElseIf sStartDate = "" And sEndDate <> "" And iTotalNumber = 0 Then
            iSelectionType = 3
        ElseIf sStartDate = "" And sEndDate = "" And iTotalNumber > 0 Then
            iSelectionType = 4
        ElseIf sStartDate <> "" And sEndDate <> "" And iTotalNumber = 0 Then
            iSelectionType = 5
        ElseIf sStartDate = "" And sEndDate <> "" And iTotalNumber <> 0 Then
            iSelectionType = 6
        ElseIf sStartDate <> "" And sEndDate = "" And iTotalNumber <> 0 Then
            iSelectionType = 7
        ElseIf sStartDate <> "" And sEndDate <> "" And iTotalNumber <> 0 Then
            iSelectionType = 8
        End If


        '做矩阵判断，分别求出各种状况的起始日期和终止日期
        Select Case iSelectionType
            Case 1
                'Set oPriceDataTable = Me
                sStartDate = sDBStartDate
                sEndDate = sDBEndDate
            Case 2
                sEndDate = sDBEndDate
                'FilterDataTablebyStartDate_EndDate sStartDate, sEndDate, oPriceDataTable
            Case 3
                sStartDate = sDBStartDate
                'FilterDataTablebyStartDate_EndDate sStartDate, sEndDate, oPriceDataTable
            Case 4
                sStartDate = sDBStartDate
                'sEndDate = LookupEndDate(sStartDate, iTotalNumber)
                LookupEndDate(sStartDate, sEndDate, iTotalNumber)
                'FilterDataTablebyStartDate_Number sStartDate, iTotalNumber, oPriceDataTable
            Case 5
                'FilterDataTablebyStartDate_EndDate sStartDate, sEndDate, oPriceDataTable
            Case 6
                'sStartDate = LookupStartDate(sEndDate, iTotalNumber)
                LookupStartDate(sStartDate, sEndDate, iTotalNumber)
                'FilterDataTablebyEndDate_Number sEndDate, iTotalNumber, oPriceDataTable
            Case 7, 8
                'sEndDate = LookupEndDate(sStartDate, sEndDate, iTotalNumber)
                LookupEndDate(sStartDate, sEndDate, iTotalNumber)
                'FilterDataTablebyStartDate_Number sStartDate, iTotalNumber, oPriceDataTable
        End Select


        FilterDataTablebyStartDate_EndDate(sStartDate, sEndDate)
        '======================================
        Return True
        'colNewPriceData = Nothing

    End Function

    '===============OBSELETE==================
    '根据起始日期和次数筛选需要日期数据
    Private Function FilterDataTablebyStartDate_Number(sStartDate As String, iTotalNumber As Integer, oPriceDataTable As CDTDaily_Stock_Collection)
        '    Dim i As Integer, j As Integer
        '
        '    'Dim oPDT As New CDataPriceTable
        '    Dim strNewDate As String
        '
        '    If CheckDateExist(sStartDate, strNewDate) = False Then
        '        MsgBox "起始日期不存在，换用最近的一个日期" & strNewDate
        '        sStartDate = strNewDate
        '    End If
        '
        '    Dim bStart As Boolean
        '
        '    bStart = False
        '
        '    j = 0
        '
        '    'j移动到需要的开始日期
        '    While bStart = False
        '        j = j + 1
        '        'Debug.Print Me.PriceData.Item(j).ThisDate
        '        If CDate(Me.PriceData.Item(j).ThisDate) = CDate(sStartDate) Then
        '            bStart = True
        '        End If
        '    Wend
        '
        '    For i = j To j + iTotalNumber - 1
        '        oPriceDataTable.PriceData.Add Me.PriceData.Item(i)
        '    Next
        '

    End Function

    '根据起始日期和终止日期筛选需要日期数据。本函数采用内部变量m_colPriceData，更合理
    Private Sub FilterDataTablebyStartDate_EndDate(sStartDate As String, sEndDate As String)
        Dim i As Integer, j As Integer

        Dim strNewDate As String = ""

        Dim m_colNewPriceData As New Collection

        If CheckDateExist(sStartDate, strNewDate) = False Then
            MsgBox("起始日期不存在，换用最近的一个日期" & strNewDate)
            sStartDate = strNewDate
        End If

        If CheckDateExist(sEndDate, strNewDate) = False Then
            MsgBox("终止日期不存在，换用最近的一个日期" & strNewDate)
            sEndDate = strNewDate
        End If

        Dim bStart As Boolean, bEnd As Boolean

        bStart = False
        bEnd = False

        i = m_colPriceData.Count
        j = 0

        'j移动到需要的开始日期
        While bStart = False And j < i
            j = j + 1
            'Debug.Print Me.PriceData.Item(j).ThisDate
            If CDate(Me.PriceData.Item(j).ThisDate) = CDate(sStartDate) Then
                bStart = True
            End If
        End While

        '开始复制到新集合，直到终止日期
        While bEnd = False
            If CDate(Me.PriceData.Item(j).ThisDate) = CDate(sEndDate) Then
                m_colNewPriceData.Add(m_colPriceData.Item(j))
                bEnd = True
            Else
                m_colNewPriceData.Add(m_colPriceData.Item(j))
            End If
            j = j + 1
        End While

        m_colPriceData = m_colNewPriceData

        'm_colNewPriceData = Nothing

    End Sub

    '根据起始日期和终止日期筛选需要日期数据
    Private Function FilterDataTablebyStartDate_EndDate2(sStartDate As String, sEndDate As String, oPriceDataTable As CDTDaily_Stock_Collection)
        Dim i As Integer, j As Integer

        Dim strNewDate As String

        'If CheckDateExist(sStartDate, strNewDate) = False Then
        '    MsgBox("终止日期不存在，换用最近的一个日期" & strNewDate)
        '    sStartDate = strNewDate
        'End If

        'If CheckDateExist(sEndDate, strNewDate) = False Then
        '    MsgBox("终止日期不存在，换用最近的一个日期" & strNewDate)
        '    sEndDate = strNewDate
        'End If

        Dim oPDT As New CDTDaily_Stock_Collection

        Dim bStart As Boolean, bEnd As Boolean

        bStart = False
        bEnd = False

        i = Me.PriceData.Count
        j = 0

        'j移动到需要的开始日期
        While bStart = False And j < i
            j = j + 1
            'Debug.Print Me.PriceData.Item(j).ThisDate
            If CDate(Me.PriceData.Item(j).ThisDate) = CDate(sStartDate) Then
                bStart = True
            End If
        End While

        '开始复制到新集合，直到终止日期
        While bEnd = False
            If CDate(Me.PriceData.Item(j).ThisDate) = CDate(sEndDate) Then
                oPDT.PriceData.Add(Me.PriceData.Item(j))
                bEnd = True
            Else
                oPDT.PriceData.Add(Me.PriceData.Item(j))
            End If
            j = j + 1
        End While

        oPriceDataTable = oPDT

        oPDT = Nothing

    End Function


    '===============OBSELETE==================
    '根据终止日期和次数筛选需要日期数据，需要反推。
    Private Function FilterDataTablebyEndDate_Number(sEndDate As String, iTotalNumber As Integer, oPriceDataTable As CDTDaily_Stock_Collection)
        '    Dim j As Integer, i As Integer
        '
        '    Dim strNewDate As String
        '    Dim oPDT As New CDataPriceTable
        '
        '    Dim bEnd As Boolean
        '
        '    If CheckDateExist(sEndDate, strNewDate) = False Then
        '        MsgBox "起始日期不存在，换用最近的一个日期" & strNewDate
        '        sEndDate = strNewDate
        '    End If
        '
        '    bEnd = False
        '
        '    j = Me.PriceData.Count
        '
        '    'j移动到需要的终止日期
        '    While bEnd = False
        '        If CDate(Me.PriceData.Item(j).ThisDate) = CDate(sEndDate) Then
        '            bEnd = True
        '            'Exit while
        '        End If
        '        j = j - 1
        '    Wend
        '
        '    j = j + 1
        '    For i = iTotalNumber To 1 Step -1
        '        oPDT.PriceData.Add Me.PriceData.Item(j - i + 1)
        '    Next
        '
        '    Set oPriceDataTable = oPDT
        '
        '    Set oPDT = Nothing

    End Function

    Private Function JudgeDateNumberValid(sStartDate As String, sEndDate As String, iNumbers As Integer) As Boolean

        Dim strNewDate As String

        JudgeDateNumberValid = True

        If sStartDate <> "" Then
            If IsDate(sStartDate) = True Then
                If IsInStartDateScope(sStartDate) = False Then
                    JudgeDateNumberValid = False
                    Exit Function
                End If
            Else
                MsgBox("起始日期有误!")
                JudgeDateNumberValid = False
                Exit Function
            End If

        End If

        If sEndDate <> "" Then
            If IsDate(sEndDate) = True Then
                If IsInEndDateScope(sEndDate) = False Then
                    JudgeDateNumberValid = False
                    Exit Function
                End If
            Else
                MsgBox("终止日期有误!")
                JudgeDateNumberValid = False
                Exit Function
            End If

            '        If CheckDateExist(sEndDate, strNewDate) = False Then
            '            MsgBox "终止日期不存在，换用最近的一个日期" & strNewDate
            '            JudgeDateNumberValid = False
            '            End
            '        End If
        End If

        If IsDate(sStartDate) And IsDate(sEndDate) Then
            If CDate(sStartDate) > CDate(sEndDate) Then
                MsgBox("输入起始日期超出终止日期，请重新输入!")
                JudgeDateNumberValid = False
                Exit Function
            End If
        End If
        '    If iNumbers >= 0 Then
        '        If IsInNumbersScope(iNumbers) = False Then
        '            JudgeDateNumberValid = False
        '        End If
        '    Else
        '        JudgeDateNumberValid = False
        '    End If
        If iNumbers < 0 Then
            MsgBox("次数不能小于0")
            JudgeDateNumberValid = False
            Exit Function
        End If

    End Function

    '判断起始日期有效性，是否超出数据库的日期
    Private Function IsInStartDateScope(sStartDate As String) As Boolean
        If CDate(sStartDate) < CDate(m_colPriceData.Item(1).ThisDate) Then
            IsInStartDateScope = False
            MsgBox("起始日期超出范围")
        Else
            IsInStartDateScope = True
        End If
    End Function

    '判断终止日期有效性，是否超出数据库的日期
    Private Function IsInEndDateScope(sEndDate As String) As Boolean
        If CDate(sEndDate) > CDate(m_colPriceData.Item(m_colPriceData.Count).ThisDate) Then
            IsInEndDateScope = False
            MsgBox("终止日期超出范围")
        Else
            IsInEndDateScope = True
        End If
    End Function

    '===================OBSOLETE===========================
    '判断次数有效性，是否超出数据库的日期。该函数无效
    Private Function IsInNumbersScope(iNumbers As Integer) As Boolean
        '    If iNumbers > m_colPriceData.Count Then
        '        IsInNumbersScope = False
        '        MsgBox "日期次数超出范围"
        '    Else
        '        IsInNumbersScope = True
        '    End If
    End Function

    '删除未交易、停牌的数据，根据是否为0或与前一日相同
    Public Function DeleteRedundantPriceData()
        If m_bDateNormalOrder = False Then
            Me.TransposeDateOrder(True)
        End If

        Dim colPDT As New Collection

        Dim i As Integer, j As Integer

        i = Me.PriceData.Count
        Debug.Print(m_colPriceData.Count)

        colPDT.Add(Me.PriceData(1))

        For j = 2 To i
            If ((Me.PriceData(j).OpenPrice <> 0) And (Me.PriceData(j).OpenPrice <> Me.PriceData(j - 1).OpenPrice)) Then
                colPDT.Add(Me.PriceData(j))
            End If
        Next

        m_colPriceData = colPDT

        colPDT = Nothing

    End Function

    '判断日期是否存在，如果没有，返回最近的一个日期（无论前后）
    Private Function CheckDateExist(sDate As String, ByRef strNewDate As String) As Boolean
        Dim i As Integer, j As Integer

        Dim iDateInterval As Integer

        Dim iDateMinimum As Integer

        CheckDateExist = False

        '起始值
        iDateMinimum = Math.Abs(DateDiff(DateInterval.Day, CDate(Me.PriceData.Item(1).ThisDate), CDate(sDate)))
        strNewDate = Me.PriceData.Item(1).ThisDate

        i = Me.PriceData.Count
        For j = 1 To i


            iDateInterval = Math.Abs(DateDiff(DateInterval.Day, CDate(Me.PriceData.Item(j).ThisDate), CDate(sDate)))

            If iDateInterval = 0 Then
                CheckDateExist = True
                Exit For
            ElseIf iDateMinimum > iDateInterval Then
                iDateMinimum = iDateInterval
                strNewDate = Me.PriceData.Item(j).ThisDate
            End If

        Next

    End Function

    '根据终止日期、次数计算起始日期
    Private Sub LookupStartDate(ByRef sStartDate As String, ByRef strEndDate As String, iNumber As Integer)
        Dim j As Integer
        Dim strNewDate As String = ""

        Dim bEnd As Boolean

        If CheckDateExist(strEndDate, strNewDate) = False Then
            MsgBox("终止日期不存在，换用最近的一个日期" & strNewDate)
            strEndDate = strNewDate
        End If

        bEnd = False

        j = m_colPriceData.Count

        'j移动到需要的终止日期
        While bEnd = False
            If CDate(Me.PriceData.Item(j).ThisDate) = CDate(strEndDate) Then
                bEnd = True
            End If
            j = j - 1
        End While

        j = j + 1

        If j - iNumber + 1 < 0 Then
            MsgBox("计算的起始日期超出范围，以数据库实际第一天为准")
            sStartDate = m_colPriceData.Item(1).ThisDate
        Else
            sStartDate = m_colPriceData.Item(j - iNumber + 1).ThisDate
        End If

    End Sub

    '根据起始日期、次数计算终止日期
    Private Sub LookupEndDate(ByRef sStartDate As String, ByRef strEndDate As String, iNumber As Integer)
        Dim i As Integer, j As Integer

        Dim strNewDate As String = ""

        If CheckDateExist(sStartDate, strNewDate) = False Then
            MsgBox("起始日期不存在，换用最近的一个日期" & strNewDate)
            sStartDate = strNewDate
        End If

        Dim bStart As Boolean

        bStart = False

        j = 0

        If sStartDate = Nothing Then
            MsgBox("缺少起始日期")
        End If

        'j移动到需要的开始日期
        While bStart = False
            j = j + 1
            If CDate(Me.PriceData.Item(j).ThisDate) = CDate(sStartDate) Then
                bStart = True
            End If
        End While

        If j + iNumber - 1 > m_colPriceData.Count Then
            MsgBox("计算的终止日期超出范围，以数据库实际最后一天为准")
            strEndDate = m_colPriceData.Item(m_colPriceData.Count).ThisDate

        Else
            strEndDate = m_colPriceData.Item(j + iNumber - 1).ThisDate
        End If
    End Sub

    Public Sub Print2StringArray(ByRef sOutputArray() As String, Optional ByVal sPriceTag As String = "Close")

        Dim i As Integer
        ReDim sOutputArray(m_colPriceData.Count + 1)
        sOutputArray(0) = "-1"

        For i = 1 To m_colPriceData.Count
            If sPriceTag = "Close" Then
                sOutputArray(i) = m_colPriceData.Item(i).ClosePrice_PreAdj
            End If
        Next
    End Sub
End Class
