Imports MyTradingSystem.DataEntity

Public Interface IDTPrice

    Function GetOpenPrice(index As Int16) As Double
    Function GetHighPrice(index As Int16) As Double
    Function GetLowPrice(index As Int16) As Double
    Function GetClosePrice(index As Int16) As Double

    Function GetVolume(index As Int16) As Double
    Function GetCompressDT(pt As EHistoryDataPeriodType) As CDTDaily

End Interface
