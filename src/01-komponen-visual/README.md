# Pertemuan 2 - Komponen Visual

## 📖 Deskripsi

Modul ini adalah pengenalan pertama ke **Windows Forms** dalam Visual Basic .NET. Fokus utama adalah memahami komponen visual dasar dan cara kerja event-driven programming.

## 🎯 Tujuan Pembelajaran

- ✅ Memahami struktur dasar Windows Forms
- ✅ Menggunakan komponen visual: TextBox, Label, Button
- ✅ Memahami event handling (Click, TextChanged)
- ✅ Validasi input dasar
- ✅ Menggunakan MessageBox untuk output

## 📁 Struktur File

```
src/01-komponen-visual/
├── Form1.vb                 # Code-behind untuk form utama
├── Form1.Designer.vb       # Designer-generated code (UI layout)
├── Form1.resx               # Resource file
├── ApplicationEvents.vb     # Application-level events
├── My Project/              # Project settings
├── pertemuan2-komponen-visual.slnx  # Solution file
└── pertemuan2-komponen-visual.vbproj # Project file
```

## 🔍 Analisis Kode

### Form1.vb

```vb
Public Class Form1
    ' Event handler untuk tombol Tampilkan
    Private Sub BtnTampilkan_Click(sender As Object, e As EventArgs) Handles BtnTampilkan.Click
        MessageBox.Show("Eh Bujang !" & vbCrLf &
                        "Nama : " & TxtNama.Text & vbCrLf &
                        "NIM  : " & TxtNim.Text & vbCrLf &
                        "Kom  : " & TxtKom.Text)
    End Sub

    ' Event handler untuk tombol Hapus
    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        TxtNama.Clear()
        TxtKom.Clear()
        TxtNim.Clear()
    End Sub

    ' Event handler untuk tombol Keluar
    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        Me.Close()
    End Sub
End Class
```

### Penjelasan Komponen

| Komponen | Nama Control | Fungsi |
|----------|--------------|--------|
| TextBox | TxtNama | Input nama mahasiswa |
| TextBox | TxtNim | Input NIM mahasiswa |
| TextBox | TxtKom | Input Kom/Kelas |
| Button | BtnTampilkan | Menampilkan data input |
| Button | BtnHapus | Menghapus semua input |
| Button | BtnKeluar | Menutup aplikasi |

## 💡 Konsep Penting

### 1. Event Handling
Event handling adalah mekanisme di Windows Forms untuk merespon aksi user:

```vb
Private Sub BtnTampilkan_Click(sender As Object, e As EventArgs) Handles BtnTampilkan.Click
    ' Kode yang dijalankan saat tombol diklik
End Sub
```

- `sender`: Object yang memicu event (tombol)
- `e`: Event arguments berisi informasi event
- `Handles`: Keyword yang menghubungkan event dengan handler

### 2. MessageBox
MessageBox digunakan untuk menampilkan pesan ke user:

```vb
MessageBox.Show("Pesan di sini")
```

`vbCrLf` digunakan untuk baris baru (Carriage Return + Line Feed).

### 3. TextBox Properties
- `.Text`: Mengambil atau set nilai text
- `.Clear()`: Menghapus isi text
- `.Focus()`: Mengubah fokus ke control

### 4. Form Methods
- `.Close()`: Menutup form
- `.Show()`: Menampilkan form (modeless)
- `.ShowDialog()`: Menampilkan form (modal)

## 🚀 Cara Menjalankan

1. Buka file `pertemuan2-komponen-visual.slnx` di Visual Studio
2. Tekan **F5** atau klik **Start** untuk menjalankan
3. Masukkan Nama, NIM, dan Kom
4. Klik **Tampilkan** untuk melihat hasil
5. Klik **Hapus** untuk membersihkan input
6. Klik **Keluar** untuk menutup aplikasi

## 🎓 Latihan Tambahan

1. Tambahkan validasi agar semua field harus diisi sebelum tombol Tampilkan bisa diklik
2. Tambahkan tombol untuk men-copy data ke clipboard
3. Ubah warna background saat user meng-hover pada tombol
4. Tambahkan icon pada form

## 🔗 Hubungan dengan Pertemuan Lain

- **Pertemuan 3**: Lanjut dengan operator dan struktur kendali
- **Pertemuan 6**: Input form ini akan dikembangkan dengan database
- **Pertemuan 7**: Pattern input form yang sama digunakan di peminjaman buku

## 📝 Catatan Penting

- Nama control sebaiknya menggunakan prefix yang konsisten (txt untuk TextBox, btn untuk Button, lbl untuk Label)
- Event handler dibuat otomatis saat double-click pada control di Designer
- Code di Designer.vb jangan dimodifikasi manual karena akan di-overwrite oleh Designer

## 🐛 Troubleshooting

### Masalah: Tombol tidak berfungsi
**Solusi:** Pastikan `Handles` keyword ada dan nama event sesuai dengan nama control

### Masalah: TextBox tidak menerima input
**Solusi:** Cek property `Enabled` dan `ReadOnly` di Properties window

---

**Dokumentasi dibuat untuk Pertemuan 2 - Komponen Visual**
