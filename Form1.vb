Imports Microsoft.VisualBasic.ApplicationServices

Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConnectionDbase()
        txtfirst.Enabled = False
        txtlast.Enabled = False
        txtstudcourse.Enabled = False
        btnupdate.Enabled = False
        btndelete.Enabled = False
    End Sub

    Private Sub btnrecord_Click(sender As Object, e As EventArgs) Handles btnrecord.Click
        SaveRecord()

    End Sub

    Private Sub btndisplay_Click(sender As Object, e As EventArgs) Handles btndisplay.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Dim ans As DialogResult = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNo)
        If ans = DialogResult.Yes Then
            DeleteRecord(txtuserId.Text)
            MsgBox("Deletion successfull!")
        Else
            MsgBox("Deletion cancelled!")

        End If
    End Sub
End Class

