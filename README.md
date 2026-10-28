# 🎓 Pemrograman Visual - Visual Basic .NET

Project pembelajaran **Visual Basic .NET (Windows Forms)** yang dirancang untuk mempelajari konsep pemrograman visual secara bertahap dari dasar hingga aplikasi database lengkap.

## 📚 Tujuan Pembelajaran

Project ini dirancang untuk mempelajari:
- ✅ Komponen visual dasar Windows Forms
- ✅ Operator dan struktur kendali (If-Else)
- ✅ Perulangan (For Loop)
- ✅ Modul, fungsi, dan array
- ✅ Koneksi database PostgreSQL
- ✅ CRUD operations dengan database
- ✅ DataTable dan BindingSource untuk manajemen data
- ✅ Validasi input dan error handling

## 🗂️ Struktur Project

Project ini terdiri dari 7 modul/pertemuan yang disusun secara bertahap:

```
pemrograman-visual-main/
├── README.md                          # Dokumentasi utama
├── docs/                              # Dokumentasi tambahan
│   ├── STRUCTURE.md                   # Struktur folder
│   └── LEARNING_PATH.md               # Urutan pembelajaran
├── src/                               # Source code utama
│   ├── 01-komponen-visual/            # Komponen visual dasar
│   ├── 02-operator-struktur-kendali/  # Operator & kendali
│   ├── 03-perulangan/                 # Perulangan
│   ├── 04-modul-fungsi-array/         # Modul, fungsi, array
│   ├── 05-database/                   # Database PostgreSQL
│   ├── 06-form-peminjaman-buku/       # Form peminjaman buku
│   └── 07-inventaris-buku-perpustakaan/ # Inventaris buku lengkap
└── shared/                            # Komponen reusable
```

## 📖 Overview Setiap Pertemuan

### 1. Pertemuan 2 - Komponen Visual
**File:** `src/01-komponen-visual/`

**Tujuan:** Pengenalan komponen visual dasar Windows Forms

**Fitur:**
- Form input data mahasiswa (Nama, NIM, Kom)
- Tombol Tampilkan, Hapus, dan Keluar
- Event handling untuk setiap tombol
- MessageBox untuk menampilkan hasil

**Teknologi:**
- Windows Forms
- TextBox, Label, Button
- Event handlers

**Belajar:**
- Dasar Windows Forms
- Event-driven programming
- Input validation dasar

---

### 2. Pertemuan 3 - Operator & Struktur Kendali
**File:** `src/02-operator-struktur-kendali/`

**Tujuan:** Menggunakan operator dan struktur kendali (If-Else)

**Fitur:**
- Konversi nilai ujian ke gambar berdasarkan rentang
- Logika: ≤50 → gambar 1, 51-75 → gambar 2, >75 → gambar 3
- Validasi input hanya angka (0-100)
- Feedback visual dengan gambar

**Teknologi:**
- If-ElseIf-Else statements
- PictureBox control
- KeyPress validation
- Integer.TryParse

**Belajar:**
- Operator perbandingan
- Struktur kendali bersarang
- Validasi input user
- Manipulasi gambar

---

### 3. Pertemuan 4 - Perulangan
**File:** `src/03-perulangan/`

**Tujuan:** Implementasi perulangan (For Loop)

**Fitur:**
- Menampilkan urutan angka dari nilai awal ke akhir
- Automatic ascending atau descending
- Validasi input angka
- ListBox untuk menampilkan hasil

**Teknologi:**
- For...Next loop
- Step parameter untuk reverse loop
- ListBox control
- Validasi input

**Belajar:**
- Perulangan dasar
- Loop dengan kondisi dinamis
- Collection manipulation

---

### 4. Pertemuan 5 - Modul, Fungsi, & Array
**File:** `src/04-modul-fungsi-array/`

**Tujuan:** Modularisasi kode dan penggunaan array

**Fitur:**
- Fungsi reusable untuk validasi input
- Fungsi perhitungan (luas/keliling)
- Array 1D dan 2D
- Display array di ListBox

