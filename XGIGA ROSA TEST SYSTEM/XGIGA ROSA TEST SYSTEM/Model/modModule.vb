Imports System.Threading
Imports XGPub_FncModule.clsConfigFile

Module modModule
    Public strServerName, strDataBaseName, strUserName, strPassword As String
    Public iniFilePath As String = Application.StartupPath & "\Config1.ini"
    Public ConnectString As String
    Private Mut As New Mutex()
    Private DMM As New GPIBDev
#Region "API Declare"
    Public Declare Function EncryptString Lib "XG_MathIO" (ByVal strSource As String, ByVal strTarget As String) As Integer
    Public Declare Function DecryptString Lib "XG_MathIO" (ByVal strSource As String, ByVal strTarget As String) As Integer
    Public Declare Sub EncryptFileByMD5 Lib "XG_MathIO" (ByVal fileName As String, ByVal strTarget As String)
    Public Declare Function RemoveMenu Lib "user32" (ByVal hMenu As Integer, ByVal nPosition As Integer, ByVal wFlags As Integer) As Integer
    Public Declare Function GetSystemMenu Lib "user32" (ByVal hWnd As Integer, ByVal bRevert As Integer) As Integer
    Public Const SC_CLOSE = &HF060&
    Public Const MF_REMOVE = &H1000&
#End Region

#Region "API Define: XG_I2C_USB.DLL"

    Private Declare Function I2C_USB_ReadData Lib "XG_I2C_USB.dll" (ByVal devName As String, ByVal DeviceAddress As Byte,
                                                                   ByVal RegisterAddress As Byte, ByRef data As Byte,
                                                                   ByVal size As Integer) As Boolean

    Private Declare Function I2C_USB_WriteData Lib "XG_I2C_USB.dll" (ByVal devName As String, ByVal DeviceAddress As Byte,
                                                                    ByVal RegisterAddress As Byte, ByRef RegisterValue As Byte,
                                                                    ByVal size As Integer) As Boolean

    Private Declare Function I2C_GetUsbDeviceName Lib "XG_I2C_USB.dll" (ByVal devName As String, ByVal devNum As Integer) As Boolean

    Private Declare Function I2C_USB_OpenUSB Lib "XG_I2C_USB.dll" (ByVal devName As String) As Boolean

    Private Declare Sub I2C_USB_CloseUSB Lib "XG_I2C_USB.dll" ()

    ' -------- 以下两个函数要调用 I2C_USB_OpenUSB 和 I2C_USB_CloseUSB ，切记 --------------------------------------------------------
    Private Declare Function I2C_USB_ReadDataEx Lib "XG_I2C_USB.dll" (ByVal DeviceAddress As Byte, ByVal RegisterAddress As Byte,
                                                                     ByRef data As Byte, ByVal size As Integer) As Boolean

    Private Declare Function I2C_USB_WriteDataEx Lib "XG_I2C_USB.dll" (ByVal DeviceAddress As Byte, ByVal RegisterAddress As Byte,
                                                                      ByRef RegisterValue As Byte, ByVal size As Integer) As Boolean

