Namespace DataEntity


    Public Class CDSDaily_Fund
        Inherits CDSDaily

        Public Sub New()
            MyBase.New()

            m_SetCategory = "FundPriceDaily"

            m_dtAllDataTable = New CDTDaily_Fund

            m_dtInfo = New CDTInfo_Fund

            'm_dtPrice = New CDTDaily_Fund
        End Sub


        ''' <summary>
        ''' 新增一个m_dtPrice
        ''' </summary>
        Public Overrides Function CreateDataTablePriceInstance()
            m_dtPrice = New CDTDaily_Fund
        End Function

    End Class

End Namespace
