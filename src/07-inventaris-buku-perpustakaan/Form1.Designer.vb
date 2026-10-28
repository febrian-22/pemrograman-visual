<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits Form
    Private components As ComponentModel.IContainer
    Friend WithEvents lblJudulForm As Label
    Friend WithEvents lblKodeBuku As Label
    Friend WithEvents txtKodeBuku As TextBox
    Friend WithEvents lblJudul As Label
    Friend WithEvents txtJudul As TextBox
    Friend WithEvents lblPenulis As Label
    Friend WithEvents txtPenulis As TextBox
    Friend WithEvents lblKategori As Label
    Friend WithEvents cboKategori As ComboBox
    Friend WithEvents lblTahun As Label
    Friend WithEvents txtTahun As TextBox
    Friend WithEvents lblStok As Label
    Friend WithEvents txtStok As TextBox
    Friend WithEvents btnTambah As Button
    Friend WithEvents btnBersihkan As Button
    Friend WithEvents lblCari As Label
    Friend WithEvents txtCari As TextBox
    Friend WithEvents lblFilterKategori As Label
    Friend WithEvents cboFilterKategori As ComboBox
    Friend WithEvents dgvBuku As DataGridView
    Friend WithEvents bsBuku As BindingSource
    Friend WithEvents lblJumlah As Label
    Friend WithEvents lblTotalStok As Label
    Friend WithEvents errBuku As ErrorProvider
    Friend WithEvents chkStokHabis As CheckBox
    Friend WithEvents cboUrut As ComboBox
    Friend WithEvents lblUrut As Label
    Friend WithEvents pnlKiri As Panel
    Friend WithEvents pnlKanan As Panel
    Friend WithEvents pnlRingkasan As Panel
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        pnlKiri = New Panel() : pnlKanan = New Panel() : pnlRingkasan = New Panel() : chkStokHabis = New CheckBox() : cboUrut = New ComboBox() : lblUrut = New Label()
        lblJudulForm = New Label() : lblKodeBuku = New Label() : txtKodeBuku = New TextBox() : lblJudul = New Label() : txtJudul = New TextBox() : lblPenulis = New Label() : txtPenulis = New TextBox() : lblKategori = New Label() : cboKategori = New ComboBox() : lblTahun = New Label() : txtTahun = New TextBox() : lblStok = New Label() : txtStok = New TextBox() : btnTambah = New Button() : btnBersihkan = New Button() : lblCari = New Label() : txtCari = New TextBox() : lblFilterKategori = New Label() : cboFilterKategori = New ComboBox() : dgvBuku = New DataGridView() : bsBuku = New BindingSource(components) : lblJumlah = New Label() : lblTotalStok = New Label() : errBuku = New ErrorProvider(components)
        SuspendLayout()
        SetLabel(lblJudulForm, "Inventaris Buku Perpustakaan", 20, 15, "lblJudulForm")
        SetLabel(lblKodeBuku, "Kode buku", 20, 60, "lblKodeBuku") : SetText(txtKodeBuku, 130, 57, "txtKodeBuku", 180)
        SetLabel(lblJudul, "Judul", 20, 95, "lblJudul") : SetText(txtJudul, 130, 92, "txtJudul", 250)
        SetLabel(lblPenulis, "Penulis", 20, 130, "lblPenulis") : SetText(txtPenulis, 130, 127, "txtPenulis", 250)
        SetLabel(lblKategori, "Kategori", 20, 165, "lblKategori") : SetCombo(cboKategori, 130, 162, "cboKategori", New Object() {"Fiksi", "Nonfiksi", "Referensi", "Majalah"}, 180)
        SetLabel(lblTahun, "Tahun terbit", 420, 60, "lblTahun") : SetText(txtTahun, 520, 57, "txtTahun", 100)
        SetLabel(lblStok, "Stok", 420, 95, "lblStok") : SetText(txtStok, 520, 92, "txtStok", 100)
        SetButton(btnTambah, "Tambah Buku", 20, 215, "btnTambah") : SetButton(btnBersihkan, "Bersihkan", 130, 215, "btnBersihkan")
        SetLabel(lblCari, "Cari judul/penulis", 20, 20, "lblCari") : SetText(txtCari, 20, 45, "txtCari", 290)
        SetLabel(lblFilterKategori, "Filter kategori", 20, 80, "lblFilterKategori") : SetCombo(cboFilterKategori, 20, 105, "cboFilterKategori", New Object() {"Semua", "Fiksi", "Nonfiksi", "Referensi", "Majalah"}, 200)
        lblUrut = MakeLabel("Urutkan buku", 380, 20, "lblUrut")
        SetCombo(cboUrut, 380, 45, "cboUrut", New Object() {"Urutan awal", "Judul A-Z", "Tahun terbaru", "Stok terbanyak"}, 190)
        chkStokHabis.AutoSize = True : chkStokHabis.Location = New Drawing.Point(240, 108) : chkStokHabis.Name = "chkStokHabis" : chkStokHabis.Text = "Hanya stok habis"
        dgvBuku.Location = New Drawing.Point(20, 145) : dgvBuku.Name = "dgvBuku" : dgvBuku.Size = New Drawing.Size(760, 475) : dgvBuku.ReadOnly = True : dgvBuku.AllowUserToAddRows = False : dgvBuku.SelectionMode = DataGridViewSelectionMode.FullRowSelect : dgvBuku.MultiSelect = False : dgvBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill : dgvBuku.RowHeadersWidth = 35
        dgvBuku.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblJumlah = MakeLabel("Menampilkan 10 dari 10 buku", 20, 4, "lblJumlah") : lblTotalStok = MakeLabel("Total stok yang tampil: 36", 20, 33, "lblTotalStok")
        errBuku.BlinkStyle = ErrorBlinkStyle.NeverBlink
        pnlKiri.Dock = DockStyle.Left : pnlKiri.Name = "pnlKiri" : pnlKiri.Padding = New Padding(20) : pnlKiri.Width = 360
        pnlKanan.Dock = DockStyle.Fill : pnlKanan.Name = "pnlKanan" : pnlKanan.Padding = New Padding(0, 0, 20, 0)
        pnlRingkasan.Dock = DockStyle.Bottom : pnlRingkasan.Name = "pnlRingkasan" : pnlRingkasan.Height = 68 : pnlRingkasan.Padding = New Padding(0, 0, 0, 12) : pnlRingkasan.TabIndex = 0
        pnlKiri.Controls.AddRange(New Control() {lblJudulForm, lblKodeBuku, txtKodeBuku, lblJudul, txtJudul, lblPenulis, txtPenulis, lblKategori, cboKategori, lblTahun, txtTahun, lblStok, txtStok, btnTambah, btnBersihkan})
        pnlRingkasan.Controls.Add(lblJumlah) : pnlRingkasan.Controls.Add(lblTotalStok)
        lblJumlah.Location = New Drawing.Point(20, 4) : lblJumlah.Anchor = AnchorStyles.Left Or AnchorStyles.Top : lblJumlah.Visible = True
        lblTotalStok.Location = New Drawing.Point(20, 33) : lblTotalStok.Anchor = AnchorStyles.Left Or AnchorStyles.Top : lblTotalStok.Visible = True
        pnlKanan.Controls.AddRange(New Control() {lblCari, txtCari, lblFilterKategori, cboFilterKategori, lblUrut, cboUrut, chkStokHabis, dgvBuku, pnlRingkasan})
        lblJudulForm.Location = New Drawing.Point(20, 20) : lblKodeBuku.Location = New Drawing.Point(20, 75) : txtKodeBuku.Location = New Drawing.Point(20, 100) : txtKodeBuku.Width = 290
        lblJudul.Location = New Drawing.Point(20, 135) : txtJudul.Location = New Drawing.Point(20, 160) : txtJudul.Width = 290 : lblPenulis.Location = New Drawing.Point(20, 195) : txtPenulis.Location = New Drawing.Point(20, 220) : txtPenulis.Width = 290
        lblKategori.Location = New Drawing.Point(20, 255) : cboKategori.Location = New Drawing.Point(20, 280) : cboKategori.Width = 290 : lblTahun.Location = New Drawing.Point(20, 315) : txtTahun.Location = New Drawing.Point(20, 340) : txtTahun.Width = 130 : lblStok.Location = New Drawing.Point(180, 315) : txtStok.Location = New Drawing.Point(180, 340) : txtStok.Width = 130
        btnTambah.Location = New Drawing.Point(20, 390) : btnBersihkan.Location = New Drawing.Point(135, 390)
        ClientSize = New Drawing.Size(1200, 700) : Controls.Add(pnlKanan) : Controls.Add(pnlKiri) : Name = "Form1" : Text = "Inventaris Buku Perpustakaan" : MinimumSize = New Drawing.Size(1000, 700)
        ResumeLayout(False) : PerformLayout()
    End Sub
    ' Mengatur properti dasar label Designer.
    Private Sub SetLabel(label As Label, caption As String, x As Integer, y As Integer, controlName As String)
        label.AutoSize = True : label.Location = New Drawing.Point(x, y) : label.Name = controlName : label.Text = caption : Controls.Add(label)
    End Sub
    ' Mengatur posisi, nama, dan ukuran TextBox Designer.
    Private Sub SetText(box As TextBox, x As Integer, y As Integer, controlName As String, width As Integer)
        box.Location = New Drawing.Point(x, y) : box.Name = controlName : box.Size = New Drawing.Size(width, 23) : Controls.Add(box)
    End Sub
    ' Mengatur daftar pilihan dan properti ComboBox Designer.
    Private Sub SetCombo(combo As ComboBox, x As Integer, y As Integer, controlName As String, values As Object(), width As Integer)
        combo.DropDownStyle = ComboBoxStyle.DropDownList : combo.Items.AddRange(values) : combo.Location = New Drawing.Point(x, y) : combo.Name = controlName : combo.Size = New Drawing.Size(width, 23) : Controls.Add(combo)
    End Sub
    ' Mengatur properti dasar tombol Designer.
    Private Sub SetButton(button As Button, caption As String, x As Integer, y As Integer, controlName As String)
        button.Location = New Drawing.Point(x, y) : button.Name = controlName : button.Size = New Drawing.Size(100, 30) : button.Text = caption : Controls.Add(button)
    End Sub
    ' Membuat label ringkasan dengan properti Designer.
    Private Function MakeLabel(caption As String, x As Integer, y As Integer, controlName As String) As Label
        Dim label As New Label() : SetLabel(label, caption, x, y, controlName) : Return label
    End Function
End Class
