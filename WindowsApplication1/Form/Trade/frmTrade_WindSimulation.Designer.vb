<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrade_WindSimulation
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
        Me.btnLogon = New System.Windows.Forms.Button()
        Me.btnQueryCapital = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblLogonStatus = New System.Windows.Forms.Label()
        Me.btnQueryPosition = New System.Windows.Forms.Button()
        Me.btnQueryOrder = New System.Windows.Forms.Button()
        Me.btnQueryTrade = New System.Windows.Forms.Button()
        Me.btnQueryAccount = New System.Windows.Forms.Button()
        Me.dgvTrade = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbxOrderType = New System.Windows.Forms.ComboBox()
        Me.rbtSell = New System.Windows.Forms.RadioButton()
        Me.rbtBuy = New System.Windows.Forms.RadioButton()
        Me.txtVolume = New System.Windows.Forms.TextBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.txtSymbol = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOrder = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvCapital = New System.Windows.Forms.DataGridView()
        Me.dgvPosition = New System.Windows.Forms.DataGridView()
        Me.dgvOrder = New System.Windows.Forms.DataGridView()
        Me.dgvAccount = New System.Windows.Forms.DataGridView()
        Me.txtQueryResult = New System.Windows.Forms.TextBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.dgvTrade, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvCapital, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLogon
        '
        Me.btnLogon.Location = New System.Drawing.Point(48, 30)
        Me.btnLogon.Name = "btnLogon"
        Me.btnLogon.Size = New System.Drawing.Size(99, 42)
        Me.btnLogon.TabIndex = 0
        Me.btnLogon.Text = "登陆"
        Me.btnLogon.UseVisualStyleBackColor = True
        '
        'btnQueryCapital
        '
        Me.btnQueryCapital.Location = New System.Drawing.Point(26, 82)
        Me.btnQueryCapital.Name = "btnQueryCapital"
        Me.btnQueryCapital.Size = New System.Drawing.Size(99, 28)
        Me.btnQueryCapital.TabIndex = 2
        Me.btnQueryCapital.Text = "查询资金"
        Me.btnQueryCapital.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(206, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 14)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "状态:"
        '
        'lblLogonStatus
        '
        Me.lblLogonStatus.AutoSize = True
        Me.lblLogonStatus.Location = New System.Drawing.Point(277, 45)
        Me.lblLogonStatus.Name = "lblLogonStatus"
        Me.lblLogonStatus.Size = New System.Drawing.Size(49, 14)
        Me.lblLogonStatus.TabIndex = 13
        Me.lblLogonStatus.Text = "未登陆"
        '
        'btnQueryPosition
        '
        Me.btnQueryPosition.Location = New System.Drawing.Point(26, 181)
        Me.btnQueryPosition.Name = "btnQueryPosition"
        Me.btnQueryPosition.Size = New System.Drawing.Size(99, 25)
        Me.btnQueryPosition.TabIndex = 16
        Me.btnQueryPosition.Text = "查询持仓"
        Me.btnQueryPosition.UseVisualStyleBackColor = True
        '
        'btnQueryOrder
        '
        Me.btnQueryOrder.Location = New System.Drawing.Point(26, 277)
        Me.btnQueryOrder.Name = "btnQueryOrder"
        Me.btnQueryOrder.Size = New System.Drawing.Size(99, 31)
        Me.btnQueryOrder.TabIndex = 17
        Me.btnQueryOrder.Text = "查询当日委托"
        Me.btnQueryOrder.UseVisualStyleBackColor = True
        '
        'btnQueryTrade
        '
        Me.btnQueryTrade.Location = New System.Drawing.Point(26, 379)
        Me.btnQueryTrade.Name = "btnQueryTrade"
        Me.btnQueryTrade.Size = New System.Drawing.Size(99, 31)
        Me.btnQueryTrade.TabIndex = 18
        Me.btnQueryTrade.Text = "查询当日成交"
        Me.btnQueryTrade.UseVisualStyleBackColor = True
        '
        'btnQueryAccount
        '
        Me.btnQueryAccount.Location = New System.Drawing.Point(26, 481)
        Me.btnQueryAccount.Name = "btnQueryAccount"
        Me.btnQueryAccount.Size = New System.Drawing.Size(99, 31)
        Me.btnQueryAccount.TabIndex = 19
        Me.btnQueryAccount.Text = "查询股东账户"
        Me.btnQueryAccount.UseVisualStyleBackColor = True
        '
        'dgvTrade
        '
        Me.dgvTrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTrade.Location = New System.Drawing.Point(156, 341)
        Me.dgvTrade.Name = "dgvTrade"
        Me.dgvTrade.RowTemplate.Height = 24
        Me.dgvTrade.Size = New System.Drawing.Size(1073, 87)
        Me.dgvTrade.TabIndex = 20
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cbxOrderType)
        Me.GroupBox1.Controls.Add(Me.rbtSell)
        Me.GroupBox1.Controls.Add(Me.rbtBuy)
        Me.GroupBox1.Controls.Add(Me.txtVolume)
        Me.GroupBox1.Controls.Add(Me.txtPrice)
        Me.GroupBox1.Controls.Add(Me.txtSymbol)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnOrder)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 105)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1238, 160)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "下单栏"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(402, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 14)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "买入类型"
        '
        'cbxOrderType
        '
        Me.cbxOrderType.FormattingEnabled = True
        Me.cbxOrderType.Location = New System.Drawing.Point(471, 37)
        Me.cbxOrderType.Name = "cbxOrderType"
        Me.cbxOrderType.Size = New System.Drawing.Size(121, 21)
        Me.cbxOrderType.TabIndex = 25
        '
        'rbtSell
        '
        Me.rbtSell.AutoSize = True
        Me.rbtSell.Location = New System.Drawing.Point(86, 91)
        Me.rbtSell.Name = "rbtSell"
        Me.rbtSell.Size = New System.Drawing.Size(54, 18)
        Me.rbtSell.TabIndex = 24
        Me.rbtSell.Text = "卖出"
        Me.rbtSell.UseVisualStyleBackColor = True
        '
        'rbtBuy
        '
        Me.rbtBuy.AutoSize = True
        Me.rbtBuy.Checked = True
        Me.rbtBuy.Location = New System.Drawing.Point(26, 90)
        Me.rbtBuy.Name = "rbtBuy"
        Me.rbtBuy.Size = New System.Drawing.Size(54, 18)
        Me.rbtBuy.TabIndex = 23
        Me.rbtBuy.TabStop = True
        Me.rbtBuy.Text = "买入"
        Me.rbtBuy.UseVisualStyleBackColor = True
        '
        'txtVolume
        '
        Me.txtVolume.Location = New System.Drawing.Point(244, 133)
        Me.txtVolume.Name = "txtVolume"
        Me.txtVolume.Size = New System.Drawing.Size(100, 22)
        Me.txtVolume.TabIndex = 22
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(244, 87)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(100, 22)
        Me.txtPrice.TabIndex = 21
        '
        'txtSymbol
        '
        Me.txtSymbol.Location = New System.Drawing.Point(244, 41)
        Me.txtSymbol.Name = "txtSymbol"
        Me.txtSymbol.Size = New System.Drawing.Size(100, 22)
        Me.txtSymbol.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(170, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 14)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "下单量"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(170, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 14)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "证券价格"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(170, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 14)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "证券名称"
        '
        'btnOrder
        '
        Me.btnOrder.Location = New System.Drawing.Point(26, 31)
        Me.btnOrder.Name = "btnOrder"
        Me.btnOrder.Size = New System.Drawing.Size(99, 39)
        Me.btnOrder.TabIndex = 16
        Me.btnOrder.Text = "下单"
        Me.btnOrder.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvCapital)
        Me.GroupBox2.Controls.Add(Me.dgvPosition)
        Me.GroupBox2.Controls.Add(Me.dgvOrder)
        Me.GroupBox2.Controls.Add(Me.dgvAccount)
        Me.GroupBox2.Controls.Add(Me.btnQueryAccount)
        Me.GroupBox2.Controls.Add(Me.dgvTrade)
        Me.GroupBox2.Controls.Add(Me.btnQueryCapital)
        Me.GroupBox2.Controls.Add(Me.btnQueryPosition)
        Me.GroupBox2.Controls.Add(Me.btnQueryTrade)
        Me.GroupBox2.Controls.Add(Me.btnQueryOrder)
        Me.GroupBox2.Location = New System.Drawing.Point(22, 287)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1238, 544)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "状态"
        '
        'dgvCapital
        '
        Me.dgvCapital.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCapital.Location = New System.Drawing.Point(156, 62)
        Me.dgvCapital.Name = "dgvCapital"
        Me.dgvCapital.RowTemplate.Height = 24
        Me.dgvCapital.Size = New System.Drawing.Size(1073, 87)
        Me.dgvCapital.TabIndex = 24
        '
        'dgvPosition
        '
        Me.dgvPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPosition.Location = New System.Drawing.Point(156, 155)
        Me.dgvPosition.Name = "dgvPosition"
        Me.dgvPosition.RowTemplate.Height = 24
        Me.dgvPosition.Size = New System.Drawing.Size(1073, 87)
        Me.dgvPosition.TabIndex = 23
        '
        'dgvOrder
        '
        Me.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrder.Location = New System.Drawing.Point(156, 248)
        Me.dgvOrder.Name = "dgvOrder"
        Me.dgvOrder.RowTemplate.Height = 24
        Me.dgvOrder.Size = New System.Drawing.Size(1073, 87)
        Me.dgvOrder.TabIndex = 22
        '
        'dgvAccount
        '
        Me.dgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAccount.Location = New System.Drawing.Point(156, 434)
        Me.dgvAccount.Name = "dgvAccount"
        Me.dgvAccount.RowTemplate.Height = 24
        Me.dgvAccount.Size = New System.Drawing.Size(1073, 96)
        Me.dgvAccount.TabIndex = 21
        '
        'txtQueryResult
        '
        Me.txtQueryResult.Location = New System.Drawing.Point(22, 837)
        Me.txtQueryResult.Multiline = True
        Me.txtQueryResult.Name = "txtQueryResult"
        Me.txtQueryResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQueryResult.Size = New System.Drawing.Size(1238, 84)
        Me.txtQueryResult.TabIndex = 28
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'frmTrade_WindSimulation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 933)
        Me.Controls.Add(Me.txtQueryResult)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblLogonStatus)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnLogon)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmTrade_WindSimulation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmTrade_WindSimulation"
        CType(Me.dgvTrade, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvCapital, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPosition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAccount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLogon As System.Windows.Forms.Button
    Friend WithEvents btnQueryCapital As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblLogonStatus As System.Windows.Forms.Label
    Friend WithEvents btnQueryPosition As System.Windows.Forms.Button
    Friend WithEvents btnQueryOrder As System.Windows.Forms.Button
    Friend WithEvents btnQueryTrade As System.Windows.Forms.Button
    Friend WithEvents btnQueryAccount As System.Windows.Forms.Button
    Friend WithEvents dgvTrade As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbxOrderType As System.Windows.Forms.ComboBox
    Friend WithEvents rbtSell As System.Windows.Forms.RadioButton
    Friend WithEvents rbtBuy As System.Windows.Forms.RadioButton
    Friend WithEvents txtVolume As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtSymbol As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOrder As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPosition As System.Windows.Forms.DataGridView
    Friend WithEvents dgvOrder As System.Windows.Forms.DataGridView
    Friend WithEvents dgvAccount As System.Windows.Forms.DataGridView
    Friend WithEvents dgvCapital As System.Windows.Forms.DataGridView
    Friend WithEvents txtQueryResult As System.Windows.Forms.TextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
