# Pertemuan 6 - Database

## 📖 Deskripsi

Modul ini mempelajari **koneksi database PostgreSQL** dengan menggunakan pattern **3-tier architecture** dalam Visual Basic .NET. Aplikasi ini mengimplementasikan CRUD (Create, Read) operations untuk data mahasiswa dengan parameterized queries untuk keamanan.

## 🎯 Tujuan Pembelajaran

- ✅ Memahami pattern 3-tier architecture
- ✅ Koneksi database PostgreSQL dengan Npgsql
- ✅ Menggunakan Microsoft.Extensions.Configuration
- ✅ Implementasi parameterized queries (anti-SQL injection)
- ✅ CRUD operations (Create, Read)
- ✅ Exception handling database
- ✅ Data binding dengan DataTable

## 📁 Struktur File

```
src/05-database/
├── FormMahasiswa.vb         # Form UI (Presentation Layer)
├── FormMahasiswa.Designer.vb
├── FormMahasiswa.resx
├── ModDatabase.vb           # Koneksi database (Data Access Layer)
├── ModQuery.vb              # Query SQL (Business Logic Layer)
├── ModFunction.vb           # Eksekusi query (Data Access Layer)
├── ApplicationEvents.vb
├── appsettings.json         # Configuration file
├── My Project/
├── Pertemuan 6 - Database.slnx
└── Pertemuan 6 - Database.vbproj
```

## 🔍 Analisis Kode

### ModDatabase.vb (Data Access Layer)

```vb
Imports Microsoft.Extensions.Configuration
Imports Npgsql

Module ModDatabase
    Public Function GetConnectionString() As String
        Dim config As IConfiguration =
            New ConfigurationBuilder() _
            .SetBasePath(AppContext.BaseDirectory) _
            .AddJsonFile("Appsettings.json", optional:=False, reloadOnChange:=True) _
            .Build()

        Return config.GetConnectionString("DefaultConnection")
    End Function

    Public Sub DatabaseKoneksi()
        Try
            Using conn As New NpgsqlConnection(GetConnectionString)
                conn.Open()
                MessageBox.Show("Koneksi database berhasil")
            End Using
        Catch ex As Exception
            MessageBox.Show("Koneksi database gagal" & vbCrLf & ex.Message & "database")
        End Try
    End Sub
End Module
```

### ModQuery.vb (Business Logic Layer)

```vb
Imports System.Data
Module ModQuery
    Public Function TambahData(
        nim As String,
        nama As String,
        jurusan As String
    ) As Boolean
        Dim query As String =
            "INSERT INTO mahasiswa (nim, nama, jurusan) " &
            "VALUES (@nim, @nama, @jurusan)"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@nim", nim},
            {"@nama", nama},
            {"@jurusan", jurusan}
        }
        Return ModFunction.EksekusiData(query, parameters)
    End Function

    Public Function TampilkanData() As DataTable
        Return ModFunction.AmbilData(
            "SELECT * FROM mahasiswa ORDER BY id ASC"
        )
    End Function
End Module
```

### ModFunction.vb (Data Access Layer)

```vb
Imports Npgsql
Imports System.Data
Module ModFunction
    Public Function AmbilData(query As String) As DataTable
        Dim dt As New DataTable

        Try
            Using conn As New NpgsqlConnection(ModDatabase.GetConnectionString())
                conn.Open()
                Using cmd As New NpgsqlCommand(query, conn)
                    Using adapter As New NpgsqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal mengambil data" & vbCrLf & ex.Message, " database")
        End Try

        Return dt
    End Function

    Public Function EksekusiData(query As String, parameters As Dictionary(Of String, Object)) As Boolean
        Try
            Using conn As New NpgsqlConnection(ModDatabase.GetConnectionString())
                conn.Open()

                Using cmd As New NpgsqlCommand(query, conn)
                    For Each parameter In parameters
                        cmd.Parameters.AddWithValue(parameter.Key, parameter.Value)
                    Next
                    cmd.ExecuteNonQuery()
                    Return True
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(
                "Gagal mengeksekusi data:" & vbCrLf & ex.Message,
                "Error Database"
            )
            Return False
        End Try
    End Function
End Module
```

### FormMahasiswa.vb (Presentation Layer)

```vb
Public Class FormMahasiswa
    Private Sub btnTampil_Click(sender As Object, e As EventArgs) Handles btnTampil.Click
        dgvMahasiswa.AutoGenerateColumns = True
        dgvMahasiswa.DataSource = ModQuery.TampilkanData()
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If ModQuery.TambahData(
            txtNim.Text,
            txtNama.Text,
            txtJurusan.Text
        ) Then
            MessageBox.Show("Data Berhasil Disimpan")
        End If
        txtJurusan.Clear()
        txtNama.Clear()
        txtNim.Clear()
    End Sub
End Class
```

### appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=mahasiswa;Username=postgres;Password=your_password"
  }
}
```

## 💡 Konsep Penting

### 1. 3-Tier Architecture

Pattern ini memisahkan kode menjadi 3 layer:

```
┌─────────────────────────────────────────┐
│  Presentation Layer (FormMahasiswa.vb)  │
│  - UI/UX                                │
│  - User interaction                     │
│  - Data display                         │
└─────────────────┬───────────────────────┘
                  ↓
┌─────────────────────────────────────────┐
│  Business Logic Layer (ModQuery.vb)    │
│  - Query logic                          │
│  - Business rules                       │
│  - Data transformation                  │
└─────────────────┬───────────────────────┘
                  ↓
┌─────────────────────────────────────────┐
│  Data Access Layer (ModDatabase.vb,     │
│                    ModFunction.vb)       │
│  - Database connection                  │
│  - SQL execution                        │
│  - Data retrieval                       │
└─────────────────┬───────────────────────┘
                  ↓
