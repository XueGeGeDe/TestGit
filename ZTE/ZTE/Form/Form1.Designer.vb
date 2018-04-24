<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.nsgData = New xgSourceGrid.NewSourceGrid(Me.components)
        Me.gbScanner = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DDMRate = New System.Windows.Forms.ComboBox()
        Me.SelectModel = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.txPName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.HighTemp = New System.Windows.Forms.CheckBox()
        Me.NormalTemp = New System.Windows.Forms.CheckBox()
        Me.LowTemp = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.退出ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.导出数据ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.导出Excel文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.导出XML文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.文件上传ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.上传XMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.frmtxtStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TimeText = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.gbScanner.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'nsgData
        '
        Me.nsgData.BackColor = System.Drawing.SystemColors.Info
        Me.nsgData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nsgData.CellOnlyRead = False
        Me.nsgData.ClipboardMode = CType((((SourceGrid.ClipboardMode.Copy Or SourceGrid.ClipboardMode.Cut) _
                    Or SourceGrid.ClipboardMode.Paste) _
                    Or SourceGrid.ClipboardMode.Delete), SourceGrid.ClipboardMode)
        Me.nsgData.ColumnsCount = 27
        Me.nsgData.EnableSort = False
        Me.nsgData.FixedColumns = 1
        Me.nsgData.FixedRows = 1
        Me.nsgData.Location = New System.Drawing.Point(25, 26)
        Me.nsgData.MaxColumn = 26
        Me.nsgData.MaxRow = 20
        Me.nsgData.Name = "nsgData"
        Me.nsgData.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows
        Me.nsgData.OverrideCommonCmdKey = False
        Me.nsgData.ResizeColumn = True
        Me.nsgData.ResizeRow = True
        Me.nsgData.RowHeight = 21
        Me.nsgData.RowsCount = 21
        Me.nsgData.SelectionMode = SourceGrid.GridSelectionMode.Cell
        Me.nsgData.Size = New System.Drawing.Size(752, 341)
        Me.nsgData.TabIndex = 0
        Me.nsgData.TabStop = True
        Me.nsgData.ToolTipText = ""
        '
        'gbScanner
        '
        Me.gbScanner.Controls.Add(Me.Button2)
        Me.gbScanner.Controls.Add(Me.Button3)
        Me.gbScanner.Controls.Add(Me.Button1)
        Me.gbScanner.Controls.Add(Me.nsgData)
        Me.gbScanner.Location = New System.Drawing.Point(12, 156)
        Me.gbScanner.Name = "gbScanner"
        Me.gbScanner.Size = New System.Drawing.Size(802, 406)
        Me.gbScanner.TabIndex = 4
        Me.gbScanner.TabStop = False
        Me.gbScanner.Text = "扫描区域"
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(77, 373)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(122, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "删除数据"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(344, 373)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(122, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "删除所有数据"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(611, 373)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(114, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "预览标签"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.DDMRate)
        Me.GroupBox1.Controls.Add(Me.SelectModel)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.txPName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(678, 80)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "产品信息"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(522, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "产品型号"
        '
        'DDMRate
        '
        Me.DDMRate.FormattingEnabled = True
        Me.DDMRate.Items.AddRange(New Object() {"10G", "100G"})
        Me.DDMRate.Location = New System.Drawing.Point(524, 37)
        Me.DDMRate.Name = "DDMRate"
        Me.DDMRate.Size = New System.Drawing.Size(121, 20)
        Me.DDMRate.TabIndex = 5
        '
        'SelectModel
        '
        Me.SelectModel.FormattingEnabled = True
        Me.SelectModel.Location = New System.Drawing.Point(35, 39)
        Me.SelectModel.Name = "SelectModel"
        Me.SelectModel.Size = New System.Drawing.Size(148, 20)
        Me.SelectModel.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(33, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 12)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "规格型号选取"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(375, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "产品数量"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(377, 37)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(100, 21)
        Me.TextBox2.TabIndex = 2
        '
        'txPName
        '
        Me.txPName.AllowDrop = True
        Me.txPName.Location = New System.Drawing.Point(230, 37)
        Me.txPName.Name = "txPName"
        Me.txPName.Size = New System.Drawing.Size(100, 21)
        Me.txPName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(228, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SN"
        '
        'HighTemp
        '
        Me.HighTemp.AutoSize = True
        Me.HighTemp.Checked = True
        Me.HighTemp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.HighTemp.Location = New System.Drawing.Point(41, 57)
        Me.HighTemp.Name = "HighTemp"
        Me.HighTemp.Size = New System.Drawing.Size(48, 16)
        Me.HighTemp.TabIndex = 12
        Me.HighTemp.Text = "高温"
        Me.HighTemp.UseVisualStyleBackColor = True
        '
        'NormalTemp
        '
        Me.NormalTemp.AutoSize = True
        Me.NormalTemp.Checked = True
        Me.NormalTemp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.NormalTemp.Enabled = False
        Me.NormalTemp.Location = New System.Drawing.Point(41, 36)
        Me.NormalTemp.Name = "NormalTemp"
        Me.NormalTemp.Size = New System.Drawing.Size(48, 16)
        Me.NormalTemp.TabIndex = 11
        Me.NormalTemp.Text = "常温"
        Me.NormalTemp.UseVisualStyleBackColor = True
        '
        'LowTemp
        '
        Me.LowTemp.AutoSize = True
        Me.LowTemp.Checked = True
        Me.LowTemp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LowTemp.Location = New System.Drawing.Point(41, 15)
        Me.LowTemp.Name = "LowTemp"
        Me.LowTemp.Size = New System.Drawing.Size(48, 16)
        Me.LowTemp.TabIndex = 10
        Me.LowTemp.Text = "低温"
        Me.LowTemp.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("华文楷体", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(272, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(283, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "产品SN与物料号扫描"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LowTemp)
        Me.GroupBox2.Controls.Add(Me.HighTemp)
        Me.GroupBox2.Controls.Add(Me.NormalTemp)
        Me.GroupBox2.Location = New System.Drawing.Point(696, 70)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(118, 80)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "温度选择"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件ToolStripMenuItem, Me.导出数据ToolStripMenuItem, Me.文件上传ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(826, 25)
        Me.MenuStrip1.TabIndex = 11
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
        Me.退出ToolStripMenuItem.Image = CType(resources.GetObject("退出ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem"
        Me.退出ToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.退出ToolStripMenuItem.Text = "退出"
        '
        '导出数据ToolStripMenuItem
        '
        Me.导出数据ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.导出Excel文件ToolStripMenuItem, Me.导出XML文件ToolStripMenuItem})
        Me.导出数据ToolStripMenuItem.Name = "导出数据ToolStripMenuItem"
        Me.导出数据ToolStripMenuItem.Size = New System.Drawing.Size(68, 21)
        Me.导出数据ToolStripMenuItem.Text = "导出数据"
        '
        '导出Excel文件ToolStripMenuItem
        '
        Me.导出Excel文件ToolStripMenuItem.Image = CType(resources.GetObject("导出Excel文件ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.导出Excel文件ToolStripMenuItem.Name = "导出Excel文件ToolStripMenuItem"
        Me.导出Excel文件ToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.导出Excel文件ToolStripMenuItem.Text = "导出Excel文件"
        '
        '导出XML文件ToolStripMenuItem
        '
        Me.导出XML文件ToolStripMenuItem.Image = CType(resources.GetObject("导出XML文件ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.导出XML文件ToolStripMenuItem.Name = "导出XML文件ToolStripMenuItem"
        Me.导出XML文件ToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.导出XML文件ToolStripMenuItem.Text = "导出XML文件"
        '
        '文件上传ToolStripMenuItem
        '
        Me.文件上传ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.上传XMLToolStripMenuItem})
        Me.文件上传ToolStripMenuItem.Name = "文件上传ToolStripMenuItem"
        Me.文件上传ToolStripMenuItem.Size = New System.Drawing.Size(68, 21)
        Me.文件上传ToolStripMenuItem.Text = "文件上传"
        '
        '上传XMLToolStripMenuItem
        '
        Me.上传XMLToolStripMenuItem.Image = CType(resources.GetObject("上传XMLToolStripMenuItem.Image"), System.Drawing.Image)
        Me.上传XMLToolStripMenuItem.Name = "上传XMLToolStripMenuItem"
        Me.上传XMLToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.上传XMLToolStripMenuItem.Text = "上传XML"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.frmtxtStatus, Me.ToolStripStatusLabel3, Me.TimeText})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 575)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(826, 22)
        Me.StatusStrip1.TabIndex = 12
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(44, 17)
        Me.ToolStripStatusLabel1.Text = "状态："
        '
        'frmtxtStatus
        '
        Me.frmtxtStatus.Name = "frmtxtStatus"
        Me.frmtxtStatus.Size = New System.Drawing.Size(32, 17)
        Me.frmtxtStatus.Text = "就绪"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(700, 17)
        Me.ToolStripStatusLabel3.Spring = True
        '
        'TimeText
        '
        Me.TimeText.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.TimeText.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.TimeText.Name = "TimeText"
        Me.TimeText.Size = New System.Drawing.Size(4, 17)
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 597)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbScanner)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "产品SN与物料号扫描"
        Me.gbScanner.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents nsgData As xgSourceGrid.NewSourceGrid
    Friend WithEvents gbScanner As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents txPName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SelectModel As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DDMRate As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents HighTemp As System.Windows.Forms.CheckBox
    Friend WithEvents NormalTemp As System.Windows.Forms.CheckBox
    Friend WithEvents LowTemp As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 退出ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 导出数据ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 导出Excel文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 导出XML文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents frmtxtStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TimeText As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents 文件上传ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 上传XMLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
