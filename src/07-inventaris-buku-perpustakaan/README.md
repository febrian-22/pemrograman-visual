# Pertemuan 8 - Inventaris Buku Perpustakaan

## 📖 Deskripsi

Modul ini adalah aplikasi **inventaris buku perpustakaan** yang paling kompleks. Aplikasi ini menggunakan **DataTable** sebagai in-memory database dengan fitur CRUD lengkap, filter, sort, validasi dengan ErrorProvider, dan pattern data binding yang modern.

## 🎯 Tujuan Pembelajaran

- ✅ Menggunakan DataTable sebagai in-memory database
- ✅ Implementasi BindingSource untuk data binding
- ✅ CRUD operations dengan DataTable
- ✅ Advanced filtering dengan DataView.Filter
- ✅ Sorting dengan DataView.Sort
- ✅ Validasi input dengan ErrorProvider
- ✅ Regex validation untuk pattern matching
- ✅ Dynamic column configuration
- ✅ Event-driven updates

## 📁 Struktur File

```
src/07-inventaris-buku-perpustakaan/
├── Form1.vb                 # Form utama dengan logic lengkap
├── Form1.Designer.vb
├── Form1.resx
├── ApplicationEvents.vb
├── My Project/
├── Pertemuan8-Inventaris Buku Perpustakaan.slnx
└── Pertemuan8-Inventaris Buku Perpustakaan.vbproj
```

## 🔍 Analisis Kode

### Form1.vb (Full Implementation)

