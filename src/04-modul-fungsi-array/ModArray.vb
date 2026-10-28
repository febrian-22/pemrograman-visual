Module ModArray
    ' Fungsi pembatas input angka
    Public Sub HanyaAngka(e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Fungsi Hitung sederhana
    Public Function Hitung(panjang As Integer, lebar As Integer) As String
        If panjang * lebar < 50 Then
            Return "Keliling = " & (2 * (panjang + lebar)).ToString()
        Else
            Return "Luas = " & (panjang * lebar).ToString()
        End If
    End Function

    Public nilai() As Integer = {50, 60, 70, 80, 90}
    Public nilai2d(,) As Integer = {
        {55, 58, 60},
        {65, 67, 69},
        {78, 85, 90}
    }
End Module
