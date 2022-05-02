Imports Steema
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataView_StockHistoryData_Obsolete_OldTeeChart
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDataView_StockHistoryData_Obsolete_OldTeeChart))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nudPeriodLong2 = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.nudPeriodSlow2 = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.nudPeriod = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.nudPeriodLong3 = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nudPeriodMid3 = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.rdoSMA = New System.Windows.Forms.RadioButton()
        Me.nudPeriodSlow3 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtSymbol = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_StartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtp_EndDate = New System.Windows.Forms.DateTimePicker()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.AxTChart_Indicator = New TeeChart.TChart()
        Me.AxTChart_Volume = New TeeChart.TChart()
        Me.AxTChart_Candle = New TeeChart.TChart()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudPeriodLong2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPeriodSlow2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPeriodLong3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPeriodMid3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPeriodSlow3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        '     CType(Me.AxTChart_Indicator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxTChart_Volume, System.ComponentModel.ISupportInitialize).BeginInit()
        '        CType(Me.AxTChart_Candle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.nudPeriodLong2)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.nudPeriodSlow2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.nudPeriod)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.nudPeriodLong3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.nudPeriodMid3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.rdoSMA)
        Me.GroupBox1.Controls.Add(Me.nudPeriodSlow3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.txtSymbol)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtp_StartDate)
        Me.GroupBox1.Controls.Add(Me.dtp_EndDate)
        Me.GroupBox1.Location = New System.Drawing.Point(36, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(312, 580)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "选择"
        '
        'nudPeriodLong2
        '
        Me.nudPeriodLong2.Location = New System.Drawing.Point(239, 286)
        Me.nudPeriodLong2.Name = "nudPeriodLong2"
        Me.nudPeriodLong2.Size = New System.Drawing.Size(54, 22)
        Me.nudPeriodLong2.TabIndex = 33
        Me.nudPeriodLong2.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(142, 290)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 14)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "均线Fast周期"
        '
        'nudPeriodSlow2
        '
        Me.nudPeriodSlow2.Location = New System.Drawing.Point(239, 258)
        Me.nudPeriodSlow2.Name = "nudPeriodSlow2"
        Me.nudPeriodSlow2.Size = New System.Drawing.Size(54, 22)
        Me.nudPeriodSlow2.TabIndex = 31
        Me.nudPeriodSlow2.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(142, 262)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 14)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "均线Slow周期"
        '
        'nudPeriod
        '
        Me.nudPeriod.Location = New System.Drawing.Point(239, 209)
        Me.nudPeriod.Name = "nudPeriod"
        Me.nudPeriod.Size = New System.Drawing.Size(54, 22)
        Me.nudPeriod.TabIndex = 29
        Me.nudPeriod.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(142, 213)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 14)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "均线周期"
        '
        'nudPeriodLong3
        '
        Me.nudPeriodLong3.Location = New System.Drawing.Point(239, 375)
        Me.nudPeriodLong3.Name = "nudPeriodLong3"
        Me.nudPeriodLong3.Size = New System.Drawing.Size(54, 22)
        Me.nudPeriodLong3.TabIndex = 27
        Me.nudPeriodLong3.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(142, 379)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 14)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "均线Fast周期"
        '
        'nudPeriodMid3
        '
        Me.nudPeriodMid3.Location = New System.Drawing.Point(239, 352)
        Me.nudPeriodMid3.Name = "nudPeriodMid3"
        Me.nudPeriodMid3.Size = New System.Drawing.Size(54, 22)
        Me.nudPeriodMid3.TabIndex = 25
        Me.nudPeriodMid3.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(142, 356)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 14)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "均线Mid周期"
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Location = New System.Drawing.Point(19, 329)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(68, 18)
        Me.RadioButton3.TabIndex = 23
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "三均线"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(19, 269)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(68, 18)
        Me.RadioButton2.TabIndex = 22
        Me.RadioButton2.Text = "双均线"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'rdoSMA
        '
        Me.rdoSMA.AutoSize = True
        Me.rdoSMA.Location = New System.Drawing.Point(19, 209)
        Me.rdoSMA.Name = "rdoSMA"
        Me.rdoSMA.Size = New System.Drawing.Size(68, 18)
        Me.rdoSMA.TabIndex = 21
        Me.rdoSMA.Text = "单均线"
        Me.rdoSMA.UseVisualStyleBackColor = True
        '
        'nudPeriodSlow3
        '
        Me.nudPeriodSlow3.Location = New System.Drawing.Point(239, 328)
        Me.nudPeriodSlow3.Name = "nudPeriodSlow3"
        Me.nudPeriodSlow3.Size = New System.Drawing.Size(54, 22)
        Me.nudPeriodSlow3.TabIndex = 20
        Me.nudPeriodSlow3.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(142, 332)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 14)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "均线Slow周期"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(145, 158)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(83, 18)
        Me.CheckBox2.TabIndex = 18
        Me.CheckBox2.Text = "显示均线"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(97, 513)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(123, 43)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "调出数据"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(19, 158)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(69, 18)
        Me.CheckBox1.TabIndex = 16
        Me.CheckBox1.Text = "前复权"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 14)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "股票代码"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(212, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(85, 22)
        Me.TextBox1.TabIndex = 14
        '
        'txtSymbol
        '
        Me.txtSymbol.Location = New System.Drawing.Point(97, 32)
        Me.txtSymbol.Name = "txtSymbol"
        Me.txtSymbol.Size = New System.Drawing.Size(85, 22)
        Me.txtSymbol.TabIndex = 13
        Me.txtSymbol.Text = "002201"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 14)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "结束时间"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 14)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "起始时间"
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.Location = New System.Drawing.Point(97, 72)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(200, 22)
        Me.dtp_StartDate.TabIndex = 9
        '
        'dtp_EndDate
        '
        Me.dtp_EndDate.Location = New System.Drawing.Point(97, 108)
        Me.dtp_EndDate.Name = "dtp_EndDate"
        Me.dtp_EndDate.Size = New System.Drawing.Size(200, 22)
        Me.dtp_EndDate.TabIndex = 10
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(36, 640)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(312, 402)
        Me.DataGridView1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.AxTChart_Candle)
        Me.Panel1.Location = New System.Drawing.Point(368, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(2069, 957)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.AxTChart_Volume)
        Me.Panel2.Controls.Add(Me.AxTChart_Indicator)
        Me.Panel2.Location = New System.Drawing.Point(382, 920)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(2073, 352)
        Me.Panel2.TabIndex = 3
        '
        'AxTChart_Indicator
        '
        Me.AxTChart_Indicator.Enabled = True
        Me.AxTChart_Indicator.Location = New System.Drawing.Point(-14, 83)
        Me.AxTChart_Indicator.Name = "AxTChart_Indicator"
        'Me.AxTChart_Indicator.OcxState = CType(resources.GetObject("AxTChart_Indicator.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxTChart_Indicator.Size = New System.Drawing.Size(2052, 300)
        Me.AxTChart_Indicator.TabIndex = 0
        '
        'AxTChart_Volume
        '
        Me.AxTChart_Volume.Enabled = True
        Me.AxTChart_Volume.Location = New System.Drawing.Point(-14, -75)
        Me.AxTChart_Volume.Name = "AxTChart_Volume"
        'Me.AxTChart_Volume.OcxState = CType(resources.GetObject("AxTChart_Volume.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxTChart_Volume.Size = New System.Drawing.Size(2049, 165)
        Me.AxTChart_Volume.TabIndex = 1
        '
        'AxTChart_Candle
        '
        Me.AxTChart_Candle.Enabled = True
        Me.AxTChart_Candle.Location = New System.Drawing.Point(3, 3)
        Me.AxTChart_Candle.Name = "AxTChart_Candle"
        'Me.AxTChart_Candle.OcxState = CType(resources.GetObject("AxTChart_Candle.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxTChart_Candle.Size = New System.Drawing.Size(2049, 781)
        Me.AxTChart_Candle.TabIndex = 0
        '
        'frmDataView_StockHistoryData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2463, 1284)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmDataView_StockHistoryData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "股票历史数据"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudPeriodLong2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPeriodSlow2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPeriodLong3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPeriodMid3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPeriodSlow3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        'CType(Me.AxTChart_Indicator, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.AxTChart_Volume, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.AxTChart_Candle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtSymbol As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_StartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_EndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents AxTChart_Candle As TeeChart.TChart
    Friend WithEvents AxTChart_Indicator As TeeChart.TChart
    Friend WithEvents AxTChart_Volume As TeeChart.TChart
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents nudPeriodSlow3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nudPeriodLong3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nudPeriodMid3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSMA As System.Windows.Forms.RadioButton
    Friend WithEvents nudPeriodLong2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents nudPeriodSlow2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents nudPeriod As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
