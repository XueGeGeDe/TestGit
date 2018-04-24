<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigManager
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
        Me.BeforeTC = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbDMAddr = New System.Windows.Forms.ComboBox()
        Me.cbUSBAddr = New System.Windows.Forms.ComboBox()
        Me.CBVOL = New System.Windows.Forms.CheckBox()
        Me.CBRES = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ResponseTest = New System.Windows.Forms.CheckBox()
        Me.AfterTC = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.AfterStamp = New System.Windows.Forms.RadioButton()
        Me.BeforeStamp = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BeforeTC
        '
        Me.BeforeTC.AutoSize = True
        Me.BeforeTC.ForeColor = System.Drawing.Color.Blue
        Me.BeforeTC.Location = New System.Drawing.Point(46, 107)
        Me.BeforeTC.Name = "BeforeTC"
        Me.BeforeTC.Size = New System.Drawing.Size(59, 16)
        Me.BeforeTC.TabIndex = 6
        Me.BeforeTC.TabStop = True
        Me.BeforeTC.Text = "温循前"
        Me.BeforeTC.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.cbDMAddr)
        Me.GroupBox3.Controls.Add(Me.cbUSBAddr)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(324, 113)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "设备地址"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "测试板地址"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "万用表地址"
        '
        'cbDMAddr
        '
        Me.cbDMAddr.DropDownWidth = 180
        Me.cbDMAddr.ItemHeight = 12
        Me.cbDMAddr.Items.AddRange(New Object() {"USB0::0x2A8D::0xB318::MY57192779::0::INSTR"})
        Me.cbDMAddr.Location = New System.Drawing.Point(102, 20)
        Me.cbDMAddr.Name = "cbDMAddr"
        Me.cbDMAddr.Size = New System.Drawing.Size(191, 20)
        Me.cbDMAddr.TabIndex = 2
        '
        'cbUSBAddr
        '
        Me.cbUSBAddr.FormattingEnabled = True
        Me.cbUSBAddr.Location = New System.Drawing.Point(102, 74)
        Me.cbUSBAddr.Name = "cbUSBAddr"
        Me.cbUSBAddr.Size = New System.Drawing.Size(191, 20)
        Me.cbUSBAddr.TabIndex = 0
        '
        'CBVOL
        '
        Me.CBVOL.AutoSize = True
        Me.CBVOL.ForeColor = System.Drawing.Color.Blue
        Me.CBVOL.Location = New System.Drawing.Point(42, 88)
        Me.CBVOL.Name = "CBVOL"
        Me.CBVOL.Size = New System.Drawing.Size(60, 16)
        Me.CBVOL.TabIndex = 10
        Me.CBVOL.Text = "DC测试"
        Me.CBVOL.UseVisualStyleBackColor = True
        '
        'CBRES
        '
        Me.CBRES.AutoSize = True
        Me.CBRES.ForeColor = System.Drawing.Color.Blue
        Me.CBRES.Location = New System.Drawing.Point(42, 34)
        Me.CBRES.Name = "CBRES"
        Me.CBRES.Size = New System.Drawing.Size(72, 16)
        Me.CBRES.TabIndex = 9
        Me.CBRES.Text = "短路测试"
        Me.CBRES.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ResponseTest)
        Me.GroupBox2.Controls.Add(Me.CBVOL)
        Me.GroupBox2.Controls.Add(Me.CBRES)
        Me.GroupBox2.Location = New System.Drawing.Point(191, 131)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(145, 188)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "测试模式"
        '
        'ResponseTest
        '
        Me.ResponseTest.AutoSize = True
        Me.ResponseTest.ForeColor = System.Drawing.Color.Blue
        Me.ResponseTest.Location = New System.Drawing.Point(42, 139)
        Me.ResponseTest.Name = "ResponseTest"
        Me.ResponseTest.Size = New System.Drawing.Size(84, 16)
        Me.ResponseTest.TabIndex = 12
        Me.ResponseTest.Text = "响应度测试"
        Me.ResponseTest.UseVisualStyleBackColor = True
        '
        'AfterTC
        '
        Me.AfterTC.AutoSize = True
        Me.AfterTC.ForeColor = System.Drawing.Color.Red
        Me.AfterTC.Location = New System.Drawing.Point(46, 149)
        Me.AfterTC.Name = "AfterTC"
        Me.AfterTC.Size = New System.Drawing.Size(59, 16)
        Me.AfterTC.TabIndex = 7
        Me.AfterTC.TabStop = True
        Me.AfterTC.Text = "温循后"
        Me.AfterTC.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AfterTC)
        Me.GroupBox1.Controls.Add(Me.BeforeTC)
        Me.GroupBox1.Controls.Add(Me.AfterStamp)
        Me.GroupBox1.Controls.Add(Me.BeforeStamp)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 131)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(150, 188)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "测试环境"
        '
        'AfterStamp
        '
        Me.AfterStamp.AutoSize = True
        Me.AfterStamp.ForeColor = System.Drawing.Color.Red
        Me.AfterStamp.Location = New System.Drawing.Point(46, 69)
        Me.AfterStamp.Name = "AfterStamp"
        Me.AfterStamp.Size = New System.Drawing.Size(59, 16)
        Me.AfterStamp.TabIndex = 5
        Me.AfterStamp.TabStop = True
        Me.AfterStamp.Text = "加盖后"
        Me.AfterStamp.UseVisualStyleBackColor = True
        '
        'BeforeStamp
        '
        Me.BeforeStamp.AutoSize = True
        Me.BeforeStamp.ForeColor = System.Drawing.Color.Blue
        Me.BeforeStamp.Location = New System.Drawing.Point(46, 33)
        Me.BeforeStamp.Name = "BeforeStamp"
        Me.BeforeStamp.Size = New System.Drawing.Size(59, 16)
        Me.BeforeStamp.TabIndex = 4
        Me.BeforeStamp.Text = "加盖前"
        Me.BeforeStamp.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(138, 331)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ConfigManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(348, 366)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "ConfigManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "配置中心"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BeforeTC As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents cbDMAddr As System.Windows.Forms.ComboBox
    Friend WithEvents cbUSBAddr As System.Windows.Forms.ComboBox
    Friend WithEvents CBVOL As System.Windows.Forms.CheckBox
    Friend WithEvents CBRES As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ResponseTest As System.Windows.Forms.CheckBox
    Friend WithEvents AfterTC As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents AfterStamp As System.Windows.Forms.RadioButton
    Friend WithEvents BeforeStamp As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