#End Region

    Public m_AddressName As String

    Public Function USB_GetDeviceName(ByVal devNum As Integer, ByRef devName As String) As Boolean
        Dim strDevName As String = Space(50)
        Dim ret As Boolean = I2C_GetUsbDeviceName(strDevName, devNum)
        devName = LSet(strDevName, InStr(strDevName, vbNullChar))
        Return ret
    End Function

    Public Function I2C_ReadByte(ByVal DeviceAddress As Byte, ByVal RegisterAddress As Byte, ByRef data As Byte) As Boolean
        Dim bData(0) As Byte
        Try
            Mut.WaitOne()
            If I2C_USB_ReadData(m_AddressName, DeviceAddress, RegisterAddress, bData(0), 1) = False Then Return False
            data = bData(0)
            Return True
        Catch ex As Exception
            Return False
        Finally
            Mut.ReleaseMutex()
        End Try
    End Function

    Public Function I2C_WriteByte(ByVal DeviceAddress As Byte, ByVal RegisterAddress As Byte, ByVal data As Byte) As Boolean
        Dim bData() As Byte = {data}
        Try
            Mut.WaitOne()
            If I2C_USB_WriteData(m_AddressName, DeviceAddress, RegisterAddress, bData(0), 1) = False Then Return False
            Return True
        Catch ex As Exception
            Return False
        Finally
            Mut.ReleaseMutex()
        End Try
    End Function

    Public Function ReadResistanceFrom34450A(ByVal gpibAddress As String) As Single
        Dim res As Single
        Dim gpiData As String = ""
        If DMM.OpenVISA(gpibAddress) = False Then Return -1
        If DMM.SendAndReceiveData("MEAS:RES?", gpiData) = False Then Return -1
        If gpiData.Contains("0E+37") Then Return 10000000000.0
        res = Val(gpiData)
        Return res
    End Function


    Public Function ReadMgeFrom34450A(ByVal gpibAddress As String, ByVal range As Integer) As Single
        Dim res As Single
        Dim gpiData As String = ""
        If DMM.OpenVISA(gpibAddress) = False Then Return -1
        If DMM.SendAndReceiveData("MEAS:RES? " & Range & ",2.00E-5", gpiData) = False Then Return -1
        If gpiData.Contains("0E+37") Then Return 10000000000.0
        res = Val(gpiData)
        Return res
    End Function

    Public Function ReadDcFrom34450A(ByVal gpibAddress As String) As Single
        Dim strData As String = ""
        If DMM.OpenVISA(gpibAddress) = False Then Return -1
        'If DMM.SendCommand("CONFigure:PRIMary:DIODe") = False Then Return -1
        If DMM.SendAndReceiveData("MEAS:VOLT:DC?", strData) = False Then Return -1
        Return Val(strData)
    End Function
    '加密
    Public Function StringEncrypt(ByVal strSource As String) As String
        Dim strTarget As String = Space(256)
        Dim size As Integer
        size = EncryptString(strSource, strTarget)
        StringEncrypt = LSet(strTarget, size)
    End Function

    '解密
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

    Public Sub GetConfigInfor()
        strServerName = StringDecrypt(ReadConfig(iniFilePath, "DB Set", "Server", ""))
        If strServerName = "" Then strServerName = "192.168.1.19"
        strDataBaseName = StringDecrypt(ReadConfig(iniFilePath, "DB Set", "DataBase", ""))
        If strDataBaseName = "" Then strDataBaseName = "TestData"
        strUserName = StringDecrypt(ReadConfig(iniFilePath, "DB Set", "UserName", ""))
        If strUserName = "" Then strUserName = "XGIGA"
        strPassword = StringDecrypt(ReadConfig(iniFilePath, "DB Set", "Password", ""))
        If strPassword = "" Then strPassword = "Test2015"
        ConnectString = "Server=(local);Data Source=" & strServerName & ";Initial Catalog=" & strDataBaseName & ";User Id=" & strUserName & ";password=" & strPassword
    End Sub

    Public DB_isConnect As Boolean
    Public Sub CheckDB_Connect()
        Dim SQL As New XGPub_FncModule.clsDBControl
        Dim i As Integer = 0
        Try
ReSetDB:
            DB_isConnect = False
            '------------------  检查数据库是否连接成功 -------------------
            Dim NewThread As New Threading.Thread(AddressOf ShowMsgProgressForm)
            NewThread.Start()
            Thread.Sleep(20)
            If SQL.OpenConnection(ConnectString) = False Then
                DB_isConnect = True
                Thread.Sleep(20)
                NewThread.Abort()
                MsgBox("数据库设置失败，请联系管理员重新设置！ ", vbCritical, "错误")
                End
            End If
            SQL.CloseConnection()
            SQL = Nothing
            DB_isConnect = True
            NewThread.Abort()
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & ex.StackTrace, vbCritical, "提示")
        End Try
    End Sub

    Private Sub ShowMsgProgressForm()
        frmMsgProgress.labMessage.Text = "检查数据库是否连接成功"
        frmMsgProgress.ShowDialog()
    End Sub
End Module