**Teknologi:**
- Module VB.NET
- Public Function dan Sub
- Array 1D: `nilai()`
- Array 2D: `nilai2d(,)`

**Belajar:**
- Modularisasi kode
- Fungsi dengan parameter
- Array multidimensi
- Code reusability

---

### 5. Pertemuan 6 - Database
**File:** `src/05-database/`

**Tujuan:** Koneksi database PostgreSQL dengan pattern 3-tier

**Fitur:**
- CRUD mahasiswa (Tambah, Tampil)
- Koneksi PostgreSQL dengan Npgsql
- Query SQL dengan parameter
- DataTable untuk display data

**Teknologi:**
- PostgreSQL (Npgsql)
- Microsoft.Extensions.Configuration
- Pattern 3-tier (Presentation, Business, Data)
- Parameterized queries
- DataAdapter & DataTable

**Belajar:**
- Database connection
- SQL queries
- Parameterized queries (anti-SQL injection)
- Data binding
- Exception handling database

**Struktur File:**
- `ModDatabase.vb` - Konfigurasi koneksi
- `ModQuery.vb` - Query SQL
- `ModFunction.vb` - Eksekusi query
- `FormMahasiswa.vb` - UI CRUD
- `appsettings.json` - Connection string

---

### 6. Pertemuan 7 - Form Peminjaman Buku
**File:** `src/06-form-peminjaman-buku/`

**Tujuan:** Form peminjaman buku (lanjutan dari komponen visual)

**Catatan:** Saat ini masih template dari Pertemuan 2, perlu dikembangkan menjadi form peminjaman buku yang sesungguhnya.

**Fitur yang direncanakan:**
- Input data peminjaman (Nama, Kode Buku, Tanggal)
- Validasi stok buku
- Record peminjaman ke database

---

### 7. Pertemuan 8 - Inventaris Buku Perpustakaan
**File:** `src/07-inventaris-buku-perpustakaan/`

**Tujuan:** Aplikasi inventaris buku lengkap dengan DataTable

**Fitur:**
- CRUD buku (Kode, Judul, Penulis, Kategori, Tahun, Stok)
- Filter & Sort (pencarian, filter kategori, stok habis)
- Validasi input dengan ErrorProvider
- DataTable & BindingSource untuk data management
- Summary statistics
- Regex validation untuk kode buku

**Teknologi:**
- DataTable (in-memory database)
- BindingSource (data binding)
- DataGridView (display)
- ErrorProvider (validation)
- Regex (pattern matching)
- DataView.Filter (filtering)
- DataView.Sort (sorting)

**Belajar:**
- In-memory data management
- Data binding patterns
- Advanced validation
- Filter & sort operations
- Event-driven updates

**Struktur Data:**
```
KodeBuku | Judul           | Penulis      | Kategori   | Tahun | Stok
---------|-----------------|--------------|------------|-------|------
BK0001   | Laskar Pelangi  | Andrea Hirata| Fiksi      | 2005  | 8
BK0002   | Bumi            | Tere Liye    | Fiksi      | 2014  | 0
...
```

---

## 🏗️ Arsitektur Sistem

Project ini menggunakan pattern **3-tier architecture** untuk modul database:

```
┌─────────────────────────────────────────┐
│    Presentation Layer (Forms)          │
│  • FormMahasiswa                        │
│  • FormInventaris                       │
└─────────────────┬───────────────────────┘
                  ↓
┌─────────────────────────────────────────┐
│    Business Logic Layer (Modules)      │
│  • ModQuery                             │
│  • ModFunction                          │
│  • ModArray                             │
└─────────────────┬───────────────────────┘
                  ↓
┌─────────────────────────────────────────┐
│    Data Access Layer (Database)        │
│  • ModDatabase                          │
│  • DataTable                            │
└─────────────────┬───────────────────────┘
                  ↓
┌─────────────────────────────────────────┐
│    Data Layer                           │
│  • PostgreSQL                           │
│  • In-memory DataTable                  │
└─────────────────────────────────────────┘
```

