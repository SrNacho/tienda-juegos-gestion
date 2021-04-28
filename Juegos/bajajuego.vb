Imports MySql.Data.MySqlClient
Public Class bajajuego
    Dim con As New MySqlConnection
    Dim fillboxsql As MySqlCommand
    Dim listreader As MySqlDataReader
    Dim cons As consultas = New consultas
    Dim juego As String
    Dim consol As String
    Dim id_juego As Integer
    Private Sub bajajuego_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try ' intenta hacer el codigo de abajo, si algo sale mal, el catch atrapa el error y lo muestra en pantalla
            con.ConnectionString = "server=localhost;userid=root;password=;database=juegos" 'string de conexion
            con.Open() ' se abre la conexión
            fillboxsql = New MySqlCommand("SELECT distinct nombre_juego, nombre_consola FROM juego,consola where stock_juego > 0 and id_consola=id", con)
            listreader = fillboxsql.ExecuteReader(CommandBehavior.CloseConnection)
            ListView1.Items.Clear()
            Dim x As ListViewItem
            Do While listreader.Read = True
                x = New ListViewItem(listreader("nombre_juego").ToString)
                x.SubItems.Add(listreader("nombre_consola"))
                ListView1.Items.Add(x)
            Loop 'desde acá hasta la linea 14 (donde esta el fillboxsql) es para llenar el listview
            con.Close()
        Catch ex As Exception 'atrapa los errores
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.FocusedItem.Selected = True Then 'if para que no tire error de elemento no seleccionado, porque cuando cambia el index, momentaneamente se deselecciona y pasa al otro.
            juego = ListView1.SelectedItems(0).Text
            consol = ListView1.SelectedItems(0).SubItems(1).Text
            Dim sql As MySqlCommand
            Try
                con.Open()
                sql = New MySqlCommand("select id_juego from juego,consola where nombre_juego='" & juego & "' and id=id_consola and nombre_consola='" & consol & "'", con)
                id_juego = Convert.ToInt32(sql.ExecuteScalar) 'busca la id y la guarda en id_juego, es necesaria para borrar el juego
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If juego <> "" Then 'valida variable juego
            cons.alta("DELETE FROM `juego` WHERE `juego`.`id_juego` = " & id_juego & "") 'pasa consulta al metodo
            MsgBox("Juego borrado!")
        Else
            MsgBox("Seleccione un juego para borrar")
        End If
    End Sub
End Class