```vb
Option Strict On

Imports System.Data
Imports System.Collections.Generic

Public Class Form1
    Private ReadOnly tabelBuku As New DataTable()

    ' Constructor
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Load event: Siapkan tabel, data awal, binding, filter
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SiapkanTabel()
        IsiDataAwal()
        bsBuku.DataSource = tabelBuku
        dgvBuku.AutoGenerateColumns = True
        dgvBuku.DataSource = bsBuku
        AturKolomGrid()
        cboFilterKategori.SelectedIndex = 0
        cboUrut.SelectedIndex = 0
        PerbaruiRingkasan()
    End Sub

    ' Membuat struktur kolom DataTable
    Private Sub SiapkanTabel()
        tabelBuku.Columns.Add("KodeBuku", GetType(String))
        tabelBuku.Columns.Add("Judul", GetType(String))
        tabelBuku.Columns.Add("Penulis", GetType(String))
        tabelBuku.Columns.Add("Kategori", GetType(String))
        tabelBuku.Columns.Add("Tahun", GetType(Integer))
        tabelBuku.Columns.Add("Stok", GetType(Integer))
    End Sub

    ' Mengisi data awal (10 buku)
    Private Sub IsiDataAwal()
        tabelBuku.Rows.Add("BK0001", "Laskar Pelangi", "Andrea Hirata", "Fiksi", 2005, 8)
        tabelBuku.Rows.Add("BK0002", "Bumi", "Tere Liye", "Fiksi", 2014, 0)
        ' ... dan seterusnya
    End Sub

    ' Konfigurasi DataGridView
    Private Sub AturKolomGrid()
        dgvBuku.AutoGenerateColumns = True
        dgvBuku.ReadOnly = True
        dgvBuku.AllowUserToAddRows = False
        dgvBuku.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBuku.MultiSelect = False
        dgvBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        ' ... konfigurasi kolom lebih lanjut
    End Sub

    ' Validasi input dengan ErrorProvider
    Private Function ValidasiInput() As Boolean
        errBuku.Clear()
        Dim valid As Boolean = True
        Dim kode As String = txtKodeBuku.Text.Trim().ToUpperInvariant()

        ' Validasi format kode buku dengan Regex
        If Not System.Text.RegularExpressions.Regex.IsMatch(kode, "^BK\d{4}$") Then
            errBuku.SetError(txtKodeBuku, "Kode harus berformat BK dan 4 digit.")
            valid = False
        Else
            ' Cek duplikat kode
            For Each baris As DataRow In tabelBuku.Rows
                If String.Equals(baris("KodeBuku").ToString(), kode, StringComparison.OrdinalIgnoreCase) Then
                    errBuku.SetError(txtKodeBuku, "Kode buku sudah ada.")
                    valid = False
                    Exit For
                End If
            Next
        End If

        ' Validasi field lain
        If txtJudul.Text.Trim() = String.Empty Then
            errBuku.SetError(txtJudul, "Judul wajib diisi.")
            valid = False
        End If
        ' ... validasi lainnya

        Return valid
    End Function

    ' Tambah buku baru
    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If Not ValidasiInput() Then Return
        tabelBuku.Rows.Add(
            txtKodeBuku.Text.Trim().ToUpperInvariant(),
            txtJudul.Text.Trim(),
            txtPenulis.Text.Trim(),
            cboKategori.Text,
            Integer.Parse(txtTahun.Text.Trim()),
            Integer.Parse(txtStok.Text.Trim())
        )
        BersihkanIsian()
        PerbaruiRingkasan()
    End Sub

    ' Filter dan Sort
    Private Sub FilterBerubah(sender As Object, e As EventArgs) Handles txtCari.TextChanged, cboFilterKategori.SelectedIndexChanged, chkStokHabis.CheckedChanged, cboUrut.SelectedIndexChanged
        TerapkanFilter()
        TerapkanUrutan()
        PerbaruiRingkasan()
    End Sub

    Private Sub TerapkanFilter()
        Dim syarat As New List(Of String)()
        Dim kata As String = txtCari.Text.Trim()

        If kata <> String.Empty Then
            Dim aman As String = EscapeFilterValue(kata)
            syarat.Add("(Judul LIKE '%" & aman & "%' OR Penulis LIKE '%" & aman & "%')")
        End If

        If cboFilterKategori.SelectedIndex > 0 Then
            syarat.Add("Kategori = '" & EscapeFilterValue(cboFilterKategori.Text) & "'")
        End If

        If chkStokHabis.Checked Then
            syarat.Add("Stok = 0")
        End If

        bsBuku.Filter = String.Join(" AND ", syarat)
    End Sub

    Private Sub TerapkanUrutan()
        Select Case cboUrut.SelectedIndex
            Case 1 : bsBuku.Sort = "Judul ASC"
            Case 2 : bsBuku.Sort = "Tahun DESC"
            Case 3 : bsBuku.Sort = "Stok DESC"
            Case Else : bsBuku.Sort = String.Empty
        End Select
    End Sub

    ' Escape karakter khusus untuk filter
    Private Function EscapeFilterValue(nilai As String) As String
        Return nilai.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]")
    End Function

    ' Update ringkasan statistik
    Private Sub PerbaruiRingkasan()
        Dim totalStok As Integer = 0
        For Each baris As DataGridViewRow In dgvBuku.Rows
            If Not baris.IsNewRow AndAlso baris.Cells("Stok").Value IsNot Nothing Then
                totalStok += CInt(baris.Cells("Stok").Value)
            End If
        Next
        lblJumlah.Text = "Menampilkan " & dgvBuku.Rows.Count.ToString() & " dari " & tabelBuku.Rows.Count.ToString() & " buku"
        lblTotalStok.Text = "Total stok yang tampil: " & totalStok.ToString()
    End Function
End Class
```

## 💡 Konsep Penting

### 1. DataTable (In-Memory Database)

DataTable adalah representasi in-memory dari database table.

**Keuntungan:**
- Tidak perlu database fisik
- Cepat untuk data kecil-menengah
- Support CRUD operations
- Serializable

**Struktur DataTable:**
```vb
Dim dt As New DataTable()
dt.Columns.Add("ID", GetType(Integer))
dt.Columns.Add("Nama", GetType(String))
dt.Rows.Add(1, "Budi")
dt.Rows.Add(2, "Siti")
```

### 2. BindingSource

BindingSource adalah layer antara data source dan UI controls.

**Keuntungan:**
- Centralized data binding
- Support sorting dan filtering
- Automatic currency management
- Position tracking

