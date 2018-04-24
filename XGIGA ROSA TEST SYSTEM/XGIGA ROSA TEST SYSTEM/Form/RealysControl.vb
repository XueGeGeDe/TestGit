Imports XGPub_FncModule.clsConfigFile
Public Class RelaysControl
#Region "全局变量"
    Private Data4(3) As Byte
    Private RssADC(3) As Double
    Private DMM As New GPIBDev
    Dim abit As Byte
#End Region
    Dim refreshs As Boolean
    Dim I2C As New I2C_USB
    Dim Check(28) As CheckBox
    Public Sub CheckBox_CheckedChanlged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If refreshs = False Then Return
        Dim DecVal As UInteger = 0
        For i = 0 To 28 Step 1
            If Check(i).Checked Then
                DecVal += 1 << i
            End If
        Next
        Data4 = BitConverter.GetBytes(DecVal)
        Array.Reverse(Data4)
        I2C.I2C_WriteData(&HC2, 245, Data4, 4)
    End Sub

    Private Sub RelaysControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        refreshs = False
        If ConfigManager.cbUSBAddr.Items.Count > 0 Then
            I2C.DeviceName = ConfigManager.cbUSBAddr.SelectedItem.ToString
        End If
        For i = 0 To 28 Step 1
            Check(i) = Me.CBControlRelay.Controls.Item("CheckBox" & (i + 1))
            AddHandler Check(i).CheckedChanged, AddressOf CheckBox_CheckedChanlged
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim gpiAddr As String = ConfigManager.cbDMAddr.Text
        Dim relVal As Single
        If DMM.OpenVISA(gpiAddr) = False Then
            MsgBox("连接万用表失败")
        End If
        relVal = ReadResistanceFrom34450A(gpiAddr)
    End Sub

    Private Sub RelaysControl_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        DMM.CloseVISA()
    End Sub
    '回读继电器
    Dim Light(0) As Byte
    Dim Power(0) As Byte
    Dim SN74CB3Q325(0) As Byte
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If frmMain.USBAdd <> "" Then
            I2C.DeviceName = frmMain.USBAdd
        Else
            MsgBox("请先配置。", vbCritical, "错误")
            Return
        End If
        Dim Relays(3) As Byte
        Dim realValue As UInt32
        Dim gpibAddress As String
        I2C.I2C_ReadData(&HC2, 245, Relays, 4)
        Array.Reverse(Relays)
        realValue = BitConverter.ToInt32(Relays, 0)
        I2C.I2C_ReadData(&HC2, 250, Light, 1)
        I2C.I2C_ReadData(&HC2, 244, Power, 1)
        I2C.I2C_ReadData(&HC2, 249, SN74CB3Q325, 1)
        gpibAddress = ReadConfig(iniFilePath, "ConfigData", "DMMAddr", "")
        Dim DevName As String = ""
        AddLight.Checked = IIf(Light(0) = 1, False, True)
        ChipOrNo.Checked = IIf(Power(0) = 0, False, True)
        SN74C.Checked = IIf(SN74CB3Q325(0) = 0, True, False)
        For a = 0 To 28
            If (realValue And (&H1 << a)) = 0 Then
                Check(a).Checked = False
            Else
                Check(a).Checked = True
            End If
        Next
        refreshs = True
    End Sub
    '加光
    Private Sub AddLight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Light(0) = IIf(AddLight.Checked = False, 1, 0)
            I2C.I2C_WriteData(&HC2, 250, Light, 1)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "错误")
        End Try
    End Sub

    'SN74C开关
    Private Sub SN74C_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            SN74CB3Q325(0) = IIf(SN74C.Checked = True, 0, 1)
            I2C.I2C_WriteData(&HC2, 249, SN74CB3Q325, 1)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "错误")
        End Try
    End Sub
    '芯片供电
    Private Sub ChipOrNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChipOrNo.CheckedChanged
        Try
            Power(0) = IIf(ChipOrNo.Checked = True, 1, 0)
            I2C.I2C_WriteData(&HC2, 244, Power, 1)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "错误")
        End Try       
    End Sub
End Class