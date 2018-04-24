Imports XGPub_FncModule.clsConfigFile
Imports System.Windows.Forms
Imports XGPub_FIS.FIS
Public Class frmLogin
    Public isSuccess As Boolean
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim m_User, m_Password As String
        Dim ErrorInfor As String = "OK"
        Try
            m_User = Trim(txtUser.Text)
            UserID = m_User.ToUpper
            If m_User = "" Then
                MsgBox("用户名不能为空！    ", vbCritical, "错误")
                txtUser.Focus()
                txtUser.SelectAll()
                Exit Sub
            End If
            m_Password = Trim(txtPassword.Text)
            If m_Password = "" Then
                MsgBox("密码不能为空！    ", vbCritical, "错误")
                txtPassword.Focus()
                txtPassword.SelectAll()
                Exit Sub
            End If
            isRD_ID = False
            Dim iRet As Integer = fis.CheckUser(m_User, m_Password, ErrorInfor)
            If iRet = SUCCESS Then
                If m_User.ToUpper = UCase("Admin") Then isRD_ID = True
            ElseIf iRet = ERROR_PASSWORD_ERR Then
                MsgBox(ErrorInfor, vbCritical, "错误")
                txtPassword.Focus()
                txtPassword.SelectAll()
                Return
            ElseIf iRet = ERROR_NO_USER Then
                MsgBox(ErrorInfor, vbCritical, "错误")
                txtUser.Focus()
                txtUser.SelectAll()
                Return
            ElseIf iRet = DEBUG_SUCCESS Then
                MsgBox(ErrorInfor, vbInformation, "提示")
            ElseIf iRet = ERROR_NO_AUTHORIZE Then
                MsgBox(ErrorInfor, vbCritical, "错误")
                Return
            End If
            isSuccess = True         
            frmMain.UserName = txtUser.Text
            WriteConfig(iniFileName, "Config", "UserName", m_User)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "提示")
            isSuccess = False
        End Try
    End Sub

    Private Sub btnCannel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCannel.Click
        isSuccess = False
        Me.Close()
    End Sub

    Private Sub txtUser_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUser.GotFocus
        txtUser.SelectAll()
    End Sub

    Private Sub txtPassword_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.GotFocus
        txtPassword.SelectAll()
        If My.Computer.Keyboard.CapsLock Then
            Label1.Text = "大写锁定打开"
        Else
            Label1.Text = ""
        End If
    End Sub

    Private Sub frmLogin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.CapsLock Then
            If My.Computer.Keyboard.CapsLock Then
                Label1.Text = "大写锁定打开"
            Else
                Label1.Text = ""
            End If
        End If
    End Sub

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtPassword.Text = ""
        txtUser.Text = ReadConfig(iniFileName, "Config", "UserName")
    End Sub

    Private Sub frmLogin_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If txtUser.Text <> "" Then
            txtPassword.Focus()
            txtPassword.SelectAll()
        End If
    End Sub
End Class