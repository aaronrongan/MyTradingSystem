<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataInsertSQL
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
        Me.dgvDataList = New System.Windows.Forms.DataGridView()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnDataInfoFeed = New System.Windows.Forms.Button()
        Me.btnDataPriceImportSQL = New System.Windows.Forms.Button()
        Me.prgBar = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtStockName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnGetStockFullName = New System.Windows.Forms.Button()
        Me.rbtFundDaily = New System.Windows.Forms.RadioButton()
        Me.ckbAllSymbol = New System.Windows.Forms.CheckBox()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAskedSymbol = New System.Windows.Forms.TextBox()
        Me.rbtIndexDaily = New System.Windows.Forms.RadioButton()
        Me.rbtStockDaily = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnDataPriceFeed = New System.Windows.Forms.Button()
        Me.lblDGV_Total = New System.Windows.Forms.Label()
        Me.prgDGV = New System.Windows.Forms.ProgressBar()
        Me.btnDataInfoImportSQL = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.dgvDataList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDataList
        '
        Me.dgvDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDataList.Location = New System.Drawing.Point(237, 43)
        Me.dgvDataList.Name = "dgvDataList"
        Me.dgvDataList.RowTemplate.Height = 24
        Me.dgvDataList.Size = New System.Drawing.Size(955, 863)
        Me.dgvDataList.TabIndex = 0
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(1241, 43)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOutput.Size = New System.Drawing.Size(268, 863)
        Me.txtOutput.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1238, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "数据导入SQL结果"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(234, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "数据列表"
        '
        'btnDataInfoFeed
        '
        Me.btnDataInfoFeed.Location = New System.Drawing.Point(23, 344)
        Me.btnDataInfoFeed.Name = "btnDataInfoFeed"
        Me.btnDataInfoFeed.Size = New System.Drawing.Size(75, 23)
        Me.btnDataInfoFeed.TabIndex = 4
        Me.btnDataInfoFeed.Text = "数据采集"
        Me.btnDataInfoFeed.UseVisualStyleBackColor = True
        '
        'btnDataPriceImportSQL
        '
        Me.btnDataPriceImportSQL.Location = New System.Drawing.Point(99, 753)
        Me.btnDataPriceImportSQL.Name = "btnDataPriceImportSQL"
        Me.btnDataPriceImportSQL.Size = New System.Drawing.Size(75, 23)
        Me.btnDataPriceImportSQL.TabIndex = 5
        Me.btnDataPriceImportSQL.Text = "数据导入"
        Me.btnDataPriceImportSQL.UseVisualStyleBackColor = True
        '
        'prgBar
        '
        Me.prgBar.Location = New System.Drawing.Point(1241, 926)
        Me.prgBar.Name = "prgBar"
        Me.prgBar.Size = New System.Drawing.Size(268, 23)
        Me.prgBar.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 14)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "导入类型"
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
        Me.GroupBox1.Location = New System.Drawing.Point(23, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(203, 270)
        Me.GroupBox1.TabIndex = 20
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtStockName)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.btnGetStockFullName)
        Me.GroupBox2.Controls.Add(Me.rbtFundDaily)
        Me.GroupBox2.Controls.Add(Me.ckbAllSymbol)
        Me.GroupBox2.Controls.Add(Me.RadioButton6)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtAskedSymbol)
        Me.GroupBox2.Controls.Add(Me.rbtIndexDaily)
        Me.GroupBox2.Controls.Add(Me.rbtStockDaily)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 452)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(151, 295)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "价格信息"
        '
        'txtStockName
        '
        Me.txtStockName.Location = New System.Drawing.Point(82, 222)
        Me.txtStockName.Name = "txtStockName"
        Me.txtStockName.Size = New System.Drawing.Size(63, 22)
        Me.txtStockName.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 225)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 14)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "名称"
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
        Me.ckbAllSymbol.Location = New System.Drawing.Point(16, 173)
        Me.ckbAllSymbol.Name = "ckbAllSymbol"
        Me.ckbAllSymbol.Size = New System.Drawing.Size(83, 18)
        Me.ckbAllSymbol.TabIndex = 28
        Me.ckbAllSymbol.Text = "所有代码"
        Me.ckbAllSymbol.UseVisualStyleBackColor = True
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Location = New System.Drawing.Point(12, 48)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(110, 18)
        Me.RadioButton6.TabIndex = 22
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Text = "板块日线价格"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 14)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "指定代码"
        '
        'txtAskedSymbol
        '
        Me.txtAskedSymbol.Location = New System.Drawing.Point(82, 197)
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
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(482, 962)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(188, 36)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "实验显示数据库Datatable"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnDataPriceFeed
        '
        Me.btnDataPriceFeed.Location = New System.Drawing.Point(17, 753)
        Me.btnDataPriceFeed.Name = "btnDataPriceFeed"
        Me.btnDataPriceFeed.Size = New System.Drawing.Size(75, 23)
        Me.btnDataPriceFeed.TabIndex = 23
        Me.btnDataPriceFeed.Text = "数据采集"
        Me.btnDataPriceFeed.UseVisualStyleBackColor = True
        '
        'lblDGV_Total
        '
        Me.lblDGV_Total.AutoSize = True
        Me.lblDGV_Total.Location = New System.Drawing.Point(1150, 22)
        Me.lblDGV_Total.Name = "lblDGV_Total"
        Me.lblDGV_Total.Size = New System.Drawing.Size(42, 14)
        Me.lblDGV_Total.TabIndex = 24
        Me.lblDGV_Total.Text = "Label"
        Me.lblDGV_Total.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'prgDGV
        '
        Me.prgDGV.Location = New System.Drawing.Point(237, 926)
        Me.prgDGV.Name = "prgDGV"
        Me.prgDGV.Size = New System.Drawing.Size(955, 23)
        Me.prgDGV.TabIndex = 25
        '
        'btnDataInfoImportSQL
        '
        Me.btnDataInfoImportSQL.Location = New System.Drawing.Point(149, 344)
        Me.btnDataInfoImportSQL.Name = "btnDataInfoImportSQL"
        Me.btnDataInfoImportSQL.Size = New System.Drawing.Size(77, 23)
        Me.btnDataInfoImportSQL.TabIndex = 26
        Me.btnDataInfoImportSQL.Text = "数据导入"
        Me.btnDataInfoImportSQL.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(54, 926)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 27
        Me.Button2.Text = "测试"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmDataInsertSQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1578, 1010)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnDataInfoImportSQL)
        Me.Controls.Add(Me.prgDGV)
        Me.Controls.Add(Me.lblDGV_Total)
        Me.Controls.Add(Me.btnDataPriceFeed)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.prgBar)
        Me.Controls.Add(Me.btnDataPriceImportSQL)
        Me.Controls.Add(Me.btnDataInfoFeed)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.dgvDataList)
        Me.Name = "frmDataInsertSQL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "bu"
        CType(Me.dgvDataList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDataList As System.Windows.Forms.DataGridView
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnDataInfoFeed As System.Windows.Forms.Button
    Friend WithEvents btnDataPriceImportSQL As System.Windows.Forms.Button
    Friend WithEvents prgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtFundList As System.Windows.Forms.RadioButton
    Friend WithEvents rbtBlockList As System.Windows.Forms.RadioButton
    Friend WithEvents rbtIndexList As System.Windows.Forms.RadioButton
    Friend WithEvents rbtStockList As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtFundDaily As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtIndexDaily As System.Windows.Forms.RadioButton
    Friend WithEvents rbtStockDaily As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAskedSymbol As System.Windows.Forms.TextBox
    Friend WithEvents ckbAllSymbol As System.Windows.Forms.CheckBox
    Friend WithEvents txtStockName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnGetStockFullName As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnDataPriceFeed As System.Windows.Forms.Button
    Friend WithEvents lblDGV_Total As System.Windows.Forms.Label
    Friend WithEvents rbtFundCompany As System.Windows.Forms.RadioButton
    Friend WithEvents prgDGV As System.Windows.Forms.ProgressBar
    Friend WithEvents txtFundCompanyTemp As System.Windows.Forms.TextBox
    Friend WithEvents btnDataInfoImportSQL As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents rbtTradeCalendar As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSecurityType As System.Windows.Forms.RadioButton
    Friend WithEvents txtSecuritySymbol As System.Windows.Forms.TextBox
    Friend WithEvents rbtSecurityInfo As System.Windows.Forms.RadioButton
    Friend WithEvents txtSecurityTypeID As System.Windows.Forms.TextBox
    Friend WithEvents rbtSecurityTypeRelation As System.Windows.Forms.RadioButton
End Class
