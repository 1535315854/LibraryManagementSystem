Imports MySql.Data.MySqlClient

Public Class DeleteData

    '显示时间
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel2.Text = "时间" + TimeOfDay
    End Sub

    '删除按钮
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Text = "删除图书信息" Then
            Dim check As Integer
            check = MsgBox("您将要删除编号为" & ComboBox1.SelectedValue & "的图书信息，确定吗？", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "警告")
            If check = 2 Then
                'Do Nothing
            Else
                ToolStripStatusLabel1.Visible = True
                ToolStripStatusLabel1.Text = "删除图书信息中..."

                ToolStripProgressBar1.Value = 0
                ToolStripProgressBar1.Visible = True
                ToolStripProgressBar1.Maximum = 1

                Dim myCmdStr As String = "delete from Books where BookID = '" & ComboBox1.SelectedValue & "';"
                sqlQuery_2(myCmdStr)

                ToolStripProgressBar1.PerformStep()

                ToolStripStatusLabel1.Text = "图书信息删除成功"

                myCmdStr = "select BookID as 图书编号,BookName as 图书名称," + _
                                     "Author as 作者,Publisher as 出版社,Note as 备注 from Books;"
                sqlQuery(myCmdStr)
            End If
        ElseIf Text = "删除学生信息" Then
            Dim check As Integer
            check = MsgBox("您将要删除借书卡号为" & ComboBox1.SelectedValue & "的学生信息，确定吗？", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "警告")
            If check = 2 Then
                'Do Nothing
            Else
                ToolStripStatusLabel1.Visible = True
                ToolStripStatusLabel1.Text = "删除学生信息中..."

                ToolStripProgressBar1.Value = 0
                ToolStripProgressBar1.Visible = True
                ToolStripProgressBar1.Maximum = 1

                Dim myCmdStr As String = "delete from Students where LibraryCardID = '" & ComboBox1.SelectedValue & "';"
                sqlQuery_2(myCmdStr)

                ToolStripProgressBar1.PerformStep()

                ToolStripStatusLabel1.Text = "学生信息删除成功"

                myCmdStr = "select LibraryCardID as 借书卡号,StudentName as 姓名," + _
                                     "Age as 年龄,Sex as 性别,PhoneNumber as 电话号码," + _
                                     "Email as 邮箱,Note as 备注 from Students;"
                sqlQuery(myCmdStr)
            End If
        ElseIf Text = "删除借阅信息" Then
            Dim CardId = Mid(ComboBox1.SelectedValue, 1, 13)
            Dim BookId = Mid(ComboBox1.SelectedValue, 15, ComboBox1.SelectedValue.Length)

            Dim check As Integer
            check = MsgBox("您将要删除借书卡号为" & CardId & "，图书编号为" & BookId & "的借阅信息，确定吗？", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "警告")
            If check = 2 Then
                'Do Nothing
            Else
                ToolStripStatusLabel1.Visible = True
                ToolStripStatusLabel1.Text = "删除借阅信息中..."

                ToolStripProgressBar1.Value = 0
                ToolStripProgressBar1.Visible = True
                ToolStripProgressBar1.Maximum = 1

                Dim myCmdStr As String = "delete from BorrowInfo where LibraryCardID = '" + CardId + "' and BookID = '" + BookId + "';"
                sqlQuery_2(myCmdStr)

                ToolStripProgressBar1.PerformStep()

                ToolStripStatusLabel1.Text = "借阅信息删除成功"

                myCmdStr = "select concat(Students.LibraryCardID,"" "",Books.BookID) as '借书记录'," + _
                                     "concat(Students.StudentName,"" "",Books.BookName) as '学生姓名 图书名称',BorrowDate " + _
                                     "as 借书日期,ReturnDate as 应还日期,BorrowInfo.Note as 备注 " + _
                                     "from BorrowInfo inner join Books on BorrowInfo.BookID = Books.BookID " + _
                                     "inner join Students on BorrowInfo.LibraryCardID = Students.LibraryCardID;"
                sqlQuery(myCmdStr)
            End If
        End If
    End Sub

    '退出按钮
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    'num：0--图书，1--学生，2--借阅
    Public Sub sqlQuery(ByVal str As String)
        Dim myConn As New MySqlConnection("Data Source = localhost;User ID = root;Password = 666666;Initial Catalog = library_management_system;")
        Dim myAdapter As New MySqlDataAdapter(str, myConn)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet, "myTable")

        ComboBox1.DataSource = myDataSet.Tables("myTable")
        DataGridView1.DataSource = myDataSet.Tables("myTable")
    End Sub

    Private Sub sqlQuery_2(ByVal str As String)
        Dim myConn As New MySqlConnection("Data Source = localhost;User ID = root;Password = 666666;Initial Catalog = library_management_system;")
        Dim myAdapter As New MySqlDataAdapter(str, myConn)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet, "myTable")
    End Sub
End Class