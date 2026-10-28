<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblNama = New Label()
        TxtNama = New TextBox()
        lblNim = New Label()
        LblKom = New Label()
        TxtNim = New TextBox()
        TxtKom = New TextBox()
        BtnTampilkan = New Button()
        BtnHapus = New Button()
        BtnKeluar = New Button()
        SuspendLayout()
        ' 
        ' lblNama
        ' 
        lblNama.AutoSize = True
        lblNama.Location = New Point(105, 40)
        lblNama.Name = "lblNama"
        lblNama.Size = New Size(68, 25)
        lblNama.TabIndex = 0
        lblNama.Text = "Nama :"
        ' 
        ' TxtNama
        ' 
        TxtNama.Location = New Point(179, 40)
        TxtNama.Name = "TxtNama"
        TxtNama.Size = New Size(407, 31)
        TxtNama.TabIndex = 1
        ' 
        ' lblNim
        ' 
        lblNim.AutoSize = True
        lblNim.Location = New Point(105, 84)
        lblNim.Name = "lblNim"
        lblNim.Size = New Size(65, 25)
        lblNim.TabIndex = 2
        lblNim.Text = "NIM   :"
        ' 
        ' LblKom
        ' 
        LblKom.AutoSize = True
        LblKom.Location = New Point(105, 132)
        LblKom.Name = "LblKom"
        LblKom.Size = New Size(68, 25)
        LblKom.TabIndex = 3
        LblKom.Text = "Kom   :"
        ' 
        ' TxtNim
        ' 
        TxtNim.Location = New Point(179, 84)
        TxtNim.Name = "TxtNim"
        TxtNim.Size = New Size(407, 31)
        TxtNim.TabIndex = 4
        ' 
        ' TxtKom
        ' 
        TxtKom.Location = New Point(179, 129)
        TxtKom.Name = "TxtKom"
        TxtKom.Size = New Size(407, 31)
        TxtKom.TabIndex = 5
        ' 
        ' BtnTampilkan
        ' 
        BtnTampilkan.BackColor = SystemColors.AppWorkspace
        BtnTampilkan.Location = New Point(179, 178)
        BtnTampilkan.Name = "BtnTampilkan"
        BtnTampilkan.Size = New Size(112, 34)
        BtnTampilkan.TabIndex = 6
        BtnTampilkan.Text = "Tampilkan"
        BtnTampilkan.UseVisualStyleBackColor = False
        ' 
        ' BtnHapus
        ' 
        BtnHapus.BackColor = SystemColors.AppWorkspace
        BtnHapus.Location = New Point(317, 178)
        BtnHapus.Name = "BtnHapus"
        BtnHapus.Size = New Size(112, 34)
        BtnHapus.TabIndex = 7
        BtnHapus.Text = "Hapus"
        BtnHapus.UseVisualStyleBackColor = False
        ' 
        ' BtnKeluar
        ' 
        BtnKeluar.BackColor = SystemColors.AppWorkspace
        BtnKeluar.Location = New Point(454, 178)
        BtnKeluar.Name = "BtnKeluar"
        BtnKeluar.Size = New Size(112, 34)
        BtnKeluar.TabIndex = 8
        BtnKeluar.Text = "Keluar"
        BtnKeluar.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(790, 413)
        Controls.Add(BtnKeluar)
        Controls.Add(BtnHapus)
        Controls.Add(BtnTampilkan)
        Controls.Add(TxtKom)
        Controls.Add(TxtNim)
        Controls.Add(LblKom)
        Controls.Add(lblNim)
        Controls.Add(TxtNama)
        Controls.Add(lblNama)
        Name = "Form1"
        Text = "ProfileMahasiswa"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblNama As Label
    Friend WithEvents TxtNama As TextBox
    Friend WithEvents lblNim As Label
    Friend WithEvents LblKom As Label
    Friend WithEvents TxtNim As TextBox
    Friend WithEvents TxtKom As TextBox
    Friend WithEvents BtnTampilkan As Button
    Friend WithEvents BtnHapus As Button
    Friend WithEvents BtnKeluar As Button

End Class