```vb
bsBuku.DataSource = tabelBuku
dgvBuku.DataSource = bsBuku
```

### 3. DataGridView

Control untuk menampilkan data dalam format table.

**Konfigurasi Penting:**
```vb
dgvBuku.AutoGenerateColumns = True      ' Auto-generate columns
dgvBuku.ReadOnly = True                  ' Tidak bisa edit langsung
dgvBuku.AllowUserToAddRows = False       ' Tidak ada row tambahan
dgvBuku.SelectionMode = FullRowSelect    ' Select entire row
dgvBuku.MultiSelect = False              ' Hanya select satu row
```

### 4. ErrorProvider

Control untuk menampilkan error message di samping input field.

```vb
errBuku.SetError(txtKodeBuku, "Kode harus berformat BK dan 4 digit.")
errBuku.Clear()  ' Hapus semua error
```

### 5. Regex Validation

Regular Expression untuk pattern matching.

```vb
Imports System.Text.RegularExpressions

If Regex.IsMatch(kode, "^BK\d{4}$") Then
    ' Valid: BK diikuti 4 digit
End If
```

**Pattern yang digunakan:**
- `^` - Start of string
- `BK` - Literal "BK"
- `\d{4}` - 4 digit (0-9)
- `$` - End of string

### 6. DataView.Filter

Expression filter untuk BindingSource.

**Syntax:**
```vb
bsBuku.Filter = "Kategori = 'Fiksi'"
bsBuku.Filter = "Judul LIKE '%Laskar%'"
bsBuku.Filter = "Stok = 0"
bsBuku.Filter = "Kategori = 'Fiksi' AND Stok > 0"
```

**Operator yang didukung:**
- `=`, `<>`, `<`, `>`, `<=`, `>=`
- `LIKE` dengan wildcard `%`
- `AND`, `OR`, `NOT`

### 7. DataView.Sort

Sorting untuk BindingSource.

```vb
bsBuku.Sort = "Judul ASC"      ' Ascending
bsBuku.Sort = "Tahun DESC"     ' Descending
bsBuku.Sort = "Kategori ASC, Judul ASC"  ' Multi-column
```

### 8. Escaping Filter Values

Karakter khusus harus di-escape untuk menghindari error filter.

```vb
Private Function EscapeFilterValue(nilai As String) As String
    Return nilai.Replace("'", "''")  ' Escape apostrophe
               .Replace("[", "[[]")  ' Escape bracket
               .Replace("%", "[%]")  ' Escape wildcard
               .Replace("*", "[*]")  ' Escape wildcard
End Function
```

**Mengapa perlu escape?**
- `'` adalah string delimiter
- `%` dan `*` adalah wildcard di LIKE
- `[` dan `]` adalah bracket operator

### 9. Column Configuration

Mengatur tampilan kolom DataGridView.

```vb
dgvBuku.Columns("KodeBuku").HeaderText = "Kode Buku"
dgvBuku.Columns("KodeBuku").DisplayIndex = 0
dgvBuku.Columns("KodeBuku").Visible = True
dgvBuku.Columns("KodeBuku").FillWeight = 75
dgvBuku.Columns("KodeBuku").MinimumWidth = 80
dgvBuku.Columns("Tahun").DefaultCellStyle.Alignment = MiddleCenter
```

### 10. Option Strict On

```vb
Option Strict On
```

Keuntungan:
- Memaksa explicit type conversion
- Mencegah implicit narrowing conversion
- Early error detection
- Better performance

## 🎨 Alur Aplikasi

```
┌─────────────────┐
│  Form Load      │
└────────┬────────┘
         ↓
┌─────────────────┐
│ SiapkanTabel()  │ → Buat kolom DataTable
└────────┬────────┘
         ↓
┌─────────────────┐
│ IsiDataAwal()   │ → Insert 10 buku awal
└────────┬────────┘
         ↓
┌─────────────────┐
│ Data Binding    │ → DataTable → BindingSource → DataGridView
└────────┬────────┘
         ↓
┌─────────────────┐
│ AturKolomGrid() │ → Konfigurasi tampilan
└────────┬────────┘
         ↓
┌─────────────────┐
│  Ready for Use  │
└─────────────────┘

User Action:
- Input → Validasi → Add ke DataTable → Update Grid
- Filter → TerapkanFilter() → Update Grid
- Sort → TerapkanUrutan() → Update Grid
```

