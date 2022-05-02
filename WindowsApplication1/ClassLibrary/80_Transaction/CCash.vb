

''' <summary>
''' 当前现金
''' </summary>
''' <remarks></remarks>
Public Class CCash

    ''' <summary>
    ''' '' 策略ID
    ''' </summary>
    ''' <remarks></remarks>
    Public strategy_id As String

    ''' <summary>
    '''   '' 币种
    ''' </summary>
    ''' <remarks></remarks>
    Public currency As Integer

    ''' <summary>
    '''    '' 资金余额
    ''' </summary>
    ''' <remarks></remarks>
    Public nav As Double

    ''' <summary>
    ''' '' 浮动收益
    ''' </summary>
    ''' <remarks></remarks>
    Public fpnl As Double

    ''' <summary>
    '''   '' 净收益
    ''' </summary>
    ''' <remarks></remarks>
    Public pnl As Double
    ''' <summary>
    ''' '' 收益率
    ''' </summary>
    ''' <remarks></remarks>
    Public profit_ratio As Double

    ''' <summary>
    '''  持仓冻结金额
    ''' </summary>
    ''' <remarks></remarks>
    Public frozen As Double

    Public order_frozen As Double              '' 挂单冻结金额
    Public available As Double               '' 可用资金

    Public cum_inout As Double                 '' 累计出入金
    Public cum_trade As Double                 '' 累计交易额
    Public cum_pnl As Double                 '' 累计收益
    Public cum_commission As Double             '' 累计手续费

    Public last_trade As Double               '' 最新一笔交易额
    Public last_pnl As Double                '' 最新一笔交易收益
    Public last_commission As Double             '' 最新一笔交易手续费
    Public last_inout As Double              '' 最新一次出入金
    Public change_reason As Integer               '' 变动原因

    'Public transact_time As Double             '' 交易时间

    Public Sub New()
        available = 100000    '起始资金100,000
    End Sub

    Public Property AvailableCash As Double
        Get
            AvailableCash = available
        End Get
        Set(value As Double)
            available = value
        End Set
    End Property
End Class
