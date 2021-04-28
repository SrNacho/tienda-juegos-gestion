Imports MySql.Data.MySqlClient
Public Class consultas
    Dim conexion As New MySqlConnection
    Public Sub alta(ByVal consulta As String)
        Dim sql As MySqlCommand
        Try
            conexion.ConnectionString = "server=localhost;userid=root;password=;database=juegos"
            conexion.Open()
            sql = New MySqlCommand(consulta, conexion)
            sql.ExecuteNonQuery() 'ejecuta la consulta de arriba sin que devuelva resultado
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function valNum(ByVal num As String)
        Dim c As Integer
        Dim p = num.Length
        Dim b As Char
        Dim h As Integer
        For i = 1 To p
            b = GetChar(num, i)
            h = Asc(b)
            If h >= 48 And h <= 57 Then
                c += 1
            End If

        Next
        If c = p And Not p = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function valLetras(ByVal str As String)
        Dim c As Integer
        Dim p = str.Length
        Dim b As Char
        Dim h As Integer
        For i = 1 To p
            b = GetChar(str, i)
            h = Asc(b)
            If h >= 65 And h <= 90 Then
                c += 1
            End If

        Next
        If c = p And Not p = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function valLetrasYNum(ByVal str As String)
        Dim c As Integer
        Dim m As Integer
        Dim p = str.Length
        Dim b As Char
        Dim h As Integer
        For i = 1 To p
            b = GetChar(str, i)
            h = Asc(b)
            If h >= 65 And h <= 90 Then
                c += 1
            ElseIf h >= 48 And h <= 57 Then
                m += 1
            End If

        Next
        c = c + m
        If c = p And Not p = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub relo()
        modifijuego.Show()
    End Sub
    Public Sub relocon()
        modificacionconsola.Show()
    End Sub
    Public Sub reloven()
        venta.Show()
    End Sub
End Class
