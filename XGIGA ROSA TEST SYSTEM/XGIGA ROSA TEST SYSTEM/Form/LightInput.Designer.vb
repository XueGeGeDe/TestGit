<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LightInput
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.L0 = New System.Windows.Forms.NumericUpDown()
        Me.L1 = New System.Windows.Forms.NumericUpDown()
        Me.L2 = New System.Windows.Forms.NumericUpDown()
        Me.L3 = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.L0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.L1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.L2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.L3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(90, 182)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "确定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "L0(uW）:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "L1(uW）:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "L2(uW）:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "L3(uW）:"
        '
        'L0
        '
        Me.L0.Location = New System.Drawing.Point(90, 38)
        Me.L0.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.L0.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.L0.Name = "L0"
        Me.L0.Size = New System.Drawing.Size(120, 21)
        Me.L0.TabIndex = 9
        Me.L0.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'L1
        '
        Me.L1.Location = New System.Drawing.Point(90, 72)
        Me.L1.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.L1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(120, 21)
        Me.L1.TabIndex = 10
        Me.L1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'L2
        '
        Me.L2.Location = New System.Drawing.Point(90, 106)
        Me.L2.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.L2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(120, 21)
        Me.L2.TabIndex = 11
        Me.L2.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'L3
        '
        Me.L3.Location = New System.Drawing.Point(90, 142)
        Me.L3.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.L3.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(120, 21)
        Me.L3.TabIndex = 12
        Me.L3.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.L3)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.L2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.L1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.L0)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(23, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(237, 224)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "输入光功率"
        '
        'LightInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 250)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "LightInput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "光源功率控制"
        CType(Me.L0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.L1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.L2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.L3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents L0 As System.Windows.Forms.NumericUpDown
    Friend WithEvents L1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents L2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents L3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
