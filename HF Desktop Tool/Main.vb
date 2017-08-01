Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class Main
    Public apiKey As String

    Dim firstResponse As String
    Dim currentPMCount As Integer
    Dim curRepCount As Integer


    Public Function MakeRequest(key As String, apiURL As String) As String
        Try
            Dim apiRequest As New WebClient
            apiRequest.Credentials = New NetworkCredential(apiKey, "")
            apiRequest.Headers.Add("user-agent", "Mozilla/5.0 (Windows; U; Windows NT 6.1; rv:2.2) Gecko/20110201")
            apiRequest.Dispose()
            Return apiRequest.DownloadString(apiURL)
        Catch ex As Exception
            ErrorMsg.ShowError(ex.Message.ToString)
        End Try
    End Function

    Public Function CheckKey() As Boolean
        Try
            Dim valid As Boolean = False
            Dim nWbx As WebClient = New WebClient
            nWbx.Credentials = New NetworkCredential(apiKey, "")
            nWbx.Headers.Add("user-agent", "Mozilla/5.0 (Windows; U; Windows NT 6.1; rv:2.2) Gecko/20110201")
            Dim response As String = nWbx.DownloadString("https://hackforums.net/api/v1/user")
            firstResponse = response
            If response.Contains("{""success"":true,") Then
                valid = True
            End If
            nWbx.Dispose()
            Return valid
        Catch ex As Exception
            ErrorMsg.ShowError(ex.Message.ToString)
        End Try
    End Function

    Public Sub UpdateUserInfo(response As String)
        Try
            Dim json As JObject = JObject.Parse(response)
            txtUsername.Text = GetJSON(json, "result", "username")
            Dim avatarURL As String = GetJSON(json, "result", "avatar")
            imgAvatar.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(avatarURL)))
            txtPostCount.Text = "Post Count : " & GetJSON(json, "result", "postnum")
            curRepCount = Convert.ToInt32(GetJSON(json, "result", "reputation"))
            CheckRep(curRepCount)
            If imgGroup.Image Is Nothing Then
                Dim usergroup As String = GetJSON(JObject.Parse(MakeRequest(apiKey, "https://hackforums.net/api/v1/group/" & GetJSON(json, "result", "displaygroup"))), "result", "userbar")
                imgGroup.Image = GetUsergroup("https://hackforums.net/" & usergroup)
            End If
        Catch ex As Exception
            ErrorMsg.ShowError(ex.Message.ToString)
        End Try
    End Sub

    Public Sub CheckRep(rep As Integer)
        If Not rep = curRepCount Then
            If rep > curRepCount Then
                If My.Settings.pRep Then
                    ShowNotify(String.Format("You've been given an {0} rep! =D", "+" & rep - curRepCount), "Positive rep!")
                End If
            ElseIf rep < curRepCount Then
                If My.Settings.nRep Then
                    ShowNotify(String.Format("You've been given an {0} rep! :(", "+" & rep - curRepCount), "Negative rep!")
                End If
            End If
        End If
        txtRep.Text = curRepCount.ToString
    End Sub

    Public Function GetPMCount() As Integer
        Try
            Dim valid As Boolean = False
            Dim nWbx As WebClient = New WebClient
            nWbx.Credentials = New NetworkCredential(apiKey, "")
            nWbx.Headers.Add("user-agent", "Mozilla/5.0 (Windows; U; Windows NT 6.1; rv:2.2) Gecko/20110201")
            Dim pmString As String = nWbx.DownloadString("https://hackforums.net/api/v1/pmbox")
            Return Convert.ToInt32(JObject.Parse(pmString).SelectToken("result").SelectToken("pageInfo").SelectToken("total"))
        Catch ex As Exception
            ErrorMsg.ShowError(ex.Message.ToString)
        End Try
    End Function

    Public Sub delay(sec As Integer)
        For i As Integer = 0 To sec * 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
        Next
    End Sub

    Public Function GetUsergroup(url As String) As Image
        Try
            Dim tClient As WebClient = New WebClient
            tClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows; U; Windows NT 6.1; rv:2.2) Gecko/20110201")
            Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url)))
            Return tImage
        Catch ex As Exception
            ErrorMsg.ShowError(ex.Message.ToString)
        End Try
    End Function

    Public Function GetJSON(json As JObject, token1 As String, token2 As String) As String
        Return (json.SelectToken(token1).SelectToken(token2))
    End Function

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateUserInfo(firstResponse)
        delay(10)
        currentPMCount = GetPMCount()
        txtPmCount.Text = "PM Count : " & currentPMCount.ToString
        delay(3)
        Timer1.Start() 
    End Sub

    Private Sub txtRep_TextChanged(sender As Object, e As EventArgs) Handles txtRep.TextChanged
        If txtRep.Text = "0" Then
            txtRep.ForeColor = Color.White
        ElseIf txtRep.Text.Contains("-") Then
            txtRep.ForeColor = Color.Red
        Else
            txtRep.ForeColor = Color.Lime
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        UpdateUserInfo(MakeRequest(apiKey, "https://hackforums.net/api/v1/user"))
        delay(10)
        Dim curPM As Integer = GetPMCount()
        If Not curPM = currentPMCount Then
            If curPM > currentPMCount Then
                If My.Settings.PM Then
                    ShowNotify("New PM!", "You have recieved a new PM!")
                End If
            End If
            currentPMCount = curPM
        End If
        txtPmCount.Text = "PM Count : " & currentPMCount.ToString
    End Sub

    Public Sub ShowNotify(title As String, msg As String)
        NotifyIcon1.BalloonTipText = msg
        NotifyIcon1.Text = title
        NotifyIcon1.ShowBalloonTip(5000)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        End
    End Sub 

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked Then
            My.Settings.pRep = True
        Else
            My.Settings.pRep = False
        End If
        If CheckBox3.Checked Then
            My.Settings.nRep = True
        Else
            My.Settings.nRep = True
        End If
        If CheckBox4.Checked Then
            My.Settings.apiKey = apiKey
        Else
            My.Settings.apiKey = ""
        End If
        If CheckBox5.Checked Then
            My.Settings.PM = True
        Else
            My.Settings.PM = False
        End If
        My.Settings.Save()
        Msg.ShowMsg("Settings have been sucessfully saved!", "Settings saved")
    End Sub

    Private Sub SlickBlueTabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SlickBlueTabControl1.SelectedIndexChanged
        If SlickBlueTabControl1.SelectedIndex = 1 Then
            If My.Settings.pRep Then
                CheckBox1.Checked = True
            Else
                CheckBox1.Checked = False
            End If
            If My.Settings.nRep Then
                CheckBox3.Checked = True
            Else
                CheckBox3.Checked = True
            End If
            If Not My.Settings.apiKey = "" Then
                CheckBox4.Checked = True
            Else
                CheckBox4.Checked = True
            End If
            If My.Settings.PM Then
                CheckBox5.Checked = True
            Else
                CheckBox5.Checked = True
            End If
        End If
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
    End Sub
