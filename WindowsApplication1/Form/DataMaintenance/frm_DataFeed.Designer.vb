<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_DataFeed
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.数据库维护ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.交易系统ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.图形显示ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(283, 74)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(834, 567)
        Me.DataGridView1.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(18, 18)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.数据库维护ToolStripMenuItem, Me.交易系统ToolStripMenuItem, Me.图形显示ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1170, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '数据库维护ToolStripMenuItem
        '
        Me.数据库维护ToolStripMenuItem.Name = "数据库维护ToolStripMenuItem"
        Me.数据库维护ToolStripMenuItem.Size = New System.Drawing.Size(89, 20)
        Me.数据库维护ToolStripMenuItem.Text = "数据库维护"
        '
        '交易系统ToolStripMenuItem
        '
        Me.交易系统ToolStripMenuItem.Name = "交易系统ToolStripMenuItem"
        Me.交易系统ToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.交易系统ToolStripMenuItem.Text = "交易系统"
        '
        '图形显示ToolStripMenuItem
        '
        Me.图形显示ToolStripMenuItem.Name = "图形显示ToolStripMenuItem"
        Me.图形显示ToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.图形显示ToolStripMenuItem.Text = "图形显示"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(61, 137)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(106, 38)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "获取股票列表"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(61, 74)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(106, 39)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "获取指数列表"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(61, 209)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(106, 45)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "获取股票日线数据"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(62, 278)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(105, 39)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "读取通达信数据"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'frm_DataFeed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1170, 934)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frm_DataFeed"
        Me.Text = "数据获取"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 数据库维护ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 交易系统ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 图形显示ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button

End Class
