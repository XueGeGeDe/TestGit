Imports Microsoft.Office.Interop

Public Class Labels

    Private Sub Label_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim f1 As New Form1
        Code.Text = SupplyCode
        SupName.Text = SupplyName
        ModelName.Text = DMM
        txtDate.Text = Date.Now.ToString("yyyy-M-d")
        TextBox17.Text = Count
        TextBox9.Text = CStr(Lot())
    End Sub

    Dim myExcel As New Excel.Application
    Dim exBook As Excel.Workbook
    Dim exSheet As Excel.Worksheet

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim DataPath As String = pathStart & "\TestDatas\标签.xlsx"
            myExcel.Visible = True
            exBook = myExcel.Workbooks.Open(DataPath)
            exSheet = exBook.Worksheets("标签")
            exSheet.Cells(2, 2) = TextBox3.Text
            exSheet.Cells(2, 4) = ModelName.Text
            exSheet.Cells(3, 2) = TextBox7.Text
            exSheet.Cells(3, 4) = Lot()
            exSheet.Cells(4, 2) = Code.Text
            exSheet.Cells(4, 4) = txtDate.Text
            exSheet.Cells(5, 2) = SupName.Text
            exSheet.Cells(5, 4) = TextBox17.Text
            exBook.Save()
            'Dim PrintArea As SizeF
            Dim ps As New PageSetupDialog
            'Dim pd As System.Drawing.Printing.PrintDocument
            '选定打印空间
            Dim PrintSize As System.Drawing.Printing.PaperSize
            PrintSize = New System.Drawing.Printing.PaperSize("A4+", 170, 100)
            'ps.PageSettings.PaperSize = PrintSize '获取打印设置页面
            PrintExc()
            'CloseAndQuitExc()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "错误")
        End Try
    End Sub

    Public Sub CloseAndQuitExc()
        Try
            exBook.Close(True)
            myExcel.Quit()
            myExcel = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, Nothing)
        End Try
    End Sub

    Public Sub PrintExc()
        myExcel.ActiveWorkbook.PrintPreview()
    End Sub


    '批次
    Public Function Lot()
        Dim date1 As Date = Date.Now
        Dim date0 As Date = Year(date1) & "/01/01"
        Dim wk = DateDiff("ww", date0, date1) + 1
        If wk = 0 Then
            Dim date2 = Year(date1) - 1
            Dim date3 = date2 & "/12/31"
            Dim date4 = date2 & "/01/01"
            wk = DateDiff("ww", date4, date3) + 1
        End If
        Return wk
    End Function


End Class