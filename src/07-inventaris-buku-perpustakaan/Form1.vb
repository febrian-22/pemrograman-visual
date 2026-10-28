Option Strict On

Imports System.Data
Imports System.Collections.Generic

Public Class Form1
    Private ReadOnly tabelBuku As New DataTable()

    ' Membuat seluruh kontrol yang dikelola Windows Forms Designer.
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Menyiapkan tabel, data awal, binding, dan filter ketika form dibuka.
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

    ' Membuat struktur kolom DataTable inventaris buku.
    Private Sub SiapkanTabel()
        tabelBuku.Columns.Add("KodeBuku", GetType(String))
        tabelBuku.Columns.Add("Judul", GetType(String))
        tabelBuku.Columns.Add("Penulis", GetType(String))
        tabelBuku.Columns.Add("Kategori", GetType(String))
        tabelBuku.Columns.Add("Tahun", GetType(Integer))
        tabelBuku.Columns.Add("Stok", GetType(Integer))
    End Sub

    ' Mengisi minimal sepuluh buku dengan semua kategori dan stok kosong.
    Private Sub IsiDataAwal()
        tabelBuku.Rows.Add("BK0001", "Laskar Pelangi", "Andrea Hirata", "Fiksi", 2005, 8)
        tabelBuku.Rows.Add("BK0002", "Bumi", "Tere Liye", "Fiksi", 2014, 0)
        tabelBuku.Rows.Add("BK0003", "Negeri 5 Menara", "Ahmad Fuadi", "Fiksi", 2009, 5)
        tabelBuku.Rows.Add("BK0004", "Algoritma dan Pemrograman", "Rosa A.S.", "Nonfiksi", 2020, 4)
        tabelBuku.Rows.Add("BK0005", "Fisika Dasar", "Halliday", "Nonfiksi", 2018, 2)
        tabelBuku.Rows.Add("BK0006", "Ensiklopedia Sains", "Tim Referensi", "Referensi", 2017, 1)
        tabelBuku.Rows.Add("BK0007", "Kamus Bahasa Indonesia", "Badan Bahasa", "Referensi", 2016, 0)
        tabelBuku.Rows.Add("BK0008", "Majalah Teknologi", "Redaksi Tekno", "Majalah", 2023, 6)
        tabelBuku.Rows.Add("BK0009", "Majalah Ilmiah", "Redaksi Ilmu", "Majalah", 2022, 3)
        tabelBuku.Rows.Add("BK0010", "Perahu Kertas", "Dee Lestari", "Fiksi", 2009, 7)
    End Sub

    ' Merapikan judul, lebar, perataan, dan mode ukuran kolom grid.
    Private Sub AturKolomGrid()
        ' Memastikan keenam kolom DataTable dibuat otomatis tanpa kolom manual duplikat.
        dgvBuku.AutoGenerateColumns = True
        dgvBuku.ReadOnly = True
        dgvBuku.AllowUserToAddRows = False
        dgvBuku.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBuku.MultiSelect = False
        dgvBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvBuku.Dock = DockStyle.None
        dgvBuku.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        dgvBuku.Width = Math.Max(600, pnlKanan.ClientSize.Width - 40)
        dgvBuku.Columns("KodeBuku").HeaderText = "Kode Buku"
        dgvBuku.Columns("KodeBuku").DisplayIndex = 0
        dgvBuku.Columns("Judul").DisplayIndex = 1
        dgvBuku.Columns("Penulis").DisplayIndex = 2
        dgvBuku.Columns("Kategori").DisplayIndex = 3
        dgvBuku.Columns("Tahun").DisplayIndex = 4
        dgvBuku.Columns("Stok").DisplayIndex = 5
        dgvBuku.Columns("KodeBuku").Visible = True : dgvBuku.Columns("KodeBuku").FillWeight = 75 : dgvBuku.Columns("KodeBuku").MinimumWidth = 80
        dgvBuku.Columns("Judul").Visible = True : dgvBuku.Columns("Judul").FillWeight = 160 : dgvBuku.Columns("Judul").MinimumWidth = 150
        dgvBuku.Columns("Penulis").Visible = True : dgvBuku.Columns("Penulis").FillWeight = 140 : dgvBuku.Columns("Penulis").MinimumWidth = 120
        dgvBuku.Columns("Kategori").Visible = True : dgvBuku.Columns("Kategori").FillWeight = 100 : dgvBuku.Columns("Kategori").MinimumWidth = 100
        dgvBuku.Columns("Tahun").Visible = True : dgvBuku.Columns("Tahun").FillWeight = 75 : dgvBuku.Columns("Tahun").MinimumWidth = 70 : dgvBuku.Columns("Tahun").Width = 80
        dgvBuku.Columns("Stok").Visible = True : dgvBuku.Columns("Stok").FillWeight = 65 : dgvBuku.Columns("Stok").MinimumWidth = 65 : dgvBuku.Columns("Stok").Width = 70
        dgvBuku.Columns("Tahun").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvBuku.Columns("Stok").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    ' Memvalidasi seluruh isian buku dan menampilkan pesan ErrorProvider.
    Private Function ValidasiInput() As Boolean
        errBuku.Clear()
        Dim valid As Boolean = True
        Dim kode As String = txtKodeBuku.Text.Trim().ToUpperInvariant()
        If Not System.Text.RegularExpressions.Regex.IsMatch(kode, "^BK\d{4}$") Then
            errBuku.SetError(txtKodeBuku, "Kode harus berformat BK dan 4 digit.") : valid = False
        Else
            For Each baris As DataRow In tabelBuku.Rows
                If String.Equals(baris("KodeBuku").ToString(), kode, StringComparison.OrdinalIgnoreCase) Then
                    errBuku.SetError(txtKodeBuku, "Kode buku sudah ada.") : valid = False : Exit For
                End If
            Next
        End If
        If txtJudul.Text.Trim() = String.Empty Then errBuku.SetError(txtJudul, "Judul wajib diisi.") : valid = False
        If txtPenulis.Text.Trim() = String.Empty Then errBuku.SetError(txtPenulis, "Penulis wajib diisi.") : valid = False
        If cboKategori.SelectedIndex < 0 Then errBuku.SetError(cboKategori, "Kategori wajib dipilih.") : valid = False
        Dim tahun As Integer
        If Not Integer.TryParse(txtTahun.Text.Trim(), tahun) OrElse tahun < 1900 OrElse tahun > Date.Today.Year Then
            errBuku.SetError(txtTahun, "Tahun harus 1900 sampai tahun ini.") : valid = False
        End If
        Dim stok As Integer
        If Not Integer.TryParse(txtStok.Text.Trim(), stok) OrElse stok < 0 Then
            errBuku.SetError(txtStok, "Stok harus bilangan bulat minimal 0.") : valid = False
        End If
        Return valid
    End Function

    ' Menambahkan buku baru setelah validasi berhasil.
    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If Not ValidasiInput() Then Return
        tabelBuku.Rows.Add(txtKodeBuku.Text.Trim().ToUpperInvariant(), txtJudul.Text.Trim(), txtPenulis.Text.Trim(), cboKategori.Text, Integer.Parse(txtTahun.Text.Trim()), Integer.Parse(txtStok.Text.Trim()))
        BersihkanIsian()
        PerbaruiRingkasan()
    End Sub

    ' Mengosongkan isian form dan pesan validasi.
    Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
        BersihkanIsian()
    End Sub

    ' Mengosongkan semua kontrol input buku.
    Private Sub BersihkanIsian()
        txtKodeBuku.Clear() : txtJudul.Clear() : txtPenulis.Clear() : txtTahun.Clear() : txtStok.Clear()
        cboKategori.SelectedIndex = -1
        errBuku.Clear()
    End Sub

    ' Menggabungkan pencarian teks dan filter kategori pada BindingSource.
    Private Sub FilterBerubah(sender As Object, e As EventArgs) Handles txtCari.TextChanged, cboFilterKategori.SelectedIndexChanged, chkStokHabis.CheckedChanged, cboUrut.SelectedIndexChanged
        TerapkanFilter()
        TerapkanUrutan()
        PerbaruiRingkasan()
    End Sub

    ' Membangun ekspresi filter dengan karakter khusus yang sudah diamankan.
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
        If chkStokHabis.Checked Then syarat.Add("Stok = 0")
        bsBuku.Filter = String.Join(" AND ", syarat)
    End Sub

    ' Mengatur urutan data pada BindingSource berdasarkan pilihan pengguna.
    Private Sub TerapkanUrutan()
        Select Case cboUrut.SelectedIndex
            Case 1 : bsBuku.Sort = "Judul ASC"
            Case 2 : bsBuku.Sort = "Tahun DESC"
            Case 3 : bsBuku.Sort = "Stok DESC"
            Case Else : bsBuku.Sort = String.Empty
        End Select
    End Sub

    ' Mengamankan apostrof dan karakter wildcard pada nilai DataView.Filter.
    Private Function EscapeFilterValue(nilai As String) As String
        Return nilai.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]")
    End Function

    ' Menghitung jumlah baris tampil dan total stok dari grid.
    Private Sub PerbaruiRingkasan()
        Dim totalStok As Integer = 0
        For Each baris As DataGridViewRow In dgvBuku.Rows
            If Not baris.IsNewRow AndAlso baris.Cells("Stok").Value IsNot Nothing Then totalStok += CInt(baris.Cells("Stok").Value)
        Next
        lblJumlah.Text = "Menampilkan " & dgvBuku.Rows.Count.ToString() & " dari " & tabelBuku.Rows.Count.ToString() & " buku"
        lblTotalStok.Text = "Total stok yang tampil: " & totalStok.ToString()
    End Sub
End Class
