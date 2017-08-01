Public Class Msg

    Public Sub ShowMsg(msg As String, title As String)
        Me.Text = "HF Desktop - " & title
        TextBox1.Text = msg
        Me.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class