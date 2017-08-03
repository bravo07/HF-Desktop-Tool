Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class Main
    Dim apiKey As String
    Dim nWbx As New WebClient

    Dim nMsg As New Msg

    '--- We need to keep track of everything so we'll know if a number has gone up or down ---'
    Dim currentPmCount As Integer = -1
    Dim currentReputation As Integer

    '--- We're not sending 2 requests to check if the key works and the same request again ---'
    '--- to prevent the api from throwing us a 403 error. ---'
    Public firstResponse As JObject

    '--- We're going to put try/catch/end try on everything till all the kinks get worked out. ---'

    Public Function CheckKey(key As String) As Boolean 
        '--- Give a global variable the apiKey incase it needs to be called again. ---'
        apiKey = key
        Dim result As Boolean = False
        Try
            '--- Just test if the apiKey is valid by making a request. ---'
            Dim json As JObject = JObject.Parse(MakeRequest("https://hackforums.net/api/v1/user", True))
            If json.SelectToken("success") = "True" Then
                firstResponse = json
                Return True
            End If
        Catch ex As Exception
            nMsg.Msg(ex.Message, "Error!", True)
        End Try
        Return result
    End Function

    Public Sub FirstLoad(json As JObject)
        Try
            '--- Get Username, Usergroup, Avatar, Post count, and Reputation. ---'
            Dim username As String = json.SelectToken("result").SelectToken("username").ToString
            Dim usergroupID As String = json.SelectToken("result").SelectToken("displaygroup").ToString
            If usergroupID = "28" Then
                '--- UB3R Group ---'
                lblUsername.ForeColor = Color.FromArgb(0, 170, 255)
            ElseIf usergroupID = "9" Then
                '--- L33t Group ---'
                lblUsername.ForeColor = Color.FromArgb(153, 255, 0)
            ElseIf usergroupID = "3" Then
                '--- Staff Usergroup ---'
                lblUsername.ForeColor = Color.FromArgb(153, 153, 255)
            ElseIf usergroupID = "4" Then
                '--- Mr.Omni, You'll never use this but still... :) ---'
                lblUsername.ForeColor = Color.FromArgb(255, 102, 255)
            End If
            Me.Text = "HF Desktop Tool - " & username
            Dim userAvatar As String = json.SelectToken("result").SelectToken("avatar").ToString
            Dim userPostCount As String = json.SelectToken("result").SelectToken("postnum").ToString
            Dim userReputation As String = json.SelectToken("result").SelectToken("reputation").ToString
            '--- Set Username, Usergroup, Avatar, Post count, and Reputation. ---'
            lblUsername.Text = username
            lblPostCount.Text = "Post Count : " & userPostCount
            lblRep.Text = "Reputation : " & userReputation
            currentReputation = Convert.ToInt32(userReputation)
            Dim imgBytes() As Byte = MakeRequest(userAvatar, False)
            Dim imgStream As New MemoryStream(imgBytes)
            imgAvatar.Image = New Bitmap(imgStream)
            '--- We'll need to use the API to get the URL of the image of the user's display ---'
            '--- group, we'll also need to make another request to download the image itself. ---'
            GetUserGroup(usergroupID)
            CheckProfile.Start()
        Catch ex As Exception
            nMsg.Msg(ex.Message, "Error!", True)
        End Try
    End Sub

    Public Sub GetUserGroup(groupID As String)
        Try
            '--- Since only our usergroup ID is given in /user we'll need to make another call to /group ---'
            '--- with the user's group ID to retrieve the URL of the image of the user bar of the group ---'
            Dim groupResponse As String = MakeRequest("https://hackforums.net/api/v1/group/9", True)
            Dim groupJSON As JObject = JObject.Parse(groupResponse)
            '--- Then we'll need to make a request to download the image from HF, notice the "str" argument is false since we're expecting an image"
            Dim imgBytes() As Byte = MakeRequest("https://hackforums.net/" & groupJSON.SelectToken("result").SelectToken("userbar").ToString, False)
            Dim imgStream As New MemoryStream(imgBytes)
            imgGroup.Image = New Bitmap(imgStream)
        Catch ex As Exception
            nMsg.Msg(ex.Message, "Error!", True)
        End Try
    End Sub

    Public Function MakeRequest(URL As String, str As Boolean)
        '--- Each time nWbx (the webclient) is used it's headers are cleared so each time ---'
        '--- we make a request we'll need to set our credentials and our user agent. ---'   
        nWbx.Credentials = New NetworkCredential(apiKey, "")
        nWbx.Headers.Add("user-agent", "Mozilla/5.0 (Windows; U; Windows NT 6.1; rv:2.2) Gecko/20110201")
        Try
            '--- This is just so we can use this function to download string and other data (images) ---'
            If str Then
                Return (nWbx.DownloadString(URL))
            Else
                Return (nWbx.DownloadData(URL))
            End If
        Catch ex As Exception
            nMsg.Msg(ex.Message, "Error!", True)
        End Try
    End Function

    Private Sub lblRep_TextChanged(sender As Object, e As EventArgs) Handles lblRep.TextChanged
        '--- This just sets the label's color to the appropriate depending on the user's rep ---'
        '--- Lime green for positive, red for negative, and plain white for no rep. ---'
        Dim rep As Integer = Convert.ToInt32(lblRep.Text.Replace("Reputation : ", ""))
        If rep > 0 Then
            lblRep.ForeColor = Color.Lime
        ElseIf rep < 0 Then
            lblRep.ForeColor = Color.Red
        ElseIf rep = 0 Then
            lblRep.ForeColor = Color.White
        End If
    End Sub

    Private Sub CheckProfile_Tick(sender As Object, e As EventArgs) Handles CheckProfile.Tick
        Try
            '--- This timer will fire every 10 seconds, which means it is making 2 requests ---'
            '--- to the API every 10 seconds which amounts to about 720 API calls an hour! ---'

            '--- We only want to get your reputation and pm count but since you can get your ---'
            '--- post count, reputation, and username in the same call we'll update those as well ---'

            Dim userInfo As JObject = JObject.Parse(MakeRequest("https://hackforums.net/api/v1/user", True))

            '--- We're putting everything we want to update into it's own variable just because ---'
            '--- I want my code to be at least some what readable lol ---'
            Dim username As String = userInfo.SelectToken("result").SelectToken("username").ToString
            Dim userPostCount As String = userInfo.SelectToken("result").SelectToken("postnum").ToString
            Dim userReputation As String = userInfo.SelectToken("result").SelectToken("reputation").ToString


            '--- Now we'll put all the values above into their labels ---'
            lblUsername.Text = username
            lblPostCount.Text = "Post Count : " & userPostCount
            lblRep.Text = "Reputation : " & userReputation

            '--- Now we'll check if the users's reputation has gone up ---'
            If Convert.ToInt32(userReputation) > currentReputation Then
                '--- We'll send a notification to the user informing them of how much their rep has gone up by. ---'
                NotifyUser(String.Format("You've gained +{0} rep!", userReputation - currentReputation), "HF - Reputation")
            End If

            '--- Update the new  Reputation Values ---'
            currentReputation = userReputation

            CheckPMs()
        Catch ex As Exception
            nMsg.Msg(ex.Message, "Error!", True)
        End Try
    End Sub

    Dim nPM As New WebClient
    Public Sub CheckPMs()
        Try
            '--- We're going to make a new web client to check the PMs ---'
            nPM.Credentials = New NetworkCredential(apiKey, "")
            nPM.Headers.Add("user-agent", "Mozilla/5.0 (Windows; U; Windows NT 6.1; rv:2.2) Gecko/20110201")
            Dim pmInfo As JObject = JObject.Parse(nPM.DownloadString("https://hackforums.net/api/v1/pmbox"))
            Dim pmCount As String = pmInfo.SelectToken("result").SelectToken("pageInfo").SelectToken("total").ToString
            lblPmCount.Text = "PM Count : " & pmCount

            If Not currentPmCount = -1 Then
                If Convert.ToInt32(pmCount) > currentPmCount Then
                    '--- We'll send a notification to the user informing them that they've recieved a new PM ---'
                    NotifyUser("You've got a new PM!", "HF - Private Message")
                End If
            End If

            currentPmCount = pmCount
        Catch ex As Exception
            '--- Normally we would also show the error but there's been some unexpected behavior ---'
            '--- that needs to get worked out. So if the code encouters an issue here it will just ---'
            '--- skip it and it should run normally when the timer fires again. ---'
            'nMsg.Msg(ex.Message, "Error!", True)
        End Try
    End Sub

    Public Sub NotifyUser(message As String, title As String)
        Notifications.BalloonTipTitle = title
        Notifications.BalloonTipText = message
        Notifications.ShowBalloonTip(5000)
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub 

    Private Sub VelocityButton1_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        If cbSaveAPI.Checked Then
            My.Settings.apiKey = apiKey
            My.Settings.Save()
        Else
            My.Settings.apiKey = ""
            My.Settings.Save()
        End If
    End Sub

    Private Sub SlickBlueTabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SlickBlueTabControl1.SelectedIndexChanged
        If SlickBlueTabControl1.SelectedIndex = 1 Then
            If My.Settings.apiKey = "" Then
                cbSaveAPI.Checked = False
            Else
                cbSaveAPI.Checked = True
            End If
        End If
    End Sub

    Private Sub Notifications_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Notifications.MouseDoubleClick
        Me.Show()
    End Sub  

    Private Sub VelocityButton1_Click_1(sender As Object, e As EventArgs) Handles VelocityButton1.Click
        Me.Show()
        Environment.Exit(0)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Me.Show()
        Environment.Exit(0)
    End Sub
End Class