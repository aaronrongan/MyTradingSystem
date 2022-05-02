Imports System.Windows.Forms

Public Class frmMain

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click
        ' 创建此子窗体的一个新实例。
        Dim ChildForm As New System.Windows.Forms.Form
        ' 在显示该窗体前使其成为此 MDI 窗体的子窗体。
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "窗口 " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO:  在此处添加打开文件的代码。
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO:  在此处添加代码，将窗体的当前内容保存到一个文件中。
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' 使用 My.Computer.Clipboard 将选择的文本或图像插入剪贴板
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' 使用 My.Computer.Clipboard 将选择的文本或图像插入剪贴板
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        '使用 My.Computer.Clipboard.GetText() 或 My.Computer.Clipboard.GetData 从剪贴板检索信息。
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' 关闭此父窗体的所有子窗体。
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub XPanderPanel1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub 数据导入ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 数据导入ToolStripMenuItem.Click

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'frmDataView_HistoryData.Show()
        ' CSystemInit.SystemInit()
        'frmDataView_HistoryData.= True
        'Me.ActivateMdiChild(frmDataView_HistoryData)

    End Sub

    Private Sub 数据导入ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 数据导入ToolStripMenuItem1.Click
        frmDataInsertSQL.Show()
    End Sub

    Private Sub 历史日线ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 历史日线ToolStripMenuItem.Click

    End Sub

    Private Sub 临时1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 临时1ToolStripMenuItem.Click
        frm_DataFeed.Show()
    End Sub

    Private Sub 数据更新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 数据更新ToolStripMenuItem.Click
        frmDataMaintenanceSQL.Show()

    End Sub

    Private Sub 均线临时ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 均线临时ToolStripMenuItem.Click
        frm_IDCMA.Show()
    End Sub

    Private Sub Wind模拟交易ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Wind模拟交易ToolStripMenuItem.Click
        frmTrade_WindSimulation.Show()
    End Sub

    Private Sub 当日分时线ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 当日分时线ToolStripMenuItem.Click
        frmDataRealTime.Show()
    End Sub

    Private Sub 数据一览ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 数据一览ToolStripMenuItem.Click
        frmDataView_HistoryData.Show()
    End Sub

    Private Sub 回溯测试ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 回溯测试ToolStripMenuItem.Click
        frmBackTestSystem.Show()
    End Sub
End Class
