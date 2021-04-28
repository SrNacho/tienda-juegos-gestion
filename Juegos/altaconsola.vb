Imports MySql.Data.MySqlClient
Public Class altaconsola
    Dim cons As consultas = New consultas()
    Dim sql As MySqlCommand
    Dim con As New MySqlConnection
    Dim existe As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con.ConnectionString = "server=localhost;userid=root;password=;database=juegos" 'string de conexion
            con.Open()
            sql = New MySqlCommand("select count(nombre_consola) from consola where nombre_consola='" & TextBox1.Text.ToUpper & "'", con)
            existe = Convert.ToInt32(sql.ExecuteScalar) 'convierto a int
            con.Close()
            If existe = 0 Then
                If cons.valLetrasYNum(TextBox1.Text.ToUpper) Then 'esta validación permite letras y numeros, pero no otras cosas. Por ejemplo admite PS4
                    cons.alta("INSERT INTO `consola` (`nombre_consola`) VALUES ('" & TextBox1.Text & "')") 'le paso la consulta al metodo alta
                    MsgBox("Consola agregada!")
                Else
                    MsgBox("Solo se admiten letras y numeros.")
                End If
            Else
                MsgBox("La consola ya existe en la base de datos")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub

End Class