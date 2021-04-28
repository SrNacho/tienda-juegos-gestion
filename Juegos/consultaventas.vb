Imports MySql.Data.MySqlClient
Public Class consultaventas
    Dim conexion As New MySqlConnection
    Dim adapt As MySqlDataAdapter
    Dim datable As DataTable
    Dim sql As String
    Dim comando As MySqlCommand
    Dim cons As consultas = New consultas
    Private Sub consultaventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'If cons.valNum(TextBox1.Text) Then
        Try
            conexion.ConnectionString = "server=localhost;userid=root;password=;database=juegos" 'string de conexion
            conexion.Open() ' se abre la conexión
            If TextBox1.Text = "" Then
                sql = "select id_venta,dni_cliente,nombre_juego,nombre_consola,ventas.id_juego,nombre_cliente,telefono_cliente,fecha from ventas,juego,consola where consola.id=juego.id_consola and juego.id_juego=ventas.id_juego order by id_venta ASC" 'consulta sql para buscar
                adapt = New MySqlDataAdapter(sql, conexion) 'clase para llenar el dataset 
                datable = New DataTable 'representa una tabla
                adapt.Fill(datable) 'llena la tabla
                DataGridView1.DataSource = datable 'usa los datos de datable para la datagridview
                conexion.Close()
            Else
                If cons.valNum(TextBox1.Text) Then
                    sql = "select id_venta,dni_cliente,nombre_juego,nombre_consola,nombre_cliente,telefono_cliente,fecha from ventas,juego,consola where dni_cliente='" & TextBox1.Text & "' and ventas.id_juego=juego.id_juego and consola.id=juego.id_consola order by id_venta ASC" 'consulta sql para buscar
                    adapt = New MySqlDataAdapter(sql, conexion)  'clase para llenar el dataset 
                    datable = New DataTable 'representa una tabla
                    adapt.Fill(datable) 'llena la tabla
                    DataGridView1.DataSource = datable 'usa los datos de datable para la datagridview
                    conexion.Close()
                Else
                    MsgBox("Ingrese solamente NUMEROS o deje en blanco para buscar")
                    conexion.Close()

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'End If
    End Sub

End Class