End Class

Public Class SlickBlueTabControl
    Inherits TabControl

    Private _mouseOverTabIndex As Integer = 0

    Sub New()
        Dock = DockStyle.Fill
        DoubleBuffered = True
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(40, 130)
        Alignment = TabAlignment.Left
        Font = New Font("Segoe UI Semilight", 9)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim b As New Bitmap(Width, Height) : Dim g As Graphics = Graphics.FromImage(b)
        g.Clear(FromHex("#2c3e50"))
        For i = 0 To TabCount - 1
            Dim tabRect As Rectangle = GetTabRect(i)
            If i = SelectedIndex Then
                If i = 0 Then
                    g.FillRectangle(New SolidBrush(FromHex("#34495e")), 0, 0, tabRect.Width + 2, tabRect.Height + 2)
                    g.FillRectangle(Brushes.DodgerBlue, 0, 0, 4, tabRect.Height + 2)
                Else
                    g.FillRectangle(New SolidBrush(FromHex("#34495e")), tabRect)
                    g.FillRectangle(Brushes.DodgerBlue, tabRect.X - 2, tabRect.Y, 4, tabRect.Height)
                End If
            ElseIf Not _mouseOverTabIndex = -1 And i = _mouseOverTabIndex Then
                If i = 0 Then
                    g.FillRectangle(New SolidBrush(FromHex("#435363")), 0, 0, tabRect.Width + 3, tabRect.Height + 2)
                Else
                    g.FillRectangle(New SolidBrush(FromHex("#435363")), 0, tabRect.Y, tabRect.Width + 3, tabRect.Height)
                End If
            Else
                g.FillRectangle(New SolidBrush(FromHex("#2c3e50")), tabRect)
            End If
            g.DrawString(TabPages(i).Text, Font, Brushes.White, New Rectangle(tabRect.X, tabRect.Y, tabRect.Width, tabRect.Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        Next
        e.Graphics.DrawImage(b.Clone, 0, 0) : g.Dispose() : b.Dispose()
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        For i As Integer = 0 To TabPages.Count - 1
            If GetTabRect(i).Contains(e.Location) Then
                _mouseOverTabIndex = i
                Exit For
            Else
                _mouseOverTabIndex = -1
            End If
        Next
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        _mouseOverTabIndex = -1 : Invalidate()
    End Sub

#Region "Helpers"
    Public Enum MouseState
        Hover = 1
        Down = 2
        None = 3
    End Enum

    Public Function FromHex(hex As String) As Color
        Return ColorTranslator.FromHtml(hex.Replace("#", "").Insert(0, "#"))
    End Function
#End Region
End Class