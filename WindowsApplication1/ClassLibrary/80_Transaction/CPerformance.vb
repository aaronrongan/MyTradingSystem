Public Class CPerformance
    Public strategy_id As String
    Public account_id As String
    Public nav As Double                               ''净值(cum_inout + cum_pnl + fpnl - cum_commission)  
    Public pnl As Double                                      ''净收益(nav-cum_inout)                              
    Public profit_ratio As Double                              ''收益率(pnl/cum_inout)                              
    Public sharp_ratio As Double                              ''夏普比率                                           
    Public risk_ratio As Double                             ''风险比率                                           
    Public trade_count As Integer                           ''交易次数                                           
    Public win_count As Integer                               ''盈利次数                                           
    Public lose_count As Integer                             ''亏损次数                                           
    Public win_ratio As Double                                ''胜率                                               
    Public max_profit As Double                             ''最大收益                                           
    Public min_profit As Double                            ''最小收益                                           
    Public max_single_trade_profit As Double                  ''最大单次交易收益                                   
    Public min_single_trade_profit As Double                 ''最小单次交易收益                                   
    Public daily_max_single_trade_profit As Double             ''今日最大单次交易收益                               
    Public daily_min_single_trade_profit As Double           ''今日最小单次交易收益                               
    Public max_position_value As Double                ''最大持仓市值或权益                                 
    Public min_position_value As Double                     ''最小持仓市值或权益                                 
    Public max_drawdown As Double                      ''最大回撤                                           
    Public daily_pnl As Double                          ''今日收益                                           
    Public daily_return As Double                             ''今日收益率                                         
    Public annual_return As Double                           ''年化收益率                                         
    Public transact_time As Double                           ''指标计算时间 


    '   InitialFund double  期初权益
    'EndingFund double  期末权益
    'DaysCount int  回测天数
    'NetRevenue double  净收益 
    'NetReturn double  净收益率
    'AnnReturn double  年华收益率 
    'ProfitFactor double  盈利系数 
    'PayoffRatio double  风险报酬比 
    'Transactions int  交易次数 
    'Wins double  胜率 
    'MaxDDRate double  最大回撤比率 
    'StdDeviation double  标准差 
    'SharpeRate double  Sharpe比率 
    'TransFee double  交易费用 
    'TotalProfit double  盈利交易的盈利和 
    'TotalLoss double  亏损交易总亏损 
    'NumGain Int  盈利次数 
    'NumLoss Int  亏损次数 
    'AvgProfit double  每笔平均盈利 
    'AvgLoss double  每笔平均亏损 
    'MaxProfit double  单笔最大盈利 
    'MaxLoss double  单笔最大亏损 
    'MaxNumCntGain Int  最大连续盈利次数 
    'MaxNumCntLoss Int  最大连续亏损次数 
    'MaxAmtCntGain double  最大连续盈利金额 
    'MaxAmtCntLoss double  最大连续亏损金额 
    'Notes String  备注
    'TotalNetProfit
    'OpenPositionPL
    'GrossProfit
    'GrossLoss
    'TotalNumberTrades
    'ProfitPercent
    'WinningNumbers
    'LosingNumbers
    'LargestWinning	'最大盈利
    'LargetLosing	'最大亏损
    'AverageWinnding	'平均盈利
    'AverageLosting	'平均亏损
    'RatioAvgWinLoss	
    'AvgTradeWinLoss	
    'MaxConsecWinners	'最大连续盈利次数
    'MaxConsecLosers		'最大连续亏损次数
    'MaxIntradayDrawdown	'单日最大亏损
    'ProfitFactor		'盈利因子
    'MaxContractsHeld	'最大持仓数?
    'ReturnonAccount		'账户回报
End Class
