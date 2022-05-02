<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_TSAverage
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
        Me.lblStrategyName = New System.Windows.Forms.Label()
        Me.rtxt1 = New System.Windows.Forms.RichTextBox()
        Me.rtxt2 = New System.Windows.Forms.RichTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txt_Code3 = New System.Windows.Forms.TextBox()
        Me.txt_Code2 = New System.Windows.Forms.TextBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_Numbers = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtp_StartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtp_EndDate = New System.Windows.Forms.DateTimePicker()
        Me.txt_Code1 = New System.Windows.Forms.TextBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.labAllStocks = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Numbers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblStrategyName
        '
        Me.lblStrategyName.AutoSize = True
        Me.lblStrategyName.Font = New System.Drawing.Font("宋体", 16.30189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblStrategyName.Location = New System.Drawing.Point(12, 24)
        Me.lblStrategyName.Name = "lblStrategyName"
        Me.lblStrategyName.Size = New System.Drawing.Size(187, 25)
        Me.lblStrategyName.TabIndex = 25
        Me.lblStrategyName.Text = "移动均线法策略"
        '
        'rtxt1
        '
        Me.rtxt1.Location = New System.Drawing.Point(28, 21)
        Me.rtxt1.Name = "rtxt1"
        Me.rtxt1.Size = New System.Drawing.Size(635, 206)
        Me.rtxt1.TabIndex = 8
        Me.rtxt1.Text = ""
        '
        'rtxt2
        '
        Me.rtxt2.Location = New System.Drawing.Point(27, 366)
        Me.rtxt2.Name = "rtxt2"
        Me.rtxt2.Size = New System.Drawing.Size(635, 199)
        Me.rtxt2.TabIndex = 7
        Me.rtxt2.Text = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rtxt1)
        Me.GroupBox2.Controls.Add(Me.rtxt2)
        Me.GroupBox2.Controls.Add(Me.ProgressBar1)
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Location = New System.Drawing.Point(380, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(693, 610)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "交易结果"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(28, 579)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(635, 23)
        Me.ProgressBar1.TabIndex = 6
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(28, 248)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(635, 96)
        Me.DataGridView1.TabIndex = 3
        '
        'txt_Code3
        '
        Me.txt_Code3.Location = New System.Drawing.Point(48, 309)
        Me.txt_Code3.Name = "txt_Code3"
        Me.txt_Code3.Size = New System.Drawing.Size(85, 22)
        Me.txt_Code3.TabIndex = 23
        Me.txt_Code3.Text = "300188"
        '
        'txt_Code2
        '
        Me.txt_Code2.Location = New System.Drawing.Point(48, 274)
        Me.txt_Code2.Name = "txt_Code2"
        Me.txt_Code2.Size = New System.Drawing.Size(85, 22)
        Me.txt_Code2.TabIndex = 22
        Me.txt_Code2.Text = "000547"
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(11, 312)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(16, 15)
        Me.CheckBox3.TabIndex = 21
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(11, 276)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(16, 15)
        Me.CheckBox2.TabIndex = 20
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(11, 240)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(16, 15)
        Me.CheckBox1.TabIndex = 19
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(11, 361)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.Size = New System.Drawing.Size(342, 201)
        Me.DataGridView2.TabIndex = 18
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(116, 595)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(114, 55)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "执行交易策略"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "结束时间"
        '
        'txt_Numbers
        '
        Me.txt_Numbers.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.txt_Numbers.Location = New System.Drawing.Point(96, 29)
        Me.txt_Numbers.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.txt_Numbers.Name = "txt_Numbers"
        Me.txt_Numbers.Size = New System.Drawing.Size(197, 22)
        Me.txt_Numbers.TabIndex = 4
        Me.txt_Numbers.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "起始时间"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "统计次数"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_Numbers)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtp_StartDate)
        Me.GroupBox1.Controls.Add(Me.dtp_EndDate)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(343, 150)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "统计条件"
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.Location = New System.Drawing.Point(96, 65)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(200, 22)
        Me.dtp_StartDate.TabIndex = 0
        '
        'dtp_EndDate
        '
        Me.dtp_EndDate.Location = New System.Drawing.Point(96, 101)
        Me.dtp_EndDate.Name = "dtp_EndDate"
        Me.dtp_EndDate.Size = New System.Drawing.Size(200, 22)
        Me.dtp_EndDate.TabIndex = 1
        '
        'txt_Code1
        '
        Me.txt_Code1.Location = New System.Drawing.Point(47, 234)
        Me.txt_Code1.Name = "txt_Code1"
        Me.txt_Code1.Size = New System.Drawing.Size(85, 22)
        Me.txt_Code1.TabIndex = 17
        Me.txt_Code1.Text = "002201"
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(168, 241)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(16, 15)
        Me.CheckBox4.TabIndex = 26
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'labAllStocks
        '
        Me.labAllStocks.AutoSize = True
        Me.labAllStocks.Location = New System.Drawing.Point(191, 241)
        Me.labAllStocks.Name = "labAllStocks"
        Me.labAllStocks.Size = New System.Drawing.Size(91, 14)
        Me.labAllStocks.TabIndex = 27
        Me.labAllStocks.Text = "所有沪深股票"
        '
        'frm_TSAverage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1090, 708)
        Me.Controls.Add(Me.labAllStocks)
        Me.Controls.Add(Me.CheckBox4)
        Me.Controls.Add(Me.lblStrategyName)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txt_Code3)
        Me.Controls.Add(Me.txt_Code2)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txt_Code1)
        Me.Name = "frm_TSAverage"
        Me.Text = "frm_TSAverage"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Numbers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblStrategyName As System.Windows.Forms.Label
    Friend WithEvents rtxt1 As System.Windows.Forms.RichTextBox
    Friend WithEvents rtxt2 As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txt_Code3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Code2 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_Numbers As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_StartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_EndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_Code1 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents labAllStocks As System.Windows.Forms.Label
End Class
