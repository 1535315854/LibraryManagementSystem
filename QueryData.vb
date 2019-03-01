Imports MySql.Data.MySqlClient

Public Class QueryData

    '显示时间
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel2.Text = "时间" + TimeOfDay
    End Sub

    '文本框1只能输入数字和BACKSPACE键
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    '查询按钮
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Text = "图书信息查询" Then specifiedQuery(0)
        If Text = "学生信息查询" Then specifiedQuery(1)
        If Text = "借阅信息查询" Then specifiedQuery(2)
    End Sub

    '清除按钮
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    '返回按钮
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Text = "图书信息查询" Then
            Dim myCmdStr As String = "select BookID as 图书编号,BookName as 图书名称," + _
                                     "Author as 作者,Publisher as 出版社,Note as 备注 from Books;"
            sqlQuery(myCmdStr)
        ElseIf Text = "学生信息查询" Then
            Dim myCmdStr As String = "select LibraryCardID as 借书卡号,StudentName as 姓名," + _
                                     "Age as 年龄,Sex as 性别,PhoneNumber as 电话号码," + _
                                     "Email as 邮箱,Note as 备注 from Students;"
            sqlQuery(myCmdStr)
        ElseIf Text = "借阅信息查询" Then
            Dim myCmdStr As String = "select Students.LibraryCardID as 借书卡号,StudentName as 姓名," + _
                                 "Books.BookID as 图书编号,BookName as 图书名称,BorrowDate " + _
                                 "as 借书日期,ReturnDate as 应还日期,BorrowInfo.Note as 备注 " + _
                                 "from BorrowInfo inner join Books on BorrowInfo.BookID = Books.BookID " + _
                                 "inner join Students on BorrowInfo.LibraryCardID = Students.LibraryCardID;"
            sqlQuery(myCmdStr)
        End If

        ToolStripStatusLabel1.Visible = False
        ToolStripProgressBar1.Visible = False
    End Sub

    '退出按钮
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    'num：0--图书，1--学生，2--借阅
    Public Sub sqlQuery(ByVal str As String)
        Dim myConn As New MySqlConnection("Data Source = localhost;User ID = root;Password = 666666;Initial Catalog = library_management_system;")
        Dim myAdapter As New MySqlDataAdapter(str, myConn)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet, "myTable")

        DataGridView1.DataSource = myDataSet.Tables("myTable")
    End Sub

    '指定查询
    Private Sub specifiedQuery(ByVal num As Integer)
        Select Case num
            Case 0
                Dim BookId = TextBox1.Text
                Dim BookName = TextBox2.Text
                Dim Author = TextBox3.Text

                Dim myCmdStr As String

                If BookId = "" And BookName = "" And Author = "" Then
                    MsgBox("请输入内容！", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                Else
                    ToolStripStatusLabel1.Visible = True
                    ToolStripStatusLabel1.Text = "图书信息查询中..."

                    ToolStripProgressBar1.Value = 0
                    ToolStripProgressBar1.Visible = True
                    ToolStripProgressBar1.Maximum = 1

                    If BookId <> "" Then
                        myCmdStr = "select BookID as 图书编号,BookName as 图书名称," + _
                                              "Author as 作者,Publisher as 出版社,Note as 备注 from Books " + _
                                              "where BookID = '" + BookId + "';"
                        sqlQuery(myCmdStr)
                    ElseIf BookName <> "" Then
                        myCmdStr = "select BookID as 图书编号,BookName as 图书名称," + _
                                              "Author as 作者,Publisher as 出版社,Note as 备注 from Books " + _
                                              "where BookName like '%" + BookName + "%';"
                        sqlQuery(myCmdStr)
                    ElseIf Author <> "" Then
                        myCmdStr = "select BookID as 图书编号,BookName as 图书名称," + _
                                              "Author as 作者,Publisher as 出版社,Note as 备注 from Books " + _
                                              "where Author like '%" + Author + "%';"
                        sqlQuery(myCmdStr)
                    End If

                    ToolStripProgressBar1.PerformStep()

                    ToolStripStatusLabel1.Text = "图书信息查询完毕"
                End If
            Case 1
                Dim CardId = TextBox1.Text
                Dim StuName = TextBox2.Text
                Dim StuSex = TextBox3.Text

                Dim myCmdStr As String

                If CardId = "" And StuName = "" And StuSex = "" Then
                    MsgBox("请输入内容！", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                ElseIf StuSex <> "" And StuSex <> "男" And StuSex <> "女" Then
                    MsgBox("请输入正确的性别！", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                Else
                    ToolStripStatusLabel1.Visible = True
                    ToolStripStatusLabel1.Text = "学生信息查询中..."

                    ToolStripProgressBar1.Value = 0
                    ToolStripProgressBar1.Visible = True
                    ToolStripProgressBar1.Maximum = 1

                    If CardId <> "" Then
                        myCmdStr = "select LibraryCardID as 借书卡号,StudentName as 姓名," + _
                                   "Age as 年龄,Sex as 性别,PhoneNumber as 电话号码," + _
                                   "Email as 邮箱,Note as 备注 from Students where " + _
                                   "LibraryCardID = '" + CardId + "';"
                        sqlQuery(myCmdStr)
                    ElseIf StuName <> "" Then
                        myCmdStr = "select LibraryCardID as 借书卡号,StudentName as 姓名," + _
                                   "Age as 年龄,Sex as 性别,PhoneNumber as 电话号码," + _
                                   "Email as 邮箱,Note as 备注 from Students where " + _
                                   "StudentName like '%" + StuName + "%';"
                        sqlQuery(myCmdStr)
                    ElseIf StuSex <> "" Then
                        myCmdStr = "select LibraryCardID as 借书卡号,StudentName as 姓名," + _
                                   "Age as 年龄,Sex as 性别,PhoneNumber as 电话号码," + _
                                   "Email as 邮箱,Note as 备注 from Students where " + _
                                   "Sex = '" + StuSex + "';"
                        sqlQuery(myCmdStr)
                    End If

                    ToolStripProgressBar1.PerformStep()

                    ToolStripStatusLabel1.Text = "学生信息查询完毕"
                End If
            Case 2
                Dim CardId = TextBox1.Text
                Dim BookId = TextBox2.Text
                Dim StuName = TextBox3.Text

                Dim myCmdStr As String

                If CardId = "" And BookId = "" And StuName = "" Then
                    MsgBox("请输入内容！", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                Else
                    ToolStripStatusLabel1.Visible = True
                    ToolStripStatusLabel1.Text = "借阅信息查询中..."

                    ToolStripProgressBar1.Value = 0
                    ToolStripProgressBar1.Visible = True
                    ToolStripProgressBar1.Maximum = 1

                    If CardId <> "" Then
                        myCmdStr = "select Students.LibraryCardID as 借书卡号,StudentName as 姓名," + _
                                   "Books.BookID as 图书编号,BookName as 图书名称,BorrowDate " + _
                                   "as 借书日期,ReturnDate as 应还日期,BorrowInfo.Note as 备注 " + _
                                   "from BorrowInfo inner join Books on BorrowInfo.BookID = Books.BookID " + _
                                   "inner join Students on BorrowInfo.LibraryCardID = Students.LibraryCardID " + _
                                   "where Students.LibraryCardID = '" + CardId + "';"
                        sqlQuery(myCmdStr)
                    ElseIf BookId <> "" Then
                        myCmdStr = "select Students.LibraryCardID as 借书卡号,StudentName as 姓名," + _
                                   "Books.BookID as 图书编号,BookName as 图书名称,BorrowDate " + _
                                   "as 借书日期,ReturnDate as 应还日期,BorrowInfo.Note as 备注 " + _
                                   "from BorrowInfo inner join Books on BorrowInfo.BookID = Books.BookID " + _
                                   "inner join Students on BorrowInfo.LibraryCardID = Students.LibraryCardID " + _
                                   "where Books.BookID = '" + BookId + "';"
                        sqlQuery(myCmdStr)
                    ElseIf StuName <> "" Then
                        myCmdStr = "select Students.LibraryCardID as 借书卡号,StudentName as 姓名," + _
                                   "Books.BookID as 图书编号,BookName as 图书名称,BorrowDate " + _
                                   "as 借书日期,ReturnDate as 应还日期,BorrowInfo.Note as 备注 " + _
                                   "from BorrowInfo inner join Books on BorrowInfo.BookID = Books.BookID " + _
                                   "inner join Students on BorrowInfo.LibraryCardID = Students.LibraryCardID " + _
                                   "where StudentName like '%" + StuName + "%';"
                        sqlQuery(myCmdStr)
                    End If

                    ToolStripProgressBar1.PerformStep()

                    ToolStripStatusLabel1.Text = "借阅信息查询完毕"
                End If
        End Select
    End Sub
End Class