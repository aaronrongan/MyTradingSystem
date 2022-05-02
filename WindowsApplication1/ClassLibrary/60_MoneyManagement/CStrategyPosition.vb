Public Class CStrategyPosition
    ''' 交易所ID
    Public exchange As String
    ''' 证券ID
    Public sec_id As String
    ''' 买卖方向
    Public side As Byte
    ''' 持仓量
    Public volume As Double
    ''' 今仓量
    Public volume_today As Double
    ''' 持仓均价
    Public vwap As Double
    ''' 当前行情价格
    Public price As Double
    ''' 持仓额
    Public amount As Double
    ''' 浮动赢亏
    Public fpnl As Double
    ''' 持仓成本
    Public cost As Double
    ''' 挂单冻结仓位量
    Public order_frozen As Double
    ''' 挂单冻结今仓仓位
    Public order_frozen_today As Double
    ''' 可平仓位量
    Public available As Double
    ''' 可平今仓位
    Public available_today As Double
    ''' 上一笔成交价
    Public last_price As Double
    ''' 上一笔成交量
    Public last_volume As Double
    ''' 上一笔成交时间
    Public transact_time As Double
    ''' 初始建仓时间
    Public init_time As Double

    '   Symbol
    'ShortName
    'VolumeBalance		'仓位余额，股票余额
    'VolumeAvaliable		'可卖仓位
    'VolumeFrozen		'冻结仓位
    'VolumeTodayBuy		'今日买入仓位
    'VolumeTodaySell		'今日卖出仓位
    'VolumeTotal		'当前持仓，实际持仓
    'VolumeCall		'可申赎仓位?	
    'CostPrice 		'成本价格
    'Commission		'交易费
    'LatestPrice		'最近价格，市价
    'LatestValue		'市值
    'HoldingValue	'当前价格
    'ProfitLoss		'盈亏
    'ProfitLossPercent	'盈亏比例
    'MoneyType		资金类型
    'Market				'交易市场
    'AccountID			'股东账户
End Class
