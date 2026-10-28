# Pertemuan 3 - Operator & Struktur Kendali

## 📖 Deskripsi

Modul ini mempelajari penggunaan **operator** dan **struktur kendali** (If-ElseIf-Else) dalam Visual Basic .NET. Aplikasi ini mengkonversi nilai ujian menjadi feedback visual berupa gambar.

## 🎯 Tujuan Pembelajaran

- ✅ Memahami operator perbandingan dan logika
- ✅ Menggunakan struktur kendali If-ElseIf-Else
- ✅ Validasi input dengan Integer.TryParse
- ✅ KeyPress validation untuk input angka
- ✅ Manipulasi gambar dengan PictureBox
- ✅ Error handling dasar

## 📁 Struktur File

```
src/02-operator-struktur-kendali/
├── Form1.vb                 # Code-behind utama
├── Form1.Designer.vb       # Designer-generated code
├── Form1.resx               # Resource file
├── ApplicationEvents.vb     # Application events
├── My Project/              # Project settings
├── assets/                  # Folder gambar (1.jpg, 2.jpg, 3.jpg)
├── Pertemuan3-Operator-Struktur-Kendali.slnx
└── Pertemuan3-Operator-Struktur-Kendali.vbproj
```

## 🔍 Analisis Kode

### Form1.vb

```vb
Public Class Form1
    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
        Dim nilaiUjian As Integer

        ' Validasi: Cek apakah input adalah angka
        If Not Integer.TryParse(txtNilai.Text, nilaiUjian) Then
            MessageBox.Show("Masukkan dalam bentuk angka!")
            txtNilai.Focus()
            Return
        End If

        ' Validasi: Cek range nilai (0-100)
        If nilaiUjian < 0 OrElse nilaiUjian > 100 Then
            MessageBox.Show("Masukkan nilai 0 - 100")
            txtNilai.Focus()
            Return
        End If

        ' Logika konversi nilai ke gambar
        If nilaiUjian <= 50 Then
            picImage.Image = Image.FromFile("assets\1.jpg")
        ElseIf nilaiUjian <= 75 Then
            picImage.Image = Image.FromFile("assets\2.jpg")
        Else
            picImage.Image = Image.FromFile("assets\3.jpg")
        End If
    End Sub

    ' Validasi KeyPress: Hanya menerima angka
    Private Sub txtNilai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilai.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class
```

## 💡 Konsep Penting

### 1. Operator Perbandingan

| Operator | Deskripsi | Contoh |
|----------|-----------|--------|
| `=` | Sama dengan | `nilai = 100` |
| `<>` | Tidak sama dengan | `nilai <> 0` |
| `<` | Lebih kecil dari | `nilai < 50` |
| `>` | Lebih besar dari | `nilai > 75` |
| `<=` | Lebih kecil atau sama dengan | `nilai <= 50` |
| `>=` | Lebih besar atau sama dengan | `nilai >= 0` |

### 2. Operator Logika

| Operator | Deskripsi | Contoh |
|----------|-----------|--------|
| `And` | Keduanya harus True | `nilai > 0 And nilai < 100` |
| `Or` | Salah satu True sudah cukup | `nilai < 0 Or nilai > 100` |
| `AndAlso` | Short-circuit And | `nilai > 0 AndAlso nilai < 100` |
| `OrElse` | Short-circuit Or | `nilai < 0 OrElse nilai > 100` |
| `Not` | Negasi | `Not valid` |

**Perbedaan And vs AndAlso:**
- `And`: Mengevaluasi kedua sisi walaupun sisi pertama sudah False
- `AndAlso`: Stop evaluasi jika sisi pertama False (lebih efisien)

### 3. Struktur Kendali If-ElseIf-Else

```vb
If kondisi1 Then
    ' Kode jika kondisi1 True
ElseIf kondisi2 Then
    ' Kode jika kondisi1 False dan kondisi2 True
Else
    ' Kode jika semua kondisi False
End If
```

### 4. Integer.TryParse

```vb
Dim nilai As Integer
If Integer.TryParse(inputString, nilai) Then
    ' Input valid, nilai tersimpan di variabel
Else
    ' Input tidak valid
End If
```

