Public Class frm_IndicatorSetup_MACD
    Public m_PeriodsAverage As Int16
    Protected Overloads Sub Button1_Click(sender As Object, e As EventArgs)
        m_PeriodsAverage = NumericUpDown1.Value

        Me.Hide()
    End Sub

End Class
