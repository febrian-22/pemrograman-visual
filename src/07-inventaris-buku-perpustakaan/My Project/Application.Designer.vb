Option Strict On

Namespace My
    Partial Friend Class MyApplication
        Inherits Global.Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase

        Public Sub New()
            MyBase.New(Global.Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows)
            Me.IsSingleInstance = False
            Me.EnableVisualStyles = True
            Me.SaveMySettingsOnExit = True
            Me.ShutdownStyle = Global.Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses
        End Sub

        Protected Overrides Sub OnCreateMainForm()
            Me.MainForm = Global.Pertemuan8_Inventaris_Buku_Perpustakaan.Form1
        End Sub
    End Class
End Namespace
