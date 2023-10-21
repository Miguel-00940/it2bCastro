Imports System.Configuration
Imports MySql.Data.MySqlClient
Module Module1
    Dim con As New MySqlConnection
    Dim reader As MySqlDataReader
    Dim mysqlcmd As New MySqlCommand
    Dim host, uname, pwd, dbname As String
    Dim sqlquery As String
    Public Sub ConnectionDbase()
        host = "127.0.0.1"
        dbname = "it2boop"
        uname = "root"
        pwd = "password" 'password
        'Check if connection is open
        If Not con Is Nothing Then
            con.Close() 'close the dbaseconnection
            'connection string signature
            con.ConnectionString = "server =" & host & "; user id=" &
                uname & "; password =" & pwd & "; database =" & dbname & ""
            Try
                'open the connection
                con.Open()
                MessageBox.Show("Connection")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Public Sub SaveRecord()
        Dim fname, lname, Course As String
        fname = Form1.txtfname.Text 'get value from form1.textboxes
        lname = Form1.txtlname.Text
        Course = Form1.txtcourse.Text
        sqlquery = "INSERT INTO student(studFName, studLName, course) 
VALUES(@fname, @lname, course)"
        'pass the query and conncetion to mysqlcommand
        mysqlcmd = New MySqlCommand(sqlquery, con)
        'add the parameter value
        mysqlcmd.Parameters.AddWithValue("@fname", fname)
        mysqlcmd.Parameters.AddWithValue("@lname", lname)
        mysqlcmd.Parameters.AddWithValue("@course", Course)

        Try
            'execute the sql query command
            mysqlcmd.ExecuteNonQuery()
            MsgBox("Record save successfully!")
        Catch ex As Exception
            MessageBox.Show("Error" & ex.Message)

        Finally
            TextClear()

        End Try
    End Sub

    Sub textclear()
        Form1.txtfname.Clear()
        Form1.txtlname.Clear()
        Form1.txtcourse.Clear()
    End Sub

    Public Sub SearchData()
        Dim uid As String
        uid = Form1.txtuserid.text
        sqlquery = "SELECT * FROM student where studID = @uid"
        mysqlcmd = New MySqlCommand(sqlquery, con)
        mysqlcmd.Parameters.AddWithValue("@uid", uid)
        Try
            reader = mysqlcmd.ExecuteReader()
            If reader.Read Then
                Form1.txtfirst.text = reader("studFName").ToString()
                Form1.txtlast.text = reader("studlName").ToString()
                Form1.txtcourse.Text = reader("course").ToString()

            Else
                MsgBox("No Record")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            reader.Close()
        End Try
    End Sub
End Module