┌─────────────────────────────────────────┐
│  Database (PostgreSQL)                  │
└─────────────────────────────────────────┘
```

**Keuntungan 3-Tier:**
- Separation of concerns
- Reusability
- Maintainability
- Testability
- Scalability

### 2. Npgsql (PostgreSQL .NET Data Provider)

Npgsql adalah ADO.NET data provider untuk PostgreSQL.

**NuGet Package:**
```bash
Install-Package Npgsql
Install-Package Microsoft.Extensions.Configuration
Install-Package Microsoft.Extensions.Configuration.Json
```

**Connection String Format:**
```
Host=localhost;Port=5432;Database=db_name;Username=user;Password=pass
```

### 3. Using Statement

Menggunakan `Using` untuk automatic disposal:

```vb
Using conn As New NpgsqlConnection(connectionString)
    conn.Open()
    ' Kode database
End Using
' conn otomatis di-dispose di sini
```

Keuntungan:
- Otomatis memanggil `.Dispose()`
- Mencegah memory leak
- Menutup connection secara otomatis

### 4. Parameterized Queries

**Bahaya SQL Injection (tanpa parameter):**
```vb
' JANGAN DILAKUKAN!
Dim query As String = "INSERT INTO mahasiswa VALUES ('" & nim & "', '" & nama & "')"
' Jika user input: "'; DROP TABLE mahasiswa; --"
' Hasil: Data mahasiswa akan dihapus!
```

**Aman dengan parameter:**
```vb
Dim query As String = "INSERT INTO mahasiswa VALUES (@nim, @nama)"
cmd.Parameters.AddWithValue("@nim", nim)
cmd.Parameters.AddWithValue("@nama", nama)
```

### 5. DataTable & DataAdapter

**DataTable:**
- In-memory representation dari data
- Mirip dengan database table tapi di memory
- Support CRUD operations

**DataAdapter:**
- Bridge antara DataSet/DataTable dan database
- Support SELECT, INSERT, UPDATE, DELETE

```vb
Using adapter As New NpgsqlDataAdapter(cmd)
    adapter.Fill(dt)  ' Fill DataTable dengan data dari database
End Using
```

### 6. Data Binding

Menghubungkan data source ke control:

```vb
dgvMahasiswa.AutoGenerateColumns = True
dgvMahasiswa.DataSource = ModQuery.TampilkanData()
```

**DataGridView Features:**
- Auto-generate columns
- Editable
- Sortable
- Filterable

### 7. Exception Handling

```vb
Try
    ' Kode yang mungkin error
    Using conn As New NpgsqlConnection(connectionString)
        conn.Open()
        ' ...
    End Using
Catch ex As Exception
    ' Handle error
    MessageBox.Show("Error: " & ex.Message)
End Try
```

## 🗄️ Setup Database

### 1. Install PostgreSQL

Download dan install dari: https://www.postgresql.org/download/

### 2. Buat Database

```sql
CREATE DATABASE mahasiswa;
```

### 3. Buat Tabel

```sql
CREATE TABLE mahasiswa (
    id SERIAL PRIMARY KEY,
    nim VARCHAR(20) NOT NULL UNIQUE,
    nama VARCHAR(100) NOT NULL,
    jurusan VARCHAR(50) NOT NULL
);
```

### 4. Update appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=mahasiswa;Username=postgres;Password=YOUR_PASSWORD"
  }
}
```

## 🚀 Cara Menjalankan

1. Install PostgreSQL dan buat database `mahasiswa`
2. Install NuGet packages:
   - Npgsql
   - Microsoft.Extensions.Configuration
   - Microsoft.Extensions.Configuration.Json
3. Update connection string di `appsettings.json`
4. Buka project di Visual Studio
5. Tekan **F5** untuk menjalankan
6. Masukkan NIM, Nama, Jurusan
7. Klik **Tambah** untuk menyimpan data
8. Klik **Tampil** untuk menampilkan semua data di DataGridView

## 🎓 Latihan Tambahan

1. Tambahkan fitur Update dan Delete
2. Implementasikan validasi duplikat NIM
3. Tambahkan pencarian data
4. Implementasikan pagination
5. Tambahkan export ke Excel/CSV

## 🔗 Hubungan dengan Pertemuan Lain

- **Pertemuan 5**: Module pattern untuk reusability
- **Pertemuan 7**: Database ini akan digunakan untuk peminjaman buku
- **Pertemuan 8**: DataTable pattern untuk inventaris buku

## 📝 Catatan Penting

- Selalu gunakan parameterized queries untuk mencegah SQL injection
- Gunakan `Using` statement untuk resource management
- Jangan hardcode connection string, gunakan configuration file
- Handle exception dengan baik untuk debugging
- Close connection jika tidak menggunakan `Using`

## 🐛 Troubleshooting

### Masalah: Koneksi database gagal
**Solusi:**
- Cek apakah PostgreSQL service running
- Verifikasi connection string (host, port, database, username, password)
- Pastikan database sudah dibuat
- Cek firewall

### Masalah: Npgsql tidak dikenali
**Solusi:**
- Install NuGet package Npgsql
- Add reference ke project
- Rebuild project

### Masalah: appsettings.json tidak terbaca
**Solusi:**
- Set property "Copy to Output Directory" = "Copy always"
- Cek path di `SetBasePath()`
- Pastikan file ada di folder bin/Debug

### Masalah: DataTable kosong
**Solusi:**
- Cek apakah query benar
- Pastikan table ada di database
- Cek apakah ada data di table

---

**Dokumentasi dibuat untuk Pertemuan 6 - Database**
