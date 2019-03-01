<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.查询数据ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.查询图书信息ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.查询学生信息ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.查询借阅信息ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.添加数据ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.添加图书信息ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.添加学生信息ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.添加借阅信息ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.修改数据ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.修改图书信息ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.修改学生信息ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.修改借阅信息ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.删除数据ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.删除图书信息ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.删除学生信息ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.删除借阅信息ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.最小化ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.显示窗口ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.退出系统ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.查询数据ToolStripMenuItem, Me.添加数据ToolStripMenuItem, Me.修改数据ToolStripMenuItem, Me.删除数据ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(504, 25)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '查询数据ToolStripMenuItem
        '
        Me.查询数据ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.查询图书信息ToolStripMenuItem, Me.查询学生信息ToolStripMenuItem, Me.查询借阅信息ToolStripMenuItem})
        Me.查询数据ToolStripMenuItem.Name = "查询数据ToolStripMenuItem"
        Me.查询数据ToolStripMenuItem.Size = New System.Drawing.Size(68, 21)
        Me.查询数据ToolStripMenuItem.Text = "查询数据"
        '
        '查询图书信息ToolStripMenuItem
        '
        Me.查询图书信息ToolStripMenuItem.Name = "查询图书信息ToolStripMenuItem"
        Me.查询图书信息ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.查询图书信息ToolStripMenuItem.Text = "查询图书信息"
        '
        '查询学生信息ToolStripMenuItem
        '
        Me.查询学生信息ToolStripMenuItem.Name = "查询学生信息ToolStripMenuItem"
        Me.查询学生信息ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.查询学生信息ToolStripMenuItem.Text = "查询学生信息"
        '
        '查询借阅信息ToolStripMenuItem
        '
        Me.查询借阅信息ToolStripMenuItem.Name = "查询借阅信息ToolStripMenuItem"
        Me.查询借阅信息ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.查询借阅信息ToolStripMenuItem.Text = "查询借阅信息"
        '
        '添加数据ToolStripMenuItem
        '
        Me.添加数据ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.添加图书信息ToolStripMenuItem, Me.添加学生信息ToolStripMenuItem, Me.添加借阅信息ToolStripMenuItem})
        Me.添加数据ToolStripMenuItem.Name = "添加数据ToolStripMenuItem"
        Me.添加数据ToolStripMenuItem.Size = New System.Drawing.Size(68, 21)
        Me.添加数据ToolStripMenuItem.Text = "添加数据"
        '
        '添加图书信息ToolStripMenuItem
        '
        Me.添加图书信息ToolStripMenuItem.Name = "添加图书信息ToolStripMenuItem"
        Me.添加图书信息ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.添加图书信息ToolStripMenuItem.Text = "添加图书信息"
        '
        '添加学生信息ToolStripMenuItem
        '
        Me.添加学生信息ToolStripMenuItem.Name = "添加学生信息ToolStripMenuItem"
        Me.添加学生信息ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.添加学生信息ToolStripMenuItem.Text = "添加学生信息"
        '
        '添加借阅信息ToolStripMenuItem
        '
        Me.添加借阅信息ToolStripMenuItem.Name = "添加借阅信息ToolStripMenuItem"
        Me.添加借阅信息ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.添加借阅信息ToolStripMenuItem.Text = "添加借阅信息"
        '
        '修改数据ToolStripMenuItem
        '
        Me.修改数据ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.修改图书信息ToolStripMenuItem, Me.修改学生信息ToolStripMenuItem, Me.修改借阅信息ToolStripMenuItem})
        Me.修改数据ToolStripMenuItem.Name = "修改数据ToolStripMenuItem"
        Me.修改数据ToolStripMenuItem.Size = New System.Drawing.Size(68, 21)
        Me.修改数据ToolStripMenuItem.Text = "修改数据"
        '
        '修改图书信息ToolStripMenuItem
        '
        Me.修改图书信息ToolStripMenuItem.Name = "修改图书信息ToolStripMenuItem"
        Me.修改图书信息ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.修改图书信息ToolStripMenuItem.Text = "修改图书信息"
        '
        '修改学生信息ToolStripMenuItem
        '
        Me.修改学生信息ToolStripMenuItem.Name = "修改学生信息ToolStripMenuItem"
        Me.修改学生信息ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.修改学生信息ToolStripMenuItem.Text = "修改学生信息"
        '
        '修改借阅信息ToolStripMenuItem
        '
        Me.修改借阅信息ToolStripMenuItem.Name = "修改借阅信息ToolStripMenuItem"
        Me.修改借阅信息ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.修改借阅信息ToolStripMenuItem.Text = "修改借阅信息"
        '
        '删除数据ToolStripMenuItem
        '
        Me.删除数据ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.删除图书信息ToolStripMenuItem, Me.删除学生信息ToolStripMenuItem, Me.删除借阅信息ToolStripMenuItem})
        Me.删除数据ToolStripMenuItem.Name = "删除数据ToolStripMenuItem"
        Me.删除数据ToolStripMenuItem.Size = New System.Drawing.Size(68, 21)
        Me.删除数据ToolStripMenuItem.Text = "删除数据"
        '
        '删除图书信息ToolStripMenuItem
        '
        Me.删除图书信息ToolStripMenuItem.Name = "删除图书信息ToolStripMenuItem"
        Me.删除图书信息ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.删除图书信息ToolStripMenuItem.Text = "删除图书信息"
        '
        '删除学生信息ToolStripMenuItem
        '
        Me.删除学生信息ToolStripMenuItem.Name = "删除学生信息ToolStripMenuItem"
        Me.删除学生信息ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.删除学生信息ToolStripMenuItem.Text = "删除学生信息"
        '
        '删除借阅信息ToolStripMenuItem
        '
        Me.删除借阅信息ToolStripMenuItem.Name = "删除借阅信息ToolStripMenuItem"
        Me.删除借阅信息ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.删除借阅信息ToolStripMenuItem.Text = "删除借阅信息"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "图书馆管理系统"
        Me.NotifyIcon1.Visible = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 302)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(504, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(36, 3, 36, 2)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(80, 17)
        Me.ToolStripStatusLabel1.Text = "姓名：朱儒招"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Margin = New System.Windows.Forms.Padding(36, 3, 36, 2)
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(135, 17)
        Me.ToolStripStatusLabel2.Text = "学号：2015301110018"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Margin = New System.Windows.Forms.Padding(36, 3, 36, 2)
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(92, 17)
        Me.ToolStripStatusLabel3.Text = "时间：00:00:00"
        Me.ToolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.最小化ToolStripMenuItem, Me.显示窗口ToolStripMenuItem, Me.退出系统ToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(125, 70)
        '
        '最小化ToolStripMenuItem
        '
        Me.最小化ToolStripMenuItem.Name = "最小化ToolStripMenuItem"
        Me.最小化ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.最小化ToolStripMenuItem.Text = "最小化"
        '
        '显示窗口ToolStripMenuItem
        '
        Me.显示窗口ToolStripMenuItem.Name = "显示窗口ToolStripMenuItem"
        Me.显示窗口ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.显示窗口ToolStripMenuItem.Text = "显示窗口"
        '
        '退出系统ToolStripMenuItem1
        '
        Me.退出系统ToolStripMenuItem1.Name = "退出系统ToolStripMenuItem1"
        Me.退出系统ToolStripMenuItem1.Size = New System.Drawing.Size(124, 22)
        Me.退出系统ToolStripMenuItem1.Text = "退出系统"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.LibraryManagementSystem.My.Resources.Resources.背景
        Me.PictureBox1.Location = New System.Drawing.Point(12, 26)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(480, 270)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 324)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "MainWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "图书馆管理系统"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 添加数据ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 添加图书信息ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 添加学生信息ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 添加借阅信息ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 删除数据ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 删除图书信息ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 删除学生信息ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 删除借阅信息ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 修改数据ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 修改图书信息ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 修改学生信息ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 修改借阅信息ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 查询数据ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 查询图书信息ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 查询学生信息ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 查询借阅信息ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 退出系统ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents 最小化ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 显示窗口ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
