Imports MySql.Data.MySqlClient
Public Class bajaconsola
    Dim con As New MySqlConnection
    Dim fillboxsql As MySqlCommand
    Dim listreader As MySqlDataReader
    Dim cons As consultas = New consultas
    Dim consola As String
    Private Sub bajaconsola_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try ' intenta hacer el codigo de abajo, si algo sale mal, el catch atrapa el error y lo muestra en pantalla
            con.ConnectionString = "server=localhost;userid=root;password=;database=juegos" 'string de conexion
            con.Open() ' se abre la conexión
            fillboxsql = New MySqlCommand("SELECT distinct nombre_consola FROM consola", con)
            Using listreader = fillboxsql.ExecuteReader
                While listreader.Read
                    ListBox1.Items.Add(CStr(listreader("nombre_consola"))) 'Estas lineas de acá, desde llenarlistbox hasta el end using son para llenar el listbox que tiene los juegos
                End While
            End Using
            con.Close()
        Catch ex As Exception 'atrapa los errores
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If consola <> "" Then 'validación de la variable consola
            cons.alta("DELETE FROM `consola` WHERE `consola`.`nombre_consola` = '" & consola & "'") 'pasa consulta al metodo alta
            MsgBox("Consola eliminada")
        Else
            MsgBox("Seleccione una consola")
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        consola = ListBox1.GetItemText(ListBox1.SelectedItem)
    End Sub
End Class