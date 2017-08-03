Public Class Msg 

    Public Sub Msg(message As String, title As String, msgError As Boolean)
        lblTitle.Text = title.ToString
        If msgError Then
            txtMessage.Text = "An unexpected error has occurred." & vbNewLine & vbNewLine & message
        Else
            txtMessage.Text = message
        End If
        Me.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class