## 📊 Struktur Data

### DataTable Schema

| Column | Type | Description |
|--------|------|-------------|
| KodeBuku | String | Unique ID buku (format: BK####) |
| Judul | String | Judul buku |
| Penulis | String | Penulis buku |
| Kategori | String | Kategori (Fiksi, Nonfiksi, Referensi, Majalah) |
| Tahun | Integer | Tahun terbit |
| Stok | Integer | Jumlah stok |

### Sample Data

```
KodeBuku | Judul           | Penulis      | Kategori   | Tahun | Stok
---------|-----------------|--------------|------------|-------|------
BK0001   | Laskar Pelangi  | Andrea Hirata| Fiksi      | 2005  | 8
BK0002   | Bumi            | Tere Liye    | Fiksi      | 2014  | 0
BK0003   | Negeri 5 Menara | Ahmad Fuadi  | Fiksi      | 2009  | 5
BK0004   | Algoritma       | Rosa A.S.    | Nonfiksi   | 2020  | 4
...
```

## 🚀 Cara Menjalankan

1. Buka project di Visual Studio
2. Tekan **F5** untuk menjalankan
3. Data awal otomatis di-load (10 buku)
4. **Tambah Buku:**
   - Masukkan Kode (format: BK####)
   - Masukkan Judul, Penulis
   - Pilih Kategori
   - Masukkan Tahun dan Stok
   - Klik **Tambah**
5. **Filter:**
   - Ketik di pencarian (Judul/Penulis)
   - Pilih Kategori di dropdown
   - Checkbox "Stok Habis"
6. **Sort:**
   - Pilih urutan di dropdown (Judul, Tahun, Stok)
7. Lihat statistik di bagian bawah

## 🎓 Latihan Tambahan

1. Tambahkan fitur Edit dan Delete buku
2. Implementasikan export ke Excel/CSV
3. Tambahkan pagination untuk data besar
4. Implementasikan validation rule per kategori
5. Tambahkan chart statistik buku per kategori
6. Implementasikan undo/redo untuk CRUD operations
7. Tambahkan search advanced dengan multiple criteria

## 🔗 Hubungan dengan Pertemuan Lain

- **Pertemuan 5**: Array pattern untuk data collection
- **Pertemuan 6**: Database pattern (DataTable sebagai alternatif)
- **Pertemuan 7**: Data buku ini bisa digunakan untuk peminjaman

## 📝 Catatan Penting

- DataTable adalah in-memory, data hilang saat aplikasi ditutup
- Gunakan database fisik untuk persistence
- Selalu escape filter values untuk menghindari error
- Gunakan Option Strict On untuk type safety
- ErrorProvider sangat membantu untuk UX

## 🐛 Troubleshooting

### Masalah: Filter tidak berfungsi
**Solusi:**
- Pastikan BindingSource terhubung ke DataTable
- Cek syntax filter expression
- Escape karakter khusus di filter value

### Masalah: Validasi tidak muncul
**Solusi:**
- Pastikan ErrorProvider control ada di form
- Cek apakah `SetError()` dipanggil
- Pastikan event validasi terhubung

### Masalah: Grid tidak update setelah tambah data
**Solusi:**
- Pastikan data ditambah ke DataTable, bukan langsung ke Grid
- BindingSource akan otomatis update Grid
- Panggil `PerbaruiRingkasan()` untuk update statistik

### Masalah: Regex selalu gagal
**Solusi:**
- Cek pattern regex
- Gunakan `ToUpperInvariant()` untuk case-insensitive
- Test pattern di regex tester online

---

**Dokumentasi dibuat untuk Pertemuan 8 - Inventaris Buku Perpustakaan**
