Imports MySql.Data.MySqlClient
Public Class modificacionconsola
    Dim fillboxsql As MySqlCommand
    Dim listreader As MySqlDataReader
    Dim con As New MySqlConnection
    Dim cons As consultas = New consultas
    Dim consola As String
    Private Sub modificacionconsola_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        consola = ListBox1.GetItemText(ListBox1.SelectedItem) 'guarda en consola el string item seleccionado
        TextBox1.Text = consola
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If consola <> "" Then 'valida consola seleccionada
            If cons.valLetrasYNum(TextBox1.Text.ToUpper) Then 'valida numeros y letras del textbox1
                cons.alta("UPDATE `consola` SET `nombre_consola` = '" & TextBox1.Text.ToUpper & "' WHERE `consola`.`nombre_consola` = '" & consola & "'") 'ejecuta la consulta
                Me.Close()
                cons.relocon() 'cierra y recarga el formulario para evitar un bug
                MsgBox("Consola actualizada")
            Else
                MsgBox("Error en NOMBRE: Solo estan permitidos numeros y letras sin espacios // Campo vacio")
            End If
        Else
            MsgBox("Seleccione una consola")
        End If
    End Sub
End Class