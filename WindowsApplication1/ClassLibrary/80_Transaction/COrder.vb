
Namespace Trade

#Region "Event"
    Public Class OrderEventArgs
        Inherits System.EventArgs

    End Class
#End Region


#Region "Enum"
    'Public Enum EOrderType
    '    LMT = 0
    '    BOC = 1
    '    BOP = 2
    '    ITC = 3
    '    B5TC = 4
    '    FOK = 5
    '    B5TL = 6

    '    OrderType_AON = 7
    '    OrderType_B5TC = 3
    '    OrderType_B5TL = 4
    '    OrderType_BOC = 1
    '    OrderType_BOP = 2
    '    OrderType_EXE = 9
    '    OrderType_FOK = 6
    '    OrderType_IOC = 5
    '    OrderType_LMT = 0
    '    OrderType_MTL = 8
    'End Enum

    Public Enum EMarketType
        SZ = 0
        SH = 1
        OC = 2
        HK = 6
        CZC = 7
        SHF = 8
        DCE = 9
        CFE = 10

    End Enum

    Public Enum EOrderRejectReason As Integer
        AccountForbidTrading = 10
        IllegalPrice = 8
        IllegalStrategyID = 5
        IllegalSymbol = 6
        IllegalVolume = 7
        NoEnoughCash = 3
        NoEnoughPosition = 4
        NoMatchedTradingChannel = 9
        NotInTradingSession = 13
        RiskRuleCheckFailed = 2
        StrategyForbidTrading = 12
        TradingChannelNotConnected = 11
        UnknownReason = 1
    End Enum

    Public Enum EOrderSide As Integer
        Buy = 2
        Sell = 1
    End Enum

    Public Enum EOrderStatus As Integer
        AcceptedForBidding = 13
        Calculated = 11
        Canceled = 5
        DoneForDay = 4
        Expired = 12
        Filled = 3
        TheNew = 1
        PartiallyFilled = 2
        PendingCancel = 6
        PendingNew = 10
        PendingReplace = 14
        Rejected = 8
        Stopped = 7
        Suspended = 9
    End Enum

    Public Enum EOrderType As Integer
        ' OrderType_LMT    = 0;  //限价委托(limit)
        'OrderType_BOC    = 1;  //对方最优价格(best of counterparty)
        'OrderType_BOP    = 2;  //己方最优价格(best of party)
        'OrderType_B5TC   = 3;  //最优五档剩余撤销(best 5 then cancel)
        'OrderType_B5TL   = 4;  //最优五档剩余转限价(best 5 then limit)
        'OrderType_IOC    = 5;  //即时成交剩余撤销(immediately or cancel)
        'OrderType_FOK    = 6;  //即时全额成交或撤销(fill or kill)
        'OrderType_AON    = 7;  //全额成交或不成交(all or none)
        'OrderType_MTL    = 8;  //市价剩余转限价(market then limit)
        'OrderType_EXE    = 9;  //期权行权(option execute)

        LMT = 0
        BOC = 1
        BOP = 2
        B5TC = 3
        B5TL = 4
        IOC = 5
        FOK = 6
        AON = 7
        MTL = 8
        EXE = 9

       
        'ITC = 3
        'B5TC = 4
        'FOK = 5
        'B5TL = 6
    End Enum

    Public Enum ECancelOrderRejectReason
        AlreadyInPendingCancel = 104
        BrokerOption = 103
        OrderFinalized = 101
        UnknownOrder = 102
    End Enum

#End Region


    Public Class COrder

        '   OrderID			'订单ID
        'OrderTime		'委托时间	
        'TradeSide		'买卖操作
        'OrderType	 	'BOC/LMT
        'OrderStatus		'已成、已报、已撤
        'SecuritySymbol	'证券代码
        'SecurityShortName	'证券名称
        'OrderPrice			'委托价格
        'OrderVolume			'委托数量
        'ContractID			'合同编号
        'TradedTime			'成交时间
        'TradedPrice			'成交价格
        'TradedVolume		'成交量
        'TradedValue			'成交金额
        'CommissionFee		'手续费
        'TaxFee				'印花税
        'OtherFee			'其它费用
        'TradedTotalValue	'成交总金额
        'CancelVolume		'撤销数量
        'LastPrice			'市价
        'Remark				'备注
        'Market				'交易市场
        'AccountID			'股东账户


        ''' 策略ID
        Public strategy_id As String
        ''' 交易账号
        Public account_id As String

        ''' 订单时间
        Public orderdatetime As DateTime

        ''' 客户端订单ID
        Public cl_ord_id As String
        ''' 柜台订单ID
        Public order_id As String
        ''' 交易所订单ID
        Public ex_ord_id As String
        ''' 交易所ID
        Public exchange As String
        ''' 证券ID
        Public sec_id As String
        ''' 开平标志
        Public position_effect As Byte
        ''' 买卖方向
        Public side As EOrderSide
        ''' 订单类型
        Public order_type As Byte
        ''' 订单来源
        Public order_src As Integer
        ''' 订单状态
        Public status As Byte
        ''' 订单拒绝原因
        Public ord_rej_reason As Byte
        ''' 订单拒绝原因描述
        Public ord_rej_reason_detail As String
        ''' 委托价
        Public price As Double
        '''止损价
        Public stop_price As Double
        ''' 委托量
        Public volume As Double
        ''' 已成交量
        Public filled_volume As Double
        ''' 已成交均价
        Public filled_vwap As Double
        ''' 已成交额
        Public filled_amount As Double
        ''' 委托下单时间
        Public sending_time As Double
        ''' 最新一次成交时间
        Public transact_time As Double

        Public position As Integer

        Public Sub New()

        End Sub


    End Class


End Namespace
