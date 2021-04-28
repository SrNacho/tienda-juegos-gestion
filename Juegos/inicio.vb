Imports MySql.Data.MySqlClient
Public Class inicio
    Dim sql As MySqlCommand
    Dim conexion As New MySqlConnection
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        alta.Show() 'cada show es para mostrar el formulario, en este caso, llama a alta
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        baja.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        modificacion.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        consultaventas.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        SaveFileDialog1.ShowDialog()
        'Process.Start("C:\xampp\mysql\bin\mysqldump.exe", "--user=root --password= --host=localhost --databases juegos -r ""C:\BackUpDataBase.sql""")
    End Sub

    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        Dim nom As String
        nom = SaveFileDialog1.FileName.ToString
        Process.Start("C:\xampp\mysql\bin\mysqldump.exe", "--user=root --password= --host=localhost --databases juegos -r """ & nom & ".sql""")
    End Sub
End Class
