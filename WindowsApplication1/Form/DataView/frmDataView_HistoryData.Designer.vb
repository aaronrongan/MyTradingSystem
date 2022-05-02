<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataView_HistoryData
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDataView_HistoryData))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtSymbol_ = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rbtBond = New System.Windows.Forms.RadioButton()
        Me.rbtFund = New System.Windows.Forms.RadioButton()
        Me.rbtIndex = New System.Windows.Forms.RadioButton()
        Me.rbtStock = New System.Windows.Forms.RadioButton()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.nudPeriodSlow2 = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.nudPeriodFast2 = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.nudPeriod = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.nudPeriodFast3 = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nudPeriodMid3 = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rdoSMA3 = New System.Windows.Forms.RadioButton()
        Me.rdoSMA2 = New System.Windows.Forms.RadioButton()
        Me.rdoSMA = New System.Windows.Forms.RadioButton()
        Me.nudPeriodSlow3 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSymbolShortName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_StartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtp_EndDate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TChart1 = New Steema.TeeChart.TChart()
        Me.Axis1 = New Steema.TeeChart.Axis(Me.components)
        Me.Axis2 = New Steema.TeeChart.Axis(Me.components)
        Me.Axis3 = New Steema.TeeChart.Axis(Me.components)
        Me.Candle1 = New Steema.TeeChart.Styles.Candle()
        Me.Volume1 = New Steema.TeeChart.Styles.Volume()
        Me.Line1 = New Steema.TeeChart.Styles.Line()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.nudPeriodSlow2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPeriodFast2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPeriodFast3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPeriodMid3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPeriodSlow3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtSymbol_)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.Button8)
        Me.GroupBox1.Controls.Add(Me.ComboBox2)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.nudPeriodSlow2)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.nudPeriodFast2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.nudPeriod)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.nudPeriodFast3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.nudPeriodMid3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.rdoSMA3)
        Me.GroupBox1.Controls.Add(Me.rdoSMA2)
        Me.GroupBox1.Controls.Add(Me.rdoSMA)
        Me.GroupBox1.Controls.Add(Me.nudPeriodSlow3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtSymbolShortName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtp_StartDate)
        Me.GroupBox1.Controls.Add(Me.dtp_EndDate)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(312, 594)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "选择"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(18, 123)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 14)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "证券名称"
        '
        'txtSymbol_
        '
        Me.txtSymbol_.FormattingEnabled = True
        Me.txtSymbol_.Location = New System.Drawing.Point(92, 84)
        Me.txtSymbol_.Name = "txtSymbol_"
        Me.txtSymbol_.Size = New System.Drawing.Size(199, 22)
        Me.txtSymbol_.TabIndex = 40
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rbtBond)
        Me.GroupBox5.Controls.Add(Me.rbtFund)
        Me.GroupBox5.Controls.Add(Me.rbtIndex)
        Me.GroupBox5.Controls.Add(Me.rbtStock)
        Me.GroupBox5.Location = New System.Drawing.Point(17, 14)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(280, 60)
        Me.GroupBox5.TabIndex = 39
        Me.GroupBox5.TabStop = False
        '
        'rbtBond
        '
        Me.rbtBond.AutoSize = True
        Me.rbtBond.Location = New System.Drawing.Point(179, 22)
        Me.rbtBond.Name = "rbtBond"
        Me.rbtBond.Size = New System.Drawing.Size(54, 18)
        Me.rbtBond.TabIndex = 3
        Me.rbtBond.Text = "债券"
        Me.rbtBond.UseVisualStyleBackColor = True
        '
        'rbtFund
        '
        Me.rbtFund.AutoSize = True
        Me.rbtFund.Location = New System.Drawing.Point(123, 23)
        Me.rbtFund.Name = "rbtFund"
        Me.rbtFund.Size = New System.Drawing.Size(54, 18)
        Me.rbtFund.TabIndex = 2
        Me.rbtFund.Text = "基金"
        Me.rbtFund.UseVisualStyleBackColor = True
        '
        'rbtIndex
        '
        Me.rbtIndex.AutoSize = True
        Me.rbtIndex.Location = New System.Drawing.Point(68, 22)
        Me.rbtIndex.Name = "rbtIndex"
        Me.rbtIndex.Size = New System.Drawing.Size(54, 18)
        Me.rbtIndex.TabIndex = 1
        Me.rbtIndex.Text = "指数"
        Me.rbtIndex.UseVisualStyleBackColor = True
        '
        'rbtStock
        '
        Me.rbtStock.AutoSize = True
        Me.rbtStock.Checked = True
        Me.rbtStock.Location = New System.Drawing.Point(7, 23)
        Me.rbtStock.Name = "rbtStock"
        Me.rbtStock.Size = New System.Drawing.Size(54, 18)
        Me.rbtStock.TabIndex = 0
        Me.rbtStock.TabStop = True
        Me.rbtStock.Text = "股票"
        Me.rbtStock.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(169, 534)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(123, 46)
        Me.Button8.TabIndex = 38
        Me.Button8.Text = "导出数据"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(92, 272)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(139, 22)
        Me.ComboBox2.TabIndex = 37
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 274)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 14)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "数据周期"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 235)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 14)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "蜡烛图形式"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(92, 231)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(139, 22)
        Me.ComboBox1.TabIndex = 34
        '
        'nudPeriodSlow2
        '
        Me.nudPeriodSlow2.Location = New System.Drawing.Point(244, 405)
        Me.nudPeriodSlow2.Name = "nudPeriodSlow2"
        Me.nudPeriodSlow2.Size = New System.Drawing.Size(54, 23)
        Me.nudPeriodSlow2.TabIndex = 33
        Me.nudPeriodSlow2.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(147, 377)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 14)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "均线Fast周期"
        '
        'nudPeriodFast2
        '
        Me.nudPeriodFast2.Location = New System.Drawing.Point(244, 375)
        Me.nudPeriodFast2.Name = "nudPeriodFast2"
        Me.nudPeriodFast2.Size = New System.Drawing.Size(54, 23)
        Me.nudPeriodFast2.TabIndex = 31
        Me.nudPeriodFast2.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(147, 407)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 14)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "均线Slow周期"
        '
        'nudPeriod
        '
        Me.nudPeriod.Location = New System.Drawing.Point(244, 341)
        Me.nudPeriod.Name = "nudPeriod"
        Me.nudPeriod.Size = New System.Drawing.Size(54, 23)
        Me.nudPeriod.TabIndex = 29
        Me.nudPeriod.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(147, 345)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 14)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "均线周期"
        '
        'nudPeriodFast3
        '
        Me.nudPeriodFast3.Location = New System.Drawing.Point(244, 438)
        Me.nudPeriodFast3.Name = "nudPeriodFast3"
        Me.nudPeriodFast3.Size = New System.Drawing.Size(54, 23)
        Me.nudPeriodFast3.TabIndex = 27
        Me.nudPeriodFast3.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(142, 447)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 14)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "均线Fast周期"
        '
        'nudPeriodMid3
        '
        Me.nudPeriodMid3.Location = New System.Drawing.Point(244, 463)
        Me.nudPeriodMid3.Name = "nudPeriodMid3"
        Me.nudPeriodMid3.Size = New System.Drawing.Size(54, 23)
        Me.nudPeriodMid3.TabIndex = 25
        Me.nudPeriodMid3.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(147, 468)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 14)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "均线Mid周期"
        '
        'rdoSMA3
        '
        Me.rdoSMA3.AutoSize = True
        Me.rdoSMA3.Location = New System.Drawing.Point(19, 438)
        Me.rdoSMA3.Name = "rdoSMA3"
        Me.rdoSMA3.Size = New System.Drawing.Size(68, 18)
        Me.rdoSMA3.TabIndex = 23
        Me.rdoSMA3.Text = "三均线"
        Me.rdoSMA3.UseVisualStyleBackColor = True
        '
        'rdoSMA2
        '
        Me.rdoSMA2.AutoSize = True
        Me.rdoSMA2.Location = New System.Drawing.Point(19, 387)
        Me.rdoSMA2.Name = "rdoSMA2"
        Me.rdoSMA2.Size = New System.Drawing.Size(68, 18)
        Me.rdoSMA2.TabIndex = 22
        Me.rdoSMA2.Text = "双均线"
        Me.rdoSMA2.UseVisualStyleBackColor = True
        '
        'rdoSMA
        '
        Me.rdoSMA.AutoSize = True
        Me.rdoSMA.Checked = True
        Me.rdoSMA.Location = New System.Drawing.Point(19, 341)
        Me.rdoSMA.Name = "rdoSMA"
        Me.rdoSMA.Size = New System.Drawing.Size(68, 18)
        Me.rdoSMA.TabIndex = 21
        Me.rdoSMA.TabStop = True
        Me.rdoSMA.Text = "单均线"
        Me.rdoSMA.UseVisualStyleBackColor = True
        '
        'nudPeriodSlow3
        '
        Me.nudPeriodSlow3.Location = New System.Drawing.Point(244, 490)
        Me.nudPeriodSlow3.Name = "nudPeriodSlow3"
        Me.nudPeriodSlow3.Size = New System.Drawing.Size(54, 23)
        Me.nudPeriodSlow3.TabIndex = 20
        Me.nudPeriodSlow3.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(142, 492)
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
        Me.CheckBox2.Location = New System.Drawing.Point(150, 306)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(83, 18)
        Me.CheckBox2.TabIndex = 18
        Me.CheckBox2.Text = "显示均线"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(21, 534)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(123, 46)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "显示数据"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(19, 306)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(69, 18)
        Me.CheckBox1.TabIndex = 16
        Me.CheckBox1.Text = "前复权"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 14)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "证券代码"
        '
        'txtSymbolShortName
        '
        Me.txtSymbolShortName.Location = New System.Drawing.Point(92, 120)
        Me.txtSymbolShortName.Name = "txtSymbolShortName"
        Me.txtSymbolShortName.Size = New System.Drawing.Size(199, 23)
        Me.txtSymbolShortName.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 196)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 14)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "结束时间"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 157)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 14)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "起始时间"
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.Location = New System.Drawing.Point(92, 154)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(200, 23)
        Me.dtp_StartDate.TabIndex = 9
        '
        'dtp_EndDate
        '
        Me.dtp_EndDate.Location = New System.Drawing.Point(92, 194)
        Me.dtp_EndDate.Name = "dtp_EndDate"
        Me.dtp_EndDate.Size = New System.Drawing.Size(200, 23)
        Me.dtp_EndDate.TabIndex = 10
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.ListBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(26, 630)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(312, 184)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "指标"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(169, 112)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(123, 25)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "修改参数"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(169, 35)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(123, 25)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "显示指标"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 14
        Me.ListBox1.Location = New System.Drawing.Point(19, 35)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 102)
        Me.ListBox1.TabIndex = 7
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button7)
        Me.GroupBox3.Controls.Add(Me.Button6)
        Me.GroupBox3.Controls.Add(Me.ListBox2)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.Button5)
        Me.GroupBox3.Location = New System.Drawing.Point(26, 833)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(312, 194)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "策略"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(168, 73)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(123, 25)
        Me.Button7.TabIndex = 15
        Me.Button7.Text = "隐藏策略信号"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(170, 143)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(121, 23)
        Me.Button6.TabIndex = 14
        Me.Button6.Text = "单策略回溯测试"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 14
        Me.ListBox2.Location = New System.Drawing.Point(19, 38)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(120, 130)
        Me.ListBox2.TabIndex = 13
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(168, 108)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(123, 25)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "修改参数"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(170, 38)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(123, 25)
        Me.Button5.TabIndex = 11
        Me.Button5.Text = "显示策略信号"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.DataGridView2)
        Me.GroupBox4.Controls.Add(Me.DataGridView1)
        Me.GroupBox4.Location = New System.Drawing.Point(388, 1053)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1105, 182)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "回溯测试"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(766, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 14)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "盈亏一览"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(235, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 14)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "订单一览"
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(533, 32)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowTemplate.Height = 25
        Me.DataGridView2.Size = New System.Drawing.Size(566, 144)
        Me.DataGridView2.TabIndex = 12
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(8, 32)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 25
        Me.DataGridView1.Size = New System.Drawing.Size(508, 144)
        Me.DataGridView1.TabIndex = 11
        '
        'TChart1
        '
        '
        '
        '
        Me.TChart1.Aspect.View3D = False
        '
        '
        '
        Me.TChart1.Axes.Automatic = True
        Me.TChart1.Axes.Custom.Add(Me.Axis1)
        Me.TChart1.Axes.Custom.Add(Me.Axis2)
        Me.TChart1.Axes.Custom.Add(Me.Axis3)
        Me.TChart1.Cursor = System.Windows.Forms.Cursors.Default
        '
        '
        '
        Me.TChart1.Legend.Visible = False
        Me.TChart1.Location = New System.Drawing.Point(374, 38)
        Me.TChart1.Name = "TChart1"
        '
        '
        '
        Me.TChart1.Panel.MarginLeft = 5.0R
        Me.TChart1.Panel.MarginRight = 1.0R
        Me.TChart1.Panel.MarginTop = 3.0R
        Me.TChart1.Series.Add(Me.Candle1)
        Me.TChart1.Series.Add(Me.Volume1)
        Me.TChart1.Series.Add(Me.Line1)
        Me.TChart1.Size = New System.Drawing.Size(1119, 989)
        Me.TChart1.TabIndex = 13
        '
        'Axis1
        '
        Me.Axis1.EndPosition = 58.0R
        Me.Axis1.Horizontal = False
        Me.Axis1.OtherSide = False
        '
        'Axis2
        '
        Me.Axis2.EndPosition = 78.0R
        Me.Axis2.Horizontal = False
        Me.Axis2.OtherSide = False
        Me.Axis2.StartPosition = 60.0R
        '
        'Axis3
        '
        Me.Axis3.Horizontal = False
        Me.Axis3.OtherSide = False
        Me.Axis3.StartPosition = 80.0R
        '
        'Candle1
        '
        '
        '
        '
        Me.Candle1.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Candle1.CloseValues = Me.Candle1.YValues
        Me.Candle1.Color = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.Candle1.ColorEach = False
        Me.Candle1.CustomVertAxis = Me.Axis1
        Me.Candle1.DateValues = Me.Candle1.XValues
        Me.Candle1.DownCloseColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Candle1.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(98, Byte), Integer))
        '
        '
        '
        Me.Candle1.Marks.Style = Steema.TeeChart.Styles.MarksStyles.Value
        Me.Candle1.OriginalCursor = System.Windows.Forms.Cursors.Default
        '
        '
        '
        Me.Candle1.Pointer.Draw3D = False
        Me.Candle1.Pointer.SizeDouble = 0.0R
        Me.Candle1.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Candle1.RecalcOptions = CType((((Steema.TeeChart.Styles.RecalcOptions.OnDelete Or Steema.TeeChart.Styles.RecalcOptions.OnModify) _
            Or Steema.TeeChart.Styles.RecalcOptions.OnInsert) _
            Or Steema.TeeChart.Styles.RecalcOptions.OnClear), Steema.TeeChart.Styles.RecalcOptions)
        Me.Candle1.Title = "candle1"
        Me.Candle1.UpCloseColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Candle1.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Custom
        '
        '
        '
        Me.Candle1.XValues.DataMember = "Date"
        '
        '
        '
        Me.Candle1.YValues.DataMember = "Close"
        '
        'Volume1
        '
        '
        '
        '
        Me.Volume1.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Volume1.ClickableLine = False
        Me.Volume1.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Volume1.ColorEach = False
        Me.Volume1.CustomVertAxis = Me.Axis2
        '
        '
        '
        Me.Volume1.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Volume1.LinePen.Width = 3
        Me.Volume1.OriginalCursor = System.Windows.Forms.Cursors.Default
        '
        '
        '
        Me.Volume1.Pointer.SizeDouble = 0.0R
        Me.Volume1.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Volume1.RecalcOptions = CType((((Steema.TeeChart.Styles.RecalcOptions.OnDelete Or Steema.TeeChart.Styles.RecalcOptions.OnModify) _
            Or Steema.TeeChart.Styles.RecalcOptions.OnInsert) _
            Or Steema.TeeChart.Styles.RecalcOptions.OnClear), Steema.TeeChart.Styles.RecalcOptions)
        Me.Volume1.Title = "volume1"
        Me.Volume1.UseOrigin = True
        Me.Volume1.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Custom
        '
        '
        '
        Me.Volume1.XValues.DataMember = "X"
        Me.Volume1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        '
        '
        Me.Volume1.YValues.DataMember = "Y"
        '
        'Line1
        '
        '
        '
        '
        Me.Line1.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Line1.Color = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Line1.ColorEach = False
        Me.Line1.CustomVertAxis = Me.Axis3
        '
        '
        '
        Me.Line1.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.Line1.OriginalCursor = System.Windows.Forms.Cursors.Default
        '
        '
        '
        Me.Line1.Pointer.SizeDouble = 0.0R
        Me.Line1.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Line1.RecalcOptions = CType((((Steema.TeeChart.Styles.RecalcOptions.OnDelete Or Steema.TeeChart.Styles.RecalcOptions.OnModify) _
            Or Steema.TeeChart.Styles.RecalcOptions.OnInsert) _
            Or Steema.TeeChart.Styles.RecalcOptions.OnClear), Steema.TeeChart.Styles.RecalcOptions)
        Me.Line1.Title = "line1"
        Me.Line1.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Custom
        '
        '
        '
        Me.Line1.XValues.DataMember = "X"
        Me.Line1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        '
        '
        Me.Line1.YValues.DataMember = "Y"
        '
        'frmDataView_HistoryData
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1808, 1263)
        Me.Controls.Add(Me.TChart1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmDataView_HistoryData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "行情"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.nudPeriodSlow2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPeriodFast2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPeriodFast3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPeriodMid3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPeriodSlow3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents nudPeriodSlow2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents nudPeriodFast2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents nudPeriod As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nudPeriodFast3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nudPeriodMid3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rdoSMA3 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSMA2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSMA As System.Windows.Forms.RadioButton
    Friend WithEvents nudPeriodSlow3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSymbolShortName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_StartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_EndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TChart1 As Steema.TeeChart.TChart
    Friend WithEvents Axis1 As Steema.TeeChart.Axis
    Friend WithEvents Axis2 As Steema.TeeChart.Axis
    Friend WithEvents Axis3 As Steema.TeeChart.Axis
    Friend WithEvents Candle1 As Steema.TeeChart.Styles.Candle
    Friend WithEvents Volume1 As Steema.TeeChart.Styles.Volume
    Friend WithEvents Line1 As Steema.TeeChart.Styles.Line
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtBond As System.Windows.Forms.RadioButton
    Friend WithEvents rbtFund As System.Windows.Forms.RadioButton
    Friend WithEvents rbtIndex As System.Windows.Forms.RadioButton
    Friend WithEvents rbtStock As System.Windows.Forms.RadioButton
    Friend WithEvents txtSymbol_ As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
