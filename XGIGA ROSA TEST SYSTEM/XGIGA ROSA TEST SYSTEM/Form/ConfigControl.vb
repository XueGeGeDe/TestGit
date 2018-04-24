Imports XGPub_FncModule.clsConfigFile
Public Class ConfigManager
 
    ''电阻测试
    'Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Resistance = IIf(CBRES.Checked = True, True, False)
    '    For i = 1 To 29
    '        frmMain.NewSourceGrid1.SetCellValue(i, Resistance)
    '    Next
    'End Sub

    ''电压测试
    'Private Sub CBVOL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Voltage = IIf(CBVOL.Checked = True, True, False)
    '    For i = 30 To 43
    '        frmMain.NewSourceGrid1.SetCellValue(i, Voltage)
    '    Next
    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim TestState As String = ""
        Dim VoResRe As String = ""
        TestState = IIf(BeforeStamp.Checked = True, "加盖前", TestState)
        TestState = IIf(AfterStamp.Checked = True, "加盖后", TestState)
        TestState = IIf(BeforeTC.Checked = True, "温循前", TestState)
        TestState = IIf(AfterTC.Checked = True, "温循后", TestState)
        VoResRe = IIf(CBRES.Checked = True, "短路测试 " & VoResRe, VoResRe)
        VoResRe = IIf(CBVOL.Checked = True, "DC测试 " & VoResRe, VoResRe)
        VoResRe = IIf(ResponseTest.Checked = True, "响应度测试 " & VoResRe, VoResRe)
        frmMain.Label1.Text = TestState
        frmMain.Label2.Text = VoResRe
        frmMain.Resistance = IIf(CBRES.Checked = True, True, False)
        For i = 1 To 29
            frmMain.NewSourceGrid1.SetCellValue(i, frmMain.Resistance)
        Next
        frmMain.Voltage = IIf(CBVOL.Checked = True, True, False)
        For i = 30 To 43
            frmMain.NewSourceGrid1.SetCellValue(i, frmMain.Voltage)
        Next
        frmMain.Response = IIf(ResponseTest.Checked = True, True, False)
        frmMain.DMAdd = cbDMAddr.Text
        frmMain.USBAdd = cbUSBAddr.Text
        Me.Visible = False
    End Sub

    '响应度测试
    Private Sub ResponseTest_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResponseTest.CheckedChanged
        frmMain.Response = IIf(ResponseTest.Checked = True, True, False)
        If ResponseTest.Checked = True Then
            LightInput.ShowDialog()
        End If
    End Sub

    Private Sub ConfigManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strData As String
        strData = ReadConfig(iniFilePath, "ConfigData", "EVBAddr", "")
        If strData = "" Then
            If cbUSBAddr.Items.Count > 0 Then cbUSBAddr.SelectedIndex = 0
        Else
            cbUSBAddr.Text = strData
        End If
        strData = ReadConfig(iniFilePath, "ConfigData", "DMMAddr", "")
        If strData = "" Then
            If cbDMAddr.Items.Count > 0 Then cbDMAddr.SelectedIndex = 0
        Else
            cbDMAddr.Text = strData
        End If
        frmMain.TestPCName = cbUSBAddr.Text
    End Sub
End Class