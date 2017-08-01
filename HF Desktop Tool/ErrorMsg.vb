Public Class ErrorMsg

    Public Sub ShowError(msg As String)
        TextBox1.Text = msg
        Me.ShowDialog()
    End Sub

    Private Sub ErrorMsg_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub ErrorMsg_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class