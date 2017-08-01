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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.SlickBlueTabControl1 = New HF_Desktop_Tool.SlickBlueTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtPmCount = New System.Windows.Forms.Label()
        Me.txtRep = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPostCount = New System.Windows.Forms.Label()
        Me.imgGroup = New System.Windows.Forms.PictureBox()
        Me.txtUsername = New System.Windows.Forms.Label()
        Me.imgAvatar = New System.Windows.Forms.PictureBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SlickBlueTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.imgGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgAvatar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 30000
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipText = "wetewt"
        Me.NotifyIcon1.BalloonTipTitle = "wetet"
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "HF Desktop Tool"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripSeparator1, Me.ToolStripMenuItem2})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(104, 54)
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
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 32000
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
        Me.SlickBlueTabControl1.Size = New System.Drawing.Size(431, 174)
        Me.SlickBlueTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.SlickBlueTabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.txtPmCount)
        Me.TabPage1.Controls.Add(Me.txtRep)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtPostCount)
        Me.TabPage1.Controls.Add(Me.imgGroup)
        Me.TabPage1.Controls.Add(Me.txtUsername)
        Me.TabPage1.Controls.Add(Me.imgAvatar)
        Me.TabPage1.Location = New System.Drawing.Point(134, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(293, 166)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Main"
        '
        'txtPmCount
        '
        Me.txtPmCount.AutoSize = True
        Me.txtPmCount.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.txtPmCount.ForeColor = System.Drawing.Color.White
        Me.txtPmCount.Location = New System.Drawing.Point(150, 101)
        Me.txtPmCount.Name = "txtPmCount"
        Me.txtPmCount.Size = New System.Drawing.Size(77, 14)
        Me.txtPmCount.TabIndex = 6
        Me.txtPmCount.Text = "PM Count :"
        '
        'txtRep
        '
        Me.txtRep.AutoSize = True
        Me.txtRep.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.txtRep.ForeColor = System.Drawing.Color.White
        Me.txtRep.Location = New System.Drawing.Point(192, 138)
        Me.txtRep.Name = "txtRep"
        Me.txtRep.Size = New System.Drawing.Size(14, 14)
        Me.txtRep.TabIndex = 3
        Me.txtRep.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(150, 138)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 14)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Rep : "
        '
        'txtPostCount
        '
        Me.txtPostCount.AutoSize = True
        Me.txtPostCount.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.txtPostCount.ForeColor = System.Drawing.Color.White
        Me.txtPostCount.Location = New System.Drawing.Point(150, 120)
        Me.txtPostCount.Name = "txtPostCount"
        Me.txtPostCount.Size = New System.Drawing.Size(98, 14)
        Me.txtPostCount.TabIndex = 4
        Me.txtPostCount.Text = "Post Count : "
        '
        'imgGroup
        '
        Me.imgGroup.Location = New System.Drawing.Point(149, 51)
        Me.imgGroup.Name = "imgGroup"
        Me.imgGroup.Size = New System.Drawing.Size(136, 42)
        Me.imgGroup.TabIndex = 2
        Me.imgGroup.TabStop = False
        '
        'txtUsername
        '
        Me.txtUsername.AutoSize = True
        Me.txtUsername.Font = New System.Drawing.Font("Consolas", 13.0!)
        Me.txtUsername.ForeColor = System.Drawing.Color.White
        Me.txtUsername.Location = New System.Drawing.Point(149, 25)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(90, 22)
        Me.txtUsername.TabIndex = 1
        Me.txtUsername.Text = "USERNAME"
        '
        'imgAvatar
        '
        Me.imgAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgAvatar.Location = New System.Drawing.Point(7, 8)
        Me.imgAvatar.Name = "imgAvatar"
        Me.imgAvatar.Size = New System.Drawing.Size(136, 150)
        Me.imgAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgAvatar.TabIndex = 0
        Me.imgAvatar.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.CheckBox5)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.CheckBox4)
        Me.TabPage2.Controls.Add(Me.CheckBox3)
        Me.TabPage2.Controls.Add(Me.CheckBox1)
        Me.TabPage2.Location = New System.Drawing.Point(134, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(293, 166)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Settings"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.Button1.Location = New System.Drawing.Point(187, 135)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(98, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Save Settings"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Checked = True
        Me.CheckBox5.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox5.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox5.ForeColor = System.Drawing.Color.White
        Me.CheckBox5.Location = New System.Drawing.Point(151, 11)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(62, 17)
        Me.CheckBox5.TabIndex = 5
        Me.CheckBox5.Text = "New PM"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 7.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(9, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(255, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "*Note : Your key is saved locally only on your pc."
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox4.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox4.ForeColor = System.Drawing.Color.White
        Me.CheckBox4.Location = New System.Drawing.Point(11, 78)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(98, 17)
        Me.CheckBox4.TabIndex = 3
        Me.CheckBox4.Text = "Save API Key"
        Me.CheckBox4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox3.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox3.ForeColor = System.Drawing.Color.White
        Me.CheckBox3.Location = New System.Drawing.Point(11, 34)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(134, 17)
        Me.CheckBox3.TabIndex = 2
        Me.CheckBox3.Text = "Added Negative Rep"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(11, 11)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(134, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Added Positive Rep"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 174)
        Me.Controls.Add(Me.SlickBlueTabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.Text = "Main"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.SlickBlueTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.imgGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgAvatar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SlickBlueTabControl1 As SlickBlueTabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents txtUsername As Label
    Friend WithEvents imgAvatar As PictureBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txtPostCount As Label
    Friend WithEvents txtRep As Label
    Friend WithEvents imgGroup As PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents txtPmCount As System.Windows.Forms.Label
End Class
