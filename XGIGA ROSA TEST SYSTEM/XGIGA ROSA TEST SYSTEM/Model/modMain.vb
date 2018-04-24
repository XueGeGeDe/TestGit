Imports System.Management
Module modMain
    Private Declare Function EncryptString Lib "XG_MathIO" (ByVal strSource As String, ByVal strTarget As String) As Integer
    Private Declare Function DecryptString Lib "XG_MathIO" (ByVal strSource As String, ByVal strTarget As String) As Integer
    Private Declare Sub EncryptFileByMD5 Lib "XG_MathIO" (ByVal fileName As String, ByVal strTarget As String)
    Public ConnectStrings As String
    Public isRD_ID As Boolean = False
    Public iniFileName As String = My.Application.Info.DirectoryPath & "\Config.ini"
    Public HexDataPath As String = My.Application.Info.DirectoryPath & "\data"
    Public HexDataFileName As String
    Public fis As New XGPub_FIS.FIS
    Public LotNo, PartNo, UserID, SN, TOSASN, MD5, CPUID As String
    Public SoftwareName As String = My.Application.Info.AssemblyName
    Public SoftwareVer As String = My.Application.Info.Version.ToString


    Public Structure _TOSADATA
        Public TEC As Single
        Public Iop As Single
        Public EA As Single
        Public VG As Single
        Public Po As Single
        Public WL As Single
        Public Imod As Single
        Public Cross As Single
    End Structure
    Public TOSADATA(3) As _TOSADATA

    Public Structure StructBurnCfg
        Public PartNo As String
        Public ProductType As String
        Public LaneCount As Integer
        Public BurnTOSA As Boolean
        Public FWName As String
        Public FWVer As String
        Public FWMD5 As String
        Public A0_Addr As UInteger
        Public MI_Addr As UInteger    'MI=5C
        Public LUT_IBias As UInteger
        Public LUT_Imod As UInteger
        Public SN_Addr As Integer
        Public FWData() As Byte
        Public SN_Table As Integer
    End Structure
    Public BurnCfgData As StructBurnCfg
    Public FLASH_A0_ADDR As UInteger = &H8200
    Public FLASH_5C_ADDR As UInteger = &H8A00
    Public FLASH_LUT_IBias As UInteger = &H9800
    Public FLASH_LUT_Imod As UInteger = &H9000
    Public A0_SN_ADDR As Byte = 196

    Sub main()
        CPUID = GetCPUID()
        MD5 = GetFileMD5(Application.StartupPath & "\" & SoftwareName & ".exe")
        If IO.Directory.Exists(HexDataPath) = False Then
            IO.Directory.CreateDirectory(HexDataPath)
        End If
        If fis.FIS_InitOK = False Then
            MsgBox("FIS连接失败！", vbCritical, "Error")
            End
        End If
        'ConnectString = "Server=(local);Data Source=192.168.1.23;Initial Catalog=TestData;Persist Security Info=True;User ID=xgiga;Password=Test2015"
        ConnectStrings = fis.GetConnectionString
        If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then
            MsgBox("当前程序已经在运行，不支持打开多个！", vbCritical, "错误")
            End
        End If
        If System.Diagnostics.Debugger.IsAttached = False Then
            If VerifySW() = False Then End
        End If

        System.Windows.Forms.Application.EnableVisualStyles()
        frmLogin.ShowDialog()
        If frmLogin.isSuccess Then
            frmMain.ShowDialog()
            '    If frmInputPN.isSuccess Then
            '        frmMain.ShowDialog()
            '    End If
        End If
    End Sub

    Private Function PermissionWithoutNet(ByVal SoftwareName As String, ByVal SoftwareVer As String, ByVal CPUID As String, ByVal ErrorInfor As String) As Boolean
        Dim strVailDayMD5 As String = "00" & StringEncrypt("5") & "11"
        Dim strValue = GetSetting(SoftwareName, CPUID, "VaildDay", strVailDayMD5)
        Dim VaildDay As Integer = Val(StringDecrypt(Mid(strValue, 3, Len(strValue) - 4)))
        If VaildDay <= 0 Then
            MsgBox(ErrorInfor & ",您已没有使用权限,请联系管理员!", MsgBoxStyle.Exclamation, "错误")
            fis.SendMail("cary.zeng@xgiga.cn", Nothing, My.Computer.Name & ":权限已用完",
                         "Computer Name:" & My.Computer.Name & vbCrLf &
                         "CPUID:" & CPUID & vbCrLf &
                         "Software Name:" & SoftwareName & vbCrLf &
                         "Software Ver:" & SoftwareVer)
            'If MsgBox(ErrorInfor & ",您已没有使用权限,请联系管理员授权使用,是否继续？", MsgBoxStyle.Exclamation + vbYesNo, "错误") = MsgBoxResult.Yes Then
            'Dim MachineCode = GenerateMachineCode()
            'Dim RegCode As String
            'Dim strInfo As String = "授权ID为:" & MachineCode & ",请输入正确的注册码！"
            'Do
            '    RegCode = StringDecrypt(InputBox(strInfo, "软件注册", MachineCode))'MachineCode 为时间
            '    If RegCode = "" Then Exit Do
            '    Dim strDate = DateAndTime.DateAdd(DateInterval.Day, Val(RegCode), Date.Parse("1970-01-01 08:00:00"))
            '    Dim DayDiff As Integer = DateAndTime.DateDiff(DateInterval.Day, Now, strDate)
            '    If DayDiff <= 0 Then
            '        strInfo = "注册码失效,请重新输入！" & vbCrLf & "授权ID为:" & MachineCode & ",请输入正确的注册码！"
            '    Else
            '        MsgBox("注册成功,可使用天数:" & DayDiff & "天!", vbInformation, "注册")
            '        SaveSetting(SoftwareName, CPUID, "VaildDay", "00" & StringEncrypt(DayDiff.ToString) & "11")
            '        Exit Do
            '    End If
            'Loop
            'End If
            Return False
        Else
            MsgBox(ErrorInfor & ",您还有" & VaildDay & "天使用权限,请联系管理员!", MsgBoxStyle.Exclamation, "警告")
            Dim Last As Date = StringDecrypt(GetSetting(SoftwareName, CPUID, "LastDay", StringEncrypt(Now.ToString)))
            If DateAndTime.DateDiff(DateInterval.Day, Last, Now) > 0 Then
                VaildDay -= 1
                SaveSetting(SoftwareName, CPUID, "VaildDay", "00" & StringEncrypt(VaildDay.ToString) & "11")
                SaveSetting(SoftwareName, CPUID, "LastDay", StringEncrypt(Now.ToString))
            End If
            Return True
        End If
    End Function

    Private Function VerifySW() As Boolean
        Const SW_SUCCESS = &H0
        Const SW_DEBUG_SUCCESS = &H1
        Const SW_ERROR_NO_AUTHORIZE = &HBFFF0003
        Try
            Dim isAvailable = My.Computer.Network.IsAvailable
            'Dim isAvailable = False
            If isAvailable = False Then
                Return PermissionWithoutNet(SoftwareName, SoftwareVer, CPUID, "当前网络不通")
            Else
                If fis.FIS_InitOK = False Then
                    Return PermissionWithoutNet(SoftwareName, SoftwareVer, CPUID, "FIS连接失败")
                Else
                    Dim ErrorInfor As String = "OK"
                    Dim VerifyResult As Integer = fis.VerifySoftware(SoftwareName, SoftwareVer, MD5, CPUID, ErrorInfor)
                    If VerifyResult = SW_SUCCESS Then
                        Return True
                    Else
                        MsgBox(ErrorInfor, IIf(VerifyResult = SW_DEBUG_SUCCESS, MsgBoxStyle.Exclamation, MsgBoxStyle.Critical), "软件校验")
                        If VerifyResult = SW_DEBUG_SUCCESS Then Return True
                        Dim body As New System.Text.StringBuilder
                        body.AppendLine("Computer Name:" & My.Computer.Name)
                        body.AppendLine("CPUID:" & CPUID)
                        body.AppendLine("Software Name:" & SoftwareName)
                        body.AppendLine("Software Ver:" & SoftwareVer)
                        body.AppendLine(ErrorInfor)
                        If VerifyResult = SW_ERROR_NO_AUTHORIZE Then
                            fis.SendMail("cary.zeng@xgiga.cn", Nothing, My.Computer.Name & ":没有配置权限", body.ToString)
                        End If
                        Return False
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error")
            Return False
        End Try
    End Function

    Public Function StringEncrypt(ByVal strSource As String) As String
        Dim strTarget As String = Space(256)
        Dim size As Integer
        size = EncryptString(strSource, strTarget)
        StringEncrypt = LSet(strTarget, size)
    End Function

    Public Function StringDecrypt(ByVal strSource As String) As String
        Dim strTarget As String = Space(256)
        Dim size As Integer
        size = DecryptString(strSource, strTarget)
        StringDecrypt = LSet(strTarget, size)
    End Function

    Public Function GetFileMD5(ByVal fileName As String) As String
        Dim strTarget As String = Space(256)
        Call EncryptFileByMD5(fileName, strTarget)
        GetFileMD5 = LSet(strTarget, InStr(strTarget, vbNullChar) - 1)
    End Function

    Public Function FetchAllData(ByVal sqlStr As String, ByRef Data As Object) As Integer
        Dim count As Integer = 0
        Dim SQL As New XGPub_FncModule.clsDBControl
        Try
            If SQL.OpenConnection(ConnectStrings) = False Then Throw New Exception("连接数据库失败")
            If SQL.FetchAllData(sqlStr, Data, count) = False Then Throw New Exception("读取数据库数据失败")
            SQL.CloseConnection()
            SQL = Nothing
            Return count
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & ex.StackTrace, vbCritical, "提示")
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' 获取CPUID
    ''' </summary>
    ''' 

    Public Function GetCPUID() As String

        Dim strCpu As String = ""
        Dim mc As System.Management.ManagementClass = New System.Management.ManagementClass("Win32_Processor")
        For Each WmiObj As System.Management.ManagementObject In mc.GetInstances
            strCpu = WmiObj("ProcessorId")
            Exit For
        Next
        Return strCpu
    End Function

    ''' <summary>
    ''' 获取硬盘序列号
    ''' </summary>
    Public Function GetDiskSerialNumber() As String
        Dim HDID As String = ""
        Dim mc As Management.ManagementClass = New Management.ManagementClass("Win32_NetworkAdapterConfiguration")
        Dim disk As Management.ManagementObject = New Management.ManagementObject("win32_logicaldisk.deviceid=""c:""")
        disk.Get()
        HDID = disk.GetPropertyValue("VolumeSerialNumber").ToString()
        Return HDID
    End Function

    Public Function GenerateMachineCode() As String
        Dim MachineCode As String = ""
        Dim strDate As String = DateAndTime.DateDiff(DateInterval.Day, Date.Parse("1970-01-01 08:00:00"), Now)
        MachineCode = StringEncrypt(strDate)
        Return MachineCode
    End Function

    Public Function GetBurnCfg(ByVal mPartNo As String) As Boolean
        Dim Data(,) As Object = Nothing
        Try
            Dim count As Integer = FetchAllData("select F_BurnTOSA,F_FWName,F_FWVer,F_FWMD5,F_A0_Addr,F_5C_Addr,F_SN_Addr,F_LaneCount,F_LutBias_Addr,F_LutMod_Addr,F_FWData,F_SN_Table from T_BurnCfg where F_PartNo='" & mPartNo & "'", Data)
            If count = 1 Then
                BurnCfgData.PartNo = mPartNo
                BurnCfgData.BurnTOSA = CBool(Data(0, 0))
                BurnCfgData.FWName = Data(0, 1)
                BurnCfgData.FWVer = Data(0, 2)
                BurnCfgData.FWMD5 = Data(0, 3)
                If Data(0, 4) IsNot Nothing And Data(0, 4).ToString <> "" Then BurnCfgData.A0_Addr = CInt("&H" & Data(0, 4))
                If Data(0, 5) IsNot Nothing And Data(0, 5).ToString <> "" Then BurnCfgData.MI_Addr = CInt("&H" & Data(0, 5))
                BurnCfgData.SN_Addr = Data(0, 6)
                BurnCfgData.LaneCount = Val(Data(0, 7))
                If Data(0, 8) IsNot Nothing And Data(0, 8).ToString <> "" Then BurnCfgData.LUT_IBias = CInt("&H" & Val(Data(0, 8)))
                If Data(0, 9) IsNot Nothing And Data(0, 9).ToString <> "" Then BurnCfgData.LUT_Imod = CInt("&H" & Val(Data(0, 9)))
                BurnCfgData.SN_Table = Data(0, 11)
                HexDataFileName = ""

                If Data(0, 10) IsNot Nothing And Data(0, 10).ToString <> "" Then
                    BurnCfgData.FWData = Data(0, 10)
                    HexDataFileName = HexDataPath & "\" & mPartNo & ".Hex"
                    Dim mStream As New IO.FileStream(HexDataFileName, IO.FileMode.Create, IO.FileAccess.Write)
                    mStream.Write(BurnCfgData.FWData, 0, BurnCfgData.FWData.Length)
                    mStream.Close()
                    mStream = Nothing
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("GetBurnCfg:" & ex.Message, MsgBoxStyle.Critical, "错误")
            Return False
        End Try
    End Function

End Module
