<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuery
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
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnQuerySN = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnQuerySNs = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSNEnd = New System.Windows.Forms.TextBox()
        Me.txtSNStart = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SourceGrid1 = New xgSourceGrid.NewSourceGrid(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSN
        '
        Me.txtSN.Location = New System.Drawing.Point(71, 27)
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(112, 21)
        Me.txtSN.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "序列号"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.btnQuerySN)
        Me.GroupBox1.Controls.Add(Me.txtSN)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(361, 85)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "按单个序列号查询"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(242, 51)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 27)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "查询所有数据"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnQuerySN
        '
        Me.btnQuerySN.Location = New System.Drawing.Point(243, 18)
        Me.btnQuerySN.Name = "btnQuerySN"
        Me.btnQuerySN.Size = New System.Drawing.Size(112, 27)
        Me.btnQuerySN.TabIndex = 6
        Me.btnQuerySN.Text = "查询最后一次"
        Me.btnQuerySN.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.btnQuerySNs)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtSNEnd)
        Me.GroupBox2.Controls.Add(Me.txtSNStart)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(404, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(395, 85)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "按序列号范围查询"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(297, 49)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 27)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "查询所有数据"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 12)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "例如SN:001~100"
        '
        'btnQuerySNs
        '
        Me.btnQuerySNs.Location = New System.Drawing.Point(186, 49)
        Me.btnQuerySNs.Name = "btnQuerySNs"
        Me.btnQuerySNs.Size = New System.Drawing.Size(105, 27)
        Me.btnQuerySNs.TabIndex = 5
        Me.btnQuerySNs.Text = "查询最后一次"
        Me.btnQuerySNs.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(203, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "结束序列号"
        '
        'txtSNEnd
        '
        Me.txtSNEnd.Location = New System.Drawing.Point(272, 20)
        Me.txtSNEnd.Name = "txtSNEnd"
        Me.txtSNEnd.Size = New System.Drawing.Size(112, 21)
        Me.txtSNEnd.TabIndex = 3
        '
        'txtSNStart
        '
        Me.txtSNStart.Location = New System.Drawing.Point(85, 20)
        Me.txtSNStart.Name = "txtSNStart"
        Me.txtSNStart.Size = New System.Drawing.Size(112, 21)
        Me.txtSNStart.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "起始序列号"
        '
        'SourceGrid1
        '
        Me.SourceGrid1.BackColor = System.Drawing.Color.Gray
        Me.SourceGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SourceGrid1.CellOnlyRead = False
        Me.SourceGrid1.ClipboardMode = CType((((SourceGrid.ClipboardMode.Copy Or SourceGrid.ClipboardMode.Cut) _
                    Or SourceGrid.ClipboardMode.Paste) _
                    Or SourceGrid.ClipboardMode.Delete), SourceGrid.ClipboardMode)
        Me.SourceGrid1.ColumnsCount = 27
        Me.SourceGrid1.EnableSort = False
        Me.SourceGrid1.FixedColumns = 1
        Me.SourceGrid1.FixedRows = 1
        Me.SourceGrid1.Location = New System.Drawing.Point(12, 124)
        Me.SourceGrid1.MaxColumn = 26
        Me.SourceGrid1.MaxRow = 20
        Me.SourceGrid1.Name = "SourceGrid1"
        Me.SourceGrid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows
        Me.SourceGrid1.ResizeColumn = True
        Me.SourceGrid1.ResizeRow = True
        Me.SourceGrid1.RowHeight = 21
        Me.SourceGrid1.RowsCount = 21
        Me.SourceGrid1.SelectionMode = SourceGrid.GridSelectionMode.Cell
        Me.SourceGrid1.Size = New System.Drawing.Size(787, 228)
        Me.SourceGrid1.TabIndex = 6
        Me.SourceGrid1.TabStop = True
        Me.SourceGrid1.ToolTipText = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(12, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(563, 12)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "温馨提示:点下表左上角全选，可拷贝数据到EXCEL中；或右键菜单选择""Export CSV""直接导出到EXCEL中。"
        '
        'frmQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 364)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SourceGrid1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmQuery"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "数据查询"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnQuerySN As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnQuerySNs As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSNEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtSNStart As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SourceGrid1 As xgSourceGrid.NewSourceGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
