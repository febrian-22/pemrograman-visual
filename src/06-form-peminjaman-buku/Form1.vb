Public Class Form1
    Private Sub lblNama_Click(sender As Object, e As EventArgs) Handles lblNama.Click

    End Sub

    Private Sub txtNama_TextChanged(sender As Object, e As EventArgs) Handles TxtNama.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles LblKom.Click

    End Sub

    Private Sub BtnTampilkan_Click(sender As Object, e As EventArgs) Handles BtnTampilkan.Click
        MessageBox.Show("Eh Bujang !" & vbCrLf &
                        "Nama : " & TxtNama.Text & vbCrLf &
                        "NIM  : " & TxtNim.Text & vbCrLf &
                        "Kom  : " & TxtKom.Text
     )


    End Sub

    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        TxtNama.Clear()
        TxtKom.Clear()
        TxtNim.Clear()


    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        Me.Close()

    End Sub
End Class
