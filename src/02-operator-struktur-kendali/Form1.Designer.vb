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
        btnInput = New Button()
        txtNilai = New TextBox()
        picImage = New PictureBox()
        CType(picImage, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnInput
        ' 
        btnInput.Location = New Point(526, 189)
        btnInput.Name = "btnInput"
        btnInput.Size = New Size(100, 34)
        btnInput.TabIndex = 0
        btnInput.Text = "Input"
        btnInput.UseVisualStyleBackColor = True
        ' 
        ' txtNilai
        ' 
        txtNilai.Location = New Point(503, 152)
        txtNilai.Name = "txtNilai"
        txtNilai.Size = New Size(150, 31)
        txtNilai.TabIndex = 1
        ' 
        ' picImage
        ' 
        picImage.Location = New Point(526, 46)
        picImage.Name = "picImage"
        picImage.Size = New Size(100, 100)
        picImage.SizeMode = PictureBoxSizeMode.Zoom
        picImage.TabIndex = 2
        picImage.TabStop = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1241, 687)
        Controls.Add(picImage)
        Controls.Add(txtNilai)
        Controls.Add(btnInput)
        Name = "Form1"
        Text = "Form1"
        CType(picImage, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnInput As Button
    Friend WithEvents txtNilai As TextBox
    Friend WithEvents picImage As PictureBox

End Class
