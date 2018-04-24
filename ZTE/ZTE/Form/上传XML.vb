Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Net.Sockets
Public Class 上传XML
    Private Sub UpLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpLoad.Click
        Try
            'Dim cSocket As Socket
            Dim seperator As Char = ControlChars.Lf
            Dim FileMD5 As String = Space(256)
            If MsgBox("确认上传XML文件到FTP上？", vbYesNo, "信息") = vbYes Then
                If ListView1.Items.Count = 0 Then Throw New Exception("没有需要上传的文件！")
                txtStatus.Text = "正在上传,请稍后....."
                For c = 0 To XMLPaths.Items.Count - 1
                    Dim gFileInfo As FileInfo = New FileInfo(XMLPaths.Items(c))
                    'My.Computer.Network.UploadFile(XMLPaths.Items(c), "ftp://210.21.240.223", UserCode, Password, True, 100)
                    ' If File.Exists(gFileInfo.Name) = True Then
                    '    If MsgBox("点击确认覆盖原文件，取消终止上传！", vbYesNo, "提示") = vbNo Then
                    '        Throw New Exception("上传终止")
                    '    End If
                    'End If
                    My.Computer.Network.UploadFile(XMLPaths.Items(c), "\\192.168.1.17\share\部门\研发公共\ZTE上传至测试\" & gFileInfo.Name, UserCode, Password, True, 100)
                    ' EncryptFileByMD5("\\192.168.1.17\share\部门\研发公共\ZTE上传至测试\" & gFileInfo.Name, FileMD5)
                Next
                'FTPUp.DownloadFile("ftp//:210.21.240.223 ", UserCode & Format(Date.Now, "yyyyMMdd") & RunNum & ".xml")
                ' EncryptFileByMD5("ftp://210.21.240.223/3300240020180328022.xml", FileMD5)
                MsgBox("上传成功！", vbInformation, "信息")
                txtStatus.Text = "上传成功！"
                txtStatus.ForeColor = Color.Green
            End If
        Catch ex As Exception
            txtStatus.Text = "上传失败！"
            txtStatus.ForeColor = Color.Red
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub


    Private Sub btnA0BinFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnA0BinFile.Click
        Try
            Dim Item As ListViewItem
            Dim FileSize As Single = 0
            XMLPaths.Enabled = True
            OpenFileDialog2.Title = "请选择XML文件"
            OpenFileDialog2.Filter = "XML文件(*.XML)|*.XML"
            OpenFileDialog2.Multiselect = True
            OpenFileDialog2.ShowDialog()
            ListView1.Items.Clear()
            XMLPaths.Items.Clear()
            Application.DoEvents()
            Dim AllFileNames As List(Of String) = OpenFileDialog2.FileNames.ToList
            For a = 0 To AllFileNames.Count - 1
                XMLPaths.Items.Add(AllFileNames(a))
            Next
            If XMLPaths.Items.Count = 0 Then
                Throw New Exception("没有选择正确的文件")
            ElseIf XMLPaths.Items.Count = 1 Then
                XMLPaths.SelectedIndex = 0
            Else
                XMLPaths.Text = Strings.Left(OpenFileDialog2.FileName, InStrRev(OpenFileDialog2.FileName, "\") - 1)
            End If

            For b = 0 To XMLPaths.Items.Count - 1
                Dim lvFileInfo As FileInfo = New FileInfo(XMLPaths.Items(b))
                Dim ExtXMLFileName As String = lvFileInfo.Extension
                Dim XMLFileName As String = LSet(lvFileInfo.Name, lvFileInfo.Name.IndexOf(ExtXMLFileName))
                Item = ListView1.Items.Add(lvFileInfo.Name)
                ListView1.Items(b).ForeColor = IIf(b Mod 2, Color.Red, Color.Black)
                If lvFileInfo.Length > 1024 Then
                    FileSize = lvFileInfo.Length \ 1024
                End If
                Item.SubItems.Add(FileSize & "KB")    
                Item.SubItems.Add(lvFileInfo.LastWriteTime)
                Item.SubItems.Add(lvFileInfo.FullName)
            Next
            txtStatus.Text = "已选中" & XMLPaths.Items.Count & "个XML文件"
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try

    End Sub


    '检查上传文件是否完整
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If ListView1.Items.Count = 0 Then Throw New Exception("没有需要验证和下载的文件！")
            If MsgBox("请选择下载地址.", vbYesNo, "提示") = vbYes Then
                Dim ChecKBool As Boolean = False
                Dim TestCheckBool As Boolean = True
                Dim ExMessage As String = ""
                Dim FtpDownFloder As New FolderBrowserDialog
                Dim FileMD5 As String = Space(256)
                Dim TestMD5 As String = Space(256)
                FtpDownFloder.ShowDialog()
                Dim FtpSelectPath As String = FtpDownFloder.SelectedPath
                If FtpSelectPath = "" Then Throw New Exception("未选择下载地址！")
                ' If FtpSelectPath.Equals(FtpDownFloder.SelectedPath) = True Then Throw New Exception("该路径下已有同名文件！")
                For d = 0 To XMLPaths.Items.Count - 1
                    Dim checkFileInfo As FileInfo = New FileInfo(XMLPaths.Items(d))
                    My.Computer.Network.DownloadFile("\\192.168.1.17\share\部门\研发公共\ZTE上传至测试\" & checkFileInfo.Name, FtpSelectPath & checkFileInfo.Name)
                Next
                For CheckCount = 0 To XMLPaths.Items.Count - 1
                    Dim CheckFileInfo As FileInfo = New FileInfo(XMLPaths.Items(CheckCount))
                    EncryptFileByMD5(CheckFileInfo.FullName, FileMD5)
                    EncryptFileByMD5(FtpSelectPath & CheckFileInfo.Name, TestMD5)
                    ChecKBool = IIf(FileMD5.Equals(TestMD5), True, False)
                    TestCheckBool = ChecKBool And TestCheckBool
                    If ChecKBool = False Then
                        ExMessage &= CheckFileInfo.Name & " "
                    End If
                Next
                If TestCheckBool = False Then
                    Throw New Exception(ExMessage & "上传不完整，请重新上传!")
                    txtStatus.Text = "验证失败!"
                    txtStatus.ForeColor = Color.Red
                End If

                If TestCheckBool = True Then
                    MsgBox("上传完整，验证完成.", vbInformation, "信息")
                    txtStatus.Text = "验证完成!"
                    txtStatus.ForeColor = Color.Green
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub

End Class