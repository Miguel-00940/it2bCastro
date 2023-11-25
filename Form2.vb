Public Class Form2
    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Form1.Show()
        Me.Hide()

    End Sub

    Private Sub Form2Load_Load(sender As Object, e As EventArgs) Handles Me.Load
        ConnectionDbase()
        LoadCourse()
        LoadAlldata() 'load all the data from database
        With dgvData

            .AutoResizeColumns()
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .RowsDefaultCellStyle.BackColor = Color.LightBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue
        End With
    End Sub

    Private Sub LoadAlldata()

    End Sub

    Private Sub btndisplay_Click(sender As Object, e As EventArgs) Handles btndisplay.Click
        If Cbocourse.SelectedIndex = 0 Then
            DisplayData("bsit")
        ElseIf Cbocourse.SelectedIndex = 1 Then
            DisplayData("bscs")
        ElseIf Cbocourse.SelectedIndex = 2 Then
            DisplayData("coa")
        ElseIf Cbocourse.SelectedIndex = 3 Then
            DisplayData("cba")
        End If
        MsgBox("no record found")

    End Sub
End Class