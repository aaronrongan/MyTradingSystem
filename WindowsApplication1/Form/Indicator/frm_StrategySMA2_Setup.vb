Public Class frm_StrategySMA2_Setup

    Public m_FastPeriods As Int16
    Public m_SlowPeriods As Int16
    Protected Overloads Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        m_FastPeriods = NumericUpDown1.Value
        m_SlowPeriods = NumericUpDown2.Value
        Me.Hide()
    End Sub
End Class