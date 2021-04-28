Imports MySql.Data.MySqlClient
Public Class modifijuego
    Dim con As New MySqlConnection
    Dim fillboxsql As MySqlCommand
    Dim listreader As MySqlDataReader
    Dim juego As String
    Dim cons As consultas = New consultas
    Dim sql As MySqlCommand
    Dim id_consola As Integer
    Dim consol As String
    Dim existe As Integer
    Dim nueva_consola As String
    Dim nueva_id As Integer
    Dim id_juego As Integer
    Private Sub modificonsola_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try ' intenta hacer el codigo de abajo, si algo sale mal, el catch atrapa el error y lo muestra en pantalla
            con.ConnectionString = "server=localhost;userid=root;password=;database=juegos" 'string de conexion
            con.Open() ' se abre la conexión
            fillboxsql = New MySqlCommand("SELECT distinct nombre_juego, nombre_consola FROM juego,consola where id_consola=id", con)
            listreader = fillboxsql.ExecuteReader(CommandBehavior.CloseConnection)
            ListView1.Items.Clear()
            Dim x As ListViewItem
            Do While listreader.Read = True
                x = New ListViewItem(listreader("nombre_juego").ToString)
                x.SubItems.Add(listreader("nombre_consola"))
                ListView1.Items.Add(x)
            Loop
            con.Close()
        Catch ex As Exception 'atrapa los errores
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If juego <> "" Then
            If cons.valLetrasYNum(TextBox1.Text) Then
                If cons.valNum(TextBox2.Text) Then
                    If cons.valNum(TextBox3.Text) Then
                        con.Open()
                        sql = New MySqlCommand("select count(id_juego) from juego,consola where nombre_juego='" & juego & "' and id_consola=id and nombre_consola='" & nueva_consola & "'", con) 'busca el precio del juego
                        existe = Convert.ToInt32(sql.ExecuteScalar) 'busca si ya existe el juego con ese nombre y en esa consola
                        con.Close()
                        If existe = 0 Then
                            cons.alta("UPDATE `juego` SET `id_consola` = '" & nueva_id & "', `nombre_juego` = '" & TextBox1.Text.ToUpper & "', `stock_juego` = '" & TextBox2.Text & "', `precio_juego` = '" & TextBox3.Text & "' where id_juego='" & id_juego & "'")
                            MsgBox("Juego actualizado")
                            Me.Close()
                            cons.relo() 'cierra y recarga el formulario para evitar un bug
                        Else
                            cons.alta("UPDATE `juego` SET `nombre_juego` = '" & TextBox1.Text.ToUpper & "', `stock_juego` = '" & TextBox2.Text & "', `precio_juego` = '" & TextBox3.Text & "' where id_juego='" & id_juego & "'")
                            MsgBox("Juego actualizado")
                            Me.Close()
                            cons.relo() 'cierra y recarga el formulario para evitar un bug
                        End If
                    Else
                        MsgBox("Error en PRECIO: Solo esta permitido numeros // Campo vacio")
                    End If
                Else
                    MsgBox("Error en STOCK: Solo esta permitido numeros // Campo vacio")
                End If
            Else
                MsgBox("Error en NOMBRE: Solo estan permitidos numeros y letras sin espacios // Campo vacio")
            End If
        Else
            MsgBox("Seleccione un juego")
        End If

    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.FocusedItem.Selected = True Then 'if para que no tire error de elemento no seleccionado, porque cuando cambia el index, momentaneamente se deselecciona y pasa al otro.
            juego = ListView1.SelectedItems(0).Text 'guarda en juego lo seleccionado
            consol = ListView1.SelectedItems(0).SubItems(1).Text 'guarda en la variable consol, la consola justamente
            TextBox1.Text = juego 'pone el nombre del juego en el textbox1 
            Try
                con.Open()
                sql = New MySqlCommand("select precio_juego from juego,consola where nombre_juego='" & juego & "' and id_consola=id and nombre_consola='" & consol & "'", con) 'busca el precio del juego
                TextBox3.Text = Convert.ToInt32(sql.ExecuteScalar) 'pone en el textbox3 el precio del juego
                sql = New MySqlCommand("select stock_juego from juego,consola where nombre_juego='" & juego & "' and id_consola=id and nombre_consola='" & consol & "'", con)
                TextBox2.Text = Convert.ToInt32(sql.ExecuteScalar) 'pone en el textbox2 el stock del juego
                fillboxsql = New MySqlCommand("SELECT distinct nombre_consola FROM consola ORDER BY `consola`.`id` ASC", con) 'Estas lineas de acá, desde llenarlistbox hasta el end using son para llenar el listbox que tiene los juegos
                ListBox2.Items.Clear() 'limpia el listbox 2 que tiene las consolas
                Using listreader = fillboxsql.ExecuteReader
                    While listreader.Read
                        ListBox2.Items.Add(CStr(listreader("nombre_consola")))
                    End While
                End Using
                con.Close()
                con.Open()
                sql = New MySqlCommand("select id_consola from juego,consola where nombre_juego='" & juego & "' and id_consola=id and nombre_consola='" & consol & "'", con)
                id_consola = Convert.ToInt32(sql.ExecuteScalar) 'guarda la id de la consola
                sql = New MySqlCommand("select id_juego from juego,consola where nombre_juego='" & juego & "' and id_consola=id and id_consola='" & id_consola & "'", con)
                id_juego = Convert.ToInt32(sql.ExecuteScalar) 'guarda la id del juego
                ListBox2.SetSelected(id_consola - 1, True) 'hace la resta para seleccionarlo en el listbox, acordate que este chamuyo ya te lo expliqué
                con.Close()
                nueva_consola = ListBox2.SelectedItem.ToString()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        nueva_consola = ListBox2.GetItemText(ListBox2.SelectedItem) 'guarda el nombre de la consola nueva elegida
        Try
            con.Open()
            sql = New MySqlCommand("select id from consola where nombre_consola='" & nueva_consola & "'", con) 'busca el precio del juego
            nueva_id = Convert.ToInt32(sql.ExecuteScalar) 'guarda en nueva id, la id de la consola elegida
            con.Close()
        Catch ex As Exception
        End Try
    End Sub
End Class