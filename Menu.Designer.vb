<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Menu1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.HomeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RoomManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RoomClassManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FloorManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DayVacationManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.AzureHotel.My.Resources.Resources.hotel
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(0, 23)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(665, 230)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'HomeToolStripMenuItem
        '
        Me.HomeToolStripMenuItem.Name = "HomeToolStripMenuItem"
        Me.HomeToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.HomeToolStripMenuItem.Text = "Home"
        '
        'RoomManagementToolStripMenuItem
        '
        Me.RoomManagementToolStripMenuItem.Name = "RoomManagementToolStripMenuItem"
        Me.RoomManagementToolStripMenuItem.Size = New System.Drawing.Size(125, 20)
        Me.RoomManagementToolStripMenuItem.Text = "Room Management"
        '
        'RoomClassManagementToolStripMenuItem
        '
        Me.RoomClassManagementToolStripMenuItem.Name = "RoomClassManagementToolStripMenuItem"
        Me.RoomClassManagementToolStripMenuItem.Size = New System.Drawing.Size(155, 20)
        Me.RoomClassManagementToolStripMenuItem.Text = "Room Class Management"
        '
        'FloorManagementToolStripMenuItem
        '
        Me.FloorManagementToolStripMenuItem.Name = "FloorManagementToolStripMenuItem"
        Me.FloorManagementToolStripMenuItem.Size = New System.Drawing.Size(120, 20)
        Me.FloorManagementToolStripMenuItem.Text = "Floor Management"
        '
        'DayVacationManagementToolStripMenuItem
        '
        Me.DayVacationManagementToolStripMenuItem.Name = "DayVacationManagementToolStripMenuItem"
        Me.DayVacationManagementToolStripMenuItem.Size = New System.Drawing.Size(161, 20)
        Me.DayVacationManagementToolStripMenuItem.Text = "Day Vacation Management"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HomeToolStripMenuItem, Me.RoomManagementToolStripMenuItem, Me.RoomClassManagementToolStripMenuItem, Me.FloorManagementToolStripMenuItem, Me.DayVacationManagementToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(665, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.AzureHotel.My.Resources.Resources.azurehotel3_9
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Location = New System.Drawing.Point(0, 143)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(286, 110)
        Me.Panel1.TabIndex = 3
        '
        'Menu1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 253)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Menu1"
        Me.Text = "Menu"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents HomeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RoomManagementToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RoomClassManagementToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FloorManagementToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DayVacationManagementToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents Panel1 As Panel
End Class
