<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_IDCMA
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
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txt_Input = New System.Windows.Forms.TextBox()
        Me.txt_Output1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_Code1 = New System.Windows.Forms.TextBox()
        Me.txt_Output2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_Output3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_Output4 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_Output6 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_Output5 = New System.Windows.Forms.TextBox()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtp_StartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtp_EndDate = New System.Windows.Forms.DateTimePicker()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.nudPeriod = New System.Windows.Forms.NumericUpDown()
        Me.dgvAverage = New System.Windows.Forms.DataGridView()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAverage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 432)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(131, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "均线计算_old"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txt_Input
        '
        Me.txt_Input.Location = New System.Drawing.Point(175, 60)
        Me.txt_Input.Multiline = True
        Me.txt_Input.Name = "txt_Input"
        Me.txt_Input.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_Input.Size = New System.Drawing.Size(139, 395)
        Me.txt_Input.TabIndex = 1
        '
        'txt_Output1
        '
        Me.txt_Output1.Location = New System.Drawing.Point(341, 60)
        Me.txt_Output1.Multiline = True
        Me.txt_Output1.Name = "txt_Output1"
        Me.txt_Output1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_Output1.Size = New System.Drawing.Size(111, 395)
        Me.txt_Output1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(218, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "日线数据"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(366, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "输出值_3日"
        '
        'txt_Code1
        '
        Me.txt_Code1.Location = New System.Drawing.Point(69, 131)
        Me.txt_Code1.Name = "txt_Code1"
        Me.txt_Code1.Size = New System.Drawing.Size(75, 22)
        Me.txt_Code1.TabIndex = 5
        Me.txt_Code1.Text = "002201"
        '
        'txt_Output2
        '
        Me.txt_Output2.Location = New System.Drawing.Point(475, 60)
        Me.txt_Output2.Multiline = True
        Me.txt_Output2.Name = "txt_Output2"
        Me.txt_Output2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_Output2.Size = New System.Drawing.Size(111, 395)
        Me.txt_Output2.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(492, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 14)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "输出值_7日"
        '
        'txt_Output3
        '
        Me.txt_Output3.Location = New System.Drawing.Point(603, 60)
        Me.txt_Output3.Multiline = True
        Me.txt_Output3.Name = "txt_Output3"
        Me.txt_Output3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_Output3.Size = New System.Drawing.Size(111, 395)
        Me.txt_Output3.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(618, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 14)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "输出值_15日"
        '
        'txt_Output4
        '
        Me.txt_Output4.Location = New System.Drawing.Point(731, 60)
        Me.txt_Output4.Multiline = True
        Me.txt_Output4.Name = "txt_Output4"
        Me.txt_Output4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_Output4.Size = New System.Drawing.Size(111, 395)
        Me.txt_Output4.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(747, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 14)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "输出值_30日"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(992, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 14)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "输出值_180日"
        '
        'txt_Output6
        '
        Me.txt_Output6.Location = New System.Drawing.Point(976, 60)
        Me.txt_Output6.Multiline = True
        Me.txt_Output6.Name = "txt_Output6"
        Me.txt_Output6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_Output6.Size = New System.Drawing.Size(111, 395)
        Me.txt_Output6.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(863, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 14)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "输出值_60日"
        '
        'txt_Output5
        '
        Me.txt_Output5.Location = New System.Drawing.Point(848, 60)
        Me.txt_Output5.Multiline = True
        Me.txt_Output5.Name = "txt_Output5"
        Me.txt_Output5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_Output5.Size = New System.Drawing.Size(111, 395)
        Me.txt_Output5.TabIndex = 12
        '
        'Chart1
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(603, 495)
        Me.Chart1.Name = "Chart1"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(480, 392)
        Me.Chart1.TabIndex = 16
        Me.Chart1.Text = "Chart1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(69, 175)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 22)
        Me.TextBox1.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 131)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 14)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "代码"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 175)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 14)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "名称"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(16, 495)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(131, 23)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "均线计算_new"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 294)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 14)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "结束时间"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 228)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 14)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "起始时间"
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.Location = New System.Drawing.Point(19, 245)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(125, 22)
        Me.dtp_StartDate.TabIndex = 21
        '
        'dtp_EndDate
        '
        Me.dtp_EndDate.Location = New System.Drawing.Point(19, 311)
        Me.dtp_EndDate.Name = "dtp_EndDate"
        Me.dtp_EndDate.Size = New System.Drawing.Size(128, 22)
        Me.dtp_EndDate.TabIndex = 22
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(16, 546)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(131, 23)
        Me.Button3.TabIndex = 26
        Me.Button3.Text = "均线计算_TA-Lib"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 360)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 14)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "周期"
        '
        'nudPeriod
        '
        Me.nudPeriod.Location = New System.Drawing.Point(84, 360)
        Me.nudPeriod.Name = "nudPeriod"
        Me.nudPeriod.Size = New System.Drawing.Size(63, 22)
        Me.nudPeriod.TabIndex = 29
        Me.nudPeriod.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'dgvAverage
        '
        Me.dgvAverage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAverage.Location = New System.Drawing.Point(175, 495)
        Me.dgvAverage.Name = "dgvAverage"
        Me.dgvAverage.RowTemplate.Height = 24
        Me.dgvAverage.Size = New System.Drawing.Size(411, 394)
        Me.dgvAverage.TabIndex = 30
        '
        'frm_IDCMA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 911)
        Me.Controls.Add(Me.dgvAverage)
        Me.Controls.Add(Me.nudPeriod)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dtp_StartDate)
        Me.Controls.Add(Me.dtp_EndDate)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_Output6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_Output5)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_Output4)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_Output3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_Output2)
        Me.Controls.Add(Me.txt_Code1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_Output1)
        Me.Controls.Add(Me.txt_Input)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frm_IDCMA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_Indicators"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAverage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txt_Input As System.Windows.Forms.TextBox
    Friend WithEvents txt_Output1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_Code1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Output2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_Output3 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_Output4 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_Output6 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_Output5 As System.Windows.Forms.TextBox
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtp_StartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_EndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents nudPeriod As System.Windows.Forms.NumericUpDown
    Friend WithEvents dgvAverage As System.Windows.Forms.DataGridView
End Class
