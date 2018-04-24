Public Class frmQuery
    Private Sub btnQuerySN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuerySN.Click
        Dim RowCount As Integer
        Dim Data(,) As Object = Nothing
        SourceGrid1.ClearAllRow()
        Dim strSQL As String = "Select * from T_ResData_TOSA where idx in(select max(idx) from T_ResData_TOSA where F_SN='" & txtSN.Text & "')"
        RowCount = FetchAllData(strSQL, Data)
        If RowCount > 0 Then
            SourceGrid1.MaxRow = RowCount
            SourceGrid1.SetCellArrayValue(1, 1, Data)
            SourceGrid1.ColumnTextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter
            SourceGrid1.ColumnTextAlignment(2) = DevAge.Drawing.ContentAlignment.MiddleLeft
        End If
    End Sub

    Public Function FetchAllData(ByVal strSQL As String, ByRef data(,) As Object) As Integer
        Dim SQL As New XGPub_FncModule.clsDBControl
        Dim RowCount As Integer = 0
        Try
            If SQL.OpenConnection(ConnectString) = False Then Throw New Exception("数据库连接失败")
            If SQL.FetchAllData(strSQL, data, RowCount) = False Then Throw New Exception("数据库查询失败")
            Return RowCount
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "错误")
            Return 0
        Finally
            If SQL IsNot Nothing Then SQL.CloseConnection()
            SQL = Nothing
        End Try
    End Function

    Private Sub frmQuery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Columns() As String = {"IDX", "SN", "Type", "ItemType", "Value", "Rpin1", "Rpin2", "Rpin3", "Rpin5", "Rpin7", "Rpin8", "Rpin7_8", "Vpin2", "Vpin3", "Remark", "Reslut", "Rpin", "PCName", "Date"}
        SourceGrid1.ClearAllRow()
        SourceGrid1.MaxRow = 0
        SourceGrid1.MaxColumn = 19
        'SourceGrid1.ResizeColumn = False
        SourceGrid1.CellOnlyRead = True
        SourceGrid1.SetColumnHeader(Columns)
        SourceGrid1.SetColumnHeader(2, "SN", 80)
        SourceGrid1.SetColumnHeader(10, "Rpin7_8", 60)
        SourceGrid1.SetColumnHeader(16, "Reslut", 120)
        SourceGrid1.AddRightMenu = True
    End Sub

    Private Sub btnQuerySNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuerySNs.Click
        Dim RowCount As Integer
        Dim Data(,) As Object = Nothing
        SourceGrid1.ClearAllRow()
        'SELECT a.*FROM test AS a INNER JOIN (SELECT max(id) as maxid FROM test group by rb)  AS b ON a.id=b.maxid;
        Dim strSQL As String = "Select a.* from T_ResData_TOSA as a inner join(select max(idx) as maxid from T_ResData_TOSA where F_SN between '" & txtSNStart.Text & "' and '" & txtSNEnd.Text & "' group by F_SN) AS b ON a.idx=b.maxid"
        RowCount = FetchAllData(strSQL, Data)
        If RowCount > 0 Then
            SourceGrid1.MaxRow = RowCount
            SourceGrid1.SetCellArrayValue(1, 1, Data)
            SourceGrid1.ColumnTextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter
            SourceGrid1.ColumnTextAlignment(2) = DevAge.Drawing.ContentAlignment.MiddleLeft
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim RowCount As Integer
        Dim Data(,) As Object = Nothing
        SourceGrid1.ClearAllRow()
        Dim strSQL As String = "Select * from T_ResData_TOSA where F_SN='" & txtSN.Text & "'"
        RowCount = FetchAllData(strSQL, Data)
        If RowCount > 0 Then
            SourceGrid1.MaxRow = RowCount
            SourceGrid1.SetCellArrayValue(1, 1, Data)
            SourceGrid1.ColumnTextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter
            SourceGrid1.ColumnTextAlignment(2) = DevAge.Drawing.ContentAlignment.MiddleLeft
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim RowCount As Integer
        Dim Data(,) As Object = Nothing
        SourceGrid1.ClearAllRow()
        Dim strSQL As String = "Select * from T_ResData_TOSA where F_SN between '" & txtSNStart.Text & "' and '" & txtSNEnd.Text & "'"
        RowCount = FetchAllData(strSQL, Data)
        If RowCount > 0 Then
            SourceGrid1.MaxRow = RowCount
            SourceGrid1.SetCellArrayValue(1, 1, Data)
            SourceGrid1.ColumnTextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter
            SourceGrid1.ColumnTextAlignment(2) = DevAge.Drawing.ContentAlignment.MiddleLeft
        End If
    End Sub

End Class