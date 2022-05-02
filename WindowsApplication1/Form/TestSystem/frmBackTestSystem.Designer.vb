<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackTestSystem
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.lbStrategy = New System.Windows.Forms.ListBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbSymbolList = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_StartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtp_EndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboPerformanceReport = New System.Windows.Forms.ComboBox()
        Me.rtbLogbook = New System.Windows.Forms.RichTextBox()
        Me.cboPerformanceChart = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.TChart1 = New Steema.TeeChart.TChart()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button7)
        Me.GroupBox3.Controls.Add(Me.Button6)
        Me.GroupBox3.Controls.Add(Me.lbStrategy)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.Button5)
        Me.GroupBox3.Location = New System.Drawing.Point(29, 329)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(312, 194)
        Me.GroupBox3.TabIndex = 9
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
        'lbStrategy
        '
        Me.lbStrategy.FormattingEnabled = True
        Me.lbStrategy.ItemHeight = 14
        Me.lbStrategy.Location = New System.Drawing.Point(19, 38)
        Me.lbStrategy.Name = "lbStrategy"
        Me.lbStrategy.Size = New System.Drawing.Size(120, 130)
        Me.lbStrategy.TabIndex = 13
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lbSymbolList)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtp_StartDate)
        Me.GroupBox1.Controls.Add(Me.dtp_EndDate)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(312, 285)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(93, 142)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(198, 23)
        Me.TextBox1.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 145)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 14)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Benchmark"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 14)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "证券代码"
        '
        'lbSymbolList
        '
        Me.lbSymbolList.FormattingEnabled = True
        Me.lbSymbolList.ItemHeight = 14
        Me.lbSymbolList.Location = New System.Drawing.Point(93, 22)
        Me.lbSymbolList.Name = "lbSymbolList"
        Me.lbSymbolList.Size = New System.Drawing.Size(198, 102)
        Me.lbSymbolList.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 222)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 14)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "结束时间"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 183)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 14)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "起始时间"
        '
        'dtp_StartDate
        '
        Me.dtp_StartDate.Location = New System.Drawing.Point(93, 180)
        Me.dtp_StartDate.Name = "dtp_StartDate"
        Me.dtp_StartDate.Size = New System.Drawing.Size(200, 23)
        Me.dtp_StartDate.TabIndex = 13
        '
        'dtp_EndDate
        '
        Me.dtp_EndDate.Location = New System.Drawing.Point(93, 220)
        Me.dtp_EndDate.Name = "dtp_EndDate"
        Me.dtp_EndDate.Size = New System.Drawing.Size(200, 23)
        Me.dtp_EndDate.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1285, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 14)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "测试报告"
        '
        'cboPerformanceReport
        '
        Me.cboPerformanceReport.FormattingEnabled = True
        Me.cboPerformanceReport.Location = New System.Drawing.Point(1360, 9)
        Me.cboPerformanceReport.Name = "cboPerformanceReport"
        Me.cboPerformanceReport.Size = New System.Drawing.Size(135, 22)
        Me.cboPerformanceReport.TabIndex = 20
        '
        'rtbLogbook
        '
        Me.rtbLogbook.Location = New System.Drawing.Point(360, 557)
        Me.rtbLogbook.Name = "rtbLogbook"
        Me.rtbLogbook.Size = New System.Drawing.Size(638, 310)
        Me.rtbLogbook.TabIndex = 21
        Me.rtbLogbook.Text = ""
        '
        'cboPerformanceChart
        '
        Me.cboPerformanceChart.FormattingEnabled = True
        Me.cboPerformanceChart.Location = New System.Drawing.Point(843, 35)
        Me.cboPerformanceChart.Name = "cboPerformanceChart"
        Me.cboPerformanceChart.Size = New System.Drawing.Size(155, 22)
        Me.cboPerformanceChart.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(357, 540)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 14)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "LogBook"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(29, 545)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(115, 45)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = "执行测试"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(226, 545)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(115, 45)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "停止测试"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(463, 800)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "交易分析"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.RichTextBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(463, 800)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "回报总结"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(6, 6)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(454, 788)
        Me.RichTextBox1.TabIndex = 13
        Me.RichTextBox1.Text = ""
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(1020, 38)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(471, 828)
        Me.TabControl1.TabIndex = 28
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(463, 800)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "交易清单"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 24)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(463, 800)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "周期回报"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Location = New System.Drawing.Point(4, 24)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(463, 800)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "策略设置"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage6)
        Me.TabControl2.Controls.Add(Me.TabPage7)
        Me.TabControl2.Location = New System.Drawing.Point(364, 68)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(634, 455)
        Me.TabControl2.TabIndex = 29
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.TChart1)
        Me.TabPage6.Location = New System.Drawing.Point(4, 24)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(626, 427)
        Me.TabPage6.TabIndex = 0
        Me.TabPage6.Text = "回报性能图"
        Me.TabPage6.UseVisualStyleBackColor = True
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
        Me.TChart1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TChart1.Location = New System.Drawing.Point(4, 6)
        Me.TChart1.Name = "TChart1"
        Me.TChart1.Size = New System.Drawing.Size(620, 418)
        Me.TChart1.TabIndex = 12
        '
        'TabPage7
        '
        Me.TabPage7.Location = New System.Drawing.Point(4, 24)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(626, 427)
        Me.TabPage7.TabIndex = 1
        Me.TabPage7.Text = "交易分析图"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'frmBackTestSystem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1507, 878)
        Me.Controls.Add(Me.TabControl2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboPerformanceChart)
        Me.Controls.Add(Me.rtbLogbook)
        Me.Controls.Add(Me.cboPerformanceReport)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "frmBackTestSystem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BackTestSystem"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents lbStrategy As System.Windows.Forms.ListBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_StartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_EndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbSymbolList As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboPerformanceReport As System.Windows.Forms.ComboBox
    Friend WithEvents rtbLogbook As System.Windows.Forms.RichTextBox
    Friend WithEvents cboPerformanceChart As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents TChart1 As Steema.TeeChart.TChart
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
End Class
