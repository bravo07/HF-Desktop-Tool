﻿Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq
Imports System.ComponentModel

Public Class Main
    Dim apiKey As String
    Dim nWbx As New WebClient

    Dim nMsg As New Msg

    Dim userExit As Boolean = False

    Dim currentReputation As Integer
    Dim currentUnreadPMs As Integer = 0
    Public firstResponse As JObject

    Public Function SecondsToDays(sec As Integer) As Integer
        Return sec / 86400
    End Function

    Public Function CheckKey(key As String) As Boolean
        apiKey = key
        Dim result As Boolean = False
        Try
            Dim json As JObject = JObject.Parse(MakeRequest("https://hackforums.net/api/v1/user/?include=header", True))
            If json.SelectToken("success") = "True" Then
                firstResponse = json
                Return True
            End If
        Catch ex As Exception
            nMsg.Msg(ex.Message & vbNewLine & vbNewLine & "Please report this error by clicking this link." & vbNewLine & "https://hackforums.net/private.php?action=send&uid=2307853&subject=ERROR&message=Error+code+%3A+%23" & "001", "Error!", True)
        End Try
        Return result
    End Function

    Public Sub FirstLoad(json As JObject)
        Try
            Dim username As String = json.SelectToken("result").SelectToken("username")
            Dim usergroupID As String = json.SelectToken("result").SelectToken("usergroup").ToString
            Dim userAge As String = json.SelectToken("result").SelectToken("timeonline").ToString
            Dim userAvatar As String = json.SelectToken("result").SelectToken("avatar").ToString
            Dim userPostCount As String = json.SelectToken("result").SelectToken("postnum").ToString
            Dim userReputation As String = json.SelectToken("result").SelectToken("reputation").ToString

            If usergroupID = "28" Then
                lblUsername.ForeColor = Color.FromArgb(0, 170, 255)
            ElseIf usergroupID = "9" Then
                lblUsername.ForeColor = Color.FromArgb(153, 255, 0)
            ElseIf usergroupID = "3" Then
                lblUsername.ForeColor = Color.FromArgb(153, 153, 255)
            ElseIf usergroupID = "4" Then
                lblUsername.ForeColor = Color.FromArgb(255, 102, 255)
            End If

            Me.Text = "HF Desktop Tool - " & username
            lblUsername.Text = username
            lblPostCount.Text = "Post Count : " & userPostCount
            lblRep.Text = "Reputation : " & userReputation
            lblAge.Text = Math.Floor(SecondsToDays(Convert.ToInt32(userAge))).ToString & " Days Old"
            currentReputation = Convert.ToInt32(userReputation)

            If Not userAvatar = "" Then
                If userAvatar.StartsWith(".") Then
                    userAvatar = "https://hackforums.net/" & userAvatar
                End If
                Dim imgBytes() As Byte = MakeRequest(userAvatar, False)
                Dim imgStream As New MemoryStream(imgBytes)
                imgAvatar.Image = New Bitmap(imgStream)
                imgAvatar.SizeMode = PictureBoxSizeMode.CenterImage
            End If

            GetUserGroup(usergroupID)

            CheckProfile.Start()
        Catch ex As Exception
            nMsg.Msg(ex.Message & vbNewLine & vbNewLine & "Please report this error by clicking this link." & vbNewLine & "https://hackforums.net/private.php?action=send&uid=2307853&subject=ERROR&message=Error+code+%3A+%23" & "002", "Error!", True)
        End Try
    End Sub

    Public Sub GetUserGroup(groupID As String)
        Try
            Dim groupResponse As String = MakeRequest("https://hackforums.net/api/v1/group/" & groupID, True)
            Dim groupJSON As JObject = JObject.Parse(groupResponse)
            Dim userbarURL As String = groupJSON.SelectToken("result").SelectToken("userbar").ToString
            If Not userbarURL = "" Then
                Dim imgBytes() As Byte = MakeRequest("https://hackforums.net/" & userbarURL, False)
                Dim imgStream As New MemoryStream(imgBytes)
                imgGroup.Image = New Bitmap(imgStream)
            End If
        Catch ex As Exception
            nMsg.Msg(ex.Message & vbNewLine & vbNewLine & vbNewLine & "Please report this error by clicking this link." & vbNewLine & "https://hackforums.net/private.php?action=send&uid=2307853&subject=ERROR&message=Error+code+%3A+%23" & "003", "Error!", True)
        End Try
    End Sub

    Public Function MakeRequest(URL As String, str As Boolean)
        nWbx.Credentials = New NetworkCredential(apiKey, "")
        nWbx.Headers.Add("user-agent", "Mozilla/5.0 (Windows; U; Windows NT 6.1; rv:2.2) Gecko/20110201")
        Try
            If str Then
                Return (nWbx.DownloadString(URL))
            Else
                Return (nWbx.DownloadData(URL))
            End If
        Catch ex As Exception
            nMsg.Msg(ex.Message & vbNewLine & vbNewLine & "Please report this error by clicking this link." & vbNewLine & "https://hackforums.net/private.php?action=send&uid=2307853&subject=ERROR&message=Error+code+%3A+%23" & "004", "Error!", True)
        End Try
    End Function

    Private Sub lblRep_TextChanged(sender As Object, e As EventArgs) Handles lblRep.TextChanged
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
            Dim userInfo As JObject = JObject.Parse(MakeRequest("https://hackforums.net/api/v1/user?include=header", True))

            Dim username As String = userInfo.SelectToken("result").SelectToken("username")
            Dim userAge As String = userInfo.SelectToken("result").SelectToken("timeonline").ToString
            Dim userPostCount As String = userInfo.SelectToken("result").SelectToken("postnum").ToString
            Dim userReputation As String = userInfo.SelectToken("result").SelectToken("reputation").ToString
            Dim unreadPmCount As String = userInfo.SelectToken("header").SelectToken("unreadpms").ToString

            lblUsername.Text = username
            lblAge.Text = Math.Floor(SecondsToDays(Convert.ToInt32(userAge))).ToString & " Days Old"
            lblPostCount.Text = "Post Count : " & userPostCount
            lblRep.Text = "Reputation : " & userReputation

            If Convert.ToInt32(userReputation) > currentReputation Then
                NotifyUser(String.Format("You've gained +{0} rep!", userReputation - currentReputation), "HF - Reputation")
            End If

            If Convert.ToInt32(unreadPmCount) > currentUnreadPMs Then
                NotifyUser(String.Format("You have {0} unread PMs!", unreadPmCount.ToString), "New PM!")
            End If

            If unreadPmCount > 0 Then
                lblPmAlert.Visible = True
                Notifications.Icon = My.Resources.hf_pm
                Me.Icon = My.Resources.hf_pm
            Else
                lblPmAlert.Visible = False
                Notifications.Icon = My.Resources.hficon
                Me.Icon = My.Resources.hficon
            End If

            currentReputation = userReputation
            currentUnreadPMs = unreadPmCount
        Catch ex As Exception
            nMsg.Msg(ex.Message & vbNewLine & vbNewLine & "Please report this error by clicking this link." & vbNewLine & "https://hackforums.net/private.php?action=send&uid=2307853&subject=ERROR&message=Error+code+%3A+%23" & "005", "Error!", True)
        End Try
    End Sub

    Public Sub NotifyUser(message As String, title As String)
        Notifications.BalloonTipTitle = title
        Notifications.BalloonTipText = message
        Notifications.ShowBalloonTip(5000)
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If userExit Then
            e.Cancel = False
        Else
            e.Cancel = True
            Me.Hide()
        End If
    End Sub

    Private Sub VelocityButton1_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        Try

            If comboRefresh.SelectedIndex = 0 Then
                '30 seconds in milliseconds.
                My.Settings.refreshRate = 30000
            ElseIf comboRefresh.SelectedIndex = 1 Then
                '1 minute in milliseconds.
                My.Settings.refreshRate = 60000
            ElseIf comboRefresh.SelectedIndex = 2 Then
                '2 minute in milliseconds.
                My.Settings.refreshRate = 120000
            ElseIf comboRefresh.SelectedIndex = 3 Then
                '3 minute in milliseconds.
                My.Settings.refreshRate = 180000
            ElseIf comboRefresh.SelectedIndex = 4 Then
                '5 minute in milliseconds.
                My.Settings.refreshRate = 300000
            End If

            UpdateTimer()

            If cbSaveAPI.Checked Then
                My.Settings.apiKey = apiKey
                My.Settings.Save()
            Else
                My.Settings.apiKey = ""
                My.Settings.Save()
            End If

            My.Settings.Save()

            nMsg.Msg("Your settings have been successfully saved.", "Settings Saved.", False)

        Catch ex As Exception
            nMsg.Msg(ex.Message & vbNewLine & vbNewLine & "Please report this error by clicking this link." & vbNewLine & "https://hackforums.net/private.php?action=send&uid=2307853&subject=ERROR&message=Error+code+%3A+%23" & "006", "Error!", True)
        End Try
    End Sub

    Public Sub UpdateTimer()
        CheckProfile.Interval = My.Settings.refreshRate
    End Sub

    Private Sub SlickBlueTabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SlickBlueTabControl1.SelectedIndexChanged
        If My.Settings.refreshRate = 30000 Then
            comboRefresh.SelectedIndex = 0
        ElseIf My.Settings.refreshRate = 60000 Then
            comboRefresh.SelectedIndex = 1
        ElseIf My.Settings.refreshRate = 120000 Then
            comboRefresh.SelectedIndex = 2
        ElseIf My.Settings.refreshRate = 180000 Then
            comboRefresh.SelectedIndex = 3
        ElseIf My.Settings.refreshRate = 300000 Then
            comboRefresh.SelectedIndex = 4
        End If

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
        Application.Restart()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        userExit = True
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblPmAlert.Click
        Process.Start("https://hackforums.net/private.php")
    End Sub   

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateTimer()
    End Sub

    Private Sub RichTextBox1_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles RichTextBox1.LinkClicked
        Process.Start(e.LinkText)
    End Sub 
End Class