---

## 🛠️ Teknologi yang Digunakan

- **Framework:** .NET (Windows Forms)
- **Bahasa:** Visual Basic .NET
- **Database:** PostgreSQL (Npgsql)
- **Configuration:** Microsoft.Extensions.Configuration
- **IDE:** Visual Studio
- **UI Controls:** Windows Forms (TextBox, Button, DataGridView, dll)

---

## 📋 Prerequisites

Untuk menjalankan project ini, Anda perlu:

1. **Visual Studio** (2019 atau lebih baru) dengan workload .NET desktop development
2. **.NET Framework** atau **.NET** (tergantung versi project)
3. **PostgreSQL** (untuk Pertemuan 6 dan 7)
4. **Npgsql** NuGet package (untuk koneksi PostgreSQL)

---

## 🚀 Cara Menjalankan

### Untuk Pertemuan 2-5 (Tanpa Database)

1. Buka folder `src/XX-nama-pertemuan` yang diinginkan di Visual Studio
2. Buka file `.slnx` atau `.vbproj`
3. Tekan F5 atau klik Start untuk menjalankan

### Untuk Pertemuan 6 (Dengan Database)

1. Install PostgreSQL di komputer
2. Buat database `mahasiswa`:
   ```sql
   CREATE DATABASE mahasiswa;
   ```
3. Buat tabel:
   ```sql
   CREATE TABLE mahasiswa (
       id SERIAL PRIMARY KEY,
       nim VARCHAR(20) NOT NULL,
       nama VARCHAR(100) NOT NULL,
       jurusan VARCHAR(50) NOT NULL
   );
   ```
4. Update connection string di `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Port=5432;Database=mahasiswa;Username=postgres;Password=your_password"
     }
   }
   ```
5. Jalankan project di Visual Studio

### Untuk Pertemuan 8 (Inventaris Buku)

Project ini menggunakan DataTable in-memory, tidak perlu database:
1. Buka project di Visual Studio
2. Tekan F5 untuk menjalankan
3. Data akan otomatis di-load saat form dibuka

---

## 📝 Catatan Penting

### Pertemuan 7
Pertemuan 7 saat ini masih menggunakan template dari Pertemuan 2. Perlu dikembangkan menjadi form peminjaman buku yang sesungguhnya dengan fitur:
- Input data peminjaman
- Validasi stok buku
- Koneksi ke database (bisa menggunakan database dari Pertemuan 6)
- History peminjaman

### Struktur Folder
Struktur folder telah dirapikan dengan penamaan konsisten:
- Semua folder di `src/` menggunakan penomoran (01, 02, 03, ...)
- Penamaan menggunakan lowercase dengan dash separator
- Dokumentasi dipisah di folder `docs/`
- Komponen reusable di folder `shared/`

Lihat `docs/STRUCTURE.md` untuk detail lengkap struktur folder.

---

## 🎯 Urutan Pembelajaran Disarankan

1. **Pertemuan 2** → Dasar komponen visual dan event handling
2. **Pertemuan 3** → Logika kondisional dan validasi
3. **Pertemuan 4** → Perulangan dan collection
4. **Pertemuan 5** → Modularisasi dan array
5. **Pertemuan 6** → Database operations (CRUD)
6. **Pertemuan 8** → Aplikasi lengkap dengan DataTable
7. **Pertemuan 7** → Form peminjaman buku (lanjutan)

---

## 📚 Sumber Belajar Tambahan

- [Microsoft Docs - Visual Basic](https://docs.microsoft.com/en-us/dotnet/visual-basic/)
- [Windows Forms Documentation](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)
- [Npgsql Documentation](https://www.npgsql.org/doc/)
- [PostgreSQL Tutorial](https://www.postgresqltutorial.com/)

---

## 📄 Lisensi

Project ini dibuat untuk tujuan pembelajaran.

---

## 👨‍💻 Kontributor

Project ini dibuat sebagai materi pembelajaran Pemrograman Visual.

---

**Last Updated:** 2026-10-29
