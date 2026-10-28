# Pertemuan 5 - Modul, Fungsi, & Array

## 📖 Deskripsi

Modul ini mempelajari **modularisasi kode** menggunakan Module, **fungsi reusable**, dan **array** (1D dan 2D) dalam Visual Basic .NET. Konsep ini penting untuk membuat kode yang lebih rapi, reusable, dan mudah dimaintain.

## 🎯 Tujuan Pembelajaran

- ✅ Memahami konsep Module di VB.NET
- ✅ Membuat fungsi dan subprocedure reusable
- ✅ Menggunakan array 1 dimensi
- ✅ Menggunakan array 2 dimensi
- ✅ Memanggil fungsi dari module di form
- ✅ Validasi input dengan fungsi modul

## 📁 Struktur File

```
src/04-modul-fungsi-array/
├── FrmArray.vb              # Form utama
├── FrmArray.Designer.vb
├── FrmArray.resx
├── ModArray.vb              # Module berisi fungsi dan array
├── ApplicationEvents.vb
├── My Project/
├── pertemuan5-modul-fungsi-array.slnx
└── pertemuan5-modul-fungsi-array.vbproj
```

## 🔍 Analisis Kode

### ModArray.vb (Module)

```vb
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

    ' Array 1 Dimensi
    Public nilai() As Integer = {50, 60, 70, 80, 90}

    ' Array 2 Dimensi
    Public nilai2d(,) As Integer = {
        {55, 58, 60},
        {65, 67, 69},
        {78, 85, 90}
    }
End Module
```

### FrmArray.vb (Form)

```vb
Public Class FrmArray
    Private Sub btnTampil_Click(sender As Object, e As EventArgs) Handles btnTampil.Click
        ' Menampilkan array 1D ke ListBox
        For i As Integer = 0 To nilai.Length - 1
            lstNilai.Items.Add(nilai(i))
        Next
    End Sub

    ' Menggunakan fungsi dari module untuk validasi
    Private Sub txtPanjang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPanjang.KeyPress
        HanyaAngka(e)
    End Sub

    Private Sub txtLebar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLebar.KeyPress
        HanyaAngka(e)
    End Sub
End Class
```

## 💡 Konsep Penting

### 1. Module di VB.NET

Module adalah kontainer untuk kode yang dapat diakses secara global di seluruh project.

**Keuntungan Module:**
- Member dan function bersifat `Public` secara default
- Tidak perlu instance (tidak perlu `New`)
- Dapat diakses dari mana saja tanpa prefix class

**Syntax:**
```vb
Module NamaModule
    ' Variabel, fungsi, subprocedure
End Module
```

### 2. Function vs Sub

| Fitur | Function | Sub |
|-------|----------|-----|
| Return value | Ya | Tidak |
| Keyword | `Function` | `Sub` |
| Usage | Untuk kalkulasi | Untuk aksi |
| Return statement | `Return value` | Tidak ada |

**Contoh Function:**
```vb
Public Function Hitung(a As Integer, b As Integer) As Integer
    Return a + b
End Function
```

**Contoh Sub:**
```vb
Public Sub BersihkanTextBox()
    txtInput.Clear()
End Sub
```

### 3. Access Modifiers

| Modifier | Scope | Kegunaan |
|----------|-------|----------|
| `Public` | Global | Dapat diakses dari mana saja |
| `Private` | Local | Hanya dalam class/module |
| `Friend` | Assembly | Hanya dalam project yang sama |
| `Protected` | Inheritance | Hanya class turunan |

### 4. Array 1 Dimensi

**Deklarasi:**
```vb
' Cara 1: Dengan nilai awal
Public nilai() As Integer = {50, 60, 70, 80, 90}

' Cara 2: Dengan size
Public nilai(4) As Integer  ' Index 0-4 (5 elemen)
```

**Akses Elemen:**
```vb
Dim pertama As Integer = nilai(0)  ' 50
Dim kedua As Integer = nilai(1)   ' 60
```

**Iterasi Array:**
```vb
For i As Integer = 0 To nilai.Length - 1
    Console.WriteLine(nilai(i))
Next
```

