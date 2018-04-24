Imports Microsoft.Office.Interop
Imports System.Threading
Imports System.IO

Public Class Form1
#Region "Property"
    Private fis As New XGPub_FncModule.clsUseExcel
    Private DBControl As New XGPub_FncModule.clsDBControl
    Private ConnectString As String = "Server=(local);Data Source=192.168.1.19;Initial Catalog=TestData;User Id=XGIGA;password=Test2015"
    Private AppXls As Excel.Application    '声明Excel对象
    Private AppWokBook As Excel.Workbook   '声明工作簿对象
    Private AppSheet As Excel.Worksheet    '声明工作表对象
    Private i As Integer = 1
    Private j As Integer = 1
    Private AllSN As New ArrayList
    Private SheetName() As String = {"10G 0℃测试报告", "10G 25℃测试报告", "10G 70℃测试报告"}
    Private Sheet100Name() As String = {"100G -5℃测试报告", "100G 25℃测试报告", "100G 75℃测试报告"}
    Private DataPath As String = pathStart & "\TestDatas\ZTE CPK&测试报告.xlsx" '声明测试报告路径
    Private Have10 As Boolean
    Private Have100 As Boolean
    Private XMLpath As String
    Private EXCPath As String
    'Private ALLXMLData(,) As Object
#End Region
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim data(,) As Object = Nothing
        LowTemp.ForeColor = Color.Blue
        HighTemp.ForeColor = Color.Red
        AppXls = New Excel.Application
        ' AppXls.Visible = True
        txPName.Focus()
        nsgData.MaxColumn = 3
        nsgData.MaxRow = 0
        nsgData.SetColumnHeader(1, "SN", 234)
        nsgData.SetColumnHeader(2, "产品类型", 233)
        nsgData.SetColumnHeader(3, "Pass/No", 233)
        nsgData.CellOnlyRead = True
        data = SearchInfo("T_ZETLable")
        For a = 0 To UBound(data, 1) - 1
            SelectModel.Items.Add(data(a, 1))
        Next
        SelectModel.DropDownStyle = ComboBoxStyle.DropDownList
        DDMRate.DropDownStyle = ComboBoxStyle.DropDownList
        nsgData.ColumnTextAlignment(-1) = DevAge.Drawing.ContentAlignment.MiddleCenter
        AppWokBook = AppXls.Workbooks.Open(DataPath) '打开已经存在的EXCEL文件
    End Sub

    Dim data1(,), data2(,), data3(,), data4(,), data5(,), data6(,) As Object
    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txPName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim PassOrNG As Boolean = True
            Try
                frmtxtStatus.Text = "扫描中...."
                If SelectModel.Text = "" Then Throw New Exception("请选取规格型号")
                If DDMRate.Text = "" Then Throw New Exception("请选取产品速率")
                txPName.SelectAll()
                If DBControl.OpenConnection(ConnectString) = False Then Throw New Exception("连接数据库失败")
                If AllSN.Contains(Trim(txPName.Text)) Then
                    Throw New Exception("产品型号重复！")
                Else
                    AllSN.Add(txPName.Text)
                End If
                If DDMRate.Text = "10G" Then
                    Test10Data(PassOrNG)
                ElseIf DDMRate.Text = "100G" Then
                    Test100Data(PassOrNG)
                End If
                TextBox2.Text = AllSN.Count
                frmtxtStatus.Text = "扫描结束"
            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "错误")
            End Try
        End If
    End Sub


    Public Sub LabelNature()
        Try
            Dim strSQL As String = "select * from T_ZETLable where F_PN ='" & SelectModel.Text & "'"
            Dim data(,) As Object = Nothing
            If DBControl.OpenConnection(ConnectString) = False Then Throw New Exception("连接数据库失败")
            If DBControl.FetchAllData(strSQL, data) = False Then Throw New Exception("数据查询出错")
            WriteInfoToSourceGrid(data)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If SelectModel.Text = "" Then Throw New Exception("请选择规格型号！")
            LabelNature()
            Count = AllSN.Count
            Labels.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub

    '10G测试
    Public Sub Test10Data(ByVal PassNG As Boolean)
        Try
            If LowTemp.Checked = True Then
                data1 = SearchTestData(txPName.Text, -50, 10)
                If data1 Is Nothing Then
                    AllSN.RemoveAt(AllSN.Count - 1)
                    Throw New Exception("未找到0℃(低温)测试数据")
                End If

                PassNG = PassNG And CheckAllData(data1(0, Temp - 1))
                OpenExcel("10G 0℃测试报告")
                AppSheet.Range("A" & (6 + i)).Resize(1, Temp).Value = data1
            End If

            If HighTemp.Checked = True Then
                data3 = SearchTestData(txPName.Text, 50, 200)
                If data3 Is Nothing Then
                    AllSN.RemoveAt(AllSN.Count - 1)
                    Throw New Exception("未找到70℃(高温)测试数据")
                End If
                PassNG = PassNG And CheckAllData(data3(0, Temp - 1))
                OpenExcel("10G 70℃测试报告")
                'WriteExcel(data3, i)
                AppSheet.Range("A" & (6 + i)).Resize(1, Temp).Value = data3
            End If

            data2 = SearchTestData(txPName.Text, 20, 35)
            If data2 Is Nothing Then
                AllSN.RemoveAt(AllSN.Count - 1)
                Throw New Exception("未找到25℃(常温)测试数据")
            End If
            PassNG = PassNG And CheckAllData(data2(0, Temp - 1))
            OpenExcel("10G 25℃测试报告")
            AppSheet.Range("A" & (6 + i)).Resize(1, Temp).Value = data2
            nsgData.AddRow()
            Dim POrNG As String = IIf(PassNG, "Pass", "NG")
            nsgData.SetCellValue(AllSN.Count, 3, POrNG)
            If PassNG = False Then
                nsgData.SetCellBackColor(i) = Color.Red
            End If
            nsgData.SetCellValue(AllSN.Count, 1, txPName.Text)
            nsgData.SetCellValue(AllSN.Count, 2, DDMRate.Text)
            AddExcRow()
            i += 1
            Have10 = True
            My.Application.DoEvents()
        Catch ex As Exception
            frmtxtStatus.ForeColor = Color.Red
            frmtxtStatus.Text = "扫描失败"
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub

    '100G测试
    Public Sub Test100Data(ByVal PassNG As Boolean)
        Try
            For a = 0 To 3
                If LowTemp.Checked = True Then
                    data4 = SearchChannelInfo(txPName.Text, -50, 10, a)
                    If data4 Is Nothing Then
                        AllSN.RemoveAt(AllSN.Count - 1)
                        Throw New Exception("未找到-5℃(低温)测试数据")
                    End If
                    PassNG = PassNG And CheckAllData(data4(0, 13))
                    OpenExcel("100G -5℃测试报告")
                    'WriteChannelExc(data4, j)                 
                    AppSheet.Range("A" & (13 + j)).Resize(1, 14).Value = data4
                End If

                If HighTemp.Checked = True Then
                    data6 = SearchChannelInfo(txPName.Text, 50, 200, a)
                    If data6 Is Nothing Then
                        AllSN.RemoveAt(AllSN.Count - 1)
                        Throw New Exception("未找到75℃(高温)测试数据")
                    End If
                    PassNG = PassNG And CheckAllData(data6(0, 13))
                    OpenExcel("100G 75℃测试报告")
                    AppSheet.Range("A" & (13 + j)).Resize(1, 14).Value = data6
                End If
                data5 = SearchChannelInfo(txPName.Text, 20, 35, a)
                If data5 Is Nothing Then
                    AllSN.RemoveAt(AllSN.Count - 1)
                    Throw New Exception("未找到25℃(常温)测试数据")
                End If
                PassNG = PassNG And CheckAllData(data5(0, 13))
                OpenExcel("100G 25℃测试报告")
                AppSheet.Range("A" & (13 + j)).Resize(1, 14).Value = data5
                j += 1
            Next
            'WriteInfoToSourceGrid(datas)
            Have100 = True
            nsgData.AddRow()
            Dim POrNG As String = IIf(PassNG, "Pass", "NG")
            nsgData.SetCellValue(AllSN.Count, 3, POrNG)
            If PassNG = False Then
                nsgData.SetCellBackColor(AllSN.Count) = Color.Red
            End If
            nsgData.SetCellValue(AllSN.Count, 1, txPName.Text)
            nsgData.SetCellValue(AllSN.Count, 2, DDMRate.Text)
            Add100ExcRow()
            Count = AllSN.Count
            My.Application.DoEvents()
        Catch ex As Exception
            frmtxtStatus.Text = "扫描失败"
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub


    '将值写入NewSourceGrid
    Public Sub WriteInfoToSourceGrid(ByVal data(,) As Object)
        SupplyName = data(0, 3)
        SupplyCode = data(0, 2)
        DMM = data(0, 1)
        ' Labels.Count = AllSN.Count
        Application.DoEvents()
    End Sub


    '判断是否合格
    Public Function CheckAllData(ByVal Res As String) As Boolean
        If Res.Contains("NG") Then
            CheckAllData = False
        Else
            CheckAllData = True
        End If
        Return CheckAllData
    End Function

    '打开Sheet表
    Public Sub OpenExcel(ByVal SheetName As String)
        AppSheet = AppWokBook.Sheets(SheetName)
    End Sub

    '查询物料
    Public Function SearchInfo(ByVal TableName As String)
        Dim data(,) As Object = Nothing
        Try
            Dim strSQL As String = "select * from " & TableName
            If DBControl.OpenConnection(ConnectString) = False Then Throw New Exception("连接数据库失败")
            If DBControl.FetchAllData(strSQL, data) = False Then Throw New Exception("数据库未读取到数据")
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
        Return data
    End Function

    '10G SQL
    Public Function SearchTestData(ByVal SN As String, ByVal Tem1 As Integer, ByVal Tem2 As Integer)
        Dim data(,) As Object = Nothing
        Dim EEPromCdata(,) As Object = Nothing
        Try
            Dim Conf10 As String = XGPub_FncModule.clsConfigFile.ReadConfig(Application.StartupPath & "\Config.ini", "DB Set", "RealServer")
            'Dim EEPromC As String = "select F_OldSN from T_EEPROM_Change where IDX=(select Max(IDX) from T_EEPROM_Change where F_NewSN='" & SN & "')"
            If DBControl.OpenConnection(ConnectString) = False Then Throw New Exception("连接数据库失败")
            'If DBControl.FetchAllData(EEPromC, EEPromCdata) = False Then Throw New Exception("数据库未读取到数据")
            'Dim strSQL As String = "select ExtSN,O_Power,O_Ext,O_Cross,O_Mask,O_Sens,RxOMA,LosAssert,LosDeassert,DDM_Vcc,DDM_Bias,DDM_Temp,DDM_TxPower,DDM_RxPower1,DDM_RxPower2,DDM_RxPower3,Result,Temperature from T_TestData where (IDX=(select Max(a.IDX) from  T_TestData as a where (TxRate='10.3125Gbps') and (ExtSN='" & SN & "') and (Temperature between " & Tem1 & " and " & Tem2 & ")))"
            Dim strSQL As String = "select " & Conf10 & " from T_TestData where (IDX=(select Max(a.IDX) from  T_TestData as a where (TxRate='10.3125Gbps') and (ExtSN='" & SN & "') and (Temperature between " & Tem1 & " and " & Tem2 & ")))"
            If DBControl.FetchAllData(strSQL, data) = False Then Throw New Exception("数据库未读取到数据")
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
        Return data
    End Function

    '100G SQL
    Public Function SearchChannelInfo(ByVal SN As String, ByVal Tem1 As Integer, ByVal Tem2 As Integer, ByVal Channel As Integer)
        Dim data(,) As Object = Nothing
        Try
            Dim dataEEProm(,) As Object = Nothing
            Dim Conf100 As String = XGPub_FncModule.clsConfigFile.ReadConfig(Application.StartupPath & "\Config.ini", "DB 100G", "RealServer100")
            ' Dim EERromSQl As String = "select F_OldSN from T_EEPROM_Change where IDX=(select Max(IDX) from T_EEPROM_Change where F_NewSN='" & SN & "')"
            If DBControl.OpenConnection(ConnectString) = False Then Throw New Exception("连接数据库失败")
            'If DBControl.FetchAllData(EERromSQl, dataEEProm) = False Then Throw New Exception("数据库未读取到数据")
            Dim strSQL As String = "select " & Conf100 & " from T_TestData where IDX=(select Max(a.IDX) from T_TestData as a where (TxRate='25.78125Gbps') and SN='" & SN & "' and (Temperature between " & Tem1 & " and " & Tem2 & " and modChannel ='" & Channel & "'))"
            'Dim strSQL As String = "select SN,Temperature,modChannel,O_Power,O_Ext,O_Rmsj,CenterWave,O_Sens,LosAssert,LosDeassert,DDM_TxPower,DDM_RxPower1,DDM_RxPower2,Result from T_TestData where IDX=(select Max(a.IDX) from T_TestData as a where (TxRate='25.78125Gbps') and SN='" & dataEEProm(0, 0) & "' and (Temperature between " & Tem1 & " and " & Tem2 & " and modChannel ='" & Channel & "'))"
            'Dim strSQL As String = "select SN,Temperature,modChannel,O_Power,O_Ext,O_Rmsj,CenterWave,O_Sens,LosAssert,LosDeassert,DDM_TxPower,DDM_RxPower1,DDM_RxPower2,Result from T_TestData where IDX=(select Max(a.IDX) from T_TestData as a where (TxRate='25.78125Gbps') and SN=(select F_OldSN from T_EEPROM_Change where IDX=(select Max(IDX) from T_EEPROM_Change where F_NewSN='" & SN & "')) and (Temperature between " & Tem1 & " and " & Tem2 & " and modChannel ='" & Channel & "'))"
            If DBControl.FetchAllData(strSQL, data) = False Then Throw New Exception("数据库未读取到数据")
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
        Return data
    End Function

    '清除所有数据
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        nsgData.MaxRow = 0
        If Have10 = True Then
            DeleteAllExcRow()
        End If
        If Have100 = True Then
            Dele100ExcAllRow()
        End If
        My.Application.DoEvents()
        'InitExc()
        TextBox2.Text = 0
    End Sub

    '删除一行
    Public RowNum As Integer
    Public Sub DeleteRow(ByVal LineNumber As Integer)
        nsgData.Rows.Remove(LineNumber)
    End Sub

    Public Sub CheckContidion()
        Try
            If SelectModel.Text = "" Then Throw New Exception("请选取规格型号")
            If DDMRate.Text = "" Then Throw New Exception("请选取产品速率")
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub

    Public Sub CloseExc()
        AppWokBook.Close(True)
        AppXls.Quit()
        AppXls = Nothing
    End Sub

    '窗口关闭 表格初始化 并 断开
    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
            InitExc()
            CloseExc()
    End Sub

    Private Sub nsgData_SelectCell(ByVal sender As SourceGrid.CellContext, ByVal e As System.Windows.Forms.MouseEventArgs) Handles nsgData.SelectCell
        RowNum = sender.Position.Row
    End Sub

    '清除一行数据和表格数据
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If AllSN.Count <= 0 Then Throw New Exception("无法删除")
            If DDMRate.Text = nsgData.GetCellValue(RowNum, 2) And DDMRate.Text = "10G" Then
                DeleteRow(RowNum)
                TextBox2.Text -= 1
                DeleteExcRow(AllSN(RowNum - 1))

            ElseIf DDMRate.Text = nsgData.GetCellValue(RowNum, 2) And DDMRate.Text = "100G" Then
                DeleteRow(RowNum)
                TextBox2.Text -= 1
                Dele100ExcOneRow(AllSN(RowNum - 1))
            Else
                Throw New Exception("请选择正确的型号删除")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub

    '清除10G表格中的某个数据 i-1
    Public Sub DeleteExcRow(ByVal SName As String)
        Dim xl10Range As Excel.Range
        Dim Data10 As String
        Dim Row10 As Integer
        AppSheet = AppWokBook.Sheets("10G 25℃测试报告")
        For Product = 7 To (i + 5)  '从第7行开始搜索
            xl10Range = AppSheet.Cells(Product, 1)
            Data10 = xl10Range.Value
            If Data10 <> Nothing Then
                If Data10.Contains(SName) Then
                    Row10 = Product
                End If
            End If
        Next
        For a = 0 To 2
            AppSheet = AppWokBook.Worksheets(SheetName(a))
            AppSheet.Range(Row10 & ":" & Row10).Delete()
            'AppSheet.Range(RowNums + 6 & ":" & RowNums + 6).Delete()
        Next
        i -= 1
        AllSN.RemoveAt(RowNum - 1)
    End Sub

    '删除10G模块表格中的所有数据
    Public Sub DeleteAllExcRow()
        For b = 1 To i - 1
            For a = 0 To 2
                AppSheet = AppWokBook.Worksheets(SheetName(a))
                AppSheet.Range(7 & ":" & 7).Delete()
            Next
        Next
        AllSN.Clear()
        i = 1
    End Sub

    '删除100G表格中的某个数据 j-4
    Public Sub Dele100ExcOneRow(ByVal SNames As String)
        Try
            Dim xlRange As Excel.Range
            Dim Data100 As String
            Dim SNIndex As New ArrayList
            AppSheet = AppWokBook.Sheets("100G 25℃测试报告")
            For y = 14 To 14 + (j - 2) Step 4
                xlRange = AppSheet.Cells(y, 1)
                Data100 = xlRange.Value
                If Data100 <> Nothing Then
                    If Data100.Contains(SNames) Then
                        SNIndex.Add(y)
                    End If
                End If
            Next
            For a = 0 To 2
                AppSheet = AppWokBook.Sheets(Sheet100Name(a))
                If SNIndex.Count > 0 Then
                    For xy = 1 To 4
                        AppSheet.Range(SNIndex(0) & ":" & SNIndex(0)).Delete()
                    Next
                End If
            Next
            j -= 4
            RowCounts -= 4
            AllSN.RemoveAt(RowNum - 1)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub

    '删除100G模块所有测试数据
    Public Sub Dele100ExcAllRow()
        For b = 1 To (j - 1)
            For a = 0 To 2
                AppSheet = AppWokBook.Worksheets(Sheet100Name(a))
                AppSheet.Range(14 & ":" & 14).Delete()
            Next
        Next
        AllSN.Clear()
        j = 1
    End Sub


    '增加10G表格行数
    Public Sub AddExcRow()
        For a = 0 To 2
            AppSheet = AppWokBook.Worksheets(SheetName(a))
            AppSheet.Rows(i + 7).Insert() '从第八行开始插入
        Next
    End Sub

    '增加100G表格行数
    Dim RowCounts As Integer = 22
    Public Sub Add100ExcRow()
        For a = 0 To 2
            AppSheet = AppWokBook.Worksheets(Sheet100Name(a))
            For b = 1 To 4
                AppSheet.Rows(RowCounts).Insert()
            Next
            AppSheet.Range("A" & RowCounts & ":" & "A" & RowCounts + 3).Merge()
            AppSheet.Range("B" & RowCounts & ":" & "B" & RowCounts + 3).Merge()
        Next
        RowCounts += 4
    End Sub


    Public Sub OtherTestData()
        For a = 0 To 2
            AppSheet = AppWokBook.Worksheets(Sheet100Name(a))
            AppSheet.Cells(4, 6) = SupplyName
            AppSheet.Cells(4, 13) = j - 1
            AppSheet = AppWokBook.Worksheets(SheetName(a))
        Next
    End Sub

    '初始化Excel表格
    Public Sub InitExc()
        If Have10 = True Then DeleteAllExcRow()
        If Have100 = True Then Dele100ExcAllRow()
    End Sub

    Public Sub Get10GData(ByVal ExcelPath As String)
        Dim ALLXMLData((AllSN.Count - 1), TempCount - 1) As Object
        Dim GG As Excel.Range = Nothing
        OpenExcel("10G 25℃测试报告")
        For x = 0 To AllSN.Count - 1
            For ThreeSheets = 0 To 2
                'OpenExcel(SheetName(ThreeSheets))
                If ThreeSheets = 0 Then
                    For ly = Temp To Temp - 1 + LCount
                        GG = AppSheet.Cells(x + 7, ly - Temp + 2)
                        ALLXMLData(x, ly) = GG.Value
                    Next
                ElseIf ThreeSheets = 1 Then
                    For ty = 0 To Temp - 1
                        GG = AppSheet.Cells(x + 7, ty + 1)
                        ALLXMLData(x, ty) = GG.Value
                    Next
                ElseIf ThreeSheets = 2 Then
                    For hy = Temp + LCount To TempCount - 1
                        GG = AppSheet.Cells(x + 7, hy - Temp - LCount + 2)
                        ALLXMLData(x, hy) = GG.Value
                    Next
                End If
            Next
        Next
        ExportXML(ALLXMLData, ExcelPath)
    End Sub

    '导出XML文件
    Private RunNum As String
    Public Sub ExportXML(ByVal XMLData(,) As Object, ByVal Path As String)
        Dim DateDay As Integer = XGPub_FncModule.clsConfigFile.ReadConfig(Application.StartupPath & "\Config.ini", "DB Set", "DateDay")
        Dim SerialNumber As String = XGPub_FncModule.clsConfigFile.ReadConfig(Application.StartupPath & "\Config.ini", "DB Set", "SerialNumber")
        '如果是新的一天 则流水号从0开始
        If CInt(Format(Date.Today, "dd")) <> DateDay Then
            SerialNumber = "000"
            XGPub_FncModule.clsConfigFile.WriteConfig(Application.StartupPath & "\Config.ini", "DB Set", "DateDay", Format(Date.Today, "dd"))
        End If
        Dim RealPath As String = Path & "\" & UserCode & Format(Date.Now, "yyyyMMdd") & SerialNumber & ".xml"
        Dim writer As New Xml.XmlTextWriter(RealPath, System.Text.Encoding.GetEncoding("utf-8"))
        Try
            Dim Url As String = "http://ZTE.SRM.Supplier.Schemas.Report"
            Dim TestItem10() As String = GetItem("Server", 0)
            Dim TestItem100() As String = GetItem("Server100", 1)
            RunNum = SerialNumber
            writer.Formatting = Xml.Formatting.Indented '使用自动缩进/
            writer.WriteRaw("<?xml version=""1.0"" encoding=""utf-8""?>")
            writer.WriteStartElement("QualityReport", Url)
            writer.WriteElementString("TransactionID", "TR33002400" & Format(Date.Now, "yyyyMMdd") & SerialNumber)
            writer.WriteElementString("SupplierNo", "33002400")
            writer.WriteElementString("SupplierName", "深圳市极致兴通科技有限公司")
            writer.WriteElementString("BrandName", "XGIGA")
            writer.WriteElementString("TotalQuantity", AllSN.Count)
            writer.WriteElementString("Date", Format(Date.Now, "yyyyMMdd"))
            writer.WriteElementString("Time", Format(Date.Now, "HHmmssfff"))
            writer.WriteStartElement("Items")
            writer.WriteStartElement("Item")
            writer.WriteElementString("ItemNo", SupplyCode)
            writer.WriteElementString("ItemStyle", DMM)
            writer.WriteElementString("BatchNo", Labels.Lot)
            writer.WriteElementString("ManufactureDate", Format(Date.Now, "yyyyMMdd"))
            writer.WriteStartElement("Serials")
            If DDMRate.Text = "10G" Then
                For a = 0 To XMLData.GetLength(0) - 1
                    '当XML文件达到20M的时候，将数据写入下一个文件
                    Dim FileInfo As FileInfo = New FileInfo(RealPath)
                    If a > 8000 Then
                        '    SerialNumber = +1
                        '    RealPath = Path & "\" & UserCode & Format(Date.Now, "yyyyMMdd") & SerialNumber & ".xml"
                        '    writer.Formatting = Xml.Formatting.Indented
                        '    writer = New Xml.XmlTextWriter(RealPath, System.Text.Encoding.GetEncoding("utf-8"))
                        Call CreateNewXML(XMLData, 8000, XMLData.GetLength(0))
                    End If
                    writer.WriteStartElement("Serial")
                    writer.WriteElementString("SerialNo", XMLData(a, 0))
                    For b = 0 To XMLData.GetLength(1) - 2
                        writer.WriteStartElement("Reserved")
                        writer.WriteAttributeString("Name", TestItem10(b))
                        ' If XMLData(a, b) = Nothing Then Throw New Exception("数据存在空值！")
                        writer.WriteElementString("Value", Math.Round(XMLData(a, b + 1), 10))
                        writer.WriteFullEndElement()
                    Next
                    writer.WriteFullEndElement()
                Next
            ElseIf DDMRate.Text = "100G" Then
                'Dim Server100() As String
                ' Server100 = GetItem("Server100", 1)
                'Server100L = GetItem("Server100L", 1)
                'Server100H = GetItem("Server100H", 1)
                For c = 0 To XMLData.GetLength(0) - 1
                    writer.WriteStartElement("Serial")
                    writer.WriteElementString("SerialNo", XMLData(c, 0))
                    For d = 1 To XMLData.GetLength(1) - 1
                        writer.WriteStartElement("Reserved")
                        If d <= LCount100G Then
                            writer.WriteAttributeString("Name", TestItem100(d - 1) & "_L")
                            'writer.WriteAttributeString("Name", Server100L(d - 1))
                            If XMLData(c, d) = Nothing Then Throw New Exception("数据存在空值，请检查！")
                            writer.WriteElementString("Value", Math.Round(XMLData(c, d), 10))
                            'writer.WriteFullEndElement()
                        ElseIf d >= LCount100G + 1 And d <= Temp100 + LCount100G Then
                            writer.WriteAttributeString("Name", TestItem100(d - LCount100G - 1))
                            writer.WriteElementString("Value", Math.Round(XMLData(c, d), 10))
                        ElseIf d >= Temp100 + LCount100G + 1 Then
                            'writer.WriteAttributeString("Name", Server100H(d - Temp100 - LCount100G - 1))
                            writer.WriteAttributeString("Name", TestItem100(d - Temp100 - LCount100G - 1) & "_H")
                            writer.WriteElementString("Value", Math.Round(XMLData(c, d), 10))
                        End If
                        writer.WriteFullEndElement()
                    Next
                    writer.WriteFullEndElement()
                Next
                writer.WriteEndElement()
            End If
            'writer.Flush()
            SerialNumber += 1
            SerialNumber = Format(Val(SerialNumber), "000")
            XGPub_FncModule.clsConfigFile.WriteConfig(Application.StartupPath & "\Config.ini", "DB Set", "SerialNumber", SerialNumber)
            MsgBox("导出成功！", vbInformation, "提示")
            frmtxtStatus.BackColor = Color.Black
            frmtxtStatus.Text = "导出成功."
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
            frmtxtStatus.BackColor = Color.Red
            frmtxtStatus.Text = "导出XML文件失败！"
        Finally
            writer.WriteFullEndElement()
            writer.Close()
        End Try
    End Sub


    '每当XML文件中包含的模块数量超出8000时生成新的XML文件
    Public Sub CreateNewXML(ByVal AllData(,) As Object, ByVal StartIndex As Integer, ByVal EndInex As Integer)
        Try





        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub


    '获取100G的Exc表格数据
    Private Sub Get100GData(ByVal ExcelPath As String)
        ' Try
        Dim Index As Integer = 0
        Dim All100Data(AllSN.Count - 1, TempCount100G - 1) As Object
        Dim DDM100 As Excel.Range = Nothing
        'For a = 14 To 14 + (AllSN.Count - 1) * 4 Step 4
        For a = 1 To AllSN.Count
            For intSheet = 0 To 2
                OpenExcel(Sheet100Name(intSheet))
                All100Data(a - 1, 0) = AppSheet.Cells(14 + (a - 1) * 4, 1).value
                If intSheet = 0 Then
                    For b = 4 To Count100G
                        DDM100 = AppSheet.Cells(14 + (a - 1) * 4, b)
                        All100Data(a - 1, 1 + (b - 4) * 4) = DDM100.Value
                        DDM100 = AppSheet.Cells(14 + (a - 1) * 4 + 1, b)
                        All100Data(a - 1, 1 + (b - 4) * 4 + 1) = DDM100.Value
                        DDM100 = AppSheet.Cells(14 + (a - 1) * 4 + 2, b)
                        All100Data(a - 1, 1 + (b - 4) * 4 + 2) = DDM100.Value
                        DDM100 = AppSheet.Cells(14 + (a - 1) * 4 + 3, b)
                        All100Data(a - 1, 1 + (b - 4) * 4 + 3) = DDM100.Value
                    Next
                ElseIf intSheet = 1 Then
                    For b = 4 To Count100G
                        DDM100 = AppSheet.Cells(14 + (a - 1) * 4, b)
                        All100Data(a - 1, 1 + (b - 4) * 4 + Temp100) = DDM100.Value
                        DDM100 = AppSheet.Cells(14 + (a - 1) * 4 + 1, b)
                        All100Data(a - 1, 1 + (b - 4) * 4 + 1 + Temp100) = DDM100.Value
                        DDM100 = AppSheet.Cells(14 + (a - 1) * 4 + 2, b)
                        All100Data(a - 1, 1 + (b - 4) * 4 + 2 + Temp100) = DDM100.Value
                        DDM100 = AppSheet.Cells(14 + (a - 1) * 4 + 3, b)
                        All100Data(a - 1, 1 + (b - 4) * 4 + 3 + Temp100) = DDM100.Value
                    Next
                ElseIf intSheet = 2 Then
                    For b = 4 To Count100G
                        DDM100 = AppSheet.Cells(14 + (a - 1) * 4, b)
                        All100Data(a - 1, 1 + (b - 4) * 4 + Temp100 + LCount100G) = DDM100.Value
                        DDM100 = AppSheet.Cells(14 + (a - 1) * 4 + 1, b)
                        All100Data(a - 1, 1 + (b - 4) * 4 + 1 + Temp100 + LCount100G) = DDM100.Value
                        DDM100 = AppSheet.Cells(14 + (a - 1) * 4 + 2, b)
                        All100Data(a - 1, 1 + (b - 4) * 4 + 2 + Temp100 + LCount100G) = DDM100.Value
                        DDM100 = AppSheet.Cells(14 + (a - 1) * 4 + 3, b)
                        All100Data(a - 1, 1 + (b - 4) * 4 + 3 + Temp100 + LCount100G) = DDM100.Value
                    Next
                End If
            Next
        Next
        ExportXML(All100Data, ExcelPath)
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TimeText.Text = "时间：" & Date.Now
    End Sub

    Private Sub 退出ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 退出ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Dim DefaultPath As String = ""
    Private Sub 导出XML文件ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 导出XML文件ToolStripMenuItem.Click
        Try
            If AllSN.Count = 0 Then Throw New Exception("无导出数据！")
            If MsgBox("确定导出XML文件？", vbYesNo, "信息") = vbYes Then
                LabelNature()
                Dim floder As New FolderBrowserDialog
                If floder.ShowDialog = DialogResult.OK Then
                    DefaultPath = floder.SelectedPath
                End If
                If DDMRate.Text = "10G" Then
                    Get10GData(DefaultPath)
                ElseIf DDMRate.Text = "100G" Then
                    Get100GData(DefaultPath)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub

    '导出excel数据
    Private Sub 导出Excel文件ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 导出Excel文件ToolStripMenuItem.Click
        Try
            If AllSN.Count = 0 Then Throw New Exception("无导出数据！")
            If MsgBox("确认现在导出测试数据？", vbYesNo, "提示") = vbYes Then
                OtherTestData()
                LabelNature()
                Dim Floder As New FolderBrowserDialog
                Dim ExcPath As String = ""
                If Floder.ShowDialog = DialogResult.OK Then
                    ExcPath = Floder.SelectedPath
                End If
                'CloseExc()
                'AppXls.ActiveWorkbook.SaveAs("D:\模块测试数据.xlsx", )
                AppXls.ActiveWorkbook.SaveCopyAs(ExcPath & "\" & Format(Date.Now, "HHmmssfff") & "模块测试数据.xlsx")
                MsgBox("导出成功.", vbInformation, "提示")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub

    Private Sub 上传XMLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 上传XMLToolStripMenuItem.Click
        上传XML.ShowDialog()
    End Sub


    '当XML文件大小超过20M，将它分为两个
    Public Sub DivideTwo(ByVal RealPath As String)
        '查询文件的大小
        Try
            Dim XMLFileInfo As FileInfo = New FileInfo(RealPath)
            If XMLFileInfo.Length > 20000 * 1024 Then
                XMLFileInfo.OpenWrite()
                Dim xmlDou As System.Xml.XmlDocument



            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try        
    End Sub
End Class
