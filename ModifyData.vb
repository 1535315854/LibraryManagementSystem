Imports MySql.Data.MySqlClient

Public Class ModifyData

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

    '文本框2只能输入数字和BACKSPACE键
    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    '图书按钮
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.BackColor = Color.LightBlue
        Button2.BackColor = Color.White
        Button3.BackColor = Color.White
        Text = "修改图书信息"
        Label3.Text = "* 图书编号"
        Label4.Text = "新图书编号"
        Label5.Text = "新图书名称"
        Label6.Text = "新作者姓名"
        Label7.Text = "新出版社"
        Label8.Visible = False
        Label9.Visible = False
        TextBox6.Visible = False
        TextBox7.Visible = False
        Label10.Location = New Point(550, 205)
        RichTextBox1.Location = New Point(633, 202)

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        RichTextBox1.Text = ""

        ToolStripStatusLabel1.Visible = False
        ToolStripProgressBar1.Visible = False

        Dim myCmdStr As String = "select BookID as 图书编号,BookName as 图书名称," + _
                                 "Author as 作者,Publisher as 出版社,Note as 备注 from Books;"
        sqlQuery(myCmdStr)
    End Sub

    '学生按钮
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button2.BackColor = Color.LightBlue
        Button1.BackColor = Color.White
        Button3.BackColor = Color.White
        Text = "修改学生信息"
        Label3.Text = "* 借书卡号"
        Label4.Text = "新借书卡号"
        Label5.Text = "新学生姓名"
        Label6.Text = "新学生年龄"
        Label7.Text = "新学生性别"
        Label8.Visible = True
        Label9.Visible = True
        TextBox6.Visible = True
        TextBox7.Visible = True
        Label10.Location = New Point(550, 265)
        RichTextBox1.Location = New Point(633, 262)

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        RichTextBox1.Text = ""

        ToolStripStatusLabel1.Visible = False
        ToolStripProgressBar1.Visible = False

        Dim myCmdStr As String = "select LibraryCardID as 借书卡号,StudentName as 姓名," + _
                                 "Age as 年龄,Sex as 性别,PhoneNumber as 电话号码," + _
                                 "Email as 邮箱,Note as 备注 from Students;"
        sqlQuery(myCmdStr)
    End Sub

    '借阅按钮
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button3.BackColor = Color.LightBlue
        Button1.BackColor = Color.White
        Button2.BackColor = Color.White
        Text = "修改借阅信息"
        Label3.Text = "* 借书卡号"
        Label4.Text = "* 图书编号"
        Label5.Text = "新借书卡号"
        Label6.Text = "新图书编号"
        Label7.Text = "新借书日期"
        Label8.Text = "新应还日期"
        Label8.Visible = True
        Label9.Visible = False
        TextBox6.Visible = True
        TextBox7.Visible = False
        Label10.Location = New Point(550, 235)
        RichTextBox1.Location = New Point(633, 232)

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        RichTextBox1.Text = ""

        ToolStripStatusLabel1.Visible = False
        ToolStripProgressBar1.Visible = False

        Dim myCmdStr As String = "select Students.LibraryCardID as 借书卡号,StudentName as 姓名," + _
                                 "Books.BookID as 图书编号,BookName as 图书名称,BorrowDate " + _
                                 "as 借书日期,ReturnDate as 应还日期,BorrowInfo.Note as 备注 " + _
                                 "from BorrowInfo inner join Books on BorrowInfo.BookID = Books.BookID " + _
                                 "inner join Students on BorrowInfo.LibraryCardID = Students.LibraryCardID;"
        sqlQuery(myCmdStr)
    End Sub

    '修改按钮
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Text = "修改图书信息" Then
            Dim OldBookId = TextBox1.Text
            Dim BookId = TextBox2.Text
            Dim BookName = TextBox3.Text
            Dim Author = TextBox4.Text
            Dim Publisher = TextBox5.Text
            Dim Note = RichTextBox1.Text

            If OldBookId <> "" And (BookId <> "" Or BookName <> "" Or Author <> "" Or Publisher <> "" Or Note <> "") Then
                If OldBookId.Length > 10 Then
                    MsgBox("请输入正确的图书编号", MsgBoxStyle.Exclamation, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                Else
                    Dim myCmdStr As String = "select count(*) from Books where BookID = '" + OldBookId + "';"
                    Dim myDataSet As New DataSet

                    If Not ifExist(myCmdStr) Then
                        MsgBox("图书编号不存在", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf BookId.Length > 10 Then
                        MsgBox("请输入正确的新图书编号", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf BookName.Length > 30 Then
                        MsgBox("请输入正确的新图书名称", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf Author.Length > 20 Then
                        MsgBox("请输入正确的新作者姓名", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf Publisher.Length > 20 Then
                        MsgBox("请输入正确的新出版社", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    Else
                        ToolStripStatusLabel1.Visible = True
                        ToolStripStatusLabel1.Text = "修改图书信息中..."

                        ToolStripProgressBar1.Value = 0
                        ToolStripProgressBar1.Visible = True
                        ToolStripProgressBar1.Maximum = 1

                        Dim OldName, OldAuthor, OldPublisher, OldNote As String
                        myCmdStr = "select BookName, Author, Publisher, Note from Books where BookID = '" + OldBookId + "';"
                        myDataSet = sqlQuery_2(myCmdStr)
                        OldName = myDataSet.Tables("myTable").Rows(0).Item(0).ToString
                        OldAuthor = myDataSet.Tables("myTable").Rows(0).Item(1).ToString
                        OldPublisher = myDataSet.Tables("myTable").Rows(0).Item(2).ToString
                        OldNote = myDataSet.Tables("myTable").Rows(0).Item(3).ToString

                        If BookId = "" Then
                            BookId = OldBookId
                        End If
                        If BookName = "" Then
                            BookName = OldName
                        End If
                        If Author = "" Then
                            Author = OldAuthor
                        End If
                        If Publisher = "" Then
                            Publisher = OldPublisher
                        End If
                        If Note = "" Then
                            Note = OldNote
                        End If

                        myCmdStr = "update Books set BookID = '" + BookId + "',BookName = '" + BookName + "',Author = '" +
                                    Author + "',Publisher = '" + Publisher + "',Note = '" + Note + "' where BookID = '" + OldBookId + "';"
                        sqlQuery_2(myCmdStr)

                        ToolStripProgressBar1.PerformStep()

                        ToolStripStatusLabel1.Text = "图书信息修改成功"
                    End If
                End If
            Else
                MsgBox("请输入所有必填信息", MsgBoxStyle.Exclamation, "错误")
                ToolStripStatusLabel1.Visible = False
                ToolStripProgressBar1.Visible = False
            End If

        ElseIf Text = "修改学生信息" Then
            Dim OldCardId = TextBox1.Text
            Dim CardId = TextBox2.Text
            Dim StuName = TextBox3.Text
            Dim Age = TextBox4.Text
            Dim Sex = TextBox5.Text
            Dim Phone = TextBox6.Text
            Dim Email = TextBox7.Text
            Dim Note = RichTextBox1.Text

            If OldCardId <> "" And (CardId <> "" Or StuName <> "" Or Age <> "" Or Sex <> "" Or Phone <> "" Or Email <> "" Or Note <> "") Then
                If OldCardId.Length <> 13 Then
                    MsgBox("请输入正确的借书卡号", MsgBoxStyle.Exclamation, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                Else
                    Dim myCmdStr As String = "select count(*) from Students where LibraryCardID = '" + OldCardId + "';"
                    Dim myCmdStr1 As String = "select count(*) from Students where LibraryCardID = '" + CardId + "';"
                    Dim myDataSet As New DataSet

                    If Not ifExist(myCmdStr) Then
                        MsgBox("借书卡号不存在", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf CardId <> "" And CardId.Length <> 13 Then
                        MsgBox("请输入正确的新借书卡号", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf CardId <> "" And CardId.Length = 13 And ifExist(myCmdStr1) Then
                        MsgBox("借书卡号已存在", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf StuName <> "" And StuName.Length > 10 Then
                        MsgBox("请输入正确的新学生姓名", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf Age <> "" AndAlso (Not IsNumeric(Age) OrElse (IsNumeric(Age) AndAlso (CInt(Age) < 0 OrElse CInt(Age) > 127))) Then
                        MsgBox("请输入正确的新学生年龄", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf Sex <> "" And Sex <> "男" And Sex <> "女" Then
                        MsgBox("请输入正确的新学生性别", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf Phone <> "" And Phone.Length > 11 Then
                        MsgBox("请输入正确的新电话号码", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf Email <> "" And Email.Length > 20 Then
                        MsgBox("请输入正确的新邮箱地址", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    Else
                        ToolStripStatusLabel1.Visible = True
                        ToolStripStatusLabel1.Text = "修改学生信息中..."

                        ToolStripProgressBar1.Value = 0
                        ToolStripProgressBar1.Visible = True
                        ToolStripProgressBar1.Maximum = 1

                        Dim OldName, OldAge, OldSex, OldPhone, OldEmail, OldNote As String
                        myCmdStr = "select StudentName, Age, Sex, PhoneNumber, Email, Note from Students where LibraryCardID = '" + OldCardId + "';"
                        myDataSet = sqlQuery_2(myCmdStr)
                        OldName = myDataSet.Tables("myTable").Rows(0).Item(0).ToString
                        OldAge = myDataSet.Tables("myTable").Rows(0).Item(1).ToString
                        OldSex = myDataSet.Tables("myTable").Rows(0).Item(2).ToString
                        OldPhone = myDataSet.Tables("myTable").Rows(0).Item(3).ToString
                        OldEmail = myDataSet.Tables("myTable").Rows(0).Item(4).ToString
                        OldNote = myDataSet.Tables("myTable").Rows(0).Item(5).ToString

                        If CardId = "" Then
                            CardId = OldCardId
                        End If
                        If StuName = "" Then
                            StuName = OldName
                        End If
                        If Age = "" Then
                            Age = OldAge
                        End If
                        If Sex = "" Then
                            Sex = OldSex
                        End If
                        If Phone = "" Then
                            Phone = OldPhone
                        End If
                        If Email = "" Then
                            Email = OldEmail
                        End If
                        If Note = "" Then
                            Note = OldNote
                        End If

                        myCmdStr = "update Students set LibraryCardID = '" + CardId + "',StudentName = '" + StuName + "',Age = '" +
                                    Age + "',Sex = '" + Sex + "',PhoneNumber = '" + Phone + "',Email = '" + Email + "',Note = '" +
                                    Note + "' where LibraryCardID = '" + OldCardId + "';"
                        sqlQuery_2(myCmdStr)

                        ToolStripProgressBar1.PerformStep()

                        ToolStripStatusLabel1.Text = "学生信息修改成功"
                    End If
                End If
            Else
                MsgBox("请输入所有必填信息", MsgBoxStyle.Exclamation, "错误")
                ToolStripStatusLabel1.Visible = False
                ToolStripProgressBar1.Visible = False
            End If

        ElseIf Text = "修改借阅信息" Then
            Dim OldCardId = TextBox1.Text
            Dim OldBookId = TextBox2.Text
            Dim CardId = TextBox3.Text
            Dim BookId = TextBox4.Text
            Dim BorrowDate = TextBox5.Text
            Dim ReturnDate = TextBox6.Text
            Dim Note = RichTextBox1.Text

            If OldCardId <> "" And OldBookId <> "" And (CardId <> "" Or BookId <> "" Or BorrowDate <> "" Or ReturnDate <> "" Or Note <> "") Then
                If OldCardId.Length <> 13 Then
                    MsgBox("请输入正确的借书卡号", MsgBoxStyle.Exclamation, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                ElseIf OldBookId.Length > 10 Then
                    MsgBox("请输入正确的图书编号", MsgBoxStyle.Exclamation, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                Else  
                    Dim myCmdStr As String = "select count(*) from Students where LibraryCardID = '" + OldCardId + "';"
                    Dim myCmdStr1 As String = "select count(*) from Books where BookID = '" + OldBookId + "';"
                    Dim myCmdStr2 As String = "select count(*) from BorrowInfo where LibraryCardID = '" +
                                              OldCardId + "' and BookID = '" + OldBookId + "';"
                    Dim myCmdStr3 As String = "select count(*) from Students where LibraryCardID = '" + CardId + "';"
                    Dim myCmdStr4 As String = "select count(*) from Books where BookID = '" + BookId + "';"
                    Dim myCmdStr5 As String = "select count(*) from BorrowInfo where LibraryCardID = '" +
                                              CardId + "' and BookID = '" + BookId + "';"
                    Dim myDataSet As New DataSet

                    If Not ifExist(myCmdStr) Then
                        MsgBox("借书卡号不存在", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf Not ifExist(myCmdStr1) Then
                        MsgBox("图书编号不存在", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf Not ifExist(myCmdStr2) Then
                        MsgBox("借书记录不存在", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf CardId <> "" And CardId.Length <> 13 Then
                        MsgBox("请输入正确的新借书卡号", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf CardId <> "" And CardId.Length = 13 And Not ifExist(myCmdStr3) Then
                        MsgBox("借书卡号不存在", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf BookId <> "" And BookId.Length > 10 Then
                        MsgBox("请输入正确的新图书编号", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf BookId <> "" And BookId.Length <= 10 And Not ifExist(myCmdStr4) Then
                        MsgBox("图书编号不存在", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf ifExist(myCmdStr5) Then
                        MsgBox("借书记录已存在", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf BorrowDate <> "" And Not IsDate(BorrowDate) Then
                        MsgBox("请输入正确的新借书日期", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    ElseIf ReturnDate <> "" And Not IsDate(ReturnDate) Then
                        MsgBox("请输入正确的新应还日期", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    Else
                        ToolStripStatusLabel1.Visible = True
                        ToolStripStatusLabel1.Text = "修改借阅信息中..."

                        ToolStripProgressBar1.Value = 0
                        ToolStripProgressBar1.Visible = True
                        ToolStripProgressBar1.Maximum = 1

                        Dim OldBorrowDate, OldReturnDate, OldNote As String
                        myCmdStr = "select BorrowDate, ReturnDate, Note from BorrowInfo where LibraryCardID = '" +
                                    OldCardId + "' and BookID = '" + OldBookId + "';"
                        myDataSet = sqlQuery_2(myCmdStr)
                        OldBorrowDate = myDataSet.Tables("myTable").Rows(0).Item(0).ToString
                        OldReturnDate = myDataSet.Tables("myTable").Rows(0).Item(1).ToString
                        OldNote = myDataSet.Tables("myTable").Rows(0).Item(2).ToString

                        If CardId = "" Then
                            CardId = OldCardId
                        End If
                        If BookId = "" Then
                            BookId = OldBookId
                        End If
                        If BorrowDate = "" Then
                            Dim Index As Integer
                            Index = InStr(OldBorrowDate, " ")
                            BorrowDate = Mid(OldBorrowDate, 1, Index)
                        End If
                        If ReturnDate = "" Then
                            Dim Index As Integer
                            Index = InStr(OldReturnDate, " ")
                            ReturnDate = Mid(OldReturnDate, 1, Index)
                        End If
                        If Note = "" Then
                            Note = OldNote
                        End If

                        myCmdStr = "update BorrowInfo set LibraryCardID = '" + CardId + "',BookId = '" +
                                    BookId + "',BorrowDate = '" + BorrowDate + "',ReturnDate = '" + ReturnDate + "',Note = '" +
                                    Note + "' where LibraryCardID = '" + OldCardId + "' and BookID = '" + OldBookId + "';"
                        sqlQuery_2(myCmdStr)

                        ToolStripProgressBar1.PerformStep()

                        ToolStripStatusLabel1.Text = "借阅信息修改成功"
                    End If
                End If
            Else
                MsgBox("请输入所有必填信息", MsgBoxStyle.Exclamation, "错误")
                ToolStripStatusLabel1.Visible = False
                ToolStripProgressBar1.Visible = False
            End If
        End If
    End Sub

    '刷新按钮
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If Text = "修改图书信息" Then
            ToolStripStatusLabel1.Visible = False
            ToolStripProgressBar1.Visible = False

            Dim myCmdStr As String = "select BookID as 图书编号,BookName as 图书名称," + _
                                 "Author as 作者,Publisher as 出版社,Note as 备注 from Books;"
            sqlQuery(myCmdStr)
        ElseIf Text = "修改学生信息" Then
            ToolStripStatusLabel1.Visible = False
            ToolStripProgressBar1.Visible = False

            Dim myCmdStr As String = "select LibraryCardID as 借书卡号,StudentName as 姓名," + _
                                 "Age as 年龄,Sex as 性别,PhoneNumber as 电话号码," + _
                                 "Email as 邮箱,Note as 备注 from Students;"
            sqlQuery(myCmdStr)
        Else
            ToolStripStatusLabel1.Visible = False
            ToolStripProgressBar1.Visible = False

            Dim myCmdStr As String = "select Students.LibraryCardID as 借书卡号,StudentName as 姓名," + _
                                 "Books.BookID as 图书编号,BookName as 图书名称,BorrowDate " + _
                                 "as 借书日期,ReturnDate as 应还日期,BorrowInfo.Note as 备注 " + _
                                 "from BorrowInfo inner join Books on BorrowInfo.BookID = Books.BookID " + _
                                 "inner join Students on BorrowInfo.LibraryCardID = Students.LibraryCardID;"
            sqlQuery(myCmdStr)
        End If
    End Sub

    '清除按钮
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        RichTextBox1.Text = ""

        ToolStripStatusLabel1.Visible = False
        ToolStripProgressBar1.Visible = False
    End Sub

    '退出按钮
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
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

    '返回DataSet
    Private Function sqlQuery_2(ByVal str As String) As DataSet
        Dim myConn As New MySqlConnection("Data Source = localhost;User ID = root;Password = 666666;Initial Catalog = library_management_system;")
        Dim myAdapter As New MySqlDataAdapter(str, myConn)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet, "myTable")

        sqlQuery_2 = myDataSet
    End Function

    Private Function ifExist(ByVal str As String) As Boolean
        Dim myConn As New MySqlConnection("Data Source = localhost;User ID = root;Password = 666666;Initial Catalog = library_management_system;")
        Dim myAdapter As New MySqlDataAdapter(str, myConn)
        Dim myDataSet As New DataSet
        Dim ifExistInt As Integer

        myAdapter.Fill(myDataSet, "myTable")
        ifExistInt = myDataSet.Tables("myTable").Rows(0).Item(0)

        If ifExistInt = 0 Then
            ifExist = False
        Else
            ifExist = True
        End If
    End Function
End Class