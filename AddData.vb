Imports MySql.Data.MySqlClient

Public Class AddData

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

    '文本框5只能输入数字和BACKSPACE键
    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    '添加按钮
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Text = "添加图书信息" Then
            Dim BookId = TextBox1.Text
            Dim BookName = TextBox2.Text
            Dim Author = TextBox3.Text
            Dim Publisher = TextBox4.Text
            Dim Note = RichTextBox1.Text

            If BookId <> "" And BookName <> "" And Author <> "" And Publisher <> "" Then
                If BookId.Length > 10 Then
                    MsgBox("请输入正确的图书编号", MsgBoxStyle.Exclamation, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                ElseIf BookName.Length > 30 Then
                    MsgBox("请输入正确的图书名称", MsgBoxStyle.Exclamation, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                ElseIf Author.Length > 20 Then
                    MsgBox("请输入正确的作者姓名", MsgBoxStyle.Exclamation, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                ElseIf Publisher.Length > 20 Then
                    MsgBox("请输入正确的出版社", MsgBoxStyle.Exclamation, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                Else
                    Dim myCmdStr As String = "select count(*) from Books where BookID = '" + BookId + "';"
                    Dim myDataSet = sqlQuery(myCmdStr)
                    Dim ifExist As String = myDataSet.Tables("myTable").Rows(0).Item(0).ToString

                    If ifExist = "1" Then
                        MsgBox("图书编号已存在", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    Else
                        ToolStripStatusLabel1.Visible = True
                        ToolStripStatusLabel1.Text = "添加图书信息中..."

                        ToolStripProgressBar1.Value = 0
                        ToolStripProgressBar1.Visible = True
                        ToolStripProgressBar1.Maximum = 1

                        myCmdStr = "insert Books values('" + BookId + "','" + BookName + "','" +
                                    Author + "','" + Publisher + "','" + Note + "');"
                        sqlQuery(myCmdStr)

                        ToolStripProgressBar1.PerformStep()

                        ToolStripStatusLabel1.Text = "图书信息添加成功"
                    End If
                End If
            Else
                MsgBox("请输入所有必填信息", MsgBoxStyle.Exclamation, "错误")
                ToolStripStatusLabel1.Visible = False
                ToolStripProgressBar1.Visible = False
            End If

        ElseIf Text = "添加学生信息" Then
            Dim CardId = TextBox1.Text
            Dim StuName = TextBox2.Text
            Dim Age = TextBox3.Text
            Dim Sex = TextBox4.Text
            Dim Phone = TextBox5.Text
            Dim Email = TextBox6.Text
            Dim Note = RichTextBox1.Text

            If CardId <> "" And StuName <> "" And Age <> "" And Sex <> "" Then
                If CardId.Length <> 13 Then
                    MsgBox("请输入正确的借书卡号", MsgBoxStyle.Exclamation, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                ElseIf StuName.Length > 10 Then
                    MsgBox("请输入正确的学生姓名", MsgBoxStyle.Exclamation, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                ElseIf Age <> "" AndAlso (Not IsNumeric(Age) OrElse (IsNumeric(Age) AndAlso (CInt(Age) < 0 OrElse CInt(Age) > 127))) Then
                    MsgBox("请输入正确的学生年龄", MsgBoxStyle.Exclamation, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                ElseIf Sex <> "男" And Sex <> "女" Then
                    MsgBox("请输入正确的学生性别", MsgBoxStyle.Exclamation, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                ElseIf Phone.Length > 11 Then
                    MsgBox("请输入正确的电话号码", MsgBoxStyle.Exclamation, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                ElseIf Email.Length > 20 Then
                    MsgBox("请输入正确的邮箱地址", MsgBoxStyle.Exclamation, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                Else
                    Dim myCmdStr As String = "select count(*) from Students where LibraryCardID = '" + CardId + "';"
                    Dim myDataSet = sqlQuery(myCmdStr)
                    Dim ifExist As String = myDataSet.Tables("myTable").Rows(0).Item(0).ToString

                    If ifExist = "1" Then
                        MsgBox("借书卡号已存在", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    Else
                        ToolStripStatusLabel1.Visible = True
                        ToolStripStatusLabel1.Text = "添加学生信息中..."

                        ToolStripProgressBar1.Value = 0
                        ToolStripProgressBar1.Visible = True
                        ToolStripProgressBar1.Maximum = 1

                        myCmdStr = "insert Students values('" + CardId + "','" + StuName + "','" + Age + "','" +
                                    Sex + "','" + Phone + "','" + Email + "','" + Note + "');"
                        sqlQuery(myCmdStr)

                        ToolStripProgressBar1.PerformStep()

                        ToolStripStatusLabel1.Text = "学生信息添加成功"
                    End If
                End If
            Else
                MsgBox("请输入所有必填信息", MsgBoxStyle.Exclamation, "错误")
                ToolStripStatusLabel1.Visible = False
                ToolStripProgressBar1.Visible = False
            End If

        ElseIf Text = "添加借阅信息" Then
            Dim CardId = TextBox1.Text
            Dim BookId = TextBox2.Text
            Dim BorrowDate = TextBox3.Text
            Dim ReturnDate = TextBox4.Text
            Dim Note = RichTextBox1.Text

            If CardId <> "" And BookId <> "" And BorrowDate <> "" And ReturnDate <> "" Then
                Dim myCmdStr As String
                Dim myDataSet As DataSet
                If CardId.Length <> 13 Then
                    MsgBox("请输入正确的借书卡号", MsgBoxStyle.Exclamation, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                ElseIf CardId.Length = 13 Then
                    myCmdStr = "select count(*) from Students where LibraryCardID = '" + CardId + "';"
                    myDataSet = sqlQuery(myCmdStr)
                    Dim ifExist As String = myDataSet.Tables("myTable").Rows(0).Item(0).ToString
                    If ifExist = "0" Then
                        MsgBox("借书卡号不存在", MsgBoxStyle.Exclamation, "错误")
                        ToolStripStatusLabel1.Visible = False
                        ToolStripProgressBar1.Visible = False
                    Else
                        If BookId.Length > 10 Then
                            MsgBox("请输入正确的图书编号", MsgBoxStyle.Exclamation, "错误")
                            ToolStripStatusLabel1.Visible = False
                            ToolStripProgressBar1.Visible = False
                        ElseIf BookId.Length <= 10 Then
                            myCmdStr = "select count(*) from Books where BookID = '" + BookId + "';"
                            myDataSet = sqlQuery(myCmdStr)
                            ifExist = myDataSet.Tables("myTable").Rows(0).Item(0).ToString
                            If ifExist = "0" Then
                                MsgBox("图书编号不存在", MsgBoxStyle.Exclamation, "错误")
                                ToolStripStatusLabel1.Visible = False
                                ToolStripProgressBar1.Visible = False
                            Else
                                If Not IsDate(BorrowDate) Then
                                    MsgBox("请输入正确的借书日期", MsgBoxStyle.Exclamation, "错误")
                                    ToolStripStatusLabel1.Visible = False
                                    ToolStripProgressBar1.Visible = False
                                ElseIf Not IsDate(ReturnDate) Then
                                    MsgBox("请输入正确的应还日期", MsgBoxStyle.Exclamation, "错误")
                                    ToolStripStatusLabel1.Visible = False
                                    ToolStripProgressBar1.Visible = False
                                Else
                                    myCmdStr = "select count(*) from BorrowInfo where LibraryCardID = '" +
                                                              CardId + "' and BookID = '" + BookId + "';"
                                    myDataSet = sqlQuery(myCmdStr)
                                    ifExist = myDataSet.Tables("myTable").Rows(0).Item(0).ToString

                                    If ifExist = "1" Then
                                        MsgBox("借书卡号和图书编号已存在", MsgBoxStyle.Exclamation, "错误")
                                        ToolStripStatusLabel1.Visible = False
                                        ToolStripProgressBar1.Visible = False
                                    Else
                                        ToolStripStatusLabel1.Visible = True
                                        ToolStripStatusLabel1.Text = "添加借阅信息中..."

                                        ToolStripProgressBar1.Value = 0
                                        ToolStripProgressBar1.Visible = True
                                        ToolStripProgressBar1.Maximum = 1

                                        myCmdStr = "insert BorrowInfo values('" + CardId + "','" + BookId + "','" +
                                                    BorrowDate + "','" + ReturnDate + "','" + Note + "');"
                                        sqlQuery(myCmdStr)

                                        ToolStripProgressBar1.PerformStep()

                                        ToolStripStatusLabel1.Text = "借阅信息添加成功"
                                    End If
                                End If
                            End If
                        End If
                    End If
                Else
                    MsgBox("请输入所有必填信息", MsgBoxStyle.Exclamation, "错误")
                    ToolStripStatusLabel1.Visible = False
                    ToolStripProgressBar1.Visible = False
                End If
            End If
        End If
    End Sub

    '清除按钮
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        RichTextBox1.Text = ""

        ToolStripStatusLabel1.Visible = False
        ToolStripProgressBar1.Visible = False
    End Sub

    '退出按钮
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    'num：0--图书，1--学生，2--借阅
    Public Function sqlQuery(ByVal str As String) As DataSet
        Dim myConn As New MySqlConnection("Data Source = localhost;User ID = root;Password = 666666;Initial Catalog = library_management_system;")
        Dim myAdapter As New MySqlDataAdapter(str, myConn)
        Dim myDataSet As New DataSet
        myAdapter.Fill(myDataSet, "myTable")

        sqlQuery = myDataSet
    End Function
End Class