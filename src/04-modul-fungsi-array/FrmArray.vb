Public Class FrmArray
    Private Sub btnTampil_Click(sender As Object, e As EventArgs) Handles btnTampil.Click
        'MessageBox.Show(Hitung(Val(txtPanjang.Text), Val(txtLebar.Text)))

        For i As Integer = 0 To nilai.Length - 1
            lstNilai.Items.Add(nilai(i))
        Next
    End Sub

    Private Sub txtPanjang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPanjang.KeyPress
        HanyaAngka(e)
    End Sub

    Private Sub txtLebar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLebar.KeyPress
        HanyaAngka(e)
    End Sub
End Class
