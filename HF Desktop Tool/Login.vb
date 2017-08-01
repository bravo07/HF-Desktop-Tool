Public Class Login

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Main.apiKey = TextBox1.Text
        If Main.CheckKey() Then
            Main.Show()
            Me.Close()
        Else
            Label2.Visible = True
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.apiKey IsNot "" Then
            TextBox1.Text = My.Settings.apiKey
        End If
    End Sub
End Class