# Pertemuan 4 - Perulangan

## 📖 Deskripsi

Modul ini mempelajari implementasi **perulangan (looping)** dalam Visual Basic .NET menggunakan statement `For...Next`. Aplikasi ini menampilkan urutan angka dari nilai awal ke nilai akhir dengan kemampuan ascending dan descending.

## 🎯 Tujuan Pembelajaran

- ✅ Memahami perulangan For...Next
- ✅ Menggunakan parameter Step untuk reverse loop
- ✅ Validasi input numeric
- ✅ Manipulasi ListBox
- ✅ Logic conditional untuk menentukan arah loop

## 📁 Struktur File

```
src/03-perulangan/
├── FrmPerulangan.vb        # Code-behind utama
├── FrmPerulangan.Designer.vb
├── FrmPerulangan.resx
├── ApplicationEvents.vb
├── My Project/
├── Pertemuan4-Perulangan.slnx
└── Pertemuan4-Perulangan.vbproj
```

## 🔍 Analisis Kode

### FrmPerulangan.vb

```vb
Public Class FrmPerulangan
    ' Validasi KeyPress untuk Nilai Awal
    Private Sub txtNilaiAwal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilaiAwal.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Validasi KeyPress untuk Nilai Akhir
    Private Sub txtNilaiAkhir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilaiAkhir.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Event handler tombol Input
    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
        Dim nilaiAwal As Integer
        Dim nilaiAkhir As Integer

        ' Validasi Nilai Awal
        If Not Integer.TryParse(txtNilaiAwal.Text, nilaiAwal) Then
            MessageBox.Show("Masukkan dalam bentuk angka!")
            txtNilaiAwal.Focus()
            Return
        End If

        ' Validasi Nilai Akhir
        If Not Integer.TryParse(txtNilaiAkhir.Text, nilaiAkhir) Then
            MessageBox.Show("Masukkan dalam bentuk angka!")
            txtNilaiAkhir.Focus()
            Return
        End If

        ' Bersihkan input dan hasil
        txtNilaiAwal.Clear()
        txtNilaiAkhir.Clear()
        lstHasil.Items.Clear()

        ' Logika perulangan dengan conditional
        If nilaiAwal < nilaiAkhir Then
            ' Ascending loop
            For i As Integer = nilaiAwal To nilaiAkhir
                lstHasil.Items.Add(i)
            Next
        Else
            ' Descending loop
            For i As Integer = nilaiAwal To nilaiAkhir Step -1
                lstHasil.Items.Add(i)
            Next
        End If
    End Sub
End Class
```

## 💡 Konsep Penting

### 1. For...Next Loop

**Syntax dasar:**
```vb
For counter As Integer = start To end [Step step]
    ' Kode yang diulang
Next [counter]
```

**Contoh ascending:**
```vb
For i As Integer = 1 To 10
    lstHasil.Items.Add(i)
Next
' Output: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
```

**Contoh descending:**
```vb
For i As Integer = 10 To 1 Step -1
    lstHasil.Items.Add(i)
Next
' Output: 10, 9, 8, 7, 6, 5, 4, 3, 2, 1
```

**Contoh dengan Step kustom:**
```vb
For i As Integer = 0 To 10 Step 2
    lstHasil.Items.Add(i)
Next
' Output: 0, 2, 4, 6, 8, 10
```

### 2. Parameter Step

- **Default Step:** 1 (ascending)
- **Step positif:** Ascending (1, 2, 3, ...)
- **Step negatif:** Descending (10, 9, 8, ...)
- **Step custom:** 2, 3, 5, dll (0, 2, 4, ...)

### 3. ListBox Operations

```vb
' Menambah item
lstHasil.Items.Add(item)

' Menghapus semua item
lstHasil.Items.Clear()

' Mengambil item pada index tertentu
Dim item As Object = lstHasil.Items(0)

' Menghitung jumlah item
Dim count As Integer = lstHasil.Items.Count

' Menghapus item pada index tertentu
lstHasil.Items.RemoveAt(0)
```

