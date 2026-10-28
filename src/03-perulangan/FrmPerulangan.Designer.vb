<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPerulangan
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
        btnInput = New Button()
        txtNilaiAwal = New TextBox()
        txtNilaiAkhir = New TextBox()
        lblNilaiAwal = New Label()
        lblNilaiAkhir = New Label()
        lstHasil = New ListBox()
        SuspendLayout()
        ' 
        ' btnInput
        ' 
        btnInput.Location = New Point(286, 169)
        btnInput.Name = "btnInput"
        btnInput.Size = New Size(112, 34)
        btnInput.TabIndex = 0
        btnInput.Text = "Input"
        btnInput.UseVisualStyleBackColor = True
        ' 
        ' txtNilaiAwal
        ' 
        txtNilaiAwal.Location = New Point(286, 69)
        txtNilaiAwal.Name = "txtNilaiAwal"
        txtNilaiAwal.Size = New Size(150, 31)
        txtNilaiAwal.TabIndex = 2
        ' 
        ' txtNilaiAkhir
        ' 
        txtNilaiAkhir.Location = New Point(284, 109)
        txtNilaiAkhir.Name = "txtNilaiAkhir"
        txtNilaiAkhir.Size = New Size(150, 31)
        txtNilaiAkhir.TabIndex = 3
        ' 
        ' lblNilaiAwal
        ' 
        lblNilaiAwal.AutoSize = True
        lblNilaiAwal.Location = New Point(186, 69)
        lblNilaiAwal.Name = "lblNilaiAwal"
        lblNilaiAwal.Size = New Size(89, 25)
        lblNilaiAwal.TabIndex = 4
        lblNilaiAwal.Text = "Nilai Awal"
        ' 
        ' lblNilaiAkhir
        ' 
        lblNilaiAkhir.AutoSize = True
        lblNilaiAkhir.Location = New Point(186, 109)
        lblNilaiAkhir.Name = "lblNilaiAkhir"
        lblNilaiAkhir.Size = New Size(92, 25)
        lblNilaiAkhir.TabIndex = 5
        lblNilaiAkhir.Text = "Nilai Akhir"
        ' 
        ' lstHasil
        ' 
        lstHasil.FormattingEnabled = True
        lstHasil.Location = New Point(286, 220)
        lstHasil.Name = "lstHasil"
        lstHasil.Size = New Size(180, 129)
        lstHasil.TabIndex = 6
        ' 
        ' FrmPerulangan
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(lstHasil)
        Controls.Add(lblNilaiAkhir)
        Controls.Add(lblNilaiAwal)
        Controls.Add(txtNilaiAkhir)
        Controls.Add(txtNilaiAwal)
        Controls.Add(btnInput)
        Name = "FrmPerulangan"
        Text = "Perulangan"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnInput As Button
    Friend WithEvents txtNilaiAwal As TextBox
    Friend WithEvents txtNilaiAkhir As TextBox
    Friend WithEvents lblNilaiAwal As Label
    Friend WithEvents lblNilaiAkhir As Label
    Friend WithEvents lstHasil As ListBox

End Class
