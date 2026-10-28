# Pertemuan 7 - Form Peminjaman Buku

## 📖 Deskripsi

**CATATAN PENTING:** Pertemuan 7 saat ini masih menggunakan template dari Pertemuan 2 (form input mahasiswa). Modul ini perlu dikembangkan menjadi aplikasi **peminjaman buku** yang sesungguhnya dengan integrasi database.

## 🎯 Tujuan Pembelajaran (Direncanakan)

- ✅ Integrasi form peminjaman dengan database buku
- ✅ Validasi stok buku sebelum peminjaman
- ✅ Record history peminjaman
- ✅ Kalkulasi tanggal pengembalian
- ✅ Validasi overdue (telat kembali)

## 📁 Struktur File Saat Ini

```
src/06-form-peminjaman-buku/
├── Form1.vb                 # Form utama (sama dengan Pertemuan 2)
├── Form1.Designer.vb
├── Form1.resx
├── ApplicationEvents.vb
├── My Project/
├── pertemuan2-komponen-visual.slnx
└── pertemuan2-komponen-visual.vbproj
```

## 🔍 Analisis Kode Saat Ini

### Form1.vb (Sama dengan Pertemuan 2)

```vb
Public Class Form1
    Private Sub BtnTampilkan_Click(sender As Object, e As EventArgs) Handles BtnTampilkan.Click
        MessageBox.Show("Eh Bujang !" & vbCrLf &
                        "Nama : " & TxtNama.Text & vbCrLf &
                        "NIM  : " & TxtNim.Text & vbCrLf &
                        "Kom  : " & TxtKom.Text)
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
```

## 💡 Fitur yang Harus Dikembangkan

### 1. Database Schema

Perlu 2 tabel:

**Tabel Buku:**
```sql
CREATE TABLE buku (
    id SERIAL PRIMARY KEY,
    kode_buku VARCHAR(20) UNIQUE NOT NULL,
    judul VARCHAR(200) NOT NULL,
    penulis VARCHAR(100) NOT NULL,
    kategori VARCHAR(50) NOT NULL,
    tahun_terbit INTEGER,
    stok INTEGER DEFAULT 0
);
```

**Tabel Peminjaman:**
```sql
CREATE TABLE peminjaman (
    id SERIAL PRIMARY KEY,
    kode_peminjaman VARCHAR(20) UNIQUE NOT NULL,
    nim VARCHAR(20) NOT NULL,
    nama_peminjam VARCHAR(100) NOT NULL,
    kode_buku VARCHAR(20) NOT NULL,
    judul_buku VARCHAR(200) NOT NULL,
    tanggal_pinjam DATE NOT NULL,
    tanggal_kembali DATE NOT NULL,
    tanggal_dikembalikan DATE,
    status VARCHAR(20) DEFAULT 'Dipinjam', -- 'Dipinjam', 'Dikembalikan', 'Telat'
    FOREIGN KEY (nim) REFERENCES mahasiswa(nim),
    FOREIGN KEY (kode_buku) REFERENCES buku(kode_buku)
);
```

### 2. Form yang Dibutuhkan

**Komponen Form:**
- TextBox: Nama Peminjam, NIM
- ComboBox: Pilih Buku (dropdown dari database)
- DateTimePicker: Tanggal Pinjam, Tanggal Kembali
- Button: Pinjam, Tampil History, Hapus, Keluar
- DataGridView: Tampilkan history peminjaman

### 3. Logic yang Dibutuhkan

**Validasi Stok:**
```vb
Public Function CekStok(kodeBuku As String) As Integer
    ' Query stok dari database
    ' Return jumlah stok
End Function
```

**Proses Peminjaman:**
```vb
Public Function ProsesPeminjaman(
    nim As String,
    nama As String,
    kodeBuku As String,
    judul As String,
    tanggalPinjam As Date,
    tanggalKembali As Date
) As Boolean
    ' 1. Cek stok buku
    ' 2. Jika stok > 0, kurangi stok
    ' 3. Insert ke tabel peminjaman
    ' 4. Return True jika berhasil
End Function
```

**Kalkulasi Overdue:**
```vb
Public Function CekOverdue(tanggalKembali As Date) As Boolean
    Return tanggalKembali < Date.Today
End Function
```

### 4. Modul yang Dibutuhkan

**ModPeminjaman.vb:**
```vb
Module ModPeminjaman
    Public Function PinjamBuku(...) As Boolean
        ' Logic peminjaman
    End Function

    Public Function KembalikanBuku(idPeminjaman As Integer) As Boolean
        ' Logic pengembalian
    End Function

    Public Function TampilkanHistory() As DataTable
        ' Query history peminjaman
    End Function
End Module
```

## 🎨 Desain Form yang Direncanakan

```
┌─────────────────────────────────────────────────┐
│  Form Peminjaman Buku                            │
├─────────────────────────────────────────────────┤
│                                                  │
│  Nama Peminjam: [_______________]                │
│  NIM          : [_______________]                │
│                                                  │
│  Pilih Buku   : [Dropdown          ▼]            │
│  Judul        : [Read-only________]             │
│  Stok         : [Read-only________]             │
│                                                  │
│  Tgl Pinjam   : [Date Picker     ▼]             │
│  Tgl Kembali  : [Date Picker     ▼]             │
│                                                  │
│  [Pinjam] [Tampil History] [Hapus] [Keluar]     │
│                                                  │
├─────────────────────────────────────────────────┤
│  History Peminjaman                              │
│  ┌──────────────────────────────────────────┐  │
│  │ DataGridView (history peminjaman)         │  │
│  └──────────────────────────────────────────┘  │
└─────────────────────────────────────────────────┘
```

## 🚀 Langkah Pengembangan

1. **Buat database** dengan schema di atas
2. **Modifikasi Form1.vb** untuk form peminjaman
3. **Buat ModPeminjaman.vb** untuk logic peminjaman
4. **Update Designer** untuk komponen yang dibutuhkan
5. **Implementasi validasi** stok dan tanggal
6. **Testing** flow peminjaman lengkap

## 🔗 Hubungan dengan Pertemuan Lain

- **Pertemuan 2**: Template form dasar
- **Pertemuan 6**: Database mahasiswa (bisa digunakan untuk data peminjam)
- **Pertemuan 8**: Inventaris buku (source data buku)

## 📝 Catatan Penting

- Form saat ini TIDAK berfungsi sebagai form peminjaman
- Perlu pengembangan lebih lanjut
- Database harus sudah ada sebelum menjalankan
- Integrasikan dengan database dari Pertemuan 6 dan 8

## 🐛 Status

⚠️ **BELUM SELESAI** - Masih dalam tahap template

---

**Dokumentasi dibuat untuk Pertemuan 7 - Form Peminjaman Buku**
