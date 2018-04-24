Public Class LightInput
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If L1.Text = "" Or L2.Text = "" Or L3.Text = "" Or L0.Text = "" Then
            MsgBox("光功率输入值不能为空，请重新输入", vbCritical, "错误")
        Else
            frmMain.Lights(0) = Me.L0.Value
            frmMain.Lights(1) = Me.L1.Value
            frmMain.Lights(2) = Me.L2.Value
            frmMain.Lights(3) = Me.L3.Value
            Me.Visible = False
        End If
    End Sub

    Private Sub LightInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class