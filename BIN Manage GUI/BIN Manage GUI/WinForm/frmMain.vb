Imports System.IO
Imports System.Math
Public Class frmMain

    Private Multiselect As Boolean = False
    Private Sub btnSelFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnA0BinFile.Click
        Try
            btnViewInfor.Enabled = False
            btnLoad.Enabled = False
            txtBinFilePath.Enabled = True
            OpenFileDialog1.Title = "选择BIN文件"
            OpenFileDialog1.Filter = "BIN文件(*.BIN)|*.BIN"
            OpenFileDialog1.Multiselect = True
            OpenFileDialog1.ShowDialog()
            txtBinFilePath.Items.Clear()
            Dim FileNames As List(Of String) = OpenFileDialog1.FileNames.ToList
            For i As Integer = 0 To FileNames.Count - 1
                'If FileNames(i).Contains("A2") = False Then
                txtBinFilePath.Items.Add(FileNames(i))
                'End If
            Next

            If txtBinFilePath.Items.Count = 0 Then
                Throw New Exception("没有选择正确的文件")
            ElseIf txtBinFilePath.Items.Count = 1 Then
                txtBinFilePath.SelectedIndex = 0
            Else
                txtBinFilePath.Text = Strings.Left(OpenFileDialog1.FileName, InStrRev(OpenFileDialog1.FileName, "\") - 1)
            End If
            lvBinFileList.Items.Clear()
            Dim fileSize As Single = 0
            Dim Item As ListViewItem

            Dim LastSN_StartString As String = ""
            'FilesStatus.Maximum = txtBinFilePath.Items.Count
            For i As Integer = 0 To txtBinFilePath.Items.Count - 1
                Dim gFileInfo As FileInfo = New System.IO.FileInfo(txtBinFilePath.Items(i))
                Dim strExtension As String = gFileInfo.Extension
                Dim fileName As String = LSet(gFileInfo.Name, gFileInfo.Name.IndexOf(strExtension))
                ' If fileName.Contains("A2") = False Then
                If i > 0 Then
                    If LastSN_StartString <> LSet(fileName, 3) Then
                        MsgBox("选择的BIN文件序列号前3位有不一致的,请检查BIN文件名是否有误", vbCritical, "错误")
                        Exit For
                    End If
                End If
                Item = lvBinFileList.Items.Add(fileName, 0)
                lvBinFileList.Items(i).ForeColor = IIf(i Mod 2, Color.Red, Color.Black)
                fileSize = gFileInfo.Length
                If fileSize >= 1024 Then
                    fileSize = fileSize / 1024
                End If
                Item.SubItems.Add(fileSize.ToString("##,##") & " B")
                Item.SubItems.Add(gFileInfo.LastWriteTime)
                Item.SubItems.Add(gFileInfo.FullName)
                LastSN_StartString = LSet(fileName, 3)
                AllOk.Text = "选中" & i + 1 & "个文件"

                ' End If
            Next
            btnLoad.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub

    '排序的列
    Private m_SortingColumn As ColumnHeader

    Private Sub Sort_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvBinFileList.ColumnClick
        ' Get the new sorting column.
        If e.Column = 1 Or e.Column = 2 Or e.Column = 4 Then Return
        Dim new_sorting_column As ColumnHeader = sender.Columns(e.Column)
        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending '递增顺序
        Else ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.
                If m_SortingColumn.Text.EndsWith("  ▲") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If
            ' Remove the old sort indicator.
            m_SortingColumn.Text = m_SortingColumn.Text.Substring(0, m_SortingColumn.Text.Length - 3)
        End If
        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text &= "  ▲"
        Else
            m_SortingColumn.Text &= "  ▼"
        End If
        ' Create a comparer.
        sender.ListViewItemSorter = New clsListviewSorter(e.Column, sort_order)
        ' Sort.
        sender.Sort()
    End Sub

    Private Sub lvBinFileList_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvBinFileList.KeyUp
        If e.KeyCode = Keys.Delete Then
            Debug.Print(CurrentSelectItem.Item(0).Text)
            For i As Integer = 0 To CurrentSelectItem.Count - 1
                CurrentSelectItem.Item(0).Remove()
            Next
        End If
    End Sub

    Dim CurrentSelectItem As ListView.SelectedListViewItemCollection
    Private Sub lvPartNoList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvBinFileList.SelectedIndexChanged
        Dim item As ListViewItem
        If lvBinFileList.SelectedItems.Count = 0 Then Return
        CurrentSelectItem = lvBinFileList.SelectedItems
        If CurrentSelectItem.Count > 1 Then Return
        item = CurrentSelectItem.Item(0)

        Dim fullPath As String = item.SubItems(3).Text
        Dim A0() As Byte = File.ReadAllBytes(fullPath)

        frmViewCodeInfor.listA0.Items.Clear()
        For i As Integer = 0 To A0.Length - 1
            item = frmViewCodeInfor.listA0.Items.Add(i.ToString, 0)
            item.SubItems.Add(A0(i))
            item.SubItems.Add(A0(i).ToString("X2"))
            item.SubItems.Add(Chr(A0(i)))
        Next
        If A0(0) = 3 Then
            frmViewCodeInfor.TextBox1.Text = System.Text.Encoding.UTF8.GetString(A0, 20, 16).Trim
            frmViewCodeInfor.TextBox2.Text = System.Text.Encoding.UTF8.GetString(A0, 40, 16).Trim
            frmViewCodeInfor.TextBox3.Text = System.Text.Encoding.UTF8.GetString(A0, 68, 16).Trim
            frmViewCodeInfor.TextBox4.Text = System.Text.Encoding.UTF8.GetString(A0, 84, 8).Trim
        End If
        btnViewInfor.Enabled = True

    End Sub

    Dim frmViewCodeInfor As New ViewCodeInfor
    Private Sub btnViewInfor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewInfor.Click
        If frmViewCodeInfor Is Nothing Then
            frmViewCodeInfor = New ViewCodeInfor
        End If
        frmViewCodeInfor.StartPosition = FormStartPosition.Manual
        frmViewCodeInfor.Show()
    End Sub

    Private Sub Form1_LocationChanged(sender As Object, e As System.EventArgs) Handles Me.LocationChanged
        If frmViewCodeInfor IsNot Nothing Then frmViewCodeInfor.Location = New Point(Me.Right + 5, Me.Top + 5)
    End Sub

    Private sConnectionString As String = ""
    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            'InitStatus()
            Dim FIS As New XGPub_FIS.FIS
            StartNum.SelectionLength = 16
            lvBinFileList.Size = New Size(516, 334)
            sConnectionString = FIS.GetConnectionString
            cbSalesNo.Text = GetSetting(Application.ProductName, "Setting", "LotNo", "")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub chkA2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkA2.CheckedChanged
        If chkA2.Checked Then
            txtA2BinFileTemplate.Visible = True
            btnA2BinFile.Visible = True
            Label3.Visible = True
            lvBinFileList.Size = New Size(516, 306)
            lvBinFileList.Location = New Point(8, 62)

        Else
            txtA2BinFileTemplate.Visible = False
            btnA2BinFile.Visible = False
            Label3.Visible = False
            lvBinFileList.Size = New Size(516, 334)
            lvBinFileList.Location = New Point(8, 34)
        End If
    End Sub

    Private Sub btnA2BinFile_Click(sender As System.Object, e As System.EventArgs) Handles btnA2BinFile.Click
        OpenFileDialog1.Title = "选择BIN文件"
        OpenFileDialog1.Filter = "BIN文件(*A2*.BIN)|*A2*.BIN"
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.ShowDialog()
        txtA2BinFileTemplate.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
        Status.Visible = True
        Status.Value = 0
        Dim A0() As Byte = Nothing
        Dim A2() As Byte = Nothing
        Dim A0_T1() As Byte = Nothing
        Dim A0_T2() As Byte = Nothing
        Dim SQL As New XGPub_FncModule.clsDBControl
        Dim Data(,) As Object = Nothing
        Dim RowCount As Integer = 0
        Dim SN, FileName As String
        Dim dateNow1 As DateTime = Date.Now
        Try
            btnLoad.Enabled = False
            If lvBinFileList.Items.Count = 0 Then Throw New Exception("没有要上传的任何BIN文件")
            Dim isLoadA2 As Boolean = False


            If chkA2.Checked Then
                If MsgBox("确定要上传EEPROM A2的高128字节BIN文件？", MsgBoxStyle.Information + vbYesNo, "提醒") = vbYes Then
                    If txtA2BinFileTemplate.Text = "" Then Throw New Exception("A2_H128 BIN文件路径不能为空.")
                    isLoadA2 = True
                End If
            End If
            If cbSalesNo.Text = "" Then Throw New Exception("生产工单号不能为空！")
            SaveSetting(Application.ProductName, "Setting", "LotNo", cbSalesNo.Text)
            If MsgBox("请确认您的选择,然后点确定即可上传BIN文件,确定要上传吗？", MsgBoxStyle.Information + vbYesNo, "提醒") = vbYes Then
                If SQL.OpenConnection(sConnectionString) = False Then Throw New Exception("数据库连接失败")
                Status.Maximum = lvBinFileList.Items.Count
                'sConnectionString
                For i As Integer = 0 To lvBinFileList.Items.Count - 1
                    SN = lvBinFileList.Items(i).Text
                    FileName = lvBinFileList.Items(i).SubItems(3).Text

                    If ProductType = 0 Then
                        A0 = File.ReadAllBytes(FileName)
                        If A0(0) <> 3 And A0(0) <> 11 Then Throw New Exception("当前BIN文件不是SFP类型，请确认再继续！")
                        If isLoadA2 Then
                            A2 = File.ReadAllBytes(txtA2BinFileTemplate.Text)
                        End If
                    Else
                        A0_T1 = File.ReadAllBytes(FileName)
                        If A0_T1(0) <> 6 Then Throw New Exception("当前BIN文件不是XFP类型，请确认再继续！")
                        If isLoadA2 Then
                            A0_T2 = File.ReadAllBytes(txtA2BinFileTemplate.Text)
                        End If
                    End If

                    Dim InData() As Object, Columns() As String
                    If isLoadA2 Then
                        A2 = File.ReadAllBytes(txtA2BinFileTemplate.Text)
                    End If
                    SQL.FetchAllData("select F_SN from T_CustomCode where F_SN ='" & SN & "'", Data, RowCount)

                    If RowCount > 0 Then
                        InData = IIf(ProductType = 0, {cbSalesNo.Text, A0}, {cbSalesNo.Text, A0_T1})
                        Columns = IIf(ProductType = 0, {"F_SalesNo", "F_A0"}, {"F_SalesNo", "F_A0_T1"})
                        If isLoadA2 Then
                            InData = IIf(ProductType = 0, {cbSalesNo.Text, A0, A2}, {cbSalesNo.Text, A0_T1, A0_T2})
                            Columns = IIf(ProductType = 0, {"F_SalesNo", "F_A0", "F_A2"}, {"F_SalesNo", "F_A0_T1", "F_A0_T2"})
                        End If
                        If SQL.UpdateData("T_CustomCode", Columns, {"F_SN"}, InData, {SN}) = False Then Throw New Exception("更新数据库数据失败")
                        Status.Value += 1
                        AllOk.Text = "正在上传，请稍后......"
                        Application.DoEvents()
                    Else
                        InData = IIf(ProductType = 0, {cbSalesNo.Text, SN, A0}, {cbSalesNo.Text, SN, A0_T1})
                        Columns = IIf(ProductType = 0, {"F_SalesNo", "F_SN", "F_A0"}, {"F_SalesNo", "F_SN", "F_A0_T1"})
                        If isLoadA2 Then
                            InData = IIf(ProductType = 0, {cbSalesNo.Text, SN, A0, A2}, {cbSalesNo.Text, SN, A0_T1, A0_T2})
                            Columns = IIf(ProductType = 0, {"F_SalesNo", "F_SN", "F_A0", "F_A2"}, {"F_SalesNo", "F_SN", "F_A0_T1", "F_A0_T2"})
                        End If
                        If SQL.InsertData("T_CustomCode", Columns, InData) = False Then Throw New Exception("插入数据库数据失败")
                        Status.Value += 1
                        AllOk.Text = "正在上传，请稍后......"
                        Application.DoEvents()
                    End If
                Next
                Dim dateNow2 As Date = Now
                MsgBox("上传成功!", vbInformation, "提示")
                AllOk.Text = "上传成功!" & "              共耗时" & DateDiff("s", dateNow1, dateNow2) & "秒"
            End If
         
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error")
        Finally
            SQL.CloseConnection()
            SQL = Nothing
            btnLoad.Enabled = True
            Status.Visible = False
        End Try
    End Sub

    Private Function GetCustomCode(ByVal ExtSN As String, ByRef A0CodeData() As Byte, ByRef A2CodeData() As Byte) As Boolean
        Dim SQL As New XGPub_FncModule.clsDBControl
        Dim data(,) As Object = Nothing
        Dim RowCount As Integer = 0
        Try
            If SQL.OpenConnection(sConnectionString) = False Then Throw New Exception("数据库连接失败")
            If SQL.FetchAllData("Select F_A0,F_A2 from T_CustomCode where F_SN='" & ExtSN & "'", data, RowCount) = False Then Return False
            If RowCount > 0 Then
                A0CodeData = XGPub_FncModule.clsArray.ObjectToByte(XGPub_FncModule.clsArray.Index2DArray(data, , 0)(0))
                If IsArray(data(0, 1)) Then
                    A2CodeData = XGPub_FncModule.clsArray.ObjectToByte(XGPub_FncModule.clsArray.Index2DArray(data, , 1)(0))
                End If
            Else
                Return False
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
            Return False
        Finally
            SQL.CloseConnection()
        End Try
    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        OpenFileDialog1.Title = "选择BIN文件"
        OpenFileDialog1.Filter = "BIN文件(*.BIN)|*.BIN"
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.ShowDialog()
        'lvCreateBin.Items.Clear()
        Try
            'If lvCreateBin.Items.Count = 0 Then Throw New Exception("没有选中任何需要生成的BIN文件")
            Dim FileNames As String = OpenFileDialog1.FileName
            'If FileNames.Contains("A2") Then Throw New Exception("没有选择正确文件")
            If FileNames <> Nothing Then
                If FileNames.Contains("A2") = False Then
                    btnCreateBins.Items.Add(FileNames)
                End If
            End If
            If btnCreateBins.Items.Count = 0 Then
                Throw New Exception("没有选择正确的BIN文件")
                'Else
                btnCreateBins.Text = Strings.Left(OpenFileDialog1.FileName, InStrRev(OpenFileDialog1.FileName, "\") - 1)
            Else
                btnCreateBins.Text = FileNames
            End If
            If btnCreateBins.Items.Count > 0 Then
                btnCreateBin.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub

    Private Sub btnCreateBin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateBin.Click
        Try
            Dim count As Integer = 1
            If StartName.Text = "" Or StartNum.Text = "" Or EndNum.Text = "" Or btnCreateBin.Text = "" Then
                Throw New Exception("请将路径,序列号，ID填写完整")
                Exit Sub
            End If
            Dim iteam As ListViewItem
            Dim Start As Integer = Convert.ToInt32(StartNum.Text)
            Dim Ends As Integer = EndNum.Text
            Dim FilePath As String
            Dim fullPath As String = btnCreateBins.Text
            Dim loadPath As String = Mid(fullPath, InStrRev(fullPath, "\") + 1)
            Dim PathIndex As Integer = fullPath.IndexOf(loadPath)
            Dim strfullPath As String = fullPath.Substring(0, PathIndex)
            Dim A0() As Byte = File.ReadAllBytes(fullPath)
            Dim Fileinfo As FileInfo
            Dim Filesize As Single
            'FilesStatus.Maximum = Ends
            Dim FullAllPath As String = strfullPath & Trim(StartName.Text) & StartNum.Text & "(" & EndNum.Text & ")"
            IO.Directory.CreateDirectory(FullAllPath)
            For a = Start To Ends + Start - 1
                Dim aa As String = a.ToString().PadLeft(TotalLength.Value - ChangeNumbers.Value, "0")
                Dim FileNames As String = Trim(StartName.Text) & aa
                Dim Counts As Integer = System.Text.Encoding.Default.GetByteCount(FileNames)
                If Counts > 16 Then
                    Throw New Exception("序列号和ID超出范围")
                    Exit Try
                End If
                'FilePath = TargetPath.Text & "\" & StartName.Text & aa & ".bin"
                FilePath = FullAllPath & "\" & Trim(StartName.Text) & aa & ".bin"
                If aa.Length > TotalLength.Value - ChangeNumbers.Value Then
                    Throw New Exception("无法继续生成，将超过指定数目")
                    Exit Sub
                End If

                File.Copy(btnCreateBins.Text, FilePath, True)
                Fileinfo = New System.IO.FileInfo(FilePath)
                iteam = lvCreateBin.Items.Add(Trim(StartName.Text) & aa & ".bin")
                Filesize = Fileinfo.Length
                If Filesize >= 1024 Then
                    Filesize = Filesize / 1024
                End If
                iteam.SubItems.Add(Filesize.ToString("##,##") & "B")
                iteam.SubItems.Add(Date.Now)
                iteam.SubItems.Add(Fileinfo.FullName)
                Application.DoEvents()
                FileNames = FileNames.PadRight(16)
                Dim data() As Byte = System.Text.Encoding.Default.GetBytes(FileNames) 'String类型转换为byte数组
                Array.Copy(data, 0, A0, 68, 16)
                File.WriteAllBytes(FilePath, A0)
                'WriteFile(FileName, 68, data)
                Dim Check95(0) As Byte
                Check95(0) = CheckSum(FilePath, 64, 94)
                Dim Check63(0) As Byte
                Check63(0) = CheckSum(FilePath, 0, 62)
                Array.Copy(Check95, 0, A0, 95, 1)
                Array.Copy(Check63, 0, A0, 63, 1)
                File.WriteAllBytes(FilePath, A0)
                AllOk.Text = "生成" & count & "个文件"
                count += 1
            Next
            MsgBox("生成成功!", vbInformation, "提示")
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub


    Public Function CheckSum(ByVal FilePath As String, ByVal StarIndex As Integer, ByVal EndIndex As Integer) As Byte
        Dim Sum As Integer = 0
        Dim A0Data() As Byte = File.ReadAllBytes(FilePath)
        For a = StarIndex To EndIndex
            Sum += A0Data(a)
        Next
        Dim ByteSum(0) As Byte
        ByteSum(0) = Sum And &HFF
        Return ByteSum(0)
    End Function


    'Private Sub CreateB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim folder As New FolderBrowserDialog
    '    folder.ShowDialog()
    '    Try
    '        Dim FileName As String = folder.SelectedPath
    '        TargetPath.Items.Add(FileName)
    '        If FileName.Count = 0 Then
    '            Throw New Exception("没有选择正确的地址路径")
    '        Else
    '            TargetPath.Text = FileName
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, vbCritical, "错误")
    '    End Try
    'End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeNumbers.ValueChanged
        Try
            StartName.Text = ""
            Dim fullPath As String = btnCreateBins.Text
            Dim AllData() As Byte = File.ReadAllBytes(fullPath)
            Dim Data(16) As Byte
            Dim StartNameData As String = StartName.Text
            If btnCreateBins.Text = "" Then Throw New Exception("BIN模板文件不能为空")
            Dim Info As FileInfo = New System.IO.FileInfo(btnCreateBins.Text)

            Dim FullbinPath As String = Info.Extension
            Dim FormFileName As String = LSet(Info.Name, Info.Name.IndexOf(FullbinPath))
            Dim ChangeNum As Integer = ChangeNumbers.Value
            'If ChangeNum > FormFileName.Length Then Throw New Exception("超出模板序列号长度！")
            If ChangeNum = 0 Then
                StartName.Text = ""
            Else
                For a = 0 To ChangeNum - 1
                    Data(a) = AllData(a + 68)
                Next
                StartName.Text = System.Text.Encoding.ASCII.GetString(Data)
            End If          
            'StartName.Text = FormFileName.Substring(0, ChangeNum)
        Catch ex As Exception
            'ChangeNumbers.Value = 0
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        AllOk.Text = "就绪"
        lvCreateBin.Items.Clear()
        Preview.Items.Clear()
        Preview.Text = ""
        StartNum.Text = ""
        EndNum.Text = ""
        ChangeNumbers.Value = 0
        TotalLength.Value = 0
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If TotalLength.Value < ChangeNumbers.Value Then Throw New Exception("序列号超出总字节长度")
            Preview.Items.Clear()
            If Trim(StartName.Text) = "" Or StartNum.Text = "" Or EndNum.Text = "" Then Throw New Exception("起始ID或序列号或数量不能为空")
            Dim Start As Integer = Convert.ToInt32(StartNum.Text)
            Dim Ends As Integer = EndNum.Text
            For a = Start To Ends + Start - 1
                Dim aa As String = a.ToString().PadLeft(TotalLength.Value - ChangeNumbers.Value, "0")
                Dim Filenames As String = Trim(StartName.Text) & aa
                If Filenames.Length > TotalLength.Value Then Throw New Exception("SN超过规定长度")
                'Dim Counts As Integer = System.Text.Encoding.Default.GetByteCount(Paths)
                Preview.Items.Add(Filenames)
            Next
            If Preview.Items.Count > 0 Then
                Preview.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub

    Private Sub NumericUpDown1_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotalLength.ValueChanged
        Try
            If TotalLength.Value > 16 Then Throw New Exception("序列号总长度不能超过16")
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub

    Private Function GetAllCustomCodeAndCreateBinFile(filePath As String, ByVal LotSN As String) As Boolean
        Dim SQL As New XGPub_FncModule.clsDBControl
        Dim data(,) As Object = Nothing
        Dim RowCount As Integer = 0
        Dim A0CodeData() As Byte
        Dim A2CodeData() As Byte
        Dim A2Code() As Object = Nothing
        Try
            If SQL.OpenConnection(sConnectionString) = False Then Throw New Exception("数据库连接失败")
            If SQL.FetchAllData("Select F_SN,F_A0,F_A2 from T_CustomCode where F_SalesNo='" & LotSN & "'", data, RowCount) = False Then Return False
            If RowCount > 0 Then
                For i As Integer = 0 To RowCount - 1
                    A0CodeData = XGPub_FncModule.clsArray.ObjectToByte(XGPub_FncModule.clsArray.Index2DArray(data, , 1)(i))                  
                    Dim NewPath As String = Path.Combine(filePath, LotSN)
                    If Directory.Exists(NewPath) = False Then
                        Directory.CreateDirectory(NewPath)
                    End If
                    Dim fileName As String = Path.Combine(NewPath, data(i, 0) & ".bin")
                    Dim A2fileName As String = Path.Combine(NewPath, data(i, 0) & "A2" & ".bin")
                    If XGPub_FncModule.clsArray.Index2DArray(data, , 2)(i).ToString <> "" Then
                        A2CodeData = XGPub_FncModule.clsArray.ObjectToByte(XGPub_FncModule.clsArray.Index2DArray(data, , 2)(i))
                        File.WriteAllBytes(A2fileName, A2CodeData)
                    Else
                        A2CodeData = Nothing
                    End If
                    File.WriteAllBytes(fileName, A0CodeData)

                Next
            Else
                Return False
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
            Return False
        Finally
            SQL.CloseConnection()
        End Try
    End Function

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles btnGetAllSN.Click
        btnGetAllSN.Enabled = False
        FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer
        FolderBrowserDialog1.SelectedPath = Application.StartupPath
        FolderBrowserDialog1.ShowDialog()
        Dim filePath As String = FolderBrowserDialog1.SelectedPath
        GetAllCustomCodeAndCreateBinFile(filePath, cbSalesNo.Text)
        btnGetAllSN.Enabled = True
        MsgBox("导出完成！")
    End Sub

    Dim defaultPath As String = ""
    '打开文件夹
    Private Sub OpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenFile.Click
        'InitStatus()
        Dim fileCount As Integer = 1
        Dim folder As New FolderBrowserDialog
        Dim count As Integer = 0        
        If defaultPath <> "" Then
            folder.RootFolder = Environment.SpecialFolder.Desktop
            folder.SelectedPath = defaultPath
        End If
        If folder.ShowDialog = DialogResult.OK Then
            defaultPath = folder.SelectedPath
        Else
            Exit Sub
        End If
        'folder.ShowDialog()
        Try
            Dim FieName As String = folder.SelectedPath
            If FieName = "" Then Throw New Exception("路径不能为空")
            txtBinFilePath.Text = FieName
            Dim di As IO.DirectoryInfo = New IO.DirectoryInfo(FieName)
            Dim dii() As IO.DirectoryInfo = di.GetDirectories
            '获取所有文件
            Dim fii() As IO.FileInfo = di.GetFiles("*.bin", IO.SearchOption.AllDirectories)
            Dim LastSN_StartString As String = ""
            lvBinFileList.Items.Clear()
            txtBinFilePath.Items.Clear()
            'Status.Maximum = count '进度条最大值
            For a = 0 To fii.Count - 1
                If fii(a).Name.Contains("A2") = True Then
                    Continue For
                End If
                Dim allExtension As String = fii(a).Extension
                Dim fileNames As String = LSet(fii(a).Name, fii(a).Name.IndexOf(allExtension))
                Dim item As ListViewItem
                Dim fileSize As Integer
                item = lvBinFileList.Items.Add(fileNames, 0)
                fileSize = fii(a).Length
                If fileSize >= 1024 Then
                    fileSize = fileSize / 1024
                End If
                lvBinFileList.Items(fileCount - 1).ForeColor = IIf(a Mod 2, Color.Red, Color.Black)
                item.SubItems.Add(fileSize.ToString("##,##") & "B")
                item.SubItems.Add(fii(a).LastWriteTime)
                item.SubItems.Add(fii(a).FullName)
                LastSN_StartString = LSet(fileNames, 3)
                AllOk.Text = "选中" & fileCount & "个文件"
                fileCount += 1
                Application.DoEvents()
            Next
            btnLoad.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub

    Public Sub DateTime()
        TimeShow.Text = Date.Now
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        DateTime()
    End Sub

    Private ProductType As Integer = 0
    Private Sub CheckedSFP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedSFP.CheckedChanged, CheckedXFP.CheckedChanged
        ProductType = sender.tag

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        StartName.Enabled = IIf(CheckBox1.Checked, True, False)
    End Sub
End Class


Public Class clsListviewSorter : Implements IComparer
    Private m_ColumnNumber As Integer
    Private m_SortOrder As SortOrder

    Public Sub New(ByVal column_number As Integer, ByVal sort_order As SortOrder)
        m_ColumnNumber = column_number
        m_SortOrder = sort_order
    End Sub

    ' Compare the items in the appropriate column
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim item_x As ListViewItem = DirectCast(x, ListViewItem)
        Dim item_y As ListViewItem = DirectCast(y, ListViewItem)
        ' Get the sub-item values.
        Dim string_x As String
        If item_x.SubItems.Count <= m_ColumnNumber Then
            string_x = ""
        Else
            string_x = item_x.SubItems(m_ColumnNumber).Text
        End If
        Dim string_y As String
        If item_y.SubItems.Count <= m_ColumnNumber Then
            string_y = ""
        Else
            string_y = item_y.SubItems(m_ColumnNumber).Text
        End If
        ' Compare them.
        If m_SortOrder = SortOrder.Ascending Then
            If IsNumeric(string_x) And IsNumeric(string_y) Then
                Return Val(string_x).CompareTo(Val(string_y))
            ElseIf IsDate(string_x) And IsDate(string_y) Then
                Return DateTime.Parse(string_x).CompareTo(DateTime.Parse(string_y))
            Else
                Return String.Compare(string_x, string_y)
            End If
        Else
            If IsNumeric(string_x) And IsNumeric(string_y) Then
                Return Val(string_y).CompareTo(Val(string_x))
            ElseIf IsDate(string_x) And IsDate(string_y) Then
                Return DateTime.Parse(string_y).CompareTo(DateTime.Parse(string_x))
            Else
                Return String.Compare(string_y, string_x)
            End If
        End If
    End Function

End Class
