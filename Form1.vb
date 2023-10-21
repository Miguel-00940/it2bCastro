Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    ConnectionDbase()
    txtfirst.Enabled = False
    txtlast.Enabled = False
    txtstudcourse.Enabled = False
End Sub

Private Sub btnrecord_Click(sender As Object, e As EventArgs) Handles btnrecord.Click
        SaveRecord()

    End Sub
End Class
