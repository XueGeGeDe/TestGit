Public Class frmMsgProgress

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If DB_isConnect Then
            Timer1.Enabled = False
            Me.Close()
        End If
    End Sub
End Class