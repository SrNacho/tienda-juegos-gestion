Imports MySql.Data.MySqlClient
Public Class altajuego
    Dim fillboxsql As MySqlCommand
    Dim listreader As MySqlDataReader
    Dim con As New MySqlConnection
    Dim cons As consultas = New consultas
    Dim consola As String
    Dim existe As Integer
    Private Sub altajuego_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        If cons.valLetrasYNum(TextBox1.Text.ToUpper) Then 'validación letras y numeros
            If cons.valNum(TextBox2.Text) Then 'validacion numeros
                If cons.valNum(TextBox3.Text) Then 'validacion numeros
                    If consola <> "" Then 'si la variable consola es distinta a ""
                        Dim sql As MySqlCommand
                        Try
                            con.Open()
                            sql = New MySqlCommand("select count(id_juego) from juego,consola where nombre_consola='" & consola & "' and id_consola=id and nombre_juego='" & TextBox1.Text & "'", con)
                            existe = Convert.ToInt32(sql.ExecuteScalar) 'convierto a int
                            con.Close()
                            If existe = 0 Then
                                con.Open()
                                sql = New MySqlCommand("select id from consola where nombre_consola='" & consola & "'", con) 'busca la id del juego
                                Dim id As Integer = Convert.ToInt32(sql.ExecuteScalar) 'convierto int
                                cons.alta("INSERT INTO `juego` (`id_consola`, `nombre_juego`, `stock_juego`, `precio_juego`) VALUES ('" & id & "', '" & TextBox1.Text.ToUpper & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "')") 'le paso la consulta al metodo
                                MsgBox("Juego agregado!")
                                con.Close()
                            Else
                                MsgBox("El juego ya existe en la consola especificada")
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                    Else
                        MsgBox("Seleccione una consola")
                    End If
                Else
                    MsgBox("Entrada nula o incorrecta de precio")
                End If
            Else
                MsgBox("Entrada nula o incorrecta de stock")
            End If
        Else
            MsgBox("Entrada nula o incorrecta del nombre de juego")
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        consola = ListBox1.GetItemText(ListBox1.SelectedItem) 'mete en consola el item seleccionado
    End Sub
End Class