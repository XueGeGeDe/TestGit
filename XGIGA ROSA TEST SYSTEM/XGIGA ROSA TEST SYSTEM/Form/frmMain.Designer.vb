<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Engineer = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTOSASN = New System.Windows.Forms.TextBox()
        Me.NewSourceGrid1 = New xgSourceGrid.NewSourceGrid(Me.components)
        Me.btnStart = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.退出ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuQuery = New System.Windows.Forms.ToolStripMenuItem()
        Me.Relay = New System.Windows.Forms.ToolStripMenuItem()
        Me.手动控制ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.配置中心ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateTest = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TestCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TimeShow = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox4.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Engineer)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.txtTOSASN)
        Me.GroupBox4.Controls.Add(Me.NewSourceGrid1)
        Me.GroupBox4.Controls.Add(Me.btnStart)
        Me.GroupBox4.Location = New System.Drawing.Point(19, 82)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(821, 403)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "自动测试"
        '
        'Engineer
        '
        Me.Engineer.AutoSize = True
        Me.Engineer.ForeColor = System.Drawing.Color.Blue
        Me.Engineer.Location = New System.Drawing.Point(346, 381)
        Me.Engineer.Name = "Engineer"
        Me.Engineer.Size = New System.Drawing.Size(0, 12)
        Me.Engineer.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(543, 368)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 29)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Ready"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 379)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "ROSA序列号"
        '
        'txtTOSASN
        '
        Me.txtTOSASN.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtTOSASN.ForeColor = System.Drawing.Color.Red
        Me.txtTOSASN.Location = New System.Drawing.Point(99, 369)
        Me.txtTOSASN.Name = "txtTOSASN"
        Me.txtTOSASN.Size = New System.Drawing.Size(122, 26)
        Me.txtTOSASN.TabIndex = 3
        '
        'NewSourceGrid1
        '
        Me.NewSourceGrid1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.NewSourceGrid1.AutoSize = True
        Me.NewSourceGrid1.BackColor = System.Drawing.Color.Gray
        Me.NewSourceGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NewSourceGrid1.CellOnlyRead = False
        Me.NewSourceGrid1.ClipboardMode = CType((((SourceGrid.ClipboardMode.Copy Or SourceGrid.ClipboardMode.Cut) _
                    Or SourceGrid.ClipboardMode.Paste) _
                    Or SourceGrid.ClipboardMode.Delete), SourceGrid.ClipboardMode)
        Me.NewSourceGrid1.ColumnsCount = 27
        Me.NewSourceGrid1.EnableSort = False
        Me.NewSourceGrid1.FixedColumns = 1
        Me.NewSourceGrid1.FixedRows = 1
        Me.NewSourceGrid1.Location = New System.Drawing.Point(10, 20)
        Me.NewSourceGrid1.MaxColumn = 26
        Me.NewSourceGrid1.MaxRow = 20
        Me.NewSourceGrid1.Name = "NewSourceGrid1"
        Me.NewSourceGrid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows
        Me.NewSourceGrid1.ResizeColumn = True
        Me.NewSourceGrid1.ResizeRow = True
        Me.NewSourceGrid1.RowHeight = 21
        Me.NewSourceGrid1.RowsCount = 21
        Me.NewSourceGrid1.SelectionMode = SourceGrid.GridSelectionMode.Cell
        Me.NewSourceGrid1.Size = New System.Drawing.Size(797, 330)
        Me.NewSourceGrid1.SpecialKeys = SourceGrid.GridSpecialKeys.None
        Me.NewSourceGrid1.TabIndex = 2
        Me.NewSourceGrid1.TabStop = True
        Me.NewSourceGrid1.ToolTipText = ""
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(658, 368)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(135, 29)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "开始测试"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件ToolStripMenuItem, Me.MenuQuery, Me.Relay})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(858, 25)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '文件ToolStripMenuItem
        '
        Me.文件ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.退出ToolStripMenuItem})
        Me.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem"
        Me.文件ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.文件ToolStripMenuItem.Text = "文件"
        '
        '退出ToolStripMenuItem
        '
        Me.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem"
        Me.退出ToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.退出ToolStripMenuItem.Text = "退出"
        '
        'MenuQuery
        '
        Me.MenuQuery.Name = "MenuQuery"
        Me.MenuQuery.Size = New System.Drawing.Size(68, 21)
        Me.MenuQuery.Text = "数据查询"
        '
        'Relay
        '
        Me.Relay.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.手动控制ToolStripMenuItem, Me.配置中心ToolStripMenuItem, Me.UpdateTest})
        Me.Relay.Name = "Relay"
        Me.Relay.Size = New System.Drawing.Size(68, 21)
        Me.Relay.Text = "控制中心"
        '
        '手动控制ToolStripMenuItem
        '
        Me.手动控制ToolStripMenuItem.Name = "手动控制ToolStripMenuItem"
        Me.手动控制ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.手动控制ToolStripMenuItem.Text = "手动控制"
        '
        '配置中心ToolStripMenuItem
        '
        Me.配置中心ToolStripMenuItem.Name = "配置中心ToolStripMenuItem"
        Me.配置中心ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.配置中心ToolStripMenuItem.Text = "配置中心"
        '
        'UpdateTest
        '
        Me.UpdateTest.Name = "UpdateTest"
        Me.UpdateTest.Size = New System.Drawing.Size(148, 22)
        Me.UpdateTest.Text = "更新测试范围"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(821, 48)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "测试情景"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(485, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 14)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "测试模式:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(164, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 14)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "测试环境："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(578, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 14)
        Me.Label2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(258, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 14)
        Me.Label1.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.TestCount, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.TimeShow})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 489)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(858, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(92, 17)
        Me.ToolStripStatusLabel1.Text = "剩余测试次数："
        '
        'TestCount
        '
        Me.TestCount.Name = "TestCount"
        Me.TestCount.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(573, 17)
        Me.ToolStripStatusLabel3.Spring = True
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(44, 17)
        Me.ToolStripStatusLabel4.Text = "时间："
        '
        'TimeShow
        '
        Me.TimeShow.Name = "TimeShow"
        Me.TimeShow.Size = New System.Drawing.Size(134, 17)
        Me.TimeShow.Text = "ToolStripStatusLabel5"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'frmMain
        '
        Me.AcceptButton = Me.btnStart
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 511)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ROSA引脚电阻和DC、响应度测试"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTOSASN As System.Windows.Forms.TextBox
    Friend WithEvents NewSourceGrid1 As xgSourceGrid.NewSourceGrid
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 退出ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuQuery As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Relay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 手动控制ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Engineer As System.Windows.Forms.Label
    Friend WithEvents 配置中心ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TestCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TimeShow As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents UpdateTest As System.Windows.Forms.ToolStripMenuItem

End Class
