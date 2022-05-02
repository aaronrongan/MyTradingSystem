Imports WAPIWrapperCSharp
Imports System.Data

Namespace Trade


    
    Public Class CTrade_Simulation_Wind
        Private m_AccountID1 As String
        Private m_AccountPassword1 As String
        Private m_AccountID2 As String
        Private m_AccountPassword2 As String
        Private m_LogonID1 As Integer
        Private m_WindAPI As WAPIWrapperCSharp.WindAPI
        Private m_WindData As WindData

        Private m_OrderLogonID As String
        Private m_OrderRequestID As String
        Private m_OrderNumber As String

        Private m_orderSymbol As String
        Private m_orderPrice As Single
        Private m_orderVolume As Single
        Private m_BuyorSell As String
        Private m_orderType As String

        Private m_brokerID As String
        Private m_departmentID As String
        Private m_accountType As Integer

        ''' <summary>
        ''' Singleton模式，一次交易只能有一次 VIP
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared tradeWind As CTrade_Simulation_Wind

        Sub New()
            AccountID1 = "000000"

            m_WindAPI = New WindAPI
            m_WindData = New WindData

            m_AccountID1 = "M:1365182978301"
            m_AccountPassword1 = "000000"

            m_AccountID2 = "M:1365182978302"
            m_AccountPassword2 = "000000"

            m_BuyorSell = "Sell"

            m_brokerID = "00000010"
            m_departmentID = "0"

            m_orderType = "LMT"
            'm_WindAPI.start()

        End Sub

        Public Property AccountID1 As String
            Get

            End Get
            Set(value As String)

            End Set
        End Property

        Public Property AccountPassword1 As String
            Get

            End Get
            Set(value As String)

            End Set
        End Property

        Public Property AccountID2 As String
            Get

            End Get
            Set(value As String)

            End Set
        End Property

        Public Property AccountPassword2 As String
            Get

            End Get
            Set(value As String)

            End Set
        End Property

        Public Property brokerID As String
            Get

            End Get
            Set(value As String)

            End Set
        End Property

        Public Property departmentID As String
            Get

            End Get
            Set(value As String)

            End Set
        End Property

        Public Property AccountType1 As String
            Get

            End Get
            Set(value As String)

            End Set
        End Property

        Public ReadOnly Property LogonID As String
            Get
                LogonID = m_LogonID1
            End Get

        End Property

        Public ReadOnly Property OrderNumber As String
            Get
                OrderNumber = m_OrderNumber
            End Get

        End Property

        Public ReadOnly Property OrderRequestID As String
            Get
                OrderRequestID = m_OrderRequestID
            End Get

        End Property

        Public Property OrderSymbol As String
            Get
                OrderSymbol = m_orderSymbol
            End Get
            Set(value As String)
                If Left(value, 1) = "0" Or Left(value, 1) = "3" Then
                    m_orderSymbol = value & ".SZ"
                ElseIf Left(value, 1) = "6" Then
                    m_orderSymbol = value & ".SH"
                End If

            End Set
        End Property

        Public Property OrderType As String
            Get
                OrderType = m_orderType
            End Get
            Set(value As String)
                m_orderType = "OrderType=" + value
            End Set
        End Property

        Public Property OrderPrice As Single
            Get
                OrderPrice = m_orderPrice
            End Get
            Set(value As Single)
                m_orderPrice = value
            End Set
        End Property

        Public Property OrderVolume As Integer
            Get
                OrderVolume = m_orderVolume
            End Get
            Set(value As Integer)
                m_orderVolume = value
            End Set
        End Property

        Public Property OrderBuyorSell As String
            Get
                OrderBuyorSell = m_BuyorSell
            End Get
            Set(value As String)
                m_BuyorSell = value
            End Set
        End Property

        Public Sub Logon(strAccountType_StockorOption As String)
            Try
                m_WindAPI.start()
                If strAccountType_StockorOption = "Stock" Then
                    m_WindData = m_WindAPI.tlogon(m_brokerID, m_departmentID, m_AccountID1, m_AccountPassword1, "SHSZ")
                ElseIf strAccountType_StockorOption = "Future" Then
                    m_WindData = m_WindAPI.tlogon(m_brokerID, m_departmentID, m_AccountID2, m_AccountPassword2, m_accountType) 'm_accountType对期货用什么？
                End If

                m_OrderLogonID = m_WindData.GetLogonId

            Catch ex As Exception
                MsgBox("登陆错误:" & m_WindAPI.getErrorMsg(m_WindData.errorCode))
            Finally
                RaiseError()
            End Try

        End Sub

        Public Sub Logout()
            Try
                m_WindData = m_WindAPI.tlogon(m_brokerID, m_departmentID, m_AccountID1, m_AccountID1, "SHSZ")
            Catch ex As Exception

            Finally
                RaiseError()

            End Try


        End Sub

        Public Sub PlaceOrder() 'Symbol As String, strBuyorSell As String, OrderPrice As Single, Optional OrderVolume As Single = 100, Optional Ordertype As EOrderType = EOrderType.LMT
            Try
                'm_orderSymbol = Symbol
                'm_BuyorSell = strBuyorSell
                'm_orderPrice = OrderPrice
                'm_orderVolume = OrderVolume
                'm_orderType = Ordertype

                m_WindData = m_WindAPI.torder(m_orderSymbol, m_BuyorSell, CStr(m_orderPrice), CStr(m_orderVolume), m_orderType)
                Console.Write(m_orderSymbol + m_BuyorSell + CStr(m_orderPrice) + CStr(m_orderVolume) + m_orderType)

                m_OrderRequestID = m_WindData.GetOrderRequestID
                m_OrderNumber = m_WindData.GetOrderNumber
            Catch ex As Exception

            Finally
                RaiseError()

            End Try
        End Sub

        Public Sub CancelOrder(ordernumber As String, Optional markettype As String = "SHSZ")
            Try
                m_WindData = m_WindAPI.tcancel(ordernumber, markettype)
            Catch ex As Exception

            Finally
                RaiseError()
            End Try

        End Sub

        Private Function QueryasDataTable(strQueryType As String) As DataTable
            Try

                Dim dt As New DataTable

                m_WindData = m_WindAPI.tquery(strQueryType)

                Dim FieldArray As String()

                If (m_WindData.errorCode = 0) Then
                    Dim fl As Int16 = m_WindData.GetFieldLength

                    ReDim FieldArray(fl)

                    For i = 0 To fl - 1
                        dt.Columns.Add(m_WindData.fieldList(i), GetType(System.String))
                    Next

                    Try
                        Dim iRowTotal As Int16 = m_WindData.GetDataLength / fl
                        Dim row As DataRow

                        For i = 0 To iRowTotal - 1
                            row = dt.NewRow
                            For j = 0 To fl - 1

                                Dim str As String = m_WindData.data(j, i)
                                row(j) = str

                            Next
                            dt.Rows.Add(row)
                        Next
                    Catch ex As Exception

                    End Try

                    QueryasDataTable = dt
                End If
            Catch ex As Exception
                Return Nothing
            Finally
                RaiseError()
            End Try

        End Function

        Public Function QueryCapital() As DataTable
            Try
                Dim dt As New DataTable

                dt = QueryasDataTable("Capital")

                Return dt
            Catch ex As Exception
                Return Nothing
            Finally
                RaiseError()
            End Try

        End Function

        Public Function QueryPosition() As DataTable
            Try
                Dim dt As New DataTable

                dt = QueryasDataTable("Position")

                Return dt
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Function QueryOrder() As DataTable
            Try
                Dim dt As New DataTable

                dt = QueryasDataTable("Order")

                Return dt
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Function QueryTrade() As DataTable
            Try
                Dim dt As New DataTable

                dt = QueryasDataTable("Trade")

                Return dt
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Function QueryAccount() As DataTable
            Try
                Dim dt As New DataTable

                dt = QueryasDataTable("Account")

                Return dt
            Catch ex As Exception
                Return Nothing
            End Try
        End Function


        Protected Overrides Sub Finalize()
            MyBase.Finalize()
            m_WindAPI.tlogout()
            m_WindAPI.stop()
        End Sub

        Private Sub RaiseError()
            If m_WindData.errorCode <> 0 Then
                MsgBox("错误:" & m_WindAPI.getErrorMsg(m_WindData.errorCode))
            End If
        End Sub

        Public Function GetErrorCode() As Integer
            Return m_WindData.errorCode
        End Function

    End Class

End Namespace
