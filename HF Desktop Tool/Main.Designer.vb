<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.IconMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Notifications = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.CheckProfile = New System.Windows.Forms.Timer(Me.components)
        Me.lblPmAlert = New System.Windows.Forms.Label()
        Me.SlickBlueTabControl1 = New HF_Desktop_Tool.SlickBlueTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblRep = New System.Windows.Forms.Label()
        Me.lblPostCount = New System.Windows.Forms.Label()
        Me.imgGroup = New System.Windows.Forms.PictureBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.imgAvatar = New System.Windows.Forms.PictureBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.VelocityButton1 = New HF_Desktop_Tool.VelocityButton()
        Me.btnSaveSettings = New HF_Desktop_Tool.VelocityButton()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.cbSaveAPI = New System.Windows.Forms.CheckBox()
        Me.IconMenu.SuspendLayout()
        Me.SlickBlueTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.imgGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgAvatar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'IconMenu
        '
        Me.IconMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripSeparator1, Me.ToolStripMenuItem2})
        Me.IconMenu.Name = "IconMenu"
        Me.IconMenu.Size = New System.Drawing.Size(104, 54)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(103, 22)
        Me.ToolStripMenuItem1.Text = "Show"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(100, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(103, 22)
        Me.ToolStripMenuItem2.Text = "Exit"
        '
        'Notifications
        '
        Me.Notifications.ContextMenuStrip = Me.IconMenu
        Me.Notifications.Icon = CType(resources.GetObject("Notifications.Icon"), System.Drawing.Icon)
        Me.Notifications.Text = "Notifications"
        Me.Notifications.Visible = True
        '
        'CheckProfile
        '
        Me.CheckProfile.Interval = 20000
        '
        'lblPmAlert
        '
        Me.lblPmAlert.AutoSize = True
        Me.lblPmAlert.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblPmAlert.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblPmAlert.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.lblPmAlert.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblPmAlert.Location = New System.Drawing.Point(30, 173)
        Me.lblPmAlert.Name = "lblPmAlert"
        Me.lblPmAlert.Size = New System.Drawing.Size(73, 26)
        Me.lblPmAlert.TabIndex = 2
        Me.lblPmAlert.Text = "You have" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "unread PMs!"
        Me.lblPmAlert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPmAlert.Visible = False
        '
        'SlickBlueTabControl1
        '
        Me.SlickBlueTabControl1.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.SlickBlueTabControl1.Controls.Add(Me.TabPage1)
        Me.SlickBlueTabControl1.Controls.Add(Me.TabPage2)
        Me.SlickBlueTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SlickBlueTabControl1.Font = New System.Drawing.Font("Segoe UI Semilight", 9.0!)
        Me.SlickBlueTabControl1.ItemSize = New System.Drawing.Size(40, 130)
        Me.SlickBlueTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.SlickBlueTabControl1.Multiline = True
        Me.SlickBlueTabControl1.Name = "SlickBlueTabControl1"
        Me.SlickBlueTabControl1.SelectedIndex = 0
        Me.SlickBlueTabControl1.Size = New System.Drawing.Size(502, 212)
        Me.SlickBlueTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.SlickBlueTabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.TabPage1.BackgroundImage = Global.HF_Desktop_Tool.My.Resources.Resources.mosaic_bl_1_
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(134, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(16)
        Me.TabPage1.Size = New System.Drawing.Size(364, 204)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Main"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblAge)
        Me.Panel1.Controls.Add(Me.lblRep)
        Me.Panel1.Controls.Add(Me.lblPostCount)
        Me.Panel1.Controls.Add(Me.imgGroup)
        Me.Panel1.Controls.Add(Me.lblUsername)
        Me.Panel1.Controls.Add(Me.imgAvatar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(16, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(332, 172)
        Me.Panel1.TabIndex = 1
        '
        'lblAge
        '
        Me.lblAge.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.lblAge.ForeColor = System.Drawing.Color.White
        Me.lblAge.Location = New System.Drawing.Point(168, 88)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(136, 23)
        Me.lblAge.TabIndex = 7
        Me.lblAge.Text = "0 Days Old"
        Me.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRep
        '
        Me.lblRep.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.lblRep.ForeColor = System.Drawing.Color.White
        Me.lblRep.Location = New System.Drawing.Point(168, 136)
        Me.lblRep.Name = "lblRep"
        Me.lblRep.Size = New System.Drawing.Size(136, 23)
        Me.lblRep.TabIndex = 6
        Me.lblRep.Text = "Reputation : 0"
        Me.lblRep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPostCount
        '
        Me.lblPostCount.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.lblPostCount.ForeColor = System.Drawing.Color.White
        Me.lblPostCount.Location = New System.Drawing.Point(168, 113)
        Me.lblPostCount.Name = "lblPostCount"
        Me.lblPostCount.Size = New System.Drawing.Size(136, 23)
        Me.lblPostCount.TabIndex = 5
        Me.lblPostCount.Text = "Post Count : 0"
        Me.lblPostCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'imgGroup
        '
        Me.imgGroup.Location = New System.Drawing.Point(168, 39)
        Me.imgGroup.Name = "imgGroup"
        Me.imgGroup.Size = New System.Drawing.Size(136, 42)
        Me.imgGroup.TabIndex = 3
        Me.imgGroup.TabStop = False
        '
        'lblUsername
        '
        Me.lblUsername.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lblUsername.ForeColor = System.Drawing.Color.White
        Me.lblUsername.Location = New System.Drawing.Point(154, 14)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(164, 20)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "Username"
        Me.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'imgAvatar
        '
        Me.imgAvatar.Location = New System.Drawing.Point(10, 11)
        Me.imgAvatar.Name = "imgAvatar"
        Me.imgAvatar.Size = New System.Drawing.Size(136, 150)
        Me.imgAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgAvatar.TabIndex = 0
        Me.imgAvatar.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.TabPage2.BackgroundImage = Global.HF_Desktop_Tool.My.Resources.Resources.mosaic_bl_1_
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Location = New System.Drawing.Point(134, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(16)
        Me.TabPage2.Size = New System.Drawing.Size(364, 204)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Settings"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.VelocityButton1)
        Me.Panel2.Controls.Add(Me.btnSaveSettings)
        Me.Panel2.Controls.Add(Me.RichTextBox1)
        Me.Panel2.Controls.Add(Me.cbSaveAPI)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(16, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(332, 172)
        Me.Panel2.TabIndex = 1
        '
        'VelocityButton1
        '
        Me.VelocityButton1.Font = New System.Drawing.Font("Segoe UI Semilight", 9.0!)
        Me.VelocityButton1.ForeColor = System.Drawing.Color.White
        Me.VelocityButton1.Location = New System.Drawing.Point(168, 138)
        Me.VelocityButton1.Name = "VelocityButton1"
        Me.VelocityButton1.Size = New System.Drawing.Size(80, 24)
        Me.VelocityButton1.TabIndex = 4
        Me.VelocityButton1.Text = "Restart App"
        Me.VelocityButton1.TextAlign = HF_Desktop_Tool.Helpers.TxtAlign.Center
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.Font = New System.Drawing.Font("Segoe UI Semilight", 9.0!)
        Me.btnSaveSettings.ForeColor = System.Drawing.Color.White
        Me.btnSaveSettings.Location = New System.Drawing.Point(254, 138)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(67, 24)
        Me.btnSaveSettings.TabIndex = 3
        Me.btnSaveSettings.Text = "Save"
        Me.btnSaveSettings.TextAlign = HF_Desktop_Tool.Helpers.TxtAlign.Center
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.RichTextBox1.Location = New System.Drawing.Point(10, 12)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(311, 86)
        Me.RichTextBox1.TabIndex = 2
        Me.RichTextBox1.Text = "HF Desktop Tool - v1.2.2" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & "https://hackforums.net/showthread.php?tid=5683517" & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(10) & "The" & _
    "res only 1 setting lol :3"
        '
        'cbSaveAPI
        '
        Me.cbSaveAPI.AutoSize = True
        Me.cbSaveAPI.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.cbSaveAPI.ForeColor = System.Drawing.Color.White
        Me.cbSaveAPI.Location = New System.Drawing.Point(10, 144)
        Me.cbSaveAPI.Name = "cbSaveAPI"
        Me.cbSaveAPI.Size = New System.Drawing.Size(104, 17)
        Me.cbSaveAPI.TabIndex = 1
        Me.cbSaveAPI.Text = "Save API Key."
        Me.cbSaveAPI.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 212)
        Me.Controls.Add(Me.lblPmAlert)
        Me.Controls.Add(Me.SlickBlueTabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.Text = "Main"
        Me.IconMenu.ResumeLayout(False)
        Me.SlickBlueTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.imgGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgAvatar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SlickBlueTabControl1 As SlickBlueTabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblRep As System.Windows.Forms.Label
    Friend WithEvents lblPostCount As System.Windows.Forms.Label
    Friend WithEvents imgGroup As System.Windows.Forms.PictureBox
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents imgAvatar As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnSaveSettings As HF_Desktop_Tool.VelocityButton
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents cbSaveAPI As System.Windows.Forms.CheckBox
    Friend WithEvents IconMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Notifications As System.Windows.Forms.NotifyIcon
    Friend WithEvents CheckProfile As System.Windows.Forms.Timer
    Friend WithEvents VelocityButton1 As HF_Desktop_Tool.VelocityButton
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblPmAlert As System.Windows.Forms.Label
End Class
