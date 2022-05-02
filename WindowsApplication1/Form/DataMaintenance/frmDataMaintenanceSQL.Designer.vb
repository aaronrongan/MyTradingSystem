<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataMaintenanceSQL
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbtStockDaily_BA = New System.Windows.Forms.RadioButton()
        Me.rbtStockDaily_FA = New System.Windows.Forms.RadioButton()
        Me.txtStockName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnGetStockFullName = New System.Windows.Forms.Button()
        Me.rbtFundDaily = New System.Windows.Forms.RadioButton()
        Me.ckbAllSymbol = New System.Windows.Forms.CheckBox()
        Me.tBlockDaily = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAskedSymbol = New System.Windows.Forms.TextBox()
        Me.rbtIndexDaily = New System.Windows.Forms.RadioButton()
        Me.rbtStockDaily = New System.Windows.Forms.RadioButton()
        Me.prgDGV = New System.Windows.Forms.ProgressBar()
        Me.prgBar = New System.Windows.Forms.ProgressBar()
        Me.btnDataImportSQL = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.dgvDataList = New System.Windows.Forms.DataGridView()
        Me.lblDGV_Total = New System.Windows.Forms.Label()
        Me.btnDataFeed_Price = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnDataInfoImportSQL = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSecurityTypeID = New System.Windows.Forms.TextBox()
        Me.rbtSecurityTypeRelation = New System.Windows.Forms.RadioButton()
        Me.txtSecuritySymbol = New System.Windows.Forms.TextBox()
        Me.rbtSecurityInfo = New System.Windows.Forms.RadioButton()
        Me.rbtSecurityType = New System.Windows.Forms.RadioButton()
        Me.rbtTradeCalendar = New System.Windows.Forms.RadioButton()
        Me.txtFundCompanyTemp = New System.Windows.Forms.TextBox()
        Me.rbtFundCompany = New System.Windows.Forms.RadioButton()
        Me.rbtFundList = New System.Windows.Forms.RadioButton()
        Me.rbtBlockList = New System.Windows.Forms.RadioButton()
        Me.rbtIndexList = New System.Windows.Forms.RadioButton()
        Me.rbtStockList = New System.Windows.Forms.RadioButton()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvDataList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtStockDaily_BA)
        Me.GroupBox2.Controls.Add(Me.rbtStockDaily_FA)
        Me.GroupBox2.Controls.Add(Me.txtStockName)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.btnGetStockFullName)
        Me.GroupBox2.Controls.Add(Me.rbtFundDaily)
        Me.GroupBox2.Controls.Add(Me.ckbAllSymbol)
        Me.GroupBox2.Controls.Add(Me.tBlockDaily)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtAskedSymbol)
        Me.GroupBox2.Controls.Add(Me.rbtIndexDaily)
        Me.GroupBox2.Controls.Add(Me.rbtStockDaily)
        Me.GroupBox2.Location = New System.Drawing.Point(26, 456)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(203, 295)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "价格信息"
        '
        'rbtStockDaily_BA
        '
        Me.rbtStockDaily_BA.AutoSize = True
        Me.rbtStockDaily_BA.Location = New System.Drawing.Point(12, 145)
        Me.rbtStockDaily_BA.Name = "rbtStockDaily_BA"
        Me.rbtStockDaily_BA.Size = New System.Drawing.Size(124, 18)
        Me.rbtStockDaily_BA.TabIndex = 33
        Me.rbtStockDaily_BA.TabStop = True
        Me.rbtStockDaily_BA.Text = "股票日线后复权"
        Me.rbtStockDaily_BA.UseVisualStyleBackColor = True
        '
        'rbtStockDaily_FA
        '
        Me.rbtStockDaily_FA.AutoSize = True
        Me.rbtStockDaily_FA.Location = New System.Drawing.Point(12, 121)
        Me.rbtStockDaily_FA.Name = "rbtStockDaily_FA"
        Me.rbtStockDaily_FA.Size = New System.Drawing.Size(124, 18)
        Me.rbtStockDaily_FA.TabIndex = 32
        Me.rbtStockDaily_FA.TabStop = True
        Me.rbtStockDaily_FA.Text = "股票日线前复权"
        Me.rbtStockDaily_FA.UseVisualStyleBackColor = True
        '
        'txtStockName
        '
        Me.txtStockName.Location = New System.Drawing.Point(82, 237)
        Me.txtStockName.Name = "txtStockName"
        Me.txtStockName.Size = New System.Drawing.Size(63, 22)
        Me.txtStockName.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 240)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 14)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "股票名称"
        '
        'btnGetStockFullName
        '
        Me.btnGetStockFullName.Location = New System.Drawing.Point(37, 266)
        Me.btnGetStockFullName.Name = "btnGetStockFullName"
        Me.btnGetStockFullName.Size = New System.Drawing.Size(75, 23)
        Me.btnGetStockFullName.TabIndex = 29
        Me.btnGetStockFullName.Text = "查询股票名称"
        Me.btnGetStockFullName.UseVisualStyleBackColor = True
        '
        'rbtFundDaily
        '
        Me.rbtFundDaily.AutoSize = True
        Me.rbtFundDaily.Location = New System.Drawing.Point(12, 73)
        Me.rbtFundDaily.Name = "rbtFundDaily"
        Me.rbtFundDaily.Size = New System.Drawing.Size(110, 18)
        Me.rbtFundDaily.TabIndex = 23
        Me.rbtFundDaily.TabStop = True
        Me.rbtFundDaily.Text = "基金日线价格"
        Me.rbtFundDaily.UseVisualStyleBackColor = True
        '
        'ckbAllSymbol
        '
        Me.ckbAllSymbol.AutoSize = True
        Me.ckbAllSymbol.Location = New System.Drawing.Point(16, 188)
        Me.ckbAllSymbol.Name = "ckbAllSymbol"
        Me.ckbAllSymbol.Size = New System.Drawing.Size(83, 18)
        Me.ckbAllSymbol.TabIndex = 28
        Me.ckbAllSymbol.Text = "所有代码"
        Me.ckbAllSymbol.UseVisualStyleBackColor = True
        '
        'tBlockDaily
        '
        Me.tBlockDaily.AutoSize = True
        Me.tBlockDaily.Location = New System.Drawing.Point(12, 48)
        Me.tBlockDaily.Name = "tBlockDaily"
        Me.tBlockDaily.Size = New System.Drawing.Size(110, 18)
        Me.tBlockDaily.TabIndex = 22
        Me.tBlockDaily.TabStop = True
        Me.tBlockDaily.Text = "板块日线价格"
        Me.tBlockDaily.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 215)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 14)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "指定代码"
        '
        'txtAskedSymbol
        '
        Me.txtAskedSymbol.Location = New System.Drawing.Point(82, 212)
        Me.txtAskedSymbol.Name = "txtAskedSymbol"
        Me.txtAskedSymbol.Size = New System.Drawing.Size(63, 22)
        Me.txtAskedSymbol.TabIndex = 26
        '
        'rbtIndexDaily
        '
        Me.rbtIndexDaily.AutoSize = True
        Me.rbtIndexDaily.Location = New System.Drawing.Point(12, 23)
        Me.rbtIndexDaily.Name = "rbtIndexDaily"
        Me.rbtIndexDaily.Size = New System.Drawing.Size(110, 18)
        Me.rbtIndexDaily.TabIndex = 21
        Me.rbtIndexDaily.TabStop = True
        Me.rbtIndexDaily.Text = "指数日线价格"
        Me.rbtIndexDaily.UseVisualStyleBackColor = True
        '
        'rbtStockDaily
        '
        Me.rbtStockDaily.AutoSize = True
        Me.rbtStockDaily.Location = New System.Drawing.Point(12, 97)
        Me.rbtStockDaily.Name = "rbtStockDaily"
        Me.rbtStockDaily.Size = New System.Drawing.Size(110, 18)
        Me.rbtStockDaily.TabIndex = 20
        Me.rbtStockDaily.TabStop = True
        Me.rbtStockDaily.Text = "股票日线价格"
        Me.rbtStockDaily.UseVisualStyleBackColor = True
        '
        'prgDGV
        '
        Me.prgDGV.Location = New System.Drawing.Point(258, 864)
        Me.prgDGV.Name = "prgDGV"
        Me.prgDGV.Size = New System.Drawing.Size(805, 23)
        Me.prgDGV.TabIndex = 32
        '
        'prgBar
        '
        Me.prgBar.Location = New System.Drawing.Point(1097, 864)
        Me.prgBar.Name = "prgBar"
        Me.prgBar.Size = New System.Drawing.Size(268, 23)
        Me.prgBar.TabIndex = 31
        '
        'btnDataImportSQL
        '
        Me.btnDataImportSQL.Location = New System.Drawing.Point(1191, 900)
        Me.btnDataImportSQL.Name = "btnDataImportSQL"
        Me.btnDataImportSQL.Size = New System.Drawing.Size(88, 36)
        Me.btnDataImportSQL.TabIndex = 30
        Me.btnDataImportSQL.Text = "数据导入"
        Me.btnDataImportSQL.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(255, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 14)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "数据列表"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1091, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 14)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "数据导入SQL结果"
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(1094, 95)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOutput.Size = New System.Drawing.Size(268, 755)
        Me.txtOutput.TabIndex = 27
        '
        'dgvDataList
        '
        Me.dgvDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDataList.Location = New System.Drawing.Point(258, 95)
        Me.dgvDataList.Name = "dgvDataList"
        Me.dgvDataList.RowTemplate.Height = 24
        Me.dgvDataList.Size = New System.Drawing.Size(805, 755)
        Me.dgvDataList.TabIndex = 26
        '
        'lblDGV_Total
        '
        Me.lblDGV_Total.AutoSize = True
        Me.lblDGV_Total.Location = New System.Drawing.Point(903, 75)
        Me.lblDGV_Total.Name = "lblDGV_Total"
        Me.lblDGV_Total.Size = New System.Drawing.Size(42, 14)
        Me.lblDGV_Total.TabIndex = 33
        Me.lblDGV_Total.Text = "Label"
        Me.lblDGV_Total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnDataFeed_Price
        '
        Me.btnDataFeed_Price.Location = New System.Drawing.Point(63, 770)
        Me.btnDataFeed_Price.Name = "btnDataFeed_Price"
        Me.btnDataFeed_Price.Size = New System.Drawing.Size(75, 23)
        Me.btnDataFeed_Price.TabIndex = 34
        Me.btnDataFeed_Price.Text = "数据更新"
        Me.btnDataFeed_Price.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(63, 817)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "合并股价"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnDataInfoImportSQL
        '
        Me.btnDataInfoImportSQL.Location = New System.Drawing.Point(85, 365)
        Me.btnDataInfoImportSQL.Name = "btnDataInfoImportSQL"
        Me.btnDataInfoImportSQL.Size = New System.Drawing.Size(77, 23)
        Me.btnDataInfoImportSQL.TabIndex = 38
        Me.btnDataInfoImportSQL.Text = "数据更新"
        Me.btnDataInfoImportSQL.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSecurityTypeID)
        Me.GroupBox1.Controls.Add(Me.rbtSecurityTypeRelation)
        Me.GroupBox1.Controls.Add(Me.txtSecuritySymbol)
        Me.GroupBox1.Controls.Add(Me.rbtSecurityInfo)
        Me.GroupBox1.Controls.Add(Me.rbtSecurityType)
        Me.GroupBox1.Controls.Add(Me.rbtTradeCalendar)
        Me.GroupBox1.Controls.Add(Me.txtFundCompanyTemp)
        Me.GroupBox1.Controls.Add(Me.rbtFundCompany)
        Me.GroupBox1.Controls.Add(Me.rbtFundList)
        Me.GroupBox1.Controls.Add(Me.rbtBlockList)
        Me.GroupBox1.Controls.Add(Me.rbtIndexList)
        Me.GroupBox1.Controls.Add(Me.rbtStockList)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 75)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(203, 270)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "列表信息"
        '
        'txtSecurityTypeID
        '
        Me.txtSecurityTypeID.Location = New System.Drawing.Point(126, 225)
        Me.txtSecurityTypeID.Name = "txtSecurityTypeID"
        Me.txtSecurityTypeID.Size = New System.Drawing.Size(63, 22)
        Me.txtSecurityTypeID.TabIndex = 34
        '
        'rbtSecurityTypeRelation
        '
        Me.rbtSecurityTypeRelation.AutoSize = True
        Me.rbtSecurityTypeRelation.Location = New System.Drawing.Point(16, 225)
        Me.rbtSecurityTypeRelation.Name = "rbtSecurityTypeRelation"
        Me.rbtSecurityTypeRelation.Size = New System.Drawing.Size(82, 18)
        Me.rbtSecurityTypeRelation.TabIndex = 33
        Me.rbtSecurityTypeRelation.TabStop = True
        Me.rbtSecurityTypeRelation.Text = "板块成分"
        Me.rbtSecurityTypeRelation.UseVisualStyleBackColor = True
        '
        'txtSecuritySymbol
        '
        Me.txtSecuritySymbol.Location = New System.Drawing.Point(128, 171)
        Me.txtSecuritySymbol.Name = "txtSecuritySymbol"
        Me.txtSecuritySymbol.Size = New System.Drawing.Size(63, 22)
        Me.txtSecuritySymbol.TabIndex = 32
        '
        'rbtSecurityInfo
        '
        Me.rbtSecurityInfo.AutoSize = True
        Me.rbtSecurityInfo.Location = New System.Drawing.Point(16, 175)
        Me.rbtSecurityInfo.Name = "rbtSecurityInfo"
        Me.rbtSecurityInfo.Size = New System.Drawing.Size(110, 18)
        Me.rbtSecurityInfo.TabIndex = 30
        Me.rbtSecurityInfo.TabStop = True
        Me.rbtSecurityInfo.Text = "证券个股信息"
        Me.rbtSecurityInfo.UseVisualStyleBackColor = True
        '
        'rbtSecurityType
        '
        Me.rbtSecurityType.AutoSize = True
        Me.rbtSecurityType.Location = New System.Drawing.Point(16, 200)
        Me.rbtSecurityType.Name = "rbtSecurityType"
        Me.rbtSecurityType.Size = New System.Drawing.Size(82, 18)
        Me.rbtSecurityType.TabIndex = 29
        Me.rbtSecurityType.TabStop = True
        Me.rbtSecurityType.Text = "板块列表"
        Me.rbtSecurityType.UseVisualStyleBackColor = True
        '
        'rbtTradeCalendar
        '
        Me.rbtTradeCalendar.AutoSize = True
        Me.rbtTradeCalendar.Location = New System.Drawing.Point(16, 153)
        Me.rbtTradeCalendar.Name = "rbtTradeCalendar"
        Me.rbtTradeCalendar.Size = New System.Drawing.Size(110, 18)
        Me.rbtTradeCalendar.TabIndex = 28
        Me.rbtTradeCalendar.TabStop = True
        Me.rbtTradeCalendar.Text = "股市交易日历"
        Me.rbtTradeCalendar.UseVisualStyleBackColor = True
        '
        'txtFundCompanyTemp
        '
        Me.txtFundCompanyTemp.Location = New System.Drawing.Point(128, 125)
        Me.txtFundCompanyTemp.Name = "txtFundCompanyTemp"
        Me.txtFundCompanyTemp.Size = New System.Drawing.Size(63, 22)
        Me.txtFundCompanyTemp.TabIndex = 27
        '
        'rbtFundCompany
        '
        Me.rbtFundCompany.AutoSize = True
        Me.rbtFundCompany.Location = New System.Drawing.Point(16, 103)
        Me.rbtFundCompany.Name = "rbtFundCompany"
        Me.rbtFundCompany.Size = New System.Drawing.Size(110, 18)
        Me.rbtFundCompany.TabIndex = 22
        Me.rbtFundCompany.TabStop = True
        Me.rbtFundCompany.Text = "基金公司列表"
        Me.rbtFundCompany.UseVisualStyleBackColor = True
        '
        'rbtFundList
        '
        Me.rbtFundList.AutoSize = True
        Me.rbtFundList.Location = New System.Drawing.Point(16, 129)
        Me.rbtFundList.Name = "rbtFundList"
        Me.rbtFundList.Size = New System.Drawing.Size(82, 18)
        Me.rbtFundList.TabIndex = 21
        Me.rbtFundList.TabStop = True
        Me.rbtFundList.Text = "基金列表"
        Me.rbtFundList.UseVisualStyleBackColor = True
        '
        'rbtBlockList
        '
        Me.rbtBlockList.AutoSize = True
        Me.rbtBlockList.Location = New System.Drawing.Point(16, 55)
        Me.rbtBlockList.Name = "rbtBlockList"
        Me.rbtBlockList.Size = New System.Drawing.Size(82, 18)
        Me.rbtBlockList.TabIndex = 20
        Me.rbtBlockList.TabStop = True
        Me.rbtBlockList.Text = "板块列表"
        Me.rbtBlockList.UseVisualStyleBackColor = True
        '
        'rbtIndexList
        '
        Me.rbtIndexList.AutoSize = True
        Me.rbtIndexList.Location = New System.Drawing.Point(16, 30)
        Me.rbtIndexList.Name = "rbtIndexList"
        Me.rbtIndexList.Size = New System.Drawing.Size(82, 18)
        Me.rbtIndexList.TabIndex = 19
        Me.rbtIndexList.TabStop = True
        Me.rbtIndexList.Text = "指数列表"
        Me.rbtIndexList.UseVisualStyleBackColor = True
        '
        'rbtStockList
        '
        Me.rbtStockList.AutoSize = True
        Me.rbtStockList.Location = New System.Drawing.Point(16, 79)
        Me.rbtStockList.Name = "rbtStockList"
        Me.rbtStockList.Size = New System.Drawing.Size(82, 18)
        Me.rbtStockList.TabIndex = 18
        Me.rbtStockList.TabStop = True
        Me.rbtStockList.Text = "股票列表"
        Me.rbtStockList.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'frmDataMaintenanceSQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1399, 998)
        Me.Controls.Add(Me.btnDataInfoImportSQL)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnDataFeed_Price)
        Me.Controls.Add(Me.lblDGV_Total)
        Me.Controls.Add(Me.prgDGV)
        Me.Controls.Add(Me.prgBar)
        Me.Controls.Add(Me.btnDataImportSQL)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.dgvDataList)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmDataMaintenanceSQL"
        Me.Text = "数据更新"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvDataList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtStockName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnGetStockFullName As System.Windows.Forms.Button
    Friend WithEvents rbtFundDaily As System.Windows.Forms.RadioButton
    Friend WithEvents ckbAllSymbol As System.Windows.Forms.CheckBox
    Friend WithEvents tBlockDaily As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAskedSymbol As System.Windows.Forms.TextBox
    Friend WithEvents rbtIndexDaily As System.Windows.Forms.RadioButton
    Friend WithEvents rbtStockDaily As System.Windows.Forms.RadioButton
    Friend WithEvents prgDGV As System.Windows.Forms.ProgressBar
    Friend WithEvents prgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents btnDataImportSQL As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Friend WithEvents dgvDataList As System.Windows.Forms.DataGridView
    Friend WithEvents rbtStockDaily_BA As System.Windows.Forms.RadioButton
    Friend WithEvents rbtStockDaily_FA As System.Windows.Forms.RadioButton
    Friend WithEvents lblDGV_Total As System.Windows.Forms.Label
    Friend WithEvents btnDataFeed_Price As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnDataInfoImportSQL As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSecurityTypeID As System.Windows.Forms.TextBox
    Friend WithEvents rbtSecurityTypeRelation As System.Windows.Forms.RadioButton
    Friend WithEvents txtSecuritySymbol As System.Windows.Forms.TextBox
    Friend WithEvents rbtSecurityInfo As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSecurityType As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTradeCalendar As System.Windows.Forms.RadioButton
    Friend WithEvents txtFundCompanyTemp As System.Windows.Forms.TextBox
    Friend WithEvents rbtFundCompany As System.Windows.Forms.RadioButton
    Friend WithEvents rbtFundList As System.Windows.Forms.RadioButton
    Friend WithEvents rbtBlockList As System.Windows.Forms.RadioButton
    Friend WithEvents rbtIndexList As System.Windows.Forms.RadioButton
    Friend WithEvents rbtStockList As System.Windows.Forms.RadioButton
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
