Imports System.Threading
Imports XGPub_FncModule.clsConfigFile
Imports XGPub_FncModule.clsArray
Imports XGPub_FncModule.clsDBControl
Imports System.IO

Public Class frmMain
#Region "Property"
    Public Resistance As Boolean
    Public Response As Boolean
    Public Voltage As Boolean
    Public USBAdd As String
    Public DMAdd As String
    Public Lights(3) As Integer
    Public UserName As String
    Public TestPCName As String
    Private DMMS As New GPIBDev
    Private mThread As Thread
    Private mThread1 As Thread
    Private isStopTest As Boolean = False
    Dim SQL As New XGPub_FncModule.clsDBControl
    Dim I2C As New I2C_USB
    Dim picProcessGif As New PictureBox
    Dim lstResult As New List(Of Boolean)
    Dim Result As Boolean
    Dim ChangeRange As Boolean
    Dim Current As Boolean
    Dim TestState As String = ""
    Dim VoResRe As String = ""
#End Region

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Call GetConfigInfor()
        Call CheckDB_Connect()
        txtTOSASN.CharacterCasing = CharacterCasing.Upper
        ' Dim strData As String
        'NewSourceGrid1.Size = New Size(527, 176)
        'Updates.Visible = False
        NewSourceGrid1.ClearAllRow()
        NewSourceGrid1.MaxColumn = 10
        NewSourceGrid1.MaxRow = 48
        NewSourceGrid1.ResizeColumn = False
        NewSourceGrid1.Rows(0).Height = 48
        NewSourceGrid1.Columns(0).Width = 25
        NewSourceGrid1.SetColumnHeader(1, "测试项", 153)
        NewSourceGrid1.SetColumnHeader(2, "电阻/DC/响应度 最大值", 90)
        NewSourceGrid1.SetColumnHeader(3, "电阻/DC/响应度 最小值", 90)
        NewSourceGrid1.SetColumnHeader(4, "电阻 实际值", 60)
        NewSourceGrid1.SetColumnHeader(5, "电压 实际值", 60)
        NewSourceGrid1.SetColumnHeader(6, "电流 实际值", 60)
        NewSourceGrid1.SetColumnHeader(7, "温循前 响应度", 60)
        NewSourceGrid1.SetColumnHeader(8, "温循后 响应度", 60)
        NewSourceGrid1.SetColumnHeader(9, "响应度 误差值", 60)
        NewSourceGrid1.SetColumnHeader(10, "测试结果", 60)
        NewSourceGrid1.SetCellTypeToImageType(7)
        NewSourceGrid1.SetCellBackColor(, 1) = Color.WhiteSmoke
        NewSourceGrid1.SetCellBackColor(, 4) = Color.WhiteSmoke
        NewSourceGrid1.SetCellBackColor(, 5) = Color.WhiteSmoke
        NewSourceGrid1.SetCellBackColor(, 6) = Color.WhiteSmoke
        NewSourceGrid1.SetCellBackColor(, 7) = Color.WhiteSmoke
        '读取范围
        Dim RowCount As Integer
        Dim Data(,) As Object = Nothing
        Dim strSQL As String = "Select F_DiodeMax, F_ResMax ,F_ResMin  from T_ResCfgData_TOSA where F_PartNo='" & "LR-PB4-10D" & "'"
        RowCount = frmQuery.FetchAllData(strSQL, Data)
        If RowCount > 0 Then
            NewSourceGrid1.MaxRow = RowCount
            NewSourceGrid1.SetCellArrayValue(1, 2, Data)
        End If
        NewSourceGrid1.ColumnTextAlignment() = DevAge.Drawing.ContentAlignment.MiddleCenter
        For i As Integer = 1 To 48
            Select Case i
                Case 1 To 43
                    NewSourceGrid1.SetCellTypeToCheckBoxType(i, 1, False, PINS(i - 1))
                Case 44 To 48
                    NewSourceGrid1.SetCellValue(i, PINS(i - 1))
            End Select
        Next
        '只有Admin用户有修改权限
        Dim DataRes(,) As Object = Nothing
        Dim str As String = "select Privilege,AutoLogin from T_User where UserName = '" & UserName & "'"
        If FetchAllData(str, DataRes) = False Then Throw New Exception("数据库查询失败")
        If DataRes(0, 0) = "Admin" Then
            For b = 1 To 10
                NewSourceGrid1.CellOnlyRead(b) = True
            Next
            NewSourceGrid1.CellOnlyRead(2) = False
            NewSourceGrid1.CellOnlyRead(3) = False
            'Updates.Visible = True
            Engineer.Text = "管理员：" & UserName
            UpdateTest.Visible = True
            For a = 0 To 43
                NewSourceGrid1.SetCheckBoxTypeEnable(a + 1, 1) = True
            Next
        Else
            For a = 1 To 10
                NewSourceGrid1.CellOnlyRead(a) = True
            Next
            ' Updates.Visible = False
            Engineer.Text = "测试人员：" & UserName
            UpdateTest.Visible = False
            For a = 0 To 43
                NewSourceGrid1.SetCheckBoxTypeEnable(a + 1, 1) = False
            Next
        End If
        ConfigManager.cbUSBAddr.Items.Clear()
        Dim usbAddress As String = ""
        For i As Integer = 0 To 7
            If USB_GetDeviceName(i, usbAddress) Then
                ConfigManager.cbUSBAddr.Items.Add(usbAddress)
            Else
                Exit For
            End If
        Next
        ConfigManager.ShowDialog()
        'strData = ReadConfig(iniFilePath, "ConfigData", "EVBAddr", "")
        'If strData = "" Then
        '    If ConfigManager.cbUSBAddr.Items.Count > 0 Then ConfigManager.cbUSBAddr.SelectedIndex = 0
        'Else
        '    ConfigManager.cbUSBAddr.Text = strData
        'End If
        'strData = ReadConfig(iniFilePath, "ConfigData", "DMMAddr", "")
        Label4.Text = "Ready"
        TestCountsAndTime()
    End Sub

    Private Sub cbUSBAddr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_AddressName = ConfigManager.cbUSBAddr.Text
    End Sub

    '测试次数管控
    Private TBID As Integer
    Private Status As String
    Public Sub TestCountsAndTime()
        Try
            Dim Counts(,) As Object = Nothing
            If FetchAllData("select b.F_CHCount,b.F_TBID,b.F_CHStatus from T_EvbConfig as a join T_EvbSubConfig as b on a.F_TBID = b.F_TBID where a.F_TBName='" & TestPCName & "'", Counts) = False Then Throw New Exception("数据读取失败")
            TestCount.Text = Counts(0, 0)
            TBID = Counts(0, 1)
            Status = Counts(0, 2)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub


    Public Sub UpdetaCount(ByVal ACounts As Integer)
        Try
            If SQL.OpenConnection(ConnectString) = False Then Throw New Exception("数据库连接失败")
            Dim CHCount() As String = {"F_CHCount"}
            Dim strTBID() As String = {"F_TBID"}
            Dim Count() As Object = {ACounts}
            Dim ID() As Object = {TBID}
            If SQL.UpdateData("T_EvbSubConfig", CHCount, strTBID, Count, ID) = False Then Throw New Exception("更新测试次数失败")
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub


    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        If USBAdd = "" Then
            MsgBox("请先配置测试环境。", vbCritical, "提示")
            Return
        Else
            'If ConfigManager.cbUSBAddr.Items.Count > 0 Then
            I2C.DeviceName = USBAdd '获取 设备名称 当前选定项  当为空时 抛出异常 
        End If
        Try
            If TestCount.Text <= 0 Or Status = "EOL" Then Throw New Exception("请更换测试板以及其他组件")
            If btnStart.Text = "开始测试" Then
                Label4.Text = "Testing.."
                Label4.ForeColor = Color.Blue
                btnStart.Text = "停止测试"
                If txtTOSASN.Text = "" Then
                    MsgBox("没有输入序列号，请重新输入！", vbCritical, "错误")
                    btnStart.Text = "开始测试"
                    Return
                End If
                WriteConfig(iniFilePath, "ConfigData", "EVBAddr", ConfigManager.cbUSBAddr.Text)
                WriteConfig(iniFilePath, "ConfigData", "DMMAddr", ConfigManager.cbDMAddr.Text)
                isStopTest = False
                lstResult.Clear()
                m_AddressName = USBAdd
                Dim LDOEnable(0) As Byte
                LDOEnable(0) = 0
                '清除
                ClearAll()
                mThread = New Thread(New ThreadStart(AddressOf RunTimeTest))
                mThread.Start()
                Do Until mThread.IsAlive = False
                    Thread.Sleep(10)
                    Application.DoEvents()
                Loop
                Dim TestResult As Boolean = True
                For i As Integer = 0 To lstResult.Count - 1
                    If lstResult(i) = False Then
                        TestResult = False
                        Exit For
                    End If
                Next
                Label4.Text = IIf(TestResult = True, "PASS", "NG")
                Label4.ForeColor = IIf(TestResult = True, Color.Green, Color.Red)
                btnStart.Text = "开始测试"
            Else
                isStopTest = True
                btnStart.Text = "开始测试"
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        Finally
            txtTOSASN.Focus()
            txtTOSASN.SelectAll()
            TestCount.Text -= 1
            UpdetaCount(TestCount.Text)
        End Try
    End Sub

    Private Sub ClearAll()
        If ConfigManager.ResponseTest.Checked = True Then
            For i As Integer = 1 To 43
                NewSourceGrid1.SetCellValue(i, 4, Nothing) '1-43行的第4,5,6，7，8,9,10列
                NewSourceGrid1.SetCellValue(i, 5, Nothing)
                NewSourceGrid1.SetCellValue(i, 6, Nothing)
                NewSourceGrid1.SetCellValue(i, 7, Nothing)
                NewSourceGrid1.SetCellValue(i, 8, Nothing)
                NewSourceGrid1.SetCellValue(i, 9, Nothing)
                NewSourceGrid1.SetCellValue(i, 10, Nothing)
            Next
        Else
            For i As Integer = 1 To 48
                NewSourceGrid1.SetCellValue(i, 4, Nothing)
                NewSourceGrid1.SetCellValue(i, 5, Nothing)
                NewSourceGrid1.SetCellValue(i, 6, Nothing)
                NewSourceGrid1.SetCellValue(i, 7, Nothing)
                NewSourceGrid1.SetCellValue(i, 8, Nothing)
                NewSourceGrid1.SetCellValue(i, 9, Nothing)
                NewSourceGrid1.SetCellValue(i, 10, Nothing)
            Next
        End If
    End Sub



    Private relayData() As UInt32 = {&H5, &H801, &H1001, &H10001, &H100001, &H1000001, &H10000001, &H2001, &H8001, &H20001, &H80001,
                                &H200001, &H800001, &H2000001, &H8000001, &HC000, &HC0000, &HC00000, &HC000000, &H9,
                                 &H11, &H41, &H81, &H101, &H401, &H600, &H280, &H60, &H28, &H8002, &H2002, &H80002, &H20002, &H800002, &H200002, &H8000002, &H2000002, &H402}
    Private ResRange() As Integer = {1, 1, 1, 1, 1, 1, 1, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1, 1, 1, 1, 1000000, 1000000, 1000000, 1000000, 1000000, 1000, 1000000, 1000000, 1000000, 1000000}
    Private PINS() As String = {"DCP5-DCP1(Ω)", "DCP5-DCP9(Ω)", "DCP5-RFS1(Ω)", "DCP5-RFS4(Ω)", "DCP5-RFS7(Ω)", "DCP5-RFS10(Ω)", "DCP5-RFS13(Ω)",
                                        "DCP5-OUTN0(KΩ)", "DCP5-OUTP0(KΩ)", "DCP5-OUTN1(KΩ)", "DCP5-OUTP1(KΩ)", "DCP5-OUTN2(KΩ)", "DCP5-OUTP2(KΩ)",
                                        "DCP5-OUTN3(KΩ)", "DCP5-OUTP3(KΩ)", "OUTN0-OUTP0(Ω)", "OUTN1-OUTP1(Ω)", "OUTN2-OUTP2(Ω)", "OUTN3-OUTP3(Ω)",
                                        "DCP5-R_EXT(MΩ)", "DCP5-RSSI0(MΩ)", "DCP5-RSSI1(MΩ)", "DCP5-RSSI2(MΩ)", "DCP5-RSSI3(MΩ)", "DCP5-VDD(KΩ)", "VDD-RSSI3(MΩ)", "RSSI3-RSSI2(MΩ)",
                                        "RSSI1-RSSI0(MΩ)", "RSSI0-R_EXT(MΩ)", "OUTP0(V)", "OUTN0(V)", "OUTP1(V)", "OUTN1(V)", "OUTP2(V)", "OUTN2(V)", "OUTP3(V)", "OUTN3(V)", "VDD Voltage(V)", "Id Lane0（nA）",
                             "Id Lane1 (nA)", "Id Lane2 (nA)", "Id Lane3 (nA)", "无光:ICC 电流 (mA)", "加光：L0 响应度 (A/W)", "加光：L1 响应度 (A/W)", "加光：L2 响应度 (A/W)", "加光：L3 响应度 (A/W)", "加光：ICC 电流 (mA)"}

    Private Sub RunTimeTest()
        Dim K2() As Byte = {&H0, &H0, &H0, &H2}
        Dim Nolight(0) As Byte
        Dim Data5(1) As Byte
        Dim Mark() As Integer = {18, 20, 22, 24, 26}
        Dim Mark2 As Integer = 18
        Dim VolValue(3) As Byte
        Dim aValue As New List(Of Integer)
        Dim RelaysValue(3) As Byte
        Dim gpibAddress As String = DMAdd
        Dim OE(0) As Byte
        Dim ErrorInfor As String = ""
        Dim LDOEnable(0) As Byte
        Dim fResVol As Single
        OE(0) = 1
        LDOEnable(0) = 0
        I2C.I2C_WriteData(&HC2, 244, LDOEnable, 1)
        I2C.I2C_WriteData(&HC2, 249, OE, 1)
        For a1 = 1 To 43
            If NewSourceGrid1.GetCellValue(a1, 1) = True Then
                aValue.Add(a1)
            End If
        Next
        For a = 0 To aValue.Count - 1
            '电阻 自动量程
            If DMMS.OpenVISA(gpibAddress) = False Then Exit For
            If isStopTest Then Exit For
            If aValue(a) <= 19 And aValue(a) >= 1 Then
                'I2C.I2C_ReadData(&HC2, 245, RelaysValue, 4)
                RelaysValue = BitConverter.GetBytes(relayData(aValue(a) - 1))
                Array.Reverse(RelaysValue)
                I2C.I2C_WriteData(&HC2, 245, RelaysValue, 4)
                fResVol = ReadResistanceFrom34450A(gpibAddress) / ResRange(aValue(a) - 1)
                Result = CheckResResult(aValue(a), fResVol, 4)
                lstResult.Add(Result)
                '电阻 10兆欧为量程
            ElseIf aValue(a) <= 29 And aValue(a) >= 20 Then
                'I2C.I2C_ReadData(&HC2, 245, RelaysValue, 4)
                RelaysValue = BitConverter.GetBytes(relayData(aValue(a) - 1))
                Array.Reverse(RelaysValue)
                I2C.I2C_WriteData(&HC2, 245, RelaysValue, 4)
                fResVol = ReadMgeFrom34450A(gpibAddress, 10000000) / ResRange(aValue(a) - 1)
                Result = CheckResResult(aValue(a), fResVol, 4)
                lstResult.Add(Result)
                '电压
            ElseIf aValue(a) <= 38 And aValue(a) >= 30 Then
                LDOEnable(0) = 1
                I2C.I2C_WriteData(&HC2, 244, LDOEnable, 1)
                VolValue = BitConverter.GetBytes(relayData(aValue(a) - 1))
                Array.Reverse(VolValue)
                I2C.I2C_WriteData(&HC2, 245, VolValue, 4)
                fResVol = ReadDcFrom34450A(gpibAddress)
                Result = CheckResResult(aValue(a), fResVol, 5)
                lstResult.Add(Result)
                '暗电流
            ElseIf aValue(a) <= 43 And aValue(a) >= 39 Then
                LDOEnable(0) = 1
                I2C.I2C_WriteData(&HC2, 244, LDOEnable, 1)
                I2C.I2C_WriteData(&HC2, 245, K2, 4)
                OE(0) = 0
                I2C.I2C_WriteData(&HC2, 249, OE, 1)
                Nolight(0) = 1
                I2C.I2C_WriteData(&HC2, 250, Nolight, 1)
                I2C.I2C_ReadData(&HC2, Mark(aValue(a) - 39), Data5, 2)
                fResVol = ((Data5(0) * 256) + Data5(1)) * 1
                If aValue(a) = 43 Then
                    fResVol = ((Data5(0) * 256) + Data5(1)) * 0.01
                End If
                Result = CheckResResult(aValue(a), fResVol, 6)
                lstResult.Add(Result)
            End If
            If aValue(a) > 14 Then NewSourceGrid1.VScrollBar.Value = aValue(a) - 14
            If aValue(a) <= 14 Then NewSourceGrid1.VScrollBar.Value = 0
            ErrorInfor = ""
            If Result = False Then
                ErrorInfor = PINS(a) & ":NG"
            End If
            Call SaveResistanceTest(txtTOSASN.Text, Label1.Text, PINS(aValue(a) - 1), fResVol, Result, ErrorInfor)
        Next
        '加盖前/后响应度
        I2C.I2C_WriteData(&HC2, 245, K2, 4)
        OE(0) = 0
        I2C.I2C_WriteData(&HC2, 249, OE, 1)
        LDOEnable(0) = 1
        I2C.I2C_WriteData(&HC2, 244, LDOEnable, 1)
        Dim fr As New LightInput
        For a3 = 43 To 47
            If isStopTest Then Exit For
            If Response = False Then Exit For
            NewSourceGrid1.VScrollBar.Value = 34
            Nolight(0) = 0
            I2C.I2C_WriteData(&HC2, 250, Nolight, 1)
            I2C.I2C_ReadData(&HC2, Mark2, Data5, 2)
            Select Case a3
                Case 43 To 46
                    If Response = True And Label1.Text = "温循前" Then
                        Dim Values9 As Double = NewSourceGrid1.GetCellValue(a3 + 1, 8)
                        fResVol = (((Data5(0) * 256) + Data5(1)) * 1) / Lights(a3 - 43)
                        NewSourceGrid1.SetCellValue(a3 + 1, 9, (Values9 - fResVol).ToString("0.00"))
                        Result = CheckResponse(a3 + 1, fResVol, Values9 - fResVol, 7)
                    ElseIf Response = True And Label1.Text = "温循后" Then
                        Dim Values10 As Double = NewSourceGrid1.GetCellValue(a3 + 1, 7)
                        fResVol = (((Data5(0) * 256) + Data5(1)) * 1) / Lights(a3 - 43)
                        NewSourceGrid1.SetCellValue(a3 + 1, 9, (fResVol - Values10).ToString("0.00"))
                        Result = CheckResponse(a3 + 1, fResVol, fResVol - Values10, 8)
                    End If
                Case 47
                    If Response = True And Label1.Text = "温循前" Then
                        fResVol = ((Data5(0) * 256) + Data5(1)) * 0.01
                        Result = CheckResResult(a3 + 1, fResVol, 7)
                    ElseIf Response = True And Label1.Text = "温循后" Then
                        fResVol = ((Data5(0) * 256) + Data5(1)) * 0.01
                        Result = CheckResResult(a3 + 1, fResVol, 8)
                    End If
            End Select
            lstResult.Add(Result)
            Mark2 += 2
            ErrorInfor = ""
            If Result = False Then
                ErrorInfor = PINS(a3) & ":NG"
            End If
            Call SaveResistanceTest(txtTOSASN.Text, Label1.Text, PINS(a3), fResVol, Result, ErrorInfor)
        Next
        LDOEnable(0) = 0
        I2C.I2C_WriteData(&HC2, 244, LDOEnable, 1)
    End Sub

    Dim LinkedControl As SourceGrid.LinkedControlValue
    Private Sub Update_SNGridView_Process(ByVal CurrentChannel As Integer)
        picProcessGif.Image = My.Resources.Process
        picProcessGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        LinkedControl = New SourceGrid.LinkedControlValue(picProcessGif, New SourceGrid.Position(CurrentChannel, 7))
        NewSourceGrid1.LinkedControls.Add(LinkedControl)
        Dim ColWidth As Integer = NewSourceGrid1.Columns(7).Width
        NewSourceGrid1.Columns(7).Width = ColWidth / 2
        NewSourceGrid1.Columns(7).Width = ColWidth
        NewSourceGrid1.Refresh()
    End Sub

    Private Function CheckResResult(ByVal Channel As Integer, ByVal fResVal As Single, ByVal a As Integer) As Boolean
        Dim MaxVal As Single = NewSourceGrid1.GetCellValue(Channel, 2)
        Dim MinVal As Single = NewSourceGrid1.GetCellValue(Channel, 3)
        Dim Result As Boolean = IIf(fResVal >= MinVal And fResVal <= MaxVal, True, False)
        NewSourceGrid1.SetCellValue(Channel, a, fResVal.ToString("0.##")) '.ToString("0.00")
        NewSourceGrid1.SetCellForeColor(Channel, a) = IIf(Result, Color.Black, Color.Red)
        'Update_SNGridView_Reslut(Channel, Result)
        Me.Invoke(New Action(Of Integer, Boolean)(AddressOf Update_SNGridView_Reslut), Channel, Result)
        Return Result
    End Function

    Private Function CheckResponse(ByVal Channel As Integer, ByVal fResVal As Single, ByVal fResponse As Single, ByVal a As Integer) As Boolean
        Dim MaxVal As Single = NewSourceGrid1.GetCellValue(Channel, 2)
        Dim MinVal As Single = NewSourceGrid1.GetCellValue(Channel, 3)
        Dim Result As Boolean = IIf(fResponse >= MinVal And fResVal <= MaxVal, True, False)
        NewSourceGrid1.SetCellValue(Channel, a, fResVal.ToString("0.00"))
        NewSourceGrid1.SetCellForeColor(Channel, 9) = IIf(Result, Color.Black, Color.Red)
        'Update_SNGridView_Reslut(Channel, Result)
        Me.Invoke(New Action(Of Integer, Boolean)(AddressOf Update_SNGridView_Reslut), Channel, Result)
        Return Result
    End Function

    'Private Function CheckResAndDiodeResult(ByVal Channel As Integer, ByVal fResVal As Single, ByVal fDiodeVal As Single) As Boolean
    '    Dim ResMaxVal As Single = NewSourceGrid1.GetCellValue(Channel, 2)
    '    Dim ResMinVal As Single = NewSourceGrid1.GetCellValue(Channel, 3)
    '    Dim Result1 As Boolean = IIf(fResVal >= ResMinVal And fResVal <= ResMaxVal, True, False)
    '    NewSourceGrid1.SetCellValue(Channel, 6, fResVal.ToString("0.00"))
    '    NewSourceGrid1.SetCellForeColor(Channel, 6) = IIf(Result1, Color.Black, Color.Red)
    '    Dim DiodeMaxVal As Single = NewSourceGrid1.GetCellValue(Channel, 4)
    '    Dim DiodeMinVal As Single = NewSourceGrid1.GetCellValue(Channel, 5)
    '    Dim Result2 As Boolean = IIf(fDiodeVal >= DiodeMinVal And fDiodeVal <= DiodeMaxVal, True, False)
    '    NewSourceGrid1.SetCellValue(Channel, 7, fDiodeVal.ToString("0.000"))
    '    NewSourceGrid1.SetCellForeColor(Channel, 7) = IIf(Result2, Color.Black, Color.Red)
    '    Me.Invoke(New Action(Of Integer, Boolean)(AddressOf Update_SNGridView_Reslut), Channel, Result1 And Result2)
    '    'Update_SNGridView_Reslut(Channel, Result1 And Result2)
    '    Return Result1 And Result2
    'End Function

    Private Sub Update_SNGridView_Reslut(ByVal iChannel As Integer, ByVal Result As Boolean)
        'NewSourceGrid1.LinkedControls.Remove(LinkedControl)
        If iChannel = NewSourceGrid1.MaxRow Then
            NewSourceGrid1.LinkedControls.Clear()
        End If
        NewSourceGrid1(iChannel, 10).Value = Nothing
        NewSourceGrid1(iChannel, 10).Image = IIf(Result, My.Resources.check, My.Resources.x)
        Dim ColWidth As Integer = NewSourceGrid1.Columns(7).Width
        NewSourceGrid1.Refresh()
        'NewSourceGrid1.SelectNextControl(NewSourceGrid1.Rows(17), True)
    End Sub

    Private Sub frmMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtTOSASN.Focus()
    End Sub

    Public Function SaveResistanceTest(ByVal SN As String, ByVal TestType As String, ByVal ItemType As String, ByVal value As Single, ByVal Result As Boolean, ByVal strInfor As String) As Boolean
        Try
            If SQL.OpenConnection(ConnectString) = False Then Throw New Exception("数据库连接失败")
            Dim Columns() As String = {"F_SN", "F_TestType", "F_ItemType", "F_Value", "F_Reslut", "F_PCName", "F_Remark"}
            Dim Data() As Object = {SN, TestType, ItemType, value, IIf(Result, "Pass", "NG"), My.Computer.Name, strInfor}
            If SQL.InsertData("T_ResData_TOSA", Columns, Data) = False Then
                Throw New Exception("写入失败")
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Function UpdateResistanceRange(ByVal SN As String, ByVal Item As String, ByVal ResMax As Double, ByVal ResMin As Double, ByVal x As Integer, ByVal DateNow As Date) As Boolean
        Try
            Dim j(47) As String '= {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48}
            For a = 0 To 47
                j(a) = a + 1
            Next
            If SQL.OpenConnection(ConnectString) = False Then Throw New Exception("数据库连接失败")
            Dim Columns() As String = {"F_PartNo", "F_Item", "F_ResMax", "F_ResMin", "F_Date"}
            Dim Data() As Object = {SN, Item, ResMax, ResMin, DateNow}
            Dim Columns1() As String = {"IDX"}
            Dim Data1() As Object = {j(x)}
            If SQL.UpdateData("T_ResCfgData_TOSA", Columns, Columns1, Data, Data1) = False Then
                Throw New Exception("更新失败")
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Private Sub MenuQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQuery.Click
        frmQuery.ShowDialog()
    End Sub

    Private Sub 手动控制ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 手动控制ToolStripMenuItem.Click
        RelaysControl.ShowDialog()
    End Sub


    '更新
    'Private Sub Updates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Updates.Click
    'If MsgBox("确定要更新测试范围？", vbYesNo, "提示") = vbYes Then
    '    Dim PathData As String = Application.StartupPath & "\Change.txt"
    '    Dim sw As StreamWriter = New StreamWriter(PathData, True)
    '    Dim RowCount As Integer
    '    Dim Data(,) As Object = Nothing
    '    Dim strSQL As String = "Select  F_ResMax ,F_ResMin  from T_ResCfgData_TOSA where F_PartNo='" & "LR-PB4-10D" & "'"
    '    RowCount = frmQuery.FetchAllData(strSQL, Data)

    '    For i = 0 To 47
    '        Dim strDatas As Double = NewSourceGrid1.GetCellValue(i + 1, 2)
    '        Dim strData1 As Double = NewSourceGrid1.GetCellValue(i + 1, 3)
    '        If strDatas <> Val(Data(i, 0)) Then
    '            sw.Write(PINS(i) & "," & "最大值从" & Data(i, 0) & "修改为" & strDatas & "," & Date.Now & "," & UserName & vbCrLf)
    '            sw.Flush()
    '        End If
    '        If strData1 <> Val(Data(i, 1)) Then
    '            sw.Write(PINS(i) & "," & "最小值从" & Data(i, 1) & "修改为" & strData1 & "," & Date.Now & "," & UserName & vbCrLf)
    '            sw.Flush()
    '        End If
    '    Next
    '    sw.Close()
    '    '更新范围
    '    For x = 0 To 47
    '        Dim b As String = PINS(x)
    '        Dim a As Double = NewSourceGrid1.GetCellValue(x + 1, 2)
    '        Dim c As Double = NewSourceGrid1.GetCellValue(x + 1, 3)
    '        Call UpdateResistanceRange("LR-PB4-10D", b, a, c, x, Date.Now)
    '    Next
    '    MsgBox("更新成功!", vbOKOnly, "信息")
    'End If
    'End Sub

    Private Sub 配置中心ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 配置中心ToolStripMenuItem.Click
        ConfigManager.ShowDialog()
    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TimeShow.Text = Date.Now
    End Sub

    Private Sub 更新测试范围ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateTest.Click
        If MsgBox("确定要更新测试范围？", vbYesNo, "提示") = vbYes Then
            Dim PathData As String = Application.StartupPath & "\Change.txt"
            Dim sw As StreamWriter = New StreamWriter(PathData, True)
            Dim RowCount As Integer
            Dim Data(,) As Object = Nothing
            Dim strSQL As String = "Select  F_ResMax ,F_ResMin  from T_ResCfgData_TOSA where F_PartNo='" & "LR-PB4-10D" & "'"
            RowCount = frmQuery.FetchAllData(strSQL, Data)

            For i = 0 To 47
                Dim strDatas As Double = NewSourceGrid1.GetCellValue(i + 1, 2)

                Dim strData1 As Double = NewSourceGrid1.GetCellValue(i + 1, 3)
                If strDatas <> Val(Data(i, 0)) Then
                    sw.Write(PINS(i) & "," & "最大值从" & Data(i, 0) & "修改为" & strDatas & "," & Date.Now & "," & UserName & vbCrLf)
                    sw.Flush()
                End If
                If strData1 <> Val(Data(i, 1)) Then
                    sw.Write(PINS(i) & "," & "最小值从" & Data(i, 1) & "修改为" & strData1 & "," & Date.Now & "," & UserName & vbCrLf)
                    sw.Flush()
                End If
            Next
            sw.Close()
            '更新范围
            For x = 0 To 47
                Dim b As String = PINS(x)
                Dim a As Double = NewSourceGrid1.GetCellValue(x + 1, 2)
                Dim c As Double = NewSourceGrid1.GetCellValue(x + 1, 3)
                Call UpdateResistanceRange("LR-PB4-10D", b, a, c, x, Date.Now)
            Next
            MsgBox("更新成功!", vbOKOnly, "信息")
        End If
    End Sub

    Private Sub 退出ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 退出ToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