Keuntungan `TryParse`:
- Tidak throw exception jika gagal
- Mengembalikan Boolean (True jika berhasil, False jika gagal)
- Lebih aman daripada `CInt()` atau `Convert.ToInt32()`

### 5. KeyPress Validation

```vb
Private Sub txtNilai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilai.KeyPress
    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
        e.Handled = True  ' Blokir karakter
    End If
End Sub
```

- `Char.IsControl(e.KeyChar)`: Mengizinkan control key (Backspace, Delete, Enter)
- `Char.IsDigit(e.KeyChar)`: Mengizinkan digit 0-9
- `e.Handled = True`: Membatalkan karakter yang ditekan

### 6. PictureBox & Image

```vb
picImage.Image = Image.FromFile("path\to\image.jpg")
```

**Tips:**
- Pastikan path gambar benar
- Gunakan relative path jika gambar di folder project
- Handle exception jika file tidak ditemukan

## 🎨 Alur Logika

```
┌─────────────────┐
│ User Input Nilai│
└────────┬────────┘
         ↓
┌─────────────────┐
│ Is Angka?       │───No──► MessageBox Error ──► Return
└────────┬────────┘
         ↓ Yes
┌─────────────────┐
│ Range 0-100?    │───No──► MessageBox Error ──► Return
└────────┬────────┘
         ↓ Yes
┌─────────────────┐
│ Nilai ≤ 50?     │───Yes──► Tampilkan Gambar 1
└────────┬────────┘
         ↓ No
┌─────────────────┐
│ Nilai ≤ 75?     │───Yes──► Tampilkan Gambar 2
└────────┬────────┘
         ↓ No
┌─────────────────┐
│ Tampilkan       │
│ Gambar 3        │
└─────────────────┘
```

## 🚀 Cara Menjalankan

1. Pastikan folder `assets/` berisi 3 gambar (1.jpg, 2.jpg, 3.jpg)
2. Buka project di Visual Studio
3. Tekan **F5** untuk menjalankan
4. Masukkan nilai (0-100)
5. Klik tombol Input
6. Gambar akan muncul sesuai nilai:
   - 0-50 → 1.jpg
   - 51-75 → 2.jpg
   - 76-100 → 3.jpg

## 🎓 Latihan Tambahan

1. Tambahkan validasi agar gambar hanya berubah jika input berbeda dari sebelumnya
2. Tambahkan label yang menampilkan deskripsi nilai (Kurang, Cukup, Baik, Sangat Baik)
3. Implementasikan Select Case sebagai alternatif If-ElseIf
4. Tambahkan exception handling jika file gambar tidak ditemukan
5. Buat animasi transisi antar gambar

## 🔗 Hubungan dengan Pertemuan Lain

- **Pertemuan 2**: Lanjut dari komponen visual dasar
- **Pertemuan 4**: Lanjut dengan perulangan untuk multiple nilai
- **Pertemuan 5**: Fungsi validasi akan dipindah ke modul

## 📝 Catatan Penting

- Selalu validasi input sebelum diproses
- Gunakan `TryParse` untuk konversi string ke angka
- Gunakan `AndAlso`/`OrElse` untuk short-circuit evaluation
- Path gambar sebaiknya menggunakan `Application.StartupPath` untuk portabilitas

## 🐛 Troubleshooting

### Masalah: Gambar tidak muncul
**Solusi:**
- Cek apakah folder `assets/` ada di folder bin/Debug
- Pastikan nama file gambar sesuai (1.jpg, 2.jpg, 3.jpg)
- Gunakan full path atau relative path dari executable

### Masalah: Input tidak bisa dihapus
**Solusi:**
- Pastikan `Char.IsControl(e.KeyChar)` ada di validasi KeyPress
- Ini mengizinkan Backspace dan Delete

### Masalah: Exception saat load gambar
**Solusi:**
- Tambahkan Try-Catch di sekitar `Image.FromFile()`
- Cek apakah file gambar ada sebelum load

---

**Dokumentasi dibuat untuk Pertemuan 3 - Operator & Struktur Kendali**