**Properties Array:**
- `.Length`: Jumlah elemen
- `.Rank`: Dimensi array
- `.GetUpperBound(0)`: Index maksimum dimensi 0

### 5. Array 2 Dimensi

**Deklarasi:**
```vb
Public nilai2d(,) As Integer = {
    {55, 58, 60},  ' Baris 0
    {65, 67, 69},  ' Baris 1
    {78, 85, 90}   ' Baris 2
}
```

**Visualisasi:**
```
      Kolom 0  Kolom 1  Kolom 2
Baris 0   55       58       60
Baris 1   65       67       69
Baris 2   78       85       90
```

**Akses Elemen:**
```vb
Dim elemen As Integer = nilai2d(1, 2)  ' Baris 1, Kolom 2 = 69
```

**Iterasi Array 2D:**
```vb
For baris As Integer = 0 To nilai2d.GetUpperBound(0)
    For kolom As Integer = 0 To nilai2d.GetUpperBound(1)
        Console.WriteLine(nilai2d(baris, kolom))
    Next
Next
```

### 6. Reusability dengan Module

**Sebelum (duplikasi kode):**
```vb
' Di setiap TextBox KeyPress
Private Sub txt1_KeyPress(sender As Object, e As KeyPressEventArgs)
    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
        e.Handled = True
    End If
End Sub

Private Sub txt2_KeyPress(sender As Object, e As KeyPressEventArgs)
    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
        e.Handled = True
    End If
End Sub
```

**Sesudah (reusable):**
```vb
' Di Module
Public Sub HanyaAngka(e As KeyPressEventArgs)
    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
        e.Handled = True
    End If
End Sub

' Di Form
Private Sub txt1_KeyPress(sender As Object, e As KeyPressEventArgs)
    HanyaAngka(e)
End Sub

Private Sub txt2_KeyPress(sender As Object, e As KeyPressEventArgs)
    HanyaAngka(e)
End Sub
```

## 🎨 Struktur Array

### Array 1D (nilai)
```
Index:   0    1    2    3    4
Value:  50   60   70   80   90
```

### Array 2D (nilai2d)
```
          Col0  Col1  Col2
Row0:     55    58    60
Row1:     65    67    69
Row2:     78    85    90
```

## 🚀 Cara Menjalankan

1. Buka project di Visual Studio
2. Tekan **F5** untuk menjalankan
3. Klik tombol **Tampil** untuk menampilkan array 1D di ListBox
4. Coba input di TextBox Panjang dan Lebar (hanya angka yang diterima)

## 🎓 Latihan Tambahan

1. Tambahkan fungsi untuk menghitung rata-rata array
2. Buat fungsi untuk mencari nilai maksimum/minimum array
3. Implementasikan array 2D untuk menampilkan data mahasiswa (NIM, Nama, Nilai)
4. Tambahkan fungsi untuk sorting array
5. Buat fungsi dengan parameter optional

## 🔗 Hubungan dengan Pertemuan Lain

- **Pertemuan 4**: Array digunakan dalam perulangan
- **Pertemuan 6**: Module untuk database connection dan query
- **Pertemuan 8**: Array/DataTable untuk inventaris buku

## 📝 Catatan Penting

- Module member bersifat global, hati-hati dengan naming conflict
- Array index di VB.NET dimulai dari 0
- Gunakan `.Length` untuk jumlah elemen, bukan index maksimum
- Function harus memiliki return value, Sub tidak

## 🐛 Troubleshooting

### Masalah: Fungsi module tidak dikenali di form
**Solusi:**
- Pastikan module ada di project yang sama
- Cek access modifier (harus Public)
- Rebuild project

### Masalah: Index out of range
**Solusi:**
- Gunakan `.Length - 1` untuk index maksimum
- Atau gunakan `.GetUpperBound(0)` untuk array multidimensi

### Masalah: Array kosong saat diakses
**Solusi:**
- Pastikan array di-inisialisasi dengan nilai
- Cek apakah array di-deklarasi dengan nilai awal

---

**Dokumentasi dibuat untuk Pertemuan 5 - Modul, Fungsi, & Array**
