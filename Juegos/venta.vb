Imports MySql.Data.MySqlClient
Public Class venta
    Dim fillboxsql As MySqlCommand
    Dim listreader As MySqlDataReader
    Dim con As New MySqlConnection
    Dim juego As String
    Dim cons As consultas = New consultas
    Dim precio As Integer
    Dim id_juego As Integer
    Dim stock As Integer
    Dim consol As String
    Dim juegote As String
    Dim consolete As String
    Dim idsinfacturar As Integer
    Dim nombresinfacturar As String
    Dim precio2 As Integer
    Dim sql As MySqlCommand
    Private Sub venta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try ' intenta hacer el codigo de abajo, si algo sale mal, el catch atrapa el error y lo muestra en pantalla
            con.ConnectionString = "server=localhost;userid=root;password=;database=juegos" 'string de conexion
            con.Open() ' se abre la conexión
            fillboxsql = New MySqlCommand("SELECT distinct nombre_juego, nombre_consola FROM juego,consola where stock_juego > 0 and id_consola=id", con) 'esto de acá hasta en loop es para llenar el listview
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
        If cons.valNum(TextBox1.Text) And TextBox1.TextLength = 8 Then 'valida el campo de texto
            If cons.valLetras(TextBox2.Text.ToUpper) Then
                If cons.valNum(TextBox3.Text) Then
                    If TextBox3.Text.Length >= 8 And TextBox3.Text.Length <= 10 Then
                        If juego <> "" Then
                            con.Open()
                            Try
                                For i = 0 To ListView2.Items.Count - 1
                                    juegote = ListView2.Items(i).Text
                                    consolete = ListView2.Items(i).SubItems(1).Text
                                    sql = New MySqlCommand("select id_juego from juego,consola where nombre_juego='" & juegote & "' and id=id_consola and nombre_consola='" & consolete & "'", con)
                                    id_juego = Convert.ToInt32(sql.ExecuteScalar)
                                    sql = New MySqlCommand("select stock_juego from juego where id_juego='" & id_juego & "'", con)
                                    stock = Convert.ToInt32(sql.ExecuteScalar) - 1 'resta 1 al stock
                                    If stock >= 0 Then
                                        cons.alta("INSERT INTO `ventas` (`dni_cliente`, `id_juego`,fecha, nombre_cliente,telefono_cliente) VALUES ('" & TextBox1.Text & "', '" & id_juego & "','" & Now.Date.ToString("yyyy/MM/dd") & "','" & TextBox2.Text.ToUpper & "','" & TextBox3.Text & "')")
                                    End If
                                    cons.alta("UPDATE `juego` SET `stock_juego` = '" & stock & "' WHERE `juego`.`id_juego` = '" & id_juego & "'")
                                Next
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try

                            sql = New MySqlCommand("select count(id_juego) from juego where id_juego=id_juego and stock_juego < 0", con)
                            stock = Convert.ToInt32(sql.ExecuteScalar)
                            For i = 1 To stock
                                sql = New MySqlCommand("select id_juego from juego where id_juego=id_juego and stock_juego < 0", con)
                                idsinfacturar = Convert.ToInt32(sql.ExecuteScalar)
                                sql = New MySqlCommand("select stock_juego from juego where id_juego='" & idsinfacturar & "'", con)
                                stock = Convert.ToInt32(sql.ExecuteScalar)
                                sql = New MySqlCommand("select nombre_juego from juego where id_juego='" & idsinfacturar & "'", con)
                                nombresinfacturar = Convert.ToString(sql.ExecuteScalar)
                                cons.alta("UPDATE `juego` SET `stock_juego` = 0 WHERE `juego`.`id_juego` = '" & idsinfacturar & "'")
                                MsgBox("No se han podido facturar " + stock.ToString + " unidades del juego '" + nombresinfacturar.ToString + "'")
                            Next
                            con.Close()
                            Me.Close()
                            cons.reloven()
                            MsgBox("Venta aceptada")
                        Else
                            MsgBox("Seleccione un juego")
                        End If
                    Else
                        MsgBox("El numero de telefono debe tener entre 8 y 10 caracteres")
                    End If
                Else
                    MsgBox("Ingrese el telefono correctamente")
                End If
            Else
                MsgBox("Ingrese el nombre correctamente")
            End If
        Else
            MsgBox("Ingrese el DNI correctamente")
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.FocusedItem.Selected = True Then 'if para evitar errores en el evento selectindexchanged
            juego = ListView1.SelectedItems(0).Text
            consol = ListView1.SelectedItems(0).SubItems(1).Text
            ListView2.Items.Add(juego).SubItems.Add(consol)
            Try
                con.Open()
                sql = New MySqlCommand("select precio_juego from juego where nombre_juego='" & juego & "'", con) 'busca el precio del juego
                precio = Convert.ToInt32(sql.ExecuteScalar)
                sql = New MySqlCommand("select id_juego from juego,consola where nombre_juego='" & juego & "' and id=id_consola and nombre_consola='" & consol & "'", con)
                id_juego = Convert.ToInt32(sql.ExecuteScalar)
                precio2 = precio2 + precio
                Label4.Text = precio2 'paso el precio al label4
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            juego = ""
            consol = ""
        End If
    End Sub

    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        If ListView2.FocusedItem.Selected = True Then 'if para evitar errores en el evento selectindexchanged
            If (ListView2.SelectedItems.Count > 0) Then
                juego = ListView2.SelectedItems(0).Text
                consol = ListView2.SelectedItems(0).SubItems(1).Text
                Try
                    con.Open()
                    sql = New MySqlCommand("select precio_juego from juego where nombre_juego='" & juego & "'", con) 'busca el precio del juego
                    precio = Convert.ToInt32(sql.ExecuteScalar)
                    sql = New MySqlCommand("select id_juego from juego,consola where nombre_juego='" & juego & "' and id=id_consola and nombre_consola='" & consol & "'", con)
                    id_juego = Convert.ToInt32(sql.ExecuteScalar)
                    precio2 = precio2 - precio
                    Label4.Text = precio2 'paso el precio al label4
                    con.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                juego = ""
                consol = ""
            End If
            
        End If
        Dim x As String
        For i = ListView2.Items.Count - 1 To 0 Step -1
            x = ListView2.Items(i).ToString
            If ListView2.Items(i).Selected Then
                ListView2.Items(i).Remove()
            End If
        Next
    End Sub
End Class