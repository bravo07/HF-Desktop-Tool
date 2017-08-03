Public Class Login

    Private Sub VelocityButton1_Click(sender As Object, e As EventArgs) Handles VelocityButton1.Click
        If Main.CheckKey(TextBox1.Text) Then
            Main.Show()
            Me.Close()
            Main.FirstLoad(Main.firstResponse)
        Else
            Label2.Visible = True
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.apiKey
    End Sub
End Class