Imports System.Threading

Imports System.Runtime.InteropServices
Public Class I2C_USB

    Private Mut As New Mutex()

#Region "API Define: XG_I2C_USB.DLL"
    Private Declare Function I2C_USB_ReadData Lib "XG_I2C_USB.dll" (ByVal devName As String, ByVal DeviceAddress As Byte,
                                                                   ByVal RegisterAddress As Byte, ByRef data As Byte,
                                                                   ByVal size As Integer) As Boolean

    Private Declare Function I2C_USB_WriteData Lib "XG_I2C_USB.dll" (ByVal devName As String, ByVal DeviceAddress As Byte,
                                                                    ByVal RegisterAddress As Byte, ByRef RegisterValue As Byte,
                                                                    ByVal size As Integer) As Boolean

    Private Declare Function I2C_GetUsbDeviceName Lib "XG_I2C_USB.dll" (ByVal devName As String, ByVal devNum As Integer) As Boolean
#End Region

    Public Function USB_GetDeviceName(ByVal devNum As Integer, ByRef devName As String) As Boolean '获取设备名称
        Dim strDevName As String = Space(50)
        Dim ret As Boolean = I2C_GetUsbDeviceName(strDevName, devNum)
        devName = LSet(strDevName, InStr(strDevName, vbNullChar))
        Return ret
    End Function

    Public Function I2C_ReadData(ByVal DeviceAddress As Byte, ByVal RegisterAddress As Byte, ByRef data() As Byte, ByVal Size As Integer) As Boolean
        Try
            Mut.WaitOne()
            If I2C_USB_ReadData(m_AddressName, DeviceAddress, RegisterAddress, data(0), Size) = False Then Throw New Exception("Read Data Failure")
            Return True
        Catch ex As Exception
            Return False
        Finally
            Mut.ReleaseMutex()
        End Try
    End Function

    Public Function I2C_ReadByte(ByVal DeviceAddress As Byte, ByVal RegisterAddress As Byte, ByRef data As Byte) As Boolean
        Dim bData(0) As Byte
        Try
            Mut.WaitOne()
            If I2C_USB_ReadData(m_AddressName, DeviceAddress, RegisterAddress, bData(0), 1) = False Then Throw New Exception("Read Data Failure")
            data = bData(0)
            Return True
        Catch ex As Exception
            Return False
        Finally
            Mut.ReleaseMutex()
        End Try
    End Function

    Public Function I2C_ReadTwoByte(ByVal DeviceAddress As Byte, ByVal RegisterAddress As Byte, ByRef RegValue1 As Byte, ByRef RegValue2 As Byte) As Boolean
        Dim bData(1) As Byte
        Try
            Mut.WaitOne()
            If I2C_USB_ReadData(m_AddressName, DeviceAddress, RegisterAddress, bData(0), 2) = False Then Throw New Exception("Read Data Failure")
            RegValue1 = bData(0)
            RegValue2 = bData(1)
            Return True
        Catch ex As Exception
            Return False
        Finally
            Mut.ReleaseMutex()
        End Try
    End Function

    Public Function I2C_WriteData(ByVal DeviceAddress As Byte, ByVal RegisterAddress As Byte, ByVal data() As Byte, ByVal Size As Integer) As Boolean
        Try
            Mut.WaitOne()
            If I2C_USB_WriteData(m_AddressName, DeviceAddress, RegisterAddress, data(0), Size) = False Then Throw New Exception("Write Data Failure")
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
            If I2C_USB_WriteData(m_AddressName, DeviceAddress, RegisterAddress, bData(0), 1) = False Then Throw New Exception("Write Data Failure")
            Return True
        Catch ex As Exception
            Return False
        Finally
            Mut.ReleaseMutex()
        End Try
    End Function

    Public Function I2C_WriteTwoByte(ByVal DeviceAddress As Byte, ByVal RegisterAddress As Byte, ByVal RegValue1 As Byte, ByVal RegValue2 As Byte) As Boolean
        Dim bData() As Byte = {RegValue1, RegValue2}
        Try
            Mut.WaitOne()
            If I2C_USB_WriteData(m_AddressName, DeviceAddress, RegisterAddress, bData(0), 2) = False Then Throw New Exception("Write Data Failure")
            Return True
        Catch ex As Exception
            Return False
        Finally
            Mut.ReleaseMutex()
        End Try
    End Function

    Private m_AddressName As String
    Public Property DeviceName As String
        Get
            Return m_AddressName
        End Get
        Set(ByVal value As String)
            m_AddressName = value
        End Set
    End Property

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Function Swap(ByVal bData() As Byte, ByVal StartIndex As UInt16, ByVal Size As UInt16) As Byte()
        Dim Data(Size - 1) As Byte
        For i = 0 To Size - 1
            Data(i) = bData(StartIndex + Size - 1 - i)
        Next
        Return Data
    End Function
End Class
