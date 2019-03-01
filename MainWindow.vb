Public Class MainWindow

    '状态条显示当前时间
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel3.Text = "时间：" + TimeOfDay
    End Sub

    '右键点击托盘图标弹出菜单
    Private Sub NotifyIcon1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            NotifyIcon1.ContextMenuStrip = ContextMenuStrip1
        End If
    End Sub

    Private Sub 最小化ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 最小化ToolStripMenuItem.Click
        Me.WindowState = 1
    End Sub

    Private Sub 显示窗口ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 显示窗口ToolStripMenuItem.Click
        Me.WindowState = 0
    End Sub

    Private Sub 退出系统ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 退出系统ToolStripMenuItem1.Click
        Me.Dispose()
    End Sub

    '点击窗口关闭按钮弹出确认对话框
    Private Sub MainWindow_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim intCheck As Integer
        intCheck = MsgBox("是否退出系统？", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "关闭窗口")
        If intCheck = 7 Then
            e.Cancel = True
        End If
    End Sub

    '查询数据
    Private Sub 查询图书信息ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查询图书信息ToolStripMenuItem.Click
        QueryData.Text = "图书信息查询"
        QueryData.Label2.Text = "图书编号"
        QueryData.Label3.Text = "图书名称"
        QueryData.Label4.Text = "作者姓名"

        QueryData.Show()

        Dim myCmdStr As String = "select BookID as 图书编号,BookName as 图书名称," +
                                 "Author as 作者,Publisher as 出版社,Note as 备注 from Books;"
        QueryData.sqlQuery(myCmdStr)
    End Sub

    Private Sub 查询学生信息ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查询学生信息ToolStripMenuItem.Click
        QueryData.Text = "学生信息查询"
        QueryData.Label2.Text = "借书卡号"
        QueryData.Label3.Text = "学生姓名"
        QueryData.Label4.Text = "学生性别"

        QueryData.Show()

        Dim myCmdStr As String = "select LibraryCardID as 借书卡号,StudentName as 姓名," +
                                 "Age as 年龄,Sex as 性别,PhoneNumber as 电话号码," +
                                 "Email as 邮箱,Note as 备注 from Students;"
        QueryData.sqlQuery(myCmdStr)
    End Sub

    Private Sub 查询借阅信息ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查询借阅信息ToolStripMenuItem.Click
        QueryData.Text = "借阅信息查询"
        QueryData.Label2.Text = "借书卡号"
        QueryData.Label3.Text = "图书编号"
        QueryData.Label4.Text = "学生姓名"

        QueryData.Show()

        Dim myCmdStr As String = "select Students.LibraryCardID as 借书卡号,StudentName as 姓名," +
                                 "Books.BookID as 图书编号,BookName as 图书名称,BorrowDate " +
                                 "as 借书日期,ReturnDate as 应还日期,BorrowInfo.Note as 备注 " +
                                 "from BorrowInfo inner join Books on BorrowInfo.BookID = Books.BookID " +
                                 "inner join Students on BorrowInfo.LibraryCardID = Students.LibraryCardID;"
        QueryData.sqlQuery(myCmdStr)
    End Sub

    '添加数据
    Private Sub 添加图书信息ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 添加图书信息ToolStripMenuItem.Click
        AddData.Text = "添加图书信息"
        AddData.PictureBox1.Image = My.Resources.图书
        AddData.Label1.Text = "图书信息"
        AddData.Label3.Text = "* 图书编号"
        AddData.Label4.Text = "* 图书名称"
        AddData.Label5.Text = "* 作者姓名"
        AddData.Label6.Text = "* 出版社"

        AddData.Show()
    End Sub

    Private Sub 添加学生信息ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 添加学生信息ToolStripMenuItem.Click
        AddData.Text = "添加学生信息"
        AddData.PictureBox1.Image = My.Resources.学生
        AddData.Label1.Text = "学生信息"
        AddData.Label3.Text = "* 借书卡号"
        AddData.Label4.Text = "* 学生姓名"
        AddData.Label5.Text = "* 学生年龄"
        AddData.Label6.Text = "* 学生性别"
        AddData.Label7.Visible = True
        AddData.Label8.Visible = True
        AddData.TextBox5.Visible = True
        AddData.TextBox6.Visible = True
        AddData.Label9.Location = New Point(20, 250)
        AddData.RichTextBox1.Location = New Point(105, 250)
        AddData.Button1.Location = New Point(80, 315)
        AddData.Button2.Location = New Point(200, 315)
        AddData.Button3.Location = New Point(320, 315)
        AddData.Size = New Point(480, 420)

        AddData.Show()
    End Sub

    Private Sub 添加借阅信息ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 添加借阅信息ToolStripMenuItem.Click
        AddData.Text = "添加借阅信息"
        AddData.PictureBox1.Image = My.Resources.借阅
        AddData.Label1.Text = "借阅信息"
        AddData.Label3.Text = "* 借书卡号"
        AddData.Label4.Text = "* 图书编号"
        AddData.Label5.Text = "* 借书日期"
        AddData.Label6.Text = "* 应还日期"

        AddData.Show()
    End Sub

    '修改数据
    Private Sub 修改图书信息ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 修改图书信息ToolStripMenuItem.Click
        ModifyData.Text = "修改图书信息"
        ModifyData.Button1.BackColor = Color.LightBlue
        ModifyData.Label3.Text = "* 图书编号"
        ModifyData.Label4.Text = "新图书编号"
        ModifyData.Label5.Text = "新图书名称"
        ModifyData.Label6.Text = "新作者姓名"
        ModifyData.Label7.Text = "新出版社"

        ModifyData.Show()

        Dim myCmdStr As String = "select BookID as 图书编号,BookName as 图书名称," +
                                 "Author as 作者,Publisher as 出版社,Note as 备注 from Books;"
        ModifyData.sqlQuery(myCmdStr)
    End Sub

    Private Sub 修改学生信息ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 修改学生信息ToolStripMenuItem.Click
        ModifyData.Text = "修改学生信息"
        ModifyData.Button2.BackColor = Color.LightBlue
        ModifyData.Label3.Text = "* 借书卡号"
        ModifyData.Label4.Text = "新借书卡号"
        ModifyData.Label5.Text = "新学生姓名"
        ModifyData.Label6.Text = "新学生年龄"
        ModifyData.Label7.Text = "新学生性别"
        ModifyData.Label8.Visible = True
        ModifyData.Label9.Visible = True
        ModifyData.TextBox6.Visible = True
        ModifyData.TextBox7.Visible = True
        ModifyData.Label10.Location = New Point(550, 265)
        ModifyData.RichTextBox1.Location = New Point(633, 262)

        ModifyData.Show()

        Dim myCmdStr As String = "select LibraryCardID as 借书卡号,StudentName as 姓名," +
                                 "Age as 年龄,Sex as 性别,PhoneNumber as 电话号码," +
                                 "Email as 邮箱,Note as 备注 from Students;"
        ModifyData.sqlQuery(myCmdStr)
    End Sub

    Private Sub 修改借阅信息ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 修改借阅信息ToolStripMenuItem.Click
        ModifyData.Text = "修改借阅信息"
        ModifyData.Button3.BackColor = Color.LightBlue
        ModifyData.Label3.Text = "* 借书卡号"
        ModifyData.Label4.Text = "* 图书编号"
        ModifyData.Label5.Text = "新借书卡号"
        ModifyData.Label6.Text = "新图书编号"
        ModifyData.Label7.Text = "新借书日期"
        ModifyData.Label8.Text = "新应还日期"
        ModifyData.Label8.Visible = True
        ModifyData.TextBox6.Visible = True
        ModifyData.Label10.Location = New Point(550, 235)
        ModifyData.RichTextBox1.Location = New Point(633, 232)

        ModifyData.Show()

        Dim myCmdStr As String = "select Students.LibraryCardID as 借书卡号,StudentName as 姓名," +
                                 "Books.BookID as 图书编号,BookName as 图书名称,BorrowDate " +
                                 "as 借书日期,ReturnDate as 应还日期,BorrowInfo.Note as 备注 " +
                                 "from BorrowInfo inner join Books on BorrowInfo.BookID = Books.BookID " +
                                 "inner join Students on BorrowInfo.LibraryCardID = Students.LibraryCardID;"
        ModifyData.sqlQuery(myCmdStr)
    End Sub

    '删除数据
    Private Sub 删除图书信息ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 删除图书信息ToolStripMenuItem.Click
        DeleteData.Text = "删除图书信息"
        DeleteData.PictureBox1.Image = My.Resources.图书
        DeleteData.Label1.Text = "图书信息"

        DeleteData.Show()

        Dim myCmdStr As String = "select BookID as 图书编号,BookName as 图书名称," +
                                 "Author as 作者,Publisher as 出版社,Note as 备注 from Books;"
        DeleteData.sqlQuery(myCmdStr)

        DeleteData.ComboBox1.DisplayMember = "图书名称"
        DeleteData.ComboBox1.ValueMember = "图书编号"
    End Sub

    Private Sub 删除学生信息ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 删除学生信息ToolStripMenuItem.Click
        DeleteData.Text = "删除学生信息"
        DeleteData.PictureBox1.Image = My.Resources.学生
        DeleteData.Label1.Text = "学生信息"

        DeleteData.Show()

        Dim myCmdStr As String = "select LibraryCardID as 借书卡号,StudentName as 姓名," +
                                 "Age as 年龄,Sex as 性别,PhoneNumber as 电话号码," +
                                 "Email as 邮箱,Note as 备注 from Students;"
        DeleteData.sqlQuery(myCmdStr)

        DeleteData.ComboBox1.DisplayMember = "姓名"
        DeleteData.ComboBox1.ValueMember = "借书卡号"
    End Sub

    Private Sub 删除借阅信息ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 删除借阅信息ToolStripMenuItem.Click
        DeleteData.Text = "删除借阅信息"
        DeleteData.PictureBox1.Image = My.Resources.借阅
        DeleteData.Label1.Text = "借阅信息"

        DeleteData.Show()

        Dim myCmdStr As String = "select concat(Students.LibraryCardID,"" "",Books.BookID) as '借书记录'," +
                                 "concat(Students.StudentName,"" "",Books.BookName) as '学生姓名 图书名称',BorrowDate " +
                                 "as 借书日期,ReturnDate as 应还日期,BorrowInfo.Note as 备注 " +
                                 "from BorrowInfo inner join Books on BorrowInfo.BookID = Books.BookID " +
                                 "inner join Students on BorrowInfo.LibraryCardID = Students.LibraryCardID;"
        DeleteData.sqlQuery(myCmdStr)

        DeleteData.ComboBox1.DisplayMember = "学生姓名 图书名称"
        DeleteData.ComboBox1.ValueMember = "借书记录"
    End Sub
End Class
