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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.txtBinFilePath = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnA0BinFile = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnViewInfor = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.cbSalesNo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.CheckedXFP = New System.Windows.Forms.RadioButton()
        Me.CheckedSFP = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.OpenFile = New System.Windows.Forms.Button()
        Me.btnGetAllSN = New System.Windows.Forms.Button()
        Me.txtA2BinFileTemplate = New System.Windows.Forms.TextBox()
        Me.chkA2 = New System.Windows.Forms.CheckBox()
        Me.btnA2BinFile = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lvBinFileList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TotalLength = New System.Windows.Forms.NumericUpDown()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Preview = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ChangeNumbers = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.EndNum = New System.Windows.Forms.TextBox()
        Me.btnCreateBin = New System.Windows.Forms.Button()
        Me.StartNum = New System.Windows.Forms.TextBox()
        Me.StartName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lvCreateBin = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCreateBins = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.AllOk = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Status = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TimeShow = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TotalLength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChangeNumbers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBinFilePath
        '
        Me.txtBinFilePath.FormattingEnabled = True
        Me.txtBinFilePath.Location = New System.Drawing.Point(107, 7)
        Me.txtBinFilePath.Name = "txtBinFilePath"
        Me.txtBinFilePath.Size = New System.Drawing.Size(319, 20)
        Me.txtBinFilePath.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 12)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "A0 BIN文件路径:"
        '
        'btnA0BinFile
        '
        Me.btnA0BinFile.Image = CType(resources.GetObject("btnA0BinFile.Image"), System.Drawing.Image)
        Me.btnA0BinFile.Location = New System.Drawing.Point(432, 6)
        Me.btnA0BinFile.Name = "btnA0BinFile"
        Me.btnA0BinFile.Size = New System.Drawing.Size(39, 22)
        Me.btnA0BinFile.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.btnA0BinFile, "选择A0 BIN文件")
        Me.btnA0BinFile.UseVisualStyleBackColor = True
        '
        'btnViewInfor
        '
        Me.btnViewInfor.Enabled = False
        Me.btnViewInfor.Location = New System.Drawing.Point(541, 4)
        Me.btnViewInfor.Name = "btnViewInfor"
        Me.btnViewInfor.Size = New System.Drawing.Size(148, 23)
        Me.btnViewInfor.TabIndex = 22
        Me.btnViewInfor.Text = "预览A0 BIN文件"
        Me.btnViewInfor.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Enabled = False
        Me.btnLoad.Image = CType(resources.GetObject("btnLoad.Image"), System.Drawing.Image)
        Me.btnLoad.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLoad.Location = New System.Drawing.Point(541, 89)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(148, 36)
        Me.btnLoad.TabIndex = 22
        Me.btnLoad.Text = "上传BIN文件"
        Me.btnLoad.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnLoad, "上传BIN文件到数据库")
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'cbSalesNo
        '
        Me.cbSalesNo.FormattingEnabled = True
        Me.cbSalesNo.Location = New System.Drawing.Point(541, 54)
        Me.cbSalesNo.Name = "cbSalesNo"
        Me.cbSalesNo.Size = New System.Drawing.Size(148, 20)
        Me.cbSalesNo.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(539, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 12)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "选择销售订单号"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(3, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(708, 401)
        Me.TabControl1.TabIndex = 25
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.CheckedXFP)
        Me.TabPage1.Controls.Add(Me.CheckedSFP)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.OpenFile)
        Me.TabPage1.Controls.Add(Me.btnGetAllSN)
        Me.TabPage1.Controls.Add(Me.txtA2BinFileTemplate)
        Me.TabPage1.Controls.Add(Me.chkA2)
        Me.TabPage1.Controls.Add(Me.btnA2BinFile)
        Me.TabPage1.Controls.Add(Me.btnA0BinFile)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.cbSalesNo)
        Me.TabPage1.Controls.Add(Me.txtBinFilePath)
        Me.TabPage1.Controls.Add(Me.btnLoad)
        Me.TabPage1.Controls.Add(Me.lvBinFileList)
        Me.TabPage1.Controls.Add(Me.btnViewInfor)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(700, 375)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "BIN上传管理"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'CheckedXFP
        '
        Me.CheckedXFP.AutoSize = True
        Me.CheckedXFP.Location = New System.Drawing.Point(648, 182)
        Me.CheckedXFP.Name = "CheckedXFP"
        Me.CheckedXFP.Size = New System.Drawing.Size(41, 16)
        Me.CheckedXFP.TabIndex = 31
        Me.CheckedXFP.TabStop = True
        Me.CheckedXFP.Tag = "1"
        Me.CheckedXFP.Text = "XFP"
        Me.CheckedXFP.UseVisualStyleBackColor = True
        '
        'CheckedSFP
        '
        Me.CheckedSFP.AutoSize = True
        Me.CheckedSFP.Checked = True
        Me.CheckedSFP.Location = New System.Drawing.Point(541, 182)
        Me.CheckedSFP.Name = "CheckedSFP"
        Me.CheckedSFP.Size = New System.Drawing.Size(59, 16)
        Me.CheckedSFP.TabIndex = 30
        Me.CheckedSFP.TabStop = True
        Me.CheckedSFP.Tag = "0"
        Me.CheckedSFP.Text = "SFP(+)"
        Me.CheckedSFP.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(525, 360)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 12)
        Me.Label5.TabIndex = 29
        '
        'OpenFile
        '
        Me.OpenFile.Image = CType(resources.GetObject("OpenFile.Image"), System.Drawing.Image)
        Me.OpenFile.Location = New System.Drawing.Point(480, 7)
        Me.OpenFile.Name = "OpenFile"
        Me.OpenFile.Size = New System.Drawing.Size(39, 22)
        Me.OpenFile.TabIndex = 28
        Me.OpenFile.UseVisualStyleBackColor = True
        '
        'btnGetAllSN
        '
        Me.btnGetAllSN.Location = New System.Drawing.Point(541, 222)
        Me.btnGetAllSN.Name = "btnGetAllSN"
        Me.btnGetAllSN.Size = New System.Drawing.Size(148, 33)
        Me.btnGetAllSN.TabIndex = 27
        Me.btnGetAllSN.Text = "从数据库导出BIN文件"
        Me.btnGetAllSN.UseVisualStyleBackColor = True
        '
        'txtA2BinFileTemplate
        '
        Me.txtA2BinFileTemplate.Location = New System.Drawing.Point(131, 34)
        Me.txtA2BinFileTemplate.Name = "txtA2BinFileTemplate"
        Me.txtA2BinFileTemplate.Size = New System.Drawing.Size(340, 21)
        Me.txtA2BinFileTemplate.TabIndex = 26
        Me.txtA2BinFileTemplate.Visible = False
        '
        'chkA2
        '
        Me.chkA2.AutoSize = True
        Me.chkA2.Location = New System.Drawing.Point(541, 146)
        Me.chkA2.Name = "chkA2"
        Me.chkA2.Size = New System.Drawing.Size(108, 16)
        Me.chkA2.TabIndex = 25
        Me.chkA2.Text = "生成A2 BIN文件"
        Me.chkA2.UseVisualStyleBackColor = True
        '
        'btnA2BinFile
        '
        Me.btnA2BinFile.Image = CType(resources.GetObject("btnA2BinFile.Image"), System.Drawing.Image)
        Me.btnA2BinFile.Location = New System.Drawing.Point(477, 33)
        Me.btnA2BinFile.Name = "btnA2BinFile"
        Me.btnA2BinFile.Size = New System.Drawing.Size(47, 22)
        Me.btnA2BinFile.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.btnA2BinFile, "选择A2高128字节BIN文件模板")
        Me.btnA2BinFile.UseVisualStyleBackColor = True
        Me.btnA2BinFile.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 12)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "A2 BIN文件模板路径:"
        Me.Label3.Visible = False
        '
        'lvBinFileList
        '
        Me.lvBinFileList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvBinFileList.FullRowSelect = True
        Me.lvBinFileList.GridLines = True
        Me.lvBinFileList.Location = New System.Drawing.Point(8, 41)
        Me.lvBinFileList.Name = "lvBinFileList"
        Me.lvBinFileList.ShowItemToolTips = True
        Me.lvBinFileList.Size = New System.Drawing.Size(511, 328)
        Me.lvBinFileList.TabIndex = 15
        Me.lvBinFileList.UseCompatibleStateImageBehavior = False
        Me.lvBinFileList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "文件名称"
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "大小"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 50
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "修改日期"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 140
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "完整路径"
        Me.ColumnHeader5.Width = 200
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.lvCreateBin)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.btnCreateBins)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(700, 375)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = " BIN生成管理"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.TotalLength)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Preview)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.ChangeNumbers)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.EndNum)
        Me.GroupBox1.Controls.Add(Me.btnCreateBin)
        Me.GroupBox1.Controls.Add(Me.StartNum)
        Me.GroupBox1.Controls.Add(Me.StartName)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(460, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(234, 324)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "生成文件"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(191, 91)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(48, 16)
        Me.CheckBox1.TabIndex = 43
        Me.CheckBox1.Text = "编辑"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(0, 70)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(503, 12)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = "---------------------------------------------------------------------------------" & _
            "--"
        '
        'TotalLength
        '
        Me.TotalLength.Location = New System.Drawing.Point(139, 30)
        Me.TotalLength.Name = "TotalLength"
        Me.TotalLength.Size = New System.Drawing.Size(55, 21)
        Me.TotalLength.TabIndex = 41
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(31, 33)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 12)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "序列号总长度："
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(184, 208)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(40, 23)
        Me.Button2.TabIndex = 39
        Me.Button2.Text = "预览"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Preview
        '
        Me.Preview.FormattingEnabled = True
        Me.Preview.Location = New System.Drawing.Point(51, 209)
        Me.Preview.Name = "Preview"
        Me.Preview.Size = New System.Drawing.Size(126, 20)
        Me.Preview.TabIndex = 38
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(40, 214)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(11, 12)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "-"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(1, 212)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 12)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "预览SN"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(130, 252)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 36)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "清空列表"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ChangeNumbers
        '
        Me.ChangeNumbers.Location = New System.Drawing.Point(156, 89)
        Me.ChangeNumbers.Name = "ChangeNumbers"
        Me.ChangeNumbers.Size = New System.Drawing.Size(33, 21)
        Me.ChangeNumbers.TabIndex = 32
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 12)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "-"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 172)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 12)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "数量"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 132)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 12)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "起始ID"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 92)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 12)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "序列号"
        '
        'EndNum
        '
        Me.EndNum.Location = New System.Drawing.Point(51, 169)
        Me.EndNum.Name = "EndNum"
        Me.EndNum.Size = New System.Drawing.Size(96, 21)
        Me.EndNum.TabIndex = 27
        '
        'btnCreateBin
        '
        Me.btnCreateBin.Enabled = False
        Me.btnCreateBin.Location = New System.Drawing.Point(22, 252)
        Me.btnCreateBin.Name = "btnCreateBin"
        Me.btnCreateBin.Size = New System.Drawing.Size(79, 36)
        Me.btnCreateBin.TabIndex = 18
        Me.btnCreateBin.Text = "生成Bin文件"
        Me.btnCreateBin.UseVisualStyleBackColor = True
        '
        'StartNum
        '
        Me.StartNum.Location = New System.Drawing.Point(51, 129)
        Me.StartNum.Name = "StartNum"
        Me.StartNum.Size = New System.Drawing.Size(96, 21)
        Me.StartNum.TabIndex = 26
        '
        'StartName
        '
        Me.StartName.Enabled = False
        Me.StartName.Location = New System.Drawing.Point(51, 89)
        Me.StartName.Multiline = True
        Me.StartName.Name = "StartName"
        Me.StartName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.StartName.Size = New System.Drawing.Size(105, 21)
        Me.StartName.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(41, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 12)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "-"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(41, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 12)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "-"
        '
        'lvCreateBin
        '
        Me.lvCreateBin.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvCreateBin.FullRowSelect = True
        Me.lvCreateBin.GridLines = True
        Me.lvCreateBin.Location = New System.Drawing.Point(10, 45)
        Me.lvCreateBin.Name = "lvCreateBin"
        Me.lvCreateBin.Size = New System.Drawing.Size(435, 317)
        Me.lvCreateBin.TabIndex = 19
        Me.lvCreateBin.UseCompatibleStateImageBehavior = False
        Me.lvCreateBin.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "生成BIN文件"
        Me.ColumnHeader2.Width = 110
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "大小"
        Me.ColumnHeader6.Width = 64
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "修改日期"
        Me.ColumnHeader7.Width = 86
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "完整路径"
        Me.ColumnHeader8.Width = 331
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button3.Location = New System.Drawing.Point(460, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(158, 25)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "选择BIN模板文件"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 12)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "模板文件路径:"
        '
        'btnCreateBins
        '
        Me.btnCreateBins.FormattingEnabled = True
        Me.btnCreateBins.Location = New System.Drawing.Point(96, 9)
        Me.btnCreateBins.Name = "btnCreateBins"
        Me.btnCreateBins.Size = New System.Drawing.Size(349, 20)
        Me.btnCreateBins.TabIndex = 17
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "选择路径"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.AllOk, Me.Status, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.TimeShow})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 412)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(720, 26)
        Me.StatusStrip1.TabIndex = 26
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Bump
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(44, 21)
        Me.ToolStripStatusLabel1.Text = "状态："
        '
        'AllOk
        '
        Me.AllOk.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.AllOk.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.AllOk.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.AllOk.ForeColor = System.Drawing.Color.Blue
        Me.AllOk.Name = "AllOk"
        Me.AllOk.Size = New System.Drawing.Size(311, 21)
        Me.AllOk.Spring = True
        Me.AllOk.Text = "就绪"
        Me.AllOk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Status
        '
        Me.Status.Maximum = 1000
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(200, 20)
        Me.Status.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.Status.Visible = False
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(311, 21)
        Me.ToolStripStatusLabel2.Spring = True
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(35, 21)
        Me.ToolStripStatusLabel3.Text = "时间:"
        '
        'TimeShow
        '
        Me.TimeShow.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.TimeShow.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.TimeShow.ForeColor = System.Drawing.Color.Blue
        Me.TimeShow.Name = "TimeShow"
        Me.TimeShow.Size = New System.Drawing.Size(4, 21)
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 438)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Code BIN File Manage (仅仅支持SFF8472)"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TotalLength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChangeNumbers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBinFilePath As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnA0BinFile As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnViewInfor As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents cbSalesNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCreateBins As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents chkA2 As System.Windows.Forms.CheckBox
    Friend WithEvents txtA2BinFileTemplate As System.Windows.Forms.TextBox
    Friend WithEvents btnA2BinFile As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCreateBin As System.Windows.Forms.Button
    Friend WithEvents lvCreateBin As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents StartName As System.Windows.Forms.TextBox
    Friend WithEvents StartNum As System.Windows.Forms.TextBox
    Friend WithEvents EndNum As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ChangeNumbers As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Preview As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TotalLength As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnGetAllSN As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFile As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lvBinFileList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Status As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents TimeShow As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents AllOk As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CheckedXFP As System.Windows.Forms.RadioButton
    Friend WithEvents CheckedSFP As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox

End Class