### 4. Conditional Logic untuk Arah Loop

```vb
If nilaiAwal < nilaiAkhir Then
    ' Ascending
    For i = nilaiAwal To nilaiAkhir
        ' ...
    Next
Else
    ' Descending
    For i = nilaiAwal To nilaiAkhir Step -1
        ' ...
    Next
End If
```

### 5. Tipe Perulangan Lain di VB.NET

| Tipe Loop | Syntax | Kegunaan |
|-----------|--------|----------|
| `For...Next` | `For i = 1 To 10` | Loop dengan counter |
| `For Each...Next` | `For Each item In collection` | Loop melalui collection |
| `Do While...Loop` | `Do While condition` | Loop selama kondisi True |
| `Do Until...Loop` | `Do Until condition` | Loop sampai kondisi True |
| `While...End While` | `While condition` | Loop selama kondisi True |

## 🎨 Alur Logika

```
┌─────────────────┐
│ Input Nilai Awal│
└────────┬────────┘
         ↓
┌─────────────────┐
│ Input Nilai Akhir│
└────────┬────────┘
         ↓
┌─────────────────┐
│ Validasi Angka? │───No──► MessageBox Error
└────────┬────────┘
         ↓ Yes
┌─────────────────┐
│ Bersihkan Input │
│ & ListBox       │
└────────┬────────┘
         ↓
┌─────────────────┐
│ Awal < Akhir?   │
└────────┬────────┘
    ↓ Yes      ↓ No
┌──────────┐  ┌──────────┐
│Ascending │  │Descending│
│  Loop    │  │  Loop    │
└────┬─────┘  └────┬─────┘
     ↓             ↓
┌─────────────────┐
│ Tampilkan di    │
│ ListBox         │
└─────────────────┘
```

## 🚀 Cara Menjalankan

1. Buka project di Visual Studio
2. Tekan **F5** untuk menjalankan
3. Masukkan Nilai Awal (contoh: 1)
4. Masukkan Nilai Akhir (contoh: 10)
5. Klik tombol **Input**
6. Hasil akan muncul di ListBox:
   - Jika Awal < Akhir: 1, 2, 3, ..., 10
   - Jika Awal > Akhir: 10, 9, 8, ..., 1

## 🎓 Latihan Tambahan

1. Tambahkan input untuk Step value (misal: 2 untuk genap)
2. Tampilkan jumlah total iterasi
3. Tambahkan opsi untuk tampilkan hanya bilangan ganjil/genap
4. Implementasikan Do While loop sebagai alternatif
5. Tambahkan animasi saat menambah item ke ListBox

## 🔗 Hubungan dengan Pertemuan Lain

- **Pertemuan 3**: Lanjut dari struktur kendali (If-Else)
- **Pertemuan 5**: Array akan digunakan dalam perulangan
- **Pertemuan 6**: Loop untuk iterasi database records

## 📝 Catatan Penting

- Selalu validasi input sebelum loop
- Hati-hati dengan infinite loop (pastikan kondisi stop tercapai)
- Gunakan `Step -1` untuk descending loop
- Bersihkan ListBox sebelum menambah data baru

## 🐛 Troubleshooting

### Masalah: Loop tidak berjalan
**Solusi:**
- Cek apakah nilai awal dan akhir valid
- Pastikan conditional logic benar (ascending vs descending)

### Masalah: ListBox tidak menampilkan hasil
**Solusi:**
- Pastikan `lstHasil.Items.Clear()` dipanggil sebelum loop
- Cek apakah ListBox visible dan enabled

### Masalah: Performance lambat untuk range besar
**Solusi:**
- Gunakan `lstHasil.BeginUpdate()` sebelum loop
- Gunakan `lstHasil.EndUpdate()` setelah loop
- Ini mencegah redraw setiap item ditambahkan

---

**Dokumentasi dibuat untuk Pertemuan 4 - Perulangan**
