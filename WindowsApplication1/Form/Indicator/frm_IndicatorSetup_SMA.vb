Public Class frm_IndicatorSetup_SMA
    Inherits frm_IndicatorSetup

    Public m_PeriodsAverage As Int16

    Private Sub frm_IndicatorSetup_SMA_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        'm_PeriodsAverage = NumericUpDown1.Value
    End Sub
    Private Sub frm_IndicatorSetup_SMA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Protected Overloads Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        m_PeriodsAverage = NumericUpDown1.Value

        Me.Hide()
    End Sub

End Class
