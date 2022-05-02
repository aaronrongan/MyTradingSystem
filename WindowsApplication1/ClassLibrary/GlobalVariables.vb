Public Class GlobalVariables
    Public Enum EDataFeedSource
        Sohu
        Yahoo
        Sina
        TDX_FQ
        TDX_Normal
    End Enum
    'Access数据库数据
    Public Shared g_AcessDBPath As String = "C:\MyDocuments\我的坚果云\Database\MyStocks.mdb"

    'Matlab数据
    Public Shared g_MatlabDBPath_Daily As String = "C:\MyDocuments\我的坚果云\Database\MyTradingSystem\Stocks\Matlab"

    '包含Excel/CSV/TXT/Mat格式的数据
    Public Shared g_TXTDBPath As String = "C:\MyDocuments\我的坚果云\Database\MyTradingSystem"

    '包含yahoo下载的CSV格式的日线数据
    Public Shared g_CSVDBPath_Daily As String = "C:\MyDocuments\我的坚果云\Database\MyTradingSystem\Stocks\Yahoo\Daily"

    '通达信导出的除权日线数据文件夹(.day二进制格式)，包含指数、股票数据
    Public Shared g_TDXPath_DailySZ As String = "C:\new_tdx\vipdoc\sz\lday"
    Public Shared g_TDXPath_DailySH As String = "C:\new_tdx\vipdoc\sh\lday"
    Public Shared g_TDXPath_DailyExtended As String = "C:\new_tdx\vipdoc\ds\lday"  '扩展数据，如基金(33#,34#),中证指数62#

    'Matlab导出的指数净值数据
    Public Shared g_MatlabFarutoPath_FundNetValue As String = "D:\MyDoc\Database\MyTradingSystem\Matlab\Fund_NetValue_TXT"


    '通达信导出的股票前复权、后复权、正常日线数据文件夹(TXT格式)
    Public Shared g_TDXPath_Daily_FA As String = "D:\MyDoc\Database\MyTradingSystem\TDX\Stock\FA"
    Public Shared g_TDXPath_Daily_BA As String = "D:\MyDoc\Database\MyTradingSystem\TDX\Stock\BA"
    Public Shared g_TDXPath_Daily_Normal As String = "D:\MyDoc\Database\MyTradingSystem\TDX\Stock\Normal"

    '日志文件路径
    Public Shared g_LogFilePath As String = "C:\MyDocuments\我的坚果云\Database\MyTradingSystem\Logs"

    Public Shared gSQLConnectionString As String = "Integrated Security=True;Data Source=LocalHost;Initial Catalog=TradingSystem;"

    Public Shared g_FavoriteStock As String = "C:\MyDocuments\我的坚果云\Database\MyTradingSystem\FavoriteList_Stock.csv"
    Public Shared g_FavoriteIndex As String = "C:\MyDocuments\我的坚果云\Database\MyTradingSystem\FavoriteList_Index.csv"
    Public Shared g_FavoriteFund As String = "C:\MyDocuments\我的坚果云\Database\MyTradingSystem\FavoriteList_Fund.csv"



    ''' <summary>
    ''' 股票代码前缀
    ''' </summary>
    ''' <param name="sSymbol"></param>
    ''' <param name="sSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetStockCodePrePostfix(sSymbol As String, sSource As EDataFeedSource) As String

        If sSource = EDataFeedSource.Yahoo Then
            'End
        End If

        If sSource = EDataFeedSource.Yahoo Then
            '上证股票(6...)是股票代码后面加上.ss，深证股票(0/2/3)是股票代码后面加上.sz

            If Left(sSymbol, 1) = "6" Then
                GetStockCodePrePostfix = ".ss"
            ElseIf Left(sSymbol, 1) = "0" Or Left(sSymbol, 1) = "2" Or Left(sSymbol, 1) = "3" Then
                GetStockCodePrePostfix = ".sz"
            End If
        ElseIf sSource = EDataFeedSource.Sina Then
            If Left(sSymbol, 1) = "6" Then
                GetStockCodePrePostfix = "sh"
            ElseIf Left(sSymbol, 1) = "0" Or Left(sSymbol, 1) = "2" Or Left(sSymbol, 1) = "3" Then
                GetStockCodePrePostfix = "sz"
            End If
        ElseIf sSource = EDataFeedSource.TDX_FQ Then
            If Left(sSymbol, 1) = "6" Then
                GetStockCodePrePostfix = "SH#"
            ElseIf Left(sSymbol, 1) = "0" Or Left(sSymbol, 1) = "2" Or Left(sSymbol, 1) = "3" Then
                GetStockCodePrePostfix = "SZ#"
            Else
                MsgBox("首位字母:" & Left(sSymbol, 1) & "不属于沪深股市")
            End If
        ElseIf sSource = EDataFeedSource.TDX_Normal Then
            If Left(sSymbol, 1) = "6" Then
                GetStockCodePrePostfix = "SH"
            ElseIf Left(sSymbol, 1) = "0" Or Left(sSymbol, 1) = "2" Or Left(sSymbol, 1) = "3" Then
                GetStockCodePrePostfix = "SZ"
            Else
                MsgBox("首位字母:" & Left(sSymbol, 1) & "不属于沪深股市")
            End If
        End If
    End Function

    ''' <summary>
    '''  存在2个地方有指数数据: TDX中62#开头的就是中证指数数据，SH、SZ目标下为沪深指数数据，
    ''' </summary>
    ''' <param name="sSymbol"></param>
    ''' <param name="sSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetIndexCodePrePostfix(sSymbol As String, sSource As EDataFeedSource) As String

        If sSource = EDataFeedSource.TDX_Normal Then
            If Left(sSymbol, 1) = "0" Then
                Return "SH"
            ElseIf Left(sSymbol, 1) = "3" Then
                Return "SZ"
            Else
                Return "ZZ"
                'MsgBox("首位字母:" & Left(sSymbol, 1) & "不属于沪深指数")
                Return ""
            End If
        End If
    End Function
    '
    ''' <summary>
    ''' TDX中33#开头的就是开放基金数据,34#开头的是封闭基金、货币基金
    ''' </summary>
    ''' <param name="sSymbol"></param>
    ''' <param name="sSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFundCodePrePostfix(sSymbol As String, sSource As EDataFeedSource) As String

        ''还有H开头的如何处理？
        'If sSource = EDataFeedSource.TDX_Normal Then
        '    If Left(sSymbol, 1) = "0" Then
        '        Return "SH"
        '    ElseIf Left(sSymbol, 1) = "3" Then
        '        Return "SZ"
        '    Else
        '        MsgBox("首位字母:" & Left(sSymbol, 1) & "不属于沪深指数")
        '        Return ""
        '    End If
        'End If
    End Function
End Class
