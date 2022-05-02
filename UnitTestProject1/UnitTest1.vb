Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MyTradingSystem.Indicator

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMethod1()
        Dim idcf As New CIndicatorFactory

        CIndicatorFactory.CreateIndicator(EIndicatorName.SMA)


    End Sub

End Class