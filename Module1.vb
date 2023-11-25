Imports System.Configuration
Imports System.Security.Cryptography.X509Certificates
Imports K4os.Compression.LZ4.Streams
Imports Microsoft.VisualBasic.Devices
Imports MySql.Data.MySqlClient
Module Module1
    Dim con As New MySqlConnection
    Dim reader As MySqlDataReader
    Dim mysqlcmd As New MySqlCommand
    Dim host, uname, pwd, dbname As String
    Dim sqlquery As String
    Dim dtTable As New DataTable
    Dim adapter As New MySqlDataAdapter
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
            textclear()

        End Try
    End Sub

    Sub textclear()
        Form1.txtfname.Clear()
        Form1.txtlname.Clear()
        Form1.txtcourse.Clear()
    End Sub

    Public Sub SearchData()
        Dim uid As String
        uid = Form1.txtuserId.Text
        sqlquery = "SELECT * FROM student where studID = @uid"
        mysqlcmd = New MySqlCommand(sqlquery, con)
        mysqlcmd.Parameters.AddWithValue("@uid", uid)
        Try
            reader = mysqlcmd.ExecuteReader()
            If reader.Read Then
                Form1.txtfirst.Text = reader("studFName").ToString()
                Form1.txtlast.Text = reader("studlName").ToString()
                Form1.txtcourse.Text = reader("course").ToString()
                Form1.btndelete.Enabled = True
                Form1.btnupdate.Enabled = True
                Form1.txtfirst.Enabled = True
                Form1.txtlast.Enabled = True
                Form1.txtcourse.Enabled = True
                Form1.txtstudcourse.Enabled = True


            Else
                MsgBox("No Record")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            reader.Close()
        End Try
    End Sub
    Public Sub LoadData()
        sqlquery = "SELECT * FROM student"
        adapter = New MySqlDataAdapter(sqlquery, con)
        Try
            'display the record in your datagridview
            dtTable = New DataTable
            adapter.Fill(dtTable) 'pass the record from mysql to data table
            With Form2.dgvData
                .DataSource = dtTable 'set the course of datagridview
                .AutoResizeColumns()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub LoadCourse()
        sqlquery = "SELECT course from student"
        Try
            mysqlcmd = New MySqlCommand(sqlquery, con)
            reader = mysqlcmd.ExecuteReader
            While reader.Read
                Form2.Cbocourse.Items.Add(reader("course").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub
    Public Sub LoadAlldata()
        sqlquery = "SELECT * FROM student"
        adapter = New MySqlDataAdapter(sqlquery, con)
        Try
            'display the record in your datagridview
            dtTable = New DataTable
            adapter.Fill(dtTable) 'pass the record from mysql to data table
            With Form2.dgvData
                .DataSource = dtTable 'set the course of datagridview
                .AutoResizeColumns()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub DisplayData(kurso As String)

    End Sub


    Public Sub UpdateRecord(studID As String, fname As String, lname As String, course As String)
        sqlquery = "UPDATE student set studFname = @fname, studLname = @lname, course = @course, studID = @studID"
        Try
            Using cmd As New MySqlCommand(sqlquery, con)
                cmd.Parameters.AddWithValue("@fname", fname)
                cmd.Parameters.AddWithValue("@lname", lname)
                cmd.Parameters.AddWithValue("@course", course)
                cmd.Parameters.AddWithValue("@studID", studid)
                cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbInformation, "Error Message")
        Finally
            Form1.txtfirst.Clear()
            Form1.txtlast.Clear()
            Form1.txtstudcourse.Clear()
            Form1.txtuserId.Clear()
        End Try
    End Sub

    Public Sub DeleteRecord(studid As String)
        sqlquery = "delete from student where studID = @studID"
        Try

            Using cmd As New MySqlCommand(sqlquery, con)
                cmd.Parameters.AddWithValue("@studID", studid)
                cmd.ExecuteNonQuery()

            End Using
            MsgBox("deletion successfull!", vbInformation, "Delete Message")
        Catch ex As Exception
            MsgBox("Error: & ex.Message", vbInformation, "Error Message")
        Finally
            Form1.txtfirst.Clear()
            Form1.txtlast.Clear()
            Form1.txtstudcourse.Clear()
        Form1.txtuserId.Clear()
        End Try
    End Sub
